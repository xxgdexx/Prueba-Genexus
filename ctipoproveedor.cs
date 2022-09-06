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
   public class ctipoproveedor : GXHttpHandler
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
            Form.Meta.addItem("description", "Tipo de Proveedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctipoproveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctipoproveedor( IGxContext context )
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
         cmbTprvSts = new GXCombobox();
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
         if ( cmbTprvSts.ItemCount > 0 )
         {
            A1942TprvSts = (short)(NumberUtil.Val( cmbTprvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0))), "."));
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            AssignProp("", false, cmbTprvSts_Internalname, "Values", cmbTprvSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm3U133( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPOPROVEEDOR.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Proveedor", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTprvCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTprvCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Proveedor", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvDsc_Internalname, StringUtil.RTrim( A1941TprvDsc), StringUtil.RTrim( context.localUtil.Format( A1941TprvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTprvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr. T Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvAbr_Internalname, StringUtil.RTrim( A1940TprvAbr), StringUtil.RTrim( context.localUtil.Format( A1940TprvAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTprvAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOPROVEEDOR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTprvSts, cmbTprvSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0)), 1, cmbTprvSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTprvSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CTIPOPROVEEDOR.htm");
         cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         AssignProp("", false, cmbTprvSts_Internalname, "Values", (string)(cmbTprvSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOPROVEEDOR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPOPROVEEDOR.htm");
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
            Z298TprvCod = (int)(context.localUtil.CToN( cgiGet( "Z298TprvCod"), ".", ","));
            Z1941TprvDsc = cgiGet( "Z1941TprvDsc");
            Z1940TprvAbr = cgiGet( "Z1940TprvAbr");
            Z1942TprvSts = (short)(context.localUtil.CToN( cgiGet( "Z1942TprvSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            A1941TprvDsc = cgiGet( edtTprvDsc_Internalname);
            AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
            A1940TprvAbr = cgiGet( edtTprvAbr_Internalname);
            AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
            cmbTprvSts.CurrentValue = cgiGet( cmbTprvSts_Internalname);
            A1942TprvSts = (short)(NumberUtil.Val( cgiGet( cmbTprvSts_Internalname), "."));
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
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
               A298TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
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
               InitAll3U133( ) ;
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
         DisableAttributes3U133( ) ;
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

      protected void CONFIRM_3U0( )
      {
         BeforeValidate3U133( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3U133( ) ;
            }
            else
            {
               CheckExtendedTable3U133( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3U133( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3U0( ) ;
         }
      }

      protected void ResetCaption3U0( )
      {
      }

      protected void ZM3U133( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1941TprvDsc = T003U3_A1941TprvDsc[0];
               Z1940TprvAbr = T003U3_A1940TprvAbr[0];
               Z1942TprvSts = T003U3_A1942TprvSts[0];
            }
            else
            {
               Z1941TprvDsc = A1941TprvDsc;
               Z1940TprvAbr = A1940TprvAbr;
               Z1942TprvSts = A1942TprvSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z298TprvCod = A298TprvCod;
            Z1941TprvDsc = A1941TprvDsc;
            Z1940TprvAbr = A1940TprvAbr;
            Z1942TprvSts = A1942TprvSts;
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

      protected void Load3U133( )
      {
         /* Using cursor T003U4 */
         pr_default.execute(2, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound133 = 1;
            A1941TprvDsc = T003U4_A1941TprvDsc[0];
            AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
            A1940TprvAbr = T003U4_A1940TprvAbr[0];
            AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
            A1942TprvSts = T003U4_A1942TprvSts[0];
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            ZM3U133( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3U133( ) ;
      }

      protected void OnLoadActions3U133( )
      {
      }

      protected void CheckExtendedTable3U133( )
      {
         nIsDirty_133 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3U133( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3U133( )
      {
         /* Using cursor T003U5 */
         pr_default.execute(3, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound133 = 1;
         }
         else
         {
            RcdFound133 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003U3 */
         pr_default.execute(1, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3U133( 1) ;
            RcdFound133 = 1;
            A298TprvCod = T003U3_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            A1941TprvDsc = T003U3_A1941TprvDsc[0];
            AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
            A1940TprvAbr = T003U3_A1940TprvAbr[0];
            AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
            A1942TprvSts = T003U3_A1942TprvSts[0];
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            Z298TprvCod = A298TprvCod;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3U133( ) ;
            if ( AnyError == 1 )
            {
               RcdFound133 = 0;
               InitializeNonKey3U133( ) ;
            }
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound133 = 0;
            InitializeNonKey3U133( ) ;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3U133( ) ;
         if ( RcdFound133 == 0 )
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
         RcdFound133 = 0;
         /* Using cursor T003U6 */
         pr_default.execute(4, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003U6_A298TprvCod[0] < A298TprvCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003U6_A298TprvCod[0] > A298TprvCod ) ) )
            {
               A298TprvCod = T003U6_A298TprvCod[0];
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               RcdFound133 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound133 = 0;
         /* Using cursor T003U7 */
         pr_default.execute(5, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003U7_A298TprvCod[0] > A298TprvCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003U7_A298TprvCod[0] < A298TprvCod ) ) )
            {
               A298TprvCod = T003U7_A298TprvCod[0];
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               RcdFound133 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3U133( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3U133( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound133 == 1 )
            {
               if ( A298TprvCod != Z298TprvCod )
               {
                  A298TprvCod = Z298TprvCod;
                  AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3U133( ) ;
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A298TprvCod != Z298TprvCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3U133( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPRVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTprvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTprvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3U133( ) ;
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
         if ( A298TprvCod != Z298TprvCod )
         {
            A298TprvCod = Z298TprvCod;
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTprvCod_Internalname;
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
         GetKey3U133( ) ;
         if ( RcdFound133 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TPRVCOD");
               AnyError = 1;
               GX_FocusControl = edtTprvCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A298TprvCod != Z298TprvCod )
            {
               A298TprvCod = Z298TprvCod;
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TPRVCOD");
               AnyError = 1;
               GX_FocusControl = edtTprvCod_Internalname;
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
            if ( A298TprvCod != Z298TprvCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTprvCod_Internalname;
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
         context.RollbackDataStores("ctipoproveedor",pr_default);
         GX_FocusControl = edtTprvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3U0( ) ;
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
         if ( RcdFound133 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTprvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3U133( ) ;
         if ( RcdFound133 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTprvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3U133( ) ;
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
         if ( RcdFound133 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTprvDsc_Internalname;
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
         if ( RcdFound133 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTprvDsc_Internalname;
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
         ScanStart3U133( ) ;
         if ( RcdFound133 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound133 != 0 )
            {
               ScanNext3U133( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTprvDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3U133( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3U133( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003U2 */
            pr_default.execute(0, new Object[] {A298TprvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOPROVEEDOR"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1941TprvDsc, T003U2_A1941TprvDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1940TprvAbr, T003U2_A1940TprvAbr[0]) != 0 ) || ( Z1942TprvSts != T003U2_A1942TprvSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1941TprvDsc, T003U2_A1941TprvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipoproveedor:[seudo value changed for attri]"+"TprvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1941TprvDsc);
                  GXUtil.WriteLogRaw("Current: ",T003U2_A1941TprvDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1940TprvAbr, T003U2_A1940TprvAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipoproveedor:[seudo value changed for attri]"+"TprvAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1940TprvAbr);
                  GXUtil.WriteLogRaw("Current: ",T003U2_A1940TprvAbr[0]);
               }
               if ( Z1942TprvSts != T003U2_A1942TprvSts[0] )
               {
                  GXUtil.WriteLog("ctipoproveedor:[seudo value changed for attri]"+"TprvSts");
                  GXUtil.WriteLogRaw("Old: ",Z1942TprvSts);
                  GXUtil.WriteLogRaw("Current: ",T003U2_A1942TprvSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOPROVEEDOR"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3U133( )
      {
         BeforeValidate3U133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3U133( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3U133( 0) ;
            CheckOptimisticConcurrency3U133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3U133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3U133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003U8 */
                     pr_default.execute(6, new Object[] {A298TprvCod, A1941TprvDsc, A1940TprvAbr, A1942TprvSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
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
                           ResetCaption3U0( ) ;
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
               Load3U133( ) ;
            }
            EndLevel3U133( ) ;
         }
         CloseExtendedTableCursors3U133( ) ;
      }

      protected void Update3U133( )
      {
         BeforeValidate3U133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3U133( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3U133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3U133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3U133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003U9 */
                     pr_default.execute(7, new Object[] {A1941TprvDsc, A1940TprvAbr, A1942TprvSts, A298TprvCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOPROVEEDOR"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3U133( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3U0( ) ;
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
            EndLevel3U133( ) ;
         }
         CloseExtendedTableCursors3U133( ) ;
      }

      protected void DeferredUpdate3U133( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3U133( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3U133( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3U133( ) ;
            AfterConfirm3U133( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3U133( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003U10 */
                  pr_default.execute(8, new Object[] {A298TprvCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound133 == 0 )
                        {
                           InitAll3U133( ) ;
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
                        ResetCaption3U0( ) ;
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
         sMode133 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3U133( ) ;
         Gx_mode = sMode133;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3U133( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003U11 */
            pr_default.execute(9, new Object[] {A298TprvCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel3U133( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3U133( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctipoproveedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctipoproveedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3U133( )
      {
         /* Using cursor T003U12 */
         pr_default.execute(10);
         RcdFound133 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound133 = 1;
            A298TprvCod = T003U12_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3U133( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound133 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound133 = 1;
            A298TprvCod = T003U12_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
      }

      protected void ScanEnd3U133( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm3U133( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3U133( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3U133( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3U133( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3U133( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3U133( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3U133( )
      {
         edtTprvCod_Enabled = 0;
         AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
         edtTprvDsc_Enabled = 0;
         AssignProp("", false, edtTprvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvDsc_Enabled), 5, 0), true);
         edtTprvAbr_Enabled = 0;
         AssignProp("", false, edtTprvAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvAbr_Enabled), 5, 0), true);
         cmbTprvSts.Enabled = 0;
         AssignProp("", false, cmbTprvSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTprvSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3U133( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3U0( )
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
         context.SendWebValue( "Tipo de Proveedor") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252168", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctipoproveedor.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1941TprvDsc", StringUtil.RTrim( Z1941TprvDsc));
         GxWebStd.gx_hidden_field( context, "Z1940TprvAbr", StringUtil.RTrim( Z1940TprvAbr));
         GxWebStd.gx_hidden_field( context, "Z1942TprvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1942TprvSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3U133( )
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
         return "CTIPOPROVEEDOR" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Proveedor" ;
      }

      protected void InitializeNonKey3U133( )
      {
         A1941TprvDsc = "";
         AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
         A1940TprvAbr = "";
         AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
         A1942TprvSts = 0;
         AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         Z1941TprvDsc = "";
         Z1940TprvAbr = "";
         Z1942TprvSts = 0;
      }

      protected void InitAll3U133( )
      {
         A298TprvCod = 0;
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         InitializeNonKey3U133( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252172", true, true);
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
         context.AddJavascriptSource("ctipoproveedor.js", "?202281810252173", false, true);
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
         edtTprvCod_Internalname = "TPRVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTprvDsc_Internalname = "TPRVDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTprvAbr_Internalname = "TPRVABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbTprvSts_Internalname = "TPRVSTS";
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
         cmbTprvSts_Jsonclick = "";
         cmbTprvSts.Enabled = 1;
         edtTprvAbr_Jsonclick = "";
         edtTprvAbr_Enabled = 1;
         edtTprvDsc_Jsonclick = "";
         edtTprvDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTprvCod_Jsonclick = "";
         edtTprvCod_Enabled = 1;
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
         cmbTprvSts.Name = "TPRVSTS";
         cmbTprvSts.WebTags = "";
         cmbTprvSts.addItem("1", "ACTIVO", 0);
         cmbTprvSts.addItem("0", "INACTIVO", 0);
         if ( cmbTprvSts.ItemCount > 0 )
         {
            A1942TprvSts = (short)(NumberUtil.Val( cmbTprvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0))), "."));
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTprvDsc_Internalname;
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

      public void Valid_Tprvcod( )
      {
         A1942TprvSts = (short)(NumberUtil.Val( cmbTprvSts.CurrentValue, "."));
         cmbTprvSts.CurrentValue = StringUtil.Str( (decimal)(A1942TprvSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTprvSts.ItemCount > 0 )
         {
            A1942TprvSts = (short)(NumberUtil.Val( cmbTprvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0))), "."));
            cmbTprvSts.CurrentValue = StringUtil.Str( (decimal)(A1942TprvSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1941TprvDsc", StringUtil.RTrim( A1941TprvDsc));
         AssignAttri("", false, "A1940TprvAbr", StringUtil.RTrim( A1940TprvAbr));
         AssignAttri("", false, "A1942TprvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1942TprvSts), 1, 0, ".", "")));
         cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         AssignProp("", false, cmbTprvSts_Internalname, "Values", cmbTprvSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1941TprvDsc", StringUtil.RTrim( Z1941TprvDsc));
         GxWebStd.gx_hidden_field( context, "Z1940TprvAbr", StringUtil.RTrim( Z1940TprvAbr));
         GxWebStd.gx_hidden_field( context, "Z1942TprvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1942TprvSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TPRVCOD","{handler:'Valid_Tprvcod',iparms:[{av:'cmbTprvSts'},{av:'A1942TprvSts',fld:'TPRVSTS',pic:'9'},{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TPRVCOD",",oparms:[{av:'A1941TprvDsc',fld:'TPRVDSC',pic:''},{av:'A1940TprvAbr',fld:'TPRVABR',pic:''},{av:'cmbTprvSts'},{av:'A1942TprvSts',fld:'TPRVSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z298TprvCod'},{av:'Z1941TprvDsc'},{av:'Z1940TprvAbr'},{av:'Z1942TprvSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1941TprvDsc = "";
         Z1940TprvAbr = "";
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
         A1941TprvDsc = "";
         lblTextblock3_Jsonclick = "";
         A1940TprvAbr = "";
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
         T003U4_A298TprvCod = new int[1] ;
         T003U4_A1941TprvDsc = new string[] {""} ;
         T003U4_A1940TprvAbr = new string[] {""} ;
         T003U4_A1942TprvSts = new short[1] ;
         T003U5_A298TprvCod = new int[1] ;
         T003U3_A298TprvCod = new int[1] ;
         T003U3_A1941TprvDsc = new string[] {""} ;
         T003U3_A1940TprvAbr = new string[] {""} ;
         T003U3_A1942TprvSts = new short[1] ;
         sMode133 = "";
         T003U6_A298TprvCod = new int[1] ;
         T003U7_A298TprvCod = new int[1] ;
         T003U2_A298TprvCod = new int[1] ;
         T003U2_A1941TprvDsc = new string[] {""} ;
         T003U2_A1940TprvAbr = new string[] {""} ;
         T003U2_A1942TprvSts = new short[1] ;
         T003U11_A244PrvCod = new string[] {""} ;
         T003U12_A298TprvCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1941TprvDsc = "";
         ZZ1940TprvAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctipoproveedor__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctipoproveedor__default(),
            new Object[][] {
                new Object[] {
               T003U2_A298TprvCod, T003U2_A1941TprvDsc, T003U2_A1940TprvAbr, T003U2_A1942TprvSts
               }
               , new Object[] {
               T003U3_A298TprvCod, T003U3_A1941TprvDsc, T003U3_A1940TprvAbr, T003U3_A1942TprvSts
               }
               , new Object[] {
               T003U4_A298TprvCod, T003U4_A1941TprvDsc, T003U4_A1940TprvAbr, T003U4_A1942TprvSts
               }
               , new Object[] {
               T003U5_A298TprvCod
               }
               , new Object[] {
               T003U6_A298TprvCod
               }
               , new Object[] {
               T003U7_A298TprvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003U11_A244PrvCod
               }
               , new Object[] {
               T003U12_A298TprvCod
               }
            }
         );
      }

      private short Z1942TprvSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1942TprvSts ;
      private short GX_JID ;
      private short RcdFound133 ;
      private short nIsDirty_133 ;
      private short Gx_BScreen ;
      private short ZZ1942TprvSts ;
      private int Z298TprvCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A298TprvCod ;
      private int edtTprvCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTprvDsc_Enabled ;
      private int edtTprvAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ298TprvCod ;
      private string sPrefix ;
      private string Z1941TprvDsc ;
      private string Z1940TprvAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTprvCod_Internalname ;
      private string cmbTprvSts_Internalname ;
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
      private string edtTprvCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTprvDsc_Internalname ;
      private string A1941TprvDsc ;
      private string edtTprvDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTprvAbr_Internalname ;
      private string A1940TprvAbr ;
      private string edtTprvAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbTprvSts_Jsonclick ;
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
      private string sMode133 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1941TprvDsc ;
      private string ZZ1940TprvAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTprvSts ;
      private IDataStoreProvider pr_default ;
      private int[] T003U4_A298TprvCod ;
      private string[] T003U4_A1941TprvDsc ;
      private string[] T003U4_A1940TprvAbr ;
      private short[] T003U4_A1942TprvSts ;
      private int[] T003U5_A298TprvCod ;
      private int[] T003U3_A298TprvCod ;
      private string[] T003U3_A1941TprvDsc ;
      private string[] T003U3_A1940TprvAbr ;
      private short[] T003U3_A1942TprvSts ;
      private int[] T003U6_A298TprvCod ;
      private int[] T003U7_A298TprvCod ;
      private int[] T003U2_A298TprvCod ;
      private string[] T003U2_A1941TprvDsc ;
      private string[] T003U2_A1940TprvAbr ;
      private short[] T003U2_A1942TprvSts ;
      private string[] T003U11_A244PrvCod ;
      private int[] T003U12_A298TprvCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ctipoproveedor__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctipoproveedor__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003U4;
        prmT003U4 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U5;
        prmT003U5 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U3;
        prmT003U3 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U6;
        prmT003U6 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U7;
        prmT003U7 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U2;
        prmT003U2 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U8;
        prmT003U8 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0) ,
        new ParDef("@TprvDsc",GXType.NChar,100,0) ,
        new ParDef("@TprvAbr",GXType.NChar,5,0) ,
        new ParDef("@TprvSts",GXType.Int16,1,0)
        };
        Object[] prmT003U9;
        prmT003U9 = new Object[] {
        new ParDef("@TprvDsc",GXType.NChar,100,0) ,
        new ParDef("@TprvAbr",GXType.NChar,5,0) ,
        new ParDef("@TprvSts",GXType.Int16,1,0) ,
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U10;
        prmT003U10 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U11;
        prmT003U11 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT003U12;
        prmT003U12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003U2", "SELECT [TprvCod], [TprvDsc], [TprvAbr], [TprvSts] FROM [CTIPOPROVEEDOR] WITH (UPDLOCK) WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003U3", "SELECT [TprvCod], [TprvDsc], [TprvAbr], [TprvSts] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003U4", "SELECT TM1.[TprvCod], TM1.[TprvDsc], TM1.[TprvAbr], TM1.[TprvSts] FROM [CTIPOPROVEEDOR] TM1 WHERE TM1.[TprvCod] = @TprvCod ORDER BY TM1.[TprvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003U4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003U5", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003U6", "SELECT TOP 1 [TprvCod] FROM [CTIPOPROVEEDOR] WHERE ( [TprvCod] > @TprvCod) ORDER BY [TprvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003U6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003U7", "SELECT TOP 1 [TprvCod] FROM [CTIPOPROVEEDOR] WHERE ( [TprvCod] < @TprvCod) ORDER BY [TprvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003U7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003U8", "INSERT INTO [CTIPOPROVEEDOR]([TprvCod], [TprvDsc], [TprvAbr], [TprvSts]) VALUES(@TprvCod, @TprvDsc, @TprvAbr, @TprvSts)", GxErrorMask.GX_NOMASK,prmT003U8)
           ,new CursorDef("T003U9", "UPDATE [CTIPOPROVEEDOR] SET [TprvDsc]=@TprvDsc, [TprvAbr]=@TprvAbr, [TprvSts]=@TprvSts  WHERE [TprvCod] = @TprvCod", GxErrorMask.GX_NOMASK,prmT003U9)
           ,new CursorDef("T003U10", "DELETE FROM [CTIPOPROVEEDOR]  WHERE [TprvCod] = @TprvCod", GxErrorMask.GX_NOMASK,prmT003U10)
           ,new CursorDef("T003U11", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003U12", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] ORDER BY [TprvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003U12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
