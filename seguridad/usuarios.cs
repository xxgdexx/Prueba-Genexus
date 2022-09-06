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
namespace GeneXus.Programs.seguridad {
   public class usuarios : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A2041UsuVend = (int)(NumberUtil.Val( GetPar( "UsuVend"), "."));
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A2041UsuVend) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A2040UsuTieCod = (int)(NumberUtil.Val( GetPar( "UsuTieCod"), "."));
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A2040UsuTieCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A69AreCod = (int)(NumberUtil.Val( GetPar( "AreCod"), "."));
            n69AreCod = false;
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A69AreCod) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.usuarios.aspx")), "seguridad.usuarios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.usuarios.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV18UsuCod = GetPar( "UsuCod");
                  AssignAttri("", false, "AV18UsuCod", AV18UsuCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18UsuCod, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
            Form.Meta.addItem("description", "Usuarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public usuarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_UsuCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV18UsuCod = aP1_UsuCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbUsuAutPago = new GXCombobox();
         chkUsuAut1 = new GXCheckbox();
         chkUsuAut2 = new GXCheckbox();
         chkUsuAutOcom = new GXCheckbox();
         chkUsuReqADM = new GXCheckbox();
         chkUsuOcMail = new GXCheckbox();
         chkUsuPedMail = new GXCheckbox();
         cmbUsuSts = new GXCombobox();
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
         if ( cmbUsuAutPago.ItemCount > 0 )
         {
            A2012UsuAutPago = (short)(NumberUtil.Val( cmbUsuAutPago.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0))), "."));
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuAutPago.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            AssignProp("", false, cmbUsuAutPago_Internalname, "Values", cmbUsuAutPago.ToJavascriptSource(), true);
         }
         A2009UsuAut1 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         A2010UsuAut2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         A2011UsuAutOcom = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         A2030UsuReqADM = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         A2020UsuOcMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         A2025UsuPedMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         if ( cmbUsuSts.ItemCount > 0 )
         {
            A2039UsuSts = (short)(NumberUtil.Val( cmbUsuSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0))), "."));
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            AssignProp("", false, cmbUsuSts_Internalname, "Values", cmbUsuSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
         ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
         ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
         ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, "Datos Generales", "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab1") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 1, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuPas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuPas_Internalname, "Password", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuPas_Internalname, StringUtil.RTrim( A2021UsuPas), StringUtil.RTrim( context.localUtil.Format( A2021UsuPas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuPas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuPas_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, -1, 0, 0, 1, 0, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableusunom_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusunom_Internalname, "Nombre Usuario", "", "", lblTextblockusunom_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuNom_Internalname, "Nombre Usuario", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuNom_Internalname, StringUtil.RTrim( A2019UsuNom), StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuNom_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtUsuNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableusuemail_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusuemail_Internalname, "E-Mail", "", "", lblTextblockusuemail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuEMAIL_Internalname, "E-Mail", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuEMAIL_Internalname, A2014UsuEMAIL, StringUtil.RTrim( context.localUtil.Format( A2014UsuEMAIL, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuEMAIL_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtUsuEMAIL_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableusuautpago_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusuautpago_Internalname, "Perfil", "", "", lblTextblockusuautpago_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuAutPago_Internalname, "Autorización Doc. Pagos", "col-sm-3 AttributeRealWidth50WithLabel", 0, true, "");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuAutPago, cmbUsuAutPago_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0)), 1, cmbUsuAutPago_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuAutPago.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeRealWidth50With", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 1, "HLP_Seguridad\\Usuarios.htm");
         cmbUsuAutPago.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
         AssignProp("", false, cmbUsuAutPago_Internalname, "Values", (string)(cmbUsuAutPago.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedusutiecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusutiecod_Internalname, "Local", "", "", lblTextblockusutiecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usutiecod.SetProperty("Caption", Combo_usutiecod_Caption);
         ucCombo_usutiecod.SetProperty("Cls", Combo_usutiecod_Cls);
         ucCombo_usutiecod.SetProperty("DataListProc", Combo_usutiecod_Datalistproc);
         ucCombo_usutiecod.SetProperty("DataListProcParametersPrefix", Combo_usutiecod_Datalistprocparametersprefix);
         ucCombo_usutiecod.SetProperty("EmptyItem", Combo_usutiecod_Emptyitem);
         ucCombo_usutiecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
         ucCombo_usutiecod.SetProperty("DropDownOptionsData", AV24UsuTieCod_Data);
         ucCombo_usutiecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usutiecod_Internalname, "COMBO_USUTIECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuTieCod_Internalname, "Local", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuTieCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2040UsuTieCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2040UsuTieCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuTieCod_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuTieCod_Visible, edtUsuTieCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedarecod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockarecod_Internalname, "Area", "", "", lblTextblockarecod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_arecod.SetProperty("Caption", Combo_arecod_Caption);
         ucCombo_arecod.SetProperty("Cls", Combo_arecod_Cls);
         ucCombo_arecod.SetProperty("DataListProc", Combo_arecod_Datalistproc);
         ucCombo_arecod.SetProperty("DataListProcParametersPrefix", Combo_arecod_Datalistprocparametersprefix);
         ucCombo_arecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
         ucCombo_arecod.SetProperty("DropDownOptionsData", AV12AreCod_Data);
         ucCombo_arecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_arecod_Internalname, "COMBO_ARECODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69AreCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreCod_Jsonclick, 0, "Attribute", "", "", "", "", edtAreCod_Visible, edtAreCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableusudep_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusudep_Internalname, "Departamento", "", "", lblTextblockusudep_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuDep_Internalname, "Departamento", "col-sm-3 AttributeRealWidthLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuDep_Internalname, A2013UsuDep, StringUtil.RTrim( context.localUtil.Format( A2013UsuDep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuDep_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtUsuDep_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedusuvend_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockusuvend_Internalname, "Vendedor Default", "", "", lblTextblockusuvend_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usuvend.SetProperty("Caption", Combo_usuvend_Caption);
         ucCombo_usuvend.SetProperty("Cls", Combo_usuvend_Cls);
         ucCombo_usuvend.SetProperty("DataListProc", Combo_usuvend_Datalistproc);
         ucCombo_usuvend.SetProperty("DataListProcParametersPrefix", Combo_usuvend_Datalistprocparametersprefix);
         ucCombo_usuvend.SetProperty("EmptyItem", Combo_usuvend_Emptyitem);
         ucCombo_usuvend.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
         ucCombo_usuvend.SetProperty("DropDownOptionsData", AV28UsuVend_Data);
         ucCombo_usuvend.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuvend_Internalname, "COMBO_USUVENDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuVend_Internalname, "Vendedor Default", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuVend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2041UsuVend), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2041UsuVend), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuVend_Jsonclick, 0, "Attribute", "", "", "", "", edtUsuVend_Visible, edtUsuVend_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAut1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAut1_Internalname, "Autorización 1", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAut1_Internalname, StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0), "", "Autorización 1", 1, chkUsuAut1.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,103);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAut2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAut2_Internalname, "Autorización 2", "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAut2_Internalname, StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0), "", "Autorización 2", 1, chkUsuAut2.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(107, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,107);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuAutOcom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuAutOcom_Internalname, "Autorización O. Compra", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuAutOcom_Internalname, StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0), "", "Autorización O. Compra", 1, chkUsuAutOcom.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,112);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuReqADM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuReqADM_Internalname, "Administrador Requerimiento", "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuReqADM_Internalname, StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0), "", "Administrador Requerimiento", 1, chkUsuReqADM.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,116);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuOcMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuOcMail_Internalname, "Recibir Correo de OC", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuOcMail_Internalname, StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0), "", "Recibir Correo de OC", 1, chkUsuOcMail.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(121, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,121);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedMail_Internalname, "Recibir Correo Pedido", "col-sm-4 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedMail_Internalname, StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0), "", "Recibir Correo Pedido", 1, chkUsuPedMail.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(125, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,125);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableususts_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockususts_Internalname, "Estado", "", "", lblTextblockususts_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuSts_Internalname, "Situacion Usuario", "col-sm-3 AttributeLabel", 0, true, "");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuSts, cmbUsuSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0)), 1, cmbUsuSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "", true, 1, "HLP_Seguridad\\Usuarios.htm");
         cmbUsuSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         AssignProp("", false, cmbUsuSts_Internalname, "Values", (string)(cmbUsuSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuVendDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuVendDsc_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuVendDsc_Internalname, StringUtil.RTrim( A2097UsuVendDsc), StringUtil.RTrim( context.localUtil.Format( A2097UsuVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuTieDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuTieDsc_Internalname, "Local", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuTieDsc_Internalname, StringUtil.RTrim( A2096UsuTieDsc), StringUtil.RTrim( context.localUtil.Format( A2096UsuTieDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuTieDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuTieDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab3_title_Internalname, "Opciones Generales", "", "", lblTab3_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab3") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0160"+"", StringUtil.RTrim( WebComp_Wcusuariosopciones_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0160"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosopciones), StringUtil.Lower( WebComp_Wcusuariosopciones_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0160"+"");
               }
               WebComp_Wcusuariosopciones.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosopciones), StringUtil.Lower( WebComp_Wcusuariosopciones_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, "Almacenes", "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab2") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0168"+"", StringUtil.RTrim( WebComp_Wcusuariosalmacen_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0168"+""+"\""+((WebComp_Wcusuariosalmacen_Visible==1) ? "" : " style=\"display:none;\"")) ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosalmacen), StringUtil.Lower( WebComp_Wcusuariosalmacen_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0168"+"");
               }
               WebComp_Wcusuariosalmacen.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosalmacen), StringUtil.Lower( WebComp_Wcusuariosalmacen_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab4_title_Internalname, "N° Series por Usuario", "", "", lblTab4_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\Usuarios.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab4") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0176"+"", StringUtil.RTrim( WebComp_Wcusuariosseries_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0176"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosseries), StringUtil.Lower( WebComp_Wcusuariosseries_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0176"+"");
               }
               WebComp_Wcusuariosseries.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWcusuariosseries), StringUtil.Lower( WebComp_Wcusuariosseries_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_usutiecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombousutiecod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ComboUsuTieCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombousutiecod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ComboUsuTieCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV25ComboUsuTieCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousutiecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousutiecod_Visible, edtavCombousutiecod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_arecod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboarecod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17ComboAreCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavComboarecod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17ComboAreCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV17ComboAreCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboarecod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboarecod_Visible, edtavComboarecod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_usuvend_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombousuvend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ComboUsuVend), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombousuvend_Enabled!=0) ? context.localUtil.Format( (decimal)(AV29ComboUsuVend), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV29ComboUsuVend), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombousuvend_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombousuvend_Visible, edtavCombousuvend_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Usuarios.htm");
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
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
               {
                  WebComp_Wcusuariosopciones.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Wcusuariosalmacen_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
               {
                  WebComp_Wcusuariosalmacen.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
               {
                  WebComp_Wcusuariosseries.componentstart();
               }
            }
         }
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vUSUTIECOD_DATA"), AV24UsuTieCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vARECOD_DATA"), AV12AreCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vUSUVEND_DATA"), AV28UsuVend_Data);
               /* Read saved values. */
               Z348UsuCod = cgiGet( "Z348UsuCod");
               Z2021UsuPas = cgiGet( "Z2021UsuPas");
               Z2019UsuNom = cgiGet( "Z2019UsuNom");
               Z2031UsuSerie = cgiGet( "Z2031UsuSerie");
               Z2011UsuAutOcom = (short)(context.localUtil.CToN( cgiGet( "Z2011UsuAutOcom"), ".", ","));
               Z2012UsuAutPago = (short)(context.localUtil.CToN( cgiGet( "Z2012UsuAutPago"), ".", ","));
               Z2039UsuSts = (short)(context.localUtil.CToN( cgiGet( "Z2039UsuSts"), ".", ","));
               Z2032UsuSerie1 = cgiGet( "Z2032UsuSerie1");
               Z2033UsuSerie2 = cgiGet( "Z2033UsuSerie2");
               Z2034UsuSerie3 = cgiGet( "Z2034UsuSerie3");
               Z2035UsuSerie4 = cgiGet( "Z2035UsuSerie4");
               Z2036UsuSerie5 = cgiGet( "Z2036UsuSerie5");
               Z2030UsuReqADM = (short)(context.localUtil.CToN( cgiGet( "Z2030UsuReqADM"), ".", ","));
               Z2009UsuAut1 = (short)(context.localUtil.CToN( cgiGet( "Z2009UsuAut1"), ".", ","));
               Z2010UsuAut2 = (short)(context.localUtil.CToN( cgiGet( "Z2010UsuAut2"), ".", ","));
               Z2020UsuOcMail = (short)(context.localUtil.CToN( cgiGet( "Z2020UsuOcMail"), ".", ","));
               Z2014UsuEMAIL = cgiGet( "Z2014UsuEMAIL");
               Z2025UsuPedMail = (short)(context.localUtil.CToN( cgiGet( "Z2025UsuPedMail"), ".", ","));
               Z2037UsuSOrden = cgiGet( "Z2037UsuSOrden");
               Z2038UsuSRet = cgiGet( "Z2038UsuSRet");
               Z2013UsuDep = cgiGet( "Z2013UsuDep");
               Z69AreCod = (int)(context.localUtil.CToN( cgiGet( "Z69AreCod"), ".", ","));
               n69AreCod = ((0==A69AreCod) ? true : false);
               Z2041UsuVend = (int)(context.localUtil.CToN( cgiGet( "Z2041UsuVend"), ".", ","));
               Z2040UsuTieCod = (int)(context.localUtil.CToN( cgiGet( "Z2040UsuTieCod"), ".", ","));
               A2031UsuSerie = cgiGet( "Z2031UsuSerie");
               A2032UsuSerie1 = cgiGet( "Z2032UsuSerie1");
               A2033UsuSerie2 = cgiGet( "Z2033UsuSerie2");
               A2034UsuSerie3 = cgiGet( "Z2034UsuSerie3");
               A2035UsuSerie4 = cgiGet( "Z2035UsuSerie4");
               A2036UsuSerie5 = cgiGet( "Z2036UsuSerie5");
               A2037UsuSOrden = cgiGet( "Z2037UsuSOrden");
               A2038UsuSRet = cgiGet( "Z2038UsuSRet");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N2041UsuVend = (int)(context.localUtil.CToN( cgiGet( "N2041UsuVend"), ".", ","));
               N2040UsuTieCod = (int)(context.localUtil.CToN( cgiGet( "N2040UsuTieCod"), ".", ","));
               N69AreCod = (int)(context.localUtil.CToN( cgiGet( "N69AreCod"), ".", ","));
               n69AreCod = ((0==A69AreCod) ? true : false);
               AV18UsuCod = cgiGet( "vUSUCOD");
               AV27Insert_UsuVend = (int)(context.localUtil.CToN( cgiGet( "vINSERT_USUVEND"), ".", ","));
               AV23Insert_UsuTieCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_USUTIECOD"), ".", ","));
               AV10Insert_AreCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_ARECOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A2031UsuSerie = cgiGet( "USUSERIE");
               A2032UsuSerie1 = cgiGet( "USUSERIE1");
               A2033UsuSerie2 = cgiGet( "USUSERIE2");
               A2034UsuSerie3 = cgiGet( "USUSERIE3");
               A2035UsuSerie4 = cgiGet( "USUSERIE4");
               A2036UsuSerie5 = cgiGet( "USUSERIE5");
               A2037UsuSOrden = cgiGet( "USUSORDEN");
               A2038UsuSRet = cgiGet( "USUSRET");
               AV32Pgmname = cgiGet( "vPGMNAME");
               Combo_usutiecod_Objectcall = cgiGet( "COMBO_USUTIECOD_Objectcall");
               Combo_usutiecod_Class = cgiGet( "COMBO_USUTIECOD_Class");
               Combo_usutiecod_Icontype = cgiGet( "COMBO_USUTIECOD_Icontype");
               Combo_usutiecod_Icon = cgiGet( "COMBO_USUTIECOD_Icon");
               Combo_usutiecod_Caption = cgiGet( "COMBO_USUTIECOD_Caption");
               Combo_usutiecod_Tooltip = cgiGet( "COMBO_USUTIECOD_Tooltip");
               Combo_usutiecod_Cls = cgiGet( "COMBO_USUTIECOD_Cls");
               Combo_usutiecod_Selectedvalue_set = cgiGet( "COMBO_USUTIECOD_Selectedvalue_set");
               Combo_usutiecod_Selectedvalue_get = cgiGet( "COMBO_USUTIECOD_Selectedvalue_get");
               Combo_usutiecod_Selectedtext_set = cgiGet( "COMBO_USUTIECOD_Selectedtext_set");
               Combo_usutiecod_Selectedtext_get = cgiGet( "COMBO_USUTIECOD_Selectedtext_get");
               Combo_usutiecod_Gamoauthtoken = cgiGet( "COMBO_USUTIECOD_Gamoauthtoken");
               Combo_usutiecod_Ddointernalname = cgiGet( "COMBO_USUTIECOD_Ddointernalname");
               Combo_usutiecod_Titlecontrolalign = cgiGet( "COMBO_USUTIECOD_Titlecontrolalign");
               Combo_usutiecod_Dropdownoptionstype = cgiGet( "COMBO_USUTIECOD_Dropdownoptionstype");
               Combo_usutiecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Enabled"));
               Combo_usutiecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Visible"));
               Combo_usutiecod_Titlecontrolidtoreplace = cgiGet( "COMBO_USUTIECOD_Titlecontrolidtoreplace");
               Combo_usutiecod_Datalisttype = cgiGet( "COMBO_USUTIECOD_Datalisttype");
               Combo_usutiecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Allowmultipleselection"));
               Combo_usutiecod_Datalistfixedvalues = cgiGet( "COMBO_USUTIECOD_Datalistfixedvalues");
               Combo_usutiecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Isgriditem"));
               Combo_usutiecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Hasdescription"));
               Combo_usutiecod_Datalistproc = cgiGet( "COMBO_USUTIECOD_Datalistproc");
               Combo_usutiecod_Datalistprocparametersprefix = cgiGet( "COMBO_USUTIECOD_Datalistprocparametersprefix");
               Combo_usutiecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_USUTIECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usutiecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Includeonlyselectedoption"));
               Combo_usutiecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Includeselectalloption"));
               Combo_usutiecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Emptyitem"));
               Combo_usutiecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_USUTIECOD_Includeaddnewoption"));
               Combo_usutiecod_Htmltemplate = cgiGet( "COMBO_USUTIECOD_Htmltemplate");
               Combo_usutiecod_Multiplevaluestype = cgiGet( "COMBO_USUTIECOD_Multiplevaluestype");
               Combo_usutiecod_Loadingdata = cgiGet( "COMBO_USUTIECOD_Loadingdata");
               Combo_usutiecod_Noresultsfound = cgiGet( "COMBO_USUTIECOD_Noresultsfound");
               Combo_usutiecod_Emptyitemtext = cgiGet( "COMBO_USUTIECOD_Emptyitemtext");
               Combo_usutiecod_Onlyselectedvalues = cgiGet( "COMBO_USUTIECOD_Onlyselectedvalues");
               Combo_usutiecod_Selectalltext = cgiGet( "COMBO_USUTIECOD_Selectalltext");
               Combo_usutiecod_Multiplevaluesseparator = cgiGet( "COMBO_USUTIECOD_Multiplevaluesseparator");
               Combo_usutiecod_Addnewoptiontext = cgiGet( "COMBO_USUTIECOD_Addnewoptiontext");
               Combo_usutiecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_USUTIECOD_Gxcontroltype"), ".", ","));
               Combo_arecod_Objectcall = cgiGet( "COMBO_ARECOD_Objectcall");
               Combo_arecod_Class = cgiGet( "COMBO_ARECOD_Class");
               Combo_arecod_Icontype = cgiGet( "COMBO_ARECOD_Icontype");
               Combo_arecod_Icon = cgiGet( "COMBO_ARECOD_Icon");
               Combo_arecod_Caption = cgiGet( "COMBO_ARECOD_Caption");
               Combo_arecod_Tooltip = cgiGet( "COMBO_ARECOD_Tooltip");
               Combo_arecod_Cls = cgiGet( "COMBO_ARECOD_Cls");
               Combo_arecod_Selectedvalue_set = cgiGet( "COMBO_ARECOD_Selectedvalue_set");
               Combo_arecod_Selectedvalue_get = cgiGet( "COMBO_ARECOD_Selectedvalue_get");
               Combo_arecod_Selectedtext_set = cgiGet( "COMBO_ARECOD_Selectedtext_set");
               Combo_arecod_Selectedtext_get = cgiGet( "COMBO_ARECOD_Selectedtext_get");
               Combo_arecod_Gamoauthtoken = cgiGet( "COMBO_ARECOD_Gamoauthtoken");
               Combo_arecod_Ddointernalname = cgiGet( "COMBO_ARECOD_Ddointernalname");
               Combo_arecod_Titlecontrolalign = cgiGet( "COMBO_ARECOD_Titlecontrolalign");
               Combo_arecod_Dropdownoptionstype = cgiGet( "COMBO_ARECOD_Dropdownoptionstype");
               Combo_arecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Enabled"));
               Combo_arecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Visible"));
               Combo_arecod_Titlecontrolidtoreplace = cgiGet( "COMBO_ARECOD_Titlecontrolidtoreplace");
               Combo_arecod_Datalisttype = cgiGet( "COMBO_ARECOD_Datalisttype");
               Combo_arecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Allowmultipleselection"));
               Combo_arecod_Datalistfixedvalues = cgiGet( "COMBO_ARECOD_Datalistfixedvalues");
               Combo_arecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Isgriditem"));
               Combo_arecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Hasdescription"));
               Combo_arecod_Datalistproc = cgiGet( "COMBO_ARECOD_Datalistproc");
               Combo_arecod_Datalistprocparametersprefix = cgiGet( "COMBO_ARECOD_Datalistprocparametersprefix");
               Combo_arecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_ARECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_arecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Includeonlyselectedoption"));
               Combo_arecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Includeselectalloption"));
               Combo_arecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Emptyitem"));
               Combo_arecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ARECOD_Includeaddnewoption"));
               Combo_arecod_Htmltemplate = cgiGet( "COMBO_ARECOD_Htmltemplate");
               Combo_arecod_Multiplevaluestype = cgiGet( "COMBO_ARECOD_Multiplevaluestype");
               Combo_arecod_Loadingdata = cgiGet( "COMBO_ARECOD_Loadingdata");
               Combo_arecod_Noresultsfound = cgiGet( "COMBO_ARECOD_Noresultsfound");
               Combo_arecod_Emptyitemtext = cgiGet( "COMBO_ARECOD_Emptyitemtext");
               Combo_arecod_Onlyselectedvalues = cgiGet( "COMBO_ARECOD_Onlyselectedvalues");
               Combo_arecod_Selectalltext = cgiGet( "COMBO_ARECOD_Selectalltext");
               Combo_arecod_Multiplevaluesseparator = cgiGet( "COMBO_ARECOD_Multiplevaluesseparator");
               Combo_arecod_Addnewoptiontext = cgiGet( "COMBO_ARECOD_Addnewoptiontext");
               Combo_arecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_ARECOD_Gxcontroltype"), ".", ","));
               Combo_usuvend_Objectcall = cgiGet( "COMBO_USUVEND_Objectcall");
               Combo_usuvend_Class = cgiGet( "COMBO_USUVEND_Class");
               Combo_usuvend_Icontype = cgiGet( "COMBO_USUVEND_Icontype");
               Combo_usuvend_Icon = cgiGet( "COMBO_USUVEND_Icon");
               Combo_usuvend_Caption = cgiGet( "COMBO_USUVEND_Caption");
               Combo_usuvend_Tooltip = cgiGet( "COMBO_USUVEND_Tooltip");
               Combo_usuvend_Cls = cgiGet( "COMBO_USUVEND_Cls");
               Combo_usuvend_Selectedvalue_set = cgiGet( "COMBO_USUVEND_Selectedvalue_set");
               Combo_usuvend_Selectedvalue_get = cgiGet( "COMBO_USUVEND_Selectedvalue_get");
               Combo_usuvend_Selectedtext_set = cgiGet( "COMBO_USUVEND_Selectedtext_set");
               Combo_usuvend_Selectedtext_get = cgiGet( "COMBO_USUVEND_Selectedtext_get");
               Combo_usuvend_Gamoauthtoken = cgiGet( "COMBO_USUVEND_Gamoauthtoken");
               Combo_usuvend_Ddointernalname = cgiGet( "COMBO_USUVEND_Ddointernalname");
               Combo_usuvend_Titlecontrolalign = cgiGet( "COMBO_USUVEND_Titlecontrolalign");
               Combo_usuvend_Dropdownoptionstype = cgiGet( "COMBO_USUVEND_Dropdownoptionstype");
               Combo_usuvend_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Enabled"));
               Combo_usuvend_Visible = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Visible"));
               Combo_usuvend_Titlecontrolidtoreplace = cgiGet( "COMBO_USUVEND_Titlecontrolidtoreplace");
               Combo_usuvend_Datalisttype = cgiGet( "COMBO_USUVEND_Datalisttype");
               Combo_usuvend_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Allowmultipleselection"));
               Combo_usuvend_Datalistfixedvalues = cgiGet( "COMBO_USUVEND_Datalistfixedvalues");
               Combo_usuvend_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Isgriditem"));
               Combo_usuvend_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Hasdescription"));
               Combo_usuvend_Datalistproc = cgiGet( "COMBO_USUVEND_Datalistproc");
               Combo_usuvend_Datalistprocparametersprefix = cgiGet( "COMBO_USUVEND_Datalistprocparametersprefix");
               Combo_usuvend_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_USUVEND_Datalistupdateminimumcharacters"), ".", ","));
               Combo_usuvend_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Includeonlyselectedoption"));
               Combo_usuvend_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Includeselectalloption"));
               Combo_usuvend_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Emptyitem"));
               Combo_usuvend_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_USUVEND_Includeaddnewoption"));
               Combo_usuvend_Htmltemplate = cgiGet( "COMBO_USUVEND_Htmltemplate");
               Combo_usuvend_Multiplevaluestype = cgiGet( "COMBO_USUVEND_Multiplevaluestype");
               Combo_usuvend_Loadingdata = cgiGet( "COMBO_USUVEND_Loadingdata");
               Combo_usuvend_Noresultsfound = cgiGet( "COMBO_USUVEND_Noresultsfound");
               Combo_usuvend_Emptyitemtext = cgiGet( "COMBO_USUVEND_Emptyitemtext");
               Combo_usuvend_Onlyselectedvalues = cgiGet( "COMBO_USUVEND_Onlyselectedvalues");
               Combo_usuvend_Selectalltext = cgiGet( "COMBO_USUVEND_Selectalltext");
               Combo_usuvend_Multiplevaluesseparator = cgiGet( "COMBO_USUVEND_Multiplevaluesseparator");
               Combo_usuvend_Addnewoptiontext = cgiGet( "COMBO_USUVEND_Addnewoptiontext");
               Combo_usuvend_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_USUVEND_Gxcontroltype"), ".", ","));
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), ".", ","));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), ".", ","));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               /* Read variables values. */
               A348UsuCod = cgiGet( edtUsuCod_Internalname);
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A2021UsuPas = cgiGet( edtUsuPas_Internalname);
               AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
               A2019UsuNom = cgiGet( edtUsuNom_Internalname);
               AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
               A2014UsuEMAIL = cgiGet( edtUsuEMAIL_Internalname);
               AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
               cmbUsuAutPago.CurrentValue = cgiGet( cmbUsuAutPago_Internalname);
               A2012UsuAutPago = (short)(NumberUtil.Val( cgiGet( cmbUsuAutPago_Internalname), "."));
               AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUTIECOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2040UsuTieCod = 0;
                  AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
               }
               else
               {
                  A2040UsuTieCod = (int)(context.localUtil.CToN( cgiGet( edtUsuTieCod_Internalname), ".", ","));
                  AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARECOD");
                  AnyError = 1;
                  GX_FocusControl = edtAreCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A69AreCod = 0;
                  n69AreCod = false;
                  AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               }
               else
               {
                  A69AreCod = (int)(context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ","));
                  n69AreCod = false;
                  AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               }
               n69AreCod = ((0==A69AreCod) ? true : false);
               A2013UsuDep = cgiGet( edtUsuDep_Internalname);
               AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUVEND");
                  AnyError = 1;
                  GX_FocusControl = edtUsuVend_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2041UsuVend = 0;
                  AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
               }
               else
               {
                  A2041UsuVend = (int)(context.localUtil.CToN( cgiGet( edtUsuVend_Internalname), ".", ","));
                  AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUT1");
                  AnyError = 1;
                  GX_FocusControl = chkUsuAut1_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2009UsuAut1 = 0;
                  AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
               }
               else
               {
                  A2009UsuAut1 = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAut1_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUT2");
                  AnyError = 1;
                  GX_FocusControl = chkUsuAut2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2010UsuAut2 = 0;
                  AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
               }
               else
               {
                  A2010UsuAut2 = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAut2_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUAUTOCOM");
                  AnyError = 1;
                  GX_FocusControl = chkUsuAutOcom_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2011UsuAutOcom = 0;
                  AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
               }
               else
               {
                  A2011UsuAutOcom = (short)(((StringUtil.StrCmp(cgiGet( chkUsuAutOcom_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUREQADM");
                  AnyError = 1;
                  GX_FocusControl = chkUsuReqADM_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2030UsuReqADM = 0;
                  AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
               }
               else
               {
                  A2030UsuReqADM = (short)(((StringUtil.StrCmp(cgiGet( chkUsuReqADM_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUOCMAIL");
                  AnyError = 1;
                  GX_FocusControl = chkUsuOcMail_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2020UsuOcMail = 0;
                  AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
               }
               else
               {
                  A2020UsuOcMail = (short)(((StringUtil.StrCmp(cgiGet( chkUsuOcMail_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDMAIL");
                  AnyError = 1;
                  GX_FocusControl = chkUsuPedMail_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2025UsuPedMail = 0;
                  AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
               }
               else
               {
                  A2025UsuPedMail = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedMail_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
               }
               cmbUsuSts.CurrentValue = cgiGet( cmbUsuSts_Internalname);
               A2039UsuSts = (short)(NumberUtil.Val( cgiGet( cmbUsuSts_Internalname), "."));
               AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
               A2097UsuVendDsc = cgiGet( edtUsuVendDsc_Internalname);
               AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
               A2096UsuTieDsc = cgiGet( edtUsuTieDsc_Internalname);
               AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
               AV25ComboUsuTieCod = (int)(context.localUtil.CToN( cgiGet( edtavCombousutiecod_Internalname), ".", ","));
               AssignAttri("", false, "AV25ComboUsuTieCod", StringUtil.LTrimStr( (decimal)(AV25ComboUsuTieCod), 6, 0));
               AV17ComboAreCod = (int)(context.localUtil.CToN( cgiGet( edtavComboarecod_Internalname), ".", ","));
               AssignAttri("", false, "AV17ComboAreCod", StringUtil.LTrimStr( (decimal)(AV17ComboAreCod), 6, 0));
               AV29ComboUsuVend = (int)(context.localUtil.CToN( cgiGet( edtavCombousuvend_Internalname), ".", ","));
               AssignAttri("", false, "AV29ComboUsuVend", StringUtil.LTrimStr( (decimal)(AV29ComboUsuVend), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Usuarios");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("UsuSerie", StringUtil.RTrim( context.localUtil.Format( A2031UsuSerie, "")));
               forbiddenHiddens.Add("UsuSerie1", StringUtil.RTrim( context.localUtil.Format( A2032UsuSerie1, "")));
               forbiddenHiddens.Add("UsuSerie2", StringUtil.RTrim( context.localUtil.Format( A2033UsuSerie2, "")));
               forbiddenHiddens.Add("UsuSerie3", StringUtil.RTrim( context.localUtil.Format( A2034UsuSerie3, "")));
               forbiddenHiddens.Add("UsuSerie4", StringUtil.RTrim( context.localUtil.Format( A2035UsuSerie4, "")));
               forbiddenHiddens.Add("UsuSerie5", StringUtil.RTrim( context.localUtil.Format( A2036UsuSerie5, "")));
               forbiddenHiddens.Add("UsuSOrden", StringUtil.RTrim( context.localUtil.Format( A2037UsuSOrden, "")));
               forbiddenHiddens.Add("UsuSRet", StringUtil.RTrim( context.localUtil.Format( A2038UsuSRet, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\usuarios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A348UsuCod = GetPar( "UsuCod");
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode32 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode32;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound32 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUCOD");
                        AnyError = 1;
                        GX_FocusControl = edtUsuCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E115F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 160 )
                     {
                        OldWcusuariosopciones = cgiGet( "W0160");
                        if ( ( StringUtil.Len( OldWcusuariosopciones) == 0 ) || ( StringUtil.StrCmp(OldWcusuariosopciones, WebComp_Wcusuariosopciones_Component) != 0 ) )
                        {
                           WebComp_Wcusuariosopciones = getWebComponent(GetType(), "GeneXus.Programs", OldWcusuariosopciones, new Object[] {context} );
                           WebComp_Wcusuariosopciones.ComponentInit();
                           WebComp_Wcusuariosopciones.Name = "OldWcusuariosopciones";
                           WebComp_Wcusuariosopciones_Component = OldWcusuariosopciones;
                        }
                        if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
                        {
                           WebComp_Wcusuariosopciones.componentprocess("W0160", "", sEvt);
                        }
                        WebComp_Wcusuariosopciones_Component = OldWcusuariosopciones;
                     }
                     else if ( nCmpId == 168 )
                     {
                        OldWcusuariosalmacen = cgiGet( "W0168");
                        if ( ( StringUtil.Len( OldWcusuariosalmacen) == 0 ) || ( StringUtil.StrCmp(OldWcusuariosalmacen, WebComp_Wcusuariosalmacen_Component) != 0 ) )
                        {
                           WebComp_Wcusuariosalmacen = getWebComponent(GetType(), "GeneXus.Programs", OldWcusuariosalmacen, new Object[] {context} );
                           WebComp_Wcusuariosalmacen.ComponentInit();
                           WebComp_Wcusuariosalmacen.Name = "OldWcusuariosalmacen";
                           WebComp_Wcusuariosalmacen_Component = OldWcusuariosalmacen;
                        }
                        if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
                        {
                           WebComp_Wcusuariosalmacen.componentprocess("W0168", "", sEvt);
                        }
                        WebComp_Wcusuariosalmacen_Component = OldWcusuariosalmacen;
                     }
                     else if ( nCmpId == 176 )
                     {
                        OldWcusuariosseries = cgiGet( "W0176");
                        if ( ( StringUtil.Len( OldWcusuariosseries) == 0 ) || ( StringUtil.StrCmp(OldWcusuariosseries, WebComp_Wcusuariosseries_Component) != 0 ) )
                        {
                           WebComp_Wcusuariosseries = getWebComponent(GetType(), "GeneXus.Programs", OldWcusuariosseries, new Object[] {context} );
                           WebComp_Wcusuariosseries.ComponentInit();
                           WebComp_Wcusuariosseries.Name = "OldWcusuariosseries";
                           WebComp_Wcusuariosseries_Component = OldWcusuariosseries;
                        }
                        if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
                        {
                           WebComp_Wcusuariosseries.componentprocess("W0176", "", sEvt);
                        }
                        WebComp_Wcusuariosseries_Component = OldWcusuariosseries;
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
            /* Execute user event: After Trn */
            E125F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5F32( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes5F32( ) ;
         }
         AssignProp("", false, edtavCombousutiecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousutiecod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboarecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboarecod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombousuvend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousuvend_Enabled), 5, 0), true);
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

      protected void CONFIRM_5F0( )
      {
         BeforeValidate5F32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5F32( ) ;
            }
            else
            {
               CheckExtendedTable5F32( ) ;
               CloseExtendedTableCursors5F32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5F0( )
      {
      }

      protected void E115F2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtUsuVend_Visible = 0;
         AssignProp("", false, edtUsuVend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuVend_Visible), 5, 0), true);
         AV29ComboUsuVend = 0;
         AssignAttri("", false, "AV29ComboUsuVend", StringUtil.LTrimStr( (decimal)(AV29ComboUsuVend), 6, 0));
         edtavCombousuvend_Visible = 0;
         AssignProp("", false, edtavCombousuvend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousuvend_Visible), 5, 0), true);
         edtAreCod_Visible = 0;
         AssignProp("", false, edtAreCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreCod_Visible), 5, 0), true);
         AV17ComboAreCod = 0;
         AssignAttri("", false, "AV17ComboAreCod", StringUtil.LTrimStr( (decimal)(AV17ComboAreCod), 6, 0));
         edtavComboarecod_Visible = 0;
         AssignProp("", false, edtavComboarecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboarecod_Visible), 5, 0), true);
         edtUsuTieCod_Visible = 0;
         AssignProp("", false, edtUsuTieCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuTieCod_Visible), 5, 0), true);
         AV25ComboUsuTieCod = 0;
         AssignAttri("", false, "AV25ComboUsuTieCod", StringUtil.LTrimStr( (decimal)(AV25ComboUsuTieCod), 6, 0));
         edtavCombousutiecod_Visible = 0;
         AssignProp("", false, edtavCombousutiecod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombousutiecod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOUSUTIECOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOARECOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOUSUVEND' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Transactionname, AV32Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV33GXV1 = 1;
            AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            while ( AV33GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV33GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "UsuVend") == 0 )
               {
                  AV27Insert_UsuVend = (int)(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV27Insert_UsuVend", StringUtil.LTrimStr( (decimal)(AV27Insert_UsuVend), 6, 0));
                  if ( ! (0==AV27Insert_UsuVend) )
                  {
                     AV29ComboUsuVend = AV27Insert_UsuVend;
                     AssignAttri("", false, "AV29ComboUsuVend", StringUtil.LTrimStr( (decimal)(AV29ComboUsuVend), 6, 0));
                     Combo_usuvend_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV29ComboUsuVend), 6, 0));
                     ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "SelectedValue_set", Combo_usuvend_Selectedvalue_set);
                     GXt_char2 = AV16Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "UsuVend",  "GET",  false,  AV18UsuCod,  AV11TrnContextAtt.gxTpr_Attributevalue, out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
                     AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
                     AV16Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
                     Combo_usuvend_Selectedtext_set = AV15ComboSelectedText;
                     ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "SelectedText_set", Combo_usuvend_Selectedtext_set);
                     Combo_usuvend_Enabled = false;
                     ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usuvend_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "UsuTieCod") == 0 )
               {
                  AV23Insert_UsuTieCod = (int)(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV23Insert_UsuTieCod", StringUtil.LTrimStr( (decimal)(AV23Insert_UsuTieCod), 6, 0));
                  if ( ! (0==AV23Insert_UsuTieCod) )
                  {
                     AV25ComboUsuTieCod = AV23Insert_UsuTieCod;
                     AssignAttri("", false, "AV25ComboUsuTieCod", StringUtil.LTrimStr( (decimal)(AV25ComboUsuTieCod), 6, 0));
                     Combo_usutiecod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV25ComboUsuTieCod), 6, 0));
                     ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "SelectedValue_set", Combo_usutiecod_Selectedvalue_set);
                     GXt_char2 = AV16Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "UsuTieCod",  "GET",  false,  AV18UsuCod,  AV11TrnContextAtt.gxTpr_Attributevalue, out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
                     AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
                     AV16Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
                     Combo_usutiecod_Selectedtext_set = AV15ComboSelectedText;
                     ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "SelectedText_set", Combo_usutiecod_Selectedtext_set);
                     Combo_usutiecod_Enabled = false;
                     ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usutiecod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "AreCod") == 0 )
               {
                  AV10Insert_AreCod = (int)(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV10Insert_AreCod", StringUtil.LTrimStr( (decimal)(AV10Insert_AreCod), 6, 0));
                  if ( ! (0==AV10Insert_AreCod) )
                  {
                     AV17ComboAreCod = AV10Insert_AreCod;
                     AssignAttri("", false, "AV17ComboAreCod", StringUtil.LTrimStr( (decimal)(AV17ComboAreCod), 6, 0));
                     Combo_arecod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV17ComboAreCod), 6, 0));
                     ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "SelectedValue_set", Combo_arecod_Selectedvalue_set);
                     GXt_char2 = AV16Combo_DataJson;
                     new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "AreCod",  "GET",  false,  AV18UsuCod,  AV11TrnContextAtt.gxTpr_Attributevalue, out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
                     AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
                     AV16Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
                     Combo_arecod_Selectedtext_set = AV15ComboSelectedText;
                     ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "SelectedText_set", Combo_arecod_Selectedtext_set);
                     Combo_arecod_Enabled = false;
                     ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_arecod_Enabled));
                  }
               }
               AV33GXV1 = (int)(AV33GXV1+1);
               AssignAttri("", false, "AV33GXV1", StringUtil.LTrimStr( (decimal)(AV33GXV1), 8, 0));
            }
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcusuariosseries = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcusuariosseries_Component), StringUtil.Lower( "Seguridad.UsuariosSeries")) != 0 )
         {
            WebComp_Wcusuariosseries = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.usuariosseries", new Object[] {context} );
            WebComp_Wcusuariosseries.ComponentInit();
            WebComp_Wcusuariosseries.Name = "Seguridad.UsuariosSeries";
            WebComp_Wcusuariosseries_Component = "Seguridad.UsuariosSeries";
         }
         if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
         {
            WebComp_Wcusuariosseries.setjustcreated();
            WebComp_Wcusuariosseries.componentprepare(new Object[] {(string)"W0176",(string)"",(string)Gx_mode,(string)AV18UsuCod});
            WebComp_Wcusuariosseries.componentbind(new Object[] {(string)"",(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcusuariosalmacen = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcusuariosalmacen_Component), StringUtil.Lower( "Seguridad.UsuariosAlmacen")) != 0 )
         {
            WebComp_Wcusuariosalmacen = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.usuariosalmacen", new Object[] {context} );
            WebComp_Wcusuariosalmacen.ComponentInit();
            WebComp_Wcusuariosalmacen.Name = "Seguridad.UsuariosAlmacen";
            WebComp_Wcusuariosalmacen_Component = "Seguridad.UsuariosAlmacen";
         }
         if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
         {
            WebComp_Wcusuariosalmacen.setjustcreated();
            WebComp_Wcusuariosalmacen.componentprepare(new Object[] {(string)"W0168",(string)"",(string)AV18UsuCod});
            WebComp_Wcusuariosalmacen.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcusuariosopciones = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcusuariosopciones_Component), StringUtil.Lower( "Seguridad.UsuariosOpciones")) != 0 )
         {
            WebComp_Wcusuariosopciones = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.usuariosopciones", new Object[] {context} );
            WebComp_Wcusuariosopciones.ComponentInit();
            WebComp_Wcusuariosopciones.Name = "Seguridad.UsuariosOpciones";
            WebComp_Wcusuariosopciones_Component = "Seguridad.UsuariosOpciones";
         }
         if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
         {
            WebComp_Wcusuariosopciones.setjustcreated();
            WebComp_Wcusuariosopciones.componentprepare(new Object[] {(string)"W0160",(string)"",(string)Gx_mode,(string)AV18UsuCod});
            WebComp_Wcusuariosopciones.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            WebComp_Wcusuariosalmacen_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0168"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcusuariosalmacen_Visible), 5, 0), true);
         }
      }

      protected void E125F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( A2012UsuAutPago == 1 )
         {
            new GeneXus.Programs.seguridad.pactualizausuarioadministrador(context ).execute( ref  A348UsuCod) ;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("seguridad.usuariosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'LOADCOMBOUSUVEND' Routine */
         returnInSub = false;
         GXt_char2 = AV16Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "UsuVend",  Gx_mode,  false,  AV18UsuCod,  "", out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
         AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
         AV16Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
         Combo_usuvend_Selectedvalue_set = AV14ComboSelectedValue;
         ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "SelectedValue_set", Combo_usuvend_Selectedvalue_set);
         Combo_usuvend_Selectedtext_set = AV15ComboSelectedText;
         ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "SelectedText_set", Combo_usuvend_Selectedtext_set);
         AV29ComboUsuVend = (int)(NumberUtil.Val( AV14ComboSelectedValue, "."));
         AssignAttri("", false, "AV29ComboUsuVend", StringUtil.LTrimStr( (decimal)(AV29ComboUsuVend), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usuvend_Enabled = false;
            ucCombo_usuvend.SendProperty(context, "", false, Combo_usuvend_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usuvend_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOARECOD' Routine */
         returnInSub = false;
         GXt_char2 = AV16Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "AreCod",  Gx_mode,  false,  AV18UsuCod,  "", out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
         AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
         AV16Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
         Combo_arecod_Selectedvalue_set = AV14ComboSelectedValue;
         ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "SelectedValue_set", Combo_arecod_Selectedvalue_set);
         Combo_arecod_Selectedtext_set = AV15ComboSelectedText;
         ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "SelectedText_set", Combo_arecod_Selectedtext_set);
         AV17ComboAreCod = (int)(NumberUtil.Val( AV14ComboSelectedValue, "."));
         AssignAttri("", false, "AV17ComboAreCod", StringUtil.LTrimStr( (decimal)(AV17ComboAreCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_arecod_Enabled = false;
            ucCombo_arecod.SendProperty(context, "", false, Combo_arecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_arecod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOUSUTIECOD' Routine */
         returnInSub = false;
         GXt_char2 = AV16Combo_DataJson;
         new GeneXus.Programs.seguridad.usuariosloaddvcombo(context ).execute(  "UsuTieCod",  Gx_mode,  false,  AV18UsuCod,  "", out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV14ComboSelectedValue", AV14ComboSelectedValue);
         AssignAttri("", false, "AV15ComboSelectedText", AV15ComboSelectedText);
         AV16Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV16Combo_DataJson", AV16Combo_DataJson);
         Combo_usutiecod_Selectedvalue_set = AV14ComboSelectedValue;
         ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "SelectedValue_set", Combo_usutiecod_Selectedvalue_set);
         Combo_usutiecod_Selectedtext_set = AV15ComboSelectedText;
         ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "SelectedText_set", Combo_usutiecod_Selectedtext_set);
         AV25ComboUsuTieCod = (int)(NumberUtil.Val( AV14ComboSelectedValue, "."));
         AssignAttri("", false, "AV25ComboUsuTieCod", StringUtil.LTrimStr( (decimal)(AV25ComboUsuTieCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_usutiecod_Enabled = false;
            ucCombo_usutiecod.SendProperty(context, "", false, Combo_usutiecod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_usutiecod_Enabled));
         }
      }

      protected void ZM5F32( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2021UsuPas = T005F3_A2021UsuPas[0];
               Z2019UsuNom = T005F3_A2019UsuNom[0];
               Z2031UsuSerie = T005F3_A2031UsuSerie[0];
               Z2011UsuAutOcom = T005F3_A2011UsuAutOcom[0];
               Z2012UsuAutPago = T005F3_A2012UsuAutPago[0];
               Z2039UsuSts = T005F3_A2039UsuSts[0];
               Z2032UsuSerie1 = T005F3_A2032UsuSerie1[0];
               Z2033UsuSerie2 = T005F3_A2033UsuSerie2[0];
               Z2034UsuSerie3 = T005F3_A2034UsuSerie3[0];
               Z2035UsuSerie4 = T005F3_A2035UsuSerie4[0];
               Z2036UsuSerie5 = T005F3_A2036UsuSerie5[0];
               Z2030UsuReqADM = T005F3_A2030UsuReqADM[0];
               Z2009UsuAut1 = T005F3_A2009UsuAut1[0];
               Z2010UsuAut2 = T005F3_A2010UsuAut2[0];
               Z2020UsuOcMail = T005F3_A2020UsuOcMail[0];
               Z2014UsuEMAIL = T005F3_A2014UsuEMAIL[0];
               Z2025UsuPedMail = T005F3_A2025UsuPedMail[0];
               Z2037UsuSOrden = T005F3_A2037UsuSOrden[0];
               Z2038UsuSRet = T005F3_A2038UsuSRet[0];
               Z2013UsuDep = T005F3_A2013UsuDep[0];
               Z69AreCod = T005F3_A69AreCod[0];
               Z2041UsuVend = T005F3_A2041UsuVend[0];
               Z2040UsuTieCod = T005F3_A2040UsuTieCod[0];
            }
            else
            {
               Z2021UsuPas = A2021UsuPas;
               Z2019UsuNom = A2019UsuNom;
               Z2031UsuSerie = A2031UsuSerie;
               Z2011UsuAutOcom = A2011UsuAutOcom;
               Z2012UsuAutPago = A2012UsuAutPago;
               Z2039UsuSts = A2039UsuSts;
               Z2032UsuSerie1 = A2032UsuSerie1;
               Z2033UsuSerie2 = A2033UsuSerie2;
               Z2034UsuSerie3 = A2034UsuSerie3;
               Z2035UsuSerie4 = A2035UsuSerie4;
               Z2036UsuSerie5 = A2036UsuSerie5;
               Z2030UsuReqADM = A2030UsuReqADM;
               Z2009UsuAut1 = A2009UsuAut1;
               Z2010UsuAut2 = A2010UsuAut2;
               Z2020UsuOcMail = A2020UsuOcMail;
               Z2014UsuEMAIL = A2014UsuEMAIL;
               Z2025UsuPedMail = A2025UsuPedMail;
               Z2037UsuSOrden = A2037UsuSOrden;
               Z2038UsuSRet = A2038UsuSRet;
               Z2013UsuDep = A2013UsuDep;
               Z69AreCod = A69AreCod;
               Z2041UsuVend = A2041UsuVend;
               Z2040UsuTieCod = A2040UsuTieCod;
            }
         }
         if ( GX_JID == -20 )
         {
            Z348UsuCod = A348UsuCod;
            Z2021UsuPas = A2021UsuPas;
            Z2019UsuNom = A2019UsuNom;
            Z2031UsuSerie = A2031UsuSerie;
            Z2011UsuAutOcom = A2011UsuAutOcom;
            Z2012UsuAutPago = A2012UsuAutPago;
            Z2039UsuSts = A2039UsuSts;
            Z2032UsuSerie1 = A2032UsuSerie1;
            Z2033UsuSerie2 = A2033UsuSerie2;
            Z2034UsuSerie3 = A2034UsuSerie3;
            Z2035UsuSerie4 = A2035UsuSerie4;
            Z2036UsuSerie5 = A2036UsuSerie5;
            Z2030UsuReqADM = A2030UsuReqADM;
            Z2009UsuAut1 = A2009UsuAut1;
            Z2010UsuAut2 = A2010UsuAut2;
            Z2020UsuOcMail = A2020UsuOcMail;
            Z2014UsuEMAIL = A2014UsuEMAIL;
            Z2025UsuPedMail = A2025UsuPedMail;
            Z2037UsuSOrden = A2037UsuSOrden;
            Z2038UsuSRet = A2038UsuSRet;
            Z2013UsuDep = A2013UsuDep;
            Z69AreCod = A69AreCod;
            Z2041UsuVend = A2041UsuVend;
            Z2040UsuTieCod = A2040UsuTieCod;
            Z2097UsuVendDsc = A2097UsuVendDsc;
            Z2096UsuTieDsc = A2096UsuTieDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV32Pgmname = "Seguridad.Usuarios";
         AssignAttri("", false, "AV32Pgmname", AV32Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuCod)) )
         {
            A348UsuCod = AV18UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuCod)) )
         {
            edtUsuCod_Enabled = 0;
            AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuCod_Enabled = 1;
            AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18UsuCod)) )
         {
            edtUsuCod_Enabled = 0;
            AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_UsuVend) )
         {
            edtUsuVend_Enabled = 0;
            AssignProp("", false, edtUsuVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuVend_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuVend_Enabled = 1;
            AssignProp("", false, edtUsuVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuVend_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_UsuTieCod) )
         {
            edtUsuTieCod_Enabled = 0;
            AssignProp("", false, edtUsuTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuTieCod_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuTieCod_Enabled = 1;
            AssignProp("", false, edtUsuTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuTieCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV10Insert_AreCod) )
         {
            edtAreCod_Enabled = 0;
            AssignProp("", false, edtAreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreCod_Enabled), 5, 0), true);
         }
         else
         {
            edtAreCod_Enabled = 1;
            AssignProp("", false, edtAreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV23Insert_UsuTieCod) )
         {
            A2040UsuTieCod = AV23Insert_UsuTieCod;
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
         }
         else
         {
            A2040UsuTieCod = AV25ComboUsuTieCod;
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV10Insert_AreCod) )
         {
            A69AreCod = AV10Insert_AreCod;
            n69AreCod = false;
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         }
         else
         {
            if ( (0==AV17ComboAreCod) )
            {
               A69AreCod = 0;
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               n69AreCod = true;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV17ComboAreCod) )
               {
                  A69AreCod = AV17ComboAreCod;
                  n69AreCod = false;
                  AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_UsuVend) )
         {
            A2041UsuVend = AV27Insert_UsuVend;
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
         }
         else
         {
            A2041UsuVend = AV29ComboUsuVend;
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (0==A2039UsuSts) && ( Gx_BScreen == 0 ) )
         {
            A2039UsuSts = 1;
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         }
         if ( IsIns( )  && (0==A2012UsuAutPago) && ( Gx_BScreen == 0 ) )
         {
            A2012UsuAutPago = 0;
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T005F6 */
            pr_default.execute(4, new Object[] {A2040UsuTieCod});
            A2096UsuTieDsc = T005F6_A2096UsuTieDsc[0];
            AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
            pr_default.close(4);
            /* Using cursor T005F5 */
            pr_default.execute(3, new Object[] {A2041UsuVend});
            A2097UsuVendDsc = T005F5_A2097UsuVendDsc[0];
            AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
            pr_default.close(3);
         }
      }

      protected void Load5F32( )
      {
         /* Using cursor T005F7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            A2021UsuPas = T005F7_A2021UsuPas[0];
            AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
            A2019UsuNom = T005F7_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2031UsuSerie = T005F7_A2031UsuSerie[0];
            A2011UsuAutOcom = T005F7_A2011UsuAutOcom[0];
            AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            A2012UsuAutPago = T005F7_A2012UsuAutPago[0];
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            A2039UsuSts = T005F7_A2039UsuSts[0];
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            A2032UsuSerie1 = T005F7_A2032UsuSerie1[0];
            A2033UsuSerie2 = T005F7_A2033UsuSerie2[0];
            A2034UsuSerie3 = T005F7_A2034UsuSerie3[0];
            A2035UsuSerie4 = T005F7_A2035UsuSerie4[0];
            A2097UsuVendDsc = T005F7_A2097UsuVendDsc[0];
            AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
            A2036UsuSerie5 = T005F7_A2036UsuSerie5[0];
            A2030UsuReqADM = T005F7_A2030UsuReqADM[0];
            AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            A2096UsuTieDsc = T005F7_A2096UsuTieDsc[0];
            AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
            A2009UsuAut1 = T005F7_A2009UsuAut1[0];
            AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            A2010UsuAut2 = T005F7_A2010UsuAut2[0];
            AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            A2020UsuOcMail = T005F7_A2020UsuOcMail[0];
            AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            A2014UsuEMAIL = T005F7_A2014UsuEMAIL[0];
            AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
            A2025UsuPedMail = T005F7_A2025UsuPedMail[0];
            AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            A2037UsuSOrden = T005F7_A2037UsuSOrden[0];
            A2038UsuSRet = T005F7_A2038UsuSRet[0];
            A2013UsuDep = T005F7_A2013UsuDep[0];
            AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
            A69AreCod = T005F7_A69AreCod[0];
            n69AreCod = T005F7_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            A2041UsuVend = T005F7_A2041UsuVend[0];
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            A2040UsuTieCod = T005F7_A2040UsuTieCod[0];
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            ZM5F32( -20) ;
         }
         pr_default.close(5);
         OnLoadActions5F32( ) ;
      }

      protected void OnLoadActions5F32( )
      {
      }

      protected void CheckExtendedTable5F32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A348UsuCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Usuario", "", "", "", "", "", "", "", ""), 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2021UsuPas)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Password", "", "", "", "", "", "", "", ""), 1, "USUPAS");
            AnyError = 1;
            GX_FocusControl = edtUsuPas_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2019UsuNom)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Nombre Usuario", "", "", "", "", "", "", "", ""), 1, "USUNOM");
            AnyError = 1;
            GX_FocusControl = edtUsuNom_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005F5 */
         pr_default.execute(3, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2097UsuVendDsc = T005F5_A2097UsuVendDsc[0];
         AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
         pr_default.close(3);
         /* Using cursor T005F6 */
         pr_default.execute(4, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2096UsuTieDsc = T005F6_A2096UsuTieDsc[0];
         AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
         pr_default.close(4);
         /* Using cursor T005F4 */
         pr_default.execute(2, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors5F32( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( int A2041UsuVend )
      {
         /* Using cursor T005F8 */
         pr_default.execute(6, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2097UsuVendDsc = T005F8_A2097UsuVendDsc[0];
         AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2097UsuVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_23( int A2040UsuTieCod )
      {
         /* Using cursor T005F9 */
         pr_default.execute(7, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2096UsuTieDsc = T005F9_A2096UsuTieDsc[0];
         AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2096UsuTieDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_21( int A69AreCod )
      {
         /* Using cursor T005F10 */
         pr_default.execute(8, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey5F32( )
      {
         /* Using cursor T005F11 */
         pr_default.execute(9, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005F3 */
         pr_default.execute(1, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5F32( 20) ;
            RcdFound32 = 1;
            A348UsuCod = T005F3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A2021UsuPas = T005F3_A2021UsuPas[0];
            AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
            A2019UsuNom = T005F3_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2031UsuSerie = T005F3_A2031UsuSerie[0];
            A2011UsuAutOcom = T005F3_A2011UsuAutOcom[0];
            AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
            A2012UsuAutPago = T005F3_A2012UsuAutPago[0];
            AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            A2039UsuSts = T005F3_A2039UsuSts[0];
            AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            A2032UsuSerie1 = T005F3_A2032UsuSerie1[0];
            A2033UsuSerie2 = T005F3_A2033UsuSerie2[0];
            A2034UsuSerie3 = T005F3_A2034UsuSerie3[0];
            A2035UsuSerie4 = T005F3_A2035UsuSerie4[0];
            A2036UsuSerie5 = T005F3_A2036UsuSerie5[0];
            A2030UsuReqADM = T005F3_A2030UsuReqADM[0];
            AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
            A2009UsuAut1 = T005F3_A2009UsuAut1[0];
            AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
            A2010UsuAut2 = T005F3_A2010UsuAut2[0];
            AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
            A2020UsuOcMail = T005F3_A2020UsuOcMail[0];
            AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
            A2014UsuEMAIL = T005F3_A2014UsuEMAIL[0];
            AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
            A2025UsuPedMail = T005F3_A2025UsuPedMail[0];
            AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
            A2037UsuSOrden = T005F3_A2037UsuSOrden[0];
            A2038UsuSRet = T005F3_A2038UsuSRet[0];
            A2013UsuDep = T005F3_A2013UsuDep[0];
            AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
            A69AreCod = T005F3_A69AreCod[0];
            n69AreCod = T005F3_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            A2041UsuVend = T005F3_A2041UsuVend[0];
            AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
            A2040UsuTieCod = T005F3_A2040UsuTieCod[0];
            AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5F32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey5F32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey5F32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5F32( ) ;
         if ( RcdFound32 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound32 = 0;
         /* Using cursor T005F12 */
         pr_default.execute(10, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T005F12_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T005F12_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T005F12_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T005F13 */
         pr_default.execute(11, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T005F13_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T005F13_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T005F13_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5F32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5F32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5F32( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5F32( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5F32( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5F32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005F2 */
            pr_default.execute(0, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2021UsuPas, T005F2_A2021UsuPas[0]) != 0 ) || ( StringUtil.StrCmp(Z2019UsuNom, T005F2_A2019UsuNom[0]) != 0 ) || ( StringUtil.StrCmp(Z2031UsuSerie, T005F2_A2031UsuSerie[0]) != 0 ) || ( Z2011UsuAutOcom != T005F2_A2011UsuAutOcom[0] ) || ( Z2012UsuAutPago != T005F2_A2012UsuAutPago[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2039UsuSts != T005F2_A2039UsuSts[0] ) || ( StringUtil.StrCmp(Z2032UsuSerie1, T005F2_A2032UsuSerie1[0]) != 0 ) || ( StringUtil.StrCmp(Z2033UsuSerie2, T005F2_A2033UsuSerie2[0]) != 0 ) || ( StringUtil.StrCmp(Z2034UsuSerie3, T005F2_A2034UsuSerie3[0]) != 0 ) || ( StringUtil.StrCmp(Z2035UsuSerie4, T005F2_A2035UsuSerie4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2036UsuSerie5, T005F2_A2036UsuSerie5[0]) != 0 ) || ( Z2030UsuReqADM != T005F2_A2030UsuReqADM[0] ) || ( Z2009UsuAut1 != T005F2_A2009UsuAut1[0] ) || ( Z2010UsuAut2 != T005F2_A2010UsuAut2[0] ) || ( Z2020UsuOcMail != T005F2_A2020UsuOcMail[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2014UsuEMAIL, T005F2_A2014UsuEMAIL[0]) != 0 ) || ( Z2025UsuPedMail != T005F2_A2025UsuPedMail[0] ) || ( StringUtil.StrCmp(Z2037UsuSOrden, T005F2_A2037UsuSOrden[0]) != 0 ) || ( StringUtil.StrCmp(Z2038UsuSRet, T005F2_A2038UsuSRet[0]) != 0 ) || ( StringUtil.StrCmp(Z2013UsuDep, T005F2_A2013UsuDep[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z69AreCod != T005F2_A69AreCod[0] ) || ( Z2041UsuVend != T005F2_A2041UsuVend[0] ) || ( Z2040UsuTieCod != T005F2_A2040UsuTieCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z2021UsuPas, T005F2_A2021UsuPas[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuPas");
                  GXUtil.WriteLogRaw("Old: ",Z2021UsuPas);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2021UsuPas[0]);
               }
               if ( StringUtil.StrCmp(Z2019UsuNom, T005F2_A2019UsuNom[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuNom");
                  GXUtil.WriteLogRaw("Old: ",Z2019UsuNom);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2019UsuNom[0]);
               }
               if ( StringUtil.StrCmp(Z2031UsuSerie, T005F2_A2031UsuSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie");
                  GXUtil.WriteLogRaw("Old: ",Z2031UsuSerie);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2031UsuSerie[0]);
               }
               if ( Z2011UsuAutOcom != T005F2_A2011UsuAutOcom[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuAutOcom");
                  GXUtil.WriteLogRaw("Old: ",Z2011UsuAutOcom);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2011UsuAutOcom[0]);
               }
               if ( Z2012UsuAutPago != T005F2_A2012UsuAutPago[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuAutPago");
                  GXUtil.WriteLogRaw("Old: ",Z2012UsuAutPago);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2012UsuAutPago[0]);
               }
               if ( Z2039UsuSts != T005F2_A2039UsuSts[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSts");
                  GXUtil.WriteLogRaw("Old: ",Z2039UsuSts);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2039UsuSts[0]);
               }
               if ( StringUtil.StrCmp(Z2032UsuSerie1, T005F2_A2032UsuSerie1[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie1");
                  GXUtil.WriteLogRaw("Old: ",Z2032UsuSerie1);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2032UsuSerie1[0]);
               }
               if ( StringUtil.StrCmp(Z2033UsuSerie2, T005F2_A2033UsuSerie2[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie2");
                  GXUtil.WriteLogRaw("Old: ",Z2033UsuSerie2);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2033UsuSerie2[0]);
               }
               if ( StringUtil.StrCmp(Z2034UsuSerie3, T005F2_A2034UsuSerie3[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie3");
                  GXUtil.WriteLogRaw("Old: ",Z2034UsuSerie3);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2034UsuSerie3[0]);
               }
               if ( StringUtil.StrCmp(Z2035UsuSerie4, T005F2_A2035UsuSerie4[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie4");
                  GXUtil.WriteLogRaw("Old: ",Z2035UsuSerie4);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2035UsuSerie4[0]);
               }
               if ( StringUtil.StrCmp(Z2036UsuSerie5, T005F2_A2036UsuSerie5[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSerie5");
                  GXUtil.WriteLogRaw("Old: ",Z2036UsuSerie5);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2036UsuSerie5[0]);
               }
               if ( Z2030UsuReqADM != T005F2_A2030UsuReqADM[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuReqADM");
                  GXUtil.WriteLogRaw("Old: ",Z2030UsuReqADM);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2030UsuReqADM[0]);
               }
               if ( Z2009UsuAut1 != T005F2_A2009UsuAut1[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuAut1");
                  GXUtil.WriteLogRaw("Old: ",Z2009UsuAut1);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2009UsuAut1[0]);
               }
               if ( Z2010UsuAut2 != T005F2_A2010UsuAut2[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuAut2");
                  GXUtil.WriteLogRaw("Old: ",Z2010UsuAut2);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2010UsuAut2[0]);
               }
               if ( Z2020UsuOcMail != T005F2_A2020UsuOcMail[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuOcMail");
                  GXUtil.WriteLogRaw("Old: ",Z2020UsuOcMail);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2020UsuOcMail[0]);
               }
               if ( StringUtil.StrCmp(Z2014UsuEMAIL, T005F2_A2014UsuEMAIL[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuEMAIL");
                  GXUtil.WriteLogRaw("Old: ",Z2014UsuEMAIL);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2014UsuEMAIL[0]);
               }
               if ( Z2025UsuPedMail != T005F2_A2025UsuPedMail[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuPedMail");
                  GXUtil.WriteLogRaw("Old: ",Z2025UsuPedMail);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2025UsuPedMail[0]);
               }
               if ( StringUtil.StrCmp(Z2037UsuSOrden, T005F2_A2037UsuSOrden[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSOrden");
                  GXUtil.WriteLogRaw("Old: ",Z2037UsuSOrden);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2037UsuSOrden[0]);
               }
               if ( StringUtil.StrCmp(Z2038UsuSRet, T005F2_A2038UsuSRet[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuSRet");
                  GXUtil.WriteLogRaw("Old: ",Z2038UsuSRet);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2038UsuSRet[0]);
               }
               if ( StringUtil.StrCmp(Z2013UsuDep, T005F2_A2013UsuDep[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuDep");
                  GXUtil.WriteLogRaw("Old: ",Z2013UsuDep);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2013UsuDep[0]);
               }
               if ( Z69AreCod != T005F2_A69AreCod[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"AreCod");
                  GXUtil.WriteLogRaw("Old: ",Z69AreCod);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A69AreCod[0]);
               }
               if ( Z2041UsuVend != T005F2_A2041UsuVend[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuVend");
                  GXUtil.WriteLogRaw("Old: ",Z2041UsuVend);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2041UsuVend[0]);
               }
               if ( Z2040UsuTieCod != T005F2_A2040UsuTieCod[0] )
               {
                  GXUtil.WriteLog("seguridad.usuarios:[seudo value changed for attri]"+"UsuTieCod");
                  GXUtil.WriteLogRaw("Old: ",Z2040UsuTieCod);
                  GXUtil.WriteLogRaw("Current: ",T005F2_A2040UsuTieCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5F32( )
      {
         BeforeValidate5F32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5F32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5F32( 0) ;
            CheckOptimisticConcurrency5F32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5F32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5F32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005F14 */
                     pr_default.execute(12, new Object[] {A348UsuCod, A2021UsuPas, A2019UsuNom, A2031UsuSerie, A2011UsuAutOcom, A2012UsuAutPago, A2039UsuSts, A2032UsuSerie1, A2033UsuSerie2, A2034UsuSerie3, A2035UsuSerie4, A2036UsuSerie5, A2030UsuReqADM, A2009UsuAut1, A2010UsuAut2, A2020UsuOcMail, A2014UsuEMAIL, A2025UsuPedMail, A2037UsuSOrden, A2038UsuSRet, A2013UsuDep, n69AreCod, A69AreCod, A2041UsuVend, A2040UsuTieCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption5F0( ) ;
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
               Load5F32( ) ;
            }
            EndLevel5F32( ) ;
         }
         CloseExtendedTableCursors5F32( ) ;
      }

      protected void Update5F32( )
      {
         BeforeValidate5F32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5F32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5F32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5F32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5F32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005F15 */
                     pr_default.execute(13, new Object[] {A2021UsuPas, A2019UsuNom, A2031UsuSerie, A2011UsuAutOcom, A2012UsuAutPago, A2039UsuSts, A2032UsuSerie1, A2033UsuSerie2, A2034UsuSerie3, A2035UsuSerie4, A2036UsuSerie5, A2030UsuReqADM, A2009UsuAut1, A2010UsuAut2, A2020UsuOcMail, A2014UsuEMAIL, A2025UsuPedMail, A2037UsuSOrden, A2038UsuSRet, A2013UsuDep, n69AreCod, A69AreCod, A2041UsuVend, A2040UsuTieCod, A348UsuCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5F32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel5F32( ) ;
         }
         CloseExtendedTableCursors5F32( ) ;
      }

      protected void DeferredUpdate5F32( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5F32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5F32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5F32( ) ;
            AfterConfirm5F32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5F32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005F16 */
                  pr_default.execute(14, new Object[] {A348UsuCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5F32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5F32( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005F17 */
            pr_default.execute(15, new Object[] {A2041UsuVend});
            A2097UsuVendDsc = T005F17_A2097UsuVendDsc[0];
            AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
            pr_default.close(15);
            /* Using cursor T005F18 */
            pr_default.execute(16, new Object[] {A2040UsuTieCod});
            A2096UsuTieDsc = T005F18_A2096UsuTieDsc[0];
            AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005F19 */
            pr_default.execute(17, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005F20 */
            pr_default.execute(18, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005F21 */
            pr_default.execute(19, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T005F22 */
            pr_default.execute(20, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T005F23 */
            pr_default.execute(21, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T005F24 */
            pr_default.execute(22, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel5F32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5F32( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("seguridad.usuarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("seguridad.usuarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5F32( )
      {
         /* Scan By routine */
         /* Using cursor T005F25 */
         pr_default.execute(23);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005F25_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5F32( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T005F25_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd5F32( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm5F32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5F32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5F32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5F32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5F32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5F32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5F32( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtUsuPas_Enabled = 0;
         AssignProp("", false, edtUsuPas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuPas_Enabled), 5, 0), true);
         edtUsuNom_Enabled = 0;
         AssignProp("", false, edtUsuNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuNom_Enabled), 5, 0), true);
         edtUsuEMAIL_Enabled = 0;
         AssignProp("", false, edtUsuEMAIL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuEMAIL_Enabled), 5, 0), true);
         cmbUsuAutPago.Enabled = 0;
         AssignProp("", false, cmbUsuAutPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuAutPago.Enabled), 5, 0), true);
         edtUsuTieCod_Enabled = 0;
         AssignProp("", false, edtUsuTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuTieCod_Enabled), 5, 0), true);
         edtAreCod_Enabled = 0;
         AssignProp("", false, edtAreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreCod_Enabled), 5, 0), true);
         edtUsuDep_Enabled = 0;
         AssignProp("", false, edtUsuDep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuDep_Enabled), 5, 0), true);
         edtUsuVend_Enabled = 0;
         AssignProp("", false, edtUsuVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuVend_Enabled), 5, 0), true);
         chkUsuAut1.Enabled = 0;
         AssignProp("", false, chkUsuAut1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAut1.Enabled), 5, 0), true);
         chkUsuAut2.Enabled = 0;
         AssignProp("", false, chkUsuAut2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAut2.Enabled), 5, 0), true);
         chkUsuAutOcom.Enabled = 0;
         AssignProp("", false, chkUsuAutOcom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuAutOcom.Enabled), 5, 0), true);
         chkUsuReqADM.Enabled = 0;
         AssignProp("", false, chkUsuReqADM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuReqADM.Enabled), 5, 0), true);
         chkUsuOcMail.Enabled = 0;
         AssignProp("", false, chkUsuOcMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuOcMail.Enabled), 5, 0), true);
         chkUsuPedMail.Enabled = 0;
         AssignProp("", false, chkUsuPedMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedMail.Enabled), 5, 0), true);
         cmbUsuSts.Enabled = 0;
         AssignProp("", false, cmbUsuSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuSts.Enabled), 5, 0), true);
         edtUsuVendDsc_Enabled = 0;
         AssignProp("", false, edtUsuVendDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuVendDsc_Enabled), 5, 0), true);
         edtUsuTieDsc_Enabled = 0;
         AssignProp("", false, edtUsuTieDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuTieDsc_Enabled), 5, 0), true);
         edtavCombousutiecod_Enabled = 0;
         AssignProp("", false, edtavCombousutiecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousutiecod_Enabled), 5, 0), true);
         edtavComboarecod_Enabled = 0;
         AssignProp("", false, edtavComboarecod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboarecod_Enabled), 5, 0), true);
         edtavCombousuvend_Enabled = 0;
         AssignProp("", false, edtavCombousuvend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombousuvend_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5F32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026123", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV18UsuCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Usuarios");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("UsuSerie", StringUtil.RTrim( context.localUtil.Format( A2031UsuSerie, "")));
         forbiddenHiddens.Add("UsuSerie1", StringUtil.RTrim( context.localUtil.Format( A2032UsuSerie1, "")));
         forbiddenHiddens.Add("UsuSerie2", StringUtil.RTrim( context.localUtil.Format( A2033UsuSerie2, "")));
         forbiddenHiddens.Add("UsuSerie3", StringUtil.RTrim( context.localUtil.Format( A2034UsuSerie3, "")));
         forbiddenHiddens.Add("UsuSerie4", StringUtil.RTrim( context.localUtil.Format( A2035UsuSerie4, "")));
         forbiddenHiddens.Add("UsuSerie5", StringUtil.RTrim( context.localUtil.Format( A2036UsuSerie5, "")));
         forbiddenHiddens.Add("UsuSOrden", StringUtil.RTrim( context.localUtil.Format( A2037UsuSOrden, "")));
         forbiddenHiddens.Add("UsuSRet", StringUtil.RTrim( context.localUtil.Format( A2038UsuSRet, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\usuarios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z2021UsuPas", StringUtil.RTrim( Z2021UsuPas));
         GxWebStd.gx_hidden_field( context, "Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, "Z2031UsuSerie", StringUtil.RTrim( Z2031UsuSerie));
         GxWebStd.gx_hidden_field( context, "Z2011UsuAutOcom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2011UsuAutOcom), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2012UsuAutPago", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2012UsuAutPago), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2039UsuSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2039UsuSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2032UsuSerie1", StringUtil.RTrim( Z2032UsuSerie1));
         GxWebStd.gx_hidden_field( context, "Z2033UsuSerie2", StringUtil.RTrim( Z2033UsuSerie2));
         GxWebStd.gx_hidden_field( context, "Z2034UsuSerie3", StringUtil.RTrim( Z2034UsuSerie3));
         GxWebStd.gx_hidden_field( context, "Z2035UsuSerie4", StringUtil.RTrim( Z2035UsuSerie4));
         GxWebStd.gx_hidden_field( context, "Z2036UsuSerie5", StringUtil.RTrim( Z2036UsuSerie5));
         GxWebStd.gx_hidden_field( context, "Z2030UsuReqADM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2030UsuReqADM), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2009UsuAut1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2009UsuAut1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2010UsuAut2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2010UsuAut2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2020UsuOcMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2020UsuOcMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2014UsuEMAIL", Z2014UsuEMAIL);
         GxWebStd.gx_hidden_field( context, "Z2025UsuPedMail", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2025UsuPedMail), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2037UsuSOrden", StringUtil.RTrim( Z2037UsuSOrden));
         GxWebStd.gx_hidden_field( context, "Z2038UsuSRet", StringUtil.RTrim( Z2038UsuSRet));
         GxWebStd.gx_hidden_field( context, "Z2013UsuDep", Z2013UsuDep);
         GxWebStd.gx_hidden_field( context, "Z69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2041UsuVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2041UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2040UsuTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2040UsuTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N2041UsuVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2041UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N2040UsuTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2040UsuTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A69AreCod), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV13DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUTIECOD_DATA", AV24UsuTieCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUTIECOD_DATA", AV24UsuTieCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vARECOD_DATA", AV12AreCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vARECOD_DATA", AV12AreCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUVEND_DATA", AV28UsuVend_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUVEND_DATA", AV28UsuVend_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vUSUCOD", StringUtil.RTrim( AV18UsuCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18UsuCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_USUVEND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Insert_UsuVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_USUTIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Insert_UsuTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ARECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Insert_AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUSERIE", StringUtil.RTrim( A2031UsuSerie));
         GxWebStd.gx_hidden_field( context, "USUSERIE1", StringUtil.RTrim( A2032UsuSerie1));
         GxWebStd.gx_hidden_field( context, "USUSERIE2", StringUtil.RTrim( A2033UsuSerie2));
         GxWebStd.gx_hidden_field( context, "USUSERIE3", StringUtil.RTrim( A2034UsuSerie3));
         GxWebStd.gx_hidden_field( context, "USUSERIE4", StringUtil.RTrim( A2035UsuSerie4));
         GxWebStd.gx_hidden_field( context, "USUSERIE5", StringUtil.RTrim( A2036UsuSerie5));
         GxWebStd.gx_hidden_field( context, "USUSORDEN", StringUtil.RTrim( A2037UsuSOrden));
         GxWebStd.gx_hidden_field( context, "USUSRET", StringUtil.RTrim( A2038UsuSRet));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV32Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Objectcall", StringUtil.RTrim( Combo_usutiecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Cls", StringUtil.RTrim( Combo_usutiecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Selectedvalue_set", StringUtil.RTrim( Combo_usutiecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Selectedtext_set", StringUtil.RTrim( Combo_usutiecod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Enabled", StringUtil.BoolToStr( Combo_usutiecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Datalistproc", StringUtil.RTrim( Combo_usutiecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usutiecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_USUTIECOD_Emptyitem", StringUtil.BoolToStr( Combo_usutiecod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Objectcall", StringUtil.RTrim( Combo_arecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Cls", StringUtil.RTrim( Combo_arecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Selectedvalue_set", StringUtil.RTrim( Combo_arecod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Selectedtext_set", StringUtil.RTrim( Combo_arecod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Enabled", StringUtil.BoolToStr( Combo_arecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Datalistproc", StringUtil.RTrim( Combo_arecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ARECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_arecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Objectcall", StringUtil.RTrim( Combo_usuvend_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Cls", StringUtil.RTrim( Combo_usuvend_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Selectedvalue_set", StringUtil.RTrim( Combo_usuvend_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Selectedtext_set", StringUtil.RTrim( Combo_usuvend_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Enabled", StringUtil.BoolToStr( Combo_usuvend_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Datalistproc", StringUtil.RTrim( Combo_usuvend_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Datalistprocparametersprefix", StringUtil.RTrim( Combo_usuvend_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_USUVEND_Emptyitem", StringUtil.BoolToStr( Combo_usuvend_Emptyitem));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
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
         if ( ! ( WebComp_Wcusuariosopciones == null ) )
         {
            WebComp_Wcusuariosopciones.componentjscripts();
         }
         if ( ! ( WebComp_Wcusuariosalmacen == null ) )
         {
            WebComp_Wcusuariosalmacen.componentjscripts();
         }
         if ( ! ( WebComp_Wcusuariosseries == null ) )
         {
            WebComp_Wcusuariosseries.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
               {
                  WebComp_Wcusuariosopciones.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Wcusuariosalmacen_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
               {
                  WebComp_Wcusuariosalmacen.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
               {
                  WebComp_Wcusuariosseries.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
               {
                  WebComp_Wcusuariosopciones.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( WebComp_Wcusuariosalmacen_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
               {
                  WebComp_Wcusuariosalmacen.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
               {
                  WebComp_Wcusuariosseries.componentstart();
               }
            }
         }
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.usuarios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV18UsuCod));
         return formatLink("seguridad.usuarios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.Usuarios" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios" ;
      }

      protected void InitializeNonKey5F32( )
      {
         A2041UsuVend = 0;
         AssignAttri("", false, "A2041UsuVend", StringUtil.LTrimStr( (decimal)(A2041UsuVend), 6, 0));
         A2040UsuTieCod = 0;
         AssignAttri("", false, "A2040UsuTieCod", StringUtil.LTrimStr( (decimal)(A2040UsuTieCod), 6, 0));
         A69AreCod = 0;
         n69AreCod = false;
         AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         n69AreCod = ((0==A69AreCod) ? true : false);
         A2021UsuPas = "";
         AssignAttri("", false, "A2021UsuPas", A2021UsuPas);
         A2019UsuNom = "";
         AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
         A2031UsuSerie = "";
         AssignAttri("", false, "A2031UsuSerie", A2031UsuSerie);
         A2011UsuAutOcom = 0;
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         A2032UsuSerie1 = "";
         AssignAttri("", false, "A2032UsuSerie1", A2032UsuSerie1);
         A2033UsuSerie2 = "";
         AssignAttri("", false, "A2033UsuSerie2", A2033UsuSerie2);
         A2034UsuSerie3 = "";
         AssignAttri("", false, "A2034UsuSerie3", A2034UsuSerie3);
         A2035UsuSerie4 = "";
         AssignAttri("", false, "A2035UsuSerie4", A2035UsuSerie4);
         A2097UsuVendDsc = "";
         AssignAttri("", false, "A2097UsuVendDsc", A2097UsuVendDsc);
         A2036UsuSerie5 = "";
         AssignAttri("", false, "A2036UsuSerie5", A2036UsuSerie5);
         A2030UsuReqADM = 0;
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         A2096UsuTieDsc = "";
         AssignAttri("", false, "A2096UsuTieDsc", A2096UsuTieDsc);
         A2009UsuAut1 = 0;
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         A2010UsuAut2 = 0;
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         A2020UsuOcMail = 0;
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         A2014UsuEMAIL = "";
         AssignAttri("", false, "A2014UsuEMAIL", A2014UsuEMAIL);
         A2025UsuPedMail = 0;
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         A2037UsuSOrden = "";
         AssignAttri("", false, "A2037UsuSOrden", A2037UsuSOrden);
         A2038UsuSRet = "";
         AssignAttri("", false, "A2038UsuSRet", A2038UsuSRet);
         A2013UsuDep = "";
         AssignAttri("", false, "A2013UsuDep", A2013UsuDep);
         A2012UsuAutPago = 0;
         AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
         A2039UsuSts = 1;
         AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         Z2021UsuPas = "";
         Z2019UsuNom = "";
         Z2031UsuSerie = "";
         Z2011UsuAutOcom = 0;
         Z2012UsuAutPago = 0;
         Z2039UsuSts = 0;
         Z2032UsuSerie1 = "";
         Z2033UsuSerie2 = "";
         Z2034UsuSerie3 = "";
         Z2035UsuSerie4 = "";
         Z2036UsuSerie5 = "";
         Z2030UsuReqADM = 0;
         Z2009UsuAut1 = 0;
         Z2010UsuAut2 = 0;
         Z2020UsuOcMail = 0;
         Z2014UsuEMAIL = "";
         Z2025UsuPedMail = 0;
         Z2037UsuSOrden = "";
         Z2038UsuSRet = "";
         Z2013UsuDep = "";
         Z69AreCod = 0;
         Z2041UsuVend = 0;
         Z2040UsuTieCod = 0;
      }

      protected void InitAll5F32( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         InitializeNonKey5F32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A2039UsuSts = i2039UsuSts;
         AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
         A2012UsuAutPago = i2012UsuAutPago;
         AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcusuariosopciones == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcusuariosopciones_Component) != 0 )
            {
               WebComp_Wcusuariosopciones.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcusuariosalmacen == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcusuariosalmacen_Component) != 0 )
            {
               WebComp_Wcusuariosalmacen.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcusuariosseries == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcusuariosseries_Component) != 0 )
            {
               WebComp_Wcusuariosseries.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261281", true, true);
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
         context.AddJavascriptSource("seguridad/usuarios.js", "?202281810261281", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTab1_title_Internalname = "TAB1_TITLE";
         edtUsuCod_Internalname = "USUCOD";
         edtUsuPas_Internalname = "USUPAS";
         lblTextblockusunom_Internalname = "TEXTBLOCKUSUNOM";
         edtUsuNom_Internalname = "USUNOM";
         divUnnamedtableusunom_Internalname = "UNNAMEDTABLEUSUNOM";
         lblTextblockusuemail_Internalname = "TEXTBLOCKUSUEMAIL";
         edtUsuEMAIL_Internalname = "USUEMAIL";
         divUnnamedtableusuemail_Internalname = "UNNAMEDTABLEUSUEMAIL";
         lblTextblockusuautpago_Internalname = "TEXTBLOCKUSUAUTPAGO";
         cmbUsuAutPago_Internalname = "USUAUTPAGO";
         divUnnamedtableusuautpago_Internalname = "UNNAMEDTABLEUSUAUTPAGO";
         lblTextblockusutiecod_Internalname = "TEXTBLOCKUSUTIECOD";
         Combo_usutiecod_Internalname = "COMBO_USUTIECOD";
         edtUsuTieCod_Internalname = "USUTIECOD";
         divTablesplittedusutiecod_Internalname = "TABLESPLITTEDUSUTIECOD";
         lblTextblockarecod_Internalname = "TEXTBLOCKARECOD";
         Combo_arecod_Internalname = "COMBO_ARECOD";
         edtAreCod_Internalname = "ARECOD";
         divTablesplittedarecod_Internalname = "TABLESPLITTEDARECOD";
         lblTextblockusudep_Internalname = "TEXTBLOCKUSUDEP";
         edtUsuDep_Internalname = "USUDEP";
         divUnnamedtableusudep_Internalname = "UNNAMEDTABLEUSUDEP";
         lblTextblockusuvend_Internalname = "TEXTBLOCKUSUVEND";
         Combo_usuvend_Internalname = "COMBO_USUVEND";
         edtUsuVend_Internalname = "USUVEND";
         divTablesplittedusuvend_Internalname = "TABLESPLITTEDUSUVEND";
         chkUsuAut1_Internalname = "USUAUT1";
         chkUsuAut2_Internalname = "USUAUT2";
         chkUsuAutOcom_Internalname = "USUAUTOCOM";
         chkUsuReqADM_Internalname = "USUREQADM";
         chkUsuOcMail_Internalname = "USUOCMAIL";
         chkUsuPedMail_Internalname = "USUPEDMAIL";
         lblTextblockususts_Internalname = "TEXTBLOCKUSUSTS";
         cmbUsuSts_Internalname = "USUSTS";
         divUnnamedtableususts_Internalname = "UNNAMEDTABLEUSUSTS";
         edtUsuVendDsc_Internalname = "USUVENDDSC";
         edtUsuTieDsc_Internalname = "USUTIEDSC";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblTab3_title_Internalname = "TAB3_TITLE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblTab2_title_Internalname = "TAB2_TITLE";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTab4_title_Internalname = "TAB4_TITLE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombousutiecod_Internalname = "vCOMBOUSUTIECOD";
         divSectionattribute_usutiecod_Internalname = "SECTIONATTRIBUTE_USUTIECOD";
         edtavComboarecod_Internalname = "vCOMBOARECOD";
         divSectionattribute_arecod_Internalname = "SECTIONATTRIBUTE_ARECOD";
         edtavCombousuvend_Internalname = "vCOMBOUSUVEND";
         divSectionattribute_usuvend_Internalname = "SECTIONATTRIBUTE_USUVEND";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Usuarios";
         edtavCombousuvend_Jsonclick = "";
         edtavCombousuvend_Enabled = 0;
         edtavCombousuvend_Visible = 1;
         edtavComboarecod_Jsonclick = "";
         edtavComboarecod_Enabled = 0;
         edtavComboarecod_Visible = 1;
         edtavCombousutiecod_Jsonclick = "";
         edtavCombousutiecod_Enabled = 0;
         edtavCombousutiecod_Visible = 1;
         WebComp_Wcusuariosalmacen_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0168"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcusuariosalmacen_Visible), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtUsuTieDsc_Jsonclick = "";
         edtUsuTieDsc_Enabled = 0;
         edtUsuVendDsc_Jsonclick = "";
         edtUsuVendDsc_Enabled = 0;
         cmbUsuSts_Jsonclick = "";
         cmbUsuSts.Enabled = 1;
         chkUsuPedMail.Enabled = 1;
         chkUsuOcMail.Enabled = 1;
         chkUsuReqADM.Enabled = 1;
         chkUsuAutOcom.Enabled = 1;
         chkUsuAut2.Enabled = 1;
         chkUsuAut1.Enabled = 1;
         edtUsuVend_Jsonclick = "";
         edtUsuVend_Enabled = 1;
         edtUsuVend_Visible = 1;
         Combo_usuvend_Emptyitem = Convert.ToBoolean( 0);
         Combo_usuvend_Datalistprocparametersprefix = " \"ComboName\": \"UsuVend\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_usuvend_Datalistproc = "Seguridad.UsuariosLoadDVCombo";
         Combo_usuvend_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_usuvend_Caption = "";
         Combo_usuvend_Enabled = Convert.ToBoolean( -1);
         edtUsuDep_Jsonclick = "";
         edtUsuDep_Enabled = 1;
         edtAreCod_Jsonclick = "";
         edtAreCod_Enabled = 1;
         edtAreCod_Visible = 1;
         Combo_arecod_Datalistprocparametersprefix = " \"ComboName\": \"AreCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_arecod_Datalistproc = "Seguridad.UsuariosLoadDVCombo";
         Combo_arecod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_arecod_Caption = "";
         Combo_arecod_Enabled = Convert.ToBoolean( -1);
         edtUsuTieCod_Jsonclick = "";
         edtUsuTieCod_Enabled = 1;
         edtUsuTieCod_Visible = 1;
         Combo_usutiecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_usutiecod_Datalistprocparametersprefix = " \"ComboName\": \"UsuTieCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UsuCod\": \"\"";
         Combo_usutiecod_Datalistproc = "Seguridad.UsuariosLoadDVCombo";
         Combo_usutiecod_Cls = "ExtendedCombo AttributeRealWidth50With";
         Combo_usutiecod_Caption = "";
         Combo_usutiecod_Enabled = Convert.ToBoolean( -1);
         cmbUsuAutPago_Jsonclick = "";
         cmbUsuAutPago.Enabled = 1;
         edtUsuEMAIL_Jsonclick = "";
         edtUsuEMAIL_Enabled = 1;
         edtUsuNom_Jsonclick = "";
         edtUsuNom_Enabled = 1;
         edtUsuPas_Jsonclick = "";
         edtUsuPas_Enabled = 1;
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "";
         Gxuitabspanel_tabs_Pagecount = 4;
         divLayoutmaintable_Class = "Table";
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
         cmbUsuAutPago.Name = "USUAUTPAGO";
         cmbUsuAutPago.WebTags = "";
         cmbUsuAutPago.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(Ninguno)", 0);
         cmbUsuAutPago.addItem("1", "Administrador", 0);
         if ( cmbUsuAutPago.ItemCount > 0 )
         {
            if ( (0==A2012UsuAutPago) )
            {
               A2012UsuAutPago = 0;
               AssignAttri("", false, "A2012UsuAutPago", StringUtil.Str( (decimal)(A2012UsuAutPago), 1, 0));
            }
         }
         chkUsuAut1.Name = "USUAUT1";
         chkUsuAut1.WebTags = "";
         chkUsuAut1.Caption = "";
         AssignProp("", false, chkUsuAut1_Internalname, "TitleCaption", chkUsuAut1.Caption, true);
         chkUsuAut1.CheckedValue = "0";
         A2009UsuAut1 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2009UsuAut1), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2009UsuAut1", StringUtil.Str( (decimal)(A2009UsuAut1), 1, 0));
         chkUsuAut2.Name = "USUAUT2";
         chkUsuAut2.WebTags = "";
         chkUsuAut2.Caption = "";
         AssignProp("", false, chkUsuAut2_Internalname, "TitleCaption", chkUsuAut2.Caption, true);
         chkUsuAut2.CheckedValue = "0";
         A2010UsuAut2 = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2010UsuAut2), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2010UsuAut2", StringUtil.Str( (decimal)(A2010UsuAut2), 1, 0));
         chkUsuAutOcom.Name = "USUAUTOCOM";
         chkUsuAutOcom.WebTags = "";
         chkUsuAutOcom.Caption = "";
         AssignProp("", false, chkUsuAutOcom_Internalname, "TitleCaption", chkUsuAutOcom.Caption, true);
         chkUsuAutOcom.CheckedValue = "0";
         A2011UsuAutOcom = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2011UsuAutOcom), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2011UsuAutOcom", StringUtil.Str( (decimal)(A2011UsuAutOcom), 1, 0));
         chkUsuReqADM.Name = "USUREQADM";
         chkUsuReqADM.WebTags = "";
         chkUsuReqADM.Caption = "";
         AssignProp("", false, chkUsuReqADM_Internalname, "TitleCaption", chkUsuReqADM.Caption, true);
         chkUsuReqADM.CheckedValue = "0";
         A2030UsuReqADM = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2030UsuReqADM), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2030UsuReqADM", StringUtil.Str( (decimal)(A2030UsuReqADM), 1, 0));
         chkUsuOcMail.Name = "USUOCMAIL";
         chkUsuOcMail.WebTags = "";
         chkUsuOcMail.Caption = "";
         AssignProp("", false, chkUsuOcMail_Internalname, "TitleCaption", chkUsuOcMail.Caption, true);
         chkUsuOcMail.CheckedValue = "0";
         A2020UsuOcMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2020UsuOcMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2020UsuOcMail", StringUtil.Str( (decimal)(A2020UsuOcMail), 1, 0));
         chkUsuPedMail.Name = "USUPEDMAIL";
         chkUsuPedMail.WebTags = "";
         chkUsuPedMail.Caption = "";
         AssignProp("", false, chkUsuPedMail_Internalname, "TitleCaption", chkUsuPedMail.Caption, true);
         chkUsuPedMail.CheckedValue = "0";
         A2025UsuPedMail = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2025UsuPedMail), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2025UsuPedMail", StringUtil.Str( (decimal)(A2025UsuPedMail), 1, 0));
         cmbUsuSts.Name = "USUSTS";
         cmbUsuSts.WebTags = "";
         cmbUsuSts.addItem("1", "ACTIVO", 0);
         cmbUsuSts.addItem("0", "INACTIVO", 0);
         if ( cmbUsuSts.ItemCount > 0 )
         {
            if ( (0==A2039UsuSts) )
            {
               A2039UsuSts = 1;
               AssignAttri("", false, "A2039UsuSts", StringUtil.Str( (decimal)(A2039UsuSts), 1, 0));
            }
         }
         /* End function init_web_controls */
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

      public void Valid_Usutiecod( )
      {
         /* Using cursor T005F18 */
         pr_default.execute(16, new Object[] {A2040UsuTieCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tienda'.", "ForeignKeyNotFound", 1, "USUTIECOD");
            AnyError = 1;
            GX_FocusControl = edtUsuTieCod_Internalname;
         }
         A2096UsuTieDsc = T005F18_A2096UsuTieDsc[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2096UsuTieDsc", StringUtil.RTrim( A2096UsuTieDsc));
      }

      public void Valid_Arecod( )
      {
         n69AreCod = false;
         /* Using cursor T005F26 */
         pr_default.execute(24, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A69AreCod) ) )
            {
               GX_msglist.addItem("No existe 'Areas Empresa'.", "ForeignKeyNotFound", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usuvend( )
      {
         /* Using cursor T005F17 */
         pr_default.execute(15, new Object[] {A2041UsuVend});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "USUVEND");
            AnyError = 1;
            GX_FocusControl = edtUsuVend_Internalname;
         }
         A2097UsuVendDsc = T005F17_A2097UsuVendDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2097UsuVendDsc", StringUtil.RTrim( A2097UsuVendDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV18UsuCod',fld:'vUSUCOD',pic:'',hsh:true},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV18UsuCod',fld:'vUSUCOD',pic:'',hsh:true},{av:'A2031UsuSerie',fld:'USUSERIE',pic:''},{av:'A2032UsuSerie1',fld:'USUSERIE1',pic:''},{av:'A2033UsuSerie2',fld:'USUSERIE2',pic:''},{av:'A2034UsuSerie3',fld:'USUSERIE3',pic:''},{av:'A2035UsuSerie4',fld:'USUSERIE4',pic:''},{av:'A2036UsuSerie5',fld:'USUSERIE5',pic:''},{av:'A2037UsuSOrden',fld:'USUSORDEN',pic:''},{av:'A2038UsuSRet',fld:'USUSRET',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E125F2',iparms:[{av:'cmbUsuAutPago'},{av:'A2012UsuAutPago',fld:'USUAUTPAGO',pic:'9'},{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_USUCOD",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_USUPAS","{handler:'Valid_Usupas',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_USUPAS",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_USUNOM","{handler:'Valid_Usunom',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_USUNOM",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_USUTIECOD","{handler:'Valid_Usutiecod',iparms:[{av:'A2040UsuTieCod',fld:'USUTIECOD',pic:'ZZZZZ9'},{av:'A2096UsuTieDsc',fld:'USUTIEDSC',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_USUTIECOD",",oparms:[{av:'A2096UsuTieDsc',fld:'USUTIEDSC',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_ARECOD","{handler:'Valid_Arecod',iparms:[{av:'A69AreCod',fld:'ARECOD',pic:'ZZZZZ9'},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_ARECOD",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALID_USUVEND","{handler:'Valid_Usuvend',iparms:[{av:'A2041UsuVend',fld:'USUVEND',pic:'ZZZZZ9'},{av:'A2097UsuVendDsc',fld:'USUVENDDSC',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALID_USUVEND",",oparms:[{av:'A2097UsuVendDsc',fld:'USUVENDDSC',pic:''},{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUTIECOD","{handler:'Validv_Combousutiecod',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUTIECOD",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOARECOD","{handler:'Validv_Comboarecod',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOARECOD",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
         setEventMetadata("VALIDV_COMBOUSUVEND","{handler:'Validv_Combousuvend',iparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]");
         setEventMetadata("VALIDV_COMBOUSUVEND",",oparms:[{av:'A2009UsuAut1',fld:'USUAUT1',pic:'9'},{av:'A2010UsuAut2',fld:'USUAUT2',pic:'9'},{av:'A2011UsuAutOcom',fld:'USUAUTOCOM',pic:'9'},{av:'A2030UsuReqADM',fld:'USUREQADM',pic:'9'},{av:'A2020UsuOcMail',fld:'USUOCMAIL',pic:'9'},{av:'A2025UsuPedMail',fld:'USUPEDMAIL',pic:'9'}]}");
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
         pr_default.close(24);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV18UsuCod = "";
         Z348UsuCod = "";
         Z2021UsuPas = "";
         Z2019UsuNom = "";
         Z2031UsuSerie = "";
         Z2032UsuSerie1 = "";
         Z2033UsuSerie2 = "";
         Z2034UsuSerie3 = "";
         Z2035UsuSerie4 = "";
         Z2036UsuSerie5 = "";
         Z2014UsuEMAIL = "";
         Z2037UsuSOrden = "";
         Z2038UsuSRet = "";
         Z2013UsuDep = "";
         Combo_usuvend_Selectedvalue_get = "";
         Combo_arecod_Selectedvalue_get = "";
         Combo_usutiecod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         TempTags = "";
         A348UsuCod = "";
         A2021UsuPas = "";
         lblTextblockusunom_Jsonclick = "";
         A2019UsuNom = "";
         lblTextblockusuemail_Jsonclick = "";
         A2014UsuEMAIL = "";
         lblTextblockusuautpago_Jsonclick = "";
         lblTextblockusutiecod_Jsonclick = "";
         ucCombo_usutiecod = new GXUserControl();
         AV13DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24UsuTieCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockarecod_Jsonclick = "";
         ucCombo_arecod = new GXUserControl();
         AV12AreCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockusudep_Jsonclick = "";
         A2013UsuDep = "";
         lblTextblockusuvend_Jsonclick = "";
         ucCombo_usuvend = new GXUserControl();
         AV28UsuVend_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockususts_Jsonclick = "";
         A2097UsuVendDsc = "";
         A2096UsuTieDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         lblTab3_title_Jsonclick = "";
         WebComp_Wcusuariosopciones_Component = "";
         OldWcusuariosopciones = "";
         lblTab2_title_Jsonclick = "";
         WebComp_Wcusuariosalmacen_Component = "";
         OldWcusuariosalmacen = "";
         lblTab4_title_Jsonclick = "";
         WebComp_Wcusuariosseries_Component = "";
         OldWcusuariosseries = "";
         A2031UsuSerie = "";
         A2032UsuSerie1 = "";
         A2033UsuSerie2 = "";
         A2034UsuSerie3 = "";
         A2035UsuSerie4 = "";
         A2036UsuSerie5 = "";
         A2037UsuSOrden = "";
         A2038UsuSRet = "";
         AV32Pgmname = "";
         Combo_usutiecod_Objectcall = "";
         Combo_usutiecod_Class = "";
         Combo_usutiecod_Icontype = "";
         Combo_usutiecod_Icon = "";
         Combo_usutiecod_Tooltip = "";
         Combo_usutiecod_Selectedvalue_set = "";
         Combo_usutiecod_Selectedtext_set = "";
         Combo_usutiecod_Selectedtext_get = "";
         Combo_usutiecod_Gamoauthtoken = "";
         Combo_usutiecod_Ddointernalname = "";
         Combo_usutiecod_Titlecontrolalign = "";
         Combo_usutiecod_Dropdownoptionstype = "";
         Combo_usutiecod_Titlecontrolidtoreplace = "";
         Combo_usutiecod_Datalisttype = "";
         Combo_usutiecod_Datalistfixedvalues = "";
         Combo_usutiecod_Htmltemplate = "";
         Combo_usutiecod_Multiplevaluestype = "";
         Combo_usutiecod_Loadingdata = "";
         Combo_usutiecod_Noresultsfound = "";
         Combo_usutiecod_Emptyitemtext = "";
         Combo_usutiecod_Onlyselectedvalues = "";
         Combo_usutiecod_Selectalltext = "";
         Combo_usutiecod_Multiplevaluesseparator = "";
         Combo_usutiecod_Addnewoptiontext = "";
         Combo_arecod_Objectcall = "";
         Combo_arecod_Class = "";
         Combo_arecod_Icontype = "";
         Combo_arecod_Icon = "";
         Combo_arecod_Tooltip = "";
         Combo_arecod_Selectedvalue_set = "";
         Combo_arecod_Selectedtext_set = "";
         Combo_arecod_Selectedtext_get = "";
         Combo_arecod_Gamoauthtoken = "";
         Combo_arecod_Ddointernalname = "";
         Combo_arecod_Titlecontrolalign = "";
         Combo_arecod_Dropdownoptionstype = "";
         Combo_arecod_Titlecontrolidtoreplace = "";
         Combo_arecod_Datalisttype = "";
         Combo_arecod_Datalistfixedvalues = "";
         Combo_arecod_Htmltemplate = "";
         Combo_arecod_Multiplevaluestype = "";
         Combo_arecod_Loadingdata = "";
         Combo_arecod_Noresultsfound = "";
         Combo_arecod_Emptyitemtext = "";
         Combo_arecod_Onlyselectedvalues = "";
         Combo_arecod_Selectalltext = "";
         Combo_arecod_Multiplevaluesseparator = "";
         Combo_arecod_Addnewoptiontext = "";
         Combo_usuvend_Objectcall = "";
         Combo_usuvend_Class = "";
         Combo_usuvend_Icontype = "";
         Combo_usuvend_Icon = "";
         Combo_usuvend_Tooltip = "";
         Combo_usuvend_Selectedvalue_set = "";
         Combo_usuvend_Selectedtext_set = "";
         Combo_usuvend_Selectedtext_get = "";
         Combo_usuvend_Gamoauthtoken = "";
         Combo_usuvend_Ddointernalname = "";
         Combo_usuvend_Titlecontrolalign = "";
         Combo_usuvend_Dropdownoptionstype = "";
         Combo_usuvend_Titlecontrolidtoreplace = "";
         Combo_usuvend_Datalisttype = "";
         Combo_usuvend_Datalistfixedvalues = "";
         Combo_usuvend_Htmltemplate = "";
         Combo_usuvend_Multiplevaluestype = "";
         Combo_usuvend_Loadingdata = "";
         Combo_usuvend_Noresultsfound = "";
         Combo_usuvend_Emptyitemtext = "";
         Combo_usuvend_Onlyselectedvalues = "";
         Combo_usuvend_Selectalltext = "";
         Combo_usuvend_Multiplevaluesseparator = "";
         Combo_usuvend_Addnewoptiontext = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV16Combo_DataJson = "";
         AV14ComboSelectedValue = "";
         AV15ComboSelectedText = "";
         GXt_char2 = "";
         Z2097UsuVendDsc = "";
         Z2096UsuTieDsc = "";
         T005F6_A2096UsuTieDsc = new string[] {""} ;
         T005F5_A2097UsuVendDsc = new string[] {""} ;
         T005F7_A348UsuCod = new string[] {""} ;
         T005F7_A2021UsuPas = new string[] {""} ;
         T005F7_A2019UsuNom = new string[] {""} ;
         T005F7_A2031UsuSerie = new string[] {""} ;
         T005F7_A2011UsuAutOcom = new short[1] ;
         T005F7_A2012UsuAutPago = new short[1] ;
         T005F7_A2039UsuSts = new short[1] ;
         T005F7_A2032UsuSerie1 = new string[] {""} ;
         T005F7_A2033UsuSerie2 = new string[] {""} ;
         T005F7_A2034UsuSerie3 = new string[] {""} ;
         T005F7_A2035UsuSerie4 = new string[] {""} ;
         T005F7_A2097UsuVendDsc = new string[] {""} ;
         T005F7_A2036UsuSerie5 = new string[] {""} ;
         T005F7_A2030UsuReqADM = new short[1] ;
         T005F7_A2096UsuTieDsc = new string[] {""} ;
         T005F7_A2009UsuAut1 = new short[1] ;
         T005F7_A2010UsuAut2 = new short[1] ;
         T005F7_A2020UsuOcMail = new short[1] ;
         T005F7_A2014UsuEMAIL = new string[] {""} ;
         T005F7_A2025UsuPedMail = new short[1] ;
         T005F7_A2037UsuSOrden = new string[] {""} ;
         T005F7_A2038UsuSRet = new string[] {""} ;
         T005F7_A2013UsuDep = new string[] {""} ;
         T005F7_A69AreCod = new int[1] ;
         T005F7_n69AreCod = new bool[] {false} ;
         T005F7_A2041UsuVend = new int[1] ;
         T005F7_A2040UsuTieCod = new int[1] ;
         T005F4_A69AreCod = new int[1] ;
         T005F4_n69AreCod = new bool[] {false} ;
         T005F8_A2097UsuVendDsc = new string[] {""} ;
         T005F9_A2096UsuTieDsc = new string[] {""} ;
         T005F10_A69AreCod = new int[1] ;
         T005F10_n69AreCod = new bool[] {false} ;
         T005F11_A348UsuCod = new string[] {""} ;
         T005F3_A348UsuCod = new string[] {""} ;
         T005F3_A2021UsuPas = new string[] {""} ;
         T005F3_A2019UsuNom = new string[] {""} ;
         T005F3_A2031UsuSerie = new string[] {""} ;
         T005F3_A2011UsuAutOcom = new short[1] ;
         T005F3_A2012UsuAutPago = new short[1] ;
         T005F3_A2039UsuSts = new short[1] ;
         T005F3_A2032UsuSerie1 = new string[] {""} ;
         T005F3_A2033UsuSerie2 = new string[] {""} ;
         T005F3_A2034UsuSerie3 = new string[] {""} ;
         T005F3_A2035UsuSerie4 = new string[] {""} ;
         T005F3_A2036UsuSerie5 = new string[] {""} ;
         T005F3_A2030UsuReqADM = new short[1] ;
         T005F3_A2009UsuAut1 = new short[1] ;
         T005F3_A2010UsuAut2 = new short[1] ;
         T005F3_A2020UsuOcMail = new short[1] ;
         T005F3_A2014UsuEMAIL = new string[] {""} ;
         T005F3_A2025UsuPedMail = new short[1] ;
         T005F3_A2037UsuSOrden = new string[] {""} ;
         T005F3_A2038UsuSRet = new string[] {""} ;
         T005F3_A2013UsuDep = new string[] {""} ;
         T005F3_A69AreCod = new int[1] ;
         T005F3_n69AreCod = new bool[] {false} ;
         T005F3_A2041UsuVend = new int[1] ;
         T005F3_A2040UsuTieCod = new int[1] ;
         T005F12_A348UsuCod = new string[] {""} ;
         T005F13_A348UsuCod = new string[] {""} ;
         T005F2_A348UsuCod = new string[] {""} ;
         T005F2_A2021UsuPas = new string[] {""} ;
         T005F2_A2019UsuNom = new string[] {""} ;
         T005F2_A2031UsuSerie = new string[] {""} ;
         T005F2_A2011UsuAutOcom = new short[1] ;
         T005F2_A2012UsuAutPago = new short[1] ;
         T005F2_A2039UsuSts = new short[1] ;
         T005F2_A2032UsuSerie1 = new string[] {""} ;
         T005F2_A2033UsuSerie2 = new string[] {""} ;
         T005F2_A2034UsuSerie3 = new string[] {""} ;
         T005F2_A2035UsuSerie4 = new string[] {""} ;
         T005F2_A2036UsuSerie5 = new string[] {""} ;
         T005F2_A2030UsuReqADM = new short[1] ;
         T005F2_A2009UsuAut1 = new short[1] ;
         T005F2_A2010UsuAut2 = new short[1] ;
         T005F2_A2020UsuOcMail = new short[1] ;
         T005F2_A2014UsuEMAIL = new string[] {""} ;
         T005F2_A2025UsuPedMail = new short[1] ;
         T005F2_A2037UsuSOrden = new string[] {""} ;
         T005F2_A2038UsuSRet = new string[] {""} ;
         T005F2_A2013UsuDep = new string[] {""} ;
         T005F2_A69AreCod = new int[1] ;
         T005F2_n69AreCod = new bool[] {false} ;
         T005F2_A2041UsuVend = new int[1] ;
         T005F2_A2040UsuTieCod = new int[1] ;
         T005F17_A2097UsuVendDsc = new string[] {""} ;
         T005F18_A2096UsuTieDsc = new string[] {""} ;
         T005F19_A2237SGNotificacionID = new long[1] ;
         T005F19_A2245SGNotificacionDetID = new short[1] ;
         T005F20_A2237SGNotificacionID = new long[1] ;
         T005F21_A348UsuCod = new string[] {""} ;
         T005F21_A149TipCod = new string[] {""} ;
         T005F21_A351UsuSerDet = new string[] {""} ;
         T005F22_A348UsuCod = new string[] {""} ;
         T005F22_A346ObjCod = new int[1] ;
         T005F23_A348UsuCod = new string[] {""} ;
         T005F23_A342SGMenuPrograma = new string[] {""} ;
         T005F23_A343SGMenuNiv1ID = new string[] {""} ;
         T005F24_A348UsuCod = new string[] {""} ;
         T005F24_A349UsuAlmCod = new int[1] ;
         T005F25_A348UsuCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T005F26_A69AreCod = new int[1] ;
         T005F26_n69AreCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuarios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuarios__default(),
            new Object[][] {
                new Object[] {
               T005F2_A348UsuCod, T005F2_A2021UsuPas, T005F2_A2019UsuNom, T005F2_A2031UsuSerie, T005F2_A2011UsuAutOcom, T005F2_A2012UsuAutPago, T005F2_A2039UsuSts, T005F2_A2032UsuSerie1, T005F2_A2033UsuSerie2, T005F2_A2034UsuSerie3,
               T005F2_A2035UsuSerie4, T005F2_A2036UsuSerie5, T005F2_A2030UsuReqADM, T005F2_A2009UsuAut1, T005F2_A2010UsuAut2, T005F2_A2020UsuOcMail, T005F2_A2014UsuEMAIL, T005F2_A2025UsuPedMail, T005F2_A2037UsuSOrden, T005F2_A2038UsuSRet,
               T005F2_A2013UsuDep, T005F2_A69AreCod, T005F2_n69AreCod, T005F2_A2041UsuVend, T005F2_A2040UsuTieCod
               }
               , new Object[] {
               T005F3_A348UsuCod, T005F3_A2021UsuPas, T005F3_A2019UsuNom, T005F3_A2031UsuSerie, T005F3_A2011UsuAutOcom, T005F3_A2012UsuAutPago, T005F3_A2039UsuSts, T005F3_A2032UsuSerie1, T005F3_A2033UsuSerie2, T005F3_A2034UsuSerie3,
               T005F3_A2035UsuSerie4, T005F3_A2036UsuSerie5, T005F3_A2030UsuReqADM, T005F3_A2009UsuAut1, T005F3_A2010UsuAut2, T005F3_A2020UsuOcMail, T005F3_A2014UsuEMAIL, T005F3_A2025UsuPedMail, T005F3_A2037UsuSOrden, T005F3_A2038UsuSRet,
               T005F3_A2013UsuDep, T005F3_A69AreCod, T005F3_n69AreCod, T005F3_A2041UsuVend, T005F3_A2040UsuTieCod
               }
               , new Object[] {
               T005F4_A69AreCod
               }
               , new Object[] {
               T005F5_A2097UsuVendDsc
               }
               , new Object[] {
               T005F6_A2096UsuTieDsc
               }
               , new Object[] {
               T005F7_A348UsuCod, T005F7_A2021UsuPas, T005F7_A2019UsuNom, T005F7_A2031UsuSerie, T005F7_A2011UsuAutOcom, T005F7_A2012UsuAutPago, T005F7_A2039UsuSts, T005F7_A2032UsuSerie1, T005F7_A2033UsuSerie2, T005F7_A2034UsuSerie3,
               T005F7_A2035UsuSerie4, T005F7_A2097UsuVendDsc, T005F7_A2036UsuSerie5, T005F7_A2030UsuReqADM, T005F7_A2096UsuTieDsc, T005F7_A2009UsuAut1, T005F7_A2010UsuAut2, T005F7_A2020UsuOcMail, T005F7_A2014UsuEMAIL, T005F7_A2025UsuPedMail,
               T005F7_A2037UsuSOrden, T005F7_A2038UsuSRet, T005F7_A2013UsuDep, T005F7_A69AreCod, T005F7_n69AreCod, T005F7_A2041UsuVend, T005F7_A2040UsuTieCod
               }
               , new Object[] {
               T005F8_A2097UsuVendDsc
               }
               , new Object[] {
               T005F9_A2096UsuTieDsc
               }
               , new Object[] {
               T005F10_A69AreCod
               }
               , new Object[] {
               T005F11_A348UsuCod
               }
               , new Object[] {
               T005F12_A348UsuCod
               }
               , new Object[] {
               T005F13_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005F17_A2097UsuVendDsc
               }
               , new Object[] {
               T005F18_A2096UsuTieDsc
               }
               , new Object[] {
               T005F19_A2237SGNotificacionID, T005F19_A2245SGNotificacionDetID
               }
               , new Object[] {
               T005F20_A2237SGNotificacionID
               }
               , new Object[] {
               T005F21_A348UsuCod, T005F21_A149TipCod, T005F21_A351UsuSerDet
               }
               , new Object[] {
               T005F22_A348UsuCod, T005F22_A346ObjCod
               }
               , new Object[] {
               T005F23_A348UsuCod, T005F23_A342SGMenuPrograma, T005F23_A343SGMenuNiv1ID
               }
               , new Object[] {
               T005F24_A348UsuCod, T005F24_A349UsuAlmCod
               }
               , new Object[] {
               T005F25_A348UsuCod
               }
               , new Object[] {
               T005F26_A69AreCod
               }
            }
         );
         WebComp_Wcusuariosopciones = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcusuariosalmacen = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcusuariosseries = new GeneXus.Http.GXNullWebComponent();
         AV32Pgmname = "Seguridad.Usuarios";
         Z2012UsuAutPago = 0;
         A2012UsuAutPago = 0;
         i2012UsuAutPago = 0;
         Z2039UsuSts = 1;
         A2039UsuSts = 1;
         i2039UsuSts = 1;
      }

      private short Z2011UsuAutOcom ;
      private short Z2012UsuAutPago ;
      private short Z2039UsuSts ;
      private short Z2030UsuReqADM ;
      private short Z2009UsuAut1 ;
      private short Z2010UsuAut2 ;
      private short Z2020UsuOcMail ;
      private short Z2025UsuPedMail ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2012UsuAutPago ;
      private short A2009UsuAut1 ;
      private short A2010UsuAut2 ;
      private short A2011UsuAutOcom ;
      private short A2030UsuReqADM ;
      private short A2020UsuOcMail ;
      private short A2025UsuPedMail ;
      private short A2039UsuSts ;
      private short Gx_BScreen ;
      private short RcdFound32 ;
      private short nCmpId ;
      private short GX_JID ;
      private short nIsDirty_32 ;
      private short gxajaxcallmode ;
      private short i2039UsuSts ;
      private short i2012UsuAutPago ;
      private int Z69AreCod ;
      private int Z2041UsuVend ;
      private int Z2040UsuTieCod ;
      private int N2041UsuVend ;
      private int N2040UsuTieCod ;
      private int N69AreCod ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int A69AreCod ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtUsuCod_Enabled ;
      private int edtUsuPas_Enabled ;
      private int edtUsuNom_Enabled ;
      private int edtUsuEMAIL_Enabled ;
      private int edtUsuTieCod_Visible ;
      private int edtUsuTieCod_Enabled ;
      private int edtAreCod_Visible ;
      private int edtAreCod_Enabled ;
      private int edtUsuDep_Enabled ;
      private int edtUsuVend_Visible ;
      private int edtUsuVend_Enabled ;
      private int edtUsuVendDsc_Enabled ;
      private int edtUsuTieDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int WebComp_Wcusuariosalmacen_Visible ;
      private int AV25ComboUsuTieCod ;
      private int edtavCombousutiecod_Enabled ;
      private int edtavCombousutiecod_Visible ;
      private int AV17ComboAreCod ;
      private int edtavComboarecod_Enabled ;
      private int edtavComboarecod_Visible ;
      private int AV29ComboUsuVend ;
      private int edtavCombousuvend_Enabled ;
      private int edtavCombousuvend_Visible ;
      private int AV27Insert_UsuVend ;
      private int AV23Insert_UsuTieCod ;
      private int AV10Insert_AreCod ;
      private int Combo_usutiecod_Datalistupdateminimumcharacters ;
      private int Combo_usutiecod_Gxcontroltype ;
      private int Combo_arecod_Datalistupdateminimumcharacters ;
      private int Combo_arecod_Gxcontroltype ;
      private int Combo_usuvend_Datalistupdateminimumcharacters ;
      private int Combo_usuvend_Gxcontroltype ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int AV33GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV18UsuCod ;
      private string Z348UsuCod ;
      private string Z2021UsuPas ;
      private string Z2019UsuNom ;
      private string Z2031UsuSerie ;
      private string Z2032UsuSerie1 ;
      private string Z2033UsuSerie2 ;
      private string Z2034UsuSerie3 ;
      private string Z2035UsuSerie4 ;
      private string Z2036UsuSerie5 ;
      private string Z2037UsuSOrden ;
      private string Z2038UsuSRet ;
      private string Combo_usuvend_Selectedvalue_get ;
      private string Combo_arecod_Selectedvalue_get ;
      private string Combo_usutiecod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV18UsuCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
      private string cmbUsuAutPago_Internalname ;
      private string cmbUsuSts_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string A348UsuCod ;
      private string edtUsuCod_Jsonclick ;
      private string edtUsuPas_Internalname ;
      private string A2021UsuPas ;
      private string edtUsuPas_Jsonclick ;
      private string divUnnamedtableusunom_Internalname ;
      private string lblTextblockusunom_Internalname ;
      private string lblTextblockusunom_Jsonclick ;
      private string edtUsuNom_Internalname ;
      private string A2019UsuNom ;
      private string edtUsuNom_Jsonclick ;
      private string divUnnamedtableusuemail_Internalname ;
      private string lblTextblockusuemail_Internalname ;
      private string lblTextblockusuemail_Jsonclick ;
      private string edtUsuEMAIL_Internalname ;
      private string edtUsuEMAIL_Jsonclick ;
      private string divUnnamedtableusuautpago_Internalname ;
      private string lblTextblockusuautpago_Internalname ;
      private string lblTextblockusuautpago_Jsonclick ;
      private string cmbUsuAutPago_Jsonclick ;
      private string divTablesplittedusutiecod_Internalname ;
      private string lblTextblockusutiecod_Internalname ;
      private string lblTextblockusutiecod_Jsonclick ;
      private string Combo_usutiecod_Caption ;
      private string Combo_usutiecod_Cls ;
      private string Combo_usutiecod_Datalistproc ;
      private string Combo_usutiecod_Datalistprocparametersprefix ;
      private string Combo_usutiecod_Internalname ;
      private string edtUsuTieCod_Internalname ;
      private string edtUsuTieCod_Jsonclick ;
      private string divTablesplittedarecod_Internalname ;
      private string lblTextblockarecod_Internalname ;
      private string lblTextblockarecod_Jsonclick ;
      private string Combo_arecod_Caption ;
      private string Combo_arecod_Cls ;
      private string Combo_arecod_Datalistproc ;
      private string Combo_arecod_Datalistprocparametersprefix ;
      private string Combo_arecod_Internalname ;
      private string edtAreCod_Internalname ;
      private string edtAreCod_Jsonclick ;
      private string divUnnamedtableusudep_Internalname ;
      private string lblTextblockusudep_Internalname ;
      private string lblTextblockusudep_Jsonclick ;
      private string edtUsuDep_Internalname ;
      private string edtUsuDep_Jsonclick ;
      private string divTablesplittedusuvend_Internalname ;
      private string lblTextblockusuvend_Internalname ;
      private string lblTextblockusuvend_Jsonclick ;
      private string Combo_usuvend_Caption ;
      private string Combo_usuvend_Cls ;
      private string Combo_usuvend_Datalistproc ;
      private string Combo_usuvend_Datalistprocparametersprefix ;
      private string Combo_usuvend_Internalname ;
      private string edtUsuVend_Internalname ;
      private string edtUsuVend_Jsonclick ;
      private string chkUsuAut1_Internalname ;
      private string chkUsuAut2_Internalname ;
      private string chkUsuAutOcom_Internalname ;
      private string chkUsuReqADM_Internalname ;
      private string chkUsuOcMail_Internalname ;
      private string chkUsuPedMail_Internalname ;
      private string divUnnamedtableususts_Internalname ;
      private string lblTextblockususts_Internalname ;
      private string lblTextblockususts_Jsonclick ;
      private string cmbUsuSts_Jsonclick ;
      private string edtUsuVendDsc_Internalname ;
      private string A2097UsuVendDsc ;
      private string edtUsuVendDsc_Jsonclick ;
      private string edtUsuTieDsc_Internalname ;
      private string A2096UsuTieDsc ;
      private string edtUsuTieDsc_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string lblTab3_title_Internalname ;
      private string lblTab3_title_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string WebComp_Wcusuariosopciones_Component ;
      private string OldWcusuariosopciones ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string WebComp_Wcusuariosalmacen_Component ;
      private string OldWcusuariosalmacen ;
      private string lblTab4_title_Internalname ;
      private string lblTab4_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string WebComp_Wcusuariosseries_Component ;
      private string OldWcusuariosseries ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_usutiecod_Internalname ;
      private string edtavCombousutiecod_Internalname ;
      private string edtavCombousutiecod_Jsonclick ;
      private string divSectionattribute_arecod_Internalname ;
      private string edtavComboarecod_Internalname ;
      private string edtavComboarecod_Jsonclick ;
      private string divSectionattribute_usuvend_Internalname ;
      private string edtavCombousuvend_Internalname ;
      private string edtavCombousuvend_Jsonclick ;
      private string A2031UsuSerie ;
      private string A2032UsuSerie1 ;
      private string A2033UsuSerie2 ;
      private string A2034UsuSerie3 ;
      private string A2035UsuSerie4 ;
      private string A2036UsuSerie5 ;
      private string A2037UsuSOrden ;
      private string A2038UsuSRet ;
      private string AV32Pgmname ;
      private string Combo_usutiecod_Objectcall ;
      private string Combo_usutiecod_Class ;
      private string Combo_usutiecod_Icontype ;
      private string Combo_usutiecod_Icon ;
      private string Combo_usutiecod_Tooltip ;
      private string Combo_usutiecod_Selectedvalue_set ;
      private string Combo_usutiecod_Selectedtext_set ;
      private string Combo_usutiecod_Selectedtext_get ;
      private string Combo_usutiecod_Gamoauthtoken ;
      private string Combo_usutiecod_Ddointernalname ;
      private string Combo_usutiecod_Titlecontrolalign ;
      private string Combo_usutiecod_Dropdownoptionstype ;
      private string Combo_usutiecod_Titlecontrolidtoreplace ;
      private string Combo_usutiecod_Datalisttype ;
      private string Combo_usutiecod_Datalistfixedvalues ;
      private string Combo_usutiecod_Htmltemplate ;
      private string Combo_usutiecod_Multiplevaluestype ;
      private string Combo_usutiecod_Loadingdata ;
      private string Combo_usutiecod_Noresultsfound ;
      private string Combo_usutiecod_Emptyitemtext ;
      private string Combo_usutiecod_Onlyselectedvalues ;
      private string Combo_usutiecod_Selectalltext ;
      private string Combo_usutiecod_Multiplevaluesseparator ;
      private string Combo_usutiecod_Addnewoptiontext ;
      private string Combo_arecod_Objectcall ;
      private string Combo_arecod_Class ;
      private string Combo_arecod_Icontype ;
      private string Combo_arecod_Icon ;
      private string Combo_arecod_Tooltip ;
      private string Combo_arecod_Selectedvalue_set ;
      private string Combo_arecod_Selectedtext_set ;
      private string Combo_arecod_Selectedtext_get ;
      private string Combo_arecod_Gamoauthtoken ;
      private string Combo_arecod_Ddointernalname ;
      private string Combo_arecod_Titlecontrolalign ;
      private string Combo_arecod_Dropdownoptionstype ;
      private string Combo_arecod_Titlecontrolidtoreplace ;
      private string Combo_arecod_Datalisttype ;
      private string Combo_arecod_Datalistfixedvalues ;
      private string Combo_arecod_Htmltemplate ;
      private string Combo_arecod_Multiplevaluestype ;
      private string Combo_arecod_Loadingdata ;
      private string Combo_arecod_Noresultsfound ;
      private string Combo_arecod_Emptyitemtext ;
      private string Combo_arecod_Onlyselectedvalues ;
      private string Combo_arecod_Selectalltext ;
      private string Combo_arecod_Multiplevaluesseparator ;
      private string Combo_arecod_Addnewoptiontext ;
      private string Combo_usuvend_Objectcall ;
      private string Combo_usuvend_Class ;
      private string Combo_usuvend_Icontype ;
      private string Combo_usuvend_Icon ;
      private string Combo_usuvend_Tooltip ;
      private string Combo_usuvend_Selectedvalue_set ;
      private string Combo_usuvend_Selectedtext_set ;
      private string Combo_usuvend_Selectedtext_get ;
      private string Combo_usuvend_Gamoauthtoken ;
      private string Combo_usuvend_Ddointernalname ;
      private string Combo_usuvend_Titlecontrolalign ;
      private string Combo_usuvend_Dropdownoptionstype ;
      private string Combo_usuvend_Titlecontrolidtoreplace ;
      private string Combo_usuvend_Datalisttype ;
      private string Combo_usuvend_Datalistfixedvalues ;
      private string Combo_usuvend_Htmltemplate ;
      private string Combo_usuvend_Multiplevaluestype ;
      private string Combo_usuvend_Loadingdata ;
      private string Combo_usuvend_Noresultsfound ;
      private string Combo_usuvend_Emptyitemtext ;
      private string Combo_usuvend_Onlyselectedvalues ;
      private string Combo_usuvend_Selectalltext ;
      private string Combo_usuvend_Multiplevaluesseparator ;
      private string Combo_usuvend_Addnewoptiontext ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string hsh ;
      private string sMode32 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z2097UsuVendDsc ;
      private string Z2096UsuTieDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n69AreCod ;
      private bool wbErr ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool Combo_usutiecod_Emptyitem ;
      private bool Combo_usuvend_Emptyitem ;
      private bool Combo_usutiecod_Enabled ;
      private bool Combo_usutiecod_Visible ;
      private bool Combo_usutiecod_Allowmultipleselection ;
      private bool Combo_usutiecod_Isgriditem ;
      private bool Combo_usutiecod_Hasdescription ;
      private bool Combo_usutiecod_Includeonlyselectedoption ;
      private bool Combo_usutiecod_Includeselectalloption ;
      private bool Combo_usutiecod_Includeaddnewoption ;
      private bool Combo_arecod_Enabled ;
      private bool Combo_arecod_Visible ;
      private bool Combo_arecod_Allowmultipleselection ;
      private bool Combo_arecod_Isgriditem ;
      private bool Combo_arecod_Hasdescription ;
      private bool Combo_arecod_Includeonlyselectedoption ;
      private bool Combo_arecod_Includeselectalloption ;
      private bool Combo_arecod_Emptyitem ;
      private bool Combo_arecod_Includeaddnewoption ;
      private bool Combo_usuvend_Enabled ;
      private bool Combo_usuvend_Visible ;
      private bool Combo_usuvend_Allowmultipleselection ;
      private bool Combo_usuvend_Isgriditem ;
      private bool Combo_usuvend_Hasdescription ;
      private bool Combo_usuvend_Includeonlyselectedoption ;
      private bool Combo_usuvend_Includeselectalloption ;
      private bool Combo_usuvend_Includeaddnewoption ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool returnInSub ;
      private bool bDynCreated_Wcusuariosseries ;
      private bool bDynCreated_Wcusuariosalmacen ;
      private bool bDynCreated_Wcusuariosopciones ;
      private bool Gx_longc ;
      private string AV16Combo_DataJson ;
      private string Z2014UsuEMAIL ;
      private string Z2013UsuDep ;
      private string A2014UsuEMAIL ;
      private string A2013UsuDep ;
      private string AV14ComboSelectedValue ;
      private string AV15ComboSelectedText ;
      private IGxSession AV9WebSession ;
      private GXWebComponent WebComp_Wcusuariosopciones ;
      private GXWebComponent WebComp_Wcusuariosalmacen ;
      private GXWebComponent WebComp_Wcusuariosseries ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucCombo_usutiecod ;
      private GXUserControl ucCombo_arecod ;
      private GXUserControl ucCombo_usuvend ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuAutPago ;
      private GXCheckbox chkUsuAut1 ;
      private GXCheckbox chkUsuAut2 ;
      private GXCheckbox chkUsuAutOcom ;
      private GXCheckbox chkUsuReqADM ;
      private GXCheckbox chkUsuOcMail ;
      private GXCheckbox chkUsuPedMail ;
      private GXCombobox cmbUsuSts ;
      private IDataStoreProvider pr_default ;
      private string[] T005F6_A2096UsuTieDsc ;
      private string[] T005F5_A2097UsuVendDsc ;
      private string[] T005F7_A348UsuCod ;
      private string[] T005F7_A2021UsuPas ;
      private string[] T005F7_A2019UsuNom ;
      private string[] T005F7_A2031UsuSerie ;
      private short[] T005F7_A2011UsuAutOcom ;
      private short[] T005F7_A2012UsuAutPago ;
      private short[] T005F7_A2039UsuSts ;
      private string[] T005F7_A2032UsuSerie1 ;
      private string[] T005F7_A2033UsuSerie2 ;
      private string[] T005F7_A2034UsuSerie3 ;
      private string[] T005F7_A2035UsuSerie4 ;
      private string[] T005F7_A2097UsuVendDsc ;
      private string[] T005F7_A2036UsuSerie5 ;
      private short[] T005F7_A2030UsuReqADM ;
      private string[] T005F7_A2096UsuTieDsc ;
      private short[] T005F7_A2009UsuAut1 ;
      private short[] T005F7_A2010UsuAut2 ;
      private short[] T005F7_A2020UsuOcMail ;
      private string[] T005F7_A2014UsuEMAIL ;
      private short[] T005F7_A2025UsuPedMail ;
      private string[] T005F7_A2037UsuSOrden ;
      private string[] T005F7_A2038UsuSRet ;
      private string[] T005F7_A2013UsuDep ;
      private int[] T005F7_A69AreCod ;
      private bool[] T005F7_n69AreCod ;
      private int[] T005F7_A2041UsuVend ;
      private int[] T005F7_A2040UsuTieCod ;
      private int[] T005F4_A69AreCod ;
      private bool[] T005F4_n69AreCod ;
      private string[] T005F8_A2097UsuVendDsc ;
      private string[] T005F9_A2096UsuTieDsc ;
      private int[] T005F10_A69AreCod ;
      private bool[] T005F10_n69AreCod ;
      private string[] T005F11_A348UsuCod ;
      private string[] T005F3_A348UsuCod ;
      private string[] T005F3_A2021UsuPas ;
      private string[] T005F3_A2019UsuNom ;
      private string[] T005F3_A2031UsuSerie ;
      private short[] T005F3_A2011UsuAutOcom ;
      private short[] T005F3_A2012UsuAutPago ;
      private short[] T005F3_A2039UsuSts ;
      private string[] T005F3_A2032UsuSerie1 ;
      private string[] T005F3_A2033UsuSerie2 ;
      private string[] T005F3_A2034UsuSerie3 ;
      private string[] T005F3_A2035UsuSerie4 ;
      private string[] T005F3_A2036UsuSerie5 ;
      private short[] T005F3_A2030UsuReqADM ;
      private short[] T005F3_A2009UsuAut1 ;
      private short[] T005F3_A2010UsuAut2 ;
      private short[] T005F3_A2020UsuOcMail ;
      private string[] T005F3_A2014UsuEMAIL ;
      private short[] T005F3_A2025UsuPedMail ;
      private string[] T005F3_A2037UsuSOrden ;
      private string[] T005F3_A2038UsuSRet ;
      private string[] T005F3_A2013UsuDep ;
      private int[] T005F3_A69AreCod ;
      private bool[] T005F3_n69AreCod ;
      private int[] T005F3_A2041UsuVend ;
      private int[] T005F3_A2040UsuTieCod ;
      private string[] T005F12_A348UsuCod ;
      private string[] T005F13_A348UsuCod ;
      private string[] T005F2_A348UsuCod ;
      private string[] T005F2_A2021UsuPas ;
      private string[] T005F2_A2019UsuNom ;
      private string[] T005F2_A2031UsuSerie ;
      private short[] T005F2_A2011UsuAutOcom ;
      private short[] T005F2_A2012UsuAutPago ;
      private short[] T005F2_A2039UsuSts ;
      private string[] T005F2_A2032UsuSerie1 ;
      private string[] T005F2_A2033UsuSerie2 ;
      private string[] T005F2_A2034UsuSerie3 ;
      private string[] T005F2_A2035UsuSerie4 ;
      private string[] T005F2_A2036UsuSerie5 ;
      private short[] T005F2_A2030UsuReqADM ;
      private short[] T005F2_A2009UsuAut1 ;
      private short[] T005F2_A2010UsuAut2 ;
      private short[] T005F2_A2020UsuOcMail ;
      private string[] T005F2_A2014UsuEMAIL ;
      private short[] T005F2_A2025UsuPedMail ;
      private string[] T005F2_A2037UsuSOrden ;
      private string[] T005F2_A2038UsuSRet ;
      private string[] T005F2_A2013UsuDep ;
      private int[] T005F2_A69AreCod ;
      private bool[] T005F2_n69AreCod ;
      private int[] T005F2_A2041UsuVend ;
      private int[] T005F2_A2040UsuTieCod ;
      private string[] T005F17_A2097UsuVendDsc ;
      private string[] T005F18_A2096UsuTieDsc ;
      private long[] T005F19_A2237SGNotificacionID ;
      private short[] T005F19_A2245SGNotificacionDetID ;
      private long[] T005F20_A2237SGNotificacionID ;
      private string[] T005F21_A348UsuCod ;
      private string[] T005F21_A149TipCod ;
      private string[] T005F21_A351UsuSerDet ;
      private string[] T005F22_A348UsuCod ;
      private int[] T005F22_A346ObjCod ;
      private string[] T005F23_A348UsuCod ;
      private string[] T005F23_A342SGMenuPrograma ;
      private string[] T005F23_A343SGMenuNiv1ID ;
      private string[] T005F24_A348UsuCod ;
      private int[] T005F24_A349UsuAlmCod ;
      private string[] T005F25_A348UsuCod ;
      private int[] T005F26_A69AreCod ;
      private bool[] T005F26_n69AreCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24UsuTieCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV12AreCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV28UsuVend_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class usuarios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuarios__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005F7;
        prmT005F7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F5;
        prmT005F5 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        Object[] prmT005F6;
        prmT005F6 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT005F4;
        prmT005F4 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005F8;
        prmT005F8 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        Object[] prmT005F9;
        prmT005F9 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT005F10;
        prmT005F10 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005F11;
        prmT005F11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F3;
        prmT005F3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F12;
        prmT005F12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F13;
        prmT005F13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F2;
        prmT005F2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F14;
        prmT005F14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuPas",GXType.NChar,10,0) ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuSerie",GXType.NChar,4,0) ,
        new ParDef("@UsuAutOcom",GXType.Int16,1,0) ,
        new ParDef("@UsuAutPago",GXType.Int16,1,0) ,
        new ParDef("@UsuSts",GXType.Int16,1,0) ,
        new ParDef("@UsuSerie1",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie2",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie3",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie4",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie5",GXType.NChar,4,0) ,
        new ParDef("@UsuReqADM",GXType.Int16,1,0) ,
        new ParDef("@UsuAut1",GXType.Int16,1,0) ,
        new ParDef("@UsuAut2",GXType.Int16,1,0) ,
        new ParDef("@UsuOcMail",GXType.Int16,1,0) ,
        new ParDef("@UsuEMAIL",GXType.NVarChar,100,0) ,
        new ParDef("@UsuPedMail",GXType.Int16,1,0) ,
        new ParDef("@UsuSOrden",GXType.NChar,3,0) ,
        new ParDef("@UsuSRet",GXType.NChar,4,0) ,
        new ParDef("@UsuDep",GXType.NVarChar,100,0) ,
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuVend",GXType.Int32,6,0) ,
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT005F15;
        prmT005F15 = new Object[] {
        new ParDef("@UsuPas",GXType.NChar,10,0) ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuSerie",GXType.NChar,4,0) ,
        new ParDef("@UsuAutOcom",GXType.Int16,1,0) ,
        new ParDef("@UsuAutPago",GXType.Int16,1,0) ,
        new ParDef("@UsuSts",GXType.Int16,1,0) ,
        new ParDef("@UsuSerie1",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie2",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie3",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie4",GXType.NChar,4,0) ,
        new ParDef("@UsuSerie5",GXType.NChar,4,0) ,
        new ParDef("@UsuReqADM",GXType.Int16,1,0) ,
        new ParDef("@UsuAut1",GXType.Int16,1,0) ,
        new ParDef("@UsuAut2",GXType.Int16,1,0) ,
        new ParDef("@UsuOcMail",GXType.Int16,1,0) ,
        new ParDef("@UsuEMAIL",GXType.NVarChar,100,0) ,
        new ParDef("@UsuPedMail",GXType.Int16,1,0) ,
        new ParDef("@UsuSOrden",GXType.NChar,3,0) ,
        new ParDef("@UsuSRet",GXType.NChar,4,0) ,
        new ParDef("@UsuDep",GXType.NVarChar,100,0) ,
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuVend",GXType.Int32,6,0) ,
        new ParDef("@UsuTieCod",GXType.Int32,6,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F16;
        prmT005F16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F19;
        prmT005F19 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F20;
        prmT005F20 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F21;
        prmT005F21 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F22;
        prmT005F22 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F23;
        prmT005F23 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F24;
        prmT005F24 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT005F25;
        prmT005F25 = new Object[] {
        };
        Object[] prmT005F18;
        prmT005F18 = new Object[] {
        new ParDef("@UsuTieCod",GXType.Int32,6,0)
        };
        Object[] prmT005F26;
        prmT005F26 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005F17;
        prmT005F17 = new Object[] {
        new ParDef("@UsuVend",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005F2", "SELECT [UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [AreCod], [UsuVend] AS UsuVend, [UsuTieCod] AS UsuTieCod FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F3", "SELECT [UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [AreCod], [UsuVend] AS UsuVend, [UsuTieCod] AS UsuTieCod FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F4", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F5", "SELECT [VenDsc] AS UsuVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F6", "SELECT [TieDsc] AS UsuTieDsc FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F7", "SELECT TM1.[UsuCod], TM1.[UsuPas], TM1.[UsuNom], TM1.[UsuSerie], TM1.[UsuAutOcom], TM1.[UsuAutPago], TM1.[UsuSts], TM1.[UsuSerie1], TM1.[UsuSerie2], TM1.[UsuSerie3], TM1.[UsuSerie4], T2.[VenDsc] AS UsuVendDsc, TM1.[UsuSerie5], TM1.[UsuReqADM], T3.[TieDsc] AS UsuTieDsc, TM1.[UsuAut1], TM1.[UsuAut2], TM1.[UsuOcMail], TM1.[UsuEMAIL], TM1.[UsuPedMail], TM1.[UsuSOrden], TM1.[UsuSRet], TM1.[UsuDep], TM1.[AreCod], TM1.[UsuVend] AS UsuVend, TM1.[UsuTieCod] AS UsuTieCod FROM (([SGUSUARIOS] TM1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = TM1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = TM1.[UsuTieCod]) WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005F7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F8", "SELECT [VenDsc] AS UsuVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F9", "SELECT [TieDsc] AS UsuTieDsc FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F10", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F11", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005F11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F12", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005F12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F13", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005F13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F14", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuPas], [UsuNom], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuSerie5], [UsuReqADM], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [UsuSRet], [UsuDep], [AreCod], [UsuVend], [UsuTieCod], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto], [UsuVendAut]) VALUES(@UsuCod, @UsuPas, @UsuNom, @UsuSerie, @UsuAutOcom, @UsuAutPago, @UsuSts, @UsuSerie1, @UsuSerie2, @UsuSerie3, @UsuSerie4, @UsuSerie5, @UsuReqADM, @UsuAut1, @UsuAut2, @UsuOcMail, @UsuEMAIL, @UsuPedMail, @UsuSOrden, @UsuSRet, @UsuDep, @AreCod, @UsuVend, @UsuTieCod, convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0))", GxErrorMask.GX_NOMASK,prmT005F14)
           ,new CursorDef("T005F15", "UPDATE [SGUSUARIOS] SET [UsuPas]=@UsuPas, [UsuNom]=@UsuNom, [UsuSerie]=@UsuSerie, [UsuAutOcom]=@UsuAutOcom, [UsuAutPago]=@UsuAutPago, [UsuSts]=@UsuSts, [UsuSerie1]=@UsuSerie1, [UsuSerie2]=@UsuSerie2, [UsuSerie3]=@UsuSerie3, [UsuSerie4]=@UsuSerie4, [UsuSerie5]=@UsuSerie5, [UsuReqADM]=@UsuReqADM, [UsuAut1]=@UsuAut1, [UsuAut2]=@UsuAut2, [UsuOcMail]=@UsuOcMail, [UsuEMAIL]=@UsuEMAIL, [UsuPedMail]=@UsuPedMail, [UsuSOrden]=@UsuSOrden, [UsuSRet]=@UsuSRet, [UsuDep]=@UsuDep, [AreCod]=@AreCod, [UsuVend]=@UsuVend, [UsuTieCod]=@UsuTieCod  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT005F15)
           ,new CursorDef("T005F16", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT005F16)
           ,new CursorDef("T005F17", "SELECT [VenDsc] AS UsuVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @UsuVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F18", "SELECT [TieDsc] AS UsuTieDsc FROM [SGTIENDAS] WHERE [TieCod] = @UsuTieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F19", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F20", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F21", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F22", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F23", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F24", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005F25", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005F25,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005F26", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005F26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 4);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 4);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 4);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 4);
              ((string[]) buf[9])[0] = rslt.getString(10, 4);
              ((string[]) buf[10])[0] = rslt.getString(11, 4);
              ((string[]) buf[11])[0] = rslt.getString(12, 100);
              ((string[]) buf[12])[0] = rslt.getString(13, 4);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((short[]) buf[16])[0] = rslt.getShort(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((short[]) buf[19])[0] = rslt.getShort(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((string[]) buf[21])[0] = rslt.getString(22, 4);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((int[]) buf[23])[0] = rslt.getInt(24);
              ((bool[]) buf[24])[0] = rslt.wasNull(24);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              ((int[]) buf[26])[0] = rslt.getInt(26);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
