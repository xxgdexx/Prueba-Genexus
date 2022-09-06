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
namespace GeneXus.Programs.ventas {
   public class clientesww : GXDataArea
   {
      public clientesww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clientesww( IGxContext context )
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
               nRC_GXsfl_110 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_110"), "."));
               nGXsfl_110_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_110_idx"), "."));
               sGXsfl_110_idx = GetPar( "sGXsfl_110_idx");
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
               AV17CliDsc1 = GetPar( "CliDsc1");
               AV18CliVendDsc1 = GetPar( "CliVendDsc1");
               cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
               AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
               cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
               AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."));
               AV22CliDsc2 = GetPar( "CliDsc2");
               AV23CliVendDsc2 = GetPar( "CliVendDsc2");
               cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
               AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
               cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
               AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."));
               AV27CliDsc3 = GetPar( "CliDsc3");
               AV28CliVendDsc3 = GetPar( "CliVendDsc3");
               AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
               AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
               AV92Pgmname = GetPar( "Pgmname");
               AV34TFCliCod = GetPar( "TFCliCod");
               AV35TFCliCod_Sel = GetPar( "TFCliCod_Sel");
               AV36TFCliDsc = GetPar( "TFCliDsc");
               AV37TFCliDsc_Sel = GetPar( "TFCliDsc_Sel");
               AV38TFCliDir = GetPar( "TFCliDir");
               AV39TFCliDir_Sel = GetPar( "TFCliDir_Sel");
               AV40TFEstCod = GetPar( "TFEstCod");
               AV41TFEstCod_Sel = GetPar( "TFEstCod_Sel");
               AV42TFPaiCod = GetPar( "TFPaiCod");
               AV43TFPaiCod_Sel = GetPar( "TFPaiCod_Sel");
               AV44TFCliTel1 = GetPar( "TFCliTel1");
               AV45TFCliTel1_Sel = GetPar( "TFCliTel1_Sel");
               AV46TFCliTel2 = GetPar( "TFCliTel2");
               AV47TFCliTel2_Sel = GetPar( "TFCliTel2_Sel");
               AV48TFCliFax = GetPar( "TFCliFax");
               AV49TFCliFax_Sel = GetPar( "TFCliFax_Sel");
               AV50TFCliCel = GetPar( "TFCliCel");
               AV51TFCliCel_Sel = GetPar( "TFCliCel_Sel");
               AV52TFCliEma = GetPar( "TFCliEma");
               AV53TFCliEma_Sel = GetPar( "TFCliEma_Sel");
               AV54TFCliWeb = GetPar( "TFCliWeb");
               AV55TFCliWeb_Sel = GetPar( "TFCliWeb_Sel");
               AV56TFTipCCod = (int)(NumberUtil.Val( GetPar( "TFTipCCod"), "."));
               AV57TFTipCCod_To = (int)(NumberUtil.Val( GetPar( "TFTipCCod_To"), "."));
               AV58TFCliSts = (short)(NumberUtil.Val( GetPar( "TFCliSts"), "."));
               AV59TFCliSts_To = (short)(NumberUtil.Val( GetPar( "TFCliSts_To"), "."));
               AV60TFConpcod = (int)(NumberUtil.Val( GetPar( "TFConpcod"), "."));
               AV61TFConpcod_To = (int)(NumberUtil.Val( GetPar( "TFConpcod_To"), "."));
               AV62TFCliLim = NumberUtil.Val( GetPar( "TFCliLim"), ".");
               AV63TFCliLim_To = NumberUtil.Val( GetPar( "TFCliLim_To"), ".");
               AV64TFCliVend = (int)(NumberUtil.Val( GetPar( "TFCliVend"), "."));
               AV65TFCliVend_To = (int)(NumberUtil.Val( GetPar( "TFCliVend_To"), "."));
               AV66TFCliVendDsc = GetPar( "TFCliVendDsc");
               AV67TFCliVendDsc_Sel = GetPar( "TFCliVendDsc_Sel");
               AV68TFCliRef1 = GetPar( "TFCliRef1");
               AV69TFCliRef1_Sel = GetPar( "TFCliRef1_Sel");
               AV70TFCliRef2 = GetPar( "TFCliRef2");
               AV71TFCliRef2_Sel = GetPar( "TFCliRef2_Sel");
               AV72TFCliRef3 = GetPar( "TFCliRef3");
               AV73TFCliRef3_Sel = GetPar( "TFCliRef3_Sel");
               AV74TFCliRef4 = GetPar( "TFCliRef4");
               AV75TFCliRef4_Sel = GetPar( "TFCliRef4_Sel");
               AV76TFCliRef5 = GetPar( "TFCliRef5");
               AV77TFCliRef5_Sel = GetPar( "TFCliRef5_Sel");
               AV78TFCliRef6 = GetPar( "TFCliRef6");
               AV79TFCliRef6_Sel = GetPar( "TFCliRef6_Sel");
               AV80TFCliRef7 = GetPar( "TFCliRef7");
               AV81TFCliRef7_Sel = GetPar( "TFCliRef7_Sel");
               AV13OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
               AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
               AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA782( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START782( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810322739", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas.clientesww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16DynamicFiltersOperator1), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIDSC1", StringUtil.RTrim( AV17CliDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIVENDDSC1", StringUtil.RTrim( AV18CliVendDsc1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIDSC2", StringUtil.RTrim( AV22CliDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIVENDDSC2", StringUtil.RTrim( AV23CliVendDsc2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIDSC3", StringUtil.RTrim( AV27CliDsc3));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIVENDDSC3", StringUtil.RTrim( AV28CliVendDsc3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84GridCurrentPage), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85GridPageCount), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV86GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV88AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV88AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV82DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV82DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCLICOD", StringUtil.RTrim( AV34TFCliCod));
         GxWebStd.gx_hidden_field( context, "vTFCLICOD_SEL", StringUtil.RTrim( AV35TFCliCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIDSC", StringUtil.RTrim( AV36TFCliDsc));
         GxWebStd.gx_hidden_field( context, "vTFCLIDSC_SEL", StringUtil.RTrim( AV37TFCliDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIDIR", StringUtil.RTrim( AV38TFCliDir));
         GxWebStd.gx_hidden_field( context, "vTFCLIDIR_SEL", StringUtil.RTrim( AV39TFCliDir_Sel));
         GxWebStd.gx_hidden_field( context, "vTFESTCOD", StringUtil.RTrim( AV40TFEstCod));
         GxWebStd.gx_hidden_field( context, "vTFESTCOD_SEL", StringUtil.RTrim( AV41TFEstCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFPAICOD", StringUtil.RTrim( AV42TFPaiCod));
         GxWebStd.gx_hidden_field( context, "vTFPAICOD_SEL", StringUtil.RTrim( AV43TFPaiCod_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLITEL1", StringUtil.RTrim( AV44TFCliTel1));
         GxWebStd.gx_hidden_field( context, "vTFCLITEL1_SEL", StringUtil.RTrim( AV45TFCliTel1_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLITEL2", StringUtil.RTrim( AV46TFCliTel2));
         GxWebStd.gx_hidden_field( context, "vTFCLITEL2_SEL", StringUtil.RTrim( AV47TFCliTel2_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIFAX", StringUtil.RTrim( AV48TFCliFax));
         GxWebStd.gx_hidden_field( context, "vTFCLIFAX_SEL", StringUtil.RTrim( AV49TFCliFax_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLICEL", StringUtil.RTrim( AV50TFCliCel));
         GxWebStd.gx_hidden_field( context, "vTFCLICEL_SEL", StringUtil.RTrim( AV51TFCliCel_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIEMA", AV52TFCliEma);
         GxWebStd.gx_hidden_field( context, "vTFCLIEMA_SEL", AV53TFCliEma_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIWEB", StringUtil.RTrim( AV54TFCliWeb));
         GxWebStd.gx_hidden_field( context, "vTFCLIWEB_SEL", StringUtil.RTrim( AV55TFCliWeb_Sel));
         GxWebStd.gx_hidden_field( context, "vTFTIPCCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56TFTipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFTIPCCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57TFTipCCod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLISTS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58TFCliSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLISTS_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59TFCliSts_To), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONPCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60TFConpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCONPCOD_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61TFConpcod_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLILIM", StringUtil.LTrim( StringUtil.NToC( AV62TFCliLim, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLILIM_TO", StringUtil.LTrim( StringUtil.NToC( AV63TFCliLim_To, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIVEND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64TFCliVend), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIVEND_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65TFCliVend_To), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIVENDDSC", StringUtil.RTrim( AV66TFCliVendDsc));
         GxWebStd.gx_hidden_field( context, "vTFCLIVENDDSC_SEL", StringUtil.RTrim( AV67TFCliVendDsc_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF1", StringUtil.RTrim( AV68TFCliRef1));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF1_SEL", StringUtil.RTrim( AV69TFCliRef1_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF2", StringUtil.RTrim( AV70TFCliRef2));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF2_SEL", StringUtil.RTrim( AV71TFCliRef2_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF3", StringUtil.RTrim( AV72TFCliRef3));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF3_SEL", StringUtil.RTrim( AV73TFCliRef3_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF4", StringUtil.RTrim( AV74TFCliRef4));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF4_SEL", StringUtil.RTrim( AV75TFCliRef4_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF5", StringUtil.RTrim( AV76TFCliRef5));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF5_SEL", StringUtil.RTrim( AV77TFCliRef5_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF6", StringUtil.RTrim( AV78TFCliRef6));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF6_SEL", StringUtil.RTrim( AV79TFCliRef6_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF7", StringUtil.RTrim( AV80TFCliRef7));
         GxWebStd.gx_hidden_field( context, "vTFCLIREF7_SEL", StringUtil.RTrim( AV81TFCliRef7_Sel));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
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
            WE782( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT782( ) ;
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
         return formatLink("ventas.clientesww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas.ClientesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Clientes" ;
      }

      protected void WB780( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Agregar", bttBtninsert_Jsonclick, 5, "Agregar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Reportes", bttBtnagexport_Jsonclick, 0, "Reportes", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas\\ClientesWW.htm");
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
            wb_table1_25_782( true) ;
         }
         else
         {
            wb_table1_25_782( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_782e( bool wbgen )
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"110\">") ;
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
               context.SendWebValue( "Codigo Cliente") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Razon Social") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Dirección") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Pais") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Telefono 1") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Telefono 2") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fax") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Celular") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "E-Mail") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Pagina Web") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo T. Cliente") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Foto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Situación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Codigo condicion pago") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Limite Credito") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vendedor") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vendedor") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87GridActions), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A45CliCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A161CliDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCliDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A596CliDir));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A140EstCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A139PaiCod));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A629CliTel1));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A630CliTel2));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A611CliFax));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A575CliCel));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A609CliEma);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A637CliWeb));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( A612CliFoto));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A627CliSts), 1, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A613CliLim, 15, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A160CliVend), 6, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A635CliVendDsc));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCliVendDsc_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A618CliRef1));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A619CliRef2));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A620CliRef3));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A621CliRef4));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A622CliRef5));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A623CliRef6));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( A624CliRef7));
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
         if ( wbEnd == 110 )
         {
            wbEnd = 0;
            nRC_GXsfl_110 = (int)(nGXsfl_110_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV84GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV85GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV86GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV88AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 1, "HLP_Ventas\\ClientesWW.htm");
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV82DDO_TitleSettingsIcons);
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
         if ( wbEnd == 110 )
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

      protected void START782( )
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
            Form.Meta.addItem("description", " Clientes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP780( ) ;
      }

      protected void WS782( )
      {
         START782( ) ;
         EVT782( ) ;
      }

      protected void EVT782( )
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
                              E11782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22782 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23782 ();
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
                              nGXsfl_110_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
                              SubsflControlProps_1102( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV87GridActions = (short)(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
                              A45CliCod = cgiGet( edtCliCod_Internalname);
                              A161CliDsc = cgiGet( edtCliDsc_Internalname);
                              A596CliDir = cgiGet( edtCliDir_Internalname);
                              A140EstCod = cgiGet( edtEstCod_Internalname);
                              A139PaiCod = cgiGet( edtPaiCod_Internalname);
                              A629CliTel1 = cgiGet( edtCliTel1_Internalname);
                              A630CliTel2 = cgiGet( edtCliTel2_Internalname);
                              A611CliFax = cgiGet( edtCliFax_Internalname);
                              A575CliCel = cgiGet( edtCliCel_Internalname);
                              A609CliEma = cgiGet( edtCliEma_Internalname);
                              A637CliWeb = cgiGet( edtCliWeb_Internalname);
                              A159TipCCod = (int)(context.localUtil.CToN( cgiGet( edtTipCCod_Internalname), ".", ","));
                              A612CliFoto = cgiGet( edtCliFoto_Internalname);
                              n612CliFoto = false;
                              AssignProp("", false, edtCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), !bGXsfl_110_Refreshing);
                              AssignProp("", false, edtCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
                              A627CliSts = (short)(context.localUtil.CToN( cgiGet( edtCliSts_Internalname), ".", ","));
                              A137Conpcod = (int)(context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ","));
                              A613CliLim = context.localUtil.CToN( cgiGet( edtCliLim_Internalname), ".", ",");
                              A160CliVend = (int)(context.localUtil.CToN( cgiGet( edtCliVend_Internalname), ".", ","));
                              A635CliVendDsc = cgiGet( edtCliVendDsc_Internalname);
                              A618CliRef1 = cgiGet( edtCliRef1_Internalname);
                              A619CliRef2 = cgiGet( edtCliRef2_Internalname);
                              A620CliRef3 = cgiGet( edtCliRef3_Internalname);
                              A621CliRef4 = cgiGet( edtCliRef4_Internalname);
                              A622CliRef5 = cgiGet( edtCliRef5_Internalname);
                              A623CliRef6 = cgiGet( edtCliRef6_Internalname);
                              A624CliRef7 = cgiGet( edtCliRef7_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24782 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25782 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E26782 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27782 ();
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
                                       /* Set Refresh If Clidsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC1"), AV17CliDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clivenddsc1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC1"), AV18CliVendDsc1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clidsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC2"), AV22CliDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clivenddsc2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC2"), AV23CliVendDsc2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clidsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC3"), AV27CliDsc3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clivenddsc3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC3"), AV28CliVendDsc3) != 0 )
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

      protected void WE782( )
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

      protected void PA782( )
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
         SubsflControlProps_1102( ) ;
         while ( nGXsfl_110_idx <= nRC_GXsfl_110 )
         {
            sendrow_1102( ) ;
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV15DynamicFiltersSelector1 ,
                                       short AV16DynamicFiltersOperator1 ,
                                       string AV17CliDsc1 ,
                                       string AV18CliVendDsc1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22CliDsc2 ,
                                       string AV23CliVendDsc2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       string AV27CliDsc3 ,
                                       string AV28CliVendDsc3 ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV92Pgmname ,
                                       string AV34TFCliCod ,
                                       string AV35TFCliCod_Sel ,
                                       string AV36TFCliDsc ,
                                       string AV37TFCliDsc_Sel ,
                                       string AV38TFCliDir ,
                                       string AV39TFCliDir_Sel ,
                                       string AV40TFEstCod ,
                                       string AV41TFEstCod_Sel ,
                                       string AV42TFPaiCod ,
                                       string AV43TFPaiCod_Sel ,
                                       string AV44TFCliTel1 ,
                                       string AV45TFCliTel1_Sel ,
                                       string AV46TFCliTel2 ,
                                       string AV47TFCliTel2_Sel ,
                                       string AV48TFCliFax ,
                                       string AV49TFCliFax_Sel ,
                                       string AV50TFCliCel ,
                                       string AV51TFCliCel_Sel ,
                                       string AV52TFCliEma ,
                                       string AV53TFCliEma_Sel ,
                                       string AV54TFCliWeb ,
                                       string AV55TFCliWeb_Sel ,
                                       int AV56TFTipCCod ,
                                       int AV57TFTipCCod_To ,
                                       short AV58TFCliSts ,
                                       short AV59TFCliSts_To ,
                                       int AV60TFConpcod ,
                                       int AV61TFConpcod_To ,
                                       decimal AV62TFCliLim ,
                                       decimal AV63TFCliLim_To ,
                                       int AV64TFCliVend ,
                                       int AV65TFCliVend_To ,
                                       string AV66TFCliVendDsc ,
                                       string AV67TFCliVendDsc_Sel ,
                                       string AV68TFCliRef1 ,
                                       string AV69TFCliRef1_Sel ,
                                       string AV70TFCliRef2 ,
                                       string AV71TFCliRef2_Sel ,
                                       string AV72TFCliRef3 ,
                                       string AV73TFCliRef3_Sel ,
                                       string AV74TFCliRef4 ,
                                       string AV75TFCliRef4_Sel ,
                                       string AV76TFCliRef5 ,
                                       string AV77TFCliRef5_Sel ,
                                       string AV78TFCliRef6 ,
                                       string AV79TFCliRef6_Sel ,
                                       string AV80TFCliRef7 ,
                                       string AV81TFCliRef7_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E25782 ();
         GRID_nCurrentRecord = 0;
         RF782( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLICOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), context));
         GxWebStd.gx_hidden_field( context, "CLICOD", StringUtil.RTrim( A45CliCod));
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
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF782( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV92Pgmname = "Ventas.ClientesWW";
         context.Gx_err = 0;
      }

      protected void RF782( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E25782 ();
         nGXsfl_110_idx = 1;
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         bGXsfl_110_Refreshing = true;
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
            SubsflControlProps_1102( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV93Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                                 AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                                 AV95Ventas_clienteswwds_3_clidsc1 ,
                                                 AV96Ventas_clienteswwds_4_clivenddsc1 ,
                                                 AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                                 AV98Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                                 AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                                 AV100Ventas_clienteswwds_8_clidsc2 ,
                                                 AV101Ventas_clienteswwds_9_clivenddsc2 ,
                                                 AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                                 AV103Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                                 AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                                 AV105Ventas_clienteswwds_13_clidsc3 ,
                                                 AV106Ventas_clienteswwds_14_clivenddsc3 ,
                                                 AV108Ventas_clienteswwds_16_tfclicod_sel ,
                                                 AV107Ventas_clienteswwds_15_tfclicod ,
                                                 AV110Ventas_clienteswwds_18_tfclidsc_sel ,
                                                 AV109Ventas_clienteswwds_17_tfclidsc ,
                                                 AV112Ventas_clienteswwds_20_tfclidir_sel ,
                                                 AV111Ventas_clienteswwds_19_tfclidir ,
                                                 AV114Ventas_clienteswwds_22_tfestcod_sel ,
                                                 AV113Ventas_clienteswwds_21_tfestcod ,
                                                 AV116Ventas_clienteswwds_24_tfpaicod_sel ,
                                                 AV115Ventas_clienteswwds_23_tfpaicod ,
                                                 AV118Ventas_clienteswwds_26_tfclitel1_sel ,
                                                 AV117Ventas_clienteswwds_25_tfclitel1 ,
                                                 AV120Ventas_clienteswwds_28_tfclitel2_sel ,
                                                 AV119Ventas_clienteswwds_27_tfclitel2 ,
                                                 AV122Ventas_clienteswwds_30_tfclifax_sel ,
                                                 AV121Ventas_clienteswwds_29_tfclifax ,
                                                 AV124Ventas_clienteswwds_32_tfclicel_sel ,
                                                 AV123Ventas_clienteswwds_31_tfclicel ,
                                                 AV126Ventas_clienteswwds_34_tfcliema_sel ,
                                                 AV125Ventas_clienteswwds_33_tfcliema ,
                                                 AV128Ventas_clienteswwds_36_tfcliweb_sel ,
                                                 AV127Ventas_clienteswwds_35_tfcliweb ,
                                                 AV129Ventas_clienteswwds_37_tftipccod ,
                                                 AV130Ventas_clienteswwds_38_tftipccod_to ,
                                                 AV131Ventas_clienteswwds_39_tfclists ,
                                                 AV132Ventas_clienteswwds_40_tfclists_to ,
                                                 AV133Ventas_clienteswwds_41_tfconpcod ,
                                                 AV134Ventas_clienteswwds_42_tfconpcod_to ,
                                                 AV135Ventas_clienteswwds_43_tfclilim ,
                                                 AV136Ventas_clienteswwds_44_tfclilim_to ,
                                                 AV137Ventas_clienteswwds_45_tfclivend ,
                                                 AV138Ventas_clienteswwds_46_tfclivend_to ,
                                                 AV140Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                                 AV139Ventas_clienteswwds_47_tfclivenddsc ,
                                                 AV142Ventas_clienteswwds_50_tfcliref1_sel ,
                                                 AV141Ventas_clienteswwds_49_tfcliref1 ,
                                                 AV144Ventas_clienteswwds_52_tfcliref2_sel ,
                                                 AV143Ventas_clienteswwds_51_tfcliref2 ,
                                                 AV146Ventas_clienteswwds_54_tfcliref3_sel ,
                                                 AV145Ventas_clienteswwds_53_tfcliref3 ,
                                                 AV148Ventas_clienteswwds_56_tfcliref4_sel ,
                                                 AV147Ventas_clienteswwds_55_tfcliref4 ,
                                                 AV150Ventas_clienteswwds_58_tfcliref5_sel ,
                                                 AV149Ventas_clienteswwds_57_tfcliref5 ,
                                                 AV152Ventas_clienteswwds_60_tfcliref6_sel ,
                                                 AV151Ventas_clienteswwds_59_tfcliref6 ,
                                                 AV154Ventas_clienteswwds_62_tfcliref7_sel ,
                                                 AV153Ventas_clienteswwds_61_tfcliref7 ,
                                                 A161CliDsc ,
                                                 A635CliVendDsc ,
                                                 A45CliCod ,
                                                 A596CliDir ,
                                                 A140EstCod ,
                                                 A139PaiCod ,
                                                 A629CliTel1 ,
                                                 A630CliTel2 ,
                                                 A611CliFax ,
                                                 A575CliCel ,
                                                 A609CliEma ,
                                                 A637CliWeb ,
                                                 A159TipCCod ,
                                                 A627CliSts ,
                                                 A137Conpcod ,
                                                 A613CliLim ,
                                                 A160CliVend ,
                                                 A618CliRef1 ,
                                                 A619CliRef2 ,
                                                 A620CliRef3 ,
                                                 A621CliRef4 ,
                                                 A622CliRef5 ,
                                                 A623CliRef6 ,
                                                 A624CliRef7 ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV95Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1), 100, "%");
            lV95Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1), 100, "%");
            lV96Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1), 100, "%");
            lV96Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1), 100, "%");
            lV100Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2), 100, "%");
            lV100Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2), 100, "%");
            lV101Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2), 100, "%");
            lV101Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2), 100, "%");
            lV105Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3), 100, "%");
            lV105Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3), 100, "%");
            lV106Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3), 100, "%");
            lV106Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3), 100, "%");
            lV107Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_15_tfclicod), 20, "%");
            lV109Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV109Ventas_clienteswwds_17_tfclidsc), 100, "%");
            lV111Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV111Ventas_clienteswwds_19_tfclidir), 100, "%");
            lV113Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV113Ventas_clienteswwds_21_tfestcod), 4, "%");
            lV115Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV115Ventas_clienteswwds_23_tfpaicod), 4, "%");
            lV117Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV117Ventas_clienteswwds_25_tfclitel1), 20, "%");
            lV119Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV119Ventas_clienteswwds_27_tfclitel2), 20, "%");
            lV121Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV121Ventas_clienteswwds_29_tfclifax), 20, "%");
            lV123Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV123Ventas_clienteswwds_31_tfclicel), 20, "%");
            lV125Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV125Ventas_clienteswwds_33_tfcliema), "%", "");
            lV127Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV127Ventas_clienteswwds_35_tfcliweb), 50, "%");
            lV139Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV139Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
            lV141Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV141Ventas_clienteswwds_49_tfcliref1), 50, "%");
            lV143Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV143Ventas_clienteswwds_51_tfcliref2), 50, "%");
            lV145Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV145Ventas_clienteswwds_53_tfcliref3), 50, "%");
            lV147Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV147Ventas_clienteswwds_55_tfcliref4), 50, "%");
            lV149Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV149Ventas_clienteswwds_57_tfcliref5), 50, "%");
            lV151Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV151Ventas_clienteswwds_59_tfcliref6), 50, "%");
            lV153Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV153Ventas_clienteswwds_61_tfcliref7), 50, "%");
            /* Using cursor H00782 */
            pr_default.execute(0, new Object[] {lV95Ventas_clienteswwds_3_clidsc1, lV95Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_4_clivenddsc1, lV96Ventas_clienteswwds_4_clivenddsc1, lV100Ventas_clienteswwds_8_clidsc2, lV100Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_9_clivenddsc2, lV101Ventas_clienteswwds_9_clivenddsc2, lV105Ventas_clienteswwds_13_clidsc3, lV105Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_14_clivenddsc3, lV106Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_15_tfclicod, AV108Ventas_clienteswwds_16_tfclicod_sel, lV109Ventas_clienteswwds_17_tfclidsc, AV110Ventas_clienteswwds_18_tfclidsc_sel, lV111Ventas_clienteswwds_19_tfclidir, AV112Ventas_clienteswwds_20_tfclidir_sel, lV113Ventas_clienteswwds_21_tfestcod, AV114Ventas_clienteswwds_22_tfestcod_sel, lV115Ventas_clienteswwds_23_tfpaicod, AV116Ventas_clienteswwds_24_tfpaicod_sel, lV117Ventas_clienteswwds_25_tfclitel1, AV118Ventas_clienteswwds_26_tfclitel1_sel, lV119Ventas_clienteswwds_27_tfclitel2, AV120Ventas_clienteswwds_28_tfclitel2_sel, lV121Ventas_clienteswwds_29_tfclifax, AV122Ventas_clienteswwds_30_tfclifax_sel, lV123Ventas_clienteswwds_31_tfclicel, AV124Ventas_clienteswwds_32_tfclicel_sel, lV125Ventas_clienteswwds_33_tfcliema, AV126Ventas_clienteswwds_34_tfcliema_sel, lV127Ventas_clienteswwds_35_tfcliweb, AV128Ventas_clienteswwds_36_tfcliweb_sel, AV129Ventas_clienteswwds_37_tftipccod, AV130Ventas_clienteswwds_38_tftipccod_to, AV131Ventas_clienteswwds_39_tfclists, AV132Ventas_clienteswwds_40_tfclists_to, AV133Ventas_clienteswwds_41_tfconpcod, AV134Ventas_clienteswwds_42_tfconpcod_to, AV135Ventas_clienteswwds_43_tfclilim, AV136Ventas_clienteswwds_44_tfclilim_to, AV137Ventas_clienteswwds_45_tfclivend, AV138Ventas_clienteswwds_46_tfclivend_to, lV139Ventas_clienteswwds_47_tfclivenddsc, AV140Ventas_clienteswwds_48_tfclivenddsc_sel, lV141Ventas_clienteswwds_49_tfcliref1, AV142Ventas_clienteswwds_50_tfcliref1_sel, lV143Ventas_clienteswwds_51_tfcliref2, AV144Ventas_clienteswwds_52_tfcliref2_sel, lV145Ventas_clienteswwds_53_tfcliref3, AV146Ventas_clienteswwds_54_tfcliref3_sel, lV147Ventas_clienteswwds_55_tfcliref4, AV148Ventas_clienteswwds_56_tfcliref4_sel, lV149Ventas_clienteswwds_57_tfcliref5, AV150Ventas_clienteswwds_58_tfcliref5_sel, lV151Ventas_clienteswwds_59_tfcliref6, AV152Ventas_clienteswwds_60_tfcliref6_sel, lV153Ventas_clienteswwds_61_tfcliref7, AV154Ventas_clienteswwds_62_tfcliref7_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A624CliRef7 = H00782_A624CliRef7[0];
               A623CliRef6 = H00782_A623CliRef6[0];
               A622CliRef5 = H00782_A622CliRef5[0];
               A621CliRef4 = H00782_A621CliRef4[0];
               A620CliRef3 = H00782_A620CliRef3[0];
               A619CliRef2 = H00782_A619CliRef2[0];
               A618CliRef1 = H00782_A618CliRef1[0];
               A635CliVendDsc = H00782_A635CliVendDsc[0];
               A160CliVend = H00782_A160CliVend[0];
               A613CliLim = H00782_A613CliLim[0];
               A137Conpcod = H00782_A137Conpcod[0];
               A627CliSts = H00782_A627CliSts[0];
               A40000CliFoto_GXI = H00782_A40000CliFoto_GXI[0];
               n40000CliFoto_GXI = H00782_n40000CliFoto_GXI[0];
               AssignProp("", false, edtCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), !bGXsfl_110_Refreshing);
               AssignProp("", false, edtCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
               A159TipCCod = H00782_A159TipCCod[0];
               A637CliWeb = H00782_A637CliWeb[0];
               A609CliEma = H00782_A609CliEma[0];
               A575CliCel = H00782_A575CliCel[0];
               A611CliFax = H00782_A611CliFax[0];
               A630CliTel2 = H00782_A630CliTel2[0];
               A629CliTel1 = H00782_A629CliTel1[0];
               A139PaiCod = H00782_A139PaiCod[0];
               A140EstCod = H00782_A140EstCod[0];
               A596CliDir = H00782_A596CliDir[0];
               A161CliDsc = H00782_A161CliDsc[0];
               A45CliCod = H00782_A45CliCod[0];
               A612CliFoto = H00782_A612CliFoto[0];
               n612CliFoto = H00782_n612CliFoto[0];
               AssignProp("", false, edtCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), !bGXsfl_110_Refreshing);
               AssignProp("", false, edtCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
               A635CliVendDsc = H00782_A635CliVendDsc[0];
               E26782 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB780( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes782( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV92Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV92Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLICOD"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), context));
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
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV93Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV95Ventas_clienteswwds_3_clidsc1 ,
                                              AV96Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV98Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV100Ventas_clienteswwds_8_clidsc2 ,
                                              AV101Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV103Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV105Ventas_clienteswwds_13_clidsc3 ,
                                              AV106Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV108Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV107Ventas_clienteswwds_15_tfclicod ,
                                              AV110Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV109Ventas_clienteswwds_17_tfclidsc ,
                                              AV112Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV111Ventas_clienteswwds_19_tfclidir ,
                                              AV114Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV113Ventas_clienteswwds_21_tfestcod ,
                                              AV116Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV115Ventas_clienteswwds_23_tfpaicod ,
                                              AV118Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV117Ventas_clienteswwds_25_tfclitel1 ,
                                              AV120Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV119Ventas_clienteswwds_27_tfclitel2 ,
                                              AV122Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV121Ventas_clienteswwds_29_tfclifax ,
                                              AV124Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV123Ventas_clienteswwds_31_tfclicel ,
                                              AV126Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV125Ventas_clienteswwds_33_tfcliema ,
                                              AV128Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV127Ventas_clienteswwds_35_tfcliweb ,
                                              AV129Ventas_clienteswwds_37_tftipccod ,
                                              AV130Ventas_clienteswwds_38_tftipccod_to ,
                                              AV131Ventas_clienteswwds_39_tfclists ,
                                              AV132Ventas_clienteswwds_40_tfclists_to ,
                                              AV133Ventas_clienteswwds_41_tfconpcod ,
                                              AV134Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV135Ventas_clienteswwds_43_tfclilim ,
                                              AV136Ventas_clienteswwds_44_tfclilim_to ,
                                              AV137Ventas_clienteswwds_45_tfclivend ,
                                              AV138Ventas_clienteswwds_46_tfclivend_to ,
                                              AV140Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV139Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV142Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV141Ventas_clienteswwds_49_tfcliref1 ,
                                              AV144Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV143Ventas_clienteswwds_51_tfcliref2 ,
                                              AV146Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV145Ventas_clienteswwds_53_tfcliref3 ,
                                              AV148Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV147Ventas_clienteswwds_55_tfcliref4 ,
                                              AV150Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV149Ventas_clienteswwds_57_tfcliref5 ,
                                              AV152Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV151Ventas_clienteswwds_59_tfcliref6 ,
                                              AV154Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV153Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV95Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV95Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV96Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV100Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV100Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV101Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV105Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV105Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV106Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV109Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV109Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV111Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV111Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV113Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV113Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV115Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV115Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV117Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV117Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV119Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV119Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV121Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV121Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV123Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV123Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV125Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV125Ventas_clienteswwds_33_tfcliema), "%", "");
         lV127Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV127Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV139Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV139Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV141Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV141Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV143Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV143Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV145Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV145Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV147Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV147Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV149Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV149Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV151Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV151Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV153Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV153Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor H00783 */
         pr_default.execute(1, new Object[] {lV95Ventas_clienteswwds_3_clidsc1, lV95Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_4_clivenddsc1, lV96Ventas_clienteswwds_4_clivenddsc1, lV100Ventas_clienteswwds_8_clidsc2, lV100Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_9_clivenddsc2, lV101Ventas_clienteswwds_9_clivenddsc2, lV105Ventas_clienteswwds_13_clidsc3, lV105Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_14_clivenddsc3, lV106Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_15_tfclicod, AV108Ventas_clienteswwds_16_tfclicod_sel, lV109Ventas_clienteswwds_17_tfclidsc, AV110Ventas_clienteswwds_18_tfclidsc_sel, lV111Ventas_clienteswwds_19_tfclidir, AV112Ventas_clienteswwds_20_tfclidir_sel, lV113Ventas_clienteswwds_21_tfestcod, AV114Ventas_clienteswwds_22_tfestcod_sel, lV115Ventas_clienteswwds_23_tfpaicod, AV116Ventas_clienteswwds_24_tfpaicod_sel, lV117Ventas_clienteswwds_25_tfclitel1, AV118Ventas_clienteswwds_26_tfclitel1_sel, lV119Ventas_clienteswwds_27_tfclitel2, AV120Ventas_clienteswwds_28_tfclitel2_sel, lV121Ventas_clienteswwds_29_tfclifax, AV122Ventas_clienteswwds_30_tfclifax_sel, lV123Ventas_clienteswwds_31_tfclicel, AV124Ventas_clienteswwds_32_tfclicel_sel, lV125Ventas_clienteswwds_33_tfcliema, AV126Ventas_clienteswwds_34_tfcliema_sel, lV127Ventas_clienteswwds_35_tfcliweb, AV128Ventas_clienteswwds_36_tfcliweb_sel, AV129Ventas_clienteswwds_37_tftipccod, AV130Ventas_clienteswwds_38_tftipccod_to, AV131Ventas_clienteswwds_39_tfclists, AV132Ventas_clienteswwds_40_tfclists_to, AV133Ventas_clienteswwds_41_tfconpcod, AV134Ventas_clienteswwds_42_tfconpcod_to, AV135Ventas_clienteswwds_43_tfclilim, AV136Ventas_clienteswwds_44_tfclilim_to, AV137Ventas_clienteswwds_45_tfclivend, AV138Ventas_clienteswwds_46_tfclivend_to, lV139Ventas_clienteswwds_47_tfclivenddsc, AV140Ventas_clienteswwds_48_tfclivenddsc_sel, lV141Ventas_clienteswwds_49_tfcliref1, AV142Ventas_clienteswwds_50_tfcliref1_sel, lV143Ventas_clienteswwds_51_tfcliref2, AV144Ventas_clienteswwds_52_tfcliref2_sel, lV145Ventas_clienteswwds_53_tfcliref3, AV146Ventas_clienteswwds_54_tfcliref3_sel, lV147Ventas_clienteswwds_55_tfcliref4, AV148Ventas_clienteswwds_56_tfcliref4_sel, lV149Ventas_clienteswwds_57_tfcliref5, AV150Ventas_clienteswwds_58_tfcliref5_sel, lV151Ventas_clienteswwds_59_tfcliref6, AV152Ventas_clienteswwds_60_tfcliref6_sel, lV153Ventas_clienteswwds_61_tfcliref7, AV154Ventas_clienteswwds_62_tfcliref7_sel});
         GRID_nRecordCount = H00783_AGRID_nRecordCount[0];
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
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV92Pgmname = "Ventas.ClientesWW";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP780( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24782 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV88AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV82DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ".", ","));
            AV84GridCurrentPage = (long)(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ".", ","));
            AV85GridPageCount = (long)(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ".", ","));
            AV86GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV17CliDsc1 = cgiGet( edtavClidsc1_Internalname);
            AssignAttri("", false, "AV17CliDsc1", AV17CliDsc1);
            AV18CliVendDsc1 = cgiGet( edtavClivenddsc1_Internalname);
            AssignAttri("", false, "AV18CliVendDsc1", AV18CliVendDsc1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22CliDsc2 = cgiGet( edtavClidsc2_Internalname);
            AssignAttri("", false, "AV22CliDsc2", AV22CliDsc2);
            AV23CliVendDsc2 = cgiGet( edtavClivenddsc2_Internalname);
            AssignAttri("", false, "AV23CliVendDsc2", AV23CliVendDsc2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AV27CliDsc3 = cgiGet( edtavClidsc3_Internalname);
            AssignAttri("", false, "AV27CliDsc3", AV27CliDsc3);
            AV28CliVendDsc3 = cgiGet( edtavClivenddsc3_Internalname);
            AssignAttri("", false, "AV28CliVendDsc3", AV28CliVendDsc3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC1"), AV17CliDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC1"), AV18CliVendDsc1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ".", ",") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC2"), AV22CliDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC2"), AV23CliVendDsc2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ".", ",") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIDSC3"), AV27CliDsc3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIVENDDSC3"), AV28CliVendDsc3) != 0 )
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
         E24782 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24782( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV15DynamicFiltersSelector1 = "CLIDSC";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "CLIDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "CLIDSC";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
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
         AV88AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV89AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV89AGExportDataItem.gxTpr_Title = "PDF";
         AV89AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV89AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV89AGExportDataItem.gxTpr_Isdivider = false;
         AV88AGExportData.Add(AV89AGExportDataItem, 0);
         AV89AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV89AGExportDataItem.gxTpr_Title = "Excel";
         AV89AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV89AGExportDataItem.gxTpr_Eventkey = "Export";
         AV89AGExportDataItem.gxTpr_Isdivider = false;
         AV88AGExportData.Add(AV89AGExportDataItem, 0);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Clientes";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV82DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV82DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25782( )
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
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Comienza con", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contiene", 0);
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
            }
            if ( AV24DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIDSC") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
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
         AV84GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV84GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV84GridCurrentPage), 10, 0));
         AV85GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV85GridPageCount", StringUtil.LTrimStr( (decimal)(AV85GridPageCount), 10, 0));
         GXt_char2 = AV86GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV92Pgmname, out  GXt_char2) ;
         AV86GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV86GridAppliedFilters", AV86GridAppliedFilters);
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV16DynamicFiltersOperator1;
         AV95Ventas_clienteswwds_3_clidsc1 = AV17CliDsc1;
         AV96Ventas_clienteswwds_4_clivenddsc1 = AV18CliVendDsc1;
         AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV100Ventas_clienteswwds_8_clidsc2 = AV22CliDsc2;
         AV101Ventas_clienteswwds_9_clivenddsc2 = AV23CliVendDsc2;
         AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV105Ventas_clienteswwds_13_clidsc3 = AV27CliDsc3;
         AV106Ventas_clienteswwds_14_clivenddsc3 = AV28CliVendDsc3;
         AV107Ventas_clienteswwds_15_tfclicod = AV34TFCliCod;
         AV108Ventas_clienteswwds_16_tfclicod_sel = AV35TFCliCod_Sel;
         AV109Ventas_clienteswwds_17_tfclidsc = AV36TFCliDsc;
         AV110Ventas_clienteswwds_18_tfclidsc_sel = AV37TFCliDsc_Sel;
         AV111Ventas_clienteswwds_19_tfclidir = AV38TFCliDir;
         AV112Ventas_clienteswwds_20_tfclidir_sel = AV39TFCliDir_Sel;
         AV113Ventas_clienteswwds_21_tfestcod = AV40TFEstCod;
         AV114Ventas_clienteswwds_22_tfestcod_sel = AV41TFEstCod_Sel;
         AV115Ventas_clienteswwds_23_tfpaicod = AV42TFPaiCod;
         AV116Ventas_clienteswwds_24_tfpaicod_sel = AV43TFPaiCod_Sel;
         AV117Ventas_clienteswwds_25_tfclitel1 = AV44TFCliTel1;
         AV118Ventas_clienteswwds_26_tfclitel1_sel = AV45TFCliTel1_Sel;
         AV119Ventas_clienteswwds_27_tfclitel2 = AV46TFCliTel2;
         AV120Ventas_clienteswwds_28_tfclitel2_sel = AV47TFCliTel2_Sel;
         AV121Ventas_clienteswwds_29_tfclifax = AV48TFCliFax;
         AV122Ventas_clienteswwds_30_tfclifax_sel = AV49TFCliFax_Sel;
         AV123Ventas_clienteswwds_31_tfclicel = AV50TFCliCel;
         AV124Ventas_clienteswwds_32_tfclicel_sel = AV51TFCliCel_Sel;
         AV125Ventas_clienteswwds_33_tfcliema = AV52TFCliEma;
         AV126Ventas_clienteswwds_34_tfcliema_sel = AV53TFCliEma_Sel;
         AV127Ventas_clienteswwds_35_tfcliweb = AV54TFCliWeb;
         AV128Ventas_clienteswwds_36_tfcliweb_sel = AV55TFCliWeb_Sel;
         AV129Ventas_clienteswwds_37_tftipccod = AV56TFTipCCod;
         AV130Ventas_clienteswwds_38_tftipccod_to = AV57TFTipCCod_To;
         AV131Ventas_clienteswwds_39_tfclists = AV58TFCliSts;
         AV132Ventas_clienteswwds_40_tfclists_to = AV59TFCliSts_To;
         AV133Ventas_clienteswwds_41_tfconpcod = AV60TFConpcod;
         AV134Ventas_clienteswwds_42_tfconpcod_to = AV61TFConpcod_To;
         AV135Ventas_clienteswwds_43_tfclilim = AV62TFCliLim;
         AV136Ventas_clienteswwds_44_tfclilim_to = AV63TFCliLim_To;
         AV137Ventas_clienteswwds_45_tfclivend = AV64TFCliVend;
         AV138Ventas_clienteswwds_46_tfclivend_to = AV65TFCliVend_To;
         AV139Ventas_clienteswwds_47_tfclivenddsc = AV66TFCliVendDsc;
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = AV67TFCliVendDsc_Sel;
         AV141Ventas_clienteswwds_49_tfcliref1 = AV68TFCliRef1;
         AV142Ventas_clienteswwds_50_tfcliref1_sel = AV69TFCliRef1_Sel;
         AV143Ventas_clienteswwds_51_tfcliref2 = AV70TFCliRef2;
         AV144Ventas_clienteswwds_52_tfcliref2_sel = AV71TFCliRef2_Sel;
         AV145Ventas_clienteswwds_53_tfcliref3 = AV72TFCliRef3;
         AV146Ventas_clienteswwds_54_tfcliref3_sel = AV73TFCliRef3_Sel;
         AV147Ventas_clienteswwds_55_tfcliref4 = AV74TFCliRef4;
         AV148Ventas_clienteswwds_56_tfcliref4_sel = AV75TFCliRef4_Sel;
         AV149Ventas_clienteswwds_57_tfcliref5 = AV76TFCliRef5;
         AV150Ventas_clienteswwds_58_tfcliref5_sel = AV77TFCliRef5_Sel;
         AV151Ventas_clienteswwds_59_tfcliref6 = AV78TFCliRef6;
         AV152Ventas_clienteswwds_60_tfcliref6_sel = AV79TFCliRef6_Sel;
         AV153Ventas_clienteswwds_61_tfcliref7 = AV80TFCliRef7;
         AV154Ventas_clienteswwds_62_tfcliref7_sel = AV81TFCliRef7_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E11782( )
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
            AV83PageToGo = (int)(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."));
            subgrid_gotopage( AV83PageToGo) ;
         }
      }

      protected void E12782( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14782( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliCod") == 0 )
            {
               AV34TFCliCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFCliCod", AV34TFCliCod);
               AV35TFCliCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFCliCod_Sel", AV35TFCliCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliDsc") == 0 )
            {
               AV36TFCliDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFCliDsc", AV36TFCliDsc);
               AV37TFCliDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFCliDsc_Sel", AV37TFCliDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliDir") == 0 )
            {
               AV38TFCliDir = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFCliDir", AV38TFCliDir);
               AV39TFCliDir_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFCliDir_Sel", AV39TFCliDir_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "EstCod") == 0 )
            {
               AV40TFEstCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFEstCod", AV40TFEstCod);
               AV41TFEstCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFEstCod_Sel", AV41TFEstCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PaiCod") == 0 )
            {
               AV42TFPaiCod = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFPaiCod", AV42TFPaiCod);
               AV43TFPaiCod_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFPaiCod_Sel", AV43TFPaiCod_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliTel1") == 0 )
            {
               AV44TFCliTel1 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFCliTel1", AV44TFCliTel1);
               AV45TFCliTel1_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFCliTel1_Sel", AV45TFCliTel1_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliTel2") == 0 )
            {
               AV46TFCliTel2 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFCliTel2", AV46TFCliTel2);
               AV47TFCliTel2_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFCliTel2_Sel", AV47TFCliTel2_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliFax") == 0 )
            {
               AV48TFCliFax = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFCliFax", AV48TFCliFax);
               AV49TFCliFax_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFCliFax_Sel", AV49TFCliFax_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliCel") == 0 )
            {
               AV50TFCliCel = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFCliCel", AV50TFCliCel);
               AV51TFCliCel_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFCliCel_Sel", AV51TFCliCel_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliEma") == 0 )
            {
               AV52TFCliEma = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFCliEma", AV52TFCliEma);
               AV53TFCliEma_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFCliEma_Sel", AV53TFCliEma_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliWeb") == 0 )
            {
               AV54TFCliWeb = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFCliWeb", AV54TFCliWeb);
               AV55TFCliWeb_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFCliWeb_Sel", AV55TFCliWeb_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipCCod") == 0 )
            {
               AV56TFTipCCod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV56TFTipCCod", StringUtil.LTrimStr( (decimal)(AV56TFTipCCod), 6, 0));
               AV57TFTipCCod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV57TFTipCCod_To", StringUtil.LTrimStr( (decimal)(AV57TFTipCCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliSts") == 0 )
            {
               AV58TFCliSts = (short)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV58TFCliSts", StringUtil.Str( (decimal)(AV58TFCliSts), 1, 0));
               AV59TFCliSts_To = (short)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV59TFCliSts_To", StringUtil.Str( (decimal)(AV59TFCliSts_To), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "Conpcod") == 0 )
            {
               AV60TFConpcod = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV60TFConpcod", StringUtil.LTrimStr( (decimal)(AV60TFConpcod), 6, 0));
               AV61TFConpcod_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV61TFConpcod_To", StringUtil.LTrimStr( (decimal)(AV61TFConpcod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliLim") == 0 )
            {
               AV62TFCliLim = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV62TFCliLim", StringUtil.LTrimStr( AV62TFCliLim, 15, 2));
               AV63TFCliLim_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV63TFCliLim_To", StringUtil.LTrimStr( AV63TFCliLim_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliVend") == 0 )
            {
               AV64TFCliVend = (int)(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."));
               AssignAttri("", false, "AV64TFCliVend", StringUtil.LTrimStr( (decimal)(AV64TFCliVend), 6, 0));
               AV65TFCliVend_To = (int)(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."));
               AssignAttri("", false, "AV65TFCliVend_To", StringUtil.LTrimStr( (decimal)(AV65TFCliVend_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliVendDsc") == 0 )
            {
               AV66TFCliVendDsc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV66TFCliVendDsc", AV66TFCliVendDsc);
               AV67TFCliVendDsc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV67TFCliVendDsc_Sel", AV67TFCliVendDsc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef1") == 0 )
            {
               AV68TFCliRef1 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV68TFCliRef1", AV68TFCliRef1);
               AV69TFCliRef1_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV69TFCliRef1_Sel", AV69TFCliRef1_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef2") == 0 )
            {
               AV70TFCliRef2 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV70TFCliRef2", AV70TFCliRef2);
               AV71TFCliRef2_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV71TFCliRef2_Sel", AV71TFCliRef2_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef3") == 0 )
            {
               AV72TFCliRef3 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV72TFCliRef3", AV72TFCliRef3);
               AV73TFCliRef3_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV73TFCliRef3_Sel", AV73TFCliRef3_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef4") == 0 )
            {
               AV74TFCliRef4 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFCliRef4", AV74TFCliRef4);
               AV75TFCliRef4_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFCliRef4_Sel", AV75TFCliRef4_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef5") == 0 )
            {
               AV76TFCliRef5 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV76TFCliRef5", AV76TFCliRef5);
               AV77TFCliRef5_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV77TFCliRef5_Sel", AV77TFCliRef5_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef6") == 0 )
            {
               AV78TFCliRef6 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV78TFCliRef6", AV78TFCliRef6);
               AV79TFCliRef6_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV79TFCliRef6_Sel", AV79TFCliRef6_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliRef7") == 0 )
            {
               AV80TFCliRef7 = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV80TFCliRef7", AV80TFCliRef7);
               AV81TFCliRef7_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV81TFCliRef7_Sel", AV81TFCliRef7_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E26782( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Modificar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Eliminar", "fa fa-times", "", "", "", "", "", "", ""), 0);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A45CliCod));
         edtCliDsc_Link = formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "configuracion.vendedores.aspx"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A160CliVend,6,0));
         edtCliVendDsc_Link = formatLink("configuracion.vendedores.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 110;
         }
         sendrow_1102( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_110_Refreshing )
         {
            DoAjaxLoad(110, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
      }

      protected void E19782( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E15782( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E20782( )
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

      protected void E21782( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E16782( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E22782( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E17782( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV15DynamicFiltersSelector1, AV16DynamicFiltersOperator1, AV17CliDsc1, AV18CliVendDsc1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CliDsc2, AV23CliVendDsc2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27CliDsc3, AV28CliVendDsc3, AV19DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV92Pgmname, AV34TFCliCod, AV35TFCliCod_Sel, AV36TFCliDsc, AV37TFCliDsc_Sel, AV38TFCliDir, AV39TFCliDir_Sel, AV40TFEstCod, AV41TFEstCod_Sel, AV42TFPaiCod, AV43TFPaiCod_Sel, AV44TFCliTel1, AV45TFCliTel1_Sel, AV46TFCliTel2, AV47TFCliTel2_Sel, AV48TFCliFax, AV49TFCliFax_Sel, AV50TFCliCel, AV51TFCliCel_Sel, AV52TFCliEma, AV53TFCliEma_Sel, AV54TFCliWeb, AV55TFCliWeb_Sel, AV56TFTipCCod, AV57TFTipCCod_To, AV58TFCliSts, AV59TFCliSts_To, AV60TFConpcod, AV61TFConpcod_To, AV62TFCliLim, AV63TFCliLim_To, AV64TFCliVend, AV65TFCliVend_To, AV66TFCliVendDsc, AV67TFCliVendDsc_Sel, AV68TFCliRef1, AV69TFCliRef1_Sel, AV70TFCliRef2, AV71TFCliRef2_Sel, AV72TFCliRef3, AV73TFCliRef3_Sel, AV74TFCliRef4, AV75TFCliRef4_Sel, AV76TFCliRef5, AV77TFCliRef5_Sel, AV78TFCliRef6, AV79TFCliRef6_Sel, AV80TFCliRef7, AV81TFCliRef7_Sel, AV13OrderedBy, AV14OrderedDsc, AV10GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E23782( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E27782( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV87GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV87GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV87GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E18782( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E13782( )
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
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
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
         edtavClidsc1_Visible = 0;
         AssignProp("", false, edtavClidsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc1_Visible), 5, 0), true);
         edtavClivenddsc1_Visible = 0;
         AssignProp("", false, edtavClivenddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIDSC") == 0 )
         {
            edtavClidsc1_Visible = 1;
            AssignProp("", false, edtavClidsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
         {
            edtavClivenddsc1_Visible = 1;
            AssignProp("", false, edtavClivenddsc1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavClidsc2_Visible = 0;
         AssignProp("", false, edtavClidsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc2_Visible), 5, 0), true);
         edtavClivenddsc2_Visible = 0;
         AssignProp("", false, edtavClivenddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIDSC") == 0 )
         {
            edtavClidsc2_Visible = 1;
            AssignProp("", false, edtavClidsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
         {
            edtavClivenddsc2_Visible = 1;
            AssignProp("", false, edtavClivenddsc2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavClidsc3_Visible = 0;
         AssignProp("", false, edtavClidsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc3_Visible), 5, 0), true);
         edtavClivenddsc3_Visible = 0;
         AssignProp("", false, edtavClivenddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIDSC") == 0 )
         {
            edtavClidsc3_Visible = 1;
            AssignProp("", false, edtavClidsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClidsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
         {
            edtavClivenddsc3_Visible = 1;
            AssignProp("", false, edtavClivenddsc3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClivenddsc3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S192( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "CLIDSC";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22CliDsc2 = "";
         AssignAttri("", false, "AV22CliDsc2", AV22CliDsc2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "CLIDSC";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV27CliDsc3 = "";
         AssignAttri("", false, "AV27CliDsc3", AV27CliDsc3);
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
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A45CliCod));
         CallWebObject(formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "ventas.clientes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A45CliCod));
         CallWebObject(formatLink("ventas.clientes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S152( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get(AV92Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV92Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV33Session.Get(AV92Pgmname+"GridState"), null, "", "");
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
         AV155GXV1 = 1;
         while ( AV155GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV155GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV34TFCliCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFCliCod", AV34TFCliCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV35TFCliCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFCliCod_Sel", AV35TFCliCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIDSC") == 0 )
            {
               AV36TFCliDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFCliDsc", AV36TFCliDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIDSC_SEL") == 0 )
            {
               AV37TFCliDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCliDsc_Sel", AV37TFCliDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIDIR") == 0 )
            {
               AV38TFCliDir = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCliDir", AV38TFCliDir);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIDIR_SEL") == 0 )
            {
               AV39TFCliDir_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFCliDir_Sel", AV39TFCliDir_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV40TFEstCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFEstCod", AV40TFEstCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV41TFEstCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFEstCod_Sel", AV41TFEstCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV42TFPaiCod = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFPaiCod", AV42TFPaiCod);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV43TFPaiCod_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFPaiCod_Sel", AV43TFPaiCod_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLITEL1") == 0 )
            {
               AV44TFCliTel1 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFCliTel1", AV44TFCliTel1);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLITEL1_SEL") == 0 )
            {
               AV45TFCliTel1_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFCliTel1_Sel", AV45TFCliTel1_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLITEL2") == 0 )
            {
               AV46TFCliTel2 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFCliTel2", AV46TFCliTel2);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLITEL2_SEL") == 0 )
            {
               AV47TFCliTel2_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFCliTel2_Sel", AV47TFCliTel2_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIFAX") == 0 )
            {
               AV48TFCliFax = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFCliFax", AV48TFCliFax);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIFAX_SEL") == 0 )
            {
               AV49TFCliFax_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFCliFax_Sel", AV49TFCliFax_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICEL") == 0 )
            {
               AV50TFCliCel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFCliCel", AV50TFCliCel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLICEL_SEL") == 0 )
            {
               AV51TFCliCel_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFCliCel_Sel", AV51TFCliCel_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIEMA") == 0 )
            {
               AV52TFCliEma = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFCliEma", AV52TFCliEma);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIEMA_SEL") == 0 )
            {
               AV53TFCliEma_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFCliEma_Sel", AV53TFCliEma_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIWEB") == 0 )
            {
               AV54TFCliWeb = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFCliWeb", AV54TFCliWeb);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIWEB_SEL") == 0 )
            {
               AV55TFCliWeb_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFCliWeb_Sel", AV55TFCliWeb_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV56TFTipCCod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV56TFTipCCod", StringUtil.LTrimStr( (decimal)(AV56TFTipCCod), 6, 0));
               AV57TFTipCCod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV57TFTipCCod_To", StringUtil.LTrimStr( (decimal)(AV57TFTipCCod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLISTS") == 0 )
            {
               AV58TFCliSts = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV58TFCliSts", StringUtil.Str( (decimal)(AV58TFCliSts), 1, 0));
               AV59TFCliSts_To = (short)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV59TFCliSts_To", StringUtil.Str( (decimal)(AV59TFCliSts_To), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV60TFConpcod = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV60TFConpcod", StringUtil.LTrimStr( (decimal)(AV60TFConpcod), 6, 0));
               AV61TFConpcod_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV61TFConpcod_To", StringUtil.LTrimStr( (decimal)(AV61TFConpcod_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLILIM") == 0 )
            {
               AV62TFCliLim = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV62TFCliLim", StringUtil.LTrimStr( AV62TFCliLim, 15, 2));
               AV63TFCliLim_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV63TFCliLim_To", StringUtil.LTrimStr( AV63TFCliLim_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIVEND") == 0 )
            {
               AV64TFCliVend = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri("", false, "AV64TFCliVend", StringUtil.LTrimStr( (decimal)(AV64TFCliVend), 6, 0));
               AV65TFCliVend_To = (int)(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."));
               AssignAttri("", false, "AV65TFCliVend_To", StringUtil.LTrimStr( (decimal)(AV65TFCliVend_To), 6, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC") == 0 )
            {
               AV66TFCliVendDsc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFCliVendDsc", AV66TFCliVendDsc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC_SEL") == 0 )
            {
               AV67TFCliVendDsc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFCliVendDsc_Sel", AV67TFCliVendDsc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF1") == 0 )
            {
               AV68TFCliRef1 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFCliRef1", AV68TFCliRef1);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF1_SEL") == 0 )
            {
               AV69TFCliRef1_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFCliRef1_Sel", AV69TFCliRef1_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF2") == 0 )
            {
               AV70TFCliRef2 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFCliRef2", AV70TFCliRef2);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF2_SEL") == 0 )
            {
               AV71TFCliRef2_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFCliRef2_Sel", AV71TFCliRef2_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF3") == 0 )
            {
               AV72TFCliRef3 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFCliRef3", AV72TFCliRef3);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF3_SEL") == 0 )
            {
               AV73TFCliRef3_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFCliRef3_Sel", AV73TFCliRef3_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF4") == 0 )
            {
               AV74TFCliRef4 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFCliRef4", AV74TFCliRef4);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF4_SEL") == 0 )
            {
               AV75TFCliRef4_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFCliRef4_Sel", AV75TFCliRef4_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF5") == 0 )
            {
               AV76TFCliRef5 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFCliRef5", AV76TFCliRef5);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF5_SEL") == 0 )
            {
               AV77TFCliRef5_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV77TFCliRef5_Sel", AV77TFCliRef5_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF6") == 0 )
            {
               AV78TFCliRef6 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFCliRef6", AV78TFCliRef6);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF6_SEL") == 0 )
            {
               AV79TFCliRef6_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFCliRef6_Sel", AV79TFCliRef6_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF7") == 0 )
            {
               AV80TFCliRef7 = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFCliRef7", AV80TFCliRef7);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIREF7_SEL") == 0 )
            {
               AV81TFCliRef7_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFCliRef7_Sel", AV81TFCliRef7_Sel);
            }
            AV155GXV1 = (int)(AV155GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCliCod_Sel)),  AV35TFCliCod_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCliDsc_Sel)),  AV37TFCliDsc_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCliDir_Sel)),  AV39TFCliDir_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEstCod_Sel)),  AV41TFEstCod_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPaiCod_Sel)),  AV43TFPaiCod_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCliTel1_Sel)),  AV45TFCliTel1_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliTel2_Sel)),  AV47TFCliTel2_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCliFax_Sel)),  AV49TFCliFax_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCliCel_Sel)),  AV51TFCliCel_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCliEma_Sel)),  AV53TFCliEma_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCliWeb_Sel)),  AV55TFCliWeb_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliVendDsc_Sel)),  AV67TFCliVendDsc_Sel, out  GXt_char13) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliRef1_Sel)),  AV69TFCliRef1_Sel, out  GXt_char14) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCliRef2_Sel)),  AV71TFCliRef2_Sel, out  GXt_char15) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCliRef3_Sel)),  AV73TFCliRef3_Sel, out  GXt_char16) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCliRef4_Sel)),  AV75TFCliRef4_Sel, out  GXt_char17) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCliRef5_Sel)),  AV77TFCliRef5_Sel, out  GXt_char18) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliRef6_Sel)),  AV79TFCliRef6_Sel, out  GXt_char19) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCliRef7_Sel)),  AV81TFCliRef7_Sel, out  GXt_char20) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"||||||"+GXt_char13+"|"+GXt_char14+"|"+GXt_char15+"|"+GXt_char16+"|"+GXt_char17+"|"+GXt_char18+"|"+GXt_char19+"|"+GXt_char20;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCliCod)),  AV34TFCliCod, out  GXt_char20) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCliDsc)),  AV36TFCliDsc, out  GXt_char19) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCliDir)),  AV38TFCliDir, out  GXt_char18) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEstCod)),  AV40TFEstCod, out  GXt_char17) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPaiCod)),  AV42TFPaiCod, out  GXt_char16) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCliTel1)),  AV44TFCliTel1, out  GXt_char15) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCliTel2)),  AV46TFCliTel2, out  GXt_char14) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliFax)),  AV48TFCliFax, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCliCel)),  AV50TFCliCel, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCliEma)),  AV52TFCliEma, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCliWeb)),  AV54TFCliWeb, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliVendDsc)),  AV66TFCliVendDsc, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliRef1)),  AV68TFCliRef1, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliRef2)),  AV70TFCliRef2, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCliRef3)),  AV72TFCliRef3, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCliRef4)),  AV74TFCliRef4, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCliRef5)),  AV76TFCliRef5, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCliRef6)),  AV78TFCliRef6, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliRef7)),  AV80TFCliRef7, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char20+"|"+GXt_char19+"|"+GXt_char18+"|"+GXt_char17+"|"+GXt_char16+"|"+GXt_char15+"|"+GXt_char14+"|"+GXt_char13+"|"+GXt_char12+"|"+GXt_char11+"|"+GXt_char10+"|"+((0==AV56TFTipCCod) ? "" : StringUtil.Str( (decimal)(AV56TFTipCCod), 6, 0))+"|"+((0==AV58TFCliSts) ? "" : StringUtil.Str( (decimal)(AV58TFCliSts), 1, 0))+"|"+((0==AV60TFConpcod) ? "" : StringUtil.Str( (decimal)(AV60TFConpcod), 6, 0))+"|"+((Convert.ToDecimal(0)==AV62TFCliLim) ? "" : StringUtil.Str( AV62TFCliLim, 15, 2))+"|"+((0==AV64TFCliVend) ? "" : StringUtil.Str( (decimal)(AV64TFCliVend), 6, 0))+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||||||||"+((0==AV57TFTipCCod_To) ? "" : StringUtil.Str( (decimal)(AV57TFTipCCod_To), 6, 0))+"|"+((0==AV59TFCliSts_To) ? "" : StringUtil.Str( (decimal)(AV59TFCliSts_To), 1, 0))+"|"+((0==AV61TFConpcod_To) ? "" : StringUtil.Str( (decimal)(AV61TFConpcod_To), 6, 0))+"|"+((Convert.ToDecimal(0)==AV63TFCliLim_To) ? "" : StringUtil.Str( AV63TFCliLim_To, 15, 2))+"|"+((0==AV65TFCliVend_To) ? "" : StringUtil.Str( (decimal)(AV65TFCliVend_To), 6, 0))+"||||||||";
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
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV17CliDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17CliDsc1", AV17CliDsc1);
            }
            else if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
            {
               AV16DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV16DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
               AV18CliVendDsc1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18CliVendDsc1", AV18CliVendDsc1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22CliDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22CliDsc2", AV22CliDsc2);
               }
               else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV23CliVendDsc2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23CliVendDsc2", AV23CliVendDsc2);
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
                  AV24DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27CliDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV27CliDsc3", AV27CliDsc3);
                  }
                  else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV28CliVendDsc3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28CliVendDsc3", AV28CliVendDsc3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV33Session.Get(AV92Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLICOD",  "Codigo Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCliCod)),  0,  AV34TFCliCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCliCod_Sel)),  AV35TFCliCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIDSC",  "Razon Social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFCliDsc)),  0,  AV36TFCliDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCliDsc_Sel)),  AV37TFCliDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIDIR",  "Dirección",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCliDir)),  0,  AV38TFCliDir,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCliDir_Sel)),  AV39TFCliDir_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFESTCOD",  "Estado",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEstCod)),  0,  AV40TFEstCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFEstCod_Sel)),  AV41TFEstCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPAICOD",  "Pais",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPaiCod)),  0,  AV42TFPaiCod,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFPaiCod_Sel)),  AV43TFPaiCod_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLITEL1",  "Telefono 1",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCliTel1)),  0,  AV44TFCliTel1,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCliTel1_Sel)),  AV45TFCliTel1_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLITEL2",  "Telefono 2",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCliTel2)),  0,  AV46TFCliTel2,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCliTel2_Sel)),  AV47TFCliTel2_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIFAX",  "Fax",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCliFax)),  0,  AV48TFCliFax,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCliFax_Sel)),  AV49TFCliFax_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLICEL",  "Celular",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCliCel)),  0,  AV50TFCliCel,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCliCel_Sel)),  AV51TFCliCel_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIEMA",  "E-Mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCliEma)),  0,  AV52TFCliEma,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCliEma_Sel)),  AV53TFCliEma_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIWEB",  "Pagina Web",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCliWeb)),  0,  AV54TFCliWeb,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCliWeb_Sel)),  AV55TFCliWeb_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTIPCCOD",  "Codigo T. Cliente",  !((0==AV56TFTipCCod)&&(0==AV57TFTipCCod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV56TFTipCCod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV57TFTipCCod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLISTS",  "Situación",  !((0==AV58TFCliSts)&&(0==AV59TFCliSts_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV58TFCliSts), 1, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV59TFCliSts_To), 1, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCONPCOD",  "Codigo condicion pago",  !((0==AV60TFConpcod)&&(0==AV61TFConpcod_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV60TFConpcod), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV61TFConpcod_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLILIM",  "Limite Credito",  !((Convert.ToDecimal(0)==AV62TFCliLim)&&(Convert.ToDecimal(0)==AV63TFCliLim_To)),  0,  StringUtil.Trim( StringUtil.Str( AV62TFCliLim, 15, 2)),  StringUtil.Trim( StringUtil.Str( AV63TFCliLim_To, 15, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIVEND",  "Vendedor",  !((0==AV64TFCliVend)&&(0==AV65TFCliVend_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV64TFCliVend), 6, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV65TFCliVend_To), 6, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIVENDDSC",  "Vendedor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliVendDsc)),  0,  AV66TFCliVendDsc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliVendDsc_Sel)),  AV67TFCliVendDsc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF1",  "Referencia 1",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliRef1)),  0,  AV68TFCliRef1,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliRef1_Sel)),  AV69TFCliRef1_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF2",  "Referencia 2",  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliRef2)),  0,  AV70TFCliRef2,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCliRef2_Sel)),  AV71TFCliRef2_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF3",  "Referencia 3",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCliRef3)),  0,  AV72TFCliRef3,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCliRef3_Sel)),  AV73TFCliRef3_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF4",  "Referencia 4",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCliRef4)),  0,  AV74TFCliRef4,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCliRef4_Sel)),  AV75TFCliRef4_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF5",  "Referencia 5",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCliRef5)),  0,  AV76TFCliRef5,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCliRef5_Sel)),  AV77TFCliRef5_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF6",  "Referencia 6",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCliRef6)),  0,  AV78TFCliRef6,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliRef6_Sel)),  AV79TFCliRef6_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIREF7",  "Referencia 7",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliRef7)),  0,  AV80TFCliRef7,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCliRef7_Sel)),  AV81TFCliRef7_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV92Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S182( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CliDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Razon Social";
               AV12GridStateDynamicFilter.gxTpr_Value = AV17CliDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "CLIVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CliVendDsc1)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV18CliVendDsc1;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV16DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CliDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Razon Social";
               AV12GridStateDynamicFilter.gxTpr_Value = AV22CliDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CliVendDsc2)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV23CliVendDsc2;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV21DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV24DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27CliDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Razon Social";
               AV12GridStateDynamicFilter.gxTpr_Value = AV27CliDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIVENDDSC") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CliVendDsc3)) )
            {
               AV12GridStateDynamicFilter.gxTpr_Dsc = "Vendedor";
               AV12GridStateDynamicFilter.gxTpr_Value = AV28CliVendDsc3;
               AV12GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV92Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Ventas.Clientes";
         AV33Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
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
         new GeneXus.Programs.ventas.clienteswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
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
         Innewwindow1_Target = formatLink("ventas.clienteswwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table1_25_782( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_39_782( true) ;
         }
         else
         {
            wb_table2_39_782( false) ;
         }
         return  ;
      }

      protected void wb_table2_39_782e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table3_64_782( true) ;
         }
         else
         {
            wb_table3_64_782( false) ;
         }
         return  ;
      }

      protected void wb_table3_64_782e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Buscar en", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "left", "top", "", "flex-grow:1;", "div");
            wb_table4_89_782( true) ;
         }
         else
         {
            wb_table4_89_782( false) ;
         }
         return  ;
      }

      protected void wb_table4_89_782e( bool wbgen )
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
            wb_table1_25_782e( true) ;
         }
         else
         {
            wb_table1_25_782e( false) ;
         }
      }

      protected void wb_table4_89_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clidsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc3_Internalname, "Cli Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc3_Internalname, StringUtil.RTrim( AV27CliDsc3), StringUtil.RTrim( context.localUtil.Format( AV27CliDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClidsc3_Visible, edtavClidsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clivenddsc3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClivenddsc3_Internalname, "Cli Vend Dsc3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClivenddsc3_Internalname, StringUtil.RTrim( AV28CliVendDsc3), StringUtil.RTrim( context.localUtil.Format( AV28CliVendDsc3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClivenddsc3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClivenddsc3_Visible, edtavClivenddsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\ClientesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_89_782e( true) ;
         }
         else
         {
            wb_table4_89_782e( false) ;
         }
      }

      protected void wb_table3_64_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clidsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc2_Internalname, "Cli Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc2_Internalname, StringUtil.RTrim( AV22CliDsc2), StringUtil.RTrim( context.localUtil.Format( AV22CliDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClidsc2_Visible, edtavClidsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clivenddsc2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClivenddsc2_Internalname, "Cli Vend Dsc2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClivenddsc2_Internalname, StringUtil.RTrim( AV23CliVendDsc2), StringUtil.RTrim( context.localUtil.Format( AV23CliVendDsc2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClivenddsc2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClivenddsc2_Visible, edtavClivenddsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\ClientesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\ClientesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_64_782e( true) ;
         }
         else
         {
            wb_table3_64_782e( false) ;
         }
      }

      protected void wb_table2_39_782( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 1, "HLP_Ventas\\ClientesWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clidsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClidsc1_Internalname, "Cli Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClidsc1_Internalname, StringUtil.RTrim( AV17CliDsc1), StringUtil.RTrim( context.localUtil.Format( AV17CliDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClidsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClidsc1_Visible, edtavClidsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clivenddsc1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClivenddsc1_Internalname, "Cli Vend Dsc1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClivenddsc1_Internalname, StringUtil.RTrim( AV18CliVendDsc1), StringUtil.RTrim( context.localUtil.Format( AV18CliVendDsc1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClivenddsc1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClivenddsc1_Visible, edtavClivenddsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Ventas\\ClientesWW.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Agregar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\ClientesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Quitar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas\\ClientesWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_39_782e( true) ;
         }
         else
         {
            wb_table2_39_782e( false) ;
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
         PA782( ) ;
         WS782( ) ;
         WE782( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810323438", true, true);
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
         context.AddJavascriptSource("ventas/clientesww.js", "?202281810323439", false, true);
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

      protected void SubsflControlProps_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_idx;
         edtCliCod_Internalname = "CLICOD_"+sGXsfl_110_idx;
         edtCliDsc_Internalname = "CLIDSC_"+sGXsfl_110_idx;
         edtCliDir_Internalname = "CLIDIR_"+sGXsfl_110_idx;
         edtEstCod_Internalname = "ESTCOD_"+sGXsfl_110_idx;
         edtPaiCod_Internalname = "PAICOD_"+sGXsfl_110_idx;
         edtCliTel1_Internalname = "CLITEL1_"+sGXsfl_110_idx;
         edtCliTel2_Internalname = "CLITEL2_"+sGXsfl_110_idx;
         edtCliFax_Internalname = "CLIFAX_"+sGXsfl_110_idx;
         edtCliCel_Internalname = "CLICEL_"+sGXsfl_110_idx;
         edtCliEma_Internalname = "CLIEMA_"+sGXsfl_110_idx;
         edtCliWeb_Internalname = "CLIWEB_"+sGXsfl_110_idx;
         edtTipCCod_Internalname = "TIPCCOD_"+sGXsfl_110_idx;
         edtCliFoto_Internalname = "CLIFOTO_"+sGXsfl_110_idx;
         edtCliSts_Internalname = "CLISTS_"+sGXsfl_110_idx;
         edtConpcod_Internalname = "CONPCOD_"+sGXsfl_110_idx;
         edtCliLim_Internalname = "CLILIM_"+sGXsfl_110_idx;
         edtCliVend_Internalname = "CLIVEND_"+sGXsfl_110_idx;
         edtCliVendDsc_Internalname = "CLIVENDDSC_"+sGXsfl_110_idx;
         edtCliRef1_Internalname = "CLIREF1_"+sGXsfl_110_idx;
         edtCliRef2_Internalname = "CLIREF2_"+sGXsfl_110_idx;
         edtCliRef3_Internalname = "CLIREF3_"+sGXsfl_110_idx;
         edtCliRef4_Internalname = "CLIREF4_"+sGXsfl_110_idx;
         edtCliRef5_Internalname = "CLIREF5_"+sGXsfl_110_idx;
         edtCliRef6_Internalname = "CLIREF6_"+sGXsfl_110_idx;
         edtCliRef7_Internalname = "CLIREF7_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_110_fel_idx;
         edtCliCod_Internalname = "CLICOD_"+sGXsfl_110_fel_idx;
         edtCliDsc_Internalname = "CLIDSC_"+sGXsfl_110_fel_idx;
         edtCliDir_Internalname = "CLIDIR_"+sGXsfl_110_fel_idx;
         edtEstCod_Internalname = "ESTCOD_"+sGXsfl_110_fel_idx;
         edtPaiCod_Internalname = "PAICOD_"+sGXsfl_110_fel_idx;
         edtCliTel1_Internalname = "CLITEL1_"+sGXsfl_110_fel_idx;
         edtCliTel2_Internalname = "CLITEL2_"+sGXsfl_110_fel_idx;
         edtCliFax_Internalname = "CLIFAX_"+sGXsfl_110_fel_idx;
         edtCliCel_Internalname = "CLICEL_"+sGXsfl_110_fel_idx;
         edtCliEma_Internalname = "CLIEMA_"+sGXsfl_110_fel_idx;
         edtCliWeb_Internalname = "CLIWEB_"+sGXsfl_110_fel_idx;
         edtTipCCod_Internalname = "TIPCCOD_"+sGXsfl_110_fel_idx;
         edtCliFoto_Internalname = "CLIFOTO_"+sGXsfl_110_fel_idx;
         edtCliSts_Internalname = "CLISTS_"+sGXsfl_110_fel_idx;
         edtConpcod_Internalname = "CONPCOD_"+sGXsfl_110_fel_idx;
         edtCliLim_Internalname = "CLILIM_"+sGXsfl_110_fel_idx;
         edtCliVend_Internalname = "CLIVEND_"+sGXsfl_110_fel_idx;
         edtCliVendDsc_Internalname = "CLIVENDDSC_"+sGXsfl_110_fel_idx;
         edtCliRef1_Internalname = "CLIREF1_"+sGXsfl_110_fel_idx;
         edtCliRef2_Internalname = "CLIREF2_"+sGXsfl_110_fel_idx;
         edtCliRef3_Internalname = "CLIREF3_"+sGXsfl_110_fel_idx;
         edtCliRef4_Internalname = "CLIREF4_"+sGXsfl_110_fel_idx;
         edtCliRef5_Internalname = "CLIREF5_"+sGXsfl_110_fel_idx;
         edtCliRef6_Internalname = "CLIREF6_"+sGXsfl_110_fel_idx;
         edtCliRef7_Internalname = "CLIREF7_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         SubsflControlProps_1102( ) ;
         WB780( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_110_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_110_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_110_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 111,'',false,'"+sGXsfl_110_idx+"',110)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV87GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0))), "."));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,111);\"" : " "),(string)"",(bool)true,(short)1});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliCod_Internalname,StringUtil.RTrim( A45CliCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDsc_Internalname,StringUtil.RTrim( A161CliDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCliDsc_Link,(string)"",(string)"",(string)"",(string)edtCliDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDir_Internalname,StringUtil.RTrim( A596CliDir),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDir_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstCod_Internalname,StringUtil.RTrim( A140EstCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaiCod_Internalname,StringUtil.RTrim( A139PaiCod),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaiCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliTel1_Internalname,StringUtil.RTrim( A629CliTel1),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliTel1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliTel2_Internalname,StringUtil.RTrim( A630CliTel2),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliTel2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliFax_Internalname,StringUtil.RTrim( A611CliFax),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliFax_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliCel_Internalname,StringUtil.RTrim( A575CliCel),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliCel_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliEma_Internalname,(string)A609CliEma,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A609CliEma,(string)"",(string)"",(string)"",(string)edtCliEma_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliWeb_Internalname,StringUtil.RTrim( A637CliWeb),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliWeb_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A612CliFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.PathToRelativeUrl( A612CliFoto));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtCliFoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A612CliFoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliSts_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A627CliSts), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A627CliSts), "9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliSts_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtConpcod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtConpcod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliLim_Internalname,StringUtil.LTrim( StringUtil.NToC( A613CliLim, 15, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliLim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliVend_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A160CliVend), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A160CliVend), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliVend_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliVendDsc_Internalname,StringUtil.RTrim( A635CliVendDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCliVendDsc_Link,(string)"",(string)"",(string)"",(string)edtCliVendDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef1_Internalname,StringUtil.RTrim( A618CliRef1),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef2_Internalname,StringUtil.RTrim( A619CliRef2),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef3_Internalname,StringUtil.RTrim( A620CliRef3),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef4_Internalname,StringUtil.RTrim( A621CliRef4),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef4_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef5_Internalname,StringUtil.RTrim( A622CliRef5),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef5_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef6_Internalname,StringUtil.RTrim( A623CliRef6),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef6_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliRef7_Internalname,StringUtil.RTrim( A624CliRef7),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliRef7_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)110,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes782( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         /* End function sendrow_1102 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CLIDSC", "Razon Social", 0);
         cmbavDynamicfiltersselector1.addItem("CLIVENDDSC", "Vendedor", 0);
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
         cmbavDynamicfiltersselector2.addItem("CLIDSC", "Razon Social", 0);
         cmbavDynamicfiltersselector2.addItem("CLIVENDDSC", "Vendedor", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CLIDSC", "Razon Social", 0);
         cmbavDynamicfiltersselector3.addItem("CLIVENDDSC", "Vendedor", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Comienza con", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contiene", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_110_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV87GridActions = (short)(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0))), "."));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
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
         edtavClidsc1_Internalname = "vCLIDSC1";
         cellFilter_clidsc1_cell_Internalname = "FILTER_CLIDSC1_CELL";
         edtavClivenddsc1_Internalname = "vCLIVENDDSC1";
         cellFilter_clivenddsc1_cell_Internalname = "FILTER_CLIVENDDSC1_CELL";
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
         edtavClidsc2_Internalname = "vCLIDSC2";
         cellFilter_clidsc2_cell_Internalname = "FILTER_CLIDSC2_CELL";
         edtavClivenddsc2_Internalname = "vCLIVENDDSC2";
         cellFilter_clivenddsc2_cell_Internalname = "FILTER_CLIVENDDSC2_CELL";
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
         edtavClidsc3_Internalname = "vCLIDSC3";
         cellFilter_clidsc3_cell_Internalname = "FILTER_CLIDSC3_CELL";
         edtavClivenddsc3_Internalname = "vCLIVENDDSC3";
         cellFilter_clivenddsc3_cell_Internalname = "FILTER_CLIVENDDSC3_CELL";
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
         edtCliCod_Internalname = "CLICOD";
         edtCliDsc_Internalname = "CLIDSC";
         edtCliDir_Internalname = "CLIDIR";
         edtEstCod_Internalname = "ESTCOD";
         edtPaiCod_Internalname = "PAICOD";
         edtCliTel1_Internalname = "CLITEL1";
         edtCliTel2_Internalname = "CLITEL2";
         edtCliFax_Internalname = "CLIFAX";
         edtCliCel_Internalname = "CLICEL";
         edtCliEma_Internalname = "CLIEMA";
         edtCliWeb_Internalname = "CLIWEB";
         edtTipCCod_Internalname = "TIPCCOD";
         edtCliFoto_Internalname = "CLIFOTO";
         edtCliSts_Internalname = "CLISTS";
         edtConpcod_Internalname = "CONPCOD";
         edtCliLim_Internalname = "CLILIM";
         edtCliVend_Internalname = "CLIVEND";
         edtCliVendDsc_Internalname = "CLIVENDDSC";
         edtCliRef1_Internalname = "CLIREF1";
         edtCliRef2_Internalname = "CLIREF2";
         edtCliRef3_Internalname = "CLIREF3";
         edtCliRef4_Internalname = "CLIREF4";
         edtCliRef5_Internalname = "CLIREF5";
         edtCliRef6_Internalname = "CLIREF6";
         edtCliRef7_Internalname = "CLIREF7";
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
         edtCliRef7_Jsonclick = "";
         edtCliRef6_Jsonclick = "";
         edtCliRef5_Jsonclick = "";
         edtCliRef4_Jsonclick = "";
         edtCliRef3_Jsonclick = "";
         edtCliRef2_Jsonclick = "";
         edtCliRef1_Jsonclick = "";
         edtCliVendDsc_Jsonclick = "";
         edtCliVend_Jsonclick = "";
         edtCliLim_Jsonclick = "";
         edtConpcod_Jsonclick = "";
         edtCliSts_Jsonclick = "";
         edtTipCCod_Jsonclick = "";
         edtCliWeb_Jsonclick = "";
         edtCliEma_Jsonclick = "";
         edtCliCel_Jsonclick = "";
         edtCliFax_Jsonclick = "";
         edtCliTel2_Jsonclick = "";
         edtCliTel1_Jsonclick = "";
         edtPaiCod_Jsonclick = "";
         edtEstCod_Jsonclick = "";
         edtCliDir_Jsonclick = "";
         edtCliDsc_Jsonclick = "";
         edtCliCod_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavClivenddsc1_Jsonclick = "";
         edtavClivenddsc1_Enabled = 1;
         edtavClidsc1_Jsonclick = "";
         edtavClidsc1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavClivenddsc2_Jsonclick = "";
         edtavClivenddsc2_Enabled = 1;
         edtavClidsc2_Jsonclick = "";
         edtavClidsc2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavClivenddsc3_Jsonclick = "";
         edtavClivenddsc3_Enabled = 1;
         edtavClidsc3_Jsonclick = "";
         edtavClidsc3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavClivenddsc3_Visible = 1;
         edtavClidsc3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavClivenddsc2_Visible = 1;
         edtavClidsc2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavClivenddsc1_Visible = 1;
         edtavClidsc1_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtCliVendDsc_Link = "";
         edtCliDsc_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "Ventas.ClientesWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||||||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T|T|T|T|T|T|T|T|T|T||||||T|T|T|T|T|T|T|T";
         Ddo_grid_Filterisrange = "|||||||||||T|T|T|T|T||||||||";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character|Character|Character|Character|Character|Numeric|Numeric|Numeric|Numeric|Numeric|Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24";
         Ddo_grid_Columnids = "1:CliCod|2:CliDsc|3:CliDir|4:EstCod|5:PaiCod|6:CliTel1|7:CliTel2|8:CliFax|9:CliCel|10:CliEma|11:CliWeb|12:TipCCod|14:CliSts|15:Conpcod|16:CliLim|17:CliVend|18:CliVendDsc|19:CliRef1|20:CliRef2|21:CliRef3|22:CliRef4|23:CliRef5|24:CliRef6|25:CliRef7";
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
         Form.Caption = " Clientes";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E14782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E26782',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:'',hsh:true},{av:'A160CliVend',fld:'CLIVEND',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtCliDsc_Link',ctrl:'CLIDSC',prop:'Link'},{av:'edtCliVendDsc_Link',ctrl:'CLIVENDDSC',prop:'Link'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E19782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E15782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'edtavClidsc2_Visible',ctrl:'vCLIDSC2',prop:'Visible'},{av:'edtavClivenddsc2_Visible',ctrl:'vCLIVENDDSC2',prop:'Visible'},{av:'edtavClidsc3_Visible',ctrl:'vCLIDSC3',prop:'Visible'},{av:'edtavClivenddsc3_Visible',ctrl:'vCLIVENDDSC3',prop:'Visible'},{av:'edtavClidsc1_Visible',ctrl:'vCLIDSC1',prop:'Visible'},{av:'edtavClivenddsc1_Visible',ctrl:'vCLIVENDDSC1',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E20782',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavClidsc1_Visible',ctrl:'vCLIDSC1',prop:'Visible'},{av:'edtavClivenddsc1_Visible',ctrl:'vCLIVENDDSC1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E21782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E16782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'edtavClidsc2_Visible',ctrl:'vCLIDSC2',prop:'Visible'},{av:'edtavClivenddsc2_Visible',ctrl:'vCLIVENDDSC2',prop:'Visible'},{av:'edtavClidsc3_Visible',ctrl:'vCLIDSC3',prop:'Visible'},{av:'edtavClivenddsc3_Visible',ctrl:'vCLIVENDDSC3',prop:'Visible'},{av:'edtavClidsc1_Visible',ctrl:'vCLIDSC1',prop:'Visible'},{av:'edtavClivenddsc1_Visible',ctrl:'vCLIVENDDSC1',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E22782',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavClidsc2_Visible',ctrl:'vCLIDSC2',prop:'Visible'},{av:'edtavClivenddsc2_Visible',ctrl:'vCLIVENDDSC2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E17782',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'edtavClidsc2_Visible',ctrl:'vCLIDSC2',prop:'Visible'},{av:'edtavClivenddsc2_Visible',ctrl:'vCLIVENDDSC2',prop:'Visible'},{av:'edtavClidsc3_Visible',ctrl:'vCLIDSC3',prop:'Visible'},{av:'edtavClivenddsc3_Visible',ctrl:'vCLIVENDDSC3',prop:'Visible'},{av:'edtavClidsc1_Visible',ctrl:'vCLIDSC1',prop:'Visible'},{av:'edtavClivenddsc1_Visible',ctrl:'vCLIVENDDSC1',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E23782',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavClidsc3_Visible',ctrl:'vCLIDSC3',prop:'Visible'},{av:'edtavClivenddsc3_Visible',ctrl:'vCLIVENDDSC3',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E27782',iparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A45CliCod',fld:'CLICOD',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18782',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13782',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV10GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV81TFCliRef7_Sel',fld:'vTFCLIREF7_SEL',pic:''},{av:'AV80TFCliRef7',fld:'vTFCLIREF7',pic:''},{av:'AV79TFCliRef6_Sel',fld:'vTFCLIREF6_SEL',pic:''},{av:'AV78TFCliRef6',fld:'vTFCLIREF6',pic:''},{av:'AV77TFCliRef5_Sel',fld:'vTFCLIREF5_SEL',pic:''},{av:'AV76TFCliRef5',fld:'vTFCLIREF5',pic:''},{av:'AV75TFCliRef4_Sel',fld:'vTFCLIREF4_SEL',pic:''},{av:'AV74TFCliRef4',fld:'vTFCLIREF4',pic:''},{av:'AV73TFCliRef3_Sel',fld:'vTFCLIREF3_SEL',pic:''},{av:'AV72TFCliRef3',fld:'vTFCLIREF3',pic:''},{av:'AV71TFCliRef2_Sel',fld:'vTFCLIREF2_SEL',pic:''},{av:'AV70TFCliRef2',fld:'vTFCLIREF2',pic:''},{av:'AV69TFCliRef1_Sel',fld:'vTFCLIREF1_SEL',pic:''},{av:'AV68TFCliRef1',fld:'vTFCLIREF1',pic:''},{av:'AV67TFCliVendDsc_Sel',fld:'vTFCLIVENDDSC_SEL',pic:''},{av:'AV66TFCliVendDsc',fld:'vTFCLIVENDDSC',pic:''},{av:'AV64TFCliVend',fld:'vTFCLIVEND',pic:'ZZZZZ9'},{av:'AV65TFCliVend_To',fld:'vTFCLIVEND_TO',pic:'ZZZZZ9'},{av:'AV62TFCliLim',fld:'vTFCLILIM',pic:'ZZZZZZZZZZZ9.99'},{av:'AV63TFCliLim_To',fld:'vTFCLILIM_TO',pic:'ZZZZZZZZZZZ9.99'},{av:'AV60TFConpcod',fld:'vTFCONPCOD',pic:'ZZZZZ9'},{av:'AV61TFConpcod_To',fld:'vTFCONPCOD_TO',pic:'ZZZZZ9'},{av:'AV58TFCliSts',fld:'vTFCLISTS',pic:'9'},{av:'AV59TFCliSts_To',fld:'vTFCLISTS_TO',pic:'9'},{av:'AV56TFTipCCod',fld:'vTFTIPCCOD',pic:'ZZZZZ9'},{av:'AV57TFTipCCod_To',fld:'vTFTIPCCOD_TO',pic:'ZZZZZ9'},{av:'AV55TFCliWeb_Sel',fld:'vTFCLIWEB_SEL',pic:''},{av:'AV54TFCliWeb',fld:'vTFCLIWEB',pic:''},{av:'AV53TFCliEma_Sel',fld:'vTFCLIEMA_SEL',pic:''},{av:'AV52TFCliEma',fld:'vTFCLIEMA',pic:''},{av:'AV51TFCliCel_Sel',fld:'vTFCLICEL_SEL',pic:''},{av:'AV50TFCliCel',fld:'vTFCLICEL',pic:''},{av:'AV49TFCliFax_Sel',fld:'vTFCLIFAX_SEL',pic:''},{av:'AV48TFCliFax',fld:'vTFCLIFAX',pic:''},{av:'AV47TFCliTel2_Sel',fld:'vTFCLITEL2_SEL',pic:''},{av:'AV46TFCliTel2',fld:'vTFCLITEL2',pic:''},{av:'AV45TFCliTel1_Sel',fld:'vTFCLITEL1_SEL',pic:''},{av:'AV44TFCliTel1',fld:'vTFCLITEL1',pic:''},{av:'AV43TFPaiCod_Sel',fld:'vTFPAICOD_SEL',pic:''},{av:'AV42TFPaiCod',fld:'vTFPAICOD',pic:''},{av:'AV41TFEstCod_Sel',fld:'vTFESTCOD_SEL',pic:''},{av:'AV40TFEstCod',fld:'vTFESTCOD',pic:''},{av:'AV39TFCliDir_Sel',fld:'vTFCLIDIR_SEL',pic:''},{av:'AV38TFCliDir',fld:'vTFCLIDIR',pic:''},{av:'AV37TFCliDsc_Sel',fld:'vTFCLIDSC_SEL',pic:''},{av:'AV36TFCliDsc',fld:'vTFCLIDSC',pic:''},{av:'AV35TFCliCod_Sel',fld:'vTFCLICOD_SEL',pic:''},{av:'AV34TFCliCod',fld:'vTFCLICOD',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'cmbavDynamicfiltersselector1'},{av:'AV15DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV16DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV17CliDsc1',fld:'vCLIDSC1',pic:''},{av:'AV18CliVendDsc1',fld:'vCLIVENDDSC1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV20DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV21DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV22CliDsc2',fld:'vCLIDSC2',pic:''},{av:'AV23CliVendDsc2',fld:'vCLIVENDDSC2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27CliDsc3',fld:'vCLIDSC3',pic:''},{av:'AV28CliVendDsc3',fld:'vCLIVENDDSC3',pic:''},{av:'AV19DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV92Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavClidsc1_Visible',ctrl:'vCLIDSC1',prop:'Visible'},{av:'edtavClivenddsc1_Visible',ctrl:'vCLIVENDDSC1',prop:'Visible'},{av:'edtavClidsc2_Visible',ctrl:'vCLIDSC2',prop:'Visible'},{av:'edtavClivenddsc2_Visible',ctrl:'vCLIVENDDSC2',prop:'Visible'},{av:'edtavClidsc3_Visible',ctrl:'vCLIDSC3',prop:'Visible'},{av:'edtavClivenddsc3_Visible',ctrl:'vCLIVENDDSC3',prop:'Visible'}]}");
         setEventMetadata("VALID_CLIVEND","{handler:'Valid_Clivend',iparms:[]");
         setEventMetadata("VALID_CLIVEND",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cliref7',iparms:[]");
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
         AV17CliDsc1 = "";
         AV18CliVendDsc1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22CliDsc2 = "";
         AV23CliVendDsc2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV27CliDsc3 = "";
         AV28CliVendDsc3 = "";
         AV92Pgmname = "";
         AV34TFCliCod = "";
         AV35TFCliCod_Sel = "";
         AV36TFCliDsc = "";
         AV37TFCliDsc_Sel = "";
         AV38TFCliDir = "";
         AV39TFCliDir_Sel = "";
         AV40TFEstCod = "";
         AV41TFEstCod_Sel = "";
         AV42TFPaiCod = "";
         AV43TFPaiCod_Sel = "";
         AV44TFCliTel1 = "";
         AV45TFCliTel1_Sel = "";
         AV46TFCliTel2 = "";
         AV47TFCliTel2_Sel = "";
         AV48TFCliFax = "";
         AV49TFCliFax_Sel = "";
         AV50TFCliCel = "";
         AV51TFCliCel_Sel = "";
         AV52TFCliEma = "";
         AV53TFCliEma_Sel = "";
         AV54TFCliWeb = "";
         AV55TFCliWeb_Sel = "";
         AV66TFCliVendDsc = "";
         AV67TFCliVendDsc_Sel = "";
         AV68TFCliRef1 = "";
         AV69TFCliRef1_Sel = "";
         AV70TFCliRef2 = "";
         AV71TFCliRef2_Sel = "";
         AV72TFCliRef3 = "";
         AV73TFCliRef3_Sel = "";
         AV74TFCliRef4 = "";
         AV75TFCliRef4_Sel = "";
         AV76TFCliRef5 = "";
         AV77TFCliRef5_Sel = "";
         AV78TFCliRef6 = "";
         AV79TFCliRef6_Sel = "";
         AV80TFCliRef7 = "";
         AV81TFCliRef7_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV86GridAppliedFilters = "";
         AV88AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV82DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A45CliCod = "";
         A161CliDsc = "";
         A596CliDir = "";
         A140EstCod = "";
         A139PaiCod = "";
         A629CliTel1 = "";
         A630CliTel2 = "";
         A611CliFax = "";
         A575CliCel = "";
         A609CliEma = "";
         A637CliWeb = "";
         A612CliFoto = "";
         A635CliVendDsc = "";
         A618CliRef1 = "";
         A619CliRef2 = "";
         A620CliRef3 = "";
         A621CliRef4 = "";
         A622CliRef5 = "";
         A623CliRef6 = "";
         A624CliRef7 = "";
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
         A40000CliFoto_GXI = "";
         scmdbuf = "";
         lV95Ventas_clienteswwds_3_clidsc1 = "";
         lV96Ventas_clienteswwds_4_clivenddsc1 = "";
         lV100Ventas_clienteswwds_8_clidsc2 = "";
         lV101Ventas_clienteswwds_9_clivenddsc2 = "";
         lV105Ventas_clienteswwds_13_clidsc3 = "";
         lV106Ventas_clienteswwds_14_clivenddsc3 = "";
         lV107Ventas_clienteswwds_15_tfclicod = "";
         lV109Ventas_clienteswwds_17_tfclidsc = "";
         lV111Ventas_clienteswwds_19_tfclidir = "";
         lV113Ventas_clienteswwds_21_tfestcod = "";
         lV115Ventas_clienteswwds_23_tfpaicod = "";
         lV117Ventas_clienteswwds_25_tfclitel1 = "";
         lV119Ventas_clienteswwds_27_tfclitel2 = "";
         lV121Ventas_clienteswwds_29_tfclifax = "";
         lV123Ventas_clienteswwds_31_tfclicel = "";
         lV125Ventas_clienteswwds_33_tfcliema = "";
         lV127Ventas_clienteswwds_35_tfcliweb = "";
         lV139Ventas_clienteswwds_47_tfclivenddsc = "";
         lV141Ventas_clienteswwds_49_tfcliref1 = "";
         lV143Ventas_clienteswwds_51_tfcliref2 = "";
         lV145Ventas_clienteswwds_53_tfcliref3 = "";
         lV147Ventas_clienteswwds_55_tfcliref4 = "";
         lV149Ventas_clienteswwds_57_tfcliref5 = "";
         lV151Ventas_clienteswwds_59_tfcliref6 = "";
         lV153Ventas_clienteswwds_61_tfcliref7 = "";
         AV93Ventas_clienteswwds_1_dynamicfiltersselector1 = "";
         AV95Ventas_clienteswwds_3_clidsc1 = "";
         AV96Ventas_clienteswwds_4_clivenddsc1 = "";
         AV98Ventas_clienteswwds_6_dynamicfiltersselector2 = "";
         AV100Ventas_clienteswwds_8_clidsc2 = "";
         AV101Ventas_clienteswwds_9_clivenddsc2 = "";
         AV103Ventas_clienteswwds_11_dynamicfiltersselector3 = "";
         AV105Ventas_clienteswwds_13_clidsc3 = "";
         AV106Ventas_clienteswwds_14_clivenddsc3 = "";
         AV108Ventas_clienteswwds_16_tfclicod_sel = "";
         AV107Ventas_clienteswwds_15_tfclicod = "";
         AV110Ventas_clienteswwds_18_tfclidsc_sel = "";
         AV109Ventas_clienteswwds_17_tfclidsc = "";
         AV112Ventas_clienteswwds_20_tfclidir_sel = "";
         AV111Ventas_clienteswwds_19_tfclidir = "";
         AV114Ventas_clienteswwds_22_tfestcod_sel = "";
         AV113Ventas_clienteswwds_21_tfestcod = "";
         AV116Ventas_clienteswwds_24_tfpaicod_sel = "";
         AV115Ventas_clienteswwds_23_tfpaicod = "";
         AV118Ventas_clienteswwds_26_tfclitel1_sel = "";
         AV117Ventas_clienteswwds_25_tfclitel1 = "";
         AV120Ventas_clienteswwds_28_tfclitel2_sel = "";
         AV119Ventas_clienteswwds_27_tfclitel2 = "";
         AV122Ventas_clienteswwds_30_tfclifax_sel = "";
         AV121Ventas_clienteswwds_29_tfclifax = "";
         AV124Ventas_clienteswwds_32_tfclicel_sel = "";
         AV123Ventas_clienteswwds_31_tfclicel = "";
         AV126Ventas_clienteswwds_34_tfcliema_sel = "";
         AV125Ventas_clienteswwds_33_tfcliema = "";
         AV128Ventas_clienteswwds_36_tfcliweb_sel = "";
         AV127Ventas_clienteswwds_35_tfcliweb = "";
         AV140Ventas_clienteswwds_48_tfclivenddsc_sel = "";
         AV139Ventas_clienteswwds_47_tfclivenddsc = "";
         AV142Ventas_clienteswwds_50_tfcliref1_sel = "";
         AV141Ventas_clienteswwds_49_tfcliref1 = "";
         AV144Ventas_clienteswwds_52_tfcliref2_sel = "";
         AV143Ventas_clienteswwds_51_tfcliref2 = "";
         AV146Ventas_clienteswwds_54_tfcliref3_sel = "";
         AV145Ventas_clienteswwds_53_tfcliref3 = "";
         AV148Ventas_clienteswwds_56_tfcliref4_sel = "";
         AV147Ventas_clienteswwds_55_tfcliref4 = "";
         AV150Ventas_clienteswwds_58_tfcliref5_sel = "";
         AV149Ventas_clienteswwds_57_tfcliref5 = "";
         AV152Ventas_clienteswwds_60_tfcliref6_sel = "";
         AV151Ventas_clienteswwds_59_tfcliref6 = "";
         AV154Ventas_clienteswwds_62_tfcliref7_sel = "";
         AV153Ventas_clienteswwds_61_tfcliref7 = "";
         H00782_A624CliRef7 = new string[] {""} ;
         H00782_A623CliRef6 = new string[] {""} ;
         H00782_A622CliRef5 = new string[] {""} ;
         H00782_A621CliRef4 = new string[] {""} ;
         H00782_A620CliRef3 = new string[] {""} ;
         H00782_A619CliRef2 = new string[] {""} ;
         H00782_A618CliRef1 = new string[] {""} ;
         H00782_A635CliVendDsc = new string[] {""} ;
         H00782_A160CliVend = new int[1] ;
         H00782_A613CliLim = new decimal[1] ;
         H00782_A137Conpcod = new int[1] ;
         H00782_A627CliSts = new short[1] ;
         H00782_A40000CliFoto_GXI = new string[] {""} ;
         H00782_n40000CliFoto_GXI = new bool[] {false} ;
         H00782_A159TipCCod = new int[1] ;
         H00782_A637CliWeb = new string[] {""} ;
         H00782_A609CliEma = new string[] {""} ;
         H00782_A575CliCel = new string[] {""} ;
         H00782_A611CliFax = new string[] {""} ;
         H00782_A630CliTel2 = new string[] {""} ;
         H00782_A629CliTel1 = new string[] {""} ;
         H00782_A139PaiCod = new string[] {""} ;
         H00782_A140EstCod = new string[] {""} ;
         H00782_A596CliDir = new string[] {""} ;
         H00782_A161CliDsc = new string[] {""} ;
         H00782_A45CliCod = new string[] {""} ;
         H00782_A612CliFoto = new string[] {""} ;
         H00782_n612CliFoto = new bool[] {false} ;
         H00783_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV89AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV33Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char20 = "";
         GXt_char19 = "";
         GXt_char18 = "";
         GXt_char17 = "";
         GXt_char16 = "";
         GXt_char15 = "";
         GXt_char14 = "";
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
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.clientesww__default(),
            new Object[][] {
                new Object[] {
               H00782_A624CliRef7, H00782_A623CliRef6, H00782_A622CliRef5, H00782_A621CliRef4, H00782_A620CliRef3, H00782_A619CliRef2, H00782_A618CliRef1, H00782_A635CliVendDsc, H00782_A160CliVend, H00782_A613CliLim,
               H00782_A137Conpcod, H00782_A627CliSts, H00782_A40000CliFoto_GXI, H00782_n40000CliFoto_GXI, H00782_A159TipCCod, H00782_A637CliWeb, H00782_A609CliEma, H00782_A575CliCel, H00782_A611CliFax, H00782_A630CliTel2,
               H00782_A629CliTel1, H00782_A139PaiCod, H00782_A140EstCod, H00782_A596CliDir, H00782_A161CliDsc, H00782_A45CliCod, H00782_A612CliFoto, H00782_n612CliFoto
               }
               , new Object[] {
               H00783_AGRID_nRecordCount
               }
            }
         );
         AV92Pgmname = "Ventas.ClientesWW";
         /* GeneXus formulas. */
         AV92Pgmname = "Ventas.ClientesWW";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV58TFCliSts ;
      private short AV59TFCliSts_To ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Sortable ;
      private short AV87GridActions ;
      private short A627CliSts ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 ;
      private short AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 ;
      private short AV131Ventas_clienteswwds_39_tfclists ;
      private short AV132Ventas_clienteswwds_40_tfclists_to ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int AV56TFTipCCod ;
      private int AV57TFTipCCod_To ;
      private int AV60TFConpcod ;
      private int AV61TFConpcod_To ;
      private int AV64TFCliVend ;
      private int AV65TFCliVend_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A159TipCCod ;
      private int A137Conpcod ;
      private int A160CliVend ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV129Ventas_clienteswwds_37_tftipccod ;
      private int AV130Ventas_clienteswwds_38_tftipccod_to ;
      private int AV133Ventas_clienteswwds_41_tfconpcod ;
      private int AV134Ventas_clienteswwds_42_tfconpcod_to ;
      private int AV137Ventas_clienteswwds_45_tfclivend ;
      private int AV138Ventas_clienteswwds_46_tfclivend_to ;
      private int AV83PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavClidsc1_Visible ;
      private int edtavClivenddsc1_Visible ;
      private int edtavClidsc2_Visible ;
      private int edtavClivenddsc2_Visible ;
      private int edtavClidsc3_Visible ;
      private int edtavClivenddsc3_Visible ;
      private int AV155GXV1 ;
      private int edtavClidsc3_Enabled ;
      private int edtavClivenddsc3_Enabled ;
      private int edtavClidsc2_Enabled ;
      private int edtavClivenddsc2_Enabled ;
      private int edtavClidsc1_Enabled ;
      private int edtavClivenddsc1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV84GridCurrentPage ;
      private long AV85GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV62TFCliLim ;
      private decimal AV63TFCliLim_To ;
      private decimal A613CliLim ;
      private decimal AV135Ventas_clienteswwds_43_tfclilim ;
      private decimal AV136Ventas_clienteswwds_44_tfclilim_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_110_idx="0001" ;
      private string AV17CliDsc1 ;
      private string AV18CliVendDsc1 ;
      private string AV22CliDsc2 ;
      private string AV23CliVendDsc2 ;
      private string AV27CliDsc3 ;
      private string AV28CliVendDsc3 ;
      private string AV92Pgmname ;
      private string AV34TFCliCod ;
      private string AV35TFCliCod_Sel ;
      private string AV36TFCliDsc ;
      private string AV37TFCliDsc_Sel ;
      private string AV38TFCliDir ;
      private string AV39TFCliDir_Sel ;
      private string AV40TFEstCod ;
      private string AV41TFEstCod_Sel ;
      private string AV42TFPaiCod ;
      private string AV43TFPaiCod_Sel ;
      private string AV44TFCliTel1 ;
      private string AV45TFCliTel1_Sel ;
      private string AV46TFCliTel2 ;
      private string AV47TFCliTel2_Sel ;
      private string AV48TFCliFax ;
      private string AV49TFCliFax_Sel ;
      private string AV50TFCliCel ;
      private string AV51TFCliCel_Sel ;
      private string AV54TFCliWeb ;
      private string AV55TFCliWeb_Sel ;
      private string AV66TFCliVendDsc ;
      private string AV67TFCliVendDsc_Sel ;
      private string AV68TFCliRef1 ;
      private string AV69TFCliRef1_Sel ;
      private string AV70TFCliRef2 ;
      private string AV71TFCliRef2_Sel ;
      private string AV72TFCliRef3 ;
      private string AV73TFCliRef3_Sel ;
      private string AV74TFCliRef4 ;
      private string AV75TFCliRef4_Sel ;
      private string AV76TFCliRef5 ;
      private string AV77TFCliRef5_Sel ;
      private string AV78TFCliRef6 ;
      private string AV79TFCliRef6_Sel ;
      private string AV80TFCliRef7 ;
      private string AV81TFCliRef7_Sel ;
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
      private string A45CliCod ;
      private string A161CliDsc ;
      private string edtCliDsc_Link ;
      private string A596CliDir ;
      private string A140EstCod ;
      private string A139PaiCod ;
      private string A629CliTel1 ;
      private string A630CliTel2 ;
      private string A611CliFax ;
      private string A575CliCel ;
      private string A637CliWeb ;
      private string A635CliVendDsc ;
      private string edtCliVendDsc_Link ;
      private string A618CliRef1 ;
      private string A619CliRef2 ;
      private string A620CliRef3 ;
      private string A621CliRef4 ;
      private string A622CliRef5 ;
      private string A623CliRef6 ;
      private string A624CliRef7 ;
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
      private string edtCliCod_Internalname ;
      private string edtCliDsc_Internalname ;
      private string edtCliDir_Internalname ;
      private string edtEstCod_Internalname ;
      private string edtPaiCod_Internalname ;
      private string edtCliTel1_Internalname ;
      private string edtCliTel2_Internalname ;
      private string edtCliFax_Internalname ;
      private string edtCliCel_Internalname ;
      private string edtCliEma_Internalname ;
      private string edtCliWeb_Internalname ;
      private string edtTipCCod_Internalname ;
      private string edtCliFoto_Internalname ;
      private string edtCliSts_Internalname ;
      private string edtConpcod_Internalname ;
      private string edtCliLim_Internalname ;
      private string edtCliVend_Internalname ;
      private string edtCliVendDsc_Internalname ;
      private string edtCliRef1_Internalname ;
      private string edtCliRef2_Internalname ;
      private string edtCliRef3_Internalname ;
      private string edtCliRef4_Internalname ;
      private string edtCliRef5_Internalname ;
      private string edtCliRef6_Internalname ;
      private string edtCliRef7_Internalname ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV95Ventas_clienteswwds_3_clidsc1 ;
      private string lV96Ventas_clienteswwds_4_clivenddsc1 ;
      private string lV100Ventas_clienteswwds_8_clidsc2 ;
      private string lV101Ventas_clienteswwds_9_clivenddsc2 ;
      private string lV105Ventas_clienteswwds_13_clidsc3 ;
      private string lV106Ventas_clienteswwds_14_clivenddsc3 ;
      private string lV107Ventas_clienteswwds_15_tfclicod ;
      private string lV109Ventas_clienteswwds_17_tfclidsc ;
      private string lV111Ventas_clienteswwds_19_tfclidir ;
      private string lV113Ventas_clienteswwds_21_tfestcod ;
      private string lV115Ventas_clienteswwds_23_tfpaicod ;
      private string lV117Ventas_clienteswwds_25_tfclitel1 ;
      private string lV119Ventas_clienteswwds_27_tfclitel2 ;
      private string lV121Ventas_clienteswwds_29_tfclifax ;
      private string lV123Ventas_clienteswwds_31_tfclicel ;
      private string lV127Ventas_clienteswwds_35_tfcliweb ;
      private string lV139Ventas_clienteswwds_47_tfclivenddsc ;
      private string lV141Ventas_clienteswwds_49_tfcliref1 ;
      private string lV143Ventas_clienteswwds_51_tfcliref2 ;
      private string lV145Ventas_clienteswwds_53_tfcliref3 ;
      private string lV147Ventas_clienteswwds_55_tfcliref4 ;
      private string lV149Ventas_clienteswwds_57_tfcliref5 ;
      private string lV151Ventas_clienteswwds_59_tfcliref6 ;
      private string lV153Ventas_clienteswwds_61_tfcliref7 ;
      private string AV95Ventas_clienteswwds_3_clidsc1 ;
      private string AV96Ventas_clienteswwds_4_clivenddsc1 ;
      private string AV100Ventas_clienteswwds_8_clidsc2 ;
      private string AV101Ventas_clienteswwds_9_clivenddsc2 ;
      private string AV105Ventas_clienteswwds_13_clidsc3 ;
      private string AV106Ventas_clienteswwds_14_clivenddsc3 ;
      private string AV108Ventas_clienteswwds_16_tfclicod_sel ;
      private string AV107Ventas_clienteswwds_15_tfclicod ;
      private string AV110Ventas_clienteswwds_18_tfclidsc_sel ;
      private string AV109Ventas_clienteswwds_17_tfclidsc ;
      private string AV112Ventas_clienteswwds_20_tfclidir_sel ;
      private string AV111Ventas_clienteswwds_19_tfclidir ;
      private string AV114Ventas_clienteswwds_22_tfestcod_sel ;
      private string AV113Ventas_clienteswwds_21_tfestcod ;
      private string AV116Ventas_clienteswwds_24_tfpaicod_sel ;
      private string AV115Ventas_clienteswwds_23_tfpaicod ;
      private string AV118Ventas_clienteswwds_26_tfclitel1_sel ;
      private string AV117Ventas_clienteswwds_25_tfclitel1 ;
      private string AV120Ventas_clienteswwds_28_tfclitel2_sel ;
      private string AV119Ventas_clienteswwds_27_tfclitel2 ;
      private string AV122Ventas_clienteswwds_30_tfclifax_sel ;
      private string AV121Ventas_clienteswwds_29_tfclifax ;
      private string AV124Ventas_clienteswwds_32_tfclicel_sel ;
      private string AV123Ventas_clienteswwds_31_tfclicel ;
      private string AV128Ventas_clienteswwds_36_tfcliweb_sel ;
      private string AV127Ventas_clienteswwds_35_tfcliweb ;
      private string AV140Ventas_clienteswwds_48_tfclivenddsc_sel ;
      private string AV139Ventas_clienteswwds_47_tfclivenddsc ;
      private string AV142Ventas_clienteswwds_50_tfcliref1_sel ;
      private string AV141Ventas_clienteswwds_49_tfcliref1 ;
      private string AV144Ventas_clienteswwds_52_tfcliref2_sel ;
      private string AV143Ventas_clienteswwds_51_tfcliref2 ;
      private string AV146Ventas_clienteswwds_54_tfcliref3_sel ;
      private string AV145Ventas_clienteswwds_53_tfcliref3 ;
      private string AV148Ventas_clienteswwds_56_tfcliref4_sel ;
      private string AV147Ventas_clienteswwds_55_tfcliref4 ;
      private string AV150Ventas_clienteswwds_58_tfcliref5_sel ;
      private string AV149Ventas_clienteswwds_57_tfcliref5 ;
      private string AV152Ventas_clienteswwds_60_tfcliref6_sel ;
      private string AV151Ventas_clienteswwds_59_tfcliref6 ;
      private string AV154Ventas_clienteswwds_62_tfcliref7_sel ;
      private string AV153Ventas_clienteswwds_61_tfcliref7 ;
      private string edtavClidsc1_Internalname ;
      private string edtavClivenddsc1_Internalname ;
      private string edtavClidsc2_Internalname ;
      private string edtavClivenddsc2_Internalname ;
      private string edtavClidsc3_Internalname ;
      private string edtavClivenddsc3_Internalname ;
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
      private string GXt_char20 ;
      private string GXt_char19 ;
      private string GXt_char18 ;
      private string GXt_char17 ;
      private string GXt_char16 ;
      private string GXt_char15 ;
      private string GXt_char14 ;
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
      private string cellFilter_clidsc3_cell_Internalname ;
      private string edtavClidsc3_Jsonclick ;
      private string cellFilter_clivenddsc3_cell_Internalname ;
      private string edtavClivenddsc3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_clidsc2_cell_Internalname ;
      private string edtavClidsc2_Jsonclick ;
      private string cellFilter_clivenddsc2_cell_Internalname ;
      private string edtavClivenddsc2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_clidsc1_cell_Internalname ;
      private string edtavClidsc1_Jsonclick ;
      private string cellFilter_clivenddsc1_cell_Internalname ;
      private string edtavClivenddsc1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCliCod_Jsonclick ;
      private string edtCliDsc_Jsonclick ;
      private string edtCliDir_Jsonclick ;
      private string edtEstCod_Jsonclick ;
      private string edtPaiCod_Jsonclick ;
      private string edtCliTel1_Jsonclick ;
      private string edtCliTel2_Jsonclick ;
      private string edtCliFax_Jsonclick ;
      private string edtCliCel_Jsonclick ;
      private string edtCliEma_Jsonclick ;
      private string edtCliWeb_Jsonclick ;
      private string edtTipCCod_Jsonclick ;
      private string edtCliSts_Jsonclick ;
      private string edtConpcod_Jsonclick ;
      private string edtCliLim_Jsonclick ;
      private string edtCliVend_Jsonclick ;
      private string edtCliVendDsc_Jsonclick ;
      private string edtCliRef1_Jsonclick ;
      private string edtCliRef2_Jsonclick ;
      private string edtCliRef3_Jsonclick ;
      private string edtCliRef4_Jsonclick ;
      private string edtCliRef5_Jsonclick ;
      private string edtCliRef6_Jsonclick ;
      private string edtCliRef7_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV14OrderedDsc ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
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
      private bool n612CliFoto ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 ;
      private bool n40000CliFoto_GXI ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A612CliFoto_IsBlob ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV52TFCliEma ;
      private string AV53TFCliEma_Sel ;
      private string AV86GridAppliedFilters ;
      private string A609CliEma ;
      private string A40000CliFoto_GXI ;
      private string lV125Ventas_clienteswwds_33_tfcliema ;
      private string AV93Ventas_clienteswwds_1_dynamicfiltersselector1 ;
      private string AV98Ventas_clienteswwds_6_dynamicfiltersselector2 ;
      private string AV103Ventas_clienteswwds_11_dynamicfiltersselector3 ;
      private string AV126Ventas_clienteswwds_34_tfcliema_sel ;
      private string AV125Ventas_clienteswwds_33_tfcliema ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private string A612CliFoto ;
      private IGxSession AV33Session ;
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
      private IDataStoreProvider pr_default ;
      private string[] H00782_A624CliRef7 ;
      private string[] H00782_A623CliRef6 ;
      private string[] H00782_A622CliRef5 ;
      private string[] H00782_A621CliRef4 ;
      private string[] H00782_A620CliRef3 ;
      private string[] H00782_A619CliRef2 ;
      private string[] H00782_A618CliRef1 ;
      private string[] H00782_A635CliVendDsc ;
      private int[] H00782_A160CliVend ;
      private decimal[] H00782_A613CliLim ;
      private int[] H00782_A137Conpcod ;
      private short[] H00782_A627CliSts ;
      private string[] H00782_A40000CliFoto_GXI ;
      private bool[] H00782_n40000CliFoto_GXI ;
      private int[] H00782_A159TipCCod ;
      private string[] H00782_A637CliWeb ;
      private string[] H00782_A609CliEma ;
      private string[] H00782_A575CliCel ;
      private string[] H00782_A611CliFax ;
      private string[] H00782_A630CliTel2 ;
      private string[] H00782_A629CliTel1 ;
      private string[] H00782_A139PaiCod ;
      private string[] H00782_A140EstCod ;
      private string[] H00782_A596CliDir ;
      private string[] H00782_A161CliDsc ;
      private string[] H00782_A45CliCod ;
      private string[] H00782_A612CliFoto ;
      private bool[] H00782_n612CliFoto ;
      private long[] H00783_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV88AGExportData ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV82DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV89AGExportDataItem ;
   }

   public class clientesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00782( IGxContext context ,
                                             string AV93Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                             short AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                             string AV95Ventas_clienteswwds_3_clidsc1 ,
                                             string AV96Ventas_clienteswwds_4_clivenddsc1 ,
                                             bool AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV98Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV100Ventas_clienteswwds_8_clidsc2 ,
                                             string AV101Ventas_clienteswwds_9_clivenddsc2 ,
                                             bool AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                             string AV103Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                             short AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                             string AV105Ventas_clienteswwds_13_clidsc3 ,
                                             string AV106Ventas_clienteswwds_14_clivenddsc3 ,
                                             string AV108Ventas_clienteswwds_16_tfclicod_sel ,
                                             string AV107Ventas_clienteswwds_15_tfclicod ,
                                             string AV110Ventas_clienteswwds_18_tfclidsc_sel ,
                                             string AV109Ventas_clienteswwds_17_tfclidsc ,
                                             string AV112Ventas_clienteswwds_20_tfclidir_sel ,
                                             string AV111Ventas_clienteswwds_19_tfclidir ,
                                             string AV114Ventas_clienteswwds_22_tfestcod_sel ,
                                             string AV113Ventas_clienteswwds_21_tfestcod ,
                                             string AV116Ventas_clienteswwds_24_tfpaicod_sel ,
                                             string AV115Ventas_clienteswwds_23_tfpaicod ,
                                             string AV118Ventas_clienteswwds_26_tfclitel1_sel ,
                                             string AV117Ventas_clienteswwds_25_tfclitel1 ,
                                             string AV120Ventas_clienteswwds_28_tfclitel2_sel ,
                                             string AV119Ventas_clienteswwds_27_tfclitel2 ,
                                             string AV122Ventas_clienteswwds_30_tfclifax_sel ,
                                             string AV121Ventas_clienteswwds_29_tfclifax ,
                                             string AV124Ventas_clienteswwds_32_tfclicel_sel ,
                                             string AV123Ventas_clienteswwds_31_tfclicel ,
                                             string AV126Ventas_clienteswwds_34_tfcliema_sel ,
                                             string AV125Ventas_clienteswwds_33_tfcliema ,
                                             string AV128Ventas_clienteswwds_36_tfcliweb_sel ,
                                             string AV127Ventas_clienteswwds_35_tfcliweb ,
                                             int AV129Ventas_clienteswwds_37_tftipccod ,
                                             int AV130Ventas_clienteswwds_38_tftipccod_to ,
                                             short AV131Ventas_clienteswwds_39_tfclists ,
                                             short AV132Ventas_clienteswwds_40_tfclists_to ,
                                             int AV133Ventas_clienteswwds_41_tfconpcod ,
                                             int AV134Ventas_clienteswwds_42_tfconpcod_to ,
                                             decimal AV135Ventas_clienteswwds_43_tfclilim ,
                                             decimal AV136Ventas_clienteswwds_44_tfclilim_to ,
                                             int AV137Ventas_clienteswwds_45_tfclivend ,
                                             int AV138Ventas_clienteswwds_46_tfclivend_to ,
                                             string AV140Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                             string AV139Ventas_clienteswwds_47_tfclivenddsc ,
                                             string AV142Ventas_clienteswwds_50_tfcliref1_sel ,
                                             string AV141Ventas_clienteswwds_49_tfcliref1 ,
                                             string AV144Ventas_clienteswwds_52_tfcliref2_sel ,
                                             string AV143Ventas_clienteswwds_51_tfcliref2 ,
                                             string AV146Ventas_clienteswwds_54_tfcliref3_sel ,
                                             string AV145Ventas_clienteswwds_53_tfcliref3 ,
                                             string AV148Ventas_clienteswwds_56_tfcliref4_sel ,
                                             string AV147Ventas_clienteswwds_55_tfcliref4 ,
                                             string AV150Ventas_clienteswwds_58_tfcliref5_sel ,
                                             string AV149Ventas_clienteswwds_57_tfcliref5 ,
                                             string AV152Ventas_clienteswwds_60_tfcliref6_sel ,
                                             string AV151Ventas_clienteswwds_59_tfcliref6 ,
                                             string AV154Ventas_clienteswwds_62_tfcliref7_sel ,
                                             string AV153Ventas_clienteswwds_61_tfcliref7 ,
                                             string A161CliDsc ,
                                             string A635CliVendDsc ,
                                             string A45CliCod ,
                                             string A596CliDir ,
                                             string A140EstCod ,
                                             string A139PaiCod ,
                                             string A629CliTel1 ,
                                             string A630CliTel2 ,
                                             string A611CliFax ,
                                             string A575CliCel ,
                                             string A609CliEma ,
                                             string A637CliWeb ,
                                             int A159TipCCod ,
                                             short A627CliSts ,
                                             int A137Conpcod ,
                                             decimal A613CliLim ,
                                             int A160CliVend ,
                                             string A618CliRef1 ,
                                             string A619CliRef2 ,
                                             string A620CliRef3 ,
                                             string A621CliRef4 ,
                                             string A622CliRef5 ,
                                             string A623CliRef6 ,
                                             string A624CliRef7 ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int21 = new short[63];
         Object[] GXv_Object22 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[CliRef7], T1.[CliRef6], T1.[CliRef5], T1.[CliRef4], T1.[CliRef3], T1.[CliRef2], T1.[CliRef1], T2.[VenDsc] AS CliVendDsc, T1.[CliVend] AS CliVend, T1.[CliLim], T1.[Conpcod], T1.[CliSts], T1.[CliFoto_GXI], T1.[TipCCod], T1.[CliWeb], T1.[CliEma], T1.[CliCel], T1.[CliFax], T1.[CliTel2], T1.[CliTel1], T1.[PaiCod], T1.[EstCod], T1.[CliDir], T1.[CliDsc], T1.[CliCod], T1.[CliFoto]";
         sFromString = " FROM ([CLCLIENTES] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CliVend])";
         sOrderString = "";
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV95Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int21[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV95Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int21[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV96Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int21[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV96Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int21[3] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV100Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int21[4] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV100Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int21[5] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV101Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int21[6] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV101Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int21[7] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV105Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int21[8] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV105Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int21[9] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV106Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int21[10] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV106Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int21[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_16_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_15_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV107Ventas_clienteswwds_15_tfclicod)");
         }
         else
         {
            GXv_int21[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_16_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV108Ventas_clienteswwds_16_tfclicod_sel)");
         }
         else
         {
            GXv_int21[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Ventas_clienteswwds_18_tfclidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Ventas_clienteswwds_17_tfclidsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV109Ventas_clienteswwds_17_tfclidsc)");
         }
         else
         {
            GXv_int21[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Ventas_clienteswwds_18_tfclidsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] = @AV110Ventas_clienteswwds_18_tfclidsc_sel)");
         }
         else
         {
            GXv_int21[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_20_tfclidir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Ventas_clienteswwds_19_tfclidir)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] like @lV111Ventas_clienteswwds_19_tfclidir)");
         }
         else
         {
            GXv_int21[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_20_tfclidir_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] = @AV112Ventas_clienteswwds_20_tfclidir_sel)");
         }
         else
         {
            GXv_int21[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Ventas_clienteswwds_22_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_21_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV113Ventas_clienteswwds_21_tfestcod)");
         }
         else
         {
            GXv_int21[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Ventas_clienteswwds_22_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV114Ventas_clienteswwds_22_tfestcod_sel)");
         }
         else
         {
            GXv_int21[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Ventas_clienteswwds_24_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Ventas_clienteswwds_23_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV115Ventas_clienteswwds_23_tfpaicod)");
         }
         else
         {
            GXv_int21[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Ventas_clienteswwds_24_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] = @AV116Ventas_clienteswwds_24_tfpaicod_sel)");
         }
         else
         {
            GXv_int21[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_26_tfclitel1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_25_tfclitel1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] like @lV117Ventas_clienteswwds_25_tfclitel1)");
         }
         else
         {
            GXv_int21[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_26_tfclitel1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] = @AV118Ventas_clienteswwds_26_tfclitel1_sel)");
         }
         else
         {
            GXv_int21[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_28_tfclitel2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Ventas_clienteswwds_27_tfclitel2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] like @lV119Ventas_clienteswwds_27_tfclitel2)");
         }
         else
         {
            GXv_int21[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_28_tfclitel2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] = @AV120Ventas_clienteswwds_28_tfclitel2_sel)");
         }
         else
         {
            GXv_int21[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_30_tfclifax_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Ventas_clienteswwds_29_tfclifax)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] like @lV121Ventas_clienteswwds_29_tfclifax)");
         }
         else
         {
            GXv_int21[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_30_tfclifax_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] = @AV122Ventas_clienteswwds_30_tfclifax_sel)");
         }
         else
         {
            GXv_int21[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_32_tfclicel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Ventas_clienteswwds_31_tfclicel)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] like @lV123Ventas_clienteswwds_31_tfclicel)");
         }
         else
         {
            GXv_int21[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_32_tfclicel_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] = @AV124Ventas_clienteswwds_32_tfclicel_sel)");
         }
         else
         {
            GXv_int21[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_34_tfcliema_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Ventas_clienteswwds_33_tfcliema)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] like @lV125Ventas_clienteswwds_33_tfcliema)");
         }
         else
         {
            GXv_int21[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_34_tfcliema_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] = @AV126Ventas_clienteswwds_34_tfcliema_sel)");
         }
         else
         {
            GXv_int21[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_36_tfcliweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Ventas_clienteswwds_35_tfcliweb)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] like @lV127Ventas_clienteswwds_35_tfcliweb)");
         }
         else
         {
            GXv_int21[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_36_tfcliweb_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] = @AV128Ventas_clienteswwds_36_tfcliweb_sel)");
         }
         else
         {
            GXv_int21[33] = 1;
         }
         if ( ! (0==AV129Ventas_clienteswwds_37_tftipccod) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] >= @AV129Ventas_clienteswwds_37_tftipccod)");
         }
         else
         {
            GXv_int21[34] = 1;
         }
         if ( ! (0==AV130Ventas_clienteswwds_38_tftipccod_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] <= @AV130Ventas_clienteswwds_38_tftipccod_to)");
         }
         else
         {
            GXv_int21[35] = 1;
         }
         if ( ! (0==AV131Ventas_clienteswwds_39_tfclists) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] >= @AV131Ventas_clienteswwds_39_tfclists)");
         }
         else
         {
            GXv_int21[36] = 1;
         }
         if ( ! (0==AV132Ventas_clienteswwds_40_tfclists_to) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] <= @AV132Ventas_clienteswwds_40_tfclists_to)");
         }
         else
         {
            GXv_int21[37] = 1;
         }
         if ( ! (0==AV133Ventas_clienteswwds_41_tfconpcod) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] >= @AV133Ventas_clienteswwds_41_tfconpcod)");
         }
         else
         {
            GXv_int21[38] = 1;
         }
         if ( ! (0==AV134Ventas_clienteswwds_42_tfconpcod_to) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] <= @AV134Ventas_clienteswwds_42_tfconpcod_to)");
         }
         else
         {
            GXv_int21[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Ventas_clienteswwds_43_tfclilim) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] >= @AV135Ventas_clienteswwds_43_tfclilim)");
         }
         else
         {
            GXv_int21[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Ventas_clienteswwds_44_tfclilim_to) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] <= @AV136Ventas_clienteswwds_44_tfclilim_to)");
         }
         else
         {
            GXv_int21[41] = 1;
         }
         if ( ! (0==AV137Ventas_clienteswwds_45_tfclivend) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] >= @AV137Ventas_clienteswwds_45_tfclivend)");
         }
         else
         {
            GXv_int21[42] = 1;
         }
         if ( ! (0==AV138Ventas_clienteswwds_46_tfclivend_to) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] <= @AV138Ventas_clienteswwds_46_tfclivend_to)");
         }
         else
         {
            GXv_int21[43] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_48_tfclivenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Ventas_clienteswwds_47_tfclivenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV139Ventas_clienteswwds_47_tfclivenddsc)");
         }
         else
         {
            GXv_int21[44] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_48_tfclivenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV140Ventas_clienteswwds_48_tfclivenddsc_sel)");
         }
         else
         {
            GXv_int21[45] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV142Ventas_clienteswwds_50_tfcliref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Ventas_clienteswwds_49_tfcliref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] like @lV141Ventas_clienteswwds_49_tfcliref1)");
         }
         else
         {
            GXv_int21[46] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Ventas_clienteswwds_50_tfcliref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] = @AV142Ventas_clienteswwds_50_tfcliref1_sel)");
         }
         else
         {
            GXv_int21[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Ventas_clienteswwds_52_tfcliref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Ventas_clienteswwds_51_tfcliref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] like @lV143Ventas_clienteswwds_51_tfcliref2)");
         }
         else
         {
            GXv_int21[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Ventas_clienteswwds_52_tfcliref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] = @AV144Ventas_clienteswwds_52_tfcliref2_sel)");
         }
         else
         {
            GXv_int21[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV146Ventas_clienteswwds_54_tfcliref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Ventas_clienteswwds_53_tfcliref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] like @lV145Ventas_clienteswwds_53_tfcliref3)");
         }
         else
         {
            GXv_int21[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Ventas_clienteswwds_54_tfcliref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] = @AV146Ventas_clienteswwds_54_tfcliref3_sel)");
         }
         else
         {
            GXv_int21[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV148Ventas_clienteswwds_56_tfcliref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Ventas_clienteswwds_55_tfcliref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] like @lV147Ventas_clienteswwds_55_tfcliref4)");
         }
         else
         {
            GXv_int21[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Ventas_clienteswwds_56_tfcliref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] = @AV148Ventas_clienteswwds_56_tfcliref4_sel)");
         }
         else
         {
            GXv_int21[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Ventas_clienteswwds_58_tfcliref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Ventas_clienteswwds_57_tfcliref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] like @lV149Ventas_clienteswwds_57_tfcliref5)");
         }
         else
         {
            GXv_int21[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Ventas_clienteswwds_58_tfcliref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] = @AV150Ventas_clienteswwds_58_tfcliref5_sel)");
         }
         else
         {
            GXv_int21[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_60_tfcliref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Ventas_clienteswwds_59_tfcliref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] like @lV151Ventas_clienteswwds_59_tfcliref6)");
         }
         else
         {
            GXv_int21[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_60_tfcliref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] = @AV152Ventas_clienteswwds_60_tfcliref6_sel)");
         }
         else
         {
            GXv_int21[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_62_tfcliref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Ventas_clienteswwds_61_tfcliref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] like @lV153Ventas_clienteswwds_61_tfcliref7)");
         }
         else
         {
            GXv_int21[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_62_tfcliref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] = @AV154Ventas_clienteswwds_62_tfcliref7_sel)");
         }
         else
         {
            GXv_int21[59] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliDsc]";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliCod]";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliCod] DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliDir]";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliDir] DESC";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[EstCod]";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[EstCod] DESC";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PaiCod]";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PaiCod] DESC";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliTel1]";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliTel1] DESC";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliTel2]";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliTel2] DESC";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliFax]";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliFax] DESC";
         }
         else if ( ( AV13OrderedBy == 9 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliCel]";
         }
         else if ( ( AV13OrderedBy == 9 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliCel] DESC";
         }
         else if ( ( AV13OrderedBy == 10 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliEma]";
         }
         else if ( ( AV13OrderedBy == 10 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliEma] DESC";
         }
         else if ( ( AV13OrderedBy == 11 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliWeb]";
         }
         else if ( ( AV13OrderedBy == 11 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliWeb] DESC";
         }
         else if ( ( AV13OrderedBy == 12 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[TipCCod]";
         }
         else if ( ( AV13OrderedBy == 12 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[TipCCod] DESC";
         }
         else if ( ( AV13OrderedBy == 13 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliSts]";
         }
         else if ( ( AV13OrderedBy == 13 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliSts] DESC";
         }
         else if ( ( AV13OrderedBy == 14 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[Conpcod]";
         }
         else if ( ( AV13OrderedBy == 14 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[Conpcod] DESC";
         }
         else if ( ( AV13OrderedBy == 15 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliLim]";
         }
         else if ( ( AV13OrderedBy == 15 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliLim] DESC";
         }
         else if ( ( AV13OrderedBy == 16 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliVend]";
         }
         else if ( ( AV13OrderedBy == 16 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliVend] DESC";
         }
         else if ( ( AV13OrderedBy == 17 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV13OrderedBy == 17 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV13OrderedBy == 18 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef1]";
         }
         else if ( ( AV13OrderedBy == 18 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef1] DESC";
         }
         else if ( ( AV13OrderedBy == 19 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef2]";
         }
         else if ( ( AV13OrderedBy == 19 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef2] DESC";
         }
         else if ( ( AV13OrderedBy == 20 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef3]";
         }
         else if ( ( AV13OrderedBy == 20 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef3] DESC";
         }
         else if ( ( AV13OrderedBy == 21 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef4]";
         }
         else if ( ( AV13OrderedBy == 21 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef4] DESC";
         }
         else if ( ( AV13OrderedBy == 22 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef5]";
         }
         else if ( ( AV13OrderedBy == 22 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef5] DESC";
         }
         else if ( ( AV13OrderedBy == 23 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef6]";
         }
         else if ( ( AV13OrderedBy == 23 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef6] DESC";
         }
         else if ( ( AV13OrderedBy == 24 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[CliRef7]";
         }
         else if ( ( AV13OrderedBy == 24 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[CliRef7] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[CliCod]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object22[0] = scmdbuf;
         GXv_Object22[1] = GXv_int21;
         return GXv_Object22 ;
      }

      protected Object[] conditional_H00783( IGxContext context ,
                                             string AV93Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                             short AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                             string AV95Ventas_clienteswwds_3_clidsc1 ,
                                             string AV96Ventas_clienteswwds_4_clivenddsc1 ,
                                             bool AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV98Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV100Ventas_clienteswwds_8_clidsc2 ,
                                             string AV101Ventas_clienteswwds_9_clivenddsc2 ,
                                             bool AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                             string AV103Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                             short AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                             string AV105Ventas_clienteswwds_13_clidsc3 ,
                                             string AV106Ventas_clienteswwds_14_clivenddsc3 ,
                                             string AV108Ventas_clienteswwds_16_tfclicod_sel ,
                                             string AV107Ventas_clienteswwds_15_tfclicod ,
                                             string AV110Ventas_clienteswwds_18_tfclidsc_sel ,
                                             string AV109Ventas_clienteswwds_17_tfclidsc ,
                                             string AV112Ventas_clienteswwds_20_tfclidir_sel ,
                                             string AV111Ventas_clienteswwds_19_tfclidir ,
                                             string AV114Ventas_clienteswwds_22_tfestcod_sel ,
                                             string AV113Ventas_clienteswwds_21_tfestcod ,
                                             string AV116Ventas_clienteswwds_24_tfpaicod_sel ,
                                             string AV115Ventas_clienteswwds_23_tfpaicod ,
                                             string AV118Ventas_clienteswwds_26_tfclitel1_sel ,
                                             string AV117Ventas_clienteswwds_25_tfclitel1 ,
                                             string AV120Ventas_clienteswwds_28_tfclitel2_sel ,
                                             string AV119Ventas_clienteswwds_27_tfclitel2 ,
                                             string AV122Ventas_clienteswwds_30_tfclifax_sel ,
                                             string AV121Ventas_clienteswwds_29_tfclifax ,
                                             string AV124Ventas_clienteswwds_32_tfclicel_sel ,
                                             string AV123Ventas_clienteswwds_31_tfclicel ,
                                             string AV126Ventas_clienteswwds_34_tfcliema_sel ,
                                             string AV125Ventas_clienteswwds_33_tfcliema ,
                                             string AV128Ventas_clienteswwds_36_tfcliweb_sel ,
                                             string AV127Ventas_clienteswwds_35_tfcliweb ,
                                             int AV129Ventas_clienteswwds_37_tftipccod ,
                                             int AV130Ventas_clienteswwds_38_tftipccod_to ,
                                             short AV131Ventas_clienteswwds_39_tfclists ,
                                             short AV132Ventas_clienteswwds_40_tfclists_to ,
                                             int AV133Ventas_clienteswwds_41_tfconpcod ,
                                             int AV134Ventas_clienteswwds_42_tfconpcod_to ,
                                             decimal AV135Ventas_clienteswwds_43_tfclilim ,
                                             decimal AV136Ventas_clienteswwds_44_tfclilim_to ,
                                             int AV137Ventas_clienteswwds_45_tfclivend ,
                                             int AV138Ventas_clienteswwds_46_tfclivend_to ,
                                             string AV140Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                             string AV139Ventas_clienteswwds_47_tfclivenddsc ,
                                             string AV142Ventas_clienteswwds_50_tfcliref1_sel ,
                                             string AV141Ventas_clienteswwds_49_tfcliref1 ,
                                             string AV144Ventas_clienteswwds_52_tfcliref2_sel ,
                                             string AV143Ventas_clienteswwds_51_tfcliref2 ,
                                             string AV146Ventas_clienteswwds_54_tfcliref3_sel ,
                                             string AV145Ventas_clienteswwds_53_tfcliref3 ,
                                             string AV148Ventas_clienteswwds_56_tfcliref4_sel ,
                                             string AV147Ventas_clienteswwds_55_tfcliref4 ,
                                             string AV150Ventas_clienteswwds_58_tfcliref5_sel ,
                                             string AV149Ventas_clienteswwds_57_tfcliref5 ,
                                             string AV152Ventas_clienteswwds_60_tfcliref6_sel ,
                                             string AV151Ventas_clienteswwds_59_tfcliref6 ,
                                             string AV154Ventas_clienteswwds_62_tfcliref7_sel ,
                                             string AV153Ventas_clienteswwds_61_tfcliref7 ,
                                             string A161CliDsc ,
                                             string A635CliVendDsc ,
                                             string A45CliCod ,
                                             string A596CliDir ,
                                             string A140EstCod ,
                                             string A139PaiCod ,
                                             string A629CliTel1 ,
                                             string A630CliTel2 ,
                                             string A611CliFax ,
                                             string A575CliCel ,
                                             string A609CliEma ,
                                             string A637CliWeb ,
                                             int A159TipCCod ,
                                             short A627CliSts ,
                                             int A137Conpcod ,
                                             decimal A613CliLim ,
                                             int A160CliVend ,
                                             string A618CliRef1 ,
                                             string A619CliRef2 ,
                                             string A620CliRef3 ,
                                             string A621CliRef4 ,
                                             string A622CliRef5 ,
                                             string A623CliRef6 ,
                                             string A624CliRef7 ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int23 = new short[60];
         Object[] GXv_Object24 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([CLCLIENTES] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CliVend])";
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV95Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int23[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Ventas_clienteswwds_3_clidsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV95Ventas_clienteswwds_3_clidsc1)");
         }
         else
         {
            GXv_int23[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV96Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int23[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV93Ventas_clienteswwds_1_dynamicfiltersselector1, "CLIVENDDSC") == 0 ) && ( AV94Ventas_clienteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Ventas_clienteswwds_4_clivenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV96Ventas_clienteswwds_4_clivenddsc1)");
         }
         else
         {
            GXv_int23[3] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV100Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int23[4] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Ventas_clienteswwds_8_clidsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV100Ventas_clienteswwds_8_clidsc2)");
         }
         else
         {
            GXv_int23[5] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV101Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int23[6] = 1;
         }
         if ( AV97Ventas_clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV98Ventas_clienteswwds_6_dynamicfiltersselector2, "CLIVENDDSC") == 0 ) && ( AV99Ventas_clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Ventas_clienteswwds_9_clivenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV101Ventas_clienteswwds_9_clivenddsc2)");
         }
         else
         {
            GXv_int23[7] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV105Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int23[8] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Ventas_clienteswwds_13_clidsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like '%' + @lV105Ventas_clienteswwds_13_clidsc3)");
         }
         else
         {
            GXv_int23[9] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV106Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int23[10] = 1;
         }
         if ( AV102Ventas_clienteswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV103Ventas_clienteswwds_11_dynamicfiltersselector3, "CLIVENDDSC") == 0 ) && ( AV104Ventas_clienteswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Ventas_clienteswwds_14_clivenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV106Ventas_clienteswwds_14_clivenddsc3)");
         }
         else
         {
            GXv_int23[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_16_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Ventas_clienteswwds_15_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV107Ventas_clienteswwds_15_tfclicod)");
         }
         else
         {
            GXv_int23[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Ventas_clienteswwds_16_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV108Ventas_clienteswwds_16_tfclicod_sel)");
         }
         else
         {
            GXv_int23[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Ventas_clienteswwds_18_tfclidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Ventas_clienteswwds_17_tfclidsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] like @lV109Ventas_clienteswwds_17_tfclidsc)");
         }
         else
         {
            GXv_int23[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Ventas_clienteswwds_18_tfclidsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDsc] = @AV110Ventas_clienteswwds_18_tfclidsc_sel)");
         }
         else
         {
            GXv_int23[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_20_tfclidir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Ventas_clienteswwds_19_tfclidir)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] like @lV111Ventas_clienteswwds_19_tfclidir)");
         }
         else
         {
            GXv_int23[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Ventas_clienteswwds_20_tfclidir_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliDir] = @AV112Ventas_clienteswwds_20_tfclidir_sel)");
         }
         else
         {
            GXv_int23[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Ventas_clienteswwds_22_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Ventas_clienteswwds_21_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV113Ventas_clienteswwds_21_tfestcod)");
         }
         else
         {
            GXv_int23[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Ventas_clienteswwds_22_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV114Ventas_clienteswwds_22_tfestcod_sel)");
         }
         else
         {
            GXv_int23[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Ventas_clienteswwds_24_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Ventas_clienteswwds_23_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV115Ventas_clienteswwds_23_tfpaicod)");
         }
         else
         {
            GXv_int23[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Ventas_clienteswwds_24_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] = @AV116Ventas_clienteswwds_24_tfpaicod_sel)");
         }
         else
         {
            GXv_int23[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_26_tfclitel1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Ventas_clienteswwds_25_tfclitel1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] like @lV117Ventas_clienteswwds_25_tfclitel1)");
         }
         else
         {
            GXv_int23[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Ventas_clienteswwds_26_tfclitel1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel1] = @AV118Ventas_clienteswwds_26_tfclitel1_sel)");
         }
         else
         {
            GXv_int23[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_28_tfclitel2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Ventas_clienteswwds_27_tfclitel2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] like @lV119Ventas_clienteswwds_27_tfclitel2)");
         }
         else
         {
            GXv_int23[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Ventas_clienteswwds_28_tfclitel2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliTel2] = @AV120Ventas_clienteswwds_28_tfclitel2_sel)");
         }
         else
         {
            GXv_int23[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_30_tfclifax_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Ventas_clienteswwds_29_tfclifax)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] like @lV121Ventas_clienteswwds_29_tfclifax)");
         }
         else
         {
            GXv_int23[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Ventas_clienteswwds_30_tfclifax_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliFax] = @AV122Ventas_clienteswwds_30_tfclifax_sel)");
         }
         else
         {
            GXv_int23[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_32_tfclicel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Ventas_clienteswwds_31_tfclicel)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] like @lV123Ventas_clienteswwds_31_tfclicel)");
         }
         else
         {
            GXv_int23[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Ventas_clienteswwds_32_tfclicel_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCel] = @AV124Ventas_clienteswwds_32_tfclicel_sel)");
         }
         else
         {
            GXv_int23[29] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_34_tfcliema_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Ventas_clienteswwds_33_tfcliema)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] like @lV125Ventas_clienteswwds_33_tfcliema)");
         }
         else
         {
            GXv_int23[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Ventas_clienteswwds_34_tfcliema_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliEma] = @AV126Ventas_clienteswwds_34_tfcliema_sel)");
         }
         else
         {
            GXv_int23[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_36_tfcliweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Ventas_clienteswwds_35_tfcliweb)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] like @lV127Ventas_clienteswwds_35_tfcliweb)");
         }
         else
         {
            GXv_int23[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Ventas_clienteswwds_36_tfcliweb_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliWeb] = @AV128Ventas_clienteswwds_36_tfcliweb_sel)");
         }
         else
         {
            GXv_int23[33] = 1;
         }
         if ( ! (0==AV129Ventas_clienteswwds_37_tftipccod) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] >= @AV129Ventas_clienteswwds_37_tftipccod)");
         }
         else
         {
            GXv_int23[34] = 1;
         }
         if ( ! (0==AV130Ventas_clienteswwds_38_tftipccod_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCCod] <= @AV130Ventas_clienteswwds_38_tftipccod_to)");
         }
         else
         {
            GXv_int23[35] = 1;
         }
         if ( ! (0==AV131Ventas_clienteswwds_39_tfclists) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] >= @AV131Ventas_clienteswwds_39_tfclists)");
         }
         else
         {
            GXv_int23[36] = 1;
         }
         if ( ! (0==AV132Ventas_clienteswwds_40_tfclists_to) )
         {
            AddWhere(sWhereString, "(T1.[CliSts] <= @AV132Ventas_clienteswwds_40_tfclists_to)");
         }
         else
         {
            GXv_int23[37] = 1;
         }
         if ( ! (0==AV133Ventas_clienteswwds_41_tfconpcod) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] >= @AV133Ventas_clienteswwds_41_tfconpcod)");
         }
         else
         {
            GXv_int23[38] = 1;
         }
         if ( ! (0==AV134Ventas_clienteswwds_42_tfconpcod_to) )
         {
            AddWhere(sWhereString, "(T1.[Conpcod] <= @AV134Ventas_clienteswwds_42_tfconpcod_to)");
         }
         else
         {
            GXv_int23[39] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Ventas_clienteswwds_43_tfclilim) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] >= @AV135Ventas_clienteswwds_43_tfclilim)");
         }
         else
         {
            GXv_int23[40] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV136Ventas_clienteswwds_44_tfclilim_to) )
         {
            AddWhere(sWhereString, "(T1.[CliLim] <= @AV136Ventas_clienteswwds_44_tfclilim_to)");
         }
         else
         {
            GXv_int23[41] = 1;
         }
         if ( ! (0==AV137Ventas_clienteswwds_45_tfclivend) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] >= @AV137Ventas_clienteswwds_45_tfclivend)");
         }
         else
         {
            GXv_int23[42] = 1;
         }
         if ( ! (0==AV138Ventas_clienteswwds_46_tfclivend_to) )
         {
            AddWhere(sWhereString, "(T1.[CliVend] <= @AV138Ventas_clienteswwds_46_tfclivend_to)");
         }
         else
         {
            GXv_int23[43] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_48_tfclivenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Ventas_clienteswwds_47_tfclivenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV139Ventas_clienteswwds_47_tfclivenddsc)");
         }
         else
         {
            GXv_int23[44] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Ventas_clienteswwds_48_tfclivenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV140Ventas_clienteswwds_48_tfclivenddsc_sel)");
         }
         else
         {
            GXv_int23[45] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV142Ventas_clienteswwds_50_tfcliref1_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Ventas_clienteswwds_49_tfcliref1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] like @lV141Ventas_clienteswwds_49_tfcliref1)");
         }
         else
         {
            GXv_int23[46] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Ventas_clienteswwds_50_tfcliref1_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef1] = @AV142Ventas_clienteswwds_50_tfcliref1_sel)");
         }
         else
         {
            GXv_int23[47] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV144Ventas_clienteswwds_52_tfcliref2_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Ventas_clienteswwds_51_tfcliref2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] like @lV143Ventas_clienteswwds_51_tfcliref2)");
         }
         else
         {
            GXv_int23[48] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Ventas_clienteswwds_52_tfcliref2_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef2] = @AV144Ventas_clienteswwds_52_tfcliref2_sel)");
         }
         else
         {
            GXv_int23[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV146Ventas_clienteswwds_54_tfcliref3_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Ventas_clienteswwds_53_tfcliref3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] like @lV145Ventas_clienteswwds_53_tfcliref3)");
         }
         else
         {
            GXv_int23[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Ventas_clienteswwds_54_tfcliref3_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef3] = @AV146Ventas_clienteswwds_54_tfcliref3_sel)");
         }
         else
         {
            GXv_int23[51] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV148Ventas_clienteswwds_56_tfcliref4_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Ventas_clienteswwds_55_tfcliref4)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] like @lV147Ventas_clienteswwds_55_tfcliref4)");
         }
         else
         {
            GXv_int23[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Ventas_clienteswwds_56_tfcliref4_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef4] = @AV148Ventas_clienteswwds_56_tfcliref4_sel)");
         }
         else
         {
            GXv_int23[53] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Ventas_clienteswwds_58_tfcliref5_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Ventas_clienteswwds_57_tfcliref5)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] like @lV149Ventas_clienteswwds_57_tfcliref5)");
         }
         else
         {
            GXv_int23[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Ventas_clienteswwds_58_tfcliref5_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef5] = @AV150Ventas_clienteswwds_58_tfcliref5_sel)");
         }
         else
         {
            GXv_int23[55] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_60_tfcliref6_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Ventas_clienteswwds_59_tfcliref6)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] like @lV151Ventas_clienteswwds_59_tfcliref6)");
         }
         else
         {
            GXv_int23[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Ventas_clienteswwds_60_tfcliref6_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef6] = @AV152Ventas_clienteswwds_60_tfcliref6_sel)");
         }
         else
         {
            GXv_int23[57] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_62_tfcliref7_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Ventas_clienteswwds_61_tfcliref7)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] like @lV153Ventas_clienteswwds_61_tfcliref7)");
         }
         else
         {
            GXv_int23[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Ventas_clienteswwds_62_tfcliref7_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliRef7] = @AV154Ventas_clienteswwds_62_tfcliref7_sel)");
         }
         else
         {
            GXv_int23[59] = 1;
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
         GXv_Object24[0] = scmdbuf;
         GXv_Object24[1] = GXv_int23;
         return GXv_Object24 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00782(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (short)dynConstraints[75] , (int)dynConstraints[76] , (decimal)dynConstraints[77] , (int)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (short)dynConstraints[86] , (bool)dynConstraints[87] );
               case 1 :
                     return conditional_H00783(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (int)dynConstraints[37] , (short)dynConstraints[38] , (short)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (decimal)dynConstraints[42] , (decimal)dynConstraints[43] , (int)dynConstraints[44] , (int)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (short)dynConstraints[75] , (int)dynConstraints[76] , (decimal)dynConstraints[77] , (int)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (short)dynConstraints[86] , (bool)dynConstraints[87] );
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
          Object[] prmH00782;
          prmH00782 = new Object[] {
          new ParDef("@lV95Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV95Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV105Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV105Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV106Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV106Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV107Ventas_clienteswwds_15_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV108Ventas_clienteswwds_16_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV109Ventas_clienteswwds_17_tfclidsc",GXType.NChar,100,0) ,
          new ParDef("@AV110Ventas_clienteswwds_18_tfclidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV111Ventas_clienteswwds_19_tfclidir",GXType.NChar,100,0) ,
          new ParDef("@AV112Ventas_clienteswwds_20_tfclidir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV113Ventas_clienteswwds_21_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV114Ventas_clienteswwds_22_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV115Ventas_clienteswwds_23_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV116Ventas_clienteswwds_24_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV117Ventas_clienteswwds_25_tfclitel1",GXType.NChar,20,0) ,
          new ParDef("@AV118Ventas_clienteswwds_26_tfclitel1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV119Ventas_clienteswwds_27_tfclitel2",GXType.NChar,20,0) ,
          new ParDef("@AV120Ventas_clienteswwds_28_tfclitel2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV121Ventas_clienteswwds_29_tfclifax",GXType.NChar,20,0) ,
          new ParDef("@AV122Ventas_clienteswwds_30_tfclifax_sel",GXType.NChar,20,0) ,
          new ParDef("@lV123Ventas_clienteswwds_31_tfclicel",GXType.NChar,20,0) ,
          new ParDef("@AV124Ventas_clienteswwds_32_tfclicel_sel",GXType.NChar,20,0) ,
          new ParDef("@lV125Ventas_clienteswwds_33_tfcliema",GXType.NVarChar,100,0) ,
          new ParDef("@AV126Ventas_clienteswwds_34_tfcliema_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV127Ventas_clienteswwds_35_tfcliweb",GXType.NChar,50,0) ,
          new ParDef("@AV128Ventas_clienteswwds_36_tfcliweb_sel",GXType.NChar,50,0) ,
          new ParDef("@AV129Ventas_clienteswwds_37_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV130Ventas_clienteswwds_38_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@AV131Ventas_clienteswwds_39_tfclists",GXType.Int16,1,0) ,
          new ParDef("@AV132Ventas_clienteswwds_40_tfclists_to",GXType.Int16,1,0) ,
          new ParDef("@AV133Ventas_clienteswwds_41_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV134Ventas_clienteswwds_42_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV135Ventas_clienteswwds_43_tfclilim",GXType.Decimal,15,2) ,
          new ParDef("@AV136Ventas_clienteswwds_44_tfclilim_to",GXType.Decimal,15,2) ,
          new ParDef("@AV137Ventas_clienteswwds_45_tfclivend",GXType.Int32,6,0) ,
          new ParDef("@AV138Ventas_clienteswwds_46_tfclivend_to",GXType.Int32,6,0) ,
          new ParDef("@lV139Ventas_clienteswwds_47_tfclivenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV140Ventas_clienteswwds_48_tfclivenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV141Ventas_clienteswwds_49_tfcliref1",GXType.NChar,50,0) ,
          new ParDef("@AV142Ventas_clienteswwds_50_tfcliref1_sel",GXType.NChar,50,0) ,
          new ParDef("@lV143Ventas_clienteswwds_51_tfcliref2",GXType.NChar,50,0) ,
          new ParDef("@AV144Ventas_clienteswwds_52_tfcliref2_sel",GXType.NChar,50,0) ,
          new ParDef("@lV145Ventas_clienteswwds_53_tfcliref3",GXType.NChar,50,0) ,
          new ParDef("@AV146Ventas_clienteswwds_54_tfcliref3_sel",GXType.NChar,50,0) ,
          new ParDef("@lV147Ventas_clienteswwds_55_tfcliref4",GXType.NChar,50,0) ,
          new ParDef("@AV148Ventas_clienteswwds_56_tfcliref4_sel",GXType.NChar,50,0) ,
          new ParDef("@lV149Ventas_clienteswwds_57_tfcliref5",GXType.NChar,50,0) ,
          new ParDef("@AV150Ventas_clienteswwds_58_tfcliref5_sel",GXType.NChar,50,0) ,
          new ParDef("@lV151Ventas_clienteswwds_59_tfcliref6",GXType.NChar,50,0) ,
          new ParDef("@AV152Ventas_clienteswwds_60_tfcliref6_sel",GXType.NChar,50,0) ,
          new ParDef("@lV153Ventas_clienteswwds_61_tfcliref7",GXType.NChar,50,0) ,
          new ParDef("@AV154Ventas_clienteswwds_62_tfcliref7_sel",GXType.NChar,50,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00783;
          prmH00783 = new Object[] {
          new ParDef("@lV95Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV95Ventas_clienteswwds_3_clidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV96Ventas_clienteswwds_4_clivenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV100Ventas_clienteswwds_8_clidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV101Ventas_clienteswwds_9_clivenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV105Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV105Ventas_clienteswwds_13_clidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV106Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV106Ventas_clienteswwds_14_clivenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV107Ventas_clienteswwds_15_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV108Ventas_clienteswwds_16_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV109Ventas_clienteswwds_17_tfclidsc",GXType.NChar,100,0) ,
          new ParDef("@AV110Ventas_clienteswwds_18_tfclidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV111Ventas_clienteswwds_19_tfclidir",GXType.NChar,100,0) ,
          new ParDef("@AV112Ventas_clienteswwds_20_tfclidir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV113Ventas_clienteswwds_21_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV114Ventas_clienteswwds_22_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV115Ventas_clienteswwds_23_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV116Ventas_clienteswwds_24_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV117Ventas_clienteswwds_25_tfclitel1",GXType.NChar,20,0) ,
          new ParDef("@AV118Ventas_clienteswwds_26_tfclitel1_sel",GXType.NChar,20,0) ,
          new ParDef("@lV119Ventas_clienteswwds_27_tfclitel2",GXType.NChar,20,0) ,
          new ParDef("@AV120Ventas_clienteswwds_28_tfclitel2_sel",GXType.NChar,20,0) ,
          new ParDef("@lV121Ventas_clienteswwds_29_tfclifax",GXType.NChar,20,0) ,
          new ParDef("@AV122Ventas_clienteswwds_30_tfclifax_sel",GXType.NChar,20,0) ,
          new ParDef("@lV123Ventas_clienteswwds_31_tfclicel",GXType.NChar,20,0) ,
          new ParDef("@AV124Ventas_clienteswwds_32_tfclicel_sel",GXType.NChar,20,0) ,
          new ParDef("@lV125Ventas_clienteswwds_33_tfcliema",GXType.NVarChar,100,0) ,
          new ParDef("@AV126Ventas_clienteswwds_34_tfcliema_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV127Ventas_clienteswwds_35_tfcliweb",GXType.NChar,50,0) ,
          new ParDef("@AV128Ventas_clienteswwds_36_tfcliweb_sel",GXType.NChar,50,0) ,
          new ParDef("@AV129Ventas_clienteswwds_37_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV130Ventas_clienteswwds_38_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@AV131Ventas_clienteswwds_39_tfclists",GXType.Int16,1,0) ,
          new ParDef("@AV132Ventas_clienteswwds_40_tfclists_to",GXType.Int16,1,0) ,
          new ParDef("@AV133Ventas_clienteswwds_41_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV134Ventas_clienteswwds_42_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV135Ventas_clienteswwds_43_tfclilim",GXType.Decimal,15,2) ,
          new ParDef("@AV136Ventas_clienteswwds_44_tfclilim_to",GXType.Decimal,15,2) ,
          new ParDef("@AV137Ventas_clienteswwds_45_tfclivend",GXType.Int32,6,0) ,
          new ParDef("@AV138Ventas_clienteswwds_46_tfclivend_to",GXType.Int32,6,0) ,
          new ParDef("@lV139Ventas_clienteswwds_47_tfclivenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV140Ventas_clienteswwds_48_tfclivenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV141Ventas_clienteswwds_49_tfcliref1",GXType.NChar,50,0) ,
          new ParDef("@AV142Ventas_clienteswwds_50_tfcliref1_sel",GXType.NChar,50,0) ,
          new ParDef("@lV143Ventas_clienteswwds_51_tfcliref2",GXType.NChar,50,0) ,
          new ParDef("@AV144Ventas_clienteswwds_52_tfcliref2_sel",GXType.NChar,50,0) ,
          new ParDef("@lV145Ventas_clienteswwds_53_tfcliref3",GXType.NChar,50,0) ,
          new ParDef("@AV146Ventas_clienteswwds_54_tfcliref3_sel",GXType.NChar,50,0) ,
          new ParDef("@lV147Ventas_clienteswwds_55_tfcliref4",GXType.NChar,50,0) ,
          new ParDef("@AV148Ventas_clienteswwds_56_tfcliref4_sel",GXType.NChar,50,0) ,
          new ParDef("@lV149Ventas_clienteswwds_57_tfcliref5",GXType.NChar,50,0) ,
          new ParDef("@AV150Ventas_clienteswwds_58_tfcliref5_sel",GXType.NChar,50,0) ,
          new ParDef("@lV151Ventas_clienteswwds_59_tfcliref6",GXType.NChar,50,0) ,
          new ParDef("@AV152Ventas_clienteswwds_60_tfcliref6_sel",GXType.NChar,50,0) ,
          new ParDef("@lV153Ventas_clienteswwds_61_tfcliref7",GXType.NChar,50,0) ,
          new ParDef("@AV154Ventas_clienteswwds_62_tfcliref7_sel",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00782", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00782,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00783", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00783,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((string[]) buf[12])[0] = rslt.getMultimediaUri(13);
                ((bool[]) buf[13])[0] = rslt.wasNull(13);
                ((int[]) buf[14])[0] = rslt.getInt(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 50);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 20);
                ((string[]) buf[18])[0] = rslt.getString(18, 20);
                ((string[]) buf[19])[0] = rslt.getString(19, 20);
                ((string[]) buf[20])[0] = rslt.getString(20, 20);
                ((string[]) buf[21])[0] = rslt.getString(21, 4);
                ((string[]) buf[22])[0] = rslt.getString(22, 4);
                ((string[]) buf[23])[0] = rslt.getString(23, 100);
                ((string[]) buf[24])[0] = rslt.getString(24, 100);
                ((string[]) buf[25])[0] = rslt.getString(25, 20);
                ((string[]) buf[26])[0] = rslt.getMultimediaFile(26, rslt.getVarchar(13));
                ((bool[]) buf[27])[0] = rslt.wasNull(26);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
