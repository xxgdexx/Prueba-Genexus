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
   public class cpproveedores : GXDataArea
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
            gxLoad_5( A139PaiCod, A140EstCod, A141ProvCod, A142DisCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A298TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A298TprvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A300PrvConpCod = (int)(NumberUtil.Val( GetPar( "PrvConpCod"), "."));
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A300PrvConpCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A297TPerCod = (int)(NumberUtil.Val( GetPar( "TPerCod"), "."));
            n297TPerCod = false;
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A297TPerCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A157TipSCod = (int)(NumberUtil.Val( GetPar( "TipSCod"), "."));
            n157TipSCod = false;
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A157TipSCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A296PrvBanCod1 = (int)(NumberUtil.Val( GetPar( "PrvBanCod1"), "."));
            n296PrvBanCod1 = false;
            AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A296PrvBanCod1) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A299PrvBanCod2 = (int)(NumberUtil.Val( GetPar( "PrvBanCod2"), "."));
            n299PrvBanCod2 = false;
            AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A299PrvBanCod2) ;
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
            Form.Meta.addItem("description", "Proveedores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpproveedores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpproveedores( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPPROVEEDORES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Proveedor", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Razon Social", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvDir_Internalname, StringUtil.RTrim( A1763PrvDir), StringUtil.RTrim( context.localUtil.Format( A1763PrvDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Departamento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Pais", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Telefono 1", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvTel1_Internalname, StringUtil.RTrim( A1779PrvTel1), StringUtil.RTrim( context.localUtil.Format( A1779PrvTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Telefono 2", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvTel2_Internalname, StringUtil.RTrim( A1780PrvTel2), StringUtil.RTrim( context.localUtil.Format( A1780PrvTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fax", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvFax_Internalname, StringUtil.RTrim( A1765PrvFax), StringUtil.RTrim( context.localUtil.Format( A1765PrvFax, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvFax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvFax_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Celular", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCel_Internalname, StringUtil.RTrim( A1747PrvCel), StringUtil.RTrim( context.localUtil.Format( A1747PrvCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "E-Mail", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvEM_Internalname, StringUtil.RTrim( A1764PrvEM), StringUtil.RTrim( context.localUtil.Format( A1764PrvEM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvEM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvEM_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Web", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvWeb_Internalname, StringUtil.RTrim( A1788PrvWeb), StringUtil.RTrim( context.localUtil.Format( A1788PrvWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvWeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvWeb_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Codigo T. Proveedor", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTprvCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTprvCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Foto", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A1766PrvFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PrvFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.PathToRelativeUrl( A1766PrvFoto));
         GxWebStd.gx_bitmap( context, imgPrvFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPrvFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", "", "", 0, A1766PrvFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CPPROVEEDORES.htm");
         AssignProp("", false, imgPrvFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.PathToRelativeUrl( A1766PrvFoto)), true);
         AssignProp("", false, imgPrvFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A1766PrvFoto_IsBlob), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Situación", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1777PrvSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtPrvSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1777PrvSts), "9") : context.localUtil.Format( (decimal)(A1777PrvSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Condicion de pago", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPrvConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A300PrvConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A300PrvConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Referencia 1", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef1_Internalname, StringUtil.RTrim( A1768PrvRef1), StringUtil.RTrim( context.localUtil.Format( A1768PrvRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Referencia 2", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef2_Internalname, StringUtil.RTrim( A1769PrvRef2), StringUtil.RTrim( context.localUtil.Format( A1769PrvRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Referencia 3", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef3_Internalname, StringUtil.RTrim( A1770PrvRef3), StringUtil.RTrim( context.localUtil.Format( A1770PrvRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Referencia 4", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef4_Internalname, StringUtil.RTrim( A1771PrvRef4), StringUtil.RTrim( context.localUtil.Format( A1771PrvRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Referencia 5", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef5_Internalname, StringUtil.RTrim( A1772PrvRef5), StringUtil.RTrim( context.localUtil.Format( A1772PrvRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Referencia 6", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef6_Internalname, StringUtil.RTrim( A1773PrvRef6), StringUtil.RTrim( context.localUtil.Format( A1773PrvRef6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef6_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Referencia 7", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef7_Internalname, StringUtil.RTrim( A1774PrvRef7), StringUtil.RTrim( context.localUtil.Format( A1774PrvRef7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef7_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Referencia 8", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRef8_Internalname, StringUtil.RTrim( A1775PrvRef8), StringUtil.RTrim( context.localUtil.Format( A1775PrvRef8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRef8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRef8_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Contacto 1", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCon1_Internalname, StringUtil.RTrim( A1748PrvCon1), StringUtil.RTrim( context.localUtil.Format( A1748PrvCon1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCon1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCon1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Telefono", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCTel1_Internalname, StringUtil.RTrim( A1758PrvCTel1), StringUtil.RTrim( context.localUtil.Format( A1758PrvCTel1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCTel1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCTel1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Contacto 2", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCon2_Internalname, StringUtil.RTrim( A1749PrvCon2), StringUtil.RTrim( context.localUtil.Format( A1749PrvCon2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCon2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCon2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Telefono", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCTel2_Internalname, StringUtil.RTrim( A1759PrvCTel2), StringUtil.RTrim( context.localUtil.Format( A1759PrvCTel2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCTel2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCTel2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Contacto 3", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCon3_Internalname, StringUtil.RTrim( A1750PrvCon3), StringUtil.RTrim( context.localUtil.Format( A1750PrvCon3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCon3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCon3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Telefono", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCTel3_Internalname, StringUtil.RTrim( A1760PrvCTel3), StringUtil.RTrim( context.localUtil.Format( A1760PrvCTel3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCTel3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCTel3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Contacto 4", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCon4_Internalname, StringUtil.RTrim( A1751PrvCon4), StringUtil.RTrim( context.localUtil.Format( A1751PrvCon4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCon4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCon4_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Telefono", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCTel4_Internalname, StringUtil.RTrim( A1761PrvCTel4), StringUtil.RTrim( context.localUtil.Format( A1761PrvCTel4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCTel4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCTel4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Contacto 5", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCon5_Internalname, StringUtil.RTrim( A1752PrvCon5), StringUtil.RTrim( context.localUtil.Format( A1752PrvCon5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCon5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCon5_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Telefono", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCTel5_Internalname, StringUtil.RTrim( A1762PrvCTel5), StringUtil.RTrim( context.localUtil.Format( A1762PrvCTel5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCTel5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCTel5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Nombre", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvNom_Internalname, StringUtil.RTrim( A1767PrvNom), StringUtil.RTrim( context.localUtil.Format( A1767PrvNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Apellido Paterno", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvAPeP_Internalname, StringUtil.RTrim( A1744PrvAPeP), StringUtil.RTrim( context.localUtil.Format( A1744PrvAPeP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvAPeP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvAPeP_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Apellido Materno", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvAPeM_Internalname, StringUtil.RTrim( A1743PrvAPeM), StringUtil.RTrim( context.localUtil.Format( A1743PrvAPeM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvAPeM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvAPeM_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Distrito", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Provincia", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Codigo Tipo Persona", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPerCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A297TPerCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPerCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A297TPerCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A297TPerCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPerCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Codigo Tipo Documento Sunat", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157TipSCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipSCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A157TipSCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A157TipSCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Proveedor Vinculado", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvVincula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1787PrvVincula), 1, 0, ".", "")), StringUtil.LTrim( ((edtPrvVincula_Enabled!=0) ? context.localUtil.Format( (decimal)(A1787PrvVincula), "9") : context.localUtil.Format( (decimal)(A1787PrvVincula), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,221);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvVincula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvVincula_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Proveedor Afecto a Retención", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvRetencion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1776PrvRetencion), 1, 0, ".", "")), StringUtil.LTrim( ((edtPrvRetencion_Enabled!=0) ? context.localUtil.Format( (decimal)(A1776PrvRetencion), "9") : context.localUtil.Format( (decimal)(A1776PrvRetencion), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvRetencion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvRetencion_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "Tipo de Cuenta", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvTipCuenta1_Internalname, A1781PrvTipCuenta1, StringUtil.RTrim( context.localUtil.Format( A1781PrvTipCuenta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,231);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvTipCuenta1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvTipCuenta1_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Banco 1", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvBanCod1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A296PrvBanCod1), 6, 0, ".", "")), StringUtil.LTrim( ((edtPrvBanCod1_Enabled!=0) ? context.localUtil.Format( (decimal)(A296PrvBanCod1), "ZZZZZ9") : context.localUtil.Format( (decimal)(A296PrvBanCod1), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,236);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvBanCod1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvBanCod1_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "N° Cuenta", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvBanCuenta1_Internalname, A1745PrvBanCuenta1, StringUtil.RTrim( context.localUtil.Format( A1745PrvBanCuenta1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,241);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvBanCuenta1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvBanCuenta1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Tipo de Cuenta", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvTipCuenta2_Internalname, A1782PrvTipCuenta2, StringUtil.RTrim( context.localUtil.Format( A1782PrvTipCuenta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvTipCuenta2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvTipCuenta2_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock47_Internalname, "Banco 2", "", "", lblTextblock47_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvBanCod2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A299PrvBanCod2), 6, 0, ".", "")), StringUtil.LTrim( ((edtPrvBanCod2_Enabled!=0) ? context.localUtil.Format( (decimal)(A299PrvBanCod2), "ZZZZZ9") : context.localUtil.Format( (decimal)(A299PrvBanCod2), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,251);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvBanCod2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvBanCod2_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock48_Internalname, "N° Cuenta", "", "", lblTextblock48_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvBanCuenta2_Internalname, A1746PrvBanCuenta2, StringUtil.RTrim( context.localUtil.Format( A1746PrvBanCuenta2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,256);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvBanCuenta2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvBanCuenta2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock49_Internalname, "Usuario Creación", "", "", lblTextblock49_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvUsuCod_Internalname, StringUtil.RTrim( A1783PrvUsuCod), StringUtil.RTrim( context.localUtil.Format( A1783PrvUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,261);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock50_Internalname, "Fecha Hora", "", "", lblTextblock50_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrvUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrvUsuFec_Internalname, context.localUtil.TToC( A1785PrvUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1785PrvUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,266);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         GxWebStd.gx_bitmap( context, edtPrvUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPrvUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock51_Internalname, "Usuario Modificación", "", "", lblTextblock51_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvUsuCodM_Internalname, StringUtil.RTrim( A1784PrvUsuCodM), StringUtil.RTrim( context.localUtil.Format( A1784PrvUsuCodM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,271);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvUsuCodM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvUsuCodM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock52_Internalname, "Fecha Hora Modificación", "", "", lblTextblock52_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 276,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrvUsuFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrvUsuFecM_Internalname, context.localUtil.TToC( A1786PrvUsuFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1786PrvUsuFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,276);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvUsuFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvUsuFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         GxWebStd.gx_bitmap( context, edtPrvUsuFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPrvUsuFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock53_Internalname, "Usuario Web", "", "", lblTextblock53_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvWebUsu_Internalname, StringUtil.RTrim( A1791PrvWebUsu), StringUtil.RTrim( context.localUtil.Format( A1791PrvWebUsu, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,281);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvWebUsu_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvWebUsu_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock54_Internalname, "Password Web", "", "", lblTextblock54_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvWebPas_Internalname, StringUtil.RTrim( A1790PrvWebPas), StringUtil.RTrim( context.localUtil.Format( A1790PrvWebPas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,286);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvWebPas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvWebPas_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock55_Internalname, "Fecha Hora Creación", "", "", lblTextblock55_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 291,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrvWebFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrvWebFec_Internalname, context.localUtil.TToC( A1789PrvWebFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1789PrvWebFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,291);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvWebFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvWebFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPPROVEEDORES.htm");
         GxWebStd.gx_bitmap( context, edtPrvWebFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPrvWebFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock56_Internalname, "Condición de Pago", "", "", lblTextblock56_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvConpDsc_Internalname, StringUtil.RTrim( A1756PrvConpDsc), StringUtil.RTrim( context.localUtil.Format( A1756PrvConpDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPPROVEEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 299,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 300,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 301,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPPROVEEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 303,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPPROVEEDORES.htm");
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
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z247PrvDsc = cgiGet( "Z247PrvDsc");
            Z1763PrvDir = cgiGet( "Z1763PrvDir");
            Z1779PrvTel1 = cgiGet( "Z1779PrvTel1");
            Z1780PrvTel2 = cgiGet( "Z1780PrvTel2");
            Z1765PrvFax = cgiGet( "Z1765PrvFax");
            Z1747PrvCel = cgiGet( "Z1747PrvCel");
            Z1764PrvEM = cgiGet( "Z1764PrvEM");
            Z1788PrvWeb = cgiGet( "Z1788PrvWeb");
            Z1777PrvSts = (short)(context.localUtil.CToN( cgiGet( "Z1777PrvSts"), ".", ","));
            Z1768PrvRef1 = cgiGet( "Z1768PrvRef1");
            Z1769PrvRef2 = cgiGet( "Z1769PrvRef2");
            Z1770PrvRef3 = cgiGet( "Z1770PrvRef3");
            Z1771PrvRef4 = cgiGet( "Z1771PrvRef4");
            Z1772PrvRef5 = cgiGet( "Z1772PrvRef5");
            Z1773PrvRef6 = cgiGet( "Z1773PrvRef6");
            Z1774PrvRef7 = cgiGet( "Z1774PrvRef7");
            Z1775PrvRef8 = cgiGet( "Z1775PrvRef8");
            Z1748PrvCon1 = cgiGet( "Z1748PrvCon1");
            Z1758PrvCTel1 = cgiGet( "Z1758PrvCTel1");
            Z1749PrvCon2 = cgiGet( "Z1749PrvCon2");
            Z1759PrvCTel2 = cgiGet( "Z1759PrvCTel2");
            Z1750PrvCon3 = cgiGet( "Z1750PrvCon3");
            Z1760PrvCTel3 = cgiGet( "Z1760PrvCTel3");
            Z1751PrvCon4 = cgiGet( "Z1751PrvCon4");
            Z1761PrvCTel4 = cgiGet( "Z1761PrvCTel4");
            Z1752PrvCon5 = cgiGet( "Z1752PrvCon5");
            Z1762PrvCTel5 = cgiGet( "Z1762PrvCTel5");
            Z1767PrvNom = cgiGet( "Z1767PrvNom");
            Z1744PrvAPeP = cgiGet( "Z1744PrvAPeP");
            Z1743PrvAPeM = cgiGet( "Z1743PrvAPeM");
            Z1787PrvVincula = (short)(context.localUtil.CToN( cgiGet( "Z1787PrvVincula"), ".", ","));
            Z1776PrvRetencion = (short)(context.localUtil.CToN( cgiGet( "Z1776PrvRetencion"), ".", ","));
            Z1781PrvTipCuenta1 = cgiGet( "Z1781PrvTipCuenta1");
            Z1745PrvBanCuenta1 = cgiGet( "Z1745PrvBanCuenta1");
            Z1782PrvTipCuenta2 = cgiGet( "Z1782PrvTipCuenta2");
            Z1778PrvTCon = (int)(context.localUtil.CToN( cgiGet( "Z1778PrvTCon"), ".", ","));
            Z1746PrvBanCuenta2 = cgiGet( "Z1746PrvBanCuenta2");
            Z1783PrvUsuCod = cgiGet( "Z1783PrvUsuCod");
            Z1785PrvUsuFec = context.localUtil.CToT( cgiGet( "Z1785PrvUsuFec"), 0);
            Z1784PrvUsuCodM = cgiGet( "Z1784PrvUsuCodM");
            Z1786PrvUsuFecM = context.localUtil.CToT( cgiGet( "Z1786PrvUsuFecM"), 0);
            Z1791PrvWebUsu = cgiGet( "Z1791PrvWebUsu");
            Z1790PrvWebPas = cgiGet( "Z1790PrvWebPas");
            Z1789PrvWebFec = context.localUtil.CToT( cgiGet( "Z1789PrvWebFec"), 0);
            Z139PaiCod = cgiGet( "Z139PaiCod");
            Z140EstCod = cgiGet( "Z140EstCod");
            Z141ProvCod = cgiGet( "Z141ProvCod");
            Z142DisCod = cgiGet( "Z142DisCod");
            Z298TprvCod = (int)(context.localUtil.CToN( cgiGet( "Z298TprvCod"), ".", ","));
            Z297TPerCod = (int)(context.localUtil.CToN( cgiGet( "Z297TPerCod"), ".", ","));
            n297TPerCod = ((0==A297TPerCod) ? true : false);
            Z157TipSCod = (int)(context.localUtil.CToN( cgiGet( "Z157TipSCod"), ".", ","));
            n157TipSCod = ((0==A157TipSCod) ? true : false);
            Z300PrvConpCod = (int)(context.localUtil.CToN( cgiGet( "Z300PrvConpCod"), ".", ","));
            Z296PrvBanCod1 = (int)(context.localUtil.CToN( cgiGet( "Z296PrvBanCod1"), ".", ","));
            n296PrvBanCod1 = ((0==A296PrvBanCod1) ? true : false);
            Z299PrvBanCod2 = (int)(context.localUtil.CToN( cgiGet( "Z299PrvBanCod2"), ".", ","));
            n299PrvBanCod2 = ((0==A299PrvBanCod2) ? true : false);
            A1778PrvTCon = (int)(context.localUtil.CToN( cgiGet( "Z1778PrvTCon"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000PrvFoto_GXI = cgiGet( "PRVFOTO_GXI");
            n40000PrvFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000PrvFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? true : false);
            A1778PrvTCon = (int)(context.localUtil.CToN( cgiGet( "PRVTCON"), ".", ","));
            /* Read variables values. */
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = cgiGet( edtPrvDir_Internalname);
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A140EstCod = cgiGet( edtEstCod_Internalname);
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A139PaiCod = cgiGet( edtPaiCod_Internalname);
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A1779PrvTel1 = cgiGet( edtPrvTel1_Internalname);
            AssignAttri("", false, "A1779PrvTel1", A1779PrvTel1);
            A1780PrvTel2 = cgiGet( edtPrvTel2_Internalname);
            AssignAttri("", false, "A1780PrvTel2", A1780PrvTel2);
            A1765PrvFax = cgiGet( edtPrvFax_Internalname);
            AssignAttri("", false, "A1765PrvFax", A1765PrvFax);
            A1747PrvCel = cgiGet( edtPrvCel_Internalname);
            AssignAttri("", false, "A1747PrvCel", A1747PrvCel);
            A1764PrvEM = cgiGet( edtPrvEM_Internalname);
            AssignAttri("", false, "A1764PrvEM", A1764PrvEM);
            A1788PrvWeb = cgiGet( edtPrvWeb_Internalname);
            AssignAttri("", false, "A1788PrvWeb", A1788PrvWeb);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPRVCOD");
               AnyError = 1;
               GX_FocusControl = edtTprvCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A298TprvCod = 0;
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            }
            else
            {
               A298TprvCod = (int)(context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ","));
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            }
            A1766PrvFoto = cgiGet( imgPrvFoto_Internalname);
            n1766PrvFoto = false;
            AssignAttri("", false, "A1766PrvFoto", A1766PrvFoto);
            n1766PrvFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVSTS");
               AnyError = 1;
               GX_FocusControl = edtPrvSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1777PrvSts = 0;
               AssignAttri("", false, "A1777PrvSts", StringUtil.Str( (decimal)(A1777PrvSts), 1, 0));
            }
            else
            {
               A1777PrvSts = (short)(context.localUtil.CToN( cgiGet( edtPrvSts_Internalname), ".", ","));
               AssignAttri("", false, "A1777PrvSts", StringUtil.Str( (decimal)(A1777PrvSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtPrvConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A300PrvConpCod = 0;
               AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            }
            else
            {
               A300PrvConpCod = (int)(context.localUtil.CToN( cgiGet( edtPrvConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            }
            A1768PrvRef1 = cgiGet( edtPrvRef1_Internalname);
            AssignAttri("", false, "A1768PrvRef1", A1768PrvRef1);
            A1769PrvRef2 = cgiGet( edtPrvRef2_Internalname);
            AssignAttri("", false, "A1769PrvRef2", A1769PrvRef2);
            A1770PrvRef3 = cgiGet( edtPrvRef3_Internalname);
            AssignAttri("", false, "A1770PrvRef3", A1770PrvRef3);
            A1771PrvRef4 = cgiGet( edtPrvRef4_Internalname);
            AssignAttri("", false, "A1771PrvRef4", A1771PrvRef4);
            A1772PrvRef5 = cgiGet( edtPrvRef5_Internalname);
            AssignAttri("", false, "A1772PrvRef5", A1772PrvRef5);
            A1773PrvRef6 = cgiGet( edtPrvRef6_Internalname);
            AssignAttri("", false, "A1773PrvRef6", A1773PrvRef6);
            A1774PrvRef7 = cgiGet( edtPrvRef7_Internalname);
            AssignAttri("", false, "A1774PrvRef7", A1774PrvRef7);
            A1775PrvRef8 = cgiGet( edtPrvRef8_Internalname);
            AssignAttri("", false, "A1775PrvRef8", A1775PrvRef8);
            A1748PrvCon1 = cgiGet( edtPrvCon1_Internalname);
            AssignAttri("", false, "A1748PrvCon1", A1748PrvCon1);
            A1758PrvCTel1 = cgiGet( edtPrvCTel1_Internalname);
            AssignAttri("", false, "A1758PrvCTel1", A1758PrvCTel1);
            A1749PrvCon2 = cgiGet( edtPrvCon2_Internalname);
            AssignAttri("", false, "A1749PrvCon2", A1749PrvCon2);
            A1759PrvCTel2 = cgiGet( edtPrvCTel2_Internalname);
            AssignAttri("", false, "A1759PrvCTel2", A1759PrvCTel2);
            A1750PrvCon3 = cgiGet( edtPrvCon3_Internalname);
            AssignAttri("", false, "A1750PrvCon3", A1750PrvCon3);
            A1760PrvCTel3 = cgiGet( edtPrvCTel3_Internalname);
            AssignAttri("", false, "A1760PrvCTel3", A1760PrvCTel3);
            A1751PrvCon4 = cgiGet( edtPrvCon4_Internalname);
            AssignAttri("", false, "A1751PrvCon4", A1751PrvCon4);
            A1761PrvCTel4 = cgiGet( edtPrvCTel4_Internalname);
            AssignAttri("", false, "A1761PrvCTel4", A1761PrvCTel4);
            A1752PrvCon5 = cgiGet( edtPrvCon5_Internalname);
            AssignAttri("", false, "A1752PrvCon5", A1752PrvCon5);
            A1762PrvCTel5 = cgiGet( edtPrvCTel5_Internalname);
            AssignAttri("", false, "A1762PrvCTel5", A1762PrvCTel5);
            A1767PrvNom = cgiGet( edtPrvNom_Internalname);
            AssignAttri("", false, "A1767PrvNom", A1767PrvNom);
            A1744PrvAPeP = cgiGet( edtPrvAPeP_Internalname);
            AssignAttri("", false, "A1744PrvAPeP", A1744PrvAPeP);
            A1743PrvAPeM = cgiGet( edtPrvAPeM_Internalname);
            AssignAttri("", false, "A1743PrvAPeM", A1743PrvAPeM);
            A142DisCod = cgiGet( edtDisCod_Internalname);
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A141ProvCod = cgiGet( edtProvCod_Internalname);
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A297TPerCod = 0;
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            }
            else
            {
               A297TPerCod = (int)(context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ","));
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            }
            n297TPerCod = ((0==A297TPerCod) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSCOD");
               AnyError = 1;
               GX_FocusControl = edtTipSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A157TipSCod = 0;
               n157TipSCod = false;
               AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            }
            else
            {
               A157TipSCod = (int)(context.localUtil.CToN( cgiGet( edtTipSCod_Internalname), ".", ","));
               n157TipSCod = false;
               AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            }
            n157TipSCod = ((0==A157TipSCod) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvVincula_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvVincula_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVVINCULA");
               AnyError = 1;
               GX_FocusControl = edtPrvVincula_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1787PrvVincula = 0;
               AssignAttri("", false, "A1787PrvVincula", StringUtil.Str( (decimal)(A1787PrvVincula), 1, 0));
            }
            else
            {
               A1787PrvVincula = (short)(context.localUtil.CToN( cgiGet( edtPrvVincula_Internalname), ".", ","));
               AssignAttri("", false, "A1787PrvVincula", StringUtil.Str( (decimal)(A1787PrvVincula), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvRetencion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvRetencion_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVRETENCION");
               AnyError = 1;
               GX_FocusControl = edtPrvRetencion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1776PrvRetencion = 0;
               AssignAttri("", false, "A1776PrvRetencion", StringUtil.Str( (decimal)(A1776PrvRetencion), 1, 0));
            }
            else
            {
               A1776PrvRetencion = (short)(context.localUtil.CToN( cgiGet( edtPrvRetencion_Internalname), ".", ","));
               AssignAttri("", false, "A1776PrvRetencion", StringUtil.Str( (decimal)(A1776PrvRetencion), 1, 0));
            }
            A1781PrvTipCuenta1 = cgiGet( edtPrvTipCuenta1_Internalname);
            AssignAttri("", false, "A1781PrvTipCuenta1", A1781PrvTipCuenta1);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvBanCod1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvBanCod1_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVBANCOD1");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A296PrvBanCod1 = 0;
               n296PrvBanCod1 = false;
               AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
            }
            else
            {
               A296PrvBanCod1 = (int)(context.localUtil.CToN( cgiGet( edtPrvBanCod1_Internalname), ".", ","));
               n296PrvBanCod1 = false;
               AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
            }
            n296PrvBanCod1 = ((0==A296PrvBanCod1) ? true : false);
            A1745PrvBanCuenta1 = cgiGet( edtPrvBanCuenta1_Internalname);
            AssignAttri("", false, "A1745PrvBanCuenta1", A1745PrvBanCuenta1);
            A1782PrvTipCuenta2 = cgiGet( edtPrvTipCuenta2_Internalname);
            AssignAttri("", false, "A1782PrvTipCuenta2", A1782PrvTipCuenta2);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPrvBanCod2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrvBanCod2_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRVBANCOD2");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A299PrvBanCod2 = 0;
               n299PrvBanCod2 = false;
               AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
            }
            else
            {
               A299PrvBanCod2 = (int)(context.localUtil.CToN( cgiGet( edtPrvBanCod2_Internalname), ".", ","));
               n299PrvBanCod2 = false;
               AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
            }
            n299PrvBanCod2 = ((0==A299PrvBanCod2) ? true : false);
            A1746PrvBanCuenta2 = cgiGet( edtPrvBanCuenta2_Internalname);
            AssignAttri("", false, "A1746PrvBanCuenta2", A1746PrvBanCuenta2);
            A1783PrvUsuCod = cgiGet( edtPrvUsuCod_Internalname);
            AssignAttri("", false, "A1783PrvUsuCod", A1783PrvUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtPrvUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "PRVUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtPrvUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1785PrvUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1785PrvUsuFec = context.localUtil.CToT( cgiGet( edtPrvUsuFec_Internalname));
               AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1784PrvUsuCodM = cgiGet( edtPrvUsuCodM_Internalname);
            AssignAttri("", false, "A1784PrvUsuCodM", A1784PrvUsuCodM);
            if ( context.localUtil.VCDateTime( cgiGet( edtPrvUsuFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora Modificación"}), 1, "PRVUSUFECM");
               AnyError = 1;
               GX_FocusControl = edtPrvUsuFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1786PrvUsuFecM = context.localUtil.CToT( cgiGet( edtPrvUsuFecM_Internalname));
               AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            A1791PrvWebUsu = cgiGet( edtPrvWebUsu_Internalname);
            AssignAttri("", false, "A1791PrvWebUsu", A1791PrvWebUsu);
            A1790PrvWebPas = cgiGet( edtPrvWebPas_Internalname);
            AssignAttri("", false, "A1790PrvWebPas", A1790PrvWebPas);
            if ( context.localUtil.VCDateTime( cgiGet( edtPrvWebFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora Creación"}), 1, "PRVWEBFEC");
               AnyError = 1;
               GX_FocusControl = edtPrvWebFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1789PrvWebFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1789PrvWebFec = context.localUtil.CToT( cgiGet( edtPrvWebFec_Internalname));
               AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1756PrvConpDsc = cgiGet( edtPrvConpDsc_Internalname);
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgPrvFoto_Internalname, ref  A1766PrvFoto, ref  A40000PrvFoto_GXI);
            n40000PrvFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000PrvFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? true : false);
            n1766PrvFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? true : false);
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CPPROVEEDORES");
            forbiddenHiddens.Add("PrvTCon", context.localUtil.Format( (decimal)(A1778PrvTCon), "ZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cpproveedores:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A244PrvCod = GetPar( "PrvCod");
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
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
               InitAll3L124( ) ;
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
         DisableAttributes3L124( ) ;
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

      protected void CONFIRM_3L0( )
      {
         BeforeValidate3L124( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3L124( ) ;
            }
            else
            {
               CheckExtendedTable3L124( ) ;
               if ( AnyError == 0 )
               {
                  ZM3L124( 5) ;
                  ZM3L124( 6) ;
                  ZM3L124( 7) ;
                  ZM3L124( 8) ;
                  ZM3L124( 9) ;
                  ZM3L124( 10) ;
                  ZM3L124( 11) ;
               }
               CloseExtendedTableCursors3L124( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3L0( ) ;
         }
      }

      protected void ResetCaption3L0( )
      {
      }

      protected void ZM3L124( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z247PrvDsc = T003L3_A247PrvDsc[0];
               Z1763PrvDir = T003L3_A1763PrvDir[0];
               Z1779PrvTel1 = T003L3_A1779PrvTel1[0];
               Z1780PrvTel2 = T003L3_A1780PrvTel2[0];
               Z1765PrvFax = T003L3_A1765PrvFax[0];
               Z1747PrvCel = T003L3_A1747PrvCel[0];
               Z1764PrvEM = T003L3_A1764PrvEM[0];
               Z1788PrvWeb = T003L3_A1788PrvWeb[0];
               Z1777PrvSts = T003L3_A1777PrvSts[0];
               Z1768PrvRef1 = T003L3_A1768PrvRef1[0];
               Z1769PrvRef2 = T003L3_A1769PrvRef2[0];
               Z1770PrvRef3 = T003L3_A1770PrvRef3[0];
               Z1771PrvRef4 = T003L3_A1771PrvRef4[0];
               Z1772PrvRef5 = T003L3_A1772PrvRef5[0];
               Z1773PrvRef6 = T003L3_A1773PrvRef6[0];
               Z1774PrvRef7 = T003L3_A1774PrvRef7[0];
               Z1775PrvRef8 = T003L3_A1775PrvRef8[0];
               Z1748PrvCon1 = T003L3_A1748PrvCon1[0];
               Z1758PrvCTel1 = T003L3_A1758PrvCTel1[0];
               Z1749PrvCon2 = T003L3_A1749PrvCon2[0];
               Z1759PrvCTel2 = T003L3_A1759PrvCTel2[0];
               Z1750PrvCon3 = T003L3_A1750PrvCon3[0];
               Z1760PrvCTel3 = T003L3_A1760PrvCTel3[0];
               Z1751PrvCon4 = T003L3_A1751PrvCon4[0];
               Z1761PrvCTel4 = T003L3_A1761PrvCTel4[0];
               Z1752PrvCon5 = T003L3_A1752PrvCon5[0];
               Z1762PrvCTel5 = T003L3_A1762PrvCTel5[0];
               Z1767PrvNom = T003L3_A1767PrvNom[0];
               Z1744PrvAPeP = T003L3_A1744PrvAPeP[0];
               Z1743PrvAPeM = T003L3_A1743PrvAPeM[0];
               Z1787PrvVincula = T003L3_A1787PrvVincula[0];
               Z1776PrvRetencion = T003L3_A1776PrvRetencion[0];
               Z1781PrvTipCuenta1 = T003L3_A1781PrvTipCuenta1[0];
               Z1745PrvBanCuenta1 = T003L3_A1745PrvBanCuenta1[0];
               Z1782PrvTipCuenta2 = T003L3_A1782PrvTipCuenta2[0];
               Z1778PrvTCon = T003L3_A1778PrvTCon[0];
               Z1746PrvBanCuenta2 = T003L3_A1746PrvBanCuenta2[0];
               Z1783PrvUsuCod = T003L3_A1783PrvUsuCod[0];
               Z1785PrvUsuFec = T003L3_A1785PrvUsuFec[0];
               Z1784PrvUsuCodM = T003L3_A1784PrvUsuCodM[0];
               Z1786PrvUsuFecM = T003L3_A1786PrvUsuFecM[0];
               Z1791PrvWebUsu = T003L3_A1791PrvWebUsu[0];
               Z1790PrvWebPas = T003L3_A1790PrvWebPas[0];
               Z1789PrvWebFec = T003L3_A1789PrvWebFec[0];
               Z139PaiCod = T003L3_A139PaiCod[0];
               Z140EstCod = T003L3_A140EstCod[0];
               Z141ProvCod = T003L3_A141ProvCod[0];
               Z142DisCod = T003L3_A142DisCod[0];
               Z298TprvCod = T003L3_A298TprvCod[0];
               Z297TPerCod = T003L3_A297TPerCod[0];
               Z157TipSCod = T003L3_A157TipSCod[0];
               Z300PrvConpCod = T003L3_A300PrvConpCod[0];
               Z296PrvBanCod1 = T003L3_A296PrvBanCod1[0];
               Z299PrvBanCod2 = T003L3_A299PrvBanCod2[0];
            }
            else
            {
               Z247PrvDsc = A247PrvDsc;
               Z1763PrvDir = A1763PrvDir;
               Z1779PrvTel1 = A1779PrvTel1;
               Z1780PrvTel2 = A1780PrvTel2;
               Z1765PrvFax = A1765PrvFax;
               Z1747PrvCel = A1747PrvCel;
               Z1764PrvEM = A1764PrvEM;
               Z1788PrvWeb = A1788PrvWeb;
               Z1777PrvSts = A1777PrvSts;
               Z1768PrvRef1 = A1768PrvRef1;
               Z1769PrvRef2 = A1769PrvRef2;
               Z1770PrvRef3 = A1770PrvRef3;
               Z1771PrvRef4 = A1771PrvRef4;
               Z1772PrvRef5 = A1772PrvRef5;
               Z1773PrvRef6 = A1773PrvRef6;
               Z1774PrvRef7 = A1774PrvRef7;
               Z1775PrvRef8 = A1775PrvRef8;
               Z1748PrvCon1 = A1748PrvCon1;
               Z1758PrvCTel1 = A1758PrvCTel1;
               Z1749PrvCon2 = A1749PrvCon2;
               Z1759PrvCTel2 = A1759PrvCTel2;
               Z1750PrvCon3 = A1750PrvCon3;
               Z1760PrvCTel3 = A1760PrvCTel3;
               Z1751PrvCon4 = A1751PrvCon4;
               Z1761PrvCTel4 = A1761PrvCTel4;
               Z1752PrvCon5 = A1752PrvCon5;
               Z1762PrvCTel5 = A1762PrvCTel5;
               Z1767PrvNom = A1767PrvNom;
               Z1744PrvAPeP = A1744PrvAPeP;
               Z1743PrvAPeM = A1743PrvAPeM;
               Z1787PrvVincula = A1787PrvVincula;
               Z1776PrvRetencion = A1776PrvRetencion;
               Z1781PrvTipCuenta1 = A1781PrvTipCuenta1;
               Z1745PrvBanCuenta1 = A1745PrvBanCuenta1;
               Z1782PrvTipCuenta2 = A1782PrvTipCuenta2;
               Z1778PrvTCon = A1778PrvTCon;
               Z1746PrvBanCuenta2 = A1746PrvBanCuenta2;
               Z1783PrvUsuCod = A1783PrvUsuCod;
               Z1785PrvUsuFec = A1785PrvUsuFec;
               Z1784PrvUsuCodM = A1784PrvUsuCodM;
               Z1786PrvUsuFecM = A1786PrvUsuFecM;
               Z1791PrvWebUsu = A1791PrvWebUsu;
               Z1790PrvWebPas = A1790PrvWebPas;
               Z1789PrvWebFec = A1789PrvWebFec;
               Z139PaiCod = A139PaiCod;
               Z140EstCod = A140EstCod;
               Z141ProvCod = A141ProvCod;
               Z142DisCod = A142DisCod;
               Z298TprvCod = A298TprvCod;
               Z297TPerCod = A297TPerCod;
               Z157TipSCod = A157TipSCod;
               Z300PrvConpCod = A300PrvConpCod;
               Z296PrvBanCod1 = A296PrvBanCod1;
               Z299PrvBanCod2 = A299PrvBanCod2;
            }
         }
         if ( GX_JID == -4 )
         {
            Z244PrvCod = A244PrvCod;
            Z247PrvDsc = A247PrvDsc;
            Z1763PrvDir = A1763PrvDir;
            Z1779PrvTel1 = A1779PrvTel1;
            Z1780PrvTel2 = A1780PrvTel2;
            Z1765PrvFax = A1765PrvFax;
            Z1747PrvCel = A1747PrvCel;
            Z1764PrvEM = A1764PrvEM;
            Z1788PrvWeb = A1788PrvWeb;
            Z1766PrvFoto = A1766PrvFoto;
            Z40000PrvFoto_GXI = A40000PrvFoto_GXI;
            Z1777PrvSts = A1777PrvSts;
            Z1768PrvRef1 = A1768PrvRef1;
            Z1769PrvRef2 = A1769PrvRef2;
            Z1770PrvRef3 = A1770PrvRef3;
            Z1771PrvRef4 = A1771PrvRef4;
            Z1772PrvRef5 = A1772PrvRef5;
            Z1773PrvRef6 = A1773PrvRef6;
            Z1774PrvRef7 = A1774PrvRef7;
            Z1775PrvRef8 = A1775PrvRef8;
            Z1748PrvCon1 = A1748PrvCon1;
            Z1758PrvCTel1 = A1758PrvCTel1;
            Z1749PrvCon2 = A1749PrvCon2;
            Z1759PrvCTel2 = A1759PrvCTel2;
            Z1750PrvCon3 = A1750PrvCon3;
            Z1760PrvCTel3 = A1760PrvCTel3;
            Z1751PrvCon4 = A1751PrvCon4;
            Z1761PrvCTel4 = A1761PrvCTel4;
            Z1752PrvCon5 = A1752PrvCon5;
            Z1762PrvCTel5 = A1762PrvCTel5;
            Z1767PrvNom = A1767PrvNom;
            Z1744PrvAPeP = A1744PrvAPeP;
            Z1743PrvAPeM = A1743PrvAPeM;
            Z1787PrvVincula = A1787PrvVincula;
            Z1776PrvRetencion = A1776PrvRetencion;
            Z1781PrvTipCuenta1 = A1781PrvTipCuenta1;
            Z1745PrvBanCuenta1 = A1745PrvBanCuenta1;
            Z1782PrvTipCuenta2 = A1782PrvTipCuenta2;
            Z1778PrvTCon = A1778PrvTCon;
            Z1746PrvBanCuenta2 = A1746PrvBanCuenta2;
            Z1783PrvUsuCod = A1783PrvUsuCod;
            Z1785PrvUsuFec = A1785PrvUsuFec;
            Z1784PrvUsuCodM = A1784PrvUsuCodM;
            Z1786PrvUsuFecM = A1786PrvUsuFecM;
            Z1791PrvWebUsu = A1791PrvWebUsu;
            Z1790PrvWebPas = A1790PrvWebPas;
            Z1789PrvWebFec = A1789PrvWebFec;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z142DisCod = A142DisCod;
            Z298TprvCod = A298TprvCod;
            Z297TPerCod = A297TPerCod;
            Z157TipSCod = A157TipSCod;
            Z300PrvConpCod = A300PrvConpCod;
            Z296PrvBanCod1 = A296PrvBanCod1;
            Z299PrvBanCod2 = A299PrvBanCod2;
            Z1756PrvConpDsc = A1756PrvConpDsc;
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

      protected void Load3L124( )
      {
         /* Using cursor T003L11 */
         pr_default.execute(9, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound124 = 1;
            A247PrvDsc = T003L11_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003L11_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A1779PrvTel1 = T003L11_A1779PrvTel1[0];
            AssignAttri("", false, "A1779PrvTel1", A1779PrvTel1);
            A1780PrvTel2 = T003L11_A1780PrvTel2[0];
            AssignAttri("", false, "A1780PrvTel2", A1780PrvTel2);
            A1765PrvFax = T003L11_A1765PrvFax[0];
            AssignAttri("", false, "A1765PrvFax", A1765PrvFax);
            A1747PrvCel = T003L11_A1747PrvCel[0];
            AssignAttri("", false, "A1747PrvCel", A1747PrvCel);
            A1764PrvEM = T003L11_A1764PrvEM[0];
            AssignAttri("", false, "A1764PrvEM", A1764PrvEM);
            A1788PrvWeb = T003L11_A1788PrvWeb[0];
            AssignAttri("", false, "A1788PrvWeb", A1788PrvWeb);
            A40000PrvFoto_GXI = T003L11_A40000PrvFoto_GXI[0];
            n40000PrvFoto_GXI = T003L11_n40000PrvFoto_GXI[0];
            AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
            AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
            A1777PrvSts = T003L11_A1777PrvSts[0];
            AssignAttri("", false, "A1777PrvSts", StringUtil.Str( (decimal)(A1777PrvSts), 1, 0));
            A1768PrvRef1 = T003L11_A1768PrvRef1[0];
            AssignAttri("", false, "A1768PrvRef1", A1768PrvRef1);
            A1769PrvRef2 = T003L11_A1769PrvRef2[0];
            AssignAttri("", false, "A1769PrvRef2", A1769PrvRef2);
            A1770PrvRef3 = T003L11_A1770PrvRef3[0];
            AssignAttri("", false, "A1770PrvRef3", A1770PrvRef3);
            A1771PrvRef4 = T003L11_A1771PrvRef4[0];
            AssignAttri("", false, "A1771PrvRef4", A1771PrvRef4);
            A1772PrvRef5 = T003L11_A1772PrvRef5[0];
            AssignAttri("", false, "A1772PrvRef5", A1772PrvRef5);
            A1773PrvRef6 = T003L11_A1773PrvRef6[0];
            AssignAttri("", false, "A1773PrvRef6", A1773PrvRef6);
            A1774PrvRef7 = T003L11_A1774PrvRef7[0];
            AssignAttri("", false, "A1774PrvRef7", A1774PrvRef7);
            A1775PrvRef8 = T003L11_A1775PrvRef8[0];
            AssignAttri("", false, "A1775PrvRef8", A1775PrvRef8);
            A1748PrvCon1 = T003L11_A1748PrvCon1[0];
            AssignAttri("", false, "A1748PrvCon1", A1748PrvCon1);
            A1758PrvCTel1 = T003L11_A1758PrvCTel1[0];
            AssignAttri("", false, "A1758PrvCTel1", A1758PrvCTel1);
            A1749PrvCon2 = T003L11_A1749PrvCon2[0];
            AssignAttri("", false, "A1749PrvCon2", A1749PrvCon2);
            A1759PrvCTel2 = T003L11_A1759PrvCTel2[0];
            AssignAttri("", false, "A1759PrvCTel2", A1759PrvCTel2);
            A1750PrvCon3 = T003L11_A1750PrvCon3[0];
            AssignAttri("", false, "A1750PrvCon3", A1750PrvCon3);
            A1760PrvCTel3 = T003L11_A1760PrvCTel3[0];
            AssignAttri("", false, "A1760PrvCTel3", A1760PrvCTel3);
            A1751PrvCon4 = T003L11_A1751PrvCon4[0];
            AssignAttri("", false, "A1751PrvCon4", A1751PrvCon4);
            A1761PrvCTel4 = T003L11_A1761PrvCTel4[0];
            AssignAttri("", false, "A1761PrvCTel4", A1761PrvCTel4);
            A1752PrvCon5 = T003L11_A1752PrvCon5[0];
            AssignAttri("", false, "A1752PrvCon5", A1752PrvCon5);
            A1762PrvCTel5 = T003L11_A1762PrvCTel5[0];
            AssignAttri("", false, "A1762PrvCTel5", A1762PrvCTel5);
            A1767PrvNom = T003L11_A1767PrvNom[0];
            AssignAttri("", false, "A1767PrvNom", A1767PrvNom);
            A1744PrvAPeP = T003L11_A1744PrvAPeP[0];
            AssignAttri("", false, "A1744PrvAPeP", A1744PrvAPeP);
            A1743PrvAPeM = T003L11_A1743PrvAPeM[0];
            AssignAttri("", false, "A1743PrvAPeM", A1743PrvAPeM);
            A1787PrvVincula = T003L11_A1787PrvVincula[0];
            AssignAttri("", false, "A1787PrvVincula", StringUtil.Str( (decimal)(A1787PrvVincula), 1, 0));
            A1776PrvRetencion = T003L11_A1776PrvRetencion[0];
            AssignAttri("", false, "A1776PrvRetencion", StringUtil.Str( (decimal)(A1776PrvRetencion), 1, 0));
            A1781PrvTipCuenta1 = T003L11_A1781PrvTipCuenta1[0];
            AssignAttri("", false, "A1781PrvTipCuenta1", A1781PrvTipCuenta1);
            A1745PrvBanCuenta1 = T003L11_A1745PrvBanCuenta1[0];
            AssignAttri("", false, "A1745PrvBanCuenta1", A1745PrvBanCuenta1);
            A1782PrvTipCuenta2 = T003L11_A1782PrvTipCuenta2[0];
            AssignAttri("", false, "A1782PrvTipCuenta2", A1782PrvTipCuenta2);
            A1778PrvTCon = T003L11_A1778PrvTCon[0];
            A1746PrvBanCuenta2 = T003L11_A1746PrvBanCuenta2[0];
            AssignAttri("", false, "A1746PrvBanCuenta2", A1746PrvBanCuenta2);
            A1783PrvUsuCod = T003L11_A1783PrvUsuCod[0];
            AssignAttri("", false, "A1783PrvUsuCod", A1783PrvUsuCod);
            A1785PrvUsuFec = T003L11_A1785PrvUsuFec[0];
            AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1784PrvUsuCodM = T003L11_A1784PrvUsuCodM[0];
            AssignAttri("", false, "A1784PrvUsuCodM", A1784PrvUsuCodM);
            A1786PrvUsuFecM = T003L11_A1786PrvUsuFecM[0];
            AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A1791PrvWebUsu = T003L11_A1791PrvWebUsu[0];
            AssignAttri("", false, "A1791PrvWebUsu", A1791PrvWebUsu);
            A1790PrvWebPas = T003L11_A1790PrvWebPas[0];
            AssignAttri("", false, "A1790PrvWebPas", A1790PrvWebPas);
            A1789PrvWebFec = T003L11_A1789PrvWebFec[0];
            AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 8, 5, 0, 3, "/", ":", " "));
            A1756PrvConpDsc = T003L11_A1756PrvConpDsc[0];
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            A139PaiCod = T003L11_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T003L11_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T003L11_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T003L11_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A298TprvCod = T003L11_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            A297TPerCod = T003L11_A297TPerCod[0];
            n297TPerCod = T003L11_n297TPerCod[0];
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            A157TipSCod = T003L11_A157TipSCod[0];
            n157TipSCod = T003L11_n157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A300PrvConpCod = T003L11_A300PrvConpCod[0];
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            A296PrvBanCod1 = T003L11_A296PrvBanCod1[0];
            n296PrvBanCod1 = T003L11_n296PrvBanCod1[0];
            AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
            A299PrvBanCod2 = T003L11_A299PrvBanCod2[0];
            n299PrvBanCod2 = T003L11_n299PrvBanCod2[0];
            AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
            A1766PrvFoto = T003L11_A1766PrvFoto[0];
            n1766PrvFoto = T003L11_n1766PrvFoto[0];
            AssignAttri("", false, "A1766PrvFoto", A1766PrvFoto);
            AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
            AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
            ZM3L124( -4) ;
         }
         pr_default.close(9);
         OnLoadActions3L124( ) ;
      }

      protected void OnLoadActions3L124( )
      {
      }

      protected void CheckExtendedTable3L124( )
      {
         nIsDirty_124 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003L4 */
         pr_default.execute(2, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T003L5 */
         pr_default.execute(3, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Proveedor'.", "ForeignKeyNotFound", 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T003L8 */
         pr_default.execute(6, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1756PrvConpDsc = T003L8_A1756PrvConpDsc[0];
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         pr_default.close(6);
         /* Using cursor T003L6 */
         pr_default.execute(4, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A297TPerCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Persona'.", "ForeignKeyNotFound", 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T003L7 */
         pr_default.execute(5, new Object[] {n157TipSCod, A157TipSCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A157TipSCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
               AnyError = 1;
               GX_FocusControl = edtTipSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T003L9 */
         pr_default.execute(7, new Object[] {n296PrvBanCod1, A296PrvBanCod1});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A296PrvBanCod1) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD1");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         /* Using cursor T003L10 */
         pr_default.execute(8, new Object[] {n299PrvBanCod2, A299PrvBanCod2});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A299PrvBanCod2) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD2");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A1785PrvUsuFec) || ( A1785PrvUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "PRVUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtPrvUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1786PrvUsuFecM) || ( A1786PrvUsuFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora Modificación fuera de rango", "OutOfRange", 1, "PRVUSUFECM");
            AnyError = 1;
            GX_FocusControl = edtPrvUsuFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1789PrvWebFec) || ( A1789PrvWebFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora Creación fuera de rango", "OutOfRange", 1, "PRVWEBFEC");
            AnyError = 1;
            GX_FocusControl = edtPrvWebFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3L124( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(6);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A139PaiCod ,
                               string A140EstCod ,
                               string A141ProvCod ,
                               string A142DisCod )
      {
         /* Using cursor T003L12 */
         pr_default.execute(10, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( int A298TprvCod )
      {
         /* Using cursor T003L13 */
         pr_default.execute(11, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Proveedor'.", "ForeignKeyNotFound", 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_9( int A300PrvConpCod )
      {
         /* Using cursor T003L14 */
         pr_default.execute(12, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1756PrvConpDsc = T003L14_A1756PrvConpDsc[0];
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1756PrvConpDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_7( int A297TPerCod )
      {
         /* Using cursor T003L15 */
         pr_default.execute(13, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A297TPerCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Persona'.", "ForeignKeyNotFound", 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_8( int A157TipSCod )
      {
         /* Using cursor T003L16 */
         pr_default.execute(14, new Object[] {n157TipSCod, A157TipSCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A157TipSCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
               AnyError = 1;
               GX_FocusControl = edtTipSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_10( int A296PrvBanCod1 )
      {
         /* Using cursor T003L17 */
         pr_default.execute(15, new Object[] {n296PrvBanCod1, A296PrvBanCod1});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A296PrvBanCod1) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD1");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_11( int A299PrvBanCod2 )
      {
         /* Using cursor T003L18 */
         pr_default.execute(16, new Object[] {n299PrvBanCod2, A299PrvBanCod2});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A299PrvBanCod2) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD2");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey3L124( )
      {
         /* Using cursor T003L19 */
         pr_default.execute(17, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound124 = 1;
         }
         else
         {
            RcdFound124 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003L3 */
         pr_default.execute(1, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3L124( 4) ;
            RcdFound124 = 1;
            A244PrvCod = T003L3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = T003L3_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003L3_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A1779PrvTel1 = T003L3_A1779PrvTel1[0];
            AssignAttri("", false, "A1779PrvTel1", A1779PrvTel1);
            A1780PrvTel2 = T003L3_A1780PrvTel2[0];
            AssignAttri("", false, "A1780PrvTel2", A1780PrvTel2);
            A1765PrvFax = T003L3_A1765PrvFax[0];
            AssignAttri("", false, "A1765PrvFax", A1765PrvFax);
            A1747PrvCel = T003L3_A1747PrvCel[0];
            AssignAttri("", false, "A1747PrvCel", A1747PrvCel);
            A1764PrvEM = T003L3_A1764PrvEM[0];
            AssignAttri("", false, "A1764PrvEM", A1764PrvEM);
            A1788PrvWeb = T003L3_A1788PrvWeb[0];
            AssignAttri("", false, "A1788PrvWeb", A1788PrvWeb);
            A40000PrvFoto_GXI = T003L3_A40000PrvFoto_GXI[0];
            n40000PrvFoto_GXI = T003L3_n40000PrvFoto_GXI[0];
            AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
            AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
            A1777PrvSts = T003L3_A1777PrvSts[0];
            AssignAttri("", false, "A1777PrvSts", StringUtil.Str( (decimal)(A1777PrvSts), 1, 0));
            A1768PrvRef1 = T003L3_A1768PrvRef1[0];
            AssignAttri("", false, "A1768PrvRef1", A1768PrvRef1);
            A1769PrvRef2 = T003L3_A1769PrvRef2[0];
            AssignAttri("", false, "A1769PrvRef2", A1769PrvRef2);
            A1770PrvRef3 = T003L3_A1770PrvRef3[0];
            AssignAttri("", false, "A1770PrvRef3", A1770PrvRef3);
            A1771PrvRef4 = T003L3_A1771PrvRef4[0];
            AssignAttri("", false, "A1771PrvRef4", A1771PrvRef4);
            A1772PrvRef5 = T003L3_A1772PrvRef5[0];
            AssignAttri("", false, "A1772PrvRef5", A1772PrvRef5);
            A1773PrvRef6 = T003L3_A1773PrvRef6[0];
            AssignAttri("", false, "A1773PrvRef6", A1773PrvRef6);
            A1774PrvRef7 = T003L3_A1774PrvRef7[0];
            AssignAttri("", false, "A1774PrvRef7", A1774PrvRef7);
            A1775PrvRef8 = T003L3_A1775PrvRef8[0];
            AssignAttri("", false, "A1775PrvRef8", A1775PrvRef8);
            A1748PrvCon1 = T003L3_A1748PrvCon1[0];
            AssignAttri("", false, "A1748PrvCon1", A1748PrvCon1);
            A1758PrvCTel1 = T003L3_A1758PrvCTel1[0];
            AssignAttri("", false, "A1758PrvCTel1", A1758PrvCTel1);
            A1749PrvCon2 = T003L3_A1749PrvCon2[0];
            AssignAttri("", false, "A1749PrvCon2", A1749PrvCon2);
            A1759PrvCTel2 = T003L3_A1759PrvCTel2[0];
            AssignAttri("", false, "A1759PrvCTel2", A1759PrvCTel2);
            A1750PrvCon3 = T003L3_A1750PrvCon3[0];
            AssignAttri("", false, "A1750PrvCon3", A1750PrvCon3);
            A1760PrvCTel3 = T003L3_A1760PrvCTel3[0];
            AssignAttri("", false, "A1760PrvCTel3", A1760PrvCTel3);
            A1751PrvCon4 = T003L3_A1751PrvCon4[0];
            AssignAttri("", false, "A1751PrvCon4", A1751PrvCon4);
            A1761PrvCTel4 = T003L3_A1761PrvCTel4[0];
            AssignAttri("", false, "A1761PrvCTel4", A1761PrvCTel4);
            A1752PrvCon5 = T003L3_A1752PrvCon5[0];
            AssignAttri("", false, "A1752PrvCon5", A1752PrvCon5);
            A1762PrvCTel5 = T003L3_A1762PrvCTel5[0];
            AssignAttri("", false, "A1762PrvCTel5", A1762PrvCTel5);
            A1767PrvNom = T003L3_A1767PrvNom[0];
            AssignAttri("", false, "A1767PrvNom", A1767PrvNom);
            A1744PrvAPeP = T003L3_A1744PrvAPeP[0];
            AssignAttri("", false, "A1744PrvAPeP", A1744PrvAPeP);
            A1743PrvAPeM = T003L3_A1743PrvAPeM[0];
            AssignAttri("", false, "A1743PrvAPeM", A1743PrvAPeM);
            A1787PrvVincula = T003L3_A1787PrvVincula[0];
            AssignAttri("", false, "A1787PrvVincula", StringUtil.Str( (decimal)(A1787PrvVincula), 1, 0));
            A1776PrvRetencion = T003L3_A1776PrvRetencion[0];
            AssignAttri("", false, "A1776PrvRetencion", StringUtil.Str( (decimal)(A1776PrvRetencion), 1, 0));
            A1781PrvTipCuenta1 = T003L3_A1781PrvTipCuenta1[0];
            AssignAttri("", false, "A1781PrvTipCuenta1", A1781PrvTipCuenta1);
            A1745PrvBanCuenta1 = T003L3_A1745PrvBanCuenta1[0];
            AssignAttri("", false, "A1745PrvBanCuenta1", A1745PrvBanCuenta1);
            A1782PrvTipCuenta2 = T003L3_A1782PrvTipCuenta2[0];
            AssignAttri("", false, "A1782PrvTipCuenta2", A1782PrvTipCuenta2);
            A1778PrvTCon = T003L3_A1778PrvTCon[0];
            A1746PrvBanCuenta2 = T003L3_A1746PrvBanCuenta2[0];
            AssignAttri("", false, "A1746PrvBanCuenta2", A1746PrvBanCuenta2);
            A1783PrvUsuCod = T003L3_A1783PrvUsuCod[0];
            AssignAttri("", false, "A1783PrvUsuCod", A1783PrvUsuCod);
            A1785PrvUsuFec = T003L3_A1785PrvUsuFec[0];
            AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1784PrvUsuCodM = T003L3_A1784PrvUsuCodM[0];
            AssignAttri("", false, "A1784PrvUsuCodM", A1784PrvUsuCodM);
            A1786PrvUsuFecM = T003L3_A1786PrvUsuFecM[0];
            AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A1791PrvWebUsu = T003L3_A1791PrvWebUsu[0];
            AssignAttri("", false, "A1791PrvWebUsu", A1791PrvWebUsu);
            A1790PrvWebPas = T003L3_A1790PrvWebPas[0];
            AssignAttri("", false, "A1790PrvWebPas", A1790PrvWebPas);
            A1789PrvWebFec = T003L3_A1789PrvWebFec[0];
            AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 8, 5, 0, 3, "/", ":", " "));
            A139PaiCod = T003L3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T003L3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T003L3_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T003L3_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A298TprvCod = T003L3_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            A297TPerCod = T003L3_A297TPerCod[0];
            n297TPerCod = T003L3_n297TPerCod[0];
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            A157TipSCod = T003L3_A157TipSCod[0];
            n157TipSCod = T003L3_n157TipSCod[0];
            AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
            A300PrvConpCod = T003L3_A300PrvConpCod[0];
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            A296PrvBanCod1 = T003L3_A296PrvBanCod1[0];
            n296PrvBanCod1 = T003L3_n296PrvBanCod1[0];
            AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
            A299PrvBanCod2 = T003L3_A299PrvBanCod2[0];
            n299PrvBanCod2 = T003L3_n299PrvBanCod2[0];
            AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
            A1766PrvFoto = T003L3_A1766PrvFoto[0];
            n1766PrvFoto = T003L3_n1766PrvFoto[0];
            AssignAttri("", false, "A1766PrvFoto", A1766PrvFoto);
            AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
            AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
            Z244PrvCod = A244PrvCod;
            sMode124 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3L124( ) ;
            if ( AnyError == 1 )
            {
               RcdFound124 = 0;
               InitializeNonKey3L124( ) ;
            }
            Gx_mode = sMode124;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound124 = 0;
            InitializeNonKey3L124( ) ;
            sMode124 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode124;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3L124( ) ;
         if ( RcdFound124 == 0 )
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
         RcdFound124 = 0;
         /* Using cursor T003L20 */
         pr_default.execute(18, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( StringUtil.StrCmp(T003L20_A244PrvCod[0], A244PrvCod) < 0 ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( StringUtil.StrCmp(T003L20_A244PrvCod[0], A244PrvCod) > 0 ) ) )
            {
               A244PrvCod = T003L20_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               RcdFound124 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void move_previous( )
      {
         RcdFound124 = 0;
         /* Using cursor T003L21 */
         pr_default.execute(19, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T003L21_A244PrvCod[0], A244PrvCod) > 0 ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T003L21_A244PrvCod[0], A244PrvCod) < 0 ) ) )
            {
               A244PrvCod = T003L21_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               RcdFound124 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3L124( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3L124( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound124 == 1 )
            {
               if ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 )
               {
                  A244PrvCod = Z244PrvCod;
                  AssignAttri("", false, "A244PrvCod", A244PrvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3L124( ) ;
                  GX_FocusControl = edtPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3L124( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPrvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPrvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3L124( ) ;
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
         if ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 )
         {
            A244PrvCod = Z244PrvCod;
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPrvCod_Internalname;
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
         GetKey3L124( ) ;
         if ( RcdFound124 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PRVCOD");
               AnyError = 1;
               GX_FocusControl = edtPrvCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 )
            {
               A244PrvCod = Z244PrvCod;
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PRVCOD");
               AnyError = 1;
               GX_FocusControl = edtPrvCod_Internalname;
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
            if ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPrvCod_Internalname;
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
         context.RollbackDataStores("cpproveedores",pr_default);
         GX_FocusControl = edtPrvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3L0( ) ;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPrvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3L124( ) ;
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3L124( ) ;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvDsc_Internalname;
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
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvDsc_Internalname;
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
         ScanStart3L124( ) ;
         if ( RcdFound124 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound124 != 0 )
            {
               ScanNext3L124( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3L124( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3L124( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003L2 */
            pr_default.execute(0, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPPROVEEDORES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z247PrvDsc, T003L2_A247PrvDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1763PrvDir, T003L2_A1763PrvDir[0]) != 0 ) || ( StringUtil.StrCmp(Z1779PrvTel1, T003L2_A1779PrvTel1[0]) != 0 ) || ( StringUtil.StrCmp(Z1780PrvTel2, T003L2_A1780PrvTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z1765PrvFax, T003L2_A1765PrvFax[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1747PrvCel, T003L2_A1747PrvCel[0]) != 0 ) || ( StringUtil.StrCmp(Z1764PrvEM, T003L2_A1764PrvEM[0]) != 0 ) || ( StringUtil.StrCmp(Z1788PrvWeb, T003L2_A1788PrvWeb[0]) != 0 ) || ( Z1777PrvSts != T003L2_A1777PrvSts[0] ) || ( StringUtil.StrCmp(Z1768PrvRef1, T003L2_A1768PrvRef1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1769PrvRef2, T003L2_A1769PrvRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1770PrvRef3, T003L2_A1770PrvRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1771PrvRef4, T003L2_A1771PrvRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1772PrvRef5, T003L2_A1772PrvRef5[0]) != 0 ) || ( StringUtil.StrCmp(Z1773PrvRef6, T003L2_A1773PrvRef6[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1774PrvRef7, T003L2_A1774PrvRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z1775PrvRef8, T003L2_A1775PrvRef8[0]) != 0 ) || ( StringUtil.StrCmp(Z1748PrvCon1, T003L2_A1748PrvCon1[0]) != 0 ) || ( StringUtil.StrCmp(Z1758PrvCTel1, T003L2_A1758PrvCTel1[0]) != 0 ) || ( StringUtil.StrCmp(Z1749PrvCon2, T003L2_A1749PrvCon2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1759PrvCTel2, T003L2_A1759PrvCTel2[0]) != 0 ) || ( StringUtil.StrCmp(Z1750PrvCon3, T003L2_A1750PrvCon3[0]) != 0 ) || ( StringUtil.StrCmp(Z1760PrvCTel3, T003L2_A1760PrvCTel3[0]) != 0 ) || ( StringUtil.StrCmp(Z1751PrvCon4, T003L2_A1751PrvCon4[0]) != 0 ) || ( StringUtil.StrCmp(Z1761PrvCTel4, T003L2_A1761PrvCTel4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1752PrvCon5, T003L2_A1752PrvCon5[0]) != 0 ) || ( StringUtil.StrCmp(Z1762PrvCTel5, T003L2_A1762PrvCTel5[0]) != 0 ) || ( StringUtil.StrCmp(Z1767PrvNom, T003L2_A1767PrvNom[0]) != 0 ) || ( StringUtil.StrCmp(Z1744PrvAPeP, T003L2_A1744PrvAPeP[0]) != 0 ) || ( StringUtil.StrCmp(Z1743PrvAPeM, T003L2_A1743PrvAPeM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1787PrvVincula != T003L2_A1787PrvVincula[0] ) || ( Z1776PrvRetencion != T003L2_A1776PrvRetencion[0] ) || ( StringUtil.StrCmp(Z1781PrvTipCuenta1, T003L2_A1781PrvTipCuenta1[0]) != 0 ) || ( StringUtil.StrCmp(Z1745PrvBanCuenta1, T003L2_A1745PrvBanCuenta1[0]) != 0 ) || ( StringUtil.StrCmp(Z1782PrvTipCuenta2, T003L2_A1782PrvTipCuenta2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1778PrvTCon != T003L2_A1778PrvTCon[0] ) || ( StringUtil.StrCmp(Z1746PrvBanCuenta2, T003L2_A1746PrvBanCuenta2[0]) != 0 ) || ( StringUtil.StrCmp(Z1783PrvUsuCod, T003L2_A1783PrvUsuCod[0]) != 0 ) || ( Z1785PrvUsuFec != T003L2_A1785PrvUsuFec[0] ) || ( StringUtil.StrCmp(Z1784PrvUsuCodM, T003L2_A1784PrvUsuCodM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1786PrvUsuFecM != T003L2_A1786PrvUsuFecM[0] ) || ( StringUtil.StrCmp(Z1791PrvWebUsu, T003L2_A1791PrvWebUsu[0]) != 0 ) || ( StringUtil.StrCmp(Z1790PrvWebPas, T003L2_A1790PrvWebPas[0]) != 0 ) || ( Z1789PrvWebFec != T003L2_A1789PrvWebFec[0] ) || ( StringUtil.StrCmp(Z139PaiCod, T003L2_A139PaiCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z140EstCod, T003L2_A140EstCod[0]) != 0 ) || ( StringUtil.StrCmp(Z141ProvCod, T003L2_A141ProvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z142DisCod, T003L2_A142DisCod[0]) != 0 ) || ( Z298TprvCod != T003L2_A298TprvCod[0] ) || ( Z297TPerCod != T003L2_A297TPerCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z157TipSCod != T003L2_A157TipSCod[0] ) || ( Z300PrvConpCod != T003L2_A300PrvConpCod[0] ) || ( Z296PrvBanCod1 != T003L2_A296PrvBanCod1[0] ) || ( Z299PrvBanCod2 != T003L2_A299PrvBanCod2[0] ) )
            {
               if ( StringUtil.StrCmp(Z247PrvDsc, T003L2_A247PrvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z247PrvDsc);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A247PrvDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1763PrvDir, T003L2_A1763PrvDir[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvDir");
                  GXUtil.WriteLogRaw("Old: ",Z1763PrvDir);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1763PrvDir[0]);
               }
               if ( StringUtil.StrCmp(Z1779PrvTel1, T003L2_A1779PrvTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvTel1");
                  GXUtil.WriteLogRaw("Old: ",Z1779PrvTel1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1779PrvTel1[0]);
               }
               if ( StringUtil.StrCmp(Z1780PrvTel2, T003L2_A1780PrvTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvTel2");
                  GXUtil.WriteLogRaw("Old: ",Z1780PrvTel2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1780PrvTel2[0]);
               }
               if ( StringUtil.StrCmp(Z1765PrvFax, T003L2_A1765PrvFax[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvFax");
                  GXUtil.WriteLogRaw("Old: ",Z1765PrvFax);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1765PrvFax[0]);
               }
               if ( StringUtil.StrCmp(Z1747PrvCel, T003L2_A1747PrvCel[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCel");
                  GXUtil.WriteLogRaw("Old: ",Z1747PrvCel);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1747PrvCel[0]);
               }
               if ( StringUtil.StrCmp(Z1764PrvEM, T003L2_A1764PrvEM[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvEM");
                  GXUtil.WriteLogRaw("Old: ",Z1764PrvEM);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1764PrvEM[0]);
               }
               if ( StringUtil.StrCmp(Z1788PrvWeb, T003L2_A1788PrvWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvWeb");
                  GXUtil.WriteLogRaw("Old: ",Z1788PrvWeb);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1788PrvWeb[0]);
               }
               if ( Z1777PrvSts != T003L2_A1777PrvSts[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvSts");
                  GXUtil.WriteLogRaw("Old: ",Z1777PrvSts);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1777PrvSts[0]);
               }
               if ( StringUtil.StrCmp(Z1768PrvRef1, T003L2_A1768PrvRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1768PrvRef1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1768PrvRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1769PrvRef2, T003L2_A1769PrvRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1769PrvRef2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1769PrvRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1770PrvRef3, T003L2_A1770PrvRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1770PrvRef3);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1770PrvRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1771PrvRef4, T003L2_A1771PrvRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1771PrvRef4);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1771PrvRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1772PrvRef5, T003L2_A1772PrvRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1772PrvRef5);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1772PrvRef5[0]);
               }
               if ( StringUtil.StrCmp(Z1773PrvRef6, T003L2_A1773PrvRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef6");
                  GXUtil.WriteLogRaw("Old: ",Z1773PrvRef6);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1773PrvRef6[0]);
               }
               if ( StringUtil.StrCmp(Z1774PrvRef7, T003L2_A1774PrvRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef7");
                  GXUtil.WriteLogRaw("Old: ",Z1774PrvRef7);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1774PrvRef7[0]);
               }
               if ( StringUtil.StrCmp(Z1775PrvRef8, T003L2_A1775PrvRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRef8");
                  GXUtil.WriteLogRaw("Old: ",Z1775PrvRef8);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1775PrvRef8[0]);
               }
               if ( StringUtil.StrCmp(Z1748PrvCon1, T003L2_A1748PrvCon1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCon1");
                  GXUtil.WriteLogRaw("Old: ",Z1748PrvCon1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1748PrvCon1[0]);
               }
               if ( StringUtil.StrCmp(Z1758PrvCTel1, T003L2_A1758PrvCTel1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCTel1");
                  GXUtil.WriteLogRaw("Old: ",Z1758PrvCTel1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1758PrvCTel1[0]);
               }
               if ( StringUtil.StrCmp(Z1749PrvCon2, T003L2_A1749PrvCon2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCon2");
                  GXUtil.WriteLogRaw("Old: ",Z1749PrvCon2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1749PrvCon2[0]);
               }
               if ( StringUtil.StrCmp(Z1759PrvCTel2, T003L2_A1759PrvCTel2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCTel2");
                  GXUtil.WriteLogRaw("Old: ",Z1759PrvCTel2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1759PrvCTel2[0]);
               }
               if ( StringUtil.StrCmp(Z1750PrvCon3, T003L2_A1750PrvCon3[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCon3");
                  GXUtil.WriteLogRaw("Old: ",Z1750PrvCon3);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1750PrvCon3[0]);
               }
               if ( StringUtil.StrCmp(Z1760PrvCTel3, T003L2_A1760PrvCTel3[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCTel3");
                  GXUtil.WriteLogRaw("Old: ",Z1760PrvCTel3);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1760PrvCTel3[0]);
               }
               if ( StringUtil.StrCmp(Z1751PrvCon4, T003L2_A1751PrvCon4[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCon4");
                  GXUtil.WriteLogRaw("Old: ",Z1751PrvCon4);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1751PrvCon4[0]);
               }
               if ( StringUtil.StrCmp(Z1761PrvCTel4, T003L2_A1761PrvCTel4[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCTel4");
                  GXUtil.WriteLogRaw("Old: ",Z1761PrvCTel4);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1761PrvCTel4[0]);
               }
               if ( StringUtil.StrCmp(Z1752PrvCon5, T003L2_A1752PrvCon5[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCon5");
                  GXUtil.WriteLogRaw("Old: ",Z1752PrvCon5);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1752PrvCon5[0]);
               }
               if ( StringUtil.StrCmp(Z1762PrvCTel5, T003L2_A1762PrvCTel5[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvCTel5");
                  GXUtil.WriteLogRaw("Old: ",Z1762PrvCTel5);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1762PrvCTel5[0]);
               }
               if ( StringUtil.StrCmp(Z1767PrvNom, T003L2_A1767PrvNom[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvNom");
                  GXUtil.WriteLogRaw("Old: ",Z1767PrvNom);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1767PrvNom[0]);
               }
               if ( StringUtil.StrCmp(Z1744PrvAPeP, T003L2_A1744PrvAPeP[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvAPeP");
                  GXUtil.WriteLogRaw("Old: ",Z1744PrvAPeP);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1744PrvAPeP[0]);
               }
               if ( StringUtil.StrCmp(Z1743PrvAPeM, T003L2_A1743PrvAPeM[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvAPeM");
                  GXUtil.WriteLogRaw("Old: ",Z1743PrvAPeM);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1743PrvAPeM[0]);
               }
               if ( Z1787PrvVincula != T003L2_A1787PrvVincula[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvVincula");
                  GXUtil.WriteLogRaw("Old: ",Z1787PrvVincula);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1787PrvVincula[0]);
               }
               if ( Z1776PrvRetencion != T003L2_A1776PrvRetencion[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvRetencion");
                  GXUtil.WriteLogRaw("Old: ",Z1776PrvRetencion);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1776PrvRetencion[0]);
               }
               if ( StringUtil.StrCmp(Z1781PrvTipCuenta1, T003L2_A1781PrvTipCuenta1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvTipCuenta1");
                  GXUtil.WriteLogRaw("Old: ",Z1781PrvTipCuenta1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1781PrvTipCuenta1[0]);
               }
               if ( StringUtil.StrCmp(Z1745PrvBanCuenta1, T003L2_A1745PrvBanCuenta1[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvBanCuenta1");
                  GXUtil.WriteLogRaw("Old: ",Z1745PrvBanCuenta1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1745PrvBanCuenta1[0]);
               }
               if ( StringUtil.StrCmp(Z1782PrvTipCuenta2, T003L2_A1782PrvTipCuenta2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvTipCuenta2");
                  GXUtil.WriteLogRaw("Old: ",Z1782PrvTipCuenta2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1782PrvTipCuenta2[0]);
               }
               if ( Z1778PrvTCon != T003L2_A1778PrvTCon[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvTCon");
                  GXUtil.WriteLogRaw("Old: ",Z1778PrvTCon);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1778PrvTCon[0]);
               }
               if ( StringUtil.StrCmp(Z1746PrvBanCuenta2, T003L2_A1746PrvBanCuenta2[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvBanCuenta2");
                  GXUtil.WriteLogRaw("Old: ",Z1746PrvBanCuenta2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1746PrvBanCuenta2[0]);
               }
               if ( StringUtil.StrCmp(Z1783PrvUsuCod, T003L2_A1783PrvUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1783PrvUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1783PrvUsuCod[0]);
               }
               if ( Z1785PrvUsuFec != T003L2_A1785PrvUsuFec[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1785PrvUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1785PrvUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z1784PrvUsuCodM, T003L2_A1784PrvUsuCodM[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvUsuCodM");
                  GXUtil.WriteLogRaw("Old: ",Z1784PrvUsuCodM);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1784PrvUsuCodM[0]);
               }
               if ( Z1786PrvUsuFecM != T003L2_A1786PrvUsuFecM[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvUsuFecM");
                  GXUtil.WriteLogRaw("Old: ",Z1786PrvUsuFecM);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1786PrvUsuFecM[0]);
               }
               if ( StringUtil.StrCmp(Z1791PrvWebUsu, T003L2_A1791PrvWebUsu[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvWebUsu");
                  GXUtil.WriteLogRaw("Old: ",Z1791PrvWebUsu);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1791PrvWebUsu[0]);
               }
               if ( StringUtil.StrCmp(Z1790PrvWebPas, T003L2_A1790PrvWebPas[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvWebPas");
                  GXUtil.WriteLogRaw("Old: ",Z1790PrvWebPas);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1790PrvWebPas[0]);
               }
               if ( Z1789PrvWebFec != T003L2_A1789PrvWebFec[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvWebFec");
                  GXUtil.WriteLogRaw("Old: ",Z1789PrvWebFec);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A1789PrvWebFec[0]);
               }
               if ( StringUtil.StrCmp(Z139PaiCod, T003L2_A139PaiCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PaiCod");
                  GXUtil.WriteLogRaw("Old: ",Z139PaiCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A139PaiCod[0]);
               }
               if ( StringUtil.StrCmp(Z140EstCod, T003L2_A140EstCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"EstCod");
                  GXUtil.WriteLogRaw("Old: ",Z140EstCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A140EstCod[0]);
               }
               if ( StringUtil.StrCmp(Z141ProvCod, T003L2_A141ProvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"ProvCod");
                  GXUtil.WriteLogRaw("Old: ",Z141ProvCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A141ProvCod[0]);
               }
               if ( StringUtil.StrCmp(Z142DisCod, T003L2_A142DisCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"DisCod");
                  GXUtil.WriteLogRaw("Old: ",Z142DisCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A142DisCod[0]);
               }
               if ( Z298TprvCod != T003L2_A298TprvCod[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"TprvCod");
                  GXUtil.WriteLogRaw("Old: ",Z298TprvCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A298TprvCod[0]);
               }
               if ( Z297TPerCod != T003L2_A297TPerCod[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"TPerCod");
                  GXUtil.WriteLogRaw("Old: ",Z297TPerCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A297TPerCod[0]);
               }
               if ( Z157TipSCod != T003L2_A157TipSCod[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"TipSCod");
                  GXUtil.WriteLogRaw("Old: ",Z157TipSCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A157TipSCod[0]);
               }
               if ( Z300PrvConpCod != T003L2_A300PrvConpCod[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z300PrvConpCod);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A300PrvConpCod[0]);
               }
               if ( Z296PrvBanCod1 != T003L2_A296PrvBanCod1[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvBanCod1");
                  GXUtil.WriteLogRaw("Old: ",Z296PrvBanCod1);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A296PrvBanCod1[0]);
               }
               if ( Z299PrvBanCod2 != T003L2_A299PrvBanCod2[0] )
               {
                  GXUtil.WriteLog("cpproveedores:[seudo value changed for attri]"+"PrvBanCod2");
                  GXUtil.WriteLogRaw("Old: ",Z299PrvBanCod2);
                  GXUtil.WriteLogRaw("Current: ",T003L2_A299PrvBanCod2[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPPROVEEDORES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3L124( )
      {
         BeforeValidate3L124( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3L124( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3L124( 0) ;
            CheckOptimisticConcurrency3L124( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3L124( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3L124( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003L22 */
                     pr_default.execute(20, new Object[] {A244PrvCod, A247PrvDsc, A1763PrvDir, A1779PrvTel1, A1780PrvTel2, A1765PrvFax, A1747PrvCel, A1764PrvEM, A1788PrvWeb, n1766PrvFoto, A1766PrvFoto, n40000PrvFoto_GXI, A40000PrvFoto_GXI, A1777PrvSts, A1768PrvRef1, A1769PrvRef2, A1770PrvRef3, A1771PrvRef4, A1772PrvRef5, A1773PrvRef6, A1774PrvRef7, A1775PrvRef8, A1748PrvCon1, A1758PrvCTel1, A1749PrvCon2, A1759PrvCTel2, A1750PrvCon3, A1760PrvCTel3, A1751PrvCon4, A1761PrvCTel4, A1752PrvCon5, A1762PrvCTel5, A1767PrvNom, A1744PrvAPeP, A1743PrvAPeM, A1787PrvVincula, A1776PrvRetencion, A1781PrvTipCuenta1, A1745PrvBanCuenta1, A1782PrvTipCuenta2, A1778PrvTCon, A1746PrvBanCuenta2, A1783PrvUsuCod, A1785PrvUsuFec, A1784PrvUsuCodM, A1786PrvUsuFecM, A1791PrvWebUsu, A1790PrvWebPas, A1789PrvWebFec, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A298TprvCod, n297TPerCod, A297TPerCod, n157TipSCod, A157TipSCod, A300PrvConpCod, n296PrvBanCod1, A296PrvBanCod1, n299PrvBanCod2, A299PrvBanCod2});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("CPPROVEEDORES");
                     if ( (pr_default.getStatus(20) == 1) )
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
                           ResetCaption3L0( ) ;
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
               Load3L124( ) ;
            }
            EndLevel3L124( ) ;
         }
         CloseExtendedTableCursors3L124( ) ;
      }

      protected void Update3L124( )
      {
         BeforeValidate3L124( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3L124( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3L124( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3L124( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3L124( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003L23 */
                     pr_default.execute(21, new Object[] {A247PrvDsc, A1763PrvDir, A1779PrvTel1, A1780PrvTel2, A1765PrvFax, A1747PrvCel, A1764PrvEM, A1788PrvWeb, A1777PrvSts, A1768PrvRef1, A1769PrvRef2, A1770PrvRef3, A1771PrvRef4, A1772PrvRef5, A1773PrvRef6, A1774PrvRef7, A1775PrvRef8, A1748PrvCon1, A1758PrvCTel1, A1749PrvCon2, A1759PrvCTel2, A1750PrvCon3, A1760PrvCTel3, A1751PrvCon4, A1761PrvCTel4, A1752PrvCon5, A1762PrvCTel5, A1767PrvNom, A1744PrvAPeP, A1743PrvAPeM, A1787PrvVincula, A1776PrvRetencion, A1781PrvTipCuenta1, A1745PrvBanCuenta1, A1782PrvTipCuenta2, A1778PrvTCon, A1746PrvBanCuenta2, A1783PrvUsuCod, A1785PrvUsuFec, A1784PrvUsuCodM, A1786PrvUsuFecM, A1791PrvWebUsu, A1790PrvWebPas, A1789PrvWebFec, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod, A298TprvCod, n297TPerCod, A297TPerCod, n157TipSCod, A157TipSCod, A300PrvConpCod, n296PrvBanCod1, A296PrvBanCod1, n299PrvBanCod2, A299PrvBanCod2, A244PrvCod});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("CPPROVEEDORES");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPPROVEEDORES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3L124( ) ;
                     if ( AnyError == 0 )
                     {
                        new cpproveedoresupdateredundancy(context ).execute( ref  A244PrvCod) ;
                        AssignAttri("", false, "A244PrvCod", A244PrvCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3L0( ) ;
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
            EndLevel3L124( ) ;
         }
         CloseExtendedTableCursors3L124( ) ;
      }

      protected void DeferredUpdate3L124( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T003L24 */
            pr_default.execute(22, new Object[] {n1766PrvFoto, A1766PrvFoto, n40000PrvFoto_GXI, A40000PrvFoto_GXI, A244PrvCod});
            pr_default.close(22);
            dsDefault.SmartCacheProvider.SetUpdated("CPPROVEEDORES");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3L124( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3L124( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3L124( ) ;
            AfterConfirm3L124( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3L124( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003L25 */
                  pr_default.execute(23, new Object[] {A244PrvCod});
                  pr_default.close(23);
                  dsDefault.SmartCacheProvider.SetUpdated("CPPROVEEDORES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound124 == 0 )
                        {
                           InitAll3L124( ) ;
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
                        ResetCaption3L0( ) ;
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
         sMode124 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3L124( ) ;
         Gx_mode = sMode124;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3L124( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003L26 */
            pr_default.execute(24, new Object[] {A300PrvConpCod});
            A1756PrvConpDsc = T003L26_A1756PrvConpDsc[0];
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003L27 */
            pr_default.execute(25, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T003L28 */
            pr_default.execute(26, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T003L29 */
            pr_default.execute(27, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T003L30 */
            pr_default.execute(28, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T003L31 */
            pr_default.execute(29, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T003L32 */
            pr_default.execute(30, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta Pagar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T003L33 */
            pr_default.execute(31, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T003L34 */
            pr_default.execute(32, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T003L35 */
            pr_default.execute(33, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retención"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T003L36 */
            pr_default.execute(34, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T003L37 */
            pr_default.execute(35, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Lista de Precios Proveedor"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T003L38 */
            pr_default.execute(36, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T003L39 */
            pr_default.execute(37, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proveedores Contactos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T003L40 */
            pr_default.execute(38, new Object[] {A244PrvCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CPCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
         }
      }

      protected void EndLevel3L124( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3L124( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(24);
            context.CommitDataStores("cpproveedores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(24);
            context.RollbackDataStores("cpproveedores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3L124( )
      {
         /* Using cursor T003L41 */
         pr_default.execute(39);
         RcdFound124 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound124 = 1;
            A244PrvCod = T003L41_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3L124( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound124 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound124 = 1;
            A244PrvCod = T003L41_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
         }
      }

      protected void ScanEnd3L124( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm3L124( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3L124( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3L124( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3L124( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3L124( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3L124( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3L124( )
      {
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtPrvDir_Enabled = 0;
         AssignProp("", false, edtPrvDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDir_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtPrvTel1_Enabled = 0;
         AssignProp("", false, edtPrvTel1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvTel1_Enabled), 5, 0), true);
         edtPrvTel2_Enabled = 0;
         AssignProp("", false, edtPrvTel2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvTel2_Enabled), 5, 0), true);
         edtPrvFax_Enabled = 0;
         AssignProp("", false, edtPrvFax_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvFax_Enabled), 5, 0), true);
         edtPrvCel_Enabled = 0;
         AssignProp("", false, edtPrvCel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCel_Enabled), 5, 0), true);
         edtPrvEM_Enabled = 0;
         AssignProp("", false, edtPrvEM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvEM_Enabled), 5, 0), true);
         edtPrvWeb_Enabled = 0;
         AssignProp("", false, edtPrvWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvWeb_Enabled), 5, 0), true);
         edtTprvCod_Enabled = 0;
         AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
         imgPrvFoto_Enabled = 0;
         AssignProp("", false, imgPrvFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPrvFoto_Enabled), 5, 0), true);
         edtPrvSts_Enabled = 0;
         AssignProp("", false, edtPrvSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvSts_Enabled), 5, 0), true);
         edtPrvConpCod_Enabled = 0;
         AssignProp("", false, edtPrvConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvConpCod_Enabled), 5, 0), true);
         edtPrvRef1_Enabled = 0;
         AssignProp("", false, edtPrvRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef1_Enabled), 5, 0), true);
         edtPrvRef2_Enabled = 0;
         AssignProp("", false, edtPrvRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef2_Enabled), 5, 0), true);
         edtPrvRef3_Enabled = 0;
         AssignProp("", false, edtPrvRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef3_Enabled), 5, 0), true);
         edtPrvRef4_Enabled = 0;
         AssignProp("", false, edtPrvRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef4_Enabled), 5, 0), true);
         edtPrvRef5_Enabled = 0;
         AssignProp("", false, edtPrvRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef5_Enabled), 5, 0), true);
         edtPrvRef6_Enabled = 0;
         AssignProp("", false, edtPrvRef6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef6_Enabled), 5, 0), true);
         edtPrvRef7_Enabled = 0;
         AssignProp("", false, edtPrvRef7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef7_Enabled), 5, 0), true);
         edtPrvRef8_Enabled = 0;
         AssignProp("", false, edtPrvRef8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRef8_Enabled), 5, 0), true);
         edtPrvCon1_Enabled = 0;
         AssignProp("", false, edtPrvCon1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCon1_Enabled), 5, 0), true);
         edtPrvCTel1_Enabled = 0;
         AssignProp("", false, edtPrvCTel1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCTel1_Enabled), 5, 0), true);
         edtPrvCon2_Enabled = 0;
         AssignProp("", false, edtPrvCon2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCon2_Enabled), 5, 0), true);
         edtPrvCTel2_Enabled = 0;
         AssignProp("", false, edtPrvCTel2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCTel2_Enabled), 5, 0), true);
         edtPrvCon3_Enabled = 0;
         AssignProp("", false, edtPrvCon3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCon3_Enabled), 5, 0), true);
         edtPrvCTel3_Enabled = 0;
         AssignProp("", false, edtPrvCTel3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCTel3_Enabled), 5, 0), true);
         edtPrvCon4_Enabled = 0;
         AssignProp("", false, edtPrvCon4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCon4_Enabled), 5, 0), true);
         edtPrvCTel4_Enabled = 0;
         AssignProp("", false, edtPrvCTel4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCTel4_Enabled), 5, 0), true);
         edtPrvCon5_Enabled = 0;
         AssignProp("", false, edtPrvCon5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCon5_Enabled), 5, 0), true);
         edtPrvCTel5_Enabled = 0;
         AssignProp("", false, edtPrvCTel5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCTel5_Enabled), 5, 0), true);
         edtPrvNom_Enabled = 0;
         AssignProp("", false, edtPrvNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvNom_Enabled), 5, 0), true);
         edtPrvAPeP_Enabled = 0;
         AssignProp("", false, edtPrvAPeP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvAPeP_Enabled), 5, 0), true);
         edtPrvAPeM_Enabled = 0;
         AssignProp("", false, edtPrvAPeM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvAPeM_Enabled), 5, 0), true);
         edtDisCod_Enabled = 0;
         AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtTPerCod_Enabled = 0;
         AssignProp("", false, edtTPerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPerCod_Enabled), 5, 0), true);
         edtTipSCod_Enabled = 0;
         AssignProp("", false, edtTipSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSCod_Enabled), 5, 0), true);
         edtPrvVincula_Enabled = 0;
         AssignProp("", false, edtPrvVincula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvVincula_Enabled), 5, 0), true);
         edtPrvRetencion_Enabled = 0;
         AssignProp("", false, edtPrvRetencion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvRetencion_Enabled), 5, 0), true);
         edtPrvTipCuenta1_Enabled = 0;
         AssignProp("", false, edtPrvTipCuenta1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvTipCuenta1_Enabled), 5, 0), true);
         edtPrvBanCod1_Enabled = 0;
         AssignProp("", false, edtPrvBanCod1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvBanCod1_Enabled), 5, 0), true);
         edtPrvBanCuenta1_Enabled = 0;
         AssignProp("", false, edtPrvBanCuenta1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvBanCuenta1_Enabled), 5, 0), true);
         edtPrvTipCuenta2_Enabled = 0;
         AssignProp("", false, edtPrvTipCuenta2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvTipCuenta2_Enabled), 5, 0), true);
         edtPrvBanCod2_Enabled = 0;
         AssignProp("", false, edtPrvBanCod2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvBanCod2_Enabled), 5, 0), true);
         edtPrvBanCuenta2_Enabled = 0;
         AssignProp("", false, edtPrvBanCuenta2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvBanCuenta2_Enabled), 5, 0), true);
         edtPrvUsuCod_Enabled = 0;
         AssignProp("", false, edtPrvUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvUsuCod_Enabled), 5, 0), true);
         edtPrvUsuFec_Enabled = 0;
         AssignProp("", false, edtPrvUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvUsuFec_Enabled), 5, 0), true);
         edtPrvUsuCodM_Enabled = 0;
         AssignProp("", false, edtPrvUsuCodM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvUsuCodM_Enabled), 5, 0), true);
         edtPrvUsuFecM_Enabled = 0;
         AssignProp("", false, edtPrvUsuFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvUsuFecM_Enabled), 5, 0), true);
         edtPrvWebUsu_Enabled = 0;
         AssignProp("", false, edtPrvWebUsu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvWebUsu_Enabled), 5, 0), true);
         edtPrvWebPas_Enabled = 0;
         AssignProp("", false, edtPrvWebPas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvWebPas_Enabled), 5, 0), true);
         edtPrvWebFec_Enabled = 0;
         AssignProp("", false, edtPrvWebFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvWebFec_Enabled), 5, 0), true);
         edtPrvConpDsc_Enabled = 0;
         AssignProp("", false, edtPrvConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvConpDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3L124( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025282", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpproveedores.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CPPROVEEDORES");
         forbiddenHiddens.Add("PrvTCon", context.localUtil.Format( (decimal)(A1778PrvTCon), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cpproveedores:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1763PrvDir", StringUtil.RTrim( Z1763PrvDir));
         GxWebStd.gx_hidden_field( context, "Z1779PrvTel1", StringUtil.RTrim( Z1779PrvTel1));
         GxWebStd.gx_hidden_field( context, "Z1780PrvTel2", StringUtil.RTrim( Z1780PrvTel2));
         GxWebStd.gx_hidden_field( context, "Z1765PrvFax", StringUtil.RTrim( Z1765PrvFax));
         GxWebStd.gx_hidden_field( context, "Z1747PrvCel", StringUtil.RTrim( Z1747PrvCel));
         GxWebStd.gx_hidden_field( context, "Z1764PrvEM", StringUtil.RTrim( Z1764PrvEM));
         GxWebStd.gx_hidden_field( context, "Z1788PrvWeb", StringUtil.RTrim( Z1788PrvWeb));
         GxWebStd.gx_hidden_field( context, "Z1777PrvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1777PrvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1768PrvRef1", StringUtil.RTrim( Z1768PrvRef1));
         GxWebStd.gx_hidden_field( context, "Z1769PrvRef2", StringUtil.RTrim( Z1769PrvRef2));
         GxWebStd.gx_hidden_field( context, "Z1770PrvRef3", StringUtil.RTrim( Z1770PrvRef3));
         GxWebStd.gx_hidden_field( context, "Z1771PrvRef4", StringUtil.RTrim( Z1771PrvRef4));
         GxWebStd.gx_hidden_field( context, "Z1772PrvRef5", StringUtil.RTrim( Z1772PrvRef5));
         GxWebStd.gx_hidden_field( context, "Z1773PrvRef6", StringUtil.RTrim( Z1773PrvRef6));
         GxWebStd.gx_hidden_field( context, "Z1774PrvRef7", StringUtil.RTrim( Z1774PrvRef7));
         GxWebStd.gx_hidden_field( context, "Z1775PrvRef8", StringUtil.RTrim( Z1775PrvRef8));
         GxWebStd.gx_hidden_field( context, "Z1748PrvCon1", StringUtil.RTrim( Z1748PrvCon1));
         GxWebStd.gx_hidden_field( context, "Z1758PrvCTel1", StringUtil.RTrim( Z1758PrvCTel1));
         GxWebStd.gx_hidden_field( context, "Z1749PrvCon2", StringUtil.RTrim( Z1749PrvCon2));
         GxWebStd.gx_hidden_field( context, "Z1759PrvCTel2", StringUtil.RTrim( Z1759PrvCTel2));
         GxWebStd.gx_hidden_field( context, "Z1750PrvCon3", StringUtil.RTrim( Z1750PrvCon3));
         GxWebStd.gx_hidden_field( context, "Z1760PrvCTel3", StringUtil.RTrim( Z1760PrvCTel3));
         GxWebStd.gx_hidden_field( context, "Z1751PrvCon4", StringUtil.RTrim( Z1751PrvCon4));
         GxWebStd.gx_hidden_field( context, "Z1761PrvCTel4", StringUtil.RTrim( Z1761PrvCTel4));
         GxWebStd.gx_hidden_field( context, "Z1752PrvCon5", StringUtil.RTrim( Z1752PrvCon5));
         GxWebStd.gx_hidden_field( context, "Z1762PrvCTel5", StringUtil.RTrim( Z1762PrvCTel5));
         GxWebStd.gx_hidden_field( context, "Z1767PrvNom", StringUtil.RTrim( Z1767PrvNom));
         GxWebStd.gx_hidden_field( context, "Z1744PrvAPeP", StringUtil.RTrim( Z1744PrvAPeP));
         GxWebStd.gx_hidden_field( context, "Z1743PrvAPeM", StringUtil.RTrim( Z1743PrvAPeM));
         GxWebStd.gx_hidden_field( context, "Z1787PrvVincula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1787PrvVincula), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1776PrvRetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1776PrvRetencion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1781PrvTipCuenta1", Z1781PrvTipCuenta1);
         GxWebStd.gx_hidden_field( context, "Z1745PrvBanCuenta1", Z1745PrvBanCuenta1);
         GxWebStd.gx_hidden_field( context, "Z1782PrvTipCuenta2", Z1782PrvTipCuenta2);
         GxWebStd.gx_hidden_field( context, "Z1778PrvTCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1778PrvTCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1746PrvBanCuenta2", Z1746PrvBanCuenta2);
         GxWebStd.gx_hidden_field( context, "Z1783PrvUsuCod", StringUtil.RTrim( Z1783PrvUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1785PrvUsuFec", context.localUtil.TToC( Z1785PrvUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1784PrvUsuCodM", StringUtil.RTrim( Z1784PrvUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z1786PrvUsuFecM", context.localUtil.TToC( Z1786PrvUsuFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1791PrvWebUsu", StringUtil.RTrim( Z1791PrvWebUsu));
         GxWebStd.gx_hidden_field( context, "Z1790PrvWebPas", StringUtil.RTrim( Z1790PrvWebPas));
         GxWebStd.gx_hidden_field( context, "Z1789PrvWebFec", context.localUtil.TToC( Z1789PrvWebFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z297TPerCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z297TPerCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z157TipSCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157TipSCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300PrvConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z296PrvBanCod1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z296PrvBanCod1), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z299PrvBanCod2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299PrvBanCod2), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PRVFOTO_GXI", A40000PrvFoto_GXI);
         GxWebStd.gx_hidden_field( context, "PRVTCON", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1778PrvTCon), 6, 0, ".", "")));
         GXCCtlgxBlob = "PRVFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A1766PrvFoto);
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
         return formatLink("cpproveedores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPPROVEEDORES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proveedores" ;
      }

      protected void InitializeNonKey3L124( )
      {
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = "";
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A1779PrvTel1 = "";
         AssignAttri("", false, "A1779PrvTel1", A1779PrvTel1);
         A1780PrvTel2 = "";
         AssignAttri("", false, "A1780PrvTel2", A1780PrvTel2);
         A1765PrvFax = "";
         AssignAttri("", false, "A1765PrvFax", A1765PrvFax);
         A1747PrvCel = "";
         AssignAttri("", false, "A1747PrvCel", A1747PrvCel);
         A1764PrvEM = "";
         AssignAttri("", false, "A1764PrvEM", A1764PrvEM);
         A1788PrvWeb = "";
         AssignAttri("", false, "A1788PrvWeb", A1788PrvWeb);
         A298TprvCod = 0;
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         A1766PrvFoto = "";
         n1766PrvFoto = false;
         AssignAttri("", false, "A1766PrvFoto", A1766PrvFoto);
         AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
         AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
         n1766PrvFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? true : false);
         A40000PrvFoto_GXI = "";
         n40000PrvFoto_GXI = false;
         AssignProp("", false, imgPrvFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1766PrvFoto)) ? A40000PrvFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1766PrvFoto))), true);
         AssignProp("", false, imgPrvFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1766PrvFoto), true);
         A1777PrvSts = 0;
         AssignAttri("", false, "A1777PrvSts", StringUtil.Str( (decimal)(A1777PrvSts), 1, 0));
         A300PrvConpCod = 0;
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
         A1768PrvRef1 = "";
         AssignAttri("", false, "A1768PrvRef1", A1768PrvRef1);
         A1769PrvRef2 = "";
         AssignAttri("", false, "A1769PrvRef2", A1769PrvRef2);
         A1770PrvRef3 = "";
         AssignAttri("", false, "A1770PrvRef3", A1770PrvRef3);
         A1771PrvRef4 = "";
         AssignAttri("", false, "A1771PrvRef4", A1771PrvRef4);
         A1772PrvRef5 = "";
         AssignAttri("", false, "A1772PrvRef5", A1772PrvRef5);
         A1773PrvRef6 = "";
         AssignAttri("", false, "A1773PrvRef6", A1773PrvRef6);
         A1774PrvRef7 = "";
         AssignAttri("", false, "A1774PrvRef7", A1774PrvRef7);
         A1775PrvRef8 = "";
         AssignAttri("", false, "A1775PrvRef8", A1775PrvRef8);
         A1748PrvCon1 = "";
         AssignAttri("", false, "A1748PrvCon1", A1748PrvCon1);
         A1758PrvCTel1 = "";
         AssignAttri("", false, "A1758PrvCTel1", A1758PrvCTel1);
         A1749PrvCon2 = "";
         AssignAttri("", false, "A1749PrvCon2", A1749PrvCon2);
         A1759PrvCTel2 = "";
         AssignAttri("", false, "A1759PrvCTel2", A1759PrvCTel2);
         A1750PrvCon3 = "";
         AssignAttri("", false, "A1750PrvCon3", A1750PrvCon3);
         A1760PrvCTel3 = "";
         AssignAttri("", false, "A1760PrvCTel3", A1760PrvCTel3);
         A1751PrvCon4 = "";
         AssignAttri("", false, "A1751PrvCon4", A1751PrvCon4);
         A1761PrvCTel4 = "";
         AssignAttri("", false, "A1761PrvCTel4", A1761PrvCTel4);
         A1752PrvCon5 = "";
         AssignAttri("", false, "A1752PrvCon5", A1752PrvCon5);
         A1762PrvCTel5 = "";
         AssignAttri("", false, "A1762PrvCTel5", A1762PrvCTel5);
         A1767PrvNom = "";
         AssignAttri("", false, "A1767PrvNom", A1767PrvNom);
         A1744PrvAPeP = "";
         AssignAttri("", false, "A1744PrvAPeP", A1744PrvAPeP);
         A1743PrvAPeM = "";
         AssignAttri("", false, "A1743PrvAPeM", A1743PrvAPeM);
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A297TPerCod = 0;
         n297TPerCod = false;
         AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
         n297TPerCod = ((0==A297TPerCod) ? true : false);
         A157TipSCod = 0;
         n157TipSCod = false;
         AssignAttri("", false, "A157TipSCod", StringUtil.LTrimStr( (decimal)(A157TipSCod), 6, 0));
         n157TipSCod = ((0==A157TipSCod) ? true : false);
         A1787PrvVincula = 0;
         AssignAttri("", false, "A1787PrvVincula", StringUtil.Str( (decimal)(A1787PrvVincula), 1, 0));
         A1776PrvRetencion = 0;
         AssignAttri("", false, "A1776PrvRetencion", StringUtil.Str( (decimal)(A1776PrvRetencion), 1, 0));
         A1781PrvTipCuenta1 = "";
         AssignAttri("", false, "A1781PrvTipCuenta1", A1781PrvTipCuenta1);
         A296PrvBanCod1 = 0;
         n296PrvBanCod1 = false;
         AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrimStr( (decimal)(A296PrvBanCod1), 6, 0));
         n296PrvBanCod1 = ((0==A296PrvBanCod1) ? true : false);
         A1745PrvBanCuenta1 = "";
         AssignAttri("", false, "A1745PrvBanCuenta1", A1745PrvBanCuenta1);
         A1782PrvTipCuenta2 = "";
         AssignAttri("", false, "A1782PrvTipCuenta2", A1782PrvTipCuenta2);
         A299PrvBanCod2 = 0;
         n299PrvBanCod2 = false;
         AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrimStr( (decimal)(A299PrvBanCod2), 6, 0));
         n299PrvBanCod2 = ((0==A299PrvBanCod2) ? true : false);
         A1778PrvTCon = 0;
         AssignAttri("", false, "A1778PrvTCon", StringUtil.LTrimStr( (decimal)(A1778PrvTCon), 6, 0));
         A1746PrvBanCuenta2 = "";
         AssignAttri("", false, "A1746PrvBanCuenta2", A1746PrvBanCuenta2);
         A1783PrvUsuCod = "";
         AssignAttri("", false, "A1783PrvUsuCod", A1783PrvUsuCod);
         A1785PrvUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1784PrvUsuCodM = "";
         AssignAttri("", false, "A1784PrvUsuCodM", A1784PrvUsuCodM);
         A1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 8, 5, 0, 3, "/", ":", " "));
         A1791PrvWebUsu = "";
         AssignAttri("", false, "A1791PrvWebUsu", A1791PrvWebUsu);
         A1790PrvWebPas = "";
         AssignAttri("", false, "A1790PrvWebPas", A1790PrvWebPas);
         A1789PrvWebFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 8, 5, 0, 3, "/", ":", " "));
         A1756PrvConpDsc = "";
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         Z247PrvDsc = "";
         Z1763PrvDir = "";
         Z1779PrvTel1 = "";
         Z1780PrvTel2 = "";
         Z1765PrvFax = "";
         Z1747PrvCel = "";
         Z1764PrvEM = "";
         Z1788PrvWeb = "";
         Z1777PrvSts = 0;
         Z1768PrvRef1 = "";
         Z1769PrvRef2 = "";
         Z1770PrvRef3 = "";
         Z1771PrvRef4 = "";
         Z1772PrvRef5 = "";
         Z1773PrvRef6 = "";
         Z1774PrvRef7 = "";
         Z1775PrvRef8 = "";
         Z1748PrvCon1 = "";
         Z1758PrvCTel1 = "";
         Z1749PrvCon2 = "";
         Z1759PrvCTel2 = "";
         Z1750PrvCon3 = "";
         Z1760PrvCTel3 = "";
         Z1751PrvCon4 = "";
         Z1761PrvCTel4 = "";
         Z1752PrvCon5 = "";
         Z1762PrvCTel5 = "";
         Z1767PrvNom = "";
         Z1744PrvAPeP = "";
         Z1743PrvAPeM = "";
         Z1787PrvVincula = 0;
         Z1776PrvRetencion = 0;
         Z1781PrvTipCuenta1 = "";
         Z1745PrvBanCuenta1 = "";
         Z1782PrvTipCuenta2 = "";
         Z1778PrvTCon = 0;
         Z1746PrvBanCuenta2 = "";
         Z1783PrvUsuCod = "";
         Z1785PrvUsuFec = (DateTime)(DateTime.MinValue);
         Z1784PrvUsuCodM = "";
         Z1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
         Z1791PrvWebUsu = "";
         Z1790PrvWebPas = "";
         Z1789PrvWebFec = (DateTime)(DateTime.MinValue);
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         Z298TprvCod = 0;
         Z297TPerCod = 0;
         Z157TipSCod = 0;
         Z300PrvConpCod = 0;
         Z296PrvBanCod1 = 0;
         Z299PrvBanCod2 = 0;
      }

      protected void InitAll3L124( )
      {
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         InitializeNonKey3L124( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252857", true, true);
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
         context.AddJavascriptSource("cpproveedores.js", "?202281810252857", false, true);
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
         edtPrvCod_Internalname = "PRVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPrvDsc_Internalname = "PRVDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPrvDir_Internalname = "PRVDIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtEstCod_Internalname = "ESTCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPaiCod_Internalname = "PAICOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPrvTel1_Internalname = "PRVTEL1";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPrvTel2_Internalname = "PRVTEL2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPrvFax_Internalname = "PRVFAX";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPrvCel_Internalname = "PRVCEL";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPrvEM_Internalname = "PRVEM";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPrvWeb_Internalname = "PRVWEB";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtTprvCod_Internalname = "TPRVCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         imgPrvFoto_Internalname = "PRVFOTO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtPrvSts_Internalname = "PRVSTS";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtPrvConpCod_Internalname = "PRVCONPCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtPrvRef1_Internalname = "PRVREF1";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtPrvRef2_Internalname = "PRVREF2";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtPrvRef3_Internalname = "PRVREF3";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtPrvRef4_Internalname = "PRVREF4";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtPrvRef5_Internalname = "PRVREF5";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtPrvRef6_Internalname = "PRVREF6";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtPrvRef7_Internalname = "PRVREF7";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtPrvRef8_Internalname = "PRVREF8";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtPrvCon1_Internalname = "PRVCON1";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtPrvCTel1_Internalname = "PRVCTEL1";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtPrvCon2_Internalname = "PRVCON2";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtPrvCTel2_Internalname = "PRVCTEL2";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtPrvCon3_Internalname = "PRVCON3";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtPrvCTel3_Internalname = "PRVCTEL3";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtPrvCon4_Internalname = "PRVCON4";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtPrvCTel4_Internalname = "PRVCTEL4";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtPrvCon5_Internalname = "PRVCON5";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtPrvCTel5_Internalname = "PRVCTEL5";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtPrvNom_Internalname = "PRVNOM";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtPrvAPeP_Internalname = "PRVAPEP";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtPrvAPeM_Internalname = "PRVAPEM";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtDisCod_Internalname = "DISCOD";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtProvCod_Internalname = "PROVCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtTPerCod_Internalname = "TPERCOD";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtTipSCod_Internalname = "TIPSCOD";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtPrvVincula_Internalname = "PRVVINCULA";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtPrvRetencion_Internalname = "PRVRETENCION";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtPrvTipCuenta1_Internalname = "PRVTIPCUENTA1";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtPrvBanCod1_Internalname = "PRVBANCOD1";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtPrvBanCuenta1_Internalname = "PRVBANCUENTA1";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtPrvTipCuenta2_Internalname = "PRVTIPCUENTA2";
         lblTextblock47_Internalname = "TEXTBLOCK47";
         edtPrvBanCod2_Internalname = "PRVBANCOD2";
         lblTextblock48_Internalname = "TEXTBLOCK48";
         edtPrvBanCuenta2_Internalname = "PRVBANCUENTA2";
         lblTextblock49_Internalname = "TEXTBLOCK49";
         edtPrvUsuCod_Internalname = "PRVUSUCOD";
         lblTextblock50_Internalname = "TEXTBLOCK50";
         edtPrvUsuFec_Internalname = "PRVUSUFEC";
         lblTextblock51_Internalname = "TEXTBLOCK51";
         edtPrvUsuCodM_Internalname = "PRVUSUCODM";
         lblTextblock52_Internalname = "TEXTBLOCK52";
         edtPrvUsuFecM_Internalname = "PRVUSUFECM";
         lblTextblock53_Internalname = "TEXTBLOCK53";
         edtPrvWebUsu_Internalname = "PRVWEBUSU";
         lblTextblock54_Internalname = "TEXTBLOCK54";
         edtPrvWebPas_Internalname = "PRVWEBPAS";
         lblTextblock55_Internalname = "TEXTBLOCK55";
         edtPrvWebFec_Internalname = "PRVWEBFEC";
         lblTextblock56_Internalname = "TEXTBLOCK56";
         edtPrvConpDsc_Internalname = "PRVCONPDSC";
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
         Form.Caption = "Proveedores";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPrvConpDsc_Jsonclick = "";
         edtPrvConpDsc_Enabled = 0;
         edtPrvWebFec_Jsonclick = "";
         edtPrvWebFec_Enabled = 1;
         edtPrvWebPas_Jsonclick = "";
         edtPrvWebPas_Enabled = 1;
         edtPrvWebUsu_Jsonclick = "";
         edtPrvWebUsu_Enabled = 1;
         edtPrvUsuFecM_Jsonclick = "";
         edtPrvUsuFecM_Enabled = 1;
         edtPrvUsuCodM_Jsonclick = "";
         edtPrvUsuCodM_Enabled = 1;
         edtPrvUsuFec_Jsonclick = "";
         edtPrvUsuFec_Enabled = 1;
         edtPrvUsuCod_Jsonclick = "";
         edtPrvUsuCod_Enabled = 1;
         edtPrvBanCuenta2_Jsonclick = "";
         edtPrvBanCuenta2_Enabled = 1;
         edtPrvBanCod2_Jsonclick = "";
         edtPrvBanCod2_Enabled = 1;
         edtPrvTipCuenta2_Jsonclick = "";
         edtPrvTipCuenta2_Enabled = 1;
         edtPrvBanCuenta1_Jsonclick = "";
         edtPrvBanCuenta1_Enabled = 1;
         edtPrvBanCod1_Jsonclick = "";
         edtPrvBanCod1_Enabled = 1;
         edtPrvTipCuenta1_Jsonclick = "";
         edtPrvTipCuenta1_Enabled = 1;
         edtPrvRetencion_Jsonclick = "";
         edtPrvRetencion_Enabled = 1;
         edtPrvVincula_Jsonclick = "";
         edtPrvVincula_Enabled = 1;
         edtTipSCod_Jsonclick = "";
         edtTipSCod_Enabled = 1;
         edtTPerCod_Jsonclick = "";
         edtTPerCod_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
         edtPrvAPeM_Jsonclick = "";
         edtPrvAPeM_Enabled = 1;
         edtPrvAPeP_Jsonclick = "";
         edtPrvAPeP_Enabled = 1;
         edtPrvNom_Jsonclick = "";
         edtPrvNom_Enabled = 1;
         edtPrvCTel5_Jsonclick = "";
         edtPrvCTel5_Enabled = 1;
         edtPrvCon5_Jsonclick = "";
         edtPrvCon5_Enabled = 1;
         edtPrvCTel4_Jsonclick = "";
         edtPrvCTel4_Enabled = 1;
         edtPrvCon4_Jsonclick = "";
         edtPrvCon4_Enabled = 1;
         edtPrvCTel3_Jsonclick = "";
         edtPrvCTel3_Enabled = 1;
         edtPrvCon3_Jsonclick = "";
         edtPrvCon3_Enabled = 1;
         edtPrvCTel2_Jsonclick = "";
         edtPrvCTel2_Enabled = 1;
         edtPrvCon2_Jsonclick = "";
         edtPrvCon2_Enabled = 1;
         edtPrvCTel1_Jsonclick = "";
         edtPrvCTel1_Enabled = 1;
         edtPrvCon1_Jsonclick = "";
         edtPrvCon1_Enabled = 1;
         edtPrvRef8_Jsonclick = "";
         edtPrvRef8_Enabled = 1;
         edtPrvRef7_Jsonclick = "";
         edtPrvRef7_Enabled = 1;
         edtPrvRef6_Jsonclick = "";
         edtPrvRef6_Enabled = 1;
         edtPrvRef5_Jsonclick = "";
         edtPrvRef5_Enabled = 1;
         edtPrvRef4_Jsonclick = "";
         edtPrvRef4_Enabled = 1;
         edtPrvRef3_Jsonclick = "";
         edtPrvRef3_Enabled = 1;
         edtPrvRef2_Jsonclick = "";
         edtPrvRef2_Enabled = 1;
         edtPrvRef1_Jsonclick = "";
         edtPrvRef1_Enabled = 1;
         edtPrvConpCod_Jsonclick = "";
         edtPrvConpCod_Enabled = 1;
         edtPrvSts_Jsonclick = "";
         edtPrvSts_Enabled = 1;
         imgPrvFoto_Enabled = 1;
         edtTprvCod_Jsonclick = "";
         edtTprvCod_Enabled = 1;
         edtPrvWeb_Jsonclick = "";
         edtPrvWeb_Enabled = 1;
         edtPrvEM_Jsonclick = "";
         edtPrvEM_Enabled = 1;
         edtPrvCel_Jsonclick = "";
         edtPrvCel_Enabled = 1;
         edtPrvFax_Jsonclick = "";
         edtPrvFax_Enabled = 1;
         edtPrvTel2_Jsonclick = "";
         edtPrvTel2_Enabled = 1;
         edtPrvTel1_Jsonclick = "";
         edtPrvTel1_Enabled = 1;
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtPrvDir_Jsonclick = "";
         edtPrvDir_Enabled = 1;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPrvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Prvcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1763PrvDir", StringUtil.RTrim( A1763PrvDir));
         AssignAttri("", false, "A140EstCod", StringUtil.RTrim( A140EstCod));
         AssignAttri("", false, "A139PaiCod", StringUtil.RTrim( A139PaiCod));
         AssignAttri("", false, "A1779PrvTel1", StringUtil.RTrim( A1779PrvTel1));
         AssignAttri("", false, "A1780PrvTel2", StringUtil.RTrim( A1780PrvTel2));
         AssignAttri("", false, "A1765PrvFax", StringUtil.RTrim( A1765PrvFax));
         AssignAttri("", false, "A1747PrvCel", StringUtil.RTrim( A1747PrvCel));
         AssignAttri("", false, "A1764PrvEM", StringUtil.RTrim( A1764PrvEM));
         AssignAttri("", false, "A1788PrvWeb", StringUtil.RTrim( A1788PrvWeb));
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1766PrvFoto", context.PathToRelativeUrl( A1766PrvFoto));
         GXCCtlgxBlob = "PRVFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A1766PrvFoto));
         AssignAttri("", false, "A40000PrvFoto_GXI", A40000PrvFoto_GXI);
         AssignAttri("", false, "A1777PrvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1777PrvSts), 1, 0, ".", "")));
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1768PrvRef1", StringUtil.RTrim( A1768PrvRef1));
         AssignAttri("", false, "A1769PrvRef2", StringUtil.RTrim( A1769PrvRef2));
         AssignAttri("", false, "A1770PrvRef3", StringUtil.RTrim( A1770PrvRef3));
         AssignAttri("", false, "A1771PrvRef4", StringUtil.RTrim( A1771PrvRef4));
         AssignAttri("", false, "A1772PrvRef5", StringUtil.RTrim( A1772PrvRef5));
         AssignAttri("", false, "A1773PrvRef6", StringUtil.RTrim( A1773PrvRef6));
         AssignAttri("", false, "A1774PrvRef7", StringUtil.RTrim( A1774PrvRef7));
         AssignAttri("", false, "A1775PrvRef8", StringUtil.RTrim( A1775PrvRef8));
         AssignAttri("", false, "A1748PrvCon1", StringUtil.RTrim( A1748PrvCon1));
         AssignAttri("", false, "A1758PrvCTel1", StringUtil.RTrim( A1758PrvCTel1));
         AssignAttri("", false, "A1749PrvCon2", StringUtil.RTrim( A1749PrvCon2));
         AssignAttri("", false, "A1759PrvCTel2", StringUtil.RTrim( A1759PrvCTel2));
         AssignAttri("", false, "A1750PrvCon3", StringUtil.RTrim( A1750PrvCon3));
         AssignAttri("", false, "A1760PrvCTel3", StringUtil.RTrim( A1760PrvCTel3));
         AssignAttri("", false, "A1751PrvCon4", StringUtil.RTrim( A1751PrvCon4));
         AssignAttri("", false, "A1761PrvCTel4", StringUtil.RTrim( A1761PrvCTel4));
         AssignAttri("", false, "A1752PrvCon5", StringUtil.RTrim( A1752PrvCon5));
         AssignAttri("", false, "A1762PrvCTel5", StringUtil.RTrim( A1762PrvCTel5));
         AssignAttri("", false, "A1767PrvNom", StringUtil.RTrim( A1767PrvNom));
         AssignAttri("", false, "A1744PrvAPeP", StringUtil.RTrim( A1744PrvAPeP));
         AssignAttri("", false, "A1743PrvAPeM", StringUtil.RTrim( A1743PrvAPeM));
         AssignAttri("", false, "A142DisCod", StringUtil.RTrim( A142DisCod));
         AssignAttri("", false, "A141ProvCod", StringUtil.RTrim( A141ProvCod));
         AssignAttri("", false, "A297TPerCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A297TPerCod), 6, 0, ".", "")));
         AssignAttri("", false, "A157TipSCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A157TipSCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1787PrvVincula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1787PrvVincula), 1, 0, ".", "")));
         AssignAttri("", false, "A1776PrvRetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1776PrvRetencion), 1, 0, ".", "")));
         AssignAttri("", false, "A1781PrvTipCuenta1", A1781PrvTipCuenta1);
         AssignAttri("", false, "A296PrvBanCod1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A296PrvBanCod1), 6, 0, ".", "")));
         AssignAttri("", false, "A1745PrvBanCuenta1", A1745PrvBanCuenta1);
         AssignAttri("", false, "A1782PrvTipCuenta2", A1782PrvTipCuenta2);
         AssignAttri("", false, "A299PrvBanCod2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A299PrvBanCod2), 6, 0, ".", "")));
         AssignAttri("", false, "A1778PrvTCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1778PrvTCon), 6, 0, ".", "")));
         AssignAttri("", false, "A1746PrvBanCuenta2", A1746PrvBanCuenta2);
         AssignAttri("", false, "A1783PrvUsuCod", StringUtil.RTrim( A1783PrvUsuCod));
         AssignAttri("", false, "A1785PrvUsuFec", context.localUtil.TToC( A1785PrvUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1784PrvUsuCodM", StringUtil.RTrim( A1784PrvUsuCodM));
         AssignAttri("", false, "A1786PrvUsuFecM", context.localUtil.TToC( A1786PrvUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1791PrvWebUsu", StringUtil.RTrim( A1791PrvWebUsu));
         AssignAttri("", false, "A1790PrvWebPas", StringUtil.RTrim( A1790PrvWebPas));
         AssignAttri("", false, "A1789PrvWebFec", context.localUtil.TToC( A1789PrvWebFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1756PrvConpDsc", StringUtil.RTrim( A1756PrvConpDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1763PrvDir", StringUtil.RTrim( Z1763PrvDir));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z1779PrvTel1", StringUtil.RTrim( Z1779PrvTel1));
         GxWebStd.gx_hidden_field( context, "Z1780PrvTel2", StringUtil.RTrim( Z1780PrvTel2));
         GxWebStd.gx_hidden_field( context, "Z1765PrvFax", StringUtil.RTrim( Z1765PrvFax));
         GxWebStd.gx_hidden_field( context, "Z1747PrvCel", StringUtil.RTrim( Z1747PrvCel));
         GxWebStd.gx_hidden_field( context, "Z1764PrvEM", StringUtil.RTrim( Z1764PrvEM));
         GxWebStd.gx_hidden_field( context, "Z1788PrvWeb", StringUtil.RTrim( Z1788PrvWeb));
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1766PrvFoto", context.PathToRelativeUrl( Z1766PrvFoto));
         GxWebStd.gx_hidden_field( context, "Z40000PrvFoto_GXI", Z40000PrvFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z1777PrvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1777PrvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300PrvConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1768PrvRef1", StringUtil.RTrim( Z1768PrvRef1));
         GxWebStd.gx_hidden_field( context, "Z1769PrvRef2", StringUtil.RTrim( Z1769PrvRef2));
         GxWebStd.gx_hidden_field( context, "Z1770PrvRef3", StringUtil.RTrim( Z1770PrvRef3));
         GxWebStd.gx_hidden_field( context, "Z1771PrvRef4", StringUtil.RTrim( Z1771PrvRef4));
         GxWebStd.gx_hidden_field( context, "Z1772PrvRef5", StringUtil.RTrim( Z1772PrvRef5));
         GxWebStd.gx_hidden_field( context, "Z1773PrvRef6", StringUtil.RTrim( Z1773PrvRef6));
         GxWebStd.gx_hidden_field( context, "Z1774PrvRef7", StringUtil.RTrim( Z1774PrvRef7));
         GxWebStd.gx_hidden_field( context, "Z1775PrvRef8", StringUtil.RTrim( Z1775PrvRef8));
         GxWebStd.gx_hidden_field( context, "Z1748PrvCon1", StringUtil.RTrim( Z1748PrvCon1));
         GxWebStd.gx_hidden_field( context, "Z1758PrvCTel1", StringUtil.RTrim( Z1758PrvCTel1));
         GxWebStd.gx_hidden_field( context, "Z1749PrvCon2", StringUtil.RTrim( Z1749PrvCon2));
         GxWebStd.gx_hidden_field( context, "Z1759PrvCTel2", StringUtil.RTrim( Z1759PrvCTel2));
         GxWebStd.gx_hidden_field( context, "Z1750PrvCon3", StringUtil.RTrim( Z1750PrvCon3));
         GxWebStd.gx_hidden_field( context, "Z1760PrvCTel3", StringUtil.RTrim( Z1760PrvCTel3));
         GxWebStd.gx_hidden_field( context, "Z1751PrvCon4", StringUtil.RTrim( Z1751PrvCon4));
         GxWebStd.gx_hidden_field( context, "Z1761PrvCTel4", StringUtil.RTrim( Z1761PrvCTel4));
         GxWebStd.gx_hidden_field( context, "Z1752PrvCon5", StringUtil.RTrim( Z1752PrvCon5));
         GxWebStd.gx_hidden_field( context, "Z1762PrvCTel5", StringUtil.RTrim( Z1762PrvCTel5));
         GxWebStd.gx_hidden_field( context, "Z1767PrvNom", StringUtil.RTrim( Z1767PrvNom));
         GxWebStd.gx_hidden_field( context, "Z1744PrvAPeP", StringUtil.RTrim( Z1744PrvAPeP));
         GxWebStd.gx_hidden_field( context, "Z1743PrvAPeM", StringUtil.RTrim( Z1743PrvAPeM));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z297TPerCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z297TPerCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z157TipSCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157TipSCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1787PrvVincula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1787PrvVincula), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1776PrvRetencion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1776PrvRetencion), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1781PrvTipCuenta1", Z1781PrvTipCuenta1);
         GxWebStd.gx_hidden_field( context, "Z296PrvBanCod1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z296PrvBanCod1), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1745PrvBanCuenta1", Z1745PrvBanCuenta1);
         GxWebStd.gx_hidden_field( context, "Z1782PrvTipCuenta2", Z1782PrvTipCuenta2);
         GxWebStd.gx_hidden_field( context, "Z299PrvBanCod2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z299PrvBanCod2), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1778PrvTCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1778PrvTCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1746PrvBanCuenta2", Z1746PrvBanCuenta2);
         GxWebStd.gx_hidden_field( context, "Z1783PrvUsuCod", StringUtil.RTrim( Z1783PrvUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1785PrvUsuFec", context.localUtil.TToC( Z1785PrvUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1784PrvUsuCodM", StringUtil.RTrim( Z1784PrvUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z1786PrvUsuFecM", context.localUtil.TToC( Z1786PrvUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1791PrvWebUsu", StringUtil.RTrim( Z1791PrvWebUsu));
         GxWebStd.gx_hidden_field( context, "Z1790PrvWebPas", StringUtil.RTrim( Z1790PrvWebPas));
         GxWebStd.gx_hidden_field( context, "Z1789PrvWebFec", context.localUtil.TToC( Z1789PrvWebFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1756PrvConpDsc", StringUtil.RTrim( Z1756PrvConpDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tprvcod( )
      {
         /* Using cursor T003L42 */
         pr_default.execute(40, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(40) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Proveedor'.", "ForeignKeyNotFound", 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
         }
         pr_default.close(40);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prvconpcod( )
      {
         /* Using cursor T003L26 */
         pr_default.execute(24, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvConpCod_Internalname;
         }
         A1756PrvConpDsc = T003L26_A1756PrvConpDsc[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1756PrvConpDsc", StringUtil.RTrim( A1756PrvConpDsc));
      }

      public void Valid_Provcod( )
      {
         /* Using cursor T003L43 */
         pr_default.execute(41, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(41) == 101) )
         {
            GX_msglist.addItem("No existe 'Distritos'.", "ForeignKeyNotFound", 1, "DISCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(41);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tpercod( )
      {
         n297TPerCod = false;
         /* Using cursor T003L44 */
         pr_default.execute(42, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(42) == 101) )
         {
            if ( ! ( (0==A297TPerCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Persona'.", "ForeignKeyNotFound", 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
            }
         }
         pr_default.close(42);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipscod( )
      {
         n157TipSCod = false;
         /* Using cursor T003L45 */
         pr_default.execute(43, new Object[] {n157TipSCod, A157TipSCod});
         if ( (pr_default.getStatus(43) == 101) )
         {
            if ( ! ( (0==A157TipSCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Documentos'.", "ForeignKeyNotFound", 1, "TIPSCOD");
               AnyError = 1;
               GX_FocusControl = edtTipSCod_Internalname;
            }
         }
         pr_default.close(43);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prvbancod1( )
      {
         n296PrvBanCod1 = false;
         /* Using cursor T003L46 */
         pr_default.execute(44, new Object[] {n296PrvBanCod1, A296PrvBanCod1});
         if ( (pr_default.getStatus(44) == 101) )
         {
            if ( ! ( (0==A296PrvBanCod1) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD1");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod1_Internalname;
            }
         }
         pr_default.close(44);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prvbancod2( )
      {
         n299PrvBanCod2 = false;
         /* Using cursor T003L47 */
         pr_default.execute(45, new Object[] {n299PrvBanCod2, A299PrvBanCod2});
         if ( (pr_default.getStatus(45) == 101) )
         {
            if ( ! ( (0==A299PrvBanCod2) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "PRVBANCOD2");
               AnyError = 1;
               GX_FocusControl = edtPrvBanCod2_Internalname;
            }
         }
         pr_default.close(45);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1778PrvTCon',fld:'PRVTCON',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A1778PrvTCon',fld:'PRVTCON',pic:'ZZZZZ9'},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1779PrvTel1',fld:'PRVTEL1',pic:''},{av:'A1780PrvTel2',fld:'PRVTEL2',pic:''},{av:'A1765PrvFax',fld:'PRVFAX',pic:''},{av:'A1747PrvCel',fld:'PRVCEL',pic:''},{av:'A1764PrvEM',fld:'PRVEM',pic:''},{av:'A1788PrvWeb',fld:'PRVWEB',pic:''},{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'},{av:'A1766PrvFoto',fld:'PRVFOTO',pic:''},{av:'A40000PrvFoto_GXI',fld:'PRVFOTO_GXI',pic:''},{av:'A1777PrvSts',fld:'PRVSTS',pic:'9'},{av:'A300PrvConpCod',fld:'PRVCONPCOD',pic:'ZZZZZ9'},{av:'A1768PrvRef1',fld:'PRVREF1',pic:''},{av:'A1769PrvRef2',fld:'PRVREF2',pic:''},{av:'A1770PrvRef3',fld:'PRVREF3',pic:''},{av:'A1771PrvRef4',fld:'PRVREF4',pic:''},{av:'A1772PrvRef5',fld:'PRVREF5',pic:''},{av:'A1773PrvRef6',fld:'PRVREF6',pic:''},{av:'A1774PrvRef7',fld:'PRVREF7',pic:''},{av:'A1775PrvRef8',fld:'PRVREF8',pic:''},{av:'A1748PrvCon1',fld:'PRVCON1',pic:''},{av:'A1758PrvCTel1',fld:'PRVCTEL1',pic:''},{av:'A1749PrvCon2',fld:'PRVCON2',pic:''},{av:'A1759PrvCTel2',fld:'PRVCTEL2',pic:''},{av:'A1750PrvCon3',fld:'PRVCON3',pic:''},{av:'A1760PrvCTel3',fld:'PRVCTEL3',pic:''},{av:'A1751PrvCon4',fld:'PRVCON4',pic:''},{av:'A1761PrvCTel4',fld:'PRVCTEL4',pic:''},{av:'A1752PrvCon5',fld:'PRVCON5',pic:''},{av:'A1762PrvCTel5',fld:'PRVCTEL5',pic:''},{av:'A1767PrvNom',fld:'PRVNOM',pic:''},{av:'A1744PrvAPeP',fld:'PRVAPEP',pic:''},{av:'A1743PrvAPeM',fld:'PRVAPEM',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A297TPerCod',fld:'TPERCOD',pic:'ZZZZZ9'},{av:'A157TipSCod',fld:'TIPSCOD',pic:'ZZZZZ9'},{av:'A1787PrvVincula',fld:'PRVVINCULA',pic:'9'},{av:'A1776PrvRetencion',fld:'PRVRETENCION',pic:'9'},{av:'A1781PrvTipCuenta1',fld:'PRVTIPCUENTA1',pic:''},{av:'A296PrvBanCod1',fld:'PRVBANCOD1',pic:'ZZZZZ9'},{av:'A1745PrvBanCuenta1',fld:'PRVBANCUENTA1',pic:''},{av:'A1782PrvTipCuenta2',fld:'PRVTIPCUENTA2',pic:''},{av:'A299PrvBanCod2',fld:'PRVBANCOD2',pic:'ZZZZZ9'},{av:'A1778PrvTCon',fld:'PRVTCON',pic:'ZZZZZ9'},{av:'A1746PrvBanCuenta2',fld:'PRVBANCUENTA2',pic:''},{av:'A1783PrvUsuCod',fld:'PRVUSUCOD',pic:''},{av:'A1785PrvUsuFec',fld:'PRVUSUFEC',pic:'99/99/99 99:99'},{av:'A1784PrvUsuCodM',fld:'PRVUSUCODM',pic:''},{av:'A1786PrvUsuFecM',fld:'PRVUSUFECM',pic:'99/99/99 99:99'},{av:'A1791PrvWebUsu',fld:'PRVWEBUSU',pic:''},{av:'A1790PrvWebPas',fld:'PRVWEBPAS',pic:''},{av:'A1789PrvWebFec',fld:'PRVWEBFEC',pic:'99/99/99 99:99'},{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z244PrvCod'},{av:'Z247PrvDsc'},{av:'Z1763PrvDir'},{av:'Z140EstCod'},{av:'Z139PaiCod'},{av:'Z1779PrvTel1'},{av:'Z1780PrvTel2'},{av:'Z1765PrvFax'},{av:'Z1747PrvCel'},{av:'Z1764PrvEM'},{av:'Z1788PrvWeb'},{av:'Z298TprvCod'},{av:'Z1766PrvFoto'},{av:'Z40000PrvFoto_GXI'},{av:'Z1777PrvSts'},{av:'Z300PrvConpCod'},{av:'Z1768PrvRef1'},{av:'Z1769PrvRef2'},{av:'Z1770PrvRef3'},{av:'Z1771PrvRef4'},{av:'Z1772PrvRef5'},{av:'Z1773PrvRef6'},{av:'Z1774PrvRef7'},{av:'Z1775PrvRef8'},{av:'Z1748PrvCon1'},{av:'Z1758PrvCTel1'},{av:'Z1749PrvCon2'},{av:'Z1759PrvCTel2'},{av:'Z1750PrvCon3'},{av:'Z1760PrvCTel3'},{av:'Z1751PrvCon4'},{av:'Z1761PrvCTel4'},{av:'Z1752PrvCon5'},{av:'Z1762PrvCTel5'},{av:'Z1767PrvNom'},{av:'Z1744PrvAPeP'},{av:'Z1743PrvAPeM'},{av:'Z142DisCod'},{av:'Z141ProvCod'},{av:'Z297TPerCod'},{av:'Z157TipSCod'},{av:'Z1787PrvVincula'},{av:'Z1776PrvRetencion'},{av:'Z1781PrvTipCuenta1'},{av:'Z296PrvBanCod1'},{av:'Z1745PrvBanCuenta1'},{av:'Z1782PrvTipCuenta2'},{av:'Z299PrvBanCod2'},{av:'Z1778PrvTCon'},{av:'Z1746PrvBanCuenta2'},{av:'Z1783PrvUsuCod'},{av:'Z1785PrvUsuFec'},{av:'Z1784PrvUsuCodM'},{av:'Z1786PrvUsuFecM'},{av:'Z1791PrvWebUsu'},{av:'Z1790PrvWebPas'},{av:'Z1789PrvWebFec'},{av:'Z1756PrvConpDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[]");
         setEventMetadata("VALID_PAICOD",",oparms:[]}");
         setEventMetadata("VALID_TPRVCOD","{handler:'Valid_Tprvcod',iparms:[{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_PRVCONPCOD","{handler:'Valid_Prvconpcod',iparms:[{av:'A300PrvConpCod',fld:'PRVCONPCOD',pic:'ZZZZZ9'},{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''}]");
         setEventMetadata("VALID_PRVCONPCOD",",oparms:[{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''}]}");
         setEventMetadata("VALID_DISCOD","{handler:'Valid_Discod',iparms:[]");
         setEventMetadata("VALID_DISCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[]}");
         setEventMetadata("VALID_TPERCOD","{handler:'Valid_Tpercod',iparms:[{av:'A297TPerCod',fld:'TPERCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TPERCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPSCOD","{handler:'Valid_Tipscod',iparms:[{av:'A157TipSCod',fld:'TIPSCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPSCOD",",oparms:[]}");
         setEventMetadata("VALID_PRVBANCOD1","{handler:'Valid_Prvbancod1',iparms:[{av:'A296PrvBanCod1',fld:'PRVBANCOD1',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRVBANCOD1",",oparms:[]}");
         setEventMetadata("VALID_PRVBANCOD2","{handler:'Valid_Prvbancod2',iparms:[{av:'A299PrvBanCod2',fld:'PRVBANCOD2',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRVBANCOD2",",oparms:[]}");
         setEventMetadata("VALID_PRVUSUFEC","{handler:'Valid_Prvusufec',iparms:[]");
         setEventMetadata("VALID_PRVUSUFEC",",oparms:[]}");
         setEventMetadata("VALID_PRVUSUFECM","{handler:'Valid_Prvusufecm',iparms:[]");
         setEventMetadata("VALID_PRVUSUFECM",",oparms:[]}");
         setEventMetadata("VALID_PRVWEBFEC","{handler:'Valid_Prvwebfec',iparms:[]");
         setEventMetadata("VALID_PRVWEBFEC",",oparms:[]}");
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
         pr_default.close(41);
         pr_default.close(40);
         pr_default.close(42);
         pr_default.close(43);
         pr_default.close(24);
         pr_default.close(44);
         pr_default.close(45);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z244PrvCod = "";
         Z247PrvDsc = "";
         Z1763PrvDir = "";
         Z1779PrvTel1 = "";
         Z1780PrvTel2 = "";
         Z1765PrvFax = "";
         Z1747PrvCel = "";
         Z1764PrvEM = "";
         Z1788PrvWeb = "";
         Z1768PrvRef1 = "";
         Z1769PrvRef2 = "";
         Z1770PrvRef3 = "";
         Z1771PrvRef4 = "";
         Z1772PrvRef5 = "";
         Z1773PrvRef6 = "";
         Z1774PrvRef7 = "";
         Z1775PrvRef8 = "";
         Z1748PrvCon1 = "";
         Z1758PrvCTel1 = "";
         Z1749PrvCon2 = "";
         Z1759PrvCTel2 = "";
         Z1750PrvCon3 = "";
         Z1760PrvCTel3 = "";
         Z1751PrvCon4 = "";
         Z1761PrvCTel4 = "";
         Z1752PrvCon5 = "";
         Z1762PrvCTel5 = "";
         Z1767PrvNom = "";
         Z1744PrvAPeP = "";
         Z1743PrvAPeM = "";
         Z1781PrvTipCuenta1 = "";
         Z1745PrvBanCuenta1 = "";
         Z1782PrvTipCuenta2 = "";
         Z1746PrvBanCuenta2 = "";
         Z1783PrvUsuCod = "";
         Z1785PrvUsuFec = (DateTime)(DateTime.MinValue);
         Z1784PrvUsuCodM = "";
         Z1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
         Z1791PrvWebUsu = "";
         Z1790PrvWebPas = "";
         Z1789PrvWebFec = (DateTime)(DateTime.MinValue);
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         A244PrvCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A247PrvDsc = "";
         lblTextblock3_Jsonclick = "";
         A1763PrvDir = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1779PrvTel1 = "";
         lblTextblock7_Jsonclick = "";
         A1780PrvTel2 = "";
         lblTextblock8_Jsonclick = "";
         A1765PrvFax = "";
         lblTextblock9_Jsonclick = "";
         A1747PrvCel = "";
         lblTextblock10_Jsonclick = "";
         A1764PrvEM = "";
         lblTextblock11_Jsonclick = "";
         A1788PrvWeb = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A1766PrvFoto = "";
         A40000PrvFoto_GXI = "";
         sImgUrl = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         A1768PrvRef1 = "";
         lblTextblock17_Jsonclick = "";
         A1769PrvRef2 = "";
         lblTextblock18_Jsonclick = "";
         A1770PrvRef3 = "";
         lblTextblock19_Jsonclick = "";
         A1771PrvRef4 = "";
         lblTextblock20_Jsonclick = "";
         A1772PrvRef5 = "";
         lblTextblock21_Jsonclick = "";
         A1773PrvRef6 = "";
         lblTextblock22_Jsonclick = "";
         A1774PrvRef7 = "";
         lblTextblock23_Jsonclick = "";
         A1775PrvRef8 = "";
         lblTextblock24_Jsonclick = "";
         A1748PrvCon1 = "";
         lblTextblock25_Jsonclick = "";
         A1758PrvCTel1 = "";
         lblTextblock26_Jsonclick = "";
         A1749PrvCon2 = "";
         lblTextblock27_Jsonclick = "";
         A1759PrvCTel2 = "";
         lblTextblock28_Jsonclick = "";
         A1750PrvCon3 = "";
         lblTextblock29_Jsonclick = "";
         A1760PrvCTel3 = "";
         lblTextblock30_Jsonclick = "";
         A1751PrvCon4 = "";
         lblTextblock31_Jsonclick = "";
         A1761PrvCTel4 = "";
         lblTextblock32_Jsonclick = "";
         A1752PrvCon5 = "";
         lblTextblock33_Jsonclick = "";
         A1762PrvCTel5 = "";
         lblTextblock34_Jsonclick = "";
         A1767PrvNom = "";
         lblTextblock35_Jsonclick = "";
         A1744PrvAPeP = "";
         lblTextblock36_Jsonclick = "";
         A1743PrvAPeM = "";
         lblTextblock37_Jsonclick = "";
         lblTextblock38_Jsonclick = "";
         lblTextblock39_Jsonclick = "";
         lblTextblock40_Jsonclick = "";
         lblTextblock41_Jsonclick = "";
         lblTextblock42_Jsonclick = "";
         lblTextblock43_Jsonclick = "";
         A1781PrvTipCuenta1 = "";
         lblTextblock44_Jsonclick = "";
         lblTextblock45_Jsonclick = "";
         A1745PrvBanCuenta1 = "";
         lblTextblock46_Jsonclick = "";
         A1782PrvTipCuenta2 = "";
         lblTextblock47_Jsonclick = "";
         lblTextblock48_Jsonclick = "";
         A1746PrvBanCuenta2 = "";
         lblTextblock49_Jsonclick = "";
         A1783PrvUsuCod = "";
         lblTextblock50_Jsonclick = "";
         A1785PrvUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock51_Jsonclick = "";
         A1784PrvUsuCodM = "";
         lblTextblock52_Jsonclick = "";
         A1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
         lblTextblock53_Jsonclick = "";
         A1791PrvWebUsu = "";
         lblTextblock54_Jsonclick = "";
         A1790PrvWebPas = "";
         lblTextblock55_Jsonclick = "";
         A1789PrvWebFec = (DateTime)(DateTime.MinValue);
         lblTextblock56_Jsonclick = "";
         A1756PrvConpDsc = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1766PrvFoto = "";
         Z40000PrvFoto_GXI = "";
         Z1756PrvConpDsc = "";
         T003L11_A244PrvCod = new string[] {""} ;
         T003L11_A247PrvDsc = new string[] {""} ;
         T003L11_A1763PrvDir = new string[] {""} ;
         T003L11_A1779PrvTel1 = new string[] {""} ;
         T003L11_A1780PrvTel2 = new string[] {""} ;
         T003L11_A1765PrvFax = new string[] {""} ;
         T003L11_A1747PrvCel = new string[] {""} ;
         T003L11_A1764PrvEM = new string[] {""} ;
         T003L11_A1788PrvWeb = new string[] {""} ;
         T003L11_A40000PrvFoto_GXI = new string[] {""} ;
         T003L11_n40000PrvFoto_GXI = new bool[] {false} ;
         T003L11_A1777PrvSts = new short[1] ;
         T003L11_A1768PrvRef1 = new string[] {""} ;
         T003L11_A1769PrvRef2 = new string[] {""} ;
         T003L11_A1770PrvRef3 = new string[] {""} ;
         T003L11_A1771PrvRef4 = new string[] {""} ;
         T003L11_A1772PrvRef5 = new string[] {""} ;
         T003L11_A1773PrvRef6 = new string[] {""} ;
         T003L11_A1774PrvRef7 = new string[] {""} ;
         T003L11_A1775PrvRef8 = new string[] {""} ;
         T003L11_A1748PrvCon1 = new string[] {""} ;
         T003L11_A1758PrvCTel1 = new string[] {""} ;
         T003L11_A1749PrvCon2 = new string[] {""} ;
         T003L11_A1759PrvCTel2 = new string[] {""} ;
         T003L11_A1750PrvCon3 = new string[] {""} ;
         T003L11_A1760PrvCTel3 = new string[] {""} ;
         T003L11_A1751PrvCon4 = new string[] {""} ;
         T003L11_A1761PrvCTel4 = new string[] {""} ;
         T003L11_A1752PrvCon5 = new string[] {""} ;
         T003L11_A1762PrvCTel5 = new string[] {""} ;
         T003L11_A1767PrvNom = new string[] {""} ;
         T003L11_A1744PrvAPeP = new string[] {""} ;
         T003L11_A1743PrvAPeM = new string[] {""} ;
         T003L11_A1787PrvVincula = new short[1] ;
         T003L11_A1776PrvRetencion = new short[1] ;
         T003L11_A1781PrvTipCuenta1 = new string[] {""} ;
         T003L11_A1745PrvBanCuenta1 = new string[] {""} ;
         T003L11_A1782PrvTipCuenta2 = new string[] {""} ;
         T003L11_A1778PrvTCon = new int[1] ;
         T003L11_A1746PrvBanCuenta2 = new string[] {""} ;
         T003L11_A1783PrvUsuCod = new string[] {""} ;
         T003L11_A1785PrvUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003L11_A1784PrvUsuCodM = new string[] {""} ;
         T003L11_A1786PrvUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T003L11_A1791PrvWebUsu = new string[] {""} ;
         T003L11_A1790PrvWebPas = new string[] {""} ;
         T003L11_A1789PrvWebFec = new DateTime[] {DateTime.MinValue} ;
         T003L11_A1756PrvConpDsc = new string[] {""} ;
         T003L11_A139PaiCod = new string[] {""} ;
         T003L11_A140EstCod = new string[] {""} ;
         T003L11_A141ProvCod = new string[] {""} ;
         T003L11_A142DisCod = new string[] {""} ;
         T003L11_A298TprvCod = new int[1] ;
         T003L11_A297TPerCod = new int[1] ;
         T003L11_n297TPerCod = new bool[] {false} ;
         T003L11_A157TipSCod = new int[1] ;
         T003L11_n157TipSCod = new bool[] {false} ;
         T003L11_A300PrvConpCod = new int[1] ;
         T003L11_A296PrvBanCod1 = new int[1] ;
         T003L11_n296PrvBanCod1 = new bool[] {false} ;
         T003L11_A299PrvBanCod2 = new int[1] ;
         T003L11_n299PrvBanCod2 = new bool[] {false} ;
         T003L11_A1766PrvFoto = new string[] {""} ;
         T003L11_n1766PrvFoto = new bool[] {false} ;
         T003L4_A139PaiCod = new string[] {""} ;
         T003L5_A298TprvCod = new int[1] ;
         T003L8_A1756PrvConpDsc = new string[] {""} ;
         T003L6_A297TPerCod = new int[1] ;
         T003L6_n297TPerCod = new bool[] {false} ;
         T003L7_A157TipSCod = new int[1] ;
         T003L7_n157TipSCod = new bool[] {false} ;
         T003L9_A296PrvBanCod1 = new int[1] ;
         T003L9_n296PrvBanCod1 = new bool[] {false} ;
         T003L10_A299PrvBanCod2 = new int[1] ;
         T003L10_n299PrvBanCod2 = new bool[] {false} ;
         T003L12_A139PaiCod = new string[] {""} ;
         T003L13_A298TprvCod = new int[1] ;
         T003L14_A1756PrvConpDsc = new string[] {""} ;
         T003L15_A297TPerCod = new int[1] ;
         T003L15_n297TPerCod = new bool[] {false} ;
         T003L16_A157TipSCod = new int[1] ;
         T003L16_n157TipSCod = new bool[] {false} ;
         T003L17_A296PrvBanCod1 = new int[1] ;
         T003L17_n296PrvBanCod1 = new bool[] {false} ;
         T003L18_A299PrvBanCod2 = new int[1] ;
         T003L18_n299PrvBanCod2 = new bool[] {false} ;
         T003L19_A244PrvCod = new string[] {""} ;
         T003L3_A244PrvCod = new string[] {""} ;
         T003L3_A247PrvDsc = new string[] {""} ;
         T003L3_A1763PrvDir = new string[] {""} ;
         T003L3_A1779PrvTel1 = new string[] {""} ;
         T003L3_A1780PrvTel2 = new string[] {""} ;
         T003L3_A1765PrvFax = new string[] {""} ;
         T003L3_A1747PrvCel = new string[] {""} ;
         T003L3_A1764PrvEM = new string[] {""} ;
         T003L3_A1788PrvWeb = new string[] {""} ;
         T003L3_A40000PrvFoto_GXI = new string[] {""} ;
         T003L3_n40000PrvFoto_GXI = new bool[] {false} ;
         T003L3_A1777PrvSts = new short[1] ;
         T003L3_A1768PrvRef1 = new string[] {""} ;
         T003L3_A1769PrvRef2 = new string[] {""} ;
         T003L3_A1770PrvRef3 = new string[] {""} ;
         T003L3_A1771PrvRef4 = new string[] {""} ;
         T003L3_A1772PrvRef5 = new string[] {""} ;
         T003L3_A1773PrvRef6 = new string[] {""} ;
         T003L3_A1774PrvRef7 = new string[] {""} ;
         T003L3_A1775PrvRef8 = new string[] {""} ;
         T003L3_A1748PrvCon1 = new string[] {""} ;
         T003L3_A1758PrvCTel1 = new string[] {""} ;
         T003L3_A1749PrvCon2 = new string[] {""} ;
         T003L3_A1759PrvCTel2 = new string[] {""} ;
         T003L3_A1750PrvCon3 = new string[] {""} ;
         T003L3_A1760PrvCTel3 = new string[] {""} ;
         T003L3_A1751PrvCon4 = new string[] {""} ;
         T003L3_A1761PrvCTel4 = new string[] {""} ;
         T003L3_A1752PrvCon5 = new string[] {""} ;
         T003L3_A1762PrvCTel5 = new string[] {""} ;
         T003L3_A1767PrvNom = new string[] {""} ;
         T003L3_A1744PrvAPeP = new string[] {""} ;
         T003L3_A1743PrvAPeM = new string[] {""} ;
         T003L3_A1787PrvVincula = new short[1] ;
         T003L3_A1776PrvRetencion = new short[1] ;
         T003L3_A1781PrvTipCuenta1 = new string[] {""} ;
         T003L3_A1745PrvBanCuenta1 = new string[] {""} ;
         T003L3_A1782PrvTipCuenta2 = new string[] {""} ;
         T003L3_A1778PrvTCon = new int[1] ;
         T003L3_A1746PrvBanCuenta2 = new string[] {""} ;
         T003L3_A1783PrvUsuCod = new string[] {""} ;
         T003L3_A1785PrvUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003L3_A1784PrvUsuCodM = new string[] {""} ;
         T003L3_A1786PrvUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T003L3_A1791PrvWebUsu = new string[] {""} ;
         T003L3_A1790PrvWebPas = new string[] {""} ;
         T003L3_A1789PrvWebFec = new DateTime[] {DateTime.MinValue} ;
         T003L3_A139PaiCod = new string[] {""} ;
         T003L3_A140EstCod = new string[] {""} ;
         T003L3_A141ProvCod = new string[] {""} ;
         T003L3_A142DisCod = new string[] {""} ;
         T003L3_A298TprvCod = new int[1] ;
         T003L3_A297TPerCod = new int[1] ;
         T003L3_n297TPerCod = new bool[] {false} ;
         T003L3_A157TipSCod = new int[1] ;
         T003L3_n157TipSCod = new bool[] {false} ;
         T003L3_A300PrvConpCod = new int[1] ;
         T003L3_A296PrvBanCod1 = new int[1] ;
         T003L3_n296PrvBanCod1 = new bool[] {false} ;
         T003L3_A299PrvBanCod2 = new int[1] ;
         T003L3_n299PrvBanCod2 = new bool[] {false} ;
         T003L3_A1766PrvFoto = new string[] {""} ;
         T003L3_n1766PrvFoto = new bool[] {false} ;
         sMode124 = "";
         T003L20_A244PrvCod = new string[] {""} ;
         T003L21_A244PrvCod = new string[] {""} ;
         T003L2_A244PrvCod = new string[] {""} ;
         T003L2_A247PrvDsc = new string[] {""} ;
         T003L2_A1763PrvDir = new string[] {""} ;
         T003L2_A1779PrvTel1 = new string[] {""} ;
         T003L2_A1780PrvTel2 = new string[] {""} ;
         T003L2_A1765PrvFax = new string[] {""} ;
         T003L2_A1747PrvCel = new string[] {""} ;
         T003L2_A1764PrvEM = new string[] {""} ;
         T003L2_A1788PrvWeb = new string[] {""} ;
         T003L2_A40000PrvFoto_GXI = new string[] {""} ;
         T003L2_n40000PrvFoto_GXI = new bool[] {false} ;
         T003L2_A1777PrvSts = new short[1] ;
         T003L2_A1768PrvRef1 = new string[] {""} ;
         T003L2_A1769PrvRef2 = new string[] {""} ;
         T003L2_A1770PrvRef3 = new string[] {""} ;
         T003L2_A1771PrvRef4 = new string[] {""} ;
         T003L2_A1772PrvRef5 = new string[] {""} ;
         T003L2_A1773PrvRef6 = new string[] {""} ;
         T003L2_A1774PrvRef7 = new string[] {""} ;
         T003L2_A1775PrvRef8 = new string[] {""} ;
         T003L2_A1748PrvCon1 = new string[] {""} ;
         T003L2_A1758PrvCTel1 = new string[] {""} ;
         T003L2_A1749PrvCon2 = new string[] {""} ;
         T003L2_A1759PrvCTel2 = new string[] {""} ;
         T003L2_A1750PrvCon3 = new string[] {""} ;
         T003L2_A1760PrvCTel3 = new string[] {""} ;
         T003L2_A1751PrvCon4 = new string[] {""} ;
         T003L2_A1761PrvCTel4 = new string[] {""} ;
         T003L2_A1752PrvCon5 = new string[] {""} ;
         T003L2_A1762PrvCTel5 = new string[] {""} ;
         T003L2_A1767PrvNom = new string[] {""} ;
         T003L2_A1744PrvAPeP = new string[] {""} ;
         T003L2_A1743PrvAPeM = new string[] {""} ;
         T003L2_A1787PrvVincula = new short[1] ;
         T003L2_A1776PrvRetencion = new short[1] ;
         T003L2_A1781PrvTipCuenta1 = new string[] {""} ;
         T003L2_A1745PrvBanCuenta1 = new string[] {""} ;
         T003L2_A1782PrvTipCuenta2 = new string[] {""} ;
         T003L2_A1778PrvTCon = new int[1] ;
         T003L2_A1746PrvBanCuenta2 = new string[] {""} ;
         T003L2_A1783PrvUsuCod = new string[] {""} ;
         T003L2_A1785PrvUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003L2_A1784PrvUsuCodM = new string[] {""} ;
         T003L2_A1786PrvUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T003L2_A1791PrvWebUsu = new string[] {""} ;
         T003L2_A1790PrvWebPas = new string[] {""} ;
         T003L2_A1789PrvWebFec = new DateTime[] {DateTime.MinValue} ;
         T003L2_A139PaiCod = new string[] {""} ;
         T003L2_A140EstCod = new string[] {""} ;
         T003L2_A141ProvCod = new string[] {""} ;
         T003L2_A142DisCod = new string[] {""} ;
         T003L2_A298TprvCod = new int[1] ;
         T003L2_A297TPerCod = new int[1] ;
         T003L2_n297TPerCod = new bool[] {false} ;
         T003L2_A157TipSCod = new int[1] ;
         T003L2_n157TipSCod = new bool[] {false} ;
         T003L2_A300PrvConpCod = new int[1] ;
         T003L2_A296PrvBanCod1 = new int[1] ;
         T003L2_n296PrvBanCod1 = new bool[] {false} ;
         T003L2_A299PrvBanCod2 = new int[1] ;
         T003L2_n299PrvBanCod2 = new bool[] {false} ;
         T003L2_A1766PrvFoto = new string[] {""} ;
         T003L2_n1766PrvFoto = new bool[] {false} ;
         T003L26_A1756PrvConpDsc = new string[] {""} ;
         T003L27_A412PagReg = new long[1] ;
         T003L28_A365EntCod = new int[1] ;
         T003L28_A403MVLEntCod = new string[] {""} ;
         T003L28_A404MVLEITem = new int[1] ;
         T003L29_A358CajCod = new int[1] ;
         T003L29_A391MVLCajCod = new string[] {""} ;
         T003L29_A392MVLITem = new int[1] ;
         T003L30_A286CPLisHisProdCod = new string[] {""} ;
         T003L30_A287CPLisHisPrvCod = new string[] {""} ;
         T003L30_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003L31_A265LetPLetCod = new string[] {""} ;
         T003L32_A260CPTipCod = new string[] {""} ;
         T003L32_A261CPComCod = new string[] {""} ;
         T003L32_A262CPPrvCod = new string[] {""} ;
         T003L33_A354TSAntCod = new string[] {""} ;
         T003L34_A387TSMovCod = new string[] {""} ;
         T003L35_A302CPRetCod = new string[] {""} ;
         T003L36_A289OrdCod = new string[] {""} ;
         T003L37_A284CPLisProdCod = new string[] {""} ;
         T003L37_A285CPLisPrvItem = new short[1] ;
         T003L38_A149TipCod = new string[] {""} ;
         T003L38_A243ComCod = new string[] {""} ;
         T003L38_A244PrvCod = new string[] {""} ;
         T003L39_A244PrvCod = new string[] {""} ;
         T003L39_A301PrvConCod = new int[1] ;
         T003L40_A238CheqDCod = new string[] {""} ;
         T003L41_A244PrvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ244PrvCod = "";
         ZZ247PrvDsc = "";
         ZZ1763PrvDir = "";
         ZZ140EstCod = "";
         ZZ139PaiCod = "";
         ZZ1779PrvTel1 = "";
         ZZ1780PrvTel2 = "";
         ZZ1765PrvFax = "";
         ZZ1747PrvCel = "";
         ZZ1764PrvEM = "";
         ZZ1788PrvWeb = "";
         ZZ1766PrvFoto = "";
         ZZ40000PrvFoto_GXI = "";
         ZZ1768PrvRef1 = "";
         ZZ1769PrvRef2 = "";
         ZZ1770PrvRef3 = "";
         ZZ1771PrvRef4 = "";
         ZZ1772PrvRef5 = "";
         ZZ1773PrvRef6 = "";
         ZZ1774PrvRef7 = "";
         ZZ1775PrvRef8 = "";
         ZZ1748PrvCon1 = "";
         ZZ1758PrvCTel1 = "";
         ZZ1749PrvCon2 = "";
         ZZ1759PrvCTel2 = "";
         ZZ1750PrvCon3 = "";
         ZZ1760PrvCTel3 = "";
         ZZ1751PrvCon4 = "";
         ZZ1761PrvCTel4 = "";
         ZZ1752PrvCon5 = "";
         ZZ1762PrvCTel5 = "";
         ZZ1767PrvNom = "";
         ZZ1744PrvAPeP = "";
         ZZ1743PrvAPeM = "";
         ZZ142DisCod = "";
         ZZ141ProvCod = "";
         ZZ1781PrvTipCuenta1 = "";
         ZZ1745PrvBanCuenta1 = "";
         ZZ1782PrvTipCuenta2 = "";
         ZZ1746PrvBanCuenta2 = "";
         ZZ1783PrvUsuCod = "";
         ZZ1785PrvUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1784PrvUsuCodM = "";
         ZZ1786PrvUsuFecM = (DateTime)(DateTime.MinValue);
         ZZ1791PrvWebUsu = "";
         ZZ1790PrvWebPas = "";
         ZZ1789PrvWebFec = (DateTime)(DateTime.MinValue);
         ZZ1756PrvConpDsc = "";
         T003L42_A298TprvCod = new int[1] ;
         T003L43_A139PaiCod = new string[] {""} ;
         T003L44_A297TPerCod = new int[1] ;
         T003L44_n297TPerCod = new bool[] {false} ;
         T003L45_A157TipSCod = new int[1] ;
         T003L45_n157TipSCod = new bool[] {false} ;
         T003L46_A296PrvBanCod1 = new int[1] ;
         T003L46_n296PrvBanCod1 = new bool[] {false} ;
         T003L47_A299PrvBanCod2 = new int[1] ;
         T003L47_n299PrvBanCod2 = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpproveedores__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpproveedores__default(),
            new Object[][] {
                new Object[] {
               T003L2_A244PrvCod, T003L2_A247PrvDsc, T003L2_A1763PrvDir, T003L2_A1779PrvTel1, T003L2_A1780PrvTel2, T003L2_A1765PrvFax, T003L2_A1747PrvCel, T003L2_A1764PrvEM, T003L2_A1788PrvWeb, T003L2_A40000PrvFoto_GXI,
               T003L2_n40000PrvFoto_GXI, T003L2_A1777PrvSts, T003L2_A1768PrvRef1, T003L2_A1769PrvRef2, T003L2_A1770PrvRef3, T003L2_A1771PrvRef4, T003L2_A1772PrvRef5, T003L2_A1773PrvRef6, T003L2_A1774PrvRef7, T003L2_A1775PrvRef8,
               T003L2_A1748PrvCon1, T003L2_A1758PrvCTel1, T003L2_A1749PrvCon2, T003L2_A1759PrvCTel2, T003L2_A1750PrvCon3, T003L2_A1760PrvCTel3, T003L2_A1751PrvCon4, T003L2_A1761PrvCTel4, T003L2_A1752PrvCon5, T003L2_A1762PrvCTel5,
               T003L2_A1767PrvNom, T003L2_A1744PrvAPeP, T003L2_A1743PrvAPeM, T003L2_A1787PrvVincula, T003L2_A1776PrvRetencion, T003L2_A1781PrvTipCuenta1, T003L2_A1745PrvBanCuenta1, T003L2_A1782PrvTipCuenta2, T003L2_A1778PrvTCon, T003L2_A1746PrvBanCuenta2,
               T003L2_A1783PrvUsuCod, T003L2_A1785PrvUsuFec, T003L2_A1784PrvUsuCodM, T003L2_A1786PrvUsuFecM, T003L2_A1791PrvWebUsu, T003L2_A1790PrvWebPas, T003L2_A1789PrvWebFec, T003L2_A139PaiCod, T003L2_A140EstCod, T003L2_A141ProvCod,
               T003L2_A142DisCod, T003L2_A298TprvCod, T003L2_A297TPerCod, T003L2_n297TPerCod, T003L2_A157TipSCod, T003L2_n157TipSCod, T003L2_A300PrvConpCod, T003L2_A296PrvBanCod1, T003L2_n296PrvBanCod1, T003L2_A299PrvBanCod2,
               T003L2_n299PrvBanCod2, T003L2_A1766PrvFoto, T003L2_n1766PrvFoto
               }
               , new Object[] {
               T003L3_A244PrvCod, T003L3_A247PrvDsc, T003L3_A1763PrvDir, T003L3_A1779PrvTel1, T003L3_A1780PrvTel2, T003L3_A1765PrvFax, T003L3_A1747PrvCel, T003L3_A1764PrvEM, T003L3_A1788PrvWeb, T003L3_A40000PrvFoto_GXI,
               T003L3_n40000PrvFoto_GXI, T003L3_A1777PrvSts, T003L3_A1768PrvRef1, T003L3_A1769PrvRef2, T003L3_A1770PrvRef3, T003L3_A1771PrvRef4, T003L3_A1772PrvRef5, T003L3_A1773PrvRef6, T003L3_A1774PrvRef7, T003L3_A1775PrvRef8,
               T003L3_A1748PrvCon1, T003L3_A1758PrvCTel1, T003L3_A1749PrvCon2, T003L3_A1759PrvCTel2, T003L3_A1750PrvCon3, T003L3_A1760PrvCTel3, T003L3_A1751PrvCon4, T003L3_A1761PrvCTel4, T003L3_A1752PrvCon5, T003L3_A1762PrvCTel5,
               T003L3_A1767PrvNom, T003L3_A1744PrvAPeP, T003L3_A1743PrvAPeM, T003L3_A1787PrvVincula, T003L3_A1776PrvRetencion, T003L3_A1781PrvTipCuenta1, T003L3_A1745PrvBanCuenta1, T003L3_A1782PrvTipCuenta2, T003L3_A1778PrvTCon, T003L3_A1746PrvBanCuenta2,
               T003L3_A1783PrvUsuCod, T003L3_A1785PrvUsuFec, T003L3_A1784PrvUsuCodM, T003L3_A1786PrvUsuFecM, T003L3_A1791PrvWebUsu, T003L3_A1790PrvWebPas, T003L3_A1789PrvWebFec, T003L3_A139PaiCod, T003L3_A140EstCod, T003L3_A141ProvCod,
               T003L3_A142DisCod, T003L3_A298TprvCod, T003L3_A297TPerCod, T003L3_n297TPerCod, T003L3_A157TipSCod, T003L3_n157TipSCod, T003L3_A300PrvConpCod, T003L3_A296PrvBanCod1, T003L3_n296PrvBanCod1, T003L3_A299PrvBanCod2,
               T003L3_n299PrvBanCod2, T003L3_A1766PrvFoto, T003L3_n1766PrvFoto
               }
               , new Object[] {
               T003L4_A139PaiCod
               }
               , new Object[] {
               T003L5_A298TprvCod
               }
               , new Object[] {
               T003L6_A297TPerCod
               }
               , new Object[] {
               T003L7_A157TipSCod
               }
               , new Object[] {
               T003L8_A1756PrvConpDsc
               }
               , new Object[] {
               T003L9_A296PrvBanCod1
               }
               , new Object[] {
               T003L10_A299PrvBanCod2
               }
               , new Object[] {
               T003L11_A244PrvCod, T003L11_A247PrvDsc, T003L11_A1763PrvDir, T003L11_A1779PrvTel1, T003L11_A1780PrvTel2, T003L11_A1765PrvFax, T003L11_A1747PrvCel, T003L11_A1764PrvEM, T003L11_A1788PrvWeb, T003L11_A40000PrvFoto_GXI,
               T003L11_n40000PrvFoto_GXI, T003L11_A1777PrvSts, T003L11_A1768PrvRef1, T003L11_A1769PrvRef2, T003L11_A1770PrvRef3, T003L11_A1771PrvRef4, T003L11_A1772PrvRef5, T003L11_A1773PrvRef6, T003L11_A1774PrvRef7, T003L11_A1775PrvRef8,
               T003L11_A1748PrvCon1, T003L11_A1758PrvCTel1, T003L11_A1749PrvCon2, T003L11_A1759PrvCTel2, T003L11_A1750PrvCon3, T003L11_A1760PrvCTel3, T003L11_A1751PrvCon4, T003L11_A1761PrvCTel4, T003L11_A1752PrvCon5, T003L11_A1762PrvCTel5,
               T003L11_A1767PrvNom, T003L11_A1744PrvAPeP, T003L11_A1743PrvAPeM, T003L11_A1787PrvVincula, T003L11_A1776PrvRetencion, T003L11_A1781PrvTipCuenta1, T003L11_A1745PrvBanCuenta1, T003L11_A1782PrvTipCuenta2, T003L11_A1778PrvTCon, T003L11_A1746PrvBanCuenta2,
               T003L11_A1783PrvUsuCod, T003L11_A1785PrvUsuFec, T003L11_A1784PrvUsuCodM, T003L11_A1786PrvUsuFecM, T003L11_A1791PrvWebUsu, T003L11_A1790PrvWebPas, T003L11_A1789PrvWebFec, T003L11_A1756PrvConpDsc, T003L11_A139PaiCod, T003L11_A140EstCod,
               T003L11_A141ProvCod, T003L11_A142DisCod, T003L11_A298TprvCod, T003L11_A297TPerCod, T003L11_n297TPerCod, T003L11_A157TipSCod, T003L11_n157TipSCod, T003L11_A300PrvConpCod, T003L11_A296PrvBanCod1, T003L11_n296PrvBanCod1,
               T003L11_A299PrvBanCod2, T003L11_n299PrvBanCod2, T003L11_A1766PrvFoto, T003L11_n1766PrvFoto
               }
               , new Object[] {
               T003L12_A139PaiCod
               }
               , new Object[] {
               T003L13_A298TprvCod
               }
               , new Object[] {
               T003L14_A1756PrvConpDsc
               }
               , new Object[] {
               T003L15_A297TPerCod
               }
               , new Object[] {
               T003L16_A157TipSCod
               }
               , new Object[] {
               T003L17_A296PrvBanCod1
               }
               , new Object[] {
               T003L18_A299PrvBanCod2
               }
               , new Object[] {
               T003L19_A244PrvCod
               }
               , new Object[] {
               T003L20_A244PrvCod
               }
               , new Object[] {
               T003L21_A244PrvCod
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
               T003L26_A1756PrvConpDsc
               }
               , new Object[] {
               T003L27_A412PagReg
               }
               , new Object[] {
               T003L28_A365EntCod, T003L28_A403MVLEntCod, T003L28_A404MVLEITem
               }
               , new Object[] {
               T003L29_A358CajCod, T003L29_A391MVLCajCod, T003L29_A392MVLITem
               }
               , new Object[] {
               T003L30_A286CPLisHisProdCod, T003L30_A287CPLisHisPrvCod, T003L30_A288CPLisHisFecha
               }
               , new Object[] {
               T003L31_A265LetPLetCod
               }
               , new Object[] {
               T003L32_A260CPTipCod, T003L32_A261CPComCod, T003L32_A262CPPrvCod
               }
               , new Object[] {
               T003L33_A354TSAntCod
               }
               , new Object[] {
               T003L34_A387TSMovCod
               }
               , new Object[] {
               T003L35_A302CPRetCod
               }
               , new Object[] {
               T003L36_A289OrdCod
               }
               , new Object[] {
               T003L37_A284CPLisProdCod, T003L37_A285CPLisPrvItem
               }
               , new Object[] {
               T003L38_A149TipCod, T003L38_A243ComCod, T003L38_A244PrvCod
               }
               , new Object[] {
               T003L39_A244PrvCod, T003L39_A301PrvConCod
               }
               , new Object[] {
               T003L40_A238CheqDCod
               }
               , new Object[] {
               T003L41_A244PrvCod
               }
               , new Object[] {
               T003L42_A298TprvCod
               }
               , new Object[] {
               T003L43_A139PaiCod
               }
               , new Object[] {
               T003L44_A297TPerCod
               }
               , new Object[] {
               T003L45_A157TipSCod
               }
               , new Object[] {
               T003L46_A296PrvBanCod1
               }
               , new Object[] {
               T003L47_A299PrvBanCod2
               }
            }
         );
      }

      private short Z1777PrvSts ;
      private short Z1787PrvVincula ;
      private short Z1776PrvRetencion ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1777PrvSts ;
      private short A1787PrvVincula ;
      private short A1776PrvRetencion ;
      private short GX_JID ;
      private short RcdFound124 ;
      private short nIsDirty_124 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1777PrvSts ;
      private short ZZ1787PrvVincula ;
      private short ZZ1776PrvRetencion ;
      private int Z1778PrvTCon ;
      private int Z298TprvCod ;
      private int Z297TPerCod ;
      private int Z157TipSCod ;
      private int Z300PrvConpCod ;
      private int Z296PrvBanCod1 ;
      private int Z299PrvBanCod2 ;
      private int A298TprvCod ;
      private int A300PrvConpCod ;
      private int A297TPerCod ;
      private int A157TipSCod ;
      private int A296PrvBanCod1 ;
      private int A299PrvBanCod2 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPrvCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtPrvDir_Enabled ;
      private int edtEstCod_Enabled ;
      private int edtPaiCod_Enabled ;
      private int edtPrvTel1_Enabled ;
      private int edtPrvTel2_Enabled ;
      private int edtPrvFax_Enabled ;
      private int edtPrvCel_Enabled ;
      private int edtPrvEM_Enabled ;
      private int edtPrvWeb_Enabled ;
      private int edtTprvCod_Enabled ;
      private int imgPrvFoto_Enabled ;
      private int edtPrvSts_Enabled ;
      private int edtPrvConpCod_Enabled ;
      private int edtPrvRef1_Enabled ;
      private int edtPrvRef2_Enabled ;
      private int edtPrvRef3_Enabled ;
      private int edtPrvRef4_Enabled ;
      private int edtPrvRef5_Enabled ;
      private int edtPrvRef6_Enabled ;
      private int edtPrvRef7_Enabled ;
      private int edtPrvRef8_Enabled ;
      private int edtPrvCon1_Enabled ;
      private int edtPrvCTel1_Enabled ;
      private int edtPrvCon2_Enabled ;
      private int edtPrvCTel2_Enabled ;
      private int edtPrvCon3_Enabled ;
      private int edtPrvCTel3_Enabled ;
      private int edtPrvCon4_Enabled ;
      private int edtPrvCTel4_Enabled ;
      private int edtPrvCon5_Enabled ;
      private int edtPrvCTel5_Enabled ;
      private int edtPrvNom_Enabled ;
      private int edtPrvAPeP_Enabled ;
      private int edtPrvAPeM_Enabled ;
      private int edtDisCod_Enabled ;
      private int edtProvCod_Enabled ;
      private int edtTPerCod_Enabled ;
      private int edtTipSCod_Enabled ;
      private int edtPrvVincula_Enabled ;
      private int edtPrvRetencion_Enabled ;
      private int edtPrvTipCuenta1_Enabled ;
      private int edtPrvBanCod1_Enabled ;
      private int edtPrvBanCuenta1_Enabled ;
      private int edtPrvTipCuenta2_Enabled ;
      private int edtPrvBanCod2_Enabled ;
      private int edtPrvBanCuenta2_Enabled ;
      private int edtPrvUsuCod_Enabled ;
      private int edtPrvUsuFec_Enabled ;
      private int edtPrvUsuCodM_Enabled ;
      private int edtPrvUsuFecM_Enabled ;
      private int edtPrvWebUsu_Enabled ;
      private int edtPrvWebPas_Enabled ;
      private int edtPrvWebFec_Enabled ;
      private int edtPrvConpDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A1778PrvTCon ;
      private int idxLst ;
      private int ZZ298TprvCod ;
      private int ZZ300PrvConpCod ;
      private int ZZ297TPerCod ;
      private int ZZ157TipSCod ;
      private int ZZ296PrvBanCod1 ;
      private int ZZ299PrvBanCod2 ;
      private int ZZ1778PrvTCon ;
      private string sPrefix ;
      private string Z244PrvCod ;
      private string Z247PrvDsc ;
      private string Z1763PrvDir ;
      private string Z1779PrvTel1 ;
      private string Z1780PrvTel2 ;
      private string Z1765PrvFax ;
      private string Z1747PrvCel ;
      private string Z1764PrvEM ;
      private string Z1788PrvWeb ;
      private string Z1768PrvRef1 ;
      private string Z1769PrvRef2 ;
      private string Z1770PrvRef3 ;
      private string Z1771PrvRef4 ;
      private string Z1772PrvRef5 ;
      private string Z1773PrvRef6 ;
      private string Z1774PrvRef7 ;
      private string Z1775PrvRef8 ;
      private string Z1748PrvCon1 ;
      private string Z1758PrvCTel1 ;
      private string Z1749PrvCon2 ;
      private string Z1759PrvCTel2 ;
      private string Z1750PrvCon3 ;
      private string Z1760PrvCTel3 ;
      private string Z1751PrvCon4 ;
      private string Z1761PrvCTel4 ;
      private string Z1752PrvCon5 ;
      private string Z1762PrvCTel5 ;
      private string Z1767PrvNom ;
      private string Z1744PrvAPeP ;
      private string Z1743PrvAPeM ;
      private string Z1783PrvUsuCod ;
      private string Z1784PrvUsuCodM ;
      private string Z1791PrvWebUsu ;
      private string Z1790PrvWebPas ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z142DisCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPrvCod_Internalname ;
      private string sStyleString ;
      private string tblTable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string tblTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string A244PrvCod ;
      private string edtPrvCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPrvDir_Internalname ;
      private string A1763PrvDir ;
      private string edtPrvDir_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtEstCod_Internalname ;
      private string edtEstCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPaiCod_Internalname ;
      private string edtPaiCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPrvTel1_Internalname ;
      private string A1779PrvTel1 ;
      private string edtPrvTel1_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPrvTel2_Internalname ;
      private string A1780PrvTel2 ;
      private string edtPrvTel2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPrvFax_Internalname ;
      private string A1765PrvFax ;
      private string edtPrvFax_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPrvCel_Internalname ;
      private string A1747PrvCel ;
      private string edtPrvCel_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPrvEM_Internalname ;
      private string A1764PrvEM ;
      private string edtPrvEM_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPrvWeb_Internalname ;
      private string A1788PrvWeb ;
      private string edtPrvWeb_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtTprvCod_Internalname ;
      private string edtTprvCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string sImgUrl ;
      private string imgPrvFoto_Internalname ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtPrvSts_Internalname ;
      private string edtPrvSts_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtPrvConpCod_Internalname ;
      private string edtPrvConpCod_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtPrvRef1_Internalname ;
      private string A1768PrvRef1 ;
      private string edtPrvRef1_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtPrvRef2_Internalname ;
      private string A1769PrvRef2 ;
      private string edtPrvRef2_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtPrvRef3_Internalname ;
      private string A1770PrvRef3 ;
      private string edtPrvRef3_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtPrvRef4_Internalname ;
      private string A1771PrvRef4 ;
      private string edtPrvRef4_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtPrvRef5_Internalname ;
      private string A1772PrvRef5 ;
      private string edtPrvRef5_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtPrvRef6_Internalname ;
      private string A1773PrvRef6 ;
      private string edtPrvRef6_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtPrvRef7_Internalname ;
      private string A1774PrvRef7 ;
      private string edtPrvRef7_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtPrvRef8_Internalname ;
      private string A1775PrvRef8 ;
      private string edtPrvRef8_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtPrvCon1_Internalname ;
      private string A1748PrvCon1 ;
      private string edtPrvCon1_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtPrvCTel1_Internalname ;
      private string A1758PrvCTel1 ;
      private string edtPrvCTel1_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtPrvCon2_Internalname ;
      private string A1749PrvCon2 ;
      private string edtPrvCon2_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtPrvCTel2_Internalname ;
      private string A1759PrvCTel2 ;
      private string edtPrvCTel2_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtPrvCon3_Internalname ;
      private string A1750PrvCon3 ;
      private string edtPrvCon3_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtPrvCTel3_Internalname ;
      private string A1760PrvCTel3 ;
      private string edtPrvCTel3_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtPrvCon4_Internalname ;
      private string A1751PrvCon4 ;
      private string edtPrvCon4_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtPrvCTel4_Internalname ;
      private string A1761PrvCTel4 ;
      private string edtPrvCTel4_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtPrvCon5_Internalname ;
      private string A1752PrvCon5 ;
      private string edtPrvCon5_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtPrvCTel5_Internalname ;
      private string A1762PrvCTel5 ;
      private string edtPrvCTel5_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtPrvNom_Internalname ;
      private string A1767PrvNom ;
      private string edtPrvNom_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtPrvAPeP_Internalname ;
      private string A1744PrvAPeP ;
      private string edtPrvAPeP_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtPrvAPeM_Internalname ;
      private string A1743PrvAPeM ;
      private string edtPrvAPeM_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtDisCod_Internalname ;
      private string edtDisCod_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtProvCod_Internalname ;
      private string edtProvCod_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtTPerCod_Internalname ;
      private string edtTPerCod_Jsonclick ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string edtTipSCod_Internalname ;
      private string edtTipSCod_Jsonclick ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string edtPrvVincula_Internalname ;
      private string edtPrvVincula_Jsonclick ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string edtPrvRetencion_Internalname ;
      private string edtPrvRetencion_Jsonclick ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string edtPrvTipCuenta1_Internalname ;
      private string edtPrvTipCuenta1_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string edtPrvBanCod1_Internalname ;
      private string edtPrvBanCod1_Jsonclick ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string edtPrvBanCuenta1_Internalname ;
      private string edtPrvBanCuenta1_Jsonclick ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string edtPrvTipCuenta2_Internalname ;
      private string edtPrvTipCuenta2_Jsonclick ;
      private string lblTextblock47_Internalname ;
      private string lblTextblock47_Jsonclick ;
      private string edtPrvBanCod2_Internalname ;
      private string edtPrvBanCod2_Jsonclick ;
      private string lblTextblock48_Internalname ;
      private string lblTextblock48_Jsonclick ;
      private string edtPrvBanCuenta2_Internalname ;
      private string edtPrvBanCuenta2_Jsonclick ;
      private string lblTextblock49_Internalname ;
      private string lblTextblock49_Jsonclick ;
      private string edtPrvUsuCod_Internalname ;
      private string A1783PrvUsuCod ;
      private string edtPrvUsuCod_Jsonclick ;
      private string lblTextblock50_Internalname ;
      private string lblTextblock50_Jsonclick ;
      private string edtPrvUsuFec_Internalname ;
      private string edtPrvUsuFec_Jsonclick ;
      private string lblTextblock51_Internalname ;
      private string lblTextblock51_Jsonclick ;
      private string edtPrvUsuCodM_Internalname ;
      private string A1784PrvUsuCodM ;
      private string edtPrvUsuCodM_Jsonclick ;
      private string lblTextblock52_Internalname ;
      private string lblTextblock52_Jsonclick ;
      private string edtPrvUsuFecM_Internalname ;
      private string edtPrvUsuFecM_Jsonclick ;
      private string lblTextblock53_Internalname ;
      private string lblTextblock53_Jsonclick ;
      private string edtPrvWebUsu_Internalname ;
      private string A1791PrvWebUsu ;
      private string edtPrvWebUsu_Jsonclick ;
      private string lblTextblock54_Internalname ;
      private string lblTextblock54_Jsonclick ;
      private string edtPrvWebPas_Internalname ;
      private string A1790PrvWebPas ;
      private string edtPrvWebPas_Jsonclick ;
      private string lblTextblock55_Internalname ;
      private string lblTextblock55_Jsonclick ;
      private string edtPrvWebFec_Internalname ;
      private string edtPrvWebFec_Jsonclick ;
      private string lblTextblock56_Internalname ;
      private string lblTextblock56_Jsonclick ;
      private string edtPrvConpDsc_Internalname ;
      private string A1756PrvConpDsc ;
      private string edtPrvConpDsc_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_check_Internalname ;
      private string bttBtn_check_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string bttBtn_help_Internalname ;
      private string bttBtn_help_Jsonclick ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1756PrvConpDsc ;
      private string sMode124 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ244PrvCod ;
      private string ZZ247PrvDsc ;
      private string ZZ1763PrvDir ;
      private string ZZ140EstCod ;
      private string ZZ139PaiCod ;
      private string ZZ1779PrvTel1 ;
      private string ZZ1780PrvTel2 ;
      private string ZZ1765PrvFax ;
      private string ZZ1747PrvCel ;
      private string ZZ1764PrvEM ;
      private string ZZ1788PrvWeb ;
      private string ZZ1768PrvRef1 ;
      private string ZZ1769PrvRef2 ;
      private string ZZ1770PrvRef3 ;
      private string ZZ1771PrvRef4 ;
      private string ZZ1772PrvRef5 ;
      private string ZZ1773PrvRef6 ;
      private string ZZ1774PrvRef7 ;
      private string ZZ1775PrvRef8 ;
      private string ZZ1748PrvCon1 ;
      private string ZZ1758PrvCTel1 ;
      private string ZZ1749PrvCon2 ;
      private string ZZ1759PrvCTel2 ;
      private string ZZ1750PrvCon3 ;
      private string ZZ1760PrvCTel3 ;
      private string ZZ1751PrvCon4 ;
      private string ZZ1761PrvCTel4 ;
      private string ZZ1752PrvCon5 ;
      private string ZZ1762PrvCTel5 ;
      private string ZZ1767PrvNom ;
      private string ZZ1744PrvAPeP ;
      private string ZZ1743PrvAPeM ;
      private string ZZ142DisCod ;
      private string ZZ141ProvCod ;
      private string ZZ1783PrvUsuCod ;
      private string ZZ1784PrvUsuCodM ;
      private string ZZ1791PrvWebUsu ;
      private string ZZ1790PrvWebPas ;
      private string ZZ1756PrvConpDsc ;
      private DateTime Z1785PrvUsuFec ;
      private DateTime Z1786PrvUsuFecM ;
      private DateTime Z1789PrvWebFec ;
      private DateTime A1785PrvUsuFec ;
      private DateTime A1786PrvUsuFecM ;
      private DateTime A1789PrvWebFec ;
      private DateTime ZZ1785PrvUsuFec ;
      private DateTime ZZ1786PrvUsuFecM ;
      private DateTime ZZ1789PrvWebFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n297TPerCod ;
      private bool n157TipSCod ;
      private bool n296PrvBanCod1 ;
      private bool n299PrvBanCod2 ;
      private bool wbErr ;
      private bool A1766PrvFoto_IsBlob ;
      private bool n40000PrvFoto_GXI ;
      private bool n1766PrvFoto ;
      private bool Gx_longc ;
      private string Z1781PrvTipCuenta1 ;
      private string Z1745PrvBanCuenta1 ;
      private string Z1782PrvTipCuenta2 ;
      private string Z1746PrvBanCuenta2 ;
      private string A40000PrvFoto_GXI ;
      private string A1781PrvTipCuenta1 ;
      private string A1745PrvBanCuenta1 ;
      private string A1782PrvTipCuenta2 ;
      private string A1746PrvBanCuenta2 ;
      private string Z40000PrvFoto_GXI ;
      private string ZZ40000PrvFoto_GXI ;
      private string ZZ1781PrvTipCuenta1 ;
      private string ZZ1745PrvBanCuenta1 ;
      private string ZZ1782PrvTipCuenta2 ;
      private string ZZ1746PrvBanCuenta2 ;
      private string A1766PrvFoto ;
      private string Z1766PrvFoto ;
      private string ZZ1766PrvFoto ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003L11_A244PrvCod ;
      private string[] T003L11_A247PrvDsc ;
      private string[] T003L11_A1763PrvDir ;
      private string[] T003L11_A1779PrvTel1 ;
      private string[] T003L11_A1780PrvTel2 ;
      private string[] T003L11_A1765PrvFax ;
      private string[] T003L11_A1747PrvCel ;
      private string[] T003L11_A1764PrvEM ;
      private string[] T003L11_A1788PrvWeb ;
      private string[] T003L11_A40000PrvFoto_GXI ;
      private bool[] T003L11_n40000PrvFoto_GXI ;
      private short[] T003L11_A1777PrvSts ;
      private string[] T003L11_A1768PrvRef1 ;
      private string[] T003L11_A1769PrvRef2 ;
      private string[] T003L11_A1770PrvRef3 ;
      private string[] T003L11_A1771PrvRef4 ;
      private string[] T003L11_A1772PrvRef5 ;
      private string[] T003L11_A1773PrvRef6 ;
      private string[] T003L11_A1774PrvRef7 ;
      private string[] T003L11_A1775PrvRef8 ;
      private string[] T003L11_A1748PrvCon1 ;
      private string[] T003L11_A1758PrvCTel1 ;
      private string[] T003L11_A1749PrvCon2 ;
      private string[] T003L11_A1759PrvCTel2 ;
      private string[] T003L11_A1750PrvCon3 ;
      private string[] T003L11_A1760PrvCTel3 ;
      private string[] T003L11_A1751PrvCon4 ;
      private string[] T003L11_A1761PrvCTel4 ;
      private string[] T003L11_A1752PrvCon5 ;
      private string[] T003L11_A1762PrvCTel5 ;
      private string[] T003L11_A1767PrvNom ;
      private string[] T003L11_A1744PrvAPeP ;
      private string[] T003L11_A1743PrvAPeM ;
      private short[] T003L11_A1787PrvVincula ;
      private short[] T003L11_A1776PrvRetencion ;
      private string[] T003L11_A1781PrvTipCuenta1 ;
      private string[] T003L11_A1745PrvBanCuenta1 ;
      private string[] T003L11_A1782PrvTipCuenta2 ;
      private int[] T003L11_A1778PrvTCon ;
      private string[] T003L11_A1746PrvBanCuenta2 ;
      private string[] T003L11_A1783PrvUsuCod ;
      private DateTime[] T003L11_A1785PrvUsuFec ;
      private string[] T003L11_A1784PrvUsuCodM ;
      private DateTime[] T003L11_A1786PrvUsuFecM ;
      private string[] T003L11_A1791PrvWebUsu ;
      private string[] T003L11_A1790PrvWebPas ;
      private DateTime[] T003L11_A1789PrvWebFec ;
      private string[] T003L11_A1756PrvConpDsc ;
      private string[] T003L11_A139PaiCod ;
      private string[] T003L11_A140EstCod ;
      private string[] T003L11_A141ProvCod ;
      private string[] T003L11_A142DisCod ;
      private int[] T003L11_A298TprvCod ;
      private int[] T003L11_A297TPerCod ;
      private bool[] T003L11_n297TPerCod ;
      private int[] T003L11_A157TipSCod ;
      private bool[] T003L11_n157TipSCod ;
      private int[] T003L11_A300PrvConpCod ;
      private int[] T003L11_A296PrvBanCod1 ;
      private bool[] T003L11_n296PrvBanCod1 ;
      private int[] T003L11_A299PrvBanCod2 ;
      private bool[] T003L11_n299PrvBanCod2 ;
      private string[] T003L11_A1766PrvFoto ;
      private bool[] T003L11_n1766PrvFoto ;
      private string[] T003L4_A139PaiCod ;
      private int[] T003L5_A298TprvCod ;
      private string[] T003L8_A1756PrvConpDsc ;
      private int[] T003L6_A297TPerCod ;
      private bool[] T003L6_n297TPerCod ;
      private int[] T003L7_A157TipSCod ;
      private bool[] T003L7_n157TipSCod ;
      private int[] T003L9_A296PrvBanCod1 ;
      private bool[] T003L9_n296PrvBanCod1 ;
      private int[] T003L10_A299PrvBanCod2 ;
      private bool[] T003L10_n299PrvBanCod2 ;
      private string[] T003L12_A139PaiCod ;
      private int[] T003L13_A298TprvCod ;
      private string[] T003L14_A1756PrvConpDsc ;
      private int[] T003L15_A297TPerCod ;
      private bool[] T003L15_n297TPerCod ;
      private int[] T003L16_A157TipSCod ;
      private bool[] T003L16_n157TipSCod ;
      private int[] T003L17_A296PrvBanCod1 ;
      private bool[] T003L17_n296PrvBanCod1 ;
      private int[] T003L18_A299PrvBanCod2 ;
      private bool[] T003L18_n299PrvBanCod2 ;
      private string[] T003L19_A244PrvCod ;
      private string[] T003L3_A244PrvCod ;
      private string[] T003L3_A247PrvDsc ;
      private string[] T003L3_A1763PrvDir ;
      private string[] T003L3_A1779PrvTel1 ;
      private string[] T003L3_A1780PrvTel2 ;
      private string[] T003L3_A1765PrvFax ;
      private string[] T003L3_A1747PrvCel ;
      private string[] T003L3_A1764PrvEM ;
      private string[] T003L3_A1788PrvWeb ;
      private string[] T003L3_A40000PrvFoto_GXI ;
      private bool[] T003L3_n40000PrvFoto_GXI ;
      private short[] T003L3_A1777PrvSts ;
      private string[] T003L3_A1768PrvRef1 ;
      private string[] T003L3_A1769PrvRef2 ;
      private string[] T003L3_A1770PrvRef3 ;
      private string[] T003L3_A1771PrvRef4 ;
      private string[] T003L3_A1772PrvRef5 ;
      private string[] T003L3_A1773PrvRef6 ;
      private string[] T003L3_A1774PrvRef7 ;
      private string[] T003L3_A1775PrvRef8 ;
      private string[] T003L3_A1748PrvCon1 ;
      private string[] T003L3_A1758PrvCTel1 ;
      private string[] T003L3_A1749PrvCon2 ;
      private string[] T003L3_A1759PrvCTel2 ;
      private string[] T003L3_A1750PrvCon3 ;
      private string[] T003L3_A1760PrvCTel3 ;
      private string[] T003L3_A1751PrvCon4 ;
      private string[] T003L3_A1761PrvCTel4 ;
      private string[] T003L3_A1752PrvCon5 ;
      private string[] T003L3_A1762PrvCTel5 ;
      private string[] T003L3_A1767PrvNom ;
      private string[] T003L3_A1744PrvAPeP ;
      private string[] T003L3_A1743PrvAPeM ;
      private short[] T003L3_A1787PrvVincula ;
      private short[] T003L3_A1776PrvRetencion ;
      private string[] T003L3_A1781PrvTipCuenta1 ;
      private string[] T003L3_A1745PrvBanCuenta1 ;
      private string[] T003L3_A1782PrvTipCuenta2 ;
      private int[] T003L3_A1778PrvTCon ;
      private string[] T003L3_A1746PrvBanCuenta2 ;
      private string[] T003L3_A1783PrvUsuCod ;
      private DateTime[] T003L3_A1785PrvUsuFec ;
      private string[] T003L3_A1784PrvUsuCodM ;
      private DateTime[] T003L3_A1786PrvUsuFecM ;
      private string[] T003L3_A1791PrvWebUsu ;
      private string[] T003L3_A1790PrvWebPas ;
      private DateTime[] T003L3_A1789PrvWebFec ;
      private string[] T003L3_A139PaiCod ;
      private string[] T003L3_A140EstCod ;
      private string[] T003L3_A141ProvCod ;
      private string[] T003L3_A142DisCod ;
      private int[] T003L3_A298TprvCod ;
      private int[] T003L3_A297TPerCod ;
      private bool[] T003L3_n297TPerCod ;
      private int[] T003L3_A157TipSCod ;
      private bool[] T003L3_n157TipSCod ;
      private int[] T003L3_A300PrvConpCod ;
      private int[] T003L3_A296PrvBanCod1 ;
      private bool[] T003L3_n296PrvBanCod1 ;
      private int[] T003L3_A299PrvBanCod2 ;
      private bool[] T003L3_n299PrvBanCod2 ;
      private string[] T003L3_A1766PrvFoto ;
      private bool[] T003L3_n1766PrvFoto ;
      private string[] T003L20_A244PrvCod ;
      private string[] T003L21_A244PrvCod ;
      private string[] T003L2_A244PrvCod ;
      private string[] T003L2_A247PrvDsc ;
      private string[] T003L2_A1763PrvDir ;
      private string[] T003L2_A1779PrvTel1 ;
      private string[] T003L2_A1780PrvTel2 ;
      private string[] T003L2_A1765PrvFax ;
      private string[] T003L2_A1747PrvCel ;
      private string[] T003L2_A1764PrvEM ;
      private string[] T003L2_A1788PrvWeb ;
      private string[] T003L2_A40000PrvFoto_GXI ;
      private bool[] T003L2_n40000PrvFoto_GXI ;
      private short[] T003L2_A1777PrvSts ;
      private string[] T003L2_A1768PrvRef1 ;
      private string[] T003L2_A1769PrvRef2 ;
      private string[] T003L2_A1770PrvRef3 ;
      private string[] T003L2_A1771PrvRef4 ;
      private string[] T003L2_A1772PrvRef5 ;
      private string[] T003L2_A1773PrvRef6 ;
      private string[] T003L2_A1774PrvRef7 ;
      private string[] T003L2_A1775PrvRef8 ;
      private string[] T003L2_A1748PrvCon1 ;
      private string[] T003L2_A1758PrvCTel1 ;
      private string[] T003L2_A1749PrvCon2 ;
      private string[] T003L2_A1759PrvCTel2 ;
      private string[] T003L2_A1750PrvCon3 ;
      private string[] T003L2_A1760PrvCTel3 ;
      private string[] T003L2_A1751PrvCon4 ;
      private string[] T003L2_A1761PrvCTel4 ;
      private string[] T003L2_A1752PrvCon5 ;
      private string[] T003L2_A1762PrvCTel5 ;
      private string[] T003L2_A1767PrvNom ;
      private string[] T003L2_A1744PrvAPeP ;
      private string[] T003L2_A1743PrvAPeM ;
      private short[] T003L2_A1787PrvVincula ;
      private short[] T003L2_A1776PrvRetencion ;
      private string[] T003L2_A1781PrvTipCuenta1 ;
      private string[] T003L2_A1745PrvBanCuenta1 ;
      private string[] T003L2_A1782PrvTipCuenta2 ;
      private int[] T003L2_A1778PrvTCon ;
      private string[] T003L2_A1746PrvBanCuenta2 ;
      private string[] T003L2_A1783PrvUsuCod ;
      private DateTime[] T003L2_A1785PrvUsuFec ;
      private string[] T003L2_A1784PrvUsuCodM ;
      private DateTime[] T003L2_A1786PrvUsuFecM ;
      private string[] T003L2_A1791PrvWebUsu ;
      private string[] T003L2_A1790PrvWebPas ;
      private DateTime[] T003L2_A1789PrvWebFec ;
      private string[] T003L2_A139PaiCod ;
      private string[] T003L2_A140EstCod ;
      private string[] T003L2_A141ProvCod ;
      private string[] T003L2_A142DisCod ;
      private int[] T003L2_A298TprvCod ;
      private int[] T003L2_A297TPerCod ;
      private bool[] T003L2_n297TPerCod ;
      private int[] T003L2_A157TipSCod ;
      private bool[] T003L2_n157TipSCod ;
      private int[] T003L2_A300PrvConpCod ;
      private int[] T003L2_A296PrvBanCod1 ;
      private bool[] T003L2_n296PrvBanCod1 ;
      private int[] T003L2_A299PrvBanCod2 ;
      private bool[] T003L2_n299PrvBanCod2 ;
      private string[] T003L2_A1766PrvFoto ;
      private bool[] T003L2_n1766PrvFoto ;
      private string[] T003L26_A1756PrvConpDsc ;
      private long[] T003L27_A412PagReg ;
      private int[] T003L28_A365EntCod ;
      private string[] T003L28_A403MVLEntCod ;
      private int[] T003L28_A404MVLEITem ;
      private int[] T003L29_A358CajCod ;
      private string[] T003L29_A391MVLCajCod ;
      private int[] T003L29_A392MVLITem ;
      private string[] T003L30_A286CPLisHisProdCod ;
      private string[] T003L30_A287CPLisHisPrvCod ;
      private DateTime[] T003L30_A288CPLisHisFecha ;
      private string[] T003L31_A265LetPLetCod ;
      private string[] T003L32_A260CPTipCod ;
      private string[] T003L32_A261CPComCod ;
      private string[] T003L32_A262CPPrvCod ;
      private string[] T003L33_A354TSAntCod ;
      private string[] T003L34_A387TSMovCod ;
      private string[] T003L35_A302CPRetCod ;
      private string[] T003L36_A289OrdCod ;
      private string[] T003L37_A284CPLisProdCod ;
      private short[] T003L37_A285CPLisPrvItem ;
      private string[] T003L38_A149TipCod ;
      private string[] T003L38_A243ComCod ;
      private string[] T003L38_A244PrvCod ;
      private string[] T003L39_A244PrvCod ;
      private int[] T003L39_A301PrvConCod ;
      private string[] T003L40_A238CheqDCod ;
      private string[] T003L41_A244PrvCod ;
      private int[] T003L42_A298TprvCod ;
      private string[] T003L43_A139PaiCod ;
      private int[] T003L44_A297TPerCod ;
      private bool[] T003L44_n297TPerCod ;
      private int[] T003L45_A157TipSCod ;
      private bool[] T003L45_n157TipSCod ;
      private int[] T003L46_A296PrvBanCod1 ;
      private bool[] T003L46_n296PrvBanCod1 ;
      private int[] T003L47_A299PrvBanCod2 ;
      private bool[] T003L47_n299PrvBanCod2 ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpproveedores__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpproveedores__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003L11;
        prmT003L11 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L4;
        prmT003L4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT003L5;
        prmT003L5 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003L8;
        prmT003L8 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003L6;
        prmT003L6 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L7;
        prmT003L7 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L9;
        prmT003L9 = new Object[] {
        new ParDef("@PrvBanCod1",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L10;
        prmT003L10 = new Object[] {
        new ParDef("@PrvBanCod2",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L12;
        prmT003L12 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT003L13;
        prmT003L13 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003L14;
        prmT003L14 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003L15;
        prmT003L15 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L16;
        prmT003L16 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L17;
        prmT003L17 = new Object[] {
        new ParDef("@PrvBanCod1",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L18;
        prmT003L18 = new Object[] {
        new ParDef("@PrvBanCod2",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L19;
        prmT003L19 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L3;
        prmT003L3 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L20;
        prmT003L20 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L21;
        prmT003L21 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L2;
        prmT003L2 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L22;
        prmT003L22 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@PrvDsc",GXType.NChar,100,0) ,
        new ParDef("@PrvDir",GXType.NChar,100,0) ,
        new ParDef("@PrvTel1",GXType.NChar,20,0) ,
        new ParDef("@PrvTel2",GXType.NChar,20,0) ,
        new ParDef("@PrvFax",GXType.NChar,20,0) ,
        new ParDef("@PrvCel",GXType.NChar,20,0) ,
        new ParDef("@PrvEM",GXType.NChar,50,0) ,
        new ParDef("@PrvWeb",GXType.NChar,50,0) ,
        new ParDef("@PrvFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@PrvFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=9, Tbl="CPPROVEEDORES", Fld="PrvFoto"} ,
        new ParDef("@PrvSts",GXType.Int16,1,0) ,
        new ParDef("@PrvRef1",GXType.NChar,50,0) ,
        new ParDef("@PrvRef2",GXType.NChar,50,0) ,
        new ParDef("@PrvRef3",GXType.NChar,50,0) ,
        new ParDef("@PrvRef4",GXType.NChar,50,0) ,
        new ParDef("@PrvRef5",GXType.NChar,50,0) ,
        new ParDef("@PrvRef6",GXType.NChar,50,0) ,
        new ParDef("@PrvRef7",GXType.NChar,50,0) ,
        new ParDef("@PrvRef8",GXType.NChar,50,0) ,
        new ParDef("@PrvCon1",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel1",GXType.NChar,20,0) ,
        new ParDef("@PrvCon2",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel2",GXType.NChar,20,0) ,
        new ParDef("@PrvCon3",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel3",GXType.NChar,20,0) ,
        new ParDef("@PrvCon4",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel4",GXType.NChar,20,0) ,
        new ParDef("@PrvCon5",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel5",GXType.NChar,20,0) ,
        new ParDef("@PrvNom",GXType.NChar,100,0) ,
        new ParDef("@PrvAPeP",GXType.NChar,100,0) ,
        new ParDef("@PrvAPeM",GXType.NChar,100,0) ,
        new ParDef("@PrvVincula",GXType.Int16,1,0) ,
        new ParDef("@PrvRetencion",GXType.Int16,1,0) ,
        new ParDef("@PrvTipCuenta1",GXType.NVarChar,1,0) ,
        new ParDef("@PrvBanCuenta1",GXType.NVarChar,20,0) ,
        new ParDef("@PrvTipCuenta2",GXType.NVarChar,1,0) ,
        new ParDef("@PrvTCon",GXType.Int32,6,0) ,
        new ParDef("@PrvBanCuenta2",GXType.NVarChar,20,0) ,
        new ParDef("@PrvUsuCod",GXType.NChar,10,0) ,
        new ParDef("@PrvUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@PrvUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@PrvUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@PrvWebUsu",GXType.NChar,100,0) ,
        new ParDef("@PrvWebPas",GXType.NChar,10,0) ,
        new ParDef("@PrvWebFec",GXType.DateTime,8,5) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@TprvCod",GXType.Int32,6,0) ,
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TipSCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PrvConpCod",GXType.Int32,6,0) ,
        new ParDef("@PrvBanCod1",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PrvBanCod2",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L23;
        prmT003L23 = new Object[] {
        new ParDef("@PrvDsc",GXType.NChar,100,0) ,
        new ParDef("@PrvDir",GXType.NChar,100,0) ,
        new ParDef("@PrvTel1",GXType.NChar,20,0) ,
        new ParDef("@PrvTel2",GXType.NChar,20,0) ,
        new ParDef("@PrvFax",GXType.NChar,20,0) ,
        new ParDef("@PrvCel",GXType.NChar,20,0) ,
        new ParDef("@PrvEM",GXType.NChar,50,0) ,
        new ParDef("@PrvWeb",GXType.NChar,50,0) ,
        new ParDef("@PrvSts",GXType.Int16,1,0) ,
        new ParDef("@PrvRef1",GXType.NChar,50,0) ,
        new ParDef("@PrvRef2",GXType.NChar,50,0) ,
        new ParDef("@PrvRef3",GXType.NChar,50,0) ,
        new ParDef("@PrvRef4",GXType.NChar,50,0) ,
        new ParDef("@PrvRef5",GXType.NChar,50,0) ,
        new ParDef("@PrvRef6",GXType.NChar,50,0) ,
        new ParDef("@PrvRef7",GXType.NChar,50,0) ,
        new ParDef("@PrvRef8",GXType.NChar,50,0) ,
        new ParDef("@PrvCon1",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel1",GXType.NChar,20,0) ,
        new ParDef("@PrvCon2",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel2",GXType.NChar,20,0) ,
        new ParDef("@PrvCon3",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel3",GXType.NChar,20,0) ,
        new ParDef("@PrvCon4",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel4",GXType.NChar,20,0) ,
        new ParDef("@PrvCon5",GXType.NChar,50,0) ,
        new ParDef("@PrvCTel5",GXType.NChar,20,0) ,
        new ParDef("@PrvNom",GXType.NChar,100,0) ,
        new ParDef("@PrvAPeP",GXType.NChar,100,0) ,
        new ParDef("@PrvAPeM",GXType.NChar,100,0) ,
        new ParDef("@PrvVincula",GXType.Int16,1,0) ,
        new ParDef("@PrvRetencion",GXType.Int16,1,0) ,
        new ParDef("@PrvTipCuenta1",GXType.NVarChar,1,0) ,
        new ParDef("@PrvBanCuenta1",GXType.NVarChar,20,0) ,
        new ParDef("@PrvTipCuenta2",GXType.NVarChar,1,0) ,
        new ParDef("@PrvTCon",GXType.Int32,6,0) ,
        new ParDef("@PrvBanCuenta2",GXType.NVarChar,20,0) ,
        new ParDef("@PrvUsuCod",GXType.NChar,10,0) ,
        new ParDef("@PrvUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@PrvUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@PrvUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@PrvWebUsu",GXType.NChar,100,0) ,
        new ParDef("@PrvWebPas",GXType.NChar,10,0) ,
        new ParDef("@PrvWebFec",GXType.DateTime,8,5) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@TprvCod",GXType.Int32,6,0) ,
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TipSCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PrvConpCod",GXType.Int32,6,0) ,
        new ParDef("@PrvBanCod1",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PrvBanCod2",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L24;
        prmT003L24 = new Object[] {
        new ParDef("@PrvFoto",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@PrvFoto_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="CPPROVEEDORES", Fld="PrvFoto"} ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L25;
        prmT003L25 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L27;
        prmT003L27 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L28;
        prmT003L28 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L29;
        prmT003L29 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L30;
        prmT003L30 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L31;
        prmT003L31 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L32;
        prmT003L32 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L33;
        prmT003L33 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L34;
        prmT003L34 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L35;
        prmT003L35 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L36;
        prmT003L36 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L37;
        prmT003L37 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L38;
        prmT003L38 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L39;
        prmT003L39 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L40;
        prmT003L40 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003L41;
        prmT003L41 = new Object[] {
        };
        Object[] prmT003L42;
        prmT003L42 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003L26;
        prmT003L26 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003L43;
        prmT003L43 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT003L44;
        prmT003L44 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L45;
        prmT003L45 = new Object[] {
        new ParDef("@TipSCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L46;
        prmT003L46 = new Object[] {
        new ParDef("@PrvBanCod1",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003L47;
        prmT003L47 = new Object[] {
        new ParDef("@PrvBanCod2",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T003L2", "SELECT [PrvCod], [PrvDsc], [PrvDir], [PrvTel1], [PrvTel2], [PrvFax], [PrvCel], [PrvEM], [PrvWeb], [PrvFoto_GXI], [PrvSts], [PrvRef1], [PrvRef2], [PrvRef3], [PrvRef4], [PrvRef5], [PrvRef6], [PrvRef7], [PrvRef8], [PrvCon1], [PrvCTel1], [PrvCon2], [PrvCTel2], [PrvCon3], [PrvCTel3], [PrvCon4], [PrvCTel4], [PrvCon5], [PrvCTel5], [PrvNom], [PrvAPeP], [PrvAPeM], [PrvVincula], [PrvRetencion], [PrvTipCuenta1], [PrvBanCuenta1], [PrvTipCuenta2], [PrvTCon], [PrvBanCuenta2], [PrvUsuCod], [PrvUsuFec], [PrvUsuCodM], [PrvUsuFecM], [PrvWebUsu], [PrvWebPas], [PrvWebFec], [PaiCod], [EstCod], [ProvCod], [DisCod], [TprvCod], [TPerCod], [TipSCod], [PrvConpCod] AS PrvConpCod, [PrvBanCod1] AS PrvBanCod1, [PrvBanCod2] AS PrvBanCod2, [PrvFoto] FROM [CPPROVEEDORES] WITH (UPDLOCK) WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L3", "SELECT [PrvCod], [PrvDsc], [PrvDir], [PrvTel1], [PrvTel2], [PrvFax], [PrvCel], [PrvEM], [PrvWeb], [PrvFoto_GXI], [PrvSts], [PrvRef1], [PrvRef2], [PrvRef3], [PrvRef4], [PrvRef5], [PrvRef6], [PrvRef7], [PrvRef8], [PrvCon1], [PrvCTel1], [PrvCon2], [PrvCTel2], [PrvCon3], [PrvCTel3], [PrvCon4], [PrvCTel4], [PrvCon5], [PrvCTel5], [PrvNom], [PrvAPeP], [PrvAPeM], [PrvVincula], [PrvRetencion], [PrvTipCuenta1], [PrvBanCuenta1], [PrvTipCuenta2], [PrvTCon], [PrvBanCuenta2], [PrvUsuCod], [PrvUsuFec], [PrvUsuCodM], [PrvUsuFecM], [PrvWebUsu], [PrvWebPas], [PrvWebFec], [PaiCod], [EstCod], [ProvCod], [DisCod], [TprvCod], [TPerCod], [TipSCod], [PrvConpCod] AS PrvConpCod, [PrvBanCod1] AS PrvBanCod1, [PrvBanCod2] AS PrvBanCod2, [PrvFoto] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L4", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L5", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L6", "SELECT [TPerCod] FROM [CTPERSONA] WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L7", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L8", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L9", "SELECT [BanCod] AS PrvBanCod1 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L10", "SELECT [BanCod] AS PrvBanCod2 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L11", "SELECT TM1.[PrvCod], TM1.[PrvDsc], TM1.[PrvDir], TM1.[PrvTel1], TM1.[PrvTel2], TM1.[PrvFax], TM1.[PrvCel], TM1.[PrvEM], TM1.[PrvWeb], TM1.[PrvFoto_GXI], TM1.[PrvSts], TM1.[PrvRef1], TM1.[PrvRef2], TM1.[PrvRef3], TM1.[PrvRef4], TM1.[PrvRef5], TM1.[PrvRef6], TM1.[PrvRef7], TM1.[PrvRef8], TM1.[PrvCon1], TM1.[PrvCTel1], TM1.[PrvCon2], TM1.[PrvCTel2], TM1.[PrvCon3], TM1.[PrvCTel3], TM1.[PrvCon4], TM1.[PrvCTel4], TM1.[PrvCon5], TM1.[PrvCTel5], TM1.[PrvNom], TM1.[PrvAPeP], TM1.[PrvAPeM], TM1.[PrvVincula], TM1.[PrvRetencion], TM1.[PrvTipCuenta1], TM1.[PrvBanCuenta1], TM1.[PrvTipCuenta2], TM1.[PrvTCon], TM1.[PrvBanCuenta2], TM1.[PrvUsuCod], TM1.[PrvUsuFec], TM1.[PrvUsuCodM], TM1.[PrvUsuFecM], TM1.[PrvWebUsu], TM1.[PrvWebPas], TM1.[PrvWebFec], T2.[ConpDsc] AS PrvConpDsc, TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod], TM1.[DisCod], TM1.[TprvCod], TM1.[TPerCod], TM1.[TipSCod], TM1.[PrvConpCod] AS PrvConpCod, TM1.[PrvBanCod1] AS PrvBanCod1, TM1.[PrvBanCod2] AS PrvBanCod2, TM1.[PrvFoto] FROM ([CPPROVEEDORES] TM1 INNER JOIN [CCONDICIONPAGO] T2 ON T2.[Conpcod] = TM1.[PrvConpCod]) WHERE TM1.[PrvCod] = @PrvCod ORDER BY TM1.[PrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003L11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L12", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L13", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L14", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L15", "SELECT [TPerCod] FROM [CTPERSONA] WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L16", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L17", "SELECT [BanCod] AS PrvBanCod1 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L18", "SELECT [BanCod] AS PrvBanCod2 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L19", "SELECT [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003L19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L20", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE ( [PrvCod] > @PrvCod) ORDER BY [PrvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003L20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L21", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE ( [PrvCod] < @PrvCod) ORDER BY [PrvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003L21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L22", "INSERT INTO [CPPROVEEDORES]([PrvCod], [PrvDsc], [PrvDir], [PrvTel1], [PrvTel2], [PrvFax], [PrvCel], [PrvEM], [PrvWeb], [PrvFoto], [PrvFoto_GXI], [PrvSts], [PrvRef1], [PrvRef2], [PrvRef3], [PrvRef4], [PrvRef5], [PrvRef6], [PrvRef7], [PrvRef8], [PrvCon1], [PrvCTel1], [PrvCon2], [PrvCTel2], [PrvCon3], [PrvCTel3], [PrvCon4], [PrvCTel4], [PrvCon5], [PrvCTel5], [PrvNom], [PrvAPeP], [PrvAPeM], [PrvVincula], [PrvRetencion], [PrvTipCuenta1], [PrvBanCuenta1], [PrvTipCuenta2], [PrvTCon], [PrvBanCuenta2], [PrvUsuCod], [PrvUsuFec], [PrvUsuCodM], [PrvUsuFecM], [PrvWebUsu], [PrvWebPas], [PrvWebFec], [PaiCod], [EstCod], [ProvCod], [DisCod], [TprvCod], [TPerCod], [TipSCod], [PrvConpCod], [PrvBanCod1], [PrvBanCod2]) VALUES(@PrvCod, @PrvDsc, @PrvDir, @PrvTel1, @PrvTel2, @PrvFax, @PrvCel, @PrvEM, @PrvWeb, @PrvFoto, @PrvFoto_GXI, @PrvSts, @PrvRef1, @PrvRef2, @PrvRef3, @PrvRef4, @PrvRef5, @PrvRef6, @PrvRef7, @PrvRef8, @PrvCon1, @PrvCTel1, @PrvCon2, @PrvCTel2, @PrvCon3, @PrvCTel3, @PrvCon4, @PrvCTel4, @PrvCon5, @PrvCTel5, @PrvNom, @PrvAPeP, @PrvAPeM, @PrvVincula, @PrvRetencion, @PrvTipCuenta1, @PrvBanCuenta1, @PrvTipCuenta2, @PrvTCon, @PrvBanCuenta2, @PrvUsuCod, @PrvUsuFec, @PrvUsuCodM, @PrvUsuFecM, @PrvWebUsu, @PrvWebPas, @PrvWebFec, @PaiCod, @EstCod, @ProvCod, @DisCod, @TprvCod, @TPerCod, @TipSCod, @PrvConpCod, @PrvBanCod1, @PrvBanCod2)", GxErrorMask.GX_NOMASK,prmT003L22)
           ,new CursorDef("T003L23", "UPDATE [CPPROVEEDORES] SET [PrvDsc]=@PrvDsc, [PrvDir]=@PrvDir, [PrvTel1]=@PrvTel1, [PrvTel2]=@PrvTel2, [PrvFax]=@PrvFax, [PrvCel]=@PrvCel, [PrvEM]=@PrvEM, [PrvWeb]=@PrvWeb, [PrvSts]=@PrvSts, [PrvRef1]=@PrvRef1, [PrvRef2]=@PrvRef2, [PrvRef3]=@PrvRef3, [PrvRef4]=@PrvRef4, [PrvRef5]=@PrvRef5, [PrvRef6]=@PrvRef6, [PrvRef7]=@PrvRef7, [PrvRef8]=@PrvRef8, [PrvCon1]=@PrvCon1, [PrvCTel1]=@PrvCTel1, [PrvCon2]=@PrvCon2, [PrvCTel2]=@PrvCTel2, [PrvCon3]=@PrvCon3, [PrvCTel3]=@PrvCTel3, [PrvCon4]=@PrvCon4, [PrvCTel4]=@PrvCTel4, [PrvCon5]=@PrvCon5, [PrvCTel5]=@PrvCTel5, [PrvNom]=@PrvNom, [PrvAPeP]=@PrvAPeP, [PrvAPeM]=@PrvAPeM, [PrvVincula]=@PrvVincula, [PrvRetencion]=@PrvRetencion, [PrvTipCuenta1]=@PrvTipCuenta1, [PrvBanCuenta1]=@PrvBanCuenta1, [PrvTipCuenta2]=@PrvTipCuenta2, [PrvTCon]=@PrvTCon, [PrvBanCuenta2]=@PrvBanCuenta2, [PrvUsuCod]=@PrvUsuCod, [PrvUsuFec]=@PrvUsuFec, [PrvUsuCodM]=@PrvUsuCodM, [PrvUsuFecM]=@PrvUsuFecM, [PrvWebUsu]=@PrvWebUsu, [PrvWebPas]=@PrvWebPas, [PrvWebFec]=@PrvWebFec, [PaiCod]=@PaiCod, [EstCod]=@EstCod, [ProvCod]=@ProvCod, [DisCod]=@DisCod, [TprvCod]=@TprvCod, [TPerCod]=@TPerCod, [TipSCod]=@TipSCod, [PrvConpCod]=@PrvConpCod, [PrvBanCod1]=@PrvBanCod1, [PrvBanCod2]=@PrvBanCod2  WHERE [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK,prmT003L23)
           ,new CursorDef("T003L24", "UPDATE [CPPROVEEDORES] SET [PrvFoto]=@PrvFoto, [PrvFoto_GXI]=@PrvFoto_GXI  WHERE [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK,prmT003L24)
           ,new CursorDef("T003L25", "DELETE FROM [CPPROVEEDORES]  WHERE [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK,prmT003L25)
           ,new CursorDef("T003L26", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L27", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L28", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L29", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L30", "SELECT TOP 1 [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L31", "SELECT TOP 1 [LetPLetCod] FROM [CPLETRAS] WHERE [LetPPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L32", "SELECT TOP 1 [CPTipCod], [CPComCod], [CPPrvCod] FROM [CPCUENTAPAGAR] WHERE [CPPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L33", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L34", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L35", "SELECT TOP 1 [CPRetCod] FROM [CPRETENCION] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L36", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L37", "SELECT TOP 1 [CPLisProdCod], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L38", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L39", "SELECT TOP 1 [PrvCod], [PrvConCod] FROM [CPPROVEEDORESCONTACTOS] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L40", "SELECT TOP 1 [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDPrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003L41", "SELECT [PrvCod] FROM [CPPROVEEDORES] ORDER BY [PrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003L41,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L42", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L43", "SELECT [PaiCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L44", "SELECT [TPerCod] FROM [CTPERSONA] WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L44,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L45", "SELECT [TipSCod] FROM [CTIPDOCS] WHERE [TipSCod] = @TipSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L46", "SELECT [BanCod] AS PrvBanCod1 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003L47", "SELECT [BanCod] AS PrvBanCod2 FROM [TSBANCOS] WHERE [BanCod] = @PrvBanCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT003L47,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 50);
              ((string[]) buf[13])[0] = rslt.getString(13, 50);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 20);
              ((string[]) buf[22])[0] = rslt.getString(22, 50);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((string[]) buf[24])[0] = rslt.getString(24, 50);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((string[]) buf[26])[0] = rslt.getString(26, 50);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((string[]) buf[28])[0] = rslt.getString(28, 50);
              ((string[]) buf[29])[0] = rslt.getString(29, 20);
              ((string[]) buf[30])[0] = rslt.getString(30, 100);
              ((string[]) buf[31])[0] = rslt.getString(31, 100);
              ((string[]) buf[32])[0] = rslt.getString(32, 100);
              ((short[]) buf[33])[0] = rslt.getShort(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((string[]) buf[36])[0] = rslt.getVarchar(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              ((string[]) buf[39])[0] = rslt.getVarchar(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(41);
              ((string[]) buf[42])[0] = rslt.getString(42, 10);
              ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 100);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((DateTime[]) buf[46])[0] = rslt.getGXDateTime(46);
              ((string[]) buf[47])[0] = rslt.getString(47, 4);
              ((string[]) buf[48])[0] = rslt.getString(48, 4);
              ((string[]) buf[49])[0] = rslt.getString(49, 4);
              ((string[]) buf[50])[0] = rslt.getString(50, 4);
              ((int[]) buf[51])[0] = rslt.getInt(51);
              ((int[]) buf[52])[0] = rslt.getInt(52);
              ((bool[]) buf[53])[0] = rslt.wasNull(52);
              ((int[]) buf[54])[0] = rslt.getInt(53);
              ((bool[]) buf[55])[0] = rslt.wasNull(53);
              ((int[]) buf[56])[0] = rslt.getInt(54);
              ((int[]) buf[57])[0] = rslt.getInt(55);
              ((bool[]) buf[58])[0] = rslt.wasNull(55);
              ((int[]) buf[59])[0] = rslt.getInt(56);
              ((bool[]) buf[60])[0] = rslt.wasNull(56);
              ((string[]) buf[61])[0] = rslt.getMultimediaFile(57, rslt.getVarchar(10));
              ((bool[]) buf[62])[0] = rslt.wasNull(57);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 50);
              ((string[]) buf[13])[0] = rslt.getString(13, 50);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 20);
              ((string[]) buf[22])[0] = rslt.getString(22, 50);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((string[]) buf[24])[0] = rslt.getString(24, 50);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((string[]) buf[26])[0] = rslt.getString(26, 50);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((string[]) buf[28])[0] = rslt.getString(28, 50);
              ((string[]) buf[29])[0] = rslt.getString(29, 20);
              ((string[]) buf[30])[0] = rslt.getString(30, 100);
              ((string[]) buf[31])[0] = rslt.getString(31, 100);
              ((string[]) buf[32])[0] = rslt.getString(32, 100);
              ((short[]) buf[33])[0] = rslt.getShort(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((string[]) buf[36])[0] = rslt.getVarchar(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              ((string[]) buf[39])[0] = rslt.getVarchar(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(41);
              ((string[]) buf[42])[0] = rslt.getString(42, 10);
              ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 100);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((DateTime[]) buf[46])[0] = rslt.getGXDateTime(46);
              ((string[]) buf[47])[0] = rslt.getString(47, 4);
              ((string[]) buf[48])[0] = rslt.getString(48, 4);
              ((string[]) buf[49])[0] = rslt.getString(49, 4);
              ((string[]) buf[50])[0] = rslt.getString(50, 4);
              ((int[]) buf[51])[0] = rslt.getInt(51);
              ((int[]) buf[52])[0] = rslt.getInt(52);
              ((bool[]) buf[53])[0] = rslt.wasNull(52);
              ((int[]) buf[54])[0] = rslt.getInt(53);
              ((bool[]) buf[55])[0] = rslt.wasNull(53);
              ((int[]) buf[56])[0] = rslt.getInt(54);
              ((int[]) buf[57])[0] = rslt.getInt(55);
              ((bool[]) buf[58])[0] = rslt.wasNull(55);
              ((int[]) buf[59])[0] = rslt.getInt(56);
              ((bool[]) buf[60])[0] = rslt.wasNull(56);
              ((string[]) buf[61])[0] = rslt.getMultimediaFile(57, rslt.getVarchar(10));
              ((bool[]) buf[62])[0] = rslt.wasNull(57);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
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
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 50);
              ((string[]) buf[13])[0] = rslt.getString(13, 50);
              ((string[]) buf[14])[0] = rslt.getString(14, 50);
              ((string[]) buf[15])[0] = rslt.getString(15, 50);
              ((string[]) buf[16])[0] = rslt.getString(16, 50);
              ((string[]) buf[17])[0] = rslt.getString(17, 50);
              ((string[]) buf[18])[0] = rslt.getString(18, 50);
              ((string[]) buf[19])[0] = rslt.getString(19, 50);
              ((string[]) buf[20])[0] = rslt.getString(20, 50);
              ((string[]) buf[21])[0] = rslt.getString(21, 20);
              ((string[]) buf[22])[0] = rslt.getString(22, 50);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((string[]) buf[24])[0] = rslt.getString(24, 50);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((string[]) buf[26])[0] = rslt.getString(26, 50);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((string[]) buf[28])[0] = rslt.getString(28, 50);
              ((string[]) buf[29])[0] = rslt.getString(29, 20);
              ((string[]) buf[30])[0] = rslt.getString(30, 100);
              ((string[]) buf[31])[0] = rslt.getString(31, 100);
              ((string[]) buf[32])[0] = rslt.getString(32, 100);
              ((short[]) buf[33])[0] = rslt.getShort(33);
              ((short[]) buf[34])[0] = rslt.getShort(34);
              ((string[]) buf[35])[0] = rslt.getVarchar(35);
              ((string[]) buf[36])[0] = rslt.getVarchar(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              ((string[]) buf[39])[0] = rslt.getVarchar(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(41);
              ((string[]) buf[42])[0] = rslt.getString(42, 10);
              ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 100);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((DateTime[]) buf[46])[0] = rslt.getGXDateTime(46);
              ((string[]) buf[47])[0] = rslt.getString(47, 100);
              ((string[]) buf[48])[0] = rslt.getString(48, 4);
              ((string[]) buf[49])[0] = rslt.getString(49, 4);
              ((string[]) buf[50])[0] = rslt.getString(50, 4);
              ((string[]) buf[51])[0] = rslt.getString(51, 4);
              ((int[]) buf[52])[0] = rslt.getInt(52);
              ((int[]) buf[53])[0] = rslt.getInt(53);
              ((bool[]) buf[54])[0] = rslt.wasNull(53);
              ((int[]) buf[55])[0] = rslt.getInt(54);
              ((bool[]) buf[56])[0] = rslt.wasNull(54);
              ((int[]) buf[57])[0] = rslt.getInt(55);
              ((int[]) buf[58])[0] = rslt.getInt(56);
              ((bool[]) buf[59])[0] = rslt.wasNull(56);
              ((int[]) buf[60])[0] = rslt.getInt(57);
              ((bool[]) buf[61])[0] = rslt.wasNull(57);
              ((string[]) buf[62])[0] = rslt.getMultimediaFile(58, rslt.getVarchar(10));
              ((bool[]) buf[63])[0] = rslt.wasNull(58);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 40 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 42 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 43 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 44 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 45 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
