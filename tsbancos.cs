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
   public class tsbancos : GXHttpHandler
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
            Form.Meta.addItem("description", "Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsbancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsbancos( IGxContext context )
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
            RenderHtmlCloseForm51168( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSBANCOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Banco", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Banco", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanDsc_Internalname, StringUtil.RTrim( A482BanDsc), StringUtil.RTrim( context.localUtil.Format( A482BanDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanAbr_Internalname, StringUtil.RTrim( A481BanAbr), StringUtil.RTrim( context.localUtil.Format( A481BanAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A483BanSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtBanSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A483BanSts), "9") : context.localUtil.Format( (decimal)(A483BanSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cod.Sunat", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanSunat_Internalname, StringUtil.RTrim( A484BanSunat), StringUtil.RTrim( context.localUtil.Format( A484BanSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSBANCOS.htm");
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
            Z372BanCod = (int)(context.localUtil.CToN( cgiGet( "Z372BanCod"), ".", ","));
            Z482BanDsc = cgiGet( "Z482BanDsc");
            Z481BanAbr = cgiGet( "Z481BanAbr");
            Z483BanSts = (short)(context.localUtil.CToN( cgiGet( "Z483BanSts"), ".", ","));
            Z484BanSunat = cgiGet( "Z484BanSunat");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A372BanCod = 0;
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            }
            else
            {
               A372BanCod = (int)(context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            }
            A482BanDsc = cgiGet( edtBanDsc_Internalname);
            AssignAttri("", false, "A482BanDsc", A482BanDsc);
            A481BanAbr = cgiGet( edtBanAbr_Internalname);
            AssignAttri("", false, "A481BanAbr", A481BanAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANSTS");
               AnyError = 1;
               GX_FocusControl = edtBanSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A483BanSts = 0;
               AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            }
            else
            {
               A483BanSts = (short)(context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ","));
               AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            }
            A484BanSunat = cgiGet( edtBanSunat_Internalname);
            AssignAttri("", false, "A484BanSunat", A484BanSunat);
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
               A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
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
               InitAll51168( ) ;
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
         DisableAttributes51168( ) ;
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

      protected void CONFIRM_510( )
      {
         BeforeValidate51168( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls51168( ) ;
            }
            else
            {
               CheckExtendedTable51168( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors51168( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues510( ) ;
         }
      }

      protected void ResetCaption510( )
      {
      }

      protected void ZM51168( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z482BanDsc = T00513_A482BanDsc[0];
               Z481BanAbr = T00513_A481BanAbr[0];
               Z483BanSts = T00513_A483BanSts[0];
               Z484BanSunat = T00513_A484BanSunat[0];
            }
            else
            {
               Z482BanDsc = A482BanDsc;
               Z481BanAbr = A481BanAbr;
               Z483BanSts = A483BanSts;
               Z484BanSunat = A484BanSunat;
            }
         }
         if ( GX_JID == -1 )
         {
            Z372BanCod = A372BanCod;
            Z482BanDsc = A482BanDsc;
            Z481BanAbr = A481BanAbr;
            Z483BanSts = A483BanSts;
            Z484BanSunat = A484BanSunat;
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

      protected void Load51168( )
      {
         /* Using cursor T00514 */
         pr_default.execute(2, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound168 = 1;
            A482BanDsc = T00514_A482BanDsc[0];
            AssignAttri("", false, "A482BanDsc", A482BanDsc);
            A481BanAbr = T00514_A481BanAbr[0];
            AssignAttri("", false, "A481BanAbr", A481BanAbr);
            A483BanSts = T00514_A483BanSts[0];
            AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            A484BanSunat = T00514_A484BanSunat[0];
            AssignAttri("", false, "A484BanSunat", A484BanSunat);
            ZM51168( -1) ;
         }
         pr_default.close(2);
         OnLoadActions51168( ) ;
      }

      protected void OnLoadActions51168( )
      {
      }

      protected void CheckExtendedTable51168( )
      {
         nIsDirty_168 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors51168( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey51168( )
      {
         /* Using cursor T00515 */
         pr_default.execute(3, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound168 = 1;
         }
         else
         {
            RcdFound168 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00513 */
         pr_default.execute(1, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM51168( 1) ;
            RcdFound168 = 1;
            A372BanCod = T00513_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A482BanDsc = T00513_A482BanDsc[0];
            AssignAttri("", false, "A482BanDsc", A482BanDsc);
            A481BanAbr = T00513_A481BanAbr[0];
            AssignAttri("", false, "A481BanAbr", A481BanAbr);
            A483BanSts = T00513_A483BanSts[0];
            AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            A484BanSunat = T00513_A484BanSunat[0];
            AssignAttri("", false, "A484BanSunat", A484BanSunat);
            Z372BanCod = A372BanCod;
            sMode168 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load51168( ) ;
            if ( AnyError == 1 )
            {
               RcdFound168 = 0;
               InitializeNonKey51168( ) ;
            }
            Gx_mode = sMode168;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound168 = 0;
            InitializeNonKey51168( ) ;
            sMode168 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode168;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey51168( ) ;
         if ( RcdFound168 == 0 )
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
         RcdFound168 = 0;
         /* Using cursor T00516 */
         pr_default.execute(4, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00516_A372BanCod[0] < A372BanCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00516_A372BanCod[0] > A372BanCod ) ) )
            {
               A372BanCod = T00516_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               RcdFound168 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound168 = 0;
         /* Using cursor T00517 */
         pr_default.execute(5, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00517_A372BanCod[0] > A372BanCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00517_A372BanCod[0] < A372BanCod ) ) )
            {
               A372BanCod = T00517_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               RcdFound168 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey51168( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert51168( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound168 == 1 )
            {
               if ( A372BanCod != Z372BanCod )
               {
                  A372BanCod = Z372BanCod;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update51168( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A372BanCod != Z372BanCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert51168( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert51168( ) ;
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
         if ( A372BanCod != Z372BanCod )
         {
            A372BanCod = Z372BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBanCod_Internalname;
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
         GetKey51168( ) ;
         if ( RcdFound168 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A372BanCod != Z372BanCod )
            {
               A372BanCod = Z372BanCod;
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
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
            if ( A372BanCod != Z372BanCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
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
         context.RollbackDataStores("tsbancos",pr_default);
         GX_FocusControl = edtBanDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_510( ) ;
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
         if ( RcdFound168 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtBanDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart51168( ) ;
         if ( RcdFound168 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBanDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd51168( ) ;
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
         if ( RcdFound168 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBanDsc_Internalname;
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
         if ( RcdFound168 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBanDsc_Internalname;
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
         ScanStart51168( ) ;
         if ( RcdFound168 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound168 != 0 )
            {
               ScanNext51168( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBanDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd51168( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency51168( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00512 */
            pr_default.execute(0, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z482BanDsc, T00512_A482BanDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z481BanAbr, T00512_A481BanAbr[0]) != 0 ) || ( Z483BanSts != T00512_A483BanSts[0] ) || ( StringUtil.StrCmp(Z484BanSunat, T00512_A484BanSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z482BanDsc, T00512_A482BanDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsbancos:[seudo value changed for attri]"+"BanDsc");
                  GXUtil.WriteLogRaw("Old: ",Z482BanDsc);
                  GXUtil.WriteLogRaw("Current: ",T00512_A482BanDsc[0]);
               }
               if ( StringUtil.StrCmp(Z481BanAbr, T00512_A481BanAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("tsbancos:[seudo value changed for attri]"+"BanAbr");
                  GXUtil.WriteLogRaw("Old: ",Z481BanAbr);
                  GXUtil.WriteLogRaw("Current: ",T00512_A481BanAbr[0]);
               }
               if ( Z483BanSts != T00512_A483BanSts[0] )
               {
                  GXUtil.WriteLog("tsbancos:[seudo value changed for attri]"+"BanSts");
                  GXUtil.WriteLogRaw("Old: ",Z483BanSts);
                  GXUtil.WriteLogRaw("Current: ",T00512_A483BanSts[0]);
               }
               if ( StringUtil.StrCmp(Z484BanSunat, T00512_A484BanSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("tsbancos:[seudo value changed for attri]"+"BanSunat");
                  GXUtil.WriteLogRaw("Old: ",Z484BanSunat);
                  GXUtil.WriteLogRaw("Current: ",T00512_A484BanSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert51168( )
      {
         BeforeValidate51168( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable51168( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM51168( 0) ;
            CheckOptimisticConcurrency51168( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm51168( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert51168( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00518 */
                     pr_default.execute(6, new Object[] {A372BanCod, A482BanDsc, A481BanAbr, A483BanSts, A484BanSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
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
                           ResetCaption510( ) ;
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
               Load51168( ) ;
            }
            EndLevel51168( ) ;
         }
         CloseExtendedTableCursors51168( ) ;
      }

      protected void Update51168( )
      {
         BeforeValidate51168( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable51168( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency51168( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm51168( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate51168( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00519 */
                     pr_default.execute(7, new Object[] {A482BanDsc, A481BanAbr, A483BanSts, A484BanSunat, A372BanCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate51168( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption510( ) ;
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
            EndLevel51168( ) ;
         }
         CloseExtendedTableCursors51168( ) ;
      }

      protected void DeferredUpdate51168( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate51168( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency51168( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls51168( ) ;
            AfterConfirm51168( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete51168( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005110 */
                  pr_default.execute(8, new Object[] {A372BanCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound168 == 0 )
                        {
                           InitAll51168( ) ;
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
                        ResetCaption510( ) ;
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
         sMode168 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel51168( ) ;
         Gx_mode = sMode168;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls51168( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005111 */
            pr_default.execute(9, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005112 */
            pr_default.execute(10, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"+" ("+"Bancos Destino"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T005113 */
            pr_default.execute(11, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"+" ("+"Banco Origen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005114 */
            pr_default.execute(12, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005115 */
            pr_default.execute(13, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005116 */
            pr_default.execute(14, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005117 */
            pr_default.execute(15, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005118 */
            pr_default.execute(16, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005119 */
            pr_default.execute(17, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005120 */
            pr_default.execute(18, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005121 */
            pr_default.execute(19, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"+" ("+"Banco"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T005122 */
            pr_default.execute(20, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"+" ("+"Banco"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T005123 */
            pr_default.execute(21, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T005124 */
            pr_default.execute(22, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T005125 */
            pr_default.execute(23, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel51168( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete51168( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tsbancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues510( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tsbancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart51168( )
      {
         /* Using cursor T005126 */
         pr_default.execute(24);
         RcdFound168 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound168 = 1;
            A372BanCod = T005126_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext51168( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound168 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound168 = 1;
            A372BanCod = T005126_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
      }

      protected void ScanEnd51168( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm51168( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert51168( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate51168( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete51168( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete51168( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate51168( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes51168( )
      {
         edtBanCod_Enabled = 0;
         AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         edtBanDsc_Enabled = 0;
         AssignProp("", false, edtBanDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanDsc_Enabled), 5, 0), true);
         edtBanAbr_Enabled = 0;
         AssignProp("", false, edtBanAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanAbr_Enabled), 5, 0), true);
         edtBanSts_Enabled = 0;
         AssignProp("", false, edtBanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanSts_Enabled), 5, 0), true);
         edtBanSunat_Enabled = 0;
         AssignProp("", false, edtBanSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanSunat_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes51168( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues510( )
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
         context.SendWebValue( "Bancos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025482", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsbancos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z482BanDsc", StringUtil.RTrim( Z482BanDsc));
         GxWebStd.gx_hidden_field( context, "Z481BanAbr", StringUtil.RTrim( Z481BanAbr));
         GxWebStd.gx_hidden_field( context, "Z483BanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z483BanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z484BanSunat", StringUtil.RTrim( Z484BanSunat));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm51168( )
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
         return "TSBANCOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Bancos" ;
      }

      protected void InitializeNonKey51168( )
      {
         A482BanDsc = "";
         AssignAttri("", false, "A482BanDsc", A482BanDsc);
         A481BanAbr = "";
         AssignAttri("", false, "A481BanAbr", A481BanAbr);
         A483BanSts = 0;
         AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
         A484BanSunat = "";
         AssignAttri("", false, "A484BanSunat", A484BanSunat);
         Z482BanDsc = "";
         Z481BanAbr = "";
         Z483BanSts = 0;
         Z484BanSunat = "";
      }

      protected void InitAll51168( )
      {
         A372BanCod = 0;
         AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         InitializeNonKey51168( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025488", true, true);
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
         context.AddJavascriptSource("tsbancos.js", "?20228181025488", false, true);
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
         edtBanCod_Internalname = "BANCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtBanDsc_Internalname = "BANDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtBanAbr_Internalname = "BANABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtBanSts_Internalname = "BANSTS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtBanSunat_Internalname = "BANSUNAT";
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
         edtBanSunat_Jsonclick = "";
         edtBanSunat_Enabled = 1;
         edtBanSts_Jsonclick = "";
         edtBanSts_Enabled = 1;
         edtBanAbr_Jsonclick = "";
         edtBanAbr_Enabled = 1;
         edtBanDsc_Jsonclick = "";
         edtBanDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtBanCod_Jsonclick = "";
         edtBanCod_Enabled = 1;
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
         GX_FocusControl = edtBanDsc_Internalname;
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

      public void Valid_Bancod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A482BanDsc", StringUtil.RTrim( A482BanDsc));
         AssignAttri("", false, "A481BanAbr", StringUtil.RTrim( A481BanAbr));
         AssignAttri("", false, "A483BanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A483BanSts), 1, 0, ".", "")));
         AssignAttri("", false, "A484BanSunat", StringUtil.RTrim( A484BanSunat));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z482BanDsc", StringUtil.RTrim( Z482BanDsc));
         GxWebStd.gx_hidden_field( context, "Z481BanAbr", StringUtil.RTrim( Z481BanAbr));
         GxWebStd.gx_hidden_field( context, "Z483BanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z483BanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z484BanSunat", StringUtil.RTrim( Z484BanSunat));
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
         setEventMetadata("VALID_BANCOD","{handler:'Valid_Bancod',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_BANCOD",",oparms:[{av:'A482BanDsc',fld:'BANDSC',pic:''},{av:'A481BanAbr',fld:'BANABR',pic:''},{av:'A483BanSts',fld:'BANSTS',pic:'9'},{av:'A484BanSunat',fld:'BANSUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z372BanCod'},{av:'Z482BanDsc'},{av:'Z481BanAbr'},{av:'Z483BanSts'},{av:'Z484BanSunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z482BanDsc = "";
         Z481BanAbr = "";
         Z484BanSunat = "";
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
         A482BanDsc = "";
         lblTextblock3_Jsonclick = "";
         A481BanAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A484BanSunat = "";
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
         T00514_A372BanCod = new int[1] ;
         T00514_A482BanDsc = new string[] {""} ;
         T00514_A481BanAbr = new string[] {""} ;
         T00514_A483BanSts = new short[1] ;
         T00514_A484BanSunat = new string[] {""} ;
         T00515_A372BanCod = new int[1] ;
         T00513_A372BanCod = new int[1] ;
         T00513_A482BanDsc = new string[] {""} ;
         T00513_A481BanAbr = new string[] {""} ;
         T00513_A483BanSts = new short[1] ;
         T00513_A484BanSunat = new string[] {""} ;
         sMode168 = "";
         T00516_A372BanCod = new int[1] ;
         T00517_A372BanCod = new int[1] ;
         T00512_A372BanCod = new int[1] ;
         T00512_A482BanDsc = new string[] {""} ;
         T00512_A481BanAbr = new string[] {""} ;
         T00512_A483BanSts = new short[1] ;
         T00512_A484BanSunat = new string[] {""} ;
         T005111_A348UsuCod = new string[] {""} ;
         T005112_A423TSTransCod = new string[] {""} ;
         T005113_A423TSTransCod = new string[] {""} ;
         T005114_A412PagReg = new long[1] ;
         T005115_A387TSMovCod = new string[] {""} ;
         T005116_A379LBBanCod = new int[1] ;
         T005116_A380LBCBCod = new string[] {""} ;
         T005116_A381LBRegistro = new string[] {""} ;
         T005117_A372BanCod = new int[1] ;
         T005117_A377CBCod = new string[] {""} ;
         T005118_A365EntCod = new int[1] ;
         T005118_A366AperEntCod = new string[] {""} ;
         T005119_A358CajCod = new int[1] ;
         T005119_A359AperCajCod = new string[] {""} ;
         T005120_A354TSAntCod = new string[] {""} ;
         T005121_A244PrvCod = new string[] {""} ;
         T005122_A244PrvCod = new string[] {""} ;
         T005123_A270LiqCod = new string[] {""} ;
         T005123_A236LiqPrvCod = new string[] {""} ;
         T005123_A271LiqCodItem = new int[1] ;
         T005124_A166CobTip = new string[] {""} ;
         T005124_A167CobCod = new string[] {""} ;
         T005124_A173Item = new int[1] ;
         T005125_A166CobTip = new string[] {""} ;
         T005125_A167CobCod = new string[] {""} ;
         T005126_A372BanCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ482BanDsc = "";
         ZZ481BanAbr = "";
         ZZ484BanSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsbancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsbancos__default(),
            new Object[][] {
                new Object[] {
               T00512_A372BanCod, T00512_A482BanDsc, T00512_A481BanAbr, T00512_A483BanSts, T00512_A484BanSunat
               }
               , new Object[] {
               T00513_A372BanCod, T00513_A482BanDsc, T00513_A481BanAbr, T00513_A483BanSts, T00513_A484BanSunat
               }
               , new Object[] {
               T00514_A372BanCod, T00514_A482BanDsc, T00514_A481BanAbr, T00514_A483BanSts, T00514_A484BanSunat
               }
               , new Object[] {
               T00515_A372BanCod
               }
               , new Object[] {
               T00516_A372BanCod
               }
               , new Object[] {
               T00517_A372BanCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005111_A348UsuCod
               }
               , new Object[] {
               T005112_A423TSTransCod
               }
               , new Object[] {
               T005113_A423TSTransCod
               }
               , new Object[] {
               T005114_A412PagReg
               }
               , new Object[] {
               T005115_A387TSMovCod
               }
               , new Object[] {
               T005116_A379LBBanCod, T005116_A380LBCBCod, T005116_A381LBRegistro
               }
               , new Object[] {
               T005117_A372BanCod, T005117_A377CBCod
               }
               , new Object[] {
               T005118_A365EntCod, T005118_A366AperEntCod
               }
               , new Object[] {
               T005119_A358CajCod, T005119_A359AperCajCod
               }
               , new Object[] {
               T005120_A354TSAntCod
               }
               , new Object[] {
               T005121_A244PrvCod
               }
               , new Object[] {
               T005122_A244PrvCod
               }
               , new Object[] {
               T005123_A270LiqCod, T005123_A236LiqPrvCod, T005123_A271LiqCodItem
               }
               , new Object[] {
               T005124_A166CobTip, T005124_A167CobCod, T005124_A173Item
               }
               , new Object[] {
               T005125_A166CobTip, T005125_A167CobCod
               }
               , new Object[] {
               T005126_A372BanCod
               }
            }
         );
      }

      private short Z483BanSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A483BanSts ;
      private short GX_JID ;
      private short RcdFound168 ;
      private short nIsDirty_168 ;
      private short Gx_BScreen ;
      private short ZZ483BanSts ;
      private int Z372BanCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A372BanCod ;
      private int edtBanCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtBanDsc_Enabled ;
      private int edtBanAbr_Enabled ;
      private int edtBanSts_Enabled ;
      private int edtBanSunat_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ372BanCod ;
      private string sPrefix ;
      private string Z482BanDsc ;
      private string Z481BanAbr ;
      private string Z484BanSunat ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtBanCod_Internalname ;
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
      private string edtBanCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtBanDsc_Internalname ;
      private string A482BanDsc ;
      private string edtBanDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtBanAbr_Internalname ;
      private string A481BanAbr ;
      private string edtBanAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtBanSts_Internalname ;
      private string edtBanSts_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtBanSunat_Internalname ;
      private string A484BanSunat ;
      private string edtBanSunat_Jsonclick ;
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
      private string sMode168 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ482BanDsc ;
      private string ZZ481BanAbr ;
      private string ZZ484BanSunat ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00514_A372BanCod ;
      private string[] T00514_A482BanDsc ;
      private string[] T00514_A481BanAbr ;
      private short[] T00514_A483BanSts ;
      private string[] T00514_A484BanSunat ;
      private int[] T00515_A372BanCod ;
      private int[] T00513_A372BanCod ;
      private string[] T00513_A482BanDsc ;
      private string[] T00513_A481BanAbr ;
      private short[] T00513_A483BanSts ;
      private string[] T00513_A484BanSunat ;
      private int[] T00516_A372BanCod ;
      private int[] T00517_A372BanCod ;
      private int[] T00512_A372BanCod ;
      private string[] T00512_A482BanDsc ;
      private string[] T00512_A481BanAbr ;
      private short[] T00512_A483BanSts ;
      private string[] T00512_A484BanSunat ;
      private string[] T005111_A348UsuCod ;
      private string[] T005112_A423TSTransCod ;
      private string[] T005113_A423TSTransCod ;
      private long[] T005114_A412PagReg ;
      private string[] T005115_A387TSMovCod ;
      private int[] T005116_A379LBBanCod ;
      private string[] T005116_A380LBCBCod ;
      private string[] T005116_A381LBRegistro ;
      private int[] T005117_A372BanCod ;
      private string[] T005117_A377CBCod ;
      private int[] T005118_A365EntCod ;
      private string[] T005118_A366AperEntCod ;
      private int[] T005119_A358CajCod ;
      private string[] T005119_A359AperCajCod ;
      private string[] T005120_A354TSAntCod ;
      private string[] T005121_A244PrvCod ;
      private string[] T005122_A244PrvCod ;
      private string[] T005123_A270LiqCod ;
      private string[] T005123_A236LiqPrvCod ;
      private int[] T005123_A271LiqCodItem ;
      private string[] T005124_A166CobTip ;
      private string[] T005124_A167CobCod ;
      private int[] T005124_A173Item ;
      private string[] T005125_A166CobTip ;
      private string[] T005125_A167CobCod ;
      private int[] T005126_A372BanCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tsbancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsbancos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00514;
        prmT00514 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00515;
        prmT00515 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00513;
        prmT00513 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00516;
        prmT00516 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00517;
        prmT00517 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00512;
        prmT00512 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00518;
        prmT00518 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@BanDsc",GXType.NChar,100,0) ,
        new ParDef("@BanAbr",GXType.NChar,5,0) ,
        new ParDef("@BanSts",GXType.Int16,1,0) ,
        new ParDef("@BanSunat",GXType.NChar,5,0)
        };
        Object[] prmT00519;
        prmT00519 = new Object[] {
        new ParDef("@BanDsc",GXType.NChar,100,0) ,
        new ParDef("@BanAbr",GXType.NChar,5,0) ,
        new ParDef("@BanSts",GXType.Int16,1,0) ,
        new ParDef("@BanSunat",GXType.NChar,5,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005110;
        prmT005110 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005111;
        prmT005111 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005112;
        prmT005112 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005113;
        prmT005113 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005114;
        prmT005114 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005115;
        prmT005115 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005116;
        prmT005116 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005117;
        prmT005117 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005118;
        prmT005118 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005119;
        prmT005119 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005120;
        prmT005120 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005121;
        prmT005121 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005122;
        prmT005122 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005123;
        prmT005123 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005124;
        prmT005124 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005125;
        prmT005125 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005126;
        prmT005126 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00512", "SELECT [BanCod], [BanDsc], [BanAbr], [BanSts], [BanSunat] FROM [TSBANCOS] WITH (UPDLOCK) WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00512,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00513", "SELECT [BanCod], [BanDsc], [BanAbr], [BanSts], [BanSunat] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00514", "SELECT TM1.[BanCod], TM1.[BanDsc], TM1.[BanAbr], TM1.[BanSts], TM1.[BanSunat] FROM [TSBANCOS] TM1 WHERE TM1.[BanCod] = @BanCod ORDER BY TM1.[BanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00514,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00515", "SELECT [BanCod] FROM [TSBANCOS] WHERE [BanCod] = @BanCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00516", "SELECT TOP 1 [BanCod] FROM [TSBANCOS] WHERE ( [BanCod] > @BanCod) ORDER BY [BanCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00516,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00517", "SELECT TOP 1 [BanCod] FROM [TSBANCOS] WHERE ( [BanCod] < @BanCod) ORDER BY [BanCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00517,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00518", "INSERT INTO [TSBANCOS]([BanCod], [BanDsc], [BanAbr], [BanSts], [BanSunat]) VALUES(@BanCod, @BanDsc, @BanAbr, @BanSts, @BanSunat)", GxErrorMask.GX_NOMASK,prmT00518)
           ,new CursorDef("T00519", "UPDATE [TSBANCOS] SET [BanDsc]=@BanDsc, [BanAbr]=@BanAbr, [BanSts]=@BanSts, [BanSunat]=@BanSunat  WHERE [BanCod] = @BanCod", GxErrorMask.GX_NOMASK,prmT00519)
           ,new CursorDef("T005110", "DELETE FROM [TSBANCOS]  WHERE [BanCod] = @BanCod", GxErrorMask.GX_NOMASK,prmT005110)
           ,new CursorDef("T005111", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005112", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransBanDestino] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005113", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransBanOrigen] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005114", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005115", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005115,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005116", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005116,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005117", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005117,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005118", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005118,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005119", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005119,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005120", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [TSAntBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005120,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005121", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvBanCod2] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005121,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005122", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvBanCod1] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005122,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005123", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005123,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005124", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [CobDBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005124,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005125", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005125,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005126", "SELECT [BanCod] FROM [TSBANCOS] ORDER BY [BanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005126,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
