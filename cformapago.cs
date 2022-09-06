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
   public class cformapago : GXHttpHandler
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
            Form.Meta.addItem("description", "Formas de Pago", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cformapago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cformapago( IGxContext context )
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
         chkForBanSts = new GXCheckbox();
         cmbForSts = new GXCombobox();
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
         A987ForBanSts = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         if ( cmbForSts.ItemCount > 0 )
         {
            A989ForSts = (short)(NumberUtil.Val( cmbForSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0))), "."));
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            AssignProp("", false, cmbForSts_Internalname, "Values", cmbForSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2C81( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CFORMAPAGO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo forma pago", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Forma de pago", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForDsc_Internalname, StringUtil.RTrim( A988ForDsc), StringUtil.RTrim( context.localUtil.Format( A988ForDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura forma pago", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForAbr_Internalname, StringUtil.RTrim( A986ForAbr), StringUtil.RTrim( context.localUtil.Format( A986ForAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cod.Sunat", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForSunat_Internalname, StringUtil.RTrim( A990ForSunat), StringUtil.RTrim( context.localUtil.Format( A990ForSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Afecta Banco", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkForBanSts_Internalname, StringUtil.Str( (decimal)(A987ForBanSts), 1, 0), "", "", 1, chkForBanSts.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Situacion forma pago", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CFORMAPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbForSts, cmbForSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0)), 1, cmbForSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbForSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 1, "HLP_CFORMAPAGO.htm");
         cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         AssignProp("", false, cmbForSts_Internalname, "Values", (string)(cmbForSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFORMAPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CFORMAPAGO.htm");
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
            Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
            Z988ForDsc = cgiGet( "Z988ForDsc");
            Z986ForAbr = cgiGet( "Z986ForAbr");
            Z990ForSunat = cgiGet( "Z990ForSunat");
            Z987ForBanSts = (short)(context.localUtil.CToN( cgiGet( "Z987ForBanSts"), ".", ","));
            Z989ForSts = (short)(context.localUtil.CToN( cgiGet( "Z989ForSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORCOD");
               AnyError = 1;
               GX_FocusControl = edtForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A143ForCod = 0;
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            else
            {
               A143ForCod = (int)(context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ","));
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            A988ForDsc = cgiGet( edtForDsc_Internalname);
            AssignAttri("", false, "A988ForDsc", A988ForDsc);
            A986ForAbr = cgiGet( edtForAbr_Internalname);
            AssignAttri("", false, "A986ForAbr", A986ForAbr);
            A990ForSunat = cgiGet( edtForSunat_Internalname);
            AssignAttri("", false, "A990ForSunat", A990ForSunat);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORBANSTS");
               AnyError = 1;
               GX_FocusControl = chkForBanSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A987ForBanSts = 0;
               AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            }
            else
            {
               A987ForBanSts = (short)(((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            }
            cmbForSts.CurrentValue = cgiGet( cmbForSts_Internalname);
            A989ForSts = (short)(NumberUtil.Val( cgiGet( cmbForSts_Internalname), "."));
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
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
               A143ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
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
               InitAll2C81( ) ;
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
         DisableAttributes2C81( ) ;
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

      protected void CONFIRM_2C0( )
      {
         BeforeValidate2C81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2C81( ) ;
            }
            else
            {
               CheckExtendedTable2C81( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2C81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2C0( ) ;
         }
      }

      protected void ResetCaption2C0( )
      {
      }

      protected void ZM2C81( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z988ForDsc = T002C3_A988ForDsc[0];
               Z986ForAbr = T002C3_A986ForAbr[0];
               Z990ForSunat = T002C3_A990ForSunat[0];
               Z987ForBanSts = T002C3_A987ForBanSts[0];
               Z989ForSts = T002C3_A989ForSts[0];
            }
            else
            {
               Z988ForDsc = A988ForDsc;
               Z986ForAbr = A986ForAbr;
               Z990ForSunat = A990ForSunat;
               Z987ForBanSts = A987ForBanSts;
               Z989ForSts = A989ForSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z143ForCod = A143ForCod;
            Z988ForDsc = A988ForDsc;
            Z986ForAbr = A986ForAbr;
            Z990ForSunat = A990ForSunat;
            Z987ForBanSts = A987ForBanSts;
            Z989ForSts = A989ForSts;
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

      protected void Load2C81( )
      {
         /* Using cursor T002C4 */
         pr_default.execute(2, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound81 = 1;
            A988ForDsc = T002C4_A988ForDsc[0];
            AssignAttri("", false, "A988ForDsc", A988ForDsc);
            A986ForAbr = T002C4_A986ForAbr[0];
            AssignAttri("", false, "A986ForAbr", A986ForAbr);
            A990ForSunat = T002C4_A990ForSunat[0];
            AssignAttri("", false, "A990ForSunat", A990ForSunat);
            A987ForBanSts = T002C4_A987ForBanSts[0];
            AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            A989ForSts = T002C4_A989ForSts[0];
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            ZM2C81( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2C81( ) ;
      }

      protected void OnLoadActions2C81( )
      {
      }

      protected void CheckExtendedTable2C81( )
      {
         nIsDirty_81 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2C81( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2C81( )
      {
         /* Using cursor T002C5 */
         pr_default.execute(3, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002C3 */
         pr_default.execute(1, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2C81( 1) ;
            RcdFound81 = 1;
            A143ForCod = T002C3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A988ForDsc = T002C3_A988ForDsc[0];
            AssignAttri("", false, "A988ForDsc", A988ForDsc);
            A986ForAbr = T002C3_A986ForAbr[0];
            AssignAttri("", false, "A986ForAbr", A986ForAbr);
            A990ForSunat = T002C3_A990ForSunat[0];
            AssignAttri("", false, "A990ForSunat", A990ForSunat);
            A987ForBanSts = T002C3_A987ForBanSts[0];
            AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            A989ForSts = T002C3_A989ForSts[0];
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            Z143ForCod = A143ForCod;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2C81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey2C81( ) ;
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey2C81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2C81( ) ;
         if ( RcdFound81 == 0 )
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
         RcdFound81 = 0;
         /* Using cursor T002C6 */
         pr_default.execute(4, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002C6_A143ForCod[0] < A143ForCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002C6_A143ForCod[0] > A143ForCod ) ) )
            {
               A143ForCod = T002C6_A143ForCod[0];
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound81 = 0;
         /* Using cursor T002C7 */
         pr_default.execute(5, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002C7_A143ForCod[0] > A143ForCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002C7_A143ForCod[0] < A143ForCod ) ) )
            {
               A143ForCod = T002C7_A143ForCod[0];
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2C81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2C81( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A143ForCod != Z143ForCod )
               {
                  A143ForCod = Z143ForCod;
                  AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FORCOD");
                  AnyError = 1;
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2C81( ) ;
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A143ForCod != Z143ForCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2C81( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FORCOD");
                     AnyError = 1;
                     GX_FocusControl = edtForCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtForCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2C81( ) ;
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
         if ( A143ForCod != Z143ForCod )
         {
            A143ForCod = Z143ForCod;
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtForCod_Internalname;
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
         GetKey2C81( ) ;
         if ( RcdFound81 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "FORCOD");
               AnyError = 1;
               GX_FocusControl = edtForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A143ForCod != Z143ForCod )
            {
               A143ForCod = Z143ForCod;
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "FORCOD");
               AnyError = 1;
               GX_FocusControl = edtForCod_Internalname;
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
            if ( A143ForCod != Z143ForCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FORCOD");
                  AnyError = 1;
                  GX_FocusControl = edtForCod_Internalname;
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
         context.RollbackDataStores("cformapago",pr_default);
         GX_FocusControl = edtForDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2C0( ) ;
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
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtForDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2C81( ) ;
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtForDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2C81( ) ;
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
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtForDsc_Internalname;
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
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtForDsc_Internalname;
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
         ScanStart2C81( ) ;
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound81 != 0 )
            {
               ScanNext2C81( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtForDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2C81( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2C81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002C2 */
            pr_default.execute(0, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFORMAPAGO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z988ForDsc, T002C2_A988ForDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z986ForAbr, T002C2_A986ForAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z990ForSunat, T002C2_A990ForSunat[0]) != 0 ) || ( Z987ForBanSts != T002C2_A987ForBanSts[0] ) || ( Z989ForSts != T002C2_A989ForSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z988ForDsc, T002C2_A988ForDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cformapago:[seudo value changed for attri]"+"ForDsc");
                  GXUtil.WriteLogRaw("Old: ",Z988ForDsc);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A988ForDsc[0]);
               }
               if ( StringUtil.StrCmp(Z986ForAbr, T002C2_A986ForAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cformapago:[seudo value changed for attri]"+"ForAbr");
                  GXUtil.WriteLogRaw("Old: ",Z986ForAbr);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A986ForAbr[0]);
               }
               if ( StringUtil.StrCmp(Z990ForSunat, T002C2_A990ForSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("cformapago:[seudo value changed for attri]"+"ForSunat");
                  GXUtil.WriteLogRaw("Old: ",Z990ForSunat);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A990ForSunat[0]);
               }
               if ( Z987ForBanSts != T002C2_A987ForBanSts[0] )
               {
                  GXUtil.WriteLog("cformapago:[seudo value changed for attri]"+"ForBanSts");
                  GXUtil.WriteLogRaw("Old: ",Z987ForBanSts);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A987ForBanSts[0]);
               }
               if ( Z989ForSts != T002C2_A989ForSts[0] )
               {
                  GXUtil.WriteLog("cformapago:[seudo value changed for attri]"+"ForSts");
                  GXUtil.WriteLogRaw("Old: ",Z989ForSts);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A989ForSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CFORMAPAGO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2C81( )
      {
         BeforeValidate2C81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2C81( 0) ;
            CheckOptimisticConcurrency2C81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2C81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002C8 */
                     pr_default.execute(6, new Object[] {A143ForCod, A988ForDsc, A986ForAbr, A990ForSunat, A987ForBanSts, A989ForSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
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
                           ResetCaption2C0( ) ;
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
               Load2C81( ) ;
            }
            EndLevel2C81( ) ;
         }
         CloseExtendedTableCursors2C81( ) ;
      }

      protected void Update2C81( )
      {
         BeforeValidate2C81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2C81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002C9 */
                     pr_default.execute(7, new Object[] {A988ForDsc, A986ForAbr, A990ForSunat, A987ForBanSts, A989ForSts, A143ForCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFORMAPAGO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2C81( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2C0( ) ;
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
            EndLevel2C81( ) ;
         }
         CloseExtendedTableCursors2C81( ) ;
      }

      protected void DeferredUpdate2C81( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2C81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2C81( ) ;
            AfterConfirm2C81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2C81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002C10 */
                  pr_default.execute(8, new Object[] {A143ForCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound81 == 0 )
                        {
                           InitAll2C81( ) ;
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
                        ResetCaption2C0( ) ;
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2C81( ) ;
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2C81( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002C11 */
            pr_default.execute(9, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T002C12 */
            pr_default.execute(10, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T002C13 */
            pr_default.execute(11, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T002C14 */
            pr_default.execute(12, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T002C15 */
            pr_default.execute(13, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T002C16 */
            pr_default.execute(14, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002C17 */
            pr_default.execute(15, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T002C18 */
            pr_default.execute(16, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T002C19 */
            pr_default.execute(17, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T002C20 */
            pr_default.execute(18, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002C21 */
            pr_default.execute(19, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retención"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002C22 */
            pr_default.execute(20, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel2C81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2C81( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cformapago",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cformapago",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2C81( )
      {
         /* Using cursor T002C23 */
         pr_default.execute(21);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound81 = 1;
            A143ForCod = T002C23_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2C81( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound81 = 1;
            A143ForCod = T002C23_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
      }

      protected void ScanEnd2C81( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm2C81( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2C81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2C81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2C81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2C81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2C81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2C81( )
      {
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         edtForDsc_Enabled = 0;
         AssignProp("", false, edtForDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForDsc_Enabled), 5, 0), true);
         edtForAbr_Enabled = 0;
         AssignProp("", false, edtForAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForAbr_Enabled), 5, 0), true);
         edtForSunat_Enabled = 0;
         AssignProp("", false, edtForSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForSunat_Enabled), 5, 0), true);
         chkForBanSts.Enabled = 0;
         AssignProp("", false, chkForBanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkForBanSts.Enabled), 5, 0), true);
         cmbForSts.Enabled = 0;
         AssignProp("", false, cmbForSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbForSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2C81( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2C0( )
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
         context.SendWebValue( "Formas de Pago") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810243054", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cformapago.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z988ForDsc", StringUtil.RTrim( Z988ForDsc));
         GxWebStd.gx_hidden_field( context, "Z986ForAbr", StringUtil.RTrim( Z986ForAbr));
         GxWebStd.gx_hidden_field( context, "Z990ForSunat", StringUtil.RTrim( Z990ForSunat));
         GxWebStd.gx_hidden_field( context, "Z987ForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z987ForBanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z989ForSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z989ForSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm2C81( )
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
         return "CFORMAPAGO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Formas de Pago" ;
      }

      protected void InitializeNonKey2C81( )
      {
         A988ForDsc = "";
         AssignAttri("", false, "A988ForDsc", A988ForDsc);
         A986ForAbr = "";
         AssignAttri("", false, "A986ForAbr", A986ForAbr);
         A990ForSunat = "";
         AssignAttri("", false, "A990ForSunat", A990ForSunat);
         A987ForBanSts = 0;
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         A989ForSts = 0;
         AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         Z988ForDsc = "";
         Z986ForAbr = "";
         Z990ForSunat = "";
         Z987ForBanSts = 0;
         Z989ForSts = 0;
      }

      protected void InitAll2C81( )
      {
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         InitializeNonKey2C81( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810243061", true, true);
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
         context.AddJavascriptSource("cformapago.js", "?202281810243061", false, true);
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
         edtForCod_Internalname = "FORCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtForDsc_Internalname = "FORDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtForAbr_Internalname = "FORABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtForSunat_Internalname = "FORSUNAT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         chkForBanSts_Internalname = "FORBANSTS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         cmbForSts_Internalname = "FORSTS";
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
         cmbForSts_Jsonclick = "";
         cmbForSts.Enabled = 1;
         chkForBanSts.Enabled = 1;
         edtForSunat_Jsonclick = "";
         edtForSunat_Enabled = 1;
         edtForAbr_Jsonclick = "";
         edtForAbr_Enabled = 1;
         edtForDsc_Jsonclick = "";
         edtForDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
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
         chkForBanSts.Name = "FORBANSTS";
         chkForBanSts.WebTags = "";
         chkForBanSts.Caption = "";
         AssignProp("", false, chkForBanSts_Internalname, "TitleCaption", chkForBanSts.Caption, true);
         chkForBanSts.CheckedValue = "0";
         A987ForBanSts = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         cmbForSts.Name = "FORSTS";
         cmbForSts.WebTags = "";
         cmbForSts.addItem("1", "ACTIVO", 0);
         cmbForSts.addItem("0", "INACTIVO", 0);
         if ( cmbForSts.ItemCount > 0 )
         {
            A989ForSts = (short)(NumberUtil.Val( cmbForSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0))), "."));
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtForDsc_Internalname;
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

      public void Valid_Forcod( )
      {
         A989ForSts = (short)(NumberUtil.Val( cmbForSts.CurrentValue, "."));
         cmbForSts.CurrentValue = StringUtil.Str( (decimal)(A989ForSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A987ForBanSts = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         if ( cmbForSts.ItemCount > 0 )
         {
            A989ForSts = (short)(NumberUtil.Val( cmbForSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0))), "."));
            cmbForSts.CurrentValue = StringUtil.Str( (decimal)(A989ForSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A988ForDsc", StringUtil.RTrim( A988ForDsc));
         AssignAttri("", false, "A986ForAbr", StringUtil.RTrim( A986ForAbr));
         AssignAttri("", false, "A990ForSunat", StringUtil.RTrim( A990ForSunat));
         AssignAttri("", false, "A987ForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")));
         AssignAttri("", false, "A989ForSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A989ForSts), 1, 0, ".", "")));
         cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         AssignProp("", false, cmbForSts_Internalname, "Values", cmbForSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z988ForDsc", StringUtil.RTrim( Z988ForDsc));
         GxWebStd.gx_hidden_field( context, "Z986ForAbr", StringUtil.RTrim( Z986ForAbr));
         GxWebStd.gx_hidden_field( context, "Z990ForSunat", StringUtil.RTrim( Z990ForSunat));
         GxWebStd.gx_hidden_field( context, "Z987ForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z987ForBanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z989ForSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z989ForSts), 1, 0, ".", "")));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'cmbForSts'},{av:'A989ForSts',fld:'FORSTS',pic:'9'},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[{av:'A988ForDsc',fld:'FORDSC',pic:''},{av:'A986ForAbr',fld:'FORABR',pic:''},{av:'A990ForSunat',fld:'FORSUNAT',pic:''},{av:'cmbForSts'},{av:'A989ForSts',fld:'FORSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z143ForCod'},{av:'Z988ForDsc'},{av:'Z986ForAbr'},{av:'Z990ForSunat'},{av:'Z987ForBanSts'},{av:'Z989ForSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
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
         Z988ForDsc = "";
         Z986ForAbr = "";
         Z990ForSunat = "";
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
         A988ForDsc = "";
         lblTextblock3_Jsonclick = "";
         A986ForAbr = "";
         lblTextblock4_Jsonclick = "";
         A990ForSunat = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
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
         T002C4_A143ForCod = new int[1] ;
         T002C4_A988ForDsc = new string[] {""} ;
         T002C4_A986ForAbr = new string[] {""} ;
         T002C4_A990ForSunat = new string[] {""} ;
         T002C4_A987ForBanSts = new short[1] ;
         T002C4_A989ForSts = new short[1] ;
         T002C5_A143ForCod = new int[1] ;
         T002C3_A143ForCod = new int[1] ;
         T002C3_A988ForDsc = new string[] {""} ;
         T002C3_A986ForAbr = new string[] {""} ;
         T002C3_A990ForSunat = new string[] {""} ;
         T002C3_A987ForBanSts = new short[1] ;
         T002C3_A989ForSts = new short[1] ;
         sMode81 = "";
         T002C6_A143ForCod = new int[1] ;
         T002C7_A143ForCod = new int[1] ;
         T002C2_A143ForCod = new int[1] ;
         T002C2_A988ForDsc = new string[] {""} ;
         T002C2_A986ForAbr = new string[] {""} ;
         T002C2_A990ForSunat = new string[] {""} ;
         T002C2_A987ForBanSts = new short[1] ;
         T002C2_A989ForSts = new short[1] ;
         T002C11_A412PagReg = new long[1] ;
         T002C12_A365EntCod = new int[1] ;
         T002C12_A403MVLEntCod = new string[] {""} ;
         T002C12_A404MVLEITem = new int[1] ;
         T002C13_A358CajCod = new int[1] ;
         T002C13_A391MVLCajCod = new string[] {""} ;
         T002C13_A392MVLITem = new int[1] ;
         T002C14_A379LBBanCod = new int[1] ;
         T002C14_A380LBCBCod = new string[] {""} ;
         T002C14_A381LBRegistro = new string[] {""} ;
         T002C14_A383LBDITem = new int[1] ;
         T002C15_A379LBBanCod = new int[1] ;
         T002C15_A380LBCBCod = new string[] {""} ;
         T002C15_A381LBRegistro = new string[] {""} ;
         T002C16_A365EntCod = new int[1] ;
         T002C16_A366AperEntCod = new string[] {""} ;
         T002C17_A358CajCod = new int[1] ;
         T002C17_A359AperCajCod = new string[] {""} ;
         T002C18_A270LiqCod = new string[] {""} ;
         T002C18_A236LiqPrvCod = new string[] {""} ;
         T002C18_A271LiqCodItem = new int[1] ;
         T002C19_A423TSTransCod = new string[] {""} ;
         T002C20_A387TSMovCod = new string[] {""} ;
         T002C21_A302CPRetCod = new string[] {""} ;
         T002C22_A166CobTip = new string[] {""} ;
         T002C22_A167CobCod = new string[] {""} ;
         T002C22_A173Item = new int[1] ;
         T002C23_A143ForCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ988ForDsc = "";
         ZZ986ForAbr = "";
         ZZ990ForSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cformapago__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cformapago__default(),
            new Object[][] {
                new Object[] {
               T002C2_A143ForCod, T002C2_A988ForDsc, T002C2_A986ForAbr, T002C2_A990ForSunat, T002C2_A987ForBanSts, T002C2_A989ForSts
               }
               , new Object[] {
               T002C3_A143ForCod, T002C3_A988ForDsc, T002C3_A986ForAbr, T002C3_A990ForSunat, T002C3_A987ForBanSts, T002C3_A989ForSts
               }
               , new Object[] {
               T002C4_A143ForCod, T002C4_A988ForDsc, T002C4_A986ForAbr, T002C4_A990ForSunat, T002C4_A987ForBanSts, T002C4_A989ForSts
               }
               , new Object[] {
               T002C5_A143ForCod
               }
               , new Object[] {
               T002C6_A143ForCod
               }
               , new Object[] {
               T002C7_A143ForCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002C11_A412PagReg
               }
               , new Object[] {
               T002C12_A365EntCod, T002C12_A403MVLEntCod, T002C12_A404MVLEITem
               }
               , new Object[] {
               T002C13_A358CajCod, T002C13_A391MVLCajCod, T002C13_A392MVLITem
               }
               , new Object[] {
               T002C14_A379LBBanCod, T002C14_A380LBCBCod, T002C14_A381LBRegistro, T002C14_A383LBDITem
               }
               , new Object[] {
               T002C15_A379LBBanCod, T002C15_A380LBCBCod, T002C15_A381LBRegistro
               }
               , new Object[] {
               T002C16_A365EntCod, T002C16_A366AperEntCod
               }
               , new Object[] {
               T002C17_A358CajCod, T002C17_A359AperCajCod
               }
               , new Object[] {
               T002C18_A270LiqCod, T002C18_A236LiqPrvCod, T002C18_A271LiqCodItem
               }
               , new Object[] {
               T002C19_A423TSTransCod
               }
               , new Object[] {
               T002C20_A387TSMovCod
               }
               , new Object[] {
               T002C21_A302CPRetCod
               }
               , new Object[] {
               T002C22_A166CobTip, T002C22_A167CobCod, T002C22_A173Item
               }
               , new Object[] {
               T002C23_A143ForCod
               }
            }
         );
      }

      private short Z987ForBanSts ;
      private short Z989ForSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A987ForBanSts ;
      private short A989ForSts ;
      private short GX_JID ;
      private short RcdFound81 ;
      private short nIsDirty_81 ;
      private short Gx_BScreen ;
      private short ZZ987ForBanSts ;
      private short ZZ989ForSts ;
      private int Z143ForCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A143ForCod ;
      private int edtForCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtForDsc_Enabled ;
      private int edtForAbr_Enabled ;
      private int edtForSunat_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ143ForCod ;
      private string sPrefix ;
      private string Z988ForDsc ;
      private string Z986ForAbr ;
      private string Z990ForSunat ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtForCod_Internalname ;
      private string cmbForSts_Internalname ;
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
      private string edtForCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtForDsc_Internalname ;
      private string A988ForDsc ;
      private string edtForDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtForAbr_Internalname ;
      private string A986ForAbr ;
      private string edtForAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtForSunat_Internalname ;
      private string A990ForSunat ;
      private string edtForSunat_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string chkForBanSts_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string cmbForSts_Jsonclick ;
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
      private string sMode81 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ988ForDsc ;
      private string ZZ986ForAbr ;
      private string ZZ990ForSunat ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkForBanSts ;
      private GXCombobox cmbForSts ;
      private IDataStoreProvider pr_default ;
      private int[] T002C4_A143ForCod ;
      private string[] T002C4_A988ForDsc ;
      private string[] T002C4_A986ForAbr ;
      private string[] T002C4_A990ForSunat ;
      private short[] T002C4_A987ForBanSts ;
      private short[] T002C4_A989ForSts ;
      private int[] T002C5_A143ForCod ;
      private int[] T002C3_A143ForCod ;
      private string[] T002C3_A988ForDsc ;
      private string[] T002C3_A986ForAbr ;
      private string[] T002C3_A990ForSunat ;
      private short[] T002C3_A987ForBanSts ;
      private short[] T002C3_A989ForSts ;
      private int[] T002C6_A143ForCod ;
      private int[] T002C7_A143ForCod ;
      private int[] T002C2_A143ForCod ;
      private string[] T002C2_A988ForDsc ;
      private string[] T002C2_A986ForAbr ;
      private string[] T002C2_A990ForSunat ;
      private short[] T002C2_A987ForBanSts ;
      private short[] T002C2_A989ForSts ;
      private long[] T002C11_A412PagReg ;
      private int[] T002C12_A365EntCod ;
      private string[] T002C12_A403MVLEntCod ;
      private int[] T002C12_A404MVLEITem ;
      private int[] T002C13_A358CajCod ;
      private string[] T002C13_A391MVLCajCod ;
      private int[] T002C13_A392MVLITem ;
      private int[] T002C14_A379LBBanCod ;
      private string[] T002C14_A380LBCBCod ;
      private string[] T002C14_A381LBRegistro ;
      private int[] T002C14_A383LBDITem ;
      private int[] T002C15_A379LBBanCod ;
      private string[] T002C15_A380LBCBCod ;
      private string[] T002C15_A381LBRegistro ;
      private int[] T002C16_A365EntCod ;
      private string[] T002C16_A366AperEntCod ;
      private int[] T002C17_A358CajCod ;
      private string[] T002C17_A359AperCajCod ;
      private string[] T002C18_A270LiqCod ;
      private string[] T002C18_A236LiqPrvCod ;
      private int[] T002C18_A271LiqCodItem ;
      private string[] T002C19_A423TSTransCod ;
      private string[] T002C20_A387TSMovCod ;
      private string[] T002C21_A302CPRetCod ;
      private string[] T002C22_A166CobTip ;
      private string[] T002C22_A167CobCod ;
      private int[] T002C22_A173Item ;
      private int[] T002C23_A143ForCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cformapago__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cformapago__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002C4;
        prmT002C4 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C5;
        prmT002C5 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C3;
        prmT002C3 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C6;
        prmT002C6 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C7;
        prmT002C7 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C2;
        prmT002C2 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C8;
        prmT002C8 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@ForDsc",GXType.NChar,100,0) ,
        new ParDef("@ForAbr",GXType.NChar,5,0) ,
        new ParDef("@ForSunat",GXType.NChar,5,0) ,
        new ParDef("@ForBanSts",GXType.Int16,1,0) ,
        new ParDef("@ForSts",GXType.Int16,1,0)
        };
        Object[] prmT002C9;
        prmT002C9 = new Object[] {
        new ParDef("@ForDsc",GXType.NChar,100,0) ,
        new ParDef("@ForAbr",GXType.NChar,5,0) ,
        new ParDef("@ForSunat",GXType.NChar,5,0) ,
        new ParDef("@ForBanSts",GXType.Int16,1,0) ,
        new ParDef("@ForSts",GXType.Int16,1,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C10;
        prmT002C10 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C11;
        prmT002C11 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C12;
        prmT002C12 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C13;
        prmT002C13 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C14;
        prmT002C14 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C15;
        prmT002C15 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C16;
        prmT002C16 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C17;
        prmT002C17 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C18;
        prmT002C18 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C19;
        prmT002C19 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C20;
        prmT002C20 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C21;
        prmT002C21 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C22;
        prmT002C22 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002C23;
        prmT002C23 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002C2", "SELECT [ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts] FROM [CFORMAPAGO] WITH (UPDLOCK) WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002C3", "SELECT [ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002C4", "SELECT TM1.[ForCod], TM1.[ForDsc], TM1.[ForAbr], TM1.[ForSunat], TM1.[ForBanSts], TM1.[ForSts] FROM [CFORMAPAGO] TM1 WHERE TM1.[ForCod] = @ForCod ORDER BY TM1.[ForCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002C5", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002C6", "SELECT TOP 1 [ForCod] FROM [CFORMAPAGO] WHERE ( [ForCod] > @ForCod) ORDER BY [ForCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002C6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C7", "SELECT TOP 1 [ForCod] FROM [CFORMAPAGO] WHERE ( [ForCod] < @ForCod) ORDER BY [ForCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002C7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C8", "INSERT INTO [CFORMAPAGO]([ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts]) VALUES(@ForCod, @ForDsc, @ForAbr, @ForSunat, @ForBanSts, @ForSts)", GxErrorMask.GX_NOMASK,prmT002C8)
           ,new CursorDef("T002C9", "UPDATE [CFORMAPAGO] SET [ForDsc]=@ForDsc, [ForAbr]=@ForAbr, [ForSunat]=@ForSunat, [ForBanSts]=@ForBanSts, [ForSts]=@ForSts  WHERE [ForCod] = @ForCod", GxErrorMask.GX_NOMASK,prmT002C9)
           ,new CursorDef("T002C10", "DELETE FROM [CFORMAPAGO]  WHERE [ForCod] = @ForCod", GxErrorMask.GX_NOMASK,prmT002C10)
           ,new CursorDef("T002C11", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C12", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C13", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C14", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBDForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C15", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C16", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C17", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C18", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C19", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C20", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C21", "SELECT TOP 1 [CPRetCod] FROM [CPRETENCION] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C22", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002C23", "SELECT [ForCod] FROM [CFORMAPAGO] ORDER BY [ForCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002C23,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
