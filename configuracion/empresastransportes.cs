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
namespace GeneXus.Programs.configuracion {
   public class empresastransportes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCEMPTCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACEMPTCOD5P78( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.empresastransportes.aspx")), "configuracion.empresastransportes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.empresastransportes.aspx")))) ;
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
                  AV7EmpTCod = (int)(NumberUtil.Val( GetPar( "EmpTCod"), "."));
                  AssignAttri("", false, "AV7EmpTCod", StringUtil.LTrimStr( (decimal)(AV7EmpTCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vEMPTCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpTCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Empresas de Transportes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpTDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public empresastransportes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public empresastransportes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_EmpTCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpTCod = aP1_EmpTCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbEmpTSts = new GXCombobox();
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
         if ( cmbEmpTSts.ItemCount > 0 )
         {
            A967EmpTSts = (short)(NumberUtil.Val( cmbEmpTSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0))), "."));
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            AssignProp("", false, cmbEmpTSts_Internalname, "Values", cmbEmpTSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmpTDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpTDsc_Internalname, "Empresa de Transporte", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTDsc_Internalname, A964EmpTDsc, StringUtil.RTrim( context.localUtil.Format( A964EmpTDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtEmpTDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmptDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmptDir_Internalname, "Dirección", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmptDir_Internalname, A963EmptDir, StringUtil.RTrim( context.localUtil.Format( A963EmptDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmptDir_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtEmptDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedemptruc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockemptruc_Internalname, "R.U.C.", "", "", lblTextblockemptruc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedemptruc_Internalname, tblTablemergedemptruc_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpTRuc_Internalname, "R.U.C.", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTRuc_Internalname, A966EmpTRuc, StringUtil.RTrim( context.localUtil.Format( A966EmpTRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTRuc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellLogin CellPaddingLogin'>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblRuc_Internalname, "Consulte RUC Aquí", "", "", lblRuc_Jsonclick, "'"+""+"'"+",false,"+"'"+"ERUC.CLICK."+"'", "", "DataDescriptionLogin", 5, "", 1, 1, 0, 1, "HLP_Configuracion\\EmpresasTransportes.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbEmpTSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEmpTSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEmpTSts, cmbEmpTSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0)), 1, cmbEmpTSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEmpTSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 1, "HLP_Configuracion\\EmpresasTransportes.htm");
         cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         AssignProp("", false, cmbEmpTSts_Internalname, "Values", (string)(cmbEmpTSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\EmpresasTransportes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\EmpresasTransportes.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EmpTCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTCod_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpTCod_Visible, edtEmpTCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\EmpresasTransportes.htm");
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
         E115P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z17EmpTCod = (int)(context.localUtil.CToN( cgiGet( "Z17EmpTCod"), ".", ","));
               Z964EmpTDsc = cgiGet( "Z964EmpTDsc");
               Z963EmptDir = cgiGet( "Z963EmptDir");
               Z966EmpTRuc = cgiGet( "Z966EmpTRuc");
               Z967EmpTSts = (short)(context.localUtil.CToN( cgiGet( "Z967EmpTSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7EmpTCod = (int)(context.localUtil.CToN( cgiGet( "vEMPTCOD"), ".", ","));
               AV11cEmpTCod = (int)(context.localUtil.CToN( cgiGet( "vCEMPTCOD"), ".", ","));
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
               /* Read variables values. */
               A964EmpTDsc = cgiGet( edtEmpTDsc_Internalname);
               AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
               A963EmptDir = cgiGet( edtEmptDir_Internalname);
               AssignAttri("", false, "A963EmptDir", A963EmptDir);
               A966EmpTRuc = cgiGet( edtEmpTRuc_Internalname);
               AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
               cmbEmpTSts.CurrentValue = cgiGet( cmbEmpTSts_Internalname);
               A967EmpTSts = (short)(NumberUtil.Val( cgiGet( cmbEmpTSts_Internalname), "."));
               AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17EmpTCod = 0;
                  n17EmpTCod = false;
                  AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               }
               else
               {
                  A17EmpTCod = (int)(context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ","));
                  n17EmpTCod = false;
                  AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"EmpresasTransportes");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A17EmpTCod != Z17EmpTCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\empresastransportes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A17EmpTCod = (int)(NumberUtil.Val( GetPar( "EmpTCod"), "."));
                  n17EmpTCod = false;
                  AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
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
                     sMode78 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode78;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound78 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPTCOD");
                        AnyError = 1;
                        GX_FocusControl = edtEmpTCod_Internalname;
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
                           E115P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "RUC.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E135P2 ();
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
            E125P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5P78( ) ;
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
            DisableAttributes5P78( ) ;
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

      protected void CONFIRM_5P0( )
      {
         BeforeValidate5P78( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5P78( ) ;
            }
            else
            {
               CheckExtendedTable5P78( ) ;
               CloseExtendedTableCursors5P78( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5P0( )
      {
      }

      protected void E115P2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtEmpTCod_Visible = 0;
         AssignProp("", false, edtEmpTCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Visible), 5, 0), true);
      }

      protected void E125P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV12SGAuDocGls = "Empresa de Transporte N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A17EmpTCod), 10, 0)) + " " + StringUtil.Trim( A964EmpTDsc);
            AV13Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A17EmpTCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV12SGAuDocGls, ref  AV13Codigo, ref  AV13Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.empresastransportesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E135P2( )
      {
         /* Ruc_Click Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A966EmpTRuc)) )
         {
            new GeneXus.Programs.configuracion.procbuscadatosruc(context ).execute(  A966EmpTRuc, out  A964EmpTDsc, out  A963EmptDir, out  AV18Estado, out  AV14EstCod, out  AV15ProvCod, out  AV16DisCod, out  AV17Condicion) ;
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            GX_msglist.addItem(StringUtil.Trim( AV18Estado)+" - "+StringUtil.Trim( AV17Condicion));
         }
         else
         {
            GX_msglist.addItem("Falta ingresar el Numero de RUC para poder validar con SUNAT.....");
         }
         /*  Sending Event outputs  */
      }

      protected void ZM5P78( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z964EmpTDsc = T005P3_A964EmpTDsc[0];
               Z963EmptDir = T005P3_A963EmptDir[0];
               Z966EmpTRuc = T005P3_A966EmpTRuc[0];
               Z967EmpTSts = T005P3_A967EmpTSts[0];
            }
            else
            {
               Z964EmpTDsc = A964EmpTDsc;
               Z963EmptDir = A963EmptDir;
               Z966EmpTRuc = A966EmpTRuc;
               Z967EmpTSts = A967EmpTSts;
            }
         }
         if ( GX_JID == -9 )
         {
            Z17EmpTCod = A17EmpTCod;
            Z964EmpTDsc = A964EmpTDsc;
            Z963EmptDir = A963EmptDir;
            Z966EmpTRuc = A966EmpTRuc;
            Z967EmpTSts = A967EmpTSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmpTCod) )
         {
            A17EmpTCod = AV7EmpTCod;
            n17EmpTCod = false;
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
         if ( ! (0==AV7EmpTCod) )
         {
            edtEmpTCod_Enabled = 0;
            AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
         }
         else
         {
            edtEmpTCod_Enabled = 1;
            AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7EmpTCod) )
         {
            edtEmpTCod_Enabled = 0;
            AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A967EmpTSts) && ( Gx_BScreen == 0 ) )
         {
            A967EmpTSts = 1;
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         }
      }

      protected void Load5P78( )
      {
         /* Using cursor T005P4 */
         pr_default.execute(2, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound78 = 1;
            A964EmpTDsc = T005P4_A964EmpTDsc[0];
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            A963EmptDir = T005P4_A963EmptDir[0];
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            A966EmpTRuc = T005P4_A966EmpTRuc[0];
            AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
            A967EmpTSts = T005P4_A967EmpTSts[0];
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            ZM5P78( -9) ;
         }
         pr_default.close(2);
         OnLoadActions5P78( ) ;
      }

      protected void OnLoadActions5P78( )
      {
      }

      protected void CheckExtendedTable5P78( )
      {
         nIsDirty_78 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A964EmpTDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Empresa de Transporte", "", "", "", "", "", "", "", ""), 1, "EMPTDSC");
            AnyError = 1;
            GX_FocusControl = edtEmpTDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A963EmptDir)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Dirección", "", "", "", "", "", "", "", ""), 1, "EMPTDIR");
            AnyError = 1;
            GX_FocusControl = edtEmptDir_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5P78( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5P78( )
      {
         /* Using cursor T005P5 */
         pr_default.execute(3, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005P3 */
         pr_default.execute(1, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5P78( 9) ;
            RcdFound78 = 1;
            A17EmpTCod = T005P3_A17EmpTCod[0];
            n17EmpTCod = T005P3_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            A964EmpTDsc = T005P3_A964EmpTDsc[0];
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            A963EmptDir = T005P3_A963EmptDir[0];
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            A966EmpTRuc = T005P3_A966EmpTRuc[0];
            AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
            A967EmpTSts = T005P3_A967EmpTSts[0];
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            Z17EmpTCod = A17EmpTCod;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5P78( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey5P78( ) ;
            }
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey5P78( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5P78( ) ;
         if ( RcdFound78 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound78 = 0;
         /* Using cursor T005P6 */
         pr_default.execute(4, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005P6_A17EmpTCod[0] < A17EmpTCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005P6_A17EmpTCod[0] > A17EmpTCod ) ) )
            {
               A17EmpTCod = T005P6_A17EmpTCod[0];
               n17EmpTCod = T005P6_n17EmpTCod[0];
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound78 = 0;
         /* Using cursor T005P7 */
         pr_default.execute(5, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005P7_A17EmpTCod[0] > A17EmpTCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005P7_A17EmpTCod[0] < A17EmpTCod ) ) )
            {
               A17EmpTCod = T005P7_A17EmpTCod[0];
               n17EmpTCod = T005P7_n17EmpTCod[0];
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5P78( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpTDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5P78( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A17EmpTCod != Z17EmpTCod )
               {
                  A17EmpTCod = Z17EmpTCod;
                  n17EmpTCod = false;
                  AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpTDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5P78( ) ;
                  GX_FocusControl = edtEmpTDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17EmpTCod != Z17EmpTCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpTDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5P78( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEmpTCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmpTDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5P78( ) ;
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
         if ( A17EmpTCod != Z17EmpTCod )
         {
            A17EmpTCod = Z17EmpTCod;
            n17EmpTCod = false;
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPTCOD");
            AnyError = 1;
            GX_FocusControl = edtEmpTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpTDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5P78( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005P2 */
            pr_default.execute(0, new Object[] {n17EmpTCod, A17EmpTCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEMPTRANSPORTE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z964EmpTDsc, T005P2_A964EmpTDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z963EmptDir, T005P2_A963EmptDir[0]) != 0 ) || ( StringUtil.StrCmp(Z966EmpTRuc, T005P2_A966EmpTRuc[0]) != 0 ) || ( Z967EmpTSts != T005P2_A967EmpTSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z964EmpTDsc, T005P2_A964EmpTDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.empresastransportes:[seudo value changed for attri]"+"EmpTDsc");
                  GXUtil.WriteLogRaw("Old: ",Z964EmpTDsc);
                  GXUtil.WriteLogRaw("Current: ",T005P2_A964EmpTDsc[0]);
               }
               if ( StringUtil.StrCmp(Z963EmptDir, T005P2_A963EmptDir[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.empresastransportes:[seudo value changed for attri]"+"EmptDir");
                  GXUtil.WriteLogRaw("Old: ",Z963EmptDir);
                  GXUtil.WriteLogRaw("Current: ",T005P2_A963EmptDir[0]);
               }
               if ( StringUtil.StrCmp(Z966EmpTRuc, T005P2_A966EmpTRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.empresastransportes:[seudo value changed for attri]"+"EmpTRuc");
                  GXUtil.WriteLogRaw("Old: ",Z966EmpTRuc);
                  GXUtil.WriteLogRaw("Current: ",T005P2_A966EmpTRuc[0]);
               }
               if ( Z967EmpTSts != T005P2_A967EmpTSts[0] )
               {
                  GXUtil.WriteLog("configuracion.empresastransportes:[seudo value changed for attri]"+"EmpTSts");
                  GXUtil.WriteLogRaw("Old: ",Z967EmpTSts);
                  GXUtil.WriteLogRaw("Current: ",T005P2_A967EmpTSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CEMPTRANSPORTE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5P78( )
      {
         BeforeValidate5P78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5P78( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5P78( 0) ;
            CheckOptimisticConcurrency5P78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5P78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5P78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005P8 */
                     pr_default.execute(6, new Object[] {n17EmpTCod, A17EmpTCod, A964EmpTDsc, A963EmptDir, A966EmpTRuc, A967EmpTSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
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
                           ResetCaption5P0( ) ;
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
               Load5P78( ) ;
            }
            EndLevel5P78( ) ;
         }
         CloseExtendedTableCursors5P78( ) ;
      }

      protected void Update5P78( )
      {
         BeforeValidate5P78( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5P78( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5P78( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5P78( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5P78( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005P9 */
                     pr_default.execute(7, new Object[] {A964EmpTDsc, A963EmptDir, A966EmpTRuc, A967EmpTSts, n17EmpTCod, A17EmpTCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEMPTRANSPORTE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5P78( ) ;
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
            EndLevel5P78( ) ;
         }
         CloseExtendedTableCursors5P78( ) ;
      }

      protected void DeferredUpdate5P78( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5P78( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5P78( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5P78( ) ;
            AfterConfirm5P78( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5P78( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005P10 */
                  pr_default.execute(8, new Object[] {n17EmpTCod, A17EmpTCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5P78( ) ;
         Gx_mode = sMode78;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5P78( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005P11 */
            pr_default.execute(9, new Object[] {n17EmpTCod, A17EmpTCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel5P78( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5P78( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.empresastransportes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.empresastransportes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5P78( )
      {
         /* Scan By routine */
         /* Using cursor T005P12 */
         pr_default.execute(10);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound78 = 1;
            A17EmpTCod = T005P12_A17EmpTCod[0];
            n17EmpTCod = T005P12_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5P78( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound78 = 1;
            A17EmpTCod = T005P12_A17EmpTCod[0];
            n17EmpTCod = T005P12_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
      }

      protected void ScanEnd5P78( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm5P78( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV11cEmpTCod;
            GXt_char3 = "EMPTRANSPO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV11cEmpTCod = (int)(GXt_int4);
            AssignAttri("", false, "AV11cEmpTCod", StringUtil.LTrimStr( (decimal)(AV11cEmpTCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A17EmpTCod = AV11cEmpTCod;
            n17EmpTCod = false;
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
      }

      protected void BeforeInsert5P78( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5P78( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5P78( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5P78( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5P78( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5P78( )
      {
         edtEmpTDsc_Enabled = 0;
         AssignProp("", false, edtEmpTDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTDsc_Enabled), 5, 0), true);
         edtEmptDir_Enabled = 0;
         AssignProp("", false, edtEmptDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmptDir_Enabled), 5, 0), true);
         edtEmpTRuc_Enabled = 0;
         AssignProp("", false, edtEmpTRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTRuc_Enabled), 5, 0), true);
         cmbEmpTSts.Enabled = 0;
         AssignProp("", false, cmbEmpTSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEmpTSts.Enabled), 5, 0), true);
         edtEmpTCod_Enabled = 0;
         AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5P78( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5P0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026856", false, true);
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
         GXEncryptionTmp = "configuracion.empresastransportes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EmpTCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.empresastransportes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"EmpresasTransportes");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\empresastransportes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z964EmpTDsc", Z964EmpTDsc);
         GxWebStd.gx_hidden_field( context, "Z963EmptDir", Z963EmptDir);
         GxWebStd.gx_hidden_field( context, "Z966EmpTRuc", Z966EmpTRuc);
         GxWebStd.gx_hidden_field( context, "Z967EmpTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z967EmpTSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vEMPTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPTCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpTCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCEMPTCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cEmpTCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.empresastransportes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7EmpTCod,6,0));
         return formatLink("configuracion.empresastransportes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.EmpresasTransportes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empresas de Transportes" ;
      }

      protected void InitializeNonKey5P78( )
      {
         AV11cEmpTCod = 0;
         AssignAttri("", false, "AV11cEmpTCod", StringUtil.LTrimStr( (decimal)(AV11cEmpTCod), 6, 0));
         A964EmpTDsc = "";
         AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
         A963EmptDir = "";
         AssignAttri("", false, "A963EmptDir", A963EmptDir);
         A966EmpTRuc = "";
         AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
         A967EmpTSts = 1;
         AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         Z964EmpTDsc = "";
         Z963EmptDir = "";
         Z966EmpTRuc = "";
         Z967EmpTSts = 0;
      }

      protected void InitAll5P78( )
      {
         A17EmpTCod = 0;
         n17EmpTCod = false;
         AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         InitializeNonKey5P78( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A967EmpTSts = i967EmpTSts;
         AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026875", true, true);
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
         context.AddJavascriptSource("configuracion/empresastransportes.js", "?20228181026875", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEmpTDsc_Internalname = "EMPTDSC";
         edtEmptDir_Internalname = "EMPTDIR";
         lblTextblockemptruc_Internalname = "TEXTBLOCKEMPTRUC";
         edtEmpTRuc_Internalname = "EMPTRUC";
         lblRuc_Internalname = "RUC";
         tblTablemergedemptruc_Internalname = "TABLEMERGEDEMPTRUC";
         divTablesplittedemptruc_Internalname = "TABLESPLITTEDEMPTRUC";
         cmbEmpTSts_Internalname = "EMPTSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEmpTCod_Internalname = "EMPTCOD";
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
         Form.Caption = "Empresas de Transportes";
         edtEmpTCod_Jsonclick = "";
         edtEmpTCod_Enabled = 1;
         edtEmpTCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbEmpTSts_Jsonclick = "";
         cmbEmpTSts.Enabled = 1;
         edtEmpTRuc_Jsonclick = "";
         edtEmpTRuc_Enabled = 1;
         edtEmptDir_Jsonclick = "";
         edtEmptDir_Enabled = 1;
         edtEmpTDsc_Jsonclick = "";
         edtEmpTDsc_Enabled = 1;
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

      protected void GX4ASACEMPTCOD5P78( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV11cEmpTCod;
            GXt_char3 = "EMPTRANSPO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV11cEmpTCod = (int)(GXt_int4);
            AssignAttri("", false, "AV11cEmpTCod", StringUtil.LTrimStr( (decimal)(AV11cEmpTCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cEmpTCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbEmpTSts.Name = "EMPTSTS";
         cmbEmpTSts.WebTags = "";
         cmbEmpTSts.addItem("1", "ACTIVO", 0);
         cmbEmpTSts.addItem("0", "INACTIVO", 0);
         if ( cmbEmpTSts.ItemCount > 0 )
         {
            if ( (0==A967EmpTSts) )
            {
               A967EmpTSts = 1;
               AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EmpTCod',fld:'vEMPTCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EmpTCod',fld:'vEMPTCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125P2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A17EmpTCod',fld:'EMPTCOD',pic:'ZZZZZ9'},{av:'A964EmpTDsc',fld:'EMPTDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("RUC.CLICK","{handler:'E135P2',iparms:[{av:'A966EmpTRuc',fld:'EMPTRUC',pic:''}]");
         setEventMetadata("RUC.CLICK",",oparms:[{av:'A963EmptDir',fld:'EMPTDIR',pic:''},{av:'A964EmpTDsc',fld:'EMPTDSC',pic:''}]}");
         setEventMetadata("VALID_EMPTDSC","{handler:'Valid_Emptdsc',iparms:[]");
         setEventMetadata("VALID_EMPTDSC",",oparms:[]}");
         setEventMetadata("VALID_EMPTDIR","{handler:'Valid_Emptdir',iparms:[]");
         setEventMetadata("VALID_EMPTDIR",",oparms:[]}");
         setEventMetadata("VALID_EMPTCOD","{handler:'Valid_Emptcod',iparms:[]");
         setEventMetadata("VALID_EMPTCOD",",oparms:[]}");
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
         wcpOGx_mode = "";
         Z964EmpTDsc = "";
         Z963EmptDir = "";
         Z966EmpTRuc = "";
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
         TempTags = "";
         A964EmpTDsc = "";
         A963EmptDir = "";
         lblTextblockemptruc_Jsonclick = "";
         sStyleString = "";
         A966EmpTRuc = "";
         lblRuc_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode78 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12SGAuDocGls = "";
         AV13Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         AV18Estado = "";
         AV14EstCod = "";
         AV15ProvCod = "";
         AV16DisCod = "";
         AV17Condicion = "";
         T005P4_A17EmpTCod = new int[1] ;
         T005P4_n17EmpTCod = new bool[] {false} ;
         T005P4_A964EmpTDsc = new string[] {""} ;
         T005P4_A963EmptDir = new string[] {""} ;
         T005P4_A966EmpTRuc = new string[] {""} ;
         T005P4_A967EmpTSts = new short[1] ;
         T005P5_A17EmpTCod = new int[1] ;
         T005P5_n17EmpTCod = new bool[] {false} ;
         T005P3_A17EmpTCod = new int[1] ;
         T005P3_n17EmpTCod = new bool[] {false} ;
         T005P3_A964EmpTDsc = new string[] {""} ;
         T005P3_A963EmptDir = new string[] {""} ;
         T005P3_A966EmpTRuc = new string[] {""} ;
         T005P3_A967EmpTSts = new short[1] ;
         T005P6_A17EmpTCod = new int[1] ;
         T005P6_n17EmpTCod = new bool[] {false} ;
         T005P7_A17EmpTCod = new int[1] ;
         T005P7_n17EmpTCod = new bool[] {false} ;
         T005P2_A17EmpTCod = new int[1] ;
         T005P2_n17EmpTCod = new bool[] {false} ;
         T005P2_A964EmpTDsc = new string[] {""} ;
         T005P2_A963EmptDir = new string[] {""} ;
         T005P2_A966EmpTRuc = new string[] {""} ;
         T005P2_A967EmpTSts = new short[1] ;
         T005P11_A13MvATip = new string[] {""} ;
         T005P11_A14MvACod = new string[] {""} ;
         T005P12_A17EmpTCod = new int[1] ;
         T005P12_n17EmpTCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.empresastransportes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.empresastransportes__default(),
            new Object[][] {
                new Object[] {
               T005P2_A17EmpTCod, T005P2_A964EmpTDsc, T005P2_A963EmptDir, T005P2_A966EmpTRuc, T005P2_A967EmpTSts
               }
               , new Object[] {
               T005P3_A17EmpTCod, T005P3_A964EmpTDsc, T005P3_A963EmptDir, T005P3_A966EmpTRuc, T005P3_A967EmpTSts
               }
               , new Object[] {
               T005P4_A17EmpTCod, T005P4_A964EmpTDsc, T005P4_A963EmptDir, T005P4_A966EmpTRuc, T005P4_A967EmpTSts
               }
               , new Object[] {
               T005P5_A17EmpTCod
               }
               , new Object[] {
               T005P6_A17EmpTCod
               }
               , new Object[] {
               T005P7_A17EmpTCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005P11_A13MvATip, T005P11_A14MvACod
               }
               , new Object[] {
               T005P12_A17EmpTCod
               }
            }
         );
         Z967EmpTSts = 1;
         A967EmpTSts = 1;
         i967EmpTSts = 1;
      }

      private short Z967EmpTSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A967EmpTSts ;
      private short Gx_BScreen ;
      private short RcdFound78 ;
      private short GX_JID ;
      private short nIsDirty_78 ;
      private short gxajaxcallmode ;
      private short i967EmpTSts ;
      private int wcpOAV7EmpTCod ;
      private int Z17EmpTCod ;
      private int AV7EmpTCod ;
      private int trnEnded ;
      private int edtEmpTDsc_Enabled ;
      private int edtEmptDir_Enabled ;
      private int edtEmpTRuc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A17EmpTCod ;
      private int edtEmpTCod_Visible ;
      private int edtEmpTCod_Enabled ;
      private int AV11cEmpTCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpTDsc_Internalname ;
      private string cmbEmpTSts_Internalname ;
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
      private string edtEmpTDsc_Jsonclick ;
      private string edtEmptDir_Internalname ;
      private string edtEmptDir_Jsonclick ;
      private string divTablesplittedemptruc_Internalname ;
      private string lblTextblockemptruc_Internalname ;
      private string lblTextblockemptruc_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedemptruc_Internalname ;
      private string edtEmpTRuc_Internalname ;
      private string edtEmpTRuc_Jsonclick ;
      private string lblRuc_Internalname ;
      private string lblRuc_Jsonclick ;
      private string cmbEmpTSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEmpTCod_Internalname ;
      private string edtEmpTCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode78 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string AV14EstCod ;
      private string AV15ProvCod ;
      private string AV16DisCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
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
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n17EmpTCod ;
      private bool returnInSub ;
      private string Z964EmpTDsc ;
      private string Z963EmptDir ;
      private string Z966EmpTRuc ;
      private string A964EmpTDsc ;
      private string A963EmptDir ;
      private string A966EmpTRuc ;
      private string AV12SGAuDocGls ;
      private string AV13Codigo ;
      private string AV18Estado ;
      private string AV17Condicion ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEmpTSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005P4_A17EmpTCod ;
      private bool[] T005P4_n17EmpTCod ;
      private string[] T005P4_A964EmpTDsc ;
      private string[] T005P4_A963EmptDir ;
      private string[] T005P4_A966EmpTRuc ;
      private short[] T005P4_A967EmpTSts ;
      private int[] T005P5_A17EmpTCod ;
      private bool[] T005P5_n17EmpTCod ;
      private int[] T005P3_A17EmpTCod ;
      private bool[] T005P3_n17EmpTCod ;
      private string[] T005P3_A964EmpTDsc ;
      private string[] T005P3_A963EmptDir ;
      private string[] T005P3_A966EmpTRuc ;
      private short[] T005P3_A967EmpTSts ;
      private int[] T005P6_A17EmpTCod ;
      private bool[] T005P6_n17EmpTCod ;
      private int[] T005P7_A17EmpTCod ;
      private bool[] T005P7_n17EmpTCod ;
      private int[] T005P2_A17EmpTCod ;
      private bool[] T005P2_n17EmpTCod ;
      private string[] T005P2_A964EmpTDsc ;
      private string[] T005P2_A963EmptDir ;
      private string[] T005P2_A966EmpTRuc ;
      private short[] T005P2_A967EmpTSts ;
      private string[] T005P11_A13MvATip ;
      private string[] T005P11_A14MvACod ;
      private int[] T005P12_A17EmpTCod ;
      private bool[] T005P12_n17EmpTCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class empresastransportes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class empresastransportes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005P4;
        prmT005P4 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P5;
        prmT005P5 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P3;
        prmT005P3 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P6;
        prmT005P6 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P7;
        prmT005P7 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P2;
        prmT005P2 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P8;
        prmT005P8 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EmpTDsc",GXType.NVarChar,100,0) ,
        new ParDef("@EmptDir",GXType.NVarChar,100,0) ,
        new ParDef("@EmpTRuc",GXType.NVarChar,20,0) ,
        new ParDef("@EmpTSts",GXType.Int16,1,0)
        };
        Object[] prmT005P9;
        prmT005P9 = new Object[] {
        new ParDef("@EmpTDsc",GXType.NVarChar,100,0) ,
        new ParDef("@EmptDir",GXType.NVarChar,100,0) ,
        new ParDef("@EmpTRuc",GXType.NVarChar,20,0) ,
        new ParDef("@EmpTSts",GXType.Int16,1,0) ,
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P10;
        prmT005P10 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P11;
        prmT005P11 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005P12;
        prmT005P12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005P2", "SELECT [EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts] FROM [CEMPTRANSPORTE] WITH (UPDLOCK) WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005P3", "SELECT [EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005P4", "SELECT TM1.[EmpTCod], TM1.[EmpTDsc], TM1.[EmptDir], TM1.[EmpTRuc], TM1.[EmpTSts] FROM [CEMPTRANSPORTE] TM1 WHERE TM1.[EmpTCod] = @EmpTCod ORDER BY TM1.[EmpTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005P4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005P5", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005P6", "SELECT TOP 1 [EmpTCod] FROM [CEMPTRANSPORTE] WHERE ( [EmpTCod] > @EmpTCod) ORDER BY [EmpTCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005P6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005P7", "SELECT TOP 1 [EmpTCod] FROM [CEMPTRANSPORTE] WHERE ( [EmpTCod] < @EmpTCod) ORDER BY [EmpTCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005P7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005P8", "INSERT INTO [CEMPTRANSPORTE]([EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts]) VALUES(@EmpTCod, @EmpTDsc, @EmptDir, @EmpTRuc, @EmpTSts)", GxErrorMask.GX_NOMASK,prmT005P8)
           ,new CursorDef("T005P9", "UPDATE [CEMPTRANSPORTE] SET [EmpTDsc]=@EmpTDsc, [EmptDir]=@EmptDir, [EmpTRuc]=@EmpTRuc, [EmpTSts]=@EmpTSts  WHERE [EmpTCod] = @EmpTCod", GxErrorMask.GX_NOMASK,prmT005P9)
           ,new CursorDef("T005P10", "DELETE FROM [CEMPTRANSPORTE]  WHERE [EmpTCod] = @EmpTCod", GxErrorMask.GX_NOMASK,prmT005P10)
           ,new CursorDef("T005P11", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005P11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005P12", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] ORDER BY [EmpTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005P12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
