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
   public class tscajachica : GXHttpHandler
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A91CueCod) ;
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
            Form.Meta.addItem("description", "Caja Chica", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tscajachica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tscajachica( IGxContext context )
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
         cmbCajSts = new GXCombobox();
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
         if ( cmbCajSts.ItemCount > 0 )
         {
            A487CajSts = (short)(NumberUtil.Val( cmbCajSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0))), "."));
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            AssignProp("", false, cmbCajSts_Internalname, "Values", cmbCajSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm52169( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSCAJACHICA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo de Caja", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A358CajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripción de Caja", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajDsc_Internalname, StringUtil.RTrim( A486CajDsc), StringUtil.RTrim( context.localUtil.Format( A486CajDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajAbr_Internalname, StringUtil.RTrim( A485CajAbr), StringUtil.RTrim( context.localUtil.Format( A485CajAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cuenta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Estado", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCajSts, cmbCajSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0)), 1, cmbCajSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCajSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_TSCAJACHICA.htm");
         cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         AssignProp("", false, cmbCajSts_Internalname, "Values", (string)(cmbCajSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSCAJACHICA.htm");
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
            Z358CajCod = (int)(context.localUtil.CToN( cgiGet( "Z358CajCod"), ".", ","));
            Z486CajDsc = cgiGet( "Z486CajDsc");
            Z485CajAbr = cgiGet( "Z485CajAbr");
            Z487CajSts = (short)(context.localUtil.CToN( cgiGet( "Z487CajSts"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A358CajCod = 0;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            else
            {
               A358CajCod = (int)(context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            A486CajDsc = cgiGet( edtCajDsc_Internalname);
            AssignAttri("", false, "A486CajDsc", A486CajDsc);
            A485CajAbr = cgiGet( edtCajAbr_Internalname);
            AssignAttri("", false, "A485CajAbr", A485CajAbr);
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            cmbCajSts.CurrentValue = cgiGet( cmbCajSts_Internalname);
            A487CajSts = (short)(NumberUtil.Val( cgiGet( cmbCajSts_Internalname), "."));
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
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
               A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
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
               InitAll52169( ) ;
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
         DisableAttributes52169( ) ;
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

      protected void CONFIRM_520( )
      {
         BeforeValidate52169( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls52169( ) ;
            }
            else
            {
               CheckExtendedTable52169( ) ;
               if ( AnyError == 0 )
               {
                  ZM52169( 2) ;
               }
               CloseExtendedTableCursors52169( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues520( ) ;
         }
      }

      protected void ResetCaption520( )
      {
      }

      protected void ZM52169( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z486CajDsc = T00523_A486CajDsc[0];
               Z485CajAbr = T00523_A485CajAbr[0];
               Z487CajSts = T00523_A487CajSts[0];
               Z91CueCod = T00523_A91CueCod[0];
            }
            else
            {
               Z486CajDsc = A486CajDsc;
               Z485CajAbr = A485CajAbr;
               Z487CajSts = A487CajSts;
               Z91CueCod = A91CueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z358CajCod = A358CajCod;
            Z486CajDsc = A486CajDsc;
            Z485CajAbr = A485CajAbr;
            Z487CajSts = A487CajSts;
            Z91CueCod = A91CueCod;
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

      protected void Load52169( )
      {
         /* Using cursor T00525 */
         pr_default.execute(3, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound169 = 1;
            A486CajDsc = T00525_A486CajDsc[0];
            AssignAttri("", false, "A486CajDsc", A486CajDsc);
            A485CajAbr = T00525_A485CajAbr[0];
            AssignAttri("", false, "A485CajAbr", A485CajAbr);
            A487CajSts = T00525_A487CajSts[0];
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            A91CueCod = T00525_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            ZM52169( -1) ;
         }
         pr_default.close(3);
         OnLoadActions52169( ) ;
      }

      protected void OnLoadActions52169( )
      {
      }

      protected void CheckExtendedTable52169( )
      {
         nIsDirty_169 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00524 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors52169( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A91CueCod )
      {
         /* Using cursor T00526 */
         pr_default.execute(4, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey52169( )
      {
         /* Using cursor T00527 */
         pr_default.execute(5, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound169 = 1;
         }
         else
         {
            RcdFound169 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00523 */
         pr_default.execute(1, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM52169( 1) ;
            RcdFound169 = 1;
            A358CajCod = T00523_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A486CajDsc = T00523_A486CajDsc[0];
            AssignAttri("", false, "A486CajDsc", A486CajDsc);
            A485CajAbr = T00523_A485CajAbr[0];
            AssignAttri("", false, "A485CajAbr", A485CajAbr);
            A487CajSts = T00523_A487CajSts[0];
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
            A91CueCod = T00523_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            Z358CajCod = A358CajCod;
            sMode169 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load52169( ) ;
            if ( AnyError == 1 )
            {
               RcdFound169 = 0;
               InitializeNonKey52169( ) ;
            }
            Gx_mode = sMode169;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound169 = 0;
            InitializeNonKey52169( ) ;
            sMode169 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode169;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey52169( ) ;
         if ( RcdFound169 == 0 )
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
         RcdFound169 = 0;
         /* Using cursor T00528 */
         pr_default.execute(6, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00528_A358CajCod[0] < A358CajCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00528_A358CajCod[0] > A358CajCod ) ) )
            {
               A358CajCod = T00528_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               RcdFound169 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound169 = 0;
         /* Using cursor T00529 */
         pr_default.execute(7, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00529_A358CajCod[0] > A358CajCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00529_A358CajCod[0] < A358CajCod ) ) )
            {
               A358CajCod = T00529_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               RcdFound169 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey52169( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert52169( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound169 == 1 )
            {
               if ( A358CajCod != Z358CajCod )
               {
                  A358CajCod = Z358CajCod;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update52169( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A358CajCod != Z358CajCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert52169( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert52169( ) ;
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
         if ( A358CajCod != Z358CajCod )
         {
            A358CajCod = Z358CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCajCod_Internalname;
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
         GetKey52169( ) ;
         if ( RcdFound169 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A358CajCod != Z358CajCod )
            {
               A358CajCod = Z358CajCod;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
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
            if ( A358CajCod != Z358CajCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
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
         context.RollbackDataStores("tscajachica",pr_default);
         GX_FocusControl = edtCajDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_520( ) ;
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
         if ( RcdFound169 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCajDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart52169( ) ;
         if ( RcdFound169 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCajDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd52169( ) ;
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
         if ( RcdFound169 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCajDsc_Internalname;
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
         if ( RcdFound169 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCajDsc_Internalname;
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
         ScanStart52169( ) ;
         if ( RcdFound169 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound169 != 0 )
            {
               ScanNext52169( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCajDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd52169( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency52169( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00522 */
            pr_default.execute(0, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJACHICA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z486CajDsc, T00522_A486CajDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z485CajAbr, T00522_A485CajAbr[0]) != 0 ) || ( Z487CajSts != T00522_A487CajSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T00522_A91CueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z486CajDsc, T00522_A486CajDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajachica:[seudo value changed for attri]"+"CajDsc");
                  GXUtil.WriteLogRaw("Old: ",Z486CajDsc);
                  GXUtil.WriteLogRaw("Current: ",T00522_A486CajDsc[0]);
               }
               if ( StringUtil.StrCmp(Z485CajAbr, T00522_A485CajAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajachica:[seudo value changed for attri]"+"CajAbr");
                  GXUtil.WriteLogRaw("Old: ",Z485CajAbr);
                  GXUtil.WriteLogRaw("Current: ",T00522_A485CajAbr[0]);
               }
               if ( Z487CajSts != T00522_A487CajSts[0] )
               {
                  GXUtil.WriteLog("tscajachica:[seudo value changed for attri]"+"CajSts");
                  GXUtil.WriteLogRaw("Old: ",Z487CajSts);
                  GXUtil.WriteLogRaw("Current: ",T00522_A487CajSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T00522_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tscajachica:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T00522_A91CueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCAJACHICA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert52169( )
      {
         BeforeValidate52169( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable52169( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM52169( 0) ;
            CheckOptimisticConcurrency52169( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm52169( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert52169( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005210 */
                     pr_default.execute(8, new Object[] {A358CajCod, A486CajDsc, A485CajAbr, A487CajSts, A91CueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption520( ) ;
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
               Load52169( ) ;
            }
            EndLevel52169( ) ;
         }
         CloseExtendedTableCursors52169( ) ;
      }

      protected void Update52169( )
      {
         BeforeValidate52169( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable52169( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency52169( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm52169( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate52169( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005211 */
                     pr_default.execute(9, new Object[] {A486CajDsc, A485CajAbr, A487CajSts, A91CueCod, A358CajCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCAJACHICA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate52169( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption520( ) ;
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
            EndLevel52169( ) ;
         }
         CloseExtendedTableCursors52169( ) ;
      }

      protected void DeferredUpdate52169( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate52169( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency52169( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls52169( ) ;
            AfterConfirm52169( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete52169( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005212 */
                  pr_default.execute(10, new Object[] {A358CajCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCAJACHICA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound169 == 0 )
                        {
                           InitAll52169( ) ;
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
                        ResetCaption520( ) ;
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
         sMode169 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel52169( ) ;
         Gx_mode = sMode169;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls52169( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005213 */
            pr_default.execute(11, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005214 */
            pr_default.execute(12, new Object[] {A358CajCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel52169( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete52169( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tscajachica",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues520( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tscajachica",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart52169( )
      {
         /* Using cursor T005215 */
         pr_default.execute(13);
         RcdFound169 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound169 = 1;
            A358CajCod = T005215_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext52169( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound169 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound169 = 1;
            A358CajCod = T005215_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         }
      }

      protected void ScanEnd52169( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm52169( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert52169( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate52169( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete52169( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete52169( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate52169( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes52169( )
      {
         edtCajCod_Enabled = 0;
         AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         edtCajDsc_Enabled = 0;
         AssignProp("", false, edtCajDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajDsc_Enabled), 5, 0), true);
         edtCajAbr_Enabled = 0;
         AssignProp("", false, edtCajAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajAbr_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         cmbCajSts.Enabled = 0;
         AssignProp("", false, cmbCajSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCajSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes52169( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues520( )
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
         context.SendWebValue( "Caja Chica") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254569", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tscajachica.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z486CajDsc", StringUtil.RTrim( Z486CajDsc));
         GxWebStd.gx_hidden_field( context, "Z485CajAbr", StringUtil.RTrim( Z485CajAbr));
         GxWebStd.gx_hidden_field( context, "Z487CajSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487CajSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm52169( )
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
         return "TSCAJACHICA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Caja Chica" ;
      }

      protected void InitializeNonKey52169( )
      {
         A486CajDsc = "";
         AssignAttri("", false, "A486CajDsc", A486CajDsc);
         A485CajAbr = "";
         AssignAttri("", false, "A485CajAbr", A485CajAbr);
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A487CajSts = 0;
         AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         Z486CajDsc = "";
         Z485CajAbr = "";
         Z487CajSts = 0;
         Z91CueCod = "";
      }

      protected void InitAll52169( )
      {
         A358CajCod = 0;
         AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         InitializeNonKey52169( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254574", true, true);
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
         context.AddJavascriptSource("tscajachica.js", "?202281810254574", false, true);
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
         edtCajCod_Internalname = "CAJCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCajDsc_Internalname = "CAJDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCajAbr_Internalname = "CAJABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbCajSts_Internalname = "CAJSTS";
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
         cmbCajSts_Jsonclick = "";
         cmbCajSts.Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtCajAbr_Jsonclick = "";
         edtCajAbr_Enabled = 1;
         edtCajDsc_Jsonclick = "";
         edtCajDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCajCod_Jsonclick = "";
         edtCajCod_Enabled = 1;
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
         cmbCajSts.Name = "CAJSTS";
         cmbCajSts.WebTags = "";
         cmbCajSts.addItem("1", "ACTIVO", 0);
         cmbCajSts.addItem("0", "INACTIVO", 0);
         if ( cmbCajSts.ItemCount > 0 )
         {
            A487CajSts = (short)(NumberUtil.Val( cmbCajSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0))), "."));
            AssignAttri("", false, "A487CajSts", StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCajDsc_Internalname;
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

      public void Valid_Cajcod( )
      {
         A487CajSts = (short)(NumberUtil.Val( cmbCajSts.CurrentValue, "."));
         cmbCajSts.CurrentValue = StringUtil.Str( (decimal)(A487CajSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbCajSts.ItemCount > 0 )
         {
            A487CajSts = (short)(NumberUtil.Val( cmbCajSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0))), "."));
            cmbCajSts.CurrentValue = StringUtil.Str( (decimal)(A487CajSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A486CajDsc", StringUtil.RTrim( A486CajDsc));
         AssignAttri("", false, "A485CajAbr", StringUtil.RTrim( A485CajAbr));
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A487CajSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A487CajSts), 1, 0, ".", "")));
         cmbCajSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A487CajSts), 1, 0));
         AssignProp("", false, cmbCajSts_Internalname, "Values", cmbCajSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z486CajDsc", StringUtil.RTrim( Z486CajDsc));
         GxWebStd.gx_hidden_field( context, "Z485CajAbr", StringUtil.RTrim( Z485CajAbr));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z487CajSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487CajSts), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T005216 */
         pr_default.execute(14, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(14);
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
         setEventMetadata("VALID_CAJCOD","{handler:'Valid_Cajcod',iparms:[{av:'cmbCajSts'},{av:'A487CajSts',fld:'CAJSTS',pic:'9'},{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CAJCOD",",oparms:[{av:'A486CajDsc',fld:'CAJDSC',pic:''},{av:'A485CajAbr',fld:'CAJABR',pic:''},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'cmbCajSts'},{av:'A487CajSts',fld:'CAJSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z358CajCod'},{av:'Z486CajDsc'},{av:'Z485CajAbr'},{av:'Z91CueCod'},{av:'Z487CajSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z486CajDsc = "";
         Z485CajAbr = "";
         Z91CueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A91CueCod = "";
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
         A486CajDsc = "";
         lblTextblock3_Jsonclick = "";
         A485CajAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
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
         T00525_A358CajCod = new int[1] ;
         T00525_A486CajDsc = new string[] {""} ;
         T00525_A485CajAbr = new string[] {""} ;
         T00525_A487CajSts = new short[1] ;
         T00525_A91CueCod = new string[] {""} ;
         T00524_A91CueCod = new string[] {""} ;
         T00526_A91CueCod = new string[] {""} ;
         T00527_A358CajCod = new int[1] ;
         T00523_A358CajCod = new int[1] ;
         T00523_A486CajDsc = new string[] {""} ;
         T00523_A485CajAbr = new string[] {""} ;
         T00523_A487CajSts = new short[1] ;
         T00523_A91CueCod = new string[] {""} ;
         sMode169 = "";
         T00528_A358CajCod = new int[1] ;
         T00529_A358CajCod = new int[1] ;
         T00522_A358CajCod = new int[1] ;
         T00522_A486CajDsc = new string[] {""} ;
         T00522_A485CajAbr = new string[] {""} ;
         T00522_A487CajSts = new short[1] ;
         T00522_A91CueCod = new string[] {""} ;
         T005213_A358CajCod = new int[1] ;
         T005213_A391MVLCajCod = new string[] {""} ;
         T005213_A392MVLITem = new int[1] ;
         T005214_A358CajCod = new int[1] ;
         T005214_A359AperCajCod = new string[] {""} ;
         T005215_A358CajCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ486CajDsc = "";
         ZZ485CajAbr = "";
         ZZ91CueCod = "";
         T005216_A91CueCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tscajachica__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tscajachica__default(),
            new Object[][] {
                new Object[] {
               T00522_A358CajCod, T00522_A486CajDsc, T00522_A485CajAbr, T00522_A487CajSts, T00522_A91CueCod
               }
               , new Object[] {
               T00523_A358CajCod, T00523_A486CajDsc, T00523_A485CajAbr, T00523_A487CajSts, T00523_A91CueCod
               }
               , new Object[] {
               T00524_A91CueCod
               }
               , new Object[] {
               T00525_A358CajCod, T00525_A486CajDsc, T00525_A485CajAbr, T00525_A487CajSts, T00525_A91CueCod
               }
               , new Object[] {
               T00526_A91CueCod
               }
               , new Object[] {
               T00527_A358CajCod
               }
               , new Object[] {
               T00528_A358CajCod
               }
               , new Object[] {
               T00529_A358CajCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005213_A358CajCod, T005213_A391MVLCajCod, T005213_A392MVLITem
               }
               , new Object[] {
               T005214_A358CajCod, T005214_A359AperCajCod
               }
               , new Object[] {
               T005215_A358CajCod
               }
               , new Object[] {
               T005216_A91CueCod
               }
            }
         );
      }

      private short Z487CajSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A487CajSts ;
      private short GX_JID ;
      private short RcdFound169 ;
      private short nIsDirty_169 ;
      private short Gx_BScreen ;
      private short ZZ487CajSts ;
      private int Z358CajCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A358CajCod ;
      private int edtCajCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCajDsc_Enabled ;
      private int edtCajAbr_Enabled ;
      private int edtCueCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ358CajCod ;
      private string sPrefix ;
      private string Z486CajDsc ;
      private string Z485CajAbr ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCajCod_Internalname ;
      private string cmbCajSts_Internalname ;
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
      private string edtCajCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCajDsc_Internalname ;
      private string A486CajDsc ;
      private string edtCajDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCajAbr_Internalname ;
      private string A485CajAbr ;
      private string edtCajAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbCajSts_Jsonclick ;
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
      private string sMode169 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ486CajDsc ;
      private string ZZ485CajAbr ;
      private string ZZ91CueCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCajSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00525_A358CajCod ;
      private string[] T00525_A486CajDsc ;
      private string[] T00525_A485CajAbr ;
      private short[] T00525_A487CajSts ;
      private string[] T00525_A91CueCod ;
      private string[] T00524_A91CueCod ;
      private string[] T00526_A91CueCod ;
      private int[] T00527_A358CajCod ;
      private int[] T00523_A358CajCod ;
      private string[] T00523_A486CajDsc ;
      private string[] T00523_A485CajAbr ;
      private short[] T00523_A487CajSts ;
      private string[] T00523_A91CueCod ;
      private int[] T00528_A358CajCod ;
      private int[] T00529_A358CajCod ;
      private int[] T00522_A358CajCod ;
      private string[] T00522_A486CajDsc ;
      private string[] T00522_A485CajAbr ;
      private short[] T00522_A487CajSts ;
      private string[] T00522_A91CueCod ;
      private int[] T005213_A358CajCod ;
      private string[] T005213_A391MVLCajCod ;
      private int[] T005213_A392MVLITem ;
      private int[] T005214_A358CajCod ;
      private string[] T005214_A359AperCajCod ;
      private int[] T005215_A358CajCod ;
      private string[] T005216_A91CueCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tscajachica__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tscajachica__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
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
        Object[] prmT00525;
        prmT00525 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT00524;
        prmT00524 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00526;
        prmT00526 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00527;
        prmT00527 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT00523;
        prmT00523 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT00528;
        prmT00528 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT00529;
        prmT00529 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT00522;
        prmT00522 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005210;
        prmT005210 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@CajDsc",GXType.NChar,100,0) ,
        new ParDef("@CajAbr",GXType.NChar,5,0) ,
        new ParDef("@CajSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT005211;
        prmT005211 = new Object[] {
        new ParDef("@CajDsc",GXType.NChar,100,0) ,
        new ParDef("@CajAbr",GXType.NChar,5,0) ,
        new ParDef("@CajSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005212;
        prmT005212 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005213;
        prmT005213 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005214;
        prmT005214 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005215;
        prmT005215 = new Object[] {
        };
        Object[] prmT005216;
        prmT005216 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00522", "SELECT [CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod] FROM [TSCAJACHICA] WITH (UPDLOCK) WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00522,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00523", "SELECT [CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00523,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00524", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00524,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00525", "SELECT TM1.[CajCod], TM1.[CajDsc], TM1.[CajAbr], TM1.[CajSts], TM1.[CueCod] FROM [TSCAJACHICA] TM1 WHERE TM1.[CajCod] = @CajCod ORDER BY TM1.[CajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00525,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00526", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00526,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00527", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00527,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00528", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE ( [CajCod] > @CajCod) ORDER BY [CajCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00528,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00529", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE ( [CajCod] < @CajCod) ORDER BY [CajCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00529,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005210", "INSERT INTO [TSCAJACHICA]([CajCod], [CajDsc], [CajAbr], [CajSts], [CueCod]) VALUES(@CajCod, @CajDsc, @CajAbr, @CajSts, @CueCod)", GxErrorMask.GX_NOMASK,prmT005210)
           ,new CursorDef("T005211", "UPDATE [TSCAJACHICA] SET [CajDsc]=@CajDsc, [CajAbr]=@CajAbr, [CajSts]=@CajSts, [CueCod]=@CueCod  WHERE [CajCod] = @CajCod", GxErrorMask.GX_NOMASK,prmT005211)
           ,new CursorDef("T005212", "DELETE FROM [TSCAJACHICA]  WHERE [CajCod] = @CajCod", GxErrorMask.GX_NOMASK,prmT005212)
           ,new CursorDef("T005213", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005213,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005214", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005214,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005215", "SELECT [CajCod] FROM [TSCAJACHICA] ORDER BY [CajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005215,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005216", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005216,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
