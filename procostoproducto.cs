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
   public class procostoproducto : GXDataArea
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
            Form.Meta.addItem("description", "PROCOSTOPRODUCTO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public procostoproducto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public procostoproducto( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "PROCOSTOPRODUCTO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_PROCOSTOPRODUCTO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PROCOSTOPRODUCTO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCUsuCod_Internalname, StringUtil.RTrim( A2383ProCUsuCod), StringUtil.RTrim( context.localUtil.Format( A2383ProCUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2384ProCItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtProCItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A2384ProCItem), "ZZZ9") : context.localUtil.Format( (decimal)(A2384ProCItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCProdCod_Internalname, "Codigo Materia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCProdCod_Internalname, StringUtil.RTrim( A2404ProCProdCod), StringUtil.RTrim( context.localUtil.Format( A2404ProCProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCProdDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCProdDsc_Internalname, StringUtil.RTrim( A2405ProCProdDsc), StringUtil.RTrim( context.localUtil.Format( A2405ProCProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCUnidades_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCUnidades_Internalname, "Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCUnidades_Internalname, StringUtil.LTrim( StringUtil.NToC( A2403ProCUnidades, 21, 6, ".", "")), StringUtil.LTrim( ((edtProCUnidades_Enabled!=0) ? context.localUtil.Format( A2403ProCUnidades, "ZZ,ZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2403ProCUnidades, "ZZ,ZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCUnidades_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCUnidades_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCCosUnidades_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCCosUnidades_Internalname, "Costo Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCCosUnidades_Internalname, StringUtil.LTrim( StringUtil.NToC( A2402ProCCosUnidades, 20, 4, ".", "")), StringUtil.LTrim( ((edtProCCosUnidades_Enabled!=0) ? context.localUtil.Format( A2402ProCCosUnidades, "ZZZ,ZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2402ProCCosUnidades, "ZZZ,ZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCCosUnidades_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCCosUnidades_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCCostoTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCCostoTotal_Internalname, "Costo Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCCostoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A2406ProCCostoTotal, 18, 2, ".", "")), StringUtil.LTrim( ((edtProCCostoTotal_Enabled!=0) ? context.localUtil.Format( A2406ProCCostoTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2406ProCCostoTotal, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCCostoTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCCostoTotal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCCostoUnit_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCCostoUnit_Internalname, "Cos. Unitario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCCostoUnit_Internalname, StringUtil.LTrim( StringUtil.NToC( A2407ProCCostoUnit, 20, 4, ".", "")), StringUtil.LTrim( ((edtProCCostoUnit_Enabled!=0) ? context.localUtil.Format( A2407ProCCostoUnit, "ZZZ,ZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2407ProCCostoUnit, "ZZZ,ZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCCostoUnit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCCostoUnit_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCTotales_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCTotales_Internalname, "Totales", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCTotales_Internalname, A2413ProCTotales, StringUtil.RTrim( context.localUtil.Format( A2413ProCTotales, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCTotales_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCTotales_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCProducto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCProducto_Internalname, "Codigo Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCProducto_Internalname, StringUtil.RTrim( A2408ProCProducto), StringUtil.RTrim( context.localUtil.Format( A2408ProCProducto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCProducto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCProducto_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCProductoDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCProductoDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCProductoDsc_Internalname, StringUtil.RTrim( A2409ProCProductoDsc), StringUtil.RTrim( context.localUtil.Format( A2409ProCProductoDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCProductoDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCProductoDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCRendimiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCRendimiento_Internalname, "Rendimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCRendimiento_Internalname, StringUtil.LTrim( StringUtil.NToC( A2410ProCRendimiento, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCRendimiento_Enabled!=0) ? context.localUtil.Format( A2410ProCRendimiento, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2410ProCRendimiento, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCRendimiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCRendimiento_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCTipCambio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCTipCambio_Internalname, "Tipo Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCTipCambio_Internalname, StringUtil.LTrim( StringUtil.NToC( A2411ProCTipCambio, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCTipCambio_Enabled!=0) ? context.localUtil.Format( A2411ProCTipCambio, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2411ProCTipCambio, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCTipCambio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCTipCambio_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCHorOptimas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCHorOptimas_Internalname, "Horas Optimas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCHorOptimas_Internalname, StringUtil.LTrim( StringUtil.NToC( A2412ProCHorOptimas, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCHorOptimas_Enabled!=0) ? context.localUtil.Format( A2412ProCHorOptimas, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2412ProCHorOptimas, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCHorOptimas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCHorOptimas_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_PROCOSTOPRODUCTO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOPRODUCTO.htm");
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
            Z2383ProCUsuCod = cgiGet( "Z2383ProCUsuCod");
            Z2384ProCItem = (short)(context.localUtil.CToN( cgiGet( "Z2384ProCItem"), ".", ","));
            Z2404ProCProdCod = cgiGet( "Z2404ProCProdCod");
            Z2405ProCProdDsc = cgiGet( "Z2405ProCProdDsc");
            Z2403ProCUnidades = context.localUtil.CToN( cgiGet( "Z2403ProCUnidades"), ".", ",");
            Z2402ProCCosUnidades = context.localUtil.CToN( cgiGet( "Z2402ProCCosUnidades"), ".", ",");
            Z2406ProCCostoTotal = context.localUtil.CToN( cgiGet( "Z2406ProCCostoTotal"), ".", ",");
            Z2407ProCCostoUnit = context.localUtil.CToN( cgiGet( "Z2407ProCCostoUnit"), ".", ",");
            Z2413ProCTotales = cgiGet( "Z2413ProCTotales");
            Z2408ProCProducto = cgiGet( "Z2408ProCProducto");
            Z2409ProCProductoDsc = cgiGet( "Z2409ProCProductoDsc");
            Z2410ProCRendimiento = context.localUtil.CToN( cgiGet( "Z2410ProCRendimiento"), ".", ",");
            Z2411ProCTipCambio = context.localUtil.CToN( cgiGet( "Z2411ProCTipCambio"), ".", ",");
            Z2412ProCHorOptimas = context.localUtil.CToN( cgiGet( "Z2412ProCHorOptimas"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2383ProCUsuCod = cgiGet( edtProCUsuCod_Internalname);
            AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCITEM");
               AnyError = 1;
               GX_FocusControl = edtProCItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2384ProCItem = 0;
               AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
            }
            else
            {
               A2384ProCItem = (short)(context.localUtil.CToN( cgiGet( edtProCItem_Internalname), ".", ","));
               AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
            }
            A2404ProCProdCod = cgiGet( edtProCProdCod_Internalname);
            AssignAttri("", false, "A2404ProCProdCod", A2404ProCProdCod);
            A2405ProCProdDsc = cgiGet( edtProCProdDsc_Internalname);
            AssignAttri("", false, "A2405ProCProdDsc", A2405ProCProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCUnidades_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCUnidades_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCUNIDADES");
               AnyError = 1;
               GX_FocusControl = edtProCUnidades_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2403ProCUnidades = 0;
               AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrimStr( A2403ProCUnidades, 18, 6));
            }
            else
            {
               A2403ProCUnidades = context.localUtil.CToN( cgiGet( edtProCUnidades_Internalname), ".", ",");
               AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrimStr( A2403ProCUnidades, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCCosUnidades_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCCosUnidades_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCCOSUNIDADES");
               AnyError = 1;
               GX_FocusControl = edtProCCosUnidades_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2402ProCCosUnidades = 0;
               AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrimStr( A2402ProCCosUnidades, 15, 4));
            }
            else
            {
               A2402ProCCosUnidades = context.localUtil.CToN( cgiGet( edtProCCosUnidades_Internalname), ".", ",");
               AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrimStr( A2402ProCCosUnidades, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCCostoTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCCostoTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCCOSTOTOTAL");
               AnyError = 1;
               GX_FocusControl = edtProCCostoTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2406ProCCostoTotal = 0;
               AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrimStr( A2406ProCCostoTotal, 15, 2));
            }
            else
            {
               A2406ProCCostoTotal = context.localUtil.CToN( cgiGet( edtProCCostoTotal_Internalname), ".", ",");
               AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrimStr( A2406ProCCostoTotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCCostoUnit_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCCostoUnit_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCCOSTOUNIT");
               AnyError = 1;
               GX_FocusControl = edtProCCostoUnit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2407ProCCostoUnit = 0;
               AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrimStr( A2407ProCCostoUnit, 15, 4));
            }
            else
            {
               A2407ProCCostoUnit = context.localUtil.CToN( cgiGet( edtProCCostoUnit_Internalname), ".", ",");
               AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrimStr( A2407ProCCostoUnit, 15, 4));
            }
            A2413ProCTotales = cgiGet( edtProCTotales_Internalname);
            AssignAttri("", false, "A2413ProCTotales", A2413ProCTotales);
            A2408ProCProducto = cgiGet( edtProCProducto_Internalname);
            AssignAttri("", false, "A2408ProCProducto", A2408ProCProducto);
            A2409ProCProductoDsc = cgiGet( edtProCProductoDsc_Internalname);
            AssignAttri("", false, "A2409ProCProductoDsc", A2409ProCProductoDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCRendimiento_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCRendimiento_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCRENDIMIENTO");
               AnyError = 1;
               GX_FocusControl = edtProCRendimiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2410ProCRendimiento = 0;
               AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrimStr( A2410ProCRendimiento, 15, 2));
            }
            else
            {
               A2410ProCRendimiento = context.localUtil.CToN( cgiGet( edtProCRendimiento_Internalname), ".", ",");
               AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrimStr( A2410ProCRendimiento, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCTipCambio_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCTipCambio_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCTIPCAMBIO");
               AnyError = 1;
               GX_FocusControl = edtProCTipCambio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2411ProCTipCambio = 0;
               AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrimStr( A2411ProCTipCambio, 15, 4));
            }
            else
            {
               A2411ProCTipCambio = context.localUtil.CToN( cgiGet( edtProCTipCambio_Internalname), ".", ",");
               AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrimStr( A2411ProCTipCambio, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCHorOptimas_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCHorOptimas_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCHOROPTIMAS");
               AnyError = 1;
               GX_FocusControl = edtProCHorOptimas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2412ProCHorOptimas = 0;
               AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrimStr( A2412ProCHorOptimas, 15, 2));
            }
            else
            {
               A2412ProCHorOptimas = context.localUtil.CToN( cgiGet( edtProCHorOptimas_Internalname), ".", ",");
               AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrimStr( A2412ProCHorOptimas, 15, 2));
            }
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
               A2383ProCUsuCod = GetPar( "ProCUsuCod");
               AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
               A2384ProCItem = (short)(NumberUtil.Val( GetPar( "ProCItem"), "."));
               AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
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
               InitAll7N211( ) ;
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
         DisableAttributes7N211( ) ;
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

      protected void ResetCaption7N0( )
      {
      }

      protected void ZM7N211( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2404ProCProdCod = T007N3_A2404ProCProdCod[0];
               Z2405ProCProdDsc = T007N3_A2405ProCProdDsc[0];
               Z2403ProCUnidades = T007N3_A2403ProCUnidades[0];
               Z2402ProCCosUnidades = T007N3_A2402ProCCosUnidades[0];
               Z2406ProCCostoTotal = T007N3_A2406ProCCostoTotal[0];
               Z2407ProCCostoUnit = T007N3_A2407ProCCostoUnit[0];
               Z2413ProCTotales = T007N3_A2413ProCTotales[0];
               Z2408ProCProducto = T007N3_A2408ProCProducto[0];
               Z2409ProCProductoDsc = T007N3_A2409ProCProductoDsc[0];
               Z2410ProCRendimiento = T007N3_A2410ProCRendimiento[0];
               Z2411ProCTipCambio = T007N3_A2411ProCTipCambio[0];
               Z2412ProCHorOptimas = T007N3_A2412ProCHorOptimas[0];
            }
            else
            {
               Z2404ProCProdCod = A2404ProCProdCod;
               Z2405ProCProdDsc = A2405ProCProdDsc;
               Z2403ProCUnidades = A2403ProCUnidades;
               Z2402ProCCosUnidades = A2402ProCCosUnidades;
               Z2406ProCCostoTotal = A2406ProCCostoTotal;
               Z2407ProCCostoUnit = A2407ProCCostoUnit;
               Z2413ProCTotales = A2413ProCTotales;
               Z2408ProCProducto = A2408ProCProducto;
               Z2409ProCProductoDsc = A2409ProCProductoDsc;
               Z2410ProCRendimiento = A2410ProCRendimiento;
               Z2411ProCTipCambio = A2411ProCTipCambio;
               Z2412ProCHorOptimas = A2412ProCHorOptimas;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2383ProCUsuCod = A2383ProCUsuCod;
            Z2384ProCItem = A2384ProCItem;
            Z2404ProCProdCod = A2404ProCProdCod;
            Z2405ProCProdDsc = A2405ProCProdDsc;
            Z2403ProCUnidades = A2403ProCUnidades;
            Z2402ProCCosUnidades = A2402ProCCosUnidades;
            Z2406ProCCostoTotal = A2406ProCCostoTotal;
            Z2407ProCCostoUnit = A2407ProCCostoUnit;
            Z2413ProCTotales = A2413ProCTotales;
            Z2408ProCProducto = A2408ProCProducto;
            Z2409ProCProductoDsc = A2409ProCProductoDsc;
            Z2410ProCRendimiento = A2410ProCRendimiento;
            Z2411ProCTipCambio = A2411ProCTipCambio;
            Z2412ProCHorOptimas = A2412ProCHorOptimas;
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

      protected void Load7N211( )
      {
         /* Using cursor T007N4 */
         pr_default.execute(2, new Object[] {A2383ProCUsuCod, A2384ProCItem});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound211 = 1;
            A2404ProCProdCod = T007N4_A2404ProCProdCod[0];
            AssignAttri("", false, "A2404ProCProdCod", A2404ProCProdCod);
            A2405ProCProdDsc = T007N4_A2405ProCProdDsc[0];
            AssignAttri("", false, "A2405ProCProdDsc", A2405ProCProdDsc);
            A2403ProCUnidades = T007N4_A2403ProCUnidades[0];
            AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrimStr( A2403ProCUnidades, 18, 6));
            A2402ProCCosUnidades = T007N4_A2402ProCCosUnidades[0];
            AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrimStr( A2402ProCCosUnidades, 15, 4));
            A2406ProCCostoTotal = T007N4_A2406ProCCostoTotal[0];
            AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrimStr( A2406ProCCostoTotal, 15, 2));
            A2407ProCCostoUnit = T007N4_A2407ProCCostoUnit[0];
            AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrimStr( A2407ProCCostoUnit, 15, 4));
            A2413ProCTotales = T007N4_A2413ProCTotales[0];
            AssignAttri("", false, "A2413ProCTotales", A2413ProCTotales);
            A2408ProCProducto = T007N4_A2408ProCProducto[0];
            AssignAttri("", false, "A2408ProCProducto", A2408ProCProducto);
            A2409ProCProductoDsc = T007N4_A2409ProCProductoDsc[0];
            AssignAttri("", false, "A2409ProCProductoDsc", A2409ProCProductoDsc);
            A2410ProCRendimiento = T007N4_A2410ProCRendimiento[0];
            AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrimStr( A2410ProCRendimiento, 15, 2));
            A2411ProCTipCambio = T007N4_A2411ProCTipCambio[0];
            AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrimStr( A2411ProCTipCambio, 15, 4));
            A2412ProCHorOptimas = T007N4_A2412ProCHorOptimas[0];
            AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrimStr( A2412ProCHorOptimas, 15, 2));
            ZM7N211( -1) ;
         }
         pr_default.close(2);
         OnLoadActions7N211( ) ;
      }

      protected void OnLoadActions7N211( )
      {
      }

      protected void CheckExtendedTable7N211( )
      {
         nIsDirty_211 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7N211( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7N211( )
      {
         /* Using cursor T007N5 */
         pr_default.execute(3, new Object[] {A2383ProCUsuCod, A2384ProCItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound211 = 1;
         }
         else
         {
            RcdFound211 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007N3 */
         pr_default.execute(1, new Object[] {A2383ProCUsuCod, A2384ProCItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7N211( 1) ;
            RcdFound211 = 1;
            A2383ProCUsuCod = T007N3_A2383ProCUsuCod[0];
            AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
            A2384ProCItem = T007N3_A2384ProCItem[0];
            AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
            A2404ProCProdCod = T007N3_A2404ProCProdCod[0];
            AssignAttri("", false, "A2404ProCProdCod", A2404ProCProdCod);
            A2405ProCProdDsc = T007N3_A2405ProCProdDsc[0];
            AssignAttri("", false, "A2405ProCProdDsc", A2405ProCProdDsc);
            A2403ProCUnidades = T007N3_A2403ProCUnidades[0];
            AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrimStr( A2403ProCUnidades, 18, 6));
            A2402ProCCosUnidades = T007N3_A2402ProCCosUnidades[0];
            AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrimStr( A2402ProCCosUnidades, 15, 4));
            A2406ProCCostoTotal = T007N3_A2406ProCCostoTotal[0];
            AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrimStr( A2406ProCCostoTotal, 15, 2));
            A2407ProCCostoUnit = T007N3_A2407ProCCostoUnit[0];
            AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrimStr( A2407ProCCostoUnit, 15, 4));
            A2413ProCTotales = T007N3_A2413ProCTotales[0];
            AssignAttri("", false, "A2413ProCTotales", A2413ProCTotales);
            A2408ProCProducto = T007N3_A2408ProCProducto[0];
            AssignAttri("", false, "A2408ProCProducto", A2408ProCProducto);
            A2409ProCProductoDsc = T007N3_A2409ProCProductoDsc[0];
            AssignAttri("", false, "A2409ProCProductoDsc", A2409ProCProductoDsc);
            A2410ProCRendimiento = T007N3_A2410ProCRendimiento[0];
            AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrimStr( A2410ProCRendimiento, 15, 2));
            A2411ProCTipCambio = T007N3_A2411ProCTipCambio[0];
            AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrimStr( A2411ProCTipCambio, 15, 4));
            A2412ProCHorOptimas = T007N3_A2412ProCHorOptimas[0];
            AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrimStr( A2412ProCHorOptimas, 15, 2));
            Z2383ProCUsuCod = A2383ProCUsuCod;
            Z2384ProCItem = A2384ProCItem;
            sMode211 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7N211( ) ;
            if ( AnyError == 1 )
            {
               RcdFound211 = 0;
               InitializeNonKey7N211( ) ;
            }
            Gx_mode = sMode211;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound211 = 0;
            InitializeNonKey7N211( ) ;
            sMode211 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode211;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7N211( ) ;
         if ( RcdFound211 == 0 )
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
         RcdFound211 = 0;
         /* Using cursor T007N6 */
         pr_default.execute(4, new Object[] {A2383ProCUsuCod, A2384ProCItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007N6_A2383ProCUsuCod[0], A2383ProCUsuCod) < 0 ) || ( StringUtil.StrCmp(T007N6_A2383ProCUsuCod[0], A2383ProCUsuCod) == 0 ) && ( T007N6_A2384ProCItem[0] < A2384ProCItem ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T007N6_A2383ProCUsuCod[0], A2383ProCUsuCod) > 0 ) || ( StringUtil.StrCmp(T007N6_A2383ProCUsuCod[0], A2383ProCUsuCod) == 0 ) && ( T007N6_A2384ProCItem[0] > A2384ProCItem ) ) )
            {
               A2383ProCUsuCod = T007N6_A2383ProCUsuCod[0];
               AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
               A2384ProCItem = T007N6_A2384ProCItem[0];
               AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
               RcdFound211 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound211 = 0;
         /* Using cursor T007N7 */
         pr_default.execute(5, new Object[] {A2383ProCUsuCod, A2384ProCItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007N7_A2383ProCUsuCod[0], A2383ProCUsuCod) > 0 ) || ( StringUtil.StrCmp(T007N7_A2383ProCUsuCod[0], A2383ProCUsuCod) == 0 ) && ( T007N7_A2384ProCItem[0] > A2384ProCItem ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T007N7_A2383ProCUsuCod[0], A2383ProCUsuCod) < 0 ) || ( StringUtil.StrCmp(T007N7_A2383ProCUsuCod[0], A2383ProCUsuCod) == 0 ) && ( T007N7_A2384ProCItem[0] < A2384ProCItem ) ) )
            {
               A2383ProCUsuCod = T007N7_A2383ProCUsuCod[0];
               AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
               A2384ProCItem = T007N7_A2384ProCItem[0];
               AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
               RcdFound211 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7N211( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7N211( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound211 == 1 )
            {
               if ( ( StringUtil.StrCmp(A2383ProCUsuCod, Z2383ProCUsuCod) != 0 ) || ( A2384ProCItem != Z2384ProCItem ) )
               {
                  A2383ProCUsuCod = Z2383ProCUsuCod;
                  AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
                  A2384ProCItem = Z2384ProCItem;
                  AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCUSUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7N211( ) ;
                  GX_FocusControl = edtProCUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A2383ProCUsuCod, Z2383ProCUsuCod) != 0 ) || ( A2384ProCItem != Z2384ProCItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7N211( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCUSUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7N211( ) ;
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
         if ( ( StringUtil.StrCmp(A2383ProCUsuCod, Z2383ProCUsuCod) != 0 ) || ( A2384ProCItem != Z2384ProCItem ) )
         {
            A2383ProCUsuCod = Z2383ProCUsuCod;
            AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
            A2384ProCItem = Z2384ProCItem;
            AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCUSUCOD");
            AnyError = 1;
            GX_FocusControl = edtProCUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCUsuCod_Internalname;
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
         if ( RcdFound211 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCUSUCOD");
            AnyError = 1;
            GX_FocusControl = edtProCUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProCProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7N211( ) ;
         if ( RcdFound211 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7N211( ) ;
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
         if ( RcdFound211 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCProdCod_Internalname;
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
         if ( RcdFound211 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCProdCod_Internalname;
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
         ScanStart7N211( ) ;
         if ( RcdFound211 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound211 != 0 )
            {
               ScanNext7N211( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7N211( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7N211( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007N2 */
            pr_default.execute(0, new Object[] {A2383ProCUsuCod, A2384ProCItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOPRODUCTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2404ProCProdCod, T007N2_A2404ProCProdCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2405ProCProdDsc, T007N2_A2405ProCProdDsc[0]) != 0 ) || ( Z2403ProCUnidades != T007N2_A2403ProCUnidades[0] ) || ( Z2402ProCCosUnidades != T007N2_A2402ProCCosUnidades[0] ) || ( Z2406ProCCostoTotal != T007N2_A2406ProCCostoTotal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2407ProCCostoUnit != T007N2_A2407ProCCostoUnit[0] ) || ( StringUtil.StrCmp(Z2413ProCTotales, T007N2_A2413ProCTotales[0]) != 0 ) || ( StringUtil.StrCmp(Z2408ProCProducto, T007N2_A2408ProCProducto[0]) != 0 ) || ( StringUtil.StrCmp(Z2409ProCProductoDsc, T007N2_A2409ProCProductoDsc[0]) != 0 ) || ( Z2410ProCRendimiento != T007N2_A2410ProCRendimiento[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2411ProCTipCambio != T007N2_A2411ProCTipCambio[0] ) || ( Z2412ProCHorOptimas != T007N2_A2412ProCHorOptimas[0] ) )
            {
               if ( StringUtil.StrCmp(Z2404ProCProdCod, T007N2_A2404ProCProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z2404ProCProdCod);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2404ProCProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z2405ProCProdDsc, T007N2_A2405ProCProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2405ProCProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2405ProCProdDsc[0]);
               }
               if ( Z2403ProCUnidades != T007N2_A2403ProCUnidades[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCUnidades");
                  GXUtil.WriteLogRaw("Old: ",Z2403ProCUnidades);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2403ProCUnidades[0]);
               }
               if ( Z2402ProCCosUnidades != T007N2_A2402ProCCosUnidades[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCCosUnidades");
                  GXUtil.WriteLogRaw("Old: ",Z2402ProCCosUnidades);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2402ProCCosUnidades[0]);
               }
               if ( Z2406ProCCostoTotal != T007N2_A2406ProCCostoTotal[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCCostoTotal");
                  GXUtil.WriteLogRaw("Old: ",Z2406ProCCostoTotal);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2406ProCCostoTotal[0]);
               }
               if ( Z2407ProCCostoUnit != T007N2_A2407ProCCostoUnit[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCCostoUnit");
                  GXUtil.WriteLogRaw("Old: ",Z2407ProCCostoUnit);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2407ProCCostoUnit[0]);
               }
               if ( StringUtil.StrCmp(Z2413ProCTotales, T007N2_A2413ProCTotales[0]) != 0 )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCTotales");
                  GXUtil.WriteLogRaw("Old: ",Z2413ProCTotales);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2413ProCTotales[0]);
               }
               if ( StringUtil.StrCmp(Z2408ProCProducto, T007N2_A2408ProCProducto[0]) != 0 )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCProducto");
                  GXUtil.WriteLogRaw("Old: ",Z2408ProCProducto);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2408ProCProducto[0]);
               }
               if ( StringUtil.StrCmp(Z2409ProCProductoDsc, T007N2_A2409ProCProductoDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCProductoDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2409ProCProductoDsc);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2409ProCProductoDsc[0]);
               }
               if ( Z2410ProCRendimiento != T007N2_A2410ProCRendimiento[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCRendimiento");
                  GXUtil.WriteLogRaw("Old: ",Z2410ProCRendimiento);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2410ProCRendimiento[0]);
               }
               if ( Z2411ProCTipCambio != T007N2_A2411ProCTipCambio[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCTipCambio");
                  GXUtil.WriteLogRaw("Old: ",Z2411ProCTipCambio);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2411ProCTipCambio[0]);
               }
               if ( Z2412ProCHorOptimas != T007N2_A2412ProCHorOptimas[0] )
               {
                  GXUtil.WriteLog("procostoproducto:[seudo value changed for attri]"+"ProCHorOptimas");
                  GXUtil.WriteLogRaw("Old: ",Z2412ProCHorOptimas);
                  GXUtil.WriteLogRaw("Current: ",T007N2_A2412ProCHorOptimas[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PROCOSTOPRODUCTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7N211( )
      {
         BeforeValidate7N211( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7N211( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7N211( 0) ;
            CheckOptimisticConcurrency7N211( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7N211( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7N211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007N8 */
                     pr_default.execute(6, new Object[] {A2383ProCUsuCod, A2384ProCItem, A2404ProCProdCod, A2405ProCProdDsc, A2403ProCUnidades, A2402ProCCosUnidades, A2406ProCCostoTotal, A2407ProCCostoUnit, A2413ProCTotales, A2408ProCProducto, A2409ProCProductoDsc, A2410ProCRendimiento, A2411ProCTipCambio, A2412ProCHorOptimas});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOPRODUCTO");
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
                           ResetCaption7N0( ) ;
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
               Load7N211( ) ;
            }
            EndLevel7N211( ) ;
         }
         CloseExtendedTableCursors7N211( ) ;
      }

      protected void Update7N211( )
      {
         BeforeValidate7N211( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7N211( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7N211( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7N211( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7N211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007N9 */
                     pr_default.execute(7, new Object[] {A2404ProCProdCod, A2405ProCProdDsc, A2403ProCUnidades, A2402ProCCosUnidades, A2406ProCCostoTotal, A2407ProCCostoUnit, A2413ProCTotales, A2408ProCProducto, A2409ProCProductoDsc, A2410ProCRendimiento, A2411ProCTipCambio, A2412ProCHorOptimas, A2383ProCUsuCod, A2384ProCItem});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOPRODUCTO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOPRODUCTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7N211( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7N0( ) ;
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
            EndLevel7N211( ) ;
         }
         CloseExtendedTableCursors7N211( ) ;
      }

      protected void DeferredUpdate7N211( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7N211( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7N211( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7N211( ) ;
            AfterConfirm7N211( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7N211( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007N10 */
                  pr_default.execute(8, new Object[] {A2383ProCUsuCod, A2384ProCItem});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOPRODUCTO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound211 == 0 )
                        {
                           InitAll7N211( ) ;
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
                        ResetCaption7N0( ) ;
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
         sMode211 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7N211( ) ;
         Gx_mode = sMode211;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7N211( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7N211( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7N211( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("procostoproducto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("procostoproducto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7N211( )
      {
         /* Using cursor T007N11 */
         pr_default.execute(9);
         RcdFound211 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound211 = 1;
            A2383ProCUsuCod = T007N11_A2383ProCUsuCod[0];
            AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
            A2384ProCItem = T007N11_A2384ProCItem[0];
            AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7N211( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound211 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound211 = 1;
            A2383ProCUsuCod = T007N11_A2383ProCUsuCod[0];
            AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
            A2384ProCItem = T007N11_A2384ProCItem[0];
            AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
         }
      }

      protected void ScanEnd7N211( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm7N211( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7N211( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7N211( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7N211( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7N211( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7N211( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7N211( )
      {
         edtProCUsuCod_Enabled = 0;
         AssignProp("", false, edtProCUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCUsuCod_Enabled), 5, 0), true);
         edtProCItem_Enabled = 0;
         AssignProp("", false, edtProCItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCItem_Enabled), 5, 0), true);
         edtProCProdCod_Enabled = 0;
         AssignProp("", false, edtProCProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCProdCod_Enabled), 5, 0), true);
         edtProCProdDsc_Enabled = 0;
         AssignProp("", false, edtProCProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCProdDsc_Enabled), 5, 0), true);
         edtProCUnidades_Enabled = 0;
         AssignProp("", false, edtProCUnidades_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCUnidades_Enabled), 5, 0), true);
         edtProCCosUnidades_Enabled = 0;
         AssignProp("", false, edtProCCosUnidades_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCCosUnidades_Enabled), 5, 0), true);
         edtProCCostoTotal_Enabled = 0;
         AssignProp("", false, edtProCCostoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCCostoTotal_Enabled), 5, 0), true);
         edtProCCostoUnit_Enabled = 0;
         AssignProp("", false, edtProCCostoUnit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCCostoUnit_Enabled), 5, 0), true);
         edtProCTotales_Enabled = 0;
         AssignProp("", false, edtProCTotales_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCTotales_Enabled), 5, 0), true);
         edtProCProducto_Enabled = 0;
         AssignProp("", false, edtProCProducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCProducto_Enabled), 5, 0), true);
         edtProCProductoDsc_Enabled = 0;
         AssignProp("", false, edtProCProductoDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCProductoDsc_Enabled), 5, 0), true);
         edtProCRendimiento_Enabled = 0;
         AssignProp("", false, edtProCRendimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCRendimiento_Enabled), 5, 0), true);
         edtProCTipCambio_Enabled = 0;
         AssignProp("", false, edtProCTipCambio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCTipCambio_Enabled), 5, 0), true);
         edtProCHorOptimas_Enabled = 0;
         AssignProp("", false, edtProCHorOptimas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCHorOptimas_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7N211( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271521", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("procostoproducto.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2383ProCUsuCod", StringUtil.RTrim( Z2383ProCUsuCod));
         GxWebStd.gx_hidden_field( context, "Z2384ProCItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2384ProCItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2404ProCProdCod", StringUtil.RTrim( Z2404ProCProdCod));
         GxWebStd.gx_hidden_field( context, "Z2405ProCProdDsc", StringUtil.RTrim( Z2405ProCProdDsc));
         GxWebStd.gx_hidden_field( context, "Z2403ProCUnidades", StringUtil.LTrim( StringUtil.NToC( Z2403ProCUnidades, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2402ProCCosUnidades", StringUtil.LTrim( StringUtil.NToC( Z2402ProCCosUnidades, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2406ProCCostoTotal", StringUtil.LTrim( StringUtil.NToC( Z2406ProCCostoTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2407ProCCostoUnit", StringUtil.LTrim( StringUtil.NToC( Z2407ProCCostoUnit, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2413ProCTotales", Z2413ProCTotales);
         GxWebStd.gx_hidden_field( context, "Z2408ProCProducto", StringUtil.RTrim( Z2408ProCProducto));
         GxWebStd.gx_hidden_field( context, "Z2409ProCProductoDsc", StringUtil.RTrim( Z2409ProCProductoDsc));
         GxWebStd.gx_hidden_field( context, "Z2410ProCRendimiento", StringUtil.LTrim( StringUtil.NToC( Z2410ProCRendimiento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2411ProCTipCambio", StringUtil.LTrim( StringUtil.NToC( Z2411ProCTipCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2412ProCHorOptimas", StringUtil.LTrim( StringUtil.NToC( Z2412ProCHorOptimas, 15, 2, ".", "")));
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
         return formatLink("procostoproducto.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PROCOSTOPRODUCTO" ;
      }

      public override string GetPgmdesc( )
      {
         return "PROCOSTOPRODUCTO" ;
      }

      protected void InitializeNonKey7N211( )
      {
         A2404ProCProdCod = "";
         AssignAttri("", false, "A2404ProCProdCod", A2404ProCProdCod);
         A2405ProCProdDsc = "";
         AssignAttri("", false, "A2405ProCProdDsc", A2405ProCProdDsc);
         A2403ProCUnidades = 0;
         AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrimStr( A2403ProCUnidades, 18, 6));
         A2402ProCCosUnidades = 0;
         AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrimStr( A2402ProCCosUnidades, 15, 4));
         A2406ProCCostoTotal = 0;
         AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrimStr( A2406ProCCostoTotal, 15, 2));
         A2407ProCCostoUnit = 0;
         AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrimStr( A2407ProCCostoUnit, 15, 4));
         A2413ProCTotales = "";
         AssignAttri("", false, "A2413ProCTotales", A2413ProCTotales);
         A2408ProCProducto = "";
         AssignAttri("", false, "A2408ProCProducto", A2408ProCProducto);
         A2409ProCProductoDsc = "";
         AssignAttri("", false, "A2409ProCProductoDsc", A2409ProCProductoDsc);
         A2410ProCRendimiento = 0;
         AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrimStr( A2410ProCRendimiento, 15, 2));
         A2411ProCTipCambio = 0;
         AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrimStr( A2411ProCTipCambio, 15, 4));
         A2412ProCHorOptimas = 0;
         AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrimStr( A2412ProCHorOptimas, 15, 2));
         Z2404ProCProdCod = "";
         Z2405ProCProdDsc = "";
         Z2403ProCUnidades = 0;
         Z2402ProCCosUnidades = 0;
         Z2406ProCCostoTotal = 0;
         Z2407ProCCostoUnit = 0;
         Z2413ProCTotales = "";
         Z2408ProCProducto = "";
         Z2409ProCProductoDsc = "";
         Z2410ProCRendimiento = 0;
         Z2411ProCTipCambio = 0;
         Z2412ProCHorOptimas = 0;
      }

      protected void InitAll7N211( )
      {
         A2383ProCUsuCod = "";
         AssignAttri("", false, "A2383ProCUsuCod", A2383ProCUsuCod);
         A2384ProCItem = 0;
         AssignAttri("", false, "A2384ProCItem", StringUtil.LTrimStr( (decimal)(A2384ProCItem), 4, 0));
         InitializeNonKey7N211( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271532", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("procostoproducto.js", "?202281810271532", false, true);
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
         edtProCUsuCod_Internalname = "PROCUSUCOD";
         edtProCItem_Internalname = "PROCITEM";
         edtProCProdCod_Internalname = "PROCPRODCOD";
         edtProCProdDsc_Internalname = "PROCPRODDSC";
         edtProCUnidades_Internalname = "PROCUNIDADES";
         edtProCCosUnidades_Internalname = "PROCCOSUNIDADES";
         edtProCCostoTotal_Internalname = "PROCCOSTOTOTAL";
         edtProCCostoUnit_Internalname = "PROCCOSTOUNIT";
         edtProCTotales_Internalname = "PROCTOTALES";
         edtProCProducto_Internalname = "PROCPRODUCTO";
         edtProCProductoDsc_Internalname = "PROCPRODUCTODSC";
         edtProCRendimiento_Internalname = "PROCRENDIMIENTO";
         edtProCTipCambio_Internalname = "PROCTIPCAMBIO";
         edtProCHorOptimas_Internalname = "PROCHOROPTIMAS";
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
         Form.Caption = "PROCOSTOPRODUCTO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProCHorOptimas_Jsonclick = "";
         edtProCHorOptimas_Enabled = 1;
         edtProCTipCambio_Jsonclick = "";
         edtProCTipCambio_Enabled = 1;
         edtProCRendimiento_Jsonclick = "";
         edtProCRendimiento_Enabled = 1;
         edtProCProductoDsc_Jsonclick = "";
         edtProCProductoDsc_Enabled = 1;
         edtProCProducto_Jsonclick = "";
         edtProCProducto_Enabled = 1;
         edtProCTotales_Jsonclick = "";
         edtProCTotales_Enabled = 1;
         edtProCCostoUnit_Jsonclick = "";
         edtProCCostoUnit_Enabled = 1;
         edtProCCostoTotal_Jsonclick = "";
         edtProCCostoTotal_Enabled = 1;
         edtProCCosUnidades_Jsonclick = "";
         edtProCCosUnidades_Enabled = 1;
         edtProCUnidades_Jsonclick = "";
         edtProCUnidades_Enabled = 1;
         edtProCProdDsc_Jsonclick = "";
         edtProCProdDsc_Enabled = 1;
         edtProCProdCod_Jsonclick = "";
         edtProCProdCod_Enabled = 1;
         edtProCItem_Jsonclick = "";
         edtProCItem_Enabled = 1;
         edtProCUsuCod_Jsonclick = "";
         edtProCUsuCod_Enabled = 1;
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
         GX_FocusControl = edtProCProdCod_Internalname;
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

      public void Valid_Procitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2404ProCProdCod", StringUtil.RTrim( A2404ProCProdCod));
         AssignAttri("", false, "A2405ProCProdDsc", StringUtil.RTrim( A2405ProCProdDsc));
         AssignAttri("", false, "A2403ProCUnidades", StringUtil.LTrim( StringUtil.NToC( A2403ProCUnidades, 18, 6, ".", "")));
         AssignAttri("", false, "A2402ProCCosUnidades", StringUtil.LTrim( StringUtil.NToC( A2402ProCCosUnidades, 15, 4, ".", "")));
         AssignAttri("", false, "A2406ProCCostoTotal", StringUtil.LTrim( StringUtil.NToC( A2406ProCCostoTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A2407ProCCostoUnit", StringUtil.LTrim( StringUtil.NToC( A2407ProCCostoUnit, 15, 4, ".", "")));
         AssignAttri("", false, "A2413ProCTotales", A2413ProCTotales);
         AssignAttri("", false, "A2408ProCProducto", StringUtil.RTrim( A2408ProCProducto));
         AssignAttri("", false, "A2409ProCProductoDsc", StringUtil.RTrim( A2409ProCProductoDsc));
         AssignAttri("", false, "A2410ProCRendimiento", StringUtil.LTrim( StringUtil.NToC( A2410ProCRendimiento, 15, 2, ".", "")));
         AssignAttri("", false, "A2411ProCTipCambio", StringUtil.LTrim( StringUtil.NToC( A2411ProCTipCambio, 15, 4, ".", "")));
         AssignAttri("", false, "A2412ProCHorOptimas", StringUtil.LTrim( StringUtil.NToC( A2412ProCHorOptimas, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2383ProCUsuCod", StringUtil.RTrim( Z2383ProCUsuCod));
         GxWebStd.gx_hidden_field( context, "Z2384ProCItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2384ProCItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2404ProCProdCod", StringUtil.RTrim( Z2404ProCProdCod));
         GxWebStd.gx_hidden_field( context, "Z2405ProCProdDsc", StringUtil.RTrim( Z2405ProCProdDsc));
         GxWebStd.gx_hidden_field( context, "Z2403ProCUnidades", StringUtil.LTrim( StringUtil.NToC( Z2403ProCUnidades, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2402ProCCosUnidades", StringUtil.LTrim( StringUtil.NToC( Z2402ProCCosUnidades, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2406ProCCostoTotal", StringUtil.LTrim( StringUtil.NToC( Z2406ProCCostoTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2407ProCCostoUnit", StringUtil.LTrim( StringUtil.NToC( Z2407ProCCostoUnit, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2413ProCTotales", Z2413ProCTotales);
         GxWebStd.gx_hidden_field( context, "Z2408ProCProducto", StringUtil.RTrim( Z2408ProCProducto));
         GxWebStd.gx_hidden_field( context, "Z2409ProCProductoDsc", StringUtil.RTrim( Z2409ProCProductoDsc));
         GxWebStd.gx_hidden_field( context, "Z2410ProCRendimiento", StringUtil.LTrim( StringUtil.NToC( Z2410ProCRendimiento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2411ProCTipCambio", StringUtil.LTrim( StringUtil.NToC( Z2411ProCTipCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2412ProCHorOptimas", StringUtil.LTrim( StringUtil.NToC( Z2412ProCHorOptimas, 15, 2, ".", "")));
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
         setEventMetadata("VALID_PROCUSUCOD","{handler:'Valid_Procusucod',iparms:[]");
         setEventMetadata("VALID_PROCUSUCOD",",oparms:[]}");
         setEventMetadata("VALID_PROCITEM","{handler:'Valid_Procitem',iparms:[{av:'A2383ProCUsuCod',fld:'PROCUSUCOD',pic:''},{av:'A2384ProCItem',fld:'PROCITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCITEM",",oparms:[{av:'A2404ProCProdCod',fld:'PROCPRODCOD',pic:''},{av:'A2405ProCProdDsc',fld:'PROCPRODDSC',pic:''},{av:'A2403ProCUnidades',fld:'PROCUNIDADES',pic:'ZZ,ZZZ,ZZZ,ZZ9.999999'},{av:'A2402ProCCosUnidades',fld:'PROCCOSUNIDADES',pic:'ZZZ,ZZZ,ZZZ,ZZ9.9999'},{av:'A2406ProCCostoTotal',fld:'PROCCOSTOTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'A2407ProCCostoUnit',fld:'PROCCOSTOUNIT',pic:'ZZZ,ZZZ,ZZZ,ZZ9.9999'},{av:'A2413ProCTotales',fld:'PROCTOTALES',pic:''},{av:'A2408ProCProducto',fld:'PROCPRODUCTO',pic:''},{av:'A2409ProCProductoDsc',fld:'PROCPRODUCTODSC',pic:''},{av:'A2410ProCRendimiento',fld:'PROCRENDIMIENTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2411ProCTipCambio',fld:'PROCTIPCAMBIO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2412ProCHorOptimas',fld:'PROCHOROPTIMAS',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2383ProCUsuCod'},{av:'Z2384ProCItem'},{av:'Z2404ProCProdCod'},{av:'Z2405ProCProdDsc'},{av:'Z2403ProCUnidades'},{av:'Z2402ProCCosUnidades'},{av:'Z2406ProCCostoTotal'},{av:'Z2407ProCCostoUnit'},{av:'Z2413ProCTotales'},{av:'Z2408ProCProducto'},{av:'Z2409ProCProductoDsc'},{av:'Z2410ProCRendimiento'},{av:'Z2411ProCTipCambio'},{av:'Z2412ProCHorOptimas'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z2383ProCUsuCod = "";
         Z2404ProCProdCod = "";
         Z2405ProCProdDsc = "";
         Z2413ProCTotales = "";
         Z2408ProCProducto = "";
         Z2409ProCProductoDsc = "";
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
         A2383ProCUsuCod = "";
         A2404ProCProdCod = "";
         A2405ProCProdDsc = "";
         A2413ProCTotales = "";
         A2408ProCProducto = "";
         A2409ProCProductoDsc = "";
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
         T007N4_A2383ProCUsuCod = new string[] {""} ;
         T007N4_A2384ProCItem = new short[1] ;
         T007N4_A2404ProCProdCod = new string[] {""} ;
         T007N4_A2405ProCProdDsc = new string[] {""} ;
         T007N4_A2403ProCUnidades = new decimal[1] ;
         T007N4_A2402ProCCosUnidades = new decimal[1] ;
         T007N4_A2406ProCCostoTotal = new decimal[1] ;
         T007N4_A2407ProCCostoUnit = new decimal[1] ;
         T007N4_A2413ProCTotales = new string[] {""} ;
         T007N4_A2408ProCProducto = new string[] {""} ;
         T007N4_A2409ProCProductoDsc = new string[] {""} ;
         T007N4_A2410ProCRendimiento = new decimal[1] ;
         T007N4_A2411ProCTipCambio = new decimal[1] ;
         T007N4_A2412ProCHorOptimas = new decimal[1] ;
         T007N5_A2383ProCUsuCod = new string[] {""} ;
         T007N5_A2384ProCItem = new short[1] ;
         T007N3_A2383ProCUsuCod = new string[] {""} ;
         T007N3_A2384ProCItem = new short[1] ;
         T007N3_A2404ProCProdCod = new string[] {""} ;
         T007N3_A2405ProCProdDsc = new string[] {""} ;
         T007N3_A2403ProCUnidades = new decimal[1] ;
         T007N3_A2402ProCCosUnidades = new decimal[1] ;
         T007N3_A2406ProCCostoTotal = new decimal[1] ;
         T007N3_A2407ProCCostoUnit = new decimal[1] ;
         T007N3_A2413ProCTotales = new string[] {""} ;
         T007N3_A2408ProCProducto = new string[] {""} ;
         T007N3_A2409ProCProductoDsc = new string[] {""} ;
         T007N3_A2410ProCRendimiento = new decimal[1] ;
         T007N3_A2411ProCTipCambio = new decimal[1] ;
         T007N3_A2412ProCHorOptimas = new decimal[1] ;
         sMode211 = "";
         T007N6_A2383ProCUsuCod = new string[] {""} ;
         T007N6_A2384ProCItem = new short[1] ;
         T007N7_A2383ProCUsuCod = new string[] {""} ;
         T007N7_A2384ProCItem = new short[1] ;
         T007N2_A2383ProCUsuCod = new string[] {""} ;
         T007N2_A2384ProCItem = new short[1] ;
         T007N2_A2404ProCProdCod = new string[] {""} ;
         T007N2_A2405ProCProdDsc = new string[] {""} ;
         T007N2_A2403ProCUnidades = new decimal[1] ;
         T007N2_A2402ProCCosUnidades = new decimal[1] ;
         T007N2_A2406ProCCostoTotal = new decimal[1] ;
         T007N2_A2407ProCCostoUnit = new decimal[1] ;
         T007N2_A2413ProCTotales = new string[] {""} ;
         T007N2_A2408ProCProducto = new string[] {""} ;
         T007N2_A2409ProCProductoDsc = new string[] {""} ;
         T007N2_A2410ProCRendimiento = new decimal[1] ;
         T007N2_A2411ProCTipCambio = new decimal[1] ;
         T007N2_A2412ProCHorOptimas = new decimal[1] ;
         T007N11_A2383ProCUsuCod = new string[] {""} ;
         T007N11_A2384ProCItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2383ProCUsuCod = "";
         ZZ2404ProCProdCod = "";
         ZZ2405ProCProdDsc = "";
         ZZ2413ProCTotales = "";
         ZZ2408ProCProducto = "";
         ZZ2409ProCProductoDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.procostoproducto__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procostoproducto__default(),
            new Object[][] {
                new Object[] {
               T007N2_A2383ProCUsuCod, T007N2_A2384ProCItem, T007N2_A2404ProCProdCod, T007N2_A2405ProCProdDsc, T007N2_A2403ProCUnidades, T007N2_A2402ProCCosUnidades, T007N2_A2406ProCCostoTotal, T007N2_A2407ProCCostoUnit, T007N2_A2413ProCTotales, T007N2_A2408ProCProducto,
               T007N2_A2409ProCProductoDsc, T007N2_A2410ProCRendimiento, T007N2_A2411ProCTipCambio, T007N2_A2412ProCHorOptimas
               }
               , new Object[] {
               T007N3_A2383ProCUsuCod, T007N3_A2384ProCItem, T007N3_A2404ProCProdCod, T007N3_A2405ProCProdDsc, T007N3_A2403ProCUnidades, T007N3_A2402ProCCosUnidades, T007N3_A2406ProCCostoTotal, T007N3_A2407ProCCostoUnit, T007N3_A2413ProCTotales, T007N3_A2408ProCProducto,
               T007N3_A2409ProCProductoDsc, T007N3_A2410ProCRendimiento, T007N3_A2411ProCTipCambio, T007N3_A2412ProCHorOptimas
               }
               , new Object[] {
               T007N4_A2383ProCUsuCod, T007N4_A2384ProCItem, T007N4_A2404ProCProdCod, T007N4_A2405ProCProdDsc, T007N4_A2403ProCUnidades, T007N4_A2402ProCCosUnidades, T007N4_A2406ProCCostoTotal, T007N4_A2407ProCCostoUnit, T007N4_A2413ProCTotales, T007N4_A2408ProCProducto,
               T007N4_A2409ProCProductoDsc, T007N4_A2410ProCRendimiento, T007N4_A2411ProCTipCambio, T007N4_A2412ProCHorOptimas
               }
               , new Object[] {
               T007N5_A2383ProCUsuCod, T007N5_A2384ProCItem
               }
               , new Object[] {
               T007N6_A2383ProCUsuCod, T007N6_A2384ProCItem
               }
               , new Object[] {
               T007N7_A2383ProCUsuCod, T007N7_A2384ProCItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007N11_A2383ProCUsuCod, T007N11_A2384ProCItem
               }
            }
         );
      }

      private short Z2384ProCItem ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2384ProCItem ;
      private short GX_JID ;
      private short RcdFound211 ;
      private short nIsDirty_211 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2384ProCItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCUsuCod_Enabled ;
      private int edtProCItem_Enabled ;
      private int edtProCProdCod_Enabled ;
      private int edtProCProdDsc_Enabled ;
      private int edtProCUnidades_Enabled ;
      private int edtProCCosUnidades_Enabled ;
      private int edtProCCostoTotal_Enabled ;
      private int edtProCCostoUnit_Enabled ;
      private int edtProCTotales_Enabled ;
      private int edtProCProducto_Enabled ;
      private int edtProCProductoDsc_Enabled ;
      private int edtProCRendimiento_Enabled ;
      private int edtProCTipCambio_Enabled ;
      private int edtProCHorOptimas_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z2403ProCUnidades ;
      private decimal Z2402ProCCosUnidades ;
      private decimal Z2406ProCCostoTotal ;
      private decimal Z2407ProCCostoUnit ;
      private decimal Z2410ProCRendimiento ;
      private decimal Z2411ProCTipCambio ;
      private decimal Z2412ProCHorOptimas ;
      private decimal A2403ProCUnidades ;
      private decimal A2402ProCCosUnidades ;
      private decimal A2406ProCCostoTotal ;
      private decimal A2407ProCCostoUnit ;
      private decimal A2410ProCRendimiento ;
      private decimal A2411ProCTipCambio ;
      private decimal A2412ProCHorOptimas ;
      private decimal ZZ2403ProCUnidades ;
      private decimal ZZ2402ProCCosUnidades ;
      private decimal ZZ2406ProCCostoTotal ;
      private decimal ZZ2407ProCCostoUnit ;
      private decimal ZZ2410ProCRendimiento ;
      private decimal ZZ2411ProCTipCambio ;
      private decimal ZZ2412ProCHorOptimas ;
      private string sPrefix ;
      private string Z2383ProCUsuCod ;
      private string Z2404ProCProdCod ;
      private string Z2405ProCProdDsc ;
      private string Z2408ProCProducto ;
      private string Z2409ProCProductoDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCUsuCod_Internalname ;
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
      private string A2383ProCUsuCod ;
      private string edtProCUsuCod_Jsonclick ;
      private string edtProCItem_Internalname ;
      private string edtProCItem_Jsonclick ;
      private string edtProCProdCod_Internalname ;
      private string A2404ProCProdCod ;
      private string edtProCProdCod_Jsonclick ;
      private string edtProCProdDsc_Internalname ;
      private string A2405ProCProdDsc ;
      private string edtProCProdDsc_Jsonclick ;
      private string edtProCUnidades_Internalname ;
      private string edtProCUnidades_Jsonclick ;
      private string edtProCCosUnidades_Internalname ;
      private string edtProCCosUnidades_Jsonclick ;
      private string edtProCCostoTotal_Internalname ;
      private string edtProCCostoTotal_Jsonclick ;
      private string edtProCCostoUnit_Internalname ;
      private string edtProCCostoUnit_Jsonclick ;
      private string edtProCTotales_Internalname ;
      private string edtProCTotales_Jsonclick ;
      private string edtProCProducto_Internalname ;
      private string A2408ProCProducto ;
      private string edtProCProducto_Jsonclick ;
      private string edtProCProductoDsc_Internalname ;
      private string A2409ProCProductoDsc ;
      private string edtProCProductoDsc_Jsonclick ;
      private string edtProCRendimiento_Internalname ;
      private string edtProCRendimiento_Jsonclick ;
      private string edtProCTipCambio_Internalname ;
      private string edtProCTipCambio_Jsonclick ;
      private string edtProCHorOptimas_Internalname ;
      private string edtProCHorOptimas_Jsonclick ;
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
      private string sMode211 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2383ProCUsuCod ;
      private string ZZ2404ProCProdCod ;
      private string ZZ2405ProCProdDsc ;
      private string ZZ2408ProCProducto ;
      private string ZZ2409ProCProductoDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2413ProCTotales ;
      private string A2413ProCTotales ;
      private string ZZ2413ProCTotales ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007N4_A2383ProCUsuCod ;
      private short[] T007N4_A2384ProCItem ;
      private string[] T007N4_A2404ProCProdCod ;
      private string[] T007N4_A2405ProCProdDsc ;
      private decimal[] T007N4_A2403ProCUnidades ;
      private decimal[] T007N4_A2402ProCCosUnidades ;
      private decimal[] T007N4_A2406ProCCostoTotal ;
      private decimal[] T007N4_A2407ProCCostoUnit ;
      private string[] T007N4_A2413ProCTotales ;
      private string[] T007N4_A2408ProCProducto ;
      private string[] T007N4_A2409ProCProductoDsc ;
      private decimal[] T007N4_A2410ProCRendimiento ;
      private decimal[] T007N4_A2411ProCTipCambio ;
      private decimal[] T007N4_A2412ProCHorOptimas ;
      private string[] T007N5_A2383ProCUsuCod ;
      private short[] T007N5_A2384ProCItem ;
      private string[] T007N3_A2383ProCUsuCod ;
      private short[] T007N3_A2384ProCItem ;
      private string[] T007N3_A2404ProCProdCod ;
      private string[] T007N3_A2405ProCProdDsc ;
      private decimal[] T007N3_A2403ProCUnidades ;
      private decimal[] T007N3_A2402ProCCosUnidades ;
      private decimal[] T007N3_A2406ProCCostoTotal ;
      private decimal[] T007N3_A2407ProCCostoUnit ;
      private string[] T007N3_A2413ProCTotales ;
      private string[] T007N3_A2408ProCProducto ;
      private string[] T007N3_A2409ProCProductoDsc ;
      private decimal[] T007N3_A2410ProCRendimiento ;
      private decimal[] T007N3_A2411ProCTipCambio ;
      private decimal[] T007N3_A2412ProCHorOptimas ;
      private string[] T007N6_A2383ProCUsuCod ;
      private short[] T007N6_A2384ProCItem ;
      private string[] T007N7_A2383ProCUsuCod ;
      private short[] T007N7_A2384ProCItem ;
      private string[] T007N2_A2383ProCUsuCod ;
      private short[] T007N2_A2384ProCItem ;
      private string[] T007N2_A2404ProCProdCod ;
      private string[] T007N2_A2405ProCProdDsc ;
      private decimal[] T007N2_A2403ProCUnidades ;
      private decimal[] T007N2_A2402ProCCosUnidades ;
      private decimal[] T007N2_A2406ProCCostoTotal ;
      private decimal[] T007N2_A2407ProCCostoUnit ;
      private string[] T007N2_A2413ProCTotales ;
      private string[] T007N2_A2408ProCProducto ;
      private string[] T007N2_A2409ProCProductoDsc ;
      private decimal[] T007N2_A2410ProCRendimiento ;
      private decimal[] T007N2_A2411ProCTipCambio ;
      private decimal[] T007N2_A2412ProCHorOptimas ;
      private string[] T007N11_A2383ProCUsuCod ;
      private short[] T007N11_A2384ProCItem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class procostoproducto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class procostoproducto__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007N4;
        prmT007N4 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N5;
        prmT007N5 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N3;
        prmT007N3 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N6;
        prmT007N6 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N7;
        prmT007N7 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N2;
        prmT007N2 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N8;
        prmT007N8 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0) ,
        new ParDef("@ProCProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCUnidades",GXType.Decimal,18,6) ,
        new ParDef("@ProCCosUnidades",GXType.Decimal,15,4) ,
        new ParDef("@ProCCostoTotal",GXType.Decimal,15,2) ,
        new ParDef("@ProCCostoUnit",GXType.Decimal,15,4) ,
        new ParDef("@ProCTotales",GXType.NVarChar,1,0) ,
        new ParDef("@ProCProducto",GXType.NChar,15,0) ,
        new ParDef("@ProCProductoDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCRendimiento",GXType.Decimal,15,2) ,
        new ParDef("@ProCTipCambio",GXType.Decimal,15,4) ,
        new ParDef("@ProCHorOptimas",GXType.Decimal,15,2)
        };
        Object[] prmT007N9;
        prmT007N9 = new Object[] {
        new ParDef("@ProCProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCUnidades",GXType.Decimal,18,6) ,
        new ParDef("@ProCCosUnidades",GXType.Decimal,15,4) ,
        new ParDef("@ProCCostoTotal",GXType.Decimal,15,2) ,
        new ParDef("@ProCCostoUnit",GXType.Decimal,15,4) ,
        new ParDef("@ProCTotales",GXType.NVarChar,1,0) ,
        new ParDef("@ProCProducto",GXType.NChar,15,0) ,
        new ParDef("@ProCProductoDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCRendimiento",GXType.Decimal,15,2) ,
        new ParDef("@ProCTipCambio",GXType.Decimal,15,4) ,
        new ParDef("@ProCHorOptimas",GXType.Decimal,15,2) ,
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N10;
        prmT007N10 = new Object[] {
        new ParDef("@ProCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@ProCItem",GXType.Int16,4,0)
        };
        Object[] prmT007N11;
        prmT007N11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007N2", "SELECT [ProCUsuCod], [ProCItem], [ProCProdCod], [ProCProdDsc], [ProCUnidades], [ProCCosUnidades], [ProCCostoTotal], [ProCCostoUnit], [ProCTotales], [ProCProducto], [ProCProductoDsc], [ProCRendimiento], [ProCTipCambio], [ProCHorOptimas] FROM [PROCOSTOPRODUCTO] WITH (UPDLOCK) WHERE [ProCUsuCod] = @ProCUsuCod AND [ProCItem] = @ProCItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007N3", "SELECT [ProCUsuCod], [ProCItem], [ProCProdCod], [ProCProdDsc], [ProCUnidades], [ProCCosUnidades], [ProCCostoTotal], [ProCCostoUnit], [ProCTotales], [ProCProducto], [ProCProductoDsc], [ProCRendimiento], [ProCTipCambio], [ProCHorOptimas] FROM [PROCOSTOPRODUCTO] WHERE [ProCUsuCod] = @ProCUsuCod AND [ProCItem] = @ProCItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007N4", "SELECT TM1.[ProCUsuCod], TM1.[ProCItem], TM1.[ProCProdCod], TM1.[ProCProdDsc], TM1.[ProCUnidades], TM1.[ProCCosUnidades], TM1.[ProCCostoTotal], TM1.[ProCCostoUnit], TM1.[ProCTotales], TM1.[ProCProducto], TM1.[ProCProductoDsc], TM1.[ProCRendimiento], TM1.[ProCTipCambio], TM1.[ProCHorOptimas] FROM [PROCOSTOPRODUCTO] TM1 WHERE TM1.[ProCUsuCod] = @ProCUsuCod and TM1.[ProCItem] = @ProCItem ORDER BY TM1.[ProCUsuCod], TM1.[ProCItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007N5", "SELECT [ProCUsuCod], [ProCItem] FROM [PROCOSTOPRODUCTO] WHERE [ProCUsuCod] = @ProCUsuCod AND [ProCItem] = @ProCItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007N6", "SELECT TOP 1 [ProCUsuCod], [ProCItem] FROM [PROCOSTOPRODUCTO] WHERE ( [ProCUsuCod] > @ProCUsuCod or [ProCUsuCod] = @ProCUsuCod and [ProCItem] > @ProCItem) ORDER BY [ProCUsuCod], [ProCItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007N7", "SELECT TOP 1 [ProCUsuCod], [ProCItem] FROM [PROCOSTOPRODUCTO] WHERE ( [ProCUsuCod] < @ProCUsuCod or [ProCUsuCod] = @ProCUsuCod and [ProCItem] < @ProCItem) ORDER BY [ProCUsuCod] DESC, [ProCItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007N8", "INSERT INTO [PROCOSTOPRODUCTO]([ProCUsuCod], [ProCItem], [ProCProdCod], [ProCProdDsc], [ProCUnidades], [ProCCosUnidades], [ProCCostoTotal], [ProCCostoUnit], [ProCTotales], [ProCProducto], [ProCProductoDsc], [ProCRendimiento], [ProCTipCambio], [ProCHorOptimas]) VALUES(@ProCUsuCod, @ProCItem, @ProCProdCod, @ProCProdDsc, @ProCUnidades, @ProCCosUnidades, @ProCCostoTotal, @ProCCostoUnit, @ProCTotales, @ProCProducto, @ProCProductoDsc, @ProCRendimiento, @ProCTipCambio, @ProCHorOptimas)", GxErrorMask.GX_NOMASK,prmT007N8)
           ,new CursorDef("T007N9", "UPDATE [PROCOSTOPRODUCTO] SET [ProCProdCod]=@ProCProdCod, [ProCProdDsc]=@ProCProdDsc, [ProCUnidades]=@ProCUnidades, [ProCCosUnidades]=@ProCCosUnidades, [ProCCostoTotal]=@ProCCostoTotal, [ProCCostoUnit]=@ProCCostoUnit, [ProCTotales]=@ProCTotales, [ProCProducto]=@ProCProducto, [ProCProductoDsc]=@ProCProductoDsc, [ProCRendimiento]=@ProCRendimiento, [ProCTipCambio]=@ProCTipCambio, [ProCHorOptimas]=@ProCHorOptimas  WHERE [ProCUsuCod] = @ProCUsuCod AND [ProCItem] = @ProCItem", GxErrorMask.GX_NOMASK,prmT007N9)
           ,new CursorDef("T007N10", "DELETE FROM [PROCOSTOPRODUCTO]  WHERE [ProCUsuCod] = @ProCUsuCod AND [ProCItem] = @ProCItem", GxErrorMask.GX_NOMASK,prmT007N10)
           ,new CursorDef("T007N11", "SELECT [ProCUsuCod], [ProCItem] FROM [PROCOSTOPRODUCTO] ORDER BY [ProCUsuCod], [ProCItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007N11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 100);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 100);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 100);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
