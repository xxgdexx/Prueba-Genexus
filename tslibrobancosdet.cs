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
   public class tslibrobancosdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = GetPar( "LBCBCod");
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = GetPar( "LBRegistro");
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A379LBBanCod, A380LBCBCod, A381LBRegistro) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A386LBConBan = (int)(NumberUtil.Val( GetPar( "LBConBan"), "."));
            AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A386LBConBan) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A1058LBCueCod = GetPar( "LBCueCod");
            AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A1058LBCueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A385LBDForCod = (int)(NumberUtil.Val( GetPar( "LBDForCod"), "."));
            n385LBDForCod = false;
            AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A385LBDForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A384LBDCosCod = GetPar( "LBDCosCod");
            n384LBDCosCod = false;
            AssignAttri("", false, "A384LBDCosCod", A384LBDCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A384LBDCosCod) ;
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
            Form.Meta.addItem("description", "Libro Bancos - Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tslibrobancosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tslibrobancosdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSLIBROBANCOSDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Banco", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A379LBBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A379LBBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A379LBBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cuenta Banco", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCBCod_Internalname, StringUtil.RTrim( A380LBCBCod), StringUtil.RTrim( context.localUtil.Format( A380LBCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Registro", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBRegistro_Internalname, StringUtil.RTrim( A381LBRegistro), StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Item", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDITem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A383LBDITem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBDITem_Enabled!=0) ? context.localUtil.Format( (decimal)(A383LBDITem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A383LBDITem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDITem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDITem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Tipo de Documento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBTipCod_Internalname, StringUtil.RTrim( A1092LBTipCod), StringUtil.RTrim( context.localUtil.Format( A1092LBTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Documento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDDoc_Internalname, StringUtil.RTrim( A1068LBDDoc), StringUtil.RTrim( context.localUtil.Format( A1068LBDDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDDoc_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Importe Debe", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDDebe_Internalname, StringUtil.LTrim( StringUtil.NToC( A1067LBDDebe, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBDDebe_Enabled!=0) ? context.localUtil.Format( A1067LBDDebe, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1067LBDDebe, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDDebe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDDebe_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Importe Haber", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDHaber_Internalname, StringUtil.LTrim( StringUtil.NToC( A1074LBDHaber, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBDHaber_Enabled!=0) ? context.localUtil.Format( A1074LBDHaber, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1074LBDHaber, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDHaber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDHaber_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Concepto de Banco", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBConBan_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A386LBConBan), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBConBan_Enabled!=0) ? context.localUtil.Format( (decimal)(A386LBConBan), "ZZZZZ9") : context.localUtil.Format( (decimal)(A386LBConBan), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBConBan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBConBan_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "R.U.C.", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBPrvCod_Internalname, StringUtil.RTrim( A1087LBPrvCod), StringUtil.RTrim( context.localUtil.Format( A1087LBPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cuenta", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDCueCod_Internalname, StringUtil.RTrim( A1066LBDCueCod), StringUtil.RTrim( context.localUtil.Format( A1066LBDCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Auxiliar", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDCueAux_Internalname, StringUtil.RTrim( A1065LBDCueAux), StringUtil.RTrim( context.localUtil.Format( A1065LBDCueAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDCueAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDCueAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Forma de Pago", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A385LBDForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBDForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A385LBDForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A385LBDForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "N° Pago", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1076LBDPagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtLBDPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1076LBDPagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1076LBDPagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Centro de Costo", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDCosCod_Internalname, StringUtil.RTrim( A384LBDCosCod), StringUtil.RTrim( context.localUtil.Format( A384LBDCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Tipo de Cambio", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1077LBDTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtLBDTipCmb_Enabled!=0) ? context.localUtil.Format( A1077LBDTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1077LBDTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Cuenta", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBCueCod_Internalname, StringUtil.RTrim( A1058LBCueCod), StringUtil.RTrim( context.localUtil.Format( A1058LBCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Concepto", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBDConcepto_Internalname, StringUtil.RTrim( A1064LBDConcepto), StringUtil.RTrim( context.localUtil.Format( A1064LBDConcepto, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Centro Costo", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBCueCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1059LBCueCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtLBCueCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1059LBCueCos), "9") : context.localUtil.Format( (decimal)(A1059LBCueCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCueCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCueCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Cuenta", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBCueDsc_Internalname, StringUtil.RTrim( A1060LBCueDsc), StringUtil.RTrim( context.localUtil.Format( A1060LBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSLIBROBANCOSDET.htm");
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
            Z379LBBanCod = (int)(context.localUtil.CToN( cgiGet( "Z379LBBanCod"), ".", ","));
            Z380LBCBCod = cgiGet( "Z380LBCBCod");
            Z381LBRegistro = cgiGet( "Z381LBRegistro");
            Z383LBDITem = (int)(context.localUtil.CToN( cgiGet( "Z383LBDITem"), ".", ","));
            Z1092LBTipCod = cgiGet( "Z1092LBTipCod");
            Z1068LBDDoc = cgiGet( "Z1068LBDDoc");
            Z1067LBDDebe = context.localUtil.CToN( cgiGet( "Z1067LBDDebe"), ".", ",");
            Z1074LBDHaber = context.localUtil.CToN( cgiGet( "Z1074LBDHaber"), ".", ",");
            Z1087LBPrvCod = cgiGet( "Z1087LBPrvCod");
            Z1066LBDCueCod = cgiGet( "Z1066LBDCueCod");
            Z1065LBDCueAux = cgiGet( "Z1065LBDCueAux");
            Z1076LBDPagReg = (long)(context.localUtil.CToN( cgiGet( "Z1076LBDPagReg"), ".", ","));
            n1076LBDPagReg = ((0==A1076LBDPagReg) ? true : false);
            Z1077LBDTipCmb = context.localUtil.CToN( cgiGet( "Z1077LBDTipCmb"), ".", ",");
            Z386LBConBan = (int)(context.localUtil.CToN( cgiGet( "Z386LBConBan"), ".", ","));
            Z385LBDForCod = (int)(context.localUtil.CToN( cgiGet( "Z385LBDForCod"), ".", ","));
            n385LBDForCod = ((0==A385LBDForCod) ? true : false);
            Z384LBDCosCod = cgiGet( "Z384LBDCosCod");
            O1067LBDDebe = context.localUtil.CToN( cgiGet( "O1067LBDDebe"), ".", ",");
            O1072LBTDebe = context.localUtil.CToN( cgiGet( "O1072LBTDebe"), ".", ",");
            O1074LBDHaber = context.localUtil.CToN( cgiGet( "O1074LBDHaber"), ".", ",");
            O1073LBTHaber = context.localUtil.CToN( cgiGet( "O1073LBTHaber"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1073LBTHaber = context.localUtil.CToN( cgiGet( "LBTHABER"), ".", ",");
            A1072LBTDebe = context.localUtil.CToN( cgiGet( "LBTDEBE"), ".", ",");
            A1061LBCueMon = (short)(context.localUtil.CToN( cgiGet( "LBCUEMON"), ".", ","));
            A1090LBTipACod = (int)(context.localUtil.CToN( cgiGet( "LBTIPACOD"), ".", ","));
            n1090LBTipACod = false;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A379LBBanCod = 0;
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            }
            else
            {
               A379LBBanCod = (int)(context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            }
            A380LBCBCod = cgiGet( edtLBCBCod_Internalname);
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = cgiGet( edtLBRegistro_Internalname);
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDITem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDITem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDITEM");
               AnyError = 1;
               GX_FocusControl = edtLBDITem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A383LBDITem = 0;
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
            }
            else
            {
               A383LBDITem = (int)(context.localUtil.CToN( cgiGet( edtLBDITem_Internalname), ".", ","));
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
            }
            A1092LBTipCod = cgiGet( edtLBTipCod_Internalname);
            AssignAttri("", false, "A1092LBTipCod", A1092LBTipCod);
            A1068LBDDoc = cgiGet( edtLBDDoc_Internalname);
            AssignAttri("", false, "A1068LBDDoc", A1068LBDDoc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDDebe_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDDebe_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDDEBE");
               AnyError = 1;
               GX_FocusControl = edtLBDDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1067LBDDebe = 0;
               AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
            }
            else
            {
               A1067LBDDebe = context.localUtil.CToN( cgiGet( edtLBDDebe_Internalname), ".", ",");
               AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDHaber_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDHaber_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDHABER");
               AnyError = 1;
               GX_FocusControl = edtLBDHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1074LBDHaber = 0;
               AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
            }
            else
            {
               A1074LBDHaber = context.localUtil.CToN( cgiGet( edtLBDHaber_Internalname), ".", ",");
               AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBConBan_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBConBan_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBCONBAN");
               AnyError = 1;
               GX_FocusControl = edtLBConBan_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A386LBConBan = 0;
               AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
            }
            else
            {
               A386LBConBan = (int)(context.localUtil.CToN( cgiGet( edtLBConBan_Internalname), ".", ","));
               AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
            }
            A1087LBPrvCod = cgiGet( edtLBPrvCod_Internalname);
            AssignAttri("", false, "A1087LBPrvCod", A1087LBPrvCod);
            A1066LBDCueCod = cgiGet( edtLBDCueCod_Internalname);
            AssignAttri("", false, "A1066LBDCueCod", A1066LBDCueCod);
            A1065LBDCueAux = cgiGet( edtLBDCueAux_Internalname);
            AssignAttri("", false, "A1065LBDCueAux", A1065LBDCueAux);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A385LBDForCod = 0;
               n385LBDForCod = false;
               AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
            }
            else
            {
               A385LBDForCod = (int)(context.localUtil.CToN( cgiGet( edtLBDForCod_Internalname), ".", ","));
               n385LBDForCod = false;
               AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
            }
            n385LBDForCod = ((0==A385LBDForCod) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDPAGREG");
               AnyError = 1;
               GX_FocusControl = edtLBDPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1076LBDPagReg = 0;
               n1076LBDPagReg = false;
               AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrimStr( (decimal)(A1076LBDPagReg), 10, 0));
            }
            else
            {
               A1076LBDPagReg = (long)(context.localUtil.CToN( cgiGet( edtLBDPagReg_Internalname), ".", ","));
               n1076LBDPagReg = false;
               AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrimStr( (decimal)(A1076LBDPagReg), 10, 0));
            }
            n1076LBDPagReg = ((0==A1076LBDPagReg) ? true : false);
            A384LBDCosCod = cgiGet( edtLBDCosCod_Internalname);
            n384LBDCosCod = false;
            AssignAttri("", false, "A384LBDCosCod", A384LBDCosCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBDTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBDTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBDTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtLBDTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1077LBDTipCmb = 0;
               AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrimStr( A1077LBDTipCmb, 15, 5));
            }
            else
            {
               A1077LBDTipCmb = context.localUtil.CToN( cgiGet( edtLBDTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrimStr( A1077LBDTipCmb, 15, 5));
            }
            A1058LBCueCod = cgiGet( edtLBCueCod_Internalname);
            AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
            A1064LBDConcepto = cgiGet( edtLBDConcepto_Internalname);
            AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
            A1059LBCueCos = (short)(context.localUtil.CToN( cgiGet( edtLBCueCos_Internalname), ".", ","));
            AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
            A1060LBCueDsc = cgiGet( edtLBCueDsc_Internalname);
            AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = GetPar( "LBCBCod");
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = GetPar( "LBRegistro");
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               A383LBDITem = (int)(NumberUtil.Val( GetPar( "LBDITem"), "."));
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
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
               InitAll5A177( ) ;
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
         DisableAttributes5A177( ) ;
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

      protected void CONFIRM_5A0( )
      {
         BeforeValidate5A177( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5A177( ) ;
            }
            else
            {
               CheckExtendedTable5A177( ) ;
               if ( AnyError == 0 )
               {
                  ZM5A177( 4) ;
                  ZM5A177( 5) ;
                  ZM5A177( 6) ;
                  ZM5A177( 7) ;
                  ZM5A177( 8) ;
               }
               CloseExtendedTableCursors5A177( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues5A0( ) ;
         }
      }

      protected void ResetCaption5A0( )
      {
      }

      protected void ZM5A177( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1092LBTipCod = T005A3_A1092LBTipCod[0];
               Z1068LBDDoc = T005A3_A1068LBDDoc[0];
               Z1067LBDDebe = T005A3_A1067LBDDebe[0];
               Z1074LBDHaber = T005A3_A1074LBDHaber[0];
               Z1087LBPrvCod = T005A3_A1087LBPrvCod[0];
               Z1066LBDCueCod = T005A3_A1066LBDCueCod[0];
               Z1065LBDCueAux = T005A3_A1065LBDCueAux[0];
               Z1076LBDPagReg = T005A3_A1076LBDPagReg[0];
               Z1077LBDTipCmb = T005A3_A1077LBDTipCmb[0];
               Z386LBConBan = T005A3_A386LBConBan[0];
               Z385LBDForCod = T005A3_A385LBDForCod[0];
               Z384LBDCosCod = T005A3_A384LBDCosCod[0];
            }
            else
            {
               Z1092LBTipCod = A1092LBTipCod;
               Z1068LBDDoc = A1068LBDDoc;
               Z1067LBDDebe = A1067LBDDebe;
               Z1074LBDHaber = A1074LBDHaber;
               Z1087LBPrvCod = A1087LBPrvCod;
               Z1066LBDCueCod = A1066LBDCueCod;
               Z1065LBDCueAux = A1065LBDCueAux;
               Z1076LBDPagReg = A1076LBDPagReg;
               Z1077LBDTipCmb = A1077LBDTipCmb;
               Z386LBConBan = A386LBConBan;
               Z385LBDForCod = A385LBDForCod;
               Z384LBDCosCod = A384LBDCosCod;
            }
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z383LBDITem = A383LBDITem;
            Z1092LBTipCod = A1092LBTipCod;
            Z1068LBDDoc = A1068LBDDoc;
            Z1067LBDDebe = A1067LBDDebe;
            Z1074LBDHaber = A1074LBDHaber;
            Z1087LBPrvCod = A1087LBPrvCod;
            Z1066LBDCueCod = A1066LBDCueCod;
            Z1065LBDCueAux = A1065LBDCueAux;
            Z1076LBDPagReg = A1076LBDPagReg;
            Z1077LBDTipCmb = A1077LBDTipCmb;
            Z379LBBanCod = A379LBBanCod;
            Z380LBCBCod = A380LBCBCod;
            Z381LBRegistro = A381LBRegistro;
            Z386LBConBan = A386LBConBan;
            Z385LBDForCod = A385LBDForCod;
            Z384LBDCosCod = A384LBDCosCod;
            Z1073LBTHaber = A1073LBTHaber;
            Z1072LBTDebe = A1072LBTDebe;
            Z1064LBDConcepto = A1064LBDConcepto;
            Z1058LBCueCod = A1058LBCueCod;
            Z1061LBCueMon = A1061LBCueMon;
            Z1059LBCueCos = A1059LBCueCos;
            Z1060LBCueDsc = A1060LBCueDsc;
            Z1090LBTipACod = A1090LBTipACod;
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

      protected void Load5A177( )
      {
         /* Using cursor T005A10 */
         pr_default.execute(8, new Object[] {A383LBDITem, A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound177 = 1;
            A1073LBTHaber = T005A10_A1073LBTHaber[0];
            A1072LBTDebe = T005A10_A1072LBTDebe[0];
            A1092LBTipCod = T005A10_A1092LBTipCod[0];
            AssignAttri("", false, "A1092LBTipCod", A1092LBTipCod);
            A1068LBDDoc = T005A10_A1068LBDDoc[0];
            AssignAttri("", false, "A1068LBDDoc", A1068LBDDoc);
            A1067LBDDebe = T005A10_A1067LBDDebe[0];
            AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
            A1074LBDHaber = T005A10_A1074LBDHaber[0];
            AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
            A1087LBPrvCod = T005A10_A1087LBPrvCod[0];
            AssignAttri("", false, "A1087LBPrvCod", A1087LBPrvCod);
            A1066LBDCueCod = T005A10_A1066LBDCueCod[0];
            AssignAttri("", false, "A1066LBDCueCod", A1066LBDCueCod);
            A1065LBDCueAux = T005A10_A1065LBDCueAux[0];
            AssignAttri("", false, "A1065LBDCueAux", A1065LBDCueAux);
            A1061LBCueMon = T005A10_A1061LBCueMon[0];
            A1076LBDPagReg = T005A10_A1076LBDPagReg[0];
            n1076LBDPagReg = T005A10_n1076LBDPagReg[0];
            AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrimStr( (decimal)(A1076LBDPagReg), 10, 0));
            A1077LBDTipCmb = T005A10_A1077LBDTipCmb[0];
            AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrimStr( A1077LBDTipCmb, 15, 5));
            A1064LBDConcepto = T005A10_A1064LBDConcepto[0];
            AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
            A1059LBCueCos = T005A10_A1059LBCueCos[0];
            AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
            A1060LBCueDsc = T005A10_A1060LBCueDsc[0];
            AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
            A386LBConBan = T005A10_A386LBConBan[0];
            AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
            A385LBDForCod = T005A10_A385LBDForCod[0];
            n385LBDForCod = T005A10_n385LBDForCod[0];
            AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
            A384LBDCosCod = T005A10_A384LBDCosCod[0];
            n384LBDCosCod = T005A10_n384LBDCosCod[0];
            AssignAttri("", false, "A384LBDCosCod", A384LBDCosCod);
            A1058LBCueCod = T005A10_A1058LBCueCod[0];
            AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
            A1090LBTipACod = T005A10_A1090LBTipACod[0];
            n1090LBTipACod = T005A10_n1090LBTipACod[0];
            ZM5A177( -3) ;
         }
         pr_default.close(8);
         OnLoadActions5A177( ) ;
      }

      protected void OnLoadActions5A177( )
      {
         O1072LBTDebe = A1072LBTDebe;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         O1073LBTHaber = A1073LBTHaber;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         if ( IsIns( )  )
         {
            A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber);
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber-O1074LBDHaber);
               AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A1073LBTHaber = (decimal)(O1073LBTHaber-O1074LBDHaber);
                  AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
               }
            }
         }
         if ( IsIns( )  )
         {
            A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe);
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe-O1067LBDDebe);
               AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A1072LBTDebe = (decimal)(O1072LBTDebe-O1067LBDDebe);
                  AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable5A177( )
      {
         nIsDirty_177 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005A5 */
         pr_default.execute(3, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Libro Bancos'.", "ForeignKeyNotFound", 1, "LBREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1073LBTHaber = T005A5_A1073LBTHaber[0];
         A1072LBTDebe = T005A5_A1072LBTDebe[0];
         nIsDirty_177 = 1;
         O1072LBTDebe = A1072LBTDebe;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         nIsDirty_177 = 1;
         O1073LBTHaber = A1073LBTHaber;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_177 = 1;
            A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber);
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_177 = 1;
               A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber-O1074LBDHaber);
               AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_177 = 1;
                  A1073LBTHaber = (decimal)(O1073LBTHaber-O1074LBDHaber);
                  AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
               }
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_177 = 1;
            A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe);
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_177 = 1;
               A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe-O1067LBDDebe);
               AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_177 = 1;
                  A1072LBTDebe = (decimal)(O1072LBTDebe-O1067LBDDebe);
                  AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
               }
            }
         }
         /* Using cursor T005A6 */
         pr_default.execute(4, new Object[] {A386LBConBan});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto Libro Bancos'.", "ForeignKeyNotFound", 1, "LBCONBAN");
            AnyError = 1;
            GX_FocusControl = edtLBConBan_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1064LBDConcepto = T005A6_A1064LBDConcepto[0];
         AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
         A1058LBCueCod = T005A6_A1058LBCueCod[0];
         AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
         pr_default.close(4);
         /* Using cursor T005A9 */
         pr_default.execute(7, new Object[] {A1058LBCueCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "LBCUECOD");
            AnyError = 1;
         }
         A1061LBCueMon = T005A9_A1061LBCueMon[0];
         A1059LBCueCos = T005A9_A1059LBCueCos[0];
         AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
         A1060LBCueDsc = T005A9_A1060LBCueDsc[0];
         AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
         A1090LBTipACod = T005A9_A1090LBTipACod[0];
         n1090LBTipACod = T005A9_n1090LBTipACod[0];
         pr_default.close(7);
         /* Using cursor T005A7 */
         pr_default.execute(5, new Object[] {n385LBDForCod, A385LBDForCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A385LBDForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LBDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T005A8 */
         pr_default.execute(6, new Object[] {n384LBDCosCod, A384LBDCosCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A384LBDCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "LBDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors5A177( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A379LBBanCod ,
                               string A380LBCBCod ,
                               string A381LBRegistro )
      {
         /* Using cursor T005A5 */
         pr_default.execute(3, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Libro Bancos'.", "ForeignKeyNotFound", 1, "LBREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1073LBTHaber = T005A5_A1073LBTHaber[0];
         A1072LBTDebe = T005A5_A1072LBTDebe[0];
         O1072LBTDebe = A1072LBTDebe;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         O1073LBTHaber = A1073LBTHaber;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(3);
      }

      protected void gxLoad_5( int A386LBConBan )
      {
         /* Using cursor T005A11 */
         pr_default.execute(9, new Object[] {A386LBConBan});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto Libro Bancos'.", "ForeignKeyNotFound", 1, "LBCONBAN");
            AnyError = 1;
            GX_FocusControl = edtLBConBan_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1064LBDConcepto = T005A11_A1064LBDConcepto[0];
         AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
         A1058LBCueCod = T005A11_A1058LBCueCod[0];
         AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1064LBDConcepto))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1058LBCueCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_8( string A1058LBCueCod )
      {
         /* Using cursor T005A12 */
         pr_default.execute(10, new Object[] {A1058LBCueCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "LBCUECOD");
            AnyError = 1;
         }
         A1061LBCueMon = T005A12_A1061LBCueMon[0];
         A1059LBCueCos = T005A12_A1059LBCueCos[0];
         AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
         A1060LBCueDsc = T005A12_A1060LBCueDsc[0];
         AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
         A1090LBTipACod = T005A12_A1090LBTipACod[0];
         n1090LBTipACod = T005A12_n1090LBTipACod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1061LBCueMon), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1059LBCueCos), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1060LBCueDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1090LBTipACod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( int A385LBDForCod )
      {
         /* Using cursor T005A13 */
         pr_default.execute(11, new Object[] {n385LBDForCod, A385LBDForCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A385LBDForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LBDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_7( string A384LBDCosCod )
      {
         /* Using cursor T005A14 */
         pr_default.execute(12, new Object[] {n384LBDCosCod, A384LBDCosCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A384LBDCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "LBDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey5A177( )
      {
         /* Using cursor T005A15 */
         pr_default.execute(13, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro, A383LBDITem});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound177 = 1;
         }
         else
         {
            RcdFound177 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005A3 */
         pr_default.execute(1, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro, A383LBDITem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5A177( 3) ;
            RcdFound177 = 1;
            A383LBDITem = T005A3_A383LBDITem[0];
            AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
            A1092LBTipCod = T005A3_A1092LBTipCod[0];
            AssignAttri("", false, "A1092LBTipCod", A1092LBTipCod);
            A1068LBDDoc = T005A3_A1068LBDDoc[0];
            AssignAttri("", false, "A1068LBDDoc", A1068LBDDoc);
            A1067LBDDebe = T005A3_A1067LBDDebe[0];
            AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
            A1074LBDHaber = T005A3_A1074LBDHaber[0];
            AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
            A1087LBPrvCod = T005A3_A1087LBPrvCod[0];
            AssignAttri("", false, "A1087LBPrvCod", A1087LBPrvCod);
            A1066LBDCueCod = T005A3_A1066LBDCueCod[0];
            AssignAttri("", false, "A1066LBDCueCod", A1066LBDCueCod);
            A1065LBDCueAux = T005A3_A1065LBDCueAux[0];
            AssignAttri("", false, "A1065LBDCueAux", A1065LBDCueAux);
            A1076LBDPagReg = T005A3_A1076LBDPagReg[0];
            n1076LBDPagReg = T005A3_n1076LBDPagReg[0];
            AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrimStr( (decimal)(A1076LBDPagReg), 10, 0));
            A1077LBDTipCmb = T005A3_A1077LBDTipCmb[0];
            AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrimStr( A1077LBDTipCmb, 15, 5));
            A379LBBanCod = T005A3_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T005A3_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = T005A3_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            A386LBConBan = T005A3_A386LBConBan[0];
            AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
            A385LBDForCod = T005A3_A385LBDForCod[0];
            n385LBDForCod = T005A3_n385LBDForCod[0];
            AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
            A384LBDCosCod = T005A3_A384LBDCosCod[0];
            n384LBDCosCod = T005A3_n384LBDCosCod[0];
            AssignAttri("", false, "A384LBDCosCod", A384LBDCosCod);
            O1067LBDDebe = A1067LBDDebe;
            AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
            O1074LBDHaber = A1074LBDHaber;
            AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
            Z379LBBanCod = A379LBBanCod;
            Z380LBCBCod = A380LBCBCod;
            Z381LBRegistro = A381LBRegistro;
            Z383LBDITem = A383LBDITem;
            sMode177 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load5A177( ) ;
            if ( AnyError == 1 )
            {
               RcdFound177 = 0;
               InitializeNonKey5A177( ) ;
            }
            Gx_mode = sMode177;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound177 = 0;
            InitializeNonKey5A177( ) ;
            sMode177 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode177;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5A177( ) ;
         if ( RcdFound177 == 0 )
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
         RcdFound177 = 0;
         /* Using cursor T005A16 */
         pr_default.execute(14, new Object[] {A383LBDITem, A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T005A16_A383LBDITem[0] < A383LBDITem ) || ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( T005A16_A379LBBanCod[0] < A379LBBanCod ) || ( T005A16_A379LBBanCod[0] == A379LBBanCod ) && ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A16_A380LBCBCod[0], A380LBCBCod) < 0 ) || ( StringUtil.StrCmp(T005A16_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005A16_A379LBBanCod[0] == A379LBBanCod ) && ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A16_A381LBRegistro[0], A381LBRegistro) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T005A16_A383LBDITem[0] > A383LBDITem ) || ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( T005A16_A379LBBanCod[0] > A379LBBanCod ) || ( T005A16_A379LBBanCod[0] == A379LBBanCod ) && ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A16_A380LBCBCod[0], A380LBCBCod) > 0 ) || ( StringUtil.StrCmp(T005A16_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005A16_A379LBBanCod[0] == A379LBBanCod ) && ( T005A16_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A16_A381LBRegistro[0], A381LBRegistro) > 0 ) ) )
            {
               A383LBDITem = T005A16_A383LBDITem[0];
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
               A379LBBanCod = T005A16_A379LBBanCod[0];
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = T005A16_A380LBCBCod[0];
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = T005A16_A381LBRegistro[0];
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               RcdFound177 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound177 = 0;
         /* Using cursor T005A17 */
         pr_default.execute(15, new Object[] {A383LBDITem, A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T005A17_A383LBDITem[0] > A383LBDITem ) || ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( T005A17_A379LBBanCod[0] > A379LBBanCod ) || ( T005A17_A379LBBanCod[0] == A379LBBanCod ) && ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A17_A380LBCBCod[0], A380LBCBCod) > 0 ) || ( StringUtil.StrCmp(T005A17_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005A17_A379LBBanCod[0] == A379LBBanCod ) && ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A17_A381LBRegistro[0], A381LBRegistro) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T005A17_A383LBDITem[0] < A383LBDITem ) || ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( T005A17_A379LBBanCod[0] < A379LBBanCod ) || ( T005A17_A379LBBanCod[0] == A379LBBanCod ) && ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A17_A380LBCBCod[0], A380LBCBCod) < 0 ) || ( StringUtil.StrCmp(T005A17_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005A17_A379LBBanCod[0] == A379LBBanCod ) && ( T005A17_A383LBDITem[0] == A383LBDITem ) && ( StringUtil.StrCmp(T005A17_A381LBRegistro[0], A381LBRegistro) < 0 ) ) )
            {
               A383LBDITem = T005A17_A383LBDITem[0];
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
               A379LBBanCod = T005A17_A379LBBanCod[0];
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = T005A17_A380LBCBCod[0];
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = T005A17_A381LBRegistro[0];
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               RcdFound177 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5A177( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5A177( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound177 == 1 )
            {
               if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) || ( A383LBDITem != Z383LBDITem ) )
               {
                  A379LBBanCod = Z379LBBanCod;
                  AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
                  A380LBCBCod = Z380LBCBCod;
                  AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
                  A381LBRegistro = Z381LBRegistro;
                  AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
                  A383LBDITem = Z383LBDITem;
                  AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LBBANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update5A177( ) ;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) || ( A383LBDITem != Z383LBDITem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5A177( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LBBANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLBBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLBBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5A177( ) ;
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
         if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) || ( A383LBDITem != Z383LBDITem ) )
         {
            A379LBBanCod = Z379LBBanCod;
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = Z380LBCBCod;
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = Z381LBRegistro;
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            A383LBDITem = Z383LBDITem;
            AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLBBanCod_Internalname;
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
         GetKey5A177( ) ;
         if ( RcdFound177 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) || ( A383LBDITem != Z383LBDITem ) )
            {
               A379LBBanCod = Z379LBBanCod;
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = Z380LBCBCod;
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = Z381LBRegistro;
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               A383LBDITem = Z383LBDITem;
               AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
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
            if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) || ( A383LBDITem != Z383LBDITem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LBBANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLBBanCod_Internalname;
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
         context.RollbackDataStores("tslibrobancosdet",pr_default);
         GX_FocusControl = edtLBTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_5A0( ) ;
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
         if ( RcdFound177 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLBTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart5A177( ) ;
         if ( RcdFound177 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5A177( ) ;
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
         if ( RcdFound177 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBTipCod_Internalname;
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
         if ( RcdFound177 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBTipCod_Internalname;
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
         ScanStart5A177( ) ;
         if ( RcdFound177 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound177 != 0 )
            {
               ScanNext5A177( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5A177( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency5A177( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005A2 */
            pr_default.execute(0, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro, A383LBDITem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSLIBROBANCOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1092LBTipCod, T005A2_A1092LBTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1068LBDDoc, T005A2_A1068LBDDoc[0]) != 0 ) || ( Z1067LBDDebe != T005A2_A1067LBDDebe[0] ) || ( Z1074LBDHaber != T005A2_A1074LBDHaber[0] ) || ( StringUtil.StrCmp(Z1087LBPrvCod, T005A2_A1087LBPrvCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1066LBDCueCod, T005A2_A1066LBDCueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1065LBDCueAux, T005A2_A1065LBDCueAux[0]) != 0 ) || ( Z1076LBDPagReg != T005A2_A1076LBDPagReg[0] ) || ( Z1077LBDTipCmb != T005A2_A1077LBDTipCmb[0] ) || ( Z386LBConBan != T005A2_A386LBConBan[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z385LBDForCod != T005A2_A385LBDForCod[0] ) || ( StringUtil.StrCmp(Z384LBDCosCod, T005A2_A384LBDCosCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1092LBTipCod, T005A2_A1092LBTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z1092LBTipCod);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1092LBTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z1068LBDDoc, T005A2_A1068LBDDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1068LBDDoc);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1068LBDDoc[0]);
               }
               if ( Z1067LBDDebe != T005A2_A1067LBDDebe[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDDebe");
                  GXUtil.WriteLogRaw("Old: ",Z1067LBDDebe);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1067LBDDebe[0]);
               }
               if ( Z1074LBDHaber != T005A2_A1074LBDHaber[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDHaber");
                  GXUtil.WriteLogRaw("Old: ",Z1074LBDHaber);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1074LBDHaber[0]);
               }
               if ( StringUtil.StrCmp(Z1087LBPrvCod, T005A2_A1087LBPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z1087LBPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1087LBPrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z1066LBDCueCod, T005A2_A1066LBDCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z1066LBDCueCod);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1066LBDCueCod[0]);
               }
               if ( StringUtil.StrCmp(Z1065LBDCueAux, T005A2_A1065LBDCueAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDCueAux");
                  GXUtil.WriteLogRaw("Old: ",Z1065LBDCueAux);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1065LBDCueAux[0]);
               }
               if ( Z1076LBDPagReg != T005A2_A1076LBDPagReg[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDPagReg");
                  GXUtil.WriteLogRaw("Old: ",Z1076LBDPagReg);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1076LBDPagReg[0]);
               }
               if ( Z1077LBDTipCmb != T005A2_A1077LBDTipCmb[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1077LBDTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A1077LBDTipCmb[0]);
               }
               if ( Z386LBConBan != T005A2_A386LBConBan[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBConBan");
                  GXUtil.WriteLogRaw("Old: ",Z386LBConBan);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A386LBConBan[0]);
               }
               if ( Z385LBDForCod != T005A2_A385LBDForCod[0] )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDForCod");
                  GXUtil.WriteLogRaw("Old: ",Z385LBDForCod);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A385LBDForCod[0]);
               }
               if ( StringUtil.StrCmp(Z384LBDCosCod, T005A2_A384LBDCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancosdet:[seudo value changed for attri]"+"LBDCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z384LBDCosCod);
                  GXUtil.WriteLogRaw("Current: ",T005A2_A384LBDCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSLIBROBANCOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T005A18 */
         pr_default.execute(16, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(16) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSLIBROBANCOS"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSLIBROBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5A177( )
      {
         BeforeValidate5A177( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5A177( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5A177( 0) ;
            CheckOptimisticConcurrency5A177( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5A177( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5A177( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005A19 */
                     pr_default.execute(17, new Object[] {A383LBDITem, A1092LBTipCod, A1068LBDDoc, A1067LBDDebe, A1074LBDHaber, A1087LBPrvCod, A1066LBDCueCod, A1065LBDCueAux, n1076LBDPagReg, A1076LBDPagReg, A1077LBDTipCmb, A379LBBanCod, A380LBCBCod, A381LBRegistro, A386LBConBan, n385LBDForCod, A385LBDForCod, n384LBDCosCod, A384LBDCosCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOSDET");
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN15A177( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption5A0( ) ;
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
               Load5A177( ) ;
            }
            EndLevel5A177( ) ;
         }
         CloseExtendedTableCursors5A177( ) ;
      }

      protected void Update5A177( )
      {
         BeforeValidate5A177( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5A177( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5A177( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5A177( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5A177( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005A20 */
                     pr_default.execute(18, new Object[] {A1092LBTipCod, A1068LBDDoc, A1067LBDDebe, A1074LBDHaber, A1087LBPrvCod, A1066LBDCueCod, A1065LBDCueAux, n1076LBDPagReg, A1076LBDPagReg, A1077LBDTipCmb, A386LBConBan, n385LBDForCod, A385LBDForCod, n384LBDCosCod, A384LBDCosCod, A379LBBanCod, A380LBCBCod, A381LBRegistro, A383LBDITem});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOSDET");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSLIBROBANCOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5A177( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN15A177( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption5A0( ) ;
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
            EndLevel5A177( ) ;
         }
         CloseExtendedTableCursors5A177( ) ;
      }

      protected void DeferredUpdate5A177( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate5A177( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5A177( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5A177( ) ;
            AfterConfirm5A177( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5A177( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005A21 */
                  pr_default.execute(19, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro, A383LBDITem});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOSDET");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN15A177( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound177 == 0 )
                        {
                           InitAll5A177( ) ;
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
                        ResetCaption5A0( ) ;
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
         sMode177 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5A177( ) ;
         Gx_mode = sMode177;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5A177( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005A22 */
            pr_default.execute(20, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            A1073LBTHaber = T005A22_A1073LBTHaber[0];
            A1072LBTDebe = T005A22_A1072LBTDebe[0];
            O1072LBTDebe = A1072LBTDebe;
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            O1073LBTHaber = A1073LBTHaber;
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            pr_default.close(20);
            if ( IsIns( )  )
            {
               A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe);
               AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe-O1067LBDDebe);
                  AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A1072LBTDebe = (decimal)(O1072LBTDebe-O1067LBDDebe);
                     AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
                  }
               }
            }
            if ( IsIns( )  )
            {
               A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber);
               AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber-O1074LBDHaber);
                  AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A1073LBTHaber = (decimal)(O1073LBTHaber-O1074LBDHaber);
                     AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
                  }
               }
            }
            /* Using cursor T005A23 */
            pr_default.execute(21, new Object[] {A386LBConBan});
            A1064LBDConcepto = T005A23_A1064LBDConcepto[0];
            AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
            A1058LBCueCod = T005A23_A1058LBCueCod[0];
            AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
            pr_default.close(21);
            /* Using cursor T005A24 */
            pr_default.execute(22, new Object[] {A1058LBCueCod});
            A1061LBCueMon = T005A24_A1061LBCueMon[0];
            A1059LBCueCos = T005A24_A1059LBCueCos[0];
            AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
            A1060LBCueDsc = T005A24_A1060LBCueDsc[0];
            AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
            A1090LBTipACod = T005A24_A1090LBTipACod[0];
            n1090LBTipACod = T005A24_n1090LBTipACod[0];
            pr_default.close(22);
         }
      }

      protected void UpdateTablesN15A177( )
      {
         /* Using cursor T005A25 */
         pr_default.execute(23, new Object[] {A1073LBTHaber, A1072LBTDebe, A379LBBanCod, A380LBCBCod, A381LBRegistro});
         pr_default.close(23);
         dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOS");
      }

      protected void EndLevel5A177( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(16);
         if ( AnyError == 0 )
         {
            BeforeComplete5A177( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.CommitDataStores("tslibrobancosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.RollbackDataStores("tslibrobancosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5A177( )
      {
         /* Using cursor T005A26 */
         pr_default.execute(24);
         RcdFound177 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound177 = 1;
            A379LBBanCod = T005A26_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T005A26_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = T005A26_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            A383LBDITem = T005A26_A383LBDITem[0];
            AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5A177( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound177 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound177 = 1;
            A379LBBanCod = T005A26_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T005A26_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = T005A26_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            A383LBDITem = T005A26_A383LBDITem[0];
            AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
         }
      }

      protected void ScanEnd5A177( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm5A177( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5A177( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5A177( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5A177( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5A177( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5A177( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5A177( )
      {
         edtLBBanCod_Enabled = 0;
         AssignProp("", false, edtLBBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBBanCod_Enabled), 5, 0), true);
         edtLBCBCod_Enabled = 0;
         AssignProp("", false, edtLBCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCBCod_Enabled), 5, 0), true);
         edtLBRegistro_Enabled = 0;
         AssignProp("", false, edtLBRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBRegistro_Enabled), 5, 0), true);
         edtLBDITem_Enabled = 0;
         AssignProp("", false, edtLBDITem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDITem_Enabled), 5, 0), true);
         edtLBTipCod_Enabled = 0;
         AssignProp("", false, edtLBTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTipCod_Enabled), 5, 0), true);
         edtLBDDoc_Enabled = 0;
         AssignProp("", false, edtLBDDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDDoc_Enabled), 5, 0), true);
         edtLBDDebe_Enabled = 0;
         AssignProp("", false, edtLBDDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDDebe_Enabled), 5, 0), true);
         edtLBDHaber_Enabled = 0;
         AssignProp("", false, edtLBDHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDHaber_Enabled), 5, 0), true);
         edtLBConBan_Enabled = 0;
         AssignProp("", false, edtLBConBan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBConBan_Enabled), 5, 0), true);
         edtLBPrvCod_Enabled = 0;
         AssignProp("", false, edtLBPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBPrvCod_Enabled), 5, 0), true);
         edtLBDCueCod_Enabled = 0;
         AssignProp("", false, edtLBDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDCueCod_Enabled), 5, 0), true);
         edtLBDCueAux_Enabled = 0;
         AssignProp("", false, edtLBDCueAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDCueAux_Enabled), 5, 0), true);
         edtLBDForCod_Enabled = 0;
         AssignProp("", false, edtLBDForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDForCod_Enabled), 5, 0), true);
         edtLBDPagReg_Enabled = 0;
         AssignProp("", false, edtLBDPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDPagReg_Enabled), 5, 0), true);
         edtLBDCosCod_Enabled = 0;
         AssignProp("", false, edtLBDCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDCosCod_Enabled), 5, 0), true);
         edtLBDTipCmb_Enabled = 0;
         AssignProp("", false, edtLBDTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDTipCmb_Enabled), 5, 0), true);
         edtLBCueCod_Enabled = 0;
         AssignProp("", false, edtLBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCueCod_Enabled), 5, 0), true);
         edtLBDConcepto_Enabled = 0;
         AssignProp("", false, edtLBDConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDConcepto_Enabled), 5, 0), true);
         edtLBCueCos_Enabled = 0;
         AssignProp("", false, edtLBCueCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCueCos_Enabled), 5, 0), true);
         edtLBCueDsc_Enabled = 0;
         AssignProp("", false, edtLBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5A177( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255482", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tslibrobancosdet.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z379LBBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z379LBBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z380LBCBCod", StringUtil.RTrim( Z380LBCBCod));
         GxWebStd.gx_hidden_field( context, "Z381LBRegistro", StringUtil.RTrim( Z381LBRegistro));
         GxWebStd.gx_hidden_field( context, "Z383LBDITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z383LBDITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1092LBTipCod", StringUtil.RTrim( Z1092LBTipCod));
         GxWebStd.gx_hidden_field( context, "Z1068LBDDoc", StringUtil.RTrim( Z1068LBDDoc));
         GxWebStd.gx_hidden_field( context, "Z1067LBDDebe", StringUtil.LTrim( StringUtil.NToC( Z1067LBDDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1074LBDHaber", StringUtil.LTrim( StringUtil.NToC( Z1074LBDHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1087LBPrvCod", StringUtil.RTrim( Z1087LBPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1066LBDCueCod", StringUtil.RTrim( Z1066LBDCueCod));
         GxWebStd.gx_hidden_field( context, "Z1065LBDCueAux", StringUtil.RTrim( Z1065LBDCueAux));
         GxWebStd.gx_hidden_field( context, "Z1076LBDPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1076LBDPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1077LBDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1077LBDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z386LBConBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z386LBConBan), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z385LBDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z385LBDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z384LBDCosCod", StringUtil.RTrim( Z384LBDCosCod));
         GxWebStd.gx_hidden_field( context, "O1067LBDDebe", StringUtil.LTrim( StringUtil.NToC( O1067LBDDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "O1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( O1072LBTDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "O1074LBDHaber", StringUtil.LTrim( StringUtil.NToC( O1074LBDHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "O1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( O1073LBTHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "LBTHABER", StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LBTDEBE", StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LBCUEMON", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1061LBCueMon), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LBTIPACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1090LBTipACod), 6, 0, ".", "")));
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
         return formatLink("tslibrobancosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSLIBROBANCOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Libro Bancos - Detalle" ;
      }

      protected void InitializeNonKey5A177( )
      {
         A1073LBTHaber = 0;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         A1072LBTDebe = 0;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         A1092LBTipCod = "";
         AssignAttri("", false, "A1092LBTipCod", A1092LBTipCod);
         A1068LBDDoc = "";
         AssignAttri("", false, "A1068LBDDoc", A1068LBDDoc);
         A1067LBDDebe = 0;
         AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
         A1074LBDHaber = 0;
         AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
         A386LBConBan = 0;
         AssignAttri("", false, "A386LBConBan", StringUtil.LTrimStr( (decimal)(A386LBConBan), 6, 0));
         A1087LBPrvCod = "";
         AssignAttri("", false, "A1087LBPrvCod", A1087LBPrvCod);
         A1066LBDCueCod = "";
         AssignAttri("", false, "A1066LBDCueCod", A1066LBDCueCod);
         A1065LBDCueAux = "";
         AssignAttri("", false, "A1065LBDCueAux", A1065LBDCueAux);
         A1061LBCueMon = 0;
         AssignAttri("", false, "A1061LBCueMon", StringUtil.Str( (decimal)(A1061LBCueMon), 1, 0));
         A385LBDForCod = 0;
         n385LBDForCod = false;
         AssignAttri("", false, "A385LBDForCod", StringUtil.LTrimStr( (decimal)(A385LBDForCod), 6, 0));
         n385LBDForCod = ((0==A385LBDForCod) ? true : false);
         A1076LBDPagReg = 0;
         n1076LBDPagReg = false;
         AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrimStr( (decimal)(A1076LBDPagReg), 10, 0));
         n1076LBDPagReg = ((0==A1076LBDPagReg) ? true : false);
         A384LBDCosCod = "";
         n384LBDCosCod = false;
         AssignAttri("", false, "A384LBDCosCod", A384LBDCosCod);
         A1077LBDTipCmb = 0;
         AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrimStr( A1077LBDTipCmb, 15, 5));
         A1058LBCueCod = "";
         AssignAttri("", false, "A1058LBCueCod", A1058LBCueCod);
         A1090LBTipACod = 0;
         n1090LBTipACod = false;
         AssignAttri("", false, "A1090LBTipACod", StringUtil.LTrimStr( (decimal)(A1090LBTipACod), 6, 0));
         A1064LBDConcepto = "";
         AssignAttri("", false, "A1064LBDConcepto", A1064LBDConcepto);
         A1059LBCueCos = 0;
         AssignAttri("", false, "A1059LBCueCos", StringUtil.Str( (decimal)(A1059LBCueCos), 1, 0));
         A1060LBCueDsc = "";
         AssignAttri("", false, "A1060LBCueDsc", A1060LBCueDsc);
         O1067LBDDebe = A1067LBDDebe;
         AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrimStr( A1067LBDDebe, 15, 2));
         O1072LBTDebe = A1072LBTDebe;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         O1074LBDHaber = A1074LBDHaber;
         AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrimStr( A1074LBDHaber, 15, 2));
         O1073LBTHaber = A1073LBTHaber;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         Z1092LBTipCod = "";
         Z1068LBDDoc = "";
         Z1067LBDDebe = 0;
         Z1074LBDHaber = 0;
         Z1087LBPrvCod = "";
         Z1066LBDCueCod = "";
         Z1065LBDCueAux = "";
         Z1076LBDPagReg = 0;
         Z1077LBDTipCmb = 0;
         Z386LBConBan = 0;
         Z385LBDForCod = 0;
         Z384LBDCosCod = "";
      }

      protected void InitAll5A177( )
      {
         A379LBBanCod = 0;
         AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
         A380LBCBCod = "";
         AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
         A381LBRegistro = "";
         AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
         A383LBDITem = 0;
         AssignAttri("", false, "A383LBDITem", StringUtil.LTrimStr( (decimal)(A383LBDITem), 6, 0));
         InitializeNonKey5A177( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025551", true, true);
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
         context.AddJavascriptSource("tslibrobancosdet.js", "?20228181025552", false, true);
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
         edtLBBanCod_Internalname = "LBBANCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLBCBCod_Internalname = "LBCBCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLBRegistro_Internalname = "LBREGISTRO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLBDITem_Internalname = "LBDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLBTipCod_Internalname = "LBTIPCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLBDDoc_Internalname = "LBDDOC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLBDDebe_Internalname = "LBDDEBE";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLBDHaber_Internalname = "LBDHABER";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLBConBan_Internalname = "LBCONBAN";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLBPrvCod_Internalname = "LBPRVCOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtLBDCueCod_Internalname = "LBDCUECOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtLBDCueAux_Internalname = "LBDCUEAUX";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLBDForCod_Internalname = "LBDFORCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtLBDPagReg_Internalname = "LBDPAGREG";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtLBDCosCod_Internalname = "LBDCOSCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtLBDTipCmb_Internalname = "LBDTIPCMB";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtLBCueCod_Internalname = "LBCUECOD";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtLBDConcepto_Internalname = "LBDCONCEPTO";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtLBCueCos_Internalname = "LBCUECOS";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtLBCueDsc_Internalname = "LBCUEDSC";
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
         Form.Caption = "Libro Bancos - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLBCueDsc_Jsonclick = "";
         edtLBCueDsc_Enabled = 0;
         edtLBCueCos_Jsonclick = "";
         edtLBCueCos_Enabled = 0;
         edtLBDConcepto_Jsonclick = "";
         edtLBDConcepto_Enabled = 0;
         edtLBCueCod_Jsonclick = "";
         edtLBCueCod_Enabled = 0;
         edtLBDTipCmb_Jsonclick = "";
         edtLBDTipCmb_Enabled = 1;
         edtLBDCosCod_Jsonclick = "";
         edtLBDCosCod_Enabled = 1;
         edtLBDPagReg_Jsonclick = "";
         edtLBDPagReg_Enabled = 1;
         edtLBDForCod_Jsonclick = "";
         edtLBDForCod_Enabled = 1;
         edtLBDCueAux_Jsonclick = "";
         edtLBDCueAux_Enabled = 1;
         edtLBDCueCod_Jsonclick = "";
         edtLBDCueCod_Enabled = 1;
         edtLBPrvCod_Jsonclick = "";
         edtLBPrvCod_Enabled = 1;
         edtLBConBan_Jsonclick = "";
         edtLBConBan_Enabled = 1;
         edtLBDHaber_Jsonclick = "";
         edtLBDHaber_Enabled = 1;
         edtLBDDebe_Jsonclick = "";
         edtLBDDebe_Enabled = 1;
         edtLBDDoc_Jsonclick = "";
         edtLBDDoc_Enabled = 1;
         edtLBTipCod_Jsonclick = "";
         edtLBTipCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLBDITem_Jsonclick = "";
         edtLBDITem_Enabled = 1;
         edtLBRegistro_Jsonclick = "";
         edtLBRegistro_Enabled = 1;
         edtLBCBCod_Jsonclick = "";
         edtLBCBCod_Enabled = 1;
         edtLBBanCod_Jsonclick = "";
         edtLBBanCod_Enabled = 1;
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
         /* Using cursor T005A22 */
         pr_default.execute(20, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Libro Bancos'.", "ForeignKeyNotFound", 1, "LBREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1073LBTHaber = T005A22_A1073LBTHaber[0];
         A1072LBTDebe = T005A22_A1072LBTDebe[0];
         pr_default.close(20);
         GX_FocusControl = edtLBTipCod_Internalname;
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

      public void Valid_Lbregistro( )
      {
         /* Using cursor T005A22 */
         pr_default.execute(20, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Libro Bancos'.", "ForeignKeyNotFound", 1, "LBREGISTRO");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
         }
         A1073LBTHaber = T005A22_A1073LBTHaber[0];
         A1072LBTDebe = T005A22_A1072LBTDebe[0];
         O1072LBTDebe = A1072LBTDebe;
         O1073LBTHaber = A1073LBTHaber;
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( O1073LBTHaber, 15, 2, ".", "")));
         AssignAttri("", false, "O1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( O1072LBTDebe, 15, 2, ".", "")));
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")));
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")));
      }

      public void Valid_Lbditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1092LBTipCod", StringUtil.RTrim( A1092LBTipCod));
         AssignAttri("", false, "A1068LBDDoc", StringUtil.RTrim( A1068LBDDoc));
         AssignAttri("", false, "A1067LBDDebe", StringUtil.LTrim( StringUtil.NToC( A1067LBDDebe, 15, 2, ".", "")));
         AssignAttri("", false, "A1074LBDHaber", StringUtil.LTrim( StringUtil.NToC( A1074LBDHaber, 15, 2, ".", "")));
         AssignAttri("", false, "A386LBConBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(A386LBConBan), 6, 0, ".", "")));
         AssignAttri("", false, "A1087LBPrvCod", StringUtil.RTrim( A1087LBPrvCod));
         AssignAttri("", false, "A1066LBDCueCod", StringUtil.RTrim( A1066LBDCueCod));
         AssignAttri("", false, "A1065LBDCueAux", StringUtil.RTrim( A1065LBDCueAux));
         AssignAttri("", false, "A385LBDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A385LBDForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1076LBDPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1076LBDPagReg), 10, 0, ".", "")));
         AssignAttri("", false, "A384LBDCosCod", StringUtil.RTrim( A384LBDCosCod));
         AssignAttri("", false, "A1077LBDTipCmb", StringUtil.LTrim( StringUtil.NToC( A1077LBDTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")));
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")));
         AssignAttri("", false, "A1064LBDConcepto", StringUtil.RTrim( A1064LBDConcepto));
         AssignAttri("", false, "A1058LBCueCod", StringUtil.RTrim( A1058LBCueCod));
         AssignAttri("", false, "A1061LBCueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1061LBCueMon), 1, 0, ".", "")));
         AssignAttri("", false, "A1059LBCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1059LBCueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A1060LBCueDsc", StringUtil.RTrim( A1060LBCueDsc));
         AssignAttri("", false, "A1090LBTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1090LBTipACod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z379LBBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z379LBBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z380LBCBCod", StringUtil.RTrim( Z380LBCBCod));
         GxWebStd.gx_hidden_field( context, "Z381LBRegistro", StringUtil.RTrim( Z381LBRegistro));
         GxWebStd.gx_hidden_field( context, "Z383LBDITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z383LBDITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1092LBTipCod", StringUtil.RTrim( Z1092LBTipCod));
         GxWebStd.gx_hidden_field( context, "Z1068LBDDoc", StringUtil.RTrim( Z1068LBDDoc));
         GxWebStd.gx_hidden_field( context, "Z1067LBDDebe", StringUtil.LTrim( StringUtil.NToC( Z1067LBDDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1074LBDHaber", StringUtil.LTrim( StringUtil.NToC( Z1074LBDHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z386LBConBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z386LBConBan), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1087LBPrvCod", StringUtil.RTrim( Z1087LBPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1066LBDCueCod", StringUtil.RTrim( Z1066LBDCueCod));
         GxWebStd.gx_hidden_field( context, "Z1065LBDCueAux", StringUtil.RTrim( Z1065LBDCueAux));
         GxWebStd.gx_hidden_field( context, "Z385LBDForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z385LBDForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1076LBDPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1076LBDPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z384LBDCosCod", StringUtil.RTrim( Z384LBDCosCod));
         GxWebStd.gx_hidden_field( context, "Z1077LBDTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1077LBDTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( Z1073LBTHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( Z1072LBTDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1064LBDConcepto", StringUtil.RTrim( Z1064LBDConcepto));
         GxWebStd.gx_hidden_field( context, "Z1058LBCueCod", StringUtil.RTrim( Z1058LBCueCod));
         GxWebStd.gx_hidden_field( context, "Z1061LBCueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1061LBCueMon), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1059LBCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1059LBCueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1060LBCueDsc", StringUtil.RTrim( Z1060LBCueDsc));
         GxWebStd.gx_hidden_field( context, "Z1090LBTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1090LBTipACod), 6, 0, ".", "")));
         AssignAttri("", false, "O1067LBDDebe", StringUtil.LTrim( StringUtil.NToC( O1067LBDDebe, 15, 2, ".", "")));
         AssignAttri("", false, "O1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( O1072LBTDebe, 15, 2, ".", "")));
         AssignAttri("", false, "O1074LBDHaber", StringUtil.LTrim( StringUtil.NToC( O1074LBDHaber, 15, 2, ".", "")));
         AssignAttri("", false, "O1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( O1073LBTHaber, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Lbconban( )
      {
         n1090LBTipACod = false;
         /* Using cursor T005A23 */
         pr_default.execute(21, new Object[] {A386LBConBan});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto Libro Bancos'.", "ForeignKeyNotFound", 1, "LBCONBAN");
            AnyError = 1;
            GX_FocusControl = edtLBConBan_Internalname;
         }
         A1064LBDConcepto = T005A23_A1064LBDConcepto[0];
         A1058LBCueCod = T005A23_A1058LBCueCod[0];
         pr_default.close(21);
         /* Using cursor T005A24 */
         pr_default.execute(22, new Object[] {A1058LBCueCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "LBCUECOD");
            AnyError = 1;
         }
         A1061LBCueMon = T005A24_A1061LBCueMon[0];
         A1059LBCueCos = T005A24_A1059LBCueCos[0];
         A1060LBCueDsc = T005A24_A1060LBCueDsc[0];
         A1090LBTipACod = T005A24_A1090LBTipACod[0];
         n1090LBTipACod = T005A24_n1090LBTipACod[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1064LBDConcepto", StringUtil.RTrim( A1064LBDConcepto));
         AssignAttri("", false, "A1058LBCueCod", StringUtil.RTrim( A1058LBCueCod));
         AssignAttri("", false, "A1061LBCueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1061LBCueMon), 1, 0, ".", "")));
         AssignAttri("", false, "A1059LBCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1059LBCueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A1060LBCueDsc", StringUtil.RTrim( A1060LBCueDsc));
         AssignAttri("", false, "A1090LBTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1090LBTipACod), 6, 0, ".", "")));
      }

      public void Valid_Lbdforcod( )
      {
         n385LBDForCod = false;
         /* Using cursor T005A27 */
         pr_default.execute(25, new Object[] {n385LBDForCod, A385LBDForCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A385LBDForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LBDFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDForCod_Internalname;
            }
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Lbdcoscod( )
      {
         n384LBDCosCod = false;
         /* Using cursor T005A28 */
         pr_default.execute(26, new Object[] {n384LBDCosCod, A384LBDCosCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A384LBDCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "LBDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtLBDCosCod_Internalname;
            }
         }
         pr_default.close(26);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_LBBANCOD","{handler:'Valid_Lbbancod',iparms:[]");
         setEventMetadata("VALID_LBBANCOD",",oparms:[]}");
         setEventMetadata("VALID_LBCBCOD","{handler:'Valid_Lbcbcod',iparms:[]");
         setEventMetadata("VALID_LBCBCOD",",oparms:[]}");
         setEventMetadata("VALID_LBREGISTRO","{handler:'Valid_Lbregistro',iparms:[{av:'A379LBBanCod',fld:'LBBANCOD',pic:'ZZZZZ9'},{av:'A380LBCBCod',fld:'LBCBCOD',pic:''},{av:'A381LBRegistro',fld:'LBREGISTRO',pic:''},{av:'A1073LBTHaber',fld:'LBTHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1072LBTDebe',fld:'LBTDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("VALID_LBREGISTRO",",oparms:[{av:'O1073LBTHaber'},{av:'O1072LBTDebe'},{av:'A1073LBTHaber',fld:'LBTHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1072LBTDebe',fld:'LBTDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]}");
         setEventMetadata("VALID_LBDITEM","{handler:'Valid_Lbditem',iparms:[{av:'A379LBBanCod',fld:'LBBANCOD',pic:'ZZZZZ9'},{av:'A380LBCBCod',fld:'LBCBCOD',pic:''},{av:'A381LBRegistro',fld:'LBREGISTRO',pic:''},{av:'A383LBDITem',fld:'LBDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LBDITEM",",oparms:[{av:'A1092LBTipCod',fld:'LBTIPCOD',pic:''},{av:'A1068LBDDoc',fld:'LBDDOC',pic:''},{av:'A1067LBDDebe',fld:'LBDDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1074LBDHaber',fld:'LBDHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A386LBConBan',fld:'LBCONBAN',pic:'ZZZZZ9'},{av:'A1087LBPrvCod',fld:'LBPRVCOD',pic:''},{av:'A1066LBDCueCod',fld:'LBDCUECOD',pic:''},{av:'A1065LBDCueAux',fld:'LBDCUEAUX',pic:''},{av:'A385LBDForCod',fld:'LBDFORCOD',pic:'ZZZZZ9'},{av:'A1076LBDPagReg',fld:'LBDPAGREG',pic:'ZZZZZZZZZ9'},{av:'A384LBDCosCod',fld:'LBDCOSCOD',pic:''},{av:'A1077LBDTipCmb',fld:'LBDTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1073LBTHaber',fld:'LBTHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1072LBTDebe',fld:'LBTDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1064LBDConcepto',fld:'LBDCONCEPTO',pic:''},{av:'A1058LBCueCod',fld:'LBCUECOD',pic:''},{av:'A1061LBCueMon',fld:'LBCUEMON',pic:'9'},{av:'A1059LBCueCos',fld:'LBCUECOS',pic:'9'},{av:'A1060LBCueDsc',fld:'LBCUEDSC',pic:''},{av:'A1090LBTipACod',fld:'LBTIPACOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z379LBBanCod'},{av:'Z380LBCBCod'},{av:'Z381LBRegistro'},{av:'Z383LBDITem'},{av:'Z1092LBTipCod'},{av:'Z1068LBDDoc'},{av:'Z1067LBDDebe'},{av:'Z1074LBDHaber'},{av:'Z386LBConBan'},{av:'Z1087LBPrvCod'},{av:'Z1066LBDCueCod'},{av:'Z1065LBDCueAux'},{av:'Z385LBDForCod'},{av:'Z1076LBDPagReg'},{av:'Z384LBDCosCod'},{av:'Z1077LBDTipCmb'},{av:'Z1073LBTHaber'},{av:'Z1072LBTDebe'},{av:'Z1064LBDConcepto'},{av:'Z1058LBCueCod'},{av:'Z1061LBCueMon'},{av:'Z1059LBCueCos'},{av:'Z1060LBCueDsc'},{av:'Z1090LBTipACod'},{av:'O1067LBDDebe'},{av:'O1072LBTDebe'},{av:'O1074LBDHaber'},{av:'O1073LBTHaber'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LBDDEBE","{handler:'Valid_Lbddebe',iparms:[]");
         setEventMetadata("VALID_LBDDEBE",",oparms:[]}");
         setEventMetadata("VALID_LBDHABER","{handler:'Valid_Lbdhaber',iparms:[]");
         setEventMetadata("VALID_LBDHABER",",oparms:[]}");
         setEventMetadata("VALID_LBCONBAN","{handler:'Valid_Lbconban',iparms:[{av:'A386LBConBan',fld:'LBCONBAN',pic:'ZZZZZ9'},{av:'A1058LBCueCod',fld:'LBCUECOD',pic:''},{av:'A1064LBDConcepto',fld:'LBDCONCEPTO',pic:''},{av:'A1061LBCueMon',fld:'LBCUEMON',pic:'9'},{av:'A1059LBCueCos',fld:'LBCUECOS',pic:'9'},{av:'A1060LBCueDsc',fld:'LBCUEDSC',pic:''},{av:'A1090LBTipACod',fld:'LBTIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LBCONBAN",",oparms:[{av:'A1064LBDConcepto',fld:'LBDCONCEPTO',pic:''},{av:'A1058LBCueCod',fld:'LBCUECOD',pic:''},{av:'A1061LBCueMon',fld:'LBCUEMON',pic:'9'},{av:'A1059LBCueCos',fld:'LBCUECOS',pic:'9'},{av:'A1060LBCueDsc',fld:'LBCUEDSC',pic:''},{av:'A1090LBTipACod',fld:'LBTIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_LBDFORCOD","{handler:'Valid_Lbdforcod',iparms:[{av:'A385LBDForCod',fld:'LBDFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LBDFORCOD",",oparms:[]}");
         setEventMetadata("VALID_LBDCOSCOD","{handler:'Valid_Lbdcoscod',iparms:[{av:'A384LBDCosCod',fld:'LBDCOSCOD',pic:''}]");
         setEventMetadata("VALID_LBDCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_LBCUECOD","{handler:'Valid_Lbcuecod',iparms:[]");
         setEventMetadata("VALID_LBCUECOD",",oparms:[]}");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z380LBCBCod = "";
         Z381LBRegistro = "";
         Z1092LBTipCod = "";
         Z1068LBDDoc = "";
         Z1087LBPrvCod = "";
         Z1066LBDCueCod = "";
         Z1065LBDCueAux = "";
         Z384LBDCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A380LBCBCod = "";
         A381LBRegistro = "";
         A1058LBCueCod = "";
         A384LBDCosCod = "";
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
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A1092LBTipCod = "";
         lblTextblock6_Jsonclick = "";
         A1068LBDDoc = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1087LBPrvCod = "";
         lblTextblock11_Jsonclick = "";
         A1066LBDCueCod = "";
         lblTextblock12_Jsonclick = "";
         A1065LBDCueAux = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A1064LBDConcepto = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         A1060LBCueDsc = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1064LBDConcepto = "";
         Z1058LBCueCod = "";
         Z1060LBCueDsc = "";
         T005A10_A1073LBTHaber = new decimal[1] ;
         T005A10_A1072LBTDebe = new decimal[1] ;
         T005A10_A383LBDITem = new int[1] ;
         T005A10_A1092LBTipCod = new string[] {""} ;
         T005A10_A1068LBDDoc = new string[] {""} ;
         T005A10_A1067LBDDebe = new decimal[1] ;
         T005A10_A1074LBDHaber = new decimal[1] ;
         T005A10_A1087LBPrvCod = new string[] {""} ;
         T005A10_A1066LBDCueCod = new string[] {""} ;
         T005A10_A1065LBDCueAux = new string[] {""} ;
         T005A10_A1061LBCueMon = new short[1] ;
         T005A10_A1076LBDPagReg = new long[1] ;
         T005A10_n1076LBDPagReg = new bool[] {false} ;
         T005A10_A1077LBDTipCmb = new decimal[1] ;
         T005A10_A1064LBDConcepto = new string[] {""} ;
         T005A10_A1059LBCueCos = new short[1] ;
         T005A10_A1060LBCueDsc = new string[] {""} ;
         T005A10_A379LBBanCod = new int[1] ;
         T005A10_A380LBCBCod = new string[] {""} ;
         T005A10_A381LBRegistro = new string[] {""} ;
         T005A10_A386LBConBan = new int[1] ;
         T005A10_A385LBDForCod = new int[1] ;
         T005A10_n385LBDForCod = new bool[] {false} ;
         T005A10_A384LBDCosCod = new string[] {""} ;
         T005A10_n384LBDCosCod = new bool[] {false} ;
         T005A10_A1058LBCueCod = new string[] {""} ;
         T005A10_A1090LBTipACod = new int[1] ;
         T005A10_n1090LBTipACod = new bool[] {false} ;
         T005A5_A1073LBTHaber = new decimal[1] ;
         T005A5_A1072LBTDebe = new decimal[1] ;
         T005A6_A1064LBDConcepto = new string[] {""} ;
         T005A6_A1058LBCueCod = new string[] {""} ;
         T005A9_A1061LBCueMon = new short[1] ;
         T005A9_A1059LBCueCos = new short[1] ;
         T005A9_A1060LBCueDsc = new string[] {""} ;
         T005A9_A1090LBTipACod = new int[1] ;
         T005A9_n1090LBTipACod = new bool[] {false} ;
         T005A7_A385LBDForCod = new int[1] ;
         T005A7_n385LBDForCod = new bool[] {false} ;
         T005A8_A384LBDCosCod = new string[] {""} ;
         T005A8_n384LBDCosCod = new bool[] {false} ;
         T005A11_A1064LBDConcepto = new string[] {""} ;
         T005A11_A1058LBCueCod = new string[] {""} ;
         T005A12_A1061LBCueMon = new short[1] ;
         T005A12_A1059LBCueCos = new short[1] ;
         T005A12_A1060LBCueDsc = new string[] {""} ;
         T005A12_A1090LBTipACod = new int[1] ;
         T005A12_n1090LBTipACod = new bool[] {false} ;
         T005A13_A385LBDForCod = new int[1] ;
         T005A13_n385LBDForCod = new bool[] {false} ;
         T005A14_A384LBDCosCod = new string[] {""} ;
         T005A14_n384LBDCosCod = new bool[] {false} ;
         T005A15_A379LBBanCod = new int[1] ;
         T005A15_A380LBCBCod = new string[] {""} ;
         T005A15_A381LBRegistro = new string[] {""} ;
         T005A15_A383LBDITem = new int[1] ;
         T005A3_A383LBDITem = new int[1] ;
         T005A3_A1092LBTipCod = new string[] {""} ;
         T005A3_A1068LBDDoc = new string[] {""} ;
         T005A3_A1067LBDDebe = new decimal[1] ;
         T005A3_A1074LBDHaber = new decimal[1] ;
         T005A3_A1087LBPrvCod = new string[] {""} ;
         T005A3_A1066LBDCueCod = new string[] {""} ;
         T005A3_A1065LBDCueAux = new string[] {""} ;
         T005A3_A1076LBDPagReg = new long[1] ;
         T005A3_n1076LBDPagReg = new bool[] {false} ;
         T005A3_A1077LBDTipCmb = new decimal[1] ;
         T005A3_A379LBBanCod = new int[1] ;
         T005A3_A380LBCBCod = new string[] {""} ;
         T005A3_A381LBRegistro = new string[] {""} ;
         T005A3_A386LBConBan = new int[1] ;
         T005A3_A385LBDForCod = new int[1] ;
         T005A3_n385LBDForCod = new bool[] {false} ;
         T005A3_A384LBDCosCod = new string[] {""} ;
         T005A3_n384LBDCosCod = new bool[] {false} ;
         sMode177 = "";
         T005A16_A383LBDITem = new int[1] ;
         T005A16_A379LBBanCod = new int[1] ;
         T005A16_A380LBCBCod = new string[] {""} ;
         T005A16_A381LBRegistro = new string[] {""} ;
         T005A17_A383LBDITem = new int[1] ;
         T005A17_A379LBBanCod = new int[1] ;
         T005A17_A380LBCBCod = new string[] {""} ;
         T005A17_A381LBRegistro = new string[] {""} ;
         T005A2_A383LBDITem = new int[1] ;
         T005A2_A1092LBTipCod = new string[] {""} ;
         T005A2_A1068LBDDoc = new string[] {""} ;
         T005A2_A1067LBDDebe = new decimal[1] ;
         T005A2_A1074LBDHaber = new decimal[1] ;
         T005A2_A1087LBPrvCod = new string[] {""} ;
         T005A2_A1066LBDCueCod = new string[] {""} ;
         T005A2_A1065LBDCueAux = new string[] {""} ;
         T005A2_A1076LBDPagReg = new long[1] ;
         T005A2_n1076LBDPagReg = new bool[] {false} ;
         T005A2_A1077LBDTipCmb = new decimal[1] ;
         T005A2_A379LBBanCod = new int[1] ;
         T005A2_A380LBCBCod = new string[] {""} ;
         T005A2_A381LBRegistro = new string[] {""} ;
         T005A2_A386LBConBan = new int[1] ;
         T005A2_A385LBDForCod = new int[1] ;
         T005A2_n385LBDForCod = new bool[] {false} ;
         T005A2_A384LBDCosCod = new string[] {""} ;
         T005A2_n384LBDCosCod = new bool[] {false} ;
         T005A18_A1073LBTHaber = new decimal[1] ;
         T005A18_A1072LBTDebe = new decimal[1] ;
         T005A22_A1073LBTHaber = new decimal[1] ;
         T005A22_A1072LBTDebe = new decimal[1] ;
         T005A23_A1064LBDConcepto = new string[] {""} ;
         T005A23_A1058LBCueCod = new string[] {""} ;
         T005A24_A1061LBCueMon = new short[1] ;
         T005A24_A1059LBCueCos = new short[1] ;
         T005A24_A1060LBCueDsc = new string[] {""} ;
         T005A24_A1090LBTipACod = new int[1] ;
         T005A24_n1090LBTipACod = new bool[] {false} ;
         T005A26_A379LBBanCod = new int[1] ;
         T005A26_A380LBCBCod = new string[] {""} ;
         T005A26_A381LBRegistro = new string[] {""} ;
         T005A26_A383LBDITem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ380LBCBCod = "";
         ZZ381LBRegistro = "";
         ZZ1092LBTipCod = "";
         ZZ1068LBDDoc = "";
         ZZ1087LBPrvCod = "";
         ZZ1066LBDCueCod = "";
         ZZ1065LBDCueAux = "";
         ZZ384LBDCosCod = "";
         ZZ1064LBDConcepto = "";
         ZZ1058LBCueCod = "";
         ZZ1060LBCueDsc = "";
         T005A27_A385LBDForCod = new int[1] ;
         T005A27_n385LBDForCod = new bool[] {false} ;
         T005A28_A384LBDCosCod = new string[] {""} ;
         T005A28_n384LBDCosCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tslibrobancosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tslibrobancosdet__default(),
            new Object[][] {
                new Object[] {
               T005A2_A383LBDITem, T005A2_A1092LBTipCod, T005A2_A1068LBDDoc, T005A2_A1067LBDDebe, T005A2_A1074LBDHaber, T005A2_A1087LBPrvCod, T005A2_A1066LBDCueCod, T005A2_A1065LBDCueAux, T005A2_A1076LBDPagReg, T005A2_n1076LBDPagReg,
               T005A2_A1077LBDTipCmb, T005A2_A379LBBanCod, T005A2_A380LBCBCod, T005A2_A381LBRegistro, T005A2_A386LBConBan, T005A2_A385LBDForCod, T005A2_n385LBDForCod, T005A2_A384LBDCosCod, T005A2_n384LBDCosCod
               }
               , new Object[] {
               T005A3_A383LBDITem, T005A3_A1092LBTipCod, T005A3_A1068LBDDoc, T005A3_A1067LBDDebe, T005A3_A1074LBDHaber, T005A3_A1087LBPrvCod, T005A3_A1066LBDCueCod, T005A3_A1065LBDCueAux, T005A3_A1076LBDPagReg, T005A3_n1076LBDPagReg,
               T005A3_A1077LBDTipCmb, T005A3_A379LBBanCod, T005A3_A380LBCBCod, T005A3_A381LBRegistro, T005A3_A386LBConBan, T005A3_A385LBDForCod, T005A3_n385LBDForCod, T005A3_A384LBDCosCod, T005A3_n384LBDCosCod
               }
               , new Object[] {
               T005A4_A1073LBTHaber, T005A4_A1072LBTDebe
               }
               , new Object[] {
               T005A5_A1073LBTHaber, T005A5_A1072LBTDebe
               }
               , new Object[] {
               T005A6_A1064LBDConcepto, T005A6_A1058LBCueCod
               }
               , new Object[] {
               T005A7_A385LBDForCod
               }
               , new Object[] {
               T005A8_A384LBDCosCod
               }
               , new Object[] {
               T005A9_A1061LBCueMon, T005A9_A1059LBCueCos, T005A9_A1060LBCueDsc, T005A9_A1090LBTipACod, T005A9_n1090LBTipACod
               }
               , new Object[] {
               T005A10_A1073LBTHaber, T005A10_A1072LBTDebe, T005A10_A383LBDITem, T005A10_A1092LBTipCod, T005A10_A1068LBDDoc, T005A10_A1067LBDDebe, T005A10_A1074LBDHaber, T005A10_A1087LBPrvCod, T005A10_A1066LBDCueCod, T005A10_A1065LBDCueAux,
               T005A10_A1061LBCueMon, T005A10_A1076LBDPagReg, T005A10_n1076LBDPagReg, T005A10_A1077LBDTipCmb, T005A10_A1064LBDConcepto, T005A10_A1059LBCueCos, T005A10_A1060LBCueDsc, T005A10_A379LBBanCod, T005A10_A380LBCBCod, T005A10_A381LBRegistro,
               T005A10_A386LBConBan, T005A10_A385LBDForCod, T005A10_n385LBDForCod, T005A10_A384LBDCosCod, T005A10_n384LBDCosCod, T005A10_A1058LBCueCod, T005A10_A1090LBTipACod, T005A10_n1090LBTipACod
               }
               , new Object[] {
               T005A11_A1064LBDConcepto, T005A11_A1058LBCueCod
               }
               , new Object[] {
               T005A12_A1061LBCueMon, T005A12_A1059LBCueCos, T005A12_A1060LBCueDsc, T005A12_A1090LBTipACod, T005A12_n1090LBTipACod
               }
               , new Object[] {
               T005A13_A385LBDForCod
               }
               , new Object[] {
               T005A14_A384LBDCosCod
               }
               , new Object[] {
               T005A15_A379LBBanCod, T005A15_A380LBCBCod, T005A15_A381LBRegistro, T005A15_A383LBDITem
               }
               , new Object[] {
               T005A16_A383LBDITem, T005A16_A379LBBanCod, T005A16_A380LBCBCod, T005A16_A381LBRegistro
               }
               , new Object[] {
               T005A17_A383LBDITem, T005A17_A379LBBanCod, T005A17_A380LBCBCod, T005A17_A381LBRegistro
               }
               , new Object[] {
               T005A18_A1073LBTHaber, T005A18_A1072LBTDebe
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005A22_A1073LBTHaber, T005A22_A1072LBTDebe
               }
               , new Object[] {
               T005A23_A1064LBDConcepto, T005A23_A1058LBCueCod
               }
               , new Object[] {
               T005A24_A1061LBCueMon, T005A24_A1059LBCueCos, T005A24_A1060LBCueDsc, T005A24_A1090LBTipACod, T005A24_n1090LBTipACod
               }
               , new Object[] {
               }
               , new Object[] {
               T005A26_A379LBBanCod, T005A26_A380LBCBCod, T005A26_A381LBRegistro, T005A26_A383LBDITem
               }
               , new Object[] {
               T005A27_A385LBDForCod
               }
               , new Object[] {
               T005A28_A384LBDCosCod
               }
            }
         );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1059LBCueCos ;
      private short A1061LBCueMon ;
      private short GX_JID ;
      private short Z1061LBCueMon ;
      private short Z1059LBCueCos ;
      private short RcdFound177 ;
      private short nIsDirty_177 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1061LBCueMon ;
      private short ZZ1059LBCueCos ;
      private int Z379LBBanCod ;
      private int Z383LBDITem ;
      private int Z386LBConBan ;
      private int Z385LBDForCod ;
      private int A379LBBanCod ;
      private int A386LBConBan ;
      private int A385LBDForCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLBBanCod_Enabled ;
      private int edtLBCBCod_Enabled ;
      private int edtLBRegistro_Enabled ;
      private int A383LBDITem ;
      private int edtLBDITem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLBTipCod_Enabled ;
      private int edtLBDDoc_Enabled ;
      private int edtLBDDebe_Enabled ;
      private int edtLBDHaber_Enabled ;
      private int edtLBConBan_Enabled ;
      private int edtLBPrvCod_Enabled ;
      private int edtLBDCueCod_Enabled ;
      private int edtLBDCueAux_Enabled ;
      private int edtLBDForCod_Enabled ;
      private int edtLBDPagReg_Enabled ;
      private int edtLBDCosCod_Enabled ;
      private int edtLBDTipCmb_Enabled ;
      private int edtLBCueCod_Enabled ;
      private int edtLBDConcepto_Enabled ;
      private int edtLBCueCos_Enabled ;
      private int edtLBCueDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A1090LBTipACod ;
      private int Z1090LBTipACod ;
      private int idxLst ;
      private int ZZ379LBBanCod ;
      private int ZZ383LBDITem ;
      private int ZZ386LBConBan ;
      private int ZZ385LBDForCod ;
      private int ZZ1090LBTipACod ;
      private long Z1076LBDPagReg ;
      private long A1076LBDPagReg ;
      private long ZZ1076LBDPagReg ;
      private decimal Z1067LBDDebe ;
      private decimal Z1074LBDHaber ;
      private decimal Z1077LBDTipCmb ;
      private decimal O1067LBDDebe ;
      private decimal O1072LBTDebe ;
      private decimal O1074LBDHaber ;
      private decimal O1073LBTHaber ;
      private decimal A1067LBDDebe ;
      private decimal A1074LBDHaber ;
      private decimal A1077LBDTipCmb ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal Z1073LBTHaber ;
      private decimal Z1072LBTDebe ;
      private decimal ZO1073LBTHaber ;
      private decimal ZO1072LBTDebe ;
      private decimal ZZ1067LBDDebe ;
      private decimal ZZ1074LBDHaber ;
      private decimal ZZ1077LBDTipCmb ;
      private decimal ZZ1073LBTHaber ;
      private decimal ZZ1072LBTDebe ;
      private decimal ZO1067LBDDebe ;
      private decimal ZO1074LBDHaber ;
      private string sPrefix ;
      private string Z380LBCBCod ;
      private string Z381LBRegistro ;
      private string Z1092LBTipCod ;
      private string Z1068LBDDoc ;
      private string Z1087LBPrvCod ;
      private string Z1066LBDCueCod ;
      private string Z1065LBDCueAux ;
      private string Z384LBDCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A380LBCBCod ;
      private string A381LBRegistro ;
      private string A1058LBCueCod ;
      private string A384LBDCosCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLBBanCod_Internalname ;
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
      private string edtLBBanCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLBCBCod_Internalname ;
      private string edtLBCBCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLBRegistro_Internalname ;
      private string edtLBRegistro_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLBDITem_Internalname ;
      private string edtLBDITem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLBTipCod_Internalname ;
      private string A1092LBTipCod ;
      private string edtLBTipCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLBDDoc_Internalname ;
      private string A1068LBDDoc ;
      private string edtLBDDoc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLBDDebe_Internalname ;
      private string edtLBDDebe_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLBDHaber_Internalname ;
      private string edtLBDHaber_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLBConBan_Internalname ;
      private string edtLBConBan_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLBPrvCod_Internalname ;
      private string A1087LBPrvCod ;
      private string edtLBPrvCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtLBDCueCod_Internalname ;
      private string A1066LBDCueCod ;
      private string edtLBDCueCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtLBDCueAux_Internalname ;
      private string A1065LBDCueAux ;
      private string edtLBDCueAux_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLBDForCod_Internalname ;
      private string edtLBDForCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtLBDPagReg_Internalname ;
      private string edtLBDPagReg_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtLBDCosCod_Internalname ;
      private string edtLBDCosCod_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtLBDTipCmb_Internalname ;
      private string edtLBDTipCmb_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtLBCueCod_Internalname ;
      private string edtLBCueCod_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtLBDConcepto_Internalname ;
      private string A1064LBDConcepto ;
      private string edtLBDConcepto_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtLBCueCos_Internalname ;
      private string edtLBCueCos_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtLBCueDsc_Internalname ;
      private string A1060LBCueDsc ;
      private string edtLBCueDsc_Jsonclick ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1064LBDConcepto ;
      private string Z1058LBCueCod ;
      private string Z1060LBCueDsc ;
      private string sMode177 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ380LBCBCod ;
      private string ZZ381LBRegistro ;
      private string ZZ1092LBTipCod ;
      private string ZZ1068LBDDoc ;
      private string ZZ1087LBPrvCod ;
      private string ZZ1066LBDCueCod ;
      private string ZZ1065LBDCueAux ;
      private string ZZ384LBDCosCod ;
      private string ZZ1064LBDConcepto ;
      private string ZZ1058LBCueCod ;
      private string ZZ1060LBCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n385LBDForCod ;
      private bool n384LBDCosCod ;
      private bool wbErr ;
      private bool n1076LBDPagReg ;
      private bool n1090LBTipACod ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T005A10_A1073LBTHaber ;
      private decimal[] T005A10_A1072LBTDebe ;
      private int[] T005A10_A383LBDITem ;
      private string[] T005A10_A1092LBTipCod ;
      private string[] T005A10_A1068LBDDoc ;
      private decimal[] T005A10_A1067LBDDebe ;
      private decimal[] T005A10_A1074LBDHaber ;
      private string[] T005A10_A1087LBPrvCod ;
      private string[] T005A10_A1066LBDCueCod ;
      private string[] T005A10_A1065LBDCueAux ;
      private short[] T005A10_A1061LBCueMon ;
      private long[] T005A10_A1076LBDPagReg ;
      private bool[] T005A10_n1076LBDPagReg ;
      private decimal[] T005A10_A1077LBDTipCmb ;
      private string[] T005A10_A1064LBDConcepto ;
      private short[] T005A10_A1059LBCueCos ;
      private string[] T005A10_A1060LBCueDsc ;
      private int[] T005A10_A379LBBanCod ;
      private string[] T005A10_A380LBCBCod ;
      private string[] T005A10_A381LBRegistro ;
      private int[] T005A10_A386LBConBan ;
      private int[] T005A10_A385LBDForCod ;
      private bool[] T005A10_n385LBDForCod ;
      private string[] T005A10_A384LBDCosCod ;
      private bool[] T005A10_n384LBDCosCod ;
      private string[] T005A10_A1058LBCueCod ;
      private int[] T005A10_A1090LBTipACod ;
      private bool[] T005A10_n1090LBTipACod ;
      private decimal[] T005A5_A1073LBTHaber ;
      private decimal[] T005A5_A1072LBTDebe ;
      private string[] T005A6_A1064LBDConcepto ;
      private string[] T005A6_A1058LBCueCod ;
      private short[] T005A9_A1061LBCueMon ;
      private short[] T005A9_A1059LBCueCos ;
      private string[] T005A9_A1060LBCueDsc ;
      private int[] T005A9_A1090LBTipACod ;
      private bool[] T005A9_n1090LBTipACod ;
      private int[] T005A7_A385LBDForCod ;
      private bool[] T005A7_n385LBDForCod ;
      private string[] T005A8_A384LBDCosCod ;
      private bool[] T005A8_n384LBDCosCod ;
      private string[] T005A11_A1064LBDConcepto ;
      private string[] T005A11_A1058LBCueCod ;
      private short[] T005A12_A1061LBCueMon ;
      private short[] T005A12_A1059LBCueCos ;
      private string[] T005A12_A1060LBCueDsc ;
      private int[] T005A12_A1090LBTipACod ;
      private bool[] T005A12_n1090LBTipACod ;
      private int[] T005A13_A385LBDForCod ;
      private bool[] T005A13_n385LBDForCod ;
      private string[] T005A14_A384LBDCosCod ;
      private bool[] T005A14_n384LBDCosCod ;
      private int[] T005A15_A379LBBanCod ;
      private string[] T005A15_A380LBCBCod ;
      private string[] T005A15_A381LBRegistro ;
      private int[] T005A15_A383LBDITem ;
      private int[] T005A3_A383LBDITem ;
      private string[] T005A3_A1092LBTipCod ;
      private string[] T005A3_A1068LBDDoc ;
      private decimal[] T005A3_A1067LBDDebe ;
      private decimal[] T005A3_A1074LBDHaber ;
      private string[] T005A3_A1087LBPrvCod ;
      private string[] T005A3_A1066LBDCueCod ;
      private string[] T005A3_A1065LBDCueAux ;
      private long[] T005A3_A1076LBDPagReg ;
      private bool[] T005A3_n1076LBDPagReg ;
      private decimal[] T005A3_A1077LBDTipCmb ;
      private int[] T005A3_A379LBBanCod ;
      private string[] T005A3_A380LBCBCod ;
      private string[] T005A3_A381LBRegistro ;
      private int[] T005A3_A386LBConBan ;
      private int[] T005A3_A385LBDForCod ;
      private bool[] T005A3_n385LBDForCod ;
      private string[] T005A3_A384LBDCosCod ;
      private bool[] T005A3_n384LBDCosCod ;
      private int[] T005A16_A383LBDITem ;
      private int[] T005A16_A379LBBanCod ;
      private string[] T005A16_A380LBCBCod ;
      private string[] T005A16_A381LBRegistro ;
      private int[] T005A17_A383LBDITem ;
      private int[] T005A17_A379LBBanCod ;
      private string[] T005A17_A380LBCBCod ;
      private string[] T005A17_A381LBRegistro ;
      private int[] T005A2_A383LBDITem ;
      private string[] T005A2_A1092LBTipCod ;
      private string[] T005A2_A1068LBDDoc ;
      private decimal[] T005A2_A1067LBDDebe ;
      private decimal[] T005A2_A1074LBDHaber ;
      private string[] T005A2_A1087LBPrvCod ;
      private string[] T005A2_A1066LBDCueCod ;
      private string[] T005A2_A1065LBDCueAux ;
      private long[] T005A2_A1076LBDPagReg ;
      private bool[] T005A2_n1076LBDPagReg ;
      private decimal[] T005A2_A1077LBDTipCmb ;
      private int[] T005A2_A379LBBanCod ;
      private string[] T005A2_A380LBCBCod ;
      private string[] T005A2_A381LBRegistro ;
      private int[] T005A2_A386LBConBan ;
      private int[] T005A2_A385LBDForCod ;
      private bool[] T005A2_n385LBDForCod ;
      private string[] T005A2_A384LBDCosCod ;
      private bool[] T005A2_n384LBDCosCod ;
      private decimal[] T005A18_A1073LBTHaber ;
      private decimal[] T005A18_A1072LBTDebe ;
      private decimal[] T005A22_A1073LBTHaber ;
      private decimal[] T005A22_A1072LBTDebe ;
      private string[] T005A23_A1064LBDConcepto ;
      private string[] T005A23_A1058LBCueCod ;
      private short[] T005A24_A1061LBCueMon ;
      private short[] T005A24_A1059LBCueCos ;
      private string[] T005A24_A1060LBCueDsc ;
      private int[] T005A24_A1090LBTipACod ;
      private bool[] T005A24_n1090LBTipACod ;
      private int[] T005A26_A379LBBanCod ;
      private string[] T005A26_A380LBCBCod ;
      private string[] T005A26_A381LBRegistro ;
      private int[] T005A26_A383LBDITem ;
      private int[] T005A27_A385LBDForCod ;
      private bool[] T005A27_n385LBDForCod ;
      private string[] T005A28_A384LBDCosCod ;
      private bool[] T005A28_n384LBDCosCod ;
      private IDataStoreProvider pr_datastore2 ;
      private decimal[] T005A4_A1073LBTHaber ;
      private decimal[] T005A4_A1072LBTDebe ;
      private GXWebForm Form ;
   }

   public class tslibrobancosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tslibrobancosdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005A4;
        prmT005A4 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A10;
        prmT005A10 = new Object[] {
        new ParDef("@LBDITem",GXType.Int32,6,0) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A6;
        prmT005A6 = new Object[] {
        new ParDef("@LBConBan",GXType.Int32,6,0)
        };
        Object[] prmT005A9;
        prmT005A9 = new Object[] {
        new ParDef("@LBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005A7;
        prmT005A7 = new Object[] {
        new ParDef("@LBDForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005A8;
        prmT005A8 = new Object[] {
        new ParDef("@LBDCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005A5;
        prmT005A5 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A11;
        prmT005A11 = new Object[] {
        new ParDef("@LBConBan",GXType.Int32,6,0)
        };
        Object[] prmT005A12;
        prmT005A12 = new Object[] {
        new ParDef("@LBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005A13;
        prmT005A13 = new Object[] {
        new ParDef("@LBDForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005A14;
        prmT005A14 = new Object[] {
        new ParDef("@LBDCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005A15;
        prmT005A15 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBDITem",GXType.Int32,6,0)
        };
        Object[] prmT005A3;
        prmT005A3 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBDITem",GXType.Int32,6,0)
        };
        Object[] prmT005A16;
        prmT005A16 = new Object[] {
        new ParDef("@LBDITem",GXType.Int32,6,0) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A17;
        prmT005A17 = new Object[] {
        new ParDef("@LBDITem",GXType.Int32,6,0) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A2;
        prmT005A2 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBDITem",GXType.Int32,6,0)
        };
        Object[] prmT005A18;
        prmT005A18 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A19;
        prmT005A19 = new Object[] {
        new ParDef("@LBDITem",GXType.Int32,6,0) ,
        new ParDef("@LBTipCod",GXType.NChar,3,0) ,
        new ParDef("@LBDDoc",GXType.NChar,15,0) ,
        new ParDef("@LBDDebe",GXType.Decimal,15,2) ,
        new ParDef("@LBDHaber",GXType.Decimal,15,2) ,
        new ParDef("@LBPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LBDCueCod",GXType.NChar,15,0) ,
        new ParDef("@LBDCueAux",GXType.NChar,20,0) ,
        new ParDef("@LBDPagReg",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@LBDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBConBan",GXType.Int32,6,0) ,
        new ParDef("@LBDForCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LBDCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005A20;
        prmT005A20 = new Object[] {
        new ParDef("@LBTipCod",GXType.NChar,3,0) ,
        new ParDef("@LBDDoc",GXType.NChar,15,0) ,
        new ParDef("@LBDDebe",GXType.Decimal,15,2) ,
        new ParDef("@LBDHaber",GXType.Decimal,15,2) ,
        new ParDef("@LBPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LBDCueCod",GXType.NChar,15,0) ,
        new ParDef("@LBDCueAux",GXType.NChar,20,0) ,
        new ParDef("@LBDPagReg",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@LBDTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LBConBan",GXType.Int32,6,0) ,
        new ParDef("@LBDForCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LBDCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBDITem",GXType.Int32,6,0)
        };
        Object[] prmT005A21;
        prmT005A21 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBDITem",GXType.Int32,6,0)
        };
        Object[] prmT005A25;
        prmT005A25 = new Object[] {
        new ParDef("@LBTHaber",GXType.Decimal,15,2) ,
        new ParDef("@LBTDebe",GXType.Decimal,15,2) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A26;
        prmT005A26 = new Object[] {
        };
        Object[] prmT005A22;
        prmT005A22 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005A23;
        prmT005A23 = new Object[] {
        new ParDef("@LBConBan",GXType.Int32,6,0)
        };
        Object[] prmT005A24;
        prmT005A24 = new Object[] {
        new ParDef("@LBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005A27;
        prmT005A27 = new Object[] {
        new ParDef("@LBDForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005A28;
        prmT005A28 = new Object[] {
        new ParDef("@LBDCosCod",GXType.NChar,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T005A2", "SELECT [LBDITem], [LBTipCod], [LBDDoc], [LBDDebe], [LBDHaber], [LBPrvCod], [LBDCueCod], [LBDCueAux], [LBDPagReg], [LBDTipCmb], [LBBanCod], [LBCBCod], [LBRegistro], [LBConBan] AS LBConBan, [LBDForCod] AS LBDForCod, [LBDCosCod] AS LBDCosCod FROM [TSLIBROBANCOSDET] WITH (UPDLOCK) WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro AND [LBDITem] = @LBDITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A3", "SELECT [LBDITem], [LBTipCod], [LBDDoc], [LBDDebe], [LBDHaber], [LBPrvCod], [LBDCueCod], [LBDCueAux], [LBDPagReg], [LBDTipCmb], [LBBanCod], [LBCBCod], [LBRegistro], [LBConBan] AS LBConBan, [LBDForCod] AS LBDForCod, [LBDCosCod] AS LBDCosCod FROM [TSLIBROBANCOSDET] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro AND [LBDITem] = @LBDITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A4", "SELECT [LBTHaber], [LBTDebe] FROM [TSLIBROBANCOS] WITH (UPDLOCK) WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A5", "SELECT [LBTHaber], [LBTDebe] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A6", "SELECT [ConBDsc] AS LBDConcepto, [ConBCueCod] AS LBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LBConBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A7", "SELECT [ForCod] AS LBDForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LBDForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A8", "SELECT [COSCod] AS LBDCosCod FROM [CBCOSTOS] WHERE [COSCod] = @LBDCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A9", "SELECT [CueMon] AS LBCueMon, [CueCos] AS LBCueCos, [CueDsc] AS LBCueDsc, [TipACod] AS LBTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @LBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A10", "SELECT T2.[LBTHaber], T2.[LBTDebe], TM1.[LBDITem], TM1.[LBTipCod], TM1.[LBDDoc], TM1.[LBDDebe], TM1.[LBDHaber], TM1.[LBPrvCod], TM1.[LBDCueCod], TM1.[LBDCueAux], T4.[CueMon] AS LBCueMon, TM1.[LBDPagReg], TM1.[LBDTipCmb], T3.[ConBDsc] AS LBDConcepto, T4.[CueCos] AS LBCueCos, T4.[CueDsc] AS LBCueDsc, TM1.[LBBanCod], TM1.[LBCBCod], TM1.[LBRegistro], TM1.[LBConBan] AS LBConBan, TM1.[LBDForCod] AS LBDForCod, TM1.[LBDCosCod] AS LBDCosCod, T3.[ConBCueCod] AS LBCueCod, T4.[TipACod] AS LBTipACod FROM ((([TSLIBROBANCOSDET] TM1 INNER JOIN [TSLIBROBANCOS] T2 ON T2.[LBBanCod] = TM1.[LBBanCod] AND T2.[LBCBCod] = TM1.[LBCBCod] AND T2.[LBRegistro] = TM1.[LBRegistro]) INNER JOIN [TSCONCEPTOBANCOS] T3 ON T3.[ConBCod] = TM1.[LBConBan]) INNER JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T3.[ConBCueCod]) WHERE TM1.[LBDITem] = @LBDITem and TM1.[LBBanCod] = @LBBanCod and TM1.[LBCBCod] = @LBCBCod and TM1.[LBRegistro] = @LBRegistro ORDER BY TM1.[LBBanCod], TM1.[LBCBCod], TM1.[LBRegistro], TM1.[LBDITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005A10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A11", "SELECT [ConBDsc] AS LBDConcepto, [ConBCueCod] AS LBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LBConBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A12", "SELECT [CueMon] AS LBCueMon, [CueCos] AS LBCueCos, [CueDsc] AS LBCueDsc, [TipACod] AS LBTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @LBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A13", "SELECT [ForCod] AS LBDForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LBDForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A14", "SELECT [COSCod] AS LBDCosCod FROM [CBCOSTOS] WHERE [COSCod] = @LBDCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A15", "SELECT [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro AND [LBDITem] = @LBDITem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005A15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A16", "SELECT TOP 1 [LBDITem], [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOSDET] WHERE ( [LBDITem] > @LBDITem or [LBDITem] = @LBDITem and [LBBanCod] > @LBBanCod or [LBBanCod] = @LBBanCod and [LBDITem] = @LBDITem and [LBCBCod] > @LBCBCod or [LBCBCod] = @LBCBCod and [LBBanCod] = @LBBanCod and [LBDITem] = @LBDITem and [LBRegistro] > @LBRegistro) ORDER BY [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005A16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005A17", "SELECT TOP 1 [LBDITem], [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOSDET] WHERE ( [LBDITem] < @LBDITem or [LBDITem] = @LBDITem and [LBBanCod] < @LBBanCod or [LBBanCod] = @LBBanCod and [LBDITem] = @LBDITem and [LBCBCod] < @LBCBCod or [LBCBCod] = @LBCBCod and [LBBanCod] = @LBBanCod and [LBDITem] = @LBDITem and [LBRegistro] < @LBRegistro) ORDER BY [LBBanCod] DESC, [LBCBCod] DESC, [LBRegistro] DESC, [LBDITem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005A17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005A18", "SELECT [LBTHaber], [LBTDebe] FROM [TSLIBROBANCOS] WITH (UPDLOCK) WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A19", "INSERT INTO [TSLIBROBANCOSDET]([LBDITem], [LBTipCod], [LBDDoc], [LBDDebe], [LBDHaber], [LBPrvCod], [LBDCueCod], [LBDCueAux], [LBDPagReg], [LBDTipCmb], [LBBanCod], [LBCBCod], [LBRegistro], [LBConBan], [LBDForCod], [LBDCosCod]) VALUES(@LBDITem, @LBTipCod, @LBDDoc, @LBDDebe, @LBDHaber, @LBPrvCod, @LBDCueCod, @LBDCueAux, @LBDPagReg, @LBDTipCmb, @LBBanCod, @LBCBCod, @LBRegistro, @LBConBan, @LBDForCod, @LBDCosCod)", GxErrorMask.GX_NOMASK,prmT005A19)
           ,new CursorDef("T005A20", "UPDATE [TSLIBROBANCOSDET] SET [LBTipCod]=@LBTipCod, [LBDDoc]=@LBDDoc, [LBDDebe]=@LBDDebe, [LBDHaber]=@LBDHaber, [LBPrvCod]=@LBPrvCod, [LBDCueCod]=@LBDCueCod, [LBDCueAux]=@LBDCueAux, [LBDPagReg]=@LBDPagReg, [LBDTipCmb]=@LBDTipCmb, [LBConBan]=@LBConBan, [LBDForCod]=@LBDForCod, [LBDCosCod]=@LBDCosCod  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro AND [LBDITem] = @LBDITem", GxErrorMask.GX_NOMASK,prmT005A20)
           ,new CursorDef("T005A21", "DELETE FROM [TSLIBROBANCOSDET]  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro AND [LBDITem] = @LBDITem", GxErrorMask.GX_NOMASK,prmT005A21)
           ,new CursorDef("T005A22", "SELECT [LBTHaber], [LBTDebe] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A23", "SELECT [ConBDsc] AS LBDConcepto, [ConBCueCod] AS LBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LBConBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A24", "SELECT [CueMon] AS LBCueMon, [CueCos] AS LBCueCos, [CueDsc] AS LBCueDsc, [TipACod] AS LBTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @LBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A25", "UPDATE [TSLIBROBANCOS] SET [LBTHaber]=@LBTHaber, [LBTDebe]=@LBTDebe  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro", GxErrorMask.GX_NOMASK,prmT005A25)
           ,new CursorDef("T005A26", "SELECT [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] ORDER BY [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005A26,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A27", "SELECT [ForCod] AS LBDForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LBDForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005A28", "SELECT [COSCod] AS LBDCosCod FROM [CBCOSTOS] WHERE [COSCod] = @LBDCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005A28,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 20);
              ((string[]) buf[13])[0] = rslt.getString(13, 10);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 10);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 20);
              ((string[]) buf[13])[0] = rslt.getString(13, 10);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 10);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 100);
              ((short[]) buf[15])[0] = rslt.getShort(15);
              ((string[]) buf[16])[0] = rslt.getString(16, 100);
              ((int[]) buf[17])[0] = rslt.getInt(17);
              ((string[]) buf[18])[0] = rslt.getString(18, 20);
              ((string[]) buf[19])[0] = rslt.getString(19, 10);
              ((int[]) buf[20])[0] = rslt.getInt(20);
              ((int[]) buf[21])[0] = rslt.getInt(21);
              ((bool[]) buf[22])[0] = rslt.wasNull(21);
              ((string[]) buf[23])[0] = rslt.getString(22, 10);
              ((bool[]) buf[24])[0] = rslt.wasNull(22);
              ((string[]) buf[25])[0] = rslt.getString(23, 15);
              ((int[]) buf[26])[0] = rslt.getInt(24);
              ((bool[]) buf[27])[0] = rslt.wasNull(24);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 16 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 20 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
