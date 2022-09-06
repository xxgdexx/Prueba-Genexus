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
namespace GeneXus.Programs {
   public class clclientes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
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
            gxLoad_5( A139PaiCod, A140EstCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
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
            gxLoad_6( A139PaiCod, A140EstCod, A141ProvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
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
            gxLoad_7( A139PaiCod, A140EstCod, A141ProvCod, A142DisCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A159TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A159TipCCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A137Conpcod = (int)(NumberUtil.Val( GetPar( "Conpcod"), "."));
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A137Conpcod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A160CliVend = (int)(NumberUtil.Val( GetPar( "CliVend"), "."));
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A160CliVend) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
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
            gxLoad_10( A158ZonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
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
            gxLoad_13( A156CliTipLCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A157TipSCod = (int)(NumberUtil.Val( GetPar( "TipSCod"), "."));
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A157TipSCod) ;
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

      public clclientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clclientes( IGxContext context )
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
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Cliente", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Razon Social", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDsc_Internalname, StringUtil.RTrim( A161CliDsc), StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDir_Internalname, StringUtil.RTrim( A596CliDir), StringUtil.RTrim( context.localUtil.Format( A596CliDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Departamento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Pais", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Telefono 1", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTel1_Internalname, StringUtil.RTrim( A629CliTel1), StringUtil.RTrim( context.localUtil.Format( A629CliTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Telefono 2", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTel2_Internalname, StringUtil.RTrim( A630CliTel2), StringUtil.RTrim( context.localUtil.Format( A630CliTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fax", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliFax_Internalname, StringUtil.RTrim( A611CliFax), StringUtil.RTrim( context.localUtil.Format( A611CliFax, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliFax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliFax_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Celular", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCel_Internalname, StringUtil.RTrim( A575CliCel), StringUtil.RTrim( context.localUtil.Format( A575CliCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "E-Mail", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliEma_Internalname, A609CliEma, StringUtil.RTrim( context.localUtil.Format( A609CliEma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A609CliEma, "", "", "", edtCliEma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliEma_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Pagina Web", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliWeb_Internalname, StringUtil.RTrim( A637CliWeb), StringUtil.RTrim( context.localUtil.Format( A637CliWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliWeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliWeb_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Codigo T. Cliente", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipCCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Foto", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A612CliFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.PathToRelativeUrl( A612CliFoto));
         GxWebStd.gx_bitmap( context, imgCliFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgCliFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", "", "", 0, A612CliFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CLCLIENTES.htm");
         AssignProp("", false, imgCliFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.PathToRelativeUrl( A612CliFoto)), true);
         AssignProp("", false, imgCliFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A612CliFoto_IsBlob), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Situación", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A627CliSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A627CliSts), "9") : context.localUtil.Format( (decimal)(A627CliSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Codigo condicion pago", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConpcod_Enabled!=0) ? context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Limite Credito", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliLim_Internalname, StringUtil.LTrim( StringUtil.NToC( A613CliLim, 15, 2, ".", "")), StringUtil.LTrim( ((edtCliLim_Enabled!=0) ? context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A613CliLim, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliLim_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliLim_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Vendedor", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliVend_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A160CliVend), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliVend_Enabled!=0) ? context.localUtil.Format( (decimal)(A160CliVend), "ZZZZZ9") : context.localUtil.Format( (decimal)(A160CliVend), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVend_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliVend_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Vendedor", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliVendDsc_Internalname, StringUtil.RTrim( A635CliVendDsc), StringUtil.RTrim( context.localUtil.Format( A635CliVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Referencia 1", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef1_Internalname, StringUtil.RTrim( A618CliRef1), StringUtil.RTrim( context.localUtil.Format( A618CliRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Referencia 2", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef2_Internalname, StringUtil.RTrim( A619CliRef2), StringUtil.RTrim( context.localUtil.Format( A619CliRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Referencia 3", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef3_Internalname, StringUtil.RTrim( A620CliRef3), StringUtil.RTrim( context.localUtil.Format( A620CliRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Referencia 4", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef4_Internalname, StringUtil.RTrim( A621CliRef4), StringUtil.RTrim( context.localUtil.Format( A621CliRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Referencia 5", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef5_Internalname, StringUtil.RTrim( A622CliRef5), StringUtil.RTrim( context.localUtil.Format( A622CliRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Referencia 6", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef6_Internalname, StringUtil.RTrim( A623CliRef6), StringUtil.RTrim( context.localUtil.Format( A623CliRef6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef6_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Referencia 7", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef7_Internalname, StringUtil.RTrim( A624CliRef7), StringUtil.RTrim( context.localUtil.Format( A624CliRef7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef7_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Referencia 8", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRef8_Internalname, StringUtil.RTrim( A625CliRef8), StringUtil.RTrim( context.localUtil.Format( A625CliRef8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRef8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRef8_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Contacto 1", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont1_Internalname, StringUtil.RTrim( A581CliCont1), StringUtil.RTrim( context.localUtil.Format( A581CliCont1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Telefono", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel1_Internalname, StringUtil.RTrim( A587CliCTel1), StringUtil.RTrim( context.localUtil.Format( A587CliCTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Contacto 2", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont2_Internalname, StringUtil.RTrim( A582CliCont2), StringUtil.RTrim( context.localUtil.Format( A582CliCont2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Telefono", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel2_Internalname, StringUtil.RTrim( A588CliCTel2), StringUtil.RTrim( context.localUtil.Format( A588CliCTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Contacto 3", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont3_Internalname, StringUtil.RTrim( A583CliCont3), StringUtil.RTrim( context.localUtil.Format( A583CliCont3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Telefono", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCtel3_Internalname, StringUtil.RTrim( A589CliCtel3), StringUtil.RTrim( context.localUtil.Format( A589CliCtel3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCtel3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCtel3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Contacto 4", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont4_Internalname, StringUtil.RTrim( A584CliCont4), StringUtil.RTrim( context.localUtil.Format( A584CliCont4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Telefono", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCTel4_Internalname, StringUtil.RTrim( A590CliCTel4), StringUtil.RTrim( context.localUtil.Format( A590CliCTel4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCTel4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCTel4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Contacto 5", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCont5_Internalname, StringUtil.RTrim( A585CliCont5), StringUtil.RTrim( context.localUtil.Format( A585CliCont5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCont5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCont5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Telefono", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCtel5_Internalname, StringUtil.RTrim( A591CliCtel5), StringUtil.RTrim( context.localUtil.Format( A591CliCtel5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCtel5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCtel5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Distrito", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Provincia", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Total Item Direcciones", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTItemDir_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A632CliTItemDir), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliTItemDir_Enabled!=0) ? context.localUtil.Format( (decimal)(A632CliTItemDir), "ZZZZZ9") : context.localUtil.Format( (decimal)(A632CliTItemDir), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTItemDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTItemDir_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Codigo Zona", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ZonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtZonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A158ZonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A158ZonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtZonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Moneda Limite Credito", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A614CliMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A614CliMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A614CliMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,221);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Cliente Vinculado", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliVincula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A636CliVincula), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliVincula_Enabled!=0) ? context.localUtil.Format( (decimal)(A636CliVincula), "9") : context.localUtil.Format( (decimal)(A636CliVincula), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliVincula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliVincula_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "Cliente Afecto Retención", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliRetencion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A626CliRetencion), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliRetencion_Enabled!=0) ? context.localUtil.Format( (decimal)(A626CliRetencion), "9") : context.localUtil.Format( (decimal)(A626CliRetencion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,231);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliRetencion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliRetencion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Cliente Afecto Percepción", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliPercepcion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A617CliPercepcion), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliPercepcion_Enabled!=0) ? context.localUtil.Format( (decimal)(A617CliPercepcion), "9") : context.localUtil.Format( (decimal)(A617CliPercepcion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,236);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliPercepcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliPercepcion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "Lista de Precios", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A156CliTipLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliTipLCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A156CliTipLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A156CliTipLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,241);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliTipLCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Nombres", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliNom_Internalname, A615CliNom, StringUtil.RTrim( context.localUtil.Format( A615CliNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock47_Internalname, "Apellido Paterno", "", "", lblTextblock47_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliAPEP_Internalname, A574CliAPEP, StringUtil.RTrim( context.localUtil.Format( A574CliAPEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,251);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliAPEP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliAPEP_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock48_Internalname, "Apellido Materno", "", "", lblTextblock48_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliAPEM_Internalname, A573CliAPEM, StringUtil.RTrim( context.localUtil.Format( A573CliAPEM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,256);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliAPEM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliAPEM_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock49_Internalname, "Codigo Tipo Documento Sunat", "", "", lblTextblock49_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157TipSCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipSCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A157TipSCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A157TipSCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,261);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock50_Internalname, "Usuario", "", "", lblTextblock50_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliUsuCod_Internalname, StringUtil.RTrim( A633CliUsuCod), StringUtil.RTrim( context.localUtil.Format( A633CliUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock51_Internalname, "Usuario Fecha", "", "", lblTextblock51_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCliUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCliUsuFec_Internalname, context.localUtil.TToC( A634CliUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A634CliUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,271);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTES.htm");
         GxWebStd.gx_bitmap( context, edtCliUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCliUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock52_Internalname, "E-Mail Percepción", "", "", lblTextblock52_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 276,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliEMAPer_Internalname, A610CliEMAPer, StringUtil.RTrim( context.localUtil.Format( A610CliEMAPer, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,276);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliEMAPer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliEMAPer_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock53_Internalname, "Password Percepción", "", "", lblTextblock53_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliPassPer_Internalname, A616CliPassPer, StringUtil.RTrim( context.localUtil.Format( A616CliPassPer, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,281);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliPassPer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliPassPer_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 285,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 287,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 288,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCLIENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
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
            A628CliTCon = (int)(context.localUtil.CToN( cgiGet( "Z628CliTCon"), ".", ","));
            A631CliTipCod = cgiGet( "Z631CliTipCod");
            A608CliDTAval = (int)(context.localUtil.CToN( cgiGet( "Z608CliDTAval"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A602EstDsc = cgiGet( "ESTDSC");
            A603ProvDsc = cgiGet( "PROVDSC");
            A604DisDsc = cgiGet( "DISDSC");
            A601CliDireccionLarga = cgiGet( "CLIDIRECCIONLARGA");
            A40000CliFoto_GXI = cgiGet( "CLIFOTO_GXI");
            n40000CliFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
            A628CliTCon = (int)(context.localUtil.CToN( cgiGet( "CLITCON"), ".", ","));
            A631CliTipCod = cgiGet( "CLITIPCOD");
            A608CliDTAval = (int)(context.localUtil.CToN( cgiGet( "CLIDTAVAL"), ".", ","));
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgCliFoto_Internalname, ref  A612CliFoto, ref  A40000CliFoto_GXI);
            n40000CliFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000CliFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
            n612CliFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? true : false);
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLCLIENTES");
            forbiddenHiddens.Add("CliTCon", context.localUtil.Format( (decimal)(A628CliTCon), "ZZZZZ9"));
            forbiddenHiddens.Add("CliTipCod", StringUtil.RTrim( context.localUtil.Format( A631CliTipCod, "")));
            forbiddenHiddens.Add("CliDTAval", context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clclientes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A45CliCod = GetPar( "CliCod");
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GET") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_get( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "CHECK") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_Check( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                           /* No code required for Help button. It is implemented at the Browser level. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2E11( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_get_Visible = 0;
         AssignProp("", false, bttBtn_get_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_get_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2E11( ) ;
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

      protected void CONFIRM_2E0( )
      {
         BeforeValidate2E11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2E11( ) ;
            }
            else
            {
               CheckExtendedTable2E11( ) ;
               if ( AnyError == 0 )
               {
                  ZM2E11( 5) ;
                  ZM2E11( 6) ;
                  ZM2E11( 7) ;
                  ZM2E11( 8) ;
                  ZM2E11( 9) ;
                  ZM2E11( 10) ;
                  ZM2E11( 11) ;
                  ZM2E11( 12) ;
                  ZM2E11( 13) ;
               }
               CloseExtendedTableCursors2E11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2E0( ) ;
         }
      }

      protected void ResetCaption2E0( )
      {
      }

      protected void ZM2E11( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z161CliDsc = T002E3_A161CliDsc[0];
               Z596CliDir = T002E3_A596CliDir[0];
               Z629CliTel1 = T002E3_A629CliTel1[0];
               Z630CliTel2 = T002E3_A630CliTel2[0];
               Z611CliFax = T002E3_A611CliFax[0];
               Z575CliCel = T002E3_A575CliCel[0];
               Z609CliEma = T002E3_A609CliEma[0];
               Z637CliWeb = T002E3_A637CliWeb[0];
               Z627CliSts = T002E3_A627CliSts[0];
               Z613CliLim = T002E3_A613CliLim[0];
               Z618CliRef1 = T002E3_A618CliRef1[0];
               Z619CliRef2 = T002E3_A619CliRef2[0];
               Z620CliRef3 = T002E3_A620CliRef3[0];
               Z621CliRef4 = T002E3_A621CliRef4[0];
               Z622CliRef5 = T002E3_A622CliRef5[0];
               Z623CliRef6 = T002E3_A623CliRef6[0];
               Z624CliRef7 = T002E3_A624CliRef7[0];
               Z625CliRef8 = T002E3_A625CliRef8[0];
               Z581CliCont1 = T002E3_A581CliCont1[0];
               Z587CliCTel1 = T002E3_A587CliCTel1[0];
               Z582CliCont2 = T002E3_A582CliCont2[0];
               Z588CliCTel2 = T002E3_A588CliCTel2[0];
               Z583CliCont3 = T002E3_A583CliCont3[0];
               Z589CliCtel3 = T002E3_A589CliCtel3[0];
               Z584CliCont4 = T002E3_A584CliCont4[0];
               Z590CliCTel4 = T002E3_A590CliCTel4[0];
               Z585CliCont5 = T002E3_A585CliCont5[0];
               Z591CliCtel5 = T002E3_A591CliCtel5[0];
               Z632CliTItemDir = T002E3_A632CliTItemDir[0];
               Z614CliMon = T002E3_A614CliMon[0];
               Z636CliVincula = T002E3_A636CliVincula[0];
               Z626CliRetencion = T002E3_A626CliRetencion[0];
               Z617CliPercepcion = T002E3_A617CliPercepcion[0];
               Z615CliNom = T002E3_A615CliNom[0];
               Z574CliAPEP = T002E3_A574CliAPEP[0];
               Z573CliAPEM = T002E3_A573CliAPEM[0];
               Z633CliUsuCod = T002E3_A633CliUsuCod[0];
               Z634CliUsuFec = T002E3_A634CliUsuFec[0];
               Z610CliEMAPer = T002E3_A610CliEMAPer[0];
               Z616CliPassPer = T002E3_A616CliPassPer[0];
               Z628CliTCon = T002E3_A628CliTCon[0];
               Z631CliTipCod = T002E3_A631CliTipCod[0];
               Z608CliDTAval = T002E3_A608CliDTAval[0];
               Z139PaiCod = T002E3_A139PaiCod[0];
               Z140EstCod = T002E3_A140EstCod[0];
               Z141ProvCod = T002E3_A141ProvCod[0];
               Z142DisCod = T002E3_A142DisCod[0];
               Z159TipCCod = T002E3_A159TipCCod[0];
               Z137Conpcod = T002E3_A137Conpcod[0];
               Z158ZonCod = T002E3_A158ZonCod[0];
               Z157TipSCod = T002E3_A157TipSCod[0];
               Z160CliVend = T002E3_A160CliVend[0];
               Z156CliTipLCod = T002E3_A156CliTipLCod[0];
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
         if ( GX_JID == -4 )
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
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            bttBtn_get_Enabled = 0;
            AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_get_Enabled = 1;
            AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_check_Enabled = 0;
            AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_check_Enabled = 1;
            AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         }
      }

      protected void Load2E11( )
      {
         /* Using cursor T002E13 */
         pr_default.execute(11, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound11 = 1;
            A161CliDsc = T002E13_A161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            A596CliDir = T002E13_A596CliDir[0];
            AssignAttri("", false, "A596CliDir", A596CliDir);
            A629CliTel1 = T002E13_A629CliTel1[0];
            AssignAttri("", false, "A629CliTel1", A629CliTel1);
            A630CliTel2 = T002E13_A630CliTel2[0];
            AssignAttri("", false, "A630CliTel2", A630CliTel2);
            A611CliFax = T002E13_A611CliFax[0];
            AssignAttri("", false, "A611CliFax", A611CliFax);
            A575CliCel = T002E13_A575CliCel[0];
            AssignAttri("", false, "A575CliCel", A575CliCel);
            A609CliEma = T002E13_A609CliEma[0];
            AssignAttri("", false, "A609CliEma", A609CliEma);
            A637CliWeb = T002E13_A637CliWeb[0];
            AssignAttri("", false, "A637CliWeb", A637CliWeb);
            A40000CliFoto_GXI = T002E13_A40000CliFoto_GXI[0];
            n40000CliFoto_GXI = T002E13_n40000CliFoto_GXI[0];
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            A627CliSts = T002E13_A627CliSts[0];
            AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
            A613CliLim = T002E13_A613CliLim[0];
            AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
            A635CliVendDsc = T002E13_A635CliVendDsc[0];
            AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
            A618CliRef1 = T002E13_A618CliRef1[0];
            AssignAttri("", false, "A618CliRef1", A618CliRef1);
            A619CliRef2 = T002E13_A619CliRef2[0];
            AssignAttri("", false, "A619CliRef2", A619CliRef2);
            A620CliRef3 = T002E13_A620CliRef3[0];
            AssignAttri("", false, "A620CliRef3", A620CliRef3);
            A621CliRef4 = T002E13_A621CliRef4[0];
            AssignAttri("", false, "A621CliRef4", A621CliRef4);
            A622CliRef5 = T002E13_A622CliRef5[0];
            AssignAttri("", false, "A622CliRef5", A622CliRef5);
            A623CliRef6 = T002E13_A623CliRef6[0];
            AssignAttri("", false, "A623CliRef6", A623CliRef6);
            A624CliRef7 = T002E13_A624CliRef7[0];
            AssignAttri("", false, "A624CliRef7", A624CliRef7);
            A625CliRef8 = T002E13_A625CliRef8[0];
            AssignAttri("", false, "A625CliRef8", A625CliRef8);
            A581CliCont1 = T002E13_A581CliCont1[0];
            AssignAttri("", false, "A581CliCont1", A581CliCont1);
            A587CliCTel1 = T002E13_A587CliCTel1[0];
            AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
            A582CliCont2 = T002E13_A582CliCont2[0];
            AssignAttri("", false, "A582CliCont2", A582CliCont2);
            A588CliCTel2 = T002E13_A588CliCTel2[0];
            AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
            A583CliCont3 = T002E13_A583CliCont3[0];
            AssignAttri("", false, "A583CliCont3", A583CliCont3);
            A589CliCtel3 = T002E13_A589CliCtel3[0];
            AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
            A584CliCont4 = T002E13_A584CliCont4[0];
            AssignAttri("", false, "A584CliCont4", A584CliCont4);
            A590CliCTel4 = T002E13_A590CliCTel4[0];
            AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
            A585CliCont5 = T002E13_A585CliCont5[0];
            AssignAttri("", false, "A585CliCont5", A585CliCont5);
            A591CliCtel5 = T002E13_A591CliCtel5[0];
            AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
            A632CliTItemDir = T002E13_A632CliTItemDir[0];
            AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
            A614CliMon = T002E13_A614CliMon[0];
            AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
            A636CliVincula = T002E13_A636CliVincula[0];
            AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
            A626CliRetencion = T002E13_A626CliRetencion[0];
            AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
            A617CliPercepcion = T002E13_A617CliPercepcion[0];
            AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
            A615CliNom = T002E13_A615CliNom[0];
            AssignAttri("", false, "A615CliNom", A615CliNom);
            A574CliAPEP = T002E13_A574CliAPEP[0];
            AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
            A573CliAPEM = T002E13_A573CliAPEM[0];
            AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
            A633CliUsuCod = T002E13_A633CliUsuCod[0];
            AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
            A634CliUsuFec = T002E13_A634CliUsuFec[0];
            AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A610CliEMAPer = T002E13_A610CliEMAPer[0];
            AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
            A616CliPassPer = T002E13_A616CliPassPer[0];
            AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
            A628CliTCon = T002E13_A628CliTCon[0];
            A631CliTipCod = T002E13_A631CliTipCod[0];
            A608CliDTAval = T002E13_A608CliDTAval[0];
            A602EstDsc = T002E13_A602EstDsc[0];
            A603ProvDsc = T002E13_A603ProvDsc[0];
            A604DisDsc = T002E13_A604DisDsc[0];
            A139PaiCod = T002E13_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002E13_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T002E13_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T002E13_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A159TipCCod = T002E13_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            A137Conpcod = T002E13_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A158ZonCod = T002E13_A158ZonCod[0];
            n158ZonCod = T002E13_n158ZonCod[0];
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            A157TipSCod = T002E13_A157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A160CliVend = T002E13_A160CliVend[0];
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            A156CliTipLCod = T002E13_A156CliTipLCod[0];
            n156CliTipLCod = T002E13_n156CliTipLCod[0];
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            A612CliFoto = T002E13_A612CliFoto[0];
            n612CliFoto = T002E13_n612CliFoto[0];
            AssignAttri("", false, "A612CliFoto", A612CliFoto);
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            ZM2E11( -4) ;
         }
         pr_default.close(11);
         OnLoadActions2E11( ) ;
      }

      protected void OnLoadActions2E11( )
      {
         A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
      }

      protected void CheckExtendedTable2E11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002E4 */
         pr_default.execute(2, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A602EstDsc = T002E4_A602EstDsc[0];
         pr_default.close(2);
         /* Using cursor T002E5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A603ProvDsc = T002E5_A603ProvDsc[0];
         pr_default.close(3);
         /* Using cursor T002E6 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A604DisDsc = T002E6_A604DisDsc[0];
         pr_default.close(4);
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
         /* Using cursor T002E7 */
         pr_default.execute(5, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Cliente'.", "ForeignKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T002E8 */
         pr_default.execute(6, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Condiciones de Pago'.", "ForeignKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         /* Using cursor T002E11 */
         pr_default.execute(9, new Object[] {A160CliVend});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedores'.", "ForeignKeyNotFound", 1, "CLIVEND");
            AnyError = 1;
            GX_FocusControl = edtCliVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A635CliVendDsc = T002E11_A635CliVendDsc[0];
         AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
         pr_default.close(9);
         /* Using cursor T002E9 */
         pr_default.execute(7, new Object[] {n158ZonCod, A158ZonCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A158ZonCod) ) )
            {
               GX_msglist.addItem("No existe 'Zonas'.", "ForeignKeyNotFound", 1, "ZONCOD");
               AnyError = 1;
               GX_FocusControl = edtZonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         /* Using cursor T002E12 */
         pr_default.execute(10, new Object[] {n156CliTipLCod, A156CliTipLCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A156CliTipLCod) ) )
            {
               GX_msglist.addItem("No existe 'Lista de Precios'.", "ForeignKeyNotFound", 1, "CLITIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtCliTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(10);
         /* Using cursor T002E10 */
         pr_default.execute(8, new Object[] {A157TipSCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
            AnyError = 1;
            GX_FocusControl = edtTipSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A634CliUsuFec) || ( A634CliUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "CLIUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtCliUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2E11( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(9);
         pr_default.close(7);
         pr_default.close(10);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A139PaiCod ,
                               string A140EstCod )
      {
         /* Using cursor T002E14 */
         pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Departamentos'.", "ForeignKeyNotFound", 1, "ESTCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A602EstDsc = T002E14_A602EstDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A602EstDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_6( string A139PaiCod ,
                               string A140EstCod ,
                               string A141ProvCod )
      {
         /* Using cursor T002E15 */
         pr_default.execute(13, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A603ProvDsc = T002E15_A603ProvDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A603ProvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_7( string A139PaiCod ,
                               string A140EstCod ,
                               string A141ProvCod ,
                               string A142DisCod )
      {
         /* Using cursor T002E16 */
         pr_default.execute(14, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A604DisDsc = T002E16_A604DisDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A604DisDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_8( int A159TipCCod )
      {
         /* Using cursor T002E17 */
         pr_default.execute(15, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Cliente'.", "ForeignKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_9( int A137Conpcod )
      {
         /* Using cursor T002E18 */
         pr_default.execute(16, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Condiciones de Pago'.", "ForeignKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_12( int A160CliVend )
      {
         /* Using cursor T002E19 */
         pr_default.execute(17, new Object[] {A160CliVend});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedores'.", "ForeignKeyNotFound", 1, "CLIVEND");
            AnyError = 1;
            GX_FocusControl = edtCliVend_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A635CliVendDsc = T002E19_A635CliVendDsc[0];
         AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A635CliVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_10( int A158ZonCod )
      {
         /* Using cursor T002E20 */
         pr_default.execute(18, new Object[] {n158ZonCod, A158ZonCod});
         if ( (pr_default.getStatus(18) == 101) )
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
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_13( int A156CliTipLCod )
      {
         /* Using cursor T002E21 */
         pr_default.execute(19, new Object[] {n156CliTipLCod, A156CliTipLCod});
         if ( (pr_default.getStatus(19) == 101) )
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
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_11( int A157TipSCod )
      {
         /* Using cursor T002E22 */
         pr_default.execute(20, new Object[] {A157TipSCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
            AnyError = 1;
            GX_FocusControl = edtTipSCod_Internalname;
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

      protected void GetKey2E11( )
      {
         /* Using cursor T002E23 */
         pr_default.execute(21, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002E3 */
         pr_default.execute(1, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2E11( 4) ;
            RcdFound11 = 1;
            A45CliCod = T002E3_A45CliCod[0];
            n45CliCod = T002E3_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A161CliDsc = T002E3_A161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            A596CliDir = T002E3_A596CliDir[0];
            AssignAttri("", false, "A596CliDir", A596CliDir);
            A629CliTel1 = T002E3_A629CliTel1[0];
            AssignAttri("", false, "A629CliTel1", A629CliTel1);
            A630CliTel2 = T002E3_A630CliTel2[0];
            AssignAttri("", false, "A630CliTel2", A630CliTel2);
            A611CliFax = T002E3_A611CliFax[0];
            AssignAttri("", false, "A611CliFax", A611CliFax);
            A575CliCel = T002E3_A575CliCel[0];
            AssignAttri("", false, "A575CliCel", A575CliCel);
            A609CliEma = T002E3_A609CliEma[0];
            AssignAttri("", false, "A609CliEma", A609CliEma);
            A637CliWeb = T002E3_A637CliWeb[0];
            AssignAttri("", false, "A637CliWeb", A637CliWeb);
            A40000CliFoto_GXI = T002E3_A40000CliFoto_GXI[0];
            n40000CliFoto_GXI = T002E3_n40000CliFoto_GXI[0];
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            A627CliSts = T002E3_A627CliSts[0];
            AssignAttri("", false, "A627CliSts", StringUtil.Str( (decimal)(A627CliSts), 1, 0));
            A613CliLim = T002E3_A613CliLim[0];
            AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
            A618CliRef1 = T002E3_A618CliRef1[0];
            AssignAttri("", false, "A618CliRef1", A618CliRef1);
            A619CliRef2 = T002E3_A619CliRef2[0];
            AssignAttri("", false, "A619CliRef2", A619CliRef2);
            A620CliRef3 = T002E3_A620CliRef3[0];
            AssignAttri("", false, "A620CliRef3", A620CliRef3);
            A621CliRef4 = T002E3_A621CliRef4[0];
            AssignAttri("", false, "A621CliRef4", A621CliRef4);
            A622CliRef5 = T002E3_A622CliRef5[0];
            AssignAttri("", false, "A622CliRef5", A622CliRef5);
            A623CliRef6 = T002E3_A623CliRef6[0];
            AssignAttri("", false, "A623CliRef6", A623CliRef6);
            A624CliRef7 = T002E3_A624CliRef7[0];
            AssignAttri("", false, "A624CliRef7", A624CliRef7);
            A625CliRef8 = T002E3_A625CliRef8[0];
            AssignAttri("", false, "A625CliRef8", A625CliRef8);
            A581CliCont1 = T002E3_A581CliCont1[0];
            AssignAttri("", false, "A581CliCont1", A581CliCont1);
            A587CliCTel1 = T002E3_A587CliCTel1[0];
            AssignAttri("", false, "A587CliCTel1", A587CliCTel1);
            A582CliCont2 = T002E3_A582CliCont2[0];
            AssignAttri("", false, "A582CliCont2", A582CliCont2);
            A588CliCTel2 = T002E3_A588CliCTel2[0];
            AssignAttri("", false, "A588CliCTel2", A588CliCTel2);
            A583CliCont3 = T002E3_A583CliCont3[0];
            AssignAttri("", false, "A583CliCont3", A583CliCont3);
            A589CliCtel3 = T002E3_A589CliCtel3[0];
            AssignAttri("", false, "A589CliCtel3", A589CliCtel3);
            A584CliCont4 = T002E3_A584CliCont4[0];
            AssignAttri("", false, "A584CliCont4", A584CliCont4);
            A590CliCTel4 = T002E3_A590CliCTel4[0];
            AssignAttri("", false, "A590CliCTel4", A590CliCTel4);
            A585CliCont5 = T002E3_A585CliCont5[0];
            AssignAttri("", false, "A585CliCont5", A585CliCont5);
            A591CliCtel5 = T002E3_A591CliCtel5[0];
            AssignAttri("", false, "A591CliCtel5", A591CliCtel5);
            A632CliTItemDir = T002E3_A632CliTItemDir[0];
            AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
            A614CliMon = T002E3_A614CliMon[0];
            AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
            A636CliVincula = T002E3_A636CliVincula[0];
            AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
            A626CliRetencion = T002E3_A626CliRetencion[0];
            AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
            A617CliPercepcion = T002E3_A617CliPercepcion[0];
            AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
            A615CliNom = T002E3_A615CliNom[0];
            AssignAttri("", false, "A615CliNom", A615CliNom);
            A574CliAPEP = T002E3_A574CliAPEP[0];
            AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
            A573CliAPEM = T002E3_A573CliAPEM[0];
            AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
            A633CliUsuCod = T002E3_A633CliUsuCod[0];
            AssignAttri("", false, "A633CliUsuCod", A633CliUsuCod);
            A634CliUsuFec = T002E3_A634CliUsuFec[0];
            AssignAttri("", false, "A634CliUsuFec", context.localUtil.TToC( A634CliUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A610CliEMAPer = T002E3_A610CliEMAPer[0];
            AssignAttri("", false, "A610CliEMAPer", A610CliEMAPer);
            A616CliPassPer = T002E3_A616CliPassPer[0];
            AssignAttri("", false, "A616CliPassPer", A616CliPassPer);
            A628CliTCon = T002E3_A628CliTCon[0];
            A631CliTipCod = T002E3_A631CliTipCod[0];
            A608CliDTAval = T002E3_A608CliDTAval[0];
            A139PaiCod = T002E3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002E3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T002E3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T002E3_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A159TipCCod = T002E3_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            A137Conpcod = T002E3_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A158ZonCod = T002E3_A158ZonCod[0];
            n158ZonCod = T002E3_n158ZonCod[0];
            AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
            A157TipSCod = T002E3_A157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A160CliVend = T002E3_A160CliVend[0];
            AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
            A156CliTipLCod = T002E3_A156CliTipLCod[0];
            n156CliTipLCod = T002E3_n156CliTipLCod[0];
            AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
            A612CliFoto = T002E3_A612CliFoto[0];
            n612CliFoto = T002E3_n612CliFoto[0];
            AssignAttri("", false, "A612CliFoto", A612CliFoto);
            AssignProp("", false, imgCliFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A612CliFoto)) ? A40000CliFoto_GXI : context.convertURL( context.PathToRelativeUrl( A612CliFoto))), true);
            AssignProp("", false, imgCliFoto_Internalname, "SrcSet", context.GetImageSrcSet( A612CliFoto), true);
            Z45CliCod = A45CliCod;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2E11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey2E11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey2E11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2E11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T002E24 */
         pr_default.execute(22, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T002E24_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T002E24_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               A45CliCod = T002E24_A45CliCod[0];
               n45CliCod = T002E24_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T002E25 */
         pr_default.execute(23, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T002E25_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T002E25_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               A45CliCod = T002E25_A45CliCod[0];
               n45CliCod = T002E25_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2E11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2E11( ) ;
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
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2E11( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2E11( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2E11( ) ;
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
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_Check( )
      {
         nKeyPressed = 3;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         GetKey2E11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
            {
               A45CliCod = Z45CliCod;
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               update_Check( ) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(0);
         context.RollbackDataStores("clclientes",pr_default);
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2E0( ) ;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2E11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2E11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2E11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext2E11( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2E11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2E11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002E2 */
            pr_default.execute(0, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z161CliDsc, T002E2_A161CliDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z596CliDir, T002E2_A596CliDir[0]) != 0 ) || ( StringUtil.StrCmp(Z629CliTel1, T002E2_A629CliTel1[0]) != 0 ) || ( StringUtil.StrCmp(Z630CliTel2, T002E2_A630CliTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z611CliFax, T002E2_A611CliFax[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z575CliCel, T002E2_A575CliCel[0]) != 0 ) || ( StringUtil.StrCmp(Z609CliEma, T002E2_A609CliEma[0]) != 0 ) || ( StringUtil.StrCmp(Z637CliWeb, T002E2_A637CliWeb[0]) != 0 ) || ( Z627CliSts != T002E2_A627CliSts[0] ) || ( Z613CliLim != T002E2_A613CliLim[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z618CliRef1, T002E2_A618CliRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z619CliRef2, T002E2_A619CliRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z620CliRef3, T002E2_A620CliRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z621CliRef4, T002E2_A621CliRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z622CliRef5, T002E2_A622CliRef5[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z623CliRef6, T002E2_A623CliRef6[0]) != 0 ) || ( StringUtil.StrCmp(Z624CliRef7, T002E2_A624CliRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z625CliRef8, T002E2_A625CliRef8[0]) != 0 ) || ( StringUtil.StrCmp(Z581CliCont1, T002E2_A581CliCont1[0]) != 0 ) || ( StringUtil.StrCmp(Z587CliCTel1, T002E2_A587CliCTel1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z582CliCont2, T002E2_A582CliCont2[0]) != 0 ) || ( StringUtil.StrCmp(Z588CliCTel2, T002E2_A588CliCTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z583CliCont3, T002E2_A583CliCont3[0]) != 0 ) || ( StringUtil.StrCmp(Z589CliCtel3, T002E2_A589CliCtel3[0]) != 0 ) || ( StringUtil.StrCmp(Z584CliCont4, T002E2_A584CliCont4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z590CliCTel4, T002E2_A590CliCTel4[0]) != 0 ) || ( StringUtil.StrCmp(Z585CliCont5, T002E2_A585CliCont5[0]) != 0 ) || ( StringUtil.StrCmp(Z591CliCtel5, T002E2_A591CliCtel5[0]) != 0 ) || ( Z632CliTItemDir != T002E2_A632CliTItemDir[0] ) || ( Z614CliMon != T002E2_A614CliMon[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z636CliVincula != T002E2_A636CliVincula[0] ) || ( Z626CliRetencion != T002E2_A626CliRetencion[0] ) || ( Z617CliPercepcion != T002E2_A617CliPercepcion[0] ) || ( StringUtil.StrCmp(Z615CliNom, T002E2_A615CliNom[0]) != 0 ) || ( StringUtil.StrCmp(Z574CliAPEP, T002E2_A574CliAPEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z573CliAPEM, T002E2_A573CliAPEM[0]) != 0 ) || ( StringUtil.StrCmp(Z633CliUsuCod, T002E2_A633CliUsuCod[0]) != 0 ) || ( Z634CliUsuFec != T002E2_A634CliUsuFec[0] ) || ( StringUtil.StrCmp(Z610CliEMAPer, T002E2_A610CliEMAPer[0]) != 0 ) || ( StringUtil.StrCmp(Z616CliPassPer, T002E2_A616CliPassPer[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z628CliTCon != T002E2_A628CliTCon[0] ) || ( StringUtil.StrCmp(Z631CliTipCod, T002E2_A631CliTipCod[0]) != 0 ) || ( Z608CliDTAval != T002E2_A608CliDTAval[0] ) || ( StringUtil.StrCmp(Z139PaiCod, T002E2_A139PaiCod[0]) != 0 ) || ( StringUtil.StrCmp(Z140EstCod, T002E2_A140EstCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z141ProvCod, T002E2_A141ProvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z142DisCod, T002E2_A142DisCod[0]) != 0 ) || ( Z159TipCCod != T002E2_A159TipCCod[0] ) || ( Z137Conpcod != T002E2_A137Conpcod[0] ) || ( Z158ZonCod != T002E2_A158ZonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z157TipSCod != T002E2_A157TipSCod[0] ) || ( Z160CliVend != T002E2_A160CliVend[0] ) || ( Z156CliTipLCod != T002E2_A156CliTipLCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z161CliDsc, T002E2_A161CliDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliDsc");
                  GXUtil.WriteLogRaw("Old: ",Z161CliDsc);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A161CliDsc[0]);
               }
               if ( StringUtil.StrCmp(Z596CliDir, T002E2_A596CliDir[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliDir");
                  GXUtil.WriteLogRaw("Old: ",Z596CliDir);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A596CliDir[0]);
               }
               if ( StringUtil.StrCmp(Z629CliTel1, T002E2_A629CliTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTel1");
                  GXUtil.WriteLogRaw("Old: ",Z629CliTel1);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A629CliTel1[0]);
               }
               if ( StringUtil.StrCmp(Z630CliTel2, T002E2_A630CliTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTel2");
                  GXUtil.WriteLogRaw("Old: ",Z630CliTel2);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A630CliTel2[0]);
               }
               if ( StringUtil.StrCmp(Z611CliFax, T002E2_A611CliFax[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliFax");
                  GXUtil.WriteLogRaw("Old: ",Z611CliFax);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A611CliFax[0]);
               }
               if ( StringUtil.StrCmp(Z575CliCel, T002E2_A575CliCel[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCel");
                  GXUtil.WriteLogRaw("Old: ",Z575CliCel);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A575CliCel[0]);
               }
               if ( StringUtil.StrCmp(Z609CliEma, T002E2_A609CliEma[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliEma");
                  GXUtil.WriteLogRaw("Old: ",Z609CliEma);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A609CliEma[0]);
               }
               if ( StringUtil.StrCmp(Z637CliWeb, T002E2_A637CliWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliWeb");
                  GXUtil.WriteLogRaw("Old: ",Z637CliWeb);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A637CliWeb[0]);
               }
               if ( Z627CliSts != T002E2_A627CliSts[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliSts");
                  GXUtil.WriteLogRaw("Old: ",Z627CliSts);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A627CliSts[0]);
               }
               if ( Z613CliLim != T002E2_A613CliLim[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliLim");
                  GXUtil.WriteLogRaw("Old: ",Z613CliLim);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A613CliLim[0]);
               }
               if ( StringUtil.StrCmp(Z618CliRef1, T002E2_A618CliRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef1");
                  GXUtil.WriteLogRaw("Old: ",Z618CliRef1);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A618CliRef1[0]);
               }
               if ( StringUtil.StrCmp(Z619CliRef2, T002E2_A619CliRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef2");
                  GXUtil.WriteLogRaw("Old: ",Z619CliRef2);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A619CliRef2[0]);
               }
               if ( StringUtil.StrCmp(Z620CliRef3, T002E2_A620CliRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef3");
                  GXUtil.WriteLogRaw("Old: ",Z620CliRef3);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A620CliRef3[0]);
               }
               if ( StringUtil.StrCmp(Z621CliRef4, T002E2_A621CliRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef4");
                  GXUtil.WriteLogRaw("Old: ",Z621CliRef4);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A621CliRef4[0]);
               }
               if ( StringUtil.StrCmp(Z622CliRef5, T002E2_A622CliRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef5");
                  GXUtil.WriteLogRaw("Old: ",Z622CliRef5);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A622CliRef5[0]);
               }
               if ( StringUtil.StrCmp(Z623CliRef6, T002E2_A623CliRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef6");
                  GXUtil.WriteLogRaw("Old: ",Z623CliRef6);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A623CliRef6[0]);
               }
               if ( StringUtil.StrCmp(Z624CliRef7, T002E2_A624CliRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef7");
                  GXUtil.WriteLogRaw("Old: ",Z624CliRef7);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A624CliRef7[0]);
               }
               if ( StringUtil.StrCmp(Z625CliRef8, T002E2_A625CliRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRef8");
                  GXUtil.WriteLogRaw("Old: ",Z625CliRef8);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A625CliRef8[0]);
               }
               if ( StringUtil.StrCmp(Z581CliCont1, T002E2_A581CliCont1[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCont1");
                  GXUtil.WriteLogRaw("Old: ",Z581CliCont1);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A581CliCont1[0]);
               }
               if ( StringUtil.StrCmp(Z587CliCTel1, T002E2_A587CliCTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCTel1");
                  GXUtil.WriteLogRaw("Old: ",Z587CliCTel1);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A587CliCTel1[0]);
               }
               if ( StringUtil.StrCmp(Z582CliCont2, T002E2_A582CliCont2[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCont2");
                  GXUtil.WriteLogRaw("Old: ",Z582CliCont2);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A582CliCont2[0]);
               }
               if ( StringUtil.StrCmp(Z588CliCTel2, T002E2_A588CliCTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCTel2");
                  GXUtil.WriteLogRaw("Old: ",Z588CliCTel2);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A588CliCTel2[0]);
               }
               if ( StringUtil.StrCmp(Z583CliCont3, T002E2_A583CliCont3[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCont3");
                  GXUtil.WriteLogRaw("Old: ",Z583CliCont3);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A583CliCont3[0]);
               }
               if ( StringUtil.StrCmp(Z589CliCtel3, T002E2_A589CliCtel3[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCtel3");
                  GXUtil.WriteLogRaw("Old: ",Z589CliCtel3);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A589CliCtel3[0]);
               }
               if ( StringUtil.StrCmp(Z584CliCont4, T002E2_A584CliCont4[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCont4");
                  GXUtil.WriteLogRaw("Old: ",Z584CliCont4);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A584CliCont4[0]);
               }
               if ( StringUtil.StrCmp(Z590CliCTel4, T002E2_A590CliCTel4[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCTel4");
                  GXUtil.WriteLogRaw("Old: ",Z590CliCTel4);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A590CliCTel4[0]);
               }
               if ( StringUtil.StrCmp(Z585CliCont5, T002E2_A585CliCont5[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCont5");
                  GXUtil.WriteLogRaw("Old: ",Z585CliCont5);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A585CliCont5[0]);
               }
               if ( StringUtil.StrCmp(Z591CliCtel5, T002E2_A591CliCtel5[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliCtel5");
                  GXUtil.WriteLogRaw("Old: ",Z591CliCtel5);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A591CliCtel5[0]);
               }
               if ( Z632CliTItemDir != T002E2_A632CliTItemDir[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTItemDir");
                  GXUtil.WriteLogRaw("Old: ",Z632CliTItemDir);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A632CliTItemDir[0]);
               }
               if ( Z614CliMon != T002E2_A614CliMon[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliMon");
                  GXUtil.WriteLogRaw("Old: ",Z614CliMon);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A614CliMon[0]);
               }
               if ( Z636CliVincula != T002E2_A636CliVincula[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliVincula");
                  GXUtil.WriteLogRaw("Old: ",Z636CliVincula);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A636CliVincula[0]);
               }
               if ( Z626CliRetencion != T002E2_A626CliRetencion[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliRetencion");
                  GXUtil.WriteLogRaw("Old: ",Z626CliRetencion);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A626CliRetencion[0]);
               }
               if ( Z617CliPercepcion != T002E2_A617CliPercepcion[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliPercepcion");
                  GXUtil.WriteLogRaw("Old: ",Z617CliPercepcion);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A617CliPercepcion[0]);
               }
               if ( StringUtil.StrCmp(Z615CliNom, T002E2_A615CliNom[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliNom");
                  GXUtil.WriteLogRaw("Old: ",Z615CliNom);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A615CliNom[0]);
               }
               if ( StringUtil.StrCmp(Z574CliAPEP, T002E2_A574CliAPEP[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliAPEP");
                  GXUtil.WriteLogRaw("Old: ",Z574CliAPEP);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A574CliAPEP[0]);
               }
               if ( StringUtil.StrCmp(Z573CliAPEM, T002E2_A573CliAPEM[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliAPEM");
                  GXUtil.WriteLogRaw("Old: ",Z573CliAPEM);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A573CliAPEM[0]);
               }
               if ( StringUtil.StrCmp(Z633CliUsuCod, T002E2_A633CliUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z633CliUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A633CliUsuCod[0]);
               }
               if ( Z634CliUsuFec != T002E2_A634CliUsuFec[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z634CliUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A634CliUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z610CliEMAPer, T002E2_A610CliEMAPer[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliEMAPer");
                  GXUtil.WriteLogRaw("Old: ",Z610CliEMAPer);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A610CliEMAPer[0]);
               }
               if ( StringUtil.StrCmp(Z616CliPassPer, T002E2_A616CliPassPer[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliPassPer");
                  GXUtil.WriteLogRaw("Old: ",Z616CliPassPer);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A616CliPassPer[0]);
               }
               if ( Z628CliTCon != T002E2_A628CliTCon[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTCon");
                  GXUtil.WriteLogRaw("Old: ",Z628CliTCon);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A628CliTCon[0]);
               }
               if ( StringUtil.StrCmp(Z631CliTipCod, T002E2_A631CliTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z631CliTipCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A631CliTipCod[0]);
               }
               if ( Z608CliDTAval != T002E2_A608CliDTAval[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliDTAval");
                  GXUtil.WriteLogRaw("Old: ",Z608CliDTAval);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A608CliDTAval[0]);
               }
               if ( StringUtil.StrCmp(Z139PaiCod, T002E2_A139PaiCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"PaiCod");
                  GXUtil.WriteLogRaw("Old: ",Z139PaiCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A139PaiCod[0]);
               }
               if ( StringUtil.StrCmp(Z140EstCod, T002E2_A140EstCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"EstCod");
                  GXUtil.WriteLogRaw("Old: ",Z140EstCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A140EstCod[0]);
               }
               if ( StringUtil.StrCmp(Z141ProvCod, T002E2_A141ProvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"ProvCod");
                  GXUtil.WriteLogRaw("Old: ",Z141ProvCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A141ProvCod[0]);
               }
               if ( StringUtil.StrCmp(Z142DisCod, T002E2_A142DisCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"DisCod");
                  GXUtil.WriteLogRaw("Old: ",Z142DisCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A142DisCod[0]);
               }
               if ( Z159TipCCod != T002E2_A159TipCCod[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"TipCCod");
                  GXUtil.WriteLogRaw("Old: ",Z159TipCCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A159TipCCod[0]);
               }
               if ( Z137Conpcod != T002E2_A137Conpcod[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"Conpcod");
                  GXUtil.WriteLogRaw("Old: ",Z137Conpcod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A137Conpcod[0]);
               }
               if ( Z158ZonCod != T002E2_A158ZonCod[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"ZonCod");
                  GXUtil.WriteLogRaw("Old: ",Z158ZonCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A158ZonCod[0]);
               }
               if ( Z157TipSCod != T002E2_A157TipSCod[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"TipSCod");
                  GXUtil.WriteLogRaw("Old: ",Z157TipSCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A157TipSCod[0]);
               }
               if ( Z160CliVend != T002E2_A160CliVend[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliVend");
                  GXUtil.WriteLogRaw("Old: ",Z160CliVend);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A160CliVend[0]);
               }
               if ( Z156CliTipLCod != T002E2_A156CliTipLCod[0] )
               {
                  GXUtil.WriteLog("clclientes:[seudo value changed for attri]"+"CliTipLCod");
                  GXUtil.WriteLogRaw("Old: ",Z156CliTipLCod);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A156CliTipLCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2E11( )
      {
         BeforeValidate2E11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2E11( 0) ;
            CheckOptimisticConcurrency2E11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2E11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002E26 */
                     pr_default.execute(24, new Object[] {n45CliCod, A45CliCod, A161CliDsc, A596CliDir, A629CliTel1, A630CliTel2, A611CliFax, A575CliCel, A609CliEma, A637CliWeb, n612CliFoto, A612CliFoto, n40000CliFoto_GXI, A40000CliFoto_GXI, A627CliSts, A613CliLim, A618CliRef1, A619CliRef2, A620CliRef3, A621CliRef4, A622CliRef5, A623CliRef6, A624CliRef7, A625CliRef8, A581CliCont1, A587CliCTel1, A582CliCont2, A588CliCTel2, A583CliCont3, A589CliCtel3, A584CliCont4, A590CliCTel4, A585CliCont5, A591CliCtel5, A632CliTItemDir, A614CliMon, A636CliVincula, A626CliRetencion, A617CliPercepcion, A615CliNom, A574CliAPEP, A573CliAPEM, A633CliUsuCod, A634CliUsuFec, A610CliEMAPer, A616CliPassPer, A628CliTCon, A631CliTipCod, A608CliDTAval, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A159TipCCod, A137Conpcod, n158ZonCod, A158ZonCod, A157TipSCod, A160CliVend, n156CliTipLCod, A156CliTipLCod});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( (pr_default.getStatus(24) == 1) )
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
                           ResetCaption2E0( ) ;
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
               Load2E11( ) ;
            }
            EndLevel2E11( ) ;
         }
         CloseExtendedTableCursors2E11( ) ;
      }

      protected void Update2E11( )
      {
         BeforeValidate2E11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2E11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002E27 */
                     pr_default.execute(25, new Object[] {A161CliDsc, A596CliDir, A629CliTel1, A630CliTel2, A611CliFax, A575CliCel, A609CliEma, A637CliWeb, A627CliSts, A613CliLim, A618CliRef1, A619CliRef2, A620CliRef3, A621CliRef4, A622CliRef5, A623CliRef6, A624CliRef7, A625CliRef8, A581CliCont1, A587CliCTel1, A582CliCont2, A588CliCTel2, A583CliCont3, A589CliCtel3, A584CliCont4, A590CliCTel4, A585CliCont5, A591CliCtel5, A632CliTItemDir, A614CliMon, A636CliVincula, A626CliRetencion, A617CliPercepcion, A615CliNom, A574CliAPEP, A573CliAPEM, A633CliUsuCod, A634CliUsuFec, A610CliEMAPer, A616CliPassPer, A628CliTCon, A631CliTipCod, A608CliDTAval, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A159TipCCod, A137Conpcod, n158ZonCod, A158ZonCod, A157TipSCod, A160CliVend, n156CliTipLCod, A156CliTipLCod, n45CliCod, A45CliCod});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2E11( ) ;
                     if ( AnyError == 0 )
                     {
                        new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                        AssignAttri("", false, "A45CliCod", A45CliCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2E0( ) ;
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
            EndLevel2E11( ) ;
         }
         CloseExtendedTableCursors2E11( ) ;
      }

      protected void DeferredUpdate2E11( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002E28 */
            pr_default.execute(26, new Object[] {n612CliFoto, A612CliFoto, n40000CliFoto_GXI, A40000CliFoto_GXI, n45CliCod, A45CliCod});
            pr_default.close(26);
            dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2E11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2E11( ) ;
            AfterConfirm2E11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2E11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002E29 */
                  pr_default.execute(27, new Object[] {n45CliCod, A45CliCod});
                  pr_default.close(27);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound11 == 0 )
                        {
                           InitAll2E11( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption2E0( ) ;
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2E11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2E11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002E30 */
            pr_default.execute(28, new Object[] {A139PaiCod, A140EstCod});
            A602EstDsc = T002E30_A602EstDsc[0];
            pr_default.close(28);
            /* Using cursor T002E31 */
            pr_default.execute(29, new Object[] {A160CliVend});
            A635CliVendDsc = T002E31_A635CliVendDsc[0];
            AssignAttri("", false, "A635CliVendDsc", A635CliVendDsc);
            pr_default.close(29);
            /* Using cursor T002E32 */
            pr_default.execute(30, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
            A603ProvDsc = T002E32_A603ProvDsc[0];
            pr_default.close(30);
            /* Using cursor T002E33 */
            pr_default.execute(31, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            A604DisDsc = T002E33_A604DisDsc[0];
            pr_default.close(31);
            A601CliDireccionLarga = StringUtil.Trim( A596CliDir) + " - " + StringUtil.Trim( A602EstDsc) + " - " + StringUtil.Trim( A603ProvDsc) + " - " + StringUtil.Trim( A604DisDsc);
            AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002E34 */
            pr_default.execute(32, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T002E35 */
            pr_default.execute(33, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T002E36 */
            pr_default.execute(34, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Comprobantes de Percepción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T002E37 */
            pr_default.execute(35, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T002E38 */
            pr_default.execute(36, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T002E39 */
            pr_default.execute(37, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T002E40 */
            pr_default.execute(38, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T002E41 */
            pr_default.execute(39, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T002E42 */
            pr_default.execute(40, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T002E43 */
            pr_default.execute(41, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T002E44 */
            pr_default.execute(42, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T002E45 */
            pr_default.execute(43, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Vehiculos Placas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T002E46 */
            pr_default.execute(44, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Clientes Direcciones"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T002E47 */
            pr_default.execute(45, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Clientes Contacto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T002E48 */
            pr_default.execute(46, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCLIENTESAVALES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T002E49 */
            pr_default.execute(47, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T002E50 */
            pr_default.execute(48, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T002E51 */
            pr_default.execute(49, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T002E52 */
            pr_default.execute(50, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
         }
      }

      protected void EndLevel2E11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2E11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(30);
            pr_default.close(31);
            pr_default.close(29);
            context.CommitDataStores("clclientes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(28);
            pr_default.close(30);
            pr_default.close(31);
            pr_default.close(29);
            context.RollbackDataStores("clclientes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2E11( )
      {
         /* Using cursor T002E53 */
         pr_default.execute(51);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T002E53_A45CliCod[0];
            n45CliCod = T002E53_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2E11( )
      {
         /* Scan next routine */
         pr_default.readNext(51);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T002E53_A45CliCod[0];
            n45CliCod = T002E53_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
      }

      protected void ScanEnd2E11( )
      {
         pr_default.close(51);
      }

      protected void AfterConfirm2E11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2E11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2E11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2E11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2E11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2E11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2E11( )
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
      }

      protected void send_integrity_lvl_hashes2E11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2E0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
         context.AddJavascriptSource("gxcfg.js", "?202281816425742", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clclientes.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "Form", true);
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLCLIENTES");
         forbiddenHiddens.Add("CliTCon", context.localUtil.Format( (decimal)(A628CliTCon), "ZZZZZ9"));
         forbiddenHiddens.Add("CliTipCod", StringUtil.RTrim( context.localUtil.Format( A631CliTipCod, "")));
         forbiddenHiddens.Add("CliDTAval", context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clclientes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         GxWebStd.gx_hidden_field( context, "ESTDSC", StringUtil.RTrim( A602EstDsc));
         GxWebStd.gx_hidden_field( context, "PROVDSC", StringUtil.RTrim( A603ProvDsc));
         GxWebStd.gx_hidden_field( context, "DISDSC", StringUtil.RTrim( A604DisDsc));
         GxWebStd.gx_hidden_field( context, "CLIDIRECCIONLARGA", A601CliDireccionLarga);
         GxWebStd.gx_hidden_field( context, "CLIFOTO_GXI", A40000CliFoto_GXI);
         GxWebStd.gx_hidden_field( context, "CLITCON", StringUtil.LTrim( StringUtil.NToC( (decimal)(A628CliTCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLITIPCOD", StringUtil.RTrim( A631CliTipCod));
         GxWebStd.gx_hidden_field( context, "CLIDTAVAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A608CliDTAval), 6, 0, ".", "")));
         GXCCtlgxBlob = "CLIFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A612CliFoto);
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
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
         return formatLink("clclientes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCLIENTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes" ;
      }

      protected void InitializeNonKey2E11( )
      {
         A601CliDireccionLarga = "";
         AssignAttri("", false, "A601CliDireccionLarga", A601CliDireccionLarga);
         A161CliDsc = "";
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         A596CliDir = "";
         AssignAttri("", false, "A596CliDir", A596CliDir);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
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
         A159TipCCod = 0;
         AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
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
         A137Conpcod = 0;
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         A613CliLim = 0;
         AssignAttri("", false, "A613CliLim", StringUtil.LTrimStr( A613CliLim, 15, 2));
         A160CliVend = 0;
         AssignAttri("", false, "A160CliVend", StringUtil.LTrimStr( (decimal)(A160CliVend), 6, 0));
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
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A632CliTItemDir = 0;
         AssignAttri("", false, "A632CliTItemDir", StringUtil.LTrimStr( (decimal)(A632CliTItemDir), 6, 0));
         A158ZonCod = 0;
         n158ZonCod = false;
         AssignAttri("", false, "A158ZonCod", StringUtil.LTrimStr( (decimal)(A158ZonCod), 6, 0));
         n158ZonCod = ((0==A158ZonCod) ? true : false);
         A614CliMon = 0;
         AssignAttri("", false, "A614CliMon", StringUtil.LTrimStr( (decimal)(A614CliMon), 6, 0));
         A636CliVincula = 0;
         AssignAttri("", false, "A636CliVincula", StringUtil.Str( (decimal)(A636CliVincula), 1, 0));
         A626CliRetencion = 0;
         AssignAttri("", false, "A626CliRetencion", StringUtil.Str( (decimal)(A626CliRetencion), 1, 0));
         A617CliPercepcion = 0;
         AssignAttri("", false, "A617CliPercepcion", StringUtil.Str( (decimal)(A617CliPercepcion), 1, 0));
         A156CliTipLCod = 0;
         n156CliTipLCod = false;
         AssignAttri("", false, "A156CliTipLCod", StringUtil.LTrimStr( (decimal)(A156CliTipLCod), 6, 0));
         n156CliTipLCod = ((0==A156CliTipLCod) ? true : false);
         A615CliNom = "";
         AssignAttri("", false, "A615CliNom", A615CliNom);
         A574CliAPEP = "";
         AssignAttri("", false, "A574CliAPEP", A574CliAPEP);
         A573CliAPEM = "";
         AssignAttri("", false, "A573CliAPEM", A573CliAPEM);
         A157TipSCod = 0;
         AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
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

      protected void InitAll2E11( )
      {
         A45CliCod = "";
         n45CliCod = false;
         AssignAttri("", false, "A45CliCod", A45CliCod);
         InitializeNonKey2E11( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816425812", true, true);
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
         context.AddJavascriptSource("clclientes.js", "?202281816425813", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtCliCod_Internalname = "CLICOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCliDsc_Internalname = "CLIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCliDir_Internalname = "CLIDIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtEstCod_Internalname = "ESTCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPaiCod_Internalname = "PAICOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCliTel1_Internalname = "CLITEL1";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCliTel2_Internalname = "CLITEL2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCliFax_Internalname = "CLIFAX";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCliCel_Internalname = "CLICEL";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCliEma_Internalname = "CLIEMA";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCliWeb_Internalname = "CLIWEB";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtTipCCod_Internalname = "TIPCCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         imgCliFoto_Internalname = "CLIFOTO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCliSts_Internalname = "CLISTS";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtConpcod_Internalname = "CONPCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtCliLim_Internalname = "CLILIM";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtCliVend_Internalname = "CLIVEND";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtCliVendDsc_Internalname = "CLIVENDDSC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtCliRef1_Internalname = "CLIREF1";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtCliRef2_Internalname = "CLIREF2";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtCliRef3_Internalname = "CLIREF3";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtCliRef4_Internalname = "CLIREF4";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtCliRef5_Internalname = "CLIREF5";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtCliRef6_Internalname = "CLIREF6";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtCliRef7_Internalname = "CLIREF7";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtCliRef8_Internalname = "CLIREF8";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtCliCont1_Internalname = "CLICONT1";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtCliCTel1_Internalname = "CLICTEL1";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtCliCont2_Internalname = "CLICONT2";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtCliCTel2_Internalname = "CLICTEL2";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtCliCont3_Internalname = "CLICONT3";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtCliCtel3_Internalname = "CLICTEL3";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtCliCont4_Internalname = "CLICONT4";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtCliCTel4_Internalname = "CLICTEL4";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtCliCont5_Internalname = "CLICONT5";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtCliCtel5_Internalname = "CLICTEL5";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtDisCod_Internalname = "DISCOD";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtProvCod_Internalname = "PROVCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtCliTItemDir_Internalname = "CLITITEMDIR";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtZonCod_Internalname = "ZONCOD";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtCliMon_Internalname = "CLIMON";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtCliVincula_Internalname = "CLIVINCULA";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtCliRetencion_Internalname = "CLIRETENCION";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtCliPercepcion_Internalname = "CLIPERCEPCION";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtCliTipLCod_Internalname = "CLITIPLCOD";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtCliNom_Internalname = "CLINOM";
         lblTextblock47_Internalname = "TEXTBLOCK47";
         edtCliAPEP_Internalname = "CLIAPEP";
         lblTextblock48_Internalname = "TEXTBLOCK48";
         edtCliAPEM_Internalname = "CLIAPEM";
         lblTextblock49_Internalname = "TEXTBLOCK49";
         edtTipSCod_Internalname = "TIPSCOD";
         lblTextblock50_Internalname = "TEXTBLOCK50";
         edtCliUsuCod_Internalname = "CLIUSUCOD";
         lblTextblock51_Internalname = "TEXTBLOCK51";
         edtCliUsuFec_Internalname = "CLIUSUFEC";
         lblTextblock52_Internalname = "TEXTBLOCK52";
         edtCliEMAPer_Internalname = "CLIEMAPER";
         lblTextblock53_Internalname = "TEXTBLOCK53";
         edtCliPassPer_Internalname = "CLIPASSPER";
         tblTable2_Internalname = "TABLE2";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_check_Internalname = "BTN_CHECK";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         bttBtn_help_Internalname = "BTN_HELP";
         tblTable1_Internalname = "TABLE1";
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
         Form.Caption = "Clientes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
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
         edtCliAPEM_Jsonclick = "";
         edtCliAPEM_Enabled = 1;
         edtCliAPEP_Jsonclick = "";
         edtCliAPEP_Enabled = 1;
         edtCliNom_Jsonclick = "";
         edtCliNom_Enabled = 1;
         edtCliTipLCod_Jsonclick = "";
         edtCliTipLCod_Enabled = 1;
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
         edtCliTItemDir_Jsonclick = "";
         edtCliTItemDir_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
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
         edtCliRef6_Js