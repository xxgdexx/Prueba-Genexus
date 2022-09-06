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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.almacen {
   public class productosww : GXDataArea
   {
      public productosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public productosww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         chkProdVta = new GXCheckbox();
         chkProdCmp = new GXCheckbox();
         cmbProdSts = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_137 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_137"), "."));
               nGXsfl_137_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_137_idx"), "."));
               sGXsfl_137_idx = GetPar( "sGXsfl_137_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
               cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
               AV15DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
               cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
               AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."));
               AV17ProdDsc1 = GetPar( "ProdDsc1");
               AV18ProdCuentaVDsc1 = GetPar( "ProdCuentaVDsc1");
               AV19ProdCuentaCDsc1 = GetPar( "ProdCuentaCDsc1");
               AV20ProdCuentaADsc1 = GetPar( "ProdCuentaADsc1");
               AV108LinDsc1 = GetPar( "LinDsc1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV23DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV24ProdDsc2 = GetPar( "ProdDsc2");
               AV25ProdCuentaVDsc2 = GetPar( "ProdCuentaVDsc2");
               AV26ProdCuentaCDsc2 = GetPar( "ProdCuentaCDsc2");
               AV27ProdCuentaADsc2 = GetPar( "ProdCuentaADsc2");
               AV109LinDsc2 = GetPar( "LinDsc2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV29DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV30DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV31ProdDsc3 = GetPar( "ProdDsc3");
               AV32ProdCuentaVDsc3 = GetPar( "ProdCuentaVDsc3");
               AV33ProdCuentaCDsc3 = GetPar( "ProdCuentaCDsc3");
               AV34ProdCuentaADsc3 = GetPar( "ProdCuentaADsc3");
               AV110LinDsc3 = GetPar( "LinDsc3");
               AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV28DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV113Pgmname = GetPar( "Pgmname");
               AV40TFProdCod = GetPar( "TFProdCod");
               AV41TFProdCod_Sel = GetPar( "TFProdCod_Sel");
               AV42TFLinCod = (int)(NumberUtil.Val( GetPar( "TFLinCod"), "."));
               AV43TFLinCod_To = (int)(NumberUtil.Val( GetPar( "TFLinCod_To"), "."));
               AV44TFProdDsc = GetPar( "TFProdDsc");
               AV45TFProdDsc_Sel = GetPar( "TFProdDsc_Sel");
               AV46TFSublCod = (int)(NumberUtil.Val( GetPar( "TFSublCod"), "."));
               AV47TFSublCod_To = (int)(NumberUtil.Val( GetPar( "TFSublCod_To"), "."));
               AV48TFFamCod = (int)(NumberUtil.Val( GetPar( "TFFamCod"), "."));
               AV49TFFamCod_To = (int)(NumberUtil.Val( GetPar( "TFFamCod_To"), "."));
               AV50TFUniCod = (int)(NumberUtil.Val( GetPar( "TFUniCod"), "."));
               AV51TFUniCod_To = (int)(NumberUtil.Val( GetPar( "TFUniCod_To"), "."));
               AV103TFProdVta_Sel = (short)(NumberUtil.Val( GetPar( "TFProdVta_Sel"), "."));
               AV104TFProdCmp_Sel = (short)(NumberUtil.Val( GetPar( "TFProdCmp_Sel"), "."));
               AV56TFProdPeso = NumberUtil.Val( GetPar( "TFProdPeso"), ".");
               AV57TFProdPeso_To = NumberUtil.Val( GetPar( "TFProdPeso_To"), ".");
               AV58TFProdVolumen = NumberUtil.Val( GetPar( "TFProdVolumen"), ".");
               AV59TFProdVolumen_To = NumberUtil.Val( GetPar( "TFProdVolumen_To"), ".");
               AV60TFProdStkMax = NumberUtil.Val( GetPar( "TFProdStkMax"), ".");
               AV61TFProdStkMax_To = NumberUtil.Val( GetPar( "TFProdStkMax_To"), ".");
               AV62TFProdStkMin = NumberUtil.Val( GetPar( "TFProdStkMin"), ".");
               AV63TFProdStkMin_To = NumberUtil.Val( GetPar( "TFProdStkMin_To"), ".");
               AV64TFProdRef1 = GetPar( "TFProdRef1");
               AV65TFProdRef1_Sel = GetPar( "TFProdRef1_Sel");
               AV66TFProdRef2 = GetPar( "TFProdRef2");
               AV67TFProdRef2_Sel = GetPar( "TFProdRef2_Sel");
               AV68TFProdRef3 = GetPar( "TFProdRef3");
               AV69TFProdRef3_Sel = GetPar( "TFProdRef3_Sel");
               AV70TFProdRef4 = GetPar( "TFProdRef4");
               AV71TFProdRef4_Sel = GetPar( "TFProdRef4_Sel");
               AV72TFProdRef5 = GetPar( "TFProdRef5");
               AV73TFProdRef5_Sel = GetPar( "TFProdRef5_Sel");
               AV74TFProdRef6 = GetPar( "TFProdRef6");
               AV75TFProdRef6_Sel = GetPar( "TFProdRef6_Sel");
               AV76TFProdRef7 = GetPar( "TFProdRef7");
               AV77TFProdRef7_Sel = GetPar( "TFProdRef7_Sel");
               AV78TFProdRef8 = GetPar( "TFProdRef8");
               AV79TFProdRef8_Sel = GetPar( "TFProdRef8_Sel");
               AV80TFProdRef9 = GetPar( "TFProdRef9");
               AV81TFProdRef9_Sel = GetPar( "TFProdRef9_Sel");
               AV82TFProdRef10 = GetPar( "TFProdRef10");
               AV83TFProdRef10_Sel = GetPar( "TFProdRef10_Sel");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV106TFProdSts_Sels);
               AV86TFProdCosto = NumberUtil.Val( GetPar( "TFProdCosto"), ".");
               AV87TFProdCosto_To = NumberUtil.Val( GetPar( "TFProdCosto_To"), ".");
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV36DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV35DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
               AddString( context.getJSONResponse( )) ;
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810312873", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("almacen.productosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV113Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODDSC1", StringUtil.RTrim( AV17ProdDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAVDSC1", StringUtil.RTrim( AV18ProdCuentaVDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTACDSC1", StringUtil.RTrim( AV19ProdCuentaCDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAADSC1", StringUtil.RTrim( AV20ProdCuentaADsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vLINDSC1", StringUtil.RTrim( AV108LinDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODDSC2", StringUtil.RTrim( AV24ProdDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAVDSC2", StringUtil.RTrim( AV25ProdCuentaVDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTACDSC2", StringUtil.RTrim( AV26ProdCuentaCDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAADSC2", StringUtil.RTrim( AV27ProdCuentaADsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vLINDSC2", StringUtil.RTrim( AV109LinDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV29DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODDSC3", StringUtil.RTrim( AV31ProdDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAVDSC3", StringUtil.RTrim( AV32ProdCuentaVDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTACDSC3", StringUtil.RTrim( AV33ProdCuentaCDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vPRODCUENTAADSC3", StringUtil.RTrim( AV34ProdCuentaADsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vLINDSC3", StringUtil.RTrim( AV110LinDsc3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_137", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_137), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV91GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV92GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV94AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV94AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV88DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV88DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV28DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV113Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV113Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD", StringUtil.RTrim( AV40TFProdCod));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOD_SEL", StringUtil.RTrim( AV41TFProdCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFLINCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43TFLinCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODDSC", StringUtil.RTrim( AV44TFProdDsc));
         GxWebStd.gx_hidden_field( context, "vTFPRODDSC_SEL", StringUtil.RTrim( AV45TFProdDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFSUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFSublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFSUBLCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFSublCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFFAMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFFamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFFAMCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49TFFamCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFUNICOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFUniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFUNICOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51TFUniCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODVTA_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103TFProdVta_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODCMP_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV104TFProdCmp_Sel), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODPESO", StringUtil.LTrim( StringUtil.NToC( AV56TFProdPeso, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODPESO_TO", StringUtil.LTrim( StringUtil.NToC( AV57TFProdPeso_To, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODVOLUMEN", StringUtil.LTrim( StringUtil.NToC( AV58TFProdVolumen, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODVOLUMEN_TO", StringUtil.LTrim( StringUtil.NToC( AV59TFProdVolumen_To, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODSTKMAX", StringUtil.LTrim( StringUtil.NToC( AV60TFProdStkMax, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODSTKMAX_TO", StringUtil.LTrim( StringUtil.NToC( AV61TFProdStkMax_To, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODSTKMIN", StringUtil.LTrim( StringUtil.NToC( AV62TFProdStkMin, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODSTKMIN_TO", StringUtil.LTrim( StringUtil.NToC( AV63TFProdStkMin_To, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF1", StringUtil.RTrim( AV64TFProdRef1));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF1_SEL", StringUtil.RTrim( AV65TFProdRef1_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF2", StringUtil.RTrim( AV66TFProdRef2));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF2_SEL", StringUtil.RTrim( AV67TFProdRef2_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF3", StringUtil.RTrim( AV68TFProdRef3));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF3_SEL", StringUtil.RTrim( AV69TFProdRef3_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF4", StringUtil.RTrim( AV70TFProdRef4));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF4_SEL", StringUtil.RTrim( AV71TFProdRef4_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF5", StringUtil.RTrim( AV72TFProdRef5));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF5_SEL", StringUtil.RTrim( AV73TFProdRef5_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF6", StringUtil.RTrim( AV74TFProdRef6));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF6_SEL", StringUtil.RTrim( AV75TFProdRef6_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF7", StringUtil.RTrim( AV76TFProdRef7));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF7_SEL", StringUtil.RTrim( AV77TFProdRef7_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF8", StringUtil.RTrim( AV78TFProdRef8));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF8_SEL", StringUtil.RTrim( AV79TFProdRef8_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF9", StringUtil.RTrim( AV80TFProdRef9));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF9_SEL", StringUtil.RTrim( AV81TFProdRef9_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF10", StringUtil.RTrim( AV82TFProdRef10));
         GxWebStd.gx_hidden_field( context, "vTFPRODREF10_SEL", StringUtil.RTrim( AV83TFProdRef10_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPRODSTS_SELS", AV106TFProdSts_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPRODSTS_SELS", AV106TFProdSts_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPRODCOSTO", StringUtil.LTrim( StringUtil.NToC( AV86TFProdCosto, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFPRODCOSTO_TO", StringUtil.LTrim( StringUtil.NToC( AV87TFProdCosto_To, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV36DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV35DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFPRODSTS_SELSJSON", AV105TFProdSts_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         return formatLink("almacen.productosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Almacen.ProductosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Productos" ;
      }

      protected void WB4R0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableheader.SetProperty("Width", Dvpanel_tableheader_Width);
            ucDvpanel_tableheader.SetProperty("AutoWidth", Dvpanel_tableheader_Autowidth);
            ucDvpanel_tableheader.SetProperty("AutoHeight", Dvpanel_tableheader_Autoheight);
            ucDvpanel_tableheader.SetProperty("Cls", Dvpanel_tableheader_Cls);
            ucDvpanel_tableheader.SetProperty("Title", Dvpanel_tableheader_Title);
            ucDvpanel_tableheader.SetProperty("Collapsible", Dvpanel_tableheader_Collapsible);
            ucDvpanel_tableheader.SetProperty("Collapsed", Dvpanel_tableheader_Collapsed);
            ucDvpanel_tableheader.SetProperty("ShowCollapseIcon", Dvpanel_tableheader_Showcollapseicon);
            ucDvpanel_tableheader.SetProperty("IconPosition", Dvpanel_tableheader_Iconposition);
            ucDvpanel_tableheader.SetProperty("AutoScroll", Dvpanel_tableheader_Autoscroll);
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, "DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(137), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_25_4R2( true) ;
         }
         else
         {
            wb_table1_25_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"137\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo de Linea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripcion producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Sub Linea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Familia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo Unidad Medida") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Destinado Venta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Destinado Compra") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Peso producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Volumen producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Stock Maximo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Stock Minimo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Foto Producto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 1") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 2") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 3") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 4") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 5") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 6") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 7") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 8") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 9") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Referencia 10") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Situacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Ult. Costo MN") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV93GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A28ProdCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A55ProdDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProdDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1702ProdPeso, 15, 5, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1723ProdVolumen, 15, 5, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1716ProdStkMax, 17, 4, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1717ProdStkMin, 17, 4, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( A1695ProdFoto));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1705ProdRef1));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1707ProdRef2));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1708ProdRef3));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1709ProdRef4));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1710ProdRef5));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1711ProdRef6));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1712ProdRef7));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1713ProdRef8));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1714ProdRef9));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A1706ProdRef10));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1718ProdSts), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1681ProdCosto, 18, 5, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 137 )
         {
            wbEnd = 0;
            nRC_GXsfl_137 = (int)(nGXsfl_137_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV90GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV91GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV92GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV94AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Almacen\\ProductosWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV88DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 137 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4R2( )
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
            Form.Meta.addItem("description", " Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E114R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E164R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E174R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E184R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E194R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E204R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E214R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E224R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E234R2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_137_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
                              SubsflControlProps_1372( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV93GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV93GridActions), 4, 0));
                              A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
                              A52LinCod = (int)(context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ","));
                              A55ProdDsc = cgiGet( edtProdDsc_Internalname);
                              A51SublCod = (int)(context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ","));
                              n51SublCod = false;
                              A50FamCod = (int)(context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ","));
                              n50FamCod = false;
                              A49UniCod = (int)(context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ","));
                              A1724ProdVta = (short)(((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0));
                              A1679ProdCmp = (short)(((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0));
                              A1702ProdPeso = context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",");
                              A1723ProdVolumen = context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",");
                              A1716ProdStkMax = context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",");
                              A1717ProdStkMin = context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",");
                              A1695ProdFoto = cgiGet( edtProdFoto_Internalname);
                              n1695ProdFoto = false;
                              AssignProp("", false, edtProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), !bGXsfl_137_Refreshing);
                              AssignProp("", false, edtProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
                              A1705ProdRef1 = cgiGet( edtProdRef1_Internalname);
                              A1707ProdRef2 = cgiGet( edtProdRef2_Internalname);
                              A1708ProdRef3 = cgiGet( edtProdRef3_Internalname);
                              A1709ProdRef4 = cgiGet( edtProdRef4_Internalname);
                              A1710ProdRef5 = cgiGet( edtProdRef5_Internalname);
                              A1711ProdRef6 = cgiGet( edtProdRef6_Internalname);
                              A1712ProdRef7 = cgiGet( edtProdRef7_Internalname);
                              A1713ProdRef8 = cgiGet( edtProdRef8_Internalname);
                              A1714ProdRef9 = cgiGet( edtProdRef9_Internalname);
                              A1706ProdRef10 = cgiGet( edtProdRef10_Internalname);
                              cmbProdSts.Name = cmbProdSts_Internalname;
                              cmbProdSts.CurrentValue = cgiGet( cmbProdSts_Internalname);
                              A1718ProdSts = (short)(NumberUtil.Val( cgiGet( cmbProdSts_Internalname), "."));
                              A1681ProdCosto = context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E244R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E254R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E264R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E274R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ".", ",") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proddsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC1"), AV17ProdDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentavdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC1"), AV18ProdCuentaVDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentacdsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC1"), AV19ProdCuentaCDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentaadsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC1"), AV20ProdCuentaADsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Lindsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC1"), AV108LinDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proddsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC2"), AV24ProdDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentavdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC2"), AV25ProdCuentaVDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentacdsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC2"), AV26ProdCuentaCDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentaadsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC2"), AV27ProdCuentaADsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Lindsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC2"), AV109LinDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Proddsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC3"), AV31ProdDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentavdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC3"), AV32ProdCuentaVDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentacdsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC3"), AV33ProdCuentaCDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Prodcuentaadsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC3"), AV34ProdCuentaADsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Lindsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC3"), AV110LinDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4R2( )
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

      protected void PA4R2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavDynamicfiltersselector1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1372( ) ;
         while ( nGXsfl_137_idx <= nRC_GXsfl_137 )
         {
            sendrow_1372( ) ;
            nGXsfl_137_idx = ((subGrid_Islastpage==1)&&(nGXsfl_137_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_137_idx+1);
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17ProdDsc1 ,
                                       string AV18ProdCuentaVDsc1 ,
                                       string AV19ProdCuentaCDsc1 ,
                                       string AV20ProdCuentaADsc1 ,
                                       string AV108LinDsc1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24ProdDsc2 ,
                                       string AV25ProdCuentaVDsc2 ,
                                       string AV26ProdCuentaCDsc2 ,
                                       string AV27ProdCuentaADsc2 ,
                                       string AV109LinDsc2 ,
                                       string AV29DynamicFiltersSelector3 ,
                                       short AV30DynamicFiltersOperator3 ,
                                       string AV31ProdDsc3 ,
                                       string AV32ProdCuentaVDsc3 ,
                                       string AV33ProdCuentaCDsc3 ,
                                       string AV34ProdCuentaADsc3 ,
                                       string AV110LinDsc3 ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV28DynamicFiltersEnabled3 ,
                                       string AV113Pgmname ,
                                       string AV40TFProdCod ,
                                       string AV41TFProdCod_Sel ,
                                       int AV42TFLinCod ,
                                       int AV43TFLinCod_To ,
                                       string AV44TFProdDsc ,
                                       string AV45TFProdDsc_Sel ,
                                       int AV46TFSublCod ,
                                       int AV47TFSublCod_To ,
                                       int AV48TFFamCod ,
                                       int AV49TFFamCod_To ,
                                       int AV50TFUniCod ,
                                       int AV51TFUniCod_To ,
                                       short AV103TFProdVta_Sel ,
                                       short AV104TFProdCmp_Sel ,
                                       decimal AV56TFProdPeso ,
                                       decimal AV57TFProdPeso_To ,
                                       decimal AV58TFProdVolumen ,
                                       decimal AV59TFProdVolumen_To ,
                                       decimal AV60TFProdStkMax ,
                                       decimal AV61TFProdStkMax_To ,
                                       decimal AV62TFProdStkMin ,
                                       decimal AV63TFProdStkMin_To ,
                                       string AV64TFProdRef1 ,
                                       string AV65TFProdRef1_Sel ,
                                       string AV66TFProdRef2 ,
                                       string AV67TFProdRef2_Sel ,
                                       string AV68TFProdRef3 ,
                                       string AV69TFProdRef3_Sel ,
                                       string AV70TFProdRef4 ,
                                       string AV71TFProdRef4_Sel ,
                                       string AV72TFProdRef5 ,
                                       string AV73TFProdRef5_Sel ,
                                       string AV74TFProdRef6 ,
                                       string AV75TFProdRef6_Sel ,
                                       string AV76TFProdRef7 ,
                                       string AV77TFProdRef7_Sel ,
                                       string AV78TFProdRef8 ,
                                       string AV79TFProdRef8_Sel ,
                                       string AV80TFProdRef9 ,
                                       string AV81TFProdRef9_Sel ,
                                       string AV82TFProdRef10 ,
                                       string AV83TFProdRef10_Sel ,
                                       GxSimpleCollection<short> AV106TFProdSts_Sels ,
                                       decimal AV86TFProdCosto ,
                                       decimal AV87TFProdCosto_To ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV36DynamicFiltersIgnoreFirst ,
                                       bool AV35DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E254R2 ();
         GRID_nCurrentRecord = 0;
         RF4R2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), context));
         GxWebStd.gx_hidden_field( context, "PRODCOD", StringUtil.RTrim( A28ProdCod));
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV113Pgmname = "Almacen.ProductosWW";
         context.Gx_err = 0;
      }

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 137;
         /* Execute user event: Refresh */
         E254R2 ();
         nGXsfl_137_idx = 1;
         sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
         SubsflControlProps_1372( ) ;
         bGXsfl_137_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1718ProdSts ,
                                                 AV179Almacen_productoswwds_66_tfprodsts_sels ,
                                                 AV114Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                                 AV115Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                                 AV116Almacen_productoswwds_3_proddsc1 ,
                                                 AV117Almacen_productoswwds_4_prodcuentavdsc1 ,
                                                 AV118Almacen_productoswwds_5_prodcuentacdsc1 ,
                                                 AV119Almacen_productoswwds_6_prodcuentaadsc1 ,
                                                 AV120Almacen_productoswwds_7_lindsc1 ,
                                                 AV121Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                                 AV122Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                                 AV123Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                                 AV124Almacen_productoswwds_11_proddsc2 ,
                                                 AV125Almacen_productoswwds_12_prodcuentavdsc2 ,
                                                 AV126Almacen_productoswwds_13_prodcuentacdsc2 ,
                                                 AV127Almacen_productoswwds_14_prodcuentaadsc2 ,
                                                 AV128Almacen_productoswwds_15_lindsc2 ,
                                                 AV129Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                                 AV130Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                                 AV131Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                                 AV132Almacen_productoswwds_19_proddsc3 ,
                                                 AV133Almacen_productoswwds_20_prodcuentavdsc3 ,
                                                 AV134Almacen_productoswwds_21_prodcuentacdsc3 ,
                                                 AV135Almacen_productoswwds_22_prodcuentaadsc3 ,
                                                 AV136Almacen_productoswwds_23_lindsc3 ,
                                                 AV138Almacen_productoswwds_25_tfprodcod_sel ,
                                                 AV137Almacen_productoswwds_24_tfprodcod ,
                                                 AV139Almacen_productoswwds_26_tflincod ,
                                                 AV140Almacen_productoswwds_27_tflincod_to ,
                                                 AV142Almacen_productoswwds_29_tfproddsc_sel ,
                                                 AV141Almacen_productoswwds_28_tfproddsc ,
                                                 AV143Almacen_productoswwds_30_tfsublcod ,
                                                 AV144Almacen_productoswwds_31_tfsublcod_to ,
                                                 AV145Almacen_productoswwds_32_tffamcod ,
                                                 AV146Almacen_productoswwds_33_tffamcod_to ,
                                                 AV147Almacen_productoswwds_34_tfunicod ,
                                                 AV148Almacen_productoswwds_35_tfunicod_to ,
                                                 AV149Almacen_productoswwds_36_tfprodvta_sel ,
                                                 AV150Almacen_productoswwds_37_tfprodcmp_sel ,
                                                 AV151Almacen_productoswwds_38_tfprodpeso ,
                                                 AV152Almacen_productoswwds_39_tfprodpeso_to ,
                                                 AV153Almacen_productoswwds_40_tfprodvolumen ,
                                                 AV154Almacen_productoswwds_41_tfprodvolumen_to ,
                                                 AV155Almacen_productoswwds_42_tfprodstkmax ,
                                                 AV156Almacen_productoswwds_43_tfprodstkmax_to ,
                                                 AV157Almacen_productoswwds_44_tfprodstkmin ,
                                                 AV158Almacen_productoswwds_45_tfprodstkmin_to ,
                                                 AV160Almacen_productoswwds_47_tfprodref1_sel ,
                                                 AV159Almacen_productoswwds_46_tfprodref1 ,
                                                 AV162Almacen_productoswwds_49_tfprodref2_sel ,
                                                 AV161Almacen_productoswwds_48_tfprodref2 ,
                                                 AV164Almacen_productoswwds_51_tfprodref3_sel ,
                                                 AV163Almacen_productoswwds_50_tfprodref3 ,
                                                 AV166Almacen_productoswwds_53_tfprodref4_sel ,
                                                 AV165Almacen_productoswwds_52_tfprodref4 ,
                                                 AV168Almacen_productoswwds_55_tfprodref5_sel ,
                                                 AV167Almacen_productoswwds_54_tfprodref5 ,
                                                 AV170Almacen_productoswwds_57_tfprodref6_sel ,
                                                 AV169Almacen_productoswwds_56_tfprodref6 ,
                                                 AV172Almacen_productoswwds_59_tfprodref7_sel ,
                                                 AV171Almacen_productoswwds_58_tfprodref7 ,
                                                 AV174Almacen_productoswwds_61_tfprodref8_sel ,
                                                 AV173Almacen_productoswwds_60_tfprodref8 ,
                                                 AV176Almacen_productoswwds_63_tfprodref9_sel ,
                                                 AV175Almacen_productoswwds_62_tfprodref9 ,
                                                 AV178Almacen_productoswwds_65_tfprodref10_sel ,
                                                 AV177Almacen_productoswwds_64_tfprodref10 ,
                                                 AV179Almacen_productoswwds_66_tfprodsts_sels.Count ,
                                                 AV180Almacen_productoswwds_67_tfprodcosto ,
                                                 AV181Almacen_productoswwds_68_tfprodcosto_to ,
                                                 A55ProdDsc ,
                                                 A1686ProdCuentaVDsc ,
                                                 A1685ProdCuentaCDsc ,
                                                 A1684ProdCuentaADsc ,
                                                 A1153LinDsc ,
                                                 A28ProdCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A49UniCod ,
                                                 A1724ProdVta ,
                                                 A1679ProdCmp ,
                                                 A1702ProdPeso ,
                                                 A1723ProdVolumen ,
                                                 A1716ProdStkMax ,
                                                 A1717ProdStkMin ,
                                                 A1705ProdRef1 ,
                                                 A1707ProdRef2 ,
                                                 A1708ProdRef3 ,
                                                 A1709ProdRef4 ,
                                                 A1710ProdRef5 ,
                                                 A1711ProdRef6 ,
                                                 A1712ProdRef7 ,
                                                 A1713ProdRef8 ,
                                                 A1714ProdRef9 ,
                                                 A1706ProdRef10 ,
                                                 A1681ProdCosto ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV116Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1), 100, "%");
            lV116Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1), 100, "%");
            lV117Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
            lV117Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
            lV118Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
            lV118Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
            lV119Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
            lV119Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
            lV120Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1), 100, "%");
            lV120Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1), 100, "%");
            lV124Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2), 100, "%");
            lV124Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2), 100, "%");
            lV125Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
            lV125Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
            lV126Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
            lV126Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
            lV127Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
            lV127Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
            lV128Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2), 100, "%");
            lV128Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2), 100, "%");
            lV132Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3), 100, "%");
            lV132Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3), 100, "%");
            lV133Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
            lV133Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
            lV134Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
            lV134Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
            lV135Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
            lV135Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
            lV136Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3), 100, "%");
            lV136Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3), 100, "%");
            lV137Almacen_productoswwds_24_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV137Almacen_productoswwds_24_tfprodcod), 15, "%");
            lV141Almacen_productoswwds_28_tfproddsc = StringUtil.PadR( StringUtil.RTrim( AV141Almacen_productoswwds_28_tfproddsc), 100, "%");
            lV159Almacen_productoswwds_46_tfprodref1 = StringUtil.PadR( StringUtil.RTrim( AV159Almacen_productoswwds_46_tfprodref1), 20, "%");
            lV161Almacen_productoswwds_48_tfprodref2 = StringUtil.PadR( StringUtil.RTrim( AV161Almacen_productoswwds_48_tfprodref2), 20, "%");
            lV163Almacen_productoswwds_50_tfprodref3 = StringUtil.PadR( StringUtil.RTrim( AV163Almacen_productoswwds_50_tfprodref3), 20, "%");
            lV165Almacen_productoswwds_52_tfprodref4 = StringUtil.PadR( StringUtil.RTrim( AV165Almacen_productoswwds_52_tfprodref4), 20, "%");
            lV167Almacen_productoswwds_54_tfprodref5 = StringUtil.PadR( StringUtil.RTrim( AV167Almacen_productoswwds_54_tfprodref5), 20, "%");
            lV169Almacen_productoswwds_56_tfprodref6 = StringUtil.PadR( StringUtil.RTrim( AV169Almacen_productoswwds_56_tfprodref6), 20, "%");
            lV171Almacen_productoswwds_58_tfprodref7 = StringUtil.PadR( StringUtil.RTrim( AV171Almacen_productoswwds_58_tfprodref7), 20, "%");
            lV173Almacen_productoswwds_60_tfprodref8 = StringUtil.PadR( StringUtil.RTrim( AV173Almacen_productoswwds_60_tfprodref8), 20, "%");
            lV175Almacen_productoswwds_62_tfprodref9 = StringUtil.PadR( StringUtil.RTrim( AV175Almacen_productoswwds_62_tfprodref9), 20, "%");
            lV177Almacen_productoswwds_64_tfprodref10 = StringUtil.PadR( StringUtil.RTrim( AV177Almacen_productoswwds_64_tfprodref10), 20, "%");
            /* Using cursor H004R2 */
            pr_default.execute(0, new Object[] {lV116Almacen_productoswwds_3_proddsc1, lV116Almacen_productoswwds_3_proddsc1, lV117Almacen_productoswwds_4_prodcuentavdsc1, lV117Almacen_productoswwds_4_prodcuentavdsc1, lV118Almacen_productoswwds_5_prodcuentacdsc1, lV118Almacen_productoswwds_5_prodcuentacdsc1, lV119Almacen_productoswwds_6_prodcuentaadsc1, lV119Almacen_productoswwds_6_prodcuentaadsc1, lV120Almacen_productoswwds_7_lindsc1, lV120Almacen_productoswwds_7_lindsc1, lV124Almacen_productoswwds_11_proddsc2, lV124Almacen_productoswwds_11_proddsc2, lV125Almacen_productoswwds_12_prodcuentavdsc2, lV125Almacen_productoswwds_12_prodcuentavdsc2, lV126Almacen_productoswwds_13_prodcuentacdsc2, lV126Almacen_productoswwds_13_prodcuentacdsc2, lV127Almacen_productoswwds_14_prodcuentaadsc2, lV127Almacen_productoswwds_14_prodcuentaadsc2, lV128Almacen_productoswwds_15_lindsc2, lV128Almacen_productoswwds_15_lindsc2, lV132Almacen_productoswwds_19_proddsc3, lV132Almacen_productoswwds_19_proddsc3, lV133Almacen_productoswwds_20_prodcuentavdsc3, lV133Almacen_productoswwds_20_prodcuentavdsc3, lV134Almacen_productoswwds_21_prodcuentacdsc3, lV134Almacen_productoswwds_21_prodcuentacdsc3, lV135Almacen_productoswwds_22_prodcuentaadsc3, lV135Almacen_productoswwds_22_prodcuentaadsc3, lV136Almacen_productoswwds_23_lindsc3, lV136Almacen_productoswwds_23_lindsc3, lV137Almacen_productoswwds_24_tfprodcod, AV138Almacen_productoswwds_25_tfprodcod_sel, AV139Almacen_productoswwds_26_tflincod, AV140Almacen_productoswwds_27_tflincod_to, lV141Almacen_productoswwds_28_tfproddsc, AV142Almacen_productoswwds_29_tfproddsc_sel, AV143Almacen_productoswwds_30_tfsublcod, AV144Almacen_productoswwds_31_tfsublcod_to, AV145Almacen_productoswwds_32_tffamcod, AV146Almacen_productoswwds_33_tffamcod_to, AV147Almacen_productoswwds_34_tfunicod, AV148Almacen_productoswwds_35_tfunicod_to, AV151Almacen_productoswwds_38_tfprodpeso, AV152Almacen_productoswwds_39_tfprodpeso_to, AV153Almacen_productoswwds_40_tfprodvolumen, AV154Almacen_productoswwds_41_tfprodvolumen_to, AV155Almacen_productoswwds_42_tfprodstkmax, AV156Almacen_productoswwds_43_tfprodstkmax_to, AV157Almacen_productoswwds_44_tfprodstkmin, AV158Almacen_productoswwds_45_tfprodstkmin_to, lV159Almacen_productoswwds_46_tfprodref1, AV160Almacen_productoswwds_47_tfprodref1_sel, lV161Almacen_productoswwds_48_tfprodref2, AV162Almacen_productoswwds_49_tfprodref2_sel, lV163Almacen_productoswwds_50_tfprodref3, AV164Almacen_productoswwds_51_tfprodref3_sel, lV165Almacen_productoswwds_52_tfprodref4, AV166Almacen_productoswwds_53_tfprodref4_sel, lV167Almacen_productoswwds_54_tfprodref5, AV168Almacen_productoswwds_55_tfprodref5_sel, lV169Almacen_productoswwds_56_tfprodref6, AV170Almacen_productoswwds_57_tfprodref6_sel, lV171Almacen_productoswwds_58_tfprodref7, AV172Almacen_productoswwds_59_tfprodref7_sel, lV173Almacen_productoswwds_60_tfprodref8, AV174Almacen_productoswwds_61_tfprodref8_sel, lV175Almacen_productoswwds_62_tfprodref9, AV176Almacen_productoswwds_63_tfprodref9_sel, lV177Almacen_productoswwds_64_tfprodref10, AV178Almacen_productoswwds_65_tfprodref10_sel, AV180Almacen_productoswwds_67_tfprodcosto, AV181Almacen_productoswwds_68_tfprodcosto_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_137_idx = 1;
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A48ProdCuentaV = H004R2_A48ProdCuentaV[0];
               n48ProdCuentaV = H004R2_n48ProdCuentaV[0];
               A53ProdCuentaC = H004R2_A53ProdCuentaC[0];
               n53ProdCuentaC = H004R2_n53ProdCuentaC[0];
               A54ProdCuentaA = H004R2_A54ProdCuentaA[0];
               n54ProdCuentaA = H004R2_n54ProdCuentaA[0];
               A1153LinDsc = H004R2_A1153LinDsc[0];
               A1684ProdCuentaADsc = H004R2_A1684ProdCuentaADsc[0];
               A1685ProdCuentaCDsc = H004R2_A1685ProdCuentaCDsc[0];
               A1686ProdCuentaVDsc = H004R2_A1686ProdCuentaVDsc[0];
               A1681ProdCosto = H004R2_A1681ProdCosto[0];
               A1718ProdSts = H004R2_A1718ProdSts[0];
               A1706ProdRef10 = H004R2_A1706ProdRef10[0];
               A1714ProdRef9 = H004R2_A1714ProdRef9[0];
               A1713ProdRef8 = H004R2_A1713ProdRef8[0];
               A1712ProdRef7 = H004R2_A1712ProdRef7[0];
               A1711ProdRef6 = H004R2_A1711ProdRef6[0];
               A1710ProdRef5 = H004R2_A1710ProdRef5[0];
               A1709ProdRef4 = H004R2_A1709ProdRef4[0];
               A1708ProdRef3 = H004R2_A1708ProdRef3[0];
               A1707ProdRef2 = H004R2_A1707ProdRef2[0];
               A1705ProdRef1 = H004R2_A1705ProdRef1[0];
               A40000ProdFoto_GXI = H004R2_A40000ProdFoto_GXI[0];
               n40000ProdFoto_GXI = H004R2_n40000ProdFoto_GXI[0];
               AssignProp("", false, edtProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), !bGXsfl_137_Refreshing);
               AssignProp("", false, edtProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
               A1717ProdStkMin = H004R2_A1717ProdStkMin[0];
               A1716ProdStkMax = H004R2_A1716ProdStkMax[0];
               A1723ProdVolumen = H004R2_A1723ProdVolumen[0];
               A1702ProdPeso = H004R2_A1702ProdPeso[0];
               A1679ProdCmp = H004R2_A1679ProdCmp[0];
               A1724ProdVta = H004R2_A1724ProdVta[0];
               A49UniCod = H004R2_A49UniCod[0];
               A50FamCod = H004R2_A50FamCod[0];
               n50FamCod = H004R2_n50FamCod[0];
               A51SublCod = H004R2_A51SublCod[0];
               n51SublCod = H004R2_n51SublCod[0];
               A55ProdDsc = H004R2_A55ProdDsc[0];
               A52LinCod = H004R2_A52LinCod[0];
               A28ProdCod = H004R2_A28ProdCod[0];
               A1695ProdFoto = H004R2_A1695ProdFoto[0];
               n1695ProdFoto = H004R2_n1695ProdFoto[0];
               AssignProp("", false, edtProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), !bGXsfl_137_Refreshing);
               AssignProp("", false, edtProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
               A1686ProdCuentaVDsc = H004R2_A1686ProdCuentaVDsc[0];
               A1685ProdCuentaCDsc = H004R2_A1685ProdCuentaCDsc[0];
               A1684ProdCuentaADsc = H004R2_A1684ProdCuentaADsc[0];
               A1153LinDsc = H004R2_A1153LinDsc[0];
               E264R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 137;
            WB4R0( ) ;
         }
         bGXsfl_137_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV113Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV113Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODCOD"+"_"+sGXsfl_137_idx, GetSecureSignedToken( sGXsfl_137_idx, StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1718ProdSts ,
                                              AV179Almacen_productoswwds_66_tfprodsts_sels ,
                                              AV114Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                              AV115Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                              AV116Almacen_productoswwds_3_proddsc1 ,
                                              AV117Almacen_productoswwds_4_prodcuentavdsc1 ,
                                              AV118Almacen_productoswwds_5_prodcuentacdsc1 ,
                                              AV119Almacen_productoswwds_6_prodcuentaadsc1 ,
                                              AV120Almacen_productoswwds_7_lindsc1 ,
                                              AV121Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                              AV122Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                              AV123Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                              AV124Almacen_productoswwds_11_proddsc2 ,
                                              AV125Almacen_productoswwds_12_prodcuentavdsc2 ,
                                              AV126Almacen_productoswwds_13_prodcuentacdsc2 ,
                                              AV127Almacen_productoswwds_14_prodcuentaadsc2 ,
                                              AV128Almacen_productoswwds_15_lindsc2 ,
                                              AV129Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                              AV130Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                              AV131Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                              AV132Almacen_productoswwds_19_proddsc3 ,
                                              AV133Almacen_productoswwds_20_prodcuentavdsc3 ,
                                              AV134Almacen_productoswwds_21_prodcuentacdsc3 ,
                                              AV135Almacen_productoswwds_22_prodcuentaadsc3 ,
                                              AV136Almacen_productoswwds_23_lindsc3 ,
                                              AV138Almacen_productoswwds_25_tfprodcod_sel ,
                                              AV137Almacen_productoswwds_24_tfprodcod ,
                                              AV139Almacen_productoswwds_26_tflincod ,
                                              AV140Almacen_productoswwds_27_tflincod_to ,
                                              AV142Almacen_productoswwds_29_tfproddsc_sel ,
                                              AV141Almacen_productoswwds_28_tfproddsc ,
                                              AV143Almacen_productoswwds_30_tfsublcod ,
                                              AV144Almacen_productoswwds_31_tfsublcod_to ,
                                              AV145Almacen_productoswwds_32_tffamcod ,
                                              AV146Almacen_productoswwds_33_tffamcod_to ,
                                              AV147Almacen_productoswwds_34_tfunicod ,
                                              AV148Almacen_productoswwds_35_tfunicod_to ,
                                              AV149Almacen_productoswwds_36_tfprodvta_sel ,
                                              AV150Almacen_productoswwds_37_tfprodcmp_sel ,
                                              AV151Almacen_productoswwds_38_tfprodpeso ,
                                              AV152Almacen_productoswwds_39_tfprodpeso_to ,
                                              AV153Almacen_productoswwds_40_tfprodvolumen ,
                                              AV154Almacen_productoswwds_41_tfprodvolumen_to ,
                                              AV155Almacen_productoswwds_42_tfprodstkmax ,
                                              AV156Almacen_productoswwds_43_tfprodstkmax_to ,
                                              AV157Almacen_productoswwds_44_tfprodstkmin ,
                                              AV158Almacen_productoswwds_45_tfprodstkmin_to ,
                                              AV160Almacen_productoswwds_47_tfprodref1_sel ,
                                              AV159Almacen_productoswwds_46_tfprodref1 ,
                                              AV162Almacen_productoswwds_49_tfprodref2_sel ,
                                              AV161Almacen_productoswwds_48_tfprodref2 ,
                                              AV164Almacen_productoswwds_51_tfprodref3_sel ,
                                              AV163Almacen_productoswwds_50_tfprodref3 ,
                                              AV166Almacen_productoswwds_53_tfprodref4_sel ,
                                              AV165Almacen_productoswwds_52_tfprodref4 ,
                                              AV168Almacen_productoswwds_55_tfprodref5_sel ,
                                              AV167Almacen_productoswwds_54_tfprodref5 ,
                                              AV170Almacen_productoswwds_57_tfprodref6_sel ,
                                              AV169Almacen_productoswwds_56_tfprodref6 ,
                                              AV172Almacen_productoswwds_59_tfprodref7_sel ,
                                              AV171Almacen_productoswwds_58_tfprodref7 ,
                                              AV174Almacen_productoswwds_61_tfprodref8_sel ,
                                              AV173Almacen_productoswwds_60_tfprodref8 ,
                                              AV176Almacen_productoswwds_63_tfprodref9_sel ,
                                              AV175Almacen_productoswwds_62_tfprodref9 ,
                                              AV178Almacen_productoswwds_65_tfprodref10_sel ,
                                              AV177Almacen_productoswwds_64_tfprodref10 ,
                                              AV179Almacen_productoswwds_66_tfprodsts_sels.Count ,
                                              AV180Almacen_productoswwds_67_tfprodcosto ,
                                              AV181Almacen_productoswwds_68_tfprodcosto_to ,
                                              A55ProdDsc ,
                                              A1686ProdCuentaVDsc ,
                                              A1685ProdCuentaCDsc ,
                                              A1684ProdCuentaADsc ,
                                              A1153LinDsc ,
                                              A28ProdCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A49UniCod ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1702ProdPeso ,
                                              A1723ProdVolumen ,
                                              A1716ProdStkMax ,
                                              A1717ProdStkMin ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1681ProdCosto ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV116Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1), 100, "%");
         lV116Almacen_productoswwds_3_proddsc1 = StringUtil.PadR( StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1), 100, "%");
         lV117Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV117Almacen_productoswwds_4_prodcuentavdsc1 = StringUtil.PadR( StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1), 100, "%");
         lV118Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV118Almacen_productoswwds_5_prodcuentacdsc1 = StringUtil.PadR( StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1), 100, "%");
         lV119Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV119Almacen_productoswwds_6_prodcuentaadsc1 = StringUtil.PadR( StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1), 100, "%");
         lV120Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1), 100, "%");
         lV120Almacen_productoswwds_7_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1), 100, "%");
         lV124Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2), 100, "%");
         lV124Almacen_productoswwds_11_proddsc2 = StringUtil.PadR( StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2), 100, "%");
         lV125Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV125Almacen_productoswwds_12_prodcuentavdsc2 = StringUtil.PadR( StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2), 100, "%");
         lV126Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV126Almacen_productoswwds_13_prodcuentacdsc2 = StringUtil.PadR( StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2), 100, "%");
         lV127Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV127Almacen_productoswwds_14_prodcuentaadsc2 = StringUtil.PadR( StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2), 100, "%");
         lV128Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2), 100, "%");
         lV128Almacen_productoswwds_15_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2), 100, "%");
         lV132Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3), 100, "%");
         lV132Almacen_productoswwds_19_proddsc3 = StringUtil.PadR( StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3), 100, "%");
         lV133Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV133Almacen_productoswwds_20_prodcuentavdsc3 = StringUtil.PadR( StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3), 100, "%");
         lV134Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV134Almacen_productoswwds_21_prodcuentacdsc3 = StringUtil.PadR( StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3), 100, "%");
         lV135Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV135Almacen_productoswwds_22_prodcuentaadsc3 = StringUtil.PadR( StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3), 100, "%");
         lV136Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3), 100, "%");
         lV136Almacen_productoswwds_23_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3), 100, "%");
         lV137Almacen_productoswwds_24_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV137Almacen_productoswwds_24_tfprodcod), 15, "%");
         lV141Almacen_productoswwds_28_tfproddsc = StringUtil.PadR( StringUtil.RTrim( AV141Almacen_productoswwds_28_tfproddsc), 100, "%");
         lV159Almacen_productoswwds_46_tfprodref1 = StringUtil.PadR( StringUtil.RTrim( AV159Almacen_productoswwds_46_tfprodref1), 20, "%");
         lV161Almacen_productoswwds_48_tfprodref2 = StringUtil.PadR( StringUtil.RTrim( AV161Almacen_productoswwds_48_tfprodref2), 20, "%");
         lV163Almacen_productoswwds_50_tfprodref3 = StringUtil.PadR( StringUtil.RTrim( AV163Almacen_productoswwds_50_tfprodref3), 20, "%");
         lV165Almacen_productoswwds_52_tfprodref4 = StringUtil.PadR( StringUtil.RTrim( AV165Almacen_productoswwds_52_tfprodref4), 20, "%");
         lV167Almacen_productoswwds_54_tfprodref5 = StringUtil.PadR( StringUtil.RTrim( AV167Almacen_productoswwds_54_tfprodref5), 20, "%");
         lV169Almacen_productoswwds_56_tfprodref6 = StringUtil.PadR( StringUtil.RTrim( AV169Almacen_productoswwds_56_tfprodref6), 20, "%");
         lV171Almacen_productoswwds_58_tfprodref7 = StringUtil.PadR( StringUtil.RTrim( AV171Almacen_productoswwds_58_tfprodref7), 20, "%");
         lV173Almacen_productoswwds_60_tfprodref8 = StringUtil.PadR( StringUtil.RTrim( AV173Almacen_productoswwds_60_tfprodref8), 20, "%");
         lV175Almacen_productoswwds_62_tfprodref9 = StringUtil.PadR( StringUtil.RTrim( AV175Almacen_productoswwds_62_tfprodref9), 20, "%");
         lV177Almacen_productoswwds_64_tfprodref10 = StringUtil.PadR( StringUtil.RTrim( AV177Almacen_productoswwds_64_tfprodref10), 20, "%");
         /* Using cursor H004R3 */
         pr_default.execute(1, new Object[] {lV116Almacen_productoswwds_3_proddsc1, lV116Almacen_productoswwds_3_proddsc1, lV117Almacen_productoswwds_4_prodcuentavdsc1, lV117Almacen_productoswwds_4_prodcuentavdsc1, lV118Almacen_productoswwds_5_prodcuentacdsc1, lV118Almacen_productoswwds_5_prodcuentacdsc1, lV119Almacen_productoswwds_6_prodcuentaadsc1, lV119Almacen_productoswwds_6_prodcuentaadsc1, lV120Almacen_productoswwds_7_lindsc1, lV120Almacen_productoswwds_7_lindsc1, lV124Almacen_productoswwds_11_proddsc2, lV124Almacen_productoswwds_11_proddsc2, lV125Almacen_productoswwds_12_prodcuentavdsc2, lV125Almacen_productoswwds_12_prodcuentavdsc2, lV126Almacen_productoswwds_13_prodcuentacdsc2, lV126Almacen_productoswwds_13_prodcuentacdsc2, lV127Almacen_productoswwds_14_prodcuentaadsc2, lV127Almacen_productoswwds_14_prodcuentaadsc2, lV128Almacen_productoswwds_15_lindsc2, lV128Almacen_productoswwds_15_lindsc2, lV132Almacen_productoswwds_19_proddsc3, lV132Almacen_productoswwds_19_proddsc3, lV133Almacen_productoswwds_20_prodcuentavdsc3, lV133Almacen_productoswwds_20_prodcuentavdsc3, lV134Almacen_productoswwds_21_prodcuentacdsc3, lV134Almacen_productoswwds_21_prodcuentacdsc3, lV135Almacen_productoswwds_22_prodcuentaadsc3, lV135Almacen_productoswwds_22_prodcuentaadsc3, lV136Almacen_productoswwds_23_lindsc3, lV136Almacen_productoswwds_23_lindsc3, lV137Almacen_productoswwds_24_tfprodcod, AV138Almacen_productoswwds_25_tfprodcod_sel, AV139Almacen_productoswwds_26_tflincod, AV140Almacen_productoswwds_27_tflincod_to, lV141Almacen_productoswwds_28_tfproddsc, AV142Almacen_productoswwds_29_tfproddsc_sel, AV143Almacen_productoswwds_30_tfsublcod, AV144Almacen_productoswwds_31_tfsublcod_to, AV145Almacen_productoswwds_32_tffamcod, AV146Almacen_productoswwds_33_tffamcod_to, AV147Almacen_productoswwds_34_tfunicod, AV148Almacen_productoswwds_35_tfunicod_to, AV151Almacen_productoswwds_38_tfprodpeso, AV152Almacen_productoswwds_39_tfprodpeso_to, AV153Almacen_productoswwds_40_tfprodvolumen, AV154Almacen_productoswwds_41_tfprodvolumen_to, AV155Almacen_productoswwds_42_tfprodstkmax, AV156Almacen_productoswwds_43_tfprodstkmax_to, AV157Almacen_productoswwds_44_tfprodstkmin, AV158Almacen_productoswwds_45_tfprodstkmin_to, lV159Almacen_productoswwds_46_tfprodref1, AV160Almacen_productoswwds_47_tfprodref1_sel, lV161Almacen_productoswwds_48_tfprodref2, AV162Almacen_productoswwds_49_tfprodref2_sel, lV163Almacen_productoswwds_50_tfprodref3, AV164Almacen_productoswwds_51_tfprodref3_sel, lV165Almacen_productoswwds_52_tfprodref4, AV166Almacen_productoswwds_53_tfprodref4_sel, lV167Almacen_productoswwds_54_tfprodref5, AV168Almacen_productoswwds_55_tfprodref5_sel, lV169Almacen_productoswwds_56_tfprodref6, AV170Almacen_productoswwds_57_tfprodref6_sel, lV171Almacen_productoswwds_58_tfprodref7, AV172Almacen_productoswwds_59_tfprodref7_sel, lV173Almacen_productoswwds_60_tfprodref8, AV174Almacen_productoswwds_61_tfprodref8_sel, lV175Almacen_productoswwds_62_tfprodref9, AV176Almacen_productoswwds_63_tfprodref9_sel, lV177Almacen_productoswwds_64_tfprodref10, AV178Almacen_productoswwds_65_tfprodref10_sel, AV180Almacen_productoswwds_67_tfprodcosto, AV181Almacen_productoswwds_68_tfprodcosto_to});
         GRID_nRecordCount = H004R3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV113Pgmname = "Almacen.ProductosWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E244R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV94AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV88DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_137 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_137"), ".", ","));
            AV90GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV91GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV92GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tableheader_Width = cgiGet( "DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( "DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( "DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( "DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ".", ","));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ".", ","));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AV17ProdDsc1 = cgiGet( edtavProddsc1_Internalname);
            AssignAttri("", false, "AV17ProdDsc1", AV17ProdDsc1);
            AV18ProdCuentaVDsc1 = cgiGet( edtavProdcuentavdsc1_Internalname);
            AssignAttri("", false, "AV18ProdCuentaVDsc1", AV18ProdCuentaVDsc1);
            AV19ProdCuentaCDsc1 = cgiGet( edtavProdcuentacdsc1_Internalname);
            AssignAttri("", false, "AV19ProdCuentaCDsc1", AV19ProdCuentaCDsc1);
            AV20ProdCuentaADsc1 = cgiGet( edtavProdcuentaadsc1_Internalname);
            AssignAttri("", false, "AV20ProdCuentaADsc1", AV20ProdCuentaADsc1);
            AV108LinDsc1 = cgiGet( edtavLindsc1_Internalname);
            AssignAttri("", false, "AV108LinDsc1", AV108LinDsc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24ProdDsc2 = cgiGet( edtavProddsc2_Internalname);
            AssignAttri("", false, "AV24ProdDsc2", AV24ProdDsc2);
            AV25ProdCuentaVDsc2 = cgiGet( edtavProdcuentavdsc2_Internalname);
            AssignAttri("", false, "AV25ProdCuentaVDsc2", AV25ProdCuentaVDsc2);
            AV26ProdCuentaCDsc2 = cgiGet( edtavProdcuentacdsc2_Internalname);
            AssignAttri("", false, "AV26ProdCuentaCDsc2", AV26ProdCuentaCDsc2);
            AV27ProdCuentaADsc2 = cgiGet( edtavProdcuentaadsc2_Internalname);
            AssignAttri("", false, "AV27ProdCuentaADsc2", AV27ProdCuentaADsc2);
            AV109LinDsc2 = cgiGet( edtavLindsc2_Internalname);
            AssignAttri("", false, "AV109LinDsc2", AV109LinDsc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV29DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV30DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AV31ProdDsc3 = cgiGet( edtavProddsc3_Internalname);
            AssignAttri("", false, "AV31ProdDsc3", AV31ProdDsc3);
            AV32ProdCuentaVDsc3 = cgiGet( edtavProdcuentavdsc3_Internalname);
            AssignAttri("", false, "AV32ProdCuentaVDsc3", AV32ProdCuentaVDsc3);
            AV33ProdCuentaCDsc3 = cgiGet( edtavProdcuentacdsc3_Internalname);
            AssignAttri("", false, "AV33ProdCuentaCDsc3", AV33ProdCuentaCDsc3);
            AV34ProdCuentaADsc3 = cgiGet( edtavProdcuentaadsc3_Internalname);
            AssignAttri("", false, "AV34ProdCuentaADsc3", AV34ProdCuentaADsc3);
            AV110LinDsc3 = cgiGet( edtavLindsc3_Internalname);
            AssignAttri("", false, "AV110LinDsc3", AV110LinDsc3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ".", ",") != Convert.ToDecimal( AV16DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC1"), AV17ProdDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC1"), AV18ProdCuentaVDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC1"), AV19ProdCuentaCDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC1"), AV20ProdCuentaADsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC1"), AV108LinDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC2"), AV24ProdDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC2"), AV25ProdCuentaVDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC2"), AV26ProdCuentaCDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC2"), AV27ProdCuentaADsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC2"), AV109LinDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODDSC3"), AV31ProdDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAVDSC3"), AV32ProdCuentaVDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTACDSC3"), AV33ProdCuentaCDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODCUENTAADSC3"), AV34ProdCuentaADsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLINDSC3"), AV110LinDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E244R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E244R2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "PRODDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "PRODDSC";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector3 = "PRODDSC";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV94AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV95AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV95AGExportDataItem.gxTpr_Title = "PDF";
         AV95AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV95AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV95AGExportDataItem.gxTpr_Isdivider = false;
         AV94AGExportData.Add(AV95AGExportDataItem, 0);
         AV95AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV95AGExportDataItem.gxTpr_Title = "Excel";
         AV95AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV95AGExportDataItem.gxTpr_Eventkey = "Export";
         AV95AGExportDataItem.gxTpr_Isdivider = false;
         AV94AGExportData.Add(AV95AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Productos";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV88DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV88DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E254R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "LINDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LINDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV28DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "LINDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV90GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV90GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV90GridCurrentPage), 10, 0));
         AV91GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV91GridPageCount", StringUtil.LTrimStr( (decimal)(AV91GridPageCount), 10, 0));
         GXt_char2 = AV92GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV113Pgmname, out  GXt_char2) ;
         AV92GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV92GridAppliedFilters", AV92GridAppliedFilters);
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV115Almacen_productoswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV116Almacen_productoswwds_3_proddsc1 = AV17ProdDsc1;
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = AV18ProdCuentaVDsc1;
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = AV19ProdCuentaCDsc1;
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = AV20ProdCuentaADsc1;
         AV120Almacen_productoswwds_7_lindsc1 = AV108LinDsc1;
         AV121Almacen_productoswwds_8_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV123Almacen_productoswwds_10_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV124Almacen_productoswwds_11_proddsc2 = AV24ProdDsc2;
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = AV25ProdCuentaVDsc2;
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = AV26ProdCuentaCDsc2;
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = AV27ProdCuentaADsc2;
         AV128Almacen_productoswwds_15_lindsc2 = AV109LinDsc2;
         AV129Almacen_productoswwds_16_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV131Almacen_productoswwds_18_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV132Almacen_productoswwds_19_proddsc3 = AV31ProdDsc3;
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = AV32ProdCuentaVDsc3;
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = AV33ProdCuentaCDsc3;
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = AV34ProdCuentaADsc3;
         AV136Almacen_productoswwds_23_lindsc3 = AV110LinDsc3;
         AV137Almacen_productoswwds_24_tfprodcod = AV40TFProdCod;
         AV138Almacen_productoswwds_25_tfprodcod_sel = AV41TFProdCod_Sel;
         AV139Almacen_productoswwds_26_tflincod = AV42TFLinCod;
         AV140Almacen_productoswwds_27_tflincod_to = AV43TFLinCod_To;
         AV141Almacen_productoswwds_28_tfproddsc = AV44TFProdDsc;
         AV142Almacen_productoswwds_29_tfproddsc_sel = AV45TFProdDsc_Sel;
         AV143Almacen_productoswwds_30_tfsublcod = AV46TFSublCod;
         AV144Almacen_productoswwds_31_tfsublcod_to = AV47TFSublCod_To;
         AV145Almacen_productoswwds_32_tffamcod = AV48TFFamCod;
         AV146Almacen_productoswwds_33_tffamcod_to = AV49TFFamCod_To;
         AV147Almacen_productoswwds_34_tfunicod = AV50TFUniCod;
         AV148Almacen_productoswwds_35_tfunicod_to = AV51TFUniCod_To;
         AV149Almacen_productoswwds_36_tfprodvta_sel = AV103TFProdVta_Sel;
         AV150Almacen_productoswwds_37_tfprodcmp_sel = AV104TFProdCmp_Sel;
         AV151Almacen_productoswwds_38_tfprodpeso = AV56TFProdPeso;
         AV152Almacen_productoswwds_39_tfprodpeso_to = AV57TFProdPeso_To;
         AV153Almacen_productoswwds_40_tfprodvolumen = AV58TFProdVolumen;
         AV154Almacen_productoswwds_41_tfprodvolumen_to = AV59TFProdVolumen_To;
         AV155Almacen_productoswwds_42_tfprodstkmax = AV60TFProdStkMax;
         AV156Almacen_productoswwds_43_tfprodstkmax_to = AV61TFProdStkMax_To;
         AV157Almacen_productoswwds_44_tfprodstkmin = AV62TFProdStkMin;
         AV158Almacen_productoswwds_45_tfprodstkmin_to = AV63TFProdStkMin_To;
         AV159Almacen_productoswwds_46_tfprodref1 = AV64TFProdRef1;
         AV160Almacen_productoswwds_47_tfprodref1_sel = AV65TFProdRef1_Sel;
         AV161Almacen_productoswwds_48_tfprodref2 = AV66TFProdRef2;
         AV162Almacen_productoswwds_49_tfprodref2_sel = AV67TFProdRef2_Sel;
         AV163Almacen_productoswwds_50_tfprodref3 = AV68TFProdRef3;
         AV164Almacen_productoswwds_51_tfprodref3_sel = AV69TFProdRef3_Sel;
         AV165Almacen_productoswwds_52_tfprodref4 = AV70TFProdRef4;
         AV166Almacen_productoswwds_53_tfprodref4_sel = AV71TFProdRef4_Sel;
         AV167Almacen_productoswwds_54_tfprodref5 = AV72TFProdRef5;
         AV168Almacen_productoswwds_55_tfprodref5_sel = AV73TFProdRef5_Sel;
         AV169Almacen_productoswwds_56_tfprodref6 = AV74TFProdRef6;
         AV170Almacen_productoswwds_57_tfprodref6_sel = AV75TFProdRef6_Sel;
         AV171Almacen_productoswwds_58_tfprodref7 = AV76TFProdRef7;
         AV172Almacen_productoswwds_59_tfprodref7_sel = AV77TFProdRef7_Sel;
         AV173Almacen_productoswwds_60_tfprodref8 = AV78TFProdRef8;
         AV174Almacen_productoswwds_61_tfprodref8_sel = AV79TFProdRef8_Sel;
         AV175Almacen_productoswwds_62_tfprodref9 = AV80TFProdRef9;
         AV176Almacen_productoswwds_63_tfprodref9_sel = AV81TFProdRef9_Sel;
         AV177Almacen_productoswwds_64_tfprodref10 = AV82TFProdRef10;
         AV178Almacen_productoswwds_65_tfprodref10_sel = AV83TFProdRef10_Sel;
         AV179Almacen_productoswwds_66_tfprodsts_sels = AV106TFProdSts_Sels;
         AV180Almacen_productoswwds_67_tfprodcosto = AV86TFProdCosto;
         AV181Almacen_productoswwds_68_tfprodcosto_to = AV87TFProdCosto_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E114R2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV89PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV89PageToGo) ;
         }
      }

      protected void E124R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E144R2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdCod") == 0 )
            {
               AV40TFProdCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFProdCod", AV40TFProdCod);
               AV41TFProdCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFProdCod_Sel", AV41TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LinCod") == 0 )
            {
               AV42TFLinCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV42TFLinCod", StringUtil.LTrimStr( (decimal)(AV42TFLinCod), 6, 0));
               AV43TFLinCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV43TFLinCod_To", StringUtil.LTrimStr( (decimal)(AV43TFLinCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdDsc") == 0 )
            {
               AV44TFProdDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFProdDsc", AV44TFProdDsc);
               AV45TFProdDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFProdDsc_Sel", AV45TFProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SublCod") == 0 )
            {
               AV46TFSublCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV46TFSublCod", StringUtil.LTrimStr( (decimal)(AV46TFSublCod), 6, 0));
               AV47TFSublCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV47TFSublCod_To", StringUtil.LTrimStr( (decimal)(AV47TFSublCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FamCod") == 0 )
            {
               AV48TFFamCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV48TFFamCod", StringUtil.LTrimStr( (decimal)(AV48TFFamCod), 6, 0));
               AV49TFFamCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV49TFFamCod_To", StringUtil.LTrimStr( (decimal)(AV49TFFamCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "UniCod") == 0 )
            {
               AV50TFUniCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV50TFUniCod", StringUtil.LTrimStr( (decimal)(AV50TFUniCod), 6, 0));
               AV51TFUniCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV51TFUniCod_To", StringUtil.LTrimStr( (decimal)(AV51TFUniCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdVta") == 0 )
            {
               AV103TFProdVta_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV103TFProdVta_Sel", StringUtil.Str( (decimal)(AV103TFProdVta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdCmp") == 0 )
            {
               AV104TFProdCmp_Sel = (short)(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."));
               AssignAttri("", false, "AV104TFProdCmp_Sel", StringUtil.Str( (decimal)(AV104TFProdCmp_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdPeso") == 0 )
            {
               AV56TFProdPeso = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV56TFProdPeso", StringUtil.LTrimStr( AV56TFProdPeso, 15, 5));
               AV57TFProdPeso_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV57TFProdPeso_To", StringUtil.LTrimStr( AV57TFProdPeso_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdVolumen") == 0 )
            {
               AV58TFProdVolumen = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV58TFProdVolumen", StringUtil.LTrimStr( AV58TFProdVolumen, 15, 5));
               AV59TFProdVolumen_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV59TFProdVolumen_To", StringUtil.LTrimStr( AV59TFProdVolumen_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdStkMax") == 0 )
            {
               AV60TFProdStkMax = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV60TFProdStkMax", StringUtil.LTrimStr( AV60TFProdStkMax, 15, 4));
               AV61TFProdStkMax_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV61TFProdStkMax_To", StringUtil.LTrimStr( AV61TFProdStkMax_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdStkMin") == 0 )
            {
               AV62TFProdStkMin = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV62TFProdStkMin", StringUtil.LTrimStr( AV62TFProdStkMin, 15, 4));
               AV63TFProdStkMin_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV63TFProdStkMin_To", StringUtil.LTrimStr( AV63TFProdStkMin_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef1") == 0 )
            {
               AV64TFProdRef1 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFProdRef1", AV64TFProdRef1);
               AV65TFProdRef1_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFProdRef1_Sel", AV65TFProdRef1_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef2") == 0 )
            {
               AV66TFProdRef2 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFProdRef2", AV66TFProdRef2);
               AV67TFProdRef2_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFProdRef2_Sel", AV67TFProdRef2_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef3") == 0 )
            {
               AV68TFProdRef3 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFProdRef3", AV68TFProdRef3);
               AV69TFProdRef3_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFProdRef3_Sel", AV69TFProdRef3_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef4") == 0 )
            {
               AV70TFProdRef4 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV70TFProdRef4", AV70TFProdRef4);
               AV71TFProdRef4_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV71TFProdRef4_Sel", AV71TFProdRef4_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef5") == 0 )
            {
               AV72TFProdRef5 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV72TFProdRef5", AV72TFProdRef5);
               AV73TFProdRef5_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFProdRef5_Sel", AV73TFProdRef5_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef6") == 0 )
            {
               AV74TFProdRef6 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFProdRef6", AV74TFProdRef6);
               AV75TFProdRef6_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFProdRef6_Sel", AV75TFProdRef6_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef7") == 0 )
            {
               AV76TFProdRef7 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV76TFProdRef7", AV76TFProdRef7);
               AV77TFProdRef7_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV77TFProdRef7_Sel", AV77TFProdRef7_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef8") == 0 )
            {
               AV78TFProdRef8 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV78TFProdRef8", AV78TFProdRef8);
               AV79TFProdRef8_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV79TFProdRef8_Sel", AV79TFProdRef8_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef9") == 0 )
            {
               AV80TFProdRef9 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV80TFProdRef9", AV80TFProdRef9);
               AV81TFProdRef9_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV81TFProdRef9_Sel", AV81TFProdRef9_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdRef10") == 0 )
            {
               AV82TFProdRef10 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV82TFProdRef10", AV82TFProdRef10);
               AV83TFProdRef10_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV83TFProdRef10_Sel", AV83TFProdRef10_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdSts") == 0 )
            {
               AV105TFProdSts_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV105TFProdSts_SelsJson", AV105TFProdSts_SelsJson);
               AV106TFProdSts_Sels.FromJSonString(StringUtil.StringReplace( AV105TFProdSts_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProdCosto") == 0 )
            {
               AV86TFProdCosto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV86TFProdCosto", StringUtil.LTrimStr( AV86TFProdCosto, 18, 5));
               AV87TFProdCosto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV87TFProdCosto_To", StringUtil.LTrimStr( AV87TFProdCosto_To, 18, 5));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV106TFProdSts_Sels", AV106TFProdSts_Sels);
      }

      private void E264R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A28ProdCod));
         edtProdDsc_Link = formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 137;
         }
         sendrow_1372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_137_Refreshing )
         {
            DoAjaxLoad(137, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0));
      }

      protected void E194R2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E154R2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E204R2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV16DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E214R2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E164R2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E224R2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E174R2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17ProdDsc1, AV18ProdCuentaVDsc1, AV19ProdCuentaCDsc1, AV20ProdCuentaADsc1, AV108LinDsc1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24ProdDsc2, AV25ProdCuentaVDsc2, AV26ProdCuentaCDsc2, AV27ProdCuentaADsc2, AV109LinDsc2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31ProdDsc3, AV32ProdCuentaVDsc3, AV33ProdCuentaCDsc3, AV34ProdCuentaADsc3, AV110LinDsc3, AV21DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV113Pgmname, AV40TFProdCod, AV41TFProdCod_Sel, AV42TFLinCod, AV43TFLinCod_To, AV44TFProdDsc, AV45TFProdDsc_Sel, AV46TFSublCod, AV47TFSublCod_To, AV48TFFamCod, AV49TFFamCod_To, AV50TFUniCod, AV51TFUniCod_To, AV103TFProdVta_Sel, AV104TFProdCmp_Sel, AV56TFProdPeso, AV57TFProdPeso_To, AV58TFProdVolumen, AV59TFProdVolumen_To, AV60TFProdStkMax, AV61TFProdStkMax_To, AV62TFProdStkMin, AV63TFProdStkMin_To, AV64TFProdRef1, AV65TFProdRef1_Sel, AV66TFProdRef2, AV67TFProdRef2_Sel, AV68TFProdRef3, AV69TFProdRef3_Sel, AV70TFProdRef4, AV71TFProdRef4_Sel, AV72TFProdRef5, AV73TFProdRef5_Sel, AV74TFProdRef6, AV75TFProdRef6_Sel, AV76TFProdRef7, AV77TFProdRef7_Sel, AV78TFProdRef8, AV79TFProdRef8_Sel, AV80TFProdRef9, AV81TFProdRef9_Sel, AV82TFProdRef10, AV83TFProdRef10_Sel, AV106TFProdSts_Sels, AV86TFProdCosto, AV87TFProdCosto_To, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV36DynamicFiltersIgnoreFirst, AV35DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E234R2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV30DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E274R2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV93GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV93GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV93GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV93GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E184R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E134R2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV106TFProdSts_Sels", AV106TFProdSts_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S162( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavProddsc1_Visible = 0;
         AssignProp("", false, edtavProddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc1_Visible), 5, 0), true);
         edtavProdcuentavdsc1_Visible = 0;
         AssignProp("", false, edtavProdcuentavdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc1_Visible), 5, 0), true);
         edtavProdcuentacdsc1_Visible = 0;
         AssignProp("", false, edtavProdcuentacdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc1_Visible), 5, 0), true);
         edtavProdcuentaadsc1_Visible = 0;
         AssignProp("", false, edtavProdcuentaadsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc1_Visible), 5, 0), true);
         edtavLindsc1_Visible = 0;
         AssignProp("", false, edtavLindsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODDSC") == 0 )
         {
            edtavProddsc1_Visible = 1;
            AssignProp("", false, edtavProddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 )
         {
            edtavProdcuentavdsc1_Visible = 1;
            AssignProp("", false, edtavProdcuentavdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 )
         {
            edtavProdcuentacdsc1_Visible = 1;
            AssignProp("", false, edtavProdcuentacdsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 )
         {
            edtavProdcuentaadsc1_Visible = 1;
            AssignProp("", false, edtavProdcuentaadsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "LINDSC") == 0 )
         {
            edtavLindsc1_Visible = 1;
            AssignProp("", false, edtavLindsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavProddsc2_Visible = 0;
         AssignProp("", false, edtavProddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc2_Visible), 5, 0), true);
         edtavProdcuentavdsc2_Visible = 0;
         AssignProp("", false, edtavProdcuentavdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc2_Visible), 5, 0), true);
         edtavProdcuentacdsc2_Visible = 0;
         AssignProp("", false, edtavProdcuentacdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc2_Visible), 5, 0), true);
         edtavProdcuentaadsc2_Visible = 0;
         AssignProp("", false, edtavProdcuentaadsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc2_Visible), 5, 0), true);
         edtavLindsc2_Visible = 0;
         AssignProp("", false, edtavLindsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODDSC") == 0 )
         {
            edtavProddsc2_Visible = 1;
            AssignProp("", false, edtavProddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 )
         {
            edtavProdcuentavdsc2_Visible = 1;
            AssignProp("", false, edtavProdcuentavdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 )
         {
            edtavProdcuentacdsc2_Visible = 1;
            AssignProp("", false, edtavProdcuentacdsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 )
         {
            edtavProdcuentaadsc2_Visible = 1;
            AssignProp("", false, edtavProdcuentaadsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LINDSC") == 0 )
         {
            edtavLindsc2_Visible = 1;
            AssignProp("", false, edtavLindsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavProddsc3_Visible = 0;
         AssignProp("", false, edtavProddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc3_Visible), 5, 0), true);
         edtavProdcuentavdsc3_Visible = 0;
         AssignProp("", false, edtavProdcuentavdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc3_Visible), 5, 0), true);
         edtavProdcuentacdsc3_Visible = 0;
         AssignProp("", false, edtavProdcuentacdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc3_Visible), 5, 0), true);
         edtavProdcuentaadsc3_Visible = 0;
         AssignProp("", false, edtavProdcuentaadsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc3_Visible), 5, 0), true);
         edtavLindsc3_Visible = 0;
         AssignProp("", false, edtavLindsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODDSC") == 0 )
         {
            edtavProddsc3_Visible = 1;
            AssignProp("", false, edtavProddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProddsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 )
         {
            edtavProdcuentavdsc3_Visible = 1;
            AssignProp("", false, edtavProdcuentavdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentavdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 )
         {
            edtavProdcuentacdsc3_Visible = 1;
            AssignProp("", false, edtavProdcuentacdsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentacdsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 )
         {
            edtavProdcuentaadsc3_Visible = 1;
            AssignProp("", false, edtavProdcuentaadsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProdcuentaadsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "LINDSC") == 0 )
         {
            edtavLindsc3_Visible = 1;
            AssignProp("", false, edtavLindsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLindsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "PRODDSC";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24ProdDsc2 = "";
         AssignAttri("", false, "AV24ProdDsc2", AV24ProdDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         AV29DynamicFiltersSelector3 = "PRODDSC";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         AV30DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AV31ProdDsc3 = "";
         AssignAttri("", false, "AV31ProdDsc3", AV31ProdDsc3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A28ProdCod));
         CallWebObject(formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "almacen.productos.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A28ProdCod));
         CallWebObject(formatLink("almacen.productos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get(AV113Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV113Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV39Session.Get(AV113Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV182GXV1 = 1;
         while ( AV182GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV182GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV40TFProdCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFProdCod", AV40TFProdCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV41TFProdCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFProdCod_Sel", AV41TFProdCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV42TFLinCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV42TFLinCod", StringUtil.LTrimStr( (decimal)(AV42TFLinCod), 6, 0));
               AV43TFLinCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV43TFLinCod_To", StringUtil.LTrimStr( (decimal)(AV43TFLinCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODDSC") == 0 )
            {
               AV44TFProdDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFProdDsc", AV44TFProdDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODDSC_SEL") == 0 )
            {
               AV45TFProdDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFProdDsc_Sel", AV45TFProdDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV46TFSublCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV46TFSublCod", StringUtil.LTrimStr( (decimal)(AV46TFSublCod), 6, 0));
               AV47TFSublCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV47TFSublCod_To", StringUtil.LTrimStr( (decimal)(AV47TFSublCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV48TFFamCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV48TFFamCod", StringUtil.LTrimStr( (decimal)(AV48TFFamCod), 6, 0));
               AV49TFFamCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV49TFFamCod_To", StringUtil.LTrimStr( (decimal)(AV49TFFamCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV50TFUniCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV50TFUniCod", StringUtil.LTrimStr( (decimal)(AV50TFUniCod), 6, 0));
               AV51TFUniCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV51TFUniCod_To", StringUtil.LTrimStr( (decimal)(AV51TFUniCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODVTA_SEL") == 0 )
            {
               AV103TFProdVta_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV103TFProdVta_Sel", StringUtil.Str( (decimal)(AV103TFProdVta_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCMP_SEL") == 0 )
            {
               AV104TFProdCmp_Sel = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV104TFProdCmp_Sel", StringUtil.Str( (decimal)(AV104TFProdCmp_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODPESO") == 0 )
            {
               AV56TFProdPeso = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV56TFProdPeso", StringUtil.LTrimStr( AV56TFProdPeso, 15, 5));
               AV57TFProdPeso_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV57TFProdPeso_To", StringUtil.LTrimStr( AV57TFProdPeso_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODVOLUMEN") == 0 )
            {
               AV58TFProdVolumen = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV58TFProdVolumen", StringUtil.LTrimStr( AV58TFProdVolumen, 15, 5));
               AV59TFProdVolumen_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV59TFProdVolumen_To", StringUtil.LTrimStr( AV59TFProdVolumen_To, 15, 5));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODSTKMAX") == 0 )
            {
               AV60TFProdStkMax = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV60TFProdStkMax", StringUtil.LTrimStr( AV60TFProdStkMax, 15, 4));
               AV61TFProdStkMax_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV61TFProdStkMax_To", StringUtil.LTrimStr( AV61TFProdStkMax_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODSTKMIN") == 0 )
            {
               AV62TFProdStkMin = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV62TFProdStkMin", StringUtil.LTrimStr( AV62TFProdStkMin, 15, 4));
               AV63TFProdStkMin_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV63TFProdStkMin_To", StringUtil.LTrimStr( AV63TFProdStkMin_To, 15, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF1") == 0 )
            {
               AV64TFProdRef1 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFProdRef1", AV64TFProdRef1);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF1_SEL") == 0 )
            {
               AV65TFProdRef1_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFProdRef1_Sel", AV65TFProdRef1_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF2") == 0 )
            {
               AV66TFProdRef2 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFProdRef2", AV66TFProdRef2);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF2_SEL") == 0 )
            {
               AV67TFProdRef2_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFProdRef2_Sel", AV67TFProdRef2_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF3") == 0 )
            {
               AV68TFProdRef3 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFProdRef3", AV68TFProdRef3);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF3_SEL") == 0 )
            {
               AV69TFProdRef3_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFProdRef3_Sel", AV69TFProdRef3_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF4") == 0 )
            {
               AV70TFProdRef4 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFProdRef4", AV70TFProdRef4);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF4_SEL") == 0 )
            {
               AV71TFProdRef4_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFProdRef4_Sel", AV71TFProdRef4_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF5") == 0 )
            {
               AV72TFProdRef5 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFProdRef5", AV72TFProdRef5);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF5_SEL") == 0 )
            {
               AV73TFProdRef5_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFProdRef5_Sel", AV73TFProdRef5_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF6") == 0 )
            {
               AV74TFProdRef6 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFProdRef6", AV74TFProdRef6);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF6_SEL") == 0 )
            {
               AV75TFProdRef6_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFProdRef6_Sel", AV75TFProdRef6_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF7") == 0 )
            {
               AV76TFProdRef7 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFProdRef7", AV76TFProdRef7);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF7_SEL") == 0 )
            {
               AV77TFProdRef7_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFProdRef7_Sel", AV77TFProdRef7_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF8") == 0 )
            {
               AV78TFProdRef8 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFProdRef8", AV78TFProdRef8);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF8_SEL") == 0 )
            {
               AV79TFProdRef8_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFProdRef8_Sel", AV79TFProdRef8_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF9") == 0 )
            {
               AV80TFProdRef9 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFProdRef9", AV80TFProdRef9);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF9_SEL") == 0 )
            {
               AV81TFProdRef9_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFProdRef9_Sel", AV81TFProdRef9_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF10") == 0 )
            {
               AV82TFProdRef10 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82TFProdRef10", AV82TFProdRef10);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODREF10_SEL") == 0 )
            {
               AV83TFProdRef10_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV83TFProdRef10_Sel", AV83TFProdRef10_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODSTS_SEL") == 0 )
            {
               AV105TFProdSts_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV105TFProdSts_SelsJson", AV105TFProdSts_SelsJson);
               AV106TFProdSts_Sels.FromJSonString(AV105TFProdSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPRODCOSTO") == 0 )
            {
               AV86TFProdCosto = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV86TFProdCosto", StringUtil.LTrimStr( AV86TFProdCosto, 18, 5));
               AV87TFProdCosto_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV87TFProdCosto_To", StringUtil.LTrimStr( AV87TFProdCosto_To, 18, 5));
            }
            AV182GXV1 = (int)(AV182GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)),  AV41TFProdCod_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProdDsc_Sel)),  AV45TFProdDsc_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFProdRef1_Sel)),  AV65TFProdRef1_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdRef2_Sel)),  AV67TFProdRef2_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFProdRef3_Sel)),  AV69TFProdRef3_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProdRef4_Sel)),  AV71TFProdRef4_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProdRef5_Sel)),  AV73TFProdRef5_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProdRef6_Sel)),  AV75TFProdRef6_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFProdRef7_Sel)),  AV77TFProdRef7_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProdRef8_Sel)),  AV79TFProdRef8_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFProdRef9_Sel)),  AV81TFProdRef9_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProdRef10_Sel)),  AV83TFProdRef10_Sel, out  GXt_char13) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||"+GXt_char3+"||||"+((0==AV103TFProdVta_Sel) ? "" : StringUtil.Str( (decimal)(AV103TFProdVta_Sel), 1, 0))+"|"+((0==AV104TFProdCmp_Sel) ? "" : StringUtil.Str( (decimal)(AV104TFProdCmp_Sel), 1, 0))+"|||||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"|"+GXt_char13+"|"+((AV106TFProdSts_Sels.Count==0) ? "" : AV105TFProdSts_SelsJson)+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)),  AV40TFProdCod, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProdDsc)),  AV44TFProdDsc, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdRef1)),  AV64TFProdRef1, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFProdRef2)),  AV66TFProdRef2, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdRef3)),  AV68TFProdRef3, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFProdRef4)),  AV70TFProdRef4, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFProdRef5)),  AV72TFProdRef5, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFProdRef6)),  AV74TFProdRef6, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFProdRef7)),  AV76TFProdRef7, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFProdRef8)),  AV78TFProdRef8, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProdRef9)),  AV80TFProdRef9, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProdRef10)),  AV82TFProdRef10, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char13+"|"+((0==AV42TFLinCod) ? "" : StringUtil.Str( (decimal)(AV42TFLinCod), 6, 0))+"|"+GXt_char12+"|"+((0==AV46TFSublCod) ? "" : StringUtil.Str( (decimal)(AV46TFSublCod), 6, 0))+"|"+((0==AV48TFFamCod) ? "" : StringUtil.Str( (decimal)(AV48TFFamCod), 6, 0))+"|"+((0==AV50TFUniCod) ? "" : StringUtil.Str( (decimal)(AV50TFUniCod), 6, 0))+"|||"+((Convert.ToDecimal(0)==AV56TFProdPeso) ? "" : StringUtil.Str( AV56TFProdPeso, 15, 5))+"|"+((Convert.ToDecimal(0)==AV58TFProdVolumen) ? "" : StringUtil.Str( AV58TFProdVolumen, 15, 5))+"|"+((Convert.ToDecimal(0)==AV60TFProdStkMax) ? "" : StringUtil.Str( AV60TFProdStkMax, 15, 4))+"|"+((Convert.ToDecimal(0)==AV62TFProdStkMin) ? "" : StringUtil.Str( AV62TFProdStkMin, 15, 4))+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"||"+((Convert.ToDecimal(0)==AV86TFProdCosto) ? "" : StringUtil.Str( AV86TFProdCosto, 18, 5));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV43TFLinCod_To) ? "" : StringUtil.Str( (decimal)(AV43TFLinCod_To), 6, 0))+"||"+((0==AV47TFSublCod_To) ? "" : StringUtil.Str( (decimal)(AV47TFSublCod_To), 6, 0))+"|"+((0==AV49TFFamCod_To) ? "" : StringUtil.Str( (decimal)(AV49TFFamCod_To), 6, 0))+"|"+((0==AV51TFUniCod_To) ? "" : StringUtil.Str( (decimal)(AV51TFUniCod_To), 6, 0))+"|||"+((Convert.ToDecimal(0)==AV57TFProdPeso_To) ? "" : StringUtil.Str( AV57TFProdPeso_To, 15, 5))+"|"+((Convert.ToDecimal(0)==AV59TFProdVolumen_To) ? "" : StringUtil.Str( AV59TFProdVolumen_To, 15, 5))+"|"+((Convert.ToDecimal(0)==AV61TFProdStkMax_To) ? "" : StringUtil.Str( AV61TFProdStkMax_To, 15, 4))+"|"+((Convert.ToDecimal(0)==AV63TFProdStkMin_To) ? "" : StringUtil.Str( AV63TFProdStkMin_To, 15, 4))+"||||||||||||"+((Convert.ToDecimal(0)==AV87TFProdCosto_To) ? "" : StringUtil.Str( AV87TFProdCosto_To, 18, 5));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17ProdDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17ProdDsc1", AV17ProdDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV18ProdCuentaVDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18ProdCuentaVDsc1", AV18ProdCuentaVDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV19ProdCuentaCDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ProdCuentaCDsc1", AV19ProdCuentaCDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV20ProdCuentaADsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20ProdCuentaADsc1", AV20ProdCuentaADsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV108LinDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV108LinDsc1", AV108LinDsc1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24ProdDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24ProdDsc2", AV24ProdDsc2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV25ProdCuentaVDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ProdCuentaVDsc2", AV25ProdCuentaVDsc2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV26ProdCuentaCDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26ProdCuentaCDsc2", AV26ProdCuentaCDsc2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV27ProdCuentaADsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27ProdCuentaADsc2", AV27ProdCuentaADsc2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV109LinDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV109LinDsc2", AV109LinDsc2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV28DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODDSC") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV31ProdDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ProdDsc3", AV31ProdDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV32ProdCuentaVDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32ProdCuentaVDsc3", AV32ProdCuentaVDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV33ProdCuentaCDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV33ProdCuentaCDsc3", AV33ProdCuentaCDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV34ProdCuentaADsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34ProdCuentaADsc3", AV34ProdCuentaADsc3);
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV110LinDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV110LinDsc3", AV110LinDsc3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S132 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV35DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV39Session.Get(AV113Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODCOD",  "Codigo Producto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProdCod)),  0,  AV40TFProdCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProdCod_Sel)),  AV41TFProdCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFLINCOD",  "Codigo de Linea",  !((0==AV42TFLinCod)&&(0==AV43TFLinCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFLinCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV43TFLinCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODDSC",  "Descripcion producto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProdDsc)),  0,  AV44TFProdDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProdDsc_Sel)),  AV45TFProdDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSUBLCOD",  "Codigo Sub Linea",  !((0==AV46TFSublCod)&&(0==AV47TFSublCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFSublCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFSublCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFAMCOD",  "Codigo Familia",  !((0==AV48TFFamCod)&&(0==AV49TFFamCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFFamCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV49TFFamCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFUNICOD",  "Codigo Unidad Medida",  !((0==AV50TFUniCod)&&(0==AV51TFUniCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFUniCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV51TFUniCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODVTA_SEL",  "Destinado Venta",  !(0==AV103TFProdVta_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV103TFProdVta_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODCMP_SEL",  "Destinado Compra",  !(0==AV104TFProdCmp_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV104TFProdCmp_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODPESO",  "Peso producto",  !((Convert.ToDecimal(0)==AV56TFProdPeso)&&(Convert.ToDecimal(0)==AV57TFProdPeso_To)),  0,  StringUtil.Trim( StringUtil.Str( AV56TFProdPeso, 15, 5)),  StringUtil.Trim( StringUtil.Str( AV57TFProdPeso_To, 15, 5))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODVOLUMEN",  "Volumen producto",  !((Convert.ToDecimal(0)==AV58TFProdVolumen)&&(Convert.ToDecimal(0)==AV59TFProdVolumen_To)),  0,  StringUtil.Trim( StringUtil.Str( AV58TFProdVolumen, 15, 5)),  StringUtil.Trim( StringUtil.Str( AV59TFProdVolumen_To, 15, 5))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODSTKMAX",  "Stock Maximo",  !((Convert.ToDecimal(0)==AV60TFProdStkMax)&&(Convert.ToDecimal(0)==AV61TFProdStkMax_To)),  0,  StringUtil.Trim( StringUtil.Str( AV60TFProdStkMax, 15, 4)),  StringUtil.Trim( StringUtil.Str( AV61TFProdStkMax_To, 15, 4))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODSTKMIN",  "Stock Minimo",  !((Convert.ToDecimal(0)==AV62TFProdStkMin)&&(Convert.ToDecimal(0)==AV63TFProdStkMin_To)),  0,  StringUtil.Trim( StringUtil.Str( AV62TFProdStkMin, 15, 4)),  StringUtil.Trim( StringUtil.Str( AV63TFProdStkMin_To, 15, 4))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF1",  "Referencia 1",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdRef1)),  0,  AV64TFProdRef1,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFProdRef1_Sel)),  AV65TFProdRef1_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF2",  "Referencia 2",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFProdRef2)),  0,  AV66TFProdRef2,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFProdRef2_Sel)),  AV67TFProdRef2_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF3",  "Referencia 3",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFProdRef3)),  0,  AV68TFProdRef3,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFProdRef3_Sel)),  AV69TFProdRef3_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF4",  "Referencia 4",  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFProdRef4)),  0,  AV70TFProdRef4,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFProdRef4_Sel)),  AV71TFProdRef4_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF5",  "Referencia 5",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFProdRef5)),  0,  AV72TFProdRef5,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFProdRef5_Sel)),  AV73TFProdRef5_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF6",  "Referencia 6",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFProdRef6)),  0,  AV74TFProdRef6,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFProdRef6_Sel)),  AV75TFProdRef6_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF7",  "Referencia 7",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFProdRef7)),  0,  AV76TFProdRef7,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFProdRef7_Sel)),  AV77TFProdRef7_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF8",  "Referencia 8",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFProdRef8)),  0,  AV78TFProdRef8,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFProdRef8_Sel)),  AV79TFProdRef8_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF9",  "Referencia 9",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFProdRef9)),  0,  AV80TFProdRef9,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFProdRef9_Sel)),  AV81TFProdRef9_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPRODREF10",  "Referencia 10",  !String.IsNullOrEmpty(StringUtil.RTrim( AV82TFProdRef10)),  0,  AV82TFProdRef10,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV83TFProdRef10_Sel)),  AV83TFProdRef10_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODSTS_SEL",  "Situacion",  !(AV106TFProdSts_Sels.Count==0),  0,  AV106TFProdSts_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPRODCOSTO",  "Ult. Costo MN",  !((Convert.ToDecimal(0)==AV86TFProdCosto)&&(Convert.ToDecimal(0)==AV87TFProdCosto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV86TFProdCosto, 18, 5)),  StringUtil.Trim( StringUtil.Str( AV87TFProdCosto_To, 18, 5))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV113Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S182( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV36DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ProdDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17ProdDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ProdCuentaVDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV18ProdCuentaVDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTACDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProdCuentaCDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Compra";
               AV12GridStateDynamicFilter.gxTpr_Value = AV19ProdCuentaCDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "PRODCUENTAADSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ProdCuentaADsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Almacen";
               AV12GridStateDynamicFilter.gxTpr_Value = AV20ProdCuentaADsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "LINDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV108LinDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion de Linea";
               AV12GridStateDynamicFilter.gxTpr_Value = AV108LinDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ProdDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV24ProdDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ProdCuentaVDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV25ProdCuentaVDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTACDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ProdCuentaCDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Compra";
               AV12GridStateDynamicFilter.gxTpr_Value = AV26ProdCuentaCDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "PRODCUENTAADSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ProdCuentaADsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Almacen";
               AV12GridStateDynamicFilter.gxTpr_Value = AV27ProdCuentaADsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LINDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV109LinDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion de Linea";
               AV12GridStateDynamicFilter.gxTpr_Value = AV109LinDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ProdDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion producto";
               AV12GridStateDynamicFilter.gxTpr_Value = AV31ProdDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAVDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ProdCuentaVDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Venta";
               AV12GridStateDynamicFilter.gxTpr_Value = AV32ProdCuentaVDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTACDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ProdCuentaCDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Compra";
               AV12GridStateDynamicFilter.gxTpr_Value = AV33ProdCuentaCDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PRODCUENTAADSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ProdCuentaADsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripción Cuenta Almacen";
               AV12GridStateDynamicFilter.gxTpr_Value = AV34ProdCuentaADsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "LINDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV110LinDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Descripcion de Linea";
               AV12GridStateDynamicFilter.gxTpr_Value = AV110LinDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator3;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S142( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV113Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Almacen.Productos";
         AV39Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.almacen.productoswwexport(context ).execute( out  AV37ExcelFilename, out  AV38ErrorMessage) ;
         if ( StringUtil.StrCmp(AV37ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV37ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV38ErrorMessage);
         }
      }

      protected void S232( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("almacen.productoswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_4R2( true) ;
         }
         else
         {
            wb_table2_39_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_73_4R2( true) ;
         }
         else
         {
            wb_table3_73_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_73_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_107_4R2( true) ;
         }
         else
         {
            wb_table4_107_4R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_107_4R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_4R2e( true) ;
         }
         else
         {
            wb_table1_25_4R2e( false) ;
         }
      }

      protected void wb_table4_107_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proddsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc3_Internalname, "Prod Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc3_Internalname, StringUtil.RTrim( AV31ProdDsc3), StringUtil.RTrim( context.localUtil.Format( AV31ProdDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProddsc3_Visible, edtavProddsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentavdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentavdsc3_Internalname, "Prod Cuenta VDsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentavdsc3_Internalname, StringUtil.RTrim( AV32ProdCuentaVDsc3), StringUtil.RTrim( context.localUtil.Format( AV32ProdCuentaVDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentavdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentavdsc3_Visible, edtavProdcuentavdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentacdsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentacdsc3_Internalname, "Prod Cuenta CDsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentacdsc3_Internalname, StringUtil.RTrim( AV33ProdCuentaCDsc3), StringUtil.RTrim( context.localUtil.Format( AV33ProdCuentaCDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentacdsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentacdsc3_Visible, edtavProdcuentacdsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentaadsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentaadsc3_Internalname, "Prod Cuenta ADsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentaadsc3_Internalname, StringUtil.RTrim( AV34ProdCuentaADsc3), StringUtil.RTrim( context.localUtil.Format( AV34ProdCuentaADsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentaadsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentaadsc3_Visible, edtavProdcuentaadsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_lindsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLindsc3_Internalname, "Lin Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLindsc3_Internalname, StringUtil.RTrim( AV110LinDsc3), StringUtil.RTrim( context.localUtil.Format( AV110LinDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLindsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavLindsc3_Visible, edtavLindsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\ProductosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_107_4R2e( true) ;
         }
         else
         {
            wb_table4_107_4R2e( false) ;
         }
      }

      protected void wb_table3_73_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proddsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc2_Internalname, "Prod Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc2_Internalname, StringUtil.RTrim( AV24ProdDsc2), StringUtil.RTrim( context.localUtil.Format( AV24ProdDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProddsc2_Visible, edtavProddsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentavdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentavdsc2_Internalname, "Prod Cuenta VDsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentavdsc2_Internalname, StringUtil.RTrim( AV25ProdCuentaVDsc2), StringUtil.RTrim( context.localUtil.Format( AV25ProdCuentaVDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentavdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentavdsc2_Visible, edtavProdcuentavdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentacdsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentacdsc2_Internalname, "Prod Cuenta CDsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentacdsc2_Internalname, StringUtil.RTrim( AV26ProdCuentaCDsc2), StringUtil.RTrim( context.localUtil.Format( AV26ProdCuentaCDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentacdsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentacdsc2_Visible, edtavProdcuentacdsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentaadsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentaadsc2_Internalname, "Prod Cuenta ADsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentaadsc2_Internalname, StringUtil.RTrim( AV27ProdCuentaADsc2), StringUtil.RTrim( context.localUtil.Format( AV27ProdCuentaADsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentaadsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentaadsc2_Visible, edtavProdcuentaadsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_lindsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLindsc2_Internalname, "Lin Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLindsc2_Internalname, StringUtil.RTrim( AV109LinDsc2), StringUtil.RTrim( context.localUtil.Format( AV109LinDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLindsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavLindsc2_Visible, edtavLindsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\ProductosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\ProductosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_73_4R2e( true) ;
         }
         else
         {
            wb_table3_73_4R2e( false) ;
         }
      }

      protected void wb_table2_39_4R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_137_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Almacen\\ProductosWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_proddsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProddsc1_Internalname, "Prod Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProddsc1_Internalname, StringUtil.RTrim( AV17ProdDsc1), StringUtil.RTrim( context.localUtil.Format( AV17ProdDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProddsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProddsc1_Visible, edtavProddsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentavdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentavdsc1_Internalname, "Prod Cuenta VDsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentavdsc1_Internalname, StringUtil.RTrim( AV18ProdCuentaVDsc1), StringUtil.RTrim( context.localUtil.Format( AV18ProdCuentaVDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentavdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentavdsc1_Visible, edtavProdcuentavdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentacdsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentacdsc1_Internalname, "Prod Cuenta CDsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentacdsc1_Internalname, StringUtil.RTrim( AV19ProdCuentaCDsc1), StringUtil.RTrim( context.localUtil.Format( AV19ProdCuentaCDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentacdsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentacdsc1_Visible, edtavProdcuentacdsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_prodcuentaadsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProdcuentaadsc1_Internalname, "Prod Cuenta ADsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProdcuentaadsc1_Internalname, StringUtil.RTrim( AV20ProdCuentaADsc1), StringUtil.RTrim( context.localUtil.Format( AV20ProdCuentaADsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProdcuentaadsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavProdcuentaadsc1_Visible, edtavProdcuentaadsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_lindsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLindsc1_Internalname, "Lin Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_137_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLindsc1_Internalname, StringUtil.RTrim( AV108LinDsc1), StringUtil.RTrim( context.localUtil.Format( AV108LinDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLindsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavLindsc1_Visible, edtavLindsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Almacen\\ProductosWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\ProductosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Almacen\\ProductosWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_4R2e( true) ;
         }
         else
         {
            wb_table2_39_4R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181031401", true, true);
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
         context.AddJavascriptSource("almacen/productosww.js", "?20228181031401", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1372( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_137_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_137_idx;
         edtLinCod_Internalname = "LINCOD_"+sGXsfl_137_idx;
         edtProdDsc_Internalname = "PRODDSC_"+sGXsfl_137_idx;
         edtSublCod_Internalname = "SUBLCOD_"+sGXsfl_137_idx;
         edtFamCod_Internalname = "FAMCOD_"+sGXsfl_137_idx;
         edtUniCod_Internalname = "UNICOD_"+sGXsfl_137_idx;
         chkProdVta_Internalname = "PRODVTA_"+sGXsfl_137_idx;
         chkProdCmp_Internalname = "PRODCMP_"+sGXsfl_137_idx;
         edtProdPeso_Internalname = "PRODPESO_"+sGXsfl_137_idx;
         edtProdVolumen_Internalname = "PRODVOLUMEN_"+sGXsfl_137_idx;
         edtProdStkMax_Internalname = "PRODSTKMAX_"+sGXsfl_137_idx;
         edtProdStkMin_Internalname = "PRODSTKMIN_"+sGXsfl_137_idx;
         edtProdFoto_Internalname = "PRODFOTO_"+sGXsfl_137_idx;
         edtProdRef1_Internalname = "PRODREF1_"+sGXsfl_137_idx;
         edtProdRef2_Internalname = "PRODREF2_"+sGXsfl_137_idx;
         edtProdRef3_Internalname = "PRODREF3_"+sGXsfl_137_idx;
         edtProdRef4_Internalname = "PRODREF4_"+sGXsfl_137_idx;
         edtProdRef5_Internalname = "PRODREF5_"+sGXsfl_137_idx;
         edtProdRef6_Internalname = "PRODREF6_"+sGXsfl_137_idx;
         edtProdRef7_Internalname = "PRODREF7_"+sGXsfl_137_idx;
         edtProdRef8_Internalname = "PRODREF8_"+sGXsfl_137_idx;
         edtProdRef9_Internalname = "PRODREF9_"+sGXsfl_137_idx;
         edtProdRef10_Internalname = "PRODREF10_"+sGXsfl_137_idx;
         cmbProdSts_Internalname = "PRODSTS_"+sGXsfl_137_idx;
         edtProdCosto_Internalname = "PRODCOSTO_"+sGXsfl_137_idx;
      }

      protected void SubsflControlProps_fel_1372( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_137_fel_idx;
         edtProdCod_Internalname = "PRODCOD_"+sGXsfl_137_fel_idx;
         edtLinCod_Internalname = "LINCOD_"+sGXsfl_137_fel_idx;
         edtProdDsc_Internalname = "PRODDSC_"+sGXsfl_137_fel_idx;
         edtSublCod_Internalname = "SUBLCOD_"+sGXsfl_137_fel_idx;
         edtFamCod_Internalname = "FAMCOD_"+sGXsfl_137_fel_idx;
         edtUniCod_Internalname = "UNICOD_"+sGXsfl_137_fel_idx;
         chkProdVta_Internalname = "PRODVTA_"+sGXsfl_137_fel_idx;
         chkProdCmp_Internalname = "PRODCMP_"+sGXsfl_137_fel_idx;
         edtProdPeso_Internalname = "PRODPESO_"+sGXsfl_137_fel_idx;
         edtProdVolumen_Internalname = "PRODVOLUMEN_"+sGXsfl_137_fel_idx;
         edtProdStkMax_Internalname = "PRODSTKMAX_"+sGXsfl_137_fel_idx;
         edtProdStkMin_Internalname = "PRODSTKMIN_"+sGXsfl_137_fel_idx;
         edtProdFoto_Internalname = "PRODFOTO_"+sGXsfl_137_fel_idx;
         edtProdRef1_Internalname = "PRODREF1_"+sGXsfl_137_fel_idx;
         edtProdRef2_Internalname = "PRODREF2_"+sGXsfl_137_fel_idx;
         edtProdRef3_Internalname = "PRODREF3_"+sGXsfl_137_fel_idx;
         edtProdRef4_Internalname = "PRODREF4_"+sGXsfl_137_fel_idx;
         edtProdRef5_Internalname = "PRODREF5_"+sGXsfl_137_fel_idx;
         edtProdRef6_Internalname = "PRODREF6_"+sGXsfl_137_fel_idx;
         edtProdRef7_Internalname = "PRODREF7_"+sGXsfl_137_fel_idx;
         edtProdRef8_Internalname = "PRODREF8_"+sGXsfl_137_fel_idx;
         edtProdRef9_Internalname = "PRODREF9_"+sGXsfl_137_fel_idx;
         edtProdRef10_Internalname = "PRODREF10_"+sGXsfl_137_fel_idx;
         cmbProdSts_Internalname = "PRODSTS_"+sGXsfl_137_fel_idx;
         edtProdCosto_Internalname = "PRODCOSTO_"+sGXsfl_137_fel_idx;
      }

      protected void sendrow_1372( )
      {
         SubsflControlProps_1372( ) ;
         WB4R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_137_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_137_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_137_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 138,'',false,'"+sGXsfl_137_idx+"',137)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_137_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV93GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV93GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_137_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,138);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdCod_Internalname,StringUtil.RTrim( A28ProdCod),StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLinCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLinCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdDsc_Internalname,StringUtil.RTrim( A55ProdDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProdDsc_Link,(string)"",(string)"",(string)"",(string)edtProdDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSublCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSublCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFamCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFamCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUniCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUniCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "PRODVTA_" + sGXsfl_137_idx;
            chkProdVta.Name = GXCCtl;
            chkProdVta.WebTags = "";
            chkProdVta.Caption = "";
            AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, !bGXsfl_137_Refreshing);
            chkProdVta.CheckedValue = "0";
            A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProdVta_Internalname,StringUtil.Str( (decimal)(A1724ProdVta), 1, 0),(string)"",(string)"",(short)-1,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "PRODCMP_" + sGXsfl_137_idx;
            chkProdCmp.Name = GXCCtl;
            chkProdCmp.WebTags = "";
            chkProdCmp.Caption = "";
            AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, !bGXsfl_137_Refreshing);
            chkProdCmp.CheckedValue = "0";
            A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProdCmp_Internalname,StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0),(string)"",(string)"",(short)-1,(short)0,(string)"1",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdPeso_Internalname,StringUtil.LTrim( StringUtil.NToC( A1702ProdPeso, 15, 5, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdPeso_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdVolumen_Internalname,StringUtil.LTrim( StringUtil.NToC( A1723ProdVolumen, 15, 5, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdVolumen_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdStkMax_Internalname,StringUtil.LTrim( StringUtil.NToC( A1716ProdStkMax, 17, 4, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdStkMax_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"CantidadPrecio",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdStkMin_Internalname,StringUtil.LTrim( StringUtil.NToC( A1717ProdStkMin, 17, 4, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdStkMin_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"CantidadPrecio",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A1695ProdFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.PathToRelativeUrl( A1695ProdFoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProdFoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A1695ProdFoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef1_Internalname,StringUtil.RTrim( A1705ProdRef1),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef2_Internalname,StringUtil.RTrim( A1707ProdRef2),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef3_Internalname,StringUtil.RTrim( A1708ProdRef3),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef4_Internalname,StringUtil.RTrim( A1709ProdRef4),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef4_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef5_Internalname,StringUtil.RTrim( A1710ProdRef5),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef5_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef6_Internalname,StringUtil.RTrim( A1711ProdRef6),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef6_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef7_Internalname,StringUtil.RTrim( A1712ProdRef7),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef7_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef8_Internalname,StringUtil.RTrim( A1713ProdRef8),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef8_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef9_Internalname,StringUtil.RTrim( A1714ProdRef9),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef9_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdRef10_Internalname,StringUtil.RTrim( A1706ProdRef10),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdRef10_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbProdSts.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PRODSTS_" + sGXsfl_137_idx;
               cmbProdSts.Name = GXCCtl;
               cmbProdSts.WebTags = "";
               cmbProdSts.addItem("1", "ACTIVO", 0);
               cmbProdSts.addItem("0", "INACTIVO", 0);
               if ( cmbProdSts.ItemCount > 0 )
               {
                  A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProdSts,(string)cmbProdSts_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0)),(short)1,(string)cmbProdSts_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)1});
            cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            AssignProp("", false, cmbProdSts_Internalname, "Values", (string)(cmbProdSts.ToJavascriptSource()), !bGXsfl_137_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A1681ProdCosto, 18, 5, ".", "")),StringUtil.LTrim( context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)137,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes4R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_137_idx = ((subGrid_Islastpage==1)&&(nGXsfl_137_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_137_idx+1);
            sGXsfl_137_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_137_idx), 4, 0), 4, "0");
            SubsflControlProps_1372( ) ;
         }
         /* End function sendrow_1372 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("PRODDSC", "Descripcion producto", 0);
         cmbavDynamicfiltersselector1.addItem("PRODCUENTAVDSC", "Descripción Cuenta Venta", 0);
         cmbavDynamicfiltersselector1.addItem("PRODCUENTACDSC", "Descripción Cuenta Compra", 0);
         cmbavDynamicfiltersselector1.addItem("PRODCUENTAADSC", "Descripción Cuenta Almacen", 0);
         cmbavDynamicfiltersselector1.addItem("LINDSC", "Descripcion de Linea", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV16DynamicFiltersOperator1 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0))), "."));
            AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PRODDSC", "Descripcion producto", 0);
         cmbavDynamicfiltersselector2.addItem("PRODCUENTAVDSC", "Descripción Cuenta Venta", 0);
         cmbavDynamicfiltersselector2.addItem("PRODCUENTACDSC", "Descripción Cuenta Compra", 0);
         cmbavDynamicfiltersselector2.addItem("PRODCUENTAADSC", "Descripción Cuenta Almacen", 0);
         cmbavDynamicfiltersselector2.addItem("LINDSC", "Descripcion de Linea", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PRODDSC", "Descripcion producto", 0);
         cmbavDynamicfiltersselector3.addItem("PRODCUENTAVDSC", "Descripción Cuenta Venta", 0);
         cmbavDynamicfiltersselector3.addItem("PRODCUENTACDSC", "Descripción Cuenta Compra", 0);
         cmbavDynamicfiltersselector3.addItem("PRODCUENTAADSC", "Descripción Cuenta Almacen", 0);
         cmbavDynamicfiltersselector3.addItem("LINDSC", "Descripcion de Linea", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_137_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV93GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV93GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV93GridActions), 4, 0));
         }
         GXCCtl = "PRODVTA_" + sGXsfl_137_idx;
         chkProdVta.Name = GXCCtl;
         chkProdVta.WebTags = "";
         chkProdVta.Caption = "";
         AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, !bGXsfl_137_Refreshing);
         chkProdVta.CheckedValue = "0";
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         GXCCtl = "PRODCMP_" + sGXsfl_137_idx;
         chkProdCmp.Name = GXCCtl;
         chkProdCmp.WebTags = "";
         chkProdCmp.Caption = "";
         AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, !bGXsfl_137_Refreshing);
         chkProdCmp.CheckedValue = "0";
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         GXCCtl = "PRODSTS_" + sGXsfl_137_idx;
         cmbProdSts.Name = GXCCtl;
         cmbProdSts.WebTags = "";
         cmbProdSts.addItem("1", "ACTIVO", 0);
         cmbProdSts.addItem("0", "INACTIVO", 0);
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         divTableactions_Internalname = "TABLEACTIONS";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavProddsc1_Internalname = "vPRODDSC1";
         cellFilter_proddsc1_cell_Internalname = "FILTER_PRODDSC1_CELL";
         edtavProdcuentavdsc1_Internalname = "vPRODCUENTAVDSC1";
         cellFilter_prodcuentavdsc1_cell_Internalname = "FILTER_PRODCUENTAVDSC1_CELL";
         edtavProdcuentacdsc1_Internalname = "vPRODCUENTACDSC1";
         cellFilter_prodcuentacdsc1_cell_Internalname = "FILTER_PRODCUENTACDSC1_CELL";
         edtavProdcuentaadsc1_Internalname = "vPRODCUENTAADSC1";
         cellFilter_prodcuentaadsc1_cell_Internalname = "FILTER_PRODCUENTAADSC1_CELL";
         edtavLindsc1_Internalname = "vLINDSC1";
         cellFilter_lindsc1_cell_Internalname = "FILTER_LINDSC1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavProddsc2_Internalname = "vPRODDSC2";
         cellFilter_proddsc2_cell_Internalname = "FILTER_PRODDSC2_CELL";
         edtavProdcuentavdsc2_Internalname = "vPRODCUENTAVDSC2";
         cellFilter_prodcuentavdsc2_cell_Internalname = "FILTER_PRODCUENTAVDSC2_CELL";
         edtavProdcuentacdsc2_Internalname = "vPRODCUENTACDSC2";
         cellFilter_prodcuentacdsc2_cell_Internalname = "FILTER_PRODCUENTACDSC2_CELL";
         edtavProdcuentaadsc2_Internalname = "vPRODCUENTAADSC2";
         cellFilter_prodcuentaadsc2_cell_Internalname = "FILTER_PRODCUENTAADSC2_CELL";
         edtavLindsc2_Internalname = "vLINDSC2";
         cellFilter_lindsc2_cell_Internalname = "FILTER_LINDSC2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavProddsc3_Internalname = "vPRODDSC3";
         cellFilter_proddsc3_cell_Internalname = "FILTER_PRODDSC3_CELL";
         edtavProdcuentavdsc3_Internalname = "vPRODCUENTAVDSC3";
         cellFilter_prodcuentavdsc3_cell_Internalname = "FILTER_PRODCUENTAVDSC3_CELL";
         edtavProdcuentacdsc3_Internalname = "vPRODCUENTACDSC3";
         cellFilter_prodcuentacdsc3_cell_Internalname = "FILTER_PRODCUENTACDSC3_CELL";
         edtavProdcuentaadsc3_Internalname = "vPRODCUENTAADSC3";
         cellFilter_prodcuentaadsc3_cell_Internalname = "FILTER_PRODCUENTAADSC3_CELL";
         edtavLindsc3_Internalname = "vLINDSC3";
         cellFilter_lindsc3_cell_Internalname = "FILTER_LINDSC3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         tblTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtProdCod_Internalname = "PRODCOD";
         edtLinCod_Internalname = "LINCOD";
         edtProdDsc_Internalname = "PRODDSC";
         edtSublCod_Internalname = "SUBLCOD";
         edtFamCod_Internalname = "FAMCOD";
         edtUniCod_Internalname = "UNICOD";
         chkProdVta_Internalname = "PRODVTA";
         chkProdCmp_Internalname = "PRODCMP";
         edtProdPeso_Internalname = "PRODPESO";
         edtProdVolumen_Internalname = "PRODVOLUMEN";
         edtProdStkMax_Internalname = "PRODSTKMAX";
         edtProdStkMin_Internalname = "PRODSTKMIN";
         edtProdFoto_Internalname = "PRODFOTO";
         edtProdRef1_Internalname = "PRODREF1";
         edtProdRef2_Internalname = "PRODREF2";
         edtProdRef3_Internalname = "PRODREF3";
         edtProdRef4_Internalname = "PRODREF4";
         edtProdRef5_Internalname = "PRODREF5";
         edtProdRef6_Internalname = "PRODREF6";
         edtProdRef7_Internalname = "PRODREF7";
         edtProdRef8_Internalname = "PRODREF8";
         edtProdRef9_Internalname = "PRODREF9";
         edtProdRef10_Internalname = "PRODREF10";
         cmbProdSts_Internalname = "PRODSTS";
         edtProdCosto_Internalname = "PRODCOSTO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtProdCosto_Jsonclick = "";
         cmbProdSts_Jsonclick = "";
         edtProdRef10_Jsonclick = "";
         edtProdRef9_Jsonclick = "";
         edtProdRef8_Jsonclick = "";
         edtProdRef7_Jsonclick = "";
         edtProdRef6_Jsonclick = "";
         edtProdRef5_Jsonclick = "";
         edtProdRef4_Jsonclick = "";
         edtProdRef3_Jsonclick = "";
         edtProdRef2_Jsonclick = "";
         edtProdRef1_Jsonclick = "";
         edtProdStkMin_Jsonclick = "";
         edtProdStkMax_Jsonclick = "";
         edtProdVolumen_Jsonclick = "";
         edtProdPeso_Jsonclick = "";
         chkProdCmp.Caption = "";
         chkProdVta.Caption = "";
         edtUniCod_Jsonclick = "";
         edtFamCod_Jsonclick = "";
         edtSublCod_Jsonclick = "";
         edtProdDsc_Jsonclick = "";
         edtLinCod_Jsonclick = "";
         edtProdCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavLindsc1_Jsonclick = "";
         edtavLindsc1_Enabled = 1;
         edtavProdcuentaadsc1_Jsonclick = "";
         edtavProdcuentaadsc1_Enabled = 1;
         edtavProdcuentacdsc1_Jsonclick = "";
         edtavProdcuentacdsc1_Enabled = 1;
         edtavProdcuentavdsc1_Jsonclick = "";
         edtavProdcuentavdsc1_Enabled = 1;
         edtavProddsc1_Jsonclick = "";
         edtavProddsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavLindsc2_Jsonclick = "";
         edtavLindsc2_Enabled = 1;
         edtavProdcuentaadsc2_Jsonclick = "";
         edtavProdcuentaadsc2_Enabled = 1;
         edtavProdcuentacdsc2_Jsonclick = "";
         edtavProdcuentacdsc2_Enabled = 1;
         edtavProdcuentavdsc2_Jsonclick = "";
         edtavProdcuentavdsc2_Enabled = 1;
         edtavProddsc2_Jsonclick = "";
         edtavProddsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavLindsc3_Jsonclick = "";
         edtavLindsc3_Enabled = 1;
         edtavProdcuentaadsc3_Jsonclick = "";
         edtavProdcuentaadsc3_Enabled = 1;
         edtavProdcuentacdsc3_Jsonclick = "";
         edtavProdcuentacdsc3_Enabled = 1;
         edtavProdcuentavdsc3_Jsonclick = "";
         edtavProdcuentavdsc3_Enabled = 1;
         edtavProddsc3_Jsonclick = "";
         edtavProddsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavLindsc3_Visible = 1;
         edtavProdcuentaadsc3_Visible = 1;
         edtavProdcuentacdsc3_Visible = 1;
         edtavProdcuentavdsc3_Visible = 1;
         edtavProddsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavLindsc2_Visible = 1;
         edtavProdcuentaadsc2_Visible = 1;
         edtavProdcuentacdsc2_Visible = 1;
         edtavProdcuentavdsc2_Visible = 1;
         edtavProddsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavLindsc1_Visible = 1;
         edtavProdcuentaadsc1_Visible = 1;
         edtavProdcuentacdsc1_Visible = 1;
         edtavProdcuentavdsc1_Visible = 1;
         edtavProddsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtProdDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Almacen.ProductosWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked|||||||||||||||1:ACTIVO,0:INACTIVO|";
         Ddo_grid_Allowmultipleselection = "||||||||||||||||||||||T|";
         Ddo_grid_Datalisttype = "Dynamic||Dynamic||||FixedValues|FixedValues|||||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues|";
         Ddo_grid_Includedatalist = "T||T||||T|T|||||T|T|T|T|T|T|T|T|T|T|T|";
         Ddo_grid_Filterisrange = "|T||T|T|T|||T|T|T|T||||||||||||T";
         Ddo_grid_Filtertype = "Character|Numeric|Character|Numeric|Numeric|Numeric|||Numeric|Numeric|Numeric|Numeric|Character|Character|Character|Character|Character|Character|Character|Character|Character|Character||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|||T|T|T|T|T|T|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24";
         Ddo_grid_Columnids = "1:ProdCod|2:LinCod|3:ProdDsc|4:SublCod|5:FamCod|6:UniCod|7:ProdVta|8:ProdCmp|9:ProdPeso|10:ProdVolumen|11:ProdStkMax|12:ProdStkMin|14:ProdRef1|15:ProdRef2|16:ProdRef3|17:ProdRef4|18:ProdRef5|19:ProdRef6|20:ProdRef7|21:ProdRef8|22:ProdRef9|23:ProdRef10|24:ProdSts|25:ProdCosto";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Dvpanel_tableheader_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Iconposition = "Right";
         Dvpanel_tableheader_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Title = "Opciones";
         Dvpanel_tableheader_Cls = "PanelNoHeader";
         Dvpanel_tableheader_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableheader_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableheader_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Productos";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E114R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E124R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E144R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV105TFProdSts_SelsJson',fld:'vTFPRODSTS_SELSJSON',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E264R2',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV93GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtProdDsc_Link',ctrl:'PRODDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E194R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E154R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'edtavProddsc2_Visible',ctrl:'vPRODDSC2',prop:'Visible'},{av:'edtavProdcuentavdsc2_Visible',ctrl:'vPRODCUENTAVDSC2',prop:'Visible'},{av:'edtavProdcuentacdsc2_Visible',ctrl:'vPRODCUENTACDSC2',prop:'Visible'},{av:'edtavProdcuentaadsc2_Visible',ctrl:'vPRODCUENTAADSC2',prop:'Visible'},{av:'edtavLindsc2_Visible',ctrl:'vLINDSC2',prop:'Visible'},{av:'edtavProddsc3_Visible',ctrl:'vPRODDSC3',prop:'Visible'},{av:'edtavProdcuentavdsc3_Visible',ctrl:'vPRODCUENTAVDSC3',prop:'Visible'},{av:'edtavProdcuentacdsc3_Visible',ctrl:'vPRODCUENTACDSC3',prop:'Visible'},{av:'edtavProdcuentaadsc3_Visible',ctrl:'vPRODCUENTAADSC3',prop:'Visible'},{av:'edtavLindsc3_Visible',ctrl:'vLINDSC3',prop:'Visible'},{av:'edtavProddsc1_Visible',ctrl:'vPRODDSC1',prop:'Visible'},{av:'edtavProdcuentavdsc1_Visible',ctrl:'vPRODCUENTAVDSC1',prop:'Visible'},{av:'edtavProdcuentacdsc1_Visible',ctrl:'vPRODCUENTACDSC1',prop:'Visible'},{av:'edtavProdcuentaadsc1_Visible',ctrl:'vPRODCUENTAADSC1',prop:'Visible'},{av:'edtavLindsc1_Visible',ctrl:'vLINDSC1',prop:'Visible'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E204R2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavProddsc1_Visible',ctrl:'vPRODDSC1',prop:'Visible'},{av:'edtavProdcuentavdsc1_Visible',ctrl:'vPRODCUENTAVDSC1',prop:'Visible'},{av:'edtavProdcuentacdsc1_Visible',ctrl:'vPRODCUENTACDSC1',prop:'Visible'},{av:'edtavProdcuentaadsc1_Visible',ctrl:'vPRODCUENTAADSC1',prop:'Visible'},{av:'edtavLindsc1_Visible',ctrl:'vLINDSC1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E214R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E164R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'edtavProddsc2_Visible',ctrl:'vPRODDSC2',prop:'Visible'},{av:'edtavProdcuentavdsc2_Visible',ctrl:'vPRODCUENTAVDSC2',prop:'Visible'},{av:'edtavProdcuentacdsc2_Visible',ctrl:'vPRODCUENTACDSC2',prop:'Visible'},{av:'edtavProdcuentaadsc2_Visible',ctrl:'vPRODCUENTAADSC2',prop:'Visible'},{av:'edtavLindsc2_Visible',ctrl:'vLINDSC2',prop:'Visible'},{av:'edtavProddsc3_Visible',ctrl:'vPRODDSC3',prop:'Visible'},{av:'edtavProdcuentavdsc3_Visible',ctrl:'vPRODCUENTAVDSC3',prop:'Visible'},{av:'edtavProdcuentacdsc3_Visible',ctrl:'vPRODCUENTACDSC3',prop:'Visible'},{av:'edtavProdcuentaadsc3_Visible',ctrl:'vPRODCUENTAADSC3',prop:'Visible'},{av:'edtavLindsc3_Visible',ctrl:'vLINDSC3',prop:'Visible'},{av:'edtavProddsc1_Visible',ctrl:'vPRODDSC1',prop:'Visible'},{av:'edtavProdcuentavdsc1_Visible',ctrl:'vPRODCUENTAVDSC1',prop:'Visible'},{av:'edtavProdcuentacdsc1_Visible',ctrl:'vPRODCUENTACDSC1',prop:'Visible'},{av:'edtavProdcuentaadsc1_Visible',ctrl:'vPRODCUENTAADSC1',prop:'Visible'},{av:'edtavLindsc1_Visible',ctrl:'vLINDSC1',prop:'Visible'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E224R2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavProddsc2_Visible',ctrl:'vPRODDSC2',prop:'Visible'},{av:'edtavProdcuentavdsc2_Visible',ctrl:'vPRODCUENTAVDSC2',prop:'Visible'},{av:'edtavProdcuentacdsc2_Visible',ctrl:'vPRODCUENTACDSC2',prop:'Visible'},{av:'edtavProdcuentaadsc2_Visible',ctrl:'vPRODCUENTAADSC2',prop:'Visible'},{av:'edtavLindsc2_Visible',ctrl:'vLINDSC2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E174R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'edtavProddsc2_Visible',ctrl:'vPRODDSC2',prop:'Visible'},{av:'edtavProdcuentavdsc2_Visible',ctrl:'vPRODCUENTAVDSC2',prop:'Visible'},{av:'edtavProdcuentacdsc2_Visible',ctrl:'vPRODCUENTACDSC2',prop:'Visible'},{av:'edtavProdcuentaadsc2_Visible',ctrl:'vPRODCUENTAADSC2',prop:'Visible'},{av:'edtavLindsc2_Visible',ctrl:'vLINDSC2',prop:'Visible'},{av:'edtavProddsc3_Visible',ctrl:'vPRODDSC3',prop:'Visible'},{av:'edtavProdcuentavdsc3_Visible',ctrl:'vPRODCUENTAVDSC3',prop:'Visible'},{av:'edtavProdcuentacdsc3_Visible',ctrl:'vPRODCUENTACDSC3',prop:'Visible'},{av:'edtavProdcuentaadsc3_Visible',ctrl:'vPRODCUENTAADSC3',prop:'Visible'},{av:'edtavLindsc3_Visible',ctrl:'vLINDSC3',prop:'Visible'},{av:'edtavProddsc1_Visible',ctrl:'vPRODDSC1',prop:'Visible'},{av:'edtavProdcuentavdsc1_Visible',ctrl:'vPRODCUENTAVDSC1',prop:'Visible'},{av:'edtavProdcuentacdsc1_Visible',ctrl:'vPRODCUENTACDSC1',prop:'Visible'},{av:'edtavProdcuentaadsc1_Visible',ctrl:'vPRODCUENTAADSC1',prop:'Visible'},{av:'edtavLindsc1_Visible',ctrl:'vLINDSC1',prop:'Visible'},{av:'AV90GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV91GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV92GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E234R2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavProddsc3_Visible',ctrl:'vPRODDSC3',prop:'Visible'},{av:'edtavProdcuentavdsc3_Visible',ctrl:'vPRODCUENTAVDSC3',prop:'Visible'},{av:'edtavProdcuentacdsc3_Visible',ctrl:'vPRODCUENTACDSC3',prop:'Visible'},{av:'edtavProdcuentaadsc3_Visible',ctrl:'vPRODCUENTAADSC3',prop:'Visible'},{av:'edtavLindsc3_Visible',ctrl:'vLINDSC3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E274R2',iparms:[{av:'cmbavGridactions'},{av:'AV93GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV93GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E184R2',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E134R2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV105TFProdSts_SelsJson',fld:'vTFPRODSTS_SELSJSON',pic:''},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV86TFProdCosto',fld:'vTFPRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV87TFProdCosto_To',fld:'vTFPRODCOSTO_TO',pic:'ZZZZZZZZZZZ9.99999'},{av:'AV105TFProdSts_SelsJson',fld:'vTFPRODSTS_SELSJSON',pic:''},{av:'AV106TFProdSts_Sels',fld:'vTFPRODSTS_SELS',pic:''},{av:'AV83TFProdRef10_Sel',fld:'vTFPRODREF10_SEL',pic:''},{av:'AV82TFProdRef10',fld:'vTFPRODREF10',pic:''},{av:'AV81TFProdRef9_Sel',fld:'vTFPRODREF9_SEL',pic:''},{av:'AV80TFProdRef9',fld:'vTFPRODREF9',pic:''},{av:'AV79TFProdRef8_Sel',fld:'vTFPRODREF8_SEL',pic:''},{av:'AV78TFProdRef8',fld:'vTFPRODREF8',pic:''},{av:'AV77TFProdRef7_Sel',fld:'vTFPRODREF7_SEL',pic:''},{av:'AV76TFProdRef7',fld:'vTFPRODREF7',pic:''},{av:'AV75TFProdRef6_Sel',fld:'vTFPRODREF6_SEL',pic:''},{av:'AV74TFProdRef6',fld:'vTFPRODREF6',pic:''},{av:'AV73TFProdRef5_Sel',fld:'vTFPRODREF5_SEL',pic:''},{av:'AV72TFProdRef5',fld:'vTFPRODREF5',pic:''},{av:'AV71TFProdRef4_Sel',fld:'vTFPRODREF4_SEL',pic:''},{av:'AV70TFProdRef4',fld:'vTFPRODREF4',pic:''},{av:'AV69TFProdRef3_Sel',fld:'vTFPRODREF3_SEL',pic:''},{av:'AV68TFProdRef3',fld:'vTFPRODREF3',pic:''},{av:'AV67TFProdRef2_Sel',fld:'vTFPRODREF2_SEL',pic:''},{av:'AV66TFProdRef2',fld:'vTFPRODREF2',pic:''},{av:'AV65TFProdRef1_Sel',fld:'vTFPRODREF1_SEL',pic:''},{av:'AV64TFProdRef1',fld:'vTFPRODREF1',pic:''},{av:'AV62TFProdStkMin',fld:'vTFPRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV63TFProdStkMin_To',fld:'vTFPRODSTKMIN_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV60TFProdStkMax',fld:'vTFPRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV61TFProdStkMax_To',fld:'vTFPRODSTKMAX_TO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'AV58TFProdVolumen',fld:'vTFPRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'AV59TFProdVolumen_To',fld:'vTFPRODVOLUMEN_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV56TFProdPeso',fld:'vTFPRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'AV57TFProdPeso_To',fld:'vTFPRODPESO_TO',pic:'ZZZZZZZZ9.99999'},{av:'AV104TFProdCmp_Sel',fld:'vTFPRODCMP_SEL',pic:'9'},{av:'AV103TFProdVta_Sel',fld:'vTFPRODVTA_SEL',pic:'9'},{av:'AV50TFUniCod',fld:'vTFUNICOD',pic:'ZZZZZ9'},{av:'AV51TFUniCod_To',fld:'vTFUNICOD_TO',pic:'ZZZZZ9'},{av:'AV48TFFamCod',fld:'vTFFAMCOD',pic:'ZZZZZ9'},{av:'AV49TFFamCod_To',fld:'vTFFAMCOD_TO',pic:'ZZZZZ9'},{av:'AV46TFSublCod',fld:'vTFSUBLCOD',pic:'ZZZZZ9'},{av:'AV47TFSublCod_To',fld:'vTFSUBLCOD_TO',pic:'ZZZZZ9'},{av:'AV45TFProdDsc_Sel',fld:'vTFPRODDSC_SEL',pic:''},{av:'AV44TFProdDsc',fld:'vTFPRODDSC',pic:''},{av:'AV42TFLinCod',fld:'vTFLINCOD',pic:'ZZZZZ9'},{av:'AV43TFLinCod_To',fld:'vTFLINCOD_TO',pic:'ZZZZZ9'},{av:'AV41TFProdCod_Sel',fld:'vTFPRODCOD_SEL',pic:'@!'},{av:'AV40TFProdCod',fld:'vTFPRODCOD',pic:'@!'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17ProdDsc1',fld:'vPRODDSC1',pic:''},{av:'AV18ProdCuentaVDsc1',fld:'vPRODCUENTAVDSC1',pic:''},{av:'AV19ProdCuentaCDsc1',fld:'vPRODCUENTACDSC1',pic:''},{av:'AV20ProdCuentaADsc1',fld:'vPRODCUENTAADSC1',pic:''},{av:'AV108LinDsc1',fld:'vLINDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24ProdDsc2',fld:'vPRODDSC2',pic:''},{av:'AV25ProdCuentaVDsc2',fld:'vPRODCUENTAVDSC2',pic:''},{av:'AV26ProdCuentaCDsc2',fld:'vPRODCUENTACDSC2',pic:''},{av:'AV27ProdCuentaADsc2',fld:'vPRODCUENTAADSC2',pic:''},{av:'AV109LinDsc2',fld:'vLINDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV29DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV30DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV31ProdDsc3',fld:'vPRODDSC3',pic:''},{av:'AV32ProdCuentaVDsc3',fld:'vPRODCUENTAVDSC3',pic:''},{av:'AV33ProdCuentaCDsc3',fld:'vPRODCUENTACDSC3',pic:''},{av:'AV34ProdCuentaADsc3',fld:'vPRODCUENTAADSC3',pic:''},{av:'AV110LinDsc3',fld:'vLINDSC3',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV28DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV113Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavProddsc1_Visible',ctrl:'vPRODDSC1',prop:'Visible'},{av:'edtavProdcuentavdsc1_Visible',ctrl:'vPRODCUENTAVDSC1',prop:'Visible'},{av:'edtavProdcuentacdsc1_Visible',ctrl:'vPRODCUENTACDSC1',prop:'Visible'},{av:'edtavProdcuentaadsc1_Visible',ctrl:'vPRODCUENTAADSC1',prop:'Visible'},{av:'edtavLindsc1_Visible',ctrl:'vLINDSC1',prop:'Visible'},{av:'edtavProddsc2_Visible',ctrl:'vPRODDSC2',prop:'Visible'},{av:'edtavProdcuentavdsc2_Visible',ctrl:'vPRODCUENTAVDSC2',prop:'Visible'},{av:'edtavProdcuentacdsc2_Visible',ctrl:'vPRODCUENTACDSC2',prop:'Visible'},{av:'edtavProdcuentaadsc2_Visible',ctrl:'vPRODCUENTAADSC2',prop:'Visible'},{av:'edtavLindsc2_Visible',ctrl:'vLINDSC2',prop:'Visible'},{av:'edtavProddsc3_Visible',ctrl:'vPRODDSC3',prop:'Visible'},{av:'edtavProdcuentavdsc3_Visible',ctrl:'vPRODCUENTAVDSC3',prop:'Visible'},{av:'edtavProdcuentacdsc3_Visible',ctrl:'vPRODCUENTACDSC3',prop:'Visible'},{av:'edtavProdcuentaadsc3_Visible',ctrl:'vPRODCUENTAADSC3',prop:'Visible'},{av:'edtavLindsc3_Visible',ctrl:'vLINDSC3',prop:'Visible'}]}");
         setEventMetadata("VALID_LINCOD","{handler:'Valid_Lincod',iparms:[]");
         setEventMetadata("VALID_LINCOD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Prodcosto',iparms:[]");
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
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV17ProdDsc1 = "";
         AV18ProdCuentaVDsc1 = "";
         AV19ProdCuentaCDsc1 = "";
         AV20ProdCuentaADsc1 = "";
         AV108LinDsc1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ProdDsc2 = "";
         AV25ProdCuentaVDsc2 = "";
         AV26ProdCuentaCDsc2 = "";
         AV27ProdCuentaADsc2 = "";
         AV109LinDsc2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31ProdDsc3 = "";
         AV32ProdCuentaVDsc3 = "";
         AV33ProdCuentaCDsc3 = "";
         AV34ProdCuentaADsc3 = "";
         AV110LinDsc3 = "";
         AV113Pgmname = "";
         AV40TFProdCod = "";
         AV41TFProdCod_Sel = "";
         AV44TFProdDsc = "";
         AV45TFProdDsc_Sel = "";
         AV64TFProdRef1 = "";
         AV65TFProdRef1_Sel = "";
         AV66TFProdRef2 = "";
         AV67TFProdRef2_Sel = "";
         AV68TFProdRef3 = "";
         AV69TFProdRef3_Sel = "";
         AV70TFProdRef4 = "";
         AV71TFProdRef4_Sel = "";
         AV72TFProdRef5 = "";
         AV73TFProdRef5_Sel = "";
         AV74TFProdRef6 = "";
         AV75TFProdRef6_Sel = "";
         AV76TFProdRef7 = "";
         AV77TFProdRef7_Sel = "";
         AV78TFProdRef8 = "";
         AV79TFProdRef8_Sel = "";
         AV80TFProdRef9 = "";
         AV81TFProdRef9_Sel = "";
         AV82TFProdRef10 = "";
         AV83TFProdRef10_Sel = "";
         AV106TFProdSts_Sels = new GxSimpleCollection<short>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV92GridAppliedFilters = "";
         AV94AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV88DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV105TFProdSts_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A28ProdCod = "";
         A55ProdDsc = "";
         A1695ProdFoto = "";
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40000ProdFoto_GXI = "";
         AV179Almacen_productoswwds_66_tfprodsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV116Almacen_productoswwds_3_proddsc1 = "";
         lV117Almacen_productoswwds_4_prodcuentavdsc1 = "";
         lV118Almacen_productoswwds_5_prodcuentacdsc1 = "";
         lV119Almacen_productoswwds_6_prodcuentaadsc1 = "";
         lV120Almacen_productoswwds_7_lindsc1 = "";
         lV124Almacen_productoswwds_11_proddsc2 = "";
         lV125Almacen_productoswwds_12_prodcuentavdsc2 = "";
         lV126Almacen_productoswwds_13_prodcuentacdsc2 = "";
         lV127Almacen_productoswwds_14_prodcuentaadsc2 = "";
         lV128Almacen_productoswwds_15_lindsc2 = "";
         lV132Almacen_productoswwds_19_proddsc3 = "";
         lV133Almacen_productoswwds_20_prodcuentavdsc3 = "";
         lV134Almacen_productoswwds_21_prodcuentacdsc3 = "";
         lV135Almacen_productoswwds_22_prodcuentaadsc3 = "";
         lV136Almacen_productoswwds_23_lindsc3 = "";
         lV137Almacen_productoswwds_24_tfprodcod = "";
         lV141Almacen_productoswwds_28_tfproddsc = "";
         lV159Almacen_productoswwds_46_tfprodref1 = "";
         lV161Almacen_productoswwds_48_tfprodref2 = "";
         lV163Almacen_productoswwds_50_tfprodref3 = "";
         lV165Almacen_productoswwds_52_tfprodref4 = "";
         lV167Almacen_productoswwds_54_tfprodref5 = "";
         lV169Almacen_productoswwds_56_tfprodref6 = "";
         lV171Almacen_productoswwds_58_tfprodref7 = "";
         lV173Almacen_productoswwds_60_tfprodref8 = "";
         lV175Almacen_productoswwds_62_tfprodref9 = "";
         lV177Almacen_productoswwds_64_tfprodref10 = "";
         AV114Almacen_productoswwds_1_dynamicfiltersselector1 = "";
         AV116Almacen_productoswwds_3_proddsc1 = "";
         AV117Almacen_productoswwds_4_prodcuentavdsc1 = "";
         AV118Almacen_productoswwds_5_prodcuentacdsc1 = "";
         AV119Almacen_productoswwds_6_prodcuentaadsc1 = "";
         AV120Almacen_productoswwds_7_lindsc1 = "";
         AV122Almacen_productoswwds_9_dynamicfiltersselector2 = "";
         AV124Almacen_productoswwds_11_proddsc2 = "";
         AV125Almacen_productoswwds_12_prodcuentavdsc2 = "";
         AV126Almacen_productoswwds_13_prodcuentacdsc2 = "";
         AV127Almacen_productoswwds_14_prodcuentaadsc2 = "";
         AV128Almacen_productoswwds_15_lindsc2 = "";
         AV130Almacen_productoswwds_17_dynamicfiltersselector3 = "";
         AV132Almacen_productoswwds_19_proddsc3 = "";
         AV133Almacen_productoswwds_20_prodcuentavdsc3 = "";
         AV134Almacen_productoswwds_21_prodcuentacdsc3 = "";
         AV135Almacen_productoswwds_22_prodcuentaadsc3 = "";
         AV136Almacen_productoswwds_23_lindsc3 = "";
         AV138Almacen_productoswwds_25_tfprodcod_sel = "";
         AV137Almacen_productoswwds_24_tfprodcod = "";
         AV142Almacen_productoswwds_29_tfproddsc_sel = "";
         AV141Almacen_productoswwds_28_tfproddsc = "";
         AV160Almacen_productoswwds_47_tfprodref1_sel = "";
         AV159Almacen_productoswwds_46_tfprodref1 = "";
         AV162Almacen_productoswwds_49_tfprodref2_sel = "";
         AV161Almacen_productoswwds_48_tfprodref2 = "";
         AV164Almacen_productoswwds_51_tfprodref3_sel = "";
         AV163Almacen_productoswwds_50_tfprodref3 = "";
         AV166Almacen_productoswwds_53_tfprodref4_sel = "";
         AV165Almacen_productoswwds_52_tfprodref4 = "";
         AV168Almacen_productoswwds_55_tfprodref5_sel = "";
         AV167Almacen_productoswwds_54_tfprodref5 = "";
         AV170Almacen_productoswwds_57_tfprodref6_sel = "";
         AV169Almacen_productoswwds_56_tfprodref6 = "";
         AV172Almacen_productoswwds_59_tfprodref7_sel = "";
         AV171Almacen_productoswwds_58_tfprodref7 = "";
         AV174Almacen_productoswwds_61_tfprodref8_sel = "";
         AV173Almacen_productoswwds_60_tfprodref8 = "";
         AV176Almacen_productoswwds_63_tfprodref9_sel = "";
         AV175Almacen_productoswwds_62_tfprodref9 = "";
         AV178Almacen_productoswwds_65_tfprodref10_sel = "";
         AV177Almacen_productoswwds_64_tfprodref10 = "";
         A1686ProdCuentaVDsc = "";
         A1685ProdCuentaCDsc = "";
         A1684ProdCuentaADsc = "";
         A1153LinDsc = "";
         H004R2_A48ProdCuentaV = new string[] {""} ;
         H004R2_n48ProdCuentaV = new bool[] {false} ;
         H004R2_A53ProdCuentaC = new string[] {""} ;
         H004R2_n53ProdCuentaC = new bool[] {false} ;
         H004R2_A54ProdCuentaA = new string[] {""} ;
         H004R2_n54ProdCuentaA = new bool[] {false} ;
         H004R2_A1153LinDsc = new string[] {""} ;
         H004R2_A1684ProdCuentaADsc = new string[] {""} ;
         H004R2_A1685ProdCuentaCDsc = new string[] {""} ;
         H004R2_A1686ProdCuentaVDsc = new string[] {""} ;
         H004R2_A1681ProdCosto = new decimal[1] ;
         H004R2_A1718ProdSts = new short[1] ;
         H004R2_A1706ProdRef10 = new string[] {""} ;
         H004R2_A1714ProdRef9 = new string[] {""} ;
         H004R2_A1713ProdRef8 = new string[] {""} ;
         H004R2_A1712ProdRef7 = new string[] {""} ;
         H004R2_A1711ProdRef6 = new string[] {""} ;
         H004R2_A1710ProdRef5 = new string[] {""} ;
         H004R2_A1709ProdRef4 = new string[] {""} ;
         H004R2_A1708ProdRef3 = new string[] {""} ;
         H004R2_A1707ProdRef2 = new string[] {""} ;
         H004R2_A1705ProdRef1 = new string[] {""} ;
         H004R2_A40000ProdFoto_GXI = new string[] {""} ;
         H004R2_n40000ProdFoto_GXI = new bool[] {false} ;
         H004R2_A1717ProdStkMin = new decimal[1] ;
         H004R2_A1716ProdStkMax = new decimal[1] ;
         H004R2_A1723ProdVolumen = new decimal[1] ;
         H004R2_A1702ProdPeso = new decimal[1] ;
         H004R2_A1679ProdCmp = new short[1] ;
         H004R2_A1724ProdVta = new short[1] ;
         H004R2_A49UniCod = new int[1] ;
         H004R2_A50FamCod = new int[1] ;
         H004R2_n50FamCod = new bool[] {false} ;
         H004R2_A51SublCod = new int[1] ;
         H004R2_n51SublCod = new bool[] {false} ;
         H004R2_A55ProdDsc = new string[] {""} ;
         H004R2_A52LinCod = new int[1] ;
         H004R2_A28ProdCod = new string[] {""} ;
         H004R2_A1695ProdFoto = new string[] {""} ;
         H004R2_n1695ProdFoto = new bool[] {false} ;
         A48ProdCuentaV = "";
         A53ProdCuentaC = "";
         A54ProdCuentaA = "";
         H004R3_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV95AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char13 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV37ExcelFilename = "";
         AV38ErrorMessage = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         sImgUrl = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.productosww__default(),
            new Object[][] {
                new Object[] {
               H004R2_A48ProdCuentaV, H004R2_n48ProdCuentaV, H004R2_A53ProdCuentaC, H004R2_n53ProdCuentaC, H004R2_A54ProdCuentaA, H004R2_n54ProdCuentaA, H004R2_A1153LinDsc, H004R2_A1684ProdCuentaADsc, H004R2_A1685ProdCuentaCDsc, H004R2_A1686ProdCuentaVDsc,
               H004R2_A1681ProdCosto, H004R2_A1718ProdSts, H004R2_A1706ProdRef10, H004R2_A1714ProdRef9, H004R2_A1713ProdRef8, H004R2_A1712ProdRef7, H004R2_A1711ProdRef6, H004R2_A1710ProdRef5, H004R2_A1709ProdRef4, H004R2_A1708ProdRef3,
               H004R2_A1707ProdRef2, H004R2_A1705ProdRef1, H004R2_A40000ProdFoto_GXI, H004R2_n40000ProdFoto_GXI, H004R2_A1717ProdStkMin, H004R2_A1716ProdStkMax, H004R2_A1723ProdVolumen, H004R2_A1702ProdPeso, H004R2_A1679ProdCmp, H004R2_A1724ProdVta,
               H004R2_A49UniCod, H004R2_A50FamCod, H004R2_n50FamCod, H004R2_A51SublCod, H004R2_n51SublCod, H004R2_A55ProdDsc, H004R2_A52LinCod, H004R2_A28ProdCod, H004R2_A1695ProdFoto, H004R2_n1695ProdFoto
               }
               , new Object[] {
               H004R3_AGRID_nRecordCount
               }
            }
         );
         AV113Pgmname = "Almacen.ProductosWW";
         /* GeneXus formulas. */
         AV113Pgmname = "Almacen.ProductosWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV103TFProdVta_Sel ;
      private short AV104TFProdCmp_Sel ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV93GridActions ;
      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short A1718ProdSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV115Almacen_productoswwds_2_dynamicfiltersoperator1 ;
      private short AV123Almacen_productoswwds_10_dynamicfiltersoperator2 ;
      private short AV131Almacen_productoswwds_18_dynamicfiltersoperator3 ;
      private short AV149Almacen_productoswwds_36_tfprodvta_sel ;
      private short AV150Almacen_productoswwds_37_tfprodcmp_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_137 ;
      private int nGXsfl_137_idx=1 ;
      private int AV42TFLinCod ;
      private int AV43TFLinCod_To ;
      private int AV46TFSublCod ;
      private int AV47TFSublCod_To ;
      private int AV48TFFamCod ;
      private int AV49TFFamCod_To ;
      private int AV50TFUniCod ;
      private int AV51TFUniCod_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV179Almacen_productoswwds_66_tfprodsts_sels_Count ;
      private int AV139Almacen_productoswwds_26_tflincod ;
      private int AV140Almacen_productoswwds_27_tflincod_to ;
      private int AV143Almacen_productoswwds_30_tfsublcod ;
      private int AV144Almacen_productoswwds_31_tfsublcod_to ;
      private int AV145Almacen_productoswwds_32_tffamcod ;
      private int AV146Almacen_productoswwds_33_tffamcod_to ;
      private int AV147Almacen_productoswwds_34_tfunicod ;
      private int AV148Almacen_productoswwds_35_tfunicod_to ;
      private int AV89PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavProddsc1_Visible ;
      private int edtavProdcuentavdsc1_Visible ;
      private int edtavProdcuentacdsc1_Visible ;
      private int edtavProdcuentaadsc1_Visible ;
      private int edtavLindsc1_Visible ;
      private int edtavProddsc2_Visible ;
      private int edtavProdcuentavdsc2_Visible ;
      private int edtavProdcuentacdsc2_Visible ;
      private int edtavProdcuentaadsc2_Visible ;
      private int edtavLindsc2_Visible ;
      private int edtavProddsc3_Visible ;
      private int edtavProdcuentavdsc3_Visible ;
      private int edtavProdcuentacdsc3_Visible ;
      private int edtavProdcuentaadsc3_Visible ;
      private int edtavLindsc3_Visible ;
      private int AV182GXV1 ;
      private int edtavProddsc3_Enabled ;
      private int edtavProdcuentavdsc3_Enabled ;
      private int edtavProdcuentacdsc3_Enabled ;
      private int edtavProdcuentaadsc3_Enabled ;
      private int edtavLindsc3_Enabled ;
      private int edtavProddsc2_Enabled ;
      private int edtavProdcuentavdsc2_Enabled ;
      private int edtavProdcuentacdsc2_Enabled ;
      private int edtavProdcuentaadsc2_Enabled ;
      private int edtavLindsc2_Enabled ;
      private int edtavProddsc1_Enabled ;
      private int edtavProdcuentavdsc1_Enabled ;
      private int edtavProdcuentacdsc1_Enabled ;
      private int edtavProdcuentaadsc1_Enabled ;
      private int edtavLindsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV90GridCurrentPage ;
      private long AV91GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV56TFProdPeso ;
      private decimal AV57TFProdPeso_To ;
      private decimal AV58TFProdVolumen ;
      private decimal AV59TFProdVolumen_To ;
      private decimal AV60TFProdStkMax ;
      private decimal AV61TFProdStkMax_To ;
      private decimal AV62TFProdStkMin ;
      private decimal AV63TFProdStkMin_To ;
      private decimal AV86TFProdCosto ;
      private decimal AV87TFProdCosto_To ;
      private decimal A1702ProdPeso ;
      private decimal A1723ProdVolumen ;
      private decimal A1716ProdStkMax ;
      private decimal A1717ProdStkMin ;
      private decimal A1681ProdCosto ;
      private decimal AV151Almacen_productoswwds_38_tfprodpeso ;
      private decimal AV152Almacen_productoswwds_39_tfprodpeso_to ;
      private decimal AV153Almacen_productoswwds_40_tfprodvolumen ;
      private decimal AV154Almacen_productoswwds_41_tfprodvolumen_to ;
      private decimal AV155Almacen_productoswwds_42_tfprodstkmax ;
      private decimal AV156Almacen_productoswwds_43_tfprodstkmax_to ;
      private decimal AV157Almacen_productoswwds_44_tfprodstkmin ;
      private decimal AV158Almacen_productoswwds_45_tfprodstkmin_to ;
      private decimal AV180Almacen_productoswwds_67_tfprodcosto ;
      private decimal AV181Almacen_productoswwds_68_tfprodcosto_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_137_idx="0001" ;
      private string AV17ProdDsc1 ;
      private string AV18ProdCuentaVDsc1 ;
      private string AV19ProdCuentaCDsc1 ;
      private string AV20ProdCuentaADsc1 ;
      private string AV108LinDsc1 ;
      private string AV24ProdDsc2 ;
      private string AV25ProdCuentaVDsc2 ;
      private string AV26ProdCuentaCDsc2 ;
      private string AV27ProdCuentaADsc2 ;
      private string AV109LinDsc2 ;
      private string AV31ProdDsc3 ;
      private string AV32ProdCuentaVDsc3 ;
      private string AV33ProdCuentaCDsc3 ;
      private string AV34ProdCuentaADsc3 ;
      private string AV110LinDsc3 ;
      private string AV113Pgmname ;
      private string AV40TFProdCod ;
      private string AV41TFProdCod_Sel ;
      private string AV44TFProdDsc ;
      private string AV45TFProdDsc_Sel ;
      private string AV64TFProdRef1 ;
      private string AV65TFProdRef1_Sel ;
      private string AV66TFProdRef2 ;
      private string AV67TFProdRef2_Sel ;
      private string AV68TFProdRef3 ;
      private string AV69TFProdRef3_Sel ;
      private string AV70TFProdRef4 ;
      private string AV71TFProdRef4_Sel ;
      private string AV72TFProdRef5 ;
      private string AV73TFProdRef5_Sel ;
      private string AV74TFProdRef6 ;
      private string AV75TFProdRef6_Sel ;
      private string AV76TFProdRef7 ;
      private string AV77TFProdRef7_Sel ;
      private string AV78TFProdRef8 ;
      private string AV79TFProdRef8_Sel ;
      private string AV80TFProdRef9 ;
      private string AV81TFProdRef9_Sel ;
      private string AV82TFProdRef10 ;
      private string AV83TFProdRef10_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dvpanel_tableheader_Width ;
      private string Dvpanel_tableheader_Cls ;
      private string Dvpanel_tableheader_Title ;
      private string Dvpanel_tableheader_Iconposition ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string edtProdDsc_Link ;
      private string A1705ProdRef1 ;
      private string A1707ProdRef2 ;
      private string A1708ProdRef3 ;
      private string A1709ProdRef4 ;
      private string A1710ProdRef5 ;
      private string A1711ProdRef6 ;
      private string A1712ProdRef7 ;
      private string A1713ProdRef8 ;
      private string A1714ProdRef9 ;
      private string A1706ProdRef10 ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtProdCod_Internalname ;
      private string edtLinCod_Internalname ;
      private string edtProdDsc_Internalname ;
      private string edtSublCod_Internalname ;
      private string edtFamCod_Internalname ;
      private string edtUniCod_Internalname ;
      private string chkProdVta_Internalname ;
      private string chkProdCmp_Internalname ;
      private string edtProdPeso_Internalname ;
      private string edtProdVolumen_Internalname ;
      private string edtProdStkMax_Internalname ;
      private string edtProdStkMin_Internalname ;
      private string edtProdFoto_Internalname ;
      private string edtProdRef1_Internalname ;
      private string edtProdRef2_Internalname ;
      private string edtProdRef3_Internalname ;
      private string edtProdRef4_Internalname ;
      private string edtProdRef5_Internalname ;
      private string edtProdRef6_Internalname ;
      private string edtProdRef7_Internalname ;
      private string edtProdRef8_Internalname ;
      private string edtProdRef9_Internalname ;
      private string edtProdRef10_Internalname ;
      private string cmbProdSts_Internalname ;
      private string edtProdCosto_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV116Almacen_productoswwds_3_proddsc1 ;
      private string lV117Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string lV118Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string lV119Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string lV120Almacen_productoswwds_7_lindsc1 ;
      private string lV124Almacen_productoswwds_11_proddsc2 ;
      private string lV125Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string lV126Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string lV127Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string lV128Almacen_productoswwds_15_lindsc2 ;
      private string lV132Almacen_productoswwds_19_proddsc3 ;
      private string lV133Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string lV134Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string lV135Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string lV136Almacen_productoswwds_23_lindsc3 ;
      private string lV137Almacen_productoswwds_24_tfprodcod ;
      private string lV141Almacen_productoswwds_28_tfproddsc ;
      private string lV159Almacen_productoswwds_46_tfprodref1 ;
      private string lV161Almacen_productoswwds_48_tfprodref2 ;
      private string lV163Almacen_productoswwds_50_tfprodref3 ;
      private string lV165Almacen_productoswwds_52_tfprodref4 ;
      private string lV167Almacen_productoswwds_54_tfprodref5 ;
      private string lV169Almacen_productoswwds_56_tfprodref6 ;
      private string lV171Almacen_productoswwds_58_tfprodref7 ;
      private string lV173Almacen_productoswwds_60_tfprodref8 ;
      private string lV175Almacen_productoswwds_62_tfprodref9 ;
      private string lV177Almacen_productoswwds_64_tfprodref10 ;
      private string AV116Almacen_productoswwds_3_proddsc1 ;
      private string AV117Almacen_productoswwds_4_prodcuentavdsc1 ;
      private string AV118Almacen_productoswwds_5_prodcuentacdsc1 ;
      private string AV119Almacen_productoswwds_6_prodcuentaadsc1 ;
      private string AV120Almacen_productoswwds_7_lindsc1 ;
      private string AV124Almacen_productoswwds_11_proddsc2 ;
      private string AV125Almacen_productoswwds_12_prodcuentavdsc2 ;
      private string AV126Almacen_productoswwds_13_prodcuentacdsc2 ;
      private string AV127Almacen_productoswwds_14_prodcuentaadsc2 ;
      private string AV128Almacen_productoswwds_15_lindsc2 ;
      private string AV132Almacen_productoswwds_19_proddsc3 ;
      private string AV133Almacen_productoswwds_20_prodcuentavdsc3 ;
      private string AV134Almacen_productoswwds_21_prodcuentacdsc3 ;
      private string AV135Almacen_productoswwds_22_prodcuentaadsc3 ;
      private string AV136Almacen_productoswwds_23_lindsc3 ;
      private string AV138Almacen_productoswwds_25_tfprodcod_sel ;
      private string AV137Almacen_productoswwds_24_tfprodcod ;
      private string AV142Almacen_productoswwds_29_tfproddsc_sel ;
      private string AV141Almacen_productoswwds_28_tfproddsc ;
      private string AV160Almacen_productoswwds_47_tfprodref1_sel ;
      private string AV159Almacen_productoswwds_46_tfprodref1 ;
      private string AV162Almacen_productoswwds_49_tfprodref2_sel ;
      private string AV161Almacen_productoswwds_48_tfprodref2 ;
      private string AV164Almacen_productoswwds_51_tfprodref3_sel ;
      private string AV163Almacen_productoswwds_50_tfprodref3 ;
      private string AV166Almacen_productoswwds_53_tfprodref4_sel ;
      private string AV165Almacen_productoswwds_52_tfprodref4 ;
      private string AV168Almacen_productoswwds_55_tfprodref5_sel ;
      private string AV167Almacen_productoswwds_54_tfprodref5 ;
      private string AV170Almacen_productoswwds_57_tfprodref6_sel ;
      private string AV169Almacen_productoswwds_56_tfprodref6 ;
      private string AV172Almacen_productoswwds_59_tfprodref7_sel ;
      private string AV171Almacen_productoswwds_58_tfprodref7 ;
      private string AV174Almacen_productoswwds_61_tfprodref8_sel ;
      private string AV173Almacen_productoswwds_60_tfprodref8 ;
      private string AV176Almacen_productoswwds_63_tfprodref9_sel ;
      private string AV175Almacen_productoswwds_62_tfprodref9 ;
      private string AV178Almacen_productoswwds_65_tfprodref10_sel ;
      private string AV177Almacen_productoswwds_64_tfprodref10 ;
      private string A1686ProdCuentaVDsc ;
      private string A1685ProdCuentaCDsc ;
      private string A1684ProdCuentaADsc ;
      private string A1153LinDsc ;
      private string A48ProdCuentaV ;
      private string A53ProdCuentaC ;
      private string A54ProdCuentaA ;
      private string edtavProddsc1_Internalname ;
      private string edtavProdcuentavdsc1_Internalname ;
      private string edtavProdcuentacdsc1_Internalname ;
      private string edtavProdcuentaadsc1_Internalname ;
      private string edtavLindsc1_Internalname ;
      private string edtavProddsc2_Internalname ;
      private string edtavProdcuentavdsc2_Internalname ;
      private string edtavProdcuentacdsc2_Internalname ;
      private string edtavProdcuentaadsc2_Internalname ;
      private string edtavLindsc2_Internalname ;
      private string edtavProddsc3_Internalname ;
      private string edtavProdcuentavdsc3_Internalname ;
      private string edtavProdcuentacdsc3_Internalname ;
      private string edtavProdcuentaadsc3_Internalname ;
      private string edtavLindsc3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string divTabledynamicfilters_Internalname ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string GXEncryptionTmp ;
      private string GXt_char13 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string tblTablefilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_proddsc3_cell_Internalname ;
      private string edtavProddsc3_Jsonclick ;
      private string cellFilter_prodcuentavdsc3_cell_Internalname ;
      private string edtavProdcuentavdsc3_Jsonclick ;
      private string cellFilter_prodcuentacdsc3_cell_Internalname ;
      private string edtavProdcuentacdsc3_Jsonclick ;
      private string cellFilter_prodcuentaadsc3_cell_Internalname ;
      private string edtavProdcuentaadsc3_Jsonclick ;
      private string cellFilter_lindsc3_cell_Internalname ;
      private string edtavLindsc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_proddsc2_cell_Internalname ;
      private string edtavProddsc2_Jsonclick ;
      private string cellFilter_prodcuentavdsc2_cell_Internalname ;
      private string edtavProdcuentavdsc2_Jsonclick ;
      private string cellFilter_prodcuentacdsc2_cell_Internalname ;
      private string edtavProdcuentacdsc2_Jsonclick ;
      private string cellFilter_prodcuentaadsc2_cell_Internalname ;
      private string edtavProdcuentaadsc2_Jsonclick ;
      private string cellFilter_lindsc2_cell_Internalname ;
      private string edtavLindsc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_proddsc1_cell_Internalname ;
      private string edtavProddsc1_Jsonclick ;
      private string cellFilter_prodcuentavdsc1_cell_Internalname ;
      private string edtavProdcuentavdsc1_Jsonclick ;
      private string cellFilter_prodcuentacdsc1_cell_Internalname ;
      private string edtavProdcuentacdsc1_Jsonclick ;
      private string cellFilter_prodcuentaadsc1_cell_Internalname ;
      private string edtavProdcuentaadsc1_Jsonclick ;
      private string cellFilter_lindsc1_cell_Internalname ;
      private string edtavLindsc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_137_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtProdCod_Jsonclick ;
      private string edtLinCod_Jsonclick ;
      private string edtProdDsc_Jsonclick ;
      private string edtSublCod_Jsonclick ;
      private string edtFamCod_Jsonclick ;
      private string edtUniCod_Jsonclick ;
      private string edtProdPeso_Jsonclick ;
      private string edtProdVolumen_Jsonclick ;
      private string edtProdStkMax_Jsonclick ;
      private string edtProdStkMin_Jsonclick ;
      private string edtProdRef1_Jsonclick ;
      private string edtProdRef2_Jsonclick ;
      private string edtProdRef3_Jsonclick ;
      private string edtProdRef4_Jsonclick ;
      private string edtProdRef5_Jsonclick ;
      private string edtProdRef6_Jsonclick ;
      private string edtProdRef7_Jsonclick ;
      private string edtProdRef8_Jsonclick ;
      private string edtProdRef9_Jsonclick ;
      private string edtProdRef10_Jsonclick ;
      private string cmbProdSts_Jsonclick ;
      private string edtProdCosto_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV14OrderedDsc ;
      private bool AV36DynamicFiltersIgnoreFirst ;
      private bool AV35DynamicFiltersRemoving ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n51SublCod ;
      private bool n50FamCod ;
      private bool n1695ProdFoto ;
      private bool bGXsfl_137_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV121Almacen_productoswwds_8_dynamicfiltersenabled2 ;
      private bool AV129Almacen_productoswwds_16_dynamicfiltersenabled3 ;
      private bool n48ProdCuentaV ;
      private bool n53ProdCuentaC ;
      private bool n54ProdCuentaA ;
      private bool n40000ProdFoto_GXI ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A1695ProdFoto_IsBlob ;
      private string AV105TFProdSts_SelsJson ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV92GridAppliedFilters ;
      private string A40000ProdFoto_GXI ;
      private string AV114Almacen_productoswwds_1_dynamicfiltersselector1 ;
      private string AV122Almacen_productoswwds_9_dynamicfiltersselector2 ;
      private string AV130Almacen_productoswwds_17_dynamicfiltersselector3 ;
      private string AV37ExcelFilename ;
      private string AV38ErrorMessage ;
      private string A1695ProdFoto ;
      private GxSimpleCollection<short> AV106TFProdSts_Sels ;
      private GxSimpleCollection<short> AV179Almacen_productoswwds_66_tfprodsts_sels ;
      private IGxSession AV39Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCheckbox chkProdVta ;
      private GXCheckbox chkProdCmp ;
      private GXCombobox cmbProdSts ;
      private IDataStoreProvider pr_default ;
      private string[] H004R2_A48ProdCuentaV ;
      private bool[] H004R2_n48ProdCuentaV ;
      private string[] H004R2_A53ProdCuentaC ;
      private bool[] H004R2_n53ProdCuentaC ;
      private string[] H004R2_A54ProdCuentaA ;
      private bool[] H004R2_n54ProdCuentaA ;
      private string[] H004R2_A1153LinDsc ;
      private string[] H004R2_A1684ProdCuentaADsc ;
      private string[] H004R2_A1685ProdCuentaCDsc ;
      private string[] H004R2_A1686ProdCuentaVDsc ;
      private decimal[] H004R2_A1681ProdCosto ;
      private short[] H004R2_A1718ProdSts ;
      private string[] H004R2_A1706ProdRef10 ;
      private string[] H004R2_A1714ProdRef9 ;
      private string[] H004R2_A1713ProdRef8 ;
      private string[] H004R2_A1712ProdRef7 ;
      private string[] H004R2_A1711ProdRef6 ;
      private string[] H004R2_A1710ProdRef5 ;
      private string[] H004R2_A1709ProdRef4 ;
      private string[] H004R2_A1708ProdRef3 ;
      private string[] H004R2_A1707ProdRef2 ;
      private string[] H004R2_A1705ProdRef1 ;
      private string[] H004R2_A40000ProdFoto_GXI ;
      private bool[] H004R2_n40000ProdFoto_GXI ;
      private decimal[] H004R2_A1717ProdStkMin ;
      private decimal[] H004R2_A1716ProdStkMax ;
      private decimal[] H004R2_A1723ProdVolumen ;
      private decimal[] H004R2_A1702ProdPeso ;
      private short[] H004R2_A1679ProdCmp ;
      private short[] H004R2_A1724ProdVta ;
      private int[] H004R2_A49UniCod ;
      private int[] H004R2_A50FamCod ;
      private bool[] H004R2_n50FamCod ;
      private int[] H004R2_A51SublCod ;
      private bool[] H004R2_n51SublCod ;
      private string[] H004R2_A55ProdDsc ;
      private int[] H004R2_A52LinCod ;
      private string[] H004R2_A28ProdCod ;
      private string[] H004R2_A1695ProdFoto ;
      private bool[] H004R2_n1695ProdFoto ;
      private long[] H004R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV94AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV88DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV95AGExportDataItem ;
   }

   public class productosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004R2( IGxContext context ,
                                             short A1718ProdSts ,
                                             GxSimpleCollection<short> AV179Almacen_productoswwds_66_tfprodsts_sels ,
                                             string AV114Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                             short AV115Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                             string AV116Almacen_productoswwds_3_proddsc1 ,
                                             string AV117Almacen_productoswwds_4_prodcuentavdsc1 ,
                                             string AV118Almacen_productoswwds_5_prodcuentacdsc1 ,
                                             string AV119Almacen_productoswwds_6_prodcuentaadsc1 ,
                                             string AV120Almacen_productoswwds_7_lindsc1 ,
                                             bool AV121Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                             string AV122Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                             short AV123Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                             string AV124Almacen_productoswwds_11_proddsc2 ,
                                             string AV125Almacen_productoswwds_12_prodcuentavdsc2 ,
                                             string AV126Almacen_productoswwds_13_prodcuentacdsc2 ,
                                             string AV127Almacen_productoswwds_14_prodcuentaadsc2 ,
                                             string AV128Almacen_productoswwds_15_lindsc2 ,
                                             bool AV129Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                             string AV130Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                             short AV131Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                             string AV132Almacen_productoswwds_19_proddsc3 ,
                                             string AV133Almacen_productoswwds_20_prodcuentavdsc3 ,
                                             string AV134Almacen_productoswwds_21_prodcuentacdsc3 ,
                                             string AV135Almacen_productoswwds_22_prodcuentaadsc3 ,
                                             string AV136Almacen_productoswwds_23_lindsc3 ,
                                             string AV138Almacen_productoswwds_25_tfprodcod_sel ,
                                             string AV137Almacen_productoswwds_24_tfprodcod ,
                                             int AV139Almacen_productoswwds_26_tflincod ,
                                             int AV140Almacen_productoswwds_27_tflincod_to ,
                                             string AV142Almacen_productoswwds_29_tfproddsc_sel ,
                                             string AV141Almacen_productoswwds_28_tfproddsc ,
                                             int AV143Almacen_productoswwds_30_tfsublcod ,
                                             int AV144Almacen_productoswwds_31_tfsublcod_to ,
                                             int AV145Almacen_productoswwds_32_tffamcod ,
                                             int AV146Almacen_productoswwds_33_tffamcod_to ,
                                             int AV147Almacen_productoswwds_34_tfunicod ,
                                             int AV148Almacen_productoswwds_35_tfunicod_to ,
                                             short AV149Almacen_productoswwds_36_tfprodvta_sel ,
                                             short AV150Almacen_productoswwds_37_tfprodcmp_sel ,
                                             decimal AV151Almacen_productoswwds_38_tfprodpeso ,
                                             decimal AV152Almacen_productoswwds_39_tfprodpeso_to ,
                                             decimal AV153Almacen_productoswwds_40_tfprodvolumen ,
                                             decimal AV154Almacen_productoswwds_41_tfprodvolumen_to ,
                                             decimal AV155Almacen_productoswwds_42_tfprodstkmax ,
                                             decimal AV156Almacen_productoswwds_43_tfprodstkmax_to ,
                                             decimal AV157Almacen_productoswwds_44_tfprodstkmin ,
                                             decimal AV158Almacen_productoswwds_45_tfprodstkmin_to ,
                                             string AV160Almacen_productoswwds_47_tfprodref1_sel ,
                                             string AV159Almacen_productoswwds_46_tfprodref1 ,
                                             string AV162Almacen_productoswwds_49_tfprodref2_sel ,
                                             string AV161Almacen_productoswwds_48_tfprodref2 ,
                                             string AV164Almacen_productoswwds_51_tfprodref3_sel ,
                                             string AV163Almacen_productoswwds_50_tfprodref3 ,
                                             string AV166Almacen_productoswwds_53_tfprodref4_sel ,
                                             string AV165Almacen_productoswwds_52_tfprodref4 ,
                                             string AV168Almacen_productoswwds_55_tfprodref5_sel ,
                                             string AV167Almacen_productoswwds_54_tfprodref5 ,
                                             string AV170Almacen_productoswwds_57_tfprodref6_sel ,
                                             string AV169Almacen_productoswwds_56_tfprodref6 ,
                                             string AV172Almacen_productoswwds_59_tfprodref7_sel ,
                                             string AV171Almacen_productoswwds_58_tfprodref7 ,
                                             string AV174Almacen_productoswwds_61_tfprodref8_sel ,
                                             string AV173Almacen_productoswwds_60_tfprodref8 ,
                                             string AV176Almacen_productoswwds_63_tfprodref9_sel ,
                                             string AV175Almacen_productoswwds_62_tfprodref9 ,
                                             string AV178Almacen_productoswwds_65_tfprodref10_sel ,
                                             string AV177Almacen_productoswwds_64_tfprodref10 ,
                                             int AV179Almacen_productoswwds_66_tfprodsts_sels_Count ,
                                             decimal AV180Almacen_productoswwds_67_tfprodcosto ,
                                             decimal AV181Almacen_productoswwds_68_tfprodcosto_to ,
                                             string A55ProdDsc ,
                                             string A1686ProdCuentaVDsc ,
                                             string A1685ProdCuentaCDsc ,
                                             string A1684ProdCuentaADsc ,
                                             string A1153LinDsc ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A49UniCod ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             decimal A1702ProdPeso ,
                                             decimal A1723ProdVolumen ,
                                             decimal A1716ProdStkMax ,
                                             decimal A1717ProdStkMin ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             decimal A1681ProdCosto ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[75];
         Object[] GXv_Object15 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ProdCuentaV] AS ProdCuentaV, T1.[ProdCuentaC] AS ProdCuentaC, T1.[ProdCuentaA] AS ProdCuentaA, T5.[LinDsc], T4.[CueDsc] AS ProdCuentaADsc, T3.[CueDsc] AS ProdCuentaCDsc, T2.[CueDsc] AS ProdCuentaVDsc, T1.[ProdCosto], T1.[ProdSts], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1], T1.[ProdFoto_GXI], T1.[ProdStkMin], T1.[ProdStkMax], T1.[ProdVolumen], T1.[ProdPeso], T1.[ProdCmp], T1.[ProdVta], T1.[UniCod], T1.[FamCod], T1.[SublCod], T1.[ProdDsc], T1.[LinCod], T1.[ProdCod], T1.[ProdFoto]";
         sFromString = " FROM (((([APRODUCTOS] T1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ProdCuentaV]) LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[ProdCuentaC]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[ProdCuentaA]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T1.[LinCod])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV116Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int14[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV116Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int14[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV117Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int14[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV117Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int14[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV118Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int14[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV118Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int14[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV119Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV119Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV120Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV120Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV124Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV124Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV125Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV125Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV126Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV126Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV127Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV127Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV128Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV128Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV132Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV132Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV133Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV133Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV134Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV134Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV135Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV135Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int14[27] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like @lV136Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int14[28] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[LinDsc] like '%' + @lV136Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int14[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_25_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Almacen_productoswwds_24_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV137Almacen_productoswwds_24_tfprodcod)");
         }
         else
         {
            GXv_int14[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_25_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV138Almacen_productoswwds_25_tfprodcod_sel)");
         }
         else
         {
            GXv_int14[31] = 1;
         }
         if ( ! (0==AV139Almacen_productoswwds_26_tflincod) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] >= @AV139Almacen_productoswwds_26_tflincod)");
         }
         else
         {
            GXv_int14[32] = 1;
         }
         if ( ! (0==AV140Almacen_productoswwds_27_tflincod_to) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] <= @AV140Almacen_productoswwds_27_tflincod_to)");
         }
         else
         {
            GXv_int14[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV142Almacen_productoswwds_29_tfproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Almacen_productoswwds_28_tfproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV141Almacen_productoswwds_28_tfproddsc)");
         }
         else
         {
            GXv_int14[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Almacen_productoswwds_29_tfproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV142Almacen_productoswwds_29_tfproddsc_sel)");
         }
         else
         {
            GXv_int14[35] = 1;
         }
         if ( ! (0==AV143Almacen_productoswwds_30_tfsublcod) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] >= @AV143Almacen_productoswwds_30_tfsublcod)");
         }
         else
         {
            GXv_int14[36] = 1;
         }
         if ( ! (0==AV144Almacen_productoswwds_31_tfsublcod_to) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] <= @AV144Almacen_productoswwds_31_tfsublcod_to)");
         }
         else
         {
            GXv_int14[37] = 1;
         }
         if ( ! (0==AV145Almacen_productoswwds_32_tffamcod) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] >= @AV145Almacen_productoswwds_32_tffamcod)");
         }
         else
         {
            GXv_int14[38] = 1;
         }
         if ( ! (0==AV146Almacen_productoswwds_33_tffamcod_to) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] <= @AV146Almacen_productoswwds_33_tffamcod_to)");
         }
         else
         {
            GXv_int14[39] = 1;
         }
         if ( ! (0==AV147Almacen_productoswwds_34_tfunicod) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] >= @AV147Almacen_productoswwds_34_tfunicod)");
         }
         else
         {
            GXv_int14[40] = 1;
         }
         if ( ! (0==AV148Almacen_productoswwds_35_tfunicod_to) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] <= @AV148Almacen_productoswwds_35_tfunicod_to)");
         }
         else
         {
            GXv_int14[41] = 1;
         }
         if ( AV149Almacen_productoswwds_36_tfprodvta_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( AV149Almacen_productoswwds_36_tfprodvta_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 0)");
         }
         if ( AV150Almacen_productoswwds_37_tfprodcmp_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         if ( AV150Almacen_productoswwds_37_tfprodcmp_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 0)");
         }
         if ( ! (Convert.ToDecimal(0)==AV151Almacen_productoswwds_38_tfprodpeso) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] >= @AV151Almacen_productoswwds_38_tfprodpeso)");
         }
         else
         {
            GXv_int14[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Almacen_productoswwds_39_tfprodpeso_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] <= @AV152Almacen_productoswwds_39_tfprodpeso_to)");
         }
         else
         {
            GXv_int14[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Almacen_productoswwds_40_tfprodvolumen) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] >= @AV153Almacen_productoswwds_40_tfprodvolumen)");
         }
         else
         {
            GXv_int14[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Almacen_productoswwds_41_tfprodvolumen_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] <= @AV154Almacen_productoswwds_41_tfprodvolumen_to)");
         }
         else
         {
            GXv_int14[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV155Almacen_productoswwds_42_tfprodstkmax) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] >= @AV155Almacen_productoswwds_42_tfprodstkmax)");
         }
         else
         {
            GXv_int14[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV156Almacen_productoswwds_43_tfprodstkmax_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] <= @AV156Almacen_productoswwds_43_tfprodstkmax_to)");
         }
         else
         {
            GXv_int14[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV157Almacen_productoswwds_44_tfprodstkmin) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] >= @AV157Almacen_productoswwds_44_tfprodstkmin)");
         }
         else
         {
            GXv_int14[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Almacen_productoswwds_45_tfprodstkmin_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] <= @AV158Almacen_productoswwds_45_tfprodstkmin_to)");
         }
         else
         {
            GXv_int14[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_47_tfprodref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Almacen_productoswwds_46_tfprodref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] like @lV159Almacen_productoswwds_46_tfprodref1)");
         }
         else
         {
            GXv_int14[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_47_tfprodref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] = @AV160Almacen_productoswwds_47_tfprodref1_sel)");
         }
         else
         {
            GXv_int14[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_49_tfprodref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Almacen_productoswwds_48_tfprodref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] like @lV161Almacen_productoswwds_48_tfprodref2)");
         }
         else
         {
            GXv_int14[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_49_tfprodref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] = @AV162Almacen_productoswwds_49_tfprodref2_sel)");
         }
         else
         {
            GXv_int14[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_51_tfprodref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Almacen_productoswwds_50_tfprodref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] like @lV163Almacen_productoswwds_50_tfprodref3)");
         }
         else
         {
            GXv_int14[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_51_tfprodref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] = @AV164Almacen_productoswwds_51_tfprodref3_sel)");
         }
         else
         {
            GXv_int14[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_53_tfprodref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Almacen_productoswwds_52_tfprodref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] like @lV165Almacen_productoswwds_52_tfprodref4)");
         }
         else
         {
            GXv_int14[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_53_tfprodref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] = @AV166Almacen_productoswwds_53_tfprodref4_sel)");
         }
         else
         {
            GXv_int14[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_55_tfprodref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Almacen_productoswwds_54_tfprodref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] like @lV167Almacen_productoswwds_54_tfprodref5)");
         }
         else
         {
            GXv_int14[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_55_tfprodref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] = @AV168Almacen_productoswwds_55_tfprodref5_sel)");
         }
         else
         {
            GXv_int14[59] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_57_tfprodref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Almacen_productoswwds_56_tfprodref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] like @lV169Almacen_productoswwds_56_tfprodref6)");
         }
         else
         {
            GXv_int14[60] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_57_tfprodref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] = @AV170Almacen_productoswwds_57_tfprodref6_sel)");
         }
         else
         {
            GXv_int14[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_59_tfprodref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Almacen_productoswwds_58_tfprodref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] like @lV171Almacen_productoswwds_58_tfprodref7)");
         }
         else
         {
            GXv_int14[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_59_tfprodref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] = @AV172Almacen_productoswwds_59_tfprodref7_sel)");
         }
         else
         {
            GXv_int14[63] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_61_tfprodref8_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Almacen_productoswwds_60_tfprodref8)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] like @lV173Almacen_productoswwds_60_tfprodref8)");
         }
         else
         {
            GXv_int14[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_61_tfprodref8_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] = @AV174Almacen_productoswwds_61_tfprodref8_sel)");
         }
         else
         {
            GXv_int14[65] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV176Almacen_productoswwds_63_tfprodref9_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Almacen_productoswwds_62_tfprodref9)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] like @lV175Almacen_productoswwds_62_tfprodref9)");
         }
         else
         {
            GXv_int14[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Almacen_productoswwds_63_tfprodref9_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] = @AV176Almacen_productoswwds_63_tfprodref9_sel)");
         }
         else
         {
            GXv_int14[67] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Almacen_productoswwds_65_tfprodref10_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Almacen_productoswwds_64_tfprodref10)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] like @lV177Almacen_productoswwds_64_tfprodref10)");
         }
         else
         {
            GXv_int14[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Almacen_productoswwds_65_tfprodref10_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] = @AV178Almacen_productoswwds_65_tfprodref10_sel)");
         }
         else
         {
            GXv_int14[69] = 1;
         }
         if ( AV179Almacen_productoswwds_66_tfprodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV179Almacen_productoswwds_66_tfprodsts_sels, "T1.[ProdSts] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV180Almacen_productoswwds_67_tfprodcosto) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] >= @AV180Almacen_productoswwds_67_tfprodcosto)");
         }
         else
         {
            GXv_int14[70] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV181Almacen_productoswwds_68_tfprodcosto_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] <= @AV181Almacen_productoswwds_68_tfprodcosto_to)");
         }
         else
         {
            GXv_int14[71] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdDsc]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdCod] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[LinCod]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[LinCod] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[SublCod]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[SublCod] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[FamCod]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[FamCod] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[UniCod]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[UniCod] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdVta]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdVta] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdCmp]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdCmp] DESC";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdPeso]";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdPeso] DESC";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdVolumen]";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdVolumen] DESC";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdStkMax]";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdStkMax] DESC";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdStkMin]";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdStkMin] DESC";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef1]";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef1] DESC";
         }
         else if ( ( AV13OrderedBy == 14 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef2]";
         }
         else if ( ( AV13OrderedBy == 14 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef2] DESC";
         }
         else if ( ( AV13OrderedBy == 15 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef3]";
         }
         else if ( ( AV13OrderedBy == 15 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef3] DESC";
         }
         else if ( ( AV13OrderedBy == 16 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef4]";
         }
         else if ( ( AV13OrderedBy == 16 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef4] DESC";
         }
         else if ( ( AV13OrderedBy == 17 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef5]";
         }
         else if ( ( AV13OrderedBy == 17 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef5] DESC";
         }
         else if ( ( AV13OrderedBy == 18 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef6]";
         }
         else if ( ( AV13OrderedBy == 18 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef6] DESC";
         }
         else if ( ( AV13OrderedBy == 19 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef7]";
         }
         else if ( ( AV13OrderedBy == 19 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef7] DESC";
         }
         else if ( ( AV13OrderedBy == 20 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef8]";
         }
         else if ( ( AV13OrderedBy == 20 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef8] DESC";
         }
         else if ( ( AV13OrderedBy == 21 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef9]";
         }
         else if ( ( AV13OrderedBy == 21 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef9] DESC";
         }
         else if ( ( AV13OrderedBy == 22 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdRef10]";
         }
         else if ( ( AV13OrderedBy == 22 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdRef10] DESC";
         }
         else if ( ( AV13OrderedBy == 23 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdSts]";
         }
         else if ( ( AV13OrderedBy == 23 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdSts] DESC";
         }
         else if ( ( AV13OrderedBy == 24 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[ProdCosto]";
         }
         else if ( ( AV13OrderedBy == 24 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[ProdCosto] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProdCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      protected Object[] conditional_H004R3( IGxContext context ,
                                             short A1718ProdSts ,
                                             GxSimpleCollection<short> AV179Almacen_productoswwds_66_tfprodsts_sels ,
                                             string AV114Almacen_productoswwds_1_dynamicfiltersselector1 ,
                                             short AV115Almacen_productoswwds_2_dynamicfiltersoperator1 ,
                                             string AV116Almacen_productoswwds_3_proddsc1 ,
                                             string AV117Almacen_productoswwds_4_prodcuentavdsc1 ,
                                             string AV118Almacen_productoswwds_5_prodcuentacdsc1 ,
                                             string AV119Almacen_productoswwds_6_prodcuentaadsc1 ,
                                             string AV120Almacen_productoswwds_7_lindsc1 ,
                                             bool AV121Almacen_productoswwds_8_dynamicfiltersenabled2 ,
                                             string AV122Almacen_productoswwds_9_dynamicfiltersselector2 ,
                                             short AV123Almacen_productoswwds_10_dynamicfiltersoperator2 ,
                                             string AV124Almacen_productoswwds_11_proddsc2 ,
                                             string AV125Almacen_productoswwds_12_prodcuentavdsc2 ,
                                             string AV126Almacen_productoswwds_13_prodcuentacdsc2 ,
                                             string AV127Almacen_productoswwds_14_prodcuentaadsc2 ,
                                             string AV128Almacen_productoswwds_15_lindsc2 ,
                                             bool AV129Almacen_productoswwds_16_dynamicfiltersenabled3 ,
                                             string AV130Almacen_productoswwds_17_dynamicfiltersselector3 ,
                                             short AV131Almacen_productoswwds_18_dynamicfiltersoperator3 ,
                                             string AV132Almacen_productoswwds_19_proddsc3 ,
                                             string AV133Almacen_productoswwds_20_prodcuentavdsc3 ,
                                             string AV134Almacen_productoswwds_21_prodcuentacdsc3 ,
                                             string AV135Almacen_productoswwds_22_prodcuentaadsc3 ,
                                             string AV136Almacen_productoswwds_23_lindsc3 ,
                                             string AV138Almacen_productoswwds_25_tfprodcod_sel ,
                                             string AV137Almacen_productoswwds_24_tfprodcod ,
                                             int AV139Almacen_productoswwds_26_tflincod ,
                                             int AV140Almacen_productoswwds_27_tflincod_to ,
                                             string AV142Almacen_productoswwds_29_tfproddsc_sel ,
                                             string AV141Almacen_productoswwds_28_tfproddsc ,
                                             int AV143Almacen_productoswwds_30_tfsublcod ,
                                             int AV144Almacen_productoswwds_31_tfsublcod_to ,
                                             int AV145Almacen_productoswwds_32_tffamcod ,
                                             int AV146Almacen_productoswwds_33_tffamcod_to ,
                                             int AV147Almacen_productoswwds_34_tfunicod ,
                                             int AV148Almacen_productoswwds_35_tfunicod_to ,
                                             short AV149Almacen_productoswwds_36_tfprodvta_sel ,
                                             short AV150Almacen_productoswwds_37_tfprodcmp_sel ,
                                             decimal AV151Almacen_productoswwds_38_tfprodpeso ,
                                             decimal AV152Almacen_productoswwds_39_tfprodpeso_to ,
                                             decimal AV153Almacen_productoswwds_40_tfprodvolumen ,
                                             decimal AV154Almacen_productoswwds_41_tfprodvolumen_to ,
                                             decimal AV155Almacen_productoswwds_42_tfprodstkmax ,
                                             decimal AV156Almacen_productoswwds_43_tfprodstkmax_to ,
                                             decimal AV157Almacen_productoswwds_44_tfprodstkmin ,
                                             decimal AV158Almacen_productoswwds_45_tfprodstkmin_to ,
                                             string AV160Almacen_productoswwds_47_tfprodref1_sel ,
                                             string AV159Almacen_productoswwds_46_tfprodref1 ,
                                             string AV162Almacen_productoswwds_49_tfprodref2_sel ,
                                             string AV161Almacen_productoswwds_48_tfprodref2 ,
                                             string AV164Almacen_productoswwds_51_tfprodref3_sel ,
                                             string AV163Almacen_productoswwds_50_tfprodref3 ,
                                             string AV166Almacen_productoswwds_53_tfprodref4_sel ,
                                             string AV165Almacen_productoswwds_52_tfprodref4 ,
                                             string AV168Almacen_productoswwds_55_tfprodref5_sel ,
                                             string AV167Almacen_productoswwds_54_tfprodref5 ,
                                             string AV170Almacen_productoswwds_57_tfprodref6_sel ,
                                             string AV169Almacen_productoswwds_56_tfprodref6 ,
                                             string AV172Almacen_productoswwds_59_tfprodref7_sel ,
                                             string AV171Almacen_productoswwds_58_tfprodref7 ,
                                             string AV174Almacen_productoswwds_61_tfprodref8_sel ,
                                             string AV173Almacen_productoswwds_60_tfprodref8 ,
                                             string AV176Almacen_productoswwds_63_tfprodref9_sel ,
                                             string AV175Almacen_productoswwds_62_tfprodref9 ,
                                             string AV178Almacen_productoswwds_65_tfprodref10_sel ,
                                             string AV177Almacen_productoswwds_64_tfprodref10 ,
                                             int AV179Almacen_productoswwds_66_tfprodsts_sels_Count ,
                                             decimal AV180Almacen_productoswwds_67_tfprodcosto ,
                                             decimal AV181Almacen_productoswwds_68_tfprodcosto_to ,
                                             string A55ProdDsc ,
                                             string A1686ProdCuentaVDsc ,
                                             string A1685ProdCuentaCDsc ,
                                             string A1684ProdCuentaADsc ,
                                             string A1153LinDsc ,
                                             string A28ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A49UniCod ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             decimal A1702ProdPeso ,
                                             decimal A1723ProdVolumen ,
                                             decimal A1716ProdStkMax ,
                                             decimal A1717ProdStkMin ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             decimal A1681ProdCosto ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int16 = new short[72];
         Object[] GXv_Object17 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((([APRODUCTOS] T1 LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[ProdCuentaV]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[ProdCuentaC]) LEFT JOIN [CBPLANCUENTA] T5 ON T5.[CueCod] = T1.[ProdCuentaA]) INNER JOIN [CLINEAPROD] T2 ON T2.[LinCod] = T1.[LinCod])";
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV116Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int16[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Almacen_productoswwds_3_proddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV116Almacen_productoswwds_3_proddsc1)");
         }
         else
         {
            GXv_int16[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV117Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int16[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAVDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Almacen_productoswwds_4_prodcuentavdsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV117Almacen_productoswwds_4_prodcuentavdsc1)");
         }
         else
         {
            GXv_int16[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV118Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int16[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTACDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Almacen_productoswwds_5_prodcuentacdsc1)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV118Almacen_productoswwds_5_prodcuentacdsc1)");
         }
         else
         {
            GXv_int16[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like @lV119Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int16[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "PRODCUENTAADSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Almacen_productoswwds_6_prodcuentaadsc1)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like '%' + @lV119Almacen_productoswwds_6_prodcuentaadsc1)");
         }
         else
         {
            GXv_int16[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like @lV120Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int16[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV114Almacen_productoswwds_1_dynamicfiltersselector1, "LINDSC") == 0 ) && ( AV115Almacen_productoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Almacen_productoswwds_7_lindsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like '%' + @lV120Almacen_productoswwds_7_lindsc1)");
         }
         else
         {
            GXv_int16[9] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV124Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int16[10] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Almacen_productoswwds_11_proddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV124Almacen_productoswwds_11_proddsc2)");
         }
         else
         {
            GXv_int16[11] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV125Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int16[12] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAVDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Almacen_productoswwds_12_prodcuentavdsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV125Almacen_productoswwds_12_prodcuentavdsc2)");
         }
         else
         {
            GXv_int16[13] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV126Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int16[14] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTACDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Almacen_productoswwds_13_prodcuentacdsc2)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV126Almacen_productoswwds_13_prodcuentacdsc2)");
         }
         else
         {
            GXv_int16[15] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like @lV127Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int16[16] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "PRODCUENTAADSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Almacen_productoswwds_14_prodcuentaadsc2)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like '%' + @lV127Almacen_productoswwds_14_prodcuentaadsc2)");
         }
         else
         {
            GXv_int16[17] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like @lV128Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int16[18] = 1;
         }
         if ( AV121Almacen_productoswwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Almacen_productoswwds_9_dynamicfiltersselector2, "LINDSC") == 0 ) && ( AV123Almacen_productoswwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Almacen_productoswwds_15_lindsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like '%' + @lV128Almacen_productoswwds_15_lindsc2)");
         }
         else
         {
            GXv_int16[19] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV132Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int16[20] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Almacen_productoswwds_19_proddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like '%' + @lV132Almacen_productoswwds_19_proddsc3)");
         }
         else
         {
            GXv_int16[21] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like @lV133Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int16[22] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAVDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Almacen_productoswwds_20_prodcuentavdsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[CueDsc] like '%' + @lV133Almacen_productoswwds_20_prodcuentavdsc3)");
         }
         else
         {
            GXv_int16[23] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like @lV134Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int16[24] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTACDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Almacen_productoswwds_21_prodcuentacdsc3)) ) )
         {
            AddWhere(sWhereString, "(T4.[CueDsc] like '%' + @lV134Almacen_productoswwds_21_prodcuentacdsc3)");
         }
         else
         {
            GXv_int16[25] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like @lV135Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int16[26] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "PRODCUENTAADSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Almacen_productoswwds_22_prodcuentaadsc3)) ) )
         {
            AddWhere(sWhereString, "(T5.[CueDsc] like '%' + @lV135Almacen_productoswwds_22_prodcuentaadsc3)");
         }
         else
         {
            GXv_int16[27] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like @lV136Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int16[28] = 1;
         }
         if ( AV129Almacen_productoswwds_16_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV130Almacen_productoswwds_17_dynamicfiltersselector3, "LINDSC") == 0 ) && ( AV131Almacen_productoswwds_18_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Almacen_productoswwds_23_lindsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[LinDsc] like '%' + @lV136Almacen_productoswwds_23_lindsc3)");
         }
         else
         {
            GXv_int16[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_25_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Almacen_productoswwds_24_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV137Almacen_productoswwds_24_tfprodcod)");
         }
         else
         {
            GXv_int16[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Almacen_productoswwds_25_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV138Almacen_productoswwds_25_tfprodcod_sel)");
         }
         else
         {
            GXv_int16[31] = 1;
         }
         if ( ! (0==AV139Almacen_productoswwds_26_tflincod) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] >= @AV139Almacen_productoswwds_26_tflincod)");
         }
         else
         {
            GXv_int16[32] = 1;
         }
         if ( ! (0==AV140Almacen_productoswwds_27_tflincod_to) )
         {
            AddWhere(sWhereString, "(T1.[LinCod] <= @AV140Almacen_productoswwds_27_tflincod_to)");
         }
         else
         {
            GXv_int16[33] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV142Almacen_productoswwds_29_tfproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Almacen_productoswwds_28_tfproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV141Almacen_productoswwds_28_tfproddsc)");
         }
         else
         {
            GXv_int16[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Almacen_productoswwds_29_tfproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV142Almacen_productoswwds_29_tfproddsc_sel)");
         }
         else
         {
            GXv_int16[35] = 1;
         }
         if ( ! (0==AV143Almacen_productoswwds_30_tfsublcod) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] >= @AV143Almacen_productoswwds_30_tfsublcod)");
         }
         else
         {
            GXv_int16[36] = 1;
         }
         if ( ! (0==AV144Almacen_productoswwds_31_tfsublcod_to) )
         {
            AddWhere(sWhereString, "(T1.[SublCod] <= @AV144Almacen_productoswwds_31_tfsublcod_to)");
         }
         else
         {
            GXv_int16[37] = 1;
         }
         if ( ! (0==AV145Almacen_productoswwds_32_tffamcod) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] >= @AV145Almacen_productoswwds_32_tffamcod)");
         }
         else
         {
            GXv_int16[38] = 1;
         }
         if ( ! (0==AV146Almacen_productoswwds_33_tffamcod_to) )
         {
            AddWhere(sWhereString, "(T1.[FamCod] <= @AV146Almacen_productoswwds_33_tffamcod_to)");
         }
         else
         {
            GXv_int16[39] = 1;
         }
         if ( ! (0==AV147Almacen_productoswwds_34_tfunicod) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] >= @AV147Almacen_productoswwds_34_tfunicod)");
         }
         else
         {
            GXv_int16[40] = 1;
         }
         if ( ! (0==AV148Almacen_productoswwds_35_tfunicod_to) )
         {
            AddWhere(sWhereString, "(T1.[UniCod] <= @AV148Almacen_productoswwds_35_tfunicod_to)");
         }
         else
         {
            GXv_int16[41] = 1;
         }
         if ( AV149Almacen_productoswwds_36_tfprodvta_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( AV149Almacen_productoswwds_36_tfprodvta_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 0)");
         }
         if ( AV150Almacen_productoswwds_37_tfprodcmp_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         if ( AV150Almacen_productoswwds_37_tfprodcmp_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 0)");
         }
         if ( ! (Convert.ToDecimal(0)==AV151Almacen_productoswwds_38_tfprodpeso) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] >= @AV151Almacen_productoswwds_38_tfprodpeso)");
         }
         else
         {
            GXv_int16[42] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Almacen_productoswwds_39_tfprodpeso_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdPeso] <= @AV152Almacen_productoswwds_39_tfprodpeso_to)");
         }
         else
         {
            GXv_int16[43] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Almacen_productoswwds_40_tfprodvolumen) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] >= @AV153Almacen_productoswwds_40_tfprodvolumen)");
         }
         else
         {
            GXv_int16[44] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Almacen_productoswwds_41_tfprodvolumen_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdVolumen] <= @AV154Almacen_productoswwds_41_tfprodvolumen_to)");
         }
         else
         {
            GXv_int16[45] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV155Almacen_productoswwds_42_tfprodstkmax) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] >= @AV155Almacen_productoswwds_42_tfprodstkmax)");
         }
         else
         {
            GXv_int16[46] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV156Almacen_productoswwds_43_tfprodstkmax_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMax] <= @AV156Almacen_productoswwds_43_tfprodstkmax_to)");
         }
         else
         {
            GXv_int16[47] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV157Almacen_productoswwds_44_tfprodstkmin) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] >= @AV157Almacen_productoswwds_44_tfprodstkmin)");
         }
         else
         {
            GXv_int16[48] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV158Almacen_productoswwds_45_tfprodstkmin_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdStkMin] <= @AV158Almacen_productoswwds_45_tfprodstkmin_to)");
         }
         else
         {
            GXv_int16[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_47_tfprodref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Almacen_productoswwds_46_tfprodref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] like @lV159Almacen_productoswwds_46_tfprodref1)");
         }
         else
         {
            GXv_int16[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Almacen_productoswwds_47_tfprodref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef1] = @AV160Almacen_productoswwds_47_tfprodref1_sel)");
         }
         else
         {
            GXv_int16[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_49_tfprodref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Almacen_productoswwds_48_tfprodref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] like @lV161Almacen_productoswwds_48_tfprodref2)");
         }
         else
         {
            GXv_int16[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Almacen_productoswwds_49_tfprodref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef2] = @AV162Almacen_productoswwds_49_tfprodref2_sel)");
         }
         else
         {
            GXv_int16[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_51_tfprodref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Almacen_productoswwds_50_tfprodref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] like @lV163Almacen_productoswwds_50_tfprodref3)");
         }
         else
         {
            GXv_int16[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Almacen_productoswwds_51_tfprodref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef3] = @AV164Almacen_productoswwds_51_tfprodref3_sel)");
         }
         else
         {
            GXv_int16[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_53_tfprodref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Almacen_productoswwds_52_tfprodref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] like @lV165Almacen_productoswwds_52_tfprodref4)");
         }
         else
         {
            GXv_int16[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Almacen_productoswwds_53_tfprodref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef4] = @AV166Almacen_productoswwds_53_tfprodref4_sel)");
         }
         else
         {
            GXv_int16[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_55_tfprodref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Almacen_productoswwds_54_tfprodref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] like @lV167Almacen_productoswwds_54_tfprodref5)");
         }
         else
         {
            GXv_int16[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Almacen_productoswwds_55_tfprodref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef5] = @AV168Almacen_productoswwds_55_tfprodref5_sel)");
         }
         else
         {
            GXv_int16[59] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_57_tfprodref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Almacen_productoswwds_56_tfprodref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] like @lV169Almacen_productoswwds_56_tfprodref6)");
         }
         else
         {
            GXv_int16[60] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Almacen_productoswwds_57_tfprodref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef6] = @AV170Almacen_productoswwds_57_tfprodref6_sel)");
         }
         else
         {
            GXv_int16[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_59_tfprodref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Almacen_productoswwds_58_tfprodref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] like @lV171Almacen_productoswwds_58_tfprodref7)");
         }
         else
         {
            GXv_int16[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Almacen_productoswwds_59_tfprodref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef7] = @AV172Almacen_productoswwds_59_tfprodref7_sel)");
         }
         else
         {
            GXv_int16[63] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_61_tfprodref8_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Almacen_productoswwds_60_tfprodref8)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] like @lV173Almacen_productoswwds_60_tfprodref8)");
         }
         else
         {
            GXv_int16[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Almacen_productoswwds_61_tfprodref8_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef8] = @AV174Almacen_productoswwds_61_tfprodref8_sel)");
         }
         else
         {
            GXv_int16[65] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV176Almacen_productoswwds_63_tfprodref9_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Almacen_productoswwds_62_tfprodref9)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] like @lV175Almacen_productoswwds_62_tfprodref9)");
         }
         else
         {
            GXv_int16[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Almacen_productoswwds_63_tfprodref9_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef9] = @AV176Almacen_productoswwds_63_tfprodref9_sel)");
         }
         else
         {
            GXv_int16[67] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Almacen_productoswwds_65_tfprodref10_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Almacen_productoswwds_64_tfprodref10)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] like @lV177Almacen_productoswwds_64_tfprodref10)");
         }
         else
         {
            GXv_int16[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Almacen_productoswwds_65_tfprodref10_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdRef10] = @AV178Almacen_productoswwds_65_tfprodref10_sel)");
         }
         else
         {
            GXv_int16[69] = 1;
         }
         if ( AV179Almacen_productoswwds_66_tfprodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV179Almacen_productoswwds_66_tfprodsts_sels, "T1.[ProdSts] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV180Almacen_productoswwds_67_tfprodcosto) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] >= @AV180Almacen_productoswwds_67_tfprodcosto)");
         }
         else
         {
            GXv_int16[70] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV181Almacen_productoswwds_68_tfprodcosto_to) )
         {
            AddWhere(sWhereString, "(T1.[ProdCosto] <= @AV181Almacen_productoswwds_68_tfprodcosto_to)");
         }
         else
         {
            GXv_int16[71] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 14 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 14 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 15 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 15 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 16 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 16 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 17 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 17 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 18 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 18 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 19 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 19 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 20 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 20 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 21 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 21 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 22 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 22 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 23 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 23 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 24 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 24 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object17[0] = scmdbuf;
         GXv_Object17[1] = GXv_int16;
         return GXv_Object17 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004R2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (int)dynConstraints[67] , (decimal)dynConstraints[68] , (decimal)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] , (int)dynConstraints[79] , (short)dynConstraints[80] , (short)dynConstraints[81] , (decimal)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (string)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (decimal)dynConstraints[96] , (short)dynConstraints[97] , (bool)dynConstraints[98] );
               case 1 :
                     return conditional_H004R3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] , (int)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (short)dynConstraints[37] , (short)dynConstraints[38] , (decimal)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (int)dynConstraints[67] , (decimal)dynConstraints[68] , (decimal)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (int)dynConstraints[76] , (int)dynConstraints[77] , (int)dynConstraints[78] , (int)dynConstraints[79] , (short)dynConstraints[80] , (short)dynConstraints[81] , (decimal)dynConstraints[82] , (decimal)dynConstraints[83] , (decimal)dynConstraints[84] , (decimal)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (string)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (string)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (decimal)dynConstraints[96] , (short)dynConstraints[97] , (bool)dynConstraints[98] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          new ParDef("@lV116Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV116Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV117Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV117Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV118Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV118Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV119Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV119Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV125Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV125Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV126Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV126Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV127Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV127Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV133Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV133Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV134Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV134Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV135Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV135Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV136Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV136Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV137Almacen_productoswwds_24_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV138Almacen_productoswwds_25_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@AV139Almacen_productoswwds_26_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV140Almacen_productoswwds_27_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV141Almacen_productoswwds_28_tfproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV142Almacen_productoswwds_29_tfproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV143Almacen_productoswwds_30_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV144Almacen_productoswwds_31_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV145Almacen_productoswwds_32_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV146Almacen_productoswwds_33_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV147Almacen_productoswwds_34_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV148Almacen_productoswwds_35_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@AV151Almacen_productoswwds_38_tfprodpeso",GXType.Decimal,15,5) ,
          new ParDef("@AV152Almacen_productoswwds_39_tfprodpeso_to",GXType.Decimal,15,5) ,
          new ParDef("@AV153Almacen_productoswwds_40_tfprodvolumen",GXType.Decimal,15,5) ,
          new ParDef("@AV154Almacen_productoswwds_41_tfprodvolumen_to",GXType.Decimal,15,5) ,
          new ParDef("@AV155Almacen_productoswwds_42_tfprodstkmax",GXType.Decimal,15,4) ,
          new ParDef("@AV156Almacen_productoswwds_43_tfprodstkmax_to",GXType.Decimal,15,4) ,
          new ParDef("@AV157Almacen_productoswwds_44_tfprodstkmin",GXType.Decimal,15,4) ,
          new ParDef("@AV158Almacen_productoswwds_45_tfprodstkmin_to",GXType.Decimal,15,4) ,
          new ParDef("@lV159Almacen_productoswwds_46_tfprodref1",GXType.NChar,20,0) ,
          new ParDef("@AV160Almacen_productoswwds_47_tfprodref1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV161Almacen_productoswwds_48_tfprodref2",GXType.NChar,20,0) ,
          new ParDef("@AV162Almacen_productoswwds_49_tfprodref2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV163Almacen_productoswwds_50_tfprodref3",GXType.NChar,20,0) ,
          new ParDef("@AV164Almacen_productoswwds_51_tfprodref3_sel",GXType.NChar,20,0) ,
          new ParDef("@lV165Almacen_productoswwds_52_tfprodref4",GXType.NChar,20,0) ,
          new ParDef("@AV166Almacen_productoswwds_53_tfprodref4_sel",GXType.NChar,20,0) ,
          new ParDef("@lV167Almacen_productoswwds_54_tfprodref5",GXType.NChar,20,0) ,
          new ParDef("@AV168Almacen_productoswwds_55_tfprodref5_sel",GXType.NChar,20,0) ,
          new ParDef("@lV169Almacen_productoswwds_56_tfprodref6",GXType.NChar,20,0) ,
          new ParDef("@AV170Almacen_productoswwds_57_tfprodref6_sel",GXType.NChar,20,0) ,
          new ParDef("@lV171Almacen_productoswwds_58_tfprodref7",GXType.NChar,20,0) ,
          new ParDef("@AV172Almacen_productoswwds_59_tfprodref7_sel",GXType.NChar,20,0) ,
          new ParDef("@lV173Almacen_productoswwds_60_tfprodref8",GXType.NChar,20,0) ,
          new ParDef("@AV174Almacen_productoswwds_61_tfprodref8_sel",GXType.NChar,20,0) ,
          new ParDef("@lV175Almacen_productoswwds_62_tfprodref9",GXType.NChar,20,0) ,
          new ParDef("@AV176Almacen_productoswwds_63_tfprodref9_sel",GXType.NChar,20,0) ,
          new ParDef("@lV177Almacen_productoswwds_64_tfprodref10",GXType.NChar,20,0) ,
          new ParDef("@AV178Almacen_productoswwds_65_tfprodref10_sel",GXType.NChar,20,0) ,
          new ParDef("@AV180Almacen_productoswwds_67_tfprodcosto",GXType.Decimal,18,5) ,
          new ParDef("@AV181Almacen_productoswwds_68_tfprodcosto_to",GXType.Decimal,18,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          new ParDef("@lV116Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV116Almacen_productoswwds_3_proddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV117Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV117Almacen_productoswwds_4_prodcuentavdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV118Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV118Almacen_productoswwds_5_prodcuentacdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV119Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV119Almacen_productoswwds_6_prodcuentaadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV120Almacen_productoswwds_7_lindsc1",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV124Almacen_productoswwds_11_proddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV125Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV125Almacen_productoswwds_12_prodcuentavdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV126Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV126Almacen_productoswwds_13_prodcuentacdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV127Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV127Almacen_productoswwds_14_prodcuentaadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV128Almacen_productoswwds_15_lindsc2",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV132Almacen_productoswwds_19_proddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV133Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV133Almacen_productoswwds_20_prodcuentavdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV134Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV134Almacen_productoswwds_21_prodcuentacdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV135Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV135Almacen_productoswwds_22_prodcuentaadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV136Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV136Almacen_productoswwds_23_lindsc3",GXType.NChar,100,0) ,
          new ParDef("@lV137Almacen_productoswwds_24_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV138Almacen_productoswwds_25_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@AV139Almacen_productoswwds_26_tflincod",GXType.Int32,6,0) ,
          new ParDef("@AV140Almacen_productoswwds_27_tflincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV141Almacen_productoswwds_28_tfproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV142Almacen_productoswwds_29_tfproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV143Almacen_productoswwds_30_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV144Almacen_productoswwds_31_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV145Almacen_productoswwds_32_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV146Almacen_productoswwds_33_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV147Almacen_productoswwds_34_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV148Almacen_productoswwds_35_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@AV151Almacen_productoswwds_38_tfprodpeso",GXType.Decimal,15,5) ,
          new ParDef("@AV152Almacen_productoswwds_39_tfprodpeso_to",GXType.Decimal,15,5) ,
          new ParDef("@AV153Almacen_productoswwds_40_tfprodvolumen",GXType.Decimal,15,5) ,
          new ParDef("@AV154Almacen_productoswwds_41_tfprodvolumen_to",GXType.Decimal,15,5) ,
          new ParDef("@AV155Almacen_productoswwds_42_tfprodstkmax",GXType.Decimal,15,4) ,
          new ParDef("@AV156Almacen_productoswwds_43_tfprodstkmax_to",GXType.Decimal,15,4) ,
          new ParDef("@AV157Almacen_productoswwds_44_tfprodstkmin",GXType.Decimal,15,4) ,
          new ParDef("@AV158Almacen_productoswwds_45_tfprodstkmin_to",GXType.Decimal,15,4) ,
          new ParDef("@lV159Almacen_productoswwds_46_tfprodref1",GXType.NChar,20,0) ,
          new ParDef("@AV160Almacen_productoswwds_47_tfprodref1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV161Almacen_productoswwds_48_tfprodref2",GXType.NChar,20,0) ,
          new ParDef("@AV162Almacen_productoswwds_49_tfprodref2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV163Almacen_productoswwds_50_tfprodref3",GXType.NChar,20,0) ,
          new ParDef("@AV164Almacen_productoswwds_51_tfprodref3_sel",GXType.NChar,20,0) ,
          new ParDef("@lV165Almacen_productoswwds_52_tfprodref4",GXType.NChar,20,0) ,
          new ParDef("@AV166Almacen_productoswwds_53_tfprodref4_sel",GXType.NChar,20,0) ,
          new ParDef("@lV167Almacen_productoswwds_54_tfprodref5",GXType.NChar,20,0) ,
          new ParDef("@AV168Almacen_productoswwds_55_tfprodref5_sel",GXType.NChar,20,0) ,
          new ParDef("@lV169Almacen_productoswwds_56_tfprodref6",GXType.NChar,20,0) ,
          new ParDef("@AV170Almacen_productoswwds_57_tfprodref6_sel",GXType.NChar,20,0) ,
          new ParDef("@lV171Almacen_productoswwds_58_tfprodref7",GXType.NChar,20,0) ,
          new ParDef("@AV172Almacen_productoswwds_59_tfprodref7_sel",GXType.NChar,20,0) ,
          new ParDef("@lV173Almacen_productoswwds_60_tfprodref8",GXType.NChar,20,0) ,
          new ParDef("@AV174Almacen_productoswwds_61_tfprodref8_sel",GXType.NChar,20,0) ,
          new ParDef("@lV175Almacen_productoswwds_62_tfprodref9",GXType.NChar,20,0) ,
          new ParDef("@AV176Almacen_productoswwds_63_tfprodref9_sel",GXType.NChar,20,0) ,
          new ParDef("@lV177Almacen_productoswwds_64_tfprodref10",GXType.NChar,20,0) ,
          new ParDef("@AV178Almacen_productoswwds_65_tfprodref10_sel",GXType.NChar,20,0) ,
          new ParDef("@AV180Almacen_productoswwds_67_tfprodcosto",GXType.Decimal,18,5) ,
          new ParDef("@AV181Almacen_productoswwds_68_tfprodcosto_to",GXType.Decimal,18,5)
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 100);
                ((string[]) buf[7])[0] = rslt.getString(5, 100);
                ((string[]) buf[8])[0] = rslt.getString(6, 100);
                ((string[]) buf[9])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 20);
                ((string[]) buf[13])[0] = rslt.getString(11, 20);
                ((string[]) buf[14])[0] = rslt.getString(12, 20);
                ((string[]) buf[15])[0] = rslt.getString(13, 20);
                ((string[]) buf[16])[0] = rslt.getString(14, 20);
                ((string[]) buf[17])[0] = rslt.getString(15, 20);
                ((string[]) buf[18])[0] = rslt.getString(16, 20);
                ((string[]) buf[19])[0] = rslt.getString(17, 20);
                ((string[]) buf[20])[0] = rslt.getString(18, 20);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((string[]) buf[22])[0] = rslt.getMultimediaUri(20);
                ((bool[]) buf[23])[0] = rslt.wasNull(20);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(24);
                ((short[]) buf[28])[0] = rslt.getShort(25);
                ((short[]) buf[29])[0] = rslt.getShort(26);
                ((int[]) buf[30])[0] = rslt.getInt(27);
                ((int[]) buf[31])[0] = rslt.getInt(28);
                ((bool[]) buf[32])[0] = rslt.wasNull(28);
                ((int[]) buf[33])[0] = rslt.getInt(29);
                ((bool[]) buf[34])[0] = rslt.wasNull(29);
                ((string[]) buf[35])[0] = rslt.getString(30, 100);
                ((int[]) buf[36])[0] = rslt.getInt(31);
                ((string[]) buf[37])[0] = rslt.getString(32, 15);
                ((string[]) buf[38])[0] = rslt.getMultimediaFile(33, rslt.getVarchar(20));
                ((bool[]) buf[39])[0] = rslt.wasNull(33);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
