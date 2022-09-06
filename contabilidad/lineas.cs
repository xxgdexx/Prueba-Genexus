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
namespace GeneXus.Programs.contabilidad {
   public class lineas : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A114TotTipo = GetPar( "TotTipo");
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A114TotTipo, A115TotRub, A116RubCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A91CueCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_level1") == 0 )
         {
            nRC_GXsfl_63 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."));
            nGXsfl_63_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."));
            sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridlevel_level1_newrow( ) ;
            return  ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.lineas.aspx")), "contabilidad.lineas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.lineas.aspx")))) ;
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
                  AV7TotTipo = GetPar( "TotTipo");
                  AssignAttri("", false, "AV7TotTipo", AV7TotTipo);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7TotTipo, "")), context));
                  AV8TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
                  AssignAttri("", false, "AV8TotRub", StringUtil.LTrimStr( (decimal)(AV8TotRub), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TotRub), "ZZZZZ9"), context));
                  AV9RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
                  AssignAttri("", false, "AV9RubCod", StringUtil.LTrimStr( (decimal)(AV9RubCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRUBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9RubCod), "ZZZZZ9"), context));
                  AV10RubLinCod = (int)(NumberUtil.Val( GetPar( "RubLinCod"), "."));
                  AssignAttri("", false, "AV10RubLinCod", StringUtil.LTrimStr( (decimal)(AV10RubLinCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRUBLINCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10RubLinCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Lineas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public lineas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_TotTipo ,
                           int aP2_TotRub ,
                           int aP3_RubCod ,
                           int aP4_RubLinCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TotTipo = aP1_TotTipo;
         this.AV8TotRub = aP2_TotRub;
         this.AV9RubCod = aP3_RubCod;
         this.AV10RubLinCod = aP4_RubLinCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbRubLinSts = new GXCombobox();
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
         if ( cmbRubLinSts.ItemCount > 0 )
         {
            A1828RubLinSts = (short)(NumberUtil.Val( cmbRubLinSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0))), "."));
            AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRubLinSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
            AssignProp("", false, cmbRubLinSts_Internalname, "Values", cmbRubLinSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotTipo_Internalname, "Tipo de Reporte", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTotRub_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTotRub_Internalname, "Codigo Rubro Totales", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotRub_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotRub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotRub_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubCod_Internalname, "Codigo Rubro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubLinCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubLinCod_Internalname, "Codigo Linea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118RubLinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLinCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubLinDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubLinDsc_Internalname, "Linea", "col-sm-3 AttributeRealWidth100WithLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLinDsc_Internalname, StringUtil.RTrim( A1826RubLinDsc), StringUtil.RTrim( context.localUtil.Format( A1826RubLinDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLinDsc_Jsonclick, 0, "AttributeRealWidth100With", "", "", "", "", 1, edtRubLinDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubLinDscTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubLinDscTot_Internalname, "Totales Linea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLinDscTot_Internalname, StringUtil.RTrim( A1827RubLinDscTot), StringUtil.RTrim( context.localUtil.Format( A1827RubLinDscTot, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLinDscTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLinDscTot_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRubLinOrd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubLinOrd_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLinOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A119RubLinOrd), 2, 0, ".", "")), StringUtil.LTrim( ((edtRubLinOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A119RubLinOrd), "Z9") : context.localUtil.Format( (decimal)(A119RubLinOrd), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLinOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLinOrd_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbRubLinSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRubLinSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRubLinSts, cmbRubLinSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0)), 1, cmbRubLinSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbRubLinSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 1, "HLP_Contabilidad\\Lineas.htm");
         cmbRubLinSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
         AssignProp("", false, cmbRubLinSts_Internalname, "Values", (string)(cmbRubLinSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_level1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "left", "top", "", "", "div");
         gxdraw_Gridlevel_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Lineas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridlevel_level1( )
      {
         /*  Grid Control  */
         Gridlevel_level1Container.AddObjectProperty("GridName", "Gridlevel_level1");
         Gridlevel_level1Container.AddObjectProperty("Header", subGridlevel_level1_Header);
         Gridlevel_level1Container.AddObjectProperty("Class", "WorkWith");
         Gridlevel_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("CmpContext", "");
         Gridlevel_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A91CueCod));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A860CueDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDPos_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDNeg_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowselection), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount67 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_67 = 1;
               ScanStart7667( ) ;
               while ( RcdFound67 != 0 )
               {
                  init_level_properties67( ) ;
                  getByPrimaryKey7667( ) ;
                  AddRow7667( ) ;
                  ScanNext7667( ) ;
               }
               ScanEnd7667( ) ;
               nBlankRcdCount67 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7667( ) ;
            standaloneModal7667( ) ;
            sMode67 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow7667( ) ;
               edtCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUECOD_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUEDSC_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtRubLDPos_Enabled = (int)(context.localUtil.CToN( cgiGet( "RUBLDPOS_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtRubLDPos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDPos_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtRubLDNeg_Enabled = (int)(context.localUtil.CToN( cgiGet( "RUBLDNEG_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtRubLDNeg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDNeg_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_91_Link = cgiGet( "PROMPT_91_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_67 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7667( ) ;
               }
               SendRow7667( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount67 = 5;
            nRcdExists_67 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7667( ) ;
               while ( RcdFound67 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6367( ) ;
                  init_level_properties67( ) ;
                  standaloneNotModal7667( ) ;
                  getByPrimaryKey7667( ) ;
                  standaloneModal7667( ) ;
                  AddRow7667( ) ;
                  ScanNext7667( ) ;
               }
               ScanEnd7667( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode67 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6367( ) ;
            InitAll7667( ) ;
            init_level_properties67( ) ;
            nRcdExists_67 = 0;
            nIsMod_67 = 0;
            nRcdDeleted_67 = 0;
            nBlankRcdCount67 = (short)(nBlankRcdUsr67+nBlankRcdCount67);
            fRowAdded = 0;
            while ( nBlankRcdCount67 > 0 )
            {
               standaloneNotModal7667( ) ;
               standaloneModal7667( ) ;
               AddRow7667( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount67 = (short)(nBlankRcdCount67-1);
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_level1", Gridlevel_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level1ContainerData", Gridlevel_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level1ContainerData"+"V", Gridlevel_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_level1ContainerData"+"V"+"\" value='"+Gridlevel_level1Container.GridValuesHidden()+"'/>") ;
         }
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11762 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z114TotTipo = cgiGet( "Z114TotTipo");
               Z115TotRub = (int)(context.localUtil.CToN( cgiGet( "Z115TotRub"), ".", ","));
               Z116RubCod = (int)(context.localUtil.CToN( cgiGet( "Z116RubCod"), ".", ","));
               Z118RubLinCod = (int)(context.localUtil.CToN( cgiGet( "Z118RubLinCod"), ".", ","));
               Z1826RubLinDsc = cgiGet( "Z1826RubLinDsc");
               Z1827RubLinDscTot = cgiGet( "Z1827RubLinDscTot");
               Z119RubLinOrd = (short)(context.localUtil.CToN( cgiGet( "Z119RubLinOrd"), ".", ","));
               Z1828RubLinSts = (short)(context.localUtil.CToN( cgiGet( "Z1828RubLinSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ".", ","));
               AV7TotTipo = cgiGet( "vTOTTIPO");
               AV8TotRub = (int)(context.localUtil.CToN( cgiGet( "vTOTRUB"), ".", ","));
               AV9RubCod = (int)(context.localUtil.CToN( cgiGet( "vRUBCOD"), ".", ","));
               AV10RubLinCod = (int)(context.localUtil.CToN( cgiGet( "vRUBLINCOD"), ".", ","));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A114TotTipo = cgiGet( edtTotTipo_Internalname);
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTRUB");
                  AnyError = 1;
                  GX_FocusControl = edtTotRub_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A115TotRub = 0;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               }
               else
               {
                  A115TotRub = (int)(context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ","));
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtRubCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A116RubCod = 0;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               }
               else
               {
                  A116RubCod = (int)(context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ","));
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBLINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtRubLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A118RubLinCod = 0;
                  AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               }
               else
               {
                  A118RubLinCod = (int)(context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ","));
                  AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               }
               A1826RubLinDsc = cgiGet( edtRubLinDsc_Internalname);
               AssignAttri("", false, "A1826RubLinDsc", A1826RubLinDsc);
               A1827RubLinDscTot = cgiGet( edtRubLinDscTot_Internalname);
               AssignAttri("", false, "A1827RubLinDscTot", A1827RubLinDscTot);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubLinOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLinOrd_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBLINORD");
                  AnyError = 1;
                  GX_FocusControl = edtRubLinOrd_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A119RubLinOrd = 0;
                  AssignAttri("", false, "A119RubLinOrd", StringUtil.LTrimStr( (decimal)(A119RubLinOrd), 2, 0));
               }
               else
               {
                  A119RubLinOrd = (short)(context.localUtil.CToN( cgiGet( edtRubLinOrd_Internalname), ".", ","));
                  AssignAttri("", false, "A119RubLinOrd", StringUtil.LTrimStr( (decimal)(A119RubLinOrd), 2, 0));
               }
               cmbRubLinSts.Name = cmbRubLinSts_Internalname;
               cmbRubLinSts.CurrentValue = cgiGet( cmbRubLinSts_Internalname);
               A1828RubLinSts = (short)(NumberUtil.Val( cgiGet( cmbRubLinSts_Internalname), "."));
               AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Lineas");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\lineas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A114TotTipo = GetPar( "TotTipo");
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  A116RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
                  A118RubLinCod = (int)(NumberUtil.Val( GetPar( "RubLinCod"), "."));
                  AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
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
                     sMode66 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode66;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound66 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_760( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TOTTIPO");
                        AnyError = 1;
                        GX_FocusControl = edtTotTipo_Internalname;
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
                           E11762 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12762 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12762 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7666( ) ;
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
            DisableAttributes7666( ) ;
         }
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

      protected void CONFIRM_760( )
      {
         BeforeValidate7666( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7666( ) ;
            }
            else
            {
               CheckExtendedTable7666( ) ;
               CloseExtendedTableCursors7666( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode66 = Gx_mode;
            CONFIRM_7667( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode66;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_7667( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow7667( ) ;
            if ( ( nRcdExists_67 != 0 ) || ( nIsMod_67 != 0 ) )
            {
               GetKey7667( ) ;
               if ( ( nRcdExists_67 == 0 ) && ( nRcdDeleted_67 == 0 ) )
               {
                  if ( RcdFound67 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7667( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7667( ) ;
                        CloseExtendedTableCursors7667( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CUECOD_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound67 != 0 )
                  {
                     if ( nRcdDeleted_67 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7667( ) ;
                        Load7667( ) ;
                        BeforeValidate7667( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7667( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_67 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7667( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7667( ) ;
                              CloseExtendedTableCursors7667( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_67 == 0 )
                     {
                        GXCCtl = "CUECOD_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCueCod_Internalname, StringUtil.RTrim( A91CueCod)) ;
            ChangePostValue( edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc)) ;
            ChangePostValue( edtRubLDPos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", ""))) ;
            ChangePostValue( edtRubLDNeg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_63_idx, StringUtil.RTrim( Z91CueCod)) ;
            ChangePostValue( "ZT_"+"Z1825RubLDPos_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1825RubLDPos), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1824RubLDNeg_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1824RubLDNeg), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, ".", ""))) ;
            if ( nIsMod_67 != 0 )
            {
               ChangePostValue( "CUECOD_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUEDSC_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBLDPOS_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDPos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBLDNEG_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDNeg_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption760( )
      {
      }

      protected void E11762( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV11WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12762( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.lineasww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7666( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1826RubLinDsc = T00766_A1826RubLinDsc[0];
               Z1827RubLinDscTot = T00766_A1827RubLinDscTot[0];
               Z119RubLinOrd = T00766_A119RubLinOrd[0];
               Z1828RubLinSts = T00766_A1828RubLinSts[0];
            }
            else
            {
               Z1826RubLinDsc = A1826RubLinDsc;
               Z1827RubLinDscTot = A1827RubLinDscTot;
               Z119RubLinOrd = A119RubLinOrd;
               Z1828RubLinSts = A1828RubLinSts;
            }
         }
         if ( GX_JID == -13 )
         {
            Z118RubLinCod = A118RubLinCod;
            Z1826RubLinDsc = A1826RubLinDsc;
            Z1827RubLinDscTot = A1827RubLinDscTot;
            Z119RubLinOrd = A119RubLinOrd;
            Z1828RubLinSts = A1828RubLinSts;
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TotTipo)) )
         {
            A114TotTipo = AV7TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TotTipo)) )
         {
            edtTotTipo_Enabled = 0;
            AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtTotTipo_Enabled = 1;
            AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TotTipo)) )
         {
            edtTotTipo_Enabled = 0;
            AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8TotRub) )
         {
            A115TotRub = AV8TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
         if ( ! (0==AV8TotRub) )
         {
            edtTotRub_Enabled = 0;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         }
         else
         {
            edtTotRub_Enabled = 1;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8TotRub) )
         {
            edtTotRub_Enabled = 0;
            AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         }
         if ( ! (0==AV9RubCod) )
         {
            A116RubCod = AV9RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
         if ( ! (0==AV9RubCod) )
         {
            edtRubCod_Enabled = 0;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         }
         else
         {
            edtRubCod_Enabled = 1;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV9RubCod) )
         {
            edtRubCod_Enabled = 0;
            AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10RubLinCod) )
         {
            A118RubLinCod = AV10RubLinCod;
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
         }
         if ( ! (0==AV10RubLinCod) )
         {
            edtRubLinCod_Enabled = 0;
            AssignProp("", false, edtRubLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinCod_Enabled), 5, 0), true);
         }
         else
         {
            edtRubLinCod_Enabled = 1;
            AssignProp("", false, edtRubLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10RubLinCod) )
         {
            edtRubLinCod_Enabled = 0;
            AssignProp("", false, edtRubLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load7666( )
      {
         /* Using cursor T00768 */
         pr_default.execute(6, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound66 = 1;
            A1826RubLinDsc = T00768_A1826RubLinDsc[0];
            AssignAttri("", false, "A1826RubLinDsc", A1826RubLinDsc);
            A1827RubLinDscTot = T00768_A1827RubLinDscTot[0];
            AssignAttri("", false, "A1827RubLinDscTot", A1827RubLinDscTot);
            A119RubLinOrd = T00768_A119RubLinOrd[0];
            AssignAttri("", false, "A119RubLinOrd", StringUtil.LTrimStr( (decimal)(A119RubLinOrd), 2, 0));
            A1828RubLinSts = T00768_A1828RubLinSts[0];
            AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
            ZM7666( -13) ;
         }
         pr_default.close(6);
         OnLoadActions7666( ) ;
      }

      protected void OnLoadActions7666( )
      {
      }

      protected void CheckExtendedTable7666( )
      {
         nIsDirty_66 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00767 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros'.", "ForeignKeyNotFound", 1, "RUBCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors7666( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( string A114TotTipo ,
                                int A115TotRub ,
                                int A116RubCod )
      {
         /* Using cursor T00769 */
         pr_default.execute(7, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros'.", "ForeignKeyNotFound", 1, "RUBCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey7666( )
      {
         /* Using cursor T007610 */
         pr_default.execute(8, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound66 = 1;
         }
         else
         {
            RcdFound66 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00766 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM7666( 13) ;
            RcdFound66 = 1;
            A118RubLinCod = T00766_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            A1826RubLinDsc = T00766_A1826RubLinDsc[0];
            AssignAttri("", false, "A1826RubLinDsc", A1826RubLinDsc);
            A1827RubLinDscTot = T00766_A1827RubLinDscTot[0];
            AssignAttri("", false, "A1827RubLinDscTot", A1827RubLinDscTot);
            A119RubLinOrd = T00766_A119RubLinOrd[0];
            AssignAttri("", false, "A119RubLinOrd", StringUtil.LTrimStr( (decimal)(A119RubLinOrd), 2, 0));
            A1828RubLinSts = T00766_A1828RubLinSts[0];
            AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
            A114TotTipo = T00766_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T00766_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T00766_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            Z118RubLinCod = A118RubLinCod;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7666( ) ;
            if ( AnyError == 1 )
            {
               RcdFound66 = 0;
               InitializeNonKey7666( ) ;
            }
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound66 = 0;
            InitializeNonKey7666( ) ;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey7666( ) ;
         if ( RcdFound66 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound66 = 0;
         /* Using cursor T007611 */
         pr_default.execute(9, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A115TotRub[0] < A115TotRub ) || ( T007611_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A116RubCod[0] < A116RubCod ) || ( T007611_A116RubCod[0] == A116RubCod ) && ( T007611_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A118RubLinCod[0] < A118RubLinCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A115TotRub[0] > A115TotRub ) || ( T007611_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A116RubCod[0] > A116RubCod ) || ( T007611_A116RubCod[0] == A116RubCod ) && ( T007611_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007611_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007611_A118RubLinCod[0] > A118RubLinCod ) ) )
            {
               A114TotTipo = T007611_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T007611_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T007611_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               A118RubLinCod = T007611_A118RubLinCod[0];
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               RcdFound66 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound66 = 0;
         /* Using cursor T007612 */
         pr_default.execute(10, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A115TotRub[0] > A115TotRub ) || ( T007612_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A116RubCod[0] > A116RubCod ) || ( T007612_A116RubCod[0] == A116RubCod ) && ( T007612_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A118RubLinCod[0] > A118RubLinCod ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A115TotRub[0] < A115TotRub ) || ( T007612_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A116RubCod[0] < A116RubCod ) || ( T007612_A116RubCod[0] == A116RubCod ) && ( T007612_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T007612_A114TotTipo[0], A114TotTipo) == 0 ) && ( T007612_A118RubLinCod[0] < A118RubLinCod ) ) )
            {
               A114TotTipo = T007612_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T007612_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T007612_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               A118RubLinCod = T007612_A118RubLinCod[0];
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               RcdFound66 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7666( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7666( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound66 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  A116RubCod = Z116RubCod;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
                  A118RubLinCod = Z118RubLinCod;
                  AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7666( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7666( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7666( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = Z116RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = Z118RubLinCod;
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7666( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00765 */
            pr_default.execute(3, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSL"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z1826RubLinDsc, T00765_A1826RubLinDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1827RubLinDscTot, T00765_A1827RubLinDscTot[0]) != 0 ) || ( Z119RubLinOrd != T00765_A119RubLinOrd[0] ) || ( Z1828RubLinSts != T00765_A1828RubLinSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1826RubLinDsc, T00765_A1826RubLinDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLinDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1826RubLinDsc);
                  GXUtil.WriteLogRaw("Current: ",T00765_A1826RubLinDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1827RubLinDscTot, T00765_A1827RubLinDscTot[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLinDscTot");
                  GXUtil.WriteLogRaw("Old: ",Z1827RubLinDscTot);
                  GXUtil.WriteLogRaw("Current: ",T00765_A1827RubLinDscTot[0]);
               }
               if ( Z119RubLinOrd != T00765_A119RubLinOrd[0] )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLinOrd");
                  GXUtil.WriteLogRaw("Old: ",Z119RubLinOrd);
                  GXUtil.WriteLogRaw("Current: ",T00765_A119RubLinOrd[0]);
               }
               if ( Z1828RubLinSts != T00765_A1828RubLinSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLinSts");
                  GXUtil.WriteLogRaw("Old: ",Z1828RubLinSts);
                  GXUtil.WriteLogRaw("Current: ",T00765_A1828RubLinSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROSL"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7666( )
      {
         BeforeValidate7666( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7666( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7666( 0) ;
            CheckOptimisticConcurrency7666( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7666( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7666( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007613 */
                     pr_default.execute(11, new Object[] {A118RubLinCod, A1826RubLinDsc, A1827RubLinDscTot, A119RubLinOrd, A1828RubLinSts, A114TotTipo, A115TotRub, A116RubCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSL");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel7666( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption760( ) ;
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
            else
            {
               Load7666( ) ;
            }
            EndLevel7666( ) ;
         }
         CloseExtendedTableCursors7666( ) ;
      }

      protected void Update7666( )
      {
         BeforeValidate7666( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7666( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7666( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7666( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7666( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007614 */
                     pr_default.execute(12, new Object[] {A1826RubLinDsc, A1827RubLinDscTot, A119RubLinOrd, A1828RubLinSts, A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSL");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSL"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7666( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7666( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel7666( ) ;
         }
         CloseExtendedTableCursors7666( ) ;
      }

      protected void DeferredUpdate7666( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7666( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7666( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7666( ) ;
            AfterConfirm7666( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7666( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart7667( ) ;
                  while ( RcdFound67 != 0 )
                  {
                     getByPrimaryKey7667( ) ;
                     Delete7667( ) ;
                     ScanNext7667( ) ;
                  }
                  ScanEnd7667( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007615 */
                     pr_default.execute(13, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSL");
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
         }
         sMode66 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7666( ) ;
         Gx_mode = sMode66;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7666( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel7667( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow7667( ) ;
            if ( ( nRcdExists_67 != 0 ) || ( nIsMod_67 != 0 ) )
            {
               standaloneNotModal7667( ) ;
               GetKey7667( ) ;
               if ( ( nRcdExists_67 == 0 ) && ( nRcdDeleted_67 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7667( ) ;
               }
               else
               {
                  if ( RcdFound67 != 0 )
                  {
                     if ( ( nRcdDeleted_67 != 0 ) && ( nRcdExists_67 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7667( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_67 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7667( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_67 == 0 )
                     {
                        GXCCtl = "CUECOD_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCueCod_Internalname, StringUtil.RTrim( A91CueCod)) ;
            ChangePostValue( edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc)) ;
            ChangePostValue( edtRubLDPos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", ""))) ;
            ChangePostValue( edtRubLDNeg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_63_idx, StringUtil.RTrim( Z91CueCod)) ;
            ChangePostValue( "ZT_"+"Z1825RubLDPos_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1825RubLDPos), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1824RubLDNeg_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1824RubLDNeg), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_67_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, ".", ""))) ;
            if ( nIsMod_67 != 0 )
            {
               ChangePostValue( "CUECOD_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CUEDSC_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBLDPOS_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDPos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBLDNEG_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDNeg_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7667( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_67 = 0;
         nIsMod_67 = 0;
         nRcdDeleted_67 = 0;
      }

      protected void ProcessLevel7666( )
      {
         /* Save parent mode. */
         sMode66 = Gx_mode;
         ProcessNestedLevel7667( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode66;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel7666( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7666( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("contabilidad.lineas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues760( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("contabilidad.lineas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7666( )
      {
         /* Scan By routine */
         /* Using cursor T007616 */
         pr_default.execute(14);
         RcdFound66 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound66 = 1;
            A114TotTipo = T007616_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007616_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T007616_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = T007616_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7666( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound66 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound66 = 1;
            A114TotTipo = T007616_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T007616_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T007616_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = T007616_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
         }
      }

      protected void ScanEnd7666( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm7666( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7666( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7666( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7666( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7666( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7666( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7666( )
      {
         edtTotTipo_Enabled = 0;
         AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         edtTotRub_Enabled = 0;
         AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         edtRubCod_Enabled = 0;
         AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         edtRubLinCod_Enabled = 0;
         AssignProp("", false, edtRubLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinCod_Enabled), 5, 0), true);
         edtRubLinDsc_Enabled = 0;
         AssignProp("", false, edtRubLinDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinDsc_Enabled), 5, 0), true);
         edtRubLinDscTot_Enabled = 0;
         AssignProp("", false, edtRubLinDscTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinDscTot_Enabled), 5, 0), true);
         edtRubLinOrd_Enabled = 0;
         AssignProp("", false, edtRubLinOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinOrd_Enabled), 5, 0), true);
         cmbRubLinSts.Enabled = 0;
         AssignProp("", false, cmbRubLinSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRubLinSts.Enabled), 5, 0), true);
      }

      protected void ZM7667( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1825RubLDPos = T00763_A1825RubLDPos[0];
               Z1824RubLDNeg = T00763_A1824RubLDNeg[0];
            }
            else
            {
               Z1825RubLDPos = A1825RubLDPos;
               Z1824RubLDNeg = A1824RubLDNeg;
            }
         }
         if ( GX_JID == -15 )
         {
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            Z118RubLinCod = A118RubLinCod;
            Z1825RubLDPos = A1825RubLDPos;
            Z1824RubLDNeg = A1824RubLDNeg;
            Z91CueCod = A91CueCod;
            Z860CueDsc = A860CueDsc;
         }
      }

      protected void standaloneNotModal7667( )
      {
      }

      protected void standaloneModal7667( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCueCod_Enabled = 0;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtCueCod_Enabled = 1;
            AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load7667( )
      {
         /* Using cursor T007617 */
         pr_default.execute(15, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound67 = 1;
            A860CueDsc = T007617_A860CueDsc[0];
            A1825RubLDPos = T007617_A1825RubLDPos[0];
            A1824RubLDNeg = T007617_A1824RubLDNeg[0];
            ZM7667( -15) ;
         }
         pr_default.close(15);
         OnLoadActions7667( ) ;
      }

      protected void OnLoadActions7667( )
      {
      }

      protected void CheckExtendedTable7667( )
      {
         nIsDirty_67 = 0;
         Gx_BScreen = 1;
         standaloneModal7667( ) ;
         /* Using cursor T00764 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "CUECOD_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T00764_A860CueDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7667( )
      {
         pr_default.close(2);
      }

      protected void enableDisable7667( )
      {
      }

      protected void gxLoad_16( string A91CueCod )
      {
         /* Using cursor T007618 */
         pr_default.execute(16, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "CUECOD_" + sGXsfl_63_idx;
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T007618_A860CueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A860CueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey7667( )
      {
         /* Using cursor T007619 */
         pr_default.execute(17, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey7667( )
      {
         /* Using cursor T00763 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7667( 15) ;
            RcdFound67 = 1;
            InitializeNonKey7667( ) ;
            A1825RubLDPos = T00763_A1825RubLDPos[0];
            A1824RubLDNeg = T00763_A1824RubLDNeg[0];
            A91CueCod = T00763_A91CueCod[0];
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            Z118RubLinCod = A118RubLinCod;
            Z91CueCod = A91CueCod;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7667( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey7667( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7667( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7667( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7667( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00762 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSLD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1825RubLDPos != T00762_A1825RubLDPos[0] ) || ( Z1824RubLDNeg != T00762_A1824RubLDNeg[0] ) )
            {
               if ( Z1825RubLDPos != T00762_A1825RubLDPos[0] )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLDPos");
                  GXUtil.WriteLogRaw("Old: ",Z1825RubLDPos);
                  GXUtil.WriteLogRaw("Current: ",T00762_A1825RubLDPos[0]);
               }
               if ( Z1824RubLDNeg != T00762_A1824RubLDNeg[0] )
               {
                  GXUtil.WriteLog("contabilidad.lineas:[seudo value changed for attri]"+"RubLDNeg");
                  GXUtil.WriteLogRaw("Old: ",Z1824RubLDNeg);
                  GXUtil.WriteLogRaw("Current: ",T00762_A1824RubLDNeg[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROSLD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7667( )
      {
         BeforeValidate7667( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7667( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7667( 0) ;
            CheckOptimisticConcurrency7667( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7667( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7667( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007620 */
                     pr_default.execute(18, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A1825RubLDPos, A1824RubLDNeg, A91CueCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load7667( ) ;
            }
            EndLevel7667( ) ;
         }
         CloseExtendedTableCursors7667( ) ;
      }

      protected void Update7667( )
      {
         BeforeValidate7667( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7667( ) ;
         }
         if ( ( nIsMod_67 != 0 ) || ( nIsDirty_67 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7667( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7667( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7667( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007621 */
                        pr_default.execute(19, new Object[] {A1825RubLDPos, A1824RubLDNeg, A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
                        pr_default.close(19);
                        dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSLD"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7667( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7667( ) ;
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
               EndLevel7667( ) ;
            }
         }
         CloseExtendedTableCursors7667( ) ;
      }

      protected void DeferredUpdate7667( )
      {
      }

      protected void Delete7667( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7667( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7667( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7667( ) ;
            AfterConfirm7667( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7667( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007622 */
                  pr_default.execute(20, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7667( ) ;
         Gx_mode = sMode67;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7667( )
      {
         standaloneModal7667( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007623 */
            pr_default.execute(21, new Object[] {A91CueCod});
            A860CueDsc = T007623_A860CueDsc[0];
            pr_default.close(21);
         }
      }

      protected void EndLevel7667( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7667( )
      {
         /* Scan By routine */
         /* Using cursor T007624 */
         pr_default.execute(22, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         RcdFound67 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound67 = 1;
            A91CueCod = T007624_A91CueCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7667( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound67 = 1;
            A91CueCod = T007624_A91CueCod[0];
         }
      }

      protected void ScanEnd7667( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm7667( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7667( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7667( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7667( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7667( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7667( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7667( )
      {
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtRubLDPos_Enabled = 0;
         AssignProp("", false, edtRubLDPos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDPos_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtRubLDNeg_Enabled = 0;
         AssignProp("", false, edtRubLDNeg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDNeg_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes7667( )
      {
      }

      protected void send_integrity_lvl_hashes7666( )
      {
      }

      protected void SubsflControlProps_6367( )
      {
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_63_idx;
         imgprompt_91_Internalname = "PROMPT_91_"+sGXsfl_63_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_63_idx;
         edtRubLDPos_Internalname = "RUBLDPOS_"+sGXsfl_63_idx;
         edtRubLDNeg_Internalname = "RUBLDNEG_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_6367( )
      {
         edtCueCod_Internalname = "CUECOD_"+sGXsfl_63_fel_idx;
         imgprompt_91_Internalname = "PROMPT_91_"+sGXsfl_63_fel_idx;
         edtCueDsc_Internalname = "CUEDSC_"+sGXsfl_63_fel_idx;
         edtRubLDPos_Internalname = "RUBLDPOS_"+sGXsfl_63_fel_idx;
         edtRubLDNeg_Internalname = "RUBLDNEG_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow7667( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6367( ) ;
         SendRow7667( ) ;
      }

      protected void SendRow7667( )
      {
         Gridlevel_level1Row = GXWebRow.GetNew(context);
         if ( subGridlevel_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
            }
         }
         else if ( subGridlevel_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_level1_Backstyle = 0;
            subGridlevel_level1_Backcolor = subGridlevel_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Uniform";
            }
         }
         else if ( subGridlevel_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
            {
               subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
            }
            subGridlevel_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridlevel_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
               {
                  subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Even";
               }
            }
            else
            {
               subGridlevel_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level1_Class, "") != 0 )
               {
                  subGridlevel_level1_Linesclass = subGridlevel_level1_Class+"Odd";
               }
            }
         }
         imgprompt_91_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaplancuenta.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CUECOD_"+sGXsfl_63_idx+"'), id:'"+"CUECOD_"+sGXsfl_63_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"CUEDSC_"+sGXsfl_63_idx+"'), id:'"+"CUEDSC_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_67_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueCod_Internalname,StringUtil.RTrim( A91CueCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCueCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_level1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_91_Internalname,(string)sImgUrl,(string)imgprompt_91_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_91_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCueDsc_Internalname,StringUtil.RTrim( A860CueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCueDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "AttributeCheckBox";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLDPos_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", "")),StringUtil.LTrim( ((edtRubLDPos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1825RubLDPos), "9") : context.localUtil.Format( (decimal)(A1825RubLDPos), "9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubLDPos_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubLDPos_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "AttributeCheckBox";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubLDNeg_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", "")),StringUtil.LTrim( ((edtRubLDNeg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1824RubLDNeg), "9") : context.localUtil.Format( (decimal)(A1824RubLDNeg), "9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubLDNeg_Jsonclick,(short)0,(string)"AttributeCheckBox",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubLDNeg_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_level1Row);
         send_integrity_lvl_hashes7667( ) ;
         GXCCtl = "Z91CueCod_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z91CueCod));
         GXCCtl = "Z1825RubLDPos_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1825RubLDPos), 1, 0, ".", "")));
         GXCCtl = "Z1824RubLDNeg_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1824RubLDNeg), 1, 0, ".", "")));
         GXCCtl = "nRcdDeleted_67_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_67_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, ".", "")));
         GXCCtl = "nIsMod_67_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV12TrnContext);
         }
         GXCCtl = "vTOTTIPO_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7TotTipo));
         GXCCtl = "vTOTRUB_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TotRub), 6, 0, ".", "")));
         GXCCtl = "vRUBCOD_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9RubCod), 6, 0, ".", "")));
         GXCCtl = "vRUBLINCOD_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10RubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUECOD_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUEDSC_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCueDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBLDPOS_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDPos_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBLDNEG_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubLDNeg_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_91_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_91_Link));
         ajax_sending_grid_row(null);
         Gridlevel_level1Container.AddRow(Gridlevel_level1Row);
      }

      protected void ReadRow7667( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6367( ) ;
         edtCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUECOD_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CUEDSC_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtRubLDPos_Enabled = (int)(context.localUtil.CToN( cgiGet( "RUBLDPOS_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtRubLDNeg_Enabled = (int)(context.localUtil.CToN( cgiGet( "RUBLDNEG_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         imgprompt_91_Link = cgiGet( "PROMPT_91_"+sGXsfl_63_idx+"Link");
         A91CueCod = cgiGet( edtCueCod_Internalname);
         A860CueDsc = cgiGet( edtCueDsc_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "RUBLDPOS_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubLDPos_Internalname;
            wbErr = true;
            A1825RubLDPos = 0;
         }
         else
         {
            A1825RubLDPos = (short)(context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ","));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "RUBLDNEG_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubLDNeg_Internalname;
            wbErr = true;
            A1824RubLDNeg = 0;
         }
         else
         {
            A1824RubLDNeg = (short)(context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ","));
         }
         GXCCtl = "Z91CueCod_" + sGXsfl_63_idx;
         Z91CueCod = cgiGet( GXCCtl);
         GXCCtl = "Z1825RubLDPos_" + sGXsfl_63_idx;
         Z1825RubLDPos = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z1824RubLDNeg_" + sGXsfl_63_idx;
         Z1824RubLDNeg = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_67_" + sGXsfl_63_idx;
         nRcdDeleted_67 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_67_" + sGXsfl_63_idx;
         nRcdExists_67 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_67_" + sGXsfl_63_idx;
         nIsMod_67 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCueCod_Enabled = edtCueCod_Enabled;
      }

      protected void ConfirmValues760( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6367( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6367( ) ;
            ChangePostValue( "Z91CueCod_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z91CueCod_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z91CueCod_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z1825RubLDPos_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z1825RubLDPos_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z1825RubLDPos_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z1824RubLDNeg_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z1824RubLDNeg_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z1824RubLDNeg_"+sGXsfl_63_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027480", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV8TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9RubCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10RubLinCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Lineas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\lineas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116RubCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z118RubLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118RubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1826RubLinDsc", StringUtil.RTrim( Z1826RubLinDsc));
         GxWebStd.gx_hidden_field( context, "Z1827RubLinDscTot", StringUtil.RTrim( Z1827RubLinDscTot));
         GxWebStd.gx_hidden_field( context, "Z119RubLinOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z119RubLinOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1828RubLinSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1828RubLinSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTOTTIPO", StringUtil.RTrim( AV7TotTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7TotTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vTOTRUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTOTRUB", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TotRub), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRUBCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9RubCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRUBLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10RubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBLINCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10RubLinCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "contabilidad.lineas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7TotTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV8TotRub,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9RubCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10RubLinCod,6,0));
         return formatLink("contabilidad.lineas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.Lineas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lineas" ;
      }

      protected void InitializeNonKey7666( )
      {
         A1826RubLinDsc = "";
         AssignAttri("", false, "A1826RubLinDsc", A1826RubLinDsc);
         A1827RubLinDscTot = "";
         AssignAttri("", false, "A1827RubLinDscTot", A1827RubLinDscTot);
         A119RubLinOrd = 0;
         AssignAttri("", false, "A119RubLinOrd", StringUtil.LTrimStr( (decimal)(A119RubLinOrd), 2, 0));
         A1828RubLinSts = 0;
         AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
         Z1826RubLinDsc = "";
         Z1827RubLinDscTot = "";
         Z119RubLinOrd = 0;
         Z1828RubLinSts = 0;
      }

      protected void InitAll7666( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         A116RubCod = 0;
         AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         A118RubLinCod = 0;
         AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
         InitializeNonKey7666( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7667( )
      {
         A860CueDsc = "";
         A1825RubLDPos = 0;
         A1824RubLDNeg = 0;
         Z1825RubLDPos = 0;
         Z1824RubLDNeg = 0;
      }

      protected void InitAll7667( )
      {
         A91CueCod = "";
         InitializeNonKey7667( ) ;
      }

      protected void StandaloneModalInsert7667( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027510", true, true);
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
         context.AddJavascriptSource("contabilidad/lineas.js", "?20228181027510", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties67( )
      {
         edtCueCod_Enabled = defedtCueCod_Enabled;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtTotTipo_Internalname = "TOTTIPO";
         edtTotRub_Internalname = "TOTRUB";
         edtRubCod_Internalname = "RUBCOD";
         edtRubLinCod_Internalname = "RUBLINCOD";
         edtRubLinDsc_Internalname = "RUBLINDSC";
         edtRubLinDscTot_Internalname = "RUBLINDSCTOT";
         edtRubLinOrd_Internalname = "RUBLINORD";
         cmbRubLinSts_Internalname = "RUBLINSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCueCod_Internalname = "CUECOD";
         edtCueDsc_Internalname = "CUEDSC";
         edtRubLDPos_Internalname = "RUBLDPOS";
         edtRubLDNeg_Internalname = "RUBLDNEG";
         divTableleaflevel_level1_Internalname = "TABLELEAFLEVEL_LEVEL1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_91_Internalname = "PROMPT_91";
         subGridlevel_level1_Internalname = "GRIDLEVEL_LEVEL1";
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
         Form.Caption = "Lineas";
         edtRubLDNeg_Jsonclick = "";
         edtRubLDPos_Jsonclick = "";
         edtCueDsc_Jsonclick = "";
         imgprompt_91_Visible = 1;
         imgprompt_91_Link = "";
         imgprompt_91_Visible = 1;
         edtCueCod_Jsonclick = "";
         subGridlevel_level1_Class = "WorkWith";
         subGridlevel_level1_Backcolorstyle = 0;
         subGridlevel_level1_Allowcollapsing = 0;
         subGridlevel_level1_Allowselection = 0;
         edtRubLDNeg_Enabled = 1;
         edtRubLDPos_Enabled = 1;
         edtCueDsc_Enabled = 0;
         edtCueCod_Enabled = 1;
         subGridlevel_level1_Header = "";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbRubLinSts_Jsonclick = "";
         cmbRubLinSts.Enabled = 1;
         edtRubLinOrd_Jsonclick = "";
         edtRubLinOrd_Enabled = 1;
         edtRubLinDscTot_Jsonclick = "";
         edtRubLinDscTot_Enabled = 1;
         edtRubLinDsc_Jsonclick = "";
         edtRubLinDsc_Enabled = 1;
         edtRubLinCod_Jsonclick = "";
         edtRubLinCod_Enabled = 1;
         edtRubCod_Jsonclick = "";
         edtRubCod_Enabled = 1;
         edtTotRub_Jsonclick = "";
         edtTotRub_Enabled = 1;
         edtTotTipo_Jsonclick = "";
         edtTotTipo_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Información General";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      protected void gxnrGridlevel_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6367( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7667( ) ;
            standaloneModal7667( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7667( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6367( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level1Container)) ;
         /* End function gxnrGridlevel_level1_newrow */
      }

      protected void init_web_controls( )
      {
         cmbRubLinSts.Name = "RUBLINSTS";
         cmbRubLinSts.WebTags = "";
         cmbRubLinSts.addItem("1", "ACTIVO", 0);
         cmbRubLinSts.addItem("0", "INACTIVO", 0);
         if ( cmbRubLinSts.ItemCount > 0 )
         {
            A1828RubLinSts = (short)(NumberUtil.Val( cmbRubLinSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0))), "."));
            AssignAttri("", false, "A1828RubLinSts", StringUtil.Str( (decimal)(A1828RubLinSts), 1, 0));
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

      public void Valid_Rubcod( )
      {
         /* Using cursor T007625 */
         pr_default.execute(23, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros'.", "ForeignKeyNotFound", 1, "RUBCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T007623 */
         pr_default.execute(21, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         A860CueDsc = T007623_A860CueDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV8TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true},{av:'AV9RubCod',fld:'vRUBCOD',pic:'ZZZZZ9',hsh:true},{av:'AV10RubLinCod',fld:'vRUBLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TotTipo',fld:'vTOTTIPO',pic:'',hsh:true},{av:'AV8TotRub',fld:'vTOTRUB',pic:'ZZZZZ9',hsh:true},{av:'AV9RubCod',fld:'vRUBCOD',pic:'ZZZZZ9',hsh:true},{av:'AV10RubLinCod',fld:'vRUBLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12762',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TOTTIPO","{handler:'Valid_Tottipo',iparms:[]");
         setEventMetadata("VALID_TOTTIPO",",oparms:[]}");
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[]");
         setEventMetadata("VALID_TOTRUB",",oparms:[]}");
         setEventMetadata("VALID_RUBCOD","{handler:'Valid_Rubcod',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_RUBCOD",",oparms:[]}");
         setEventMetadata("VALID_RUBLINCOD","{handler:'Valid_Rublincod',iparms:[]");
         setEventMetadata("VALID_RUBLINCOD",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Rubldneg',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(4);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7TotTipo = "";
         Z114TotTipo = "";
         Z1826RubLinDsc = "";
         Z1827RubLinDscTot = "";
         Z91CueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A114TotTipo = "";
         A91CueCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1826RubLinDsc = "";
         A1827RubLinDscTot = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_level1Container = new GXWebGrid( context);
         Gridlevel_level1Column = new GXWebColumn();
         A860CueDsc = "";
         sMode67 = "";
         sStyleString = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode66 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV11WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         T00768_A118RubLinCod = new int[1] ;
         T00768_A1826RubLinDsc = new string[] {""} ;
         T00768_A1827RubLinDscTot = new string[] {""} ;
         T00768_A119RubLinOrd = new short[1] ;
         T00768_A1828RubLinSts = new short[1] ;
         T00768_A114TotTipo = new string[] {""} ;
         T00768_A115TotRub = new int[1] ;
         T00768_A116RubCod = new int[1] ;
         T00767_A114TotTipo = new string[] {""} ;
         T00769_A114TotTipo = new string[] {""} ;
         T007610_A114TotTipo = new string[] {""} ;
         T007610_A115TotRub = new int[1] ;
         T007610_A116RubCod = new int[1] ;
         T007610_A118RubLinCod = new int[1] ;
         T00766_A118RubLinCod = new int[1] ;
         T00766_A1826RubLinDsc = new string[] {""} ;
         T00766_A1827RubLinDscTot = new string[] {""} ;
         T00766_A119RubLinOrd = new short[1] ;
         T00766_A1828RubLinSts = new short[1] ;
         T00766_A114TotTipo = new string[] {""} ;
         T00766_A115TotRub = new int[1] ;
         T00766_A116RubCod = new int[1] ;
         T007611_A114TotTipo = new string[] {""} ;
         T007611_A115TotRub = new int[1] ;
         T007611_A116RubCod = new int[1] ;
         T007611_A118RubLinCod = new int[1] ;
         T007612_A114TotTipo = new string[] {""} ;
         T007612_A115TotRub = new int[1] ;
         T007612_A116RubCod = new int[1] ;
         T007612_A118RubLinCod = new int[1] ;
         T00765_A118RubLinCod = new int[1] ;
         T00765_A1826RubLinDsc = new string[] {""} ;
         T00765_A1827RubLinDscTot = new string[] {""} ;
         T00765_A119RubLinOrd = new short[1] ;
         T00765_A1828RubLinSts = new short[1] ;
         T00765_A114TotTipo = new string[] {""} ;
         T00765_A115TotRub = new int[1] ;
         T00765_A116RubCod = new int[1] ;
         T007616_A114TotTipo = new string[] {""} ;
         T007616_A115TotRub = new int[1] ;
         T007616_A116RubCod = new int[1] ;
         T007616_A118RubLinCod = new int[1] ;
         Z860CueDsc = "";
         T007617_A114TotTipo = new string[] {""} ;
         T007617_A115TotRub = new int[1] ;
         T007617_A116RubCod = new int[1] ;
         T007617_A118RubLinCod = new int[1] ;
         T007617_A860CueDsc = new string[] {""} ;
         T007617_A1825RubLDPos = new short[1] ;
         T007617_A1824RubLDNeg = new short[1] ;
         T007617_A91CueCod = new string[] {""} ;
         T00764_A860CueDsc = new string[] {""} ;
         T007618_A860CueDsc = new string[] {""} ;
         T007619_A114TotTipo = new string[] {""} ;
         T007619_A115TotRub = new int[1] ;
         T007619_A116RubCod = new int[1] ;
         T007619_A118RubLinCod = new int[1] ;
         T007619_A91CueCod = new string[] {""} ;
         T00763_A114TotTipo = new string[] {""} ;
         T00763_A115TotRub = new int[1] ;
         T00763_A116RubCod = new int[1] ;
         T00763_A118RubLinCod = new int[1] ;
         T00763_A1825RubLDPos = new short[1] ;
         T00763_A1824RubLDNeg = new short[1] ;
         T00763_A91CueCod = new string[] {""} ;
         T00762_A114TotTipo = new string[] {""} ;
         T00762_A115TotRub = new int[1] ;
         T00762_A116RubCod = new int[1] ;
         T00762_A118RubLinCod = new int[1] ;
         T00762_A1825RubLDPos = new short[1] ;
         T00762_A1824RubLDNeg = new short[1] ;
         T00762_A91CueCod = new string[] {""} ;
         T007623_A860CueDsc = new string[] {""} ;
         T007624_A114TotTipo = new string[] {""} ;
         T007624_A115TotRub = new int[1] ;
         T007624_A116RubCod = new int[1] ;
         T007624_A118RubLinCod = new int[1] ;
         T007624_A91CueCod = new string[] {""} ;
         Gridlevel_level1Row = new GXWebRow();
         subGridlevel_level1_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T007625_A114TotTipo = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineas__default(),
            new Object[][] {
                new Object[] {
               T00762_A114TotTipo, T00762_A115TotRub, T00762_A116RubCod, T00762_A118RubLinCod, T00762_A1825RubLDPos, T00762_A1824RubLDNeg, T00762_A91CueCod
               }
               , new Object[] {
               T00763_A114TotTipo, T00763_A115TotRub, T00763_A116RubCod, T00763_A118RubLinCod, T00763_A1825RubLDPos, T00763_A1824RubLDNeg, T00763_A91CueCod
               }
               , new Object[] {
               T00764_A860CueDsc
               }
               , new Object[] {
               T00765_A118RubLinCod, T00765_A1826RubLinDsc, T00765_A1827RubLinDscTot, T00765_A119RubLinOrd, T00765_A1828RubLinSts, T00765_A114TotTipo, T00765_A115TotRub, T00765_A116RubCod
               }
               , new Object[] {
               T00766_A118RubLinCod, T00766_A1826RubLinDsc, T00766_A1827RubLinDscTot, T00766_A119RubLinOrd, T00766_A1828RubLinSts, T00766_A114TotTipo, T00766_A115TotRub, T00766_A116RubCod
               }
               , new Object[] {
               T00767_A114TotTipo
               }
               , new Object[] {
               T00768_A118RubLinCod, T00768_A1826RubLinDsc, T00768_A1827RubLinDscTot, T00768_A119RubLinOrd, T00768_A1828RubLinSts, T00768_A114TotTipo, T00768_A115TotRub, T00768_A116RubCod
               }
               , new Object[] {
               T00769_A114TotTipo
               }
               , new Object[] {
               T007610_A114TotTipo, T007610_A115TotRub, T007610_A116RubCod, T007610_A118RubLinCod
               }
               , new Object[] {
               T007611_A114TotTipo, T007611_A115TotRub, T007611_A116RubCod, T007611_A118RubLinCod
               }
               , new Object[] {
               T007612_A114TotTipo, T007612_A115TotRub, T007612_A116RubCod, T007612_A118RubLinCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007616_A114TotTipo, T007616_A115TotRub, T007616_A116RubCod, T007616_A118RubLinCod
               }
               , new Object[] {
               T007617_A114TotTipo, T007617_A115TotRub, T007617_A116RubCod, T007617_A118RubLinCod, T007617_A860CueDsc, T007617_A1825RubLDPos, T007617_A1824RubLDNeg, T007617_A91CueCod
               }
               , new Object[] {
               T007618_A860CueDsc
               }
               , new Object[] {
               T007619_A114TotTipo, T007619_A115TotRub, T007619_A116RubCod, T007619_A118RubLinCod, T007619_A91CueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007623_A860CueDsc
               }
               , new Object[] {
               T007624_A114TotTipo, T007624_A115TotRub, T007624_A116RubCod, T007624_A118RubLinCod, T007624_A91CueCod
               }
               , new Object[] {
               T007625_A114TotTipo
               }
            }
         );
      }

      private short nIsMod_67 ;
      private short Z119RubLinOrd ;
      private short Z1828RubLinSts ;
      private short Z1825RubLDPos ;
      private short Z1824RubLDNeg ;
      private short nRcdDeleted_67 ;
      private short nRcdExists_67 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1828RubLinSts ;
      private short A119RubLinOrd ;
      private short subGridlevel_level1_Backcolorstyle ;
      private short A1825RubLDPos ;
      private short A1824RubLDNeg ;
      private short subGridlevel_level1_Allowselection ;
      private short subGridlevel_level1_Allowhovering ;
      private short subGridlevel_level1_Allowcollapsing ;
      private short subGridlevel_level1_Collapsed ;
      private short nBlankRcdCount67 ;
      private short RcdFound67 ;
      private short nBlankRcdUsr67 ;
      private short RcdFound66 ;
      private short GX_JID ;
      private short nIsDirty_66 ;
      private short Gx_BScreen ;
      private short nIsDirty_67 ;
      private short subGridlevel_level1_Backstyle ;
      private short gxajaxcallmode ;
      private int wcpOAV8TotRub ;
      private int wcpOAV9RubCod ;
      private int wcpOAV10RubLinCod ;
      private int Z115TotRub ;
      private int Z116RubCod ;
      private int Z118RubLinCod ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int AV8TotRub ;
      private int AV9RubCod ;
      private int AV10RubLinCod ;
      private int trnEnded ;
      private int edtTotTipo_Enabled ;
      private int edtTotRub_Enabled ;
      private int edtRubCod_Enabled ;
      private int A118RubLinCod ;
      private int edtRubLinCod_Enabled ;
      private int edtRubLinDsc_Enabled ;
      private int edtRubLinDscTot_Enabled ;
      private int edtRubLinOrd_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtRubLDPos_Enabled ;
      private int edtRubLDNeg_Enabled ;
      private int subGridlevel_level1_Selectedindex ;
      private int subGridlevel_level1_Selectioncolor ;
      private int subGridlevel_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_level1_Backcolor ;
      private int subGridlevel_level1_Allbackcolor ;
      private int imgprompt_91_Visible ;
      private int defedtCueCod_Enabled ;
      private int idxLst ;
      private long GRIDLEVEL_LEVEL1_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string wcpOAV7TotTipo ;
      private string Z114TotTipo ;
      private string Z1826RubLinDsc ;
      private string Z1827RubLinDscTot ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A114TotTipo ;
      private string A91CueCod ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string AV7TotTipo ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTotTipo_Internalname ;
      private string cmbRubLinSts_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTotTipo_Jsonclick ;
      private string edtTotRub_Internalname ;
      private string edtTotRub_Jsonclick ;
      private string edtRubCod_Internalname ;
      private string edtRubCod_Jsonclick ;
      private string edtRubLinCod_Internalname ;
      private string edtRubLinCod_Jsonclick ;
      private string edtRubLinDsc_Internalname ;
      private string A1826RubLinDsc ;
      private string edtRubLinDsc_Jsonclick ;
      private string edtRubLinDscTot_Internalname ;
      private string A1827RubLinDscTot ;
      private string edtRubLinDscTot_Jsonclick ;
      private string edtRubLinOrd_Internalname ;
      private string edtRubLinOrd_Jsonclick ;
      private string cmbRubLinSts_Jsonclick ;
      private string divTableleaflevel_level1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string subGridlevel_level1_Header ;
      private string A860CueDsc ;
      private string sMode67 ;
      private string edtCueCod_Internalname ;
      private string edtCueDsc_Internalname ;
      private string edtRubLDPos_Internalname ;
      private string edtRubLDNeg_Internalname ;
      private string imgprompt_91_Link ;
      private string sStyleString ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode66 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z860CueDsc ;
      private string imgprompt_91_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridlevel_level1_Class ;
      private string subGridlevel_level1_Linesclass ;
      private string ROClassString ;
      private string edtCueCod_Jsonclick ;
      private string sImgUrl ;
      private string edtCueDsc_Jsonclick ;
      private string edtRubLDPos_Jsonclick ;
      private string edtRubLDNeg_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_level1_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_level1Container ;
      private GXWebRow Gridlevel_level1Row ;
      private GXWebColumn Gridlevel_level1Column ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRubLinSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00768_A118RubLinCod ;
      private string[] T00768_A1826RubLinDsc ;
      private string[] T00768_A1827RubLinDscTot ;
      private short[] T00768_A119RubLinOrd ;
      private short[] T00768_A1828RubLinSts ;
      private string[] T00768_A114TotTipo ;
      private int[] T00768_A115TotRub ;
      private int[] T00768_A116RubCod ;
      private string[] T00767_A114TotTipo ;
      private string[] T00769_A114TotTipo ;
      private string[] T007610_A114TotTipo ;
      private int[] T007610_A115TotRub ;
      private int[] T007610_A116RubCod ;
      private int[] T007610_A118RubLinCod ;
      private int[] T00766_A118RubLinCod ;
      private string[] T00766_A1826RubLinDsc ;
      private string[] T00766_A1827RubLinDscTot ;
      private short[] T00766_A119RubLinOrd ;
      private short[] T00766_A1828RubLinSts ;
      private string[] T00766_A114TotTipo ;
      private int[] T00766_A115TotRub ;
      private int[] T00766_A116RubCod ;
      private string[] T007611_A114TotTipo ;
      private int[] T007611_A115TotRub ;
      private int[] T007611_A116RubCod ;
      private int[] T007611_A118RubLinCod ;
      private string[] T007612_A114TotTipo ;
      private int[] T007612_A115TotRub ;
      private int[] T007612_A116RubCod ;
      private int[] T007612_A118RubLinCod ;
      private int[] T00765_A118RubLinCod ;
      private string[] T00765_A1826RubLinDsc ;
      private string[] T00765_A1827RubLinDscTot ;
      private short[] T00765_A119RubLinOrd ;
      private short[] T00765_A1828RubLinSts ;
      private string[] T00765_A114TotTipo ;
      private int[] T00765_A115TotRub ;
      private int[] T00765_A116RubCod ;
      private string[] T007616_A114TotTipo ;
      private int[] T007616_A115TotRub ;
      private int[] T007616_A116RubCod ;
      private int[] T007616_A118RubLinCod ;
      private string[] T007617_A114TotTipo ;
      private int[] T007617_A115TotRub ;
      private int[] T007617_A116RubCod ;
      private int[] T007617_A118RubLinCod ;
      private string[] T007617_A860CueDsc ;
      private short[] T007617_A1825RubLDPos ;
      private short[] T007617_A1824RubLDNeg ;
      private string[] T007617_A91CueCod ;
      private string[] T00764_A860CueDsc ;
      private string[] T007618_A860CueDsc ;
      private string[] T007619_A114TotTipo ;
      private int[] T007619_A115TotRub ;
      private int[] T007619_A116RubCod ;
      private int[] T007619_A118RubLinCod ;
      private string[] T007619_A91CueCod ;
      private string[] T00763_A114TotTipo ;
      private int[] T00763_A115TotRub ;
      private int[] T00763_A116RubCod ;
      private int[] T00763_A118RubLinCod ;
      private short[] T00763_A1825RubLDPos ;
      private short[] T00763_A1824RubLDNeg ;
      private string[] T00763_A91CueCod ;
      private string[] T00762_A114TotTipo ;
      private int[] T00762_A115TotRub ;
      private int[] T00762_A116RubCod ;
      private int[] T00762_A118RubLinCod ;
      private short[] T00762_A1825RubLDPos ;
      private short[] T00762_A1824RubLDNeg ;
      private string[] T00762_A91CueCod ;
      private string[] T007623_A860CueDsc ;
      private string[] T007624_A114TotTipo ;
      private int[] T007624_A115TotRub ;
      private int[] T007624_A116RubCod ;
      private int[] T007624_A118RubLinCod ;
      private string[] T007624_A91CueCod ;
      private string[] T007625_A114TotTipo ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV11WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class lineas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class lineas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00768;
        prmT00768 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT00767;
        prmT00767 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT00769;
        prmT00769 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007610;
        prmT007610 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT00766;
        prmT00766 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007611;
        prmT007611 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007612;
        prmT007612 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT00765;
        prmT00765 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007613;
        prmT007613 = new Object[] {
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinDsc",GXType.NChar,100,0) ,
        new ParDef("@RubLinDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubLinOrd",GXType.Int16,2,0) ,
        new ParDef("@RubLinSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007614;
        prmT007614 = new Object[] {
        new ParDef("@RubLinDsc",GXType.NChar,100,0) ,
        new ParDef("@RubLinDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubLinOrd",GXType.Int16,2,0) ,
        new ParDef("@RubLinSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007615;
        prmT007615 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007616;
        prmT007616 = new Object[] {
        };
        Object[] prmT007617;
        prmT007617 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00764;
        prmT00764 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007618;
        prmT007618 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007619;
        prmT007619 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00763;
        prmT00763 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00762;
        prmT00762 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007620;
        prmT007620 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@RubLDPos",GXType.Int16,1,0) ,
        new ParDef("@RubLDNeg",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007621;
        prmT007621 = new Object[] {
        new ParDef("@RubLDPos",GXType.Int16,1,0) ,
        new ParDef("@RubLDNeg",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007622;
        prmT007622 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT007624;
        prmT007624 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT007625;
        prmT007625 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT007623;
        prmT007623 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00762", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [RubLDPos], [RubLDNeg], [CueCod] FROM [CBRUBROSLD] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00762,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00763", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [RubLDPos], [RubLDNeg], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00763,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00764", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00764,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00765", "SELECT [RubLinCod], [RubLinDsc], [RubLinDscTot], [RubLinOrd], [RubLinSts], [TotTipo], [TotRub], [RubCod] FROM [CBRUBROSL] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00765,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00766", "SELECT [RubLinCod], [RubLinDsc], [RubLinDscTot], [RubLinOrd], [RubLinSts], [TotTipo], [TotRub], [RubCod] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00766,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00767", "SELECT [TotTipo] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00767,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00768", "SELECT TM1.[RubLinCod], TM1.[RubLinDsc], TM1.[RubLinDscTot], TM1.[RubLinOrd], TM1.[RubLinSts], TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod] FROM [CBRUBROSL] TM1 WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub and TM1.[RubCod] = @RubCod and TM1.[RubLinCod] = @RubLinCod ORDER BY TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod], TM1.[RubLinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00768,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00769", "SELECT [TotTipo] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00769,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007610", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007610,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007611", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] > @RubCod or [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubLinCod] > @RubLinCod) ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007612", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] < @RubCod or [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubLinCod] < @RubLinCod) ORDER BY [TotTipo] DESC, [TotRub] DESC, [RubCod] DESC, [RubLinCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007613", "INSERT INTO [CBRUBROSL]([RubLinCod], [RubLinDsc], [RubLinDscTot], [RubLinOrd], [RubLinSts], [TotTipo], [TotRub], [RubCod]) VALUES(@RubLinCod, @RubLinDsc, @RubLinDscTot, @RubLinOrd, @RubLinSts, @TotTipo, @TotRub, @RubCod)", GxErrorMask.GX_NOMASK,prmT007613)
           ,new CursorDef("T007614", "UPDATE [CBRUBROSL] SET [RubLinDsc]=@RubLinDsc, [RubLinDscTot]=@RubLinDscTot, [RubLinOrd]=@RubLinOrd, [RubLinSts]=@RubLinSts  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod", GxErrorMask.GX_NOMASK,prmT007614)
           ,new CursorDef("T007615", "DELETE FROM [CBRUBROSL]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod", GxErrorMask.GX_NOMASK,prmT007615)
           ,new CursorDef("T007616", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007616,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007617", "SELECT T1.[TotTipo], T1.[TotRub], T1.[RubCod], T1.[RubLinCod], T2.[CueDsc], T1.[RubLDPos], T1.[RubLDNeg], T1.[CueCod] FROM ([CBRUBROSLD] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE T1.[TotTipo] = @TotTipo and T1.[TotRub] = @TotRub and T1.[RubCod] = @RubCod and T1.[RubLinCod] = @RubLinCod and T1.[CueCod] = @CueCod ORDER BY T1.[TotTipo], T1.[TotRub], T1.[RubCod], T1.[RubLinCod], T1.[CueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007617,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007618", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007618,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007619", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007619,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007620", "INSERT INTO [CBRUBROSLD]([TotTipo], [TotRub], [RubCod], [RubLinCod], [RubLDPos], [RubLDNeg], [CueCod]) VALUES(@TotTipo, @TotRub, @RubCod, @RubLinCod, @RubLDPos, @RubLDNeg, @CueCod)", GxErrorMask.GX_NOMASK,prmT007620)
           ,new CursorDef("T007621", "UPDATE [CBRUBROSLD] SET [RubLDPos]=@RubLDPos, [RubLDNeg]=@RubLDNeg  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT007621)
           ,new CursorDef("T007622", "DELETE FROM [CBRUBROSLD]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT007622)
           ,new CursorDef("T007623", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007623,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007624", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @TotTipo and [TotRub] = @TotRub and [RubCod] = @RubCod and [RubLinCod] = @RubLinCod ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007624,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007625", "SELECT [TotTipo] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007625,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
