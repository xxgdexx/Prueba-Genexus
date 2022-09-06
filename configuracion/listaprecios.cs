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
   public class listaprecios : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"vCTIPLITEM") == 0 )
         {
            A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASACTIPLITEM6392( A202TipLCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel14"+"_"+"vVALIDA") == 0 )
         {
            A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = GetPar( "CliCod");
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX14ASAVALIDA6392( A202TipLCod, A28ProdCod, A45CliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A202TipLCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A28ProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A45CliCod = GetPar( "CliCod");
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A45CliCod) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.listaprecios.aspx")), "configuracion.listaprecios.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.listaprecios.aspx")))) ;
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
                  AV7TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
                  AssignAttri("", false, "AV7TipLCod", StringUtil.LTrimStr( (decimal)(AV7TipLCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipLCod), "ZZZZZ9"), context));
                  AV8TipLItem = (int)(NumberUtil.Val( GetPar( "TipLItem"), "."));
                  AssignAttri("", false, "AV8TipLItem", StringUtil.LTrimStr( (decimal)(AV8TipLItem), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPLITEM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TipLItem), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Lista de Precios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public listaprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listaprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TipLCod ,
                           int aP2_TipLItem )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipLCod = aP1_TipLCod;
         this.AV8TipLItem = aP2_TipLItem;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedtiplcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocktiplcod_Internalname, "Tipo de Lista", "", "", lblTextblocktiplcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_tiplcod.SetProperty("Caption", Combo_tiplcod_Caption);
         ucCombo_tiplcod.SetProperty("Cls", Combo_tiplcod_Cls);
         ucCombo_tiplcod.SetProperty("DataListProc", Combo_tiplcod_Datalistproc);
         ucCombo_tiplcod.SetProperty("DataListProcParametersPrefix", Combo_tiplcod_Datalistprocparametersprefix);
         ucCombo_tiplcod.SetProperty("EmptyItem", Combo_tiplcod_Emptyitem);
         ucCombo_tiplcod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_tiplcod.SetProperty("DropDownOptionsData", AV15TipLCod_Data);
         ucCombo_tiplcod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_tiplcod_Internalname, "COMBO_TIPLCODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipLCod_Internalname, "Codigo Tipo de Lista", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipLCod_Visible, edtTipLCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprodcod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprodcod_Internalname, "Codigo", "", "", lblTextblockprodcod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedprodcod_Internalname, tblTablemergedprodcod_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCod_Internalname, "Codigo Producto", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 1, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPrecios.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_28_Internalname, sImgUrl, imgprompt_28_Link, "", "", context.GetTheme( ), imgprompt_28_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtableproddsc_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproddsc_Internalname, "", "", "", lblTextblockproddsc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdDsc_Internalname, "Prod Dsc", "col-sm-3 AttributeRealWidth100WithLabel", 0, true, "");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "AttributeRealWidth100With", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell ExtendedComboCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclicod_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclicod_Internalname, "Cliente", "", "", lblTextblockclicod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellWidth_87_5", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clicod.SetProperty("Caption", Combo_clicod_Caption);
         ucCombo_clicod.SetProperty("Cls", Combo_clicod_Cls);
         ucCombo_clicod.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_clicod.SetProperty("DropDownOptionsData", AV23CliCod_Data);
         ucCombo_clicod.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clicod_Internalname, "COMBO_CLICODContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCod_Internalname, "Codigo Cliente", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", edtCliCod_Visible, edtCliCod_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPreLis_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPreLis_Internalname, "Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreLis_Internalname, StringUtil.LTrim( StringUtil.NToC( A1651PreLis, 17, 4, ".", "")), StringUtil.LTrim( ((edtPreLis_Enabled!=0) ? context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreLis_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreLis_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPreLisCred_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPreLisCred_Internalname, "% Factor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreLisCred_Internalname, StringUtil.LTrim( StringUtil.NToC( A1652PreLisCred, 17, 4, ".", "")), StringUtil.LTrim( ((edtPreLisCred_Enabled!=0) ? context.localUtil.Format( A1652PreLisCred, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1652PreLisCred, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreLisCred_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreLisCred_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablelisfech_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 MergeLabelCell CellWidth_12_5", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocklisfech_Internalname, "Fecha", "", "", lblTextblocklisfech_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidth_87_5", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLisFech_Internalname, "Fecha", "col-sm-3 AttributeDateLabel", 0, true, "");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtLisFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLisFech_Internalname, context.localUtil.Format(A1205LisFech, "99/99/99"), context.localUtil.Format( A1205LisFech, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLisFech_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtLisFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_bitmap( context, edtLisFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLisFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Configuracion\\ListaPrecios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\ListaPrecios.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_tiplcod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombotiplcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboTipLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCombotiplcod_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboTipLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV20ComboTipLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombotiplcod_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombotiplcod_Visible, edtavCombotiplcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_clicod_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboclicod_Internalname, StringUtil.RTrim( AV24ComboCliCod), StringUtil.RTrim( context.localUtil.Format( AV24ComboCliCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclicod_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclicod_Visible, edtavComboclicod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\ListaPrecios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A203TipLItem), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLItem_Jsonclick, 0, "Attribute", "", "", "", "", edtTipLItem_Visible, edtTipLItem_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\ListaPrecios.htm");
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
         E11632 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vTIPLCOD_DATA"), AV15TipLCod_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCLICOD_DATA"), AV23CliCod_Data);
               /* Read saved values. */
               Z202TipLCod = (int)(context.localUtil.CToN( cgiGet( "Z202TipLCod"), ".", ","));
               Z203TipLItem = (int)(context.localUtil.CToN( cgiGet( "Z203TipLItem"), ".", ","));
               Z1205LisFech = context.localUtil.CToD( cgiGet( "Z1205LisFech"), 0);
               Z1913TipLProdDsc = cgiGet( "Z1913TipLProdDsc");
               Z1651PreLis = context.localUtil.CToN( cgiGet( "Z1651PreLis"), ".", ",");
               Z1652PreLisCred = context.localUtil.CToN( cgiGet( "Z1652PreLisCred"), ".", ",");
               Z28ProdCod = cgiGet( "Z28ProdCod");
               Z45CliCod = cgiGet( "Z45CliCod");
               A1913TipLProdDsc = cgiGet( "Z1913TipLProdDsc");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N28ProdCod = cgiGet( "N28ProdCod");
               N45CliCod = cgiGet( "N45CliCod");
               AV27Tipo = cgiGet( "TIPO");
               AV7TipLCod = (int)(context.localUtil.CToN( cgiGet( "vTIPLCOD"), ".", ","));
               AV8TipLItem = (int)(context.localUtil.CToN( cgiGet( "vTIPLITEM"), ".", ","));
               AV25cTipLItem = (int)(context.localUtil.CToN( cgiGet( "vCTIPLITEM"), ".", ","));
               AV12Insert_ProdCod = cgiGet( "vINSERT_PRODCOD");
               AV13Insert_CliCod = cgiGet( "vINSERT_CLICOD");
               AV26Valida = (short)(context.localUtil.CToN( cgiGet( "vVALIDA"), ".", ","));
               A1913TipLProdDsc = cgiGet( "TIPLPRODDSC");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV27Tipo = cgiGet( "vTIPO");
               Gx_mode = cgiGet( "vMODE");
               A1912TipLDsc = cgiGet( "TIPLDSC");
               A161CliDsc = cgiGet( "CLIDSC");
               n161CliDsc = false;
               AV31Pgmname = cgiGet( "vPGMNAME");
               Combo_tiplcod_Objectcall = cgiGet( "COMBO_TIPLCOD_Objectcall");
               Combo_tiplcod_Class = cgiGet( "COMBO_TIPLCOD_Class");
               Combo_tiplcod_Icontype = cgiGet( "COMBO_TIPLCOD_Icontype");
               Combo_tiplcod_Icon = cgiGet( "COMBO_TIPLCOD_Icon");
               Combo_tiplcod_Caption = cgiGet( "COMBO_TIPLCOD_Caption");
               Combo_tiplcod_Tooltip = cgiGet( "COMBO_TIPLCOD_Tooltip");
               Combo_tiplcod_Cls = cgiGet( "COMBO_TIPLCOD_Cls");
               Combo_tiplcod_Selectedvalue_set = cgiGet( "COMBO_TIPLCOD_Selectedvalue_set");
               Combo_tiplcod_Selectedvalue_get = cgiGet( "COMBO_TIPLCOD_Selectedvalue_get");
               Combo_tiplcod_Selectedtext_set = cgiGet( "COMBO_TIPLCOD_Selectedtext_set");
               Combo_tiplcod_Selectedtext_get = cgiGet( "COMBO_TIPLCOD_Selectedtext_get");
               Combo_tiplcod_Gamoauthtoken = cgiGet( "COMBO_TIPLCOD_Gamoauthtoken");
               Combo_tiplcod_Ddointernalname = cgiGet( "COMBO_TIPLCOD_Ddointernalname");
               Combo_tiplcod_Titlecontrolalign = cgiGet( "COMBO_TIPLCOD_Titlecontrolalign");
               Combo_tiplcod_Dropdownoptionstype = cgiGet( "COMBO_TIPLCOD_Dropdownoptionstype");
               Combo_tiplcod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Enabled"));
               Combo_tiplcod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Visible"));
               Combo_tiplcod_Titlecontrolidtoreplace = cgiGet( "COMBO_TIPLCOD_Titlecontrolidtoreplace");
               Combo_tiplcod_Datalisttype = cgiGet( "COMBO_TIPLCOD_Datalisttype");
               Combo_tiplcod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Allowmultipleselection"));
               Combo_tiplcod_Datalistfixedvalues = cgiGet( "COMBO_TIPLCOD_Datalistfixedvalues");
               Combo_tiplcod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Isgriditem"));
               Combo_tiplcod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Hasdescription"));
               Combo_tiplcod_Datalistproc = cgiGet( "COMBO_TIPLCOD_Datalistproc");
               Combo_tiplcod_Datalistprocparametersprefix = cgiGet( "COMBO_TIPLCOD_Datalistprocparametersprefix");
               Combo_tiplcod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPLCOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_tiplcod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Includeonlyselectedoption"));
               Combo_tiplcod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Includeselectalloption"));
               Combo_tiplcod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Emptyitem"));
               Combo_tiplcod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_TIPLCOD_Includeaddnewoption"));
               Combo_tiplcod_Htmltemplate = cgiGet( "COMBO_TIPLCOD_Htmltemplate");
               Combo_tiplcod_Multiplevaluestype = cgiGet( "COMBO_TIPLCOD_Multiplevaluestype");
               Combo_tiplcod_Loadingdata = cgiGet( "COMBO_TIPLCOD_Loadingdata");
               Combo_tiplcod_Noresultsfound = cgiGet( "COMBO_TIPLCOD_Noresultsfound");
               Combo_tiplcod_Emptyitemtext = cgiGet( "COMBO_TIPLCOD_Emptyitemtext");
               Combo_tiplcod_Onlyselectedvalues = cgiGet( "COMBO_TIPLCOD_Onlyselectedvalues");
               Combo_tiplcod_Selectalltext = cgiGet( "COMBO_TIPLCOD_Selectalltext");
               Combo_tiplcod_Multiplevaluesseparator = cgiGet( "COMBO_TIPLCOD_Multiplevaluesseparator");
               Combo_tiplcod_Addnewoptiontext = cgiGet( "COMBO_TIPLCOD_Addnewoptiontext");
               Combo_tiplcod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_TIPLCOD_Gxcontroltype"), ".", ","));
               Combo_clicod_Objectcall = cgiGet( "COMBO_CLICOD_Objectcall");
               Combo_clicod_Class = cgiGet( "COMBO_CLICOD_Class");
               Combo_clicod_Icontype = cgiGet( "COMBO_CLICOD_Icontype");
               Combo_clicod_Icon = cgiGet( "COMBO_CLICOD_Icon");
               Combo_clicod_Caption = cgiGet( "COMBO_CLICOD_Caption");
               Combo_clicod_Tooltip = cgiGet( "COMBO_CLICOD_Tooltip");
               Combo_clicod_Cls = cgiGet( "COMBO_CLICOD_Cls");
               Combo_clicod_Selectedvalue_set = cgiGet( "COMBO_CLICOD_Selectedvalue_set");
               Combo_clicod_Selectedvalue_get = cgiGet( "COMBO_CLICOD_Selectedvalue_get");
               Combo_clicod_Selectedtext_set = cgiGet( "COMBO_CLICOD_Selectedtext_set");
               Combo_clicod_Selectedtext_get = cgiGet( "COMBO_CLICOD_Selectedtext_get");
               Combo_clicod_Gamoauthtoken = cgiGet( "COMBO_CLICOD_Gamoauthtoken");
               Combo_clicod_Ddointernalname = cgiGet( "COMBO_CLICOD_Ddointernalname");
               Combo_clicod_Titlecontrolalign = cgiGet( "COMBO_CLICOD_Titlecontrolalign");
               Combo_clicod_Dropdownoptionstype = cgiGet( "COMBO_CLICOD_Dropdownoptionstype");
               Combo_clicod_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Enabled"));
               Combo_clicod_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Visible"));
               Combo_clicod_Titlecontrolidtoreplace = cgiGet( "COMBO_CLICOD_Titlecontrolidtoreplace");
               Combo_clicod_Datalisttype = cgiGet( "COMBO_CLICOD_Datalisttype");
               Combo_clicod_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Allowmultipleselection"));
               Combo_clicod_Datalistfixedvalues = cgiGet( "COMBO_CLICOD_Datalistfixedvalues");
               Combo_clicod_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Isgriditem"));
               Combo_clicod_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Hasdescription"));
               Combo_clicod_Datalistproc = cgiGet( "COMBO_CLICOD_Datalistproc");
               Combo_clicod_Datalistprocparametersprefix = cgiGet( "COMBO_CLICOD_Datalistprocparametersprefix");
               Combo_clicod_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLICOD_Datalistupdateminimumcharacters"), ".", ","));
               Combo_clicod_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Includeonlyselectedoption"));
               Combo_clicod_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Includeselectalloption"));
               Combo_clicod_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Emptyitem"));
               Combo_clicod_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLICOD_Includeaddnewoption"));
               Combo_clicod_Htmltemplate = cgiGet( "COMBO_CLICOD_Htmltemplate");
               Combo_clicod_Multiplevaluestype = cgiGet( "COMBO_CLICOD_Multiplevaluestype");
               Combo_clicod_Loadingdata = cgiGet( "COMBO_CLICOD_Loadingdata");
               Combo_clicod_Noresultsfound = cgiGet( "COMBO_CLICOD_Noresultsfound");
               Combo_clicod_Emptyitemtext = cgiGet( "COMBO_CLICOD_Emptyitemtext");
               Combo_clicod_Onlyselectedvalues = cgiGet( "COMBO_CLICOD_Onlyselectedvalues");
               Combo_clicod_Selectalltext = cgiGet( "COMBO_CLICOD_Selectalltext");
               Combo_clicod_Multiplevaluesseparator = cgiGet( "COMBO_CLICOD_Multiplevaluesseparator");
               Combo_clicod_Addnewoptiontext = cgiGet( "COMBO_CLICOD_Addnewoptiontext");
               Combo_clicod_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_CLICOD_Gxcontroltype"), ".", ","));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A202TipLCod = 0;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               }
               else
               {
                  A202TipLCod = (int)(context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ","));
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               }
               A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A55ProdDsc = cgiGet( edtProdDsc_Internalname);
               AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
               A45CliCod = cgiGet( edtCliCod_Internalname);
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRELIS");
                  AnyError = 1;
                  GX_FocusControl = edtPreLis_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1651PreLis = 0;
                  AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
               }
               else
               {
                  A1651PreLis = context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",");
                  AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPreLisCred_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPreLisCred_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRELISCRED");
                  AnyError = 1;
                  GX_FocusControl = edtPreLisCred_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1652PreLisCred = 0;
                  AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
               }
               else
               {
                  A1652PreLisCred = context.localUtil.CToN( cgiGet( edtPreLisCred_Internalname), ".", ",");
                  AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
               }
               A1205LisFech = context.localUtil.CToD( cgiGet( edtLisFech_Internalname), 2);
               AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
               AV20ComboTipLCod = (int)(context.localUtil.CToN( cgiGet( edtavCombotiplcod_Internalname), ".", ","));
               AssignAttri("", false, "AV20ComboTipLCod", StringUtil.LTrimStr( (decimal)(AV20ComboTipLCod), 6, 0));
               AV24ComboCliCod = cgiGet( edtavComboclicod_Internalname);
               AssignAttri("", false, "AV24ComboCliCod", AV24ComboCliCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPLITEM");
                  AnyError = 1;
                  GX_FocusControl = edtTipLItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A203TipLItem = 0;
                  AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               }
               else
               {
                  A203TipLItem = (int)(context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ","));
                  AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ListaPrecios");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Tipo", StringUtil.RTrim( context.localUtil.Format( AV27Tipo, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\listaprecios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
                  A203TipLItem = (int)(NumberUtil.Val( GetPar( "TipLItem"), "."));
                  AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
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
                     sMode92 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode92;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound92 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_630( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPLCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTipLCod_Internalname;
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
                           E11632 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12632 ();
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
            E12632 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6392( ) ;
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
            DisableAttributes6392( ) ;
         }
         AssignProp("", false, edtavCombotiplcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotiplcod_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboclicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclicod_Enabled), 5, 0), true);
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

      protected void CONFIRM_630( )
      {
         BeforeValidate6392( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6392( ) ;
            }
            else
            {
               CheckExtendedTable6392( ) ;
               CloseExtendedTableCursors6392( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption630( )
      {
      }

      protected void E11632( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCliCod_Visible = 0;
         AssignProp("", false, edtCliCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliCod_Visible), 5, 0), true);
         AV24ComboCliCod = "";
         AssignAttri("", false, "AV24ComboCliCod", AV24ComboCliCod);
         edtavComboclicod_Visible = 0;
         AssignProp("", false, edtavComboclicod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclicod_Visible), 5, 0), true);
         edtTipLCod_Visible = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipLCod_Visible), 5, 0), true);
         AV20ComboTipLCod = 0;
         AssignAttri("", false, "AV20ComboTipLCod", StringUtil.LTrimStr( (decimal)(AV20ComboTipLCod), 6, 0));
         edtavCombotiplcod_Visible = 0;
         AssignProp("", false, edtavCombotiplcod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombotiplcod_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOTIPLCOD' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCLICOD' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ProdCod") == 0 )
               {
                  AV12Insert_ProdCod = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV12Insert_ProdCod", AV12Insert_ProdCod);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CliCod") == 0 )
               {
                  AV13Insert_CliCod = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV13Insert_CliCod", AV13Insert_CliCod);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CliCod)) )
                  {
                     AV24ComboCliCod = AV13Insert_CliCod;
                     AssignAttri("", false, "AV24ComboCliCod", AV24ComboCliCod);
                     Combo_clicod_Selectedvalue_set = AV24ComboCliCod;
                     ucCombo_clicod.SendProperty(context, "", false, Combo_clicod_Internalname, "SelectedValue_set", Combo_clicod_Selectedvalue_set);
                     Combo_clicod_Enabled = false;
                     ucCombo_clicod.SendProperty(context, "", false, Combo_clicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clicod_Enabled));
                  }
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
         edtTipLItem_Visible = 0;
         AssignProp("", false, edtTipLItem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipLItem_Visible), 5, 0), true);
      }

      protected void E12632( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.listapreciosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCLICOD' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.configuracion.listapreciosloaddvcombo(context ).execute(  "CliCod",  Gx_mode,  false,  AV7TipLCod,  AV8TipLItem,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AV19Combo_DataJson = GXt_char2;
         AV23CliCod_Data.FromJSonString(AV19Combo_DataJson, null);
         Combo_clicod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_clicod.SendProperty(context, "", false, Combo_clicod_Internalname, "SelectedValue_set", Combo_clicod_Selectedvalue_set);
         AV24ComboCliCod = AV17ComboSelectedValue;
         AssignAttri("", false, "AV24ComboCliCod", AV24ComboCliCod);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clicod_Enabled = false;
            ucCombo_clicod.SendProperty(context, "", false, Combo_clicod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clicod_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOTIPLCOD' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.configuracion.listapreciosloaddvcombo(context ).execute(  "TipLCod",  Gx_mode,  false,  AV7TipLCod,  AV8TipLItem,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AV19Combo_DataJson = GXt_char2;
         Combo_tiplcod_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_tiplcod.SendProperty(context, "", false, Combo_tiplcod_Internalname, "SelectedValue_set", Combo_tiplcod_Selectedvalue_set);
         Combo_tiplcod_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_tiplcod.SendProperty(context, "", false, Combo_tiplcod_Internalname, "SelectedText_set", Combo_tiplcod_Selectedtext_set);
         AV20ComboTipLCod = (int)(NumberUtil.Val( AV17ComboSelectedValue, "."));
         AssignAttri("", false, "AV20ComboTipLCod", StringUtil.LTrimStr( (decimal)(AV20ComboTipLCod), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (0==AV7TipLCod) )
         {
            Combo_tiplcod_Enabled = false;
            ucCombo_tiplcod.SendProperty(context, "", false, Combo_tiplcod_Internalname, "Enabled", StringUtil.BoolToStr( Combo_tiplcod_Enabled));
         }
      }

      protected void ZM6392( short GX_JID )
      {
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1205LisFech = T00633_A1205LisFech[0];
               Z1913TipLProdDsc = T00633_A1913TipLProdDsc[0];
               Z1651PreLis = T00633_A1651PreLis[0];
               Z1652PreLisCred = T00633_A1652PreLisCred[0];
               Z28ProdCod = T00633_A28ProdCod[0];
               Z45CliCod = T00633_A45CliCod[0];
            }
            else
            {
               Z1205LisFech = A1205LisFech;
               Z1913TipLProdDsc = A1913TipLProdDsc;
               Z1651PreLis = A1651PreLis;
               Z1652PreLisCred = A1652PreLisCred;
               Z28ProdCod = A28ProdCod;
               Z45CliCod = A45CliCod;
            }
         }
         if ( GX_JID == -25 )
         {
            Z203TipLItem = A203TipLItem;
            Z1205LisFech = A1205LisFech;
            Z1913TipLProdDsc = A1913TipLProdDsc;
            Z1651PreLis = A1651PreLis;
            Z161CliDsc = A161CliDsc;
            Z1652PreLisCred = A1652PreLisCred;
            Z202TipLCod = A202TipLCod;
            Z28ProdCod = A28ProdCod;
            Z45CliCod = A45CliCod;
            Z1912TipLDsc = A1912TipLDsc;
            Z55ProdDsc = A55ProdDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         edtLisFech_Enabled = 0;
         AssignProp("", false, edtLisFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLisFech_Enabled), 5, 0), true);
         AV31Pgmname = "Configuracion.ListaPrecios";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtLisFech_Enabled = 0;
         AssignProp("", false, edtLisFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLisFech_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipLCod) )
         {
            edtTipLCod_Enabled = 0;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipLCod_Enabled = 1;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipLCod) )
         {
            edtTipLCod_Enabled = 0;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8TipLItem) )
         {
            A203TipLItem = AV8TipLItem;
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
         if ( ! (0==AV8TipLItem) )
         {
            edtTipLItem_Enabled = 0;
            AssignProp("", false, edtTipLItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLItem_Enabled), 5, 0), true);
         }
         else
         {
            edtTipLItem_Enabled = 1;
            AssignProp("", false, edtTipLItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLItem_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8TipLItem) )
         {
            edtTipLItem_Enabled = 0;
            AssignProp("", false, edtTipLItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLItem_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipLCod) )
         {
            A202TipLCod = AV7TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
         else
         {
            A202TipLCod = AV20ComboTipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_ProdCod)) )
         {
            edtProdCod_Enabled = 0;
            AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         }
         else
         {
            edtProdCod_Enabled = 1;
            AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CliCod)) )
         {
            edtCliCod_Enabled = 0;
            AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         }
         else
         {
            edtCliCod_Enabled = 1;
            AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_ProdCod)) )
         {
            A28ProdCod = AV12Insert_ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Insert_CliCod)) )
         {
            A45CliCod = AV13Insert_CliCod;
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24ComboCliCod)) )
            {
               A45CliCod = "";
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               n45CliCod = true;
               AssignAttri("", false, "A45CliCod", A45CliCod);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ComboCliCod)) )
               {
                  A45CliCod = AV24ComboCliCod;
                  n45CliCod = false;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
               }
            }
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( AV27Tipo)) && ( Gx_BScreen == 0 ) )
         {
            AV27Tipo = "V";
            AssignAttri("", false, "AV27Tipo", AV27Tipo);
         }
         imgprompt_28_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"generales.wwbusquedaproducto.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODCOD"+"'), id:'"+"PRODCOD"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"PRODDSC"+"'), id:'"+"PRODDSC"+"'"+",IOType:'out'}"+","+"'"+GXUtil.ValueEncode( StringUtil.StringReplace( AV27Tipo, "'", "\\'"))+"'"+"],"+"null"+","+"'', false"+","+"false"+");");
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00634 */
            pr_default.execute(2, new Object[] {A202TipLCod});
            A1912TipLDsc = T00634_A1912TipLDsc[0];
            pr_default.close(2);
            /* Using cursor T00635 */
            pr_default.execute(3, new Object[] {A28ProdCod});
            A55ProdDsc = T00635_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            pr_default.close(3);
            A1913TipLProdDsc = A55ProdDsc;
            AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
            /* Using cursor T00636 */
            pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
            A161CliDsc = T00636_A161CliDsc[0];
            n161CliDsc = T00636_n161CliDsc[0];
            pr_default.close(4);
            GXt_int3 = AV26Valida;
            new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            AV26Valida = GXt_int3;
            AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         }
      }

      protected void Load6392( )
      {
         /* Using cursor T00637 */
         pr_default.execute(5, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound92 = 1;
            A1205LisFech = T00637_A1205LisFech[0];
            AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            A1913TipLProdDsc = T00637_A1913TipLProdDsc[0];
            A55ProdDsc = T00637_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1912TipLDsc = T00637_A1912TipLDsc[0];
            A1651PreLis = T00637_A1651PreLis[0];
            AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            A161CliDsc = T00637_A161CliDsc[0];
            n161CliDsc = T00637_n161CliDsc[0];
            A1652PreLisCred = T00637_A1652PreLisCred[0];
            AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
            A28ProdCod = T00637_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = T00637_A45CliCod[0];
            n45CliCod = T00637_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            ZM6392( -25) ;
         }
         pr_default.close(5);
         OnLoadActions6392( ) ;
      }

      protected void OnLoadActions6392( )
      {
         GXt_int3 = AV26Valida;
         new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         AssignAttri("", false, "A45CliCod", A45CliCod);
         AV26Valida = GXt_int3;
         AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         A1913TipLProdDsc = A55ProdDsc;
         AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
         /* Using cursor T00636 */
         pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
         A161CliDsc = T00636_A161CliDsc[0];
         n161CliDsc = T00636_n161CliDsc[0];
         pr_default.close(4);
      }

      protected void CheckExtendedTable6392( )
      {
         nIsDirty_92 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00634 */
         pr_default.execute(2, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1912TipLDsc = T00634_A1912TipLDsc[0];
         pr_default.close(2);
         GXt_int3 = AV26Valida;
         new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         AssignAttri("", false, "A45CliCod", A45CliCod);
         AV26Valida = GXt_int3;
         AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         if ( ( AV26Valida == 1 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            GX_msglist.addItem("El producto ya existe creado en la lista de precios", 1, "");
            AnyError = 1;
         }
         /* Using cursor T00635 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T00635_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(3);
         nIsDirty_92 = 1;
         A1913TipLProdDsc = A55ProdDsc;
         AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A28ProdCod)) )
         {
            GX_msglist.addItem("", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A1651PreLis) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Precio", "", "", "", "", "", "", "", ""), 1, "PRELIS");
            AnyError = 1;
            GX_FocusControl = edtPreLis_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00636 */
         pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A161CliDsc = T00636_A161CliDsc[0];
         n161CliDsc = T00636_n161CliDsc[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors6392( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_26( int A202TipLCod )
      {
         /* Using cursor T00638 */
         pr_default.execute(6, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1912TipLDsc = T00638_A1912TipLDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1912TipLDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_27( string A28ProdCod )
      {
         /* Using cursor T00639 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T00639_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_28( string A45CliCod )
      {
         /* Using cursor T006310 */
         pr_default.execute(8, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A161CliDsc = T006310_A161CliDsc[0];
         n161CliDsc = T006310_n161CliDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A161CliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey6392( )
      {
         /* Using cursor T006311 */
         pr_default.execute(9, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00633 */
         pr_default.execute(1, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6392( 25) ;
            RcdFound92 = 1;
            A203TipLItem = T00633_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            A1205LisFech = T00633_A1205LisFech[0];
            AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            A1913TipLProdDsc = T00633_A1913TipLProdDsc[0];
            A1651PreLis = T00633_A1651PreLis[0];
            AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            A1652PreLisCred = T00633_A1652PreLisCred[0];
            AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
            A202TipLCod = T00633_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A28ProdCod = T00633_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = T00633_A45CliCod[0];
            n45CliCod = T00633_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            Z202TipLCod = A202TipLCod;
            Z203TipLItem = A203TipLItem;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6392( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey6392( ) ;
            }
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey6392( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6392( ) ;
         if ( RcdFound92 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound92 = 0;
         /* Using cursor T006312 */
         pr_default.execute(10, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T006312_A202TipLCod[0] < A202TipLCod ) || ( T006312_A202TipLCod[0] == A202TipLCod ) && ( T006312_A203TipLItem[0] < A203TipLItem ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T006312_A202TipLCod[0] > A202TipLCod ) || ( T006312_A202TipLCod[0] == A202TipLCod ) && ( T006312_A203TipLItem[0] > A203TipLItem ) ) )
            {
               A202TipLCod = T006312_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = T006312_A203TipLItem[0];
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound92 = 0;
         /* Using cursor T006313 */
         pr_default.execute(11, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T006313_A202TipLCod[0] > A202TipLCod ) || ( T006313_A202TipLCod[0] == A202TipLCod ) && ( T006313_A203TipLItem[0] > A203TipLItem ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T006313_A202TipLCod[0] < A202TipLCod ) || ( T006313_A202TipLCod[0] == A202TipLCod ) && ( T006313_A203TipLItem[0] < A203TipLItem ) ) )
            {
               A202TipLCod = T006313_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = T006313_A203TipLItem[0];
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6392( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6392( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
               {
                  A202TipLCod = Z202TipLCod;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
                  A203TipLItem = Z203TipLItem;
                  AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6392( ) ;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6392( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPLCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6392( ) ;
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
         if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
         {
            A202TipLCod = Z202TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = Z203TipLItem;
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6392( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00632 */
            pr_default.execute(0, new Object[] {A202TipLCod, A203TipLItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLISTAPRECIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1205LisFech ) != DateTimeUtil.ResetTime ( T00632_A1205LisFech[0] ) ) || ( StringUtil.StrCmp(Z1913TipLProdDsc, T00632_A1913TipLProdDsc[0]) != 0 ) || ( Z1651PreLis != T00632_A1651PreLis[0] ) || ( Z1652PreLisCred != T00632_A1652PreLisCred[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T00632_A28ProdCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z45CliCod, T00632_A45CliCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1205LisFech ) != DateTimeUtil.ResetTime ( T00632_A1205LisFech[0] ) )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"LisFech");
                  GXUtil.WriteLogRaw("Old: ",Z1205LisFech);
                  GXUtil.WriteLogRaw("Current: ",T00632_A1205LisFech[0]);
               }
               if ( StringUtil.StrCmp(Z1913TipLProdDsc, T00632_A1913TipLProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"TipLProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1913TipLProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T00632_A1913TipLProdDsc[0]);
               }
               if ( Z1651PreLis != T00632_A1651PreLis[0] )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"PreLis");
                  GXUtil.WriteLogRaw("Old: ",Z1651PreLis);
                  GXUtil.WriteLogRaw("Current: ",T00632_A1651PreLis[0]);
               }
               if ( Z1652PreLisCred != T00632_A1652PreLisCred[0] )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"PreLisCred");
                  GXUtil.WriteLogRaw("Old: ",Z1652PreLisCred);
                  GXUtil.WriteLogRaw("Current: ",T00632_A1652PreLisCred[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T00632_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00632_A28ProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z45CliCod, T00632_A45CliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.listaprecios:[seudo value changed for attri]"+"CliCod");
                  GXUtil.WriteLogRaw("Old: ",Z45CliCod);
                  GXUtil.WriteLogRaw("Current: ",T00632_A45CliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLISTAPRECIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6392( )
      {
         BeforeValidate6392( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6392( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6392( 0) ;
            CheckOptimisticConcurrency6392( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6392( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6392( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006314 */
                     pr_default.execute(12, new Object[] {n161CliDsc, A161CliDsc, A203TipLItem, A1205LisFech, A1913TipLProdDsc, A1651PreLis, A1652PreLisCred, A202TipLCod, A28ProdCod, n45CliCod, A45CliCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
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
                           ResetCaption630( ) ;
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
               Load6392( ) ;
            }
            EndLevel6392( ) ;
         }
         CloseExtendedTableCursors6392( ) ;
      }

      protected void Update6392( )
      {
         BeforeValidate6392( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6392( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6392( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6392( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6392( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006315 */
                     pr_default.execute(13, new Object[] {n161CliDsc, A161CliDsc, A1205LisFech, A1913TipLProdDsc, A1651PreLis, A1652PreLisCred, A28ProdCod, n45CliCod, A45CliCod, A202TipLCod, A203TipLItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLISTAPRECIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6392( ) ;
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
            EndLevel6392( ) ;
         }
         CloseExtendedTableCursors6392( ) ;
      }

      protected void DeferredUpdate6392( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6392( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6392( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6392( ) ;
            AfterConfirm6392( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6392( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006316 */
                  pr_default.execute(14, new Object[] {A202TipLCod, A203TipLItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6392( ) ;
         Gx_mode = sMode92;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6392( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T006317 */
            pr_default.execute(15, new Object[] {A202TipLCod});
            A1912TipLDsc = T006317_A1912TipLDsc[0];
            pr_default.close(15);
            /* Using cursor T006318 */
            pr_default.execute(16, new Object[] {A28ProdCod});
            A55ProdDsc = T006318_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            pr_default.close(16);
            /* Using cursor T006319 */
            pr_default.execute(17, new Object[] {n45CliCod, A45CliCod});
            A161CliDsc = T006319_A161CliDsc[0];
            n161CliDsc = T006319_n161CliDsc[0];
            pr_default.close(17);
            GXt_int3 = AV26Valida;
            new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            AV26Valida = GXt_int3;
            AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         }
      }

      protected void EndLevel6392( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6392( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("configuracion.listaprecios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues630( ) ;
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
            pr_default.close(17);
            context.RollbackDataStores("configuracion.listaprecios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6392( )
      {
         /* Scan By routine */
         /* Using cursor T006320 */
         pr_default.execute(18);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A202TipLCod = T006320_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = T006320_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6392( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound92 = 1;
            A202TipLCod = T006320_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = T006320_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
      }

      protected void ScanEnd6392( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm6392( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  || IsUpd( )  )
         {
            A1205LisFech = DateTimeUtil.Today( context);
            AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV25cTipLItem;
            new GeneXus.Programs.configuracion.pobteneritemlistaprecios(context ).execute( ref  A202TipLCod, out  GXt_int4) ;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            AV25cTipLItem = GXt_int4;
            AssignAttri("", false, "AV25cTipLItem", StringUtil.LTrimStr( (decimal)(AV25cTipLItem), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A203TipLItem = AV25cTipLItem;
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
      }

      protected void BeforeInsert6392( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6392( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6392( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6392( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6392( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6392( )
      {
         edtTipLCod_Enabled = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtPreLis_Enabled = 0;
         AssignProp("", false, edtPreLis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreLis_Enabled), 5, 0), true);
         edtPreLisCred_Enabled = 0;
         AssignProp("", false, edtPreLisCred_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreLisCred_Enabled), 5, 0), true);
         edtLisFech_Enabled = 0;
         AssignProp("", false, edtLisFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLisFech_Enabled), 5, 0), true);
         edtavCombotiplcod_Enabled = 0;
         AssignProp("", false, edtavCombotiplcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombotiplcod_Enabled), 5, 0), true);
         edtavComboclicod_Enabled = 0;
         AssignProp("", false, edtavComboclicod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclicod_Enabled), 5, 0), true);
         edtTipLItem_Enabled = 0;
         AssignProp("", false, edtTipLItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLItem_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6392( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues630( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262531", false, true);
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
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8TipLItem,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ListaPrecios");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Tipo", StringUtil.RTrim( context.localUtil.Format( AV27Tipo, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\listaprecios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z203TipLItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z203TipLItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1205LisFech", context.localUtil.DToC( Z1205LisFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1913TipLProdDsc", StringUtil.RTrim( Z1913TipLProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1651PreLis", StringUtil.LTrim( StringUtil.NToC( Z1651PreLis, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1652PreLisCred", StringUtil.LTrim( StringUtil.NToC( Z1652PreLisCred, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N28ProdCod", StringUtil.RTrim( A28ProdCod));
         GxWebStd.gx_hidden_field( context, "N45CliCod", StringUtil.RTrim( A45CliCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTIPLCOD_DATA", AV15TipLCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTIPLCOD_DATA", AV15TipLCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLICOD_DATA", AV23CliCod_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLICOD_DATA", AV23CliCod_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "TIPO", AV27Tipo);
         GxWebStd.gx_hidden_field( context, "vTIPLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipLCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTIPLITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8TipLItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPLITEM", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8TipLItem), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCTIPLITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25cTipLItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODCOD", StringUtil.RTrim( AV12Insert_ProdCod));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLICOD", StringUtil.RTrim( AV13Insert_CliCod));
         GxWebStd.gx_hidden_field( context, "vVALIDA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Valida), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPLPRODDSC", StringUtil.RTrim( A1913TipLProdDsc));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTIPO", AV27Tipo);
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "TIPLDSC", StringUtil.RTrim( A1912TipLDsc));
         GxWebStd.gx_hidden_field( context, "CLIDSC", StringUtil.RTrim( A161CliDsc));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Objectcall", StringUtil.RTrim( Combo_tiplcod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Cls", StringUtil.RTrim( Combo_tiplcod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Selectedvalue_set", StringUtil.RTrim( Combo_tiplcod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Selectedtext_set", StringUtil.RTrim( Combo_tiplcod_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Enabled", StringUtil.BoolToStr( Combo_tiplcod_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Datalistproc", StringUtil.RTrim( Combo_tiplcod_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Datalistprocparametersprefix", StringUtil.RTrim( Combo_tiplcod_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_TIPLCOD_Emptyitem", StringUtil.BoolToStr( Combo_tiplcod_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CLICOD_Objectcall", StringUtil.RTrim( Combo_clicod_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLICOD_Cls", StringUtil.RTrim( Combo_clicod_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLICOD_Selectedvalue_set", StringUtil.RTrim( Combo_clicod_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLICOD_Enabled", StringUtil.BoolToStr( Combo_clicod_Enabled));
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
         GXEncryptionTmp = "configuracion.listaprecios.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipLCod,6,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV8TipLItem,6,0));
         return formatLink("configuracion.listaprecios.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.ListaPrecios" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista de Precios" ;
      }

      protected void InitializeNonKey6392( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A45CliCod = "";
         n45CliCod = false;
         AssignAttri("", false, "A45CliCod", A45CliCod);
         AV25cTipLItem = 0;
         AssignAttri("", false, "AV25cTipLItem", StringUtil.LTrimStr( (decimal)(AV25cTipLItem), 6, 0));
         AV26Valida = 0;
         AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         A1205LisFech = DateTime.MinValue;
         AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
         A1913TipLProdDsc = "";
         AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1912TipLDsc = "";
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         A1651PreLis = 0;
         AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
         A161CliDsc = "";
         n161CliDsc = false;
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         A1652PreLisCred = 0;
         AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
         AV27Tipo = "V";
         AssignAttri("", false, "AV27Tipo", AV27Tipo);
         Z1205LisFech = DateTime.MinValue;
         Z1913TipLProdDsc = "";
         Z1651PreLis = 0;
         Z1652PreLisCred = 0;
         Z28ProdCod = "";
         Z45CliCod = "";
      }

      protected void InitAll6392( )
      {
         A202TipLCod = 0;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         A203TipLItem = 0;
         AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         InitializeNonKey6392( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         AV27Tipo = iV27Tipo;
         AssignAttri("", false, "AV27Tipo", AV27Tipo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262572", true, true);
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
         context.AddJavascriptSource("configuracion/listaprecios.js", "?202281810262573", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         lblTextblocktiplcod_Internalname = "TEXTBLOCKTIPLCOD";
         Combo_tiplcod_Internalname = "COMBO_TIPLCOD";
         edtTipLCod_Internalname = "TIPLCOD";
         divTablesplittedtiplcod_Internalname = "TABLESPLITTEDTIPLCOD";
         lblTextblockprodcod_Internalname = "TEXTBLOCKPRODCOD";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblockproddsc_Internalname = "TEXTBLOCKPRODDSC";
         edtProdDsc_Internalname = "PRODDSC";
         divUnnamedtableproddsc_Internalname = "UNNAMEDTABLEPRODDSC";
         tblTablemergedprodcod_Internalname = "TABLEMERGEDPRODCOD";
         divTablesplittedprodcod_Internalname = "TABLESPLITTEDPRODCOD";
         lblTextblockclicod_Internalname = "TEXTBLOCKCLICOD";
         Combo_clicod_Internalname = "COMBO_CLICOD";
         edtCliCod_Internalname = "CLICOD";
         divTablesplittedclicod_Internalname = "TABLESPLITTEDCLICOD";
         edtPreLis_Internalname = "PRELIS";
         edtPreLisCred_Internalname = "PRELISCRED";
         lblTextblocklisfech_Internalname = "TEXTBLOCKLISFECH";
         edtLisFech_Internalname = "LISFECH";
         divUnnamedtablelisfech_Internalname = "UNNAMEDTABLELISFECH";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombotiplcod_Internalname = "vCOMBOTIPLCOD";
         divSectionattribute_tiplcod_Internalname = "SECTIONATTRIBUTE_TIPLCOD";
         edtavComboclicod_Internalname = "vCOMBOCLICOD";
         divSectionattribute_clicod_Internalname = "SECTIONATTRIBUTE_CLICOD";
         edtTipLItem_Internalname = "TIPLITEM";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_28_Internalname = "PROMPT_28";
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
         Form.Caption = "Lista de Precios";
         edtTipLItem_Jsonclick = "";
         edtTipLItem_Enabled = 1;
         edtTipLItem_Visible = 1;
         edtavComboclicod_Jsonclick = "";
         edtavComboclicod_Enabled = 0;
         edtavComboclicod_Visible = 1;
         edtavCombotiplcod_Jsonclick = "";
         edtavCombotiplcod_Enabled = 0;
         edtavCombotiplcod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLisFech_Jsonclick = "";
         edtLisFech_Enabled = 0;
         edtPreLisCred_Jsonclick = "";
         edtPreLisCred_Enabled = 1;
         edtPreLis_Jsonclick = "";
         edtPreLis_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
         edtCliCod_Visible = 1;
         Combo_clicod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_clicod_Caption = "";
         Combo_clicod_Enabled = Convert.ToBoolean( -1);
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         imgprompt_28_Visible = 1;
         imgprompt_28_Link = "";
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtTipLCod_Jsonclick = "";
         edtTipLCod_Enabled = 1;
         edtTipLCod_Visible = 1;
         Combo_tiplcod_Emptyitem = Convert.ToBoolean( 0);
         Combo_tiplcod_Datalistprocparametersprefix = " \"ComboName\": \"TipLCod\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"TipLCod\": 0, \"TipLItem\": 0";
         Combo_tiplcod_Datalistproc = "Configuracion.ListaPreciosLoadDVCombo";
         Combo_tiplcod_Cls = "ExtendedCombo AttributeRealWidth100With";
         Combo_tiplcod_Caption = "";
         Combo_tiplcod_Enabled = Convert.ToBoolean( -1);
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

      protected void GX13ASACTIPLITEM6392( int A202TipLCod )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV25cTipLItem;
            new GeneXus.Programs.configuracion.pobteneritemlistaprecios(context ).execute( ref  A202TipLCod, out  GXt_int4) ;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            AV25cTipLItem = GXt_int4;
            AssignAttri("", false, "AV25cTipLItem", StringUtil.LTrimStr( (decimal)(AV25cTipLItem), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25cTipLItem), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX14ASAVALIDA6392( int A202TipLCod ,
                                        string A28ProdCod ,
                                        string A45CliCod )
      {
         GXt_int3 = AV26Valida;
         new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         AssignAttri("", false, "A45CliCod", A45CliCod);
         AV26Valida = GXt_int3;
         AssignAttri("", false, "AV26Valida", StringUtil.LTrimStr( (decimal)(AV26Valida), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Valida), 4, 0, ".", "")))+"\"") ;
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

      public void Valid_Tiplcod( )
      {
         /* Using cursor T006317 */
         pr_default.execute(15, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
         }
         A1912TipLDsc = T006317_A1912TipLDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1912TipLDsc", StringUtil.RTrim( A1912TipLDsc));
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T006318 */
         pr_default.execute(16, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A55ProdDsc = T006318_A55ProdDsc[0];
         pr_default.close(16);
         A1913TipLProdDsc = A55ProdDsc;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A28ProdCod)) )
         {
            GX_msglist.addItem("", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A1913TipLProdDsc", StringUtil.RTrim( A1913TipLProdDsc));
      }

      public void Valid_Clicod( )
      {
         n45CliCod = false;
         n161CliDsc = false;
         /* Using cursor T006319 */
         pr_default.execute(17, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
            }
         }
         A161CliDsc = T006319_A161CliDsc[0];
         n161CliDsc = T006319_n161CliDsc[0];
         pr_default.close(17);
         GXt_int3 = AV26Valida;
         new GeneXus.Programs.configuracion.pvalidalistaprecios(context ).execute( ref  A202TipLCod, ref  A28ProdCod, ref  A45CliCod, ref  GXt_int3) ;
         AV26Valida = GXt_int3;
         if ( ( AV26Valida == 1 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            GX_msglist.addItem("El producto ya existe creado en la lista de precios", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A161CliDsc", StringUtil.RTrim( A161CliDsc));
         AssignAttri("", false, "AV26Valida", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Valida), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipLCod',fld:'vTIPLCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipLItem',fld:'vTIPLITEM',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipLCod',fld:'vTIPLCOD',pic:'ZZZZZ9',hsh:true},{av:'AV8TipLItem',fld:'vTIPLITEM',pic:'ZZZZZ9',hsh:true},{av:'AV27Tipo',fld:'vTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12632',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TIPLCOD","{handler:'Valid_Tiplcod',iparms:[{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''}]");
         setEventMetadata("VALID_TIPLCOD",",oparms:[{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1913TipLProdDsc',fld:'TIPLPRODDSC',pic:''}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1913TipLProdDsc',fld:'TIPLPRODDSC',pic:''}]}");
         setEventMetadata("VALID_PRODDSC","{handler:'Valid_Proddsc',iparms:[]");
         setEventMetadata("VALID_PRODDSC",",oparms:[]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'AV26Valida',fld:'vVALIDA',pic:'ZZZ9'},{av:'A161CliDsc',fld:'CLIDSC',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[{av:'A161CliDsc',fld:'CLIDSC',pic:''},{av:'AV26Valida',fld:'vVALIDA',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PRELIS","{handler:'Valid_Prelis',iparms:[]");
         setEventMetadata("VALID_PRELIS",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOTIPLCOD","{handler:'Validv_Combotiplcod',iparms:[]");
         setEventMetadata("VALIDV_COMBOTIPLCOD",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCLICOD","{handler:'Validv_Comboclicod',iparms:[]");
         setEventMetadata("VALIDV_COMBOCLICOD",",oparms:[]}");
         setEventMetadata("VALID_TIPLITEM","{handler:'Valid_Tiplitem',iparms:[]");
         setEventMetadata("VALID_TIPLITEM",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1205LisFech = DateTime.MinValue;
         Z1913TipLProdDsc = "";
         Z28ProdCod = "";
         Z45CliCod = "";
         N28ProdCod = "";
         N45CliCod = "";
         Combo_clicod_Selectedvalue_get = "";
         Combo_tiplcod_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A28ProdCod = "";
         A45CliCod = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblocktiplcod_Jsonclick = "";
         ucCombo_tiplcod = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15TipLCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockprodcod_Jsonclick = "";
         sStyleString = "";
         sImgUrl = "";
         lblTextblockproddsc_Jsonclick = "";
         A55ProdDsc = "";
         lblTextblockclicod_Jsonclick = "";
         ucCombo_clicod = new GXUserControl();
         AV23CliCod_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocklisfech_Jsonclick = "";
         A1205LisFech = DateTime.MinValue;
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV24ComboCliCod = "";
         A1913TipLProdDsc = "";
         AV27Tipo = "";
         AV12Insert_ProdCod = "";
         AV13Insert_CliCod = "";
         A1912TipLDsc = "";
         A161CliDsc = "";
         AV31Pgmname = "";
         Combo_tiplcod_Objectcall = "";
         Combo_tiplcod_Class = "";
         Combo_tiplcod_Icontype = "";
         Combo_tiplcod_Icon = "";
         Combo_tiplcod_Tooltip = "";
         Combo_tiplcod_Selectedvalue_set = "";
         Combo_tiplcod_Selectedtext_set = "";
         Combo_tiplcod_Selectedtext_get = "";
         Combo_tiplcod_Gamoauthtoken = "";
         Combo_tiplcod_Ddointernalname = "";
         Combo_tiplcod_Titlecontrolalign = "";
         Combo_tiplcod_Dropdownoptionstype = "";
         Combo_tiplcod_Titlecontrolidtoreplace = "";
         Combo_tiplcod_Datalisttype = "";
         Combo_tiplcod_Datalistfixedvalues = "";
         Combo_tiplcod_Htmltemplate = "";
         Combo_tiplcod_Multiplevaluestype = "";
         Combo_tiplcod_Loadingdata = "";
         Combo_tiplcod_Noresultsfound = "";
         Combo_tiplcod_Emptyitemtext = "";
         Combo_tiplcod_Onlyselectedvalues = "";
         Combo_tiplcod_Selectalltext = "";
         Combo_tiplcod_Multiplevaluesseparator = "";
         Combo_tiplcod_Addnewoptiontext = "";
         Combo_clicod_Objectcall = "";
         Combo_clicod_Class = "";
         Combo_clicod_Icontype = "";
         Combo_clicod_Icon = "";
         Combo_clicod_Tooltip = "";
         Combo_clicod_Selectedvalue_set = "";
         Combo_clicod_Selectedtext_set = "";
         Combo_clicod_Selectedtext_get = "";
         Combo_clicod_Gamoauthtoken = "";
         Combo_clicod_Ddointernalname = "";
         Combo_clicod_Titlecontrolalign = "";
         Combo_clicod_Dropdownoptionstype = "";
         Combo_clicod_Titlecontrolidtoreplace = "";
         Combo_clicod_Datalisttype = "";
         Combo_clicod_Datalistfixedvalues = "";
         Combo_clicod_Datalistproc = "";
         Combo_clicod_Datalistprocparametersprefix = "";
         Combo_clicod_Htmltemplate = "";
         Combo_clicod_Multiplevaluestype = "";
         Combo_clicod_Loadingdata = "";
         Combo_clicod_Noresultsfound = "";
         Combo_clicod_Emptyitemtext = "";
         Combo_clicod_Onlyselectedvalues = "";
         Combo_clicod_Selectalltext = "";
         Combo_clicod_Multiplevaluesseparator = "";
         Combo_clicod_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode92 = "";
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
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z161CliDsc = "";
         Z1912TipLDsc = "";
         Z55ProdDsc = "";
         T00634_A1912TipLDsc = new string[] {""} ;
         T00635_A55ProdDsc = new string[] {""} ;
         T00636_A161CliDsc = new string[] {""} ;
         T00636_n161CliDsc = new bool[] {false} ;
         T00637_A203TipLItem = new int[1] ;
         T00637_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T00637_A1913TipLProdDsc = new string[] {""} ;
         T00637_A55ProdDsc = new string[] {""} ;
         T00637_A1912TipLDsc = new string[] {""} ;
         T00637_A1651PreLis = new decimal[1] ;
         T00637_A161CliDsc = new string[] {""} ;
         T00637_n161CliDsc = new bool[] {false} ;
         T00637_A1652PreLisCred = new decimal[1] ;
         T00637_A202TipLCod = new int[1] ;
         T00637_A28ProdCod = new string[] {""} ;
         T00637_A45CliCod = new string[] {""} ;
         T00637_n45CliCod = new bool[] {false} ;
         T00638_A1912TipLDsc = new string[] {""} ;
         T00639_A55ProdDsc = new string[] {""} ;
         T006310_A161CliDsc = new string[] {""} ;
         T006310_n161CliDsc = new bool[] {false} ;
         T006311_A202TipLCod = new int[1] ;
         T006311_A203TipLItem = new int[1] ;
         T00633_A203TipLItem = new int[1] ;
         T00633_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T00633_A1913TipLProdDsc = new string[] {""} ;
         T00633_A1651PreLis = new decimal[1] ;
         T00633_A1652PreLisCred = new decimal[1] ;
         T00633_A202TipLCod = new int[1] ;
         T00633_A28ProdCod = new string[] {""} ;
         T00633_A45CliCod = new string[] {""} ;
         T00633_n45CliCod = new bool[] {false} ;
         T00633_A161CliDsc = new string[] {""} ;
         T00633_n161CliDsc = new bool[] {false} ;
         T006312_A202TipLCod = new int[1] ;
         T006312_A203TipLItem = new int[1] ;
         T006313_A202TipLCod = new int[1] ;
         T006313_A203TipLItem = new int[1] ;
         T00632_A203TipLItem = new int[1] ;
         T00632_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T00632_A1913TipLProdDsc = new string[] {""} ;
         T00632_A1651PreLis = new decimal[1] ;
         T00632_A1652PreLisCred = new decimal[1] ;
         T00632_A202TipLCod = new int[1] ;
         T00632_A28ProdCod = new string[] {""} ;
         T00632_A45CliCod = new string[] {""} ;
         T00632_n45CliCod = new bool[] {false} ;
         T00632_A161CliDsc = new string[] {""} ;
         T00632_n161CliDsc = new bool[] {false} ;
         T006317_A1912TipLDsc = new string[] {""} ;
         T006318_A55ProdDsc = new string[] {""} ;
         T006319_A161CliDsc = new string[] {""} ;
         T006319_n161CliDsc = new bool[] {false} ;
         T006320_A202TipLCod = new int[1] ;
         T006320_A203TipLItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         iV27Tipo = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listaprecios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listaprecios__default(),
            new Object[][] {
                new Object[] {
               T00632_A203TipLItem, T00632_A1205LisFech, T00632_A1913TipLProdDsc, T00632_A1651PreLis, T00632_A1652PreLisCred, T00632_A202TipLCod, T00632_A28ProdCod, T00632_A45CliCod, T00632_n45CliCod, T00632_A161CliDsc,
               T00632_n161CliDsc
               }
               , new Object[] {
               T00633_A203TipLItem, T00633_A1205LisFech, T00633_A1913TipLProdDsc, T00633_A1651PreLis, T00633_A1652PreLisCred, T00633_A202TipLCod, T00633_A28ProdCod, T00633_A45CliCod, T00633_n45CliCod, T00633_A161CliDsc,
               T00633_n161CliDsc
               }
               , new Object[] {
               T00634_A1912TipLDsc
               }
               , new Object[] {
               T00635_A55ProdDsc
               }
               , new Object[] {
               T00636_A161CliDsc
               }
               , new Object[] {
               T00637_A203TipLItem, T00637_A1205LisFech, T00637_A1913TipLProdDsc, T00637_A55ProdDsc, T00637_A1912TipLDsc, T00637_A1651PreLis, T00637_A161CliDsc, T00637_n161CliDsc, T00637_A1652PreLisCred, T00637_A202TipLCod,
               T00637_A28ProdCod, T00637_A45CliCod, T00637_n45CliCod
               }
               , new Object[] {
               T00638_A1912TipLDsc
               }
               , new Object[] {
               T00639_A55ProdDsc
               }
               , new Object[] {
               T006310_A161CliDsc
               }
               , new Object[] {
               T006311_A202TipLCod, T006311_A203TipLItem
               }
               , new Object[] {
               T006312_A202TipLCod, T006312_A203TipLItem
               }
               , new Object[] {
               T006313_A202TipLCod, T006313_A203TipLItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006317_A1912TipLDsc
               }
               , new Object[] {
               T006318_A55ProdDsc
               }
               , new Object[] {
               T006319_A161CliDsc
               }
               , new Object[] {
               T006320_A202TipLCod, T006320_A203TipLItem
               }
            }
         );
         AV31Pgmname = "Configuracion.ListaPrecios";
         AV27Tipo = "V";
         iV27Tipo = "V";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short AV26Valida ;
      private short Gx_BScreen ;
      private short RcdFound92 ;
      private short GX_JID ;
      private short nIsDirty_92 ;
      private short gxajaxcallmode ;
      private short GXt_int3 ;
      private short ZV26Valida ;
      private int wcpOAV7TipLCod ;
      private int wcpOAV8TipLItem ;
      private int Z202TipLCod ;
      private int Z203TipLItem ;
      private int A202TipLCod ;
      private int AV7TipLCod ;
      private int AV8TipLItem ;
      private int trnEnded ;
      private int edtTipLCod_Visible ;
      private int edtTipLCod_Enabled ;
      private int edtProdCod_Enabled ;
      private int imgprompt_28_Visible ;
      private int edtProdDsc_Enabled ;
      private int edtCliCod_Visible ;
      private int edtCliCod_Enabled ;
      private int edtPreLis_Enabled ;
      private int edtPreLisCred_Enabled ;
      private int edtLisFech_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV20ComboTipLCod ;
      private int edtavCombotiplcod_Enabled ;
      private int edtavCombotiplcod_Visible ;
      private int edtavComboclicod_Visible ;
      private int edtavComboclicod_Enabled ;
      private int A203TipLItem ;
      private int edtTipLItem_Visible ;
      private int edtTipLItem_Enabled ;
      private int AV25cTipLItem ;
      private int Combo_tiplcod_Datalistupdateminimumcharacters ;
      private int Combo_tiplcod_Gxcontroltype ;
      private int Combo_clicod_Datalistupdateminimumcharacters ;
      private int Combo_clicod_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV32GXV1 ;
      private int idxLst ;
      private int GXt_int4 ;
      private decimal Z1651PreLis ;
      private decimal Z1652PreLisCred ;
      private decimal A1651PreLis ;
      private decimal A1652PreLisCred ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1913TipLProdDsc ;
      private string Z28ProdCod ;
      private string Z45CliCod ;
      private string N28ProdCod ;
      private string N45CliCod ;
      private string Combo_clicod_Selectedvalue_get ;
      private string Combo_tiplcod_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A28ProdCod ;
      private string A45CliCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipLCod_Internalname ;
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
      private string divTablesplittedtiplcod_Internalname ;
      private string lblTextblocktiplcod_Internalname ;
      private string lblTextblocktiplcod_Jsonclick ;
      private string Combo_tiplcod_Caption ;
      private string Combo_tiplcod_Cls ;
      private string Combo_tiplcod_Datalistproc ;
      private string Combo_tiplcod_Datalistprocparametersprefix ;
      private string Combo_tiplcod_Internalname ;
      private string TempTags ;
      private string edtTipLCod_Jsonclick ;
      private string divTablesplittedprodcod_Internalname ;
      private string lblTextblockprodcod_Internalname ;
      private string lblTextblockprodcod_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedprodcod_Internalname ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_28_Internalname ;
      private string imgprompt_28_Link ;
      private string divUnnamedtableproddsc_Internalname ;
      private string lblTextblockproddsc_Internalname ;
      private string lblTextblockproddsc_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string divTablesplittedclicod_Internalname ;
      private string lblTextblockclicod_Internalname ;
      private string lblTextblockclicod_Jsonclick ;
      private string Combo_clicod_Caption ;
      private string Combo_clicod_Cls ;
      private string Combo_clicod_Internalname ;
      private string edtCliCod_Internalname ;
      private string edtCliCod_Jsonclick ;
      private string edtPreLis_Internalname ;
      private string edtPreLis_Jsonclick ;
      private string edtPreLisCred_Internalname ;
      private string edtPreLisCred_Jsonclick ;
      private string divUnnamedtablelisfech_Internalname ;
      private string lblTextblocklisfech_Internalname ;
      private string lblTextblocklisfech_Jsonclick ;
      private string edtLisFech_Internalname ;
      private string edtLisFech_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_tiplcod_Internalname ;
      private string edtavCombotiplcod_Internalname ;
      private string edtavCombotiplcod_Jsonclick ;
      private string divSectionattribute_clicod_Internalname ;
      private string edtavComboclicod_Internalname ;
      private string AV24ComboCliCod ;
      private string edtavComboclicod_Jsonclick ;
      private string edtTipLItem_Internalname ;
      private string edtTipLItem_Jsonclick ;
      private string A1913TipLProdDsc ;
      private string AV12Insert_ProdCod ;
      private string AV13Insert_CliCod ;
      private string A1912TipLDsc ;
      private string A161CliDsc ;
      private string AV31Pgmname ;
      private string Combo_tiplcod_Objectcall ;
      private string Combo_tiplcod_Class ;
      private string Combo_tiplcod_Icontype ;
      private string Combo_tiplcod_Icon ;
      private string Combo_tiplcod_Tooltip ;
      private string Combo_tiplcod_Selectedvalue_set ;
      private string Combo_tiplcod_Selectedtext_set ;
      private string Combo_tiplcod_Selectedtext_get ;
      private string Combo_tiplcod_Gamoauthtoken ;
      private string Combo_tiplcod_Ddointernalname ;
      private string Combo_tiplcod_Titlecontrolalign ;
      private string Combo_tiplcod_Dropdownoptionstype ;
      private string Combo_tiplcod_Titlecontrolidtoreplace ;
      private string Combo_tiplcod_Datalisttype ;
      private string Combo_tiplcod_Datalistfixedvalues ;
      private string Combo_tiplcod_Htmltemplate ;
      private string Combo_tiplcod_Multiplevaluestype ;
      private string Combo_tiplcod_Loadingdata ;
      private string Combo_tiplcod_Noresultsfound ;
      private string Combo_tiplcod_Emptyitemtext ;
      private string Combo_tiplcod_Onlyselectedvalues ;
      private string Combo_tiplcod_Selectalltext ;
      private string Combo_tiplcod_Multiplevaluesseparator ;
      private string Combo_tiplcod_Addnewoptiontext ;
      private string Combo_clicod_Objectcall ;
      private string Combo_clicod_Class ;
      private string Combo_clicod_Icontype ;
      private string Combo_clicod_Icon ;
      private string Combo_clicod_Tooltip ;
      private string Combo_clicod_Selectedvalue_set ;
      private string Combo_clicod_Selectedtext_set ;
      private string Combo_clicod_Selectedtext_get ;
      private string Combo_clicod_Gamoauthtoken ;
      private string Combo_clicod_Ddointernalname ;
      private string Combo_clicod_Titlecontrolalign ;
      private string Combo_clicod_Dropdownoptionstype ;
      private string Combo_clicod_Titlecontrolidtoreplace ;
      private string Combo_clicod_Datalisttype ;
      private string Combo_clicod_Datalistfixedvalues ;
      private string Combo_clicod_Datalistproc ;
      private string Combo_clicod_Datalistprocparametersprefix ;
      private string Combo_clicod_Htmltemplate ;
      private string Combo_clicod_Multiplevaluestype ;
      private string Combo_clicod_Loadingdata ;
      private string Combo_clicod_Noresultsfound ;
      private string Combo_clicod_Emptyitemtext ;
      private string Combo_clicod_Onlyselectedvalues ;
      private string Combo_clicod_Selectalltext ;
      private string Combo_clicod_Multiplevaluesseparator ;
      private string Combo_clicod_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode92 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string Z161CliDsc ;
      private string Z1912TipLDsc ;
      private string Z55ProdDsc ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z1205LisFech ;
      private DateTime A1205LisFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n45CliCod ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_tiplcod_Emptyitem ;
      private bool n161CliDsc ;
      private bool Combo_tiplcod_Enabled ;
      private bool Combo_tiplcod_Visible ;
      private bool Combo_tiplcod_Allowmultipleselection ;
      private bool Combo_tiplcod_Isgriditem ;
      private bool Combo_tiplcod_Hasdescription ;
      private bool Combo_tiplcod_Includeonlyselectedoption ;
      private bool Combo_tiplcod_Includeselectalloption ;
      private bool Combo_tiplcod_Includeaddnewoption ;
      private bool Combo_clicod_Enabled ;
      private bool Combo_clicod_Visible ;
      private bool Combo_clicod_Allowmultipleselection ;
      private bool Combo_clicod_Isgriditem ;
      private bool Combo_clicod_Hasdescription ;
      private bool Combo_clicod_Includeonlyselectedoption ;
      private bool Combo_clicod_Includeselectalloption ;
      private bool Combo_clicod_Emptyitem ;
      private bool Combo_clicod_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV19Combo_DataJson ;
      private string AV27Tipo ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string iV27Tipo ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_tiplcod ;
      private GXUserControl ucCombo_clicod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00634_A1912TipLDsc ;
      private string[] T00635_A55ProdDsc ;
      private string[] T00636_A161CliDsc ;
      private bool[] T00636_n161CliDsc ;
      private int[] T00637_A203TipLItem ;
      private DateTime[] T00637_A1205LisFech ;
      private string[] T00637_A1913TipLProdDsc ;
      private string[] T00637_A55ProdDsc ;
      private string[] T00637_A1912TipLDsc ;
      private decimal[] T00637_A1651PreLis ;
      private string[] T00637_A161CliDsc ;
      private bool[] T00637_n161CliDsc ;
      private decimal[] T00637_A1652PreLisCred ;
      private int[] T00637_A202TipLCod ;
      private string[] T00637_A28ProdCod ;
      private string[] T00637_A45CliCod ;
      private bool[] T00637_n45CliCod ;
      private string[] T00638_A1912TipLDsc ;
      private string[] T00639_A55ProdDsc ;
      private string[] T006310_A161CliDsc ;
      private bool[] T006310_n161CliDsc ;
      private int[] T006311_A202TipLCod ;
      private int[] T006311_A203TipLItem ;
      private int[] T00633_A203TipLItem ;
      private DateTime[] T00633_A1205LisFech ;
      private string[] T00633_A1913TipLProdDsc ;
      private decimal[] T00633_A1651PreLis ;
      private decimal[] T00633_A1652PreLisCred ;
      private int[] T00633_A202TipLCod ;
      private string[] T00633_A28ProdCod ;
      private string[] T00633_A45CliCod ;
      private bool[] T00633_n45CliCod ;
      private string[] T00633_A161CliDsc ;
      private bool[] T00633_n161CliDsc ;
      private int[] T006312_A202TipLCod ;
      private int[] T006312_A203TipLItem ;
      private int[] T006313_A202TipLCod ;
      private int[] T006313_A203TipLItem ;
      private int[] T00632_A203TipLItem ;
      private DateTime[] T00632_A1205LisFech ;
      private string[] T00632_A1913TipLProdDsc ;
      private decimal[] T00632_A1651PreLis ;
      private decimal[] T00632_A1652PreLisCred ;
      private int[] T00632_A202TipLCod ;
      private string[] T00632_A28ProdCod ;
      private string[] T00632_A45CliCod ;
      private bool[] T00632_n45CliCod ;
      private string[] T00632_A161CliDsc ;
      private bool[] T00632_n161CliDsc ;
      private string[] T006317_A1912TipLDsc ;
      private string[] T006318_A55ProdDsc ;
      private string[] T006319_A161CliDsc ;
      private bool[] T006319_n161CliDsc ;
      private int[] T006320_A202TipLCod ;
      private int[] T006320_A203TipLItem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15TipLCod_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV23CliCod_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class listaprecios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class listaprecios__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00637;
        prmT00637 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT00634;
        prmT00634 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00635;
        prmT00635 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00636;
        prmT00636 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00638;
        prmT00638 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00639;
        prmT00639 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006310;
        prmT006310 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT006311;
        prmT006311 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT00633;
        prmT00633 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT006312;
        prmT006312 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT006313;
        prmT006313 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT00632;
        prmT00632 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT006314;
        prmT006314 = new Object[] {
        new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
        new ParDef("@TipLItem",GXType.Int32,6,0) ,
        new ParDef("@LisFech",GXType.Date,8,0) ,
        new ParDef("@TipLProdDsc",GXType.NChar,100,0) ,
        new ParDef("@PreLis",GXType.Decimal,15,4) ,
        new ParDef("@PreLisCred",GXType.Decimal,15,4) ,
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT006315;
        prmT006315 = new Object[] {
        new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
        new ParDef("@LisFech",GXType.Date,8,0) ,
        new ParDef("@TipLProdDsc",GXType.NChar,100,0) ,
        new ParDef("@PreLis",GXType.Decimal,15,4) ,
        new ParDef("@PreLisCred",GXType.Decimal,15,4) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT006316;
        prmT006316 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT006320;
        prmT006320 = new Object[] {
        };
        Object[] prmT006317;
        prmT006317 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006318;
        prmT006318 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT006319;
        prmT006319 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00632", "SELECT [TipLItem], [LisFech], [TipLProdDsc], [PreLis], [PreLisCred], [TipLCod], [ProdCod], [CliCod], [CliDsc] FROM [CLISTAPRECIOS] WITH (UPDLOCK) WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00632,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00633", "SELECT [TipLItem], [LisFech], [TipLProdDsc], [PreLis], [PreLisCred], [TipLCod], [ProdCod], [CliCod], [CliDsc] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00633,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00634", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00634,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00635", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00635,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00636", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00636,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00637", "SELECT TM1.[TipLItem], TM1.[LisFech], TM1.[TipLProdDsc], T3.[ProdDsc], T2.[TipLDsc], TM1.[PreLis], TM1.[CliDsc], TM1.[PreLisCred], TM1.[TipLCod], TM1.[ProdCod], TM1.[CliCod] FROM (([CLISTAPRECIOS] TM1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = TM1.[TipLCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[ProdCod]) WHERE TM1.[TipLCod] = @TipLCod and TM1.[TipLItem] = @TipLItem ORDER BY TM1.[TipLCod], TM1.[TipLItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00637,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00638", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00638,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00639", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00639,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006310", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006310,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006311", "SELECT [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006312", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE ( [TipLCod] > @TipLCod or [TipLCod] = @TipLCod and [TipLItem] > @TipLItem) ORDER BY [TipLCod], [TipLItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006312,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006313", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE ( [TipLCod] < @TipLCod or [TipLCod] = @TipLCod and [TipLItem] < @TipLItem) ORDER BY [TipLCod] DESC, [TipLItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006313,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006314", "INSERT INTO [CLISTAPRECIOS]([CliDsc], [TipLItem], [LisFech], [TipLProdDsc], [PreLis], [PreLisCred], [TipLCod], [ProdCod], [CliCod]) VALUES(@CliDsc, @TipLItem, @LisFech, @TipLProdDsc, @PreLis, @PreLisCred, @TipLCod, @ProdCod, @CliCod)", GxErrorMask.GX_NOMASK,prmT006314)
           ,new CursorDef("T006315", "UPDATE [CLISTAPRECIOS] SET [CliDsc]=@CliDsc, [LisFech]=@LisFech, [TipLProdDsc]=@TipLProdDsc, [PreLis]=@PreLis, [PreLisCred]=@PreLisCred, [ProdCod]=@ProdCod, [CliCod]=@CliCod  WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem", GxErrorMask.GX_NOMASK,prmT006315)
           ,new CursorDef("T006316", "DELETE FROM [CLISTAPRECIOS]  WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem", GxErrorMask.GX_NOMASK,prmT006316)
           ,new CursorDef("T006317", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006317,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006318", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006318,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006319", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006319,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006320", "SELECT [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] ORDER BY [TipLCod], [TipLItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006320,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 15);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
