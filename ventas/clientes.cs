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
namespace GeneXus.Programs.ventas {
   public class clientes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_40") == 0 )
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
            gxLoad_40( A139PaiCod, A140EstCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = GetPar( "ProvCod");
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A139PaiCod, A140EstCod, A141ProvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = GetPar( "ProvCod");
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = GetPar( "DisCod");
            AssignAttri("", false, "A142DisCod", A142DisCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A139PaiCod, A140EstCod, A141ProvCod, A142DisCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A159TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A159TipCCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A137Conpcod = (int)(NumberUtil.Val( GetPar( "Conpcod"), "."));
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A137Conpcod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_47") == 0 )
         {
            A160CliVend = (int)(NumberUtil.Val( GetPar( "CliVend"), "."));
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_47( A160CliVend) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A158ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
            n158ZonCod = false;
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A158ZonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A156CliTipLCod = (int)(NumberUtil.Val( GetPar( "CliTipLCod"), "."));
            n156CliTipLCod = false;
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A156CliTipLCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A157TipSCod = (int)(NumberUtil.Val( GetPar( "TipSCod"), "."));
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A157TipSCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A165CliDirZonCod = (int)(NumberUtil.Val( GetPar( "CliDirZonCod"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A165CliDirZonCod) ;
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
            nRC_GXsfl_368 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_368"), "."));
            nGXsfl_368_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_368_idx"), "."));
            sGXsfl_368_idx = GetPar( "sGXsfl_368_idx");
            edtCliDirZonCod_Horizontalalignment = GetNextPar( );
            AssignProp("", false, edtCliDirZonCod_Internalname, "Horizontalalignment", edtCliDirZonCod_Horizontalalignment, !bGXsfl_368_Refreshing);
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_level2") == 0 )
         {
            nRC_GXsfl_383 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_383"), "."));
            nGXsfl_383_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_383_idx"), "."));
            sGXsfl_383_idx = GetPar( "sGXsfl_383_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridlevel_level2_newrow( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "ventas.clientes.aspx")), "ventas.clientes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "ventas.clientes.aspx")))) ;
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
                  AV7CliCod = GetPar( "CliCod");
                  AssignAttri("", false, "AV7CliCod", AV7CliCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CliCod, "")), context));
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
            Form.Meta.addItem("description", "Clientes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CliCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CliCod = aP1_CliCod;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCod_Internalname, "Codigo Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliDsc_Internalname, "Razon Social", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDsc_Internalname, StringUtil.RTrim( A161CliDsc), StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliDir_Internalname, "Dirección", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDir_Internalname, StringUtil.RTrim( A596CliDir), StringUtil.RTrim( context.localUtil.Format( A596CliDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedestcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockestcod_Internalname, "Estado", "", "", lblTextblockestcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_estcod.SetProperty("Caption", Combo_estcod_Caption);
         ucCombo_estcod.SetProperty("Cls", Combo_estcod_Cls);
         ucCombo_estcod.SetProperty("DataListProc", Combo_estcod_Datalistproc);
         ucCombo_estcod.SetProperty("EmptyItem", Combo_estcod_Emptyitem);
         ucCombo_estcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_estcod.SetProperty("DropDownOptionsData", AV27EstCod_Data);
         ucCombo_estcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_estcod_Internalname, "COMBO_ESTCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCod_Internalname, "Estado", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEstCod_Visible, edtEstCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedpaicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpaicod_Internalname, "Pais", "", "", lblTextblockpaicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_paicod.SetProperty("Caption", Combo_paicod_Caption);
         ucCombo_paicod.SetProperty("Cls", Combo_paicod_Cls);
         ucCombo_paicod.SetProperty("DataListProc", Combo_paicod_Datalistproc);
         ucCombo_paicod.SetProperty("DataListProcParametersPrefix", Combo_paicod_Datalistprocparametersprefix);
         ucCombo_paicod.SetProperty("EmptyItem", Combo_paicod_Emptyitem);
         ucCombo_paicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_paicod.SetProperty("DropDownOptionsData", AV30PaiCod_Data);
         ucCombo_paicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_paicod_Internalname, "COMBO_PAICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaiCod_Internalname, "Pais", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPaiCod_Visible, edtPaiCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliTel1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTel1_Internalname, "Telefono 1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTel1_Internalname, StringUtil.RTrim( A629CliTel1), StringUtil.RTrim( context.localUtil.Format( A629CliTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliTel2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTel2_Internalname, "Telefono 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTel2_Internalname, StringUtil.RTrim( A630CliTel2), StringUtil.RTrim( context.localUtil.Format( A630CliTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliFax_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliFax_Internalname, "Fax", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliFax_Internalname, StringUtil.RTrim( A611CliFax), StringUtil.RTrim( context.localUtil.Format( A611CliFax, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliFax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliFax_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCel_Internalname, "Celular", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCel_Internalname, StringUtil.RTrim( A575CliCel), StringUtil.RTrim( context.localUtil.Format( A575CliCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliEma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliEma_Internalname, "E-Mail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliEma_Internalname, A609CliEma, StringUtil.RTrim( context.localUtil.Format( A609CliEma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A609CliEma, "", "", "", edtCliEma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliEma_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliWeb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliWeb_Internalname, "Pagina Web", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliWeb_Internalname, StringUtil.RTrim( A637CliWeb), StringUtil.RTrim( context.localUtil.Format( A637CliWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliWeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliWeb_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipccod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipccod_Internalname, "Codigo T. Cliente", "", "", lblTextblocktipccod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipccod.SetProperty("Caption", Combo_tipccod_Caption);
         ucCombo_tipccod.SetProperty("Cls", Combo_tipccod_Cls);
         ucCombo_tipccod.SetProperty("DataListProc", Combo_tipccod_Datalistproc);
         ucCombo_tipccod.SetProperty("DataListProcParametersPrefix", Combo_tipccod_Datalistprocparametersprefix);
         ucCombo_tipccod.SetProperty("EmptyItem", Combo_tipccod_Emptyitem);
         ucCombo_tipccod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_tipccod.SetProperty("DropDownOptionsData", AV32TipCCod_Data);
         ucCombo_tipccod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipccod_Internalname, "COMBO_TIPCCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipCCod_Internalname, "Codigo T. Cliente", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipCCod_Visible, edtTipCCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgCliFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A612CliFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.PathToRelativeUrl( A612CliFoto));
         GxWebStd.gx_bitmap( context, imgCliFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCliFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "", "", "", 0, A612CliFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\Clientes.htm");
         AssignProp("", false, imgCliFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.PathToRelativeUrl( A612CliFoto)), true);
         AssignProp("", false, imgCliFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A612CliFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliSts_Internalname, "Situación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A627CliSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A627CliSts), "9") : context.localUtil.Format( (decimal)(A627CliSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedconpcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockconpcod_Internalname, "Codigo condicion pago", "", "", lblTextblockconpcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_conpcod.SetProperty("Caption", Combo_conpcod_Caption);
         ucCombo_conpcod.SetProperty("Cls", Combo_conpcod_Cls);
         ucCombo_conpcod.SetProperty("DataListProc", Combo_conpcod_Datalistproc);
         ucCombo_conpcod.SetProperty("DataListProcParametersPrefix", Combo_conpcod_Datalistprocparametersprefix);
         ucCombo_conpcod.SetProperty("EmptyItem", Combo_conpcod_Emptyitem);
         ucCombo_conpcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_conpcod.SetProperty("DropDownOptionsData", AV34Conpcod_Data);
         ucCombo_conpcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_conpcod_Internalname, "COMBO_CONPCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtConpcod_Internalname, "Codigo condicion pago", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpcod_Jsonclick, 0, "Attribute", "", "", "", "", edtConpcod_Visible, edtConpcod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliLim_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliLim_Internalname, "Limite Credito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliLim_Internalname, StringUtil.LTrim( StringUtil.NToC( A613CliLim, 15, 2, ".", "")), StringUtil.LTrim( ((edtCliLim_Enabled!=0) ? context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliLim_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliLim_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclivend_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclivend_Internalname, "Vendedor", "", "", lblTextblockclivend_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clivend.SetProperty("Caption", Combo_clivend_Caption);
         ucCombo_clivend.SetProperty("Cls", Combo_clivend_Cls);
         ucCombo_clivend.SetProperty("DataListProc", Combo_clivend_Datalistproc);
         ucCombo_clivend.SetProperty("DataListProcParametersPrefix", Combo_clivend_Datalistprocparametersprefix);
         ucCombo_clivend.SetProperty("EmptyItem", Combo_clivend_Emptyitem);
         ucCombo_clivend.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_clivend.SetProperty("DropDownOptionsData", AV36CliVend_Data);
         ucCombo_clivend.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clivend_Internalname, "COMBO_CLIVENDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliVend_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliVend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A160CliVend), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A160CliVend), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVend_Jsonclick, 0, "Attribute", "", "", "", "", edtCliVend_Visible, edtCliVend_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliVendDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliVendDsc_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliVendDsc_Internalname, StringUtil.RTrim( A635CliVendDsc), StringUtil.RTrim( context.localUtil.Format( A635CliVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef1_Internalname, "Referencia 1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef1_Internalname, StringUtil.RTrim( A618CliRef1), StringUtil.RTrim( context.localUtil.Format( A618CliRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef2_Internalname, "Referencia 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef2_Internalname, StringUtil.RTrim( A619CliRef2), StringUtil.RTrim( context.localUtil.Format( A619CliRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef3_Internalname, "Referencia 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef3_Internalname, StringUtil.RTrim( A620CliRef3), StringUtil.RTrim( context.localUtil.Format( A620CliRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef4_Internalname, "Referencia 4", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef4_Internalname, StringUtil.RTrim( A621CliRef4), StringUtil.RTrim( context.localUtil.Format( A621CliRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef5_Internalname, "Referencia 5", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef5_Internalname, StringUtil.RTrim( A622CliRef5), StringUtil.RTrim( context.localUtil.Format( A622CliRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef6_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef6_Internalname, "Referencia 6", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef6_Internalname, StringUtil.RTrim( A623CliRef6), StringUtil.RTrim( context.localUtil.Format( A623CliRef6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef6_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef7_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef7_Internalname, "Referencia 7", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef7_Internalname, StringUtil.RTrim( A624CliRef7), StringUtil.RTrim( context.localUtil.Format( A624CliRef7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,172);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef7_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRef8_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRef8_Internalname, "Referencia 8", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef8_Internalname, StringUtil.RTrim( A625CliRef8), StringUtil.RTrim( context.localUtil.Format( A625CliRef8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef8_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCont1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCont1_Internalname, "Contacto 1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont1_Internalname, StringUtil.RTrim( A581CliCont1), StringUtil.RTrim( context.localUtil.Format( A581CliCont1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,182);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCTel1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCTel1_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel1_Internalname, StringUtil.RTrim( A587CliCTel1), StringUtil.RTrim( context.localUtil.Format( A587CliCTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,187);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCont2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCont2_Internalname, "Contacto 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont2_Internalname, StringUtil.RTrim( A582CliCont2), StringUtil.RTrim( context.localUtil.Format( A582CliCont2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,192);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCTel2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCTel2_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel2_Internalname, StringUtil.RTrim( A588CliCTel2), StringUtil.RTrim( context.localUtil.Format( A588CliCTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,197);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCont3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCont3_Internalname, "Contacto 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont3_Internalname, StringUtil.RTrim( A583CliCont3), StringUtil.RTrim( context.localUtil.Format( A583CliCont3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,202);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCtel3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCtel3_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCtel3_Internalname, StringUtil.RTrim( A589CliCtel3), StringUtil.RTrim( context.localUtil.Format( A589CliCtel3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCtel3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCtel3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCont4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCont4_Internalname, "Contacto 4", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont4_Internalname, StringUtil.RTrim( A584CliCont4), StringUtil.RTrim( context.localUtil.Format( A584CliCont4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,212);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCTel4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCTel4_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel4_Internalname, StringUtil.RTrim( A590CliCTel4), StringUtil.RTrim( context.localUtil.Format( A590CliCTel4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,217);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCont5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCont5_Internalname, "Contacto 5", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont5_Internalname, StringUtil.RTrim( A585CliCont5), StringUtil.RTrim( context.localUtil.Format( A585CliCont5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,222);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCtel5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCtel5_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 227,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCtel5_Internalname, StringUtil.RTrim( A591CliCtel5), StringUtil.RTrim( context.localUtil.Format( A591CliCtel5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,227);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCtel5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCtel5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplitteddiscod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdiscod_Internalname, "Distrito", "", "", lblTextblockdiscod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_discod.SetProperty("Caption", Combo_discod_Caption);
         ucCombo_discod.SetProperty("Cls", Combo_discod_Cls);
         ucCombo_discod.SetProperty("DataListProc", Combo_discod_Datalistproc);
         ucCombo_discod.SetProperty("EmptyItem", Combo_discod_Emptyitem);
         ucCombo_discod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_discod.SetProperty("DropDownOptionsData", AV39DisCod_Data);
         ucCombo_discod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_discod_Internalname, "COMBO_DISCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDisCod_Internalname, "Distrito", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 238,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,238);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", edtDisCod_Visible, edtDisCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, divTablesplittedprovcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprovcod_Internalname, "Provincia", "", "", lblTextblockprovcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_provcod.SetProperty("Caption", Combo_provcod_Caption);
         ucCombo_provcod.SetProperty("Cls", Combo_provcod_Cls);
         ucCombo_provcod.SetProperty("DataListProc", Combo_provcod_Datalistproc);
         ucCombo_provcod.SetProperty("EmptyItem", Combo_provcod_Emptyitem);
         ucCombo_provcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_provcod.SetProperty("DropDownOptionsData", AV43ProvCod_Data);
         ucCombo_provcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_provcod_Internalname, "COMBO_PROVCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProvCod_Internalname, "Provincia", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", edtProvCod_Visible, edtProvCod_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliTItemDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTItemDir_Internalname, "Total Item Direcciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 254,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTItemDir_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A632CliTItemDir), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliTItemDir_Enabled!=0) ? context.localUtil.Format( (decimal)(A632CliTItemDir), "ZZZZZ9") : context.localUtil.Format( (decimal)(A632CliTItemDir), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,254);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTItemDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTItemDir_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedzoncod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockzoncod_Internalname, "Codigo Zona", "", "", lblTextblockzoncod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_zoncod.SetProperty("Caption", Combo_zoncod_Caption);
         ucCombo_zoncod.SetProperty("Cls", Combo_zoncod_Cls);
         ucCombo_zoncod.SetProperty("DataListProc", Combo_zoncod_Datalistproc);
         ucCombo_zoncod.SetProperty("DataListProcParametersPrefix", Combo_zoncod_Datalistprocparametersprefix);
         ucCombo_zoncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_zoncod.SetProperty("DropDownOptionsData", AV45ZonCod_Data);
         ucCombo_zoncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_zoncod_Internalname, "COMBO_ZONCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZonCod_Internalname, "Codigo Zona", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 265,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ZonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A158ZonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,265);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZonCod_Jsonclick, 0, "Attribute", "", "", "", "", edtZonCod_Visible, edtZonCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliMon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliMon_Internalname, "Moneda Limite Credito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 270,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A614CliMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A614CliMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A614CliMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,270);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliVincula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliVincula_Internalname, "Cliente Vinculado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 275,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliVincula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A636CliVincula), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliVincula_Enabled!=0) ? context.localUtil.Format( (decimal)(A636CliVincula), "9") : context.localUtil.Format( (decimal)(A636CliVincula), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,275);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVincula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliVincula_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliRetencion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliRetencion_Internalname, "Cliente Afecto Retención", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 280,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRetencion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A626CliRetencion), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliRetencion_Enabled!=0) ? context.localUtil.Format( (decimal)(A626CliRetencion), "9") : context.localUtil.Format( (decimal)(A626CliRetencion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,280);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRetencion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRetencion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliPercepcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliPercepcion_Internalname, "Cliente Afecto Percepción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliPercepcion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A617CliPercepcion), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliPercepcion_Enabled!=0) ? context.localUtil.Format( (decimal)(A617CliPercepcion), "9") : context.localUtil.Format( (decimal)(A617CliPercepcion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,285);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliPercepcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliPercepcion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclitiplcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclitiplcod_Internalname, "Lista de Precios", "", "", lblTextblockclitiplcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clitiplcod.SetProperty("Caption", Combo_clitiplcod_Caption);
         ucCombo_clitiplcod.SetProperty("Cls", Combo_clitiplcod_Cls);
         ucCombo_clitiplcod.SetProperty("DataListProc", Combo_clitiplcod_Datalistproc);
         ucCombo_clitiplcod.SetProperty("DataListProcParametersPrefix", Combo_clitiplcod_Datalistprocparametersprefix);
         ucCombo_clitiplcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_clitiplcod.SetProperty("DropDownOptionsData", AV47CliTipLCod_Data);
         ucCombo_clitiplcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clitiplcod_Internalname, "COMBO_CLITIPLCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTipLCod_Internalname, "Lista de Precios", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 296,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A156CliTipLCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A156CliTipLCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,296);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCliTipLCod_Visible, edtCliTipLCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliNom_Internalname, "Nombres", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 301,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliNom_Internalname, A615CliNom, StringUtil.RTrim( context.localUtil.Format( A615CliNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,301);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliAPEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliAPEP_Internalname, "Apellido Paterno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 306,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliAPEP_Internalname, A574CliAPEP, StringUtil.RTrim( context.localUtil.Format( A574CliAPEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,306);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliAPEP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliAPEP_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliAPEM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliAPEM_Internalname, "Apellido Materno", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 311,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliAPEM_Internalname, A573CliAPEM, StringUtil.RTrim( context.localUtil.Format( A573CliAPEM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,311);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliAPEM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliAPEM_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipscod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipscod_Internalname, "Codigo Tipo Documento Sunat", "", "", lblTextblocktipscod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipscod.SetProperty("Caption", Combo_tipscod_Caption);
         ucCombo_tipscod.SetProperty("Cls", Combo_tipscod_Cls);
         ucCombo_tipscod.SetProperty("DataListProc", Combo_tipscod_Datalistproc);
         ucCombo_tipscod.SetProperty("DataListProcParametersPrefix", Combo_tipscod_Datalistprocparametersprefix);
         ucCombo_tipscod.SetProperty("EmptyItem", Combo_tipscod_Emptyitem);
         ucCombo_tipscod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_tipscod.SetProperty("DropDownOptionsData", AV50TipSCod_Data);
         ucCombo_tipscod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipscod_Internalname, "COMBO_TIPSCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipSCod_Internalname, "Codigo Tipo Documento Sunat", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 322,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157TipSCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A157TipSCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,322);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipSCod_Visible, edtTipSCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 327,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliUsuCod_Internalname, StringUtil.RTrim( A633CliUsuCod), StringUtil.RTrim( context.localUtil.Format( A633CliUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,327);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliUsuFec_Internalname, "Usuario Fecha", "col-sm-3 AttributeDateTimeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 332,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCliUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCliUsuFec_Internalname, context.localUtil.TToC( A634CliUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A634CliUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,332);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliUsuFec_Jsonclick, 0, "AttributeDateTime", "", "", "", "", 1, edtCliUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_bitmap( context, edtCliUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCliUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas\\Clientes.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliEMAPer_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliEMAPer_Internalname, "E-Mail Percepción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 337,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliEMAPer_Internalname, A610CliEMAPer, StringUtil.RTrim( context.localUtil.Format( A610CliEMAPer, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,337);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliEMAPer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliEMAPer_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliPassPer_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliPassPer_Internalname, "Password Percepción", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 342,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliPassPer_Internalname, A616CliPassPer, StringUtil.RTrim( context.localUtil.Format( A616CliPassPer, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,342);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliPassPer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliPassPer_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliTCon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTCon_Internalname, "Contactos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 347,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTCon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A628CliTCon), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliTCon_Enabled!=0) ? context.localUtil.Format( (decimal)(A628CliTCon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A628CliTCon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,347);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTCon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTCon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliDireccionLarga_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliDireccionLarga_Internalname, "Larga", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCliDireccionLarga_Internalname, A601CliDireccionLarga, "", "", 0, 1, edtCliDireccionLarga_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliTipCod_Internalname, "Documento Default", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 357,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTipCod_Internalname, StringUtil.RTrim( A631CliTipCod), StringUtil.RTrim( context.localUtil.Format( A631CliTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,357);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliDTAval_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliDTAval_Internalname, "Aval", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 362,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDTAval_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A608CliDTAval), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliDTAval_Enabled!=0) ? context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9") : context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,362);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDTAval_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDTAval_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_level2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "left", "top", "", "", "div");
         gxdraw_Gridlevel_level2( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 395,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 397,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 399,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\Clientes.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_estcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboestcod_Internalname, StringUtil.RTrim( AV28ComboEstCod), StringUtil.RTrim( context.localUtil.Format( AV28ComboEstCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboestcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboestcod_Visible, edtavComboestcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_paicod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombopaicod_Internalname, StringUtil.RTrim( AV31ComboPaiCod), StringUtil.RTrim( context.localUtil.Format( AV31ComboPaiCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopaicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopaicod_Visible, edtavCombopaicod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_tipccod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotipccod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33ComboTipCCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotipccod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV33ComboTipCCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV33ComboTipCCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipccod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipccod_Visible, edtavCombotipccod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_conpcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboconpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ComboConpcod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavComboconpcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV35ComboConpcod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV35ComboConpcod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboconpcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboconpcod_Visible, edtavComboconpcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_clivend_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboclivend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ComboCliVend), 6, 0, ".", "")), StringUtil.LTrim( ((edtavComboclivend_Enabled!=0) ? context.localUtil.Format( (decimal)(AV37ComboCliVend), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV37ComboCliVend), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclivend_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclivend_Visible, edtavComboclivend_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_discod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodiscod_Internalname, StringUtil.RTrim( AV40ComboDisCod), StringUtil.RTrim( context.localUtil.Format( AV40ComboDisCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodiscod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodiscod_Visible, edtavCombodiscod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_provcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprovcod_Internalname, StringUtil.RTrim( AV44ComboProvCod), StringUtil.RTrim( context.localUtil.Format( AV44ComboProvCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprovcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprovcod_Visible, edtavComboprovcod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_zoncod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombozoncod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46ComboZonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombozoncod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV46ComboZonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV46ComboZonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombozoncod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombozoncod_Visible, edtavCombozoncod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         drawControls2( ) ;
      }

      protected void drawControls2( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_clitiplcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboclitiplcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48ComboCliTipLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavComboclitiplcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48ComboCliTipLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV48ComboCliTipLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclitiplcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclitiplcod_Visible, edtavComboclitiplcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_tipscod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotipscod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51ComboTipSCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotipscod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV51ComboTipSCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV51ComboTipSCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipscod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipscod_Visible, edtavCombotipscod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas\\Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* User Defined Control */
         ucCombo_clidirzoncod.SetProperty("Caption", Combo_clidirzoncod_Caption);
         ucCombo_clidirzoncod.SetProperty("Cls", Combo_clidirzoncod_Cls);
         ucCombo_clidirzoncod.SetProperty("IsGridItem", Combo_clidirzoncod_Isgriditem);
         ucCombo_clidirzoncod.SetProperty("HasDescription", Combo_clidirzoncod_Hasdescription);
         ucCombo_clidirzoncod.SetProperty("DataListProc", Combo_clidirzoncod_Datalistproc);
         ucCombo_clidirzoncod.SetProperty("DataListProcParametersPrefix", Combo_clidirzoncod_Datalistprocparametersprefix);
         ucCombo_clidirzoncod.SetProperty("EmptyItem", Combo_clidirzoncod_Emptyitem);
         ucCombo_clidirzoncod.SetProperty("DropDownOptionsTitleSettingsIcons", AV23DDO_TitleSettingsIcons);
         ucCombo_clidirzoncod.SetProperty("DropDownOptionsData", AV22CliDirZonCod_Data);
         ucCombo_clidirzoncod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clidirzoncod_Internalname, "COMBO_CLIDIRZONCODContainer");
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
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A164CliDirItem), 6, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirItem_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A600CliDirDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A598CliDirDir));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDir_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A605CliDirPais));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirPais_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A597CliDirDep));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDep_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A606CliDirProv));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirProv_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A599CliDirDis));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDis_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Column.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtCliDirZonCod_Horizontalalignment));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A607CliDirZonDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowselection), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_368_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount83 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_83 = 1;
               ScanStart7O83( ) ;
               while ( RcdFound83 != 0 )
               {
                  init_level_properties83( ) ;
                  getByPrimaryKey7O83( ) ;
                  AddRow7O83( ) ;
                  ScanNext7O83( ) ;
               }
               ScanEnd7O83( ) ;
               nBlankRcdCount83 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7O83( ) ;
            standaloneModal7O83( ) ;
            sMode83 = Gx_mode;
            while ( nGXsfl_368_idx < nRC_GXsfl_368 )
            {
               bGXsfl_368_Refreshing = true;
               ReadRow7O83( ) ;
               edtCliDirItem_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRITEM_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDSC_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDsc_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirDir_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDIR_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDir_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirPais_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRPAIS_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirPais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirPais_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirDep_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDEP_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirDep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDep_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirProv_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRPROV_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirProv_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirDis_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDIS_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirDis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDis_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirZonCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonCod_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               edtCliDirZonCod_Horizontalalignment = cgiGet( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Horizontalalignment");
               AssignProp("", false, edtCliDirZonCod_Internalname, "Horizontalalignment", edtCliDirZonCod_Horizontalalignment, !bGXsfl_368_Refreshing);
               edtCliDirZonDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRZONDSC_"+sGXsfl_368_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDirZonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonDsc_Enabled), 5, 0), !bGXsfl_368_Refreshing);
               if ( ( nRcdExists_83 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7O83( ) ;
               }
               SendRow7O83( ) ;
               bGXsfl_368_Refreshing = false;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount83 = 5;
            nRcdExists_83 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7O83( ) ;
               while ( RcdFound83 != 0 )
               {
                  sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_36883( ) ;
                  init_level_properties83( ) ;
                  standaloneNotModal7O83( ) ;
                  getByPrimaryKey7O83( ) ;
                  standaloneModal7O83( ) ;
                  AddRow7O83( ) ;
                  ScanNext7O83( ) ;
               }
               ScanEnd7O83( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode83 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx+1), 4, 0), 4, "0");
            SubsflControlProps_36883( ) ;
            InitAll7O83( ) ;
            init_level_properties83( ) ;
            nRcdExists_83 = 0;
            nIsMod_83 = 0;
            nRcdDeleted_83 = 0;
            nBlankRcdCount83 = (short)(nBlankRcdUsr83+nBlankRcdCount83);
            fRowAdded = 0;
            while ( nBlankRcdCount83 > 0 )
            {
               standaloneNotModal7O83( ) ;
               standaloneModal7O83( ) ;
               AddRow7O83( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCliDirItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount83 = (short)(nBlankRcdCount83-1);
            }
            Gx_mode = sMode83;
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

      protected void gxdraw_Gridlevel_level2( )
      {
         /*  Grid Control  */
         Gridlevel_level2Container.AddObjectProperty("GridName", "Gridlevel_level2");
         Gridlevel_level2Container.AddObjectProperty("Header", subGridlevel_level2_Header);
         Gridlevel_level2Container.AddObjectProperty("Class", "WorkWith");
         Gridlevel_level2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("CmpContext", "");
         Gridlevel_level2Container.AddObjectProperty("InMasterPage", "false");
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A163CliConCod), 6, 0, ".", "")));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.RTrim( A578CliConDsc));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.RTrim( A577CliConCargo));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCargo_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.RTrim( A586CliConTelf));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConTelf_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.RTrim( A576CliConArea));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConArea_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", A579CliConMail);
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMail_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", "")));
         Gridlevel_level2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMailFE_Enabled), 5, 0, ".", "")));
         Gridlevel_level2Container.AddColumnProperties(Gridlevel_level2Column);
         Gridlevel_level2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Allowselection), 1, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level2_Collapsed), 1, 0, ".", "")));
         nGXsfl_383_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount13 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_13 = 1;
               ScanStart7O13( ) ;
               while ( RcdFound13 != 0 )
               {
                  init_level_properties13( ) ;
                  getByPrimaryKey7O13( ) ;
                  AddRow7O13( ) ;
                  ScanNext7O13( ) ;
               }
               ScanEnd7O13( ) ;
               nBlankRcdCount13 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal7O13( ) ;
            standaloneModal7O13( ) ;
            sMode13 = Gx_mode;
            while ( nGXsfl_383_idx < nRC_GXsfl_383 )
            {
               bGXsfl_383_Refreshing = true;
               ReadRow7O13( ) ;
               edtCliConCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONCOD_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONDSC_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConDsc_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConCargo_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONCARGO_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCargo_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConTelf_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONTELF_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConTelf_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConArea_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONAREA_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConArea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConArea_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConMail_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONMAIL_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMail_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               edtCliConMailFE_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONMAILFE_"+sGXsfl_383_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliConMailFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMailFE_Enabled), 5, 0), !bGXsfl_383_Refreshing);
               if ( ( nRcdExists_13 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal7O13( ) ;
               }
               SendRow7O13( ) ;
               bGXsfl_383_Refreshing = false;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount13 = 5;
            nRcdExists_13 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart7O13( ) ;
               while ( RcdFound13 != 0 )
               {
                  sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_38313( ) ;
                  init_level_properties13( ) ;
                  standaloneNotModal7O13( ) ;
                  getByPrimaryKey7O13( ) ;
                  standaloneModal7O13( ) ;
                  AddRow7O13( ) ;
                  ScanNext7O13( ) ;
               }
               ScanEnd7O13( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode13 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx+1), 4, 0), 4, "0");
            SubsflControlProps_38313( ) ;
            InitAll7O13( ) ;
            init_level_properties13( ) ;
            nRcdExists_13 = 0;
            nIsMod_13 = 0;
            nRcdDeleted_13 = 0;
            nBlankRcdCount13 = (short)(nBlankRcdUsr13+nBlankRcdCount13);
            fRowAdded = 0;
            while ( nBlankRcdCount13 > 0 )
            {
               standaloneNotModal7O13( ) ;
               standaloneModal7O13( ) ;
               AddRow7O13( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCliConCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount13 = (short)(nBlankRcdCount13-1);
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_level2Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_level2", Gridlevel_level2Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level2ContainerData", Gridlevel_level2Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_level2ContainerData"+"V", Gridlevel_level2Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_level2ContainerData"+"V"+"\" value='"+Gridlevel_level2Container.GridValuesHidden()+"'/>") ;
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
         E117O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV23DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vESTCOD_DATA"), AV27EstCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPAICOD_DATA"), AV30PaiCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPCCOD_DATA"), AV32TipCCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCONPCOD_DATA"), AV34Conpcod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIVEND_DATA"), AV36CliVend_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vDISCOD_DATA"), AV39DisCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROVCOD_DATA"), AV43ProvCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vZONCOD_DATA"), AV45ZonCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCLITIPLCOD_DATA"), AV47CliTipLCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPSCOD_DATA"), AV50TipSCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIDIRZONCOD_DATA"), AV22CliDirZonCod_Data);
               /* Read saved values. */
               Z45CliCod = cgiGet( "Z45CliCod");
               Z161CliDsc = cgiGet( "Z161CliDsc");
               Z596CliDir = cgiGet( "Z596CliDir");
               Z629CliTel1 = cgiGet( "Z629CliTel1");
               Z630CliTel2 = cgiGet( "Z630CliTel2");
               Z611CliFax = cgiGet( "Z611CliFax");
               Z575CliCel = cgiGet( "Z575CliCel");
               Z609CliEma = cgiGet( "Z609CliEma");
               Z637CliWeb = cgiGet( "Z637CliWeb");
               Z627CliSts = (short)(context.localUtil.CToN( cgiGet( "Z627CliSts"), ".", ","));
               Z613CliLim = context.localUtil.CToN( cgiGet( "Z613CliLim"), ".", ",");
               Z618CliRef1 = cgiGet( "Z618CliRef1");
               Z619CliRef2 = cgiGet( "Z619CliRef2");
               Z620CliRef3 = cgiGet( "Z620CliRef3");
               Z621CliRef4 = cgiGet( "Z621CliRef4");
               Z622CliRef5 = cgiGet( "Z622CliRef5");
               Z623CliRef6 = cgiGet( "Z623CliRef6");
               Z624CliRef7 = cgiGet( "Z624CliRef7");
               Z625CliRef8 = cgiGet( "Z625CliRef8");
               Z581CliCont1 = cgiGet( "Z581CliCont1");
               Z587CliCTel1 = cgiGet( "Z587CliCTel1");
               Z582CliCont2 = cgiGet( "Z582CliCont2");
               Z588CliCTel2 = cgiGet( "Z588CliCTel2");
               Z583CliCont3 = cgiGet( "Z583CliCont3");
               Z589CliCtel3 = cgiGet( "Z589CliCtel3");
               Z584CliCont4 = cgiGet( "Z584CliCont4");
               Z590CliCTel4 = cgiGet( "Z590CliCTel4");
               Z585CliCont5 = cgiGet( "Z585CliCont5");
               Z591CliCtel5 = cgiGet( "Z591CliCtel5");
               Z632CliTItemDir = (int)(context.localUtil.CToN( cgiGet( "Z632CliTItemDir"), ".", ","));
               Z614CliMon = (int)(context.localUtil.CToN( cgiGet( "Z614CliMon"), ".", ","));
               Z636CliVincula = (short)(context.localUtil.CToN( cgiGet( "Z636CliVincula"), ".", ","));
               Z626CliRetencion = (short)(context.localUtil.CToN( cgiGet( "Z626CliRetencion"), ".", ","));
               Z617CliPercepcion = (short)(context.localUtil.CToN( cgiGet( "Z617CliPercepcion"), ".", ","));
               Z615CliNom = cgiGet( "Z615CliNom");
               Z574CliAPEP = cgiGet( "Z574CliAPEP");
               Z573CliAPEM = cgiGet( "Z573CliAPEM");
               Z633CliUsuCod = cgiGet( "Z633CliUsuCod");
               Z634CliUsuFec = context.localUtil.CToT( cgiGet( "Z634CliUsuFec"), 0);
               Z610CliEMAPer = cgiGet( "Z610CliEMAPer");
               Z616CliPassPer = cgiGet( "Z616CliPassPer");
               Z628CliTCon = (int)(context.localUtil.CToN( cgiGet( "Z628CliTCon"), ".", ","));
               Z631CliTipCod = cgiGet( "Z631CliTipCod");
               Z608CliDTAval = (int)(context.localUtil.CToN( cgiGet( "Z608CliDTAval"), ".", ","));
               Z139PaiCod = cgiGet( "Z139PaiCod");
               Z140EstCod = cgiGet( "Z140EstCod");
               Z141ProvCod = cgiGet( "Z141ProvCod");
               Z142DisCod = cgiGet( "Z142DisCod");
               Z159TipCCod = (int)(context.localUtil.CToN( cgiGet( "Z159TipCCod"), ".", ","));
               Z137Conpcod = (int)(context.localUtil.CToN( cgiGet( "Z137Conpcod"), ".", ","));
               Z158ZonCod = (int)(context.localUtil.CToN( cgiGet( "Z158ZonCod"), ".", ","));
               n158ZonCod = ((0==A158ZonCod) ? true : false);
               Z157TipSCod = (int)(context.localUtil.CToN( cgiGet( "Z157TipSCod"), ".", ","));
               Z160CliVend = (int)(context.localUtil.CToN( cgiGet( "Z160CliVend"), ".", ","));
               Z156CliTipLCod = (int)(context.localUtil.CToN( cgiGet( "Z156CliTipLCod"), ".", ","));
               n156CliTipLCod = ((0==A156CliTipLCod) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_368 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_368"), ".", ","));
               nRC_GXsfl_383 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_383"), ".", ","));
               N140EstCod = cgiGet( "N140EstCod");
               N139PaiCod = cgiGet( "N139PaiCod");
               N159TipCCod = (int)(context.localUtil.CToN( cgiGet( "N159TipCCod"), ".", ","));
               N137Conpcod = (int)(context.localUtil.CToN( cgiGet( "N137Conpcod"), ".", ","));
               N160CliVend = (int)(context.localUtil.CToN( cgiGet( "N160CliVend"), ".", ","));
               N142DisCod = cgiGet( "N142DisCod");
               N141ProvCod = cgiGet( "N141ProvCod");
               N158ZonCod = (int)(context.localUtil.CToN( cgiGet( "N158ZonCod"), ".", ","));
               n158ZonCod = ((0==A158ZonCod) ? true : false);
               N156CliTipLCod = (int)(context.localUtil.CToN( cgiGet( "N156CliTipLCod"), ".", ","));
               n156CliTipLCod = ((0==A156CliTipLCod) ? true : false);
               N157TipSCod = (int)(context.localUtil.CToN( cgiGet( "N157TipSCod"), ".", ","));
               AV41Cond_EstCod = cgiGet( "vCOND_ESTCOD");
               AV29Cond_PaiCod = cgiGet( "vCOND_PAICOD");
               AV42Cond_ProvCod = cgiGet( "vCOND_PROVCOD");
               A602EstDsc = cgiGet( "ESTDSC");
               A603ProvDsc = cgiGet( "PROVDSC");
               A604DisDsc = cgiGet( "DISDSC");
               AV7CliCod = cgiGet( "vCLICOD");
               AV11Insert_EstCod = cgiGet( "vINSERT_ESTCOD");
               AV12Insert_PaiCod = cgiGet( "vINSERT_PAICOD");
               AV13Insert_TipCCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TIPCCOD"), ".", ","));
               AV14Insert_Conpcod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CONPCOD"), ".", ","));
               AV15Insert_CliVend = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CLIVEND"), ".", ","));
               AV16Insert_DisCod = cgiGet( "vINSERT_DISCOD");
               AV17Insert_ProvCod = cgiGet( "vINSERT_PROVCOD");
               AV18Insert_ZonCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_ZONCOD"), ".", ","));
               AV19Insert_CliTipLCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CLITIPLCOD"), ".", ","));
               AV20Insert_TipSCod = (int)(context.localUtil.CToN( cgiGet( "vINSERT_TIPSCOD"), ".", ","));
               A40000CliFoto_GXI = cgiGet( "CLIFOTO_GXI");
               n40000CliFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
               AV52Pgmname = cgiGet( "vPGMNAME");
               Combo_estcod_Objectcall = cgiGet( "COMBO_ESTCOD_Objectcall");
               Combo_estcod_Class = cgiGet( "COMBO_ESTCOD_Class");
               Combo_estcod_Icontype = cgiGet( "COMBO_ESTCOD_Icontype");
               Combo_estcod_Icon = cgiGet( "COMBO_ESTCOD_Icon");
               Combo_estcod_Caption = cgiGet( "COMBO_ESTCOD_Caption");
               Combo_estcod_Tooltip = cgiGet( "COMBO_ESTCOD_Tooltip");
               Combo_estcod_Cls = cgiGet( "COMBO_ESTCOD_Cls");
               Combo_estcod_Selectedvalue_set = cgiGet( "COMBO_ESTCOD_Selectedvalue_set");
               Combo_estcod_Selectedvalue_get = cgiGet( "COMBO_ESTCOD_Selectedvalue_get");
               Combo_estcod_Selectedtext_set = cgiGet( "COMBO_ESTCOD_Selectedtext_set");
               Combo_estcod_Selectedtext_get = cgiGet( "COMBO_ESTCOD_Selectedtext_get");
               Combo_estcod_Gamoauthtoken = cgiGet( "COMBO_ESTCOD_Gamoauthtoken");
               Combo_estcod_Ddointernalname = cgiGet( "COMBO_ESTCOD_Ddointernalname");
               Combo_estcod_Titlecontrolalign = cgiGet( "COMBO_ESTCOD_Titlecontrolalign");
               Combo_estcod_Dropdownoptionstype = cgiGet( "COMBO_ESTCOD_Dropdownoptionstype");
               Combo_estcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Enabled"));
               Combo_estcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Visible"));
               Combo_estcod_Titlecontrolidtoreplace = cgiGet( "COMBO_ESTCOD_Titlecontrolidtoreplace");
               Combo_estcod_Datalisttype = cgiGet( "COMBO_ESTCOD_Datalisttype");
               Combo_estcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Allowmultipleselection"));
               Combo_estcod_Datalistfixedvalues = cgiGet( "COMBO_ESTCOD_Datalistfixedvalues");
               Combo_estcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Isgriditem"));
               Combo_estcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Hasdescription"));
               Combo_estcod_Datalistproc = cgiGet( "COMBO_ESTCOD_Datalistproc");
               Combo_estcod_Datalistprocparametersprefix = cgiGet( "COMBO_ESTCOD_Datalistprocparametersprefix");
               Combo_estcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_ESTCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_estcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeonlyselectedoption"));
               Combo_estcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeselectalloption"));
               Combo_estcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Emptyitem"));
               Combo_estcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ESTCOD_Includeaddnewoption"));
               Combo_estcod_Htmltemplate = cgiGet( "COMBO_ESTCOD_Htmltemplate");
               Combo_estcod_Multiplevaluestype = cgiGet( "COMBO_ESTCOD_Multiplevaluestype");
               Combo_estcod_Loadingdata = cgiGet( "COMBO_ESTCOD_Loadingdata");
               Combo_estcod_Noresultsfound = cgiGet( "COMBO_ESTCOD_Noresultsfound");
               Combo_estcod_Emptyitemtext = cgiGet( "COMBO_ESTCOD_Emptyitemtext");
               Combo_estcod_Onlyselectedvalues = cgiGet( "COMBO_ESTCOD_Onlyselectedvalues");
               Combo_estcod_Selectalltext = cgiGet( "COMBO_ESTCOD_Selectalltext");
               Combo_estcod_Multiplevaluesseparator = cgiGet( "COMBO_ESTCOD_Multiplevaluesseparator");
               Combo_estcod_Addnewoptiontext = cgiGet( "COMBO_ESTCOD_Addnewoptiontext");
               Combo_estcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_ESTCOD_Gxcontroltype"), ".", ","));
               Combo_paicod_Objectcall = cgiGet( "COMBO_PAICOD_Objectcall");
               Combo_paicod_Class = cgiGet( "COMBO_PAICOD_Class");
               Combo_paicod_Icontype = cgiGet( "COMBO_PAICOD_Icontype");
               Combo_paicod_Icon = cgiGet( "COMBO_PAICOD_Icon");
               Combo_paicod_Caption = cgiGet( "COMBO_PAICOD_Caption");
               Combo_paicod_Tooltip = cgiGet( "COMBO_PAICOD_Tooltip");
               Combo_paicod_Cls = cgiGet( "COMBO_PAICOD_Cls");
               Combo_paicod_Selectedvalue_set = cgiGet( "COMBO_PAICOD_Selectedvalue_set");
               Combo_paicod_Selectedvalue_get = cgiGet( "COMBO_PAICOD_Selectedvalue_get");
               Combo_paicod_Selectedtext_set = cgiGet( "COMBO_PAICOD_Selectedtext_set");
               Combo_paicod_Selectedtext_get = cgiGet( "COMBO_PAICOD_Selectedtext_get");
               Combo_paicod_Gamoauthtoken = cgiGet( "COMBO_PAICOD_Gamoauthtoken");
               Combo_paicod_Ddointernalname = cgiGet( "COMBO_PAICOD_Ddointernalname");
               Combo_paicod_Titlecontrolalign = cgiGet( "COMBO_PAICOD_Titlecontrolalign");
               Combo_paicod_Dropdownoptionstype = cgiGet( "COMBO_PAICOD_Dropdownoptionstype");
               Combo_paicod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Enabled"));
               Combo_paicod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Visible"));
               Combo_paicod_Titlecontrolidtoreplace = cgiGet( "COMBO_PAICOD_Titlecontrolidtoreplace");
               Combo_paicod_Datalisttype = cgiGet( "COMBO_PAICOD_Datalisttype");
               Combo_paicod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Allowmultipleselection"));
               Combo_paicod_Datalistfixedvalues = cgiGet( "COMBO_PAICOD_Datalistfixedvalues");
               Combo_paicod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Isgriditem"));
               Combo_paicod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Hasdescription"));
               Combo_paicod_Datalistproc = cgiGet( "COMBO_PAICOD_Datalistproc");
               Combo_paicod_Datalistprocparametersprefix = cgiGet( "COMBO_PAICOD_Datalistprocparametersprefix");
               Combo_paicod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_paicod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeonlyselectedoption"));
               Combo_paicod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeselectalloption"));
               Combo_paicod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Emptyitem"));
               Combo_paicod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PAICOD_Includeaddnewoption"));
               Combo_paicod_Htmltemplate = cgiGet( "COMBO_PAICOD_Htmltemplate");
               Combo_paicod_Multiplevaluestype = cgiGet( "COMBO_PAICOD_Multiplevaluestype");
               Combo_paicod_Loadingdata = cgiGet( "COMBO_PAICOD_Loadingdata");
               Combo_paicod_Noresultsfound = cgiGet( "COMBO_PAICOD_Noresultsfound");
               Combo_paicod_Emptyitemtext = cgiGet( "COMBO_PAICOD_Emptyitemtext");
               Combo_paicod_Onlyselectedvalues = cgiGet( "COMBO_PAICOD_Onlyselectedvalues");
               Combo_paicod_Selectalltext = cgiGet( "COMBO_PAICOD_Selectalltext");
               Combo_paicod_Multiplevaluesseparator = cgiGet( "COMBO_PAICOD_Multiplevaluesseparator");
               Combo_paicod_Addnewoptiontext = cgiGet( "COMBO_PAICOD_Addnewoptiontext");
               Combo_paicod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PAICOD_Gxcontroltype"), ".", ","));
               Combo_tipccod_Objectcall = cgiGet( "COMBO_TIPCCOD_Objectcall");
               Combo_tipccod_Class = cgiGet( "COMBO_TIPCCOD_Class");
               Combo_tipccod_Icontype = cgiGet( "COMBO_TIPCCOD_Icontype");
               Combo_tipccod_Icon = cgiGet( "COMBO_TIPCCOD_Icon");
               Combo_tipccod_Caption = cgiGet( "COMBO_TIPCCOD_Caption");
               Combo_tipccod_Tooltip = cgiGet( "COMBO_TIPCCOD_Tooltip");
               Combo_tipccod_Cls = cgiGet( "COMBO_TIPCCOD_Cls");
               Combo_tipccod_Selectedvalue_set = cgiGet( "COMBO_TIPCCOD_Selectedvalue_set");
               Combo_tipccod_Selectedvalue_get = cgiGet( "COMBO_TIPCCOD_Selectedvalue_get");
               Combo_tipccod_Selectedtext_set = cgiGet( "COMBO_TIPCCOD_Selectedtext_set");
               Combo_tipccod_Selectedtext_get = cgiGet( "COMBO_TIPCCOD_Selectedtext_get");
               Combo_tipccod_Gamoauthtoken = cgiGet( "COMBO_TIPCCOD_Gamoauthtoken");
               Combo_tipccod_Ddointernalname = cgiGet( "COMBO_TIPCCOD_Ddointernalname");
               Combo_tipccod_Titlecontrolalign = cgiGet( "COMBO_TIPCCOD_Titlecontrolalign");
               Combo_tipccod_Dropdownoptionstype = cgiGet( "COMBO_TIPCCOD_Dropdownoptionstype");
               Combo_tipccod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Enabled"));
               Combo_tipccod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Visible"));
               Combo_tipccod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPCCOD_Titlecontrolidtoreplace");
               Combo_tipccod_Datalisttype = cgiGet( "COMBO_TIPCCOD_Datalisttype");
               Combo_tipccod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Allowmultipleselection"));
               Combo_tipccod_Datalistfixedvalues = cgiGet( "COMBO_TIPCCOD_Datalistfixedvalues");
               Combo_tipccod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Isgriditem"));
               Combo_tipccod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Hasdescription"));
               Combo_tipccod_Datalistproc = cgiGet( "COMBO_TIPCCOD_Datalistproc");
               Combo_tipccod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPCCOD_Datalistprocparametersprefix");
               Combo_tipccod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPCCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipccod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Includeonlyselectedoption"));
               Combo_tipccod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Includeselectalloption"));
               Combo_tipccod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Emptyitem"));
               Combo_tipccod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPCCOD_Includeaddnewoption"));
               Combo_tipccod_Htmltemplate = cgiGet( "COMBO_TIPCCOD_Htmltemplate");
               Combo_tipccod_Multiplevaluestype = cgiGet( "COMBO_TIPCCOD_Multiplevaluestype");
               Combo_tipccod_Loadingdata = cgiGet( "COMBO_TIPCCOD_Loadingdata");
               Combo_tipccod_Noresultsfound = cgiGet( "COMBO_TIPCCOD_Noresultsfound");
               Combo_tipccod_Emptyitemtext = cgiGet( "COMBO_TIPCCOD_Emptyitemtext");
               Combo_tipccod_Onlyselectedvalues = cgiGet( "COMBO_TIPCCOD_Onlyselectedvalues");
               Combo_tipccod_Selectalltext = cgiGet( "COMBO_TIPCCOD_Selectalltext");
               Combo_tipccod_Multiplevaluesseparator = cgiGet( "COMBO_TIPCCOD_Multiplevaluesseparator");
               Combo_tipccod_Addnewoptiontext = cgiGet( "COMBO_TIPCCOD_Addnewoptiontext");
               Combo_tipccod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPCCOD_Gxcontroltype"), ".", ","));
               Combo_conpcod_Objectcall = cgiGet( "COMBO_CONPCOD_Objectcall");
               Combo_conpcod_Class = cgiGet( "COMBO_CONPCOD_Class");
               Combo_conpcod_Icontype = cgiGet( "COMBO_CONPCOD_Icontype");
               Combo_conpcod_Icon = cgiGet( "COMBO_CONPCOD_Icon");
               Combo_conpcod_Caption = cgiGet( "COMBO_CONPCOD_Caption");
               Combo_conpcod_Tooltip = cgiGet( "COMBO_CONPCOD_Tooltip");
               Combo_conpcod_Cls = cgiGet( "COMBO_CONPCOD_Cls");
               Combo_conpcod_Selectedvalue_set = cgiGet( "COMBO_CONPCOD_Selectedvalue_set");
               Combo_conpcod_Selectedvalue_get = cgiGet( "COMBO_CONPCOD_Selectedvalue_get");
               Combo_conpcod_Selectedtext_set = cgiGet( "COMBO_CONPCOD_Selectedtext_set");
               Combo_conpcod_Selectedtext_get = cgiGet( "COMBO_CONPCOD_Selectedtext_get");
               Combo_conpcod_Gamoauthtoken = cgiGet( "COMBO_CONPCOD_Gamoauthtoken");
               Combo_conpcod_Ddointernalname = cgiGet( "COMBO_CONPCOD_Ddointernalname");
               Combo_conpcod_Titlecontrolalign = cgiGet( "COMBO_CONPCOD_Titlecontrolalign");
               Combo_conpcod_Dropdownoptionstype = cgiGet( "COMBO_CONPCOD_Dropdownoptionstype");
               Combo_conpcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Enabled"));
               Combo_conpcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Visible"));
               Combo_conpcod_Titlecontrolidtoreplace = cgiGet( "COMBO_CONPCOD_Titlecontrolidtoreplace");
               Combo_conpcod_Datalisttype = cgiGet( "COMBO_CONPCOD_Datalisttype");
               Combo_conpcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Allowmultipleselection"));
               Combo_conpcod_Datalistfixedvalues = cgiGet( "COMBO_CONPCOD_Datalistfixedvalues");
               Combo_conpcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Isgriditem"));
               Combo_conpcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Hasdescription"));
               Combo_conpcod_Datalistproc = cgiGet( "COMBO_CONPCOD_Datalistproc");
               Combo_conpcod_Datalistprocparametersprefix = cgiGet( "COMBO_CONPCOD_Datalistprocparametersprefix");
               Combo_conpcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CONPCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_conpcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Includeonlyselectedoption"));
               Combo_conpcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Includeselectalloption"));
               Combo_conpcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Emptyitem"));
               Combo_conpcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CONPCOD_Includeaddnewoption"));
               Combo_conpcod_Htmltemplate = cgiGet( "COMBO_CONPCOD_Htmltemplate");
               Combo_conpcod_Multiplevaluestype = cgiGet( "COMBO_CONPCOD_Multiplevaluestype");
               Combo_conpcod_Loadingdata = cgiGet( "COMBO_CONPCOD_Loadingdata");
               Combo_conpcod_Noresultsfound = cgiGet( "COMBO_CONPCOD_Noresultsfound");
               Combo_conpcod_Emptyitemtext = cgiGet( "COMBO_CONPCOD_Emptyitemtext");
               Combo_conpcod_Onlyselectedvalues = cgiGet( "COMBO_CONPCOD_Onlyselectedvalues");
               Combo_conpcod_Selectalltext = cgiGet( "COMBO_CONPCOD_Selectalltext");
               Combo_conpcod_Multiplevaluesseparator = cgiGet( "COMBO_CONPCOD_Multiplevaluesseparator");
               Combo_conpcod_Addnewoptiontext = cgiGet( "COMBO_CONPCOD_Addnewoptiontext");
               Combo_conpcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CONPCOD_Gxcontroltype"), ".", ","));
               Combo_clivend_Objectcall = cgiGet( "COMBO_CLIVEND_Objectcall");
               Combo_clivend_Class = cgiGet( "COMBO_CLIVEND_Class");
               Combo_clivend_Icontype = cgiGet( "COMBO_CLIVEND_Icontype");
               Combo_clivend_Icon = cgiGet( "COMBO_CLIVEND_Icon");
               Combo_clivend_Caption = cgiGet( "COMBO_CLIVEND_Caption");
               Combo_clivend_Tooltip = cgiGet( "COMBO_CLIVEND_Tooltip");
               Combo_clivend_Cls = cgiGet( "COMBO_CLIVEND_Cls");
               Combo_clivend_Selectedvalue_set = cgiGet( "COMBO_CLIVEND_Selectedvalue_set");
               Combo_clivend_Selectedvalue_get = cgiGet( "COMBO_CLIVEND_Selectedvalue_get");
               Combo_clivend_Selectedtext_set = cgiGet( "COMBO_CLIVEND_Selectedtext_set");
               Combo_clivend_Selectedtext_get = cgiGet( "COMBO_CLIVEND_Selectedtext_get");
               Combo_clivend_Gamoauthtoken = cgiGet( "COMBO_CLIVEND_Gamoauthtoken");
               Combo_clivend_Ddointernalname = cgiGet( "COMBO_CLIVEND_Ddointernalname");
               Combo_clivend_Titlecontrolalign = cgiGet( "COMBO_CLIVEND_Titlecontrolalign");
               Combo_clivend_Dropdownoptionstype = cgiGet( "COMBO_CLIVEND_Dropdownoptionstype");
               Combo_clivend_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Enabled"));
               Combo_clivend_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Visible"));
               Combo_clivend_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIVEND_Titlecontrolidtoreplace");
               Combo_clivend_Datalisttype = cgiGet( "COMBO_CLIVEND_Datalisttype");
               Combo_clivend_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Allowmultipleselection"));
               Combo_clivend_Datalistfixedvalues = cgiGet( "COMBO_CLIVEND_Datalistfixedvalues");
               Combo_clivend_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Isgriditem"));
               Combo_clivend_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Hasdescription"));
               Combo_clivend_Datalistproc = cgiGet( "COMBO_CLIVEND_Datalistproc");
               Combo_clivend_Datalistprocparametersprefix = cgiGet( "COMBO_CLIVEND_Datalistprocparametersprefix");
               Combo_clivend_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLIVEND_Datalistupdateminimumcharacters"), ".", ","));
               Combo_clivend_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Includeonlyselectedoption"));
               Combo_clivend_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Includeselectalloption"));
               Combo_clivend_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Emptyitem"));
               Combo_clivend_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIVEND_Includeaddnewoption"));
               Combo_clivend_Htmltemplate = cgiGet( "COMBO_CLIVEND_Htmltemplate");
               Combo_clivend_Multiplevaluestype = cgiGet( "COMBO_CLIVEND_Multiplevaluestype");
               Combo_clivend_Loadingdata = cgiGet( "COMBO_CLIVEND_Loadingdata");
               Combo_clivend_Noresultsfound = cgiGet( "COMBO_CLIVEND_Noresultsfound");
               Combo_clivend_Emptyitemtext = cgiGet( "COMBO_CLIVEND_Emptyitemtext");
               Combo_clivend_Onlyselectedvalues = cgiGet( "COMBO_CLIVEND_Onlyselectedvalues");
               Combo_clivend_Selectalltext = cgiGet( "COMBO_CLIVEND_Selectalltext");
               Combo_clivend_Multiplevaluesseparator = cgiGet( "COMBO_CLIVEND_Multiplevaluesseparator");
               Combo_clivend_Addnewoptiontext = cgiGet( "COMBO_CLIVEND_Addnewoptiontext");
               Combo_clivend_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLIVEND_Gxcontroltype"), ".", ","));
               Combo_discod_Objectcall = cgiGet( "COMBO_DISCOD_Objectcall");
               Combo_discod_Class = cgiGet( "COMBO_DISCOD_Class");
               Combo_discod_Icontype = cgiGet( "COMBO_DISCOD_Icontype");
               Combo_discod_Icon = cgiGet( "COMBO_DISCOD_Icon");
               Combo_discod_Caption = cgiGet( "COMBO_DISCOD_Caption");
               Combo_discod_Tooltip = cgiGet( "COMBO_DISCOD_Tooltip");
               Combo_discod_Cls = cgiGet( "COMBO_DISCOD_Cls");
               Combo_discod_Selectedvalue_set = cgiGet( "COMBO_DISCOD_Selectedvalue_set");
               Combo_discod_Selectedvalue_get = cgiGet( "COMBO_DISCOD_Selectedvalue_get");
               Combo_discod_Selectedtext_set = cgiGet( "COMBO_DISCOD_Selectedtext_set");
               Combo_discod_Selectedtext_get = cgiGet( "COMBO_DISCOD_Selectedtext_get");
               Combo_discod_Gamoauthtoken = cgiGet( "COMBO_DISCOD_Gamoauthtoken");
               Combo_discod_Ddointernalname = cgiGet( "COMBO_DISCOD_Ddointernalname");
               Combo_discod_Titlecontrolalign = cgiGet( "COMBO_DISCOD_Titlecontrolalign");
               Combo_discod_Dropdownoptionstype = cgiGet( "COMBO_DISCOD_Dropdownoptionstype");
               Combo_discod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Enabled"));
               Combo_discod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Visible"));
               Combo_discod_Titlecontrolidtoreplace = cgiGet( "COMBO_DISCOD_Titlecontrolidtoreplace");
               Combo_discod_Datalisttype = cgiGet( "COMBO_DISCOD_Datalisttype");
               Combo_discod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Allowmultipleselection"));
               Combo_discod_Datalistfixedvalues = cgiGet( "COMBO_DISCOD_Datalistfixedvalues");
               Combo_discod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Isgriditem"));
               Combo_discod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Hasdescription"));
               Combo_discod_Datalistproc = cgiGet( "COMBO_DISCOD_Datalistproc");
               Combo_discod_Datalistprocparametersprefix = cgiGet( "COMBO_DISCOD_Datalistprocparametersprefix");
               Combo_discod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_DISCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_discod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeonlyselectedoption"));
               Combo_discod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeselectalloption"));
               Combo_discod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Emptyitem"));
               Combo_discod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DISCOD_Includeaddnewoption"));
               Combo_discod_Htmltemplate = cgiGet( "COMBO_DISCOD_Htmltemplate");
               Combo_discod_Multiplevaluestype = cgiGet( "COMBO_DISCOD_Multiplevaluestype");
               Combo_discod_Loadingdata = cgiGet( "COMBO_DISCOD_Loadingdata");
               Combo_discod_Noresultsfound = cgiGet( "COMBO_DISCOD_Noresultsfound");
               Combo_discod_Emptyitemtext = cgiGet( "COMBO_DISCOD_Emptyitemtext");
               Combo_discod_Onlyselectedvalues = cgiGet( "COMBO_DISCOD_Onlyselectedvalues");
               Combo_discod_Selectalltext = cgiGet( "COMBO_DISCOD_Selectalltext");
               Combo_discod_Multiplevaluesseparator = cgiGet( "COMBO_DISCOD_Multiplevaluesseparator");
               Combo_discod_Addnewoptiontext = cgiGet( "COMBO_DISCOD_Addnewoptiontext");
               Combo_discod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_DISCOD_Gxcontroltype"), ".", ","));
               Combo_provcod_Objectcall = cgiGet( "COMBO_PROVCOD_Objectcall");
               Combo_provcod_Class = cgiGet( "COMBO_PROVCOD_Class");
               Combo_provcod_Icontype = cgiGet( "COMBO_PROVCOD_Icontype");
               Combo_provcod_Icon = cgiGet( "COMBO_PROVCOD_Icon");
               Combo_provcod_Caption = cgiGet( "COMBO_PROVCOD_Caption");
               Combo_provcod_Tooltip = cgiGet( "COMBO_PROVCOD_Tooltip");
               Combo_provcod_Cls = cgiGet( "COMBO_PROVCOD_Cls");
               Combo_provcod_Selectedvalue_set = cgiGet( "COMBO_PROVCOD_Selectedvalue_set");
               Combo_provcod_Selectedvalue_get = cgiGet( "COMBO_PROVCOD_Selectedvalue_get");
               Combo_provcod_Selectedtext_set = cgiGet( "COMBO_PROVCOD_Selectedtext_set");
               Combo_provcod_Selectedtext_get = cgiGet( "COMBO_PROVCOD_Selectedtext_get");
               Combo_provcod_Gamoauthtoken = cgiGet( "COMBO_PROVCOD_Gamoauthtoken");
               Combo_provcod_Ddointernalname = cgiGet( "COMBO_PROVCOD_Ddointernalname");
               Combo_provcod_Titlecontrolalign = cgiGet( "COMBO_PROVCOD_Titlecontrolalign");
               Combo_provcod_Dropdownoptionstype = cgiGet( "COMBO_PROVCOD_Dropdownoptionstype");
               Combo_provcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Enabled"));
               Combo_provcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Visible"));
               Combo_provcod_Titlecontrolidtoreplace = cgiGet( "COMBO_PROVCOD_Titlecontrolidtoreplace");
               Combo_provcod_Datalisttype = cgiGet( "COMBO_PROVCOD_Datalisttype");
               Combo_provcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Allowmultipleselection"));
               Combo_provcod_Datalistfixedvalues = cgiGet( "COMBO_PROVCOD_Datalistfixedvalues");
               Combo_provcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Isgriditem"));
               Combo_provcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Hasdescription"));
               Combo_provcod_Datalistproc = cgiGet( "COMBO_PROVCOD_Datalistproc");
               Combo_provcod_Datalistprocparametersprefix = cgiGet( "COMBO_PROVCOD_Datalistprocparametersprefix");
               Combo_provcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PROVCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_provcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeonlyselectedoption"));
               Combo_provcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeselectalloption"));
               Combo_provcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Emptyitem"));
               Combo_provcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROVCOD_Includeaddnewoption"));
               Combo_provcod_Htmltemplate = cgiGet( "COMBO_PROVCOD_Htmltemplate");
               Combo_provcod_Multiplevaluestype = cgiGet( "COMBO_PROVCOD_Multiplevaluestype");
               Combo_provcod_Loadingdata = cgiGet( "COMBO_PROVCOD_Loadingdata");
               Combo_provcod_Noresultsfound = cgiGet( "COMBO_PROVCOD_Noresultsfound");
               Combo_provcod_Emptyitemtext = cgiGet( "COMBO_PROVCOD_Emptyitemtext");
               Combo_provcod_Onlyselectedvalues = cgiGet( "COMBO_PROVCOD_Onlyselectedvalues");
               Combo_provcod_Selectalltext = cgiGet( "COMBO_PROVCOD_Selectalltext");
               Combo_provcod_Multiplevaluesseparator = cgiGet( "COMBO_PROVCOD_Multiplevaluesseparator");
               Combo_provcod_Addnewoptiontext = cgiGet( "COMBO_PROVCOD_Addnewoptiontext");
               Combo_provcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PROVCOD_Gxcontroltype"), ".", ","));
               Combo_zoncod_Objectcall = cgiGet( "COMBO_ZONCOD_Objectcall");
               Combo_zoncod_Class = cgiGet( "COMBO_ZONCOD_Class");
               Combo_zoncod_Icontype = cgiGet( "COMBO_ZONCOD_Icontype");
               Combo_zoncod_Icon = cgiGet( "COMBO_ZONCOD_Icon");
               Combo_zoncod_Caption = cgiGet( "COMBO_ZONCOD_Caption");
               Combo_zoncod_Tooltip = cgiGet( "COMBO_ZONCOD_Tooltip");
               Combo_zoncod_Cls = cgiGet( "COMBO_ZONCOD_Cls");
               Combo_zoncod_Selectedvalue_set = cgiGet( "COMBO_ZONCOD_Selectedvalue_set");
               Combo_zoncod_Selectedvalue_get = cgiGet( "COMBO_ZONCOD_Selectedvalue_get");
               Combo_zoncod_Selectedtext_set = cgiGet( "COMBO_ZONCOD_Selectedtext_set");
               Combo_zoncod_Selectedtext_get = cgiGet( "COMBO_ZONCOD_Selectedtext_get");
               Combo_zoncod_Gamoauthtoken = cgiGet( "COMBO_ZONCOD_Gamoauthtoken");
               Combo_zoncod_Ddointernalname = cgiGet( "COMBO_ZONCOD_Ddointernalname");
               Combo_zoncod_Titlecontrolalign = cgiGet( "COMBO_ZONCOD_Titlecontrolalign");
               Combo_zoncod_Dropdownoptionstype = cgiGet( "COMBO_ZONCOD_Dropdownoptionstype");
               Combo_zoncod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Enabled"));
               Combo_zoncod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Visible"));
               Combo_zoncod_Titlecontrolidtoreplace = cgiGet( "COMBO_ZONCOD_Titlecontrolidtoreplace");
               Combo_zoncod_Datalisttype = cgiGet( "COMBO_ZONCOD_Datalisttype");
               Combo_zoncod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Allowmultipleselection"));
               Combo_zoncod_Datalistfixedvalues = cgiGet( "COMBO_ZONCOD_Datalistfixedvalues");
               Combo_zoncod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Isgriditem"));
               Combo_zoncod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Hasdescription"));
               Combo_zoncod_Datalistproc = cgiGet( "COMBO_ZONCOD_Datalistproc");
               Combo_zoncod_Datalistprocparametersprefix = cgiGet( "COMBO_ZONCOD_Datalistprocparametersprefix");
               Combo_zoncod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_ZONCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_zoncod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Includeonlyselectedoption"));
               Combo_zoncod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Includeselectalloption"));
               Combo_zoncod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Emptyitem"));
               Combo_zoncod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_ZONCOD_Includeaddnewoption"));
               Combo_zoncod_Htmltemplate = cgiGet( "COMBO_ZONCOD_Htmltemplate");
               Combo_zoncod_Multiplevaluestype = cgiGet( "COMBO_ZONCOD_Multiplevaluestype");
               Combo_zoncod_Loadingdata = cgiGet( "COMBO_ZONCOD_Loadingdata");
               Combo_zoncod_Noresultsfound = cgiGet( "COMBO_ZONCOD_Noresultsfound");
               Combo_zoncod_Emptyitemtext = cgiGet( "COMBO_ZONCOD_Emptyitemtext");
               Combo_zoncod_Onlyselectedvalues = cgiGet( "COMBO_ZONCOD_Onlyselectedvalues");
               Combo_zoncod_Selectalltext = cgiGet( "COMBO_ZONCOD_Selectalltext");
               Combo_zoncod_Multiplevaluesseparator = cgiGet( "COMBO_ZONCOD_Multiplevaluesseparator");
               Combo_zoncod_Addnewoptiontext = cgiGet( "COMBO_ZONCOD_Addnewoptiontext");
               Combo_zoncod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_ZONCOD_Gxcontroltype"), ".", ","));
               Combo_clitiplcod_Objectcall = cgiGet( "COMBO_CLITIPLCOD_Objectcall");
               Combo_clitiplcod_Class = cgiGet( "COMBO_CLITIPLCOD_Class");
               Combo_clitiplcod_Icontype = cgiGet( "COMBO_CLITIPLCOD_Icontype");
               Combo_clitiplcod_Icon = cgiGet( "COMBO_CLITIPLCOD_Icon");
               Combo_clitiplcod_Caption = cgiGet( "COMBO_CLITIPLCOD_Caption");
               Combo_clitiplcod_Tooltip = cgiGet( "COMBO_CLITIPLCOD_Tooltip");
               Combo_clitiplcod_Cls = cgiGet( "COMBO_CLITIPLCOD_Cls");
               Combo_clitiplcod_Selectedvalue_set = cgiGet( "COMBO_CLITIPLCOD_Selectedvalue_set");
               Combo_clitiplcod_Selectedvalue_get = cgiGet( "COMBO_CLITIPLCOD_Selectedvalue_get");
               Combo_clitiplcod_Selectedtext_set = cgiGet( "COMBO_CLITIPLCOD_Selectedtext_set");
               Combo_clitiplcod_Selectedtext_get = cgiGet( "COMBO_CLITIPLCOD_Selectedtext_get");
               Combo_clitiplcod_Gamoauthtoken = cgiGet( "COMBO_CLITIPLCOD_Gamoauthtoken");
               Combo_clitiplcod_Ddointernalname = cgiGet( "COMBO_CLITIPLCOD_Ddointernalname");
               Combo_clitiplcod_Titlecontrolalign = cgiGet( "COMBO_CLITIPLCOD_Titlecontrolalign");
               Combo_clitiplcod_Dropdownoptionstype = cgiGet( "COMBO_CLITIPLCOD_Dropdownoptionstype");
               Combo_clitiplcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Enabled"));
               Combo_clitiplcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Visible"));
               Combo_clitiplcod_Titlecontrolidtoreplace = cgiGet( "COMBO_CLITIPLCOD_Titlecontrolidtoreplace");
               Combo_clitiplcod_Datalisttype = cgiGet( "COMBO_CLITIPLCOD_Datalisttype");
               Combo_clitiplcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Allowmultipleselection"));
               Combo_clitiplcod_Datalistfixedvalues = cgiGet( "COMBO_CLITIPLCOD_Datalistfixedvalues");
               Combo_clitiplcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Isgriditem"));
               Combo_clitiplcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Hasdescription"));
               Combo_clitiplcod_Datalistproc = cgiGet( "COMBO_CLITIPLCOD_Datalistproc");
               Combo_clitiplcod_Datalistprocparametersprefix = cgiGet( "COMBO_CLITIPLCOD_Datalistprocparametersprefix");
               Combo_clitiplcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLITIPLCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_clitiplcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Includeonlyselectedoption"));
               Combo_clitiplcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Includeselectalloption"));
               Combo_clitiplcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Emptyitem"));
               Combo_clitiplcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLITIPLCOD_Includeaddnewoption"));
               Combo_clitiplcod_Htmltemplate = cgiGet( "COMBO_CLITIPLCOD_Htmltemplate");
               Combo_clitiplcod_Multiplevaluestype = cgiGet( "COMBO_CLITIPLCOD_Multiplevaluestype");
               Combo_clitiplcod_Loadingdata = cgiGet( "COMBO_CLITIPLCOD_Loadingdata");
               Combo_clitiplcod_Noresultsfound = cgiGet( "COMBO_CLITIPLCOD_Noresultsfound");
               Combo_clitiplcod_Emptyitemtext = cgiGet( "COMBO_CLITIPLCOD_Emptyitemtext");
               Combo_clitiplcod_Onlyselectedvalues = cgiGet( "COMBO_CLITIPLCOD_Onlyselectedvalues");
               Combo_clitiplcod_Selectalltext = cgiGet( "COMBO_CLITIPLCOD_Selectalltext");
               Combo_clitiplcod_Multiplevaluesseparator = cgiGet( "COMBO_CLITIPLCOD_Multiplevaluesseparator");
               Combo_clitiplcod_Addnewoptiontext = cgiGet( "COMBO_CLITIPLCOD_Addnewoptiontext");
               Combo_clitiplcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLITIPLCOD_Gxcontroltype"), ".", ","));
               Combo_tipscod_Objectcall = cgiGet( "COMBO_TIPSCOD_Objectcall");
               Combo_tipscod_Class = cgiGet( "COMBO_TIPSCOD_Class");
               Combo_tipscod_Icontype = cgiGet( "COMBO_TIPSCOD_Icontype");
               Combo_tipscod_Icon = cgiGet( "COMBO_TIPSCOD_Icon");
               Combo_tipscod_Caption = cgiGet( "COMBO_TIPSCOD_Caption");
               Combo_tipscod_Tooltip = cgiGet( "COMBO_TIPSCOD_Tooltip");
               Combo_tipscod_Cls = cgiGet( "COMBO_TIPSCOD_Cls");
               Combo_tipscod_Selectedvalue_set = cgiGet( "COMBO_TIPSCOD_Selectedvalue_set");
               Combo_tipscod_Selectedvalue_get = cgiGet( "COMBO_TIPSCOD_Selectedvalue_get");
               Combo_tipscod_Selectedtext_set = cgiGet( "COMBO_TIPSCOD_Selectedtext_set");
               Combo_tipscod_Selectedtext_get = cgiGet( "COMBO_TIPSCOD_Selectedtext_get");
               Combo_tipscod_Gamoauthtoken = cgiGet( "COMBO_TIPSCOD_Gamoauthtoken");
               Combo_tipscod_Ddointernalname = cgiGet( "COMBO_TIPSCOD_Ddointernalname");
               Combo_tipscod_Titlecontrolalign = cgiGet( "COMBO_TIPSCOD_Titlecontrolalign");
               Combo_tipscod_Dropdownoptionstype = cgiGet( "COMBO_TIPSCOD_Dropdownoptionstype");
               Combo_tipscod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Enabled"));
               Combo_tipscod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Visible"));
               Combo_tipscod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPSCOD_Titlecontrolidtoreplace");
               Combo_tipscod_Datalisttype = cgiGet( "COMBO_TIPSCOD_Datalisttype");
               Combo_tipscod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Allowmultipleselection"));
               Combo_tipscod_Datalistfixedvalues = cgiGet( "COMBO_TIPSCOD_Datalistfixedvalues");
               Combo_tipscod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Isgriditem"));
               Combo_tipscod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Hasdescription"));
               Combo_tipscod_Datalistproc = cgiGet( "COMBO_TIPSCOD_Datalistproc");
               Combo_tipscod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPSCOD_Datalistprocparametersprefix");
               Combo_tipscod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPSCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipscod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Includeonlyselectedoption"));
               Combo_tipscod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Includeselectalloption"));
               Combo_tipscod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Emptyitem"));
               Combo_tipscod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPSCOD_Includeaddnewoption"));
               Combo_tipscod_Htmltemplate = cgiGet( "COMBO_TIPSCOD_Htmltemplate");
               Combo_tipscod_Multiplevaluestype = cgiGet( "COMBO_TIPSCOD_Multiplevaluestype");
               Combo_tipscod_Loadingdata = cgiGet( "COMBO_TIPSCOD_Loadingdata");
               Combo_tipscod_Noresultsfound = cgiGet( "COMBO_TIPSCOD_Noresultsfound");
               Combo_tipscod_Emptyitemtext = cgiGet( "COMBO_TIPSCOD_Emptyitemtext");
               Combo_tipscod_Onlyselectedvalues = cgiGet( "COMBO_TIPSCOD_Onlyselectedvalues");
               Combo_tipscod_Selectalltext = cgiGet( "COMBO_TIPSCOD_Selectalltext");
               Combo_tipscod_Multiplevaluesseparator = cgiGet( "COMBO_TIPSCOD_Multiplevaluesseparator");
               Combo_tipscod_Addnewoptiontext = cgiGet( "COMBO_TIPSCOD_Addnewoptiontext");
               Combo_tipscod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPSCOD_Gxcontroltype"), ".", ","));
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
               Combo_clidirzoncod_Objectcall = cgiGet( "COMBO_CLIDIRZONCOD_Objectcall");
               Combo_clidirzoncod_Class = cgiGet( "COMBO_CLIDIRZONCOD_Class");
               Combo_clidirzoncod_Icontype = cgiGet( "COMBO_CLIDIRZONCOD_Icontype");
               Combo_clidirzoncod_Icon = cgiGet( "COMBO_CLIDIRZONCOD_Icon");
               Combo_clidirzoncod_Caption = cgiGet( "COMBO_CLIDIRZONCOD_Caption");
               Combo_clidirzoncod_Tooltip = cgiGet( "COMBO_CLIDIRZONCOD_Tooltip");
               Combo_clidirzoncod_Cls = cgiGet( "COMBO_CLIDIRZONCOD_Cls");
               Combo_clidirzoncod_Selectedvalue_set = cgiGet( "COMBO_CLIDIRZONCOD_Selectedvalue_set");
               Combo_clidirzoncod_Selectedvalue_get = cgiGet( "COMBO_CLIDIRZONCOD_Selectedvalue_get");
               Combo_clidirzoncod_Selectedtext_set = cgiGet( "COMBO_CLIDIRZONCOD_Selectedtext_set");
               Combo_clidirzoncod_Selectedtext_get = cgiGet( "COMBO_CLIDIRZONCOD_Selectedtext_get");
               Combo_clidirzoncod_Gamoauthtoken = cgiGet( "COMBO_CLIDIRZONCOD_Gamoauthtoken");
               Combo_clidirzoncod_Ddointernalname = cgiGet( "COMBO_CLIDIRZONCOD_Ddointernalname");
               Combo_clidirzoncod_Titlecontrolalign = cgiGet( "COMBO_CLIDIRZONCOD_Titlecontrolalign");
               Combo_clidirzoncod_Dropdownoptionstype = cgiGet( "COMBO_CLIDIRZONCOD_Dropdownoptionstype");
               Combo_clidirzoncod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Enabled"));
               Combo_clidirzoncod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Visible"));
               Combo_clidirzoncod_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIDIRZONCOD_Titlecontrolidtoreplace");
               Combo_clidirzoncod_Datalisttype = cgiGet( "COMBO_CLIDIRZONCOD_Datalisttype");
               Combo_clidirzoncod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Allowmultipleselection"));
               Combo_clidirzoncod_Datalistfixedvalues = cgiGet( "COMBO_CLIDIRZONCOD_Datalistfixedvalues");
               Combo_clidirzoncod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Isgriditem"));
               Combo_clidirzoncod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Hasdescription"));
               Combo_clidirzoncod_Datalistproc = cgiGet( "COMBO_CLIDIRZONCOD_Datalistproc");
               Combo_clidirzoncod_Datalistprocparametersprefix = cgiGet( "COMBO_CLIDIRZONCOD_Datalistprocparametersprefix");
               Combo_clidirzoncod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLIDIRZONCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_clidirzoncod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Includeonlyselectedoption"));
               Combo_clidirzoncod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Includeselectalloption"));
               Combo_clidirzoncod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Emptyitem"));
               Combo_clidirzoncod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIDIRZONCOD_Includeaddnewoption"));
               Combo_clidirzoncod_Htmltemplate = cgiGet( "COMBO_CLIDIRZONCOD_Htmltemplate");
               Combo_clidirzoncod_Multiplevaluestype = cgiGet( "COMBO_CLIDIRZONCOD_Multiplevaluestype");
               Combo_clidirzoncod_Loadingdata = cgiGet( "COMBO_CLIDIRZONCOD_Loadingdata");
               Combo_clidirzoncod_Noresultsfound = cgiGet( "COMBO_CLIDIRZONCOD_Noresultsfound");
               Combo_clidirzoncod_Emptyitemtext = cgiGet( "COMBO_CLIDIRZONCOD_Emptyitemtext");
               Combo_clidirzoncod_Onlyselectedvalues = cgiGet( "COMBO_CLIDIRZONCOD_Onlyselectedvalues");
               Combo_clidirzoncod_Selectalltext = cgiGet( "COMBO_CLIDIRZONCOD_Selectalltext");
               Combo_clidirzoncod_Multiplevaluesseparator = cgiGet( "COMBO_CLIDIRZONCOD_Multiplevaluesseparator");
               Combo_clidirzoncod_Addnewoptiontext = cgiGet( "COMBO_CLIDIRZONCOD_Addnewoptiontext");
               Combo_clidirzoncod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLIDIRZONCOD_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A45CliCod = cgiGet( edtCliCod_Internalname);
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A161CliDsc = cgiGet( edtCliDsc_Internalname);
               AssignAttri("", false, "A161CliDsc", A161CliDsc);
               A596CliDir = cgiGet( edtCliDir_Internalname);
               AssignAttri("", false, "A596CliDir", A596CliDir);
               A140EstCod = cgiGet( edtEstCod_Internalname);
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A139PaiCod = cgiGet( edtPaiCod_Internalname);
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A629CliTel1 = cgiGet( edtCliTel1_Internalname);
               AssignAttri("", false, "A629CliTel1", A629CliTel1);
               A630CliTel2 = cgiGet( edtCliTel2_Internalname);
               AssignAttri("", false, "A630CliTel2", A630CliTel2);
               A611CliFax = cgiGet( edtCliFax_Internalname);
               AssignAttri("", false, "A611CliFax", A611CliFax);
               A575CliCel = cgiGet( edtCliCel_Internalname);
               AssignAttri("", false, "A575CliCel", A575CliCel);
               A609CliEma = cgiGet( edtCliEma_Internalname);
               AssignAttri("", false, "A609CliEma", A609CliEma);
               A637CliWeb = cgiGet( edtCliWeb_Internalname);
               AssignAttri("", false, "A637CliWeb", A637CliWeb);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipCCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A159TipCCod = 0;
                  AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
               }
               else
               {
                  A159TipCCod = (int)(context.localUtil.CToN( cgiGet( edtTipCCod_Internalname), ".", ","));
                  AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
               }
               A612CliFoto = cgiGet( imgCliFoto_Internalname);
               n612CliFoto = false;
               AssignAttri("", false, "A612CliFoto", A612CliFoto);
               n612CliFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLISTS");
                  AnyError = 1;
                  GX_FocusControl = edtCliSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A627CliSts = 0;
                  AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
               }
               else
               {
                  A627CliSts = (short)(context.localUtil.CToN( cgiGet( edtCliSts_Internalname), ".", ","));
                  AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A137Conpcod = 0;
                  AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               }
               else
               {
                  A137Conpcod = (int)(context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ","));
                  AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliLim_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliLim_Internalname), ".", ",") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLILIM");
                  AnyError = 1;
                  GX_FocusControl = edtCliLim_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A613CliLim = 0;
                  AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
               }
               else
               {
                  A613CliLim = context.localUtil.CToN( cgiGet( edtCliLim_Internalname), ".", ",");
                  AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliVend_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliVend_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIVEND");
                  AnyError = 1;
                  GX_FocusControl = edtCliVend_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A160CliVend = 0;
                  AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
               }
               else
               {
                  A160CliVend = (int)(context.localUtil.CToN( cgiGet( edtCliVend_Internalname), ".", ","));
                  AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
               }
               A635CliVendDsc = cgiGet( edtCliVendDsc_Internalname);
               AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
               A618CliRef1 = cgiGet( edtCliRef1_Internalname);
               AssignAttri("", false, "A618CliRef1", A618CliRef1);
               A619CliRef2 = cgiGet( edtCliRef2_Internalname);
               AssignAttri("", false, "A619CliRef2", A619CliRef2);
               A620CliRef3 = cgiGet( edtCliRef3_Internalname);
               AssignAttri("", false, "A620CliRef3", A620CliRef3);
               A621CliRef4 = cgiGet( edtCliRef4_Internalname);
               AssignAttri("", false, "A621CliRef4", A621CliRef4);
               A622CliRef5 = cgiGet( edtCliRef5_Internalname);
               AssignAttri("", false, "A622CliRef5", A622CliRef5);
               A623CliRef6 = cgiGet( edtCliRef6_Internalname);
               AssignAttri("", false, "A623CliRef6", A623CliRef6);
               A624CliRef7 = cgiGet( edtCliRef7_Internalname);
               AssignAttri("", false, "A624CliRef7", A624CliRef7);
               A625CliRef8 = cgiGet( edtCliRef8_Internalname);
               AssignAttri("", false, "A625CliRef8", A625CliRef8);
               A581CliCont1 = cgiGet( edtCliCont1_Internalname);
               AssignAttri("", false, "A581CliCont1", A581CliCont1);
               A587CliCTel1 = cgiGet( edtCliCTel1_Internalname);
               AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
               A582CliCont2 = cgiGet( edtCliCont2_Internalname);
               AssignAttri("", false, "A582CliCont2", A582CliCont2);
               A588CliCTel2 = cgiGet( edtCliCTel2_Internalname);
               AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
               A583CliCont3 = cgiGet( edtCliCont3_Internalname);
               AssignAttri("", false, "A583CliCont3", A583CliCont3);
               A589CliCtel3 = cgiGet( edtCliCtel3_Internalname);
               AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
               A584CliCont4 = cgiGet( edtCliCont4_Internalname);
               AssignAttri("", false, "A584CliCont4", A584CliCont4);
               A590CliCTel4 = cgiGet( edtCliCTel4_Internalname);
               AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
               A585CliCont5 = cgiGet( edtCliCont5_Internalname);
               AssignAttri("", false, "A585CliCont5", A585CliCont5);
               A591CliCtel5 = cgiGet( edtCliCtel5_Internalname);
               AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
               A142DisCod = cgiGet( edtDisCod_Internalname);
               AssignAttri("", false, "A142DisCod", A142DisCod);
               A141ProvCod = cgiGet( edtProvCod_Internalname);
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliTItemDir_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliTItemDir_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLITITEMDIR");
                  AnyError = 1;
                  GX_FocusControl = edtCliTItemDir_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A632CliTItemDir = 0;
                  AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
               }
               else
               {
                  A632CliTItemDir = (int)(context.localUtil.CToN( cgiGet( edtCliTItemDir_Internalname), ".", ","));
                  AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtZonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtZonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ZONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtZonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A158ZonCod = 0;
                  n158ZonCod = false;
                  AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
               }
               else
               {
                  A158ZonCod = (int)(context.localUtil.CToN( cgiGet( edtZonCod_Internalname), ".", ","));
                  n158ZonCod = false;
                  AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
               }
               n158ZonCod = ((0==A158ZonCod) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIMON");
                  AnyError = 1;
                  GX_FocusControl = edtCliMon_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A614CliMon = 0;
                  AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
               }
               else
               {
                  A614CliMon = (int)(context.localUtil.CToN( cgiGet( edtCliMon_Internalname), ".", ","));
                  AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliVincula_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliVincula_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIVINCULA");
                  AnyError = 1;
                  GX_FocusControl = edtCliVincula_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A636CliVincula = 0;
                  AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
               }
               else
               {
                  A636CliVincula = (short)(context.localUtil.CToN( cgiGet( edtCliVincula_Internalname), ".", ","));
                  AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliRetencion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliRetencion_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIRETENCION");
                  AnyError = 1;
                  GX_FocusControl = edtCliRetencion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A626CliRetencion = 0;
                  AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
               }
               else
               {
                  A626CliRetencion = (short)(context.localUtil.CToN( cgiGet( edtCliRetencion_Internalname), ".", ","));
                  AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliPercepcion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliPercepcion_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIPERCEPCION");
                  AnyError = 1;
                  GX_FocusControl = edtCliPercepcion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A617CliPercepcion = 0;
                  AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
               }
               else
               {
                  A617CliPercepcion = (short)(context.localUtil.CToN( cgiGet( edtCliPercepcion_Internalname), ".", ","));
                  AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliTipLCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliTipLCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLITIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A156CliTipLCod = 0;
                  n156CliTipLCod = false;
                  AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
               }
               else
               {
                  A156CliTipLCod = (int)(context.localUtil.CToN( cgiGet( edtCliTipLCod_Internalname), ".", ","));
                  n156CliTipLCod = false;
                  AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
               }
               n156CliTipLCod = ((0==A156CliTipLCod) ? true : false);
               A615CliNom = cgiGet( edtCliNom_Internalname);
               AssignAttri("", false, "A615CliNom", A615CliNom);
               A574CliAPEP = cgiGet( edtCliAPEP_Internalname);
               AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
               A573CliAPEM = cgiGet( edtCliAPEM_Internalname);
               AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A157TipSCod = 0;
                  AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
               }
               else
               {
                  A157TipSCod = (int)(context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ","));
                  AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
               }
               A633CliUsuCod = cgiGet( edtCliUsuCod_Internalname);
               AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
               if ( context.localUtil.VCDateTime( cgiGet( edtCliUsuFec_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "CLIUSUFEC");
                  AnyError = 1;
                  GX_FocusControl = edtCliUsuFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A634CliUsuFec = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A634CliUsuFec = context.localUtil.CToT( cgiGet( edtCliUsuFec_Internalname));
                  AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               A610CliEMAPer = cgiGet( edtCliEMAPer_Internalname);
               AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
               A616CliPassPer = cgiGet( edtCliPassPer_Internalname);
               AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliTCon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliTCon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLITCON");
                  AnyError = 1;
                  GX_FocusControl = edtCliTCon_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A628CliTCon = 0;
                  AssignAttri("", false, "A628CliTCon", StringUtil.LTrimStr( (decimal)(A628CliTCon), 6, 0));
               }
               else
               {
                  A628CliTCon = (int)(context.localUtil.CToN( cgiGet( edtCliTCon_Internalname), ".", ","));
                  AssignAttri("", false, "A628CliTCon", StringUtil.LTrimStr( (decimal)(A628CliTCon), 6, 0));
               }
               A601CliDireccionLarga = cgiGet( edtCliDireccionLarga_Internalname);
               AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
               A631CliTipCod = cgiGet( edtCliTipCod_Internalname);
               AssignAttri("", false, "A631CliTipCod", A631CliTipCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIDTAVAL");
                  AnyError = 1;
                  GX_FocusControl = edtCliDTAval_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A608CliDTAval = 0;
                  AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
               }
               else
               {
                  A608CliDTAval = (int)(context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ","));
                  AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
               }
               AV28ComboEstCod = cgiGet( edtavComboestcod_Internalname);
               AssignAttri("", false, "AV28ComboEstCod", AV28ComboEstCod);
               AV31ComboPaiCod = cgiGet( edtavCombopaicod_Internalname);
               AssignAttri("", false, "AV31ComboPaiCod", AV31ComboPaiCod);
               AV33ComboTipCCod = (int)(context.localUtil.CToN( cgiGet( edtavCombotipccod_Internalname), ".", ","));
               AssignAttri("", false, "AV33ComboTipCCod", StringUtil.LTrimStr( (decimal)(AV33ComboTipCCod), 6, 0));
               AV35ComboConpcod = (int)(context.localUtil.CToN( cgiGet( edtavComboconpcod_Internalname), ".", ","));
               AssignAttri("", false, "AV35ComboConpcod", StringUtil.LTrimStr( (decimal)(AV35ComboConpcod), 6, 0));
               AV37ComboCliVend = (int)(context.localUtil.CToN( cgiGet( edtavComboclivend_Internalname), ".", ","));
               AssignAttri("", false, "AV37ComboCliVend", StringUtil.LTrimStr( (decimal)(AV37ComboCliVend), 6, 0));
               AV40ComboDisCod = cgiGet( edtavCombodiscod_Internalname);
               AssignAttri("", false, "AV40ComboDisCod", AV40ComboDisCod);
               AV44ComboProvCod = cgiGet( edtavComboprovcod_Internalname);
               AssignAttri("", false, "AV44ComboProvCod", AV44ComboProvCod);
               AV46ComboZonCod = (int)(context.localUtil.CToN( cgiGet( edtavCombozoncod_Internalname), ".", ","));
               AssignAttri("", false, "AV46ComboZonCod", StringUtil.LTrimStr( (decimal)(AV46ComboZonCod), 6, 0));
               AV48ComboCliTipLCod = (int)(context.localUtil.CToN( cgiGet( edtavComboclitiplcod_Internalname), ".", ","));
               AssignAttri("", false, "AV48ComboCliTipLCod", StringUtil.LTrimStr( (decimal)(AV48ComboCliTipLCod), 6, 0));
               AV51ComboTipSCod = (int)(context.localUtil.CToN( cgiGet( edtavCombotipscod_Internalname), ".", ","));
               AssignAttri("", false, "AV51ComboTipSCod", StringUtil.LTrimStr( (decimal)(AV51ComboTipSCod), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgCliFoto_Internalname, ref  A612CliFoto, ref  A40000CliFoto_GXI);
               n40000CliFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
               n612CliFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ventas\\clientes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A45CliCod = GetPar( "CliCod");
                  n45CliCod = false;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
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
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode11;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLICOD");
                        AnyError = 1;
                        GX_FocusControl = edtCliCod_Internalname;
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
                           E117O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127O2 ();
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
            E127O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7O11( ) ;
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
            DisableAttributes7O11( ) ;
         }
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombotipccod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipccod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboconpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboconpcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboclivend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclivend_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombodiscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombozoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombozoncod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboclitiplcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclitiplcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombotipscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipscod_Enabled), 5, 0), true);
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

      protected void CONFIRM_7O0( )
      {
         BeforeValidate7O11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7O11( ) ;
            }
            else
            {
               CheckExtendedTable7O11( ) ;
               CloseExtendedTableCursors7O11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode11 = Gx_mode;
            CONFIRM_7O83( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_7O13( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode11;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_7O13( )
      {
         nGXsfl_383_idx = 0;
         while ( nGXsfl_383_idx < nRC_GXsfl_383 )
         {
            ReadRow7O13( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               GetKey7O13( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7O13( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7O13( ) ;
                        CloseExtendedTableCursors7O13( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CLICONCOD_" + sGXsfl_383_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCliConCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( nRcdDeleted_13 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7O13( ) ;
                        Load7O13( ) ;
                        BeforeValidate7O13( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7O13( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7O13( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7O13( ) ;
                              CloseExtendedTableCursors7O13( ) ;
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
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "CLICONCOD_" + sGXsfl_383_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliConCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliConCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A163CliConCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliConDsc_Internalname, StringUtil.RTrim( A578CliConDsc)) ;
            ChangePostValue( edtCliConCargo_Internalname, StringUtil.RTrim( A577CliConCargo)) ;
            ChangePostValue( edtCliConTelf_Internalname, StringUtil.RTrim( A586CliConTelf)) ;
            ChangePostValue( edtCliConArea_Internalname, StringUtil.RTrim( A576CliConArea)) ;
            ChangePostValue( edtCliConMail_Internalname, A579CliConMail) ;
            ChangePostValue( edtCliConMailFE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z163CliConCod_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z163CliConCod), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z578CliConDsc_"+sGXsfl_383_idx, StringUtil.RTrim( Z578CliConDsc)) ;
            ChangePostValue( "ZT_"+"Z577CliConCargo_"+sGXsfl_383_idx, StringUtil.RTrim( Z577CliConCargo)) ;
            ChangePostValue( "ZT_"+"Z586CliConTelf_"+sGXsfl_383_idx, StringUtil.RTrim( Z586CliConTelf)) ;
            ChangePostValue( "ZT_"+"Z576CliConArea_"+sGXsfl_383_idx, StringUtil.RTrim( Z576CliConArea)) ;
            ChangePostValue( "ZT_"+"Z579CliConMail_"+sGXsfl_383_idx, Z579CliConMail) ;
            ChangePostValue( "ZT_"+"Z580CliConMailFE_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z580CliConMailFE), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "CLICONCOD_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONDSC_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONCARGO_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCargo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONTELF_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConTelf_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONAREA_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConArea_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONMAIL_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONMAILFE_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMailFE_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_7O83( )
      {
         nGXsfl_368_idx = 0;
         while ( nGXsfl_368_idx < nRC_GXsfl_368 )
         {
            ReadRow7O83( ) ;
            if ( ( nRcdExists_83 != 0 ) || ( nIsMod_83 != 0 ) )
            {
               GetKey7O83( ) ;
               if ( ( nRcdExists_83 == 0 ) && ( nRcdDeleted_83 == 0 ) )
               {
                  if ( RcdFound83 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate7O83( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7O83( ) ;
                        CloseExtendedTableCursors7O83( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CLIDIRITEM_" + sGXsfl_368_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCliDirItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound83 != 0 )
                  {
                     if ( nRcdDeleted_83 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey7O83( ) ;
                        Load7O83( ) ;
                        BeforeValidate7O83( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7O83( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_83 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate7O83( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7O83( ) ;
                              CloseExtendedTableCursors7O83( ) ;
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
                     if ( nRcdDeleted_83 == 0 )
                     {
                        GXCCtl = "CLIDIRITEM_" + sGXsfl_368_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliDirItem_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliDirItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A164CliDirItem), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDirDsc_Internalname, StringUtil.RTrim( A600CliDirDsc)) ;
            ChangePostValue( edtCliDirDir_Internalname, StringUtil.RTrim( A598CliDirDir)) ;
            ChangePostValue( edtCliDirPais_Internalname, StringUtil.RTrim( A605CliDirPais)) ;
            ChangePostValue( edtCliDirDep_Internalname, StringUtil.RTrim( A597CliDirDep)) ;
            ChangePostValue( edtCliDirProv_Internalname, StringUtil.RTrim( A606CliDirProv)) ;
            ChangePostValue( edtCliDirDis_Internalname, StringUtil.RTrim( A599CliDirDis)) ;
            ChangePostValue( edtCliDirZonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDirZonDsc_Internalname, StringUtil.RTrim( A607CliDirZonDsc)) ;
            ChangePostValue( "ZT_"+"Z164CliDirItem_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164CliDirItem), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z600CliDirDsc_"+sGXsfl_368_idx, StringUtil.RTrim( Z600CliDirDsc)) ;
            ChangePostValue( "ZT_"+"Z598CliDirDir_"+sGXsfl_368_idx, StringUtil.RTrim( Z598CliDirDir)) ;
            ChangePostValue( "ZT_"+"Z605CliDirPais_"+sGXsfl_368_idx, StringUtil.RTrim( Z605CliDirPais)) ;
            ChangePostValue( "ZT_"+"Z597CliDirDep_"+sGXsfl_368_idx, StringUtil.RTrim( Z597CliDirDep)) ;
            ChangePostValue( "ZT_"+"Z606CliDirProv_"+sGXsfl_368_idx, StringUtil.RTrim( Z606CliDirProv)) ;
            ChangePostValue( "ZT_"+"Z599CliDirDis_"+sGXsfl_368_idx, StringUtil.RTrim( Z599CliDirDis)) ;
            ChangePostValue( "ZT_"+"Z165CliDirZonCod_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliDirZonCod), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_83), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_83), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_83), 4, 0, ".", ""))) ;
            if ( nIsMod_83 != 0 )
            {
               ChangePostValue( "CLIDIRITEM_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDIR_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDir_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRPAIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirPais_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDEP_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDep_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRPROV_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirProv_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDis_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Horizontalalignment", StringUtil.RTrim( edtCliDirZonCod_Horizontalalignment)) ;
               ChangePostValue( "CLIDIRZONDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption7O0( )
      {
      }

      protected void E117O2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV23DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV23DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Combo_clidirzoncod_Titlecontrolidtoreplace = edtCliDirZonCod_Internalname;
         ucCombo_clidirzoncod.SendProperty(context, "", false, Combo_clidirzoncod_Internalname, "TitleControlIdToReplace", Combo_clidirzoncod_Titlecontrolidtoreplace);
         edtCliDirZonCod_Horizontalalignment = "Left";
         AssignProp("", false, edtCliDirZonCod_Internalname, "Horizontalalignment", edtCliDirZonCod_Horizontalalignment, !bGXsfl_368_Refreshing);
         edtTipSCod_Visible = 0;
         AssignProp("", false, edtTipSCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipSCod_Visible), 5, 0), true);
         AV51ComboTipSCod = 0;
         AssignAttri("", false, "AV51ComboTipSCod", StringUtil.LTrimStr( (decimal)(AV51ComboTipSCod), 6, 0));
         edtavCombotipscod_Visible = 0;
         AssignProp("", false, edtavCombotipscod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipscod_Visible), 5, 0), true);
         edtCliTipLCod_Visible = 0;
         AssignProp("", false, edtCliTipLCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliTipLCod_Visible), 5, 0), true);
         AV48ComboCliTipLCod = 0;
         AssignAttri("", false, "AV48ComboCliTipLCod", StringUtil.LTrimStr( (decimal)(AV48ComboCliTipLCod), 6, 0));
         edtavComboclitiplcod_Visible = 0;
         AssignProp("", false, edtavComboclitiplcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclitiplcod_Visible), 5, 0), true);
         edtZonCod_Visible = 0;
         AssignProp("", false, edtZonCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonCod_Visible), 5, 0), true);
         AV46ComboZonCod = 0;
         AssignAttri("", false, "AV46ComboZonCod", StringUtil.LTrimStr( (decimal)(AV46ComboZonCod), 6, 0));
         edtavCombozoncod_Visible = 0;
         AssignProp("", false, edtavCombozoncod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombozoncod_Visible), 5, 0), true);
         edtProvCod_Visible = 0;
         AssignProp("", false, edtProvCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProvCod_Visible), 5, 0), true);
         AV44ComboProvCod = "";
         AssignAttri("", false, "AV44ComboProvCod", AV44ComboProvCod);
         edtavComboprovcod_Visible = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Visible), 5, 0), true);
         edtDisCod_Visible = 0;
         AssignProp("", false, edtDisCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDisCod_Visible), 5, 0), true);
         AV40ComboDisCod = "";
         AssignAttri("", false, "AV40ComboDisCod", AV40ComboDisCod);
         edtavCombodiscod_Visible = 0;
         AssignProp("", false, edtavCombodiscod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Visible), 5, 0), true);
         edtCliVend_Visible = 0;
         AssignProp("", false, edtCliVend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliVend_Visible), 5, 0), true);
         AV37ComboCliVend = 0;
         AssignAttri("", false, "AV37ComboCliVend", StringUtil.LTrimStr( (decimal)(AV37ComboCliVend), 6, 0));
         edtavComboclivend_Visible = 0;
         AssignProp("", false, edtavComboclivend_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclivend_Visible), 5, 0), true);
         edtConpcod_Visible = 0;
         AssignProp("", false, edtConpcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtConpcod_Visible), 5, 0), true);
         AV35ComboConpcod = 0;
         AssignAttri("", false, "AV35ComboConpcod", StringUtil.LTrimStr( (decimal)(AV35ComboConpcod), 6, 0));
         edtavComboconpcod_Visible = 0;
         AssignProp("", false, edtavComboconpcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboconpcod_Visible), 5, 0), true);
         edtTipCCod_Visible = 0;
         AssignProp("", false, edtTipCCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipCCod_Visible), 5, 0), true);
         AV33ComboTipCCod = 0;
         AssignAttri("", false, "AV33ComboTipCCod", StringUtil.LTrimStr( (decimal)(AV33ComboTipCCod), 6, 0));
         edtavCombotipccod_Visible = 0;
         AssignProp("", false, edtavCombotipccod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipccod_Visible), 5, 0), true);
         edtPaiCod_Visible = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaiCod_Visible), 5, 0), true);
         AV31ComboPaiCod = "";
         AssignAttri("", false, "AV31ComboPaiCod", AV31ComboPaiCod);
         edtavCombopaicod_Visible = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Visible), 5, 0), true);
         edtEstCod_Visible = 0;
         AssignProp("", false, edtEstCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstCod_Visible), 5, 0), true);
         AV28ComboEstCod = "";
         AssignAttri("", false, "AV28ComboEstCod", AV28ComboEstCod);
         edtavComboestcod_Visible = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOESTCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPAICOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOTIPCCOD' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCONPCOD' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCLIVEND' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBODISCOD' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROVCOD' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOZONCOD' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCLITIPLCOD' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOTIPSCOD' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV52Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV53GXV1 = 1;
            AssignAttri("", false, "AV53GXV1", StringUtil.LTrimStr( (decimal)(AV53GXV1), 8, 0));
            while ( AV53GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV53GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "EstCod") == 0 )
               {
                  AV11Insert_EstCod = AV21TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_EstCod", AV11Insert_EstCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstCod)) )
                  {
                     AV28ComboEstCod = AV11Insert_EstCod;
                     AssignAttri("", false, "AV28ComboEstCod", AV28ComboEstCod);
                     Combo_estcod_Selectedvalue_set = AV28ComboEstCod;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "EstCod",  "GET",  false,  AV7CliCod,  AV12Insert_PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_estcod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
                     Combo_estcod_Enabled = false;
                     ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "PaiCod") == 0 )
               {
                  AV12Insert_PaiCod = AV21TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV12Insert_PaiCod", AV12Insert_PaiCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_PaiCod)) )
                  {
                     AV31ComboPaiCod = AV12Insert_PaiCod;
                     AssignAttri("", false, "AV31ComboPaiCod", AV31ComboPaiCod);
                     Combo_paicod_Selectedvalue_set = AV31ComboPaiCod;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "PaiCod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_paicod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
                     Combo_paicod_Enabled = false;
                     ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "TipCCod") == 0 )
               {
                  AV13Insert_TipCCod = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_TipCCod", StringUtil.LTrimStr( (decimal)(AV13Insert_TipCCod), 6, 0));
                  if ( ! (0==AV13Insert_TipCCod) )
                  {
                     AV33ComboTipCCod = AV13Insert_TipCCod;
                     AssignAttri("", false, "AV33ComboTipCCod", StringUtil.LTrimStr( (decimal)(AV33ComboTipCCod), 6, 0));
                     Combo_tipccod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV33ComboTipCCod), 6, 0));
                     ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedValue_set", Combo_tipccod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "TipCCod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_tipccod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedText_set", Combo_tipccod_Selectedtext_set);
                     Combo_tipccod_Enabled = false;
                     ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipccod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "Conpcod") == 0 )
               {
                  AV14Insert_Conpcod = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_Conpcod", StringUtil.LTrimStr( (decimal)(AV14Insert_Conpcod), 6, 0));
                  if ( ! (0==AV14Insert_Conpcod) )
                  {
                     AV35ComboConpcod = AV14Insert_Conpcod;
                     AssignAttri("", false, "AV35ComboConpcod", StringUtil.LTrimStr( (decimal)(AV35ComboConpcod), 6, 0));
                     Combo_conpcod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV35ComboConpcod), 6, 0));
                     ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "SelectedValue_set", Combo_conpcod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "Conpcod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_conpcod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "SelectedText_set", Combo_conpcod_Selectedtext_set);
                     Combo_conpcod_Enabled = false;
                     ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conpcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "CliVend") == 0 )
               {
                  AV15Insert_CliVend = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV15Insert_CliVend", StringUtil.LTrimStr( (decimal)(AV15Insert_CliVend), 6, 0));
                  if ( ! (0==AV15Insert_CliVend) )
                  {
                     AV37ComboCliVend = AV15Insert_CliVend;
                     AssignAttri("", false, "AV37ComboCliVend", StringUtil.LTrimStr( (decimal)(AV37ComboCliVend), 6, 0));
                     Combo_clivend_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV37ComboCliVend), 6, 0));
                     ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "SelectedValue_set", Combo_clivend_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "CliVend",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_clivend_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "SelectedText_set", Combo_clivend_Selectedtext_set);
                     Combo_clivend_Enabled = false;
                     ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clivend_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "DisCod") == 0 )
               {
                  AV16Insert_DisCod = AV21TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV16Insert_DisCod", AV16Insert_DisCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
                  {
                     AV40ComboDisCod = AV16Insert_DisCod;
                     AssignAttri("", false, "AV40ComboDisCod", AV40ComboDisCod);
                     Combo_discod_Selectedvalue_set = AV40ComboDisCod;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedValue_set", Combo_discod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "DisCod",  "GET",  false,  AV7CliCod,  AV12Insert_PaiCod,  AV11Insert_EstCod,  AV17Insert_ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_discod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedText_set", Combo_discod_Selectedtext_set);
                     Combo_discod_Enabled = false;
                     ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "ProvCod") == 0 )
               {
                  AV17Insert_ProvCod = AV21TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV17Insert_ProvCod", AV17Insert_ProvCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProvCod)) )
                  {
                     AV44ComboProvCod = AV17Insert_ProvCod;
                     AssignAttri("", false, "AV44ComboProvCod", AV44ComboProvCod);
                     Combo_provcod_Selectedvalue_set = AV44ComboProvCod;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "ProvCod",  "GET",  false,  AV7CliCod,  AV12Insert_PaiCod,  AV11Insert_EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_provcod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
                     Combo_provcod_Enabled = false;
                     ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "ZonCod") == 0 )
               {
                  AV18Insert_ZonCod = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV18Insert_ZonCod", StringUtil.LTrimStr( (decimal)(AV18Insert_ZonCod), 6, 0));
                  if ( ! (0==AV18Insert_ZonCod) )
                  {
                     AV46ComboZonCod = AV18Insert_ZonCod;
                     AssignAttri("", false, "AV46ComboZonCod", StringUtil.LTrimStr( (decimal)(AV46ComboZonCod), 6, 0));
                     Combo_zoncod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV46ComboZonCod), 6, 0));
                     ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedValue_set", Combo_zoncod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "ZonCod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_zoncod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedText_set", Combo_zoncod_Selectedtext_set);
                     Combo_zoncod_Enabled = false;
                     ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_zoncod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "CliTipLCod") == 0 )
               {
                  AV19Insert_CliTipLCod = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV19Insert_CliTipLCod", StringUtil.LTrimStr( (decimal)(AV19Insert_CliTipLCod), 6, 0));
                  if ( ! (0==AV19Insert_CliTipLCod) )
                  {
                     AV48ComboCliTipLCod = AV19Insert_CliTipLCod;
                     AssignAttri("", false, "AV48ComboCliTipLCod", StringUtil.LTrimStr( (decimal)(AV48ComboCliTipLCod), 6, 0));
                     Combo_clitiplcod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV48ComboCliTipLCod), 6, 0));
                     ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "SelectedValue_set", Combo_clitiplcod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "CliTipLCod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_clitiplcod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "SelectedText_set", Combo_clitiplcod_Selectedtext_set);
                     Combo_clitiplcod_Enabled = false;
                     ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clitiplcod_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "TipSCod") == 0 )
               {
                  AV20Insert_TipSCod = (int)(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV20Insert_TipSCod", StringUtil.LTrimStr( (decimal)(AV20Insert_TipSCod), 6, 0));
                  if ( ! (0==AV20Insert_TipSCod) )
                  {
                     AV51ComboTipSCod = AV20Insert_TipSCod;
                     AssignAttri("", false, "AV51ComboTipSCod", StringUtil.LTrimStr( (decimal)(AV51ComboTipSCod), 6, 0));
                     Combo_tipscod_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV51ComboTipSCod), 6, 0));
                     ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "SelectedValue_set", Combo_tipscod_Selectedvalue_set);
                     GXt_char2 = AV26Combo_DataJson;
                     new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "TipSCod",  "GET",  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  AV21TrnContextAtt.gxTpr_Attributevalue, out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
                     AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
                     AV26Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
                     Combo_tipscod_Selectedtext_set = AV25ComboSelectedText;
                     ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "SelectedText_set", Combo_tipscod_Selectedtext_set);
                     Combo_tipscod_Enabled = false;
                     ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipscod_Enabled));
                  }
               }
               AV53GXV1 = (int)(AV53GXV1+1);
               AssignAttri("", false, "AV53GXV1", StringUtil.LTrimStr( (decimal)(AV53GXV1), 8, 0));
            }
         }
      }

      protected void E127O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("ventas.clientesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S202( )
      {
         /* 'LOADCOMBOTIPSCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "TipSCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_tipscod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "SelectedValue_set", Combo_tipscod_Selectedvalue_set);
         Combo_tipscod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "SelectedText_set", Combo_tipscod_Selectedtext_set);
         AV51ComboTipSCod = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV51ComboTipSCod", StringUtil.LTrimStr( (decimal)(AV51ComboTipSCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tipscod_Enabled = false;
            ucCombo_tipscod.SendProperty(context, "", false, Combo_tipscod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipscod_Enabled));
         }
      }

      protected void S192( )
      {
         /* 'LOADCOMBOCLITIPLCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "CliTipLCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_clitiplcod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "SelectedValue_set", Combo_clitiplcod_Selectedvalue_set);
         Combo_clitiplcod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "SelectedText_set", Combo_clitiplcod_Selectedtext_set);
         AV48ComboCliTipLCod = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV48ComboCliTipLCod", StringUtil.LTrimStr( (decimal)(AV48ComboCliTipLCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clitiplcod_Enabled = false;
            ucCombo_clitiplcod.SendProperty(context, "", false, Combo_clitiplcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clitiplcod_Enabled));
         }
      }

      protected void S182( )
      {
         /* 'LOADCOMBOZONCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "ZonCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_zoncod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedValue_set", Combo_zoncod_Selectedvalue_set);
         Combo_zoncod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "SelectedText_set", Combo_zoncod_Selectedtext_set);
         AV46ComboZonCod = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV46ComboZonCod", StringUtil.LTrimStr( (decimal)(AV46ComboZonCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_zoncod_Enabled = false;
            ucCombo_zoncod.SendProperty(context, "", false, Combo_zoncod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_zoncod_Enabled));
         }
      }

      protected void S172( )
      {
         /* 'LOADCOMBOPROVCOD' Routine */
         returnInSub = false;
         Combo_provcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"ProvCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\", \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "DataListProcParametersPrefix", Combo_provcod_Datalistprocparametersprefix);
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "ProvCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_provcod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedValue_set", Combo_provcod_Selectedvalue_set);
         Combo_provcod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "SelectedText_set", Combo_provcod_Selectedtext_set);
         AV44ComboProvCod = AV24ComboSelectedValue;
         AssignAttri("", false, "AV44ComboProvCod", AV44ComboProvCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_provcod_Enabled = false;
            ucCombo_provcod.SendProperty(context, "", false, Combo_provcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
         }
      }

      protected void S162( )
      {
         /* 'LOADCOMBODISCOD' Routine */
         returnInSub = false;
         Combo_discod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"DisCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\", \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "DataListProcParametersPrefix", Combo_discod_Datalistprocparametersprefix);
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "DisCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_discod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedValue_set", Combo_discod_Selectedvalue_set);
         Combo_discod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "SelectedText_set", Combo_discod_Selectedtext_set);
         AV40ComboDisCod = AV24ComboSelectedValue;
         AssignAttri("", false, "AV40ComboDisCod", AV40ComboDisCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_discod_Enabled = false;
            ucCombo_discod.SendProperty(context, "", false, Combo_discod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
         }
      }

      protected void S152( )
      {
         /* 'LOADCOMBOCLIVEND' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "CliVend",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_clivend_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "SelectedValue_set", Combo_clivend_Selectedvalue_set);
         Combo_clivend_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "SelectedText_set", Combo_clivend_Selectedtext_set);
         AV37ComboCliVend = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV37ComboCliVend", StringUtil.LTrimStr( (decimal)(AV37ComboCliVend), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clivend_Enabled = false;
            ucCombo_clivend.SendProperty(context, "", false, Combo_clivend_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clivend_Enabled));
         }
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCONPCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "Conpcod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_conpcod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "SelectedValue_set", Combo_conpcod_Selectedvalue_set);
         Combo_conpcod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "SelectedText_set", Combo_conpcod_Selectedtext_set);
         AV35ComboConpcod = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV35ComboConpcod", StringUtil.LTrimStr( (decimal)(AV35ComboConpcod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_conpcod_Enabled = false;
            ucCombo_conpcod.SendProperty(context, "", false, Combo_conpcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_conpcod_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOTIPCCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "TipCCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_tipccod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedValue_set", Combo_tipccod_Selectedvalue_set);
         Combo_tipccod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "SelectedText_set", Combo_tipccod_Selectedtext_set);
         AV33ComboTipCCod = (int)(NumberUtil.Val( AV24ComboSelectedValue, "."));
         AssignAttri("", false, "AV33ComboTipCCod", StringUtil.LTrimStr( (decimal)(AV33ComboTipCCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_tipccod_Enabled = false;
            ucCombo_tipccod.SendProperty(context, "", false, Combo_tipccod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipccod_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPAICOD' Routine */
         returnInSub = false;
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "PaiCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_paicod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedValue_set", Combo_paicod_Selectedvalue_set);
         Combo_paicod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "SelectedText_set", Combo_paicod_Selectedtext_set);
         AV31ComboPaiCod = AV24ComboSelectedValue;
         AssignAttri("", false, "AV31ComboPaiCod", AV31ComboPaiCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_paicod_Enabled = false;
            ucCombo_paicod.SendProperty(context, "", false, Combo_paicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOESTCOD' Routine */
         returnInSub = false;
         Combo_estcod_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"EstCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\", \"Cond_PaiCod\": \"#%1#\", \"Cond_EstCod\": \"#%2#\", \"Cond_ProvCod\": \"#%3#\"", edtPaiCod_Internalname, edtEstCod_Internalname, edtProvCod_Internalname, "", "", "", "", "", "");
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "DataListProcParametersPrefix", Combo_estcod_Datalistprocparametersprefix);
         GXt_char2 = AV26Combo_DataJson;
         new GeneXus.Programs.ventas.clientesloaddvcombo(context ).execute(  "EstCod",  Gx_mode,  false,  AV7CliCod,  A139PaiCod,  A140EstCod,  A141ProvCod,  "", out  AV24ComboSelectedValue, out  AV25ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV24ComboSelectedValue", AV24ComboSelectedValue);
         AssignAttri("", false, "AV25ComboSelectedText", AV25ComboSelectedText);
         AV26Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV26Combo_DataJson", AV26Combo_DataJson);
         Combo_estcod_Selectedvalue_set = AV24ComboSelectedValue;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedValue_set", Combo_estcod_Selectedvalue_set);
         Combo_estcod_Selectedtext_set = AV25ComboSelectedText;
         ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "SelectedText_set", Combo_estcod_Selectedtext_set);
         AV28ComboEstCod = AV24ComboSelectedValue;
         AssignAttri("", false, "AV28ComboEstCod", AV28ComboEstCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_estcod_Enabled = false;
            ucCombo_estcod.SendProperty(context, "", false, Combo_estcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
         }
      }

      protected void ZM7O11( short GX_JID )
      {
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z161CliDsc = T007O8_A161CliDsc[0];
               Z596CliDir = T007O8_A596CliDir[0];
               Z629CliTel1 = T007O8_A629CliTel1[0];
               Z630CliTel2 = T007O8_A630CliTel2[0];
               Z611CliFax = T007O8_A611CliFax[0];
               Z575CliCel = T007O8_A575CliCel[0];
               Z609CliEma = T007O8_A609CliEma[0];
               Z637CliWeb = T007O8_A637CliWeb[0];
               Z627CliSts = T007O8_A627CliSts[0];
               Z613CliLim = T007O8_A613CliLim[0];
               Z618CliRef1 = T007O8_A618CliRef1[0];
               Z619CliRef2 = T007O8_A619CliRef2[0];
               Z620CliRef3 = T007O8_A620CliRef3[0];
               Z621CliRef4 = T007O8_A621CliRef4[0];
               Z622CliRef5 = T007O8_A622CliRef5[0];
               Z623CliRef6 = T007O8_A623CliRef6[0];
               Z624CliRef7 = T007O8_A624CliRef7[0];
               Z625CliRef8 = T007O8_A625CliRef8[0];
               Z581CliCont1 = T007O8_A581CliCont1[0];
               Z587CliCTel1 = T007O8_A587CliCTel1[0];
               Z582CliCont2 = T007O8_A582CliCont2[0];
               Z588CliCTel2 = T007O8_A588CliCTel2[0];
               Z583CliCont3 = T007O8_A583CliCont3[0];
               Z589CliCtel3 = T007O8_A589CliCtel3[0];
               Z584CliCont4 = T007O8_A584CliCont4[0];
               Z590CliCTel4 = T007O8_A590CliCTel4[0];
               Z585CliCont5 = T007O8_A585CliCont5[0];
               Z591CliCtel5 = T007O8_A591CliCtel5[0];
               Z632CliTItemDir = T007O8_A632CliTItemDir[0];
               Z614CliMon = T007O8_A614CliMon[0];
               Z636CliVincula = T007O8_A636CliVincula[0];
               Z626CliRetencion = T007O8_A626CliRetencion[0];
               Z617CliPercepcion = T007O8_A617CliPercepcion[0];
               Z615CliNom = T007O8_A615CliNom[0];
               Z574CliAPEP = T007O8_A574CliAPEP[0];
               Z573CliAPEM = T007O8_A573CliAPEM[0];
               Z633CliUsuCod = T007O8_A633CliUsuCod[0];
               Z634CliUsuFec = T007O8_A634CliUsuFec[0];
               Z610CliEMAPer = T007O8_A610CliEMAPer[0];
               Z616CliPassPer = T007O8_A616CliPassPer[0];
               Z628CliTCon = T007O8_A628CliTCon[0];
               Z631CliTipCod = T007O8_A631CliTipCod[0];
               Z608CliDTAval = T007O8_A608CliDTAval[0];
               Z139PaiCod = T007O8_A139PaiCod[0];
               Z140EstCod = T007O8_A140EstCod[0];
               Z141ProvCod = T007O8_A141ProvCod[0];
               Z142DisCod = T007O8_A142DisCod[0];
               Z159TipCCod = T007O8_A159TipCCod[0];
               Z137Conpcod = T007O8_A137Conpcod[0];
               Z158ZonCod = T007O8_A158ZonCod[0];
               Z157TipSCod = T007O8_A157TipSCod[0];
               Z160CliVend = T007O8_A160CliVend[0];
               Z156CliTipLCod = T007O8_A156CliTipLCod[0];
            }
            else
            {
               Z161CliDsc = A161CliDsc;
               Z596CliDir = A596CliDir;
               Z629CliTel1 = A629CliTel1;
               Z630CliTel2 = A630CliTel2;
               Z611CliFax = A611CliFax;
               Z575CliCel = A575CliCel;
               Z609CliEma = A609CliEma;
               Z637CliWeb = A637CliWeb;
               Z627CliSts = A627CliSts;
               Z613CliLim = A613CliLim;
               Z618CliRef1 = A618CliRef1;
               Z619CliRef2 = A619CliRef2;
               Z620CliRef3 = A620CliRef3;
               Z621CliRef4 = A621CliRef4;
               Z622CliRef5 = A622CliRef5;
               Z623CliRef6 = A623CliRef6;
               Z624CliRef7 = A624CliRef7;
               Z625CliRef8 = A625CliRef8;
               Z581CliCont1 = A581CliCont1;
               Z587CliCTel1 = A587CliCTel1;
               Z582CliCont2 = A582CliCont2;
               Z588CliCTel2 = A588CliCTel2;
               Z583CliCont3 = A583CliCont3;
               Z589CliCtel3 = A589CliCtel3;
               Z584CliCont4 = A584CliCont4;
               Z590CliCTel4 = A590CliCTel4;
               Z585CliCont5 = A585CliCont5;
               Z591CliCtel5 = A591CliCtel5;
               Z632CliTItemDir = A632CliTItemDir;
               Z614CliMon = A614CliMon;
               Z636CliVincula = A636CliVincula;
               Z626CliRetencion = A626CliRetencion;
               Z617CliPercepcion = A617CliPercepcion;
               Z615CliNom = A615CliNom;
               Z574CliAPEP = A574CliAPEP;
               Z573CliAPEM = A573CliAPEM;
               Z633CliUsuCod = A633CliUsuCod;
               Z634CliUsuFec = A634CliUsuFec;
               Z610CliEMAPer = A610CliEMAPer;
               Z616CliPassPer = A616CliPassPer;
               Z628CliTCon = A628CliTCon;
               Z631CliTipCod = A631CliTipCod;
               Z608CliDTAval = A608CliDTAval;
               Z139PaiCod = A139PaiCod;
               Z140EstCod = A140EstCod;
               Z141ProvCod = A141ProvCod;
               Z142DisCod = A142DisCod;
               Z159TipCCod = A159TipCCod;
               Z137Conpcod = A137Conpcod;
               Z158ZonCod = A158ZonCod;
               Z157TipSCod = A157TipSCod;
               Z160CliVend = A160CliVend;
               Z156CliTipLCod = A156CliTipLCod;
            }
         }
         if ( GX_JID == -39 )
         {
            Z45CliCod = A45CliCod;
            Z161CliDsc = A161CliDsc;
            Z596CliDir = A596CliDir;
            Z629CliTel1 = A629CliTel1;
            Z630CliTel2 = A630CliTel2;
            Z611CliFax = A611CliFax;
            Z575CliCel = A575CliCel;
            Z609CliEma = A609CliEma;
            Z637CliWeb = A637CliWeb;
            Z612CliFoto = A612CliFoto;
            Z40000CliFoto_GXI = A40000CliFoto_GXI;
            Z627CliSts = A627CliSts;
            Z613CliLim = A613CliLim;
            Z618CliRef1 = A618CliRef1;
            Z619CliRef2 = A619CliRef2;
            Z620CliRef3 = A620CliRef3;
            Z621CliRef4 = A621CliRef4;
            Z622CliRef5 = A622CliRef5;
            Z623CliRef6 = A623CliRef6;
            Z624CliRef7 = A624CliRef7;
            Z625CliRef8 = A625CliRef8;
            Z581CliCont1 = A581CliCont1;
            Z587CliCTel1 = A587CliCTel1;
            Z582CliCont2 = A582CliCont2;
            Z588CliCTel2 = A588CliCTel2;
            Z583CliCont3 = A583CliCont3;
            Z589CliCtel3 = A589CliCtel3;
            Z584CliCont4 = A584CliCont4;
            Z590CliCTel4 = A590CliCTel4;
            Z585CliCont5 = A585CliCont5;
            Z591CliCtel5 = A591CliCtel5;
            Z632CliTItemDir = A632CliTItemDir;
            Z614CliMon = A614CliMon;
            Z636CliVincula = A636CliVincula;
            Z626CliRetencion = A626CliRetencion;
            Z617CliPercepcion = A617CliPercepcion;
            Z615CliNom = A615CliNom;
            Z574CliAPEP = A574CliAPEP;
            Z573CliAPEM = A573CliAPEM;
            Z633CliUsuCod = A633CliUsuCod;
            Z634CliUsuFec = A634CliUsuFec;
            Z610CliEMAPer = A610CliEMAPer;
            Z616CliPassPer = A616CliPassPer;
            Z628CliTCon = A628CliTCon;
            Z631CliTipCod = A631CliTipCod;
            Z608CliDTAval = A608CliDTAval;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z142DisCod = A142DisCod;
            Z159TipCCod = A159TipCCod;
            Z137Conpcod = A137Conpcod;
            Z158ZonCod = A158ZonCod;
            Z157TipSCod = A157TipSCod;
            Z160CliVend = A160CliVend;
            Z156CliTipLCod = A156CliTipLCod;
            Z602EstDsc = A602EstDsc;
            Z635CliVendDsc = A635CliVendDsc;
            Z603ProvDsc = A603ProvDsc;
            Z604DisDsc = A604DisDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV52Pgmname = "Ventas.Clientes";
         AssignAttri("", false, "AV52Pgmname", AV52Pgmname);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CliCod)) )
         {
            A45CliCod = AV7CliCod;
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CliCod)) )
         {
            edtCliCod_Enabled = 0;
            AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCliCod_Enabled = 1;
            AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CliCod)) )
         {
            edtCliCod_Enabled = 0;
            AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstCod)) )
         {
            edtEstCod_Enabled = 0;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEstCod_Enabled = 1;
            AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_PaiCod)) )
         {
            edtPaiCod_Enabled = 0;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPaiCod_Enabled = 1;
            AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TipCCod) )
         {
            edtTipCCod_Enabled = 0;
            AssignProp("", false, edtTipCCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipCCod_Enabled = 1;
            AssignProp("", false, edtTipCCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_Conpcod) )
         {
            edtConpcod_Enabled = 0;
            AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         }
         else
         {
            edtConpcod_Enabled = 1;
            AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_CliVend) )
         {
            edtCliVend_Enabled = 0;
            AssignProp("", false, edtCliVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliVend_Enabled), 5, 0), true);
         }
         else
         {
            edtCliVend_Enabled = 1;
            AssignProp("", false, edtCliVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliVend_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
         {
            edtDisCod_Enabled = 0;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         else
         {
            edtDisCod_Enabled = 1;
            AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProvCod)) )
         {
            edtProvCod_Enabled = 0;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProvCod_Enabled = 1;
            AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_ZonCod) )
         {
            edtZonCod_Enabled = 0;
            AssignProp("", false, edtZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonCod_Enabled), 5, 0), true);
         }
         else
         {
            edtZonCod_Enabled = 1;
            AssignProp("", false, edtZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_CliTipLCod) )
         {
            edtCliTipLCod_Enabled = 0;
            AssignProp("", false, edtCliTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTipLCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCliTipLCod_Enabled = 1;
            AssignProp("", false, edtCliTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTipLCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TipSCod) )
         {
            edtTipSCod_Enabled = 0;
            AssignProp("", false, edtTipSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipSCod_Enabled = 1;
            AssignProp("", false, edtTipSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstCod)) )
         {
            A140EstCod = AV11Insert_EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         else
         {
            A140EstCod = AV28ComboEstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_PaiCod)) )
         {
            A139PaiCod = AV12Insert_PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         else
         {
            A139PaiCod = AV31ComboPaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TipCCod) )
         {
            A159TipCCod = AV13Insert_TipCCod;
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         }
         else
         {
            A159TipCCod = AV33ComboTipCCod;
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_Conpcod) )
         {
            A137Conpcod = AV14Insert_Conpcod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
         else
         {
            A137Conpcod = AV35ComboConpcod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_CliVend) )
         {
            A160CliVend = AV15Insert_CliVend;
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
         }
         else
         {
            A160CliVend = AV37ComboCliVend;
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Insert_DisCod)) )
         {
            A142DisCod = AV16Insert_DisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         else
         {
            A142DisCod = AV40ComboDisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_ProvCod)) )
         {
            A141ProvCod = AV17Insert_ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         else
         {
            A141ProvCod = AV44ComboProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_ZonCod) )
         {
            A158ZonCod = AV18Insert_ZonCod;
            n158ZonCod = false;
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
         }
         else
         {
            if ( (0==AV46ComboZonCod) )
            {
               A158ZonCod = 0;
               n158ZonCod = false;
               AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
               n158ZonCod = true;
               AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV46ComboZonCod) )
               {
                  A158ZonCod = AV46ComboZonCod;
                  n158ZonCod = false;
                  AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_CliTipLCod) )
         {
            A156CliTipLCod = AV19Insert_CliTipLCod;
            n156CliTipLCod = false;
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
         }
         else
         {
            if ( (0==AV48ComboCliTipLCod) )
            {
               A156CliTipLCod = 0;
               n156CliTipLCod = false;
               AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
               n156CliTipLCod = true;
               AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            }
            else
            {
               if ( ! (0==AV48ComboCliTipLCod) )
               {
                  A156CliTipLCod = AV48ComboCliTipLCod;
                  n156CliTipLCod = false;
                  AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TipSCod) )
         {
            A157TipSCod = AV20Insert_TipSCod;
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
         }
         else
         {
            A157TipSCod = AV51ComboTipSCod;
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T007O9 */
            pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod});
            A602EstDsc = T007O9_A602EstDsc[0];
            pr_default.close(7);
            /* Using cursor T007O16 */
            pr_default.execute(14, new Object[] {A160CliVend});
            A635CliVendDsc = T007O16_A635CliVendDsc[0];
            AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
            pr_default.close(14);
            /* Using cursor T007O10 */
            pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            A603ProvDsc = T007O10_A603ProvDsc[0];
            pr_default.close(8);
            /* Using cursor T007O11 */
            pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            A604DisDsc = T007O11_A604DisDsc[0];
            pr_default.close(9);
         }
      }

      protected void Load7O11( )
      {
         /* Using cursor T007O18 */
         pr_default.execute(16, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound11 = 1;
            A161CliDsc = T007O18_A161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            A596CliDir = T007O18_A596CliDir[0];
            AssignAttri("", false, "A596CliDir", A596CliDir);
            A629CliTel1 = T007O18_A629CliTel1[0];
            AssignAttri("", false, "A629CliTel1", A629CliTel1);
            A630CliTel2 = T007O18_A630CliTel2[0];
            AssignAttri("", false, "A630CliTel2", A630CliTel2);
            A611CliFax = T007O18_A611CliFax[0];
            AssignAttri("", false, "A611CliFax", A611CliFax);
            A575CliCel = T007O18_A575CliCel[0];
            AssignAttri("", false, "A575CliCel", A575CliCel);
            A609CliEma = T007O18_A609CliEma[0];
            AssignAttri("", false, "A609CliEma", A609CliEma);
            A637CliWeb = T007O18_A637CliWeb[0];
            AssignAttri("", false, "A637CliWeb", A637CliWeb);
            A40000CliFoto_GXI = T007O18_A40000CliFoto_GXI[0];
            n40000CliFoto_GXI = T007O18_n40000CliFoto_GXI[0];
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            A627CliSts = T007O18_A627CliSts[0];
            AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
            A613CliLim = T007O18_A613CliLim[0];
            AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
            A635CliVendDsc = T007O18_A635CliVendDsc[0];
            AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
            A618CliRef1 = T007O18_A618CliRef1[0];
            AssignAttri("", false, "A618CliRef1", A618CliRef1);
            A619CliRef2 = T007O18_A619CliRef2[0];
            AssignAttri("", false, "A619CliRef2", A619CliRef2);
            A620CliRef3 = T007O18_A620CliRef3[0];
            AssignAttri("", false, "A620CliRef3", A620CliRef3);
            A621CliRef4 = T007O18_A621CliRef4[0];
            AssignAttri("", false, "A621CliRef4", A621CliRef4);
            A622CliRef5 = T007O18_A622CliRef5[0];
            AssignAttri("", false, "A622CliRef5", A622CliRef5);
            A623CliRef6 = T007O18_A623CliRef6[0];
            AssignAttri("", false, "A623CliRef6", A623CliRef6);
            A624CliRef7 = T007O18_A624CliRef7[0];
            AssignAttri("", false, "A624CliRef7", A624CliRef7);
            A625CliRef8 = T007O18_A625CliRef8[0];
            AssignAttri("", false, "A625CliRef8", A625CliRef8);
            A581CliCont1 = T007O18_A581CliCont1[0];
            AssignAttri("", false, "A581CliCont1", A581CliCont1);
            A587CliCTel1 = T007O18_A587CliCTel1[0];
            AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
            A582CliCont2 = T007O18_A582CliCont2[0];
            AssignAttri("", false, "A582CliCont2", A582CliCont2);
            A588CliCTel2 = T007O18_A588CliCTel2[0];
            AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
            A583CliCont3 = T007O18_A583CliCont3[0];
            AssignAttri("", false, "A583CliCont3", A583CliCont3);
            A589CliCtel3 = T007O18_A589CliCtel3[0];
            AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
            A584CliCont4 = T007O18_A584CliCont4[0];
            AssignAttri("", false, "A584CliCont4", A584CliCont4);
            A590CliCTel4 = T007O18_A590CliCTel4[0];
            AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
            A585CliCont5 = T007O18_A585CliCont5[0];
            AssignAttri("", false, "A585CliCont5", A585CliCont5);
            A591CliCtel5 = T007O18_A591CliCtel5[0];
            AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
            A632CliTItemDir = T007O18_A632CliTItemDir[0];
            AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
            A614CliMon = T007O18_A614CliMon[0];
            AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
            A636CliVincula = T007O18_A636CliVincula[0];
            AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
            A626CliRetencion = T007O18_A626CliRetencion[0];
            AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
            A617CliPercepcion = T007O18_A617CliPercepcion[0];
            AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
            A615CliNom = T007O18_A615CliNom[0];
            AssignAttri("", false, "A615CliNom", A615CliNom);
            A574CliAPEP = T007O18_A574CliAPEP[0];
            AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
            A573CliAPEM = T007O18_A573CliAPEM[0];
            AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
            A633CliUsuCod = T007O18_A633CliUsuCod[0];
            AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
            A634CliUsuFec = T007O18_A634CliUsuFec[0];
            AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A610CliEMAPer = T007O18_A610CliEMAPer[0];
            AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
            A616CliPassPer = T007O18_A616CliPassPer[0];
            AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
            A628CliTCon = T007O18_A628CliTCon[0];
            AssignAttri("", false, "A628CliTCon", StringUtil.LTrimStr( (decimal)(A628CliTCon), 6, 0));
            A631CliTipCod = T007O18_A631CliTipCod[0];
            AssignAttri("", false, "A631CliTipCod", A631CliTipCod);
            A608CliDTAval = T007O18_A608CliDTAval[0];
            AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            A602EstDsc = T007O18_A602EstDsc[0];
            A603ProvDsc = T007O18_A603ProvDsc[0];
            A604DisDsc = T007O18_A604DisDsc[0];
            A139PaiCod = T007O18_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T007O18_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T007O18_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T007O18_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A159TipCCod = T007O18_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            A137Conpcod = T007O18_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A158ZonCod = T007O18_A158ZonCod[0];
            n158ZonCod = T007O18_n158ZonCod[0];
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            A157TipSCod = T007O18_A157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A160CliVend = T007O18_A160CliVend[0];
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            A156CliTipLCod = T007O18_A156CliTipLCod[0];
            n156CliTipLCod = T007O18_n156CliTipLCod[0];
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            A612CliFoto = T007O18_A612CliFoto[0];
            n612CliFoto = T007O18_n612CliFoto[0];
            AssignAttri("", false, "A612CliFoto", A612CliFoto);
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            ZM7O11( -39) ;
         }
         pr_default.close(16);
         OnLoadActions7O11( ) ;
      }

      protected void OnLoadActions7O11( )
      {
         A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
      }

      protected void CheckExtendedTable7O11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007O9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A602EstDsc = T007O9_A602EstDsc[0];
         pr_default.close(7);
         /* Using cursor T007O10 */
         pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A603ProvDsc = T007O10_A603ProvDsc[0];
         pr_default.close(8);
         /* Using cursor T007O11 */
         pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A604DisDsc = T007O11_A604DisDsc[0];
         pr_default.close(9);
         nIsDirty_11 = 1;
         A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
         if ( ! ( GxRegex.IsMatch(A609CliEma,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de E-Mail no coincide con el patrón especificado", "OutOfRange", 1, "CLIEMA");
            AnyError = 1;
            GX_FocusControl = edtCliEma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T007O12 */
         pr_default.execute(10, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Cliente'.", "ForeignKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(10);
         /* Using cursor T007O13 */
         pr_default.execute(11, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Condiciones de Pago'.", "ForeignKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(11);
         /* Using cursor T007O16 */
         pr_default.execute(14, new Object[] {A160CliVend});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedores'.", "ForeignKeyNotFound", 1, "CLIVEND");
            AnyError = 1;
            GX_FocusControl = edtCliVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A635CliVendDsc = T007O16_A635CliVendDsc[0];
         AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
         pr_default.close(14);
         /* Using cursor T007O14 */
         pr_default.execute(12, new Object[] {n158ZonCod, A158ZonCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A158ZonCod) ) )
            {
               GX_msglist.addItem("No existe 'Zonas'.", "ForeignKeyNotFound", 1, "ZONCOD");
               AnyError = 1;
               GX_FocusControl = edtZonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(12);
         /* Using cursor T007O17 */
         pr_default.execute(15, new Object[] {n156CliTipLCod, A156CliTipLCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A156CliTipLCod) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "CLITIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtCliTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(15);
         /* Using cursor T007O15 */
         pr_default.execute(13, new Object[] {A157TipSCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
            AnyError = 1;
            GX_FocusControl = edtTipSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         if ( ! ( (DateTime.MinValue==A634CliUsuFec) || ( A634CliUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "CLIUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtCliUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7O11( )
      {
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(14);
         pr_default.close(12);
         pr_default.close(15);
         pr_default.close(13);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_40( string A139PaiCod ,
                                string A140EstCod )
      {
         /* Using cursor T007O19 */
         pr_default.execute(17, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A602EstDsc = T007O19_A602EstDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A602EstDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_41( string A139PaiCod ,
                                string A140EstCod ,
                                string A141ProvCod )
      {
         /* Using cursor T007O20 */
         pr_default.execute(18, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A603ProvDsc = T007O20_A603ProvDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A603ProvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_42( string A139PaiCod ,
                                string A140EstCod ,
                                string A141ProvCod ,
                                string A142DisCod )
      {
         /* Using cursor T007O21 */
         pr_default.execute(19, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A604DisDsc = T007O21_A604DisDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A604DisDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_43( int A159TipCCod )
      {
         /* Using cursor T007O22 */
         pr_default.execute(20, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Cliente'.", "ForeignKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_44( int A137Conpcod )
      {
         /* Using cursor T007O23 */
         pr_default.execute(21, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Condiciones de Pago'.", "ForeignKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_47( int A160CliVend )
      {
         /* Using cursor T007O24 */
         pr_default.execute(22, new Object[] {A160CliVend});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedores'.", "ForeignKeyNotFound", 1, "CLIVEND");
            AnyError = 1;
            GX_FocusControl = edtCliVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A635CliVendDsc = T007O24_A635CliVendDsc[0];
         AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A635CliVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_45( int A158ZonCod )
      {
         /* Using cursor T007O25 */
         pr_default.execute(23, new Object[] {n158ZonCod, A158ZonCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A158ZonCod) ) )
            {
               GX_msglist.addItem("No existe 'Zonas'.", "ForeignKeyNotFound", 1, "ZONCOD");
               AnyError = 1;
               GX_FocusControl = edtZonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_48( int A156CliTipLCod )
      {
         /* Using cursor T007O26 */
         pr_default.execute(24, new Object[] {n156CliTipLCod, A156CliTipLCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A156CliTipLCod) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "CLITIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtCliTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_46( int A157TipSCod )
      {
         /* Using cursor T007O27 */
         pr_default.execute(25, new Object[] {A157TipSCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
            AnyError = 1;
            GX_FocusControl = edtTipSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey7O11( )
      {
         /* Using cursor T007O28 */
         pr_default.execute(26, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007O8 */
         pr_default.execute(6, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM7O11( 39) ;
            RcdFound11 = 1;
            A45CliCod = T007O8_A45CliCod[0];
            n45CliCod = T007O8_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A161CliDsc = T007O8_A161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            A596CliDir = T007O8_A596CliDir[0];
            AssignAttri("", false, "A596CliDir", A596CliDir);
            A629CliTel1 = T007O8_A629CliTel1[0];
            AssignAttri("", false, "A629CliTel1", A629CliTel1);
            A630CliTel2 = T007O8_A630CliTel2[0];
            AssignAttri("", false, "A630CliTel2", A630CliTel2);
            A611CliFax = T007O8_A611CliFax[0];
            AssignAttri("", false, "A611CliFax", A611CliFax);
            A575CliCel = T007O8_A575CliCel[0];
            AssignAttri("", false, "A575CliCel", A575CliCel);
            A609CliEma = T007O8_A609CliEma[0];
            AssignAttri("", false, "A609CliEma", A609CliEma);
            A637CliWeb = T007O8_A637CliWeb[0];
            AssignAttri("", false, "A637CliWeb", A637CliWeb);
            A40000CliFoto_GXI = T007O8_A40000CliFoto_GXI[0];
            n40000CliFoto_GXI = T007O8_n40000CliFoto_GXI[0];
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            A627CliSts = T007O8_A627CliSts[0];
            AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
            A613CliLim = T007O8_A613CliLim[0];
            AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
            A618CliRef1 = T007O8_A618CliRef1[0];
            AssignAttri("", false, "A618CliRef1", A618CliRef1);
            A619CliRef2 = T007O8_A619CliRef2[0];
            AssignAttri("", false, "A619CliRef2", A619CliRef2);
            A620CliRef3 = T007O8_A620CliRef3[0];
            AssignAttri("", false, "A620CliRef3", A620CliRef3);
            A621CliRef4 = T007O8_A621CliRef4[0];
            AssignAttri("", false, "A621CliRef4", A621CliRef4);
            A622CliRef5 = T007O8_A622CliRef5[0];
            AssignAttri("", false, "A622CliRef5", A622CliRef5);
            A623CliRef6 = T007O8_A623CliRef6[0];
            AssignAttri("", false, "A623CliRef6", A623CliRef6);
            A624CliRef7 = T007O8_A624CliRef7[0];
            AssignAttri("", false, "A624CliRef7", A624CliRef7);
            A625CliRef8 = T007O8_A625CliRef8[0];
            AssignAttri("", false, "A625CliRef8", A625CliRef8);
            A581CliCont1 = T007O8_A581CliCont1[0];
            AssignAttri("", false, "A581CliCont1", A581CliCont1);
            A587CliCTel1 = T007O8_A587CliCTel1[0];
            AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
            A582CliCont2 = T007O8_A582CliCont2[0];
            AssignAttri("", false, "A582CliCont2", A582CliCont2);
            A588CliCTel2 = T007O8_A588CliCTel2[0];
            AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
            A583CliCont3 = T007O8_A583CliCont3[0];
            AssignAttri("", false, "A583CliCont3", A583CliCont3);
            A589CliCtel3 = T007O8_A589CliCtel3[0];
            AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
            A584CliCont4 = T007O8_A584CliCont4[0];
            AssignAttri("", false, "A584CliCont4", A584CliCont4);
            A590CliCTel4 = T007O8_A590CliCTel4[0];
            AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
            A585CliCont5 = T007O8_A585CliCont5[0];
            AssignAttri("", false, "A585CliCont5", A585CliCont5);
            A591CliCtel5 = T007O8_A591CliCtel5[0];
            AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
            A632CliTItemDir = T007O8_A632CliTItemDir[0];
            AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
            A614CliMon = T007O8_A614CliMon[0];
            AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
            A636CliVincula = T007O8_A636CliVincula[0];
            AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
            A626CliRetencion = T007O8_A626CliRetencion[0];
            AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
            A617CliPercepcion = T007O8_A617CliPercepcion[0];
            AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
            A615CliNom = T007O8_A615CliNom[0];
            AssignAttri("", false, "A615CliNom", A615CliNom);
            A574CliAPEP = T007O8_A574CliAPEP[0];
            AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
            A573CliAPEM = T007O8_A573CliAPEM[0];
            AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
            A633CliUsuCod = T007O8_A633CliUsuCod[0];
            AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
            A634CliUsuFec = T007O8_A634CliUsuFec[0];
            AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A610CliEMAPer = T007O8_A610CliEMAPer[0];
            AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
            A616CliPassPer = T007O8_A616CliPassPer[0];
            AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
            A628CliTCon = T007O8_A628CliTCon[0];
            AssignAttri("", false, "A628CliTCon", StringUtil.LTrimStr( (decimal)(A628CliTCon), 6, 0));
            A631CliTipCod = T007O8_A631CliTipCod[0];
            AssignAttri("", false, "A631CliTipCod", A631CliTipCod);
            A608CliDTAval = T007O8_A608CliDTAval[0];
            AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            A139PaiCod = T007O8_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T007O8_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T007O8_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T007O8_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A159TipCCod = T007O8_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            A137Conpcod = T007O8_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A158ZonCod = T007O8_A158ZonCod[0];
            n158ZonCod = T007O8_n158ZonCod[0];
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            A157TipSCod = T007O8_A157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A160CliVend = T007O8_A160CliVend[0];
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            A156CliTipLCod = T007O8_A156CliTipLCod[0];
            n156CliTipLCod = T007O8_n156CliTipLCod[0];
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            A612CliFoto = T007O8_A612CliFoto[0];
            n612CliFoto = T007O8_n612CliFoto[0];
            AssignAttri("", false, "A612CliFoto", A612CliFoto);
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            Z45CliCod = A45CliCod;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7O11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey7O11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey7O11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey7O11( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T007O29 */
         pr_default.execute(27, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(27) != 101) )
         {
            while ( (pr_default.getStatus(27) != 101) && ( ( StringUtil.StrCmp(T007O29_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               pr_default.readNext(27);
            }
            if ( (pr_default.getStatus(27) != 101) && ( ( StringUtil.StrCmp(T007O29_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               A45CliCod = T007O29_A45CliCod[0];
               n45CliCod = T007O29_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(27);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T007O30 */
         pr_default.execute(28, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(28) != 101) )
         {
            while ( (pr_default.getStatus(28) != 101) && ( ( StringUtil.StrCmp(T007O30_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               pr_default.readNext(28);
            }
            if ( (pr_default.getStatus(28) != 101) && ( ( StringUtil.StrCmp(T007O30_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               A45CliCod = T007O30_A45CliCod[0];
               n45CliCod = T007O30_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(28);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7O11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7O11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
               {
                  A45CliCod = Z45CliCod;
                  n45CliCod = false;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7O11( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7O11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLICOD");
                     AnyError = 1;
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7O11( ) ;
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
         if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
         {
            A45CliCod = Z45CliCod;
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7O11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007O7 */
            pr_default.execute(5, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z161CliDsc, T007O7_A161CliDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z596CliDir, T007O7_A596CliDir[0]) != 0 ) || ( StringUtil.StrCmp(Z629CliTel1, T007O7_A629CliTel1[0]) != 0 ) || ( StringUtil.StrCmp(Z630CliTel2, T007O7_A630CliTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z611CliFax, T007O7_A611CliFax[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z575CliCel, T007O7_A575CliCel[0]) != 0 ) || ( StringUtil.StrCmp(Z609CliEma, T007O7_A609CliEma[0]) != 0 ) || ( StringUtil.StrCmp(Z637CliWeb, T007O7_A637CliWeb[0]) != 0 ) || ( Z627CliSts != T007O7_A627CliSts[0] ) || ( Z613CliLim != T007O7_A613CliLim[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z618CliRef1, T007O7_A618CliRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z619CliRef2, T007O7_A619CliRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z620CliRef3, T007O7_A620CliRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z621CliRef4, T007O7_A621CliRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z622CliRef5, T007O7_A622CliRef5[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z623CliRef6, T007O7_A623CliRef6[0]) != 0 ) || ( StringUtil.StrCmp(Z624CliRef7, T007O7_A624CliRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z625CliRef8, T007O7_A625CliRef8[0]) != 0 ) || ( StringUtil.StrCmp(Z581CliCont1, T007O7_A581CliCont1[0]) != 0 ) || ( StringUtil.StrCmp(Z587CliCTel1, T007O7_A587CliCTel1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z582CliCont2, T007O7_A582CliCont2[0]) != 0 ) || ( StringUtil.StrCmp(Z588CliCTel2, T007O7_A588CliCTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z583CliCont3, T007O7_A583CliCont3[0]) != 0 ) || ( StringUtil.StrCmp(Z589CliCtel3, T007O7_A589CliCtel3[0]) != 0 ) || ( StringUtil.StrCmp(Z584CliCont4, T007O7_A584CliCont4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z590CliCTel4, T007O7_A590CliCTel4[0]) != 0 ) || ( StringUtil.StrCmp(Z585CliCont5, T007O7_A585CliCont5[0]) != 0 ) || ( StringUtil.StrCmp(Z591CliCtel5, T007O7_A591CliCtel5[0]) != 0 ) || ( Z632CliTItemDir != T007O7_A632CliTItemDir[0] ) || ( Z614CliMon != T007O7_A614CliMon[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z636CliVincula != T007O7_A636CliVincula[0] ) || ( Z626CliRetencion != T007O7_A626CliRetencion[0] ) || ( Z617CliPercepcion != T007O7_A617CliPercepcion[0] ) || ( StringUtil.StrCmp(Z615CliNom, T007O7_A615CliNom[0]) != 0 ) || ( StringUtil.StrCmp(Z574CliAPEP, T007O7_A574CliAPEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z573CliAPEM, T007O7_A573CliAPEM[0]) != 0 ) || ( StringUtil.StrCmp(Z633CliUsuCod, T007O7_A633CliUsuCod[0]) != 0 ) || ( Z634CliUsuFec != T007O7_A634CliUsuFec[0] ) || ( StringUtil.StrCmp(Z610CliEMAPer, T007O7_A610CliEMAPer[0]) != 0 ) || ( StringUtil.StrCmp(Z616CliPassPer, T007O7_A616CliPassPer[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z628CliTCon != T007O7_A628CliTCon[0] ) || ( StringUtil.StrCmp(Z631CliTipCod, T007O7_A631CliTipCod[0]) != 0 ) || ( Z608CliDTAval != T007O7_A608CliDTAval[0] ) || ( StringUtil.StrCmp(Z139PaiCod, T007O7_A139PaiCod[0]) != 0 ) || ( StringUtil.StrCmp(Z140EstCod, T007O7_A140EstCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z141ProvCod, T007O7_A141ProvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z142DisCod, T007O7_A142DisCod[0]) != 0 ) || ( Z159TipCCod != T007O7_A159TipCCod[0] ) || ( Z137Conpcod != T007O7_A137Conpcod[0] ) || ( Z158ZonCod != T007O7_A158ZonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z157TipSCod != T007O7_A157TipSCod[0] ) || ( Z160CliVend != T007O7_A160CliVend[0] ) || ( Z156CliTipLCod != T007O7_A156CliTipLCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z161CliDsc, T007O7_A161CliDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDsc");
                  GXUtil.WriteLogRaw("Old: ",Z161CliDsc);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A161CliDsc[0]);
               }
               if ( StringUtil.StrCmp(Z596CliDir, T007O7_A596CliDir[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDir");
                  GXUtil.WriteLogRaw("Old: ",Z596CliDir);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A596CliDir[0]);
               }
               if ( StringUtil.StrCmp(Z629CliTel1, T007O7_A629CliTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTel1");
                  GXUtil.WriteLogRaw("Old: ",Z629CliTel1);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A629CliTel1[0]);
               }
               if ( StringUtil.StrCmp(Z630CliTel2, T007O7_A630CliTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTel2");
                  GXUtil.WriteLogRaw("Old: ",Z630CliTel2);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A630CliTel2[0]);
               }
               if ( StringUtil.StrCmp(Z611CliFax, T007O7_A611CliFax[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliFax");
                  GXUtil.WriteLogRaw("Old: ",Z611CliFax);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A611CliFax[0]);
               }
               if ( StringUtil.StrCmp(Z575CliCel, T007O7_A575CliCel[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCel");
                  GXUtil.WriteLogRaw("Old: ",Z575CliCel);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A575CliCel[0]);
               }
               if ( StringUtil.StrCmp(Z609CliEma, T007O7_A609CliEma[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliEma");
                  GXUtil.WriteLogRaw("Old: ",Z609CliEma);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A609CliEma[0]);
               }
               if ( StringUtil.StrCmp(Z637CliWeb, T007O7_A637CliWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliWeb");
                  GXUtil.WriteLogRaw("Old: ",Z637CliWeb);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A637CliWeb[0]);
               }
               if ( Z627CliSts != T007O7_A627CliSts[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliSts");
                  GXUtil.WriteLogRaw("Old: ",Z627CliSts);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A627CliSts[0]);
               }
               if ( Z613CliLim != T007O7_A613CliLim[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliLim");
                  GXUtil.WriteLogRaw("Old: ",Z613CliLim);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A613CliLim[0]);
               }
               if ( StringUtil.StrCmp(Z618CliRef1, T007O7_A618CliRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef1");
                  GXUtil.WriteLogRaw("Old: ",Z618CliRef1);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A618CliRef1[0]);
               }
               if ( StringUtil.StrCmp(Z619CliRef2, T007O7_A619CliRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef2");
                  GXUtil.WriteLogRaw("Old: ",Z619CliRef2);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A619CliRef2[0]);
               }
               if ( StringUtil.StrCmp(Z620CliRef3, T007O7_A620CliRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef3");
                  GXUtil.WriteLogRaw("Old: ",Z620CliRef3);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A620CliRef3[0]);
               }
               if ( StringUtil.StrCmp(Z621CliRef4, T007O7_A621CliRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef4");
                  GXUtil.WriteLogRaw("Old: ",Z621CliRef4);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A621CliRef4[0]);
               }
               if ( StringUtil.StrCmp(Z622CliRef5, T007O7_A622CliRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef5");
                  GXUtil.WriteLogRaw("Old: ",Z622CliRef5);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A622CliRef5[0]);
               }
               if ( StringUtil.StrCmp(Z623CliRef6, T007O7_A623CliRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef6");
                  GXUtil.WriteLogRaw("Old: ",Z623CliRef6);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A623CliRef6[0]);
               }
               if ( StringUtil.StrCmp(Z624CliRef7, T007O7_A624CliRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef7");
                  GXUtil.WriteLogRaw("Old: ",Z624CliRef7);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A624CliRef7[0]);
               }
               if ( StringUtil.StrCmp(Z625CliRef8, T007O7_A625CliRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRef8");
                  GXUtil.WriteLogRaw("Old: ",Z625CliRef8);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A625CliRef8[0]);
               }
               if ( StringUtil.StrCmp(Z581CliCont1, T007O7_A581CliCont1[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCont1");
                  GXUtil.WriteLogRaw("Old: ",Z581CliCont1);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A581CliCont1[0]);
               }
               if ( StringUtil.StrCmp(Z587CliCTel1, T007O7_A587CliCTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCTel1");
                  GXUtil.WriteLogRaw("Old: ",Z587CliCTel1);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A587CliCTel1[0]);
               }
               if ( StringUtil.StrCmp(Z582CliCont2, T007O7_A582CliCont2[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCont2");
                  GXUtil.WriteLogRaw("Old: ",Z582CliCont2);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A582CliCont2[0]);
               }
               if ( StringUtil.StrCmp(Z588CliCTel2, T007O7_A588CliCTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCTel2");
                  GXUtil.WriteLogRaw("Old: ",Z588CliCTel2);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A588CliCTel2[0]);
               }
               if ( StringUtil.StrCmp(Z583CliCont3, T007O7_A583CliCont3[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCont3");
                  GXUtil.WriteLogRaw("Old: ",Z583CliCont3);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A583CliCont3[0]);
               }
               if ( StringUtil.StrCmp(Z589CliCtel3, T007O7_A589CliCtel3[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCtel3");
                  GXUtil.WriteLogRaw("Old: ",Z589CliCtel3);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A589CliCtel3[0]);
               }
               if ( StringUtil.StrCmp(Z584CliCont4, T007O7_A584CliCont4[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCont4");
                  GXUtil.WriteLogRaw("Old: ",Z584CliCont4);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A584CliCont4[0]);
               }
               if ( StringUtil.StrCmp(Z590CliCTel4, T007O7_A590CliCTel4[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCTel4");
                  GXUtil.WriteLogRaw("Old: ",Z590CliCTel4);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A590CliCTel4[0]);
               }
               if ( StringUtil.StrCmp(Z585CliCont5, T007O7_A585CliCont5[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCont5");
                  GXUtil.WriteLogRaw("Old: ",Z585CliCont5);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A585CliCont5[0]);
               }
               if ( StringUtil.StrCmp(Z591CliCtel5, T007O7_A591CliCtel5[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliCtel5");
                  GXUtil.WriteLogRaw("Old: ",Z591CliCtel5);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A591CliCtel5[0]);
               }
               if ( Z632CliTItemDir != T007O7_A632CliTItemDir[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTItemDir");
                  GXUtil.WriteLogRaw("Old: ",Z632CliTItemDir);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A632CliTItemDir[0]);
               }
               if ( Z614CliMon != T007O7_A614CliMon[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliMon");
                  GXUtil.WriteLogRaw("Old: ",Z614CliMon);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A614CliMon[0]);
               }
               if ( Z636CliVincula != T007O7_A636CliVincula[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliVincula");
                  GXUtil.WriteLogRaw("Old: ",Z636CliVincula);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A636CliVincula[0]);
               }
               if ( Z626CliRetencion != T007O7_A626CliRetencion[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliRetencion");
                  GXUtil.WriteLogRaw("Old: ",Z626CliRetencion);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A626CliRetencion[0]);
               }
               if ( Z617CliPercepcion != T007O7_A617CliPercepcion[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliPercepcion");
                  GXUtil.WriteLogRaw("Old: ",Z617CliPercepcion);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A617CliPercepcion[0]);
               }
               if ( StringUtil.StrCmp(Z615CliNom, T007O7_A615CliNom[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliNom");
                  GXUtil.WriteLogRaw("Old: ",Z615CliNom);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A615CliNom[0]);
               }
               if ( StringUtil.StrCmp(Z574CliAPEP, T007O7_A574CliAPEP[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliAPEP");
                  GXUtil.WriteLogRaw("Old: ",Z574CliAPEP);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A574CliAPEP[0]);
               }
               if ( StringUtil.StrCmp(Z573CliAPEM, T007O7_A573CliAPEM[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliAPEM");
                  GXUtil.WriteLogRaw("Old: ",Z573CliAPEM);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A573CliAPEM[0]);
               }
               if ( StringUtil.StrCmp(Z633CliUsuCod, T007O7_A633CliUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z633CliUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A633CliUsuCod[0]);
               }
               if ( Z634CliUsuFec != T007O7_A634CliUsuFec[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z634CliUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A634CliUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z610CliEMAPer, T007O7_A610CliEMAPer[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliEMAPer");
                  GXUtil.WriteLogRaw("Old: ",Z610CliEMAPer);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A610CliEMAPer[0]);
               }
               if ( StringUtil.StrCmp(Z616CliPassPer, T007O7_A616CliPassPer[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliPassPer");
                  GXUtil.WriteLogRaw("Old: ",Z616CliPassPer);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A616CliPassPer[0]);
               }
               if ( Z628CliTCon != T007O7_A628CliTCon[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTCon");
                  GXUtil.WriteLogRaw("Old: ",Z628CliTCon);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A628CliTCon[0]);
               }
               if ( StringUtil.StrCmp(Z631CliTipCod, T007O7_A631CliTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z631CliTipCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A631CliTipCod[0]);
               }
               if ( Z608CliDTAval != T007O7_A608CliDTAval[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDTAval");
                  GXUtil.WriteLogRaw("Old: ",Z608CliDTAval);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A608CliDTAval[0]);
               }
               if ( StringUtil.StrCmp(Z139PaiCod, T007O7_A139PaiCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"PaiCod");
                  GXUtil.WriteLogRaw("Old: ",Z139PaiCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A139PaiCod[0]);
               }
               if ( StringUtil.StrCmp(Z140EstCod, T007O7_A140EstCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"EstCod");
                  GXUtil.WriteLogRaw("Old: ",Z140EstCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A140EstCod[0]);
               }
               if ( StringUtil.StrCmp(Z141ProvCod, T007O7_A141ProvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"ProvCod");
                  GXUtil.WriteLogRaw("Old: ",Z141ProvCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A141ProvCod[0]);
               }
               if ( StringUtil.StrCmp(Z142DisCod, T007O7_A142DisCod[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"DisCod");
                  GXUtil.WriteLogRaw("Old: ",Z142DisCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A142DisCod[0]);
               }
               if ( Z159TipCCod != T007O7_A159TipCCod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"TipCCod");
                  GXUtil.WriteLogRaw("Old: ",Z159TipCCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A159TipCCod[0]);
               }
               if ( Z137Conpcod != T007O7_A137Conpcod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"Conpcod");
                  GXUtil.WriteLogRaw("Old: ",Z137Conpcod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A137Conpcod[0]);
               }
               if ( Z158ZonCod != T007O7_A158ZonCod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"ZonCod");
                  GXUtil.WriteLogRaw("Old: ",Z158ZonCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A158ZonCod[0]);
               }
               if ( Z157TipSCod != T007O7_A157TipSCod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"TipSCod");
                  GXUtil.WriteLogRaw("Old: ",Z157TipSCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A157TipSCod[0]);
               }
               if ( Z160CliVend != T007O7_A160CliVend[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliVend");
                  GXUtil.WriteLogRaw("Old: ",Z160CliVend);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A160CliVend[0]);
               }
               if ( Z156CliTipLCod != T007O7_A156CliTipLCod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliTipLCod");
                  GXUtil.WriteLogRaw("Old: ",Z156CliTipLCod);
                  GXUtil.WriteLogRaw("Current: ",T007O7_A156CliTipLCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7O11( )
      {
         BeforeValidate7O11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7O11( 0) ;
            CheckOptimisticConcurrency7O11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7O11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7O11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007O31 */
                     pr_default.execute(29, new Object[] {n45CliCod, A45CliCod, A161CliDsc, A596CliDir, A629CliTel1, A630CliTel2, A611CliFax, A575CliCel, A609CliEma, A637CliWeb, n612CliFoto, A612CliFoto, n40000CliFoto_GXI, A40000CliFoto_GXI, A627CliSts, A613CliLim, A618CliRef1, A619CliRef2, A620CliRef3, A621CliRef4, A622CliRef5, A623CliRef6, A624CliRef7, A625CliRef8, A581CliCont1, A587CliCTel1, A582CliCont2, A588CliCTel2, A583CliCont3, A589CliCtel3, A584CliCont4, A590CliCTel4, A585CliCont5, A591CliCtel5, A632CliTItemDir, A614CliMon, A636CliVincula, A626CliRetencion, A617CliPercepcion, A615CliNom, A574CliAPEP, A573CliAPEM, A633CliUsuCod, A634CliUsuFec, A610CliEMAPer, A616CliPassPer, A628CliTCon, A631CliTipCod, A608CliDTAval, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A159TipCCod, A137Conpcod, n158ZonCod, A158ZonCod, A157TipSCod, A160CliVend, n156CliTipLCod, A156CliTipLCod});
                     pr_default.close(29);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( (pr_default.getStatus(29) == 1) )
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
                           ProcessLevel7O11( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption7O0( ) ;
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
               Load7O11( ) ;
            }
            EndLevel7O11( ) ;
         }
         CloseExtendedTableCursors7O11( ) ;
      }

      protected void Update7O11( )
      {
         BeforeValidate7O11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7O11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7O11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7O11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007O32 */
                     pr_default.execute(30, new Object[] {A161CliDsc, A596CliDir, A629CliTel1, A630CliTel2, A611CliFax, A575CliCel, A609CliEma, A637CliWeb, A627CliSts, A613CliLim, A618CliRef1, A619CliRef2, A620CliRef3, A621CliRef4, A622CliRef5, A623CliRef6, A624CliRef7, A625CliRef8, A581CliCont1, A587CliCTel1, A582CliCont2, A588CliCTel2, A583CliCont3, A589CliCtel3, A584CliCont4, A590CliCTel4, A585CliCont5, A591CliCtel5, A632CliTItemDir, A614CliMon, A636CliVincula, A626CliRetencion, A617CliPercepcion, A615CliNom, A574CliAPEP, A573CliAPEM, A633CliUsuCod, A634CliUsuFec, A610CliEMAPer, A616CliPassPer, A628CliTCon, A631CliTipCod, A608CliDTAval, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A159TipCCod, A137Conpcod, n158ZonCod, A158ZonCod, A157TipSCod, A160CliVend, n156CliTipLCod, A156CliTipLCod, n45CliCod, A45CliCod});
                     pr_default.close(30);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( (pr_default.getStatus(30) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7O11( ) ;
                     if ( AnyError == 0 )
                     {
                        new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                        AssignAttri("", false, "A45CliCod", A45CliCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7O11( ) ;
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
            EndLevel7O11( ) ;
         }
         CloseExtendedTableCursors7O11( ) ;
      }

      protected void DeferredUpdate7O11( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T007O33 */
            pr_default.execute(31, new Object[] {n612CliFoto, A612CliFoto, n40000CliFoto_GXI, A40000CliFoto_GXI, n45CliCod, A45CliCod});
            pr_default.close(31);
            dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
         }
      }

      protected void delete( )
      {
         BeforeValidate7O11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7O11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7O11( ) ;
            AfterConfirm7O11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7O11( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart7O13( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey7O13( ) ;
                     Delete7O13( ) ;
                     ScanNext7O13( ) ;
                  }
                  ScanEnd7O13( ) ;
                  ScanStart7O83( ) ;
                  while ( RcdFound83 != 0 )
                  {
                     getByPrimaryKey7O83( ) ;
                     Delete7O83( ) ;
                     ScanNext7O83( ) ;
                  }
                  ScanEnd7O83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007O34 */
                     pr_default.execute(32, new Object[] {n45CliCod, A45CliCod});
                     pr_default.close(32);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7O11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7O11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007O35 */
            pr_default.execute(33, new Object[] {A139PaiCod, A140EstCod});
            A602EstDsc = T007O35_A602EstDsc[0];
            pr_default.close(33);
            /* Using cursor T007O36 */
            pr_default.execute(34, new Object[] {A160CliVend});
            A635CliVendDsc = T007O36_A635CliVendDsc[0];
            AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
            pr_default.close(34);
            /* Using cursor T007O37 */
            pr_default.execute(35, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            A603ProvDsc = T007O37_A603ProvDsc[0];
            pr_default.close(35);
            /* Using cursor T007O38 */
            pr_default.execute(36, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            A604DisDsc = T007O38_A604DisDsc[0];
            pr_default.close(36);
            A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
            AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007O39 */
            pr_default.execute(37, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T007O40 */
            pr_default.execute(38, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T007O41 */
            pr_default.execute(39, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Comprobantes de Percepción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T007O42 */
            pr_default.execute(40, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T007O43 */
            pr_default.execute(41, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T007O44 */
            pr_default.execute(42, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T007O45 */
            pr_default.execute(43, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T007O46 */
            pr_default.execute(44, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T007O47 */
            pr_default.execute(45, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T007O48 */
            pr_default.execute(46, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T007O49 */
            pr_default.execute(47, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T007O50 */
            pr_default.execute(48, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Vehiculos Placas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T007O51 */
            pr_default.execute(49, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T007O52 */
            pr_default.execute(50, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCLIENTESAVALES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor T007O53 */
            pr_default.execute(51, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor T007O54 */
            pr_default.execute(52, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor T007O55 */
            pr_default.execute(53, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor T007O56 */
            pr_default.execute(54, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
         }
      }

      protected void ProcessNestedLevel7O83( )
      {
         nGXsfl_368_idx = 0;
         while ( nGXsfl_368_idx < nRC_GXsfl_368 )
         {
            ReadRow7O83( ) ;
            if ( ( nRcdExists_83 != 0 ) || ( nIsMod_83 != 0 ) )
            {
               standaloneNotModal7O83( ) ;
               GetKey7O83( ) ;
               if ( ( nRcdExists_83 == 0 ) && ( nRcdDeleted_83 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7O83( ) ;
               }
               else
               {
                  if ( RcdFound83 != 0 )
                  {
                     if ( ( nRcdDeleted_83 != 0 ) && ( nRcdExists_83 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7O83( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_83 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7O83( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_83 == 0 )
                     {
                        GXCCtl = "CLIDIRITEM_" + sGXsfl_368_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliDirItem_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliDirItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A164CliDirItem), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDirDsc_Internalname, StringUtil.RTrim( A600CliDirDsc)) ;
            ChangePostValue( edtCliDirDir_Internalname, StringUtil.RTrim( A598CliDirDir)) ;
            ChangePostValue( edtCliDirPais_Internalname, StringUtil.RTrim( A605CliDirPais)) ;
            ChangePostValue( edtCliDirDep_Internalname, StringUtil.RTrim( A597CliDirDep)) ;
            ChangePostValue( edtCliDirProv_Internalname, StringUtil.RTrim( A606CliDirProv)) ;
            ChangePostValue( edtCliDirDis_Internalname, StringUtil.RTrim( A599CliDirDis)) ;
            ChangePostValue( edtCliDirZonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDirZonDsc_Internalname, StringUtil.RTrim( A607CliDirZonDsc)) ;
            ChangePostValue( "ZT_"+"Z164CliDirItem_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164CliDirItem), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z600CliDirDsc_"+sGXsfl_368_idx, StringUtil.RTrim( Z600CliDirDsc)) ;
            ChangePostValue( "ZT_"+"Z598CliDirDir_"+sGXsfl_368_idx, StringUtil.RTrim( Z598CliDirDir)) ;
            ChangePostValue( "ZT_"+"Z605CliDirPais_"+sGXsfl_368_idx, StringUtil.RTrim( Z605CliDirPais)) ;
            ChangePostValue( "ZT_"+"Z597CliDirDep_"+sGXsfl_368_idx, StringUtil.RTrim( Z597CliDirDep)) ;
            ChangePostValue( "ZT_"+"Z606CliDirProv_"+sGXsfl_368_idx, StringUtil.RTrim( Z606CliDirProv)) ;
            ChangePostValue( "ZT_"+"Z599CliDirDis_"+sGXsfl_368_idx, StringUtil.RTrim( Z599CliDirDis)) ;
            ChangePostValue( "ZT_"+"Z165CliDirZonCod_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliDirZonCod), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_83), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_83), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_83_"+sGXsfl_368_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_83), 4, 0, ".", ""))) ;
            if ( nIsMod_83 != 0 )
            {
               ChangePostValue( "CLIDIRITEM_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDIR_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDir_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRPAIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirPais_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDEP_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDep_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRPROV_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirProv_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRDIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDis_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Horizontalalignment", StringUtil.RTrim( edtCliDirZonCod_Horizontalalignment)) ;
               ChangePostValue( "CLIDIRZONDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7O83( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_83 = 0;
         nIsMod_83 = 0;
         nRcdDeleted_83 = 0;
      }

      protected void ProcessNestedLevel7O13( )
      {
         nGXsfl_383_idx = 0;
         while ( nGXsfl_383_idx < nRC_GXsfl_383 )
         {
            ReadRow7O13( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal7O13( ) ;
               GetKey7O13( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert7O13( ) ;
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( ( nRcdDeleted_13 != 0 ) && ( nRcdExists_13 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete7O13( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update7O13( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "CLICONCOD_" + sGXsfl_383_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliConCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliConCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A163CliConCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliConDsc_Internalname, StringUtil.RTrim( A578CliConDsc)) ;
            ChangePostValue( edtCliConCargo_Internalname, StringUtil.RTrim( A577CliConCargo)) ;
            ChangePostValue( edtCliConTelf_Internalname, StringUtil.RTrim( A586CliConTelf)) ;
            ChangePostValue( edtCliConArea_Internalname, StringUtil.RTrim( A576CliConArea)) ;
            ChangePostValue( edtCliConMail_Internalname, A579CliConMail) ;
            ChangePostValue( edtCliConMailFE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z163CliConCod_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z163CliConCod), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z578CliConDsc_"+sGXsfl_383_idx, StringUtil.RTrim( Z578CliConDsc)) ;
            ChangePostValue( "ZT_"+"Z577CliConCargo_"+sGXsfl_383_idx, StringUtil.RTrim( Z577CliConCargo)) ;
            ChangePostValue( "ZT_"+"Z586CliConTelf_"+sGXsfl_383_idx, StringUtil.RTrim( Z586CliConTelf)) ;
            ChangePostValue( "ZT_"+"Z576CliConArea_"+sGXsfl_383_idx, StringUtil.RTrim( Z576CliConArea)) ;
            ChangePostValue( "ZT_"+"Z579CliConMail_"+sGXsfl_383_idx, Z579CliConMail) ;
            ChangePostValue( "ZT_"+"Z580CliConMailFE_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z580CliConMailFE), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_383_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "CLICONCOD_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONDSC_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONCARGO_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCargo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONTELF_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConTelf_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONAREA_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConArea_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONMAIL_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMail_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLICONMAILFE_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMailFE_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7O13( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         nRcdDeleted_13 = 0;
      }

      protected void ProcessLevel7O11( )
      {
         /* Save parent mode. */
         sMode11 = Gx_mode;
         ProcessNestedLevel7O83( ) ;
         ProcessNestedLevel7O13( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel7O11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7O11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(33);
            pr_default.close(35);
            pr_default.close(36);
            pr_default.close(34);
            pr_default.close(4);
            context.CommitDataStores("ventas.clientes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(33);
            pr_default.close(35);
            pr_default.close(36);
            pr_default.close(34);
            pr_default.close(4);
            context.RollbackDataStores("ventas.clientes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7O11( )
      {
         /* Scan By routine */
         /* Using cursor T007O57 */
         pr_default.execute(55);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T007O57_A45CliCod[0];
            n45CliCod = T007O57_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7O11( )
      {
         /* Scan next routine */
         pr_default.readNext(55);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T007O57_A45CliCod[0];
            n45CliCod = T007O57_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
      }

      protected void ScanEnd7O11( )
      {
         pr_default.close(55);
      }

      protected void AfterConfirm7O11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7O11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7O11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7O11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7O11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7O11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7O11( )
      {
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtCliDsc_Enabled = 0;
         AssignProp("", false, edtCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDsc_Enabled), 5, 0), true);
         edtCliDir_Enabled = 0;
         AssignProp("", false, edtCliDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDir_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtCliTel1_Enabled = 0;
         AssignProp("", false, edtCliTel1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTel1_Enabled), 5, 0), true);
         edtCliTel2_Enabled = 0;
         AssignProp("", false, edtCliTel2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTel2_Enabled), 5, 0), true);
         edtCliFax_Enabled = 0;
         AssignProp("", false, edtCliFax_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliFax_Enabled), 5, 0), true);
         edtCliCel_Enabled = 0;
         AssignProp("", false, edtCliCel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCel_Enabled), 5, 0), true);
         edtCliEma_Enabled = 0;
         AssignProp("", false, edtCliEma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliEma_Enabled), 5, 0), true);
         edtCliWeb_Enabled = 0;
         AssignProp("", false, edtCliWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliWeb_Enabled), 5, 0), true);
         edtTipCCod_Enabled = 0;
         AssignProp("", false, edtTipCCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCCod_Enabled), 5, 0), true);
         imgCliFoto_Enabled = 0;
         AssignProp("", false, imgCliFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgCliFoto_Enabled), 5, 0), true);
         edtCliSts_Enabled = 0;
         AssignProp("", false, edtCliSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliSts_Enabled), 5, 0), true);
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         edtCliLim_Enabled = 0;
         AssignProp("", false, edtCliLim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliLim_Enabled), 5, 0), true);
         edtCliVend_Enabled = 0;
         AssignProp("", false, edtCliVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliVend_Enabled), 5, 0), true);
         edtCliVendDsc_Enabled = 0;
         AssignProp("", false, edtCliVendDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliVendDsc_Enabled), 5, 0), true);
         edtCliRef1_Enabled = 0;
         AssignProp("", false, edtCliRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef1_Enabled), 5, 0), true);
         edtCliRef2_Enabled = 0;
         AssignProp("", false, edtCliRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef2_Enabled), 5, 0), true);
         edtCliRef3_Enabled = 0;
         AssignProp("", false, edtCliRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef3_Enabled), 5, 0), true);
         edtCliRef4_Enabled = 0;
         AssignProp("", false, edtCliRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef4_Enabled), 5, 0), true);
         edtCliRef5_Enabled = 0;
         AssignProp("", false, edtCliRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef5_Enabled), 5, 0), true);
         edtCliRef6_Enabled = 0;
         AssignProp("", false, edtCliRef6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef6_Enabled), 5, 0), true);
         edtCliRef7_Enabled = 0;
         AssignProp("", false, edtCliRef7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef7_Enabled), 5, 0), true);
         edtCliRef8_Enabled = 0;
         AssignProp("", false, edtCliRef8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRef8_Enabled), 5, 0), true);
         edtCliCont1_Enabled = 0;
         AssignProp("", false, edtCliCont1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCont1_Enabled), 5, 0), true);
         edtCliCTel1_Enabled = 0;
         AssignProp("", false, edtCliCTel1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCTel1_Enabled), 5, 0), true);
         edtCliCont2_Enabled = 0;
         AssignProp("", false, edtCliCont2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCont2_Enabled), 5, 0), true);
         edtCliCTel2_Enabled = 0;
         AssignProp("", false, edtCliCTel2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCTel2_Enabled), 5, 0), true);
         edtCliCont3_Enabled = 0;
         AssignProp("", false, edtCliCont3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCont3_Enabled), 5, 0), true);
         edtCliCtel3_Enabled = 0;
         AssignProp("", false, edtCliCtel3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCtel3_Enabled), 5, 0), true);
         edtCliCont4_Enabled = 0;
         AssignProp("", false, edtCliCont4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCont4_Enabled), 5, 0), true);
         edtCliCTel4_Enabled = 0;
         AssignProp("", false, edtCliCTel4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCTel4_Enabled), 5, 0), true);
         edtCliCont5_Enabled = 0;
         AssignProp("", false, edtCliCont5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCont5_Enabled), 5, 0), true);
         edtCliCtel5_Enabled = 0;
         AssignProp("", false, edtCliCtel5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCtel5_Enabled), 5, 0), true);
         edtDisCod_Enabled = 0;
         AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtCliTItemDir_Enabled = 0;
         AssignProp("", false, edtCliTItemDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTItemDir_Enabled), 5, 0), true);
         edtZonCod_Enabled = 0;
         AssignProp("", false, edtZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonCod_Enabled), 5, 0), true);
         edtCliMon_Enabled = 0;
         AssignProp("", false, edtCliMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMon_Enabled), 5, 0), true);
         edtCliVincula_Enabled = 0;
         AssignProp("", false, edtCliVincula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliVincula_Enabled), 5, 0), true);
         edtCliRetencion_Enabled = 0;
         AssignProp("", false, edtCliRetencion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliRetencion_Enabled), 5, 0), true);
         edtCliPercepcion_Enabled = 0;
         AssignProp("", false, edtCliPercepcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliPercepcion_Enabled), 5, 0), true);
         edtCliTipLCod_Enabled = 0;
         AssignProp("", false, edtCliTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTipLCod_Enabled), 5, 0), true);
         edtCliNom_Enabled = 0;
         AssignProp("", false, edtCliNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNom_Enabled), 5, 0), true);
         edtCliAPEP_Enabled = 0;
         AssignProp("", false, edtCliAPEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliAPEP_Enabled), 5, 0), true);
         edtCliAPEM_Enabled = 0;
         AssignProp("", false, edtCliAPEM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliAPEM_Enabled), 5, 0), true);
         edtTipSCod_Enabled = 0;
         AssignProp("", false, edtTipSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSCod_Enabled), 5, 0), true);
         edtCliUsuCod_Enabled = 0;
         AssignProp("", false, edtCliUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliUsuCod_Enabled), 5, 0), true);
         edtCliUsuFec_Enabled = 0;
         AssignProp("", false, edtCliUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliUsuFec_Enabled), 5, 0), true);
         edtCliEMAPer_Enabled = 0;
         AssignProp("", false, edtCliEMAPer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliEMAPer_Enabled), 5, 0), true);
         edtCliPassPer_Enabled = 0;
         AssignProp("", false, edtCliPassPer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliPassPer_Enabled), 5, 0), true);
         edtCliTCon_Enabled = 0;
         AssignProp("", false, edtCliTCon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTCon_Enabled), 5, 0), true);
         edtCliDireccionLarga_Enabled = 0;
         AssignProp("", false, edtCliDireccionLarga_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDireccionLarga_Enabled), 5, 0), true);
         edtCliTipCod_Enabled = 0;
         AssignProp("", false, edtCliTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliTipCod_Enabled), 5, 0), true);
         edtCliDTAval_Enabled = 0;
         AssignProp("", false, edtCliDTAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDTAval_Enabled), 5, 0), true);
         edtavComboestcod_Enabled = 0;
         AssignProp("", false, edtavComboestcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboestcod_Enabled), 5, 0), true);
         edtavCombopaicod_Enabled = 0;
         AssignProp("", false, edtavCombopaicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopaicod_Enabled), 5, 0), true);
         edtavCombotipccod_Enabled = 0;
         AssignProp("", false, edtavCombotipccod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipccod_Enabled), 5, 0), true);
         edtavComboconpcod_Enabled = 0;
         AssignProp("", false, edtavComboconpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboconpcod_Enabled), 5, 0), true);
         edtavComboclivend_Enabled = 0;
         AssignProp("", false, edtavComboclivend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclivend_Enabled), 5, 0), true);
         edtavCombodiscod_Enabled = 0;
         AssignProp("", false, edtavCombodiscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodiscod_Enabled), 5, 0), true);
         edtavComboprovcod_Enabled = 0;
         AssignProp("", false, edtavComboprovcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprovcod_Enabled), 5, 0), true);
         edtavCombozoncod_Enabled = 0;
         AssignProp("", false, edtavCombozoncod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombozoncod_Enabled), 5, 0), true);
         edtavComboclitiplcod_Enabled = 0;
         AssignProp("", false, edtavComboclitiplcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclitiplcod_Enabled), 5, 0), true);
         edtavCombotipscod_Enabled = 0;
         AssignProp("", false, edtavCombotipscod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipscod_Enabled), 5, 0), true);
      }

      protected void ZM7O83( short GX_JID )
      {
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z600CliDirDsc = T007O5_A600CliDirDsc[0];
               Z598CliDirDir = T007O5_A598CliDirDir[0];
               Z605CliDirPais = T007O5_A605CliDirPais[0];
               Z597CliDirDep = T007O5_A597CliDirDep[0];
               Z606CliDirProv = T007O5_A606CliDirProv[0];
               Z599CliDirDis = T007O5_A599CliDirDis[0];
               Z165CliDirZonCod = T007O5_A165CliDirZonCod[0];
            }
            else
            {
               Z600CliDirDsc = A600CliDirDsc;
               Z598CliDirDir = A598CliDirDir;
               Z605CliDirPais = A605CliDirPais;
               Z597CliDirDep = A597CliDirDep;
               Z606CliDirProv = A606CliDirProv;
               Z599CliDirDis = A599CliDirDis;
               Z165CliDirZonCod = A165CliDirZonCod;
            }
         }
         if ( GX_JID == -49 )
         {
            Z45CliCod = A45CliCod;
            Z164CliDirItem = A164CliDirItem;
            Z600CliDirDsc = A600CliDirDsc;
            Z598CliDirDir = A598CliDirDir;
            Z605CliDirPais = A605CliDirPais;
            Z597CliDirDep = A597CliDirDep;
            Z606CliDirProv = A606CliDirProv;
            Z599CliDirDis = A599CliDirDis;
            Z165CliDirZonCod = A165CliDirZonCod;
            Z607CliDirZonDsc = A607CliDirZonDsc;
         }
      }

      protected void standaloneNotModal7O83( )
      {
      }

      protected void standaloneModal7O83( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCliDirItem_Enabled = 0;
            AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         }
         else
         {
            edtCliDirItem_Enabled = 1;
            AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         }
      }

      protected void Load7O83( )
      {
         /* Using cursor T007O58 */
         pr_default.execute(56, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(56) != 101) )
         {
            RcdFound83 = 1;
            A600CliDirDsc = T007O58_A600CliDirDsc[0];
            A598CliDirDir = T007O58_A598CliDirDir[0];
            A605CliDirPais = T007O58_A605CliDirPais[0];
            A597CliDirDep = T007O58_A597CliDirDep[0];
            A606CliDirProv = T007O58_A606CliDirProv[0];
            A599CliDirDis = T007O58_A599CliDirDis[0];
            A607CliDirZonDsc = T007O58_A607CliDirZonDsc[0];
            A165CliDirZonCod = T007O58_A165CliDirZonCod[0];
            ZM7O83( -49) ;
         }
         pr_default.close(56);
         OnLoadActions7O83( ) ;
      }

      protected void OnLoadActions7O83( )
      {
      }

      protected void CheckExtendedTable7O83( )
      {
         nIsDirty_83 = 0;
         Gx_BScreen = 1;
         standaloneModal7O83( ) ;
         /* Using cursor T007O6 */
         pr_default.execute(4, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "CLIDIRZONCOD_" + sGXsfl_368_idx;
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A607CliDirZonDsc = T007O6_A607CliDirZonDsc[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors7O83( )
      {
         pr_default.close(4);
      }

      protected void enableDisable7O83( )
      {
      }

      protected void gxLoad_50( int A165CliDirZonCod )
      {
         /* Using cursor T007O59 */
         pr_default.execute(57, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(57) == 101) )
         {
            GXCCtl = "CLIDIRZONCOD_" + sGXsfl_368_idx;
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A607CliDirZonDsc = T007O59_A607CliDirZonDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A607CliDirZonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(57) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(57);
      }

      protected void GetKey7O83( )
      {
         /* Using cursor T007O60 */
         pr_default.execute(58, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(58) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(58);
      }

      protected void getByPrimaryKey7O83( )
      {
         /* Using cursor T007O5 */
         pr_default.execute(3, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM7O83( 49) ;
            RcdFound83 = 1;
            InitializeNonKey7O83( ) ;
            A164CliDirItem = T007O5_A164CliDirItem[0];
            A600CliDirDsc = T007O5_A600CliDirDsc[0];
            A598CliDirDir = T007O5_A598CliDirDir[0];
            A605CliDirPais = T007O5_A605CliDirPais[0];
            A597CliDirDep = T007O5_A597CliDirDep[0];
            A606CliDirProv = T007O5_A606CliDirProv[0];
            A599CliDirDis = T007O5_A599CliDirDis[0];
            A165CliDirZonCod = T007O5_A165CliDirZonCod[0];
            Z45CliCod = A45CliCod;
            Z164CliDirItem = A164CliDirItem;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7O83( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey7O83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7O83( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7O83( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency7O83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007O4 */
            pr_default.execute(2, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z600CliDirDsc, T007O4_A600CliDirDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z598CliDirDir, T007O4_A598CliDirDir[0]) != 0 ) || ( StringUtil.StrCmp(Z605CliDirPais, T007O4_A605CliDirPais[0]) != 0 ) || ( StringUtil.StrCmp(Z597CliDirDep, T007O4_A597CliDirDep[0]) != 0 ) || ( StringUtil.StrCmp(Z606CliDirProv, T007O4_A606CliDirProv[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z599CliDirDis, T007O4_A599CliDirDis[0]) != 0 ) || ( Z165CliDirZonCod != T007O4_A165CliDirZonCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z600CliDirDsc, T007O4_A600CliDirDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirDsc");
                  GXUtil.WriteLogRaw("Old: ",Z600CliDirDsc);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A600CliDirDsc[0]);
               }
               if ( StringUtil.StrCmp(Z598CliDirDir, T007O4_A598CliDirDir[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirDir");
                  GXUtil.WriteLogRaw("Old: ",Z598CliDirDir);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A598CliDirDir[0]);
               }
               if ( StringUtil.StrCmp(Z605CliDirPais, T007O4_A605CliDirPais[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirPais");
                  GXUtil.WriteLogRaw("Old: ",Z605CliDirPais);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A605CliDirPais[0]);
               }
               if ( StringUtil.StrCmp(Z597CliDirDep, T007O4_A597CliDirDep[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirDep");
                  GXUtil.WriteLogRaw("Old: ",Z597CliDirDep);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A597CliDirDep[0]);
               }
               if ( StringUtil.StrCmp(Z606CliDirProv, T007O4_A606CliDirProv[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirProv");
                  GXUtil.WriteLogRaw("Old: ",Z606CliDirProv);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A606CliDirProv[0]);
               }
               if ( StringUtil.StrCmp(Z599CliDirDis, T007O4_A599CliDirDis[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirDis");
                  GXUtil.WriteLogRaw("Old: ",Z599CliDirDis);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A599CliDirDis[0]);
               }
               if ( Z165CliDirZonCod != T007O4_A165CliDirZonCod[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliDirZonCod");
                  GXUtil.WriteLogRaw("Old: ",Z165CliDirZonCod);
                  GXUtil.WriteLogRaw("Current: ",T007O4_A165CliDirZonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7O83( )
      {
         BeforeValidate7O83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7O83( 0) ;
            CheckOptimisticConcurrency7O83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7O83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7O83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007O61 */
                     pr_default.execute(59, new Object[] {n45CliCod, A45CliCod, A164CliDirItem, A600CliDirDsc, A598CliDirDir, A605CliDirPais, A597CliDirDep, A606CliDirProv, A599CliDirDis, A165CliDirZonCod});
                     pr_default.close(59);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
                     if ( (pr_default.getStatus(59) == 1) )
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
               Load7O83( ) ;
            }
            EndLevel7O83( ) ;
         }
         CloseExtendedTableCursors7O83( ) ;
      }

      protected void Update7O83( )
      {
         BeforeValidate7O83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O83( ) ;
         }
         if ( ( nIsMod_83 != 0 ) || ( nIsDirty_83 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7O83( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7O83( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7O83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007O62 */
                        pr_default.execute(60, new Object[] {A600CliDirDsc, A598CliDirDir, A605CliDirPais, A597CliDirDep, A606CliDirProv, A599CliDirDis, A165CliDirZonCod, n45CliCod, A45CliCod, A164CliDirItem});
                        pr_default.close(60);
                        dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
                        if ( (pr_default.getStatus(60) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7O83( ) ;
                        if ( AnyError == 0 )
                        {
                           new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                           AssignAttri("", false, "A45CliCod", A45CliCod);
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7O83( ) ;
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
               EndLevel7O83( ) ;
            }
         }
         CloseExtendedTableCursors7O83( ) ;
      }

      protected void DeferredUpdate7O83( )
      {
      }

      protected void Delete7O83( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7O83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7O83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7O83( ) ;
            AfterConfirm7O83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7O83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007O63 */
                  pr_default.execute(61, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
                  pr_default.close(61);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7O83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7O83( )
      {
         standaloneModal7O83( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007O64 */
            pr_default.execute(62, new Object[] {A165CliDirZonCod});
            A607CliDirZonDsc = T007O64_A607CliDirZonDsc[0];
            pr_default.close(62);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T007O65 */
            pr_default.execute(63, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(63) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Sub Remision Destino Item"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(63);
            /* Using cursor T007O66 */
            pr_default.execute(64, new Object[] {n45CliCod, A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(64) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente Origen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(64);
         }
      }

      protected void EndLevel7O83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7O83( )
      {
         /* Scan By routine */
         /* Using cursor T007O67 */
         pr_default.execute(65, new Object[] {n45CliCod, A45CliCod});
         RcdFound83 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound83 = 1;
            A164CliDirItem = T007O67_A164CliDirItem[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7O83( )
      {
         /* Scan next routine */
         pr_default.readNext(65);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(65) != 101) )
         {
            RcdFound83 = 1;
            A164CliDirItem = T007O67_A164CliDirItem[0];
         }
      }

      protected void ScanEnd7O83( )
      {
         pr_default.close(65);
      }

      protected void AfterConfirm7O83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7O83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7O83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7O83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7O83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7O83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7O83( )
      {
         edtCliDirItem_Enabled = 0;
         AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirDsc_Enabled = 0;
         AssignProp("", false, edtCliDirDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDsc_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirDir_Enabled = 0;
         AssignProp("", false, edtCliDirDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDir_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirPais_Enabled = 0;
         AssignProp("", false, edtCliDirPais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirPais_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirDep_Enabled = 0;
         AssignProp("", false, edtCliDirDep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDep_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirProv_Enabled = 0;
         AssignProp("", false, edtCliDirProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirProv_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirDis_Enabled = 0;
         AssignProp("", false, edtCliDirDis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDis_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirZonCod_Enabled = 0;
         AssignProp("", false, edtCliDirZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonCod_Enabled), 5, 0), !bGXsfl_368_Refreshing);
         edtCliDirZonDsc_Enabled = 0;
         AssignProp("", false, edtCliDirZonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonDsc_Enabled), 5, 0), !bGXsfl_368_Refreshing);
      }

      protected void send_integrity_lvl_hashes7O83( )
      {
      }

      protected void ZM7O13( short GX_JID )
      {
         if ( ( GX_JID == 51 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z578CliConDsc = T007O3_A578CliConDsc[0];
               Z577CliConCargo = T007O3_A577CliConCargo[0];
               Z586CliConTelf = T007O3_A586CliConTelf[0];
               Z576CliConArea = T007O3_A576CliConArea[0];
               Z579CliConMail = T007O3_A579CliConMail[0];
               Z580CliConMailFE = T007O3_A580CliConMailFE[0];
            }
            else
            {
               Z578CliConDsc = A578CliConDsc;
               Z577CliConCargo = A577CliConCargo;
               Z586CliConTelf = A586CliConTelf;
               Z576CliConArea = A576CliConArea;
               Z579CliConMail = A579CliConMail;
               Z580CliConMailFE = A580CliConMailFE;
            }
         }
         if ( GX_JID == -51 )
         {
            Z45CliCod = A45CliCod;
            Z163CliConCod = A163CliConCod;
            Z578CliConDsc = A578CliConDsc;
            Z577CliConCargo = A577CliConCargo;
            Z586CliConTelf = A586CliConTelf;
            Z576CliConArea = A576CliConArea;
            Z579CliConMail = A579CliConMail;
            Z580CliConMailFE = A580CliConMailFE;
         }
      }

      protected void standaloneNotModal7O13( )
      {
      }

      protected void standaloneModal7O13( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCliConCod_Enabled = 0;
            AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         }
         else
         {
            edtCliConCod_Enabled = 1;
            AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         }
      }

      protected void Load7O13( )
      {
         /* Using cursor T007O68 */
         pr_default.execute(66, new Object[] {n45CliCod, A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(66) != 101) )
         {
            RcdFound13 = 1;
            A578CliConDsc = T007O68_A578CliConDsc[0];
            A577CliConCargo = T007O68_A577CliConCargo[0];
            A586CliConTelf = T007O68_A586CliConTelf[0];
            A576CliConArea = T007O68_A576CliConArea[0];
            A579CliConMail = T007O68_A579CliConMail[0];
            A580CliConMailFE = T007O68_A580CliConMailFE[0];
            ZM7O13( -51) ;
         }
         pr_default.close(66);
         OnLoadActions7O13( ) ;
      }

      protected void OnLoadActions7O13( )
      {
      }

      protected void CheckExtendedTable7O13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal7O13( ) ;
      }

      protected void CloseExtendedTableCursors7O13( )
      {
      }

      protected void enableDisable7O13( )
      {
      }

      protected void GetKey7O13( )
      {
         /* Using cursor T007O69 */
         pr_default.execute(67, new Object[] {n45CliCod, A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(67) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(67);
      }

      protected void getByPrimaryKey7O13( )
      {
         /* Using cursor T007O3 */
         pr_default.execute(1, new Object[] {n45CliCod, A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7O13( 51) ;
            RcdFound13 = 1;
            InitializeNonKey7O13( ) ;
            A163CliConCod = T007O3_A163CliConCod[0];
            A578CliConDsc = T007O3_A578CliConDsc[0];
            A577CliConCargo = T007O3_A577CliConCargo[0];
            A586CliConTelf = T007O3_A586CliConTelf[0];
            A576CliConArea = T007O3_A576CliConArea[0];
            A579CliConMail = T007O3_A579CliConMail[0];
            A580CliConMailFE = T007O3_A580CliConMailFE[0];
            Z45CliCod = A45CliCod;
            Z163CliConCod = A163CliConCod;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7O13( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey7O13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal7O13( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7O13( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7O13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007O2 */
            pr_default.execute(0, new Object[] {n45CliCod, A45CliCod, A163CliConCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z578CliConDsc, T007O2_A578CliConDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z577CliConCargo, T007O2_A577CliConCargo[0]) != 0 ) || ( StringUtil.StrCmp(Z586CliConTelf, T007O2_A586CliConTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z576CliConArea, T007O2_A576CliConArea[0]) != 0 ) || ( StringUtil.StrCmp(Z579CliConMail, T007O2_A579CliConMail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z580CliConMailFE != T007O2_A580CliConMailFE[0] ) )
            {
               if ( StringUtil.StrCmp(Z578CliConDsc, T007O2_A578CliConDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConDsc");
                  GXUtil.WriteLogRaw("Old: ",Z578CliConDsc);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A578CliConDsc[0]);
               }
               if ( StringUtil.StrCmp(Z577CliConCargo, T007O2_A577CliConCargo[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConCargo");
                  GXUtil.WriteLogRaw("Old: ",Z577CliConCargo);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A577CliConCargo[0]);
               }
               if ( StringUtil.StrCmp(Z586CliConTelf, T007O2_A586CliConTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConTelf");
                  GXUtil.WriteLogRaw("Old: ",Z586CliConTelf);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A586CliConTelf[0]);
               }
               if ( StringUtil.StrCmp(Z576CliConArea, T007O2_A576CliConArea[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConArea");
                  GXUtil.WriteLogRaw("Old: ",Z576CliConArea);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A576CliConArea[0]);
               }
               if ( StringUtil.StrCmp(Z579CliConMail, T007O2_A579CliConMail[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConMail");
                  GXUtil.WriteLogRaw("Old: ",Z579CliConMail);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A579CliConMail[0]);
               }
               if ( Z580CliConMailFE != T007O2_A580CliConMailFE[0] )
               {
                  GXUtil.WriteLog("ventas.clientes:[seudo value changed for attri]"+"CliConMailFE");
                  GXUtil.WriteLogRaw("Old: ",Z580CliConMailFE);
                  GXUtil.WriteLogRaw("Current: ",T007O2_A580CliConMailFE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7O13( )
      {
         BeforeValidate7O13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7O13( 0) ;
            CheckOptimisticConcurrency7O13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7O13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7O13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007O70 */
                     pr_default.execute(68, new Object[] {n45CliCod, A45CliCod, A163CliConCod, A578CliConDsc, A577CliConCargo, A586CliConTelf, A576CliConArea, A579CliConMail, A580CliConMailFE});
                     pr_default.close(68);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
                     if ( (pr_default.getStatus(68) == 1) )
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
               Load7O13( ) ;
            }
            EndLevel7O13( ) ;
         }
         CloseExtendedTableCursors7O13( ) ;
      }

      protected void Update7O13( )
      {
         BeforeValidate7O13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7O13( ) ;
         }
         if ( ( nIsMod_13 != 0 ) || ( nIsDirty_13 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency7O13( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm7O13( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate7O13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T007O71 */
                        pr_default.execute(69, new Object[] {A578CliConDsc, A577CliConCargo, A586CliConTelf, A576CliConArea, A579CliConMail, A580CliConMailFE, n45CliCod, A45CliCod, A163CliConCod});
                        pr_default.close(69);
                        dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
                        if ( (pr_default.getStatus(69) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate7O13( ) ;
                        if ( AnyError == 0 )
                        {
                           new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                           AssignAttri("", false, "A45CliCod", A45CliCod);
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey7O13( ) ;
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
               EndLevel7O13( ) ;
            }
         }
         CloseExtendedTableCursors7O13( ) ;
      }

      protected void DeferredUpdate7O13( )
      {
      }

      protected void Delete7O13( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7O13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7O13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7O13( ) ;
            AfterConfirm7O13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7O13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007O72 */
                  pr_default.execute(70, new Object[] {n45CliCod, A45CliCod, A163CliConCod});
                  pr_default.close(70);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7O13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7O13( )
      {
         standaloneModal7O13( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7O13( )
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

      public void ScanStart7O13( )
      {
         /* Scan By routine */
         /* Using cursor T007O73 */
         pr_default.execute(71, new Object[] {n45CliCod, A45CliCod});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(71) != 101) )
         {
            RcdFound13 = 1;
            A163CliConCod = T007O73_A163CliConCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7O13( )
      {
         /* Scan next routine */
         pr_default.readNext(71);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(71) != 101) )
         {
            RcdFound13 = 1;
            A163CliConCod = T007O73_A163CliConCod[0];
         }
      }

      protected void ScanEnd7O13( )
      {
         pr_default.close(71);
      }

      protected void AfterConfirm7O13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7O13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7O13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7O13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7O13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7O13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7O13( )
      {
         edtCliConCod_Enabled = 0;
         AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConDsc_Enabled = 0;
         AssignProp("", false, edtCliConDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConDsc_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConCargo_Enabled = 0;
         AssignProp("", false, edtCliConCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCargo_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConTelf_Enabled = 0;
         AssignProp("", false, edtCliConTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConTelf_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConArea_Enabled = 0;
         AssignProp("", false, edtCliConArea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConArea_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConMail_Enabled = 0;
         AssignProp("", false, edtCliConMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMail_Enabled), 5, 0), !bGXsfl_383_Refreshing);
         edtCliConMailFE_Enabled = 0;
         AssignProp("", false, edtCliConMailFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMailFE_Enabled), 5, 0), !bGXsfl_383_Refreshing);
      }

      protected void send_integrity_lvl_hashes7O13( )
      {
      }

      protected void send_integrity_lvl_hashes7O11( )
      {
      }

      protected void SubsflControlProps_36883( )
      {
         edtCliDirItem_Internalname = "CLIDIRITEM_"+sGXsfl_368_idx;
         edtCliDirDsc_Internalname = "CLIDIRDSC_"+sGXsfl_368_idx;
         edtCliDirDir_Internalname = "CLIDIRDIR_"+sGXsfl_368_idx;
         edtCliDirPais_Internalname = "CLIDIRPAIS_"+sGXsfl_368_idx;
         edtCliDirDep_Internalname = "CLIDIRDEP_"+sGXsfl_368_idx;
         edtCliDirProv_Internalname = "CLIDIRPROV_"+sGXsfl_368_idx;
         edtCliDirDis_Internalname = "CLIDIRDIS_"+sGXsfl_368_idx;
         edtCliDirZonCod_Internalname = "CLIDIRZONCOD_"+sGXsfl_368_idx;
         edtCliDirZonDsc_Internalname = "CLIDIRZONDSC_"+sGXsfl_368_idx;
      }

      protected void SubsflControlProps_fel_36883( )
      {
         edtCliDirItem_Internalname = "CLIDIRITEM_"+sGXsfl_368_fel_idx;
         edtCliDirDsc_Internalname = "CLIDIRDSC_"+sGXsfl_368_fel_idx;
         edtCliDirDir_Internalname = "CLIDIRDIR_"+sGXsfl_368_fel_idx;
         edtCliDirPais_Internalname = "CLIDIRPAIS_"+sGXsfl_368_fel_idx;
         edtCliDirDep_Internalname = "CLIDIRDEP_"+sGXsfl_368_fel_idx;
         edtCliDirProv_Internalname = "CLIDIRPROV_"+sGXsfl_368_fel_idx;
         edtCliDirDis_Internalname = "CLIDIRDIS_"+sGXsfl_368_fel_idx;
         edtCliDirZonCod_Internalname = "CLIDIRZONCOD_"+sGXsfl_368_fel_idx;
         edtCliDirZonDsc_Internalname = "CLIDIRZONDSC_"+sGXsfl_368_fel_idx;
      }

      protected void AddRow7O83( )
      {
         nGXsfl_368_idx = (int)(nGXsfl_368_idx+1);
         sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx), 4, 0), 4, "0");
         SubsflControlProps_36883( ) ;
         SendRow7O83( ) ;
      }

      protected void SendRow7O83( )
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
            if ( ((int)((nGXsfl_368_idx) % (2))) == 0 )
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
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 369,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirItem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A164CliDirItem), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A164CliDirItem), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,369);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirItem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirItem_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 370,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirDsc_Internalname,StringUtil.RTrim( A600CliDirDsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,370);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 371,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirDir_Internalname,StringUtil.RTrim( A598CliDirDir),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,371);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirDir_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirDir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 372,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirPais_Internalname,StringUtil.RTrim( A605CliDirPais),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,372);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirPais_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirPais_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 373,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirDep_Internalname,StringUtil.RTrim( A597CliDirDep),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,373);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirDep_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirDep_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 374,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirProv_Internalname,StringUtil.RTrim( A606CliDirProv),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,374);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirProv_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirProv_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 375,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirDis_Internalname,StringUtil.RTrim( A599CliDirDis),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,375);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirDis_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirDis_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_83_" + sGXsfl_368_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 376,'',false,'" + sGXsfl_368_idx + "',368)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirZonCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", "")),StringUtil.LTrim( ((edtCliDirZonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A165CliDirZonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A165CliDirZonCod), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,376);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirZonCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirZonCod_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)edtCliDirZonCod_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDirZonDsc_Internalname,StringUtil.RTrim( A607CliDirZonDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDirZonDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliDirZonDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)368,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_level1Row);
         send_integrity_lvl_hashes7O83( ) ;
         GXCCtl = "Z164CliDirItem_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164CliDirItem), 6, 0, ".", "")));
         GXCCtl = "Z600CliDirDsc_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z600CliDirDsc));
         GXCCtl = "Z598CliDirDir_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z598CliDirDir));
         GXCCtl = "Z605CliDirPais_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z605CliDirPais));
         GXCCtl = "Z597CliDirDep_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z597CliDirDep));
         GXCCtl = "Z606CliDirProv_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z606CliDirProv));
         GXCCtl = "Z599CliDirDis_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z599CliDirDis));
         GXCCtl = "Z165CliDirZonCod_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliDirZonCod), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_83_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_83), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_83_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_83), 4, 0, ".", "")));
         GXCCtl = "nIsMod_83_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_83), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_368_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCLICOD_" + sGXsfl_368_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7CliCod));
         GxWebStd.gx_hidden_field( context, "CLIDIRITEM_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirItem_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRDIR_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDir_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRPAIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirPais_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRDEP_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDep_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRPROV_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirProv_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRDIS_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirDis_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRZONCOD_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDIRZONCOD_"+sGXsfl_368_idx+"Horizontalalignment", StringUtil.RTrim( edtCliDirZonCod_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "CLIDIRZONDSC_"+sGXsfl_368_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDirZonDsc_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_level1Container.AddRow(Gridlevel_level1Row);
      }

      protected void ReadRow7O83( )
      {
         nGXsfl_368_idx = (int)(nGXsfl_368_idx+1);
         sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx), 4, 0), 4, "0");
         SubsflControlProps_36883( ) ;
         edtCliDirItem_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRITEM_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDSC_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirDir_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDIR_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirPais_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRPAIS_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirDep_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDEP_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirProv_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRPROV_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirDis_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRDIS_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirZonCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         edtCliDirZonCod_Horizontalalignment = cgiGet( "CLIDIRZONCOD_"+sGXsfl_368_idx+"Horizontalalignment");
         edtCliDirZonDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDIRZONDSC_"+sGXsfl_368_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CLIDIRITEM_" + sGXsfl_368_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDirItem_Internalname;
            wbErr = true;
            A164CliDirItem = 0;
         }
         else
         {
            A164CliDirItem = (int)(context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ","));
         }
         A600CliDirDsc = cgiGet( edtCliDirDsc_Internalname);
         A598CliDirDir = cgiGet( edtCliDirDir_Internalname);
         A605CliDirPais = cgiGet( edtCliDirPais_Internalname);
         A597CliDirDep = cgiGet( edtCliDirDep_Internalname);
         A606CliDirProv = cgiGet( edtCliDirProv_Internalname);
         A599CliDirDis = cgiGet( edtCliDirDis_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CLIDIRZONCOD_" + sGXsfl_368_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
            wbErr = true;
            A165CliDirZonCod = 0;
         }
         else
         {
            A165CliDirZonCod = (int)(context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ","));
         }
         A607CliDirZonDsc = cgiGet( edtCliDirZonDsc_Internalname);
         GXCCtl = "Z164CliDirItem_" + sGXsfl_368_idx;
         Z164CliDirItem = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z600CliDirDsc_" + sGXsfl_368_idx;
         Z600CliDirDsc = cgiGet( GXCCtl);
         GXCCtl = "Z598CliDirDir_" + sGXsfl_368_idx;
         Z598CliDirDir = cgiGet( GXCCtl);
         GXCCtl = "Z605CliDirPais_" + sGXsfl_368_idx;
         Z605CliDirPais = cgiGet( GXCCtl);
         GXCCtl = "Z597CliDirDep_" + sGXsfl_368_idx;
         Z597CliDirDep = cgiGet( GXCCtl);
         GXCCtl = "Z606CliDirProv_" + sGXsfl_368_idx;
         Z606CliDirProv = cgiGet( GXCCtl);
         GXCCtl = "Z599CliDirDis_" + sGXsfl_368_idx;
         Z599CliDirDis = cgiGet( GXCCtl);
         GXCCtl = "Z165CliDirZonCod_" + sGXsfl_368_idx;
         Z165CliDirZonCod = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_83_" + sGXsfl_368_idx;
         nRcdDeleted_83 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_83_" + sGXsfl_368_idx;
         nRcdExists_83 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_83_" + sGXsfl_368_idx;
         nIsMod_83 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void SubsflControlProps_38313( )
      {
         edtCliConCod_Internalname = "CLICONCOD_"+sGXsfl_383_idx;
         edtCliConDsc_Internalname = "CLICONDSC_"+sGXsfl_383_idx;
         edtCliConCargo_Internalname = "CLICONCARGO_"+sGXsfl_383_idx;
         edtCliConTelf_Internalname = "CLICONTELF_"+sGXsfl_383_idx;
         edtCliConArea_Internalname = "CLICONAREA_"+sGXsfl_383_idx;
         edtCliConMail_Internalname = "CLICONMAIL_"+sGXsfl_383_idx;
         edtCliConMailFE_Internalname = "CLICONMAILFE_"+sGXsfl_383_idx;
      }

      protected void SubsflControlProps_fel_38313( )
      {
         edtCliConCod_Internalname = "CLICONCOD_"+sGXsfl_383_fel_idx;
         edtCliConDsc_Internalname = "CLICONDSC_"+sGXsfl_383_fel_idx;
         edtCliConCargo_Internalname = "CLICONCARGO_"+sGXsfl_383_fel_idx;
         edtCliConTelf_Internalname = "CLICONTELF_"+sGXsfl_383_fel_idx;
         edtCliConArea_Internalname = "CLICONAREA_"+sGXsfl_383_fel_idx;
         edtCliConMail_Internalname = "CLICONMAIL_"+sGXsfl_383_fel_idx;
         edtCliConMailFE_Internalname = "CLICONMAILFE_"+sGXsfl_383_fel_idx;
      }

      protected void AddRow7O13( )
      {
         nGXsfl_383_idx = (int)(nGXsfl_383_idx+1);
         sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx), 4, 0), 4, "0");
         SubsflControlProps_38313( ) ;
         SendRow7O13( ) ;
      }

      protected void SendRow7O13( )
      {
         Gridlevel_level2Row = GXWebRow.GetNew(context);
         if ( subGridlevel_level2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_level2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_level2_Class, "") != 0 )
            {
               subGridlevel_level2_Linesclass = subGridlevel_level2_Class+"Odd";
            }
         }
         else if ( subGridlevel_level2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_level2_Backstyle = 0;
            subGridlevel_level2_Backcolor = subGridlevel_level2_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_level2_Class, "") != 0 )
            {
               subGridlevel_level2_Linesclass = subGridlevel_level2_Class+"Uniform";
            }
         }
         else if ( subGridlevel_level2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_level2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_level2_Class, "") != 0 )
            {
               subGridlevel_level2_Linesclass = subGridlevel_level2_Class+"Odd";
            }
            subGridlevel_level2_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_level2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_level2_Backstyle = 1;
            if ( ((int)((nGXsfl_383_idx) % (2))) == 0 )
            {
               subGridlevel_level2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level2_Class, "") != 0 )
               {
                  subGridlevel_level2_Linesclass = subGridlevel_level2_Class+"Even";
               }
            }
            else
            {
               subGridlevel_level2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_level2_Class, "") != 0 )
               {
                  subGridlevel_level2_Linesclass = subGridlevel_level2_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 384,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A163CliConCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A163CliConCod), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,384);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConCod_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 385,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConDsc_Internalname,StringUtil.RTrim( A578CliConDsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,385);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 386,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConCargo_Internalname,StringUtil.RTrim( A577CliConCargo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,386);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConCargo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConCargo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 387,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConTelf_Internalname,StringUtil.RTrim( A586CliConTelf),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,387);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConTelf_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConTelf_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 388,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConArea_Internalname,StringUtil.RTrim( A576CliConArea),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,388);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConArea_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConArea_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 389,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConMail_Internalname,(string)A579CliConMail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,389);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConMail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_383_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 390,'',false,'" + sGXsfl_383_idx + "',383)\"";
         ROClassString = "Attribute";
         Gridlevel_level2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliConMailFE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", "")),StringUtil.LTrim( ((edtCliConMailFE_Enabled!=0) ? context.localUtil.Format( (decimal)(A580CliConMailFE), "9") : context.localUtil.Format( (decimal)(A580CliConMailFE), "9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,390);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliConMailFE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCliConMailFE_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)383,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_level2Row);
         send_integrity_lvl_hashes7O13( ) ;
         GXCCtl = "Z163CliConCod_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z163CliConCod), 6, 0, ".", "")));
         GXCCtl = "Z578CliConDsc_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z578CliConDsc));
         GXCCtl = "Z577CliConCargo_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z577CliConCargo));
         GXCCtl = "Z586CliConTelf_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z586CliConTelf));
         GXCCtl = "Z576CliConArea_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z576CliConArea));
         GXCCtl = "Z579CliConMail_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z579CliConMail);
         GXCCtl = "Z580CliConMailFE_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z580CliConMailFE), 1, 0, ".", "")));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_13_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", "")));
         GXCCtl = "nIsMod_13_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_383_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCLICOD_" + sGXsfl_383_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7CliCod));
         GxWebStd.gx_hidden_field( context, "CLICONCOD_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONDSC_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONCARGO_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConCargo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONTELF_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConTelf_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONAREA_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConArea_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONMAIL_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLICONMAILFE_"+sGXsfl_383_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliConMailFE_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_level2Container.AddRow(Gridlevel_level2Row);
      }

      protected void ReadRow7O13( )
      {
         nGXsfl_383_idx = (int)(nGXsfl_383_idx+1);
         sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx), 4, 0), 4, "0");
         SubsflControlProps_38313( ) ;
         edtCliConCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONCOD_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONDSC_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConCargo_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONCARGO_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConTelf_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONTELF_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConArea_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONAREA_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConMail_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONMAIL_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         edtCliConMailFE_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLICONMAILFE_"+sGXsfl_383_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CLICONCOD_" + sGXsfl_383_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliConCod_Internalname;
            wbErr = true;
            A163CliConCod = 0;
         }
         else
         {
            A163CliConCod = (int)(context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ","));
         }
         A578CliConDsc = cgiGet( edtCliConDsc_Internalname);
         A577CliConCargo = cgiGet( edtCliConCargo_Internalname);
         A586CliConTelf = cgiGet( edtCliConTelf_Internalname);
         A576CliConArea = cgiGet( edtCliConArea_Internalname);
         A579CliConMail = cgiGet( edtCliConMail_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "CLICONMAILFE_" + sGXsfl_383_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliConMailFE_Internalname;
            wbErr = true;
            A580CliConMailFE = 0;
         }
         else
         {
            A580CliConMailFE = (short)(context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ","));
         }
         GXCCtl = "Z163CliConCod_" + sGXsfl_383_idx;
         Z163CliConCod = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z578CliConDsc_" + sGXsfl_383_idx;
         Z578CliConDsc = cgiGet( GXCCtl);
         GXCCtl = "Z577CliConCargo_" + sGXsfl_383_idx;
         Z577CliConCargo = cgiGet( GXCCtl);
         GXCCtl = "Z586CliConTelf_" + sGXsfl_383_idx;
         Z586CliConTelf = cgiGet( GXCCtl);
         GXCCtl = "Z576CliConArea_" + sGXsfl_383_idx;
         Z576CliConArea = cgiGet( GXCCtl);
         GXCCtl = "Z579CliConMail_" + sGXsfl_383_idx;
         Z579CliConMail = cgiGet( GXCCtl);
         GXCCtl = "Z580CliConMailFE_" + sGXsfl_383_idx;
         Z580CliConMailFE = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_383_idx;
         nRcdDeleted_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_13_" + sGXsfl_383_idx;
         nRcdExists_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_13_" + sGXsfl_383_idx;
         nIsMod_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCliConCod_Enabled = edtCliConCod_Enabled;
         defedtCliDirItem_Enabled = edtCliDirItem_Enabled;
      }

      protected void ConfirmValues7O0( )
      {
         nGXsfl_368_idx = 0;
         sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx), 4, 0), 4, "0");
         SubsflControlProps_36883( ) ;
         while ( nGXsfl_368_idx < nRC_GXsfl_368 )
         {
            nGXsfl_368_idx = (int)(nGXsfl_368_idx+1);
            sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx), 4, 0), 4, "0");
            SubsflControlProps_36883( ) ;
            ChangePostValue( "Z164CliDirItem_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z164CliDirItem_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z164CliDirItem_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z600CliDirDsc_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z600CliDirDsc_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z600CliDirDsc_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z598CliDirDir_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z598CliDirDir_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z598CliDirDir_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z605CliDirPais_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z605CliDirPais_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z605CliDirPais_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z597CliDirDep_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z597CliDirDep_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z597CliDirDep_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z606CliDirProv_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z606CliDirProv_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z606CliDirProv_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z599CliDirDis_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z599CliDirDis_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z599CliDirDis_"+sGXsfl_368_idx) ;
            ChangePostValue( "Z165CliDirZonCod_"+sGXsfl_368_idx, cgiGet( "ZT_"+"Z165CliDirZonCod_"+sGXsfl_368_idx)) ;
            DeletePostValue( "ZT_"+"Z165CliDirZonCod_"+sGXsfl_368_idx) ;
         }
         nGXsfl_383_idx = 0;
         sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx), 4, 0), 4, "0");
         SubsflControlProps_38313( ) ;
         while ( nGXsfl_383_idx < nRC_GXsfl_383 )
         {
            nGXsfl_383_idx = (int)(nGXsfl_383_idx+1);
            sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx), 4, 0), 4, "0");
            SubsflControlProps_38313( ) ;
            ChangePostValue( "Z163CliConCod_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z163CliConCod_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z163CliConCod_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z578CliConDsc_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z578CliConDsc_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z578CliConDsc_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z577CliConCargo_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z577CliConCargo_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z577CliConCargo_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z586CliConTelf_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z586CliConTelf_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z586CliConTelf_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z576CliConArea_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z576CliConArea_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z576CliConArea_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z579CliConMail_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z579CliConMail_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z579CliConMail_"+sGXsfl_383_idx) ;
            ChangePostValue( "Z580CliConMailFE_"+sGXsfl_383_idx, cgiGet( "ZT_"+"Z580CliConMailFE_"+sGXsfl_383_idx)) ;
            DeletePostValue( "ZT_"+"Z580CliConMailFE_"+sGXsfl_383_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810281628", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CliCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ventas\\clientes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z161CliDsc", StringUtil.RTrim( Z161CliDsc));
         GxWebStd.gx_hidden_field( context, "Z596CliDir", StringUtil.RTrim( Z596CliDir));
         GxWebStd.gx_hidden_field( context, "Z629CliTel1", StringUtil.RTrim( Z629CliTel1));
         GxWebStd.gx_hidden_field( context, "Z630CliTel2", StringUtil.RTrim( Z630CliTel2));
         GxWebStd.gx_hidden_field( context, "Z611CliFax", StringUtil.RTrim( Z611CliFax));
         GxWebStd.gx_hidden_field( context, "Z575CliCel", StringUtil.RTrim( Z575CliCel));
         GxWebStd.gx_hidden_field( context, "Z609CliEma", Z609CliEma);
         GxWebStd.gx_hidden_field( context, "Z637CliWeb", StringUtil.RTrim( Z637CliWeb));
         GxWebStd.gx_hidden_field( context, "Z627CliSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z627CliSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z613CliLim", StringUtil.LTrim( StringUtil.NToC( Z613CliLim, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z618CliRef1", StringUtil.RTrim( Z618CliRef1));
         GxWebStd.gx_hidden_field( context, "Z619CliRef2", StringUtil.RTrim( Z619CliRef2));
         GxWebStd.gx_hidden_field( context, "Z620CliRef3", StringUtil.RTrim( Z620CliRef3));
         GxWebStd.gx_hidden_field( context, "Z621CliRef4", StringUtil.RTrim( Z621CliRef4));
         GxWebStd.gx_hidden_field( context, "Z622CliRef5", StringUtil.RTrim( Z622CliRef5));
         GxWebStd.gx_hidden_field( context, "Z623CliRef6", StringUtil.RTrim( Z623CliRef6));
         GxWebStd.gx_hidden_field( context, "Z624CliRef7", StringUtil.RTrim( Z624CliRef7));
         GxWebStd.gx_hidden_field( context, "Z625CliRef8", StringUtil.RTrim( Z625CliRef8));
         GxWebStd.gx_hidden_field( context, "Z581CliCont1", StringUtil.RTrim( Z581CliCont1));
         GxWebStd.gx_hidden_field( context, "Z587CliCTel1", StringUtil.RTrim( Z587CliCTel1));
         GxWebStd.gx_hidden_field( context, "Z582CliCont2", StringUtil.RTrim( Z582CliCont2));
         GxWebStd.gx_hidden_field( context, "Z588CliCTel2", StringUtil.RTrim( Z588CliCTel2));
         GxWebStd.gx_hidden_field( context, "Z583CliCont3", StringUtil.RTrim( Z583CliCont3));
         GxWebStd.gx_hidden_field( context, "Z589CliCtel3", StringUtil.RTrim( Z589CliCtel3));
         GxWebStd.gx_hidden_field( context, "Z584CliCont4", StringUtil.RTrim( Z584CliCont4));
         GxWebStd.gx_hidden_field( context, "Z590CliCTel4", StringUtil.RTrim( Z590CliCTel4));
         GxWebStd.gx_hidden_field( context, "Z585CliCont5", StringUtil.RTrim( Z585CliCont5));
         GxWebStd.gx_hidden_field( context, "Z591CliCtel5", StringUtil.RTrim( Z591CliCtel5));
         GxWebStd.gx_hidden_field( context, "Z632CliTItemDir", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z632CliTItemDir), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z614CliMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z614CliMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z636CliVincula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z636CliVincula), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z626CliRetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z626CliRetencion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z617CliPercepcion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z617CliPercepcion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z615CliNom", Z615CliNom);
         GxWebStd.gx_hidden_field( context, "Z574CliAPEP", Z574CliAPEP);
         GxWebStd.gx_hidden_field( context, "Z573CliAPEM", Z573CliAPEM);
         GxWebStd.gx_hidden_field( context, "Z633CliUsuCod", StringUtil.RTrim( Z633CliUsuCod));
         GxWebStd.gx_hidden_field( context, "Z634CliUsuFec", context.localUtil.TToC( Z634CliUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z610CliEMAPer", Z610CliEMAPer);
         GxWebStd.gx_hidden_field( context, "Z616CliPassPer", Z616CliPassPer);
         GxWebStd.gx_hidden_field( context, "Z628CliTCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z628CliTCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z631CliTipCod", StringUtil.RTrim( Z631CliTipCod));
         GxWebStd.gx_hidden_field( context, "Z608CliDTAval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z608CliDTAval), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z159TipCCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159TipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z158ZonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z158ZonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z157TipSCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157TipSCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z160CliVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z160CliVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z156CliTipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z156CliTipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_368", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_368_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_383", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_383_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N140EstCod", StringUtil.RTrim( A140EstCod));
         GxWebStd.gx_hidden_field( context, "N139PaiCod", StringUtil.RTrim( A139PaiCod));
         GxWebStd.gx_hidden_field( context, "N159TipCCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N160CliVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(A160CliVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N142DisCod", StringUtil.RTrim( A142DisCod));
         GxWebStd.gx_hidden_field( context, "N141ProvCod", StringUtil.RTrim( A141ProvCod));
         GxWebStd.gx_hidden_field( context, "N158ZonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ZonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N156CliTipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A156CliTipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N157TipSCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157TipSCod), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV23DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vESTCOD_DATA", AV27EstCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vESTCOD_DATA", AV27EstCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPAICOD_DATA", AV30PaiCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPAICOD_DATA", AV30PaiCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPCCOD_DATA", AV32TipCCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPCCOD_DATA", AV32TipCCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONPCOD_DATA", AV34Conpcod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONPCOD_DATA", AV34Conpcod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIVEND_DATA", AV36CliVend_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIVEND_DATA", AV36CliVend_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCOD_DATA", AV39DisCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCOD_DATA", AV39DisCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROVCOD_DATA", AV43ProvCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROVCOD_DATA", AV43ProvCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vZONCOD_DATA", AV45ZonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vZONCOD_DATA", AV45ZonCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLITIPLCOD_DATA", AV47CliTipLCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLITIPLCOD_DATA", AV47CliTipLCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPSCOD_DATA", AV50TipSCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPSCOD_DATA", AV50TipSCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIDIRZONCOD_DATA", AV22CliDirZonCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIDIRZONCOD_DATA", AV22CliDirZonCod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCOND_ESTCOD", StringUtil.RTrim( AV41Cond_EstCod));
         GxWebStd.gx_hidden_field( context, "vCOND_PAICOD", StringUtil.RTrim( AV29Cond_PaiCod));
         GxWebStd.gx_hidden_field( context, "vCOND_PROVCOD", StringUtil.RTrim( AV42Cond_ProvCod));
         GxWebStd.gx_hidden_field( context, "ESTDSC", StringUtil.RTrim( A602EstDsc));
         GxWebStd.gx_hidden_field( context, "PROVDSC", StringUtil.RTrim( A603ProvDsc));
         GxWebStd.gx_hidden_field( context, "DISDSC", StringUtil.RTrim( A604DisDsc));
         GxWebStd.gx_hidden_field( context, "vCLICOD", StringUtil.RTrim( AV7CliCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CliCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTCOD", StringUtil.RTrim( AV11Insert_EstCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAICOD", StringUtil.RTrim( AV12Insert_PaiCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_TipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIVEND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_CliVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DISCOD", StringUtil.RTrim( AV16Insert_DisCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVCOD", StringUtil.RTrim( AV17Insert_ProvCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_ZONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_ZonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLITIPLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_CliTipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPSCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_TipSCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIFOTO_GXI", A40000CliFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GXCCtlgxBlob = "CLIFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A612CliFoto);
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Objectcall", StringUtil.RTrim( Combo_estcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Cls", StringUtil.RTrim( Combo_estcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedvalue_set", StringUtil.RTrim( Combo_estcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Selectedtext_set", StringUtil.RTrim( Combo_estcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Enabled", StringUtil.BoolToStr( Combo_estcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Datalistproc", StringUtil.RTrim( Combo_estcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_estcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_ESTCOD_Emptyitem", StringUtil.BoolToStr( Combo_estcod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Objectcall", StringUtil.RTrim( Combo_paicod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Cls", StringUtil.RTrim( Combo_paicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedvalue_set", StringUtil.RTrim( Combo_paicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Selectedtext_set", StringUtil.RTrim( Combo_paicod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Enabled", StringUtil.BoolToStr( Combo_paicod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistproc", StringUtil.RTrim( Combo_paicod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_paicod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PAICOD_Emptyitem", StringUtil.BoolToStr( Combo_paicod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Objectcall", StringUtil.RTrim( Combo_tipccod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Cls", StringUtil.RTrim( Combo_tipccod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipccod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Selectedtext_set", StringUtil.RTrim( Combo_tipccod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Enabled", StringUtil.BoolToStr( Combo_tipccod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Datalistproc", StringUtil.RTrim( Combo_tipccod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipccod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPCCOD_Emptyitem", StringUtil.BoolToStr( Combo_tipccod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Objectcall", StringUtil.RTrim( Combo_conpcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Cls", StringUtil.RTrim( Combo_conpcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Selectedvalue_set", StringUtil.RTrim( Combo_conpcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Selectedtext_set", StringUtil.RTrim( Combo_conpcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Enabled", StringUtil.BoolToStr( Combo_conpcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Datalistproc", StringUtil.RTrim( Combo_conpcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_conpcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CONPCOD_Emptyitem", StringUtil.BoolToStr( Combo_conpcod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Objectcall", StringUtil.RTrim( Combo_clivend_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Cls", StringUtil.RTrim( Combo_clivend_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Selectedvalue_set", StringUtil.RTrim( Combo_clivend_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Selectedtext_set", StringUtil.RTrim( Combo_clivend_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Enabled", StringUtil.BoolToStr( Combo_clivend_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Datalistproc", StringUtil.RTrim( Combo_clivend_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clivend_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIVEND_Emptyitem", StringUtil.BoolToStr( Combo_clivend_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Objectcall", StringUtil.RTrim( Combo_discod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Cls", StringUtil.RTrim( Combo_discod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Selectedvalue_set", StringUtil.RTrim( Combo_discod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Selectedtext_set", StringUtil.RTrim( Combo_discod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Enabled", StringUtil.BoolToStr( Combo_discod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Datalistproc", StringUtil.RTrim( Combo_discod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_discod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_DISCOD_Emptyitem", StringUtil.BoolToStr( Combo_discod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Objectcall", StringUtil.RTrim( Combo_provcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Cls", StringUtil.RTrim( Combo_provcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedvalue_set", StringUtil.RTrim( Combo_provcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Selectedtext_set", StringUtil.RTrim( Combo_provcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Enabled", StringUtil.BoolToStr( Combo_provcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistproc", StringUtil.RTrim( Combo_provcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_provcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROVCOD_Emptyitem", StringUtil.BoolToStr( Combo_provcod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Objectcall", StringUtil.RTrim( Combo_zoncod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Cls", StringUtil.RTrim( Combo_zoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedvalue_set", StringUtil.RTrim( Combo_zoncod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Selectedtext_set", StringUtil.RTrim( Combo_zoncod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Enabled", StringUtil.BoolToStr( Combo_zoncod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Datalistproc", StringUtil.RTrim( Combo_zoncod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_ZONCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_zoncod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Objectcall", StringUtil.RTrim( Combo_clitiplcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Cls", StringUtil.RTrim( Combo_clitiplcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_clitiplcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Selectedtext_set", StringUtil.RTrim( Combo_clitiplcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Enabled", StringUtil.BoolToStr( Combo_clitiplcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Datalistproc", StringUtil.RTrim( Combo_clitiplcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLITIPLCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clitiplcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Objectcall", StringUtil.RTrim( Combo_tipscod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Cls", StringUtil.RTrim( Combo_tipscod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipscod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Selectedtext_set", StringUtil.RTrim( Combo_tipscod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Enabled", StringUtil.BoolToStr( Combo_tipscod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Datalistproc", StringUtil.RTrim( Combo_tipscod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipscod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPSCOD_Emptyitem", StringUtil.BoolToStr( Combo_tipscod_Emptyitem));
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
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Objectcall", StringUtil.RTrim( Combo_clidirzoncod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Cls", StringUtil.RTrim( Combo_clidirzoncod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Enabled", StringUtil.BoolToStr( Combo_clidirzoncod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_clidirzoncod_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Isgriditem", StringUtil.BoolToStr( Combo_clidirzoncod_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Hasdescription", StringUtil.BoolToStr( Combo_clidirzoncod_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Datalistproc", StringUtil.RTrim( Combo_clidirzoncod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clidirzoncod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIDIRZONCOD_Emptyitem", StringUtil.BoolToStr( Combo_clidirzoncod_Emptyitem));
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
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CliCod));
         return formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.Clientes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes" ;
      }

      protected void InitializeNonKey7O11( )
      {
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A159TipCCod = 0;
         AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         A137Conpcod = 0;
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         A160CliVend = 0;
         AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A158ZonCod = 0;
         n158ZonCod = false;
         AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
         n158ZonCod = ((0==A158ZonCod) ? true : false);
         A156CliTipLCod = 0;
         n156CliTipLCod = false;
         AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
         n156CliTipLCod = ((0==A156CliTipLCod) ? true : false);
         A157TipSCod = 0;
         AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
         A601CliDireccionLarga = "";
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
         A161CliDsc = "";
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         A596CliDir = "";
         AssignAttri("", false, "A596CliDir", A596CliDir);
         A629CliTel1 = "";
         AssignAttri("", false, "A629CliTel1", A629CliTel1);
         A630CliTel2 = "";
         AssignAttri("", false, "A630CliTel2", A630CliTel2);
         A611CliFax = "";
         AssignAttri("", false, "A611CliFax", A611CliFax);
         A575CliCel = "";
         AssignAttri("", false, "A575CliCel", A575CliCel);
         A609CliEma = "";
         AssignAttri("", false, "A609CliEma", A609CliEma);
         A637CliWeb = "";
         AssignAttri("", false, "A637CliWeb", A637CliWeb);
         A612CliFoto = "";
         n612CliFoto = false;
         AssignAttri("", false, "A612CliFoto", A612CliFoto);
         AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
         AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
         n612CliFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
         A40000CliFoto_GXI = "";
         n40000CliFoto_GXI = false;
         AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
         AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
         A627CliSts = 0;
         AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
         A613CliLim = 0;
         AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
         A635CliVendDsc = "";
         AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
         A618CliRef1 = "";
         AssignAttri("", false, "A618CliRef1", A618CliRef1);
         A619CliRef2 = "";
         AssignAttri("", false, "A619CliRef2", A619CliRef2);
         A620CliRef3 = "";
         AssignAttri("", false, "A620CliRef3", A620CliRef3);
         A621CliRef4 = "";
         AssignAttri("", false, "A621CliRef4", A621CliRef4);
         A622CliRef5 = "";
         AssignAttri("", false, "A622CliRef5", A622CliRef5);
         A623CliRef6 = "";
         AssignAttri("", false, "A623CliRef6", A623CliRef6);
         A624CliRef7 = "";
         AssignAttri("", false, "A624CliRef7", A624CliRef7);
         A625CliRef8 = "";
         AssignAttri("", false, "A625CliRef8", A625CliRef8);
         A581CliCont1 = "";
         AssignAttri("", false, "A581CliCont1", A581CliCont1);
         A587CliCTel1 = "";
         AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
         A582CliCont2 = "";
         AssignAttri("", false, "A582CliCont2", A582CliCont2);
         A588CliCTel2 = "";
         AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
         A583CliCont3 = "";
         AssignAttri("", false, "A583CliCont3", A583CliCont3);
         A589CliCtel3 = "";
         AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
         A584CliCont4 = "";
         AssignAttri("", false, "A584CliCont4", A584CliCont4);
         A590CliCTel4 = "";
         AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
         A585CliCont5 = "";
         AssignAttri("", false, "A585CliCont5", A585CliCont5);
         A591CliCtel5 = "";
         AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
         A632CliTItemDir = 0;
         AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
         A614CliMon = 0;
         AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
         A636CliVincula = 0;
         AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
         A626CliRetencion = 0;
         AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
         A617CliPercepcion = 0;
         AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
         A615CliNom = "";
         AssignAttri("", false, "A615CliNom", A615CliNom);
         A574CliAPEP = "";
         AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
         A573CliAPEM = "";
         AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
         A633CliUsuCod = "";
         AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
         A634CliUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A610CliEMAPer = "";
         AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
         A616CliPassPer = "";
         AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
         A628CliTCon = 0;
         AssignAttri("", false, "A628CliTCon", StringUtil.LTrimStr( (decimal)(A628CliTCon), 6, 0));
         A631CliTipCod = "";
         AssignAttri("", false, "A631CliTipCod", A631CliTipCod);
         A608CliDTAval = 0;
         AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
         A602EstDsc = "";
         AssignAttri("", false, "A602EstDsc", A602EstDsc);
         A603ProvDsc = "";
         AssignAttri("", false, "A603ProvDsc", A603ProvDsc);
         A604DisDsc = "";
         AssignAttri("", false, "A604DisDsc", A604DisDsc);
         Z161CliDsc = "";
         Z596CliDir = "";
         Z629CliTel1 = "";
         Z630CliTel2 = "";
         Z611CliFax = "";
         Z575CliCel = "";
         Z609CliEma = "";
         Z637CliWeb = "";
         Z627CliSts = 0;
         Z613CliLim = 0;
         Z618CliRef1 = "";
         Z619CliRef2 = "";
         Z620CliRef3 = "";
         Z621CliRef4 = "";
         Z622CliRef5 = "";
         Z623CliRef6 = "";
         Z624CliRef7 = "";
         Z625CliRef8 = "";
         Z581CliCont1 = "";
         Z587CliCTel1 = "";
         Z582CliCont2 = "";
         Z588CliCTel2 = "";
         Z583CliCont3 = "";
         Z589CliCtel3 = "";
         Z584CliCont4 = "";
         Z590CliCTel4 = "";
         Z585CliCont5 = "";
         Z591CliCtel5 = "";
         Z632CliTItemDir = 0;
         Z614CliMon = 0;
         Z636CliVincula = 0;
         Z626CliRetencion = 0;
         Z617CliPercepcion = 0;
         Z615CliNom = "";
         Z574CliAPEP = "";
         Z573CliAPEM = "";
         Z633CliUsuCod = "";
         Z634CliUsuFec = (DateTime)(DateTime.MinValue);
         Z610CliEMAPer = "";
         Z616CliPassPer = "";
         Z628CliTCon = 0;
         Z631CliTipCod = "";
         Z608CliDTAval = 0;
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         Z159TipCCod = 0;
         Z137Conpcod = 0;
         Z158ZonCod = 0;
         Z157TipSCod = 0;
         Z160CliVend = 0;
         Z156CliTipLCod = 0;
      }

      protected void InitAll7O11( )
      {
         A45CliCod = "";
         n45CliCod = false;
         AssignAttri("", false, "A45CliCod", A45CliCod);
         InitializeNonKey7O11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7O83( )
      {
         A600CliDirDsc = "";
         A598CliDirDir = "";
         A605CliDirPais = "";
         A597CliDirDep = "";
         A606CliDirProv = "";
         A599CliDirDis = "";
         A165CliDirZonCod = 0;
         A607CliDirZonDsc = "";
         Z600CliDirDsc = "";
         Z598CliDirDir = "";
         Z605CliDirPais = "";
         Z597CliDirDep = "";
         Z606CliDirProv = "";
         Z599CliDirDis = "";
         Z165CliDirZonCod = 0;
      }

      protected void InitAll7O83( )
      {
         A164CliDirItem = 0;
         InitializeNonKey7O83( ) ;
      }

      protected void StandaloneModalInsert7O83( )
      {
      }

      protected void InitializeNonKey7O13( )
      {
         A578CliConDsc = "";
         A577CliConCargo = "";
         A586CliConTelf = "";
         A576CliConArea = "";
         A579CliConMail = "";
         A580CliConMailFE = 0;
         Z578CliConDsc = "";
         Z577CliConCargo = "";
         Z586CliConTelf = "";
         Z576CliConArea = "";
         Z579CliConMail = "";
         Z580CliConMailFE = 0;
      }

      protected void InitAll7O13( )
      {
         A163CliConCod = 0;
         InitializeNonKey7O13( ) ;
      }

      protected void StandaloneModalInsert7O13( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181028205", true, true);
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
         context.AddJavascriptSource("ventas/clientes.js", "?20228181028206", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void init_level_properties83( )
      {
         edtCliDirItem_Enabled = defedtCliDirItem_Enabled;
         AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), !bGXsfl_368_Refreshing);
      }

      protected void init_level_properties13( )
      {
         edtCliConCod_Enabled = defedtCliConCod_Enabled;
         AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), !bGXsfl_383_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtCliCod_Internalname = "CLICOD";
         edtCliDsc_Internalname = "CLIDSC";
         edtCliDir_Internalname = "CLIDIR";
         lblTextblockestcod_Internalname = "TEXTBLOCKESTCOD";
         Combo_estcod_Internalname = "COMBO_ESTCOD";
         edtEstCod_Internalname = "ESTCOD";
         divTablesplittedestcod_Internalname = "TABLESPLITTEDESTCOD";
         lblTextblockpaicod_Internalname = "TEXTBLOCKPAICOD";
         Combo_paicod_Internalname = "COMBO_PAICOD";
         edtPaiCod_Internalname = "PAICOD";
         divTablesplittedpaicod_Internalname = "TABLESPLITTEDPAICOD";
         edtCliTel1_Internalname = "CLITEL1";
         edtCliTel2_Internalname = "CLITEL2";
         edtCliFax_Internalname = "CLIFAX";
         edtCliCel_Internalname = "CLICEL";
         edtCliEma_Internalname = "CLIEMA";
         edtCliWeb_Internalname = "CLIWEB";
         lblTextblocktipccod_Internalname = "TEXTBLOCKTIPCCOD";
         Combo_tipccod_Internalname = "COMBO_TIPCCOD";
         edtTipCCod_Internalname = "TIPCCOD";
         divTablesplittedtipccod_Internalname = "TABLESPLITTEDTIPCCOD";
         imgCliFoto_Internalname = "CLIFOTO";
         edtCliSts_Internalname = "CLISTS";
         lblTextblockconpcod_Internalname = "TEXTBLOCKCONPCOD";
         Combo_conpcod_Internalname = "COMBO_CONPCOD";
         edtConpcod_Internalname = "CONPCOD";
         divTablesplittedconpcod_Internalname = "TABLESPLITTEDCONPCOD";
         edtCliLim_Internalname = "CLILIM";
         lblTextblockclivend_Internalname = "TEXTBLOCKCLIVEND";
         Combo_clivend_Internalname = "COMBO_CLIVEND";
         edtCliVend_Internalname = "CLIVEND";
         divTablesplittedclivend_Internalname = "TABLESPLITTEDCLIVEND";
         edtCliVendDsc_Internalname = "CLIVENDDSC";
         edtCliRef1_Internalname = "CLIREF1";
         edtCliRef2_Internalname = "CLIREF2";
         edtCliRef3_Internalname = "CLIREF3";
         edtCliRef4_Internalname = "CLIREF4";
         edtCliRef5_Internalname = "CLIREF5";
         edtCliRef6_Internalname = "CLIREF6";
         edtCliRef7_Internalname = "CLIREF7";
         edtCliRef8_Internalname = "CLIREF8";
         edtCliCont1_Internalname = "CLICONT1";
         edtCliCTel1_Internalname = "CLICTEL1";
         edtCliCont2_Internalname = "CLICONT2";
         edtCliCTel2_Internalname = "CLICTEL2";
         edtCliCont3_Internalname = "CLICONT3";
         edtCliCtel3_Internalname = "CLICTEL3";
         edtCliCont4_Internalname = "CLICONT4";
         edtCliCTel4_Internalname = "CLICTEL4";
         edtCliCont5_Internalname = "CLICONT5";
         edtCliCtel5_Internalname = "CLICTEL5";
         lblTextblockdiscod_Internalname = "TEXTBLOCKDISCOD";
         Combo_discod_Internalname = "COMBO_DISCOD";
         edtDisCod_Internalname = "DISCOD";
         divTablesplitteddiscod_Internalname = "TABLESPLITTEDDISCOD";
         lblTextblockprovcod_Internalname = "TEXTBLOCKPROVCOD";
         Combo_provcod_Internalname = "COMBO_PROVCOD";
         edtProvCod_Internalname = "PROVCOD";
         divTablesplittedprovcod_Internalname = "TABLESPLITTEDPROVCOD";
         edtCliTItemDir_Internalname = "CLITITEMDIR";
         lblTextblockzoncod_Internalname = "TEXTBLOCKZONCOD";
         Combo_zoncod_Internalname = "COMBO_ZONCOD";
         edtZonCod_Internalname = "ZONCOD";
         divTablesplittedzoncod_Internalname = "TABLESPLITTEDZONCOD";
         edtCliMon_Internalname = "CLIMON";
         edtCliVincula_Internalname = "CLIVINCULA";
         edtCliRetencion_Internalname = "CLIRETENCION";
         edtCliPercepcion_Internalname = "CLIPERCEPCION";
         lblTextblockclitiplcod_Internalname = "TEXTBLOCKCLITIPLCOD";
         Combo_clitiplcod_Internalname = "COMBO_CLITIPLCOD";
         edtCliTipLCod_Internalname = "CLITIPLCOD";
         divTablesplittedclitiplcod_Internalname = "TABLESPLITTEDCLITIPLCOD";
         edtCliNom_Internalname = "CLINOM";
         edtCliAPEP_Internalname = "CLIAPEP";
         edtCliAPEM_Internalname = "CLIAPEM";
         lblTextblocktipscod_Internalname = "TEXTBLOCKTIPSCOD";
         Combo_tipscod_Internalname = "COMBO_TIPSCOD";
         edtTipSCod_Internalname = "TIPSCOD";
         divTablesplittedtipscod_Internalname = "TABLESPLITTEDTIPSCOD";
         edtCliUsuCod_Internalname = "CLIUSUCOD";
         edtCliUsuFec_Internalname = "CLIUSUFEC";
         edtCliEMAPer_Internalname = "CLIEMAPER";
         edtCliPassPer_Internalname = "CLIPASSPER";
         edtCliTCon_Internalname = "CLITCON";
         edtCliDireccionLarga_Internalname = "CLIDIRECCIONLARGA";
         edtCliTipCod_Internalname = "CLITIPCOD";
         edtCliDTAval_Internalname = "CLIDTAVAL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCliDirItem_Internalname = "CLIDIRITEM";
         edtCliDirDsc_Internalname = "CLIDIRDSC";
         edtCliDirDir_Internalname = "CLIDIRDIR";
         edtCliDirPais_Internalname = "CLIDIRPAIS";
         edtCliDirDep_Internalname = "CLIDIRDEP";
         edtCliDirProv_Internalname = "CLIDIRPROV";
         edtCliDirDis_Internalname = "CLIDIRDIS";
         edtCliDirZonCod_Internalname = "CLIDIRZONCOD";
         edtCliDirZonDsc_Internalname = "CLIDIRZONDSC";
         divTableleaflevel_level1_Internalname = "TABLELEAFLEVEL_LEVEL1";
         edtCliConCod_Internalname = "CLICONCOD";
         edtCliConDsc_Internalname = "CLICONDSC";
         edtCliConCargo_Internalname = "CLICONCARGO";
         edtCliConTelf_Internalname = "CLICONTELF";
         edtCliConArea_Internalname = "CLICONAREA";
         edtCliConMail_Internalname = "CLICONMAIL";
         edtCliConMailFE_Internalname = "CLICONMAILFE";
         divTableleaflevel_level2_Internalname = "TABLELEAFLEVEL_LEVEL2";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboestcod_Internalname = "vCOMBOESTCOD";
         divSectionattribute_estcod_Internalname = "SECTIONATTRIBUTE_ESTCOD";
         edtavCombopaicod_Internalname = "vCOMBOPAICOD";
         divSectionattribute_paicod_Internalname = "SECTIONATTRIBUTE_PAICOD";
         edtavCombotipccod_Internalname = "vCOMBOTIPCCOD";
         divSectionattribute_tipccod_Internalname = "SECTIONATTRIBUTE_TIPCCOD";
         edtavComboconpcod_Internalname = "vCOMBOCONPCOD";
         divSectionattribute_conpcod_Internalname = "SECTIONATTRIBUTE_CONPCOD";
         edtavComboclivend_Internalname = "vCOMBOCLIVEND";
         divSectionattribute_clivend_Internalname = "SECTIONATTRIBUTE_CLIVEND";
         edtavCombodiscod_Internalname = "vCOMBODISCOD";
         divSectionattribute_discod_Internalname = "SECTIONATTRIBUTE_DISCOD";
         edtavComboprovcod_Internalname = "vCOMBOPROVCOD";
         divSectionattribute_provcod_Internalname = "SECTIONATTRIBUTE_PROVCOD";
         edtavCombozoncod_Internalname = "vCOMBOZONCOD";
         divSectionattribute_zoncod_Internalname = "SECTIONATTRIBUTE_ZONCOD";
         edtavComboclitiplcod_Internalname = "vCOMBOCLITIPLCOD";
         divSectionattribute_clitiplcod_Internalname = "SECTIONATTRIBUTE_CLITIPLCOD";
         edtavCombotipscod_Internalname = "vCOMBOTIPSCOD";
         divSectionattribute_tipscod_Internalname = "SECTIONATTRIBUTE_TIPSCOD";
         Combo_clidirzoncod_Internalname = "COMBO_CLIDIRZONCOD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_level1_Internalname = "GRIDLEVEL_LEVEL1";
         subGridlevel_level2_Internalname = "GRIDLEVEL_LEVEL2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Combo_clidirzoncod_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Clientes";
         edtCliConMailFE_Jsonclick = "";
         edtCliConMail_Jsonclick = "";
         edtCliConArea_Jsonclick = "";
         edtCliConTelf_Jsonclick = "";
         edtCliConCargo_Jsonclick = "";
         edtCliConDsc_Jsonclick = "";
         edtCliConCod_Jsonclick = "";
         subGridlevel_level2_Class = "WorkWith";
         subGridlevel_level2_Backcolorstyle = 0;
         edtCliDirZonDsc_Jsonclick = "";
         edtCliDirZonCod_Jsonclick = "";
         edtCliDirDis_Jsonclick = "";
         edtCliDirProv_Jsonclick = "";
         edtCliDirDep_Jsonclick = "";
         edtCliDirPais_Jsonclick = "";
         edtCliDirDir_Jsonclick = "";
         edtCliDirDsc_Jsonclick = "";
         edtCliDirItem_Jsonclick = "";
         subGridlevel_level1_Class = "WorkWith";
         subGridlevel_level1_Backcolorstyle = 0;
         Combo_estcod_Datalistprocparametersprefix = "";
         Combo_discod_Datalistprocparametersprefix = "";
         Combo_provcod_Datalistprocparametersprefix = "";
         Combo_clidirzoncod_Titlecontrolidtoreplace = "";
         subGridlevel_level2_Allowcollapsing = 0;
         subGridlevel_level2_Allowselection = 0;
         edtCliConMailFE_Enabled = 1;
         edtCliConMail_Enabled = 1;
         edtCliConArea_Enabled = 1;
         edtCliConTelf_Enabled = 1;
         edtCliConCargo_Enabled = 1;
         edtCliConDsc_Enabled = 1;
         edtCliConCod_Enabled = 1;
         subGridlevel_level2_Header = "";
         subGridlevel_level1_Allowcollapsing = 0;
         subGridlevel_level1_Allowselection = 0;
         edtCliDirZonDsc_Enabled = 0;
         edtCliDirZonCod_Enabled = 1;
         edtCliDirDis_Enabled = 1;
         edtCliDirProv_Enabled = 1;
         edtCliDirDep_Enabled = 1;
         edtCliDirPais_Enabled = 1;
         edtCliDirDir_Enabled = 1;
         edtCliDirDsc_Enabled = 1;
         edtCliDirItem_Enabled = 1;
         subGridlevel_level1_Header = "";
         Combo_clidirzoncod_Emptyitem = Convert.ToBoolean( 0);
         Combo_clidirzoncod_Datalistprocparametersprefix = " \"ComboName\": \"CliDirZonCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_clidirzoncod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_clidirzoncod_Hasdescription = Convert.ToBoolean( -1);
         Combo_clidirzoncod_Isgriditem = Convert.ToBoolean( -1);
         Combo_clidirzoncod_Cls = "ExtendedCombo";
         Combo_clidirzoncod_Caption = "";
         edtavCombotipscod_Jsonclick = "";
         edtavCombotipscod_Enabled = 0;
         edtavCombotipscod_Visible = 1;
         edtavComboclitiplcod_Jsonclick = "";
         edtavComboclitiplcod_Enabled = 0;
         edtavComboclitiplcod_Visible = 1;
         edtavCombozoncod_Jsonclick = "";
         edtavCombozoncod_Enabled = 0;
         edtavCombozoncod_Visible = 1;
         edtavComboprovcod_Jsonclick = "";
         edtavComboprovcod_Enabled = 0;
         edtavComboprovcod_Visible = 1;
         edtavCombodiscod_Jsonclick = "";
         edtavCombodiscod_Enabled = 0;
         edtavCombodiscod_Visible = 1;
         edtavComboclivend_Jsonclick = "";
         edtavComboclivend_Enabled = 0;
         edtavComboclivend_Visible = 1;
         edtavComboconpcod_Jsonclick = "";
         edtavComboconpcod_Enabled = 0;
         edtavComboconpcod_Visible = 1;
         edtavCombotipccod_Jsonclick = "";
         edtavCombotipccod_Enabled = 0;
         edtavCombotipccod_Visible = 1;
         edtavCombopaicod_Jsonclick = "";
         edtavCombopaicod_Enabled = 0;
         edtavCombopaicod_Visible = 1;
         edtavComboestcod_Jsonclick = "";
         edtavComboestcod_Enabled = 0;
         edtavComboestcod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCliDTAval_Jsonclick = "";
         edtCliDTAval_Enabled = 1;
         edtCliTipCod_Jsonclick = "";
         edtCliTipCod_Enabled = 1;
         edtCliDireccionLarga_Enabled = 0;
         edtCliTCon_Jsonclick = "";
         edtCliTCon_Enabled = 1;
         edtCliPassPer_Jsonclick = "";
         edtCliPassPer_Enabled = 1;
         edtCliEMAPer_Jsonclick = "";
         edtCliEMAPer_Enabled = 1;
         edtCliUsuFec_Jsonclick = "";
         edtCliUsuFec_Enabled = 1;
         edtCliUsuCod_Jsonclick = "";
         edtCliUsuCod_Enabled = 1;
         edtTipSCod_Jsonclick = "";
         edtTipSCod_Enabled = 1;
         edtTipSCod_Visible = 1;
         Combo_tipscod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipscod_Datalistprocparametersprefix = " \"ComboName\": \"TipSCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_tipscod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_tipscod_Cls = "ExtendedCombo Attribute";
         Combo_tipscod_Caption = "";
         Combo_tipscod_Enabled = Convert.ToBoolean( -1);
         edtCliAPEM_Jsonclick = "";
         edtCliAPEM_Enabled = 1;
         edtCliAPEP_Jsonclick = "";
         edtCliAPEP_Enabled = 1;
         edtCliNom_Jsonclick = "";
         edtCliNom_Enabled = 1;
         edtCliTipLCod_Jsonclick = "";
         edtCliTipLCod_Enabled = 1;
         edtCliTipLCod_Visible = 1;
         Combo_clitiplcod_Datalistprocparametersprefix = " \"ComboName\": \"CliTipLCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_clitiplcod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_clitiplcod_Cls = "ExtendedCombo Attribute";
         Combo_clitiplcod_Caption = "";
         Combo_clitiplcod_Enabled = Convert.ToBoolean( -1);
         edtCliPercepcion_Jsonclick = "";
         edtCliPercepcion_Enabled = 1;
         edtCliRetencion_Jsonclick = "";
         edtCliRetencion_Enabled = 1;
         edtCliVincula_Jsonclick = "";
         edtCliVincula_Enabled = 1;
         edtCliMon_Jsonclick = "";
         edtCliMon_Enabled = 1;
         edtZonCod_Jsonclick = "";
         edtZonCod_Enabled = 1;
         edtZonCod_Visible = 1;
         Combo_zoncod_Datalistprocparametersprefix = " \"ComboName\": \"ZonCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_zoncod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_zoncod_Cls = "ExtendedCombo Attribute";
         Combo_zoncod_Caption = "";
         Combo_zoncod_Enabled = Convert.ToBoolean( -1);
         edtCliTItemDir_Jsonclick = "";
         edtCliTItemDir_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtProvCod_Visible = 1;
         Combo_provcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_provcod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_provcod_Cls = "ExtendedCombo Attribute";
         Combo_provcod_Caption = "";
         Combo_provcod_Enabled = Convert.ToBoolean( -1);
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
         edtDisCod_Visible = 1;
         Combo_discod_Emptyitem = Convert.ToBoolean( 0);
         Combo_discod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_discod_Cls = "ExtendedCombo Attribute";
         Combo_discod_Caption = "";
         Combo_discod_Enabled = Convert.ToBoolean( -1);
         edtCliCtel5_Jsonclick = "";
         edtCliCtel5_Enabled = 1;
         edtCliCont5_Jsonclick = "";
         edtCliCont5_Enabled = 1;
         edtCliCTel4_Jsonclick = "";
         edtCliCTel4_Enabled = 1;
         edtCliCont4_Jsonclick = "";
         edtCliCont4_Enabled = 1;
         edtCliCtel3_Jsonclick = "";
         edtCliCtel3_Enabled = 1;
         edtCliCont3_Jsonclick = "";
         edtCliCont3_Enabled = 1;
         edtCliCTel2_Jsonclick = "";
         edtCliCTel2_Enabled = 1;
         edtCliCont2_Jsonclick = "";
         edtCliCont2_Enabled = 1;
         edtCliCTel1_Jsonclick = "";
         edtCliCTel1_Enabled = 1;
         edtCliCont1_Jsonclick = "";
         edtCliCont1_Enabled = 1;
         edtCliRef8_Jsonclick = "";
         edtCliRef8_Enabled = 1;
         edtCliRef7_Jsonclick = "";
         edtCliRef7_Enabled = 1;
         edtCliRef6_Jsonclick = "";
         edtCliRef6_Enabled = 1;
         edtCliRef5_Jsonclick = "";
         edtCliRef5_Enabled = 1;
         edtCliRef4_Jsonclick = "";
         edtCliRef4_Enabled = 1;
         edtCliRef3_Jsonclick = "";
         edtCliRef3_Enabled = 1;
         edtCliRef2_Jsonclick = "";
         edtCliRef2_Enabled = 1;
         edtCliRef1_Jsonclick = "";
         edtCliRef1_Enabled = 1;
         edtCliVendDsc_Jsonclick = "";
         edtCliVendDsc_Enabled = 0;
         edtCliVend_Jsonclick = "";
         edtCliVend_Enabled = 1;
         edtCliVend_Visible = 1;
         Combo_clivend_Emptyitem = Convert.ToBoolean( 0);
         Combo_clivend_Datalistprocparametersprefix = " \"ComboName\": \"CliVend\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_clivend_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_clivend_Cls = "ExtendedCombo Attribute";
         Combo_clivend_Caption = "";
         Combo_clivend_Enabled = Convert.ToBoolean( -1);
         edtCliLim_Jsonclick = "";
         edtCliLim_Enabled = 1;
         edtConpcod_Jsonclick = "";
         edtConpcod_Enabled = 1;
         edtConpcod_Visible = 1;
         Combo_conpcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_conpcod_Datalistprocparametersprefix = " \"ComboName\": \"Conpcod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_conpcod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_conpcod_Cls = "ExtendedCombo Attribute";
         Combo_conpcod_Caption = "";
         Combo_conpcod_Enabled = Convert.ToBoolean( -1);
         edtCliSts_Jsonclick = "";
         edtCliSts_Enabled = 1;
         imgCliFoto_Enabled = 1;
         edtTipCCod_Jsonclick = "";
         edtTipCCod_Enabled = 1;
         edtTipCCod_Visible = 1;
         Combo_tipccod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipccod_Datalistprocparametersprefix = " \"ComboName\": \"TipCCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_tipccod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_tipccod_Cls = "ExtendedCombo Attribute";
         Combo_tipccod_Caption = "";
         Combo_tipccod_Enabled = Convert.ToBoolean( -1);
         edtCliWeb_Jsonclick = "";
         edtCliWeb_Enabled = 1;
         edtCliEma_Jsonclick = "";
         edtCliEma_Enabled = 1;
         edtCliCel_Jsonclick = "";
         edtCliCel_Enabled = 1;
         edtCliFax_Jsonclick = "";
         edtCliFax_Enabled = 1;
         edtCliTel2_Jsonclick = "";
         edtCliTel2_Enabled = 1;
         edtCliTel1_Jsonclick = "";
         edtCliTel1_Enabled = 1;
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtPaiCod_Visible = 1;
         Combo_paicod_Emptyitem = Convert.ToBoolean( 0);
         Combo_paicod_Datalistprocparametersprefix = " \"ComboName\": \"PaiCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliCod\": \"\"";
         Combo_paicod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_paicod_Cls = "ExtendedCombo Attribute";
         Combo_paicod_Caption = "";
         Combo_paicod_Enabled = Convert.ToBoolean( -1);
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtEstCod_Visible = 1;
         Combo_estcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_estcod_Datalistproc = "Ventas.ClientesLoadDVCombo";
         Combo_estcod_Cls = "ExtendedCombo Attribute";
         Combo_estcod_Caption = "";
         Combo_estcod_Enabled = Convert.ToBoolean( -1);
         edtCliDir_Jsonclick = "";
         edtCliDir_Enabled = 1;
         edtCliDsc_Jsonclick = "";
         edtCliDsc_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
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
         edtCliDirZonCod_Horizontalalignment = "right";
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
         SubsflControlProps_36883( ) ;
         while ( nGXsfl_368_idx <= nRC_GXsfl_368 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7O83( ) ;
            standaloneModal7O83( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7O83( ) ;
            nGXsfl_368_idx = (int)(nGXsfl_368_idx+1);
            sGXsfl_368_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_368_idx), 4, 0), 4, "0");
            SubsflControlProps_36883( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level1Container)) ;
         /* End function gxnrGridlevel_level1_newrow */
      }

      protected void gxnrGridlevel_level2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_38313( ) ;
         while ( nGXsfl_383_idx <= nRC_GXsfl_383 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal7O13( ) ;
            standaloneModal7O13( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow7O13( ) ;
            nGXsfl_383_idx = (int)(nGXsfl_383_idx+1);
            sGXsfl_383_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_383_idx), 4, 0), 4, "0");
            SubsflControlProps_38313( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level2Container)) ;
         /* End function gxnrGridlevel_level2_newrow */
      }

      protected void init_web_controls( )
      {
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

      public void Valid_Paicod( )
      {
         /* Using cursor T007O35 */
         pr_default.execute(33, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A602EstDsc = T007O35_A602EstDsc[0];
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A602EstDsc", StringUtil.RTrim( A602EstDsc));
      }

      public void Valid_Tipccod( )
      {
         /* Using cursor T007O74 */
         pr_default.execute(72, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(72) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Cliente'.", "ForeignKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
         }
         pr_default.close(72);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Conpcod( )
      {
         /* Using cursor T007O75 */
         pr_default.execute(73, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(73) == 101) )
         {
            GX_msglist.addItem("No existe 'Condiciones de Pago'.", "ForeignKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
         }
         pr_default.close(73);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clivend( )
      {
         /* Using cursor T007O36 */
         pr_default.execute(34, new Object[] {A160CliVend});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedores'.", "ForeignKeyNotFound", 1, "CLIVEND");
            AnyError = 1;
            GX_FocusControl = edtCliVend_Internalname;
         }
         A635CliVendDsc = T007O36_A635CliVendDsc[0];
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A635CliVendDsc", StringUtil.RTrim( A635CliVendDsc));
      }

      public void Valid_Provcod( )
      {
         /* Using cursor T007O37 */
         pr_default.execute(35, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(35) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A603ProvDsc = T007O37_A603ProvDsc[0];
         pr_default.close(35);
         /* Using cursor T007O38 */
         pr_default.execute(36, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(36) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A604DisDsc = T007O38_A604DisDsc[0];
         pr_default.close(36);
         A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A603ProvDsc", StringUtil.RTrim( A603ProvDsc));
         AssignAttri("", false, "A604DisDsc", StringUtil.RTrim( A604DisDsc));
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
      }

      public void Valid_Zoncod( )
      {
         n158ZonCod = false;
         /* Using cursor T007O76 */
         pr_default.execute(74, new Object[] {n158ZonCod, A158ZonCod});
         if ( (pr_default.getStatus(74) == 101) )
         {
            if ( ! ( (0==A158ZonCod) ) )
            {
               GX_msglist.addItem("No existe 'Zonas'.", "ForeignKeyNotFound", 1, "ZONCOD");
               AnyError = 1;
               GX_FocusControl = edtZonCod_Internalname;
            }
         }
         pr_default.close(74);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clitiplcod( )
      {
         n156CliTipLCod = false;
         /* Using cursor T007O77 */
         pr_default.execute(75, new Object[] {n156CliTipLCod, A156CliTipLCod});
         if ( (pr_default.getStatus(75) == 101) )
         {
            if ( ! ( (0==A156CliTipLCod) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "CLITIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtCliTipLCod_Internalname;
            }
         }
         pr_default.close(75);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipscod( )
      {
         /* Using cursor T007O78 */
         pr_default.execute(76, new Object[] {A157TipSCod});
         if ( (pr_default.getStatus(76) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
            AnyError = 1;
            GX_FocusControl = edtTipSCod_Internalname;
         }
         pr_default.close(76);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clidirzoncod( )
      {
         /* Using cursor T007O64 */
         pr_default.execute(62, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(62) == 101) )
         {
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, "CLIDIRZONCOD");
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
         }
         A607CliDirZonDsc = T007O64_A607CliDirZonDsc[0];
         pr_default.close(62);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A607CliDirZonDsc", StringUtil.RTrim( A607CliDirZonDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliCod',fld:'vCLICOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CliCod',fld:'vCLICOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E127O2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
         setEventMetadata("VALID_CLIDIR","{handler:'Valid_Clidir',iparms:[]");
         setEventMetadata("VALID_CLIDIR",",oparms:[]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A602EstDsc',fld:'ESTDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A602EstDsc',fld:'ESTDSC',pic:''}]}");
         setEventMetadata("VALID_CLIEMA","{handler:'Valid_Cliema',iparms:[]");
         setEventMetadata("VALID_CLIEMA",",oparms:[]}");
         setEventMetadata("VALID_TIPCCOD","{handler:'Valid_Tipccod',iparms:[{av:'A159TipCCod',fld:'TIPCCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPCCOD",",oparms:[]}");
         setEventMetadata("VALID_CONPCOD","{handler:'Valid_Conpcod',iparms:[{av:'A137Conpcod',fld:'CONPCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CONPCOD",",oparms:[]}");
         setEventMetadata("VALID_CLIVEND","{handler:'Valid_Clivend',iparms:[{av:'A160CliVend',fld:'CLIVEND',pic:'ZZZZZ9'},{av:'A635CliVendDsc',fld:'CLIVENDDSC',pic:''}]");
         setEventMetadata("VALID_CLIVEND",",oparms:[{av:'A635CliVendDsc',fld:'CLIVENDDSC',pic:''}]}");
         setEventMetadata("VALID_DISCOD","{handler:'Valid_Discod',iparms:[]");
         setEventMetadata("VALID_DISCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''},{av:'A596CliDir',fld:'CLIDIR',pic:''},{av:'A602EstDsc',fld:'ESTDSC',pic:''},{av:'A603ProvDsc',fld:'PROVDSC',pic:''},{av:'A604DisDsc',fld:'DISDSC',pic:''},{av:'A601CliDireccionLarga',fld:'CLIDIRECCIONLARGA',pic:''}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[{av:'A603ProvDsc',fld:'PROVDSC',pic:''},{av:'A604DisDsc',fld:'DISDSC',pic:''},{av:'A601CliDireccionLarga',fld:'CLIDIRECCIONLARGA',pic:''}]}");
         setEventMetadata("VALID_ZONCOD","{handler:'Valid_Zoncod',iparms:[{av:'A158ZonCod',fld:'ZONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ZONCOD",",oparms:[]}");
         setEventMetadata("VALID_CLITIPLCOD","{handler:'Valid_Clitiplcod',iparms:[{av:'A156CliTipLCod',fld:'CLITIPLCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CLITIPLCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPSCOD","{handler:'Valid_Tipscod',iparms:[{av:'A157TipSCod',fld:'TIPSCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPSCOD",",oparms:[]}");
         setEventMetadata("VALID_CLIUSUFEC","{handler:'Valid_Cliusufec',iparms:[]");
         setEventMetadata("VALID_CLIUSUFEC",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOESTCOD","{handler:'Validv_Comboestcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOESTCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPAICOD","{handler:'Validv_Combopaicod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPAICOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOTIPCCOD","{handler:'Validv_Combotipccod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPCCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCONPCOD","{handler:'Validv_Comboconpcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCONPCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCLIVEND","{handler:'Validv_Comboclivend',iparms:[]");
         setEventMetadata("VALIDV_COMBOCLIVEND",",oparms:[]}");
         setEventMetadata("VALIDV_COMBODISCOD","{handler:'Validv_Combodiscod',iparms:[]");
         setEventMetadata("VALIDV_COMBODISCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOPROVCOD","{handler:'Validv_Comboprovcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOPROVCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOZONCOD","{handler:'Validv_Combozoncod',iparms:[]");
         setEventMetadata("VALIDV_COMBOZONCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCLITIPLCOD","{handler:'Validv_Comboclitiplcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCLITIPLCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOTIPSCOD","{handler:'Validv_Combotipscod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPSCOD",",oparms:[]}");
         setEventMetadata("VALID_CLIDIRITEM","{handler:'Valid_Clidiritem',iparms:[]");
         setEventMetadata("VALID_CLIDIRITEM",",oparms:[]}");
         setEventMetadata("VALID_CLIDIRZONCOD","{handler:'Valid_Clidirzoncod',iparms:[{av:'A165CliDirZonCod',fld:'CLIDIRZONCOD',pic:'ZZZZZ9'},{av:'A607CliDirZonDsc',fld:'CLIDIRZONDSC',pic:''}]");
         setEventMetadata("VALID_CLIDIRZONCOD",",oparms:[{av:'A607CliDirZonDsc',fld:'CLIDIRZONDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Clidirzondsc',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_CLICONCOD","{handler:'Valid_Cliconcod',iparms:[]");
         setEventMetadata("VALID_CLICONCOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cliconmailfe',iparms:[]");
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
         pr_default.close(3);
         pr_default.close(62);
         pr_default.close(6);
         pr_default.close(36);
         pr_default.close(33);
         pr_default.close(35);
         pr_default.close(72);
         pr_default.close(73);
         pr_default.close(74);
         pr_default.close(76);
         pr_default.close(34);
         pr_default.close(75);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CliCod = "";
         Z45CliCod = "";
         Z161CliDsc = "";
         Z596CliDir = "";
         Z629CliTel1 = "";
         Z630CliTel2 = "";
         Z611CliFax = "";
         Z575CliCel = "";
         Z609CliEma = "";
         Z637CliWeb = "";
         Z618CliRef1 = "";
         Z619CliRef2 = "";
         Z620CliRef3 = "";
         Z621CliRef4 = "";
         Z622CliRef5 = "";
         Z623CliRef6 = "";
         Z624CliRef7 = "";
         Z625CliRef8 = "";
         Z581CliCont1 = "";
         Z587CliCTel1 = "";
         Z582CliCont2 = "";
         Z588CliCTel2 = "";
         Z583CliCont3 = "";
         Z589CliCtel3 = "";
         Z584CliCont4 = "";
         Z590CliCTel4 = "";
         Z585CliCont5 = "";
         Z591CliCtel5 = "";
         Z615CliNom = "";
         Z574CliAPEP = "";
         Z573CliAPEM = "";
         Z633CliUsuCod = "";
         Z634CliUsuFec = (DateTime)(DateTime.MinValue);
         Z610CliEMAPer = "";
         Z616CliPassPer = "";
         Z631CliTipCod = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         N140EstCod = "";
         N139PaiCod = "";
         N142DisCod = "";
         N141ProvCod = "";
         Combo_tipscod_Selectedvalue_get = "";
         Combo_clitiplcod_Selectedvalue_get = "";
         Combo_zoncod_Selectedvalue_get = "";
         Combo_provcod_Selectedvalue_get = "";
         Combo_discod_Selectedvalue_get = "";
         Combo_clivend_Selectedvalue_get = "";
         Combo_conpcod_Selectedvalue_get = "";
         Combo_tipccod_Selectedvalue_get = "";
         Combo_paicod_Selectedvalue_get = "";
         Combo_estcod_Selectedvalue_get = "";
         Z600CliDirDsc = "";
         Z598CliDirDir = "";
         Z605CliDirPais = "";
         Z597CliDirDep = "";
         Z606CliDirProv = "";
         Z599CliDirDis = "";
         Z578CliConDsc = "";
         Z577CliConCargo = "";
         Z586CliConTelf = "";
         Z576CliConArea = "";
         Z579CliConMail = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
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
         A45CliCod = "";
         A161CliDsc = "";
         A596CliDir = "";
         lblTextblockestcod_Jsonclick = "";
         ucCombo_estcod = new GXUserControl();
         AV23DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27EstCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockpaicod_Jsonclick = "";
         ucCombo_paicod = new GXUserControl();
         AV30PaiCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A629CliTel1 = "";
         A630CliTel2 = "";
         A611CliFax = "";
         A575CliCel = "";
         A609CliEma = "";
         A637CliWeb = "";
         lblTextblocktipccod_Jsonclick = "";
         ucCombo_tipccod = new GXUserControl();
         AV32TipCCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A612CliFoto = "";
         A40000CliFoto_GXI = "";
         sImgUrl = "";
         lblTextblockconpcod_Jsonclick = "";
         ucCombo_conpcod = new GXUserControl();
         AV34Conpcod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockclivend_Jsonclick = "";
         ucCombo_clivend = new GXUserControl();
         AV36CliVend_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A635CliVendDsc = "";
         A618CliRef1 = "";
         A619CliRef2 = "";
         A620CliRef3 = "";
         A621CliRef4 = "";
         A622CliRef5 = "";
         A623CliRef6 = "";
         A624CliRef7 = "";
         A625CliRef8 = "";
         A581CliCont1 = "";
         A587CliCTel1 = "";
         A582CliCont2 = "";
         A588CliCTel2 = "";
         A583CliCont3 = "";
         A589CliCtel3 = "";
         A584CliCont4 = "";
         A590CliCTel4 = "";
         A585CliCont5 = "";
         A591CliCtel5 = "";
         lblTextblockdiscod_Jsonclick = "";
         ucCombo_discod = new GXUserControl();
         AV39DisCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprovcod_Jsonclick = "";
         ucCombo_provcod = new GXUserControl();
         AV43ProvCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockzoncod_Jsonclick = "";
         ucCombo_zoncod = new GXUserControl();
         AV45ZonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockclitiplcod_Jsonclick = "";
         ucCombo_clitiplcod = new GXUserControl();
         AV47CliTipLCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A615CliNom = "";
         A574CliAPEP = "";
         A573CliAPEM = "";
         lblTextblocktipscod_Jsonclick = "";
         ucCombo_tipscod = new GXUserControl();
         AV50TipSCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A633CliUsuCod = "";
         A634CliUsuFec = (DateTime)(DateTime.MinValue);
         A610CliEMAPer = "";
         A616CliPassPer = "";
         A601CliDireccionLarga = "";
         A631CliTipCod = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV28ComboEstCod = "";
         AV31ComboPaiCod = "";
         AV40ComboDisCod = "";
         AV44ComboProvCod = "";
         ucCombo_clidirzoncod = new GXUserControl();
         AV22CliDirZonCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Gridlevel_level1Container = new GXWebGrid( context);
         Gridlevel_level1Column = new GXWebColumn();
         A600CliDirDsc = "";
         A598CliDirDir = "";
         A605CliDirPais = "";
         A597CliDirDep = "";
         A606CliDirProv = "";
         A599CliDirDis = "";
         A607CliDirZonDsc = "";
         sMode83 = "";
         sStyleString = "";
         Gridlevel_level2Container = new GXWebGrid( context);
         Gridlevel_level2Column = new GXWebColumn();
         A578CliConDsc = "";
         A577CliConCargo = "";
         A586CliConTelf = "";
         A576CliConArea = "";
         A579CliConMail = "";
         sMode13 = "";
         AV41Cond_EstCod = "";
         AV29Cond_PaiCod = "";
         AV42Cond_ProvCod = "";
         A602EstDsc = "";
         A603ProvDsc = "";
         A604DisDsc = "";
         AV11Insert_EstCod = "";
         AV12Insert_PaiCod = "";
         AV16Insert_DisCod = "";
         AV17Insert_ProvCod = "";
         AV52Pgmname = "";
         Combo_estcod_Objectcall = "";
         Combo_estcod_Class = "";
         Combo_estcod_Icontype = "";
         Combo_estcod_Icon = "";
         Combo_estcod_Tooltip = "";
         Combo_estcod_Selectedvalue_set = "";
         Combo_estcod_Selectedtext_set = "";
         Combo_estcod_Selectedtext_get = "";
         Combo_estcod_Gamoauthtoken = "";
         Combo_estcod_Ddointernalname = "";
         Combo_estcod_Titlecontrolalign = "";
         Combo_estcod_Dropdownoptionstype = "";
         Combo_estcod_Titlecontrolidtoreplace = "";
         Combo_estcod_Datalisttype = "";
         Combo_estcod_Datalistfixedvalues = "";
         Combo_estcod_Htmltemplate = "";
         Combo_estcod_Multiplevaluestype = "";
         Combo_estcod_Loadingdata = "";
         Combo_estcod_Noresultsfound = "";
         Combo_estcod_Emptyitemtext = "";
         Combo_estcod_Onlyselectedvalues = "";
         Combo_estcod_Selectalltext = "";
         Combo_estcod_Multiplevaluesseparator = "";
         Combo_estcod_Addnewoptiontext = "";
         Combo_paicod_Objectcall = "";
         Combo_paicod_Class = "";
         Combo_paicod_Icontype = "";
         Combo_paicod_Icon = "";
         Combo_paicod_Tooltip = "";
         Combo_paicod_Selectedvalue_set = "";
         Combo_paicod_Selectedtext_set = "";
         Combo_paicod_Selectedtext_get = "";
         Combo_paicod_Gamoauthtoken = "";
         Combo_paicod_Ddointernalname = "";
         Combo_paicod_Titlecontrolalign = "";
         Combo_paicod_Dropdownoptionstype = "";
         Combo_paicod_Titlecontrolidtoreplace = "";
         Combo_paicod_Datalisttype = "";
         Combo_paicod_Datalistfixedvalues = "";
         Combo_paicod_Htmltemplate = "";
         Combo_paicod_Multiplevaluestype = "";
         Combo_paicod_Loadingdata = "";
         Combo_paicod_Noresultsfound = "";
         Combo_paicod_Emptyitemtext = "";
         Combo_paicod_Onlyselectedvalues = "";
         Combo_paicod_Selectalltext = "";
         Combo_paicod_Multiplevaluesseparator = "";
         Combo_paicod_Addnewoptiontext = "";
         Combo_tipccod_Objectcall = "";
         Combo_tipccod_Class = "";
         Combo_tipccod_Icontype = "";
         Combo_tipccod_Icon = "";
         Combo_tipccod_Tooltip = "";
         Combo_tipccod_Selectedvalue_set = "";
         Combo_tipccod_Selectedtext_set = "";
         Combo_tipccod_Selectedtext_get = "";
         Combo_tipccod_Gamoauthtoken = "";
         Combo_tipccod_Ddointernalname = "";
         Combo_tipccod_Titlecontrolalign = "";
         Combo_tipccod_Dropdownoptionstype = "";
         Combo_tipccod_Titlecontrolidtoreplace = "";
         Combo_tipccod_Datalisttype = "";
         Combo_tipccod_Datalistfixedvalues = "";
         Combo_tipccod_Htmltemplate = "";
         Combo_tipccod_Multiplevaluestype = "";
         Combo_tipccod_Loadingdata = "";
         Combo_tipccod_Noresultsfound = "";
         Combo_tipccod_Emptyitemtext = "";
         Combo_tipccod_Onlyselectedvalues = "";
         Combo_tipccod_Selectalltext = "";
         Combo_tipccod_Multiplevaluesseparator = "";
         Combo_tipccod_Addnewoptiontext = "";
         Combo_conpcod_Objectcall = "";
         Combo_conpcod_Class = "";
         Combo_conpcod_Icontype = "";
         Combo_conpcod_Icon = "";
         Combo_conpcod_Tooltip = "";
         Combo_conpcod_Selectedvalue_set = "";
         Combo_conpcod_Selectedtext_set = "";
         Combo_conpcod_Selectedtext_get = "";
         Combo_conpcod_Gamoauthtoken = "";
         Combo_conpcod_Ddointernalname = "";
         Combo_conpcod_Titlecontrolalign = "";
         Combo_conpcod_Dropdownoptionstype = "";
         Combo_conpcod_Titlecontrolidtoreplace = "";
         Combo_conpcod_Datalisttype = "";
         Combo_conpcod_Datalistfixedvalues = "";
         Combo_conpcod_Htmltemplate = "";
         Combo_conpcod_Multiplevaluestype = "";
         Combo_conpcod_Loadingdata = "";
         Combo_conpcod_Noresultsfound = "";
         Combo_conpcod_Emptyitemtext = "";
         Combo_conpcod_Onlyselectedvalues = "";
         Combo_conpcod_Selectalltext = "";
         Combo_conpcod_Multiplevaluesseparator = "";
         Combo_conpcod_Addnewoptiontext = "";
         Combo_clivend_Objectcall = "";
         Combo_clivend_Class = "";
         Combo_clivend_Icontype = "";
         Combo_clivend_Icon = "";
         Combo_clivend_Tooltip = "";
         Combo_clivend_Selectedvalue_set = "";
         Combo_clivend_Selectedtext_set = "";
         Combo_clivend_Selectedtext_get = "";
         Combo_clivend_Gamoauthtoken = "";
         Combo_clivend_Ddointernalname = "";
         Combo_clivend_Titlecontrolalign = "";
         Combo_clivend_Dropdownoptionstype = "";
         Combo_clivend_Titlecontrolidtoreplace = "";
         Combo_clivend_Datalisttype = "";
         Combo_clivend_Datalistfixedvalues = "";
         Combo_clivend_Htmltemplate = "";
         Combo_clivend_Multiplevaluestype = "";
         Combo_clivend_Loadingdata = "";
         Combo_clivend_Noresultsfound = "";
         Combo_clivend_Emptyitemtext = "";
         Combo_clivend_Onlyselectedvalues = "";
         Combo_clivend_Selectalltext = "";
         Combo_clivend_Multiplevaluesseparator = "";
         Combo_clivend_Addnewoptiontext = "";
         Combo_discod_Objectcall = "";
         Combo_discod_Class = "";
         Combo_discod_Icontype = "";
         Combo_discod_Icon = "";
         Combo_discod_Tooltip = "";
         Combo_discod_Selectedvalue_set = "";
         Combo_discod_Selectedtext_set = "";
         Combo_discod_Selectedtext_get = "";
         Combo_discod_Gamoauthtoken = "";
         Combo_discod_Ddointernalname = "";
         Combo_discod_Titlecontrolalign = "";
         Combo_discod_Dropdownoptionstype = "";
         Combo_discod_Titlecontrolidtoreplace = "";
         Combo_discod_Datalisttype = "";
         Combo_discod_Datalistfixedvalues = "";
         Combo_discod_Htmltemplate = "";
         Combo_discod_Multiplevaluestype = "";
         Combo_discod_Loadingdata = "";
         Combo_discod_Noresultsfound = "";
         Combo_discod_Emptyitemtext = "";
         Combo_discod_Onlyselectedvalues = "";
         Combo_discod_Selectalltext = "";
         Combo_discod_Multiplevaluesseparator = "";
         Combo_discod_Addnewoptiontext = "";
         Combo_provcod_Objectcall = "";
         Combo_provcod_Class = "";
         Combo_provcod_Icontype = "";
         Combo_provcod_Icon = "";
         Combo_provcod_Tooltip = "";
         Combo_provcod_Selectedvalue_set = "";
         Combo_provcod_Selectedtext_set = "";
         Combo_provcod_Selectedtext_get = "";
         Combo_provcod_Gamoauthtoken = "";
         Combo_provcod_Ddointernalname = "";
         Combo_provcod_Titlecontrolalign = "";
         Combo_provcod_Dropdownoptionstype = "";
         Combo_provcod_Titlecontrolidtoreplace = "";
         Combo_provcod_Datalisttype = "";
         Combo_provcod_Datalistfixedvalues = "";
         Combo_provcod_Htmltemplate = "";
         Combo_provcod_Multiplevaluestype = "";
         Combo_provcod_Loadingdata = "";
         Combo_provcod_Noresultsfound = "";
         Combo_provcod_Emptyitemtext = "";
         Combo_provcod_Onlyselectedvalues = "";
         Combo_provcod_Selectalltext = "";
         Combo_provcod_Multiplevaluesseparator = "";
         Combo_provcod_Addnewoptiontext = "";
         Combo_zoncod_Objectcall = "";
         Combo_zoncod_Class = "";
         Combo_zoncod_Icontype = "";
         Combo_zoncod_Icon = "";
         Combo_zoncod_Tooltip = "";
         Combo_zoncod_Selectedvalue_set = "";
         Combo_zoncod_Selectedtext_set = "";
         Combo_zoncod_Selectedtext_get = "";
         Combo_zoncod_Gamoauthtoken = "";
         Combo_zoncod_Ddointernalname = "";
         Combo_zoncod_Titlecontrolalign = "";
         Combo_zoncod_Dropdownoptionstype = "";
         Combo_zoncod_Titlecontrolidtoreplace = "";
         Combo_zoncod_Datalisttype = "";
         Combo_zoncod_Datalistfixedvalues = "";
         Combo_zoncod_Htmltemplate = "";
         Combo_zoncod_Multiplevaluestype = "";
         Combo_zoncod_Loadingdata = "";
         Combo_zoncod_Noresultsfound = "";
         Combo_zoncod_Emptyitemtext = "";
         Combo_zoncod_Onlyselectedvalues = "";
         Combo_zoncod_Selectalltext = "";
         Combo_zoncod_Multiplevaluesseparator = "";
         Combo_zoncod_Addnewoptiontext = "";
         Combo_clitiplcod_Objectcall = "";
         Combo_clitiplcod_Class = "";
         Combo_clitiplcod_Icontype = "";
         Combo_clitiplcod_Icon = "";
         Combo_clitiplcod_Tooltip = "";
         Combo_clitiplcod_Selectedvalue_set = "";
         Combo_clitiplcod_Selectedtext_set = "";
         Combo_clitiplcod_Selectedtext_get = "";
         Combo_clitiplcod_Gamoauthtoken = "";
         Combo_clitiplcod_Ddointernalname = "";
         Combo_clitiplcod_Titlecontrolalign = "";
         Combo_clitiplcod_Dropdownoptionstype = "";
         Combo_clitiplcod_Titlecontrolidtoreplace = "";
         Combo_clitiplcod_Datalisttype = "";
         Combo_clitiplcod_Datalistfixedvalues = "";
         Combo_clitiplcod_Htmltemplate = "";
         Combo_clitiplcod_Multiplevaluestype = "";
         Combo_clitiplcod_Loadingdata = "";
         Combo_clitiplcod_Noresultsfound = "";
         Combo_clitiplcod_Emptyitemtext = "";
         Combo_clitiplcod_Onlyselectedvalues = "";
         Combo_clitiplcod_Selectalltext = "";
         Combo_clitiplcod_Multiplevaluesseparator = "";
         Combo_clitiplcod_Addnewoptiontext = "";
         Combo_tipscod_Objectcall = "";
         Combo_tipscod_Class = "";
         Combo_tipscod_Icontype = "";
         Combo_tipscod_Icon = "";
         Combo_tipscod_Tooltip = "";
         Combo_tipscod_Selectedvalue_set = "";
         Combo_tipscod_Selectedtext_set = "";
         Combo_tipscod_Selectedtext_get = "";
         Combo_tipscod_Gamoauthtoken = "";
         Combo_tipscod_Ddointernalname = "";
         Combo_tipscod_Titlecontrolalign = "";
         Combo_tipscod_Dropdownoptionstype = "";
         Combo_tipscod_Titlecontrolidtoreplace = "";
         Combo_tipscod_Datalisttype = "";
         Combo_tipscod_Datalistfixedvalues = "";
         Combo_tipscod_Htmltemplate = "";
         Combo_tipscod_Multiplevaluestype = "";
         Combo_tipscod_Loadingdata = "";
         Combo_tipscod_Noresultsfound = "";
         Combo_tipscod_Emptyitemtext = "";
         Combo_tipscod_Onlyselectedvalues = "";
         Combo_tipscod_Selectalltext = "";
         Combo_tipscod_Multiplevaluesseparator = "";
         Combo_tipscod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_clidirzoncod_Objectcall = "";
         Combo_clidirzoncod_Class = "";
         Combo_clidirzoncod_Icontype = "";
         Combo_clidirzoncod_Icon = "";
         Combo_clidirzoncod_Tooltip = "";
         Combo_clidirzoncod_Selectedvalue_set = "";
         Combo_clidirzoncod_Selectedvalue_get = "";
         Combo_clidirzoncod_Selectedtext_set = "";
         Combo_clidirzoncod_Selectedtext_get = "";
         Combo_clidirzoncod_Gamoauthtoken = "";
         Combo_clidirzoncod_Ddointernalname = "";
         Combo_clidirzoncod_Titlecontrolalign = "";
         Combo_clidirzoncod_Dropdownoptionstype = "";
         Combo_clidirzoncod_Datalisttype = "";
         Combo_clidirzoncod_Datalistfixedvalues = "";
         Combo_clidirzoncod_Htmltemplate = "";
         Combo_clidirzoncod_Multiplevaluestype = "";
         Combo_clidirzoncod_Loadingdata = "";
         Combo_clidirzoncod_Noresultsfound = "";
         Combo_clidirzoncod_Emptyitemtext = "";
         Combo_clidirzoncod_Onlyselectedvalues = "";
         Combo_clidirzoncod_Selectalltext = "";
         Combo_clidirzoncod_Multiplevaluesseparator = "";
         Combo_clidirzoncod_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode11 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV21TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV26Combo_DataJson = "";
         AV24ComboSelectedValue = "";
         AV25ComboSelectedText = "";
         GXt_char2 = "";
         Z612CliFoto = "";
         Z40000CliFoto_GXI = "";
         Z602EstDsc = "";
         Z635CliVendDsc = "";
         Z603ProvDsc = "";
         Z604DisDsc = "";
         T007O9_A602EstDsc = new string[] {""} ;
         T007O16_A635CliVendDsc = new string[] {""} ;
         T007O10_A603ProvDsc = new string[] {""} ;
         T007O11_A604DisDsc = new string[] {""} ;
         T007O18_A45CliCod = new string[] {""} ;
         T007O18_n45CliCod = new bool[] {false} ;
         T007O18_A161CliDsc = new string[] {""} ;
         T007O18_A596CliDir = new string[] {""} ;
         T007O18_A629CliTel1 = new string[] {""} ;
         T007O18_A630CliTel2 = new string[] {""} ;
         T007O18_A611CliFax = new string[] {""} ;
         T007O18_A575CliCel = new string[] {""} ;
         T007O18_A609CliEma = new string[] {""} ;
         T007O18_A637CliWeb = new string[] {""} ;
         T007O18_A40000CliFoto_GXI = new string[] {""} ;
         T007O18_n40000CliFoto_GXI = new bool[] {false} ;
         T007O18_A627CliSts = new short[1] ;
         T007O18_A613CliLim = new decimal[1] ;
         T007O18_A635CliVendDsc = new string[] {""} ;
         T007O18_A618CliRef1 = new string[] {""} ;
         T007O18_A619CliRef2 = new string[] {""} ;
         T007O18_A620CliRef3 = new string[] {""} ;
         T007O18_A621CliRef4 = new string[] {""} ;
         T007O18_A622CliRef5 = new string[] {""} ;
         T007O18_A623CliRef6 = new string[] {""} ;
         T007O18_A624CliRef7 = new string[] {""} ;
         T007O18_A625CliRef8 = new string[] {""} ;
         T007O18_A581CliCont1 = new string[] {""} ;
         T007O18_A587CliCTel1 = new string[] {""} ;
         T007O18_A582CliCont2 = new string[] {""} ;
         T007O18_A588CliCTel2 = new string[] {""} ;
         T007O18_A583CliCont3 = new string[] {""} ;
         T007O18_A589CliCtel3 = new string[] {""} ;
         T007O18_A584CliCont4 = new string[] {""} ;
         T007O18_A590CliCTel4 = new string[] {""} ;
         T007O18_A585CliCont5 = new string[] {""} ;
         T007O18_A591CliCtel5 = new string[] {""} ;
         T007O18_A632CliTItemDir = new int[1] ;
         T007O18_A614CliMon = new int[1] ;
         T007O18_A636CliVincula = new short[1] ;
         T007O18_A626CliRetencion = new short[1] ;
         T007O18_A617CliPercepcion = new short[1] ;
         T007O18_A615CliNom = new string[] {""} ;
         T007O18_A574CliAPEP = new string[] {""} ;
         T007O18_A573CliAPEM = new string[] {""} ;
         T007O18_A633CliUsuCod = new string[] {""} ;
         T007O18_A634CliUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007O18_A610CliEMAPer = new string[] {""} ;
         T007O18_A616CliPassPer = new string[] {""} ;
         T007O18_A628CliTCon = new int[1] ;
         T007O18_A631CliTipCod = new string[] {""} ;
         T007O18_A608CliDTAval = new int[1] ;
         T007O18_A602EstDsc = new string[] {""} ;
         T007O18_A603ProvDsc = new string[] {""} ;
         T007O18_A604DisDsc = new string[] {""} ;
         T007O18_A139PaiCod = new string[] {""} ;
         T007O18_A140EstCod = new string[] {""} ;
         T007O18_A141ProvCod = new string[] {""} ;
         T007O18_A142DisCod = new string[] {""} ;
         T007O18_A159TipCCod = new int[1] ;
         T007O18_A137Conpcod = new int[1] ;
         T007O18_A158ZonCod = new int[1] ;
         T007O18_n158ZonCod = new bool[] {false} ;
         T007O18_A157TipSCod = new int[1] ;
         T007O18_A160CliVend = new int[1] ;
         T007O18_A156CliTipLCod = new int[1] ;
         T007O18_n156CliTipLCod = new bool[] {false} ;
         T007O18_A612CliFoto = new string[] {""} ;
         T007O18_n612CliFoto = new bool[] {false} ;
         T007O12_A159TipCCod = new int[1] ;
         T007O13_A137Conpcod = new int[1] ;
         T007O14_A158ZonCod = new int[1] ;
         T007O14_n158ZonCod = new bool[] {false} ;
         T007O17_A156CliTipLCod = new int[1] ;
         T007O17_n156CliTipLCod = new bool[] {false} ;
         T007O15_A157TipSCod = new int[1] ;
         T007O19_A602EstDsc = new string[] {""} ;
         T007O20_A603ProvDsc = new string[] {""} ;
         T007O21_A604DisDsc = new string[] {""} ;
         T007O22_A159TipCCod = new int[1] ;
         T007O23_A137Conpcod = new int[1] ;
         T007O24_A635CliVendDsc = new string[] {""} ;
         T007O25_A158ZonCod = new int[1] ;
         T007O25_n158ZonCod = new bool[] {false} ;
         T007O26_A156CliTipLCod = new int[1] ;
         T007O26_n156CliTipLCod = new bool[] {false} ;
         T007O27_A157TipSCod = new int[1] ;
         T007O28_A45CliCod = new string[] {""} ;
         T007O28_n45CliCod = new bool[] {false} ;
         T007O8_A45CliCod = new string[] {""} ;
         T007O8_n45CliCod = new bool[] {false} ;
         T007O8_A161CliDsc = new string[] {""} ;
         T007O8_A596CliDir = new string[] {""} ;
         T007O8_A629CliTel1 = new string[] {""} ;
         T007O8_A630CliTel2 = new string[] {""} ;
         T007O8_A611CliFax = new string[] {""} ;
         T007O8_A575CliCel = new string[] {""} ;
         T007O8_A609CliEma = new string[] {""} ;
         T007O8_A637CliWeb = new string[] {""} ;
         T007O8_A40000CliFoto_GXI = new string[] {""} ;
         T007O8_n40000CliFoto_GXI = new bool[] {false} ;
         T007O8_A627CliSts = new short[1] ;
         T007O8_A613CliLim = new decimal[1] ;
         T007O8_A618CliRef1 = new string[] {""} ;
         T007O8_A619CliRef2 = new string[] {""} ;
         T007O8_A620CliRef3 = new string[] {""} ;
         T007O8_A621CliRef4 = new string[] {""} ;
         T007O8_A622CliRef5 = new string[] {""} ;
         T007O8_A623CliRef6 = new string[] {""} ;
         T007O8_A624CliRef7 = new string[] {""} ;
         T007O8_A625CliRef8 = new string[] {""} ;
         T007O8_A581CliCont1 = new string[] {""} ;
         T007O8_A587CliCTel1 = new string[] {""} ;
         T007O8_A582CliCont2 = new string[] {""} ;
         T007O8_A588CliCTel2 = new string[] {""} ;
         T007O8_A583CliCont3 = new string[] {""} ;
         T007O8_A589CliCtel3 = new string[] {""} ;
         T007O8_A584CliCont4 = new string[] {""} ;
         T007O8_A590CliCTel4 = new string[] {""} ;
         T007O8_A585CliCont5 = new string[] {""} ;
         T007O8_A591CliCtel5 = new string[] {""} ;
         T007O8_A632CliTItemDir = new int[1] ;
         T007O8_A614CliMon = new int[1] ;
         T007O8_A636CliVincula = new short[1] ;
         T007O8_A626CliRetencion = new short[1] ;
         T007O8_A617CliPercepcion = new short[1] ;
         T007O8_A615CliNom = new string[] {""} ;
         T007O8_A574CliAPEP = new string[] {""} ;
         T007O8_A573CliAPEM = new string[] {""} ;
         T007O8_A633CliUsuCod = new string[] {""} ;
         T007O8_A634CliUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007O8_A610CliEMAPer = new string[] {""} ;
         T007O8_A616CliPassPer = new string[] {""} ;
         T007O8_A628CliTCon = new int[1] ;
         T007O8_A631CliTipCod = new string[] {""} ;
         T007O8_A608CliDTAval = new int[1] ;
         T007O8_A139PaiCod = new string[] {""} ;
         T007O8_A140EstCod = new string[] {""} ;
         T007O8_A141ProvCod = new string[] {""} ;
         T007O8_A142DisCod = new string[] {""} ;
         T007O8_A159TipCCod = new int[1] ;
         T007O8_A137Conpcod = new int[1] ;
         T007O8_A158ZonCod = new int[1] ;
         T007O8_n158ZonCod = new bool[] {false} ;
         T007O8_A157TipSCod = new int[1] ;
         T007O8_A160CliVend = new int[1] ;
         T007O8_A156CliTipLCod = new int[1] ;
         T007O8_n156CliTipLCod = new bool[] {false} ;
         T007O8_A612CliFoto = new string[] {""} ;
         T007O8_n612CliFoto = new bool[] {false} ;
         T007O29_A45CliCod = new string[] {""} ;
         T007O29_n45CliCod = new bool[] {false} ;
         T007O30_A45CliCod = new string[] {""} ;
         T007O30_n45CliCod = new bool[] {false} ;
         T007O7_A45CliCod = new string[] {""} ;
         T007O7_n45CliCod = new bool[] {false} ;
         T007O7_A161CliDsc = new string[] {""} ;
         T007O7_A596CliDir = new string[] {""} ;
         T007O7_A629CliTel1 = new string[] {""} ;
         T007O7_A630CliTel2 = new string[] {""} ;
         T007O7_A611CliFax = new string[] {""} ;
         T007O7_A575CliCel = new string[] {""} ;
         T007O7_A609CliEma = new string[] {""} ;
         T007O7_A637CliWeb = new string[] {""} ;
         T007O7_A40000CliFoto_GXI = new string[] {""} ;
         T007O7_n40000CliFoto_GXI = new bool[] {false} ;
         T007O7_A627CliSts = new short[1] ;
         T007O7_A613CliLim = new decimal[1] ;
         T007O7_A618CliRef1 = new string[] {""} ;
         T007O7_A619CliRef2 = new string[] {""} ;
         T007O7_A620CliRef3 = new string[] {""} ;
         T007O7_A621CliRef4 = new string[] {""} ;
         T007O7_A622CliRef5 = new string[] {""} ;
         T007O7_A623CliRef6 = new string[] {""} ;
         T007O7_A624CliRef7 = new string[] {""} ;
         T007O7_A625CliRef8 = new string[] {""} ;
         T007O7_A581CliCont1 = new string[] {""} ;
         T007O7_A587CliCTel1 = new string[] {""} ;
         T007O7_A582CliCont2 = new string[] {""} ;
         T007O7_A588CliCTel2 = new string[] {""} ;
         T007O7_A583CliCont3 = new string[] {""} ;
         T007O7_A589CliCtel3 = new string[] {""} ;
         T007O7_A584CliCont4 = new string[] {""} ;
         T007O7_A590CliCTel4 = new string[] {""} ;
         T007O7_A585CliCont5 = new string[] {""} ;
         T007O7_A591CliCtel5 = new string[] {""} ;
         T007O7_A632CliTItemDir = new int[1] ;
         T007O7_A614CliMon = new int[1] ;
         T007O7_A636CliVincula = new short[1] ;
         T007O7_A626CliRetencion = new short[1] ;
         T007O7_A617CliPercepcion = new short[1] ;
         T007O7_A615CliNom = new string[] {""} ;
         T007O7_A574CliAPEP = new string[] {""} ;
         T007O7_A573CliAPEM = new string[] {""} ;
         T007O7_A633CliUsuCod = new string[] {""} ;
         T007O7_A634CliUsuFec = new DateTime[] {DateTime.MinValue} ;
         T007O7_A610CliEMAPer = new string[] {""} ;
         T007O7_A616CliPassPer = new string[] {""} ;
         T007O7_A628CliTCon = new int[1] ;
         T007O7_A631CliTipCod = new string[] {""} ;
         T007O7_A608CliDTAval = new int[1] ;
         T007O7_A139PaiCod = new string[] {""} ;
         T007O7_A140EstCod = new string[] {""} ;
         T007O7_A141ProvCod = new string[] {""} ;
         T007O7_A142DisCod = new string[] {""} ;
         T007O7_A159TipCCod = new int[1] ;
         T007O7_A137Conpcod = new int[1] ;
         T007O7_A158ZonCod = new int[1] ;
         T007O7_n158ZonCod = new bool[] {false} ;
         T007O7_A157TipSCod = new int[1] ;
         T007O7_A160CliVend = new int[1] ;
         T007O7_A156CliTipLCod = new int[1] ;
         T007O7_n156CliTipLCod = new bool[] {false} ;
         T007O7_A612CliFoto = new string[] {""} ;
         T007O7_n612CliFoto = new bool[] {false} ;
         T007O35_A602EstDsc = new string[] {""} ;
         T007O36_A635CliVendDsc = new string[] {""} ;
         T007O37_A603ProvDsc = new string[] {""} ;
         T007O38_A604DisDsc = new string[] {""} ;
         T007O39_A149TipCod = new string[] {""} ;
         T007O39_A24DocNum = new string[] {""} ;
         T007O40_A224LotCliCod = new string[] {""} ;
         T007O41_A218PerCod = new string[] {""} ;
         T007O41_A219PerTip = new string[] {""} ;
         T007O41_A220PerTDoc = new string[] {""} ;
         T007O42_A204LetCLetCod = new string[] {""} ;
         T007O43_A191ImpItem = new long[1] ;
         T007O44_A184CCTipCod = new string[] {""} ;
         T007O44_A185CCDocNum = new string[] {""} ;
         T007O45_A150CLCheqDCod = new string[] {""} ;
         T007O46_A144CLAntTipCod = new string[] {""} ;
         T007O46_A145CLAntDocNum = new string[] {""} ;
         T007O47_A210PedCod = new string[] {""} ;
         T007O48_A202TipLCod = new int[1] ;
         T007O48_A203TipLItem = new int[1] ;
         T007O49_A177CotCod = new string[] {""} ;
         T007O50_A44PlaCod = new string[] {""} ;
         T007O51_A13MvATip = new string[] {""} ;
         T007O51_A14MvACod = new string[] {""} ;
         T007O52_A45CliCod = new string[] {""} ;
         T007O52_n45CliCod = new bool[] {false} ;
         T007O52_A162CliDAval = new int[1] ;
         T007O53_A37ListItem = new int[1] ;
         T007O54_A26AGMVATip = new string[] {""} ;
         T007O54_A27AGMVACod = new string[] {""} ;
         T007O54_A28ProdCod = new string[] {""} ;
         T007O55_A13MvATip = new string[] {""} ;
         T007O55_A14MvACod = new string[] {""} ;
         T007O56_A13MvATip = new string[] {""} ;
         T007O56_A14MvACod = new string[] {""} ;
         T007O57_A45CliCod = new string[] {""} ;
         T007O57_n45CliCod = new bool[] {false} ;
         Z607CliDirZonDsc = "";
         T007O58_A45CliCod = new string[] {""} ;
         T007O58_n45CliCod = new bool[] {false} ;
         T007O58_A164CliDirItem = new int[1] ;
         T007O58_A600CliDirDsc = new string[] {""} ;
         T007O58_A598CliDirDir = new string[] {""} ;
         T007O58_A605CliDirPais = new string[] {""} ;
         T007O58_A597CliDirDep = new string[] {""} ;
         T007O58_A606CliDirProv = new string[] {""} ;
         T007O58_A599CliDirDis = new string[] {""} ;
         T007O58_A607CliDirZonDsc = new string[] {""} ;
         T007O58_A165CliDirZonCod = new int[1] ;
         T007O6_A607CliDirZonDsc = new string[] {""} ;
         T007O59_A607CliDirZonDsc = new string[] {""} ;
         T007O60_A45CliCod = new string[] {""} ;
         T007O60_n45CliCod = new bool[] {false} ;
         T007O60_A164CliDirItem = new int[1] ;
         T007O5_A45CliCod = new string[] {""} ;
         T007O5_n45CliCod = new bool[] {false} ;
         T007O5_A164CliDirItem = new int[1] ;
         T007O5_A600CliDirDsc = new string[] {""} ;
         T007O5_A598CliDirDir = new string[] {""} ;
         T007O5_A605CliDirPais = new string[] {""} ;
         T007O5_A597CliDirDep = new string[] {""} ;
         T007O5_A606CliDirProv = new string[] {""} ;
         T007O5_A599CliDirDis = new string[] {""} ;
         T007O5_A165CliDirZonCod = new int[1] ;
         T007O4_A45CliCod = new string[] {""} ;
         T007O4_n45CliCod = new bool[] {false} ;
         T007O4_A164CliDirItem = new int[1] ;
         T007O4_A600CliDirDsc = new string[] {""} ;
         T007O4_A598CliDirDir = new string[] {""} ;
         T007O4_A605CliDirPais = new string[] {""} ;
         T007O4_A597CliDirDep = new string[] {""} ;
         T007O4_A606CliDirProv = new string[] {""} ;
         T007O4_A599CliDirDis = new string[] {""} ;
         T007O4_A165CliDirZonCod = new int[1] ;
         T007O64_A607CliDirZonDsc = new string[] {""} ;
         T007O65_A13MvATip = new string[] {""} ;
         T007O65_A14MvACod = new string[] {""} ;
         T007O66_A13MvATip = new string[] {""} ;
         T007O66_A14MvACod = new string[] {""} ;
         T007O67_A45CliCod = new string[] {""} ;
         T007O67_n45CliCod = new bool[] {false} ;
         T007O67_A164CliDirItem = new int[1] ;
         T007O68_A45CliCod = new string[] {""} ;
         T007O68_n45CliCod = new bool[] {false} ;
         T007O68_A163CliConCod = new int[1] ;
         T007O68_A578CliConDsc = new string[] {""} ;
         T007O68_A577CliConCargo = new string[] {""} ;
         T007O68_A586CliConTelf = new string[] {""} ;
         T007O68_A576CliConArea = new string[] {""} ;
         T007O68_A579CliConMail = new string[] {""} ;
         T007O68_A580CliConMailFE = new short[1] ;
         T007O69_A45CliCod = new string[] {""} ;
         T007O69_n45CliCod = new bool[] {false} ;
         T007O69_A163CliConCod = new int[1] ;
         T007O3_A45CliCod = new string[] {""} ;
         T007O3_n45CliCod = new bool[] {false} ;
         T007O3_A163CliConCod = new int[1] ;
         T007O3_A578CliConDsc = new string[] {""} ;
         T007O3_A577CliConCargo = new string[] {""} ;
         T007O3_A586CliConTelf = new string[] {""} ;
         T007O3_A576CliConArea = new string[] {""} ;
         T007O3_A579CliConMail = new string[] {""} ;
         T007O3_A580CliConMailFE = new short[1] ;
         T007O2_A45CliCod = new string[] {""} ;
         T007O2_n45CliCod = new bool[] {false} ;
         T007O2_A163CliConCod = new int[1] ;
         T007O2_A578CliConDsc = new string[] {""} ;
         T007O2_A577CliConCargo = new string[] {""} ;
         T007O2_A586CliConTelf = new string[] {""} ;
         T007O2_A576CliConArea = new string[] {""} ;
         T007O2_A579CliConMail = new string[] {""} ;
         T007O2_A580CliConMailFE = new short[1] ;
         T007O73_A45CliCod = new string[] {""} ;
         T007O73_n45CliCod = new bool[] {false} ;
         T007O73_A163CliConCod = new int[1] ;
         Gridlevel_level1Row = new GXWebRow();
         subGridlevel_level1_Linesclass = "";
         ROClassString = "";
         Gridlevel_level2Row = new GXWebRow();
         subGridlevel_level2_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         T007O74_A159TipCCod = new int[1] ;
         T007O75_A137Conpcod = new int[1] ;
         Z601CliDireccionLarga = "";
         T007O76_A158ZonCod = new int[1] ;
         T007O76_n158ZonCod = new bool[] {false} ;
         T007O77_A156CliTipLCod = new int[1] ;
         T007O77_n156CliTipLCod = new bool[] {false} ;
         T007O78_A157TipSCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ventas.clientes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.clientes__default(),
            new Object[][] {
                new Object[] {
               T007O2_A45CliCod, T007O2_A163CliConCod, T007O2_A578CliConDsc, T007O2_A577CliConCargo, T007O2_A586CliConTelf, T007O2_A576CliConArea, T007O2_A579CliConMail, T007O2_A580CliConMailFE
               }
               , new Object[] {
               T007O3_A45CliCod, T007O3_A163CliConCod, T007O3_A578CliConDsc, T007O3_A577CliConCargo, T007O3_A586CliConTelf, T007O3_A576CliConArea, T007O3_A579CliConMail, T007O3_A580CliConMailFE
               }
               , new Object[] {
               T007O4_A45CliCod, T007O4_A164CliDirItem, T007O4_A600CliDirDsc, T007O4_A598CliDirDir, T007O4_A605CliDirPais, T007O4_A597CliDirDep, T007O4_A606CliDirProv, T007O4_A599CliDirDis, T007O4_A165CliDirZonCod
               }
               , new Object[] {
               T007O5_A45CliCod, T007O5_A164CliDirItem, T007O5_A600CliDirDsc, T007O5_A598CliDirDir, T007O5_A605CliDirPais, T007O5_A597CliDirDep, T007O5_A606CliDirProv, T007O5_A599CliDirDis, T007O5_A165CliDirZonCod
               }
               , new Object[] {
               T007O6_A607CliDirZonDsc
               }
               , new Object[] {
               T007O7_A45CliCod, T007O7_A161CliDsc, T007O7_A596CliDir, T007O7_A629CliTel1, T007O7_A630CliTel2, T007O7_A611CliFax, T007O7_A575CliCel, T007O7_A609CliEma, T007O7_A637CliWeb, T007O7_A40000CliFoto_GXI,
               T007O7_n40000CliFoto_GXI, T007O7_A627CliSts, T007O7_A613CliLim, T007O7_A618CliRef1, T007O7_A619CliRef2, T007O7_A620CliRef3, T007O7_A621CliRef4, T007O7_A622CliRef5, T007O7_A623CliRef6, T007O7_A624CliRef7,
               T007O7_A625CliRef8, T007O7_A581CliCont1, T007O7_A587CliCTel1, T007O7_A582CliCont2, T007O7_A588CliCTel2, T007O7_A583CliCont3, T007O7_A589CliCtel3, T007O7_A584CliCont4, T007O7_A590CliCTel4, T007O7_A585CliCont5,
               T007O7_A591CliCtel5, T007O7_A632CliTItemDir, T007O7_A614CliMon, T007O7_A636CliVincula, T007O7_A626CliRetencion, T007O7_A617CliPercepcion, T007O7_A615CliNom, T007O7_A574CliAPEP, T007O7_A573CliAPEM, T007O7_A633CliUsuCod,
               T007O7_A634CliUsuFec, T007O7_A610CliEMAPer, T007O7_A616CliPassPer, T007O7_A628CliTCon, T007O7_A631CliTipCod, T007O7_A608CliDTAval, T007O7_A139PaiCod, T007O7_A140EstCod, T007O7_A141ProvCod, T007O7_A142DisCod,
               T007O7_A159TipCCod, T007O7_A137Conpcod, T007O7_A158ZonCod, T007O7_n158ZonCod, T007O7_A157TipSCod, T007O7_A160CliVend, T007O7_A156CliTipLCod, T007O7_n156CliTipLCod, T007O7_A612CliFoto, T007O7_n612CliFoto
               }
               , new Object[] {
               T007O8_A45CliCod, T007O8_A161CliDsc, T007O8_A596CliDir, T007O8_A629CliTel1, T007O8_A630CliTel2, T007O8_A611CliFax, T007O8_A575CliCel, T007O8_A609CliEma, T007O8_A637CliWeb, T007O8_A40000CliFoto_GXI,
               T007O8_n40000CliFoto_GXI, T007O8_A627CliSts, T007O8_A613CliLim, T007O8_A618CliRef1, T007O8_A619CliRef2, T007O8_A620CliRef3, T007O8_A621CliRef4, T007O8_A622CliRef5, T007O8_A623CliRef6, T007O8_A624CliRef7,
               T007O8_A625CliRef8, T007O8_A581CliCont1, T007O8_A587CliCTel1, T007O8_A582CliCont2, T007O8_A588CliCTel2, T007O8_A583CliCont3, T007O8_A589CliCtel3, T007O8_A584CliCont4, T007O8_A590CliCTel4, T007O8_A585CliCont5,
               T007O8_A591CliCtel5, T007O8_A632CliTItemDir, T007O8_A614CliMon, T007O8_A636CliVincula, T007O8_A626CliRetencion, T007O8_A617CliPercepcion, T007O8_A615CliNom, T007O8_A574CliAPEP, T007O8_A573CliAPEM, T007O8_A633CliUsuCod,
               T007O8_A634CliUsuFec, T007O8_A610CliEMAPer, T007O8_A616CliPassPer, T007O8_A628CliTCon, T007O8_A631CliTipCod, T007O8_A608CliDTAval, T007O8_A139PaiCod, T007O8_A140EstCod, T007O8_A141ProvCod, T007O8_A142DisCod,
               T007O8_A159TipCCod, T007O8_A137Conpcod, T007O8_A158ZonCod, T007O8_n158ZonCod, T007O8_A157TipSCod, T007O8_A160CliVend, T007O8_A156CliTipLCod, T007O8_n156CliTipLCod, T007O8_A612CliFoto, T007O8_n612CliFoto
               }
               , new Object[] {
               T007O9_A602EstDsc
               }
               , new Object[] {
               T007O10_A603ProvDsc
               }
               , new Object[] {
               T007O11_A604DisDsc
               }
               , new Object[] {
               T007O12_A159TipCCod
               }
               , new Object[] {
               T007O13_A137Conpcod
               }
               , new Object[] {
               T007O14_A158ZonCod
               }
               , new Object[] {
               T007O15_A157TipSCod
               }
               , new Object[] {
               T007O16_A635CliVendDsc
               }
               , new Object[] {
               T007O17_A156CliTipLCod
               }
               , new Object[] {
               T007O18_A45CliCod, T007O18_A161CliDsc, T007O18_A596CliDir, T007O18_A629CliTel1, T007O18_A630CliTel2, T007O18_A611CliFax, T007O18_A575CliCel, T007O18_A609CliEma, T007O18_A637CliWeb, T007O18_A40000CliFoto_GXI,
               T007O18_n40000CliFoto_GXI, T007O18_A627CliSts, T007O18_A613CliLim, T007O18_A635CliVendDsc, T007O18_A618CliRef1, T007O18_A619CliRef2, T007O18_A620CliRef3, T007O18_A621CliRef4, T007O18_A622CliRef5, T007O18_A623CliRef6,
               T007O18_A624CliRef7, T007O18_A625CliRef8, T007O18_A581CliCont1, T007O18_A587CliCTel1, T007O18_A582CliCont2, T007O18_A588CliCTel2, T007O18_A583CliCont3, T007O18_A589CliCtel3, T007O18_A584CliCont4, T007O18_A590CliCTel4,
               T007O18_A585CliCont5, T007O18_A591CliCtel5, T007O18_A632CliTItemDir, T007O18_A614CliMon, T007O18_A636CliVincula, T007O18_A626CliRetencion, T007O18_A617CliPercepcion, T007O18_A615CliNom, T007O18_A574CliAPEP, T007O18_A573CliAPEM,
               T007O18_A633CliUsuCod, T007O18_A634CliUsuFec, T007O18_A610CliEMAPer, T007O18_A616CliPassPer, T007O18_A628CliTCon, T007O18_A631CliTipCod, T007O18_A608CliDTAval, T007O18_A602EstDsc, T007O18_A603ProvDsc, T007O18_A604DisDsc,
               T007O18_A139PaiCod, T007O18_A140EstCod, T007O18_A141ProvCod, T007O18_A142DisCod, T007O18_A159TipCCod, T007O18_A137Conpcod, T007O18_A158ZonCod, T007O18_n158ZonCod, T007O18_A157TipSCod, T007O18_A160CliVend,
               T007O18_A156CliTipLCod, T007O18_n156CliTipLCod, T007O18_A612CliFoto, T007O18_n612CliFoto
               }
               , new Object[] {
               T007O19_A602EstDsc
               }
               , new Object[] {
               T007O20_A603ProvDsc
               }
               , new Object[] {
               T007O21_A604DisDsc
               }
               , new Object[] {
               T007O22_A159TipCCod
               }
               , new Object[] {
               T007O23_A137Conpcod
               }
               , new Object[] {
               T007O24_A635CliVendDsc
               }
               , new Object[] {
               T007O25_A158ZonCod
               }
               , new Object[] {
               T007O26_A156CliTipLCod
               }
               , new Object[] {
               T007O27_A157TipSCod
               }
               , new Object[] {
               T007O28_A45CliCod
               }
               , new Object[] {
               T007O29_A45CliCod
               }
               , new Object[] {
               T007O30_A45CliCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007O35_A602EstDsc
               }
               , new Object[] {
               T007O36_A635CliVendDsc
               }
               , new Object[] {
               T007O37_A603ProvDsc
               }
               , new Object[] {
               T007O38_A604DisDsc
               }
               , new Object[] {
               T007O39_A149TipCod, T007O39_A24DocNum
               }
               , new Object[] {
               T007O40_A224LotCliCod
               }
               , new Object[] {
               T007O41_A218PerCod, T007O41_A219PerTip, T007O41_A220PerTDoc
               }
               , new Object[] {
               T007O42_A204LetCLetCod
               }
               , new Object[] {
               T007O43_A191ImpItem
               }
               , new Object[] {
               T007O44_A184CCTipCod, T007O44_A185CCDocNum
               }
               , new Object[] {
               T007O45_A150CLCheqDCod
               }
               , new Object[] {
               T007O46_A144CLAntTipCod, T007O46_A145CLAntDocNum
               }
               , new Object[] {
               T007O47_A210PedCod
               }
               , new Object[] {
               T007O48_A202TipLCod, T007O48_A203TipLItem
               }
               , new Object[] {
               T007O49_A177CotCod
               }
               , new Object[] {
               T007O50_A44PlaCod
               }
               , new Object[] {
               T007O51_A13MvATip, T007O51_A14MvACod
               }
               , new Object[] {
               T007O52_A45CliCod, T007O52_A162CliDAval
               }
               , new Object[] {
               T007O53_A37ListItem
               }
               , new Object[] {
               T007O54_A26AGMVATip, T007O54_A27AGMVACod, T007O54_A28ProdCod
               }
               , new Object[] {
               T007O55_A13MvATip, T007O55_A14MvACod
               }
               , new Object[] {
               T007O56_A13MvATip, T007O56_A14MvACod
               }
               , new Object[] {
               T007O57_A45CliCod
               }
               , new Object[] {
               T007O58_A45CliCod, T007O58_A164CliDirItem, T007O58_A600CliDirDsc, T007O58_A598CliDirDir, T007O58_A605CliDirPais, T007O58_A597CliDirDep, T007O58_A606CliDirProv, T007O58_A599CliDirDis, T007O58_A607CliDirZonDsc, T007O58_A165CliDirZonCod
               }
               , new Object[] {
               T007O59_A607CliDirZonDsc
               }
               , new Object[] {
               T007O60_A45CliCod, T007O60_A164CliDirItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007O64_A607CliDirZonDsc
               }
               , new Object[] {
               T007O65_A13MvATip, T007O65_A14MvACod
               }
               , new Object[] {
               T007O66_A13MvATip, T007O66_A14MvACod
               }
               , new Object[] {
               T007O67_A45CliCod, T007O67_A164CliDirItem
               }
               , new Object[] {
               T007O68_A45CliCod, T007O68_A163CliConCod, T007O68_A578CliConDsc, T007O68_A577CliConCargo, T007O68_A586CliConTelf, T007O68_A576CliConArea, T007O68_A579CliConMail, T007O68_A580CliConMailFE
               }
               , new Object[] {
               T007O69_A45CliCod, T007O69_A163CliConCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007O73_A45CliCod, T007O73_A163CliConCod
               }
               , new Object[] {
               T007O74_A159TipCCod
               }
               , new Object[] {
               T007O75_A137Conpcod
               }
               , new Object[] {
               T007O76_A158ZonCod
               }
               , new Object[] {
               T007O77_A156CliTipLCod
               }
               , new Object[] {
               T007O78_A157TipSCod
               }
            }
         );
         AV52Pgmname = "Ventas.Clientes";
      }

      private short Z627CliSts ;
      private short Z636CliVincula ;
      private short Z626CliRetencion ;
      private short Z617CliPercepcion ;
      private short nRcdDeleted_83 ;
      private short nRcdExists_83 ;
      private short nIsMod_83 ;
      private short Z580CliConMailFE ;
      private short nRcdDeleted_13 ;
      private short nRcdExists_13 ;
      private short nIsMod_13 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A627CliSts ;
      private short A636CliVincula ;
      private short A626CliRetencion ;
      private short A617CliPercepcion ;
      private short subGridlevel_level1_Backcolorstyle ;
      private short subGridlevel_level1_Allowselection ;
      private short subGridlevel_level1_Allowhovering ;
      private short subGridlevel_level1_Allowcollapsing ;
      private short subGridlevel_level1_Collapsed ;
      private short nBlankRcdCount83 ;
      private short RcdFound83 ;
      private short nBlankRcdUsr83 ;
      private short subGridlevel_level2_Backcolorstyle ;
      private short A580CliConMailFE ;
      private short subGridlevel_level2_Allowselection ;
      private short subGridlevel_level2_Allowhovering ;
      private short subGridlevel_level2_Allowcollapsing ;
      private short subGridlevel_level2_Collapsed ;
      private short nBlankRcdCount13 ;
      private short RcdFound13 ;
      private short nBlankRcdUsr13 ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_11 ;
      private short nIsDirty_83 ;
      private short nIsDirty_13 ;
      private short subGridlevel_level1_Backstyle ;
      private short subGridlevel_level2_Backstyle ;
      private short gxajaxcallmode ;
      private int Z632CliTItemDir ;
      private int Z614CliMon ;
      private int Z628CliTCon ;
      private int Z608CliDTAval ;
      private int Z159TipCCod ;
      private int Z137Conpcod ;
      private int Z158ZonCod ;
      private int Z157TipSCod ;
      private int Z160CliVend ;
      private int Z156CliTipLCod ;
      private int nRC_GXsfl_368 ;
      private int nGXsfl_368_idx=1 ;
      private int nRC_GXsfl_383 ;
      private int nGXsfl_383_idx=1 ;
      private int N159TipCCod ;
      private int N137Conpcod ;
      private int N160CliVend ;
      private int N158ZonCod ;
      private int N156CliTipLCod ;
      private int N157TipSCod ;
      private int Z164CliDirItem ;
      private int Z165CliDirZonCod ;
      private int Z163CliConCod ;
      private int A159TipCCod ;
      private int A137Conpcod ;
      private int A160CliVend ;
      private int A158ZonCod ;
      private int A156CliTipLCod ;
      private int A157TipSCod ;
      private int A165CliDirZonCod ;
      private int trnEnded ;
      private int edtCliCod_Enabled ;
      private int edtCliDsc_Enabled ;
      private int edtCliDir_Enabled ;
      private int edtEstCod_Visible ;
      private int edtEstCod_Enabled ;
      private int edtPaiCod_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtCliTel1_Enabled ;
      private int edtCliTel2_Enabled ;
      private int edtCliFax_Enabled ;
      private int edtCliCel_Enabled ;
      private int edtCliEma_Enabled ;
      private int edtCliWeb_Enabled ;
      private int edtTipCCod_Visible ;
      private int edtTipCCod_Enabled ;
      private int imgCliFoto_Enabled ;
      private int edtCliSts_Enabled ;
      private int edtConpcod_Visible ;
      private int edtConpcod_Enabled ;
      private int edtCliLim_Enabled ;
      private int edtCliVend_Visible ;
      private int edtCliVend_Enabled ;
      private int edtCliVendDsc_Enabled ;
      private int edtCliRef1_Enabled ;
      private int edtCliRef2_Enabled ;
      private int edtCliRef3_Enabled ;
      private int edtCliRef4_Enabled ;
      private int edtCliRef5_Enabled ;
      private int edtCliRef6_Enabled ;
      private int edtCliRef7_Enabled ;
      private int edtCliRef8_Enabled ;
      private int edtCliCont1_Enabled ;
      private int edtCliCTel1_Enabled ;
      private int edtCliCont2_Enabled ;
      private int edtCliCTel2_Enabled ;
      private int edtCliCont3_Enabled ;
      private int edtCliCtel3_Enabled ;
      private int edtCliCont4_Enabled ;
      private int edtCliCTel4_Enabled ;
      private int edtCliCont5_Enabled ;
      private int edtCliCtel5_Enabled ;
      private int edtDisCod_Visible ;
      private int edtDisCod_Enabled ;
      private int edtProvCod_Visible ;
      private int edtProvCod_Enabled ;
      private int A632CliTItemDir ;
      private int edtCliTItemDir_Enabled ;
      private int edtZonCod_Visible ;
      private int edtZonCod_Enabled ;
      private int A614CliMon ;
      private int edtCliMon_Enabled ;
      private int edtCliVincula_Enabled ;
      private int edtCliRetencion_Enabled ;
      private int edtCliPercepcion_Enabled ;
      private int edtCliTipLCod_Visible ;
      private int edtCliTipLCod_Enabled ;
      private int edtCliNom_Enabled ;
      private int edtCliAPEP_Enabled ;
      private int edtCliAPEM_Enabled ;
      private int edtTipSCod_Visible ;
      private int edtTipSCod_Enabled ;
      private int edtCliUsuCod_Enabled ;
      private int edtCliUsuFec_Enabled ;
      private int edtCliEMAPer_Enabled ;
      private int edtCliPassPer_Enabled ;
      private int A628CliTCon ;
      private int edtCliTCon_Enabled ;
      private int edtCliDireccionLarga_Enabled ;
      private int edtCliTipCod_Enabled ;
      private int A608CliDTAval ;
      private int edtCliDTAval_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavComboestcod_Visible ;
      private int edtavComboestcod_Enabled ;
      private int edtavCombopaicod_Visible ;
      private int edtavCombopaicod_Enabled ;
      private int AV33ComboTipCCod ;
      private int edtavCombotipccod_Enabled ;
      private int edtavCombotipccod_Visible ;
      private int AV35ComboConpcod ;
      private int edtavComboconpcod_Enabled ;
      private int edtavComboconpcod_Visible ;
      private int AV37ComboCliVend ;
      private int edtavComboclivend_Enabled ;
      private int edtavComboclivend_Visible ;
      private int edtavCombodiscod_Visible ;
      private int edtavCombodiscod_Enabled ;
      private int edtavComboprovcod_Visible ;
      private int edtavComboprovcod_Enabled ;
      private int AV46ComboZonCod ;
      private int edtavCombozoncod_Enabled ;
      private int edtavCombozoncod_Visible ;
      private int AV48ComboCliTipLCod ;
      private int edtavComboclitiplcod_Enabled ;
      private int edtavComboclitiplcod_Visible ;
      private int AV51ComboTipSCod ;
      private int edtavCombotipscod_Enabled ;
      private int edtavCombotipscod_Visible ;
      private int A164CliDirItem ;
      private int edtCliDirItem_Enabled ;
      private int edtCliDirDsc_Enabled ;
      private int edtCliDirDir_Enabled ;
      private int edtCliDirPais_Enabled ;
      private int edtCliDirDep_Enabled ;
      private int edtCliDirProv_Enabled ;
      private int edtCliDirDis_Enabled ;
      private int edtCliDirZonCod_Enabled ;
      private int edtCliDirZonDsc_Enabled ;
      private int subGridlevel_level1_Selectedindex ;
      private int subGridlevel_level1_Selectioncolor ;
      private int subGridlevel_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int A163CliConCod ;
      private int edtCliConCod_Enabled ;
      private int edtCliConDsc_Enabled ;
      private int edtCliConCargo_Enabled ;
      private int edtCliConTelf_Enabled ;
      private int edtCliConArea_Enabled ;
      private int edtCliConMail_Enabled ;
      private int edtCliConMailFE_Enabled ;
      private int subGridlevel_level2_Selectedindex ;
      private int subGridlevel_level2_Selectioncolor ;
      private int subGridlevel_level2_Hoveringcolor ;
      private int AV13Insert_TipCCod ;
      private int AV14Insert_Conpcod ;
      private int AV15Insert_CliVend ;
      private int AV18Insert_ZonCod ;
      private int AV19Insert_CliTipLCod ;
      private int AV20Insert_TipSCod ;
      private int Combo_estcod_Datalistupdateminimumcharacters ;
      private int Combo_estcod_Gxcontroltype ;
      private int Combo_paicod_Datalistupdateminimumcharacters ;
      private int Combo_paicod_Gxcontroltype ;
      private int Combo_tipccod_Datalistupdateminimumcharacters ;
      private int Combo_tipccod_Gxcontroltype ;
      private int Combo_conpcod_Datalistupdateminimumcharacters ;
      private int Combo_conpcod_Gxcontroltype ;
      private int Combo_clivend_Datalistupdateminimumcharacters ;
      private int Combo_clivend_Gxcontroltype ;
      private int Combo_discod_Datalistupdateminimumcharacters ;
      private int Combo_discod_Gxcontroltype ;
      private int Combo_provcod_Datalistupdateminimumcharacters ;
      private int Combo_provcod_Gxcontroltype ;
      private int Combo_zoncod_Datalistupdateminimumcharacters ;
      private int Combo_zoncod_Gxcontroltype ;
      private int Combo_clitiplcod_Datalistupdateminimumcharacters ;
      private int Combo_clitiplcod_Gxcontroltype ;
      private int Combo_tipscod_Datalistupdateminimumcharacters ;
      private int Combo_tipscod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_clidirzoncod_Datalistupdateminimumcharacters ;
      private int Combo_clidirzoncod_Gxcontroltype ;
      private int AV53GXV1 ;
      private int subGridlevel_level1_Backcolor ;
      private int subGridlevel_level1_Allbackcolor ;
      private int subGridlevel_level2_Backcolor ;
      private int subGridlevel_level2_Allbackcolor ;
      private int defedtCliConCod_Enabled ;
      private int defedtCliDirItem_Enabled ;
      private int idxLst ;
      private long GRIDLEVEL_LEVEL1_nFirstRecordOnPage ;
      private long GRIDLEVEL_LEVEL2_nFirstRecordOnPage ;
      private decimal Z613CliLim ;
      private decimal A613CliLim ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7CliCod ;
      private string Z45CliCod ;
      private string Z161CliDsc ;
      private string Z596CliDir ;
      private string Z629CliTel1 ;
      private string Z630CliTel2 ;
      private string Z611CliFax ;
      private string Z575CliCel ;
      private string Z637CliWeb ;
      private string Z618CliRef1 ;
      private string Z619CliRef2 ;
      private string Z620CliRef3 ;
      private string Z621CliRef4 ;
      private string Z622CliRef5 ;
      private string Z623CliRef6 ;
      private string Z624CliRef7 ;
      private string Z625CliRef8 ;
      private string Z581CliCont1 ;
      private string Z587CliCTel1 ;
      private string Z582CliCont2 ;
      private string Z588CliCTel2 ;
      private string Z583CliCont3 ;
      private string Z589CliCtel3 ;
      private string Z584CliCont4 ;
      private string Z590CliCTel4 ;
      private string Z585CliCont5 ;
      private string Z591CliCtel5 ;
      private string Z633CliUsuCod ;
      private string Z631CliTipCod ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z142DisCod ;
      private string N140EstCod ;
      private string N139PaiCod ;
      private string N142DisCod ;
      private string N141ProvCod ;
      private string Combo_tipscod_Selectedvalue_get ;
      private string Combo_clitiplcod_Selectedvalue_get ;
      private string Combo_zoncod_Selectedvalue_get ;
      private string Combo_provcod_Selectedvalue_get ;
      private string Combo_discod_Selectedvalue_get ;
      private string Combo_clivend_Selectedvalue_get ;
      private string Combo_conpcod_Selectedvalue_get ;
      private string Combo_tipccod_Selectedvalue_get ;
      private string Combo_paicod_Selectedvalue_get ;
      private string Combo_estcod_Selectedvalue_get ;
      private string Z600CliDirDsc ;
      private string Z598CliDirDir ;
      private string Z605CliDirPais ;
      private string Z597CliDirDep ;
      private string Z606CliDirProv ;
      private string Z599CliDirDis ;
      private string Z578CliConDsc ;
      private string Z577CliConCargo ;
      private string Z586CliConTelf ;
      private string Z576CliConArea ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string sGXsfl_368_idx="0001" ;
      private string edtCliDirZonCod_Horizontalalignment ;
      private string edtCliDirZonCod_Internalname ;
      private string Gx_mode ;
      private string sGXsfl_383_idx="0001" ;
      private string GXKey ;
      private string GXDecQS ;
      private string AV7CliCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCliCod_Internalname ;
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
      private string A45CliCod ;
      private string edtCliCod_Jsonclick ;
      private string edtCliDsc_Internalname ;
      private string A161CliDsc ;
      private string edtCliDsc_Jsonclick ;
      private string edtCliDir_Internalname ;
      private string A596CliDir ;
      private string edtCliDir_Jsonclick ;
      private string divTablesplittedestcod_Internalname ;
      private string lblTextblockestcod_Internalname ;
      private string lblTextblockestcod_Jsonclick ;
      private string Combo_estcod_Caption ;
      private string Combo_estcod_Cls ;
      private string Combo_estcod_Datalistproc ;
      private string Combo_estcod_Internalname ;
      private string edtEstCod_Internalname ;
      private string edtEstCod_Jsonclick ;
      private string divTablesplittedpaicod_Internalname ;
      private string lblTextblockpaicod_Internalname ;
      private string lblTextblockpaicod_Jsonclick ;
      private string Combo_paicod_Caption ;
      private string Combo_paicod_Cls ;
      private string Combo_paicod_Datalistproc ;
      private string Combo_paicod_Datalistprocparametersprefix ;
      private string Combo_paicod_Internalname ;
      private string edtPaiCod_Internalname ;
      private string edtPaiCod_Jsonclick ;
      private string edtCliTel1_Internalname ;
      private string A629CliTel1 ;
      private string edtCliTel1_Jsonclick ;
      private string edtCliTel2_Internalname ;
      private string A630CliTel2 ;
      private string edtCliTel2_Jsonclick ;
      private string edtCliFax_Internalname ;
      private string A611CliFax ;
      private string edtCliFax_Jsonclick ;
      private string edtCliCel_Internalname ;
      private string A575CliCel ;
      private string edtCliCel_Jsonclick ;
      private string edtCliEma_Internalname ;
      private string edtCliEma_Jsonclick ;
      private string edtCliWeb_Internalname ;
      private string A637CliWeb ;
      private string edtCliWeb_Jsonclick ;
      private string divTablesplittedtipccod_Internalname ;
      private string lblTextblocktipccod_Internalname ;
      private string lblTextblocktipccod_Jsonclick ;
      private string Combo_tipccod_Caption ;
      private string Combo_tipccod_Cls ;
      private string Combo_tipccod_Datalistproc ;
      private string Combo_tipccod_Datalistprocparametersprefix ;
      private string Combo_tipccod_Internalname ;
      private string edtTipCCod_Internalname ;
      private string edtTipCCod_Jsonclick ;
      private string imgCliFoto_Internalname ;
      private string sImgUrl ;
      private string edtCliSts_Internalname ;
      private string edtCliSts_Jsonclick ;
      private string divTablesplittedconpcod_Internalname ;
      private string lblTextblockconpcod_Internalname ;
      private string lblTextblockconpcod_Jsonclick ;
      private string Combo_conpcod_Caption ;
      private string Combo_conpcod_Cls ;
      private string Combo_conpcod_Datalistproc ;
      private string Combo_conpcod_Datalistprocparametersprefix ;
      private string Combo_conpcod_Internalname ;
      private string edtConpcod_Internalname ;
      private string edtConpcod_Jsonclick ;
      private string edtCliLim_Internalname ;
      private string edtCliLim_Jsonclick ;
      private string divTablesplittedclivend_Internalname ;
      private string lblTextblockclivend_Internalname ;
      private string lblTextblockclivend_Jsonclick ;
      private string Combo_clivend_Caption ;
      private string Combo_clivend_Cls ;
      private string Combo_clivend_Datalistproc ;
      private string Combo_clivend_Datalistprocparametersprefix ;
      private string Combo_clivend_Internalname ;
      private string edtCliVend_Internalname ;
      private string edtCliVend_Jsonclick ;
      private string edtCliVendDsc_Internalname ;
      private string A635CliVendDsc ;
      private string edtCliVendDsc_Jsonclick ;
      private string edtCliRef1_Internalname ;
      private string A618CliRef1 ;
      private string edtCliRef1_Jsonclick ;
      private string edtCliRef2_Internalname ;
      private string A619CliRef2 ;
      private string edtCliRef2_Jsonclick ;
      private string edtCliRef3_Internalname ;
      private string A620CliRef3 ;
      private string edtCliRef3_Jsonclick ;
      private string edtCliRef4_Internalname ;
      private string A621CliRef4 ;
      private string edtCliRef4_Jsonclick ;
      private string edtCliRef5_Internalname ;
      private string A622CliRef5 ;
      private string edtCliRef5_Jsonclick ;
      private string edtCliRef6_Internalname ;
      private string A623CliRef6 ;
      private string edtCliRef6_Jsonclick ;
      private string edtCliRef7_Internalname ;
      private string A624CliRef7 ;
      private string edtCliRef7_Jsonclick ;
      private string edtCliRef8_Internalname ;
      private string A625CliRef8 ;
      private string edtCliRef8_Jsonclick ;
      private string edtCliCont1_Internalname ;
      private string A581CliCont1 ;
      private string edtCliCont1_Jsonclick ;
      private string edtCliCTel1_Internalname ;
      private string A587CliCTel1 ;
      private string edtCliCTel1_Jsonclick ;
      private string edtCliCont2_Internalname ;
      private string A582CliCont2 ;
      private string edtCliCont2_Jsonclick ;
      private string edtCliCTel2_Internalname ;
      private string A588CliCTel2 ;
      private string edtCliCTel2_Jsonclick ;
      private string edtCliCont3_Internalname ;
      private string A583CliCont3 ;
      private string edtCliCont3_Jsonclick ;
      private string edtCliCtel3_Internalname ;
      private string A589CliCtel3 ;
      private string edtCliCtel3_Jsonclick ;
      private string edtCliCont4_Internalname ;
      private string A584CliCont4 ;
      private string edtCliCont4_Jsonclick ;
      private string edtCliCTel4_Internalname ;
      private string A590CliCTel4 ;
      private string edtCliCTel4_Jsonclick ;
      private string edtCliCont5_Internalname ;
      private string A585CliCont5 ;
      private string edtCliCont5_Jsonclick ;
      private string edtCliCtel5_Internalname ;
      private string A591CliCtel5 ;
      private string edtCliCtel5_Jsonclick ;
      private string divTablesplitteddiscod_Internalname ;
      private string lblTextblockdiscod_Internalname ;
      private string lblTextblockdiscod_Jsonclick ;
      private string Combo_discod_Caption ;
      private string Combo_discod_Cls ;
      private string Combo_discod_Datalistproc ;
      private string Combo_discod_Internalname ;
      private string edtDisCod_Internalname ;
      private string edtDisCod_Jsonclick ;
      private string divTablesplittedprovcod_Internalname ;
      private string lblTextblockprovcod_Internalname ;
      private string lblTextblockprovcod_Jsonclick ;
      private string Combo_provcod_Caption ;
      private string Combo_provcod_Cls ;
      private string Combo_provcod_Datalistproc ;
      private string Combo_provcod_Internalname ;
      private string edtProvCod_Internalname ;
      private string edtProvCod_Jsonclick ;
      private string edtCliTItemDir_Internalname ;
      private string edtCliTItemDir_Jsonclick ;
      private string divTablesplittedzoncod_Internalname ;
      private string lblTextblockzoncod_Internalname ;
      private string lblTextblockzoncod_Jsonclick ;
      private string Combo_zoncod_Caption ;
      private string Combo_zoncod_Cls ;
      private string Combo_zoncod_Datalistproc ;
      private string Combo_zoncod_Datalistprocparametersprefix ;
      private string Combo_zoncod_Internalname ;
      private string edtZonCod_Internalname ;
      private string edtZonCod_Jsonclick ;
      private string edtCliMon_Internalname ;
      private string edtCliMon_Jsonclick ;
      private string edtCliVincula_Internalname ;
      private string edtCliVincula_Jsonclick ;
      private string edtCliRetencion_Internalname ;
      private string edtCliRetencion_Jsonclick ;
      private string edtCliPercepcion_Internalname ;
      private string edtCliPercepcion_Jsonclick ;
      private string divTablesplittedclitiplcod_Internalname ;
      private string lblTextblockclitiplcod_Internalname ;
      private string lblTextblockclitiplcod_Jsonclick ;
      private string Combo_clitiplcod_Caption ;
      private string Combo_clitiplcod_Cls ;
      private string Combo_clitiplcod_Datalistproc ;
      private string Combo_clitiplcod_Datalistprocparametersprefix ;
      private string Combo_clitiplcod_Internalname ;
      private string edtCliTipLCod_Internalname ;
      private string edtCliTipLCod_Jsonclick ;
      private string edtCliNom_Internalname ;
      private string edtCliNom_Jsonclick ;
      private string edtCliAPEP_Internalname ;
      private string edtCliAPEP_Jsonclick ;
      private string edtCliAPEM_Internalname ;
      private string edtCliAPEM_Jsonclick ;
      private string divTablesplittedtipscod_Internalname ;
      private string lblTextblocktipscod_Internalname ;
      private string lblTextblocktipscod_Jsonclick ;
      private string Combo_tipscod_Caption ;
      private string Combo_tipscod_Cls ;
      private string Combo_tipscod_Datalistproc ;
      private string Combo_tipscod_Datalistprocparametersprefix ;
      private string Combo_tipscod_Internalname ;
      private string edtTipSCod_Internalname ;
      private string edtTipSCod_Jsonclick ;
      private string edtCliUsuCod_Internalname ;
      private string A633CliUsuCod ;
      private string edtCliUsuCod_Jsonclick ;
      private string edtCliUsuFec_Internalname ;
      private string edtCliUsuFec_Jsonclick ;
      private string edtCliEMAPer_Internalname ;
      private string edtCliEMAPer_Jsonclick ;
      private string edtCliPassPer_Internalname ;
      private string edtCliPassPer_Jsonclick ;
      private string edtCliTCon_Internalname ;
      private string edtCliTCon_Jsonclick ;
      private string edtCliDireccionLarga_Internalname ;
      private string edtCliTipCod_Internalname ;
      private string A631CliTipCod ;
      private string edtCliTipCod_Jsonclick ;
      private string edtCliDTAval_Internalname ;
      private string edtCliDTAval_Jsonclick ;
      private string divTableleaflevel_level1_Internalname ;
      private string divTableleaflevel_level2_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_estcod_Internalname ;
      private string edtavComboestcod_Internalname ;
      private string AV28ComboEstCod ;
      private string edtavComboestcod_Jsonclick ;
      private string divSectionattribute_paicod_Internalname ;
      private string edtavCombopaicod_Internalname ;
      private string AV31ComboPaiCod ;
      private string edtavCombopaicod_Jsonclick ;
      private string divSectionattribute_tipccod_Internalname ;
      private string edtavCombotipccod_Internalname ;
      private string edtavCombotipccod_Jsonclick ;
      private string divSectionattribute_conpcod_Internalname ;
      private string edtavComboconpcod_Internalname ;
      private string edtavComboconpcod_Jsonclick ;
      private string divSectionattribute_clivend_Internalname ;
      private string edtavComboclivend_Internalname ;
      private string edtavComboclivend_Jsonclick ;
      private string divSectionattribute_discod_Internalname ;
      private string edtavCombodiscod_Internalname ;
      private string AV40ComboDisCod ;
      private string edtavCombodiscod_Jsonclick ;
      private string divSectionattribute_provcod_Internalname ;
      private string edtavComboprovcod_Internalname ;
      private string AV44ComboProvCod ;
      private string edtavComboprovcod_Jsonclick ;
      private string divSectionattribute_zoncod_Internalname ;
      private string edtavCombozoncod_Internalname ;
      private string edtavCombozoncod_Jsonclick ;
      private string divSectionattribute_clitiplcod_Internalname ;
      private string edtavComboclitiplcod_Internalname ;
      private string edtavComboclitiplcod_Jsonclick ;
      private string divSectionattribute_tipscod_Internalname ;
      private string edtavCombotipscod_Internalname ;
      private string edtavCombotipscod_Jsonclick ;
      private string Combo_clidirzoncod_Caption ;
      private string Combo_clidirzoncod_Cls ;
      private string Combo_clidirzoncod_Datalistproc ;
      private string Combo_clidirzoncod_Datalistprocparametersprefix ;
      private string Combo_clidirzoncod_Internalname ;
      private string subGridlevel_level1_Header ;
      private string A600CliDirDsc ;
      private string A598CliDirDir ;
      private string A605CliDirPais ;
      private string A597CliDirDep ;
      private string A606CliDirProv ;
      private string A599CliDirDis ;
      private string A607CliDirZonDsc ;
      private string sMode83 ;
      private string edtCliDirItem_Internalname ;
      private string edtCliDirDsc_Internalname ;
      private string edtCliDirDir_Internalname ;
      private string edtCliDirPais_Internalname ;
      private string edtCliDirDep_Internalname ;
      private string edtCliDirProv_Internalname ;
      private string edtCliDirDis_Internalname ;
      private string edtCliDirZonDsc_Internalname ;
      private string sStyleString ;
      private string subGridlevel_level2_Header ;
      private string A578CliConDsc ;
      private string A577CliConCargo ;
      private string A586CliConTelf ;
      private string A576CliConArea ;
      private string sMode13 ;
      private string edtCliConCod_Internalname ;
      private string edtCliConDsc_Internalname ;
      private string edtCliConCargo_Internalname ;
      private string edtCliConTelf_Internalname ;
      private string edtCliConArea_Internalname ;
      private string edtCliConMail_Internalname ;
      private string edtCliConMailFE_Internalname ;
      private string AV41Cond_EstCod ;
      private string AV29Cond_PaiCod ;
      private string AV42Cond_ProvCod ;
      private string A602EstDsc ;
      private string A603ProvDsc ;
      private string A604DisDsc ;
      private string AV11Insert_EstCod ;
      private string AV12Insert_PaiCod ;
      private string AV16Insert_DisCod ;
      private string AV17Insert_ProvCod ;
      private string AV52Pgmname ;
      private string Combo_estcod_Objectcall ;
      private string Combo_estcod_Class ;
      private string Combo_estcod_Icontype ;
      private string Combo_estcod_Icon ;
      private string Combo_estcod_Tooltip ;
      private string Combo_estcod_Selectedvalue_set ;
      private string Combo_estcod_Selectedtext_set ;
      private string Combo_estcod_Selectedtext_get ;
      private string Combo_estcod_Gamoauthtoken ;
      private string Combo_estcod_Ddointernalname ;
      private string Combo_estcod_Titlecontrolalign ;
      private string Combo_estcod_Dropdownoptionstype ;
      private string Combo_estcod_Titlecontrolidtoreplace ;
      private string Combo_estcod_Datalisttype ;
      private string Combo_estcod_Datalistfixedvalues ;
      private string Combo_estcod_Datalistprocparametersprefix ;
      private string Combo_estcod_Htmltemplate ;
      private string Combo_estcod_Multiplevaluestype ;
      private string Combo_estcod_Loadingdata ;
      private string Combo_estcod_Noresultsfound ;
      private string Combo_estcod_Emptyitemtext ;
      private string Combo_estcod_Onlyselectedvalues ;
      private string Combo_estcod_Selectalltext ;
      private string Combo_estcod_Multiplevaluesseparator ;
      private string Combo_estcod_Addnewoptiontext ;
      private string Combo_paicod_Objectcall ;
      private string Combo_paicod_Class ;
      private string Combo_paicod_Icontype ;
      private string Combo_paicod_Icon ;
      private string Combo_paicod_Tooltip ;
      private string Combo_paicod_Selectedvalue_set ;
      private string Combo_paicod_Selectedtext_set ;
      private string Combo_paicod_Selectedtext_get ;
      private string Combo_paicod_Gamoauthtoken ;
      private string Combo_paicod_Ddointernalname ;
      private string Combo_paicod_Titlecontrolalign ;
      private string Combo_paicod_Dropdownoptionstype ;
      private string Combo_paicod_Titlecontrolidtoreplace ;
      private string Combo_paicod_Datalisttype ;
      private string Combo_paicod_Datalistfixedvalues ;
      private string Combo_paicod_Htmltemplate ;
      private string Combo_paicod_Multiplevaluestype ;
      private string Combo_paicod_Loadingdata ;
      private string Combo_paicod_Noresultsfound ;
      private string Combo_paicod_Emptyitemtext ;
      private string Combo_paicod_Onlyselectedvalues ;
      private string Combo_paicod_Selectalltext ;
      private string Combo_paicod_Multiplevaluesseparator ;
      private string Combo_paicod_Addnewoptiontext ;
      private string Combo_tipccod_Objectcall ;
      private string Combo_tipccod_Class ;
      private string Combo_tipccod_Icontype ;
      private string Combo_tipccod_Icon ;
      private string Combo_tipccod_Tooltip ;
      private string Combo_tipccod_Selectedvalue_set ;
      private string Combo_tipccod_Selectedtext_set ;
      private string Combo_tipccod_Selectedtext_get ;
      private string Combo_tipccod_Gamoauthtoken ;
      private string Combo_tipccod_Ddointernalname ;
      private string Combo_tipccod_Titlecontrolalign ;
      private string Combo_tipccod_Dropdownoptionstype ;
      private string Combo_tipccod_Titlecontrolidtoreplace ;
      private string Combo_tipccod_Datalisttype ;
      private string Combo_tipccod_Datalistfixedvalues ;
      private string Combo_tipccod_Htmltemplate ;
      private string Combo_tipccod_Multiplevaluestype ;
      private string Combo_tipccod_Loadingdata ;
      private string Combo_tipccod_Noresultsfound ;
      private string Combo_tipccod_Emptyitemtext ;
      private string Combo_tipccod_Onlyselectedvalues ;
      private string Combo_tipccod_Selectalltext ;
      private string Combo_tipccod_Multiplevaluesseparator ;
      private string Combo_tipccod_Addnewoptiontext ;
      private string Combo_conpcod_Objectcall ;
      private string Combo_conpcod_Class ;
      private string Combo_conpcod_Icontype ;
      private string Combo_conpcod_Icon ;
      private string Combo_conpcod_Tooltip ;
      private string Combo_conpcod_Selectedvalue_set ;
      private string Combo_conpcod_Selectedtext_set ;
      private string Combo_conpcod_Selectedtext_get ;
      private string Combo_conpcod_Gamoauthtoken ;
      private string Combo_conpcod_Ddointernalname ;
      private string Combo_conpcod_Titlecontrolalign ;
      private string Combo_conpcod_Dropdownoptionstype ;
      private string Combo_conpcod_Titlecontrolidtoreplace ;
      private string Combo_conpcod_Datalisttype ;
      private string Combo_conpcod_Datalistfixedvalues ;
      private string Combo_conpcod_Htmltemplate ;
      private string Combo_conpcod_Multiplevaluestype ;
      private string Combo_conpcod_Loadingdata ;
      private string Combo_conpcod_Noresultsfound ;
      private string Combo_conpcod_Emptyitemtext ;
      private string Combo_conpcod_Onlyselectedvalues ;
      private string Combo_conpcod_Selectalltext ;
      private string Combo_conpcod_Multiplevaluesseparator ;
      private string Combo_conpcod_Addnewoptiontext ;
      private string Combo_clivend_Objectcall ;
      private string Combo_clivend_Class ;
      private string Combo_clivend_Icontype ;
      private string Combo_clivend_Icon ;
      private string Combo_clivend_Tooltip ;
      private string Combo_clivend_Selectedvalue_set ;
      private string Combo_clivend_Selectedtext_set ;
      private string Combo_clivend_Selectedtext_get ;
      private string Combo_clivend_Gamoauthtoken ;
      private string Combo_clivend_Ddointernalname ;
      private string Combo_clivend_Titlecontrolalign ;
      private string Combo_clivend_Dropdownoptionstype ;
      private string Combo_clivend_Titlecontrolidtoreplace ;
      private string Combo_clivend_Datalisttype ;
      private string Combo_clivend_Datalistfixedvalues ;
      private string Combo_clivend_Htmltemplate ;
      private string Combo_clivend_Multiplevaluestype ;
      private string Combo_clivend_Loadingdata ;
      private string Combo_clivend_Noresultsfound ;
      private string Combo_clivend_Emptyitemtext ;
      private string Combo_clivend_Onlyselectedvalues ;
      private string Combo_clivend_Selectalltext ;
      private string Combo_clivend_Multiplevaluesseparator ;
      private string Combo_clivend_Addnewoptiontext ;
      private string Combo_discod_Objectcall ;
      private string Combo_discod_Class ;
      private string Combo_discod_Icontype ;
      private string Combo_discod_Icon ;
      private string Combo_discod_Tooltip ;
      private string Combo_discod_Selectedvalue_set ;
      private string Combo_discod_Selectedtext_set ;
      private string Combo_discod_Selectedtext_get ;
      private string Combo_discod_Gamoauthtoken ;
      private string Combo_discod_Ddointernalname ;
      private string Combo_discod_Titlecontrolalign ;
      private string Combo_discod_Dropdownoptionstype ;
      private string Combo_discod_Titlecontrolidtoreplace ;
      private string Combo_discod_Datalisttype ;
      private string Combo_discod_Datalistfixedvalues ;
      private string Combo_discod_Datalistprocparametersprefix ;
      private string Combo_discod_Htmltemplate ;
      private string Combo_discod_Multiplevaluestype ;
      private string Combo_discod_Loadingdata ;
      private string Combo_discod_Noresultsfound ;
      private string Combo_discod_Emptyitemtext ;
      private string Combo_discod_Onlyselectedvalues ;
      private string Combo_discod_Selectalltext ;
      private string Combo_discod_Multiplevaluesseparator ;
      private string Combo_discod_Addnewoptiontext ;
      private string Combo_provcod_Objectcall ;
      private string Combo_provcod_Class ;
      private string Combo_provcod_Icontype ;
      private string Combo_provcod_Icon ;
      private string Combo_provcod_Tooltip ;
      private string Combo_provcod_Selectedvalue_set ;
      private string Combo_provcod_Selectedtext_set ;
      private string Combo_provcod_Selectedtext_get ;
      private string Combo_provcod_Gamoauthtoken ;
      private string Combo_provcod_Ddointernalname ;
      private string Combo_provcod_Titlecontrolalign ;
      private string Combo_provcod_Dropdownoptionstype ;
      private string Combo_provcod_Titlecontrolidtoreplace ;
      private string Combo_provcod_Datalisttype ;
      private string Combo_provcod_Datalistfixedvalues ;
      private string Combo_provcod_Datalistprocparametersprefix ;
      private string Combo_provcod_Htmltemplate ;
      private string Combo_provcod_Multiplevaluestype ;
      private string Combo_provcod_Loadingdata ;
      private string Combo_provcod_Noresultsfound ;
      private string Combo_provcod_Emptyitemtext ;
      private string Combo_provcod_Onlyselectedvalues ;
      private string Combo_provcod_Selectalltext ;
      private string Combo_provcod_Multiplevaluesseparator ;
      private string Combo_provcod_Addnewoptiontext ;
      private string Combo_zoncod_Objectcall ;
      private string Combo_zoncod_Class ;
      private string Combo_zoncod_Icontype ;
      private string Combo_zoncod_Icon ;
      private string Combo_zoncod_Tooltip ;
      private string Combo_zoncod_Selectedvalue_set ;
      private string Combo_zoncod_Selectedtext_set ;
      private string Combo_zoncod_Selectedtext_get ;
      private string Combo_zoncod_Gamoauthtoken ;
      private string Combo_zoncod_Ddointernalname ;
      private string Combo_zoncod_Titlecontrolalign ;
      private string Combo_zoncod_Dropdownoptionstype ;
      private string Combo_zoncod_Titlecontrolidtoreplace ;
      private string Combo_zoncod_Datalisttype ;
      private string Combo_zoncod_Datalistfixedvalues ;
      private string Combo_zoncod_Htmltemplate ;
      private string Combo_zoncod_Multiplevaluestype ;
      private string Combo_zoncod_Loadingdata ;
      private string Combo_zoncod_Noresultsfound ;
      private string Combo_zoncod_Emptyitemtext ;
      private string Combo_zoncod_Onlyselectedvalues ;
      private string Combo_zoncod_Selectalltext ;
      private string Combo_zoncod_Multiplevaluesseparator ;
      private string Combo_zoncod_Addnewoptiontext ;
      private string Combo_clitiplcod_Objectcall ;
      private string Combo_clitiplcod_Class ;
      private string Combo_clitiplcod_Icontype ;
      private string Combo_clitiplcod_Icon ;
      private string Combo_clitiplcod_Tooltip ;
      private string Combo_clitiplcod_Selectedvalue_set ;
      private string Combo_clitiplcod_Selectedtext_set ;
      private string Combo_clitiplcod_Selectedtext_get ;
      private string Combo_clitiplcod_Gamoauthtoken ;
      private string Combo_clitiplcod_Ddointernalname ;
      private string Combo_clitiplcod_Titlecontrolalign ;
      private string Combo_clitiplcod_Dropdownoptionstype ;
      private string Combo_clitiplcod_Titlecontrolidtoreplace ;
      private string Combo_clitiplcod_Datalisttype ;
      private string Combo_clitiplcod_Datalistfixedvalues ;
      private string Combo_clitiplcod_Htmltemplate ;
      private string Combo_clitiplcod_Multiplevaluestype ;
      private string Combo_clitiplcod_Loadingdata ;
      private string Combo_clitiplcod_Noresultsfound ;
      private string Combo_clitiplcod_Emptyitemtext ;
      private string Combo_clitiplcod_Onlyselectedvalues ;
      private string Combo_clitiplcod_Selectalltext ;
      private string Combo_clitiplcod_Multiplevaluesseparator ;
      private string Combo_clitiplcod_Addnewoptiontext ;
      private string Combo_tipscod_Objectcall ;
      private string Combo_tipscod_Class ;
      private string Combo_tipscod_Icontype ;
      private string Combo_tipscod_Icon ;
      private string Combo_tipscod_Tooltip ;
      private string Combo_tipscod_Selectedvalue_set ;
      private string Combo_tipscod_Selectedtext_set ;
      private string Combo_tipscod_Selectedtext_get ;
      private string Combo_tipscod_Gamoauthtoken ;
      private string Combo_tipscod_Ddointernalname ;
      private string Combo_tipscod_Titlecontrolalign ;
      private string Combo_tipscod_Dropdownoptionstype ;
      private string Combo_tipscod_Titlecontrolidtoreplace ;
      private string Combo_tipscod_Datalisttype ;
      private string Combo_tipscod_Datalistfixedvalues ;
      private string Combo_tipscod_Htmltemplate ;
      private string Combo_tipscod_Multiplevaluestype ;
      private string Combo_tipscod_Loadingdata ;
      private string Combo_tipscod_Noresultsfound ;
      private string Combo_tipscod_Emptyitemtext ;
      private string Combo_tipscod_Onlyselectedvalues ;
      private string Combo_tipscod_Selectalltext ;
      private string Combo_tipscod_Multiplevaluesseparator ;
      private string Combo_tipscod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_clidirzoncod_Objectcall ;
      private string Combo_clidirzoncod_Class ;
      private string Combo_clidirzoncod_Icontype ;
      private string Combo_clidirzoncod_Icon ;
      private string Combo_clidirzoncod_Tooltip ;
      private string Combo_clidirzoncod_Selectedvalue_set ;
      private string Combo_clidirzoncod_Selectedvalue_get ;
      private string Combo_clidirzoncod_Selectedtext_set ;
      private string Combo_clidirzoncod_Selectedtext_get ;
      private string Combo_clidirzoncod_Gamoauthtoken ;
      private string Combo_clidirzoncod_Ddointernalname ;
      private string Combo_clidirzoncod_Titlecontrolalign ;
      private string Combo_clidirzoncod_Dropdownoptionstype ;
      private string Combo_clidirzoncod_Titlecontrolidtoreplace ;
      private string Combo_clidirzoncod_Datalisttype ;
      private string Combo_clidirzoncod_Datalistfixedvalues ;
      private string Combo_clidirzoncod_Htmltemplate ;
      private string Combo_clidirzoncod_Multiplevaluestype ;
      private string Combo_clidirzoncod_Loadingdata ;
      private string Combo_clidirzoncod_Noresultsfound ;
      private string Combo_clidirzoncod_Emptyitemtext ;
      private string Combo_clidirzoncod_Onlyselectedvalues ;
      private string Combo_clidirzoncod_Selectalltext ;
      private string Combo_clidirzoncod_Multiplevaluesseparator ;
      private string Combo_clidirzoncod_Addnewoptiontext ;
      private string hsh ;
      private string sMode11 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string GXt_char2 ;
      private string Z602EstDsc ;
      private string Z635CliVendDsc ;
      private string Z603ProvDsc ;
      private string Z604DisDsc ;
      private string Z607CliDirZonDsc ;
      private string sGXsfl_368_fel_idx="0001" ;
      private string subGridlevel_level1_Class ;
      private string subGridlevel_level1_Linesclass ;
      private string ROClassString ;
      private string edtCliDirItem_Jsonclick ;
      private string edtCliDirDsc_Jsonclick ;
      private string edtCliDirDir_Jsonclick ;
      private string edtCliDirPais_Jsonclick ;
      private string edtCliDirDep_Jsonclick ;
      private string edtCliDirProv_Jsonclick ;
      private string edtCliDirDis_Jsonclick ;
      private string edtCliDirZonCod_Jsonclick ;
      private string edtCliDirZonDsc_Jsonclick ;
      private string sGXsfl_383_fel_idx="0001" ;
      private string subGridlevel_level2_Class ;
      private string subGridlevel_level2_Linesclass ;
      private string edtCliConCod_Jsonclick ;
      private string edtCliConDsc_Jsonclick ;
      private string edtCliConCargo_Jsonclick ;
      private string edtCliConTelf_Jsonclick ;
      private string edtCliConArea_Jsonclick ;
      private string edtCliConMail_Jsonclick ;
      private string edtCliConMailFE_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_level1_Internalname ;
      private string subGridlevel_level2_Internalname ;
      private DateTime Z634CliUsuFec ;
      private DateTime A634CliUsuFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n158ZonCod ;
      private bool n156CliTipLCod ;
      private bool bGXsfl_368_Refreshing=false ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_estcod_Emptyitem ;
      private bool Combo_paicod_Emptyitem ;
      private bool Combo_tipccod_Emptyitem ;
      private bool A612CliFoto_IsBlob ;
      private bool Combo_conpcod_Emptyitem ;
      private bool Combo_clivend_Emptyitem ;
      private bool Combo_discod_Emptyitem ;
      private bool Combo_provcod_Emptyitem ;
      private bool Combo_tipscod_Emptyitem ;
      private bool Combo_clidirzoncod_Isgriditem ;
      private bool Combo_clidirzoncod_Hasdescription ;
      private bool Combo_clidirzoncod_Emptyitem ;
      private bool bGXsfl_383_Refreshing=false ;
      private bool n40000CliFoto_GXI ;
      private bool Combo_estcod_Enabled ;
      private bool Combo_estcod_Visible ;
      private bool Combo_estcod_Allowmultipleselection ;
      private bool Combo_estcod_Isgriditem ;
      private bool Combo_estcod_Hasdescription ;
      private bool Combo_estcod_Includeonlyselectedoption ;
      private bool Combo_estcod_Includeselectalloption ;
      private bool Combo_estcod_Includeaddnewoption ;
      private bool Combo_paicod_Enabled ;
      private bool Combo_paicod_Visible ;
      private bool Combo_paicod_Allowmultipleselection ;
      private bool Combo_paicod_Isgriditem ;
      private bool Combo_paicod_Hasdescription ;
      private bool Combo_paicod_Includeonlyselectedoption ;
      private bool Combo_paicod_Includeselectalloption ;
      private bool Combo_paicod_Includeaddnewoption ;
      private bool Combo_tipccod_Enabled ;
      private bool Combo_tipccod_Visible ;
      private bool Combo_tipccod_Allowmultipleselection ;
      private bool Combo_tipccod_Isgriditem ;
      private bool Combo_tipccod_Hasdescription ;
      private bool Combo_tipccod_Includeonlyselectedoption ;
      private bool Combo_tipccod_Includeselectalloption ;
      private bool Combo_tipccod_Includeaddnewoption ;
      private bool Combo_conpcod_Enabled ;
      private bool Combo_conpcod_Visible ;
      private bool Combo_conpcod_Allowmultipleselection ;
      private bool Combo_conpcod_Isgriditem ;
      private bool Combo_conpcod_Hasdescription ;
      private bool Combo_conpcod_Includeonlyselectedoption ;
      private bool Combo_conpcod_Includeselectalloption ;
      private bool Combo_conpcod_Includeaddnewoption ;
      private bool Combo_clivend_Enabled ;
      private bool Combo_clivend_Visible ;
      private bool Combo_clivend_Allowmultipleselection ;
      private bool Combo_clivend_Isgriditem ;
      private bool Combo_clivend_Hasdescription ;
      private bool Combo_clivend_Includeonlyselectedoption ;
      private bool Combo_clivend_Includeselectalloption ;
      private bool Combo_clivend_Includeaddnewoption ;
      private bool Combo_discod_Enabled ;
      private bool Combo_discod_Visible ;
      private bool Combo_discod_Allowmultipleselection ;
      private bool Combo_discod_Isgriditem ;
      private bool Combo_discod_Hasdescription ;
      private bool Combo_discod_Includeonlyselectedoption ;
      private bool Combo_discod_Includeselectalloption ;
      private bool Combo_discod_Includeaddnewoption ;
      private bool Combo_provcod_Enabled ;
      private bool Combo_provcod_Visible ;
      private bool Combo_provcod_Allowmultipleselection ;
      private bool Combo_provcod_Isgriditem ;
      private bool Combo_provcod_Hasdescription ;
      private bool Combo_provcod_Includeonlyselectedoption ;
      private bool Combo_provcod_Includeselectalloption ;
      private bool Combo_provcod_Includeaddnewoption ;
      private bool Combo_zoncod_Enabled ;
      private bool Combo_zoncod_Visible ;
      private bool Combo_zoncod_Allowmultipleselection ;
      private bool Combo_zoncod_Isgriditem ;
      private bool Combo_zoncod_Hasdescription ;
      private bool Combo_zoncod_Includeonlyselectedoption ;
      private bool Combo_zoncod_Includeselectalloption ;
      private bool Combo_zoncod_Emptyitem ;
      private bool Combo_zoncod_Includeaddnewoption ;
      private bool Combo_clitiplcod_Enabled ;
      private bool Combo_clitiplcod_Visible ;
      private bool Combo_clitiplcod_Allowmultipleselection ;
      private bool Combo_clitiplcod_Isgriditem ;
      private bool Combo_clitiplcod_Hasdescription ;
      private bool Combo_clitiplcod_Includeonlyselectedoption ;
      private bool Combo_clitiplcod_Includeselectalloption ;
      private bool Combo_clitiplcod_Emptyitem ;
      private bool Combo_clitiplcod_Includeaddnewoption ;
      private bool Combo_tipscod_Enabled ;
      private bool Combo_tipscod_Visible ;
      private bool Combo_tipscod_Allowmultipleselection ;
      private bool Combo_tipscod_Isgriditem ;
      private bool Combo_tipscod_Hasdescription ;
      private bool Combo_tipscod_Includeonlyselectedoption ;
      private bool Combo_tipscod_Includeselectalloption ;
      private bool Combo_tipscod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_clidirzoncod_Enabled ;
      private bool Combo_clidirzoncod_Visible ;
      private bool Combo_clidirzoncod_Allowmultipleselection ;
      private bool Combo_clidirzoncod_Includeonlyselectedoption ;
      private bool Combo_clidirzoncod_Includeselectalloption ;
      private bool Combo_clidirzoncod_Includeaddnewoption ;
      private bool n45CliCod ;
      private bool n612CliFoto ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV26Combo_DataJson ;
      private string Z609CliEma ;
      private string Z615CliNom ;
      private string Z574CliAPEP ;
      private string Z573CliAPEM ;
      private string Z610CliEMAPer ;
      private string Z616CliPassPer ;
      private string Z579CliConMail ;
      private string A609CliEma ;
      private string A40000CliFoto_GXI ;
      private string A615CliNom ;
      private string A574CliAPEP ;
      private string A573CliAPEM ;
      private string A610CliEMAPer ;
      private string A616CliPassPer ;
      private string A601CliDireccionLarga ;
      private string A579CliConMail ;
      private string AV24ComboSelectedValue ;
      private string AV25ComboSelectedText ;
      private string Z40000CliFoto_GXI ;
      private string Z601CliDireccionLarga ;
      private string A612CliFoto ;
      private string Z612CliFoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_level1Container ;
      private GXWebGrid Gridlevel_level2Container ;
      private GXWebRow Gridlevel_level1Row ;
      private GXWebRow Gridlevel_level2Row ;
      private GXWebColumn Gridlevel_level1Column ;
      private GXWebColumn Gridlevel_level2Column ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_estcod ;
      private GXUserControl ucCombo_paicod ;
      private GXUserControl ucCombo_tipccod ;
      private GXUserControl ucCombo_conpcod ;
      private GXUserControl ucCombo_clivend ;
      private GXUserControl ucCombo_discod ;
      private GXUserControl ucCombo_provcod ;
      private GXUserControl ucCombo_zoncod ;
      private GXUserControl ucCombo_clitiplcod ;
      private GXUserControl ucCombo_tipscod ;
      private GXUserControl ucCombo_clidirzoncod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007O9_A602EstDsc ;
      private string[] T007O16_A635CliVendDsc ;
      private string[] T007O10_A603ProvDsc ;
      private string[] T007O11_A604DisDsc ;
      private string[] T007O18_A45CliCod ;
      private bool[] T007O18_n45CliCod ;
      private string[] T007O18_A161CliDsc ;
      private string[] T007O18_A596CliDir ;
      private string[] T007O18_A629CliTel1 ;
      private string[] T007O18_A630CliTel2 ;
      private string[] T007O18_A611CliFax ;
      private string[] T007O18_A575CliCel ;
      private string[] T007O18_A609CliEma ;
      private string[] T007O18_A637CliWeb ;
      private string[] T007O18_A40000CliFoto_GXI ;
      private bool[] T007O18_n40000CliFoto_GXI ;
      private short[] T007O18_A627CliSts ;
      private decimal[] T007O18_A613CliLim ;
      private string[] T007O18_A635CliVendDsc ;
      private string[] T007O18_A618CliRef1 ;
      private string[] T007O18_A619CliRef2 ;
      private string[] T007O18_A620CliRef3 ;
      private string[] T007O18_A621CliRef4 ;
      private string[] T007O18_A622CliRef5 ;
      private string[] T007O18_A623CliRef6 ;
      private string[] T007O18_A624CliRef7 ;
      private string[] T007O18_A625CliRef8 ;
      private string[] T007O18_A581CliCont1 ;
      private string[] T007O18_A587CliCTel1 ;
      private string[] T007O18_A582CliCont2 ;
      private string[] T007O18_A588CliCTel2 ;
      private string[] T007O18_A583CliCont3 ;
      private string[] T007O18_A589CliCtel3 ;
      private string[] T007O18_A584CliCont4 ;
      private string[] T007O18_A590CliCTel4 ;
      private string[] T007O18_A585CliCont5 ;
      private string[] T007O18_A591CliCtel5 ;
      private int[] T007O18_A632CliTItemDir ;
      private int[] T007O18_A614CliMon ;
      private short[] T007O18_A636CliVincula ;
      private short[] T007O18_A626CliRetencion ;
      private short[] T007O18_A617CliPercepcion ;
      private string[] T007O18_A615CliNom ;
      private string[] T007O18_A574CliAPEP ;
      private string[] T007O18_A573CliAPEM ;
      private string[] T007O18_A633CliUsuCod ;
      private DateTime[] T007O18_A634CliUsuFec ;
      private string[] T007O18_A610CliEMAPer ;
      private string[] T007O18_A616CliPassPer ;
      private int[] T007O18_A628CliTCon ;
      private string[] T007O18_A631CliTipCod ;
      private int[] T007O18_A608CliDTAval ;
      private string[] T007O18_A602EstDsc ;
      private string[] T007O18_A603ProvDsc ;
      private string[] T007O18_A604DisDsc ;
      private string[] T007O18_A139PaiCod ;
      private string[] T007O18_A140EstCod ;
      private string[] T007O18_A141ProvCod ;
      private string[] T007O18_A142DisCod ;
      private int[] T007O18_A159TipCCod ;
      private int[] T007O18_A137Conpcod ;
      private int[] T007O18_A158ZonCod ;
      private bool[] T007O18_n158ZonCod ;
      private int[] T007O18_A157TipSCod ;
      private int[] T007O18_A160CliVend ;
      private int[] T007O18_A156CliTipLCod ;
      private bool[] T007O18_n156CliTipLCod ;
      private string[] T007O18_A612CliFoto ;
      private bool[] T007O18_n612CliFoto ;
      private int[] T007O12_A159TipCCod ;
      private int[] T007O13_A137Conpcod ;
      private int[] T007O14_A158ZonCod ;
      private bool[] T007O14_n158ZonCod ;
      private int[] T007O17_A156CliTipLCod ;
      private bool[] T007O17_n156CliTipLCod ;
      private int[] T007O15_A157TipSCod ;
      private string[] T007O19_A602EstDsc ;
      private string[] T007O20_A603ProvDsc ;
      private string[] T007O21_A604DisDsc ;
      private int[] T007O22_A159TipCCod ;
      private int[] T007O23_A137Conpcod ;
      private string[] T007O24_A635CliVendDsc ;
      private int[] T007O25_A158ZonCod ;
      private bool[] T007O25_n158ZonCod ;
      private int[] T007O26_A156CliTipLCod ;
      private bool[] T007O26_n156CliTipLCod ;
      private int[] T007O27_A157TipSCod ;
      private string[] T007O28_A45CliCod ;
      private bool[] T007O28_n45CliCod ;
      private string[] T007O8_A45CliCod ;
      private bool[] T007O8_n45CliCod ;
      private string[] T007O8_A161CliDsc ;
      private string[] T007O8_A596CliDir ;
      private string[] T007O8_A629CliTel1 ;
      private string[] T007O8_A630CliTel2 ;
      private string[] T007O8_A611CliFax ;
      private string[] T007O8_A575CliCel ;
      private string[] T007O8_A609CliEma ;
      private string[] T007O8_A637CliWeb ;
      private string[] T007O8_A40000CliFoto_GXI ;
      private bool[] T007O8_n40000CliFoto_GXI ;
      private short[] T007O8_A627CliSts ;
      private decimal[] T007O8_A613CliLim ;
      private string[] T007O8_A618CliRef1 ;
      private string[] T007O8_A619CliRef2 ;
      private string[] T007O8_A620CliRef3 ;
      private string[] T007O8_A621CliRef4 ;
      private string[] T007O8_A622CliRef5 ;
      private string[] T007O8_A623CliRef6 ;
      private string[] T007O8_A624CliRef7 ;
      private string[] T007O8_A625CliRef8 ;
      private string[] T007O8_A581CliCont1 ;
      private string[] T007O8_A587CliCTel1 ;
      private string[] T007O8_A582CliCont2 ;
      private string[] T007O8_A588CliCTel2 ;
      private string[] T007O8_A583CliCont3 ;
      private string[] T007O8_A589CliCtel3 ;
      private string[] T007O8_A584CliCont4 ;
      private string[] T007O8_A590CliCTel4 ;
      private string[] T007O8_A585CliCont5 ;
      private string[] T007O8_A591CliCtel5 ;
      private int[] T007O8_A632CliTItemDir ;
      private int[] T007O8_A614CliMon ;
      private short[] T007O8_A636CliVincula ;
      private short[] T007O8_A626CliRetencion ;
      private short[] T007O8_A617CliPercepcion ;
      private string[] T007O8_A615CliNom ;
      private string[] T007O8_A574CliAPEP ;
      private string[] T007O8_A573CliAPEM ;
      private string[] T007O8_A633CliUsuCod ;
      private DateTime[] T007O8_A634CliUsuFec ;
      private string[] T007O8_A610CliEMAPer ;
      private string[] T007O8_A616CliPassPer ;
      private int[] T007O8_A628CliTCon ;
      private string[] T007O8_A631CliTipCod ;
      private int[] T007O8_A608CliDTAval ;
      private string[] T007O8_A139PaiCod ;
      private string[] T007O8_A140EstCod ;
      private string[] T007O8_A141ProvCod ;
      private string[] T007O8_A142DisCod ;
      private int[] T007O8_A159TipCCod ;
      private int[] T007O8_A137Conpcod ;
      private int[] T007O8_A158ZonCod ;
      private bool[] T007O8_n158ZonCod ;
      private int[] T007O8_A157TipSCod ;
      private int[] T007O8_A160CliVend ;
      private int[] T007O8_A156CliTipLCod ;
      private bool[] T007O8_n156CliTipLCod ;
      private string[] T007O8_A612CliFoto ;
      private bool[] T007O8_n612CliFoto ;
      private string[] T007O29_A45CliCod ;
      private bool[] T007O29_n45CliCod ;
      private string[] T007O30_A45CliCod ;
      private bool[] T007O30_n45CliCod ;
      private string[] T007O7_A45CliCod ;
      private bool[] T007O7_n45CliCod ;
      private string[] T007O7_A161CliDsc ;
      private string[] T007O7_A596CliDir ;
      private string[] T007O7_A629CliTel1 ;
      private string[] T007O7_A630CliTel2 ;
      private string[] T007O7_A611CliFax ;
      private string[] T007O7_A575CliCel ;
      private string[] T007O7_A609CliEma ;
      private string[] T007O7_A637CliWeb ;
      private string[] T007O7_A40000CliFoto_GXI ;
      private bool[] T007O7_n40000CliFoto_GXI ;
      private short[] T007O7_A627CliSts ;
      private decimal[] T007O7_A613CliLim ;
      private string[] T007O7_A618CliRef1 ;
      private string[] T007O7_A619CliRef2 ;
      private string[] T007O7_A620CliRef3 ;
      private string[] T007O7_A621CliRef4 ;
      private string[] T007O7_A622CliRef5 ;
      private string[] T007O7_A623CliRef6 ;
      private string[] T007O7_A624CliRef7 ;
      private string[] T007O7_A625CliRef8 ;
      private string[] T007O7_A581CliCont1 ;
      private string[] T007O7_A587CliCTel1 ;
      private string[] T007O7_A582CliCont2 ;
      private string[] T007O7_A588CliCTel2 ;
      private string[] T007O7_A583CliCont3 ;
      private string[] T007O7_A589CliCtel3 ;
      private string[] T007O7_A584CliCont4 ;
      private string[] T007O7_A590CliCTel4 ;
      private string[] T007O7_A585CliCont5 ;
      private string[] T007O7_A591CliCtel5 ;
      private int[] T007O7_A632CliTItemDir ;
      private int[] T007O7_A614CliMon ;
      private short[] T007O7_A636CliVincula ;
      private short[] T007O7_A626CliRetencion ;
      private short[] T007O7_A617CliPercepcion ;
      private string[] T007O7_A615CliNom ;
      private string[] T007O7_A574CliAPEP ;
      private string[] T007O7_A573CliAPEM ;
      private string[] T007O7_A633CliUsuCod ;
      private DateTime[] T007O7_A634CliUsuFec ;
      private string[] T007O7_A610CliEMAPer ;
      private string[] T007O7_A616CliPassPer ;
      private int[] T007O7_A628CliTCon ;
      private string[] T007O7_A631CliTipCod ;
      private int[] T007O7_A608CliDTAval ;
      private string[] T007O7_A139PaiCod ;
      private string[] T007O7_A140EstCod ;
      private string[] T007O7_A141ProvCod ;
      private string[] T007O7_A142DisCod ;
      private int[] T007O7_A159TipCCod ;
      private int[] T007O7_A137Conpcod ;
      private int[] T007O7_A158ZonCod ;
      private bool[] T007O7_n158ZonCod ;
      private int[] T007O7_A157TipSCod ;
      private int[] T007O7_A160CliVend ;
      private int[] T007O7_A156CliTipLCod ;
      private bool[] T007O7_n156CliTipLCod ;
      private string[] T007O7_A612CliFoto ;
      private bool[] T007O7_n612CliFoto ;
      private string[] T007O35_A602EstDsc ;
      private string[] T007O36_A635CliVendDsc ;
      private string[] T007O37_A603ProvDsc ;
      private string[] T007O38_A604DisDsc ;
      private string[] T007O39_A149TipCod ;
      private string[] T007O39_A24DocNum ;
      private string[] T007O40_A224LotCliCod ;
      private string[] T007O41_A218PerCod ;
      private string[] T007O41_A219PerTip ;
      private string[] T007O41_A220PerTDoc ;
      private string[] T007O42_A204LetCLetCod ;
      private long[] T007O43_A191ImpItem ;
      private string[] T007O44_A184CCTipCod ;
      private string[] T007O44_A185CCDocNum ;
      private string[] T007O45_A150CLCheqDCod ;
      private string[] T007O46_A144CLAntTipCod ;
      private string[] T007O46_A145CLAntDocNum ;
      private string[] T007O47_A210PedCod ;
      private int[] T007O48_A202TipLCod ;
      private int[] T007O48_A203TipLItem ;
      private string[] T007O49_A177CotCod ;
      private string[] T007O50_A44PlaCod ;
      private string[] T007O51_A13MvATip ;
      private string[] T007O51_A14MvACod ;
      private string[] T007O52_A45CliCod ;
      private bool[] T007O52_n45CliCod ;
      private int[] T007O52_A162CliDAval ;
      private int[] T007O53_A37ListItem ;
      private string[] T007O54_A26AGMVATip ;
      private string[] T007O54_A27AGMVACod ;
      private string[] T007O54_A28ProdCod ;
      private string[] T007O55_A13MvATip ;
      private string[] T007O55_A14MvACod ;
      private string[] T007O56_A13MvATip ;
      private string[] T007O56_A14MvACod ;
      private string[] T007O57_A45CliCod ;
      private bool[] T007O57_n45CliCod ;
      private string[] T007O58_A45CliCod ;
      private bool[] T007O58_n45CliCod ;
      private int[] T007O58_A164CliDirItem ;
      private string[] T007O58_A600CliDirDsc ;
      private string[] T007O58_A598CliDirDir ;
      private string[] T007O58_A605CliDirPais ;
      private string[] T007O58_A597CliDirDep ;
      private string[] T007O58_A606CliDirProv ;
      private string[] T007O58_A599CliDirDis ;
      private string[] T007O58_A607CliDirZonDsc ;
      private int[] T007O58_A165CliDirZonCod ;
      private string[] T007O6_A607CliDirZonDsc ;
      private string[] T007O59_A607CliDirZonDsc ;
      private string[] T007O60_A45CliCod ;
      private bool[] T007O60_n45CliCod ;
      private int[] T007O60_A164CliDirItem ;
      private string[] T007O5_A45CliCod ;
      private bool[] T007O5_n45CliCod ;
      private int[] T007O5_A164CliDirItem ;
      private string[] T007O5_A600CliDirDsc ;
      private string[] T007O5_A598CliDirDir ;
      private string[] T007O5_A605CliDirPais ;
      private string[] T007O5_A597CliDirDep ;
      private string[] T007O5_A606CliDirProv ;
      private string[] T007O5_A599CliDirDis ;
      private int[] T007O5_A165CliDirZonCod ;
      private string[] T007O4_A45CliCod ;
      private bool[] T007O4_n45CliCod ;
      private int[] T007O4_A164CliDirItem ;
      private string[] T007O4_A600CliDirDsc ;
      private string[] T007O4_A598CliDirDir ;
      private string[] T007O4_A605CliDirPais ;
      private string[] T007O4_A597CliDirDep ;
      private string[] T007O4_A606CliDirProv ;
      private string[] T007O4_A599CliDirDis ;
      private int[] T007O4_A165CliDirZonCod ;
      private string[] T007O64_A607CliDirZonDsc ;
      private string[] T007O65_A13MvATip ;
      private string[] T007O65_A14MvACod ;
      private string[] T007O66_A13MvATip ;
      private string[] T007O66_A14MvACod ;
      private string[] T007O67_A45CliCod ;
      private bool[] T007O67_n45CliCod ;
      private int[] T007O67_A164CliDirItem ;
      private string[] T007O68_A45CliCod ;
      private bool[] T007O68_n45CliCod ;
      private int[] T007O68_A163CliConCod ;
      private string[] T007O68_A578CliConDsc ;
      private string[] T007O68_A577CliConCargo ;
      private string[] T007O68_A586CliConTelf ;
      private string[] T007O68_A576CliConArea ;
      private string[] T007O68_A579CliConMail ;
      private short[] T007O68_A580CliConMailFE ;
      private string[] T007O69_A45CliCod ;
      private bool[] T007O69_n45CliCod ;
      private int[] T007O69_A163CliConCod ;
      private string[] T007O3_A45CliCod ;
      private bool[] T007O3_n45CliCod ;
      private int[] T007O3_A163CliConCod ;
      private string[] T007O3_A578CliConDsc ;
      private string[] T007O3_A577CliConCargo ;
      private string[] T007O3_A586CliConTelf ;
      private string[] T007O3_A576CliConArea ;
      private string[] T007O3_A579CliConMail ;
      private short[] T007O3_A580CliConMailFE ;
      private string[] T007O2_A45CliCod ;
      private bool[] T007O2_n45CliCod ;
      private int[] T007O2_A163CliConCod ;
      private string[] T007O2_A578CliConDsc ;
      private string[] T007O2_A577CliConCargo ;
      private string[] T007O2_A586CliConTelf ;
      private string[] T007O2_A576CliConArea ;
      private string[] T007O2_A579CliConMail ;
      private short[] T007O2_A580CliConMailFE ;
      private string[] T007O73_A45CliCod ;
      private bool[] T007O73_n45CliCod ;
      private int[] T007O73_A163CliConCod ;
      private int[] T007O74_A159TipCCod ;
      private int[] T007O75_A137Conpcod ;
      private int[] T007O76_A158ZonCod ;
      private bool[] T007O76_n158ZonCod ;
      private int[] T007O77_A156CliTipLCod ;
      private bool[] T007O77_n156CliTipLCod ;
      private int[] T007O78_A157TipSCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27EstCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV30PaiCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32TipCCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV34Conpcod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV36CliVend_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV39DisCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV43ProvCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV45ZonCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV47CliTipLCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV50TipSCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV22CliDirZonCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV23DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class clientes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clientes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
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
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new UpdateCursor(def[59])
       ,new UpdateCursor(def[60])
       ,new UpdateCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new ForEachCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new UpdateCursor(def[68])
       ,new UpdateCursor(def[69])
       ,new UpdateCursor(def[70])
       ,new ForEachCursor(def[71])
       ,new ForEachCursor(def[72])
       ,new ForEachCursor(def[73])
       ,new ForEachCursor(def[74])
       ,new ForEachCursor(def[75])
       ,new ForEachCursor(def[76])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007O18;
        prmT007O18 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O9;
        prmT007O9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT007O10;
        prmT007O10 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT007O11;
        prmT007O11 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT007O12;
        prmT007O12 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT007O13;
        prmT007O13 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT007O16;
        prmT007O16 = new Object[] {
        new ParDef("@CliVend",GXType.Int32,6,0)
        };
        Object[] prmT007O14;
        prmT007O14 = new Object[] {
        new ParDef("@ZonCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O17;
        prmT007O17 = new Object[] {
        new ParDef("@CliTipLCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O15;
        prmT007O15 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0)
        };
        Object[] prmT007O19;
        prmT007O19 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT007O20;
        prmT007O20 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT007O21;
        prmT007O21 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT007O22;
        prmT007O22 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT007O23;
        prmT007O23 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT007O24;
        prmT007O24 = new Object[] {
        new ParDef("@CliVend",GXType.Int32,6,0)
        };
        Object[] prmT007O25;
        prmT007O25 = new Object[] {
        new ParDef("@ZonCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O26;
        prmT007O26 = new Object[] {
        new ParDef("@CliTipLCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O27;
        prmT007O27 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0)
        };
        Object[] prmT007O28;
        prmT007O28 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O8;
        prmT007O8 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O29;
        prmT007O29 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O30;
        prmT007O30 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O7;
        prmT007O7 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O31;
        prmT007O31 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDir",GXType.NChar,100,0) ,
        new ParDef("@CliTel1",GXType.NChar,20,0) ,
        new ParDef("@CliTel2",GXType.NChar,20,0) ,
        new ParDef("@CliFax",GXType.NChar,20,0) ,
        new ParDef("@CliCel",GXType.NChar,20,0) ,
        new ParDef("@CliEma",GXType.NVarChar,100,0) ,
        new ParDef("@CliWeb",GXType.NChar,50,0) ,
        new ParDef("@CliFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@CliFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=9, Tbl="CLCLIENTES", Fld="CliFoto"} ,
        new ParDef("@CliSts",GXType.Int16,1,0) ,
        new ParDef("@CliLim",GXType.Decimal,15,2) ,
        new ParDef("@CliRef1",GXType.NChar,50,0) ,
        new ParDef("@CliRef2",GXType.NChar,50,0) ,
        new ParDef("@CliRef3",GXType.NChar,50,0) ,
        new ParDef("@CliRef4",GXType.NChar,50,0) ,
        new ParDef("@CliRef5",GXType.NChar,50,0) ,
        new ParDef("@CliRef6",GXType.NChar,50,0) ,
        new ParDef("@CliRef7",GXType.NChar,50,0) ,
        new ParDef("@CliRef8",GXType.NChar,50,0) ,
        new ParDef("@CliCont1",GXType.NChar,50,0) ,
        new ParDef("@CliCTel1",GXType.NChar,20,0) ,
        new ParDef("@CliCont2",GXType.NChar,50,0) ,
        new ParDef("@CliCTel2",GXType.NChar,20,0) ,
        new ParDef("@CliCont3",GXType.NChar,50,0) ,
        new ParDef("@CliCtel3",GXType.NChar,20,0) ,
        new ParDef("@CliCont4",GXType.NChar,50,0) ,
        new ParDef("@CliCTel4",GXType.NChar,20,0) ,
        new ParDef("@CliCont5",GXType.NChar,50,0) ,
        new ParDef("@CliCtel5",GXType.NChar,20,0) ,
        new ParDef("@CliTItemDir",GXType.Int32,6,0) ,
        new ParDef("@CliMon",GXType.Int32,6,0) ,
        new ParDef("@CliVincula",GXType.Int16,1,0) ,
        new ParDef("@CliRetencion",GXType.Int16,1,0) ,
        new ParDef("@CliPercepcion",GXType.Int16,1,0) ,
        new ParDef("@CliNom",GXType.NVarChar,100,0) ,
        new ParDef("@CliAPEP",GXType.NVarChar,100,0) ,
        new ParDef("@CliAPEM",GXType.NVarChar,100,0) ,
        new ParDef("@CliUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CliUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CliEMAPer",GXType.NVarChar,100,0) ,
        new ParDef("@CliPassPer",GXType.NVarChar,10,0) ,
        new ParDef("@CliTCon",GXType.Int32,6,0) ,
        new ParDef("@CliTipCod",GXType.NChar,3,0) ,
        new ParDef("@CliDTAval",GXType.Int32,6,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@TipCCod",GXType.Int32,6,0) ,
        new ParDef("@Conpcod",GXType.Int32,6,0) ,
        new ParDef("@ZonCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TipSCod",GXType.Int32,6,0) ,
        new ParDef("@CliVend",GXType.Int32,6,0) ,
        new ParDef("@CliTipLCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O32;
        prmT007O32 = new Object[] {
        new ParDef("@CliDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDir",GXType.NChar,100,0) ,
        new ParDef("@CliTel1",GXType.NChar,20,0) ,
        new ParDef("@CliTel2",GXType.NChar,20,0) ,
        new ParDef("@CliFax",GXType.NChar,20,0) ,
        new ParDef("@CliCel",GXType.NChar,20,0) ,
        new ParDef("@CliEma",GXType.NVarChar,100,0) ,
        new ParDef("@CliWeb",GXType.NChar,50,0) ,
        new ParDef("@CliSts",GXType.Int16,1,0) ,
        new ParDef("@CliLim",GXType.Decimal,15,2) ,
        new ParDef("@CliRef1",GXType.NChar,50,0) ,
        new ParDef("@CliRef2",GXType.NChar,50,0) ,
        new ParDef("@CliRef3",GXType.NChar,50,0) ,
        new ParDef("@CliRef4",GXType.NChar,50,0) ,
        new ParDef("@CliRef5",GXType.NChar,50,0) ,
        new ParDef("@CliRef6",GXType.NChar,50,0) ,
        new ParDef("@CliRef7",GXType.NChar,50,0) ,
        new ParDef("@CliRef8",GXType.NChar,50,0) ,
        new ParDef("@CliCont1",GXType.NChar,50,0) ,
        new ParDef("@CliCTel1",GXType.NChar,20,0) ,
        new ParDef("@CliCont2",GXType.NChar,50,0) ,
        new ParDef("@CliCTel2",GXType.NChar,20,0) ,
        new ParDef("@CliCont3",GXType.NChar,50,0) ,
        new ParDef("@CliCtel3",GXType.NChar,20,0) ,
        new ParDef("@CliCont4",GXType.NChar,50,0) ,
        new ParDef("@CliCTel4",GXType.NChar,20,0) ,
        new ParDef("@CliCont5",GXType.NChar,50,0) ,
        new ParDef("@CliCtel5",GXType.NChar,20,0) ,
        new ParDef("@CliTItemDir",GXType.Int32,6,0) ,
        new ParDef("@CliMon",GXType.Int32,6,0) ,
        new ParDef("@CliVincula",GXType.Int16,1,0) ,
        new ParDef("@CliRetencion",GXType.Int16,1,0) ,
        new ParDef("@CliPercepcion",GXType.Int16,1,0) ,
        new ParDef("@CliNom",GXType.NVarChar,100,0) ,
        new ParDef("@CliAPEP",GXType.NVarChar,100,0) ,
        new ParDef("@CliAPEM",GXType.NVarChar,100,0) ,
        new ParDef("@CliUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CliUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CliEMAPer",GXType.NVarChar,100,0) ,
        new ParDef("@CliPassPer",GXType.NVarChar,10,0) ,
        new ParDef("@CliTCon",GXType.Int32,6,0) ,
        new ParDef("@CliTipCod",GXType.NChar,3,0) ,
        new ParDef("@CliDTAval",GXType.Int32,6,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@TipCCod",GXType.Int32,6,0) ,
        new ParDef("@Conpcod",GXType.Int32,6,0) ,
        new ParDef("@ZonCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TipSCod",GXType.Int32,6,0) ,
        new ParDef("@CliVend",GXType.Int32,6,0) ,
        new ParDef("@CliTipLCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O33;
        prmT007O33 = new Object[] {
        new ParDef("@CliFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@CliFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="CLCLIENTES", Fld="CliFoto"} ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O34;
        prmT007O34 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O39;
        prmT007O39 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O40;
        prmT007O40 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O41;
        prmT007O41 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O42;
        prmT007O42 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O43;
        prmT007O43 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O44;
        prmT007O44 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O45;
        prmT007O45 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O46;
        prmT007O46 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O47;
        prmT007O47 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O48;
        prmT007O48 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O49;
        prmT007O49 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O50;
        prmT007O50 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O51;
        prmT007O51 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O52;
        prmT007O52 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O53;
        prmT007O53 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O54;
        prmT007O54 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O55;
        prmT007O55 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O56;
        prmT007O56 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O57;
        prmT007O57 = new Object[] {
        };
        Object[] prmT007O58;
        prmT007O58 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O6;
        prmT007O6 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT007O59;
        prmT007O59 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT007O60;
        prmT007O60 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O5;
        prmT007O5 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O4;
        prmT007O4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O61;
        prmT007O61 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0) ,
        new ParDef("@CliDirDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDirDir",GXType.NChar,100,0) ,
        new ParDef("@CliDirPais",GXType.NChar,4,0) ,
        new ParDef("@CliDirDep",GXType.NChar,4,0) ,
        new ParDef("@CliDirProv",GXType.NChar,4,0) ,
        new ParDef("@CliDirDis",GXType.NChar,4,0) ,
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT007O62;
        prmT007O62 = new Object[] {
        new ParDef("@CliDirDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDirDir",GXType.NChar,100,0) ,
        new ParDef("@CliDirPais",GXType.NChar,4,0) ,
        new ParDef("@CliDirDep",GXType.NChar,4,0) ,
        new ParDef("@CliDirProv",GXType.NChar,4,0) ,
        new ParDef("@CliDirDis",GXType.NChar,4,0) ,
        new ParDef("@CliDirZonCod",GXType.Int32,6,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O63;
        prmT007O63 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O65;
        prmT007O65 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O66;
        prmT007O66 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT007O67;
        prmT007O67 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O68;
        prmT007O68 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O69;
        prmT007O69 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O3;
        prmT007O3 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O2;
        prmT007O2 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O70;
        prmT007O70 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0) ,
        new ParDef("@CliConDsc",GXType.NChar,100,0) ,
        new ParDef("@CliConCargo",GXType.NChar,100,0) ,
        new ParDef("@CliConTelf",GXType.NChar,40,0) ,
        new ParDef("@CliConArea",GXType.NChar,100,0) ,
        new ParDef("@CliConMail",GXType.NVarChar,100,0) ,
        new ParDef("@CliConMailFE",GXType.Int16,1,0)
        };
        Object[] prmT007O71;
        prmT007O71 = new Object[] {
        new ParDef("@CliConDsc",GXType.NChar,100,0) ,
        new ParDef("@CliConCargo",GXType.NChar,100,0) ,
        new ParDef("@CliConTelf",GXType.NChar,40,0) ,
        new ParDef("@CliConArea",GXType.NChar,100,0) ,
        new ParDef("@CliConMail",GXType.NVarChar,100,0) ,
        new ParDef("@CliConMailFE",GXType.Int16,1,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O72;
        prmT007O72 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT007O73;
        prmT007O73 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT007O35;
        prmT007O35 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT007O74;
        prmT007O74 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT007O75;
        prmT007O75 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT007O36;
        prmT007O36 = new Object[] {
        new ParDef("@CliVend",GXType.Int32,6,0)
        };
        Object[] prmT007O37;
        prmT007O37 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT007O38;
        prmT007O38 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT007O76;
        prmT007O76 = new Object[] {
        new ParDef("@ZonCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O77;
        prmT007O77 = new Object[] {
        new ParDef("@CliTipLCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT007O78;
        prmT007O78 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0)
        };
        Object[] prmT007O64;
        prmT007O64 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007O2", "SELECT [CliCod], [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE] FROM [CLCLIENTESCONTACTOS] WITH (UPDLOCK) WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O3", "SELECT [CliCod], [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O4", "SELECT [CliCod], [CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliDirZonCod] AS CliDirZonCod FROM [CLCLIENTESDIRECCION] WITH (UPDLOCK) WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O5", "SELECT [CliCod], [CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliDirZonCod] AS CliDirZonCod FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O6", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O7", "SELECT [CliCod], [CliDsc], [CliDir], [CliTel1], [CliTel2], [CliFax], [CliCel], [CliEma], [CliWeb], [CliFoto_GXI], [CliSts], [CliLim], [CliRef1], [CliRef2], [CliRef3], [CliRef4], [CliRef5], [CliRef6], [CliRef7], [CliRef8], [CliCont1], [CliCTel1], [CliCont2], [CliCTel2], [CliCont3], [CliCtel3], [CliCont4], [CliCTel4], [CliCont5], [CliCtel5], [CliTItemDir], [CliMon], [CliVincula], [CliRetencion], [CliPercepcion], [CliNom], [CliAPEP], [CliAPEM], [CliUsuCod], [CliUsuFec], [CliEMAPer], [CliPassPer], [CliTCon], [CliTipCod], [CliDTAval], [PaiCod], [EstCod], [ProvCod], [DisCod], [TipCCod], [Conpcod], [ZonCod], [TipSCod], [CliVend] AS CliVend, [CliTipLCod] AS CliTipLCod, [CliFoto] FROM [CLCLIENTES] WITH (UPDLOCK) WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O8", "SELECT [CliCod], [CliDsc], [CliDir], [CliTel1], [CliTel2], [CliFax], [CliCel], [CliEma], [CliWeb], [CliFoto_GXI], [CliSts], [CliLim], [CliRef1], [CliRef2], [CliRef3], [CliRef4], [CliRef5], [CliRef6], [CliRef7], [CliRef8], [CliCont1], [CliCTel1], [CliCont2], [CliCTel2], [CliCont3], [CliCtel3], [CliCont4], [CliCTel4], [CliCont5], [CliCtel5], [CliTItemDir], [CliMon], [CliVincula], [CliRetencion], [CliPercepcion], [CliNom], [CliAPEP], [CliAPEM], [CliUsuCod], [CliUsuFec], [CliEMAPer], [CliPassPer], [CliTCon], [CliTipCod], [CliDTAval], [PaiCod], [EstCod], [ProvCod], [DisCod], [TipCCod], [Conpcod], [ZonCod], [TipSCod], [CliVend] AS CliVend, [CliTipLCod] AS CliTipLCod, [CliFoto] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O9", "SELECT [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O10", "SELECT [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O11", "SELECT [DisDsc] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O12", "SELECT [TipCCod] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O13", "SELECT [Conpcod] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O14", "SELECT [ZonCod] FROM [CZONAS] WHERE [ZonCod] = @ZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O15", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O16", "SELECT [VenDsc] AS CliVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CliVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O17", "SELECT [TipLCod] AS CliTipLCod FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CliTipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O18", "SELECT TM1.[CliCod], TM1.[CliDsc], TM1.[CliDir], TM1.[CliTel1], TM1.[CliTel2], TM1.[CliFax], TM1.[CliCel], TM1.[CliEma], TM1.[CliWeb], TM1.[CliFoto_GXI], TM1.[CliSts], TM1.[CliLim], T3.[VenDsc] AS CliVendDsc, TM1.[CliRef1], TM1.[CliRef2], TM1.[CliRef3], TM1.[CliRef4], TM1.[CliRef5], TM1.[CliRef6], TM1.[CliRef7], TM1.[CliRef8], TM1.[CliCont1], TM1.[CliCTel1], TM1.[CliCont2], TM1.[CliCTel2], TM1.[CliCont3], TM1.[CliCtel3], TM1.[CliCont4], TM1.[CliCTel4], TM1.[CliCont5], TM1.[CliCtel5], TM1.[CliTItemDir], TM1.[CliMon], TM1.[CliVincula], TM1.[CliRetencion], TM1.[CliPercepcion], TM1.[CliNom], TM1.[CliAPEP], TM1.[CliAPEM], TM1.[CliUsuCod], TM1.[CliUsuFec], TM1.[CliEMAPer], TM1.[CliPassPer], TM1.[CliTCon], TM1.[CliTipCod], TM1.[CliDTAval], T2.[EstDsc], T4.[ProvDsc], T5.[DisDsc], TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod], TM1.[DisCod], TM1.[TipCCod], TM1.[Conpcod], TM1.[ZonCod], TM1.[TipSCod], TM1.[CliVend] AS CliVend, TM1.[CliTipLCod] AS CliTipLCod, TM1.[CliFoto] FROM (((([CLCLIENTES] TM1 INNER JOIN [CESTADOS] T2 ON T2.[PaiCod] = TM1.[PaiCod] AND T2.[EstCod] = TM1.[EstCod]) INNER JOIN [CVENDEDORES] T3 ON T3.[VenCod] = TM1.[CliVend]) INNER JOIN [CPROVINCIA] T4 ON T4.[PaiCod] = TM1.[PaiCod] AND T4.[EstCod] = TM1.[EstCod] AND T4.[ProvCod] = TM1.[ProvCod]) INNER JOIN [CDISTRITOS] T5 ON T5.[PaiCod] = TM1.[PaiCod] AND T5.[EstCod] = TM1.[EstCod] AND T5.[ProvCod] = TM1.[ProvCod] AND T5.[DisCod] = TM1.[DisCod]) WHERE TM1.[CliCod] = @CliCod ORDER BY TM1.[CliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007O18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O19", "SELECT [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O20", "SELECT [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O21", "SELECT [DisDsc] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O22", "SELECT [TipCCod] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O23", "SELECT [Conpcod] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O24", "SELECT [VenDsc] AS CliVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CliVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O25", "SELECT [ZonCod] FROM [CZONAS] WHERE [ZonCod] = @ZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O26", "SELECT [TipLCod] AS CliTipLCod FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CliTipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O27", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O28", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007O28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O29", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE ( [CliCod] > @CliCod) ORDER BY [CliCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007O29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O30", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE ( [CliCod] < @CliCod) ORDER BY [CliCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007O30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O31", "INSERT INTO [CLCLIENTES]([CliCod], [CliDsc], [CliDir], [CliTel1], [CliTel2], [CliFax], [CliCel], [CliEma], [CliWeb], [CliFoto], [CliFoto_GXI], [CliSts], [CliLim], [CliRef1], [CliRef2], [CliRef3], [CliRef4], [CliRef5], [CliRef6], [CliRef7], [CliRef8], [CliCont1], [CliCTel1], [CliCont2], [CliCTel2], [CliCont3], [CliCtel3], [CliCont4], [CliCTel4], [CliCont5], [CliCtel5], [CliTItemDir], [CliMon], [CliVincula], [CliRetencion], [CliPercepcion], [CliNom], [CliAPEP], [CliAPEM], [CliUsuCod], [CliUsuFec], [CliEMAPer], [CliPassPer], [CliTCon], [CliTipCod], [CliDTAval], [PaiCod], [EstCod], [ProvCod], [DisCod], [TipCCod], [Conpcod], [ZonCod], [TipSCod], [CliVend], [CliTipLCod]) VALUES(@CliCod, @CliDsc, @CliDir, @CliTel1, @CliTel2, @CliFax, @CliCel, @CliEma, @CliWeb, @CliFoto, @CliFoto_GXI, @CliSts, @CliLim, @CliRef1, @CliRef2, @CliRef3, @CliRef4, @CliRef5, @CliRef6, @CliRef7, @CliRef8, @CliCont1, @CliCTel1, @CliCont2, @CliCTel2, @CliCont3, @CliCtel3, @CliCont4, @CliCTel4, @CliCont5, @CliCtel5, @CliTItemDir, @CliMon, @CliVincula, @CliRetencion, @CliPercepcion, @CliNom, @CliAPEP, @CliAPEM, @CliUsuCod, @CliUsuFec, @CliEMAPer, @CliPassPer, @CliTCon, @CliTipCod, @CliDTAval, @PaiCod, @EstCod, @ProvCod, @DisCod, @TipCCod, @Conpcod, @ZonCod, @TipSCod, @CliVend, @CliTipLCod)", GxErrorMask.GX_NOMASK,prmT007O31)
           ,new CursorDef("T007O32", "UPDATE [CLCLIENTES] SET [CliDsc]=@CliDsc, [CliDir]=@CliDir, [CliTel1]=@CliTel1, [CliTel2]=@CliTel2, [CliFax]=@CliFax, [CliCel]=@CliCel, [CliEma]=@CliEma, [CliWeb]=@CliWeb, [CliSts]=@CliSts, [CliLim]=@CliLim, [CliRef1]=@CliRef1, [CliRef2]=@CliRef2, [CliRef3]=@CliRef3, [CliRef4]=@CliRef4, [CliRef5]=@CliRef5, [CliRef6]=@CliRef6, [CliRef7]=@CliRef7, [CliRef8]=@CliRef8, [CliCont1]=@CliCont1, [CliCTel1]=@CliCTel1, [CliCont2]=@CliCont2, [CliCTel2]=@CliCTel2, [CliCont3]=@CliCont3, [CliCtel3]=@CliCtel3, [CliCont4]=@CliCont4, [CliCTel4]=@CliCTel4, [CliCont5]=@CliCont5, [CliCtel5]=@CliCtel5, [CliTItemDir]=@CliTItemDir, [CliMon]=@CliMon, [CliVincula]=@CliVincula, [CliRetencion]=@CliRetencion, [CliPercepcion]=@CliPercepcion, [CliNom]=@CliNom, [CliAPEP]=@CliAPEP, [CliAPEM]=@CliAPEM, [CliUsuCod]=@CliUsuCod, [CliUsuFec]=@CliUsuFec, [CliEMAPer]=@CliEMAPer, [CliPassPer]=@CliPassPer, [CliTCon]=@CliTCon, [CliTipCod]=@CliTipCod, [CliDTAval]=@CliDTAval, [PaiCod]=@PaiCod, [EstCod]=@EstCod, [ProvCod]=@ProvCod, [DisCod]=@DisCod, [TipCCod]=@TipCCod, [Conpcod]=@Conpcod, [ZonCod]=@ZonCod, [TipSCod]=@TipSCod, [CliVend]=@CliVend, [CliTipLCod]=@CliTipLCod  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK,prmT007O32)
           ,new CursorDef("T007O33", "UPDATE [CLCLIENTES] SET [CliFoto]=@CliFoto, [CliFoto_GXI]=@CliFoto_GXI  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK,prmT007O33)
           ,new CursorDef("T007O34", "DELETE FROM [CLCLIENTES]  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK,prmT007O34)
           ,new CursorDef("T007O35", "SELECT [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O36", "SELECT [VenDsc] AS CliVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CliVend ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O37", "SELECT [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O38", "SELECT [DisDsc] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O39", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O40", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [LotCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O41", "SELECT TOP 1 [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] WHERE [PerCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O42", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE [LetCCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O43", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O44", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O45", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O46", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O46,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O47", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O47,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O48", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O48,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O49", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O49,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O50", "SELECT TOP 1 [PlaCod] FROM [APLACAS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O50,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O51", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O51,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O52", "SELECT TOP 1 [CliCod], [CliDAval] FROM [CLCLIENTESAVALES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O52,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O53", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE [ListCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O53,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O54", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [AGCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O54,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O55", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCDesCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O55,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O56", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O56,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O57", "SELECT [CliCod] FROM [CLCLIENTES] ORDER BY [CliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007O57,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O58", "SELECT T1.[CliCod], T1.[CliDirItem], T1.[CliDirDsc], T1.[CliDirDir], T1.[CliDirPais], T1.[CliDirDep], T1.[CliDirProv], T1.[CliDirDis], T2.[ZonDsc] AS CliDirZonDsc, T1.[CliDirZonCod] AS CliDirZonCod FROM ([CLCLIENTESDIRECCION] T1 INNER JOIN [CZONAS] T2 ON T2.[ZonCod] = T1.[CliDirZonCod]) WHERE T1.[CliCod] = @CliCod and T1.[CliDirItem] = @CliDirItem ORDER BY T1.[CliCod], T1.[CliDirItem] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O58,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O59", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O59,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O60", "SELECT [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O60,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O61", "INSERT INTO [CLCLIENTESDIRECCION]([CliCod], [CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliDirZonCod]) VALUES(@CliCod, @CliDirItem, @CliDirDsc, @CliDirDir, @CliDirPais, @CliDirDep, @CliDirProv, @CliDirDis, @CliDirZonCod)", GxErrorMask.GX_NOMASK,prmT007O61)
           ,new CursorDef("T007O62", "UPDATE [CLCLIENTESDIRECCION] SET [CliDirDsc]=@CliDirDsc, [CliDirDir]=@CliDirDir, [CliDirPais]=@CliDirPais, [CliDirDep]=@CliDirDep, [CliDirProv]=@CliDirProv, [CliDirDis]=@CliDirDis, [CliDirZonCod]=@CliDirZonCod  WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem", GxErrorMask.GX_NOMASK,prmT007O62)
           ,new CursorDef("T007O63", "DELETE FROM [CLCLIENTESDIRECCION]  WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem", GxErrorMask.GX_NOMASK,prmT007O63)
           ,new CursorDef("T007O64", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O64,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O65", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCDesCod] = @CliCod AND [MVCDesItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O65,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O66", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCliCod] = @CliCod AND [MVCliOrigen] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O66,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007O67", "SELECT [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod ORDER BY [CliCod], [CliDirItem] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O67,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O68", "SELECT [CliCod], [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod and [CliConCod] = @CliConCod ORDER BY [CliCod], [CliConCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O68,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O69", "SELECT [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O69,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O70", "INSERT INTO [CLCLIENTESCONTACTOS]([CliCod], [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE]) VALUES(@CliCod, @CliConCod, @CliConDsc, @CliConCargo, @CliConTelf, @CliConArea, @CliConMail, @CliConMailFE)", GxErrorMask.GX_NOMASK,prmT007O70)
           ,new CursorDef("T007O71", "UPDATE [CLCLIENTESCONTACTOS] SET [CliConDsc]=@CliConDsc, [CliConCargo]=@CliConCargo, [CliConTelf]=@CliConTelf, [CliConArea]=@CliConArea, [CliConMail]=@CliConMail, [CliConMailFE]=@CliConMailFE  WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod", GxErrorMask.GX_NOMASK,prmT007O71)
           ,new CursorDef("T007O72", "DELETE FROM [CLCLIENTESCONTACTOS]  WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod", GxErrorMask.GX_NOMASK,prmT007O72)
           ,new CursorDef("T007O73", "SELECT [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod ORDER BY [CliCod], [CliConCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O73,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O74", "SELECT [TipCCod] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O74,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O75", "SELECT [Conpcod] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O75,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O76", "SELECT [ZonCod] FROM [CZONAS] WHERE [ZonCod] = @ZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O76,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O77", "SELECT [TipLCod] AS CliTipLCod FROM [CTIPOSLISTAS] WHERE [TipLCod] = @CliTipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O77,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007O78", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007O78,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 50);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 50);
              ((string[]) buf[22])[0] = rslt.getString(22, 20);
              ((string[]) buf[23])[0] = rslt.getString(23, 50);
              ((string[]) buf[24])[0] = rslt.getString(24, 20);
              ((string[]) buf[25])[0] = rslt.getString(25, 50);
              ((string[]) buf[26])[0] = rslt.getString(26, 20);
              ((string[]) buf[27])[0] = rslt.getString(27, 50);
              ((string[]) buf[28])[0] = rslt.getString(28, 20);
              ((string[]) buf[29])[0] = rslt.getString(29, 50);
              ((string[]) buf[30])[0] = rslt.getString(30, 20);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((short[]) buf[33])[0] = rslt.getShort(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((short[]) buf[35])[0] = rslt.getShort(35);
              ((string[]) buf[36])[0] = rslt.getVarchar(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((string[]) buf[38])[0] = rslt.getVarchar(38);
              ((string[]) buf[39])[0] = rslt.getString(39, 10);
              ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(40);
              ((string[]) buf[41])[0] = rslt.getVarchar(41);
              ((string[]) buf[42])[0] = rslt.getVarchar(42);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 3);
              ((int[]) buf[45])[0] = rslt.getInt(45);
              ((string[]) buf[46])[0] = rslt.getString(46, 4);
              ((string[]) buf[47])[0] = rslt.getString(47, 4);
              ((string[]) buf[48])[0] = rslt.getString(48, 4);
              ((string[]) buf[49])[0] = rslt.getString(49, 4);
              ((int[]) buf[50])[0] = rslt.getInt(50);
              ((int[]) buf[51])[0] = rslt.getInt(51);
              ((int[]) buf[52])[0] = rslt.getInt(52);
              ((bool[]) buf[53])[0] = rslt.wasNull(52);
              ((int[]) buf[54])[0] = rslt.getInt(53);
              ((int[]) buf[55])[0] = rslt.getInt(54);
              ((int[]) buf[56])[0] = rslt.getInt(55);
              ((bool[]) buf[57])[0] = rslt.wasNull(55);
              ((string[]) buf[58])[0] = rslt.getMultimediaFile(56, rslt.getVarchar(10));
              ((bool[]) buf[59])[0] = rslt.wasNull(56);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 50);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 50);
              ((string[]) buf[22])[0] = rslt.getString(22, 20);
              ((string[]) buf[23])[0] = rslt.getString(23, 50);
              ((string[]) buf[24])[0] = rslt.getString(24, 20);
              ((string[]) buf[25])[0] = rslt.getString(25, 50);
              ((string[]) buf[26])[0] = rslt.getString(26, 20);
              ((string[]) buf[27])[0] = rslt.getString(27, 50);
              ((string[]) buf[28])[0] = rslt.getString(28, 20);
              ((string[]) buf[29])[0] = rslt.getString(29, 50);
              ((string[]) buf[30])[0] = rslt.getString(30, 20);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((short[]) buf[33])[0] = rslt.getShort(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((short[]) buf[35])[0] = rslt.getShort(35);
              ((string[]) buf[36])[0] = rslt.getVarchar(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((string[]) buf[38])[0] = rslt.getVarchar(38);
              ((string[]) buf[39])[0] = rslt.getString(39, 10);
              ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(40);
              ((string[]) buf[41])[0] = rslt.getVarchar(41);
              ((string[]) buf[42])[0] = rslt.getVarchar(42);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 3);
              ((int[]) buf[45])[0] = rslt.getInt(45);
              ((string[]) buf[46])[0] = rslt.getString(46, 4);
              ((string[]) buf[47])[0] = rslt.getString(47, 4);
              ((string[]) buf[48])[0] = rslt.getString(48, 4);
              ((string[]) buf[49])[0] = rslt.getString(49, 4);
              ((int[]) buf[50])[0] = rslt.getInt(50);
              ((int[]) buf[51])[0] = rslt.getInt(51);
              ((int[]) buf[52])[0] = rslt.getInt(52);
              ((bool[]) buf[53])[0] = rslt.wasNull(52);
              ((int[]) buf[54])[0] = rslt.getInt(53);
              ((int[]) buf[55])[0] = rslt.getInt(54);
              ((int[]) buf[56])[0] = rslt.getInt(55);
              ((bool[]) buf[57])[0] = rslt.wasNull(55);
              ((string[]) buf[58])[0] = rslt.getMultimediaFile(56, rslt.getVarchar(10));
              ((bool[]) buf[59])[0] = rslt.wasNull(56);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 100);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 50);
              ((string[]) buf[22])[0] = rslt.getString(22, 50);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((string[]) buf[24])[0] = rslt.getString(24, 50);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((string[]) buf[26])[0] = rslt.getString(26, 50);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((string[]) buf[28])[0] = rslt.getString(28, 50);
              ((string[]) buf[29])[0] = rslt.getString(29, 20);
              ((string[]) buf[30])[0] = rslt.getString(30, 50);
              ((string[]) buf[31])[0] = rslt.getString(31, 20);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((int[]) buf[33])[0] = rslt.getInt(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((short[]) buf[35])[0] = rslt.getShort(35);
              ((short[]) buf[36])[0] = rslt.getShort(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((string[]) buf[38])[0] = rslt.getVarchar(38);
              ((string[]) buf[39])[0] = rslt.getVarchar(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(41);
              ((string[]) buf[42])[0] = rslt.getVarchar(42);
              ((string[]) buf[43])[0] = rslt.getVarchar(43);
              ((int[]) buf[44])[0] = rslt.getInt(44);
              ((string[]) buf[45])[0] = rslt.getString(45, 3);
              ((int[]) buf[46])[0] = rslt.getInt(46);
              ((string[]) buf[47])[0] = rslt.getString(47, 100);
              ((string[]) buf[48])[0] = rslt.getString(48, 100);
              ((string[]) buf[49])[0] = rslt.getString(49, 100);
              ((string[]) buf[50])[0] = rslt.getString(50, 4);
              ((string[]) buf[51])[0] = rslt.getString(51, 4);
              ((string[]) buf[52])[0] = rslt.getString(52, 4);
              ((string[]) buf[53])[0] = rslt.getString(53, 4);
              ((int[]) buf[54])[0] = rslt.getInt(54);
              ((int[]) buf[55])[0] = rslt.getInt(55);
              ((int[]) buf[56])[0] = rslt.getInt(56);
              ((bool[]) buf[57])[0] = rslt.wasNull(56);
              ((int[]) buf[58])[0] = rslt.getInt(57);
              ((int[]) buf[59])[0] = rslt.getInt(58);
              ((int[]) buf[60])[0] = rslt.getInt(59);
              ((bool[]) buf[61])[0] = rslt.wasNull(59);
              ((string[]) buf[62])[0] = rslt.getMultimediaFile(60, rslt.getVarchar(10));
              ((bool[]) buf[63])[0] = rslt.wasNull(60);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 41 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 46 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 49 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 50 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 51 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 54 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 55 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 57 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 58 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 64 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 65 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 66 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              return;
           case 67 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 71 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 72 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 73 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 74 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 75 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 76 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
