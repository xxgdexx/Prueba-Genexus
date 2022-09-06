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
   public class ctiposlistas : GXHttpHandler
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
            Form.Meta.addItem("description", "Tipos de Listas de Precios", 0) ;
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

      public ctiposlistas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctiposlistas( IGxContext context )
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
         cmbTipLSts = new GXCombobox();
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
         if ( cmbTipLSts.ItemCount > 0 )
         {
            A1914TipLSts = (short)(NumberUtil.Val( cmbTipLSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0))), "."));
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            AssignProp("", false, cmbTipLSts_Internalname, "Values", cmbTipLSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm3V134( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPOSLISTAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Tipo de Lista", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipLCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Lista", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLDsc_Internalname, StringUtil.RTrim( A1912TipLDsc), StringUtil.RTrim( context.localUtil.Format( A1912TipLDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr.T.Lista", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLAbr_Internalname, StringUtil.RTrim( A1911TipLAbr), StringUtil.RTrim( context.localUtil.Format( A1911TipLAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOSLISTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipLSts, cmbTipLSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0)), 1, cmbTipLSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTipLSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CTIPOSLISTAS.htm");
         cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         AssignProp("", false, cmbTipLSts_Internalname, "Values", (string)(cmbTipLSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOSLISTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPOSLISTAS.htm");
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
            Z202TipLCod = (int)(context.localUtil.CToN( cgiGet( "Z202TipLCod"), ".", ","));
            Z1912TipLDsc = cgiGet( "Z1912TipLDsc");
            Z1911TipLAbr = cgiGet( "Z1911TipLAbr");
            Z1914TipLSts = (short)(context.localUtil.CToN( cgiGet( "Z1914TipLSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
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
            A1912TipLDsc = cgiGet( edtTipLDsc_Internalname);
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A1911TipLAbr = cgiGet( edtTipLAbr_Internalname);
            AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
            cmbTipLSts.CurrentValue = cgiGet( cmbTipLSts_Internalname);
            A1914TipLSts = (short)(NumberUtil.Val( cgiGet( cmbTipLSts_Internalname), "."));
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
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
               A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
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
               InitAll3V134( ) ;
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
         DisableAttributes3V134( ) ;
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

      protected void CONFIRM_3V0( )
      {
         BeforeValidate3V134( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3V134( ) ;
            }
            else
            {
               CheckExtendedTable3V134( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3V134( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3V0( ) ;
         }
      }

      protected void ResetCaption3V0( )
      {
      }

      protected void ZM3V134( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1912TipLDsc = T003V3_A1912TipLDsc[0];
               Z1911TipLAbr = T003V3_A1911TipLAbr[0];
               Z1914TipLSts = T003V3_A1914TipLSts[0];
            }
            else
            {
               Z1912TipLDsc = A1912TipLDsc;
               Z1911TipLAbr = A1911TipLAbr;
               Z1914TipLSts = A1914TipLSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z202TipLCod = A202TipLCod;
            Z1912TipLDsc = A1912TipLDsc;
            Z1911TipLAbr = A1911TipLAbr;
            Z1914TipLSts = A1914TipLSts;
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

      protected void Load3V134( )
      {
         /* Using cursor T003V4 */
         pr_default.execute(2, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound134 = 1;
            A1912TipLDsc = T003V4_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A1911TipLAbr = T003V4_A1911TipLAbr[0];
            AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
            A1914TipLSts = T003V4_A1914TipLSts[0];
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            ZM3V134( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3V134( ) ;
      }

      protected void OnLoadActions3V134( )
      {
      }

      protected void CheckExtendedTable3V134( )
      {
         nIsDirty_134 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3V134( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3V134( )
      {
         /* Using cursor T003V5 */
         pr_default.execute(3, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound134 = 1;
         }
         else
         {
            RcdFound134 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003V3 */
         pr_default.execute(1, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3V134( 1) ;
            RcdFound134 = 1;
            A202TipLCod = T003V3_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A1912TipLDsc = T003V3_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A1911TipLAbr = T003V3_A1911TipLAbr[0];
            AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
            A1914TipLSts = T003V3_A1914TipLSts[0];
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            Z202TipLCod = A202TipLCod;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3V134( ) ;
            if ( AnyError == 1 )
            {
               RcdFound134 = 0;
               InitializeNonKey3V134( ) ;
            }
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound134 = 0;
            InitializeNonKey3V134( ) ;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3V134( ) ;
         if ( RcdFound134 == 0 )
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
         RcdFound134 = 0;
         /* Using cursor T003V6 */
         pr_default.execute(4, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003V6_A202TipLCod[0] < A202TipLCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003V6_A202TipLCod[0] > A202TipLCod ) ) )
            {
               A202TipLCod = T003V6_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound134 = 0;
         /* Using cursor T003V7 */
         pr_default.execute(5, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003V7_A202TipLCod[0] > A202TipLCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003V7_A202TipLCod[0] < A202TipLCod ) ) )
            {
               A202TipLCod = T003V7_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3V134( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3V134( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound134 == 1 )
            {
               if ( A202TipLCod != Z202TipLCod )
               {
                  A202TipLCod = Z202TipLCod;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
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
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3V134( ) ;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A202TipLCod != Z202TipLCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3V134( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3V134( ) ;
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
         if ( A202TipLCod != Z202TipLCod )
         {
            A202TipLCod = Z202TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
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
         GetKey3V134( ) ;
         if ( RcdFound134 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A202TipLCod != Z202TipLCod )
            {
               A202TipLCod = Z202TipLCod;
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtTipLCod_Internalname;
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
            if ( A202TipLCod != Z202TipLCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
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
         context.RollbackDataStores("ctiposlistas",pr_default);
         GX_FocusControl = edtTipLDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3V0( ) ;
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
         if ( RcdFound134 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipLDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3V134( ) ;
         if ( RcdFound134 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipLDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3V134( ) ;
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
         if ( RcdFound134 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipLDsc_Internalname;
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
         if ( RcdFound134 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipLDsc_Internalname;
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
         ScanStart3V134( ) ;
         if ( RcdFound134 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound134 != 0 )
            {
               ScanNext3V134( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipLDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3V134( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3V134( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003V2 */
            pr_default.execute(0, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOSLISTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1912TipLDsc, T003V2_A1912TipLDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1911TipLAbr, T003V2_A1911TipLAbr[0]) != 0 ) || ( Z1914TipLSts != T003V2_A1914TipLSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1912TipLDsc, T003V2_A1912TipLDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctiposlistas:[seudo value changed for attri]"+"TipLDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1912TipLDsc);
                  GXUtil.WriteLogRaw("Current: ",T003V2_A1912TipLDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1911TipLAbr, T003V2_A1911TipLAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ctiposlistas:[seudo value changed for attri]"+"TipLAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1911TipLAbr);
                  GXUtil.WriteLogRaw("Current: ",T003V2_A1911TipLAbr[0]);
               }
               if ( Z1914TipLSts != T003V2_A1914TipLSts[0] )
               {
                  GXUtil.WriteLog("ctiposlistas:[seudo value changed for attri]"+"TipLSts");
                  GXUtil.WriteLogRaw("Old: ",Z1914TipLSts);
                  GXUtil.WriteLogRaw("Current: ",T003V2_A1914TipLSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOSLISTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3V134( )
      {
         BeforeValidate3V134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3V134( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3V134( 0) ;
            CheckOptimisticConcurrency3V134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3V134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3V134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003V8 */
                     pr_default.execute(6, new Object[] {A202TipLCod, A1912TipLDsc, A1911TipLAbr, A1914TipLSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
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
                           ResetCaption3V0( ) ;
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
               Load3V134( ) ;
            }
            EndLevel3V134( ) ;
         }
         CloseExtendedTableCursors3V134( ) ;
      }

      protected void Update3V134( )
      {
         BeforeValidate3V134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3V134( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3V134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3V134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3V134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003V9 */
                     pr_default.execute(7, new Object[] {A1912TipLDsc, A1911TipLAbr, A1914TipLSts, A202TipLCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOSLISTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3V134( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3V0( ) ;
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
            EndLevel3V134( ) ;
         }
         CloseExtendedTableCursors3V134( ) ;
      }

      protected void DeferredUpdate3V134( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3V134( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3V134( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3V134( ) ;
            AfterConfirm3V134( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3V134( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003V10 */
                  pr_default.execute(8, new Object[] {A202TipLCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound134 == 0 )
                        {
                           InitAll3V134( ) ;
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
                        ResetCaption3V0( ) ;
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
         sMode134 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3V134( ) ;
         Gx_mode = sMode134;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3V134( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003V11 */
            pr_default.execute(9, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003V12 */
            pr_default.execute(10, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T003V13 */
            pr_default.execute(11, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T003V14 */
            pr_default.execute(12, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T003V15 */
            pr_default.execute(13, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel3V134( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3V134( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctiposlistas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctiposlistas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3V134( )
      {
         /* Using cursor T003V16 */
         pr_default.execute(14);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound134 = 1;
            A202TipLCod = T003V16_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3V134( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound134 = 1;
            A202TipLCod = T003V16_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
      }

      protected void ScanEnd3V134( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm3V134( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3V134( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3V134( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3V134( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3V134( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3V134( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3V134( )
      {
         edtTipLCod_Enabled = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         edtTipLDsc_Enabled = 0;
         AssignProp("", false, edtTipLDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLDsc_Enabled), 5, 0), true);
         edtTipLAbr_Enabled = 0;
         AssignProp("", false, edtTipLAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLAbr_Enabled), 5, 0), true);
         cmbTipLSts.Enabled = 0;
         AssignProp("", false, cmbTipLSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipLSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3V134( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3V0( )
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
         context.SendWebValue( "Tipos de Listas de Precios") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252493", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctiposlistas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1912TipLDsc", StringUtil.RTrim( Z1912TipLDsc));
         GxWebStd.gx_hidden_field( context, "Z1911TipLAbr", StringUtil.RTrim( Z1911TipLAbr));
         GxWebStd.gx_hidden_field( context, "Z1914TipLSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1914TipLSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3V134( )
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
         return "CTIPOSLISTAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Listas de Precios" ;
      }

      protected void InitializeNonKey3V134( )
      {
         A1912TipLDsc = "";
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         A1911TipLAbr = "";
         AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
         A1914TipLSts = 0;
         AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         Z1912TipLDsc = "";
         Z1911TipLAbr = "";
         Z1914TipLSts = 0;
      }

      protected void InitAll3V134( )
      {
         A202TipLCod = 0;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         InitializeNonKey3V134( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252498", true, true);
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
         context.AddJavascriptSource("ctiposlistas.js", "?202281810252499", false, true);
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
         edtTipLCod_Internalname = "TIPLCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipLDsc_Internalname = "TIPLDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipLAbr_Internalname = "TIPLABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbTipLSts_Internalname = "TIPLSTS";
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
         cmbTipLSts_Jsonclick = "";
         cmbTipLSts.Enabled = 1;
         edtTipLAbr_Jsonclick = "";
         edtTipLAbr_Enabled = 1;
         edtTipLDsc_Jsonclick = "";
         edtTipLDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipLCod_Jsonclick = "";
         edtTipLCod_Enabled = 1;
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
         cmbTipLSts.Name = "TIPLSTS";
         cmbTipLSts.WebTags = "";
         cmbTipLSts.addItem("1", "ACTIVO", 0);
         cmbTipLSts.addItem("0", "INACTIVO", 0);
         if ( cmbTipLSts.ItemCount > 0 )
         {
            A1914TipLSts = (short)(NumberUtil.Val( cmbTipLSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0))), "."));
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTipLDsc_Internalname;
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

      public void Valid_Tiplcod( )
      {
         A1914TipLSts = (short)(NumberUtil.Val( cmbTipLSts.CurrentValue, "."));
         cmbTipLSts.CurrentValue = StringUtil.Str( (decimal)(A1914TipLSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTipLSts.ItemCount > 0 )
         {
            A1914TipLSts = (short)(NumberUtil.Val( cmbTipLSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0))), "."));
            cmbTipLSts.CurrentValue = StringUtil.Str( (decimal)(A1914TipLSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1912TipLDsc", StringUtil.RTrim( A1912TipLDsc));
         AssignAttri("", false, "A1911TipLAbr", StringUtil.RTrim( A1911TipLAbr));
         AssignAttri("", false, "A1914TipLSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1914TipLSts), 1, 0, ".", "")));
         cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         AssignProp("", false, cmbTipLSts_Internalname, "Values", cmbTipLSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1912TipLDsc", StringUtil.RTrim( Z1912TipLDsc));
         GxWebStd.gx_hidden_field( context, "Z1911TipLAbr", StringUtil.RTrim( Z1911TipLAbr));
         GxWebStd.gx_hidden_field( context, "Z1914TipLSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1914TipLSts), 1, 0, ".", "")));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPLCOD","{handler:'Valid_Tiplcod',iparms:[{av:'cmbTipLSts'},{av:'A1914TipLSts',fld:'TIPLSTS',pic:'9'},{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPLCOD",",oparms:[{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''},{av:'A1911TipLAbr',fld:'TIPLABR',pic:''},{av:'cmbTipLSts'},{av:'A1914TipLSts',fld:'TIPLSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z202TipLCod'},{av:'Z1912TipLDsc'},{av:'Z1911TipLAbr'},{av:'Z1914TipLSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1912TipLDsc = "";
         Z1911TipLAbr = "";
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
         A1912TipLDsc = "";
         lblTextblock3_Jsonclick = "";
         A1911TipLAbr = "";
         lblTextblock4_Jsonclick = "";
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
         T003V4_A202TipLCod = new int[1] ;
         T003V4_A1912TipLDsc = new string[] {""} ;
         T003V4_A1911TipLAbr = new string[] {""} ;
         T003V4_A1914TipLSts = new short[1] ;
         T003V5_A202TipLCod = new int[1] ;
         T003V3_A202TipLCod = new int[1] ;
         T003V3_A1912TipLDsc = new string[] {""} ;
         T003V3_A1911TipLAbr = new string[] {""} ;
         T003V3_A1914TipLSts = new short[1] ;
         sMode134 = "";
         T003V6_A202TipLCod = new int[1] ;
         T003V7_A202TipLCod = new int[1] ;
         T003V2_A202TipLCod = new int[1] ;
         T003V2_A1912TipLDsc = new string[] {""} ;
         T003V2_A1911TipLAbr = new string[] {""} ;
         T003V2_A1914TipLSts = new short[1] ;
         T003V11_A149TipCod = new string[] {""} ;
         T003V11_A24DocNum = new string[] {""} ;
         T003V12_A210PedCod = new string[] {""} ;
         T003V13_A202TipLCod = new int[1] ;
         T003V13_A203TipLItem = new int[1] ;
         T003V14_A177CotCod = new string[] {""} ;
         T003V15_A45CliCod = new string[] {""} ;
         T003V16_A202TipLCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1912TipLDsc = "";
         ZZ1911TipLAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctiposlistas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctiposlistas__default(),
            new Object[][] {
                new Object[] {
               T003V2_A202TipLCod, T003V2_A1912TipLDsc, T003V2_A1911TipLAbr, T003V2_A1914TipLSts
               }
               , new Object[] {
               T003V3_A202TipLCod, T003V3_A1912TipLDsc, T003V3_A1911TipLAbr, T003V3_A1914TipLSts
               }
               , new Object[] {
               T003V4_A202TipLCod, T003V4_A1912TipLDsc, T003V4_A1911TipLAbr, T003V4_A1914TipLSts
               }
               , new Object[] {
               T003V5_A202TipLCod
               }
               , new Object[] {
               T003V6_A202TipLCod
               }
               , new Object[] {
               T003V7_A202TipLCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003V11_A149TipCod, T003V11_A24DocNum
               }
               , new Object[] {
               T003V12_A210PedCod
               }
               , new Object[] {
               T003V13_A202TipLCod, T003V13_A203TipLItem
               }
               , new Object[] {
               T003V14_A177CotCod
               }
               , new Object[] {
               T003V15_A45CliCod
               }
               , new Object[] {
               T003V16_A202TipLCod
               }
            }
         );
      }

      private short Z1914TipLSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1914TipLSts ;
      private short GX_JID ;
      private short RcdFound134 ;
      private short nIsDirty_134 ;
      private short Gx_BScreen ;
      private short ZZ1914TipLSts ;
      private int Z202TipLCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A202TipLCod ;
      private int edtTipLCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipLDsc_Enabled ;
      private int edtTipLAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ202TipLCod ;
      private string sPrefix ;
      private string Z1912TipLDsc ;
      private string Z1911TipLAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipLCod_Internalname ;
      private string cmbTipLSts_Internalname ;
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
      private string edtTipLCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipLDsc_Internalname ;
      private string A1912TipLDsc ;
      private string edtTipLDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipLAbr_Internalname ;
      private string A1911TipLAbr ;
      private string edtTipLAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbTipLSts_Jsonclick ;
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
      private string sMode134 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1912TipLDsc ;
      private string ZZ1911TipLAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTipLSts ;
      private IDataStoreProvider pr_default ;
      private int[] T003V4_A202TipLCod ;
      private string[] T003V4_A1912TipLDsc ;
      private string[] T003V4_A1911TipLAbr ;
      private short[] T003V4_A1914TipLSts ;
      private int[] T003V5_A202TipLCod ;
      private int[] T003V3_A202TipLCod ;
      private string[] T003V3_A1912TipLDsc ;
      private string[] T003V3_A1911TipLAbr ;
      private short[] T003V3_A1914TipLSts ;
      private int[] T003V6_A202TipLCod ;
      private int[] T003V7_A202TipLCod ;
      private int[] T003V2_A202TipLCod ;
      private string[] T003V2_A1912TipLDsc ;
      private string[] T003V2_A1911TipLAbr ;
      private short[] T003V2_A1914TipLSts ;
      private string[] T003V11_A149TipCod ;
      private string[] T003V11_A24DocNum ;
      private string[] T003V12_A210PedCod ;
      private int[] T003V13_A202TipLCod ;
      private int[] T003V13_A203TipLItem ;
      private string[] T003V14_A177CotCod ;
      private string[] T003V15_A45CliCod ;
      private int[] T003V16_A202TipLCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ctiposlistas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctiposlistas__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003V4;
        prmT003V4 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V5;
        prmT003V5 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V3;
        prmT003V3 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V6;
        prmT003V6 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V7;
        prmT003V7 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V2;
        prmT003V2 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V8;
        prmT003V8 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLDsc",GXType.NChar,100,0) ,
        new ParDef("@TipLAbr",GXType.NChar,5,0) ,
        new ParDef("@TipLSts",GXType.Int16,1,0)
        };
        Object[] prmT003V9;
        prmT003V9 = new Object[] {
        new ParDef("@TipLDsc",GXType.NChar,100,0) ,
        new ParDef("@TipLAbr",GXType.NChar,5,0) ,
        new ParDef("@TipLSts",GXType.Int16,1,0) ,
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V10;
        prmT003V10 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V11;
        prmT003V11 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V12;
        prmT003V12 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V13;
        prmT003V13 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V14;
        prmT003V14 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V15;
        prmT003V15 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT003V16;
        prmT003V16 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003V2", "SELECT [TipLCod], [TipLDsc], [TipLAbr], [TipLSts] FROM [CTIPOSLISTAS] WITH (UPDLOCK) WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003V3", "SELECT [TipLCod], [TipLDsc], [TipLAbr], [TipLSts] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003V4", "SELECT TM1.[TipLCod], TM1.[TipLDsc], TM1.[TipLAbr], TM1.[TipLSts] FROM [CTIPOSLISTAS] TM1 WHERE TM1.[TipLCod] = @TipLCod ORDER BY TM1.[TipLCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003V4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003V5", "SELECT [TipLCod] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003V6", "SELECT TOP 1 [TipLCod] FROM [CTIPOSLISTAS] WHERE ( [TipLCod] > @TipLCod) ORDER BY [TipLCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003V6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V7", "SELECT TOP 1 [TipLCod] FROM [CTIPOSLISTAS] WHERE ( [TipLCod] < @TipLCod) ORDER BY [TipLCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003V7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V8", "INSERT INTO [CTIPOSLISTAS]([TipLCod], [TipLDsc], [TipLAbr], [TipLSts]) VALUES(@TipLCod, @TipLDsc, @TipLAbr, @TipLSts)", GxErrorMask.GX_NOMASK,prmT003V8)
           ,new CursorDef("T003V9", "UPDATE [CTIPOSLISTAS] SET [TipLDsc]=@TipLDsc, [TipLAbr]=@TipLAbr, [TipLSts]=@TipLSts  WHERE [TipLCod] = @TipLCod", GxErrorMask.GX_NOMASK,prmT003V9)
           ,new CursorDef("T003V10", "DELETE FROM [CTIPOSLISTAS]  WHERE [TipLCod] = @TipLCod", GxErrorMask.GX_NOMASK,prmT003V10)
           ,new CursorDef("T003V11", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocLisp] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V12", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedLisp] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V13", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V14", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotLista] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V15", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [CliTipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003V15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003V16", "SELECT [TipLCod] FROM [CTIPOSLISTAS] ORDER BY [TipLCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003V16,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
