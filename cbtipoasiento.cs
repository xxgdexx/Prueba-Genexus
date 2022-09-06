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
   public class cbtipoasiento : GXHttpHandler
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
            Form.Meta.addItem("description", "Tipo de Asiento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbtipoasiento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbtipoasiento( IGxContext context )
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
         cmbTASISts = new GXCombobox();
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
         if ( cmbTASISts.ItemCount > 0 )
         {
            A1896TASISts = (short)(NumberUtil.Val( cmbTASISts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0))), "."));
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            AssignProp("", false, cmbTASISts_Internalname, "Values", cmbTASISts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2271( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBTIPOASIENTO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo Asiento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126TASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo Asiento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASIDsc_Internalname, StringUtil.RTrim( A1895TASIDsc), StringUtil.RTrim( context.localUtil.Format( A1895TASIDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASIDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASIDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASIAbr_Internalname, StringUtil.RTrim( A1894TASIAbr), StringUtil.RTrim( context.localUtil.Format( A1894TASIAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASIAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASIAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBTIPOASIENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTASISts, cmbTASISts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0)), 1, cmbTASISts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTASISts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CBTIPOASIENTO.htm");
         cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         AssignProp("", false, cmbTASISts_Internalname, "Values", (string)(cmbTASISts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBTIPOASIENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBTIPOASIENTO.htm");
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
            Z126TASICod = (int)(context.localUtil.CToN( cgiGet( "Z126TASICod"), ".", ","));
            Z1895TASIDsc = cgiGet( "Z1895TASIDsc");
            Z1894TASIAbr = cgiGet( "Z1894TASIAbr");
            Z1896TASISts = (short)(context.localUtil.CToN( cgiGet( "Z1896TASISts"), ".", ","));
            Z2256TASISunat = cgiGet( "Z2256TASISunat");
            A2256TASISunat = cgiGet( "Z2256TASISunat");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A2256TASISunat = cgiGet( "TASISUNAT");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TASICOD");
               AnyError = 1;
               GX_FocusControl = edtTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A126TASICod = 0;
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            }
            else
            {
               A126TASICod = (int)(context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            }
            A1895TASIDsc = cgiGet( edtTASIDsc_Internalname);
            AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
            A1894TASIAbr = cgiGet( edtTASIAbr_Internalname);
            AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
            cmbTASISts.CurrentValue = cgiGet( cmbTASISts_Internalname);
            A1896TASISts = (short)(NumberUtil.Val( cgiGet( cmbTASISts_Internalname), "."));
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CBTIPOASIENTO");
            forbiddenHiddens.Add("TASISunat", StringUtil.RTrim( context.localUtil.Format( A2256TASISunat, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A126TASICod != Z126TASICod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cbtipoasiento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
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
               InitAll2271( ) ;
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
         DisableAttributes2271( ) ;
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

      protected void CONFIRM_220( )
      {
         BeforeValidate2271( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2271( ) ;
            }
            else
            {
               CheckExtendedTable2271( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2271( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues220( ) ;
         }
      }

      protected void ResetCaption220( )
      {
      }

      protected void ZM2271( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1895TASIDsc = T00223_A1895TASIDsc[0];
               Z1894TASIAbr = T00223_A1894TASIAbr[0];
               Z1896TASISts = T00223_A1896TASISts[0];
               Z2256TASISunat = T00223_A2256TASISunat[0];
            }
            else
            {
               Z1895TASIDsc = A1895TASIDsc;
               Z1894TASIAbr = A1894TASIAbr;
               Z1896TASISts = A1896TASISts;
               Z2256TASISunat = A2256TASISunat;
            }
         }
         if ( GX_JID == -1 )
         {
            Z126TASICod = A126TASICod;
            Z1895TASIDsc = A1895TASIDsc;
            Z1894TASIAbr = A1894TASIAbr;
            Z1896TASISts = A1896TASISts;
            Z2256TASISunat = A2256TASISunat;
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

      protected void Load2271( )
      {
         /* Using cursor T00224 */
         pr_default.execute(2, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound71 = 1;
            A1895TASIDsc = T00224_A1895TASIDsc[0];
            AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
            A1894TASIAbr = T00224_A1894TASIAbr[0];
            AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
            A1896TASISts = T00224_A1896TASISts[0];
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            A2256TASISunat = T00224_A2256TASISunat[0];
            ZM2271( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2271( ) ;
      }

      protected void OnLoadActions2271( )
      {
      }

      protected void CheckExtendedTable2271( )
      {
         nIsDirty_71 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2271( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2271( )
      {
         /* Using cursor T00225 */
         pr_default.execute(3, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00223 */
         pr_default.execute(1, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2271( 1) ;
            RcdFound71 = 1;
            A126TASICod = T00223_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A1895TASIDsc = T00223_A1895TASIDsc[0];
            AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
            A1894TASIAbr = T00223_A1894TASIAbr[0];
            AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
            A1896TASISts = T00223_A1896TASISts[0];
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
            A2256TASISunat = T00223_A2256TASISunat[0];
            Z126TASICod = A126TASICod;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2271( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey2271( ) ;
            }
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey2271( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode71;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2271( ) ;
         if ( RcdFound71 == 0 )
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
         RcdFound71 = 0;
         /* Using cursor T00226 */
         pr_default.execute(4, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00226_A126TASICod[0] < A126TASICod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00226_A126TASICod[0] > A126TASICod ) ) )
            {
               A126TASICod = T00226_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound71 = 0;
         /* Using cursor T00227 */
         pr_default.execute(5, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00227_A126TASICod[0] > A126TASICod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00227_A126TASICod[0] < A126TASICod ) ) )
            {
               A126TASICod = T00227_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               RcdFound71 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2271( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2271( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A126TASICod != Z126TASICod )
               {
                  A126TASICod = Z126TASICod;
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TASICOD");
                  AnyError = 1;
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2271( ) ;
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A126TASICod != Z126TASICod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTASICod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2271( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TASICOD");
                     AnyError = 1;
                     GX_FocusControl = edtTASICod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTASICod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2271( ) ;
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
         if ( A126TASICod != Z126TASICod )
         {
            A126TASICod = Z126TASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTASICod_Internalname;
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
         GetKey2271( ) ;
         if ( RcdFound71 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TASICOD");
               AnyError = 1;
               GX_FocusControl = edtTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A126TASICod != Z126TASICod )
            {
               A126TASICod = Z126TASICod;
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TASICOD");
               AnyError = 1;
               GX_FocusControl = edtTASICod_Internalname;
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
            if ( A126TASICod != Z126TASICod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TASICOD");
                  AnyError = 1;
                  GX_FocusControl = edtTASICod_Internalname;
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
         context.RollbackDataStores("cbtipoasiento",pr_default);
         GX_FocusControl = edtTASIDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_220( ) ;
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
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTASIDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2271( ) ;
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTASIDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2271( ) ;
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
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTASIDsc_Internalname;
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
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTASIDsc_Internalname;
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
         ScanStart2271( ) ;
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound71 != 0 )
            {
               ScanNext2271( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTASIDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2271( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2271( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00222 */
            pr_default.execute(0, new Object[] {A126TASICod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBTIPOASIENTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1895TASIDsc, T00222_A1895TASIDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1894TASIAbr, T00222_A1894TASIAbr[0]) != 0 ) || ( Z1896TASISts != T00222_A1896TASISts[0] ) || ( StringUtil.StrCmp(Z2256TASISunat, T00222_A2256TASISunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1895TASIDsc, T00222_A1895TASIDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbtipoasiento:[seudo value changed for attri]"+"TASIDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1895TASIDsc);
                  GXUtil.WriteLogRaw("Current: ",T00222_A1895TASIDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1894TASIAbr, T00222_A1894TASIAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cbtipoasiento:[seudo value changed for attri]"+"TASIAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1894TASIAbr);
                  GXUtil.WriteLogRaw("Current: ",T00222_A1894TASIAbr[0]);
               }
               if ( Z1896TASISts != T00222_A1896TASISts[0] )
               {
                  GXUtil.WriteLog("cbtipoasiento:[seudo value changed for attri]"+"TASISts");
                  GXUtil.WriteLogRaw("Old: ",Z1896TASISts);
                  GXUtil.WriteLogRaw("Current: ",T00222_A1896TASISts[0]);
               }
               if ( StringUtil.StrCmp(Z2256TASISunat, T00222_A2256TASISunat[0]) != 0 )
               {
                  GXUtil.WriteLog("cbtipoasiento:[seudo value changed for attri]"+"TASISunat");
                  GXUtil.WriteLogRaw("Old: ",Z2256TASISunat);
                  GXUtil.WriteLogRaw("Current: ",T00222_A2256TASISunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBTIPOASIENTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2271( )
      {
         BeforeValidate2271( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2271( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2271( 0) ;
            CheckOptimisticConcurrency2271( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2271( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2271( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00228 */
                     pr_default.execute(6, new Object[] {A126TASICod, A1895TASIDsc, A1894TASIAbr, A1896TASISts, A2256TASISunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
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
                           ResetCaption220( ) ;
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
               Load2271( ) ;
            }
            EndLevel2271( ) ;
         }
         CloseExtendedTableCursors2271( ) ;
      }

      protected void Update2271( )
      {
         BeforeValidate2271( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2271( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2271( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2271( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2271( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00229 */
                     pr_default.execute(7, new Object[] {A1895TASIDsc, A1894TASIAbr, A1896TASISts, A2256TASISunat, A126TASICod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBTIPOASIENTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2271( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption220( ) ;
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
            EndLevel2271( ) ;
         }
         CloseExtendedTableCursors2271( ) ;
      }

      protected void DeferredUpdate2271( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2271( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2271( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2271( ) ;
            AfterConfirm2271( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2271( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002210 */
                  pr_default.execute(8, new Object[] {A126TASICod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBTIPOASIENTO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound71 == 0 )
                        {
                           InitAll2271( ) ;
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
                        ResetCaption220( ) ;
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
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2271( ) ;
         Gx_mode = sMode71;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2271( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002211 */
            pr_default.execute(9, new Object[] {A126TASICod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel2271( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2271( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbtipoasiento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues220( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbtipoasiento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2271( )
      {
         /* Using cursor T002212 */
         pr_default.execute(10);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
            A126TASICod = T002212_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2271( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound71 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
            A126TASICod = T002212_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         }
      }

      protected void ScanEnd2271( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2271( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2271( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2271( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2271( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2271( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2271( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2271( )
      {
         edtTASICod_Enabled = 0;
         AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
         edtTASIDsc_Enabled = 0;
         AssignProp("", false, edtTASIDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASIDsc_Enabled), 5, 0), true);
         edtTASIAbr_Enabled = 0;
         AssignProp("", false, edtTASIAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASIAbr_Enabled), 5, 0), true);
         cmbTASISts.Enabled = 0;
         AssignProp("", false, cmbTASISts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTASISts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2271( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues220( )
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
         context.SendWebValue( "Tipo de Asiento") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241793", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbtipoasiento.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CBTIPOASIENTO");
         forbiddenHiddens.Add("TASISunat", StringUtil.RTrim( context.localUtil.Format( A2256TASISunat, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cbtipoasiento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1895TASIDsc", StringUtil.RTrim( Z1895TASIDsc));
         GxWebStd.gx_hidden_field( context, "Z1894TASIAbr", StringUtil.RTrim( Z1894TASIAbr));
         GxWebStd.gx_hidden_field( context, "Z1896TASISts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1896TASISts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2256TASISunat", StringUtil.RTrim( Z2256TASISunat));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TASISUNAT", StringUtil.RTrim( A2256TASISunat));
      }

      protected void RenderHtmlCloseForm2271( )
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
         return "CBTIPOASIENTO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Asiento" ;
      }

      protected void InitializeNonKey2271( )
      {
         A1895TASIDsc = "";
         AssignAttri("", false, "A1895TASIDsc", A1895TASIDsc);
         A1894TASIAbr = "";
         AssignAttri("", false, "A1894TASIAbr", A1894TASIAbr);
         A1896TASISts = 0;
         AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         A2256TASISunat = "";
         AssignAttri("", false, "A2256TASISunat", A2256TASISunat);
         Z1895TASIDsc = "";
         Z1894TASIAbr = "";
         Z1896TASISts = 0;
         Z2256TASISunat = "";
      }

      protected void InitAll2271( )
      {
         A126TASICod = 0;
         AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         InitializeNonKey2271( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241798", true, true);
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
         context.AddJavascriptSource("cbtipoasiento.js", "?202281810241798", false, true);
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
         edtTASICod_Internalname = "TASICOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTASIDsc_Internalname = "TASIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTASIAbr_Internalname = "TASIABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbTASISts_Internalname = "TASISTS";
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
         cmbTASISts_Jsonclick = "";
         cmbTASISts.Enabled = 1;
         edtTASIAbr_Jsonclick = "";
         edtTASIAbr_Enabled = 1;
         edtTASIDsc_Jsonclick = "";
         edtTASIDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTASICod_Jsonclick = "";
         edtTASICod_Enabled = 1;
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
         cmbTASISts.Name = "TASISTS";
         cmbTASISts.WebTags = "";
         cmbTASISts.addItem("1", "ACTIVO", 0);
         cmbTASISts.addItem("0", "INACTIVO", 0);
         if ( cmbTASISts.ItemCount > 0 )
         {
            A1896TASISts = (short)(NumberUtil.Val( cmbTASISts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0))), "."));
            AssignAttri("", false, "A1896TASISts", StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTASIDsc_Internalname;
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

      public void Valid_Tasicod( )
      {
         A1896TASISts = (short)(NumberUtil.Val( cmbTASISts.CurrentValue, "."));
         cmbTASISts.CurrentValue = StringUtil.Str( (decimal)(A1896TASISts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTASISts.ItemCount > 0 )
         {
            A1896TASISts = (short)(NumberUtil.Val( cmbTASISts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0))), "."));
            cmbTASISts.CurrentValue = StringUtil.Str( (decimal)(A1896TASISts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1895TASIDsc", StringUtil.RTrim( A1895TASIDsc));
         AssignAttri("", false, "A1894TASIAbr", StringUtil.RTrim( A1894TASIAbr));
         AssignAttri("", false, "A1896TASISts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1896TASISts), 1, 0, ".", "")));
         cmbTASISts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1896TASISts), 1, 0));
         AssignProp("", false, cmbTASISts_Internalname, "Values", cmbTASISts.ToJavascriptSource(), true);
         AssignAttri("", false, "A2256TASISunat", StringUtil.RTrim( A2256TASISunat));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1895TASIDsc", StringUtil.RTrim( Z1895TASIDsc));
         GxWebStd.gx_hidden_field( context, "Z1894TASIAbr", StringUtil.RTrim( Z1894TASIAbr));
         GxWebStd.gx_hidden_field( context, "Z1896TASISts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1896TASISts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2256TASISunat", StringUtil.RTrim( Z2256TASISunat));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2256TASISunat',fld:'TASISUNAT',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TASICOD","{handler:'Valid_Tasicod',iparms:[{av:'A2256TASISunat',fld:'TASISUNAT',pic:''},{av:'cmbTASISts'},{av:'A1896TASISts',fld:'TASISTS',pic:'9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TASICOD",",oparms:[{av:'A1895TASIDsc',fld:'TASIDSC',pic:''},{av:'A1894TASIAbr',fld:'TASIABR',pic:''},{av:'cmbTASISts'},{av:'A1896TASISts',fld:'TASISTS',pic:'9'},{av:'A2256TASISunat',fld:'TASISUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z126TASICod'},{av:'Z1895TASIDsc'},{av:'Z1894TASIAbr'},{av:'Z1896TASISts'},{av:'Z2256TASISunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1895TASIDsc = "";
         Z1894TASIAbr = "";
         Z2256TASISunat = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1895TASIDsc = "";
         lblTextblock3_Jsonclick = "";
         A1894TASIAbr = "";
         lblTextblock4_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A2256TASISunat = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00224_A126TASICod = new int[1] ;
         T00224_A1895TASIDsc = new string[] {""} ;
         T00224_A1894TASIAbr = new string[] {""} ;
         T00224_A1896TASISts = new short[1] ;
         T00224_A2256TASISunat = new string[] {""} ;
         T00225_A126TASICod = new int[1] ;
         T00223_A126TASICod = new int[1] ;
         T00223_A1895TASIDsc = new string[] {""} ;
         T00223_A1894TASIAbr = new string[] {""} ;
         T00223_A1896TASISts = new short[1] ;
         T00223_A2256TASISunat = new string[] {""} ;
         sMode71 = "";
         T00226_A126TASICod = new int[1] ;
         T00227_A126TASICod = new int[1] ;
         T00222_A126TASICod = new int[1] ;
         T00222_A1895TASIDsc = new string[] {""} ;
         T00222_A1894TASIAbr = new string[] {""} ;
         T00222_A1896TASISts = new short[1] ;
         T00222_A2256TASISunat = new string[] {""} ;
         T002211_A127VouAno = new short[1] ;
         T002211_A128VouMes = new short[1] ;
         T002211_A126TASICod = new int[1] ;
         T002211_A129VouNum = new string[] {""} ;
         T002212_A126TASICod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1895TASIDsc = "";
         ZZ1894TASIAbr = "";
         ZZ2256TASISunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbtipoasiento__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbtipoasiento__default(),
            new Object[][] {
                new Object[] {
               T00222_A126TASICod, T00222_A1895TASIDsc, T00222_A1894TASIAbr, T00222_A1896TASISts, T00222_A2256TASISunat
               }
               , new Object[] {
               T00223_A126TASICod, T00223_A1895TASIDsc, T00223_A1894TASIAbr, T00223_A1896TASISts, T00223_A2256TASISunat
               }
               , new Object[] {
               T00224_A126TASICod, T00224_A1895TASIDsc, T00224_A1894TASIAbr, T00224_A1896TASISts, T00224_A2256TASISunat
               }
               , new Object[] {
               T00225_A126TASICod
               }
               , new Object[] {
               T00226_A126TASICod
               }
               , new Object[] {
               T00227_A126TASICod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002211_A127VouAno, T002211_A128VouMes, T002211_A126TASICod, T002211_A129VouNum
               }
               , new Object[] {
               T002212_A126TASICod
               }
            }
         );
      }

      private short Z1896TASISts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1896TASISts ;
      private short GX_JID ;
      private short RcdFound71 ;
      private short nIsDirty_71 ;
      private short Gx_BScreen ;
      private short ZZ1896TASISts ;
      private int Z126TASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A126TASICod ;
      private int edtTASICod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTASIDsc_Enabled ;
      private int edtTASIAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ126TASICod ;
      private string sPrefix ;
      private string Z1895TASIDsc ;
      private string Z1894TASIAbr ;
      private string Z2256TASISunat ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTASICod_Internalname ;
      private string cmbTASISts_Internalname ;
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
      private string edtTASICod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTASIDsc_Internalname ;
      private string A1895TASIDsc ;
      private string edtTASIDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTASIAbr_Internalname ;
      private string A1894TASIAbr ;
      private string edtTASIAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbTASISts_Jsonclick ;
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
      private string A2256TASISunat ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode71 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1895TASIDsc ;
      private string ZZ1894TASIAbr ;
      private string ZZ2256TASISunat ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTASISts ;
      private IDataStoreProvider pr_default ;
      private int[] T00224_A126TASICod ;
      private string[] T00224_A1895TASIDsc ;
      private string[] T00224_A1894TASIAbr ;
      private short[] T00224_A1896TASISts ;
      private string[] T00224_A2256TASISunat ;
      private int[] T00225_A126TASICod ;
      private int[] T00223_A126TASICod ;
      private string[] T00223_A1895TASIDsc ;
      private string[] T00223_A1894TASIAbr ;
      private short[] T00223_A1896TASISts ;
      private string[] T00223_A2256TASISunat ;
      private int[] T00226_A126TASICod ;
      private int[] T00227_A126TASICod ;
      private int[] T00222_A126TASICod ;
      private string[] T00222_A1895TASIDsc ;
      private string[] T00222_A1894TASIAbr ;
      private short[] T00222_A1896TASISts ;
      private string[] T00222_A2256TASISunat ;
      private short[] T002211_A127VouAno ;
      private short[] T002211_A128VouMes ;
      private int[] T002211_A126TASICod ;
      private string[] T002211_A129VouNum ;
      private int[] T002212_A126TASICod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cbtipoasiento__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbtipoasiento__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00224;
        prmT00224 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00225;
        prmT00225 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00223;
        prmT00223 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00226;
        prmT00226 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00227;
        prmT00227 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00222;
        prmT00222 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00228;
        prmT00228 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@TASIDsc",GXType.NChar,100,0) ,
        new ParDef("@TASIAbr",GXType.NChar,5,0) ,
        new ParDef("@TASISts",GXType.Int16,1,0) ,
        new ParDef("@TASISunat",GXType.NChar,5,0)
        };
        Object[] prmT00229;
        prmT00229 = new Object[] {
        new ParDef("@TASIDsc",GXType.NChar,100,0) ,
        new ParDef("@TASIAbr",GXType.NChar,5,0) ,
        new ParDef("@TASISts",GXType.Int16,1,0) ,
        new ParDef("@TASISunat",GXType.NChar,5,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002210;
        prmT002210 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002211;
        prmT002211 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002212;
        prmT002212 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00222", "SELECT [TASICod], [TASIDsc], [TASIAbr], [TASISts], [TASISunat] FROM [CBTIPOASIENTO] WITH (UPDLOCK) WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00222,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00223", "SELECT [TASICod], [TASIDsc], [TASIAbr], [TASISts], [TASISunat] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00223,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00224", "SELECT TM1.[TASICod], TM1.[TASIDsc], TM1.[TASIAbr], TM1.[TASISts], TM1.[TASISunat] FROM [CBTIPOASIENTO] TM1 WHERE TM1.[TASICod] = @TASICod ORDER BY TM1.[TASICod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00224,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00225", "SELECT [TASICod] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00225,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00226", "SELECT TOP 1 [TASICod] FROM [CBTIPOASIENTO] WHERE ( [TASICod] > @TASICod) ORDER BY [TASICod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00226,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00227", "SELECT TOP 1 [TASICod] FROM [CBTIPOASIENTO] WHERE ( [TASICod] < @TASICod) ORDER BY [TASICod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00227,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00228", "INSERT INTO [CBTIPOASIENTO]([TASICod], [TASIDsc], [TASIAbr], [TASISts], [TASISunat]) VALUES(@TASICod, @TASIDsc, @TASIAbr, @TASISts, @TASISunat)", GxErrorMask.GX_NOMASK,prmT00228)
           ,new CursorDef("T00229", "UPDATE [CBTIPOASIENTO] SET [TASIDsc]=@TASIDsc, [TASIAbr]=@TASIAbr, [TASISts]=@TASISts, [TASISunat]=@TASISunat  WHERE [TASICod] = @TASICod", GxErrorMask.GX_NOMASK,prmT00229)
           ,new CursorDef("T002210", "DELETE FROM [CBTIPOASIENTO]  WHERE [TASICod] = @TASICod", GxErrorMask.GX_NOMASK,prmT002210)
           ,new CursorDef("T002211", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002212", "SELECT [TASICod] FROM [CBTIPOASIENTO] ORDER BY [TASICod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002212,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
