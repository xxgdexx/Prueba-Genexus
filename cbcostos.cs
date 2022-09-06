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
   public class cbcostos : GXHttpHandler
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
            Form.Meta.addItem("description", "Centro de Costos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbcostos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbcostos( IGxContext context )
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
         cmbCOSSts = new GXCombobox();
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
         if ( cmbCOSSts.ItemCount > 0 )
         {
            A762COSSts = (short)(NumberUtil.Val( cmbCOSSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0))), "."));
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            AssignProp("", false, cmbCOSSts_Internalname, "Values", cmbCOSSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm1P58( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBCOSTOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo de C.Costo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod), StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Centro de Costos", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSDsc_Internalname, StringUtil.RTrim( A761COSDsc), StringUtil.RTrim( context.localUtil.Format( A761COSDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSAbr_Internalname, StringUtil.RTrim( A759COSAbr), StringUtil.RTrim( context.localUtil.Format( A759COSAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOSTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCOSSts, cmbCOSSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0)), 1, cmbCOSSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCOSSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CBCOSTOS.htm");
         cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         AssignProp("", false, cmbCOSSts_Internalname, "Values", (string)(cmbCOSSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOSTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBCOSTOS.htm");
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
            Z79COSCod = cgiGet( "Z79COSCod");
            Z761COSDsc = cgiGet( "Z761COSDsc");
            Z759COSAbr = cgiGet( "Z759COSAbr");
            Z762COSSts = (short)(context.localUtil.CToN( cgiGet( "Z762COSSts"), ".", ","));
            Z80COSCueDestino = cgiGet( "Z80COSCueDestino");
            n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
            A80COSCueDestino = cgiGet( "Z80COSCueDestino");
            n80COSCueDestino = false;
            n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A80COSCueDestino = cgiGet( "COSCUEDESTINO");
            n80COSCueDestino = (String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ? true : false);
            A760CosCueDestinoDsc = cgiGet( "COSCUEDESTINODSC");
            /* Read variables values. */
            A79COSCod = cgiGet( edtCOSCod_Internalname);
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A761COSDsc = cgiGet( edtCOSDsc_Internalname);
            AssignAttri("", false, "A761COSDsc", A761COSDsc);
            A759COSAbr = cgiGet( edtCOSAbr_Internalname);
            AssignAttri("", false, "A759COSAbr", A759COSAbr);
            cmbCOSSts.CurrentValue = cgiGet( cmbCOSSts_Internalname);
            A762COSSts = (short)(NumberUtil.Val( cgiGet( cmbCOSSts_Internalname), "."));
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CBCOSTOS");
            forbiddenHiddens.Add("COSCueDestino", StringUtil.RTrim( context.localUtil.Format( A80COSCueDestino, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cbcostos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A79COSCod = GetPar( "COSCod");
               n79COSCod = false;
               AssignAttri("", false, "A79COSCod", A79COSCod);
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
               InitAll1P58( ) ;
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
         DisableAttributes1P58( ) ;
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

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P58( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P58( ) ;
            }
            else
            {
               CheckExtendedTable1P58( ) ;
               if ( AnyError == 0 )
               {
                  ZM1P58( 2) ;
               }
               CloseExtendedTableCursors1P58( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1P0( ) ;
         }
      }

      protected void ResetCaption1P0( )
      {
      }

      protected void ZM1P58( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z761COSDsc = T001P3_A761COSDsc[0];
               Z759COSAbr = T001P3_A759COSAbr[0];
               Z762COSSts = T001P3_A762COSSts[0];
               Z80COSCueDestino = T001P3_A80COSCueDestino[0];
            }
            else
            {
               Z761COSDsc = A761COSDsc;
               Z759COSAbr = A759COSAbr;
               Z762COSSts = A762COSSts;
               Z80COSCueDestino = A80COSCueDestino;
            }
         }
         if ( GX_JID == -1 )
         {
            Z79COSCod = A79COSCod;
            Z761COSDsc = A761COSDsc;
            Z759COSAbr = A759COSAbr;
            Z762COSSts = A762COSSts;
            Z80COSCueDestino = A80COSCueDestino;
            Z760CosCueDestinoDsc = A760CosCueDestinoDsc;
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
         /* Using cursor T001P4 */
         pr_default.execute(2, new Object[] {n80COSCueDestino, A80COSCueDestino});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "COSCUEDESTINO");
               AnyError = 1;
            }
         }
         A760CosCueDestinoDsc = T001P4_A760CosCueDestinoDsc[0];
         pr_default.close(2);
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

      protected void Load1P58( )
      {
         /* Using cursor T001P5 */
         pr_default.execute(3, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A761COSDsc = T001P5_A761COSDsc[0];
            AssignAttri("", false, "A761COSDsc", A761COSDsc);
            A759COSAbr = T001P5_A759COSAbr[0];
            AssignAttri("", false, "A759COSAbr", A759COSAbr);
            A762COSSts = T001P5_A762COSSts[0];
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            A760CosCueDestinoDsc = T001P5_A760CosCueDestinoDsc[0];
            A80COSCueDestino = T001P5_A80COSCueDestino[0];
            n80COSCueDestino = T001P5_n80COSCueDestino[0];
            ZM1P58( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1P58( ) ;
      }

      protected void OnLoadActions1P58( )
      {
      }

      protected void CheckExtendedTable1P58( )
      {
         nIsDirty_58 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1P58( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1P58( )
      {
         /* Using cursor T001P6 */
         pr_default.execute(4, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001P3 */
         pr_default.execute(1, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P58( 1) ;
            RcdFound58 = 1;
            A79COSCod = T001P3_A79COSCod[0];
            n79COSCod = T001P3_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A761COSDsc = T001P3_A761COSDsc[0];
            AssignAttri("", false, "A761COSDsc", A761COSDsc);
            A759COSAbr = T001P3_A759COSAbr[0];
            AssignAttri("", false, "A759COSAbr", A759COSAbr);
            A762COSSts = T001P3_A762COSSts[0];
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
            A80COSCueDestino = T001P3_A80COSCueDestino[0];
            n80COSCueDestino = T001P3_n80COSCueDestino[0];
            Z79COSCod = A79COSCod;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1P58( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1P58( ) ;
            }
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1P58( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode58;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P58( ) ;
         if ( RcdFound58 == 0 )
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
         RcdFound58 = 0;
         /* Using cursor T001P7 */
         pr_default.execute(5, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001P7_A79COSCod[0], A79COSCod) < 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001P7_A79COSCod[0], A79COSCod) > 0 ) ) )
            {
               A79COSCod = T001P7_A79COSCod[0];
               n79COSCod = T001P7_n79COSCod[0];
               AssignAttri("", false, "A79COSCod", A79COSCod);
               RcdFound58 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound58 = 0;
         /* Using cursor T001P8 */
         pr_default.execute(6, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T001P8_A79COSCod[0], A79COSCod) > 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T001P8_A79COSCod[0], A79COSCod) < 0 ) ) )
            {
               A79COSCod = T001P8_A79COSCod[0];
               n79COSCod = T001P8_n79COSCod[0];
               AssignAttri("", false, "A79COSCod", A79COSCod);
               RcdFound58 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1P58( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1P58( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
               {
                  A79COSCod = Z79COSCod;
                  n79COSCod = false;
                  AssignAttri("", false, "A79COSCod", A79COSCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COSCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1P58( ) ;
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCOSCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1P58( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCOSCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCOSCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1P58( ) ;
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
         if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
         {
            A79COSCod = Z79COSCod;
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCOSCod_Internalname;
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
         GetKey1P58( ) ;
         if ( RcdFound58 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
            {
               A79COSCod = Z79COSCod;
               n79COSCod = false;
               AssignAttri("", false, "A79COSCod", A79COSCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
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
            if ( StringUtil.StrCmp(A79COSCod, Z79COSCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COSCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCOSCod_Internalname;
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
         context.RollbackDataStores("cbcostos",pr_default);
         GX_FocusControl = edtCOSDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1P0( ) ;
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
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COSCOD");
            AnyError = 1;
            GX_FocusControl = edtCOSCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCOSDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1P58( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1P58( ) ;
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
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSDsc_Internalname;
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
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSDsc_Internalname;
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
         ScanStart1P58( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound58 != 0 )
            {
               ScanNext1P58( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCOSDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1P58( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1P58( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001P2 */
            pr_default.execute(0, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOSTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z761COSDsc, T001P2_A761COSDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z759COSAbr, T001P2_A759COSAbr[0]) != 0 ) || ( Z762COSSts != T001P2_A762COSSts[0] ) || ( StringUtil.StrCmp(Z80COSCueDestino, T001P2_A80COSCueDestino[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z761COSDsc, T001P2_A761COSDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcostos:[seudo value changed for attri]"+"COSDsc");
                  GXUtil.WriteLogRaw("Old: ",Z761COSDsc);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A761COSDsc[0]);
               }
               if ( StringUtil.StrCmp(Z759COSAbr, T001P2_A759COSAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcostos:[seudo value changed for attri]"+"COSAbr");
                  GXUtil.WriteLogRaw("Old: ",Z759COSAbr);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A759COSAbr[0]);
               }
               if ( Z762COSSts != T001P2_A762COSSts[0] )
               {
                  GXUtil.WriteLog("cbcostos:[seudo value changed for attri]"+"COSSts");
                  GXUtil.WriteLogRaw("Old: ",Z762COSSts);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A762COSSts[0]);
               }
               if ( StringUtil.StrCmp(Z80COSCueDestino, T001P2_A80COSCueDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcostos:[seudo value changed for attri]"+"COSCueDestino");
                  GXUtil.WriteLogRaw("Old: ",Z80COSCueDestino);
                  GXUtil.WriteLogRaw("Current: ",T001P2_A80COSCueDestino[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCOSTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P58( )
      {
         BeforeValidate1P58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P58( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P58( 0) ;
            CheckOptimisticConcurrency1P58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P9 */
                     pr_default.execute(7, new Object[] {n79COSCod, A79COSCod, A761COSDsc, A759COSAbr, A762COSSts, n80COSCueDestino, A80COSCueDestino});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           ResetCaption1P0( ) ;
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
               Load1P58( ) ;
            }
            EndLevel1P58( ) ;
         }
         CloseExtendedTableCursors1P58( ) ;
      }

      protected void Update1P58( )
      {
         BeforeValidate1P58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P58( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001P10 */
                     pr_default.execute(8, new Object[] {A761COSDsc, A759COSAbr, A762COSSts, n80COSCueDestino, A80COSCueDestino, n79COSCod, A79COSCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOSTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P58( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1P0( ) ;
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
            EndLevel1P58( ) ;
         }
         CloseExtendedTableCursors1P58( ) ;
      }

      protected void DeferredUpdate1P58( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1P58( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P58( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P58( ) ;
            AfterConfirm1P58( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P58( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001P11 */
                  pr_default.execute(9, new Object[] {n79COSCod, A79COSCod});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCOSTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound58 == 0 )
                        {
                           InitAll1P58( ) ;
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
                        ResetCaption1P0( ) ;
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
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1P58( ) ;
         Gx_mode = sMode58;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1P58( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001P12 */
            pr_default.execute(10, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001P13 */
            pr_default.execute(11, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"+" ("+"C.Costo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T001P14 */
            pr_default.execute(12, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"+" ("+"C.Costo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001P15 */
            pr_default.execute(13, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"+" ("+"Centro de Costos"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001P16 */
            pr_default.execute(14, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"+" ("+"Centro de Costos"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001P17 */
            pr_default.execute(15, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001P18 */
            pr_default.execute(16, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001P19 */
            pr_default.execute(17, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001P20 */
            pr_default.execute(18, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001P21 */
            pr_default.execute(19, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBFLUJOCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001P22 */
            pr_default.execute(20, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001P23 */
            pr_default.execute(21, new Object[] {n79COSCod, A79COSCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel1P58( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P58( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbcostos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbcostos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1P58( )
      {
         /* Using cursor T001P24 */
         pr_default.execute(22);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound58 = 1;
            A79COSCod = T001P24_A79COSCod[0];
            n79COSCod = T001P24_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1P58( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound58 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound58 = 1;
            A79COSCod = T001P24_A79COSCod[0];
            n79COSCod = T001P24_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
         }
      }

      protected void ScanEnd1P58( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1P58( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P58( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P58( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P58( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P58( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P58( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P58( )
      {
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         edtCOSDsc_Enabled = 0;
         AssignProp("", false, edtCOSDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSDsc_Enabled), 5, 0), true);
         edtCOSAbr_Enabled = 0;
         AssignProp("", false, edtCOSAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSAbr_Enabled), 5, 0), true);
         cmbCOSSts.Enabled = 0;
         AssignProp("", false, cmbCOSSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCOSSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1P58( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1P0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Centro de Costos") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810241245", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbcostos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CBCOSTOS");
         forbiddenHiddens.Add("COSCueDestino", StringUtil.RTrim( context.localUtil.Format( A80COSCueDestino, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cbcostos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z761COSDsc", StringUtil.RTrim( Z761COSDsc));
         GxWebStd.gx_hidden_field( context, "Z759COSAbr", StringUtil.RTrim( Z759COSAbr));
         GxWebStd.gx_hidden_field( context, "Z762COSSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z762COSSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z80COSCueDestino", StringUtil.RTrim( Z80COSCueDestino));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "COSCUEDESTINO", StringUtil.RTrim( A80COSCueDestino));
         GxWebStd.gx_hidden_field( context, "COSCUEDESTINODSC", StringUtil.RTrim( A760CosCueDestinoDsc));
      }

      protected void RenderHtmlCloseForm1P58( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "CBCOSTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Centro de Costos" ;
      }

      protected void InitializeNonKey1P58( )
      {
         A761COSDsc = "";
         AssignAttri("", false, "A761COSDsc", A761COSDsc);
         A759COSAbr = "";
         AssignAttri("", false, "A759COSAbr", A759COSAbr);
         A762COSSts = 0;
         AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         A80COSCueDestino = "";
         n80COSCueDestino = false;
         AssignAttri("", false, "A80COSCueDestino", A80COSCueDestino);
         A760CosCueDestinoDsc = "";
         AssignAttri("", false, "A760CosCueDestinoDsc", A760CosCueDestinoDsc);
         Z761COSDsc = "";
         Z759COSAbr = "";
         Z762COSSts = 0;
         Z80COSCueDestino = "";
      }

      protected void InitAll1P58( )
      {
         A79COSCod = "";
         n79COSCod = false;
         AssignAttri("", false, "A79COSCod", A79COSCod);
         InitializeNonKey1P58( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241250", true, true);
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
         context.AddJavascriptSource("cbcostos.js", "?202281810241251", false, true);
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
         edtCOSCod_Internalname = "COSCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCOSDsc_Internalname = "COSDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCOSAbr_Internalname = "COSABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbCOSSts_Internalname = "COSSTS";
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
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbCOSSts_Jsonclick = "";
         cmbCOSSts.Enabled = 1;
         edtCOSAbr_Jsonclick = "";
         edtCOSAbr_Enabled = 1;
         edtCOSDsc_Jsonclick = "";
         edtCOSDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCOSCod_Jsonclick = "";
         edtCOSCod_Enabled = 1;
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
         cmbCOSSts.Name = "COSSTS";
         cmbCOSSts.WebTags = "";
         cmbCOSSts.addItem("1", "ACTIVO", 0);
         cmbCOSSts.addItem("0", "INACTIVO", 0);
         if ( cmbCOSSts.ItemCount > 0 )
         {
            A762COSSts = (short)(NumberUtil.Val( cmbCOSSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0))), "."));
            AssignAttri("", false, "A762COSSts", StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCOSDsc_Internalname;
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

      public void Valid_Coscod( )
      {
         A762COSSts = (short)(NumberUtil.Val( cmbCOSSts.CurrentValue, "."));
         cmbCOSSts.CurrentValue = StringUtil.Str( (decimal)(A762COSSts), 1, 0);
         n79COSCod = false;
         n80COSCueDestino = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbCOSSts.ItemCount > 0 )
         {
            A762COSSts = (short)(NumberUtil.Val( cmbCOSSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0))), "."));
            cmbCOSSts.CurrentValue = StringUtil.Str( (decimal)(A762COSSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A761COSDsc", StringUtil.RTrim( A761COSDsc));
         AssignAttri("", false, "A759COSAbr", StringUtil.RTrim( A759COSAbr));
         AssignAttri("", false, "A762COSSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A762COSSts), 1, 0, ".", "")));
         cmbCOSSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A762COSSts), 1, 0));
         AssignProp("", false, cmbCOSSts_Internalname, "Values", cmbCOSSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A80COSCueDestino", StringUtil.RTrim( A80COSCueDestino));
         AssignAttri("", false, "A760CosCueDestinoDsc", StringUtil.RTrim( A760CosCueDestinoDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z761COSDsc", StringUtil.RTrim( Z761COSDsc));
         GxWebStd.gx_hidden_field( context, "Z759COSAbr", StringUtil.RTrim( Z759COSAbr));
         GxWebStd.gx_hidden_field( context, "Z762COSSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z762COSSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z80COSCueDestino", StringUtil.RTrim( Z80COSCueDestino));
         GxWebStd.gx_hidden_field( context, "Z760CosCueDestinoDsc", StringUtil.RTrim( Z760CosCueDestinoDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A80COSCueDestino',fld:'COSCUEDESTINO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[{av:'cmbCOSSts'},{av:'A762COSSts',fld:'COSSTS',pic:'9'},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A80COSCueDestino',fld:'COSCUEDESTINO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COSCOD",",oparms:[{av:'A761COSDsc',fld:'COSDSC',pic:''},{av:'A759COSAbr',fld:'COSABR',pic:''},{av:'cmbCOSSts'},{av:'A762COSSts',fld:'COSSTS',pic:'9'},{av:'A80COSCueDestino',fld:'COSCUEDESTINO',pic:''},{av:'A760CosCueDestinoDsc',fld:'COSCUEDESTINODSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z79COSCod'},{av:'Z761COSDsc'},{av:'Z759COSAbr'},{av:'Z762COSSts'},{av:'Z80COSCueDestino'},{av:'Z760CosCueDestinoDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z79COSCod = "";
         Z761COSDsc = "";
         Z759COSAbr = "";
         Z80COSCueDestino = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A79COSCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A761COSDsc = "";
         lblTextblock3_Jsonclick = "";
         A759COSAbr = "";
         lblTextblock4_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A80COSCueDestino = "";
         Gx_mode = "";
         A760CosCueDestinoDsc = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z760CosCueDestinoDsc = "";
         T001P4_A760CosCueDestinoDsc = new string[] {""} ;
         T001P5_A79COSCod = new string[] {""} ;
         T001P5_n79COSCod = new bool[] {false} ;
         T001P5_A761COSDsc = new string[] {""} ;
         T001P5_A759COSAbr = new string[] {""} ;
         T001P5_A762COSSts = new short[1] ;
         T001P5_A760CosCueDestinoDsc = new string[] {""} ;
         T001P5_A80COSCueDestino = new string[] {""} ;
         T001P5_n80COSCueDestino = new bool[] {false} ;
         T001P6_A79COSCod = new string[] {""} ;
         T001P6_n79COSCod = new bool[] {false} ;
         T001P3_A79COSCod = new string[] {""} ;
         T001P3_n79COSCod = new bool[] {false} ;
         T001P3_A761COSDsc = new string[] {""} ;
         T001P3_A759COSAbr = new string[] {""} ;
         T001P3_A762COSSts = new short[1] ;
         T001P3_A80COSCueDestino = new string[] {""} ;
         T001P3_n80COSCueDestino = new bool[] {false} ;
         sMode58 = "";
         T001P7_A79COSCod = new string[] {""} ;
         T001P7_n79COSCod = new bool[] {false} ;
         T001P8_A79COSCod = new string[] {""} ;
         T001P8_n79COSCod = new bool[] {false} ;
         T001P2_A79COSCod = new string[] {""} ;
         T001P2_n79COSCod = new bool[] {false} ;
         T001P2_A761COSDsc = new string[] {""} ;
         T001P2_A759COSAbr = new string[] {""} ;
         T001P2_A762COSSts = new short[1] ;
         T001P2_A80COSCueDestino = new string[] {""} ;
         T001P2_n80COSCueDestino = new bool[] {false} ;
         T001P12_A2109AMovCod = new string[] {""} ;
         T001P13_A365EntCod = new int[1] ;
         T001P13_A403MVLEntCod = new string[] {""} ;
         T001P13_A404MVLEITem = new int[1] ;
         T001P14_A365EntCod = new int[1] ;
         T001P14_A403MVLEntCod = new string[] {""} ;
         T001P14_A404MVLEITem = new int[1] ;
         T001P15_A358CajCod = new int[1] ;
         T001P15_A391MVLCajCod = new string[] {""} ;
         T001P15_A392MVLITem = new int[1] ;
         T001P16_A358CajCod = new int[1] ;
         T001P16_A391MVLCajCod = new string[] {""} ;
         T001P16_A392MVLITem = new int[1] ;
         T001P17_A379LBBanCod = new int[1] ;
         T001P17_A380LBCBCod = new string[] {""} ;
         T001P17_A381LBRegistro = new string[] {""} ;
         T001P17_A383LBDITem = new int[1] ;
         T001P18_A289OrdCod = new string[] {""} ;
         T001P19_A149TipCod = new string[] {""} ;
         T001P19_A243ComCod = new string[] {""} ;
         T001P19_A244PrvCod = new string[] {""} ;
         T001P19_A250ComDItem = new short[1] ;
         T001P19_A251ComDOrdCod = new string[] {""} ;
         T001P20_A2280CBTipPre = new int[1] ;
         T001P20_A2281CBTipTipo = new string[] {""} ;
         T001P20_A2282CBLinPre = new int[1] ;
         T001P20_A2283CBRubPre = new int[1] ;
         T001P20_A2284CBRubDItem = new int[1] ;
         T001P21_A2263CBFlujCAno = new short[1] ;
         T001P21_A2264CBFlujCMes = new short[1] ;
         T001P21_A2265CBFlujCBanCod = new int[1] ;
         T001P21_A2266CBFlujCCuenta = new string[] {""} ;
         T001P21_A2267CBFlujCRegistro = new string[] {""} ;
         T001P21_A2268CBFlujCItem = new int[1] ;
         T001P22_A2100ACTActCod = new string[] {""} ;
         T001P23_A127VouAno = new short[1] ;
         T001P23_A128VouMes = new short[1] ;
         T001P23_A126TASICod = new int[1] ;
         T001P23_A129VouNum = new string[] {""} ;
         T001P23_A130VouDSec = new int[1] ;
         T001P24_A79COSCod = new string[] {""} ;
         T001P24_n79COSCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ79COSCod = "";
         ZZ761COSDsc = "";
         ZZ759COSAbr = "";
         ZZ80COSCueDestino = "";
         ZZ760CosCueDestinoDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbcostos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbcostos__default(),
            new Object[][] {
                new Object[] {
               T001P2_A79COSCod, T001P2_A761COSDsc, T001P2_A759COSAbr, T001P2_A762COSSts, T001P2_A80COSCueDestino, T001P2_n80COSCueDestino
               }
               , new Object[] {
               T001P3_A79COSCod, T001P3_A761COSDsc, T001P3_A759COSAbr, T001P3_A762COSSts, T001P3_A80COSCueDestino, T001P3_n80COSCueDestino
               }
               , new Object[] {
               T001P4_A760CosCueDestinoDsc
               }
               , new Object[] {
               T001P5_A79COSCod, T001P5_A761COSDsc, T001P5_A759COSAbr, T001P5_A762COSSts, T001P5_A760CosCueDestinoDsc, T001P5_A80COSCueDestino, T001P5_n80COSCueDestino
               }
               , new Object[] {
               T001P6_A79COSCod
               }
               , new Object[] {
               T001P7_A79COSCod
               }
               , new Object[] {
               T001P8_A79COSCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001P12_A2109AMovCod
               }
               , new Object[] {
               T001P13_A365EntCod, T001P13_A403MVLEntCod, T001P13_A404MVLEITem
               }
               , new Object[] {
               T001P14_A365EntCod, T001P14_A403MVLEntCod, T001P14_A404MVLEITem
               }
               , new Object[] {
               T001P15_A358CajCod, T001P15_A391MVLCajCod, T001P15_A392MVLITem
               }
               , new Object[] {
               T001P16_A358CajCod, T001P16_A391MVLCajCod, T001P16_A392MVLITem
               }
               , new Object[] {
               T001P17_A379LBBanCod, T001P17_A380LBCBCod, T001P17_A381LBRegistro, T001P17_A383LBDITem
               }
               , new Object[] {
               T001P18_A289OrdCod
               }
               , new Object[] {
               T001P19_A149TipCod, T001P19_A243ComCod, T001P19_A244PrvCod, T001P19_A250ComDItem, T001P19_A251ComDOrdCod
               }
               , new Object[] {
               T001P20_A2280CBTipPre, T001P20_A2281CBTipTipo, T001P20_A2282CBLinPre, T001P20_A2283CBRubPre, T001P20_A2284CBRubDItem
               }
               , new Object[] {
               T001P21_A2263CBFlujCAno, T001P21_A2264CBFlujCMes, T001P21_A2265CBFlujCBanCod, T001P21_A2266CBFlujCCuenta, T001P21_A2267CBFlujCRegistro, T001P21_A2268CBFlujCItem
               }
               , new Object[] {
               T001P22_A2100ACTActCod
               }
               , new Object[] {
               T001P23_A127VouAno, T001P23_A128VouMes, T001P23_A126TASICod, T001P23_A129VouNum, T001P23_A130VouDSec
               }
               , new Object[] {
               T001P24_A79COSCod
               }
            }
         );
      }

      private short Z762COSSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A762COSSts ;
      private short GX_JID ;
      private short RcdFound58 ;
      private short nIsDirty_58 ;
      private short Gx_BScreen ;
      private short ZZ762COSSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCOSCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCOSDsc_Enabled ;
      private int edtCOSAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string Z79COSCod ;
      private string Z761COSDsc ;
      private string Z759COSAbr ;
      private string Z80COSCueDestino ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCOSCod_Internalname ;
      private string cmbCOSSts_Internalname ;
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
      private string A79COSCod ;
      private string edtCOSCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCOSDsc_Internalname ;
      private string A761COSDsc ;
      private string edtCOSDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCOSAbr_Internalname ;
      private string A759COSAbr ;
      private string edtCOSAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbCOSSts_Jsonclick ;
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
      private string A80COSCueDestino ;
      private string Gx_mode ;
      private string A760CosCueDestinoDsc ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z760CosCueDestinoDsc ;
      private string sMode58 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ79COSCod ;
      private string ZZ761COSDsc ;
      private string ZZ759COSAbr ;
      private string ZZ80COSCueDestino ;
      private string ZZ760CosCueDestinoDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n80COSCueDestino ;
      private bool n79COSCod ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCOSSts ;
      private IDataStoreProvider pr_default ;
      private string[] T001P4_A760CosCueDestinoDsc ;
      private string[] T001P5_A79COSCod ;
      private bool[] T001P5_n79COSCod ;
      private string[] T001P5_A761COSDsc ;
      private string[] T001P5_A759COSAbr ;
      private short[] T001P5_A762COSSts ;
      private string[] T001P5_A760CosCueDestinoDsc ;
      private string[] T001P5_A80COSCueDestino ;
      private bool[] T001P5_n80COSCueDestino ;
      private string[] T001P6_A79COSCod ;
      private bool[] T001P6_n79COSCod ;
      private string[] T001P3_A79COSCod ;
      private bool[] T001P3_n79COSCod ;
      private string[] T001P3_A761COSDsc ;
      private string[] T001P3_A759COSAbr ;
      private short[] T001P3_A762COSSts ;
      private string[] T001P3_A80COSCueDestino ;
      private bool[] T001P3_n80COSCueDestino ;
      private string[] T001P7_A79COSCod ;
      private bool[] T001P7_n79COSCod ;
      private string[] T001P8_A79COSCod ;
      private bool[] T001P8_n79COSCod ;
      private string[] T001P2_A79COSCod ;
      private bool[] T001P2_n79COSCod ;
      private string[] T001P2_A761COSDsc ;
      private string[] T001P2_A759COSAbr ;
      private short[] T001P2_A762COSSts ;
      private string[] T001P2_A80COSCueDestino ;
      private bool[] T001P2_n80COSCueDestino ;
      private string[] T001P12_A2109AMovCod ;
      private int[] T001P13_A365EntCod ;
      private string[] T001P13_A403MVLEntCod ;
      private int[] T001P13_A404MVLEITem ;
      private int[] T001P14_A365EntCod ;
      private string[] T001P14_A403MVLEntCod ;
      private int[] T001P14_A404MVLEITem ;
      private int[] T001P15_A358CajCod ;
      private string[] T001P15_A391MVLCajCod ;
      private int[] T001P15_A392MVLITem ;
      private int[] T001P16_A358CajCod ;
      private string[] T001P16_A391MVLCajCod ;
      private int[] T001P16_A392MVLITem ;
      private int[] T001P17_A379LBBanCod ;
      private string[] T001P17_A380LBCBCod ;
      private string[] T001P17_A381LBRegistro ;
      private int[] T001P17_A383LBDITem ;
      private string[] T001P18_A289OrdCod ;
      private string[] T001P19_A149TipCod ;
      private string[] T001P19_A243ComCod ;
      private string[] T001P19_A244PrvCod ;
      private short[] T001P19_A250ComDItem ;
      private string[] T001P19_A251ComDOrdCod ;
      private int[] T001P20_A2280CBTipPre ;
      private string[] T001P20_A2281CBTipTipo ;
      private int[] T001P20_A2282CBLinPre ;
      private int[] T001P20_A2283CBRubPre ;
      private int[] T001P20_A2284CBRubDItem ;
      private short[] T001P21_A2263CBFlujCAno ;
      private short[] T001P21_A2264CBFlujCMes ;
      private int[] T001P21_A2265CBFlujCBanCod ;
      private string[] T001P21_A2266CBFlujCCuenta ;
      private string[] T001P21_A2267CBFlujCRegistro ;
      private int[] T001P21_A2268CBFlujCItem ;
      private string[] T001P22_A2100ACTActCod ;
      private short[] T001P23_A127VouAno ;
      private short[] T001P23_A128VouMes ;
      private int[] T001P23_A126TASICod ;
      private string[] T001P23_A129VouNum ;
      private int[] T001P23_A130VouDSec ;
      private string[] T001P24_A79COSCod ;
      private bool[] T001P24_n79COSCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cbcostos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbcostos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001P4;
        prmT001P4 = new Object[] {
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001P5;
        prmT001P5 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P6;
        prmT001P6 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P3;
        prmT001P3 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P7;
        prmT001P7 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P8;
        prmT001P8 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P2;
        prmT001P2 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P9;
        prmT001P9 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@COSDsc",GXType.NChar,100,0) ,
        new ParDef("@COSAbr",GXType.NChar,5,0) ,
        new ParDef("@COSSts",GXType.Int16,1,0) ,
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001P10;
        prmT001P10 = new Object[] {
        new ParDef("@COSDsc",GXType.NChar,100,0) ,
        new ParDef("@COSAbr",GXType.NChar,5,0) ,
        new ParDef("@COSSts",GXType.Int16,1,0) ,
        new ParDef("@COSCueDestino",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P11;
        prmT001P11 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P12;
        prmT001P12 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P13;
        prmT001P13 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P14;
        prmT001P14 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P15;
        prmT001P15 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P16;
        prmT001P16 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P17;
        prmT001P17 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P18;
        prmT001P18 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P19;
        prmT001P19 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P20;
        prmT001P20 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P21;
        prmT001P21 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P22;
        prmT001P22 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P23;
        prmT001P23 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001P24;
        prmT001P24 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001P2", "SELECT [COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino] AS COSCueDestino FROM [CBCOSTOS] WITH (UPDLOCK) WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P3", "SELECT [COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino] AS COSCueDestino FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P4", "SELECT [CueDsc] AS CosCueDestinoDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @COSCueDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P5", "SELECT TM1.[COSCod], TM1.[COSDsc], TM1.[COSAbr], TM1.[COSSts], T2.[CueDsc] AS CosCueDestinoDsc, TM1.[COSCueDestino] AS COSCueDestino FROM ([CBCOSTOS] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[COSCueDestino]) WHERE TM1.[COSCod] = @COSCod ORDER BY TM1.[COSCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P6", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001P7", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE ( [COSCod] > @COSCod) ORDER BY [COSCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P8", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE ( [COSCod] < @COSCod) ORDER BY [COSCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P9", "INSERT INTO [CBCOSTOS]([COSCod], [COSDsc], [COSAbr], [COSSts], [COSCueDestino]) VALUES(@COSCod, @COSDsc, @COSAbr, @COSSts, @COSCueDestino)", GxErrorMask.GX_NOMASK,prmT001P9)
           ,new CursorDef("T001P10", "UPDATE [CBCOSTOS] SET [COSDsc]=@COSDsc, [COSAbr]=@COSAbr, [COSSts]=@COSSts, [COSCueDestino]=@COSCueDestino  WHERE [COSCod] = @COSCod", GxErrorMask.GX_NOMASK,prmT001P10)
           ,new CursorDef("T001P11", "DELETE FROM [CBCOSTOS]  WHERE [COSCod] = @COSCod", GxErrorMask.GX_NOMASK,prmT001P11)
           ,new CursorDef("T001P12", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE [AMovCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P13", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P14", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLECosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P15", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P16", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P17", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBDCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P18", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P19", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComCosCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P20", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P21", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro], [CBFlujCItem] FROM [CBFLUJOCONCEPTOSDET] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P22", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P23", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001P23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001P24", "SELECT [COSCod] FROM [CBCOSTOS] ORDER BY [COSCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001P24,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
