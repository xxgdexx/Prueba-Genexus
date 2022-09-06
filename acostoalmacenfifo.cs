using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class acostoalmacenfifo : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         GXKey = Crypto.GetSiteKey( );
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "ACOSTOALMACENFIFO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSalFCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public acostoalmacenfifo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public acostoalmacenfifo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ACOSTOALMACENFIFO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosAlmCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosAlmCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2SalFCosAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSalFCosAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2SalFCosAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2SalFCosAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosAlmAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosAlmAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosAlmAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3SalFCosAlmAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtSalFCosAlmAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A3SalFCosAlmAno), "ZZZ9") : context.localUtil.Format( (decimal)(A3SalFCosAlmAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosAlmAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosAlmAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosAlmMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosAlmMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosAlmMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SalFCosAlmMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtSalFCosAlmMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A4SalFCosAlmMes), "Z9") : context.localUtil.Format( (decimal)(A4SalFCosAlmMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosAlmMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosAlmMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosMVTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosMVTip_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosMVTip_Internalname, A5SalFCosMVTip, StringUtil.RTrim( context.localUtil.Format( A5SalFCosMVTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosMVTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosMVTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosMVCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosMVCod_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosMVCod_Internalname, A6SalFCosMVCod, StringUtil.RTrim( context.localUtil.Format( A6SalFCosMVCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosMVCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosMVCod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosProdCod_Internalname, A7SalFCosProdCod, StringUtil.RTrim( context.localUtil.Format( A7SalFCosProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSalFCosFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSalFCosFecha_Internalname, context.localUtil.Format(A1835SalFCosFecha, "99/99/99"), context.localUtil.Format( A1835SalFCosFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_bitmap( context, edtSalFCosFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSalFCosFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACOSTOALMACENFIFO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosCant_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosCant_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1832SalFCosCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalFCosCant_Enabled!=0) ? context.localUtil.Format( A1832SalFCosCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1832SalFCosCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosUnit_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosUnit_Internalname, "Unitario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosUnit_Internalname, StringUtil.LTrim( StringUtil.NToC( A1837SalFCosUnit, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalFCosUnit_Enabled!=0) ? context.localUtil.Format( A1837SalFCosUnit, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1837SalFCosUnit, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosUnit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosUnit_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosTot_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1836SalFCosTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtSalFCosTot_Enabled!=0) ? context.localUtil.Format( A1836SalFCosTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1836SalFCosTot, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosCantFifo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosCantFifo_Internalname, "Fifo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalFCosCantFifo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1833SalFCosCantFifo, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalFCosCantFifo_Enabled!=0) ? context.localUtil.Format( A1833SalFCosCantFifo, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1833SalFCosCantFifo, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosCantFifo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosCantFifo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalFCosCantSaldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalFCosCantSaldo_Internalname, "Saldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSalFCosCantSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1834SalFCosCantSaldo, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalFCosCantSaldo_Enabled!=0) ? context.localUtil.Format( A1834SalFCosCantSaldo, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1834SalFCosCantSaldo, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalFCosCantSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalFCosCantSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACOSTOALMACENFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z2SalFCosAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z2SalFCosAlmCod"), ".", ","));
            Z3SalFCosAlmAno = (short)(context.localUtil.CToN( cgiGet( "Z3SalFCosAlmAno"), ".", ","));
            Z4SalFCosAlmMes = (short)(context.localUtil.CToN( cgiGet( "Z4SalFCosAlmMes"), ".", ","));
            Z5SalFCosMVTip = cgiGet( "Z5SalFCosMVTip");
            Z6SalFCosMVCod = cgiGet( "Z6SalFCosMVCod");
            Z7SalFCosProdCod = cgiGet( "Z7SalFCosProdCod");
            Z1835SalFCosFecha = context.localUtil.CToD( cgiGet( "Z1835SalFCosFecha"), 0);
            Z1832SalFCosCant = context.localUtil.CToN( cgiGet( "Z1832SalFCosCant"), ".", ",");
            Z1837SalFCosUnit = context.localUtil.CToN( cgiGet( "Z1837SalFCosUnit"), ".", ",");
            Z1836SalFCosTot = context.localUtil.CToN( cgiGet( "Z1836SalFCosTot"), ".", ",");
            Z1833SalFCosCantFifo = context.localUtil.CToN( cgiGet( "Z1833SalFCosCantFifo"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSALMCOD");
               AnyError = 1;
               GX_FocusControl = edtSalFCosAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2SalFCosAlmCod = 0;
               AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            }
            else
            {
               A2SalFCosAlmCod = (int)(context.localUtil.CToN( cgiGet( edtSalFCosAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSALMANO");
               AnyError = 1;
               GX_FocusControl = edtSalFCosAlmAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A3SalFCosAlmAno = 0;
               AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            }
            else
            {
               A3SalFCosAlmAno = (short)(context.localUtil.CToN( cgiGet( edtSalFCosAlmAno_Internalname), ".", ","));
               AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosAlmMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSALMMES");
               AnyError = 1;
               GX_FocusControl = edtSalFCosAlmMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A4SalFCosAlmMes = 0;
               AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            }
            else
            {
               A4SalFCosAlmMes = (short)(context.localUtil.CToN( cgiGet( edtSalFCosAlmMes_Internalname), ".", ","));
               AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            }
            A5SalFCosMVTip = cgiGet( edtSalFCosMVTip_Internalname);
            AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
            A6SalFCosMVCod = cgiGet( edtSalFCosMVCod_Internalname);
            AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
            A7SalFCosProdCod = cgiGet( edtSalFCosProdCod_Internalname);
            AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
            if ( context.localUtil.VCDate( cgiGet( edtSalFCosFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "SALFCOSFECHA");
               AnyError = 1;
               GX_FocusControl = edtSalFCosFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1835SalFCosFecha = DateTime.MinValue;
               AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
            }
            else
            {
               A1835SalFCosFecha = context.localUtil.CToD( cgiGet( edtSalFCosFecha_Internalname), 2);
               AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSCANT");
               AnyError = 1;
               GX_FocusControl = edtSalFCosCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1832SalFCosCant = 0;
               AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrimStr( A1832SalFCosCant, 15, 4));
            }
            else
            {
               A1832SalFCosCant = context.localUtil.CToN( cgiGet( edtSalFCosCant_Internalname), ".", ",");
               AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrimStr( A1832SalFCosCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosUnit_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosUnit_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSUNIT");
               AnyError = 1;
               GX_FocusControl = edtSalFCosUnit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1837SalFCosUnit = 0;
               AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrimStr( A1837SalFCosUnit, 15, 4));
            }
            else
            {
               A1837SalFCosUnit = context.localUtil.CToN( cgiGet( edtSalFCosUnit_Internalname), ".", ",");
               AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrimStr( A1837SalFCosUnit, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosTot_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosTot_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSTOT");
               AnyError = 1;
               GX_FocusControl = edtSalFCosTot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1836SalFCosTot = 0;
               AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrimStr( A1836SalFCosTot, 15, 2));
            }
            else
            {
               A1836SalFCosTot = context.localUtil.CToN( cgiGet( edtSalFCosTot_Internalname), ".", ",");
               AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrimStr( A1836SalFCosTot, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalFCosCantFifo_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalFCosCantFifo_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALFCOSCANTFIFO");
               AnyError = 1;
               GX_FocusControl = edtSalFCosCantFifo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1833SalFCosCantFifo = 0;
               AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrimStr( A1833SalFCosCantFifo, 15, 4));
            }
            else
            {
               A1833SalFCosCantFifo = context.localUtil.CToN( cgiGet( edtSalFCosCantFifo_Internalname), ".", ",");
               AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrimStr( A1833SalFCosCantFifo, 15, 4));
            }
            A1834SalFCosCantSaldo = context.localUtil.CToN( cgiGet( edtSalFCosCantSaldo_Internalname), ".", ",");
            AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrimStr( A1834SalFCosCantSaldo, 15, 4));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A2SalFCosAlmCod = (int)(NumberUtil.Val( GetPar( "SalFCosAlmCod"), "."));
               AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
               A3SalFCosAlmAno = (short)(NumberUtil.Val( GetPar( "SalFCosAlmAno"), "."));
               AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
               A4SalFCosAlmMes = (short)(NumberUtil.Val( GetPar( "SalFCosAlmMes"), "."));
               AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
               A5SalFCosMVTip = GetPar( "SalFCosMVTip");
               AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
               A6SalFCosMVCod = GetPar( "SalFCosMVCod");
               AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
               A7SalFCosProdCod = GetPar( "SalFCosProdCod");
               AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes011( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1835SalFCosFecha = T00013_A1835SalFCosFecha[0];
               Z1832SalFCosCant = T00013_A1832SalFCosCant[0];
               Z1837SalFCosUnit = T00013_A1837SalFCosUnit[0];
               Z1836SalFCosTot = T00013_A1836SalFCosTot[0];
               Z1833SalFCosCantFifo = T00013_A1833SalFCosCantFifo[0];
            }
            else
            {
               Z1835SalFCosFecha = A1835SalFCosFecha;
               Z1832SalFCosCant = A1832SalFCosCant;
               Z1837SalFCosUnit = A1837SalFCosUnit;
               Z1836SalFCosTot = A1836SalFCosTot;
               Z1833SalFCosCantFifo = A1833SalFCosCantFifo;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2SalFCosAlmCod = A2SalFCosAlmCod;
            Z3SalFCosAlmAno = A3SalFCosAlmAno;
            Z4SalFCosAlmMes = A4SalFCosAlmMes;
            Z5SalFCosMVTip = A5SalFCosMVTip;
            Z6SalFCosMVCod = A6SalFCosMVCod;
            Z7SalFCosProdCod = A7SalFCosProdCod;
            Z1835SalFCosFecha = A1835SalFCosFecha;
            Z1832SalFCosCant = A1832SalFCosCant;
            Z1837SalFCosUnit = A1837SalFCosUnit;
            Z1836SalFCosTot = A1836SalFCosTot;
            Z1833SalFCosCantFifo = A1833SalFCosCantFifo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A1835SalFCosFecha = T00014_A1835SalFCosFecha[0];
            AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
            A1832SalFCosCant = T00014_A1832SalFCosCant[0];
            AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrimStr( A1832SalFCosCant, 15, 4));
            A1837SalFCosUnit = T00014_A1837SalFCosUnit[0];
            AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrimStr( A1837SalFCosUnit, 15, 4));
            A1836SalFCosTot = T00014_A1836SalFCosTot[0];
            AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrimStr( A1836SalFCosTot, 15, 2));
            A1833SalFCosCantFifo = T00014_A1833SalFCosCantFifo[0];
            AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrimStr( A1833SalFCosCantFifo, 15, 4));
            ZM011( -3) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         A1834SalFCosCantSaldo = (decimal)(A1832SalFCosCant-A1833SalFCosCantFifo);
         AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrimStr( A1834SalFCosCantSaldo, 15, 4));
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1835SalFCosFecha) || ( DateTimeUtil.ResetTime ( A1835SalFCosFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "SALFCOSFECHA");
            AnyError = 1;
            GX_FocusControl = edtSalFCosFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_1 = 1;
         A1834SalFCosCantSaldo = (decimal)(A1832SalFCosCant-A1833SalFCosCantFifo);
         AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrimStr( A1834SalFCosCantSaldo, 15, 4));
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 3) ;
            RcdFound1 = 1;
            A2SalFCosAlmCod = T00013_A2SalFCosAlmCod[0];
            AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            A3SalFCosAlmAno = T00013_A3SalFCosAlmAno[0];
            AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            A4SalFCosAlmMes = T00013_A4SalFCosAlmMes[0];
            AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            A5SalFCosMVTip = T00013_A5SalFCosMVTip[0];
            AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
            A6SalFCosMVCod = T00013_A6SalFCosMVCod[0];
            AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
            A7SalFCosProdCod = T00013_A7SalFCosProdCod[0];
            AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
            A1835SalFCosFecha = T00013_A1835SalFCosFecha[0];
            AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
            A1832SalFCosCant = T00013_A1832SalFCosCant[0];
            AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrimStr( A1832SalFCosCant, 15, 4));
            A1837SalFCosUnit = T00013_A1837SalFCosUnit[0];
            AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrimStr( A1837SalFCosUnit, 15, 4));
            A1836SalFCosTot = T00013_A1836SalFCosTot[0];
            AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrimStr( A1836SalFCosTot, 15, 2));
            A1833SalFCosCantFifo = T00013_A1833SalFCosCantFifo[0];
            AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrimStr( A1833SalFCosCantFifo, 15, 4));
            Z2SalFCosAlmCod = A2SalFCosAlmCod;
            Z3SalFCosAlmAno = A3SalFCosAlmAno;
            Z4SalFCosAlmMes = A4SalFCosAlmMes;
            Z5SalFCosMVTip = A5SalFCosMVTip;
            Z6SalFCosMVCod = A6SalFCosMVCod;
            Z7SalFCosProdCod = A7SalFCosProdCod;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00016_A2SalFCosAlmCod[0] < A2SalFCosAlmCod ) || ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00016_A3SalFCosAlmAno[0] < A3SalFCosAlmAno ) || ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00016_A4SalFCosAlmMes[0] < A4SalFCosAlmMes ) || ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) < 0 ) || ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A6SalFCosMVCod[0], A6SalFCosMVCod) < 0 ) || ( StringUtil.StrCmp(T00016_A6SalFCosMVCod[0], A6SalFCosMVCod) == 0 ) && ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A7SalFCosProdCod[0], A7SalFCosProdCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00016_A2SalFCosAlmCod[0] > A2SalFCosAlmCod ) || ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00016_A3SalFCosAlmAno[0] > A3SalFCosAlmAno ) || ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00016_A4SalFCosAlmMes[0] > A4SalFCosAlmMes ) || ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) > 0 ) || ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A6SalFCosMVCod[0], A6SalFCosMVCod) > 0 ) || ( StringUtil.StrCmp(T00016_A6SalFCosMVCod[0], A6SalFCosMVCod) == 0 ) && ( StringUtil.StrCmp(T00016_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00016_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00016_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00016_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00016_A7SalFCosProdCod[0], A7SalFCosProdCod) > 0 ) ) )
            {
               A2SalFCosAlmCod = T00016_A2SalFCosAlmCod[0];
               AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
               A3SalFCosAlmAno = T00016_A3SalFCosAlmAno[0];
               AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
               A4SalFCosAlmMes = T00016_A4SalFCosAlmMes[0];
               AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
               A5SalFCosMVTip = T00016_A5SalFCosMVTip[0];
               AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
               A6SalFCosMVCod = T00016_A6SalFCosMVCod[0];
               AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
               A7SalFCosProdCod = T00016_A7SalFCosProdCod[0];
               AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00017_A2SalFCosAlmCod[0] > A2SalFCosAlmCod ) || ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00017_A3SalFCosAlmAno[0] > A3SalFCosAlmAno ) || ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00017_A4SalFCosAlmMes[0] > A4SalFCosAlmMes ) || ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) > 0 ) || ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A6SalFCosMVCod[0], A6SalFCosMVCod) > 0 ) || ( StringUtil.StrCmp(T00017_A6SalFCosMVCod[0], A6SalFCosMVCod) == 0 ) && ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A7SalFCosProdCod[0], A7SalFCosProdCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00017_A2SalFCosAlmCod[0] < A2SalFCosAlmCod ) || ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00017_A3SalFCosAlmAno[0] < A3SalFCosAlmAno ) || ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( T00017_A4SalFCosAlmMes[0] < A4SalFCosAlmMes ) || ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) < 0 ) || ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A6SalFCosMVCod[0], A6SalFCosMVCod) < 0 ) || ( StringUtil.StrCmp(T00017_A6SalFCosMVCod[0], A6SalFCosMVCod) == 0 ) && ( StringUtil.StrCmp(T00017_A5SalFCosMVTip[0], A5SalFCosMVTip) == 0 ) && ( T00017_A4SalFCosAlmMes[0] == A4SalFCosAlmMes ) && ( T00017_A3SalFCosAlmAno[0] == A3SalFCosAlmAno ) && ( T00017_A2SalFCosAlmCod[0] == A2SalFCosAlmCod ) && ( StringUtil.StrCmp(T00017_A7SalFCosProdCod[0], A7SalFCosProdCod) < 0 ) ) )
            {
               A2SalFCosAlmCod = T00017_A2SalFCosAlmCod[0];
               AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
               A3SalFCosAlmAno = T00017_A3SalFCosAlmAno[0];
               AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
               A4SalFCosAlmMes = T00017_A4SalFCosAlmMes[0];
               AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
               A5SalFCosMVTip = T00017_A5SalFCosMVTip[0];
               AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
               A6SalFCosMVCod = T00017_A6SalFCosMVCod[0];
               AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
               A7SalFCosProdCod = T00017_A7SalFCosProdCod[0];
               AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSalFCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( ( A2SalFCosAlmCod != Z2SalFCosAlmCod ) || ( A3SalFCosAlmAno != Z3SalFCosAlmAno ) || ( A4SalFCosAlmMes != Z4SalFCosAlmMes ) || ( StringUtil.StrCmp(A5SalFCosMVTip, Z5SalFCosMVTip) != 0 ) || ( StringUtil.StrCmp(A6SalFCosMVCod, Z6SalFCosMVCod) != 0 ) || ( StringUtil.StrCmp(A7SalFCosProdCod, Z7SalFCosProdCod) != 0 ) )
               {
                  A2SalFCosAlmCod = Z2SalFCosAlmCod;
                  AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
                  A3SalFCosAlmAno = Z3SalFCosAlmAno;
                  AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
                  A4SalFCosAlmMes = Z4SalFCosAlmMes;
                  AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
                  A5SalFCosMVTip = Z5SalFCosMVTip;
                  AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
                  A6SalFCosMVCod = Z6SalFCosMVCod;
                  AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
                  A7SalFCosProdCod = Z7SalFCosProdCod;
                  AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SALFCOSALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSalFCosAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSalFCosAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtSalFCosAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2SalFCosAlmCod != Z2SalFCosAlmCod ) || ( A3SalFCosAlmAno != Z3SalFCosAlmAno ) || ( A4SalFCosAlmMes != Z4SalFCosAlmMes ) || ( StringUtil.StrCmp(A5SalFCosMVTip, Z5SalFCosMVTip) != 0 ) || ( StringUtil.StrCmp(A6SalFCosMVCod, Z6SalFCosMVCod) != 0 ) || ( StringUtil.StrCmp(A7SalFCosProdCod, Z7SalFCosProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSalFCosAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SALFCOSALMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtSalFCosAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSalFCosAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( ( A2SalFCosAlmCod != Z2SalFCosAlmCod ) || ( A3SalFCosAlmAno != Z3SalFCosAlmAno ) || ( A4SalFCosAlmMes != Z4SalFCosAlmMes ) || ( StringUtil.StrCmp(A5SalFCosMVTip, Z5SalFCosMVTip) != 0 ) || ( StringUtil.StrCmp(A6SalFCosMVCod, Z6SalFCosMVCod) != 0 ) || ( StringUtil.StrCmp(A7SalFCosProdCod, Z7SalFCosProdCod) != 0 ) )
         {
            A2SalFCosAlmCod = Z2SalFCosAlmCod;
            AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            A3SalFCosAlmAno = Z3SalFCosAlmAno;
            AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            A4SalFCosAlmMes = Z4SalFCosAlmMes;
            AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            A5SalFCosMVTip = Z5SalFCosMVTip;
            AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
            A6SalFCosMVCod = Z6SalFCosMVCod;
            AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
            A7SalFCosProdCod = Z7SalFCosProdCod;
            AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SALFCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalFCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSalFCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SALFCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalFCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACOSTOALMACENFIFO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1835SalFCosFecha ) != DateTimeUtil.ResetTime ( T00012_A1835SalFCosFecha[0] ) ) || ( Z1832SalFCosCant != T00012_A1832SalFCosCant[0] ) || ( Z1837SalFCosUnit != T00012_A1837SalFCosUnit[0] ) || ( Z1836SalFCosTot != T00012_A1836SalFCosTot[0] ) || ( Z1833SalFCosCantFifo != T00012_A1833SalFCosCantFifo[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1835SalFCosFecha ) != DateTimeUtil.ResetTime ( T00012_A1835SalFCosFecha[0] ) )
               {
                  GXUtil.WriteLog("acostoalmacenfifo:[seudo value changed for attri]"+"SalFCosFecha");
                  GXUtil.WriteLogRaw("Old: ",Z1835SalFCosFecha);
                  GXUtil.WriteLogRaw("Current: ",T00012_A1835SalFCosFecha[0]);
               }
               if ( Z1832SalFCosCant != T00012_A1832SalFCosCant[0] )
               {
                  GXUtil.WriteLog("acostoalmacenfifo:[seudo value changed for attri]"+"SalFCosCant");
                  GXUtil.WriteLogRaw("Old: ",Z1832SalFCosCant);
                  GXUtil.WriteLogRaw("Current: ",T00012_A1832SalFCosCant[0]);
               }
               if ( Z1837SalFCosUnit != T00012_A1837SalFCosUnit[0] )
               {
                  GXUtil.WriteLog("acostoalmacenfifo:[seudo value changed for attri]"+"SalFCosUnit");
                  GXUtil.WriteLogRaw("Old: ",Z1837SalFCosUnit);
                  GXUtil.WriteLogRaw("Current: ",T00012_A1837SalFCosUnit[0]);
               }
               if ( Z1836SalFCosTot != T00012_A1836SalFCosTot[0] )
               {
                  GXUtil.WriteLog("acostoalmacenfifo:[seudo value changed for attri]"+"SalFCosTot");
                  GXUtil.WriteLogRaw("Old: ",Z1836SalFCosTot);
                  GXUtil.WriteLogRaw("Current: ",T00012_A1836SalFCosTot[0]);
               }
               if ( Z1833SalFCosCantFifo != T00012_A1833SalFCosCantFifo[0] )
               {
                  GXUtil.WriteLog("acostoalmacenfifo:[seudo value changed for attri]"+"SalFCosCantFifo");
                  GXUtil.WriteLogRaw("Old: ",Z1833SalFCosCantFifo);
                  GXUtil.WriteLogRaw("Current: ",T00012_A1833SalFCosCantFifo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACOSTOALMACENFIFO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod, A1835SalFCosFecha, A1832SalFCosCant, A1837SalFCosUnit, A1836SalFCosTot, A1833SalFCosCantFifo});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("ACOSTOALMACENFIFO");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {A1835SalFCosFecha, A1832SalFCosCant, A1837SalFCosUnit, A1836SalFCosTot, A1833SalFCosCantFifo, A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ACOSTOALMACENFIFO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACOSTOALMACENFIFO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption010( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A2SalFCosAlmCod, A3SalFCosAlmAno, A4SalFCosAlmMes, A5SalFCosMVTip, A6SalFCosMVCod, A7SalFCosProdCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("ACOSTOALMACENFIFO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound1 == 0 )
                        {
                           InitAll011( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption010( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1834SalFCosCantSaldo = (decimal)(A1832SalFCosCant-A1833SalFCosCantFifo);
            AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrimStr( A1834SalFCosCantSaldo, 15, 4));
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("acostoalmacenfifo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("acostoalmacenfifo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000111 */
         pr_default.execute(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A2SalFCosAlmCod = T000111_A2SalFCosAlmCod[0];
            AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            A3SalFCosAlmAno = T000111_A3SalFCosAlmAno[0];
            AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            A4SalFCosAlmMes = T000111_A4SalFCosAlmMes[0];
            AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            A5SalFCosMVTip = T000111_A5SalFCosMVTip[0];
            AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
            A6SalFCosMVCod = T000111_A6SalFCosMVCod[0];
            AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
            A7SalFCosProdCod = T000111_A7SalFCosProdCod[0];
            AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A2SalFCosAlmCod = T000111_A2SalFCosAlmCod[0];
            AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
            A3SalFCosAlmAno = T000111_A3SalFCosAlmAno[0];
            AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
            A4SalFCosAlmMes = T000111_A4SalFCosAlmMes[0];
            AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
            A5SalFCosMVTip = T000111_A5SalFCosMVTip[0];
            AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
            A6SalFCosMVCod = T000111_A6SalFCosMVCod[0];
            AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
            A7SalFCosProdCod = T000111_A7SalFCosProdCod[0];
            AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtSalFCosAlmCod_Enabled = 0;
         AssignProp("", false, edtSalFCosAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosAlmCod_Enabled), 5, 0), true);
         edtSalFCosAlmAno_Enabled = 0;
         AssignProp("", false, edtSalFCosAlmAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosAlmAno_Enabled), 5, 0), true);
         edtSalFCosAlmMes_Enabled = 0;
         AssignProp("", false, edtSalFCosAlmMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosAlmMes_Enabled), 5, 0), true);
         edtSalFCosMVTip_Enabled = 0;
         AssignProp("", false, edtSalFCosMVTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosMVTip_Enabled), 5, 0), true);
         edtSalFCosMVCod_Enabled = 0;
         AssignProp("", false, edtSalFCosMVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosMVCod_Enabled), 5, 0), true);
         edtSalFCosProdCod_Enabled = 0;
         AssignProp("", false, edtSalFCosProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosProdCod_Enabled), 5, 0), true);
         edtSalFCosFecha_Enabled = 0;
         AssignProp("", false, edtSalFCosFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosFecha_Enabled), 5, 0), true);
         edtSalFCosCant_Enabled = 0;
         AssignProp("", false, edtSalFCosCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosCant_Enabled), 5, 0), true);
         edtSalFCosUnit_Enabled = 0;
         AssignProp("", false, edtSalFCosUnit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosUnit_Enabled), 5, 0), true);
         edtSalFCosTot_Enabled = 0;
         AssignProp("", false, edtSalFCosTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosTot_Enabled), 5, 0), true);
         edtSalFCosCantFifo_Enabled = 0;
         AssignProp("", false, edtSalFCosCantFifo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosCantFifo_Enabled), 5, 0), true);
         edtSalFCosCantSaldo_Enabled = 0;
         AssignProp("", false, edtSalFCosCantSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalFCosCantSaldo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228181144756", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("acostoalmacenfifo.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2SalFCosAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2SalFCosAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3SalFCosAlmAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3SalFCosAlmAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4SalFCosAlmMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SalFCosAlmMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SalFCosMVTip", Z5SalFCosMVTip);
         GxWebStd.gx_hidden_field( context, "Z6SalFCosMVCod", Z6SalFCosMVCod);
         GxWebStd.gx_hidden_field( context, "Z7SalFCosProdCod", Z7SalFCosProdCod);
         GxWebStd.gx_hidden_field( context, "Z1835SalFCosFecha", context.localUtil.DToC( Z1835SalFCosFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1832SalFCosCant", StringUtil.LTrim( StringUtil.NToC( Z1832SalFCosCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1837SalFCosUnit", StringUtil.LTrim( StringUtil.NToC( Z1837SalFCosUnit, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1836SalFCosTot", StringUtil.LTrim( StringUtil.NToC( Z1836SalFCosTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1833SalFCosCantFifo", StringUtil.LTrim( StringUtil.NToC( Z1833SalFCosCantFifo, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("acostoalmacenfifo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACOSTOALMACENFIFO" ;
      }

      public override string GetPgmdesc( )
      {
         return "ACOSTOALMACENFIFO" ;
      }

      protected void InitializeNonKey011( )
      {
         A1834SalFCosCantSaldo = 0;
         AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrimStr( A1834SalFCosCantSaldo, 15, 4));
         A1835SalFCosFecha = DateTime.MinValue;
         AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
         A1832SalFCosCant = 0;
         AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrimStr( A1832SalFCosCant, 15, 4));
         A1837SalFCosUnit = 0;
         AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrimStr( A1837SalFCosUnit, 15, 4));
         A1836SalFCosTot = 0;
         AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrimStr( A1836SalFCosTot, 15, 2));
         A1833SalFCosCantFifo = 0;
         AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrimStr( A1833SalFCosCantFifo, 15, 4));
         Z1835SalFCosFecha = DateTime.MinValue;
         Z1832SalFCosCant = 0;
         Z1837SalFCosUnit = 0;
         Z1836SalFCosTot = 0;
         Z1833SalFCosCantFifo = 0;
      }

      protected void InitAll011( )
      {
         A2SalFCosAlmCod = 0;
         AssignAttri("", false, "A2SalFCosAlmCod", StringUtil.LTrimStr( (decimal)(A2SalFCosAlmCod), 6, 0));
         A3SalFCosAlmAno = 0;
         AssignAttri("", false, "A3SalFCosAlmAno", StringUtil.LTrimStr( (decimal)(A3SalFCosAlmAno), 4, 0));
         A4SalFCosAlmMes = 0;
         AssignAttri("", false, "A4SalFCosAlmMes", StringUtil.LTrimStr( (decimal)(A4SalFCosAlmMes), 2, 0));
         A5SalFCosMVTip = "";
         AssignAttri("", false, "A5SalFCosMVTip", A5SalFCosMVTip);
         A6SalFCosMVCod = "";
         AssignAttri("", false, "A6SalFCosMVCod", A6SalFCosMVCod);
         A7SalFCosProdCod = "";
         AssignAttri("", false, "A7SalFCosProdCod", A7SalFCosProdCod);
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181144766", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("acostoalmacenfifo.js", "?20228181144766", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtSalFCosAlmCod_Internalname = "SALFCOSALMCOD";
         edtSalFCosAlmAno_Internalname = "SALFCOSALMANO";
         edtSalFCosAlmMes_Internalname = "SALFCOSALMMES";
         edtSalFCosMVTip_Internalname = "SALFCOSMVTIP";
         edtSalFCosMVCod_Internalname = "SALFCOSMVCOD";
         edtSalFCosProdCod_Internalname = "SALFCOSPRODCOD";
         edtSalFCosFecha_Internalname = "SALFCOSFECHA";
         edtSalFCosCant_Internalname = "SALFCOSCANT";
         edtSalFCosUnit_Internalname = "SALFCOSUNIT";
         edtSalFCosTot_Internalname = "SALFCOSTOT";
         edtSalFCosCantFifo_Internalname = "SALFCOSCANTFIFO";
         edtSalFCosCantSaldo_Internalname = "SALFCOSCANTSALDO";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "ACOSTOALMACENFIFO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSalFCosCantSaldo_Jsonclick = "";
         edtSalFCosCantSaldo_Enabled = 0;
         edtSalFCosCantFifo_Jsonclick = "";
         edtSalFCosCantFifo_Enabled = 1;
         edtSalFCosTot_Jsonclick = "";
         edtSalFCosTot_Enabled = 1;
         edtSalFCosUnit_Jsonclick = "";
         edtSalFCosUnit_Enabled = 1;
         edtSalFCosCant_Jsonclick = "";
         edtSalFCosCant_Enabled = 1;
         edtSalFCosFecha_Jsonclick = "";
         edtSalFCosFecha_Enabled = 1;
         edtSalFCosProdCod_Jsonclick = "";
         edtSalFCosProdCod_Enabled = 1;
         edtSalFCosMVCod_Jsonclick = "";
         edtSalFCosMVCod_Enabled = 1;
         edtSalFCosMVTip_Jsonclick = "";
         edtSalFCosMVTip_Enabled = 1;
         edtSalFCosAlmMes_Jsonclick = "";
         edtSalFCosAlmMes_Enabled = 1;
         edtSalFCosAlmAno_Jsonclick = "";
         edtSalFCosAlmAno_Enabled = 1;
         edtSalFCosAlmCod_Jsonclick = "";
         edtSalFCosAlmCod_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSalFCosFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Salfcosprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1835SalFCosFecha", context.localUtil.Format(A1835SalFCosFecha, "99/99/99"));
         AssignAttri("", false, "A1832SalFCosCant", StringUtil.LTrim( StringUtil.NToC( A1832SalFCosCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1837SalFCosUnit", StringUtil.LTrim( StringUtil.NToC( A1837SalFCosUnit, 15, 4, ".", "")));
         AssignAttri("", false, "A1836SalFCosTot", StringUtil.LTrim( StringUtil.NToC( A1836SalFCosTot, 15, 2, ".", "")));
         AssignAttri("", false, "A1833SalFCosCantFifo", StringUtil.LTrim( StringUtil.NToC( A1833SalFCosCantFifo, 15, 4, ".", "")));
         AssignAttri("", false, "A1834SalFCosCantSaldo", StringUtil.LTrim( StringUtil.NToC( A1834SalFCosCantSaldo, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2SalFCosAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2SalFCosAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3SalFCosAlmAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3SalFCosAlmAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4SalFCosAlmMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SalFCosAlmMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SalFCosMVTip", Z5SalFCosMVTip);
         GxWebStd.gx_hidden_field( context, "Z6SalFCosMVCod", Z6SalFCosMVCod);
         GxWebStd.gx_hidden_field( context, "Z7SalFCosProdCod", Z7SalFCosProdCod);
         GxWebStd.gx_hidden_field( context, "Z1835SalFCosFecha", context.localUtil.Format(Z1835SalFCosFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1832SalFCosCant", StringUtil.LTrim( StringUtil.NToC( Z1832SalFCosCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1837SalFCosUnit", StringUtil.LTrim( StringUtil.NToC( Z1837SalFCosUnit, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1836SalFCosTot", StringUtil.LTrim( StringUtil.NToC( Z1836SalFCosTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1833SalFCosCantFifo", StringUtil.LTrim( StringUtil.NToC( Z1833SalFCosCantFifo, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1834SalFCosCantSaldo", StringUtil.LTrim( StringUtil.NToC( Z1834SalFCosCantSaldo, 15, 4, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSALMCOD","{handler:'Valid_Salfcosalmcod',iparms:[]");
         setEventMetadata("VALID_SALFCOSALMCOD",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSALMANO","{handler:'Valid_Salfcosalmano',iparms:[]");
         setEventMetadata("VALID_SALFCOSALMANO",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSALMMES","{handler:'Valid_Salfcosalmmes',iparms:[]");
         setEventMetadata("VALID_SALFCOSALMMES",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSMVTIP","{handler:'Valid_Salfcosmvtip',iparms:[]");
         setEventMetadata("VALID_SALFCOSMVTIP",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSMVCOD","{handler:'Valid_Salfcosmvcod',iparms:[]");
         setEventMetadata("VALID_SALFCOSMVCOD",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSPRODCOD","{handler:'Valid_Salfcosprodcod',iparms:[{av:'A2SalFCosAlmCod',fld:'SALFCOSALMCOD',pic:'ZZZZZ9'},{av:'A3SalFCosAlmAno',fld:'SALFCOSALMANO',pic:'ZZZ9'},{av:'A4SalFCosAlmMes',fld:'SALFCOSALMMES',pic:'Z9'},{av:'A5SalFCosMVTip',fld:'SALFCOSMVTIP',pic:''},{av:'A6SalFCosMVCod',fld:'SALFCOSMVCOD',pic:''},{av:'A7SalFCosProdCod',fld:'SALFCOSPRODCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SALFCOSPRODCOD",",oparms:[{av:'A1835SalFCosFecha',fld:'SALFCOSFECHA',pic:''},{av:'A1832SalFCosCant',fld:'SALFCOSCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1837SalFCosUnit',fld:'SALFCOSUNIT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1836SalFCosTot',fld:'SALFCOSTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1833SalFCosCantFifo',fld:'SALFCOSCANTFIFO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1834SalFCosCantSaldo',fld:'SALFCOSCANTSALDO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2SalFCosAlmCod'},{av:'Z3SalFCosAlmAno'},{av:'Z4SalFCosAlmMes'},{av:'Z5SalFCosMVTip'},{av:'Z6SalFCosMVCod'},{av:'Z7SalFCosProdCod'},{av:'Z1835SalFCosFecha'},{av:'Z1832SalFCosCant'},{av:'Z1837SalFCosUnit'},{av:'Z1836SalFCosTot'},{av:'Z1833SalFCosCantFifo'},{av:'Z1834SalFCosCantSaldo'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SALFCOSFECHA","{handler:'Valid_Salfcosfecha',iparms:[]");
         setEventMetadata("VALID_SALFCOSFECHA",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSCANT","{handler:'Valid_Salfcoscant',iparms:[]");
         setEventMetadata("VALID_SALFCOSCANT",",oparms:[]}");
         setEventMetadata("VALID_SALFCOSCANTFIFO","{handler:'Valid_Salfcoscantfifo',iparms:[]");
         setEventMetadata("VALID_SALFCOSCANTFIFO",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z5SalFCosMVTip = "";
         Z6SalFCosMVCod = "";
         Z7SalFCosProdCod = "";
         Z1835SalFCosFecha = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A5SalFCosMVTip = "";
         A6SalFCosMVCod = "";
         A7SalFCosProdCod = "";
         A1835SalFCosFecha = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00014_A2SalFCosAlmCod = new int[1] ;
         T00014_A3SalFCosAlmAno = new short[1] ;
         T00014_A4SalFCosAlmMes = new short[1] ;
         T00014_A5SalFCosMVTip = new string[] {""} ;
         T00014_A6SalFCosMVCod = new string[] {""} ;
         T00014_A7SalFCosProdCod = new string[] {""} ;
         T00014_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         T00014_A1832SalFCosCant = new decimal[1] ;
         T00014_A1837SalFCosUnit = new decimal[1] ;
         T00014_A1836SalFCosTot = new decimal[1] ;
         T00014_A1833SalFCosCantFifo = new decimal[1] ;
         T00015_A2SalFCosAlmCod = new int[1] ;
         T00015_A3SalFCosAlmAno = new short[1] ;
         T00015_A4SalFCosAlmMes = new short[1] ;
         T00015_A5SalFCosMVTip = new string[] {""} ;
         T00015_A6SalFCosMVCod = new string[] {""} ;
         T00015_A7SalFCosProdCod = new string[] {""} ;
         T00013_A2SalFCosAlmCod = new int[1] ;
         T00013_A3SalFCosAlmAno = new short[1] ;
         T00013_A4SalFCosAlmMes = new short[1] ;
         T00013_A5SalFCosMVTip = new string[] {""} ;
         T00013_A6SalFCosMVCod = new string[] {""} ;
         T00013_A7SalFCosProdCod = new string[] {""} ;
         T00013_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         T00013_A1832SalFCosCant = new decimal[1] ;
         T00013_A1837SalFCosUnit = new decimal[1] ;
         T00013_A1836SalFCosTot = new decimal[1] ;
         T00013_A1833SalFCosCantFifo = new decimal[1] ;
         sMode1 = "";
         T00016_A2SalFCosAlmCod = new int[1] ;
         T00016_A3SalFCosAlmAno = new short[1] ;
         T00016_A4SalFCosAlmMes = new short[1] ;
         T00016_A5SalFCosMVTip = new string[] {""} ;
         T00016_A6SalFCosMVCod = new string[] {""} ;
         T00016_A7SalFCosProdCod = new string[] {""} ;
         T00017_A2SalFCosAlmCod = new int[1] ;
         T00017_A3SalFCosAlmAno = new short[1] ;
         T00017_A4SalFCosAlmMes = new short[1] ;
         T00017_A5SalFCosMVTip = new string[] {""} ;
         T00017_A6SalFCosMVCod = new string[] {""} ;
         T00017_A7SalFCosProdCod = new string[] {""} ;
         T00012_A2SalFCosAlmCod = new int[1] ;
         T00012_A3SalFCosAlmAno = new short[1] ;
         T00012_A4SalFCosAlmMes = new short[1] ;
         T00012_A5SalFCosMVTip = new string[] {""} ;
         T00012_A6SalFCosMVCod = new string[] {""} ;
         T00012_A7SalFCosProdCod = new string[] {""} ;
         T00012_A1835SalFCosFecha = new DateTime[] {DateTime.MinValue} ;
         T00012_A1832SalFCosCant = new decimal[1] ;
         T00012_A1837SalFCosUnit = new decimal[1] ;
         T00012_A1836SalFCosTot = new decimal[1] ;
         T00012_A1833SalFCosCantFifo = new decimal[1] ;
         T000111_A2SalFCosAlmCod = new int[1] ;
         T000111_A3SalFCosAlmAno = new short[1] ;
         T000111_A4SalFCosAlmMes = new short[1] ;
         T000111_A5SalFCosMVTip = new string[] {""} ;
         T000111_A6SalFCosMVCod = new string[] {""} ;
         T000111_A7SalFCosProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ5SalFCosMVTip = "";
         ZZ6SalFCosMVCod = "";
         ZZ7SalFCosProdCod = "";
         ZZ1835SalFCosFecha = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.acostoalmacenfifo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acostoalmacenfifo__default(),
            new Object[][] {
                new Object[] {
               T00012_A2SalFCosAlmCod, T00012_A3SalFCosAlmAno, T00012_A4SalFCosAlmMes, T00012_A5SalFCosMVTip, T00012_A6SalFCosMVCod, T00012_A7SalFCosProdCod, T00012_A1835SalFCosFecha, T00012_A1832SalFCosCant, T00012_A1837SalFCosUnit, T00012_A1836SalFCosTot,
               T00012_A1833SalFCosCantFifo
               }
               , new Object[] {
               T00013_A2SalFCosAlmCod, T00013_A3SalFCosAlmAno, T00013_A4SalFCosAlmMes, T00013_A5SalFCosMVTip, T00013_A6SalFCosMVCod, T00013_A7SalFCosProdCod, T00013_A1835SalFCosFecha, T00013_A1832SalFCosCant, T00013_A1837SalFCosUnit, T00013_A1836SalFCosTot,
               T00013_A1833SalFCosCantFifo
               }
               , new Object[] {
               T00014_A2SalFCosAlmCod, T00014_A3SalFCosAlmAno, T00014_A4SalFCosAlmMes, T00014_A5SalFCosMVTip, T00014_A6SalFCosMVCod, T00014_A7SalFCosProdCod, T00014_A1835SalFCosFecha, T00014_A1832SalFCosCant, T00014_A1837SalFCosUnit, T00014_A1836SalFCosTot,
               T00014_A1833SalFCosCantFifo
               }
               , new Object[] {
               T00015_A2SalFCosAlmCod, T00015_A3SalFCosAlmAno, T00015_A4SalFCosAlmMes, T00015_A5SalFCosMVTip, T00015_A6SalFCosMVCod, T00015_A7SalFCosProdCod
               }
               , new Object[] {
               T00016_A2SalFCosAlmCod, T00016_A3SalFCosAlmAno, T00016_A4SalFCosAlmMes, T00016_A5SalFCosMVTip, T00016_A6SalFCosMVCod, T00016_A7SalFCosProdCod
               }
               , new Object[] {
               T00017_A2SalFCosAlmCod, T00017_A3SalFCosAlmAno, T00017_A4SalFCosAlmMes, T00017_A5SalFCosMVTip, T00017_A6SalFCosMVCod, T00017_A7SalFCosProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A2SalFCosAlmCod, T000111_A3SalFCosAlmAno, T000111_A4SalFCosAlmMes, T000111_A5SalFCosMVTip, T000111_A6SalFCosMVCod, T000111_A7SalFCosProdCod
               }
            }
         );
      }

      private short Z3SalFCosAlmAno ;
      private short Z4SalFCosAlmMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A3SalFCosAlmAno ;
      private short A4SalFCosAlmMes ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ3SalFCosAlmAno ;
      private short ZZ4SalFCosAlmMes ;
      private int Z2SalFCosAlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A2SalFCosAlmCod ;
      private int edtSalFCosAlmCod_Enabled ;
      private int edtSalFCosAlmAno_Enabled ;
      private int edtSalFCosAlmMes_Enabled ;
      private int edtSalFCosMVTip_Enabled ;
      private int edtSalFCosMVCod_Enabled ;
      private int edtSalFCosProdCod_Enabled ;
      private int edtSalFCosFecha_Enabled ;
      private int edtSalFCosCant_Enabled ;
      private int edtSalFCosUnit_Enabled ;
      private int edtSalFCosTot_Enabled ;
      private int edtSalFCosCantFifo_Enabled ;
      private int edtSalFCosCantSaldo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2SalFCosAlmCod ;
      private decimal Z1832SalFCosCant ;
      private decimal Z1837SalFCosUnit ;
      private decimal Z1836SalFCosTot ;
      private decimal Z1833SalFCosCantFifo ;
      private decimal A1832SalFCosCant ;
      private decimal A1837SalFCosUnit ;
      private decimal A1836SalFCosTot ;
      private decimal A1833SalFCosCantFifo ;
      private decimal A1834SalFCosCantSaldo ;
      private decimal Z1834SalFCosCantSaldo ;
      private decimal ZZ1832SalFCosCant ;
      private decimal ZZ1837SalFCosUnit ;
      private decimal ZZ1836SalFCosTot ;
      private decimal ZZ1833SalFCosCantFifo ;
      private decimal ZZ1834SalFCosCantSaldo ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSalFCosAlmCod_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSalFCosAlmCod_Jsonclick ;
      private string edtSalFCosAlmAno_Internalname ;
      private string edtSalFCosAlmAno_Jsonclick ;
      private string edtSalFCosAlmMes_Internalname ;
      private string edtSalFCosAlmMes_Jsonclick ;
      private string edtSalFCosMVTip_Internalname ;
      private string edtSalFCosMVTip_Jsonclick ;
      private string edtSalFCosMVCod_Internalname ;
      private string edtSalFCosMVCod_Jsonclick ;
      private string edtSalFCosProdCod_Internalname ;
      private string edtSalFCosProdCod_Jsonclick ;
      private string edtSalFCosFecha_Internalname ;
      private string edtSalFCosFecha_Jsonclick ;
      private string edtSalFCosCant_Internalname ;
      private string edtSalFCosCant_Jsonclick ;
      private string edtSalFCosUnit_Internalname ;
      private string edtSalFCosUnit_Jsonclick ;
      private string edtSalFCosTot_Internalname ;
      private string edtSalFCosTot_Jsonclick ;
      private string edtSalFCosCantFifo_Internalname ;
      private string edtSalFCosCantFifo_Jsonclick ;
      private string edtSalFCosCantSaldo_Internalname ;
      private string edtSalFCosCantSaldo_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z1835SalFCosFecha ;
      private DateTime A1835SalFCosFecha ;
      private DateTime ZZ1835SalFCosFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z5SalFCosMVTip ;
      private string Z6SalFCosMVCod ;
      private string Z7SalFCosProdCod ;
      private string A5SalFCosMVTip ;
      private string A6SalFCosMVCod ;
      private string A7SalFCosProdCod ;
      private string ZZ5SalFCosMVTip ;
      private string ZZ6SalFCosMVCod ;
      private string ZZ7SalFCosProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00014_A2SalFCosAlmCod ;
      private short[] T00014_A3SalFCosAlmAno ;
      private short[] T00014_A4SalFCosAlmMes ;
      private string[] T00014_A5SalFCosMVTip ;
      private string[] T00014_A6SalFCosMVCod ;
      private string[] T00014_A7SalFCosProdCod ;
      private DateTime[] T00014_A1835SalFCosFecha ;
      private decimal[] T00014_A1832SalFCosCant ;
      private decimal[] T00014_A1837SalFCosUnit ;
      private decimal[] T00014_A1836SalFCosTot ;
      private decimal[] T00014_A1833SalFCosCantFifo ;
      private int[] T00015_A2SalFCosAlmCod ;
      private short[] T00015_A3SalFCosAlmAno ;
      private short[] T00015_A4SalFCosAlmMes ;
      private string[] T00015_A5SalFCosMVTip ;
      private string[] T00015_A6SalFCosMVCod ;
      private string[] T00015_A7SalFCosProdCod ;
      private int[] T00013_A2SalFCosAlmCod ;
      private short[] T00013_A3SalFCosAlmAno ;
      private short[] T00013_A4SalFCosAlmMes ;
      private string[] T00013_A5SalFCosMVTip ;
      private string[] T00013_A6SalFCosMVCod ;
      private string[] T00013_A7SalFCosProdCod ;
      private DateTime[] T00013_A1835SalFCosFecha ;
      private decimal[] T00013_A1832SalFCosCant ;
      private decimal[] T00013_A1837SalFCosUnit ;
      private decimal[] T00013_A1836SalFCosTot ;
      private decimal[] T00013_A1833SalFCosCantFifo ;
      private int[] T00016_A2SalFCosAlmCod ;
      private short[] T00016_A3SalFCosAlmAno ;
      private short[] T00016_A4SalFCosAlmMes ;
      private string[] T00016_A5SalFCosMVTip ;
      private string[] T00016_A6SalFCosMVCod ;
      private string[] T00016_A7SalFCosProdCod ;
      private int[] T00017_A2SalFCosAlmCod ;
      private short[] T00017_A3SalFCosAlmAno ;
      private short[] T00017_A4SalFCosAlmMes ;
      private string[] T00017_A5SalFCosMVTip ;
      private string[] T00017_A6SalFCosMVCod ;
      private string[] T00017_A7SalFCosProdCod ;
      private int[] T00012_A2SalFCosAlmCod ;
      private short[] T00012_A3SalFCosAlmAno ;
      private short[] T00012_A4SalFCosAlmMes ;
      private string[] T00012_A5SalFCosMVTip ;
      private string[] T00012_A6SalFCosMVCod ;
      private string[] T00012_A7SalFCosProdCod ;
      private DateTime[] T00012_A1835SalFCosFecha ;
      private decimal[] T00012_A1832SalFCosCant ;
      private decimal[] T00012_A1837SalFCosUnit ;
      private decimal[] T00012_A1836SalFCosTot ;
      private decimal[] T00012_A1833SalFCosCantFifo ;
      private int[] T000111_A2SalFCosAlmCod ;
      private short[] T000111_A3SalFCosAlmAno ;
      private short[] T000111_A4SalFCosAlmMes ;
      private string[] T000111_A5SalFCosMVTip ;
      private string[] T000111_A6SalFCosMVCod ;
      private string[] T000111_A7SalFCosProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class acostoalmacenfifo__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class acostoalmacenfifo__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00014;
        prmT00014 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00015;
        prmT00015 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00013;
        prmT00013 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00016;
        prmT00016 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00017;
        prmT00017 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00012;
        prmT00012 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT00018;
        prmT00018 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@SalFCosFecha",GXType.Date,8,0) ,
        new ParDef("@SalFCosCant",GXType.Decimal,15,4) ,
        new ParDef("@SalFCosUnit",GXType.Decimal,15,4) ,
        new ParDef("@SalFCosTot",GXType.Decimal,15,2) ,
        new ParDef("@SalFCosCantFifo",GXType.Decimal,15,4)
        };
        Object[] prmT00019;
        prmT00019 = new Object[] {
        new ParDef("@SalFCosFecha",GXType.Date,8,0) ,
        new ParDef("@SalFCosCant",GXType.Decimal,15,4) ,
        new ParDef("@SalFCosUnit",GXType.Decimal,15,4) ,
        new ParDef("@SalFCosTot",GXType.Decimal,15,2) ,
        new ParDef("@SalFCosCantFifo",GXType.Decimal,15,4) ,
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT000110;
        prmT000110 = new Object[] {
        new ParDef("@SalFCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalFCosAlmAno",GXType.Int16,4,0) ,
        new ParDef("@SalFCosAlmMes",GXType.Int16,2,0) ,
        new ParDef("@SalFCosMVTip",GXType.NVarChar,3,0) ,
        new ParDef("@SalFCosMVCod",GXType.NVarChar,12,0) ,
        new ParDef("@SalFCosProdCod",GXType.NVarChar,15,0)
        };
        Object[] prmT000111;
        prmT000111 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod], [SalFCosFecha], [SalFCosCant], [SalFCosUnit], [SalFCosTot], [SalFCosCantFifo] FROM [ACOSTOALMACENFIFO] WITH (UPDLOCK) WHERE [SalFCosAlmCod] = @SalFCosAlmCod AND [SalFCosAlmAno] = @SalFCosAlmAno AND [SalFCosAlmMes] = @SalFCosAlmMes AND [SalFCosMVTip] = @SalFCosMVTip AND [SalFCosMVCod] = @SalFCosMVCod AND [SalFCosProdCod] = @SalFCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod], [SalFCosFecha], [SalFCosCant], [SalFCosUnit], [SalFCosTot], [SalFCosCantFifo] FROM [ACOSTOALMACENFIFO] WHERE [SalFCosAlmCod] = @SalFCosAlmCod AND [SalFCosAlmAno] = @SalFCosAlmAno AND [SalFCosAlmMes] = @SalFCosAlmMes AND [SalFCosMVTip] = @SalFCosMVTip AND [SalFCosMVCod] = @SalFCosMVCod AND [SalFCosProdCod] = @SalFCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT TM1.[SalFCosAlmCod], TM1.[SalFCosAlmAno], TM1.[SalFCosAlmMes], TM1.[SalFCosMVTip], TM1.[SalFCosMVCod], TM1.[SalFCosProdCod], TM1.[SalFCosFecha], TM1.[SalFCosCant], TM1.[SalFCosUnit], TM1.[SalFCosTot], TM1.[SalFCosCantFifo] FROM [ACOSTOALMACENFIFO] TM1 WHERE TM1.[SalFCosAlmCod] = @SalFCosAlmCod and TM1.[SalFCosAlmAno] = @SalFCosAlmAno and TM1.[SalFCosAlmMes] = @SalFCosAlmMes and TM1.[SalFCosMVTip] = @SalFCosMVTip and TM1.[SalFCosMVCod] = @SalFCosMVCod and TM1.[SalFCosProdCod] = @SalFCosProdCod ORDER BY TM1.[SalFCosAlmCod], TM1.[SalFCosAlmAno], TM1.[SalFCosAlmMes], TM1.[SalFCosMVTip], TM1.[SalFCosMVCod], TM1.[SalFCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod] FROM [ACOSTOALMACENFIFO] WHERE [SalFCosAlmCod] = @SalFCosAlmCod AND [SalFCosAlmAno] = @SalFCosAlmAno AND [SalFCosAlmMes] = @SalFCosAlmMes AND [SalFCosMVTip] = @SalFCosMVTip AND [SalFCosMVCod] = @SalFCosMVCod AND [SalFCosProdCod] = @SalFCosProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT TOP 1 [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod] FROM [ACOSTOALMACENFIFO] WHERE ( [SalFCosAlmCod] > @SalFCosAlmCod or [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosAlmAno] > @SalFCosAlmAno or [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosAlmMes] > @SalFCosAlmMes or [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosMVTip] > @SalFCosMVTip or [SalFCosMVTip] = @SalFCosMVTip and [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosMVCod] > @SalFCosMVCod or [SalFCosMVCod] = @SalFCosMVCod and [SalFCosMVTip] = @SalFCosMVTip and [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosProdCod] > @SalFCosProdCod) ORDER BY [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00017", "SELECT TOP 1 [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod] FROM [ACOSTOALMACENFIFO] WHERE ( [SalFCosAlmCod] < @SalFCosAlmCod or [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosAlmAno] < @SalFCosAlmAno or [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosAlmMes] < @SalFCosAlmMes or [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosMVTip] < @SalFCosMVTip or [SalFCosMVTip] = @SalFCosMVTip and [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosMVCod] < @SalFCosMVCod or [SalFCosMVCod] = @SalFCosMVCod and [SalFCosMVTip] = @SalFCosMVTip and [SalFCosAlmMes] = @SalFCosAlmMes and [SalFCosAlmAno] = @SalFCosAlmAno and [SalFCosAlmCod] = @SalFCosAlmCod and [SalFCosProdCod] < @SalFCosProdCod) ORDER BY [SalFCosAlmCod] DESC, [SalFCosAlmAno] DESC, [SalFCosAlmMes] DESC, [SalFCosMVTip] DESC, [SalFCosMVCod] DESC, [SalFCosProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00018", "INSERT INTO [ACOSTOALMACENFIFO]([SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod], [SalFCosFecha], [SalFCosCant], [SalFCosUnit], [SalFCosTot], [SalFCosCantFifo]) VALUES(@SalFCosAlmCod, @SalFCosAlmAno, @SalFCosAlmMes, @SalFCosMVTip, @SalFCosMVCod, @SalFCosProdCod, @SalFCosFecha, @SalFCosCant, @SalFCosUnit, @SalFCosTot, @SalFCosCantFifo)", GxErrorMask.GX_NOMASK,prmT00018)
           ,new CursorDef("T00019", "UPDATE [ACOSTOALMACENFIFO] SET [SalFCosFecha]=@SalFCosFecha, [SalFCosCant]=@SalFCosCant, [SalFCosUnit]=@SalFCosUnit, [SalFCosTot]=@SalFCosTot, [SalFCosCantFifo]=@SalFCosCantFifo  WHERE [SalFCosAlmCod] = @SalFCosAlmCod AND [SalFCosAlmAno] = @SalFCosAlmAno AND [SalFCosAlmMes] = @SalFCosAlmMes AND [SalFCosMVTip] = @SalFCosMVTip AND [SalFCosMVCod] = @SalFCosMVCod AND [SalFCosProdCod] = @SalFCosProdCod", GxErrorMask.GX_NOMASK,prmT00019)
           ,new CursorDef("T000110", "DELETE FROM [ACOSTOALMACENFIFO]  WHERE [SalFCosAlmCod] = @SalFCosAlmCod AND [SalFCosAlmAno] = @SalFCosAlmAno AND [SalFCosAlmMes] = @SalFCosAlmMes AND [SalFCosMVTip] = @SalFCosMVTip AND [SalFCosMVCod] = @SalFCosMVCod AND [SalFCosProdCod] = @SalFCosProdCod", GxErrorMask.GX_NOMASK,prmT000110)
           ,new CursorDef("T000111", "SELECT [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod] FROM [ACOSTOALMACENFIFO] ORDER BY [SalFCosAlmCod], [SalFCosAlmAno], [SalFCosAlmMes], [SalFCosMVTip], [SalFCosMVCod], [SalFCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
     }
  }

}

}
