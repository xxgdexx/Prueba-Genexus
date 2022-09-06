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
   public class cmonedas : GXHttpHandler
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
            Form.Meta.addItem("description", "Monedas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cmonedas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cmonedas( IGxContext context )
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
            RenderHtmlCloseForm30103( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CMONEDAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Moneda", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Moneda", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonDsc_Internalname, StringUtil.RTrim( A1234MonDsc), StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr. Moneda", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonAbr_Internalname, StringUtil.RTrim( A1233MonAbr), StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMONEDAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1235MonSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtMonSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1235MonSts), "9") : context.localUtil.Format( (decimal)(A1235MonSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMONEDAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMONEDAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CMONEDAS.htm");
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
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            Z1234MonDsc = cgiGet( "Z1234MonDsc");
            Z1233MonAbr = cgiGet( "Z1233MonAbr");
            Z1235MonSts = (short)(context.localUtil.CToN( cgiGet( "Z1235MonSts"), ".", ","));
            Z1236MonSunat = cgiGet( "Z1236MonSunat");
            A1236MonSunat = cgiGet( "Z1236MonSunat");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1236MonSunat = cgiGet( "MONSUNAT");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A180MonCod = 0;
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            else
            {
               A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            A1234MonDsc = cgiGet( edtMonDsc_Internalname);
            AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
            A1233MonAbr = cgiGet( edtMonAbr_Internalname);
            AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONSTS");
               AnyError = 1;
               GX_FocusControl = edtMonSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1235MonSts = 0;
               AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            }
            else
            {
               A1235MonSts = (short)(context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ","));
               AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CMONEDAS");
            forbiddenHiddens.Add("MonSunat", StringUtil.RTrim( context.localUtil.Format( A1236MonSunat, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A180MonCod != Z180MonCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cmonedas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
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
               InitAll30103( ) ;
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
         DisableAttributes30103( ) ;
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

      protected void CONFIRM_300( )
      {
         BeforeValidate30103( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls30103( ) ;
            }
            else
            {
               CheckExtendedTable30103( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors30103( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues300( ) ;
         }
      }

      protected void ResetCaption300( )
      {
      }

      protected void ZM30103( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1234MonDsc = T00303_A1234MonDsc[0];
               Z1233MonAbr = T00303_A1233MonAbr[0];
               Z1235MonSts = T00303_A1235MonSts[0];
               Z1236MonSunat = T00303_A1236MonSunat[0];
            }
            else
            {
               Z1234MonDsc = A1234MonDsc;
               Z1233MonAbr = A1233MonAbr;
               Z1235MonSts = A1235MonSts;
               Z1236MonSunat = A1236MonSunat;
            }
         }
         if ( GX_JID == -1 )
         {
            Z180MonCod = A180MonCod;
            Z1234MonDsc = A1234MonDsc;
            Z1233MonAbr = A1233MonAbr;
            Z1235MonSts = A1235MonSts;
            Z1236MonSunat = A1236MonSunat;
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

      protected void Load30103( )
      {
         /* Using cursor T00304 */
         pr_default.execute(2, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound103 = 1;
            A1234MonDsc = T00304_A1234MonDsc[0];
            AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
            A1233MonAbr = T00304_A1233MonAbr[0];
            AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
            A1235MonSts = T00304_A1235MonSts[0];
            AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            A1236MonSunat = T00304_A1236MonSunat[0];
            ZM30103( -1) ;
         }
         pr_default.close(2);
         OnLoadActions30103( ) ;
      }

      protected void OnLoadActions30103( )
      {
      }

      protected void CheckExtendedTable30103( )
      {
         nIsDirty_103 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors30103( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey30103( )
      {
         /* Using cursor T00305 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00303 */
         pr_default.execute(1, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM30103( 1) ;
            RcdFound103 = 1;
            A180MonCod = T00303_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A1234MonDsc = T00303_A1234MonDsc[0];
            AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
            A1233MonAbr = T00303_A1233MonAbr[0];
            AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
            A1235MonSts = T00303_A1235MonSts[0];
            AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            A1236MonSunat = T00303_A1236MonSunat[0];
            Z180MonCod = A180MonCod;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load30103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey30103( ) ;
            }
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey30103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey30103( ) ;
         if ( RcdFound103 == 0 )
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
         RcdFound103 = 0;
         /* Using cursor T00306 */
         pr_default.execute(4, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00306_A180MonCod[0] < A180MonCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00306_A180MonCod[0] > A180MonCod ) ) )
            {
               A180MonCod = T00306_A180MonCod[0];
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound103 = 0;
         /* Using cursor T00307 */
         pr_default.execute(5, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00307_A180MonCod[0] > A180MonCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00307_A180MonCod[0] < A180MonCod ) ) )
            {
               A180MonCod = T00307_A180MonCod[0];
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey30103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert30103( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A180MonCod != Z180MonCod )
               {
                  A180MonCod = Z180MonCod;
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update30103( ) ;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A180MonCod != Z180MonCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert30103( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MONCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert30103( ) ;
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
         if ( A180MonCod != Z180MonCod )
         {
            A180MonCod = Z180MonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMonCod_Internalname;
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
         GetKey30103( ) ;
         if ( RcdFound103 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A180MonCod != Z180MonCod )
            {
               A180MonCod = Z180MonCod;
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
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
            if ( A180MonCod != Z180MonCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMonCod_Internalname;
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
         context.RollbackDataStores("cmonedas",pr_default);
         GX_FocusControl = edtMonDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_300( ) ;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMonDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart30103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd30103( ) ;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonDsc_Internalname;
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
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonDsc_Internalname;
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
         ScanStart30103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound103 != 0 )
            {
               ScanNext30103( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd30103( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency30103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00302 */
            pr_default.execute(0, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMONEDAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1234MonDsc, T00302_A1234MonDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1233MonAbr, T00302_A1233MonAbr[0]) != 0 ) || ( Z1235MonSts != T00302_A1235MonSts[0] ) || ( StringUtil.StrCmp(Z1236MonSunat, T00302_A1236MonSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1234MonDsc, T00302_A1234MonDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cmonedas:[seudo value changed for attri]"+"MonDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1234MonDsc);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1234MonDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1233MonAbr, T00302_A1233MonAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cmonedas:[seudo value changed for attri]"+"MonAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1233MonAbr);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1233MonAbr[0]);
               }
               if ( Z1235MonSts != T00302_A1235MonSts[0] )
               {
                  GXUtil.WriteLog("cmonedas:[seudo value changed for attri]"+"MonSts");
                  GXUtil.WriteLogRaw("Old: ",Z1235MonSts);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1235MonSts[0]);
               }
               if ( StringUtil.StrCmp(Z1236MonSunat, T00302_A1236MonSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("cmonedas:[seudo value changed for attri]"+"MonSunat");
                  GXUtil.WriteLogRaw("Old: ",Z1236MonSunat);
                  GXUtil.WriteLogRaw("Current: ",T00302_A1236MonSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMONEDAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert30103( )
      {
         BeforeValidate30103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM30103( 0) ;
            CheckOptimisticConcurrency30103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert30103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00308 */
                     pr_default.execute(6, new Object[] {A180MonCod, A1234MonDsc, A1233MonAbr, A1235MonSts, A1236MonSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
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
                           ResetCaption300( ) ;
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
               Load30103( ) ;
            }
            EndLevel30103( ) ;
         }
         CloseExtendedTableCursors30103( ) ;
      }

      protected void Update30103( )
      {
         BeforeValidate30103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable30103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm30103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate30103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00309 */
                     pr_default.execute(7, new Object[] {A1234MonDsc, A1233MonAbr, A1235MonSts, A1236MonSunat, A180MonCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMONEDAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate30103( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption300( ) ;
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
            EndLevel30103( ) ;
         }
         CloseExtendedTableCursors30103( ) ;
      }

      protected void DeferredUpdate30103( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate30103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency30103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls30103( ) ;
            AfterConfirm30103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete30103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003010 */
                  pr_default.execute(8, new Object[] {A180MonCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound103 == 0 )
                        {
                           InitAll30103( ) ;
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
                        ResetCaption300( ) ;
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel30103( ) ;
         Gx_mode = sMode103;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls30103( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003011 */
            pr_default.execute(9, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003012 */
            pr_default.execute(10, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T003013 */
            pr_default.execute(11, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T003014 */
            pr_default.execute(12, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T003015 */
            pr_default.execute(13, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T003016 */
            pr_default.execute(14, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T003017 */
            pr_default.execute(15, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tipo de Cambio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T003018 */
            pr_default.execute(16, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T003019 */
            pr_default.execute(17, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T003020 */
            pr_default.execute(18, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T003021 */
            pr_default.execute(19, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta Pagar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T003022 */
            pr_default.execute(20, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T003023 */
            pr_default.execute(21, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CPCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T003024 */
            pr_default.execute(22, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T003025 */
            pr_default.execute(23, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T003026 */
            pr_default.execute(24, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T003027 */
            pr_default.execute(25, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T003028 */
            pr_default.execute(26, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T003029 */
            pr_default.execute(27, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tipo de Presupuesto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T003030 */
            pr_default.execute(28, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T003031 */
            pr_default.execute(29, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T003032 */
            pr_default.execute(30, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T003033 */
            pr_default.execute(31, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T003034 */
            pr_default.execute(32, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T003035 */
            pr_default.execute(33, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T003036 */
            pr_default.execute(34, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T003037 */
            pr_default.execute(35, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
         }
      }

      protected void EndLevel30103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete30103( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cmonedas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues300( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cmonedas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart30103( )
      {
         /* Using cursor T003038 */
         pr_default.execute(36);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound103 = 1;
            A180MonCod = T003038_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext30103( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound103 = 1;
            A180MonCod = T003038_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
      }

      protected void ScanEnd30103( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm30103( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert30103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate30103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete30103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete30103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate30103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes30103( )
      {
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         edtMonDsc_Enabled = 0;
         AssignProp("", false, edtMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonDsc_Enabled), 5, 0), true);
         edtMonAbr_Enabled = 0;
         AssignProp("", false, edtMonAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonAbr_Enabled), 5, 0), true);
         edtMonSts_Enabled = 0;
         AssignProp("", false, edtMonSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes30103( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues300( )
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
         context.SendWebValue( "Monedas") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025669", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cmonedas.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CMONEDAS");
         forbiddenHiddens.Add("MonSunat", StringUtil.RTrim( context.localUtil.Format( A1236MonSunat, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cmonedas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1234MonDsc", StringUtil.RTrim( Z1234MonDsc));
         GxWebStd.gx_hidden_field( context, "Z1233MonAbr", StringUtil.RTrim( Z1233MonAbr));
         GxWebStd.gx_hidden_field( context, "Z1235MonSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1235MonSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1236MonSunat", Z1236MonSunat);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "MONSUNAT", A1236MonSunat);
      }

      protected void RenderHtmlCloseForm30103( )
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
         return "CMONEDAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Monedas" ;
      }

      protected void InitializeNonKey30103( )
      {
         A1234MonDsc = "";
         AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
         A1233MonAbr = "";
         AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
         A1235MonSts = 0;
         AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
         A1236MonSunat = "";
         AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
         Z1234MonDsc = "";
         Z1233MonAbr = "";
         Z1235MonSts = 0;
         Z1236MonSunat = "";
      }

      protected void InitAll30103( )
      {
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         InitializeNonKey30103( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025675", true, true);
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
         context.AddJavascriptSource("cmonedas.js", "?20228181025675", false, true);
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
         edtMonCod_Internalname = "MONCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMonDsc_Internalname = "MONDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMonAbr_Internalname = "MONABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMonSts_Internalname = "MONSTS";
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
         edtMonSts_Jsonclick = "";
         edtMonSts_Enabled = 1;
         edtMonAbr_Jsonclick = "";
         edtMonAbr_Enabled = 1;
         edtMonDsc_Jsonclick = "";
         edtMonDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
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
         GX_FocusControl = edtMonDsc_Internalname;
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

      public void Valid_Moncod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1234MonDsc", StringUtil.RTrim( A1234MonDsc));
         AssignAttri("", false, "A1233MonAbr", StringUtil.RTrim( A1233MonAbr));
         AssignAttri("", false, "A1235MonSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1235MonSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1234MonDsc", StringUtil.RTrim( Z1234MonDsc));
         GxWebStd.gx_hidden_field( context, "Z1233MonAbr", StringUtil.RTrim( Z1233MonAbr));
         GxWebStd.gx_hidden_field( context, "Z1235MonSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1235MonSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1236MonSunat", Z1236MonSunat);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1236MonSunat',fld:'MONSUNAT',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A1236MonSunat',fld:'MONSUNAT',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[{av:'A1234MonDsc',fld:'MONDSC',pic:''},{av:'A1233MonAbr',fld:'MONABR',pic:''},{av:'A1235MonSts',fld:'MONSTS',pic:'9'},{av:'A1236MonSunat',fld:'MONSUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z180MonCod'},{av:'Z1234MonDsc'},{av:'Z1233MonAbr'},{av:'Z1235MonSts'},{av:'Z1236MonSunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1234MonDsc = "";
         Z1233MonAbr = "";
         Z1236MonSunat = "";
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
         A1234MonDsc = "";
         lblTextblock3_Jsonclick = "";
         A1233MonAbr = "";
         lblTextblock4_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1236MonSunat = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00304_A180MonCod = new int[1] ;
         T00304_A1234MonDsc = new string[] {""} ;
         T00304_A1233MonAbr = new string[] {""} ;
         T00304_A1235MonSts = new short[1] ;
         T00304_A1236MonSunat = new string[] {""} ;
         T00305_A180MonCod = new int[1] ;
         T00303_A180MonCod = new int[1] ;
         T00303_A1234MonDsc = new string[] {""} ;
         T00303_A1233MonAbr = new string[] {""} ;
         T00303_A1235MonSts = new short[1] ;
         T00303_A1236MonSunat = new string[] {""} ;
         sMode103 = "";
         T00306_A180MonCod = new int[1] ;
         T00307_A180MonCod = new int[1] ;
         T00302_A180MonCod = new int[1] ;
         T00302_A1234MonDsc = new string[] {""} ;
         T00302_A1233MonAbr = new string[] {""} ;
         T00302_A1235MonSts = new short[1] ;
         T00302_A1236MonSunat = new string[] {""} ;
         T003011_A2385ProCosProdCod = new string[] {""} ;
         T003012_A412PagReg = new long[1] ;
         T003013_A365EntCod = new int[1] ;
         T003013_A403MVLEntCod = new string[] {""} ;
         T003013_A404MVLEITem = new int[1] ;
         T003014_A358CajCod = new int[1] ;
         T003014_A391MVLCajCod = new string[] {""} ;
         T003014_A392MVLITem = new int[1] ;
         T003015_A365EntCod = new int[1] ;
         T003015_A366AperEntCod = new string[] {""} ;
         T003016_A358CajCod = new int[1] ;
         T003016_A359AperCajCod = new string[] {""} ;
         T003017_A307TipMonCod = new int[1] ;
         T003017_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003018_A289OrdCod = new string[] {""} ;
         T003019_A270LiqCod = new string[] {""} ;
         T003019_A236LiqPrvCod = new string[] {""} ;
         T003019_A271LiqCodItem = new int[1] ;
         T003020_A265LetPLetCod = new string[] {""} ;
         T003021_A260CPTipCod = new string[] {""} ;
         T003021_A261CPComCod = new string[] {""} ;
         T003021_A262CPPrvCod = new string[] {""} ;
         T003022_A149TipCod = new string[] {""} ;
         T003022_A243ComCod = new string[] {""} ;
         T003022_A244PrvCod = new string[] {""} ;
         T003023_A238CheqDCod = new string[] {""} ;
         T003024_A149TipCod = new string[] {""} ;
         T003024_A24DocNum = new string[] {""} ;
         T003025_A224LotCliCod = new string[] {""} ;
         T003026_A204LetCLetCod = new string[] {""} ;
         T003027_A191ImpItem = new long[1] ;
         T003028_A184CCTipCod = new string[] {""} ;
         T003028_A185CCDocNum = new string[] {""} ;
         T003029_A2280CBTipPre = new int[1] ;
         T003030_A372BanCod = new int[1] ;
         T003030_A377CBCod = new string[] {""} ;
         T003031_A210PedCod = new string[] {""} ;
         T003032_A177CotCod = new string[] {""} ;
         T003033_A166CobTip = new string[] {""} ;
         T003033_A167CobCod = new string[] {""} ;
         T003034_A150CLCheqDCod = new string[] {""} ;
         T003035_A144CLAntTipCod = new string[] {""} ;
         T003035_A145CLAntDocNum = new string[] {""} ;
         T003036_A127VouAno = new short[1] ;
         T003036_A128VouMes = new short[1] ;
         T003036_A126TASICod = new int[1] ;
         T003036_A129VouNum = new string[] {""} ;
         T003036_A130VouDSec = new int[1] ;
         T003037_A83ParTip = new string[] {""} ;
         T003037_A84ParCod = new int[1] ;
         T003038_A180MonCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1234MonDsc = "";
         ZZ1233MonAbr = "";
         ZZ1236MonSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cmonedas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cmonedas__default(),
            new Object[][] {
                new Object[] {
               T00302_A180MonCod, T00302_A1234MonDsc, T00302_A1233MonAbr, T00302_A1235MonSts, T00302_A1236MonSunat
               }
               , new Object[] {
               T00303_A180MonCod, T00303_A1234MonDsc, T00303_A1233MonAbr, T00303_A1235MonSts, T00303_A1236MonSunat
               }
               , new Object[] {
               T00304_A180MonCod, T00304_A1234MonDsc, T00304_A1233MonAbr, T00304_A1235MonSts, T00304_A1236MonSunat
               }
               , new Object[] {
               T00305_A180MonCod
               }
               , new Object[] {
               T00306_A180MonCod
               }
               , new Object[] {
               T00307_A180MonCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003011_A2385ProCosProdCod
               }
               , new Object[] {
               T003012_A412PagReg
               }
               , new Object[] {
               T003013_A365EntCod, T003013_A403MVLEntCod, T003013_A404MVLEITem
               }
               , new Object[] {
               T003014_A358CajCod, T003014_A391MVLCajCod, T003014_A392MVLITem
               }
               , new Object[] {
               T003015_A365EntCod, T003015_A366AperEntCod
               }
               , new Object[] {
               T003016_A358CajCod, T003016_A359AperCajCod
               }
               , new Object[] {
               T003017_A307TipMonCod, T003017_A308TipFech
               }
               , new Object[] {
               T003018_A289OrdCod
               }
               , new Object[] {
               T003019_A270LiqCod, T003019_A236LiqPrvCod, T003019_A271LiqCodItem
               }
               , new Object[] {
               T003020_A265LetPLetCod
               }
               , new Object[] {
               T003021_A260CPTipCod, T003021_A261CPComCod, T003021_A262CPPrvCod
               }
               , new Object[] {
               T003022_A149TipCod, T003022_A243ComCod, T003022_A244PrvCod
               }
               , new Object[] {
               T003023_A238CheqDCod
               }
               , new Object[] {
               T003024_A149TipCod, T003024_A24DocNum
               }
               , new Object[] {
               T003025_A224LotCliCod
               }
               , new Object[] {
               T003026_A204LetCLetCod
               }
               , new Object[] {
               T003027_A191ImpItem
               }
               , new Object[] {
               T003028_A184CCTipCod, T003028_A185CCDocNum
               }
               , new Object[] {
               T003029_A2280CBTipPre
               }
               , new Object[] {
               T003030_A372BanCod, T003030_A377CBCod
               }
               , new Object[] {
               T003031_A210PedCod
               }
               , new Object[] {
               T003032_A177CotCod
               }
               , new Object[] {
               T003033_A166CobTip, T003033_A167CobCod
               }
               , new Object[] {
               T003034_A150CLCheqDCod
               }
               , new Object[] {
               T003035_A144CLAntTipCod, T003035_A145CLAntDocNum
               }
               , new Object[] {
               T003036_A127VouAno, T003036_A128VouMes, T003036_A126TASICod, T003036_A129VouNum, T003036_A130VouDSec
               }
               , new Object[] {
               T003037_A83ParTip, T003037_A84ParCod
               }
               , new Object[] {
               T003038_A180MonCod
               }
            }
         );
      }

      private short Z1235MonSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1235MonSts ;
      private short GX_JID ;
      private short RcdFound103 ;
      private short nIsDirty_103 ;
      private short Gx_BScreen ;
      private short ZZ1235MonSts ;
      private int Z180MonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A180MonCod ;
      private int edtMonCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMonDsc_Enabled ;
      private int edtMonAbr_Enabled ;
      private int edtMonSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ180MonCod ;
      private string sPrefix ;
      private string Z1234MonDsc ;
      private string Z1233MonAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMonCod_Internalname ;
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
      private string edtMonCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMonDsc_Internalname ;
      private string A1234MonDsc ;
      private string edtMonDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMonAbr_Internalname ;
      private string A1233MonAbr ;
      private string edtMonAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMonSts_Internalname ;
      private string edtMonSts_Jsonclick ;
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
      private string sMode103 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1234MonDsc ;
      private string ZZ1233MonAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z1236MonSunat ;
      private string A1236MonSunat ;
      private string ZZ1236MonSunat ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00304_A180MonCod ;
      private string[] T00304_A1234MonDsc ;
      private string[] T00304_A1233MonAbr ;
      private short[] T00304_A1235MonSts ;
      private string[] T00304_A1236MonSunat ;
      private int[] T00305_A180MonCod ;
      private int[] T00303_A180MonCod ;
      private string[] T00303_A1234MonDsc ;
      private string[] T00303_A1233MonAbr ;
      private short[] T00303_A1235MonSts ;
      private string[] T00303_A1236MonSunat ;
      private int[] T00306_A180MonCod ;
      private int[] T00307_A180MonCod ;
      private int[] T00302_A180MonCod ;
      private string[] T00302_A1234MonDsc ;
      private string[] T00302_A1233MonAbr ;
      private short[] T00302_A1235MonSts ;
      private string[] T00302_A1236MonSunat ;
      private string[] T003011_A2385ProCosProdCod ;
      private long[] T003012_A412PagReg ;
      private int[] T003013_A365EntCod ;
      private string[] T003013_A403MVLEntCod ;
      private int[] T003013_A404MVLEITem ;
      private int[] T003014_A358CajCod ;
      private string[] T003014_A391MVLCajCod ;
      private int[] T003014_A392MVLITem ;
      private int[] T003015_A365EntCod ;
      private string[] T003015_A366AperEntCod ;
      private int[] T003016_A358CajCod ;
      private string[] T003016_A359AperCajCod ;
      private int[] T003017_A307TipMonCod ;
      private DateTime[] T003017_A308TipFech ;
      private string[] T003018_A289OrdCod ;
      private string[] T003019_A270LiqCod ;
      private string[] T003019_A236LiqPrvCod ;
      private int[] T003019_A271LiqCodItem ;
      private string[] T003020_A265LetPLetCod ;
      private string[] T003021_A260CPTipCod ;
      private string[] T003021_A261CPComCod ;
      private string[] T003021_A262CPPrvCod ;
      private string[] T003022_A149TipCod ;
      private string[] T003022_A243ComCod ;
      private string[] T003022_A244PrvCod ;
      private string[] T003023_A238CheqDCod ;
      private string[] T003024_A149TipCod ;
      private string[] T003024_A24DocNum ;
      private string[] T003025_A224LotCliCod ;
      private string[] T003026_A204LetCLetCod ;
      private long[] T003027_A191ImpItem ;
      private string[] T003028_A184CCTipCod ;
      private string[] T003028_A185CCDocNum ;
      private int[] T003029_A2280CBTipPre ;
      private int[] T003030_A372BanCod ;
      private string[] T003030_A377CBCod ;
      private string[] T003031_A210PedCod ;
      private string[] T003032_A177CotCod ;
      private string[] T003033_A166CobTip ;
      private string[] T003033_A167CobCod ;
      private string[] T003034_A150CLCheqDCod ;
      private string[] T003035_A144CLAntTipCod ;
      private string[] T003035_A145CLAntDocNum ;
      private short[] T003036_A127VouAno ;
      private short[] T003036_A128VouMes ;
      private int[] T003036_A126TASICod ;
      private string[] T003036_A129VouNum ;
      private int[] T003036_A130VouDSec ;
      private string[] T003037_A83ParTip ;
      private int[] T003037_A84ParCod ;
      private int[] T003038_A180MonCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cmonedas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cmonedas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00304;
        prmT00304 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00305;
        prmT00305 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00303;
        prmT00303 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00306;
        prmT00306 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00307;
        prmT00307 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00302;
        prmT00302 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00308;
        prmT00308 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@MonDsc",GXType.NChar,100,0) ,
        new ParDef("@MonAbr",GXType.NChar,5,0) ,
        new ParDef("@MonSts",GXType.Int16,1,0) ,
        new ParDef("@MonSunat",GXType.NVarChar,3,0)
        };
        Object[] prmT00309;
        prmT00309 = new Object[] {
        new ParDef("@MonDsc",GXType.NChar,100,0) ,
        new ParDef("@MonAbr",GXType.NChar,5,0) ,
        new ParDef("@MonSts",GXType.Int16,1,0) ,
        new ParDef("@MonSunat",GXType.NVarChar,3,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003010;
        prmT003010 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003011;
        prmT003011 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003012;
        prmT003012 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003013;
        prmT003013 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003014;
        prmT003014 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003015;
        prmT003015 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003016;
        prmT003016 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003017;
        prmT003017 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003018;
        prmT003018 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003019;
        prmT003019 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003020;
        prmT003020 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003021;
        prmT003021 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003022;
        prmT003022 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003023;
        prmT003023 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003024;
        prmT003024 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003025;
        prmT003025 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003026;
        prmT003026 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003027;
        prmT003027 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003028;
        prmT003028 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003029;
        prmT003029 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003030;
        prmT003030 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003031;
        prmT003031 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003032;
        prmT003032 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003033;
        prmT003033 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003034;
        prmT003034 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003035;
        prmT003035 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003036;
        prmT003036 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003037;
        prmT003037 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT003038;
        prmT003038 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00302", "SELECT [MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat] FROM [CMONEDAS] WITH (UPDLOCK) WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00302,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00303", "SELECT [MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00303,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00304", "SELECT TM1.[MonCod], TM1.[MonDsc], TM1.[MonAbr], TM1.[MonSts], TM1.[MonSunat] FROM [CMONEDAS] TM1 WHERE TM1.[MonCod] = @MonCod ORDER BY TM1.[MonCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00304,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00305", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00305,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00306", "SELECT TOP 1 [MonCod] FROM [CMONEDAS] WHERE ( [MonCod] > @MonCod) ORDER BY [MonCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00306,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00307", "SELECT TOP 1 [MonCod] FROM [CMONEDAS] WHERE ( [MonCod] < @MonCod) ORDER BY [MonCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00307,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00308", "INSERT INTO [CMONEDAS]([MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat]) VALUES(@MonCod, @MonDsc, @MonAbr, @MonSts, @MonSunat)", GxErrorMask.GX_NOMASK,prmT00308)
           ,new CursorDef("T00309", "UPDATE [CMONEDAS] SET [MonDsc]=@MonDsc, [MonAbr]=@MonAbr, [MonSts]=@MonSts, [MonSunat]=@MonSunat  WHERE [MonCod] = @MonCod", GxErrorMask.GX_NOMASK,prmT00309)
           ,new CursorDef("T003010", "DELETE FROM [CMONEDAS]  WHERE [MonCod] = @MonCod", GxErrorMask.GX_NOMASK,prmT003010)
           ,new CursorDef("T003011", "SELECT TOP 1 [ProCosProdCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003011,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003012", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003012,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003013", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003013,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003014", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003014,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003015", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003015,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003016", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003017", "SELECT TOP 1 [TipMonCod], [TipFech] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003018", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003018,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003019", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003019,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003020", "SELECT TOP 1 [LetPLetCod] FROM [CPLETRAS] WHERE [LetPMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003020,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003021", "SELECT TOP 1 [CPTipCod], [CPComCod], [CPPrvCod] FROM [CPCUENTAPAGAR] WHERE [CPMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003021,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003022", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [ComMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003022,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003023", "SELECT TOP 1 [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003023,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003024", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003024,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003025", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [LotMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003025,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003026", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE [LetCMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003026,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003027", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003027,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003028", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCmonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003028,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003029", "SELECT TOP 1 [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003029,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003030", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003030,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003031", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003031,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003032", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003032,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003033", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003033,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003034", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003034,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003035", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003035,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003036", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouDMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003036,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003037", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003037,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003038", "SELECT [MonCod] FROM [CMONEDAS] ORDER BY [MonCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003038,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 34 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
