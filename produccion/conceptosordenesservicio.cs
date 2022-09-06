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
namespace GeneXus.Programs.produccion {
   public class conceptosordenesservicio : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCPSERCONCCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACPSERCONCCOD6K157( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A333PSerDConcCueCod = GetPar( "PSerDConcCueCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A333PSerDConcCueCod) ;
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
            nRC_GXsfl_38 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."));
            nGXsfl_38_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."));
            sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.conceptosordenesservicio.aspx")), "produccion.conceptosordenesservicio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.conceptosordenesservicio.aspx")))) ;
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
                  AV7PSerConcCod = (int)(NumberUtil.Val( GetPar( "PSerConcCod"), "."));
                  AssignAttri("", false, "AV7PSerConcCod", StringUtil.LTrimStr( (decimal)(AV7PSerConcCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPSERCONCCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PSerConcCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Conceptos de Ordenes Servicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPSerConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public conceptosordenesservicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesservicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PSerConcCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PSerConcCod = aP1_PSerConcCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPSerConcTipo = new GXCombobox();
         cmbPSerConcSts = new GXCombobox();
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
         if ( cmbPSerConcTipo.ItemCount > 0 )
         {
            A1797PSerConcTipo = cmbPSerConcTipo.getValidValue(A1797PSerConcTipo);
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
            AssignProp("", false, cmbPSerConcTipo_Internalname, "Values", cmbPSerConcTipo.ToJavascriptSource(), true);
         }
         if ( cmbPSerConcSts.ItemCount > 0 )
         {
            A1796PSerConcSts = (short)(NumberUtil.Val( cmbPSerConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            AssignProp("", false, cmbPSerConcSts_Internalname, "Values", cmbPSerConcSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPSerConcDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPSerConcDsc_Internalname, "Concepto", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerConcDsc_Internalname, A1795PSerConcDsc, StringUtil.RTrim( context.localUtil.Format( A1795PSerConcDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerConcDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtPSerConcDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Produccion\\ConceptosOrdenesServicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPSerConcTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPSerConcTipo_Internalname, "Tipo Distribución", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPSerConcTipo, cmbPSerConcTipo_Internalname, StringUtil.RTrim( A1797PSerConcTipo), 1, cmbPSerConcTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPSerConcTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesServicio.htm");
         cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
         AssignProp("", false, cmbPSerConcTipo_Internalname, "Values", (string)(cmbPSerConcTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbPSerConcSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPSerConcSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPSerConcSts, cmbPSerConcSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0)), 1, cmbPSerConcSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPSerConcSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Produccion\\ConceptosOrdenesServicio.htm");
         cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         AssignProp("", false, cmbPSerConcSts_Internalname, "Values", (string)(cmbPSerConcSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesServicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesServicio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produccion\\ConceptosOrdenesServicio.htm");
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
         /* User Defined Control */
         ucCombo_pserdconccuecod.SetProperty("Caption", Combo_pserdconccuecod_Caption);
         ucCombo_pserdconccuecod.SetProperty("Cls", Combo_pserdconccuecod_Cls);
         ucCombo_pserdconccuecod.SetProperty("IsGridItem", Combo_pserdconccuecod_Isgriditem);
         ucCombo_pserdconccuecod.SetProperty("HasDescription", Combo_pserdconccuecod_Hasdescription);
         ucCombo_pserdconccuecod.SetProperty("DataListProc", Combo_pserdconccuecod_Datalistproc);
         ucCombo_pserdconccuecod.SetProperty("DataListProcParametersPrefix", Combo_pserdconccuecod_Datalistprocparametersprefix);
         ucCombo_pserdconccuecod.SetProperty("EmptyItem", Combo_pserdconccuecod_Emptyitem);
         ucCombo_pserdconccuecod.SetProperty("DropDownOptionsTitleSettingsIcons", AV12DDO_TitleSettingsIcons);
         ucCombo_pserdconccuecod.SetProperty("DropDownOptionsData", AV11PSerDConcCueCod_Data);
         ucCombo_pserdconccuecod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_pserdconccuecod_Internalname, "COMBO_PSERDCONCCUECODContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A332PSerConcCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A332PSerConcCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerConcCod_Jsonclick, 0, "Attribute", "", "", "", "", edtPSerConcCod_Visible, edtPSerConcCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Produccion\\ConceptosOrdenesServicio.htm");
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
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A333PSerDConcCueCod));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A1801PSerDConcCueDsc));
         Gridlevel_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0, ".", "")));
         Gridlevel_level1Container.AddColumnProperties(Gridlevel_level1Column);
         Gridlevel_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectedindex), 4, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowselection), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowhovering), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount158 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_158 = 1;
               ScanStart6K158( ) ;
               while ( RcdFound158 != 0 )
               {
                  init_level_properties158( ) ;
                  getByPrimaryKey6K158( ) ;
                  AddRow6K158( ) ;
                  ScanNext6K158( ) ;
               }
               ScanEnd6K158( ) ;
               nBlankRcdCount158 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal6K158( ) ;
            standaloneModal6K158( ) ;
            sMode158 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow6K158( ) ;
               edtPSerDConcCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PSERDCONCCUECOD_"+sGXsfl_38_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtPSerDConcCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PSERDCONCCUEDSC_"+sGXsfl_38_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPSerDConcCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               if ( ( nRcdExists_158 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal6K158( ) ;
               }
               SendRow6K158( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode158;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount158 = 5;
            nRcdExists_158 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart6K158( ) ;
               while ( RcdFound158 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_38158( ) ;
                  init_level_properties158( ) ;
                  standaloneNotModal6K158( ) ;
                  getByPrimaryKey6K158( ) ;
                  standaloneModal6K158( ) ;
                  AddRow6K158( ) ;
                  ScanNext6K158( ) ;
               }
               ScanEnd6K158( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode158 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_38158( ) ;
            InitAll6K158( ) ;
            init_level_properties158( ) ;
            nRcdExists_158 = 0;
            nIsMod_158 = 0;
            nRcdDeleted_158 = 0;
            nBlankRcdCount158 = (short)(nBlankRcdUsr158+nBlankRcdCount158);
            fRowAdded = 0;
            while ( nBlankRcdCount158 > 0 )
            {
               standaloneNotModal6K158( ) ;
               standaloneModal6K158( ) ;
               AddRow6K158( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPSerDConcCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount158 = (short)(nBlankRcdCount158-1);
            }
            Gx_mode = sMode158;
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
         E116K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV12DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPSERDCONCCUECOD_DATA"), AV11PSerDConcCueCod_Data);
               /* Read saved values. */
               Z332PSerConcCod = (int)(context.localUtil.CToN( cgiGet( "Z332PSerConcCod"), ".", ","));
               Z1795PSerConcDsc = cgiGet( "Z1795PSerConcDsc");
               Z1797PSerConcTipo = cgiGet( "Z1797PSerConcTipo");
               Z1796PSerConcSts = (short)(context.localUtil.CToN( cgiGet( "Z1796PSerConcSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","));
               AV7PSerConcCod = (int)(context.localUtil.CToN( cgiGet( "vPSERCONCCOD"), ".", ","));
               AV16cPSerConcCod = (int)(context.localUtil.CToN( cgiGet( "vCPSERCONCCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
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
               Combo_pserdconccuecod_Objectcall = cgiGet( "COMBO_PSERDCONCCUECOD_Objectcall");
               Combo_pserdconccuecod_Class = cgiGet( "COMBO_PSERDCONCCUECOD_Class");
               Combo_pserdconccuecod_Icontype = cgiGet( "COMBO_PSERDCONCCUECOD_Icontype");
               Combo_pserdconccuecod_Icon = cgiGet( "COMBO_PSERDCONCCUECOD_Icon");
               Combo_pserdconccuecod_Caption = cgiGet( "COMBO_PSERDCONCCUECOD_Caption");
               Combo_pserdconccuecod_Tooltip = cgiGet( "COMBO_PSERDCONCCUECOD_Tooltip");
               Combo_pserdconccuecod_Cls = cgiGet( "COMBO_PSERDCONCCUECOD_Cls");
               Combo_pserdconccuecod_Selectedvalue_set = cgiGet( "COMBO_PSERDCONCCUECOD_Selectedvalue_set");
               Combo_pserdconccuecod_Selectedvalue_get = cgiGet( "COMBO_PSERDCONCCUECOD_Selectedvalue_get");
               Combo_pserdconccuecod_Selectedtext_set = cgiGet( "COMBO_PSERDCONCCUECOD_Selectedtext_set");
               Combo_pserdconccuecod_Selectedtext_get = cgiGet( "COMBO_PSERDCONCCUECOD_Selectedtext_get");
               Combo_pserdconccuecod_Gamoauthtoken = cgiGet( "COMBO_PSERDCONCCUECOD_Gamoauthtoken");
               Combo_pserdconccuecod_Ddointernalname = cgiGet( "COMBO_PSERDCONCCUECOD_Ddointernalname");
               Combo_pserdconccuecod_Titlecontrolalign = cgiGet( "COMBO_PSERDCONCCUECOD_Titlecontrolalign");
               Combo_pserdconccuecod_Dropdownoptionstype = cgiGet( "COMBO_PSERDCONCCUECOD_Dropdownoptionstype");
               Combo_pserdconccuecod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Enabled"));
               Combo_pserdconccuecod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Visible"));
               Combo_pserdconccuecod_Titlecontrolidtoreplace = cgiGet( "COMBO_PSERDCONCCUECOD_Titlecontrolidtoreplace");
               Combo_pserdconccuecod_Datalisttype = cgiGet( "COMBO_PSERDCONCCUECOD_Datalisttype");
               Combo_pserdconccuecod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Allowmultipleselection"));
               Combo_pserdconccuecod_Datalistfixedvalues = cgiGet( "COMBO_PSERDCONCCUECOD_Datalistfixedvalues");
               Combo_pserdconccuecod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Isgriditem"));
               Combo_pserdconccuecod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Hasdescription"));
               Combo_pserdconccuecod_Datalistproc = cgiGet( "COMBO_PSERDCONCCUECOD_Datalistproc");
               Combo_pserdconccuecod_Datalistprocparametersprefix = cgiGet( "COMBO_PSERDCONCCUECOD_Datalistprocparametersprefix");
               Combo_pserdconccuecod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_PSERDCONCCUECOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_pserdconccuecod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Includeonlyselectedoption"));
               Combo_pserdconccuecod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Includeselectalloption"));
               Combo_pserdconccuecod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Emptyitem"));
               Combo_pserdconccuecod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PSERDCONCCUECOD_Includeaddnewoption"));
               Combo_pserdconccuecod_Htmltemplate = cgiGet( "COMBO_PSERDCONCCUECOD_Htmltemplate");
               Combo_pserdconccuecod_Multiplevaluestype = cgiGet( "COMBO_PSERDCONCCUECOD_Multiplevaluestype");
               Combo_pserdconccuecod_Loadingdata = cgiGet( "COMBO_PSERDCONCCUECOD_Loadingdata");
               Combo_pserdconccuecod_Noresultsfound = cgiGet( "COMBO_PSERDCONCCUECOD_Noresultsfound");
               Combo_pserdconccuecod_Emptyitemtext = cgiGet( "COMBO_PSERDCONCCUECOD_Emptyitemtext");
               Combo_pserdconccuecod_Onlyselectedvalues = cgiGet( "COMBO_PSERDCONCCUECOD_Onlyselectedvalues");
               Combo_pserdconccuecod_Selectalltext = cgiGet( "COMBO_PSERDCONCCUECOD_Selectalltext");
               Combo_pserdconccuecod_Multiplevaluesseparator = cgiGet( "COMBO_PSERDCONCCUECOD_Multiplevaluesseparator");
               Combo_pserdconccuecod_Addnewoptiontext = cgiGet( "COMBO_PSERDCONCCUECOD_Addnewoptiontext");
               Combo_pserdconccuecod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_PSERDCONCCUECOD_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A1795PSerConcDsc = cgiGet( edtPSerConcDsc_Internalname);
               AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
               cmbPSerConcTipo.Name = cmbPSerConcTipo_Internalname;
               cmbPSerConcTipo.CurrentValue = cgiGet( cmbPSerConcTipo_Internalname);
               A1797PSerConcTipo = cgiGet( cmbPSerConcTipo_Internalname);
               AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
               cmbPSerConcSts.Name = cmbPSerConcSts_Internalname;
               cmbPSerConcSts.CurrentValue = cgiGet( cmbPSerConcSts_Internalname);
               A1796PSerConcSts = (short)(NumberUtil.Val( cgiGet( cmbPSerConcSts_Internalname), "."));
               AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A332PSerConcCod = 0;
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               }
               else
               {
                  A332PSerConcCod = (int)(context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ","));
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptosOrdenesServicio");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A332PSerConcCod != Z332PSerConcCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("produccion\\conceptosordenesservicio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A332PSerConcCod = (int)(NumberUtil.Val( GetPar( "PSerConcCod"), "."));
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
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
                     sMode157 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode157;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound157 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PSERCONCCOD");
                        AnyError = 1;
                        GX_FocusControl = edtPSerConcCod_Internalname;
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
                           E116K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126K2 ();
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
            E126K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6K157( ) ;
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
            DisableAttributes6K157( ) ;
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

      protected void CONFIRM_6K0( )
      {
         BeforeValidate6K157( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6K157( ) ;
            }
            else
            {
               CheckExtendedTable6K157( ) ;
               CloseExtendedTableCursors6K157( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode157 = Gx_mode;
            CONFIRM_6K158( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode157;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode157;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_6K158( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow6K158( ) ;
            if ( ( nRcdExists_158 != 0 ) || ( nIsMod_158 != 0 ) )
            {
               GetKey6K158( ) ;
               if ( ( nRcdExists_158 == 0 ) && ( nRcdDeleted_158 == 0 ) )
               {
                  if ( RcdFound158 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate6K158( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable6K158( ) ;
                        CloseExtendedTableCursors6K158( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PSERDCONCCUECOD_" + sGXsfl_38_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPSerDConcCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound158 != 0 )
                  {
                     if ( nRcdDeleted_158 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey6K158( ) ;
                        Load6K158( ) ;
                        BeforeValidate6K158( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls6K158( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_158 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate6K158( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable6K158( ) ;
                              CloseExtendedTableCursors6K158( ) ;
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
                     if ( nRcdDeleted_158 == 0 )
                     {
                        GXCCtl = "PSERDCONCCUECOD_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPSerDConcCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPSerDConcCueCod_Internalname, StringUtil.RTrim( A333PSerDConcCueCod)) ;
            ChangePostValue( edtPSerDConcCueDsc_Internalname, StringUtil.RTrim( A1801PSerDConcCueDsc)) ;
            ChangePostValue( "ZT_"+"Z333PSerDConcCueCod_"+sGXsfl_38_idx, StringUtil.RTrim( Z333PSerDConcCueCod)) ;
            ChangePostValue( "nRcdDeleted_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_158), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_158), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_158), 4, 0, ".", ""))) ;
            if ( nIsMod_158 != 0 )
            {
               ChangePostValue( "PSERDCONCCUECOD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PSERDCONCCUEDSC_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption6K0( )
      {
      }

      protected void E116K2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV12DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV12DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Combo_pserdconccuecod_Titlecontrolidtoreplace = edtPSerDConcCueCod_Internalname;
         ucCombo_pserdconccuecod.SendProperty(context, "", false, Combo_pserdconccuecod_Internalname, "TitleControlIdToReplace", Combo_pserdconccuecod_Titlecontrolidtoreplace);
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtPSerConcCod_Visible = 0;
         AssignProp("", false, edtPSerConcCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Visible), 5, 0), true);
      }

      protected void E126K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("produccion.conceptosordenesservicioww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM6K157( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1795PSerConcDsc = T006K6_A1795PSerConcDsc[0];
               Z1797PSerConcTipo = T006K6_A1797PSerConcTipo[0];
               Z1796PSerConcSts = T006K6_A1796PSerConcSts[0];
            }
            else
            {
               Z1795PSerConcDsc = A1795PSerConcDsc;
               Z1797PSerConcTipo = A1797PSerConcTipo;
               Z1796PSerConcSts = A1796PSerConcSts;
            }
         }
         if ( GX_JID == -7 )
         {
            Z332PSerConcCod = A332PSerConcCod;
            Z1795PSerConcDsc = A1795PSerConcDsc;
            Z1797PSerConcTipo = A1797PSerConcTipo;
            Z1796PSerConcSts = A1796PSerConcSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PSerConcCod) )
         {
            A332PSerConcCod = AV7PSerConcCod;
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
         if ( ! (0==AV7PSerConcCod) )
         {
            edtPSerConcCod_Enabled = 0;
            AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
         }
         else
         {
            edtPSerConcCod_Enabled = 1;
            AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7PSerConcCod) )
         {
            edtPSerConcCod_Enabled = 0;
            AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1796PSerConcSts) && ( Gx_BScreen == 0 ) )
         {
            A1796PSerConcSts = 1;
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         }
      }

      protected void Load6K157( )
      {
         /* Using cursor T006K7 */
         pr_default.execute(5, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound157 = 1;
            A1795PSerConcDsc = T006K7_A1795PSerConcDsc[0];
            AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
            A1797PSerConcTipo = T006K7_A1797PSerConcTipo[0];
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
            A1796PSerConcSts = T006K7_A1796PSerConcSts[0];
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            ZM6K157( -7) ;
         }
         pr_default.close(5);
         OnLoadActions6K157( ) ;
      }

      protected void OnLoadActions6K157( )
      {
      }

      protected void CheckExtendedTable6K157( )
      {
         nIsDirty_157 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors6K157( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey6K157( )
      {
         /* Using cursor T006K8 */
         pr_default.execute(6, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound157 = 1;
         }
         else
         {
            RcdFound157 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006K6 */
         pr_default.execute(4, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM6K157( 7) ;
            RcdFound157 = 1;
            A332PSerConcCod = T006K6_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A1795PSerConcDsc = T006K6_A1795PSerConcDsc[0];
            AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
            A1797PSerConcTipo = T006K6_A1797PSerConcTipo[0];
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
            A1796PSerConcSts = T006K6_A1796PSerConcSts[0];
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            Z332PSerConcCod = A332PSerConcCod;
            sMode157 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6K157( ) ;
            if ( AnyError == 1 )
            {
               RcdFound157 = 0;
               InitializeNonKey6K157( ) ;
            }
            Gx_mode = sMode157;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound157 = 0;
            InitializeNonKey6K157( ) ;
            sMode157 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode157;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey6K157( ) ;
         if ( RcdFound157 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound157 = 0;
         /* Using cursor T006K9 */
         pr_default.execute(7, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006K9_A332PSerConcCod[0] < A332PSerConcCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006K9_A332PSerConcCod[0] > A332PSerConcCod ) ) )
            {
               A332PSerConcCod = T006K9_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               RcdFound157 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound157 = 0;
         /* Using cursor T006K10 */
         pr_default.execute(8, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T006K10_A332PSerConcCod[0] > A332PSerConcCod ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T006K10_A332PSerConcCod[0] < A332PSerConcCod ) ) )
            {
               A332PSerConcCod = T006K10_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               RcdFound157 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6K157( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6K157( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound157 == 1 )
            {
               if ( A332PSerConcCod != Z332PSerConcCod )
               {
                  A332PSerConcCod = Z332PSerConcCod;
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PSERCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPSerConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6K157( ) ;
                  GX_FocusControl = edtPSerConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A332PSerConcCod != Z332PSerConcCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtPSerConcDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6K157( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCONCCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPSerConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPSerConcDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6K157( ) ;
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
         if ( A332PSerConcCod != Z332PSerConcCod )
         {
            A332PSerConcCod = Z332PSerConcCod;
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPSerConcDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6K157( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006K5 */
            pr_default.execute(3, new Object[] {A332PSerConcCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z1795PSerConcDsc, T006K5_A1795PSerConcDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1797PSerConcTipo, T006K5_A1797PSerConcTipo[0]) != 0 ) || ( Z1796PSerConcSts != T006K5_A1796PSerConcSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1795PSerConcDsc, T006K5_A1795PSerConcDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesservicio:[seudo value changed for attri]"+"PSerConcDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1795PSerConcDsc);
                  GXUtil.WriteLogRaw("Current: ",T006K5_A1795PSerConcDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1797PSerConcTipo, T006K5_A1797PSerConcTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesservicio:[seudo value changed for attri]"+"PSerConcTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1797PSerConcTipo);
                  GXUtil.WriteLogRaw("Current: ",T006K5_A1797PSerConcTipo[0]);
               }
               if ( Z1796PSerConcSts != T006K5_A1796PSerConcSts[0] )
               {
                  GXUtil.WriteLog("produccion.conceptosordenesservicio:[seudo value changed for attri]"+"PSerConcSts");
                  GXUtil.WriteLogRaw("Old: ",Z1796PSerConcSts);
                  GXUtil.WriteLogRaw("Current: ",T006K5_A1796PSerConcSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6K157( )
      {
         BeforeValidate6K157( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6K157( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6K157( 0) ;
            CheckOptimisticConcurrency6K157( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6K157( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6K157( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006K11 */
                     pr_default.execute(9, new Object[] {A332PSerConcCod, A1795PSerConcDsc, A1797PSerConcTipo, A1796PSerConcSts});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel6K157( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption6K0( ) ;
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
               Load6K157( ) ;
            }
            EndLevel6K157( ) ;
         }
         CloseExtendedTableCursors6K157( ) ;
      }

      protected void Update6K157( )
      {
         BeforeValidate6K157( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6K157( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6K157( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6K157( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6K157( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006K12 */
                     pr_default.execute(10, new Object[] {A1795PSerConcDsc, A1797PSerConcTipo, A1796PSerConcSts, A332PSerConcCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6K157( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel6K157( ) ;
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
            EndLevel6K157( ) ;
         }
         CloseExtendedTableCursors6K157( ) ;
      }

      protected void DeferredUpdate6K157( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6K157( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6K157( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6K157( ) ;
            AfterConfirm6K157( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6K157( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart6K158( ) ;
                  while ( RcdFound158 != 0 )
                  {
                     getByPrimaryKey6K158( ) ;
                     Delete6K158( ) ;
                     ScanNext6K158( ) ;
                  }
                  ScanEnd6K158( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006K13 */
                     pr_default.execute(11, new Object[] {A332PSerConcCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
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
         sMode157 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6K157( ) ;
         Gx_mode = sMode157;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6K157( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel6K158( )
      {
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow6K158( ) ;
            if ( ( nRcdExists_158 != 0 ) || ( nIsMod_158 != 0 ) )
            {
               standaloneNotModal6K158( ) ;
               GetKey6K158( ) ;
               if ( ( nRcdExists_158 == 0 ) && ( nRcdDeleted_158 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert6K158( ) ;
               }
               else
               {
                  if ( RcdFound158 != 0 )
                  {
                     if ( ( nRcdDeleted_158 != 0 ) && ( nRcdExists_158 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete6K158( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_158 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update6K158( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_158 == 0 )
                     {
                        GXCCtl = "PSERDCONCCUECOD_" + sGXsfl_38_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPSerDConcCueCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPSerDConcCueCod_Internalname, StringUtil.RTrim( A333PSerDConcCueCod)) ;
            ChangePostValue( edtPSerDConcCueDsc_Internalname, StringUtil.RTrim( A1801PSerDConcCueDsc)) ;
            ChangePostValue( "ZT_"+"Z333PSerDConcCueCod_"+sGXsfl_38_idx, StringUtil.RTrim( Z333PSerDConcCueCod)) ;
            ChangePostValue( "nRcdDeleted_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_158), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_158), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_158_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_158), 4, 0, ".", ""))) ;
            if ( nIsMod_158 != 0 )
            {
               ChangePostValue( "PSERDCONCCUECOD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PSERDCONCCUEDSC_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll6K158( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_158 = 0;
         nIsMod_158 = 0;
         nRcdDeleted_158 = 0;
      }

      protected void ProcessLevel6K157( )
      {
         /* Save parent mode. */
         sMode157 = Gx_mode;
         ProcessNestedLevel6K158( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode157;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel6K157( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6K157( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("produccion.conceptosordenesservicio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6K0( ) ;
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
            context.RollbackDataStores("produccion.conceptosordenesservicio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6K157( )
      {
         /* Scan By routine */
         /* Using cursor T006K14 */
         pr_default.execute(12);
         RcdFound157 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound157 = 1;
            A332PSerConcCod = T006K14_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6K157( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound157 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound157 = 1;
            A332PSerConcCod = T006K14_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
      }

      protected void ScanEnd6K157( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm6K157( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int2 = AV16cPSerConcCod;
            GXt_char3 = "POSERCONCE";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int2) ;
            AV16cPSerConcCod = (int)(GXt_int2);
            AssignAttri("", false, "AV16cPSerConcCod", StringUtil.LTrimStr( (decimal)(AV16cPSerConcCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A332PSerConcCod = AV16cPSerConcCod;
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
      }

      protected void BeforeInsert6K157( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6K157( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6K157( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6K157( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6K157( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6K157( )
      {
         edtPSerConcDsc_Enabled = 0;
         AssignProp("", false, edtPSerConcDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcDsc_Enabled), 5, 0), true);
         cmbPSerConcTipo.Enabled = 0;
         AssignProp("", false, cmbPSerConcTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPSerConcTipo.Enabled), 5, 0), true);
         cmbPSerConcSts.Enabled = 0;
         AssignProp("", false, cmbPSerConcSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPSerConcSts.Enabled), 5, 0), true);
         edtPSerConcCod_Enabled = 0;
         AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
      }

      protected void ZM6K158( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -8 )
         {
            Z332PSerConcCod = A332PSerConcCod;
            Z333PSerDConcCueCod = A333PSerDConcCueCod;
            Z1801PSerDConcCueDsc = A1801PSerDConcCueDsc;
         }
      }

      protected void standaloneNotModal6K158( )
      {
      }

      protected void standaloneModal6K158( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPSerDConcCueCod_Enabled = 0;
            AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
         else
         {
            edtPSerDConcCueCod_Enabled = 1;
            AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         }
      }

      protected void Load6K158( )
      {
         /* Using cursor T006K15 */
         pr_default.execute(13, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound158 = 1;
            A1801PSerDConcCueDsc = T006K15_A1801PSerDConcCueDsc[0];
            ZM6K158( -8) ;
         }
         pr_default.close(13);
         OnLoadActions6K158( ) ;
      }

      protected void OnLoadActions6K158( )
      {
      }

      protected void CheckExtendedTable6K158( )
      {
         nIsDirty_158 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal6K158( ) ;
         /* Using cursor T006K4 */
         pr_default.execute(2, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PSERDCONCCUECOD_" + sGXsfl_38_idx;
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1801PSerDConcCueDsc = T006K4_A1801PSerDConcCueDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors6K158( )
      {
         pr_default.close(2);
      }

      protected void enableDisable6K158( )
      {
      }

      protected void gxLoad_9( string A333PSerDConcCueCod )
      {
         /* Using cursor T006K16 */
         pr_default.execute(14, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GXCCtl = "PSERDCONCCUECOD_" + sGXsfl_38_idx;
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1801PSerDConcCueDsc = T006K16_A1801PSerDConcCueDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1801PSerDConcCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey6K158( )
      {
         /* Using cursor T006K17 */
         pr_default.execute(15, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound158 = 1;
         }
         else
         {
            RcdFound158 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey6K158( )
      {
         /* Using cursor T006K3 */
         pr_default.execute(1, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6K158( 8) ;
            RcdFound158 = 1;
            InitializeNonKey6K158( ) ;
            A333PSerDConcCueCod = T006K3_A333PSerDConcCueCod[0];
            Z332PSerConcCod = A332PSerConcCod;
            Z333PSerDConcCueCod = A333PSerDConcCueCod;
            sMode158 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6K158( ) ;
            Gx_mode = sMode158;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound158 = 0;
            InitializeNonKey6K158( ) ;
            sMode158 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal6K158( ) ;
            Gx_mode = sMode158;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes6K158( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency6K158( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006K2 */
            pr_default.execute(0, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6K158( )
      {
         BeforeValidate6K158( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6K158( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6K158( 0) ;
            CheckOptimisticConcurrency6K158( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6K158( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6K158( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006K18 */
                     pr_default.execute(16, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOSDET");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load6K158( ) ;
            }
            EndLevel6K158( ) ;
         }
         CloseExtendedTableCursors6K158( ) ;
      }

      protected void Update6K158( )
      {
         BeforeValidate6K158( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6K158( ) ;
         }
         if ( ( nIsMod_158 != 0 ) || ( nIsDirty_158 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency6K158( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm6K158( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate6K158( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [POSERCONCEPTOSDET] */
                        DeferredUpdate6K158( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey6K158( ) ;
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
               EndLevel6K158( ) ;
            }
         }
         CloseExtendedTableCursors6K158( ) ;
      }

      protected void DeferredUpdate6K158( )
      {
      }

      protected void Delete6K158( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6K158( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6K158( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6K158( ) ;
            AfterConfirm6K158( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6K158( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006K19 */
                  pr_default.execute(17, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOSDET");
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
         sMode158 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6K158( ) ;
         Gx_mode = sMode158;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6K158( )
      {
         standaloneModal6K158( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006K20 */
            pr_default.execute(18, new Object[] {A333PSerDConcCueCod});
            A1801PSerDConcCueDsc = T006K20_A1801PSerDConcCueDsc[0];
            pr_default.close(18);
         }
      }

      protected void EndLevel6K158( )
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

      public void ScanStart6K158( )
      {
         /* Scan By routine */
         /* Using cursor T006K21 */
         pr_default.execute(19, new Object[] {A332PSerConcCod});
         RcdFound158 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound158 = 1;
            A333PSerDConcCueCod = T006K21_A333PSerDConcCueCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6K158( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound158 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound158 = 1;
            A333PSerDConcCueCod = T006K21_A333PSerDConcCueCod[0];
         }
      }

      protected void ScanEnd6K158( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm6K158( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6K158( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6K158( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6K158( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6K158( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6K158( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6K158( )
      {
         edtPSerDConcCueCod_Enabled = 0;
         AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtPSerDConcCueDsc_Enabled = 0;
         AssignProp("", false, edtPSerDConcCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes6K158( )
      {
      }

      protected void send_integrity_lvl_hashes6K157( )
      {
      }

      protected void SubsflControlProps_38158( )
      {
         edtPSerDConcCueCod_Internalname = "PSERDCONCCUECOD_"+sGXsfl_38_idx;
         edtPSerDConcCueDsc_Internalname = "PSERDCONCCUEDSC_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_38158( )
      {
         edtPSerDConcCueCod_Internalname = "PSERDCONCCUECOD_"+sGXsfl_38_fel_idx;
         edtPSerDConcCueDsc_Internalname = "PSERDCONCCUEDSC_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow6K158( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38158( ) ;
         SendRow6K158( ) ;
      }

      protected void SendRow6K158( )
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
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
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
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_158_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPSerDConcCueCod_Internalname,StringUtil.RTrim( A333PSerDConcCueCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPSerDConcCueCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPSerDConcCueCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPSerDConcCueDsc_Internalname,StringUtil.RTrim( A1801PSerDConcCueDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPSerDConcCueDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPSerDConcCueDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridlevel_level1Row);
         send_integrity_lvl_hashes6K158( ) ;
         GXCCtl = "Z333PSerDConcCueCod_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z333PSerDConcCueCod));
         GXCCtl = "nRcdDeleted_158_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_158), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_158_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_158), 4, 0, ".", "")));
         GXCCtl = "nIsMod_158_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_158), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_38_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPSERCONCCOD_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PSERDCONCCUECOD_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PSERDCONCCUEDSC_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_level1Container.AddRow(Gridlevel_level1Row);
      }

      protected void ReadRow6K158( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38158( ) ;
         edtPSerDConcCueCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PSERDCONCCUECOD_"+sGXsfl_38_idx+"Enabled"), ".", ","));
         edtPSerDConcCueDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PSERDCONCCUEDSC_"+sGXsfl_38_idx+"Enabled"), ".", ","));
         A333PSerDConcCueCod = cgiGet( edtPSerDConcCueCod_Internalname);
         A1801PSerDConcCueDsc = cgiGet( edtPSerDConcCueDsc_Internalname);
         GXCCtl = "Z333PSerDConcCueCod_" + sGXsfl_38_idx;
         Z333PSerDConcCueCod = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_158_" + sGXsfl_38_idx;
         nRcdDeleted_158 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_158_" + sGXsfl_38_idx;
         nRcdExists_158 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_158_" + sGXsfl_38_idx;
         nIsMod_158 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtPSerDConcCueCod_Enabled = edtPSerDConcCueCod_Enabled;
      }

      protected void ConfirmValues6K0( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_38158( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38158( ) ;
            ChangePostValue( "Z333PSerDConcCueCod_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z333PSerDConcCueCod_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z333PSerDConcCueCod_"+sGXsfl_38_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810263767", false, true);
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
         GXEncryptionTmp = "produccion.conceptosordenesservicio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PSerConcCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produccion.conceptosordenesservicio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ConceptosOrdenesServicio");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("produccion\\conceptosordenesservicio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z332PSerConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z332PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1795PSerConcDsc", Z1795PSerConcDsc);
         GxWebStd.gx_hidden_field( context, "Z1797PSerConcTipo", Z1797PSerConcTipo);
         GxWebStd.gx_hidden_field( context, "Z1796PSerConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1796PSerConcSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV12DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPSERDCONCCUECOD_DATA", AV11PSerDConcCueCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPSERDCONCCUECOD_DATA", AV11PSerDConcCueCod_Data);
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
         GxWebStd.gx_hidden_field( context, "vPSERCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPSERCONCCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PSerConcCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCPSERCONCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cPSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Objectcall", StringUtil.RTrim( Combo_pserdconccuecod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Cls", StringUtil.RTrim( Combo_pserdconccuecod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Enabled", StringUtil.BoolToStr( Combo_pserdconccuecod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_pserdconccuecod_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Isgriditem", StringUtil.BoolToStr( Combo_pserdconccuecod_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Hasdescription", StringUtil.BoolToStr( Combo_pserdconccuecod_Hasdescription));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Datalistproc", StringUtil.RTrim( Combo_pserdconccuecod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_pserdconccuecod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PSERDCONCCUECOD_Emptyitem", StringUtil.BoolToStr( Combo_pserdconccuecod_Emptyitem));
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
         GXEncryptionTmp = "produccion.conceptosordenesservicio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PSerConcCod,6,0));
         return formatLink("produccion.conceptosordenesservicio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Produccion.ConceptosOrdenesServicio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Ordenes Servicio" ;
      }

      protected void InitializeNonKey6K157( )
      {
         AV16cPSerConcCod = 0;
         AssignAttri("", false, "AV16cPSerConcCod", StringUtil.LTrimStr( (decimal)(AV16cPSerConcCod), 6, 0));
         A1795PSerConcDsc = "";
         AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
         A1797PSerConcTipo = "";
         AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         A1796PSerConcSts = 1;
         AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         Z1795PSerConcDsc = "";
         Z1797PSerConcTipo = "";
         Z1796PSerConcSts = 0;
      }

      protected void InitAll6K157( )
      {
         A332PSerConcCod = 0;
         AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         InitializeNonKey6K157( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1796PSerConcSts = i1796PSerConcSts;
         AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
      }

      protected void InitializeNonKey6K158( )
      {
         A1801PSerDConcCueDsc = "";
      }

      protected void InitAll6K158( )
      {
         A333PSerDConcCueCod = "";
         InitializeNonKey6K158( ) ;
      }

      protected void StandaloneModalInsert6K158( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810263794", true, true);
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
         context.AddJavascriptSource("produccion/conceptosordenesservicio.js", "?202281810263795", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties158( )
      {
         edtPSerDConcCueCod_Enabled = defedtPSerDConcCueCod_Enabled;
         AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void init_default_properties( )
      {
         edtPSerConcDsc_Internalname = "PSERCONCDSC";
         cmbPSerConcTipo_Internalname = "PSERCONCTIPO";
         cmbPSerConcSts_Internalname = "PSERCONCSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtPSerDConcCueCod_Internalname = "PSERDCONCCUECOD";
         edtPSerDConcCueDsc_Internalname = "PSERDCONCCUEDSC";
         divTableleaflevel_level1_Internalname = "TABLELEAFLEVEL_LEVEL1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_pserdconccuecod_Internalname = "COMBO_PSERDCONCCUECOD";
         edtPSerConcCod_Internalname = "PSERCONCCOD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
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
         Combo_pserdconccuecod_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Conceptos de Ordenes Servicio";
         edtPSerDConcCueDsc_Jsonclick = "";
         edtPSerDConcCueCod_Jsonclick = "";
         subGridlevel_level1_Class = "WorkWith";
         subGridlevel_level1_Backcolorstyle = 0;
         Combo_pserdconccuecod_Titlecontrolidtoreplace = "";
         subGridlevel_level1_Allowcollapsing = 0;
         subGridlevel_level1_Allowselection = 0;
         edtPSerDConcCueDsc_Enabled = 0;
         edtPSerDConcCueCod_Enabled = 1;
         subGridlevel_level1_Header = "";
         edtPSerConcCod_Jsonclick = "";
         edtPSerConcCod_Enabled = 1;
         edtPSerConcCod_Visible = 1;
         Combo_pserdconccuecod_Emptyitem = Convert.ToBoolean( 0);
         Combo_pserdconccuecod_Datalistprocparametersprefix = " \"ComboName\": \"PSerDConcCueCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PSerConcCod\": 0";
         Combo_pserdconccuecod_Datalistproc = "Produccion.ConceptosOrdenesServicioLoadDVCombo";
         Combo_pserdconccuecod_Hasdescription = Convert.ToBoolean( -1);
         Combo_pserdconccuecod_Isgriditem = Convert.ToBoolean( -1);
         Combo_pserdconccuecod_Cls = "ExtendedCombo";
         Combo_pserdconccuecod_Caption = "";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbPSerConcSts_Jsonclick = "";
         cmbPSerConcSts.Enabled = 1;
         cmbPSerConcTipo_Jsonclick = "";
         cmbPSerConcTipo.Enabled = 1;
         edtPSerConcDsc_Jsonclick = "";
         edtPSerConcDsc_Enabled = 1;
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

      protected void GX4ASACPSERCONCCOD6K157( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int2 = AV16cPSerConcCod;
            GXt_char3 = "POSERCONCE";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int2) ;
            AV16cPSerConcCod = (int)(GXt_int2);
            AssignAttri("", false, "AV16cPSerConcCod", StringUtil.LTrimStr( (decimal)(AV16cPSerConcCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cPSerConcCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_38158( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal6K158( ) ;
            standaloneModal6K158( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow6K158( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_38158( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_level1Container)) ;
         /* End function gxnrGridlevel_level1_newrow */
      }

      protected void init_web_controls( )
      {
         cmbPSerConcTipo.Name = "PSERCONCTIPO";
         cmbPSerConcTipo.WebTags = "";
         cmbPSerConcTipo.addItem("O", "Horas Mano de Obra", 0);
         cmbPSerConcTipo.addItem("M", "Horas Maquinas", 0);
         if ( cmbPSerConcTipo.ItemCount > 0 )
         {
            A1797PSerConcTipo = cmbPSerConcTipo.getValidValue(A1797PSerConcTipo);
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         }
         cmbPSerConcSts.Name = "PSERCONCSTS";
         cmbPSerConcSts.WebTags = "";
         cmbPSerConcSts.addItem("1", "Activo", 0);
         cmbPSerConcSts.addItem("0", "Inactivo", 0);
         if ( cmbPSerConcSts.ItemCount > 0 )
         {
            if ( (0==A1796PSerConcSts) )
            {
               A1796PSerConcSts = 1;
               AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
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

      public void Valid_Pserdconccuecod( )
      {
         /* Using cursor T006K20 */
         pr_default.execute(18, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, "PSERDCONCCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
         }
         A1801PSerDConcCueDsc = T006K20_A1801PSerDConcCueDsc[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1801PSerDConcCueDsc", StringUtil.RTrim( A1801PSerDConcCueDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PSerConcCod',fld:'vPSERCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PSerConcCod',fld:'vPSERCONCCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PSERCONCCOD","{handler:'Valid_Pserconccod',iparms:[]");
         setEventMetadata("VALID_PSERCONCCOD",",oparms:[]}");
         setEventMetadata("VALID_PSERDCONCCUECOD","{handler:'Valid_Pserdconccuecod',iparms:[{av:'A333PSerDConcCueCod',fld:'PSERDCONCCUECOD',pic:''},{av:'A1801PSerDConcCueDsc',fld:'PSERDCONCCUEDSC',pic:''}]");
         setEventMetadata("VALID_PSERDCONCCUECOD",",oparms:[{av:'A1801PSerDConcCueDsc',fld:'PSERDCONCCUEDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Pserdconccuedsc',iparms:[]");
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
         pr_default.close(18);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1795PSerConcDsc = "";
         Z1797PSerConcTipo = "";
         Z333PSerDConcCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A333PSerDConcCueCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1797PSerConcTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A1795PSerConcDsc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_pserdconccuecod = new GXUserControl();
         AV12DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11PSerDConcCueCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Gridlevel_level1Container = new GXWebGrid( context);
         Gridlevel_level1Column = new GXWebColumn();
         A1801PSerDConcCueDsc = "";
         sMode158 = "";
         sStyleString = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_pserdconccuecod_Objectcall = "";
         Combo_pserdconccuecod_Class = "";
         Combo_pserdconccuecod_Icontype = "";
         Combo_pserdconccuecod_Icon = "";
         Combo_pserdconccuecod_Tooltip = "";
         Combo_pserdconccuecod_Selectedvalue_set = "";
         Combo_pserdconccuecod_Selectedvalue_get = "";
         Combo_pserdconccuecod_Selectedtext_set = "";
         Combo_pserdconccuecod_Selectedtext_get = "";
         Combo_pserdconccuecod_Gamoauthtoken = "";
         Combo_pserdconccuecod_Ddointernalname = "";
         Combo_pserdconccuecod_Titlecontrolalign = "";
         Combo_pserdconccuecod_Dropdownoptionstype = "";
         Combo_pserdconccuecod_Datalisttype = "";
         Combo_pserdconccuecod_Datalistfixedvalues = "";
         Combo_pserdconccuecod_Htmltemplate = "";
         Combo_pserdconccuecod_Multiplevaluestype = "";
         Combo_pserdconccuecod_Loadingdata = "";
         Combo_pserdconccuecod_Noresultsfound = "";
         Combo_pserdconccuecod_Emptyitemtext = "";
         Combo_pserdconccuecod_Onlyselectedvalues = "";
         Combo_pserdconccuecod_Selectalltext = "";
         Combo_pserdconccuecod_Multiplevaluesseparator = "";
         Combo_pserdconccuecod_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode157 = "";
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
         T006K7_A332PSerConcCod = new int[1] ;
         T006K7_A1795PSerConcDsc = new string[] {""} ;
         T006K7_A1797PSerConcTipo = new string[] {""} ;
         T006K7_A1796PSerConcSts = new short[1] ;
         T006K8_A332PSerConcCod = new int[1] ;
         T006K6_A332PSerConcCod = new int[1] ;
         T006K6_A1795PSerConcDsc = new string[] {""} ;
         T006K6_A1797PSerConcTipo = new string[] {""} ;
         T006K6_A1796PSerConcSts = new short[1] ;
         T006K9_A332PSerConcCod = new int[1] ;
         T006K10_A332PSerConcCod = new int[1] ;
         T006K5_A332PSerConcCod = new int[1] ;
         T006K5_A1795PSerConcDsc = new string[] {""} ;
         T006K5_A1797PSerConcTipo = new string[] {""} ;
         T006K5_A1796PSerConcSts = new short[1] ;
         T006K14_A332PSerConcCod = new int[1] ;
         Z1801PSerDConcCueDsc = "";
         T006K15_A332PSerConcCod = new int[1] ;
         T006K15_A1801PSerDConcCueDsc = new string[] {""} ;
         T006K15_A333PSerDConcCueCod = new string[] {""} ;
         T006K4_A1801PSerDConcCueDsc = new string[] {""} ;
         T006K16_A1801PSerDConcCueDsc = new string[] {""} ;
         T006K17_A332PSerConcCod = new int[1] ;
         T006K17_A333PSerDConcCueCod = new string[] {""} ;
         T006K3_A332PSerConcCod = new int[1] ;
         T006K3_A333PSerDConcCueCod = new string[] {""} ;
         T006K2_A332PSerConcCod = new int[1] ;
         T006K2_A333PSerDConcCueCod = new string[] {""} ;
         T006K20_A1801PSerDConcCueDsc = new string[] {""} ;
         T006K21_A332PSerConcCod = new int[1] ;
         T006K21_A333PSerDConcCueCod = new string[] {""} ;
         Gridlevel_level1Row = new GXWebRow();
         subGridlevel_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesservicio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesservicio__default(),
            new Object[][] {
                new Object[] {
               T006K2_A332PSerConcCod, T006K2_A333PSerDConcCueCod
               }
               , new Object[] {
               T006K3_A332PSerConcCod, T006K3_A333PSerDConcCueCod
               }
               , new Object[] {
               T006K4_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T006K5_A332PSerConcCod, T006K5_A1795PSerConcDsc, T006K5_A1797PSerConcTipo, T006K5_A1796PSerConcSts
               }
               , new Object[] {
               T006K6_A332PSerConcCod, T006K6_A1795PSerConcDsc, T006K6_A1797PSerConcTipo, T006K6_A1796PSerConcSts
               }
               , new Object[] {
               T006K7_A332PSerConcCod, T006K7_A1795PSerConcDsc, T006K7_A1797PSerConcTipo, T006K7_A1796PSerConcSts
               }
               , new Object[] {
               T006K8_A332PSerConcCod
               }
               , new Object[] {
               T006K9_A332PSerConcCod
               }
               , new Object[] {
               T006K10_A332PSerConcCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006K14_A332PSerConcCod
               }
               , new Object[] {
               T006K15_A332PSerConcCod, T006K15_A1801PSerDConcCueDsc, T006K15_A333PSerDConcCueCod
               }
               , new Object[] {
               T006K16_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T006K17_A332PSerConcCod, T006K17_A333PSerDConcCueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006K20_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T006K21_A332PSerConcCod, T006K21_A333PSerDConcCueCod
               }
            }
         );
         Z1796PSerConcSts = 1;
         A1796PSerConcSts = 1;
         i1796PSerConcSts = 1;
      }

      private short Z1796PSerConcSts ;
      private short nRcdDeleted_158 ;
      private short nRcdExists_158 ;
      private short nIsMod_158 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1796PSerConcSts ;
      private short subGridlevel_level1_Backcolorstyle ;
      private short subGridlevel_level1_Allowselection ;
      private short subGridlevel_level1_Allowhovering ;
      private short subGridlevel_level1_Allowcollapsing ;
      private short subGridlevel_level1_Collapsed ;
      private short nBlankRcdCount158 ;
      private short RcdFound158 ;
      private short nBlankRcdUsr158 ;
      private short Gx_BScreen ;
      private short RcdFound157 ;
      private short GX_JID ;
      private short nIsDirty_157 ;
      private short nIsDirty_158 ;
      private short subGridlevel_level1_Backstyle ;
      private short gxajaxcallmode ;
      private short i1796PSerConcSts ;
      private int wcpOAV7PSerConcCod ;
      private int Z332PSerConcCod ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int AV7PSerConcCod ;
      private int trnEnded ;
      private int edtPSerConcDsc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A332PSerConcCod ;
      private int edtPSerConcCod_Visible ;
      private int edtPSerConcCod_Enabled ;
      private int edtPSerDConcCueCod_Enabled ;
      private int edtPSerDConcCueDsc_Enabled ;
      private int subGridlevel_level1_Selectedindex ;
      private int subGridlevel_level1_Selectioncolor ;
      private int subGridlevel_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int AV16cPSerConcCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_pserdconccuecod_Datalistupdateminimumcharacters ;
      private int Combo_pserdconccuecod_Gxcontroltype ;
      private int subGridlevel_level1_Backcolor ;
      private int subGridlevel_level1_Allbackcolor ;
      private int defedtPSerDConcCueCod_Enabled ;
      private int idxLst ;
      private long GRIDLEVEL_LEVEL1_nFirstRecordOnPage ;
      private long GXt_int2 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z333PSerDConcCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A333PSerDConcCueCod ;
      private string sGXsfl_38_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPSerConcDsc_Internalname ;
      private string cmbPSerConcTipo_Internalname ;
      private string cmbPSerConcSts_Internalname ;
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
      private string edtPSerConcDsc_Jsonclick ;
      private string cmbPSerConcTipo_Jsonclick ;
      private string cmbPSerConcSts_Jsonclick ;
      private string divTableleaflevel_level1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_pserdconccuecod_Caption ;
      private string Combo_pserdconccuecod_Cls ;
      private string Combo_pserdconccuecod_Datalistproc ;
      private string Combo_pserdconccuecod_Datalistprocparametersprefix ;
      private string Combo_pserdconccuecod_Internalname ;
      private string edtPSerConcCod_Internalname ;
      private string edtPSerConcCod_Jsonclick ;
      private string subGridlevel_level1_Header ;
      private string A1801PSerDConcCueDsc ;
      private string sMode158 ;
      private string edtPSerDConcCueCod_Internalname ;
      private string edtPSerDConcCueDsc_Internalname ;
      private string sStyleString ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_pserdconccuecod_Objectcall ;
      private string Combo_pserdconccuecod_Class ;
      private string Combo_pserdconccuecod_Icontype ;
      private string Combo_pserdconccuecod_Icon ;
      private string Combo_pserdconccuecod_Tooltip ;
      private string Combo_pserdconccuecod_Selectedvalue_set ;
      private string Combo_pserdconccuecod_Selectedvalue_get ;
      private string Combo_pserdconccuecod_Selectedtext_set ;
      private string Combo_pserdconccuecod_Selectedtext_get ;
      private string Combo_pserdconccuecod_Gamoauthtoken ;
      private string Combo_pserdconccuecod_Ddointernalname ;
      private string Combo_pserdconccuecod_Titlecontrolalign ;
      private string Combo_pserdconccuecod_Dropdownoptionstype ;
      private string Combo_pserdconccuecod_Titlecontrolidtoreplace ;
      private string Combo_pserdconccuecod_Datalisttype ;
      private string Combo_pserdconccuecod_Datalistfixedvalues ;
      private string Combo_pserdconccuecod_Htmltemplate ;
      private string Combo_pserdconccuecod_Multiplevaluestype ;
      private string Combo_pserdconccuecod_Loadingdata ;
      private string Combo_pserdconccuecod_Noresultsfound ;
      private string Combo_pserdconccuecod_Emptyitemtext ;
      private string Combo_pserdconccuecod_Onlyselectedvalues ;
      private string Combo_pserdconccuecod_Selectalltext ;
      private string Combo_pserdconccuecod_Multiplevaluesseparator ;
      private string Combo_pserdconccuecod_Addnewoptiontext ;
      private string hsh ;
      private string sMode157 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z1801PSerDConcCueDsc ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_level1_Class ;
      private string subGridlevel_level1_Linesclass ;
      private string ROClassString ;
      private string edtPSerDConcCueCod_Jsonclick ;
      private string edtPSerDConcCueDsc_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_level1_Internalname ;
      private string GXt_char3 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_pserdconccuecod_Isgriditem ;
      private bool Combo_pserdconccuecod_Hasdescription ;
      private bool Combo_pserdconccuecod_Emptyitem ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_pserdconccuecod_Enabled ;
      private bool Combo_pserdconccuecod_Visible ;
      private bool Combo_pserdconccuecod_Allowmultipleselection ;
      private bool Combo_pserdconccuecod_Includeonlyselectedoption ;
      private bool Combo_pserdconccuecod_Includeselectalloption ;
      private bool Combo_pserdconccuecod_Includeaddnewoption ;
      private bool returnInSub ;
      private string Z1795PSerConcDsc ;
      private string Z1797PSerConcTipo ;
      private string A1797PSerConcTipo ;
      private string A1795PSerConcDsc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_level1Container ;
      private GXWebRow Gridlevel_level1Row ;
      private GXWebColumn Gridlevel_level1Column ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_pserdconccuecod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPSerConcTipo ;
      private GXCombobox cmbPSerConcSts ;
      private IDataStoreProvider pr_default ;
      private int[] T006K7_A332PSerConcCod ;
      private string[] T006K7_A1795PSerConcDsc ;
      private string[] T006K7_A1797PSerConcTipo ;
      private short[] T006K7_A1796PSerConcSts ;
      private int[] T006K8_A332PSerConcCod ;
      private int[] T006K6_A332PSerConcCod ;
      private string[] T006K6_A1795PSerConcDsc ;
      private string[] T006K6_A1797PSerConcTipo ;
      private short[] T006K6_A1796PSerConcSts ;
      private int[] T006K9_A332PSerConcCod ;
      private int[] T006K10_A332PSerConcCod ;
      private int[] T006K5_A332PSerConcCod ;
      private string[] T006K5_A1795PSerConcDsc ;
      private string[] T006K5_A1797PSerConcTipo ;
      private short[] T006K5_A1796PSerConcSts ;
      private int[] T006K14_A332PSerConcCod ;
      private int[] T006K15_A332PSerConcCod ;
      private string[] T006K15_A1801PSerDConcCueDsc ;
      private string[] T006K15_A333PSerDConcCueCod ;
      private string[] T006K4_A1801PSerDConcCueDsc ;
      private string[] T006K16_A1801PSerDConcCueDsc ;
      private int[] T006K17_A332PSerConcCod ;
      private string[] T006K17_A333PSerDConcCueCod ;
      private int[] T006K3_A332PSerConcCod ;
      private string[] T006K3_A333PSerDConcCueCod ;
      private int[] T006K2_A332PSerConcCod ;
      private string[] T006K2_A333PSerDConcCueCod ;
      private string[] T006K20_A1801PSerDConcCueDsc ;
      private int[] T006K21_A332PSerConcCod ;
      private string[] T006K21_A333PSerDConcCueCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11PSerDConcCueCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV12DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class conceptosordenesservicio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class conceptosordenesservicio__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006K7;
        prmT006K7 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K8;
        prmT006K8 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K6;
        prmT006K6 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K9;
        prmT006K9 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K10;
        prmT006K10 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K5;
        prmT006K5 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K11;
        prmT006K11 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerConcDsc",GXType.NVarChar,100,0) ,
        new ParDef("@PSerConcTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerConcSts",GXType.Int16,1,0)
        };
        Object[] prmT006K12;
        prmT006K12 = new Object[] {
        new ParDef("@PSerConcDsc",GXType.NVarChar,100,0) ,
        new ParDef("@PSerConcTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerConcSts",GXType.Int16,1,0) ,
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K13;
        prmT006K13 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K14;
        prmT006K14 = new Object[] {
        };
        Object[] prmT006K15;
        prmT006K15 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K4;
        prmT006K4 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K16;
        prmT006K16 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K17;
        prmT006K17 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K3;
        prmT006K3 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K2;
        prmT006K2 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K18;
        prmT006K18 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K19;
        prmT006K19 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT006K21;
        prmT006K21 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT006K20;
        prmT006K20 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006K2", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WITH (UPDLOCK) WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K3", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K4", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K5", "SELECT [PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts] FROM [POSERCONCEPTOS] WITH (UPDLOCK) WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K6", "SELECT [PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K7", "SELECT TM1.[PSerConcCod], TM1.[PSerConcDsc], TM1.[PSerConcTipo], TM1.[PSerConcSts] FROM [POSERCONCEPTOS] TM1 WHERE TM1.[PSerConcCod] = @PSerConcCod ORDER BY TM1.[PSerConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006K7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K8", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K9", "SELECT TOP 1 [PSerConcCod] FROM [POSERCONCEPTOS] WHERE ( [PSerConcCod] > @PSerConcCod) ORDER BY [PSerConcCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006K9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006K10", "SELECT TOP 1 [PSerConcCod] FROM [POSERCONCEPTOS] WHERE ( [PSerConcCod] < @PSerConcCod) ORDER BY [PSerConcCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006K10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006K11", "INSERT INTO [POSERCONCEPTOS]([PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts]) VALUES(@PSerConcCod, @PSerConcDsc, @PSerConcTipo, @PSerConcSts)", GxErrorMask.GX_NOMASK,prmT006K11)
           ,new CursorDef("T006K12", "UPDATE [POSERCONCEPTOS] SET [PSerConcDsc]=@PSerConcDsc, [PSerConcTipo]=@PSerConcTipo, [PSerConcSts]=@PSerConcSts  WHERE [PSerConcCod] = @PSerConcCod", GxErrorMask.GX_NOMASK,prmT006K12)
           ,new CursorDef("T006K13", "DELETE FROM [POSERCONCEPTOS]  WHERE [PSerConcCod] = @PSerConcCod", GxErrorMask.GX_NOMASK,prmT006K13)
           ,new CursorDef("T006K14", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] ORDER BY [PSerConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006K14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K15", "SELECT T1.[PSerConcCod], T2.[CueDsc] AS PSerDConcCueDsc, T1.[PSerDConcCueCod] AS PSerDConcCueCod FROM ([POSERCONCEPTOSDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[PSerDConcCueCod]) WHERE T1.[PSerConcCod] = @PSerConcCod and T1.[PSerDConcCueCod] = @PSerDConcCueCod ORDER BY T1.[PSerConcCod], T1.[PSerDConcCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K15,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K16", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K17", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K18", "INSERT INTO [POSERCONCEPTOSDET]([PSerConcCod], [PSerDConcCueCod]) VALUES(@PSerConcCod, @PSerDConcCueCod)", GxErrorMask.GX_NOMASK,prmT006K18)
           ,new CursorDef("T006K19", "DELETE FROM [POSERCONCEPTOSDET]  WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod", GxErrorMask.GX_NOMASK,prmT006K19)
           ,new CursorDef("T006K20", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006K21", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod ORDER BY [PSerConcCod], [PSerDConcCueCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT006K21,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
     }
  }

}

}
