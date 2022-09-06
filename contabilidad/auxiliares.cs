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
   public class auxiliares : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A70TipACod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.auxiliares.aspx")), "contabilidad.auxiliares.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.auxiliares.aspx")))) ;
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
                  AV7TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
                  AssignAttri("", false, "AV7TipACod", StringUtil.LTrimStr( (decimal)(AV7TipACod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPACOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipACod), "ZZZZZ9"), context));
                  AV8TipADCod = GetPar( "TipADCod");
                  AssignAttri("", false, "AV8TipADCod", AV8TipADCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPADCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TipADCod, "")), context));
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
            Form.Meta.addItem("description", "Auxiliares", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public auxiliares( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliares( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TipACod ,
                           string aP2_TipADCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipACod = aP1_TipACod;
         this.AV8TipADCod = aP2_TipADCod;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtipacod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktipacod_Internalname, "Tipo de Auxiliar", "", "", lblTextblocktipacod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tipacod.SetProperty("Caption", Combo_tipacod_Caption);
         ucCombo_tipacod.SetProperty("Cls", Combo_tipacod_Cls);
         ucCombo_tipacod.SetProperty("DataListProc", Combo_tipacod_Datalistproc);
         ucCombo_tipacod.SetProperty("DataListProcParametersPrefix", Combo_tipacod_Datalistprocparametersprefix);
         ucCombo_tipacod.SetProperty("EmptyItem", Combo_tipacod_Emptyitem);
         ucCombo_tipacod.SetProperty("DropDownOptionsTitleSettingsIcons", AV13DDO_TitleSettingsIcons);
         ucCombo_tipacod.SetProperty("DropDownOptionsData", AV12TipACod_Data);
         ucCombo_tipacod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tipacod_Internalname, "COMBO_TIPACODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipACod_Internalname, "Codigo T. Auxiliar", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipACod_Visible, edtTipACod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipADCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipADCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADCod_Internalname, StringUtil.RTrim( A71TipADCod), StringUtil.RTrim( context.localUtil.Format( A71TipADCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipADCod_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipADDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipADDsc_Internalname, "Auxiliar", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADDsc_Internalname, StringUtil.RTrim( A72TipADDsc), StringUtil.RTrim( context.localUtil.Format( A72TipADDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTipADDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipADSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipADSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1901TipADSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipADSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1901TipADSts), "9") : context.localUtil.Format( (decimal)(A1901TipADSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipADSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Auxiliares.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Auxiliares.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Contabilidad\\Auxiliares.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tipacod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotipacod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17ComboTipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotipacod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17ComboTipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV17ComboTipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotipacod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotipacod_Visible, edtavCombotipacod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Contabilidad\\Auxiliares.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E116N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV13DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPACOD_DATA"), AV12TipACod_Data);
               /* Read saved values. */
               Z70TipACod = (int)(context.localUtil.CToN( cgiGet( "Z70TipACod"), ".", ","));
               Z71TipADCod = cgiGet( "Z71TipADCod");
               Z72TipADDsc = cgiGet( "Z72TipADDsc");
               Z1901TipADSts = (short)(context.localUtil.CToN( cgiGet( "Z1901TipADSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TipACod = (int)(context.localUtil.CToN( cgiGet( "vTIPACOD"), ".", ","));
               AV8TipADCod = cgiGet( "vTIPADCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               Combo_tipacod_Objectcall = cgiGet( "COMBO_TIPACOD_Objectcall");
               Combo_tipacod_Class = cgiGet( "COMBO_TIPACOD_Class");
               Combo_tipacod_Icontype = cgiGet( "COMBO_TIPACOD_Icontype");
               Combo_tipacod_Icon = cgiGet( "COMBO_TIPACOD_Icon");
               Combo_tipacod_Caption = cgiGet( "COMBO_TIPACOD_Caption");
               Combo_tipacod_Tooltip = cgiGet( "COMBO_TIPACOD_Tooltip");
               Combo_tipacod_Cls = cgiGet( "COMBO_TIPACOD_Cls");
               Combo_tipacod_Selectedvalue_set = cgiGet( "COMBO_TIPACOD_Selectedvalue_set");
               Combo_tipacod_Selectedvalue_get = cgiGet( "COMBO_TIPACOD_Selectedvalue_get");
               Combo_tipacod_Selectedtext_set = cgiGet( "COMBO_TIPACOD_Selectedtext_set");
               Combo_tipacod_Selectedtext_get = cgiGet( "COMBO_TIPACOD_Selectedtext_get");
               Combo_tipacod_Gamoauthtoken = cgiGet( "COMBO_TIPACOD_Gamoauthtoken");
               Combo_tipacod_Ddointernalname = cgiGet( "COMBO_TIPACOD_Ddointernalname");
               Combo_tipacod_Titlecontrolalign = cgiGet( "COMBO_TIPACOD_Titlecontrolalign");
               Combo_tipacod_Dropdownoptionstype = cgiGet( "COMBO_TIPACOD_Dropdownoptionstype");
               Combo_tipacod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Enabled"));
               Combo_tipacod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Visible"));
               Combo_tipacod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPACOD_Titlecontrolidtoreplace");
               Combo_tipacod_Datalisttype = cgiGet( "COMBO_TIPACOD_Datalisttype");
               Combo_tipacod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Allowmultipleselection"));
               Combo_tipacod_Datalistfixedvalues = cgiGet( "COMBO_TIPACOD_Datalistfixedvalues");
               Combo_tipacod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Isgriditem"));
               Combo_tipacod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Hasdescription"));
               Combo_tipacod_Datalistproc = cgiGet( "COMBO_TIPACOD_Datalistproc");
               Combo_tipacod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPACOD_Datalistprocparametersprefix");
               Combo_tipacod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPACOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tipacod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeonlyselectedoption"));
               Combo_tipacod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeselectalloption"));
               Combo_tipacod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Emptyitem"));
               Combo_tipacod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPACOD_Includeaddnewoption"));
               Combo_tipacod_Htmltemplate = cgiGet( "COMBO_TIPACOD_Htmltemplate");
               Combo_tipacod_Multiplevaluestype = cgiGet( "COMBO_TIPACOD_Multiplevaluestype");
               Combo_tipacod_Loadingdata = cgiGet( "COMBO_TIPACOD_Loadingdata");
               Combo_tipacod_Noresultsfound = cgiGet( "COMBO_TIPACOD_Noresultsfound");
               Combo_tipacod_Emptyitemtext = cgiGet( "COMBO_TIPACOD_Emptyitemtext");
               Combo_tipacod_Onlyselectedvalues = cgiGet( "COMBO_TIPACOD_Onlyselectedvalues");
               Combo_tipacod_Selectalltext = cgiGet( "COMBO_TIPACOD_Selectalltext");
               Combo_tipacod_Multiplevaluesseparator = cgiGet( "COMBO_TIPACOD_Multiplevaluesseparator");
               Combo_tipacod_Addnewoptiontext = cgiGet( "COMBO_TIPACOD_Addnewoptiontext");
               Combo_tipacod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPACOD_Gxcontroltype"), ".", ","));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPACOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A70TipACod = 0;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               }
               else
               {
                  A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               }
               A71TipADCod = cgiGet( edtTipADCod_Internalname);
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               A72TipADDsc = cgiGet( edtTipADDsc_Internalname);
               AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPADSTS");
                  AnyError = 1;
                  GX_FocusControl = edtTipADSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1901TipADSts = 0;
                  AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
               }
               else
               {
                  A1901TipADSts = (short)(context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
               }
               AV17ComboTipACod = (int)(context.localUtil.CToN( cgiGet( edtavCombotipacod_Internalname), ".", ","));
               AssignAttri("", false, "AV17ComboTipACod", StringUtil.LTrimStr( (decimal)(AV17ComboTipACod), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Auxiliares");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("contabilidad\\auxiliares:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
                  A71TipADCod = GetPar( "TipADCod");
                  AssignAttri("", false, "A71TipADCod", A71TipADCod);
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
                     sMode56 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode56;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound56 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPACOD");
                        AnyError = 1;
                        GX_FocusControl = edtTipACod_Internalname;
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
                           E116N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126N2 ();
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
            E126N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6N56( ) ;
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
            DisableAttributes6N56( ) ;
         }
         AssignProp("", false, edtavCombotipacod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Enabled), 5, 0), true);
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

      protected void CONFIRM_6N0( )
      {
         BeforeValidate6N56( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6N56( ) ;
            }
            else
            {
               CheckExtendedTable6N56( ) ;
               CloseExtendedTableCursors6N56( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6N0( )
      {
      }

      protected void E116N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV13DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV13DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtTipACod_Visible = 0;
         AssignProp("", false, edtTipACod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipACod_Visible), 5, 0), true);
         AV17ComboTipACod = 0;
         AssignAttri("", false, "AV17ComboTipACod", StringUtil.LTrimStr( (decimal)(AV17ComboTipACod), 6, 0));
         edtavCombotipacod_Visible = 0;
         AssignProp("", false, edtavCombotipacod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPACOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E126N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV18SGAuDocGls = "Auxiliar N° " + StringUtil.Trim( A71TipADCod) + " " + StringUtil.Trim( A72TipADDsc);
            AV19Codigo = StringUtil.Trim( A71TipADCod);
            GXt_char2 = "CON";
            GXt_char3 = "";
            GXt_char4 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char2, ref  AV18SGAuDocGls, ref  AV19Codigo, ref  AV19Codigo, ref  GXt_char3, ref  GXt_char4) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("contabilidad.auxiliaresww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPACOD' Routine */
         returnInSub = false;
         GXt_char4 = AV16Combo_DataJson;
         new GeneXus.Programs.contabilidad.auxiliaresloaddvcombo(context ).execute(  "TipACod",  Gx_mode,  false,  AV7TipACod,  AV8TipADCod,  "", out  AV14ComboSelectedValue, out  AV15ComboSelectedText, out  GXt_char4) ;
         AV16Combo_DataJson = GXt_char4;
         Combo_tipacod_Selectedvalue_set = AV14ComboSelectedValue;
         ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedValue_set", Combo_tipacod_Selectedvalue_set);
         Combo_tipacod_Selectedtext_set = AV15ComboSelectedText;
         ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "SelectedText_set", Combo_tipacod_Selectedtext_set);
         AV17ComboTipACod = (int)(NumberUtil.Val( AV14ComboSelectedValue, "."));
         AssignAttri("", false, "AV17ComboTipACod", StringUtil.LTrimStr( (decimal)(AV17ComboTipACod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7TipACod) )
         {
            Combo_tipacod_Enabled = false;
            ucCombo_tipacod.SendProperty(context, "", false, Combo_tipacod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tipacod_Enabled));
         }
      }

      protected void ZM6N56( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z72TipADDsc = T006N3_A72TipADDsc[0];
               Z1901TipADSts = T006N3_A1901TipADSts[0];
            }
            else
            {
               Z72TipADDsc = A72TipADDsc;
               Z1901TipADSts = A1901TipADSts;
            }
         }
         if ( GX_JID == -11 )
         {
            Z71TipADCod = A71TipADCod;
            Z72TipADDsc = A72TipADDsc;
            Z1901TipADSts = A1901TipADSts;
            Z70TipACod = A70TipACod;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipACod) )
         {
            edtTipACod_Enabled = 0;
            AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipACod_Enabled = 1;
            AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipACod) )
         {
            edtTipACod_Enabled = 0;
            AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TipADCod)) )
         {
            A71TipADCod = AV8TipADCod;
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TipADCod)) )
         {
            edtTipADCod_Enabled = 0;
            AssignProp("", false, edtTipADCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipADCod_Enabled = 1;
            AssignProp("", false, edtTipADCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TipADCod)) )
         {
            edtTipADCod_Enabled = 0;
            AssignProp("", false, edtTipADCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipACod) )
         {
            A70TipACod = AV7TipACod;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         }
         else
         {
            A70TipACod = AV17ComboTipACod;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
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
         if ( IsIns( )  && (0==A1901TipADSts) && ( Gx_BScreen == 0 ) )
         {
            A1901TipADSts = 1;
            AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load6N56( )
      {
         /* Using cursor T006N5 */
         pr_default.execute(3, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
            A72TipADDsc = T006N5_A72TipADDsc[0];
            AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
            A1901TipADSts = T006N5_A1901TipADSts[0];
            AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
            ZM6N56( -11) ;
         }
         pr_default.close(3);
         OnLoadActions6N56( ) ;
      }

      protected void OnLoadActions6N56( )
      {
      }

      protected void CheckExtendedTable6N56( )
      {
         nIsDirty_56 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T006N4 */
         pr_default.execute(2, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( (0==A70TipACod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo T. Auxiliar", "", "", "", "", "", "", "", ""), 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A71TipADCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo Auxiliar", "", "", "", "", "", "", "", ""), 1, "TIPADCOD");
            AnyError = 1;
            GX_FocusControl = edtTipADCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A72TipADDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Auxiliar", "", "", "", "", "", "", "", ""), 1, "TIPADDSC");
            AnyError = 1;
            GX_FocusControl = edtTipADDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6N56( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A70TipACod )
      {
         /* Using cursor T006N6 */
         pr_default.execute(4, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey6N56( )
      {
         /* Using cursor T006N7 */
         pr_default.execute(5, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006N3 */
         pr_default.execute(1, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6N56( 11) ;
            RcdFound56 = 1;
            A71TipADCod = T006N3_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
            A72TipADDsc = T006N3_A72TipADDsc[0];
            AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
            A1901TipADSts = T006N3_A1901TipADSts[0];
            AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
            A70TipACod = T006N3_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            Z70TipACod = A70TipACod;
            Z71TipADCod = A71TipADCod;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6N56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey6N56( ) ;
            }
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey6N56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6N56( ) ;
         if ( RcdFound56 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound56 = 0;
         /* Using cursor T006N8 */
         pr_default.execute(6, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T006N8_A70TipACod[0] < A70TipACod ) || ( T006N8_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T006N8_A71TipADCod[0], A71TipADCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T006N8_A70TipACod[0] > A70TipACod ) || ( T006N8_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T006N8_A71TipADCod[0], A71TipADCod) > 0 ) ) )
            {
               A70TipACod = T006N8_A70TipACod[0];
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = T006N8_A71TipADCod[0];
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound56 = 0;
         /* Using cursor T006N9 */
         pr_default.execute(7, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006N9_A70TipACod[0] > A70TipACod ) || ( T006N9_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T006N9_A71TipADCod[0], A71TipADCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006N9_A70TipACod[0] < A70TipACod ) || ( T006N9_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T006N9_A71TipADCod[0], A71TipADCod) < 0 ) ) )
            {
               A70TipACod = T006N9_A70TipACod[0];
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = T006N9_A71TipADCod[0];
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6N56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6N56( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
               {
                  A70TipACod = Z70TipACod;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
                  A71TipADCod = Z71TipADCod;
                  AssignAttri("", false, "A71TipADCod", A71TipADCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPACOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6N56( ) ;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6N56( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPACOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipACod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipACod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6N56( ) ;
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
         if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
         {
            A70TipACod = Z70TipACod;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = Z71TipADCod;
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6N56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006N2 */
            pr_default.execute(0, new Object[] {A70TipACod, A71TipADCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBAUXILIARES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z72TipADDsc, T006N2_A72TipADDsc[0]) != 0 ) || ( Z1901TipADSts != T006N2_A1901TipADSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z72TipADDsc, T006N2_A72TipADDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("contabilidad.auxiliares:[seudo value changed for attri]"+"TipADDsc");
                  GXUtil.WriteLogRaw("Old: ",Z72TipADDsc);
                  GXUtil.WriteLogRaw("Current: ",T006N2_A72TipADDsc[0]);
               }
               if ( Z1901TipADSts != T006N2_A1901TipADSts[0] )
               {
                  GXUtil.WriteLog("contabilidad.auxiliares:[seudo value changed for attri]"+"TipADSts");
                  GXUtil.WriteLogRaw("Old: ",Z1901TipADSts);
                  GXUtil.WriteLogRaw("Current: ",T006N2_A1901TipADSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBAUXILIARES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6N56( )
      {
         BeforeValidate6N56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6N56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6N56( 0) ;
            CheckOptimisticConcurrency6N56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6N56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6N56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006N10 */
                     pr_default.execute(8, new Object[] {A71TipADCod, A72TipADDsc, A1901TipADSts, A70TipACod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption6N0( ) ;
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
               Load6N56( ) ;
            }
            EndLevel6N56( ) ;
         }
         CloseExtendedTableCursors6N56( ) ;
      }

      protected void Update6N56( )
      {
         BeforeValidate6N56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6N56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6N56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6N56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6N56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006N11 */
                     pr_default.execute(9, new Object[] {A72TipADDsc, A1901TipADSts, A70TipACod, A71TipADCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBAUXILIARES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6N56( ) ;
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
            EndLevel6N56( ) ;
         }
         CloseExtendedTableCursors6N56( ) ;
      }

      protected void DeferredUpdate6N56( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6N56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6N56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6N56( ) ;
            AfterConfirm6N56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6N56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006N12 */
                  pr_default.execute(10, new Object[] {A70TipACod, A71TipADCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6N56( ) ;
         Gx_mode = sMode56;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6N56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel6N56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6N56( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("contabilidad.auxiliares",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("contabilidad.auxiliares",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6N56( )
      {
         /* Scan By routine */
         /* Using cursor T006N13 */
         pr_default.execute(11);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A70TipACod = T006N13_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = T006N13_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6N56( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A70TipACod = T006N13_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = T006N13_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
         }
      }

      protected void ScanEnd6N56( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm6N56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6N56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6N56( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6N56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6N56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6N56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6N56( )
      {
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         edtTipADCod_Enabled = 0;
         AssignProp("", false, edtTipADCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADCod_Enabled), 5, 0), true);
         edtTipADDsc_Enabled = 0;
         AssignProp("", false, edtTipADDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADDsc_Enabled), 5, 0), true);
         edtTipADSts_Enabled = 0;
         AssignProp("", false, edtTipADSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADSts_Enabled), 5, 0), true);
         edtavCombotipacod_Enabled = 0;
         AssignProp("", false, edtavCombotipacod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotipacod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6N56( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264140", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipACod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TipADCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Auxiliares");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("contabilidad\\auxiliares:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71TipADCod", StringUtil.RTrim( Z71TipADCod));
         GxWebStd.gx_hidden_field( context, "Z72TipADDsc", StringUtil.RTrim( Z72TipADDsc));
         GxWebStd.gx_hidden_field( context, "Z1901TipADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1901TipADSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPACOD_DATA", AV12TipACod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPACOD_DATA", AV12TipACod_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTIPACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPACOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipACod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTIPADCOD", StringUtil.RTrim( AV8TipADCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPADCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TipADCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Objectcall", StringUtil.RTrim( Combo_tipacod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Cls", StringUtil.RTrim( Combo_tipacod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Selectedvalue_set", StringUtil.RTrim( Combo_tipacod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Selectedtext_set", StringUtil.RTrim( Combo_tipacod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Enabled", StringUtil.BoolToStr( Combo_tipacod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Datalistproc", StringUtil.RTrim( Combo_tipacod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tipacod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPACOD_Emptyitem", StringUtil.BoolToStr( Combo_tipacod_Emptyitem));
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
         GXEncryptionTmp = "contabilidad.auxiliares.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipACod,6,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TipADCod));
         return formatLink("contabilidad.auxiliares.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Contabilidad.Auxiliares" ;
      }

      public override string GetPgmdesc( )
      {
         return "Auxiliares" ;
      }

      protected void InitializeNonKey6N56( )
      {
         A72TipADDsc = "";
         AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
         A1901TipADSts = 1;
         AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
         Z72TipADDsc = "";
         Z1901TipADSts = 0;
      }

      protected void InitAll6N56( )
      {
         A70TipACod = 0;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         A71TipADCod = "";
         AssignAttri("", false, "A71TipADCod", A71TipADCod);
         InitializeNonKey6N56( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1901TipADSts = i1901TipADSts;
         AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264165", true, true);
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
         context.AddJavascriptSource("contabilidad/auxiliares.js", "?202281810264165", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblocktipacod_Internalname = "TEXTBLOCKTIPACOD";
         Combo_tipacod_Internalname = "COMBO_TIPACOD";
         edtTipACod_Internalname = "TIPACOD";
         divTablesplittedtipacod_Internalname = "TABLESPLITTEDTIPACOD";
         edtTipADCod_Internalname = "TIPADCOD";
         edtTipADDsc_Internalname = "TIPADDSC";
         edtTipADSts_Internalname = "TIPADSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotipacod_Internalname = "vCOMBOTIPACOD";
         divSectionattribute_tipacod_Internalname = "SECTIONATTRIBUTE_TIPACOD";
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
         Form.Caption = "Auxiliares";
         edtavCombotipacod_Jsonclick = "";
         edtavCombotipacod_Enabled = 0;
         edtavCombotipacod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTipADSts_Jsonclick = "";
         edtTipADSts_Enabled = 1;
         edtTipADDsc_Jsonclick = "";
         edtTipADDsc_Enabled = 1;
         edtTipADCod_Jsonclick = "";
         edtTipADCod_Enabled = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 1;
         edtTipACod_Visible = 1;
         Combo_tipacod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tipacod_Datalistprocparametersprefix = " \"ComboName\": \"TipACod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TipACod\": 0, \"TipADCod\": \"\"";
         Combo_tipacod_Datalistproc = "Contabilidad.AuxiliaresLoadDVCombo";
         Combo_tipacod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_tipacod_Caption = "";
         Combo_tipacod_Enabled = Convert.ToBoolean( -1);
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

      public void Valid_Tipacod( )
      {
         /* Using cursor T006N14 */
         pr_default.execute(12, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
         }
         pr_default.close(12);
         if ( (0==A70TipACod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo T. Auxiliar", "", "", "", "", "", "", "", ""), 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipACod',fld:'vTIPACOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipADCod',fld:'vTIPADCOD',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipACod',fld:'vTIPACOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipADCod',fld:'vTIPADCOD',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126N2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A71TipADCod',fld:'TIPADCOD',pic:''},{av:'A72TipADDsc',fld:'TIPADDSC',pic:''},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
         setEventMetadata("VALID_TIPADCOD","{handler:'Valid_Tipadcod',iparms:[]");
         setEventMetadata("VALID_TIPADCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPADDSC","{handler:'Valid_Tipaddsc',iparms:[]");
         setEventMetadata("VALID_TIPADDSC",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOTIPACOD","{handler:'Validv_Combotipacod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPACOD",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8TipADCod = "";
         Z71TipADCod = "";
         Z72TipADDsc = "";
         Combo_tipacod_Selectedvalue_get = "";
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
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblocktipacod_Jsonclick = "";
         ucCombo_tipacod = new GXUserControl();
         AV13DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TipACod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A71TipADCod = "";
         A72TipADDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Combo_tipacod_Objectcall = "";
         Combo_tipacod_Class = "";
         Combo_tipacod_Icontype = "";
         Combo_tipacod_Icon = "";
         Combo_tipacod_Tooltip = "";
         Combo_tipacod_Selectedvalue_set = "";
         Combo_tipacod_Selectedtext_set = "";
         Combo_tipacod_Selectedtext_get = "";
         Combo_tipacod_Gamoauthtoken = "";
         Combo_tipacod_Ddointernalname = "";
         Combo_tipacod_Titlecontrolalign = "";
         Combo_tipacod_Dropdownoptionstype = "";
         Combo_tipacod_Titlecontrolidtoreplace = "";
         Combo_tipacod_Datalisttype = "";
         Combo_tipacod_Datalistfixedvalues = "";
         Combo_tipacod_Htmltemplate = "";
         Combo_tipacod_Multiplevaluestype = "";
         Combo_tipacod_Loadingdata = "";
         Combo_tipacod_Noresultsfound = "";
         Combo_tipacod_Emptyitemtext = "";
         Combo_tipacod_Onlyselectedvalues = "";
         Combo_tipacod_Selectalltext = "";
         Combo_tipacod_Multiplevaluesseparator = "";
         Combo_tipacod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode56 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV18SGAuDocGls = "";
         AV19Codigo = "";
         GXt_char2 = "";
         GXt_char3 = "";
         AV16Combo_DataJson = "";
         GXt_char4 = "";
         AV14ComboSelectedValue = "";
         AV15ComboSelectedText = "";
         T006N5_A71TipADCod = new string[] {""} ;
         T006N5_A72TipADDsc = new string[] {""} ;
         T006N5_A1901TipADSts = new short[1] ;
         T006N5_A70TipACod = new int[1] ;
         T006N4_A70TipACod = new int[1] ;
         T006N6_A70TipACod = new int[1] ;
         T006N7_A70TipACod = new int[1] ;
         T006N7_A71TipADCod = new string[] {""} ;
         T006N3_A71TipADCod = new string[] {""} ;
         T006N3_A72TipADDsc = new string[] {""} ;
         T006N3_A1901TipADSts = new short[1] ;
         T006N3_A70TipACod = new int[1] ;
         T006N8_A70TipACod = new int[1] ;
         T006N8_A71TipADCod = new string[] {""} ;
         T006N9_A70TipACod = new int[1] ;
         T006N9_A71TipADCod = new string[] {""} ;
         T006N2_A71TipADCod = new string[] {""} ;
         T006N2_A72TipADDsc = new string[] {""} ;
         T006N2_A1901TipADSts = new short[1] ;
         T006N2_A70TipACod = new int[1] ;
         T006N13_A70TipACod = new int[1] ;
         T006N13_A71TipADCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T006N14_A70TipACod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliares__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliares__default(),
            new Object[][] {
                new Object[] {
               T006N2_A71TipADCod, T006N2_A72TipADDsc, T006N2_A1901TipADSts, T006N2_A70TipACod
               }
               , new Object[] {
               T006N3_A71TipADCod, T006N3_A72TipADDsc, T006N3_A1901TipADSts, T006N3_A70TipACod
               }
               , new Object[] {
               T006N4_A70TipACod
               }
               , new Object[] {
               T006N5_A71TipADCod, T006N5_A72TipADDsc, T006N5_A1901TipADSts, T006N5_A70TipACod
               }
               , new Object[] {
               T006N6_A70TipACod
               }
               , new Object[] {
               T006N7_A70TipACod, T006N7_A71TipADCod
               }
               , new Object[] {
               T006N8_A70TipACod, T006N8_A71TipADCod
               }
               , new Object[] {
               T006N9_A70TipACod, T006N9_A71TipADCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006N13_A70TipACod, T006N13_A71TipADCod
               }
               , new Object[] {
               T006N14_A70TipACod
               }
            }
         );
         Z1901TipADSts = 1;
         A1901TipADSts = 1;
         i1901TipADSts = 1;
      }

      private short Z1901TipADSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1901TipADSts ;
      private short Gx_BScreen ;
      private short RcdFound56 ;
      private short GX_JID ;
      private short nIsDirty_56 ;
      private short gxajaxcallmode ;
      private short i1901TipADSts ;
      private int wcpOAV7TipACod ;
      private int Z70TipACod ;
      private int A70TipACod ;
      private int AV7TipACod ;
      private int trnEnded ;
      private int edtTipACod_Visible ;
      private int edtTipACod_Enabled ;
      private int edtTipADCod_Enabled ;
      private int edtTipADDsc_Enabled ;
      private int edtTipADSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV17ComboTipACod ;
      private int edtavCombotipacod_Enabled ;
      private int edtavCombotipacod_Visible ;
      private int Combo_tipacod_Datalistupdateminimumcharacters ;
      private int Combo_tipacod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV8TipADCod ;
      private string Z71TipADCod ;
      private string Z72TipADDsc ;
      private string Combo_tipacod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV8TipADCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipACod_Internalname ;
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
      private string divTablesplittedtipacod_Internalname ;
      private string lblTextblocktipacod_Internalname ;
      private string lblTextblocktipacod_Jsonclick ;
      private string Combo_tipacod_Caption ;
      private string Combo_tipacod_Cls ;
      private string Combo_tipacod_Datalistproc ;
      private string Combo_tipacod_Datalistprocparametersprefix ;
      private string Combo_tipacod_Internalname ;
      private string TempTags ;
      private string edtTipACod_Jsonclick ;
      private string edtTipADCod_Internalname ;
      private string A71TipADCod ;
      private string edtTipADCod_Jsonclick ;
      private string edtTipADDsc_Internalname ;
      private string A72TipADDsc ;
      private string edtTipADDsc_Jsonclick ;
      private string edtTipADSts_Internalname ;
      private string edtTipADSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tipacod_Internalname ;
      private string edtavCombotipacod_Internalname ;
      private string edtavCombotipacod_Jsonclick ;
      private string Combo_tipacod_Objectcall ;
      private string Combo_tipacod_Class ;
      private string Combo_tipacod_Icontype ;
      private string Combo_tipacod_Icon ;
      private string Combo_tipacod_Tooltip ;
      private string Combo_tipacod_Selectedvalue_set ;
      private string Combo_tipacod_Selectedtext_set ;
      private string Combo_tipacod_Selectedtext_get ;
      private string Combo_tipacod_Gamoauthtoken ;
      private string Combo_tipacod_Ddointernalname ;
      private string Combo_tipacod_Titlecontrolalign ;
      private string Combo_tipacod_Dropdownoptionstype ;
      private string Combo_tipacod_Titlecontrolidtoreplace ;
      private string Combo_tipacod_Datalisttype ;
      private string Combo_tipacod_Datalistfixedvalues ;
      private string Combo_tipacod_Htmltemplate ;
      private string Combo_tipacod_Multiplevaluestype ;
      private string Combo_tipacod_Loadingdata ;
      private string Combo_tipacod_Noresultsfound ;
      private string Combo_tipacod_Emptyitemtext ;
      private string Combo_tipacod_Onlyselectedvalues ;
      private string Combo_tipacod_Selectalltext ;
      private string Combo_tipacod_Multiplevaluesseparator ;
      private string Combo_tipacod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode56 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_tipacod_Emptyitem ;
      private bool Combo_tipacod_Enabled ;
      private bool Combo_tipacod_Visible ;
      private bool Combo_tipacod_Allowmultipleselection ;
      private bool Combo_tipacod_Isgriditem ;
      private bool Combo_tipacod_Hasdescription ;
      private bool Combo_tipacod_Includeonlyselectedoption ;
      private bool Combo_tipacod_Includeselectalloption ;
      private bool Combo_tipacod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV16Combo_DataJson ;
      private string AV18SGAuDocGls ;
      private string AV19Codigo ;
      private string AV14ComboSelectedValue ;
      private string AV15ComboSelectedText ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tipacod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T006N5_A71TipADCod ;
      private string[] T006N5_A72TipADDsc ;
      private short[] T006N5_A1901TipADSts ;
      private int[] T006N5_A70TipACod ;
      private int[] T006N4_A70TipACod ;
      private int[] T006N6_A70TipACod ;
      private int[] T006N7_A70TipACod ;
      private string[] T006N7_A71TipADCod ;
      private string[] T006N3_A71TipADCod ;
      private string[] T006N3_A72TipADDsc ;
      private short[] T006N3_A1901TipADSts ;
      private int[] T006N3_A70TipACod ;
      private int[] T006N8_A70TipACod ;
      private string[] T006N8_A71TipADCod ;
      private int[] T006N9_A70TipACod ;
      private string[] T006N9_A71TipADCod ;
      private string[] T006N2_A71TipADCod ;
      private string[] T006N2_A72TipADDsc ;
      private short[] T006N2_A1901TipADSts ;
      private int[] T006N2_A70TipACod ;
      private int[] T006N13_A70TipACod ;
      private string[] T006N13_A71TipADCod ;
      private int[] T006N14_A70TipACod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV12TipACod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV13DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class auxiliares__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class auxiliares__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006N5;
        prmT006N5 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N4;
        prmT006N4 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT006N6;
        prmT006N6 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT006N7;
        prmT006N7 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N3;
        prmT006N3 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N8;
        prmT006N8 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N9;
        prmT006N9 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N2;
        prmT006N2 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N10;
        prmT006N10 = new Object[] {
        new ParDef("@TipADCod",GXType.NChar,20,0) ,
        new ParDef("@TipADDsc",GXType.NChar,100,0) ,
        new ParDef("@TipADSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT006N11;
        prmT006N11 = new Object[] {
        new ParDef("@TipADDsc",GXType.NChar,100,0) ,
        new ParDef("@TipADSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N12;
        prmT006N12 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT006N13;
        prmT006N13 = new Object[] {
        };
        Object[] prmT006N14;
        prmT006N14 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006N2", "SELECT [TipADCod], [TipADDsc], [TipADSts], [TipACod] FROM [CBAUXILIARES] WITH (UPDLOCK) WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N3", "SELECT [TipADCod], [TipADDsc], [TipADSts], [TipACod] FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N4", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N5", "SELECT TM1.[TipADCod], TM1.[TipADDsc], TM1.[TipADSts], TM1.[TipACod] FROM [CBAUXILIARES] TM1 WHERE TM1.[TipACod] = @TipACod and TM1.[TipADCod] = @TipADCod ORDER BY TM1.[TipACod], TM1.[TipADCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006N5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N6", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N7", "SELECT [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N8", "SELECT TOP 1 [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE ( [TipACod] > @TipACod or [TipACod] = @TipACod and [TipADCod] > @TipADCod) ORDER BY [TipACod], [TipADCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006N8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006N9", "SELECT TOP 1 [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE ( [TipACod] < @TipACod or [TipACod] = @TipACod and [TipADCod] < @TipADCod) ORDER BY [TipACod] DESC, [TipADCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006N9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006N10", "INSERT INTO [CBAUXILIARES]([TipADCod], [TipADDsc], [TipADSts], [TipACod]) VALUES(@TipADCod, @TipADDsc, @TipADSts, @TipACod)", GxErrorMask.GX_NOMASK,prmT006N10)
           ,new CursorDef("T006N11", "UPDATE [CBAUXILIARES] SET [TipADDsc]=@TipADDsc, [TipADSts]=@TipADSts  WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod", GxErrorMask.GX_NOMASK,prmT006N11)
           ,new CursorDef("T006N12", "DELETE FROM [CBAUXILIARES]  WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod", GxErrorMask.GX_NOMASK,prmT006N12)
           ,new CursorDef("T006N13", "SELECT [TipACod], [TipADCod] FROM [CBAUXILIARES] ORDER BY [TipACod], [TipADCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006N13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006N14", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006N14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
