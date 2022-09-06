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
   public class cambiodocumentocompras : GXDataArea
   {
      public cambiodocumentocompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cambiodocumentocompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PreviousStep ,
                           string aP1_CurrentStep ,
                           bool aP2_GoingBack )
      {
         this.AV8PreviousStep = aP0_PreviousStep;
         this.AV9CurrentStep = aP1_CurrentStep;
         this.AV7GoingBack = aP2_GoingBack;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "PreviousStep");
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
               gxfirstwebparm = GetFirstPar( "PreviousStep");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PreviousStep");
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0A2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810272547", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.cambiodocumentocompras.aspx"+UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV9CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.cambiodocumentocompras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV11WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV11WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV10CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         GxWebStd.gx_hidden_field( context, "vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEP", AV9CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Steptitles == null ) )
         {
            WebComp_Steptitles.componentjscripts();
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            WebComp_Wizardstepwc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0A2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.cambiodocumentocompras.aspx"+UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.RTrim(AV9CurrentStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
         return formatLink("seguridad.cambiodocumentocompras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.CambioDocumentoCompras" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cambio de Documento de Compras" ;
      }

      protected void WB0A0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_6_0A2( true) ;
         }
         else
         {
            wb_table1_6_0A2( false) ;
         }
         return  ;
      }

      protected void wb_table1_6_0A2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0A2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Cambio de Documento de Compras", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0A0( ) ;
      }

      protected void WS0A2( )
      {
         START0A2( ) ;
         EVT0A2( ) ;
      }

      protected void EVT0A2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E120A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130A2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
                        if ( nCmpId == 9 )
                        {
                           OldSteptitles = cgiGet( "W0009");
                           if ( ( StringUtil.Len( OldSteptitles) == 0 ) || ( StringUtil.StrCmp(OldSteptitles, WebComp_Steptitles_Component) != 0 ) )
                           {
                              WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", OldSteptitles, new Object[] {context} );
                              WebComp_Steptitles.ComponentInit();
                              WebComp_Steptitles.Name = "OldSteptitles";
                              WebComp_Steptitles_Component = OldSteptitles;
                           }
                           if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
                           {
                              WebComp_Steptitles.componentprocess("W0009", "", sEvt);
                           }
                           WebComp_Steptitles_Component = OldSteptitles;
                        }
                        else if ( nCmpId == 15 )
                        {
                           OldWizardstepwc = cgiGet( "W0015");
                           if ( ( StringUtil.Len( OldWizardstepwc) == 0 ) || ( StringUtil.StrCmp(OldWizardstepwc, WebComp_Wizardstepwc_Component) != 0 ) )
                           {
                              WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", OldWizardstepwc, new Object[] {context} );
                              WebComp_Wizardstepwc.ComponentInit();
                              WebComp_Wizardstepwc.Name = "OldWizardstepwc";
                              WebComp_Wizardstepwc_Component = OldWizardstepwc;
                           }
                           if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
                           {
                              WebComp_Wizardstepwc.componentprocess("W0015", "", sEvt);
                           }
                           WebComp_Wizardstepwc_Component = OldWizardstepwc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0A2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0A2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.cambiodocumentocompras.aspx")), "seguridad.cambiodocumentocompras.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.cambiodocumentocompras.aspx")))) ;
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
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "PreviousStep");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8PreviousStep = gxfirstwebparm;
                     AssignAttri("", false, "AV8PreviousStep", AV8PreviousStep);
                     GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV9CurrentStep = GetPar( "CurrentStep");
                        AssignAttri("", false, "AV9CurrentStep", AV9CurrentStep);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
                        AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                        AssignAttri("", false, "AV7GoingBack", AV7GoingBack);
                        GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0A2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV16Pgmname = "Seguridad.CambioDocumentoCompras";
         context.Gx_err = 0;
      }

      protected void RF0A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E120A2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  WebComp_Steptitles.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  WebComp_Wizardstepwc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130A2 ();
            WB0A0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0A2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWIZARDSTEPS", AV11WizardSteps);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWIZARDSTEPS", AV11WizardSteps);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWIZARDSTEPS", GetSecureSignedToken( "", AV11WizardSteps, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTSTEPAUX", AV10CurrentStepAux);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV16Pgmname = "Seguridad.CambioDocumentoCompras";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110A2 ();
         if (returnInSub) return;
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "SIGERP_ADVANCED");
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "Paso1";
         AV12WizardStep.gxTpr_Title = "Documento Origen";
         AV12WizardStep.gxTpr_Description = "Documento Origen";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "Paso2";
         AV12WizardStep.gxTpr_Title = "Documento Destino";
         AV12WizardStep.gxTpr_Description = "Documento Destino";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV12WizardStep.gxTpr_Code = "Paso3";
         AV12WizardStep.gxTpr_Title = "Procesar";
         AV12WizardStep.gxTpr_Description = "Procesar";
         AV11WizardSteps.Add(AV12WizardStep, 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9CurrentStep)) )
         {
            AV10CurrentStepAux = "Paso1";
            AssignAttri("", false, "AV10CurrentStepAux", AV10CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
            AV5WebSession.Remove(AV16Pgmname+"_Data");
         }
         else
         {
            AV10CurrentStepAux = AV9CurrentStep;
            AssignAttri("", false, "AV10CurrentStepAux", AV10CurrentStepAux);
            GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEPAUX", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10CurrentStepAux, "")), context));
         }
         /* Execute user subroutine: 'LOADWIZARDSTEPWC' */
         S112 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Steptitles = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Steptitles_Component), StringUtil.Lower( "WWPBaseObjects.WizardStepsBulletWC")) != 0 )
         {
            WebComp_Steptitles = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wizardstepsbulletwc", new Object[] {context} );
            WebComp_Steptitles.ComponentInit();
            WebComp_Steptitles.Name = "WWPBaseObjects.WizardStepsBulletWC";
            WebComp_Steptitles_Component = "WWPBaseObjects.WizardStepsBulletWC";
         }
         if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
         {
            WebComp_Steptitles.setjustcreated();
            WebComp_Steptitles.componentprepare(new Object[] {(string)"W0009",(string)"",(GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>)AV11WizardSteps,(string)AV10CurrentStepAux});
            WebComp_Steptitles.componentbind(new Object[] {(string)"",(string)""});
         }
      }

      protected void S112( )
      {
         /* 'LOADWIZARDSTEPWC' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV10CurrentStepAux, "Paso1") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "Seguridad.CambioDocumentoComprasPaso1")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.cambiodocumentocompraspaso1", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "Seguridad.CambioDocumentoComprasPaso1";
               WebComp_Wizardstepwc_Component = "Seguridad.CambioDocumentoComprasPaso1";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV16Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV10CurrentStepAux, "Paso2") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "Seguridad.CambioDocumentoComprasPaso2")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.cambiodocumentocompraspaso2", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "Seguridad.CambioDocumentoComprasPaso2";
               WebComp_Wizardstepwc_Component = "Seguridad.CambioDocumentoComprasPaso2";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV16Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(AV10CurrentStepAux, "Paso3") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wizardstepwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wizardstepwc_Component), StringUtil.Lower( "Seguridad.CambioDocumentoComprasPaso3")) != 0 )
            {
               WebComp_Wizardstepwc = getWebComponent(GetType(), "GeneXus.Programs", "seguridad.cambiodocumentocompraspaso3", new Object[] {context} );
               WebComp_Wizardstepwc.ComponentInit();
               WebComp_Wizardstepwc.Name = "Seguridad.CambioDocumentoComprasPaso3";
               WebComp_Wizardstepwc_Component = "Seguridad.CambioDocumentoComprasPaso3";
            }
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.setjustcreated();
               WebComp_Wizardstepwc.componentprepare(new Object[] {(string)"W0015",(string)"",(string)AV16Pgmname+"_Data",(string)AV8PreviousStep,(bool)AV7GoingBack});
               WebComp_Wizardstepwc.componentbind(new Object[] {(string)""+""+"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wizardstepwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
               WebComp_Wizardstepwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void E120A2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblWizardstepdescription_Caption = "";
         AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
         AV13StepNumber = 1;
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV11WizardSteps.Count )
         {
            AV12WizardStep = ((GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem)AV11WizardSteps.Item(AV17GXV1));
            if ( StringUtil.StrCmp(AV12WizardStep.gxTpr_Code, AV10CurrentStepAux) == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12WizardStep.gxTpr_Description)) )
               {
                  lblWizardstepdescription_Caption = StringUtil.Format( "Step %1/%2 :: %3", StringUtil.Trim( StringUtil.Str( (decimal)(AV13StepNumber), 2, 0)), StringUtil.Trim( StringUtil.Str( (decimal)(AV11WizardSteps.Count), 9, 0)), AV12WizardStep.gxTpr_Description, "", "", "", "", "", "");
                  AssignProp("", false, lblWizardstepdescription_Internalname, "Caption", lblWizardstepdescription_Caption, true);
               }
            }
            else
            {
               AV13StepNumber = (short)(AV13StepNumber+1);
            }
            AV17GXV1 = (int)(AV17GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E130A2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_6_0A2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemain_Internalname, tblTablemain_Internalname, "", "TableWizardMainWithShadow", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\" class='WizardStepsCell'>") ;
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0009"+"", StringUtil.RTrim( WebComp_Steptitles_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0009"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0009"+"");
                  }
                  WebComp_Steptitles.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSteptitles), StringUtil.Lower( WebComp_Steptitles_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWizardstepdescription_Internalname, lblWizardstepdescription_Caption, "", "", lblWizardstepdescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WizardStepDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\CambioDocumentoCompras.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='WizardStepsPositionCell'>") ;
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0015"+"", StringUtil.RTrim( WebComp_Wizardstepwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0015"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0015"+"");
                  }
                  WebComp_Wizardstepwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWizardstepwc), StringUtil.Lower( WebComp_Wizardstepwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_6_0A2e( true) ;
         }
         else
         {
            wb_table1_6_0A2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8PreviousStep = (string)getParm(obj,0);
         AssignAttri("", false, "AV8PreviousStep", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vPREVIOUSSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8PreviousStep, "")), context));
         AV9CurrentStep = (string)getParm(obj,1);
         AssignAttri("", false, "AV9CurrentStep", AV9CurrentStep);
         GxWebStd.gx_hidden_field( context, "gxhash_vCURRENTSTEP", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9CurrentStep, "")), context));
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri("", false, "AV7GoingBack", AV7GoingBack);
         GxWebStd.gx_hidden_field( context, "gxhash_vGOINGBACK", GetSecureSignedToken( "", AV7GoingBack, context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0A2( ) ;
         WS0A2( ) ;
         WE0A2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Steptitles == null ) )
         {
            if ( StringUtil.Len( WebComp_Steptitles_Component) != 0 )
            {
               WebComp_Steptitles.componentthemes();
            }
         }
         if ( ! ( WebComp_Wizardstepwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wizardstepwc_Component) != 0 )
            {
               WebComp_Wizardstepwc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810272572", true, true);
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
         context.AddJavascriptSource("seguridad/cambiodocumentocompras.js", "?202281810272572", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWizardstepdescription_Internalname = "WIZARDSTEPDESCRIPTION";
         tblTablemain_Internalname = "TABLEMAIN";
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
         lblWizardstepdescription_Caption = "Descripción del paso";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cambio de Documento de Compras";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11WizardSteps',fld:'vWIZARDSTEPS',pic:'',hsh:true},{av:'AV10CurrentStepAux',fld:'vCURRENTSTEPAUX',pic:'',hsh:true},{av:'AV8PreviousStep',fld:'vPREVIOUSSTEP',pic:'',hsh:true},{av:'AV9CurrentStep',fld:'vCURRENTSTEP',pic:'',hsh:true},{av:'AV7GoingBack',fld:'vGOINGBACK',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblWizardstepdescription_Caption',ctrl:'WIZARDSTEPDESCRIPTION',prop:'Caption'}]}");
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
      }

      public override void initialize( )
      {
         wcpOAV8PreviousStep = "";
         wcpOAV9CurrentStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV11WizardSteps = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem>( context, "WizardStepsItem", "SIGERP_ADVANCED");
         AV10CurrentStepAux = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         OldSteptitles = "";
         WebComp_Steptitles_Component = "";
         OldWizardstepwc = "";
         WebComp_Wizardstepwc_Component = "";
         GXDecQS = "";
         AV16Pgmname = "";
         AV12WizardStep = new GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem(context);
         AV5WebSession = context.GetSession();
         sStyleString = "";
         lblWizardstepdescription_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Steptitles = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wizardstepwc = new GeneXus.Http.GXNullWebComponent();
         AV16Pgmname = "Seguridad.CambioDocumentoCompras";
         /* GeneXus formulas. */
         AV16Pgmname = "Seguridad.CambioDocumentoCompras";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV13StepNumber ;
      private short nGXWrapped ;
      private int AV17GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string OldSteptitles ;
      private string WebComp_Steptitles_Component ;
      private string OldWizardstepwc ;
      private string WebComp_Wizardstepwc_Component ;
      private string GXDecQS ;
      private string AV16Pgmname ;
      private string lblWizardstepdescription_Caption ;
      private string lblWizardstepdescription_Internalname ;
      private string sStyleString ;
      private string tblTablemain_Internalname ;
      private string lblWizardstepdescription_Jsonclick ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Steptitles ;
      private bool bDynCreated_Wizardstepwc ;
      private string AV8PreviousStep ;
      private string AV9CurrentStep ;
      private string wcpOAV8PreviousStep ;
      private string wcpOAV9CurrentStep ;
      private string AV10CurrentStepAux ;
      private GXWebComponent WebComp_Steptitles ;
      private GXWebComponent WebComp_Wizardstepwc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV5WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem> AV11WizardSteps ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWizardSteps_WizardStepsItem AV12WizardStep ;
   }

}
