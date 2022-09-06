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
   public class ctipocliente : GXHttpHandler
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
            Form.Meta.addItem("description", "Tipo de Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctipocliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctipocliente( IGxContext context )
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
            RenderHtmlCloseForm3T132( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPOCLIENTE.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Cliente", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159TipCCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipCCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A159TipCCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Cliente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCDsc_Internalname, StringUtil.RTrim( A1905TipCDsc), StringUtil.RTrim( context.localUtil.Format( A1905TipCDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr. T. Cliente", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCAbr_Internalname, StringUtil.RTrim( A1904TipCAbr), StringUtil.RTrim( context.localUtil.Format( A1904TipCAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCLIENTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1908TipCSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipCSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1908TipCSts), "9") : context.localUtil.Format( (decimal)(A1908TipCSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCLIENTE.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCLIENTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPOCLIENTE.htm");
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
            Z159TipCCod = (int)(context.localUtil.CToN( cgiGet( "Z159TipCCod"), ".", ","));
            Z1905TipCDsc = cgiGet( "Z1905TipCDsc");
            Z1904TipCAbr = cgiGet( "Z1904TipCAbr");
            Z1908TipCSts = (short)(context.localUtil.CToN( cgiGet( "Z1908TipCSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            A1905TipCDsc = cgiGet( edtTipCDsc_Internalname);
            AssignAttri("", false, "A1905TipCDsc", A1905TipCDsc);
            A1904TipCAbr = cgiGet( edtTipCAbr_Internalname);
            AssignAttri("", false, "A1904TipCAbr", A1904TipCAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipCSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCSTS");
               AnyError = 1;
               GX_FocusControl = edtTipCSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1908TipCSts = 0;
               AssignAttri("", false, "A1908TipCSts", StringUtil.Str( (decimal)(A1908TipCSts), 1, 0));
            }
            else
            {
               A1908TipCSts = (short)(context.localUtil.CToN( cgiGet( edtTipCSts_Internalname), ".", ","));
               AssignAttri("", false, "A1908TipCSts", StringUtil.Str( (decimal)(A1908TipCSts), 1, 0));
            }
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
               A159TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
               AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
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
               InitAll3T132( ) ;
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
         DisableAttributes3T132( ) ;
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

      protected void CONFIRM_3T0( )
      {
         BeforeValidate3T132( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3T132( ) ;
            }
            else
            {
               CheckExtendedTable3T132( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3T132( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3T0( ) ;
         }
      }

      protected void ResetCaption3T0( )
      {
      }

      protected void ZM3T132( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1905TipCDsc = T003T3_A1905TipCDsc[0];
               Z1904TipCAbr = T003T3_A1904TipCAbr[0];
               Z1908TipCSts = T003T3_A1908TipCSts[0];
            }
            else
            {
               Z1905TipCDsc = A1905TipCDsc;
               Z1904TipCAbr = A1904TipCAbr;
               Z1908TipCSts = A1908TipCSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z159TipCCod = A159TipCCod;
            Z1905TipCDsc = A1905TipCDsc;
            Z1904TipCAbr = A1904TipCAbr;
            Z1908TipCSts = A1908TipCSts;
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

      protected void Load3T132( )
      {
         /* Using cursor T003T4 */
         pr_default.execute(2, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound132 = 1;
            A1905TipCDsc = T003T4_A1905TipCDsc[0];
            AssignAttri("", false, "A1905TipCDsc", A1905TipCDsc);
            A1904TipCAbr = T003T4_A1904TipCAbr[0];
            AssignAttri("", false, "A1904TipCAbr", A1904TipCAbr);
            A1908TipCSts = T003T4_A1908TipCSts[0];
            AssignAttri("", false, "A1908TipCSts", StringUtil.Str( (decimal)(A1908TipCSts), 1, 0));
            ZM3T132( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3T132( ) ;
      }

      protected void OnLoadActions3T132( )
      {
      }

      protected void CheckExtendedTable3T132( )
      {
         nIsDirty_132 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3T132( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3T132( )
      {
         /* Using cursor T003T5 */
         pr_default.execute(3, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound132 = 1;
         }
         else
         {
            RcdFound132 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003T3 */
         pr_default.execute(1, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3T132( 1) ;
            RcdFound132 = 1;
            A159TipCCod = T003T3_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            A1905TipCDsc = T003T3_A1905TipCDsc[0];
            AssignAttri("", false, "A1905TipCDsc", A1905TipCDsc);
            A1904TipCAbr = T003T3_A1904TipCAbr[0];
            AssignAttri("", false, "A1904TipCAbr", A1904TipCAbr);
            A1908TipCSts = T003T3_A1908TipCSts[0];
            AssignAttri("", false, "A1908TipCSts", StringUtil.Str( (decimal)(A1908TipCSts), 1, 0));
            Z159TipCCod = A159TipCCod;
            sMode132 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3T132( ) ;
            if ( AnyError == 1 )
            {
               RcdFound132 = 0;
               InitializeNonKey3T132( ) ;
            }
            Gx_mode = sMode132;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound132 = 0;
            InitializeNonKey3T132( ) ;
            sMode132 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode132;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3T132( ) ;
         if ( RcdFound132 == 0 )
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
         RcdFound132 = 0;
         /* Using cursor T003T6 */
         pr_default.execute(4, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003T6_A159TipCCod[0] < A159TipCCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003T6_A159TipCCod[0] > A159TipCCod ) ) )
            {
               A159TipCCod = T003T6_A159TipCCod[0];
               AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
               RcdFound132 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound132 = 0;
         /* Using cursor T003T7 */
         pr_default.execute(5, new Object[] {A159TipCCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003T7_A159TipCCod[0] > A159TipCCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003T7_A159TipCCod[0] < A159TipCCod ) ) )
            {
               A159TipCCod = T003T7_A159TipCCod[0];
               AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
               RcdFound132 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3T132( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3T132( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound132 == 1 )
            {
               if ( A159TipCCod != Z159TipCCod )
               {
                  A159TipCCod = Z159TipCCod;
                  AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipCCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3T132( ) ;
                  GX_FocusControl = edtTipCCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A159TipCCod != Z159TipCCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3T132( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipCCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipCCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3T132( ) ;
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
         if ( A159TipCCod != Z159TipCCod )
         {
            A159TipCCod = Z159TipCCod;
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipCCod_Internalname;
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
         GetKey3T132( ) ;
         if ( RcdFound132 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A159TipCCod != Z159TipCCod )
            {
               A159TipCCod = Z159TipCCod;
               AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPCCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCCod_Internalname;
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
            if ( A159TipCCod != Z159TipCCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCCod_Internalname;
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
         context.RollbackDataStores("ctipocliente",pr_default);
         GX_FocusControl = edtTipCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3T0( ) ;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3T132( ) ;
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3T132( ) ;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCDsc_Internalname;
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
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCDsc_Internalname;
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
         ScanStart3T132( ) ;
         if ( RcdFound132 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound132 != 0 )
            {
               ScanNext3T132( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3T132( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3T132( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003T2 */
            pr_default.execute(0, new Object[] {A159TipCCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCLIENTE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1905TipCDsc, T003T2_A1905TipCDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1904TipCAbr, T003T2_A1904TipCAbr[0]) != 0 ) || ( Z1908TipCSts != T003T2_A1908TipCSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1905TipCDsc, T003T2_A1905TipCDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipocliente:[seudo value changed for attri]"+"TipCDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1905TipCDsc);
                  GXUtil.WriteLogRaw("Current: ",T003T2_A1905TipCDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1904TipCAbr, T003T2_A1904TipCAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipocliente:[seudo value changed for attri]"+"TipCAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1904TipCAbr);
                  GXUtil.WriteLogRaw("Current: ",T003T2_A1904TipCAbr[0]);
               }
               if ( Z1908TipCSts != T003T2_A1908TipCSts[0] )
               {
                  GXUtil.WriteLog("ctipocliente:[seudo value changed for attri]"+"TipCSts");
                  GXUtil.WriteLogRaw("Old: ",Z1908TipCSts);
                  GXUtil.WriteLogRaw("Current: ",T003T2_A1908TipCSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOCLIENTE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3T132( )
      {
         BeforeValidate3T132( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3T132( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3T132( 0) ;
            CheckOptimisticConcurrency3T132( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3T132( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3T132( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003T8 */
                     pr_default.execute(6, new Object[] {A159TipCCod, A1905TipCDsc, A1904TipCAbr, A1908TipCSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCLIENTE");
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
                           ResetCaption3T0( ) ;
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
               Load3T132( ) ;
            }
            EndLevel3T132( ) ;
         }
         CloseExtendedTableCursors3T132( ) ;
      }

      protected void Update3T132( )
      {
         BeforeValidate3T132( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3T132( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3T132( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3T132( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3T132( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003T9 */
                     pr_default.execute(7, new Object[] {A1905TipCDsc, A1904TipCAbr, A1908TipCSts, A159TipCCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCLIENTE");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCLIENTE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3T132( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3T0( ) ;
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
            EndLevel3T132( ) ;
         }
         CloseExtendedTableCursors3T132( ) ;
      }

      protected void DeferredUpdate3T132( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3T132( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3T132( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3T132( ) ;
            AfterConfirm3T132( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3T132( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003T10 */
                  pr_default.execute(8, new Object[] {A159TipCCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOCLIENTE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound132 == 0 )
                        {
                           InitAll3T132( ) ;
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
                        ResetCaption3T0( ) ;
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
         sMode132 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3T132( ) ;
         Gx_mode = sMode132;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3T132( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003T11 */
            pr_default.execute(9, new Object[] {A159TipCCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel3T132( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3T132( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctipocliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctipocliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3T132( )
      {
         /* Using cursor T003T12 */
         pr_default.execute(10);
         RcdFound132 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound132 = 1;
            A159TipCCod = T003T12_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3T132( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound132 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound132 = 1;
            A159TipCCod = T003T12_A159TipCCod[0];
            AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         }
      }

      protected void ScanEnd3T132( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm3T132( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3T132( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3T132( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3T132( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3T132( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3T132( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3T132( )
      {
         edtTipCCod_Enabled = 0;
         AssignProp("", false, edtTipCCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCCod_Enabled), 5, 0), true);
         edtTipCDsc_Enabled = 0;
         AssignProp("", false, edtTipCDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCDsc_Enabled), 5, 0), true);
         edtTipCAbr_Enabled = 0;
         AssignProp("", false, edtTipCAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCAbr_Enabled), 5, 0), true);
         edtTipCSts_Enabled = 0;
         AssignProp("", false, edtTipCSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3T132( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3T0( )
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
         context.SendWebValue( "Tipo de Cliente") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025210", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctipocliente.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z159TipCCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159TipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1905TipCDsc", StringUtil.RTrim( Z1905TipCDsc));
         GxWebStd.gx_hidden_field( context, "Z1904TipCAbr", StringUtil.RTrim( Z1904TipCAbr));
         GxWebStd.gx_hidden_field( context, "Z1908TipCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1908TipCSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3T132( )
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
         return "CTIPOCLIENTE" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Cliente" ;
      }

      protected void InitializeNonKey3T132( )
      {
         A1905TipCDsc = "";
         AssignAttri("", false, "A1905TipCDsc", A1905TipCDsc);
         A1904TipCAbr = "";
         AssignAttri("", false, "A1904TipCAbr", A1904TipCAbr);
         A1908TipCSts = 0;
         AssignAttri("", false, "A1908TipCSts", StringUtil.Str( (decimal)(A1908TipCSts), 1, 0));
         Z1905TipCDsc = "";
         Z1904TipCAbr = "";
         Z1908TipCSts = 0;
      }

      protected void InitAll3T132( )
      {
         A159TipCCod = 0;
         AssignAttri("", false, "A159TipCCod", StringUtil.LTrimStr( (decimal)(A159TipCCod), 6, 0));
         InitializeNonKey3T132( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025215", true, true);
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
         context.AddJavascriptSource("ctipocliente.js", "?20228181025215", false, true);
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
         edtTipCCod_Internalname = "TIPCCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipCDsc_Internalname = "TIPCDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipCAbr_Internalname = "TIPCABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTipCSts_Internalname = "TIPCSTS";
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
         edtTipCSts_Jsonclick = "";
         edtTipCSts_Enabled = 1;
         edtTipCAbr_Jsonclick = "";
         edtTipCAbr_Enabled = 1;
         edtTipCDsc_Jsonclick = "";
         edtTipCDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipCCod_Jsonclick = "";
         edtTipCCod_Enabled = 1;
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
         GX_FocusControl = edtTipCDsc_Internalname;
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

      public void Valid_Tipccod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1905TipCDsc", StringUtil.RTrim( A1905TipCDsc));
         AssignAttri("", false, "A1904TipCAbr", StringUtil.RTrim( A1904TipCAbr));
         AssignAttri("", false, "A1908TipCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1908TipCSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z159TipCCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159TipCCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1905TipCDsc", StringUtil.RTrim( Z1905TipCDsc));
         GxWebStd.gx_hidden_field( context, "Z1904TipCAbr", StringUtil.RTrim( Z1904TipCAbr));
         GxWebStd.gx_hidden_field( context, "Z1908TipCSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1908TipCSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TIPCCOD","{handler:'Valid_Tipccod',iparms:[{av:'A159TipCCod',fld:'TIPCCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPCCOD",",oparms:[{av:'A1905TipCDsc',fld:'TIPCDSC',pic:''},{av:'A1904TipCAbr',fld:'TIPCABR',pic:''},{av:'A1908TipCSts',fld:'TIPCSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z159TipCCod'},{av:'Z1905TipCDsc'},{av:'Z1904TipCAbr'},{av:'Z1908TipCSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1905TipCDsc = "";
         Z1904TipCAbr = "";
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
         A1905TipCDsc = "";
         lblTextblock3_Jsonclick = "";
         A1904TipCAbr = "";
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
         T003T4_A159TipCCod = new int[1] ;
         T003T4_A1905TipCDsc = new string[] {""} ;
         T003T4_A1904TipCAbr = new string[] {""} ;
         T003T4_A1908TipCSts = new short[1] ;
         T003T5_A159TipCCod = new int[1] ;
         T003T3_A159TipCCod = new int[1] ;
         T003T3_A1905TipCDsc = new string[] {""} ;
         T003T3_A1904TipCAbr = new string[] {""} ;
         T003T3_A1908TipCSts = new short[1] ;
         sMode132 = "";
         T003T6_A159TipCCod = new int[1] ;
         T003T7_A159TipCCod = new int[1] ;
         T003T2_A159TipCCod = new int[1] ;
         T003T2_A1905TipCDsc = new string[] {""} ;
         T003T2_A1904TipCAbr = new string[] {""} ;
         T003T2_A1908TipCSts = new short[1] ;
         T003T11_A45CliCod = new string[] {""} ;
         T003T12_A159TipCCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1905TipCDsc = "";
         ZZ1904TipCAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctipocliente__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctipocliente__default(),
            new Object[][] {
                new Object[] {
               T003T2_A159TipCCod, T003T2_A1905TipCDsc, T003T2_A1904TipCAbr, T003T2_A1908TipCSts
               }
               , new Object[] {
               T003T3_A159TipCCod, T003T3_A1905TipCDsc, T003T3_A1904TipCAbr, T003T3_A1908TipCSts
               }
               , new Object[] {
               T003T4_A159TipCCod, T003T4_A1905TipCDsc, T003T4_A1904TipCAbr, T003T4_A1908TipCSts
               }
               , new Object[] {
               T003T5_A159TipCCod
               }
               , new Object[] {
               T003T6_A159TipCCod
               }
               , new Object[] {
               T003T7_A159TipCCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003T11_A45CliCod
               }
               , new Object[] {
               T003T12_A159TipCCod
               }
            }
         );
      }

      private short Z1908TipCSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1908TipCSts ;
      private short GX_JID ;
      private short RcdFound132 ;
      private short nIsDirty_132 ;
      private short Gx_BScreen ;
      private short ZZ1908TipCSts ;
      private int Z159TipCCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A159TipCCod ;
      private int edtTipCCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipCDsc_Enabled ;
      private int edtTipCAbr_Enabled ;
      private int edtTipCSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ159TipCCod ;
      private string sPrefix ;
      private string Z1905TipCDsc ;
      private string Z1904TipCAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipCCod_Internalname ;
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
      private string edtTipCCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipCDsc_Internalname ;
      private string A1905TipCDsc ;
      private string edtTipCDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipCAbr_Internalname ;
      private string A1904TipCAbr ;
      private string edtTipCAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTipCSts_Internalname ;
      private string edtTipCSts_Jsonclick ;
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
      private string sMode132 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1905TipCDsc ;
      private string ZZ1904TipCAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T003T4_A159TipCCod ;
      private string[] T003T4_A1905TipCDsc ;
      private string[] T003T4_A1904TipCAbr ;
      private short[] T003T4_A1908TipCSts ;
      private int[] T003T5_A159TipCCod ;
      private int[] T003T3_A159TipCCod ;
      private string[] T003T3_A1905TipCDsc ;
      private string[] T003T3_A1904TipCAbr ;
      private short[] T003T3_A1908TipCSts ;
      private int[] T003T6_A159TipCCod ;
      private int[] T003T7_A159TipCCod ;
      private int[] T003T2_A159TipCCod ;
      private string[] T003T2_A1905TipCDsc ;
      private string[] T003T2_A1904TipCAbr ;
      private short[] T003T2_A1908TipCSts ;
      private string[] T003T11_A45CliCod ;
      private int[] T003T12_A159TipCCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ctipocliente__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctipocliente__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003T4;
        prmT003T4 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T5;
        prmT003T5 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T3;
        prmT003T3 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T6;
        prmT003T6 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T7;
        prmT003T7 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T2;
        prmT003T2 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T8;
        prmT003T8 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0) ,
        new ParDef("@TipCDsc",GXType.NChar,100,0) ,
        new ParDef("@TipCAbr",GXType.NChar,5,0) ,
        new ParDef("@TipCSts",GXType.Int16,1,0)
        };
        Object[] prmT003T9;
        prmT003T9 = new Object[] {
        new ParDef("@TipCDsc",GXType.NChar,100,0) ,
        new ParDef("@TipCAbr",GXType.NChar,5,0) ,
        new ParDef("@TipCSts",GXType.Int16,1,0) ,
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T10;
        prmT003T10 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T11;
        prmT003T11 = new Object[] {
        new ParDef("@TipCCod",GXType.Int32,6,0)
        };
        Object[] prmT003T12;
        prmT003T12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003T2", "SELECT [TipCCod], [TipCDsc], [TipCAbr], [TipCSts] FROM [CTIPOCLIENTE] WITH (UPDLOCK) WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003T3", "SELECT [TipCCod], [TipCDsc], [TipCAbr], [TipCSts] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003T4", "SELECT TM1.[TipCCod], TM1.[TipCDsc], TM1.[TipCAbr], TM1.[TipCSts] FROM [CTIPOCLIENTE] TM1 WHERE TM1.[TipCCod] = @TipCCod ORDER BY TM1.[TipCCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003T4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003T5", "SELECT [TipCCod] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @TipCCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003T6", "SELECT TOP 1 [TipCCod] FROM [CTIPOCLIENTE] WHERE ( [TipCCod] > @TipCCod) ORDER BY [TipCCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003T6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003T7", "SELECT TOP 1 [TipCCod] FROM [CTIPOCLIENTE] WHERE ( [TipCCod] < @TipCCod) ORDER BY [TipCCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003T7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003T8", "INSERT INTO [CTIPOCLIENTE]([TipCCod], [TipCDsc], [TipCAbr], [TipCSts]) VALUES(@TipCCod, @TipCDsc, @TipCAbr, @TipCSts)", GxErrorMask.GX_NOMASK,prmT003T8)
           ,new CursorDef("T003T9", "UPDATE [CTIPOCLIENTE] SET [TipCDsc]=@TipCDsc, [TipCAbr]=@TipCAbr, [TipCSts]=@TipCSts  WHERE [TipCCod] = @TipCCod", GxErrorMask.GX_NOMASK,prmT003T9)
           ,new CursorDef("T003T10", "DELETE FROM [CTIPOCLIENTE]  WHERE [TipCCod] = @TipCCod", GxErrorMask.GX_NOMASK,prmT003T10)
           ,new CursorDef("T003T11", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [TipCCod] = @TipCCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003T11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003T12", "SELECT [TipCCod] FROM [CTIPOCLIENTE] ORDER BY [TipCCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003T12,100, GxCacheFrequency.OFF ,true,false )
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
