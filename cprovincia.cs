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
   public class cprovincia : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A139PaiCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A139PaiCod, A140EstCod) ;
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
            Form.Meta.addItem("description", "Provincias", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cprovincia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cprovincia( IGxContext context )
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
         cmbProvSts = new GXCombobox();
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
         if ( cmbProvSts.ItemCount > 0 )
         {
            A1742ProvSts = (short)(NumberUtil.Val( cmbProvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0))), "."));
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            AssignProp("", false, cmbProvSts_Internalname, "Values", cmbProvSts.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Provincias", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPROVINCIA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPROVINCIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaiCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaiCod_Internalname, "Pais", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEstCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCod_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvCod_Internalname, "Provincia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvDsc_Internalname, "Provincia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvDsc_Internalname, StringUtil.RTrim( A603ProvDsc), StringUtil.RTrim( context.localUtil.Format( A603ProvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvAbr_Internalname, "Abr. Provincia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvAbr_Internalname, StringUtil.RTrim( A1741ProvAbr), StringUtil.RTrim( context.localUtil.Format( A1741ProvAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbProvSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProvSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProvSts, cmbProvSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0)), 1, cmbProvSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbProvSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 1, "HLP_CPROVINCIA.htm");
         cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         AssignProp("", false, cmbProvSts_Internalname, "Values", (string)(cmbProvSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPROVINCIA.htm");
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
            Z139PaiCod = cgiGet( "Z139PaiCod");
            Z140EstCod = cgiGet( "Z140EstCod");
            Z141ProvCod = cgiGet( "Z141ProvCod");
            Z603ProvDsc = cgiGet( "Z603ProvDsc");
            Z1741ProvAbr = cgiGet( "Z1741ProvAbr");
            Z1742ProvSts = (short)(context.localUtil.CToN( cgiGet( "Z1742ProvSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1500PaiDsc = cgiGet( "PAIDSC");
            /* Read variables values. */
            A139PaiCod = cgiGet( edtPaiCod_Internalname);
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = cgiGet( edtEstCod_Internalname);
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = cgiGet( edtProvCod_Internalname);
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A603ProvDsc = cgiGet( edtProvDsc_Internalname);
            AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
            A1741ProvAbr = cgiGet( edtProvAbr_Internalname);
            AssignAttri("", false, "A1741ProvAbr", A1741ProvAbr);
            cmbProvSts.CurrentValue = cgiGet( cmbProvSts_Internalname);
            A1742ProvSts = (short)(NumberUtil.Val( cgiGet( cmbProvSts_Internalname), "."));
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
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
               A139PaiCod = GetPar( "PaiCod");
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = GetPar( "EstCod");
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = GetPar( "ProvCod");
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
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
               InitAll3O127( ) ;
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
         DisableAttributes3O127( ) ;
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

      protected void ResetCaption3O0( )
      {
      }

      protected void ZM3O127( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z603ProvDsc = T003O3_A603ProvDsc[0];
               Z1741ProvAbr = T003O3_A1741ProvAbr[0];
               Z1742ProvSts = T003O3_A1742ProvSts[0];
            }
            else
            {
               Z603ProvDsc = A603ProvDsc;
               Z1741ProvAbr = A1741ProvAbr;
               Z1742ProvSts = A1742ProvSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z141ProvCod = A141ProvCod;
            Z603ProvDsc = A603ProvDsc;
            Z1741ProvAbr = A1741ProvAbr;
            Z1742ProvSts = A1742ProvSts;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z1500PaiDsc = A1500PaiDsc;
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

      protected void Load3O127( )
      {
         /* Using cursor T003O6 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound127 = 1;
            A603ProvDsc = T003O6_A603ProvDsc[0];
            AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
            A1500PaiDsc = T003O6_A1500PaiDsc[0];
            A1741ProvAbr = T003O6_A1741ProvAbr[0];
            AssignAttri("", false, "A1741ProvAbr", A1741ProvAbr);
            A1742ProvSts = T003O6_A1742ProvSts[0];
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            ZM3O127( -1) ;
         }
         pr_default.close(4);
         OnLoadActions3O127( ) ;
      }

      protected void OnLoadActions3O127( )
      {
      }

      protected void CheckExtendedTable3O127( )
      {
         nIsDirty_127 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003O4 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T003O4_A1500PaiDsc[0];
         pr_default.close(2);
         /* Using cursor T003O5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors3O127( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A139PaiCod )
      {
         /* Using cursor T003O7 */
         pr_default.execute(5, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T003O7_A1500PaiDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1500PaiDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A139PaiCod ,
                               string A140EstCod )
      {
         /* Using cursor T003O8 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey3O127( )
      {
         /* Using cursor T003O9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound127 = 1;
         }
         else
         {
            RcdFound127 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003O3 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3O127( 1) ;
            RcdFound127 = 1;
            A141ProvCod = T003O3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A603ProvDsc = T003O3_A603ProvDsc[0];
            AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
            A1741ProvAbr = T003O3_A1741ProvAbr[0];
            AssignAttri("", false, "A1741ProvAbr", A1741ProvAbr);
            A1742ProvSts = T003O3_A1742ProvSts[0];
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
            A139PaiCod = T003O3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T003O3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3O127( ) ;
            if ( AnyError == 1 )
            {
               RcdFound127 = 0;
               InitializeNonKey3O127( ) ;
            }
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound127 = 0;
            InitializeNonKey3O127( ) ;
            sMode127 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode127;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3O127( ) ;
         if ( RcdFound127 == 0 )
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
         RcdFound127 = 0;
         /* Using cursor T003O10 */
         pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T003O10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A141ProvCod[0], A141ProvCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T003O10_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O10_A141ProvCod[0], A141ProvCod) > 0 ) ) )
            {
               A139PaiCod = T003O10_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T003O10_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T003O10_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               RcdFound127 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound127 = 0;
         /* Using cursor T003O11 */
         pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T003O11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A141ProvCod[0], A141ProvCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T003O11_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T003O11_A141ProvCod[0], A141ProvCod) < 0 ) ) )
            {
               A139PaiCod = T003O11_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T003O11_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T003O11_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               RcdFound127 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3O127( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3O127( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound127 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  A141ProvCod = Z141ProvCod;
                  AssignAttri("", false, "A141ProvCod", A141ProvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAICOD");
                  AnyError = 1;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3O127( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3O127( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAICOD");
                     AnyError = 1;
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3O127( ) ;
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
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = Z141ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaiCod_Internalname;
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
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3O127( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3O127( ) ;
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
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProvDsc_Internalname;
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
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProvDsc_Internalname;
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
         ScanStart3O127( ) ;
         if ( RcdFound127 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound127 != 0 )
            {
               ScanNext3O127( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3O127( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3O127( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003O2 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPROVINCIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z603ProvDsc, T003O2_A603ProvDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1741ProvAbr, T003O2_A1741ProvAbr[0]) != 0 ) || ( Z1742ProvSts != T003O2_A1742ProvSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z603ProvDsc, T003O2_A603ProvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cprovincia:[seudo value changed for attri]"+"ProvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z603ProvDsc);
                  GXUtil.WriteLogRaw("Current: ",T003O2_A603ProvDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1741ProvAbr, T003O2_A1741ProvAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cprovincia:[seudo value changed for attri]"+"ProvAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1741ProvAbr);
                  GXUtil.WriteLogRaw("Current: ",T003O2_A1741ProvAbr[0]);
               }
               if ( Z1742ProvSts != T003O2_A1742ProvSts[0] )
               {
                  GXUtil.WriteLog("cprovincia:[seudo value changed for attri]"+"ProvSts");
                  GXUtil.WriteLogRaw("Old: ",Z1742ProvSts);
                  GXUtil.WriteLogRaw("Current: ",T003O2_A1742ProvSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPROVINCIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3O127( )
      {
         BeforeValidate3O127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3O127( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3O127( 0) ;
            CheckOptimisticConcurrency3O127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3O127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3O127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003O12 */
                     pr_default.execute(10, new Object[] {A141ProvCod, A603ProvDsc, A1741ProvAbr, A1742ProvSts, A139PaiCod, A140EstCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption3O0( ) ;
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
               Load3O127( ) ;
            }
            EndLevel3O127( ) ;
         }
         CloseExtendedTableCursors3O127( ) ;
      }

      protected void Update3O127( )
      {
         BeforeValidate3O127( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3O127( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3O127( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3O127( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3O127( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003O13 */
                     pr_default.execute(11, new Object[] {A603ProvDsc, A1741ProvAbr, A1742ProvSts, A139PaiCod, A140EstCod, A141ProvCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPROVINCIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3O127( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3O0( ) ;
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
            EndLevel3O127( ) ;
         }
         CloseExtendedTableCursors3O127( ) ;
      }

      protected void DeferredUpdate3O127( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3O127( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3O127( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3O127( ) ;
            AfterConfirm3O127( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3O127( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003O14 */
                  pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPROVINCIA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound127 == 0 )
                        {
                           InitAll3O127( ) ;
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
                        ResetCaption3O0( ) ;
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
         sMode127 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3O127( ) ;
         Gx_mode = sMode127;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3O127( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003O15 */
            pr_default.execute(13, new Object[] {A139PaiCod});
            A1500PaiDsc = T003O15_A1500PaiDsc[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003O16 */
            pr_default.execute(14, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Distritos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel3O127( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3O127( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cprovincia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cprovincia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3O127( )
      {
         /* Scan By routine */
         /* Using cursor T003O17 */
         pr_default.execute(15);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound127 = 1;
            A139PaiCod = T003O17_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T003O17_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T003O17_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3O127( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound127 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound127 = 1;
            A139PaiCod = T003O17_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T003O17_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T003O17_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
      }

      protected void ScanEnd3O127( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm3O127( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3O127( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3O127( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3O127( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3O127( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3O127( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3O127( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtProvDsc_Enabled = 0;
         AssignProp("", false, edtProvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvDsc_Enabled), 5, 0), true);
         edtProvAbr_Enabled = 0;
         AssignProp("", false, edtProvAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvAbr_Enabled), 5, 0), true);
         cmbProvSts.Enabled = 0;
         AssignProp("", false, cmbProvSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProvSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3O127( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3O0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025141", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cprovincia.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z603ProvDsc", StringUtil.RTrim( Z603ProvDsc));
         GxWebStd.gx_hidden_field( context, "Z1741ProvAbr", StringUtil.RTrim( Z1741ProvAbr));
         GxWebStd.gx_hidden_field( context, "Z1742ProvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1742ProvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PAIDSC", StringUtil.RTrim( A1500PaiDsc));
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
         return formatLink("cprovincia.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPROVINCIA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Provincias" ;
      }

      protected void InitializeNonKey3O127( )
      {
         A603ProvDsc = "";
         AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A1741ProvAbr = "";
         AssignAttri("", false, "A1741ProvAbr", A1741ProvAbr);
         A1742ProvSts = 0;
         AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         Z603ProvDsc = "";
         Z1741ProvAbr = "";
         Z1742ProvSts = 0;
      }

      protected void InitAll3O127( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         InitializeNonKey3O127( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025149", true, true);
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
         context.AddJavascriptSource("cprovincia.js", "?202281810251410", false, true);
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
         edtPaiCod_Internalname = "PAICOD";
         edtEstCod_Internalname = "ESTCOD";
         edtProvCod_Internalname = "PROVCOD";
         edtProvDsc_Internalname = "PROVDSC";
         edtProvAbr_Internalname = "PROVABR";
         cmbProvSts_Internalname = "PROVSTS";
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
         Form.Caption = "Provincias";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbProvSts_Jsonclick = "";
         cmbProvSts.Enabled = 1;
         edtProvAbr_Jsonclick = "";
         edtProvAbr_Enabled = 1;
         edtProvDsc_Jsonclick = "";
         edtProvDsc_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
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
         cmbProvSts.Name = "PROVSTS";
         cmbProvSts.WebTags = "";
         cmbProvSts.addItem("1", "ACTIVO", 0);
         cmbProvSts.addItem("0", "INACTIVO", 0);
         if ( cmbProvSts.ItemCount > 0 )
         {
            A1742ProvSts = (short)(NumberUtil.Val( cmbProvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0))), "."));
            AssignAttri("", false, "A1742ProvSts", StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T003O15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T003O15_A1500PaiDsc[0];
         pr_default.close(13);
         /* Using cursor T003O18 */
         pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtProvDsc_Internalname;
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

      public void Valid_Paicod( )
      {
         /* Using cursor T003O15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A1500PaiDsc = T003O15_A1500PaiDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
      }

      public void Valid_Estcod( )
      {
         /* Using cursor T003O18 */
         pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Provcod( )
      {
         A1742ProvSts = (short)(NumberUtil.Val( cmbProvSts.CurrentValue, "."));
         cmbProvSts.CurrentValue = StringUtil.Str( (decimal)(A1742ProvSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbProvSts.ItemCount > 0 )
         {
            A1742ProvSts = (short)(NumberUtil.Val( cmbProvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0))), "."));
            cmbProvSts.CurrentValue = StringUtil.Str( (decimal)(A1742ProvSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A603ProvDsc", StringUtil.RTrim( A603ProvDsc));
         AssignAttri("", false, "A1741ProvAbr", StringUtil.RTrim( A1741ProvAbr));
         AssignAttri("", false, "A1742ProvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1742ProvSts), 1, 0, ".", "")));
         cmbProvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1742ProvSts), 1, 0));
         AssignProp("", false, cmbProvSts_Internalname, "Values", cmbProvSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z603ProvDsc", StringUtil.RTrim( Z603ProvDsc));
         GxWebStd.gx_hidden_field( context, "Z1741ProvAbr", StringUtil.RTrim( Z1741ProvAbr));
         GxWebStd.gx_hidden_field( context, "Z1742ProvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1742ProvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1500PaiDsc", StringUtil.RTrim( Z1500PaiDsc));
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
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''}]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'cmbProvSts'},{av:'A1742ProvSts',fld:'PROVSTS',pic:'9'},{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[{av:'A603ProvDsc',fld:'PROVDSC',pic:''},{av:'A1741ProvAbr',fld:'PROVABR',pic:''},{av:'cmbProvSts'},{av:'A1742ProvSts',fld:'PROVSTS',pic:'9'},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z139PaiCod'},{av:'Z140EstCod'},{av:'Z141ProvCod'},{av:'Z603ProvDsc'},{av:'Z1741ProvAbr'},{av:'Z1742ProvSts'},{av:'Z1500PaiDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z603ProvDsc = "";
         Z1741ProvAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
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
         A141ProvCod = "";
         A603ProvDsc = "";
         A1741ProvAbr = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         A1500PaiDsc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1500PaiDsc = "";
         T003O6_A141ProvCod = new string[] {""} ;
         T003O6_A603ProvDsc = new string[] {""} ;
         T003O6_A1500PaiDsc = new string[] {""} ;
         T003O6_A1741ProvAbr = new string[] {""} ;
         T003O6_A1742ProvSts = new short[1] ;
         T003O6_A139PaiCod = new string[] {""} ;
         T003O6_A140EstCod = new string[] {""} ;
         T003O4_A1500PaiDsc = new string[] {""} ;
         T003O5_A139PaiCod = new string[] {""} ;
         T003O7_A1500PaiDsc = new string[] {""} ;
         T003O8_A139PaiCod = new string[] {""} ;
         T003O9_A139PaiCod = new string[] {""} ;
         T003O9_A140EstCod = new string[] {""} ;
         T003O9_A141ProvCod = new string[] {""} ;
         T003O3_A141ProvCod = new string[] {""} ;
         T003O3_A603ProvDsc = new string[] {""} ;
         T003O3_A1741ProvAbr = new string[] {""} ;
         T003O3_A1742ProvSts = new short[1] ;
         T003O3_A139PaiCod = new string[] {""} ;
         T003O3_A140EstCod = new string[] {""} ;
         sMode127 = "";
         T003O10_A139PaiCod = new string[] {""} ;
         T003O10_A140EstCod = new string[] {""} ;
         T003O10_A141ProvCod = new string[] {""} ;
         T003O11_A139PaiCod = new string[] {""} ;
         T003O11_A140EstCod = new string[] {""} ;
         T003O11_A141ProvCod = new string[] {""} ;
         T003O2_A141ProvCod = new string[] {""} ;
         T003O2_A603ProvDsc = new string[] {""} ;
         T003O2_A1741ProvAbr = new string[] {""} ;
         T003O2_A1742ProvSts = new short[1] ;
         T003O2_A139PaiCod = new string[] {""} ;
         T003O2_A140EstCod = new string[] {""} ;
         T003O15_A1500PaiDsc = new string[] {""} ;
         T003O16_A139PaiCod = new string[] {""} ;
         T003O16_A140EstCod = new string[] {""} ;
         T003O16_A141ProvCod = new string[] {""} ;
         T003O16_A142DisCod = new string[] {""} ;
         T003O17_A139PaiCod = new string[] {""} ;
         T003O17_A140EstCod = new string[] {""} ;
         T003O17_A141ProvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003O18_A139PaiCod = new string[] {""} ;
         ZZ139PaiCod = "";
         ZZ140EstCod = "";
         ZZ141ProvCod = "";
         ZZ603ProvDsc = "";
         ZZ1741ProvAbr = "";
         ZZ1500PaiDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cprovincia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cprovincia__default(),
            new Object[][] {
                new Object[] {
               T003O2_A141ProvCod, T003O2_A603ProvDsc, T003O2_A1741ProvAbr, T003O2_A1742ProvSts, T003O2_A139PaiCod, T003O2_A140EstCod
               }
               , new Object[] {
               T003O3_A141ProvCod, T003O3_A603ProvDsc, T003O3_A1741ProvAbr, T003O3_A1742ProvSts, T003O3_A139PaiCod, T003O3_A140EstCod
               }
               , new Object[] {
               T003O4_A1500PaiDsc
               }
               , new Object[] {
               T003O5_A139PaiCod
               }
               , new Object[] {
               T003O6_A141ProvCod, T003O6_A603ProvDsc, T003O6_A1500PaiDsc, T003O6_A1741ProvAbr, T003O6_A1742ProvSts, T003O6_A139PaiCod, T003O6_A140EstCod
               }
               , new Object[] {
               T003O7_A1500PaiDsc
               }
               , new Object[] {
               T003O8_A139PaiCod
               }
               , new Object[] {
               T003O9_A139PaiCod, T003O9_A140EstCod, T003O9_A141ProvCod
               }
               , new Object[] {
               T003O10_A139PaiCod, T003O10_A140EstCod, T003O10_A141ProvCod
               }
               , new Object[] {
               T003O11_A139PaiCod, T003O11_A140EstCod, T003O11_A141ProvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003O15_A1500PaiDsc
               }
               , new Object[] {
               T003O16_A139PaiCod, T003O16_A140EstCod, T003O16_A141ProvCod, T003O16_A142DisCod
               }
               , new Object[] {
               T003O17_A139PaiCod, T003O17_A140EstCod, T003O17_A141ProvCod
               }
               , new Object[] {
               T003O18_A139PaiCod
               }
            }
         );
      }

      private short Z1742ProvSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1742ProvSts ;
      private short GX_JID ;
      private short RcdFound127 ;
      private short nIsDirty_127 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1742ProvSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Enabled ;
      private int edtProvCod_Enabled ;
      private int edtProvDsc_Enabled ;
      private int edtProvAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z603ProvDsc ;
      private string Z1741ProvAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbProvSts_Internalname ;
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
      private string edtPaiCod_Jsonclick ;
      private string edtEstCod_Internalname ;
      private string edtEstCod_Jsonclick ;
      private string edtProvCod_Internalname ;
      private string A141ProvCod ;
      private string edtProvCod_Jsonclick ;
      private string edtProvDsc_Internalname ;
      private string A603ProvDsc ;
      private string edtProvDsc_Jsonclick ;
      private string edtProvAbr_Internalname ;
      private string A1741ProvAbr ;
      private string edtProvAbr_Jsonclick ;
      private string cmbProvSts_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string A1500PaiDsc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1500PaiDsc ;
      private string sMode127 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ139PaiCod ;
      private string ZZ140EstCod ;
      private string ZZ141ProvCod ;
      private string ZZ603ProvDsc ;
      private string ZZ1741ProvAbr ;
      private string ZZ1500PaiDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProvSts ;
      private IDataStoreProvider pr_default ;
      private string[] T003O6_A141ProvCod ;
      private string[] T003O6_A603ProvDsc ;
      private string[] T003O6_A1500PaiDsc ;
      private string[] T003O6_A1741ProvAbr ;
      private short[] T003O6_A1742ProvSts ;
      private string[] T003O6_A139PaiCod ;
      private string[] T003O6_A140EstCod ;
      private string[] T003O4_A1500PaiDsc ;
      private string[] T003O5_A139PaiCod ;
      private string[] T003O7_A1500PaiDsc ;
      private string[] T003O8_A139PaiCod ;
      private string[] T003O9_A139PaiCod ;
      private string[] T003O9_A140EstCod ;
      private string[] T003O9_A141ProvCod ;
      private string[] T003O3_A141ProvCod ;
      private string[] T003O3_A603ProvDsc ;
      private string[] T003O3_A1741ProvAbr ;
      private short[] T003O3_A1742ProvSts ;
      private string[] T003O3_A139PaiCod ;
      private string[] T003O3_A140EstCod ;
      private string[] T003O10_A139PaiCod ;
      private string[] T003O10_A140EstCod ;
      private string[] T003O10_A141ProvCod ;
      private string[] T003O11_A139PaiCod ;
      private string[] T003O11_A140EstCod ;
      private string[] T003O11_A141ProvCod ;
      private string[] T003O2_A141ProvCod ;
      private string[] T003O2_A603ProvDsc ;
      private string[] T003O2_A1741ProvAbr ;
      private short[] T003O2_A1742ProvSts ;
      private string[] T003O2_A139PaiCod ;
      private string[] T003O2_A140EstCod ;
      private string[] T003O15_A1500PaiDsc ;
      private string[] T003O16_A139PaiCod ;
      private string[] T003O16_A140EstCod ;
      private string[] T003O16_A141ProvCod ;
      private string[] T003O16_A142DisCod ;
      private string[] T003O17_A139PaiCod ;
      private string[] T003O17_A140EstCod ;
      private string[] T003O17_A141ProvCod ;
      private string[] T003O18_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cprovincia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cprovincia__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003O6;
        prmT003O6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O4;
        prmT003O4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003O5;
        prmT003O5 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT003O7;
        prmT003O7 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003O8;
        prmT003O8 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT003O9;
        prmT003O9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O3;
        prmT003O3 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O10;
        prmT003O10 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O11;
        prmT003O11 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O2;
        prmT003O2 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O12;
        prmT003O12 = new Object[] {
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@ProvDsc",GXType.NChar,100,0) ,
        new ParDef("@ProvAbr",GXType.NChar,5,0) ,
        new ParDef("@ProvSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT003O13;
        prmT003O13 = new Object[] {
        new ParDef("@ProvDsc",GXType.NChar,100,0) ,
        new ParDef("@ProvAbr",GXType.NChar,5,0) ,
        new ParDef("@ProvSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O14;
        prmT003O14 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O16;
        prmT003O16 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT003O17;
        prmT003O17 = new Object[] {
        };
        Object[] prmT003O15;
        prmT003O15 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003O18;
        prmT003O18 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003O2", "SELECT [ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod] FROM [CPROVINCIA] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O3", "SELECT [ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O4", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O5", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O6", "SELECT TM1.[ProvCod], TM1.[ProvDsc], T2.[PaiDsc], TM1.[ProvAbr], TM1.[ProvSts], TM1.[PaiCod], TM1.[EstCod] FROM ([CPROVINCIA] TM1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = TM1.[PaiCod]) WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod and TM1.[ProvCod] = @ProvCod ORDER BY TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003O6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O7", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O8", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O9", "SELECT [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003O9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O10", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] > @ProvCod) ORDER BY [PaiCod], [EstCod], [ProvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003O10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003O11", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] < @ProvCod) ORDER BY [PaiCod] DESC, [EstCod] DESC, [ProvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003O11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003O12", "INSERT INTO [CPROVINCIA]([ProvCod], [ProvDsc], [ProvAbr], [ProvSts], [PaiCod], [EstCod]) VALUES(@ProvCod, @ProvDsc, @ProvAbr, @ProvSts, @PaiCod, @EstCod)", GxErrorMask.GX_NOMASK,prmT003O12)
           ,new CursorDef("T003O13", "UPDATE [CPROVINCIA] SET [ProvDsc]=@ProvDsc, [ProvAbr]=@ProvAbr, [ProvSts]=@ProvSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod", GxErrorMask.GX_NOMASK,prmT003O13)
           ,new CursorDef("T003O14", "DELETE FROM [CPROVINCIA]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod", GxErrorMask.GX_NOMASK,prmT003O14)
           ,new CursorDef("T003O15", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O16", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003O17", "SELECT [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] ORDER BY [PaiCod], [EstCod], [ProvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003O17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003O18", "SELECT [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003O18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
