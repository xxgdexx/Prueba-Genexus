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
   public class cbcomprasconc : GXDataArea
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
            A77CConpCueCod = GetPar( "CConpCueCod");
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A77CConpCueCod) ;
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
            Form.Meta.addItem("description", "Conceptos de Compras", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbcomprasconc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbcomprasconc( IGxContext context )
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
         cmbCConpSts = new GXCombobox();
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
         if ( cmbCConpSts.ItemCount > 0 )
         {
            A517CConpSts = (short)(NumberUtil.Val( cmbCConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0))), "."));
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            AssignProp("", false, cmbCConpSts_Internalname, "Values", cmbCConpSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBCOMPRASCONC.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Concepto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76CConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A76CConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A76CConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Concepto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpDsc_Internalname, StringUtil.RTrim( A78CConpDsc), StringUtil.RTrim( context.localUtil.Format( A78CConpDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cuenta Contable", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCConpCueCod_Internalname, StringUtil.RTrim( A77CConpCueCod), StringUtil.RTrim( context.localUtil.Format( A77CConpCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCConpCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cuenta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCConpCueDsc_Internalname, StringUtil.RTrim( A516CConpCueDsc), StringUtil.RTrim( context.localUtil.Format( A516CConpCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCConpCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCConpCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Estado", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCOMPRASCONC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCConpSts, cmbCConpSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0)), 1, cmbCConpSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCConpSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CBCOMPRASCONC.htm");
         cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         AssignProp("", false, cmbCConpSts_Internalname, "Values", (string)(cmbCConpSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCOMPRASCONC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBCOMPRASCONC.htm");
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
            Z76CConpCod = (int)(context.localUtil.CToN( cgiGet( "Z76CConpCod"), ".", ","));
            Z78CConpDsc = cgiGet( "Z78CConpDsc");
            Z517CConpSts = (short)(context.localUtil.CToN( cgiGet( "Z517CConpSts"), ".", ","));
            Z77CConpCueCod = cgiGet( "Z77CConpCueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtCConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A76CConpCod = 0;
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            }
            else
            {
               A76CConpCod = (int)(context.localUtil.CToN( cgiGet( edtCConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            }
            A78CConpDsc = cgiGet( edtCConpDsc_Internalname);
            AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
            A77CConpCueCod = cgiGet( edtCConpCueCod_Internalname);
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            A516CConpCueDsc = cgiGet( edtCConpCueDsc_Internalname);
            AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
            cmbCConpSts.CurrentValue = cgiGet( cmbCConpSts_Internalname);
            A517CConpSts = (short)(NumberUtil.Val( cgiGet( cmbCConpSts_Internalname), "."));
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
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
               A76CConpCod = (int)(NumberUtil.Val( GetPar( "CConpCod"), "."));
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
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
               InitAll1O57( ) ;
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
         DisableAttributes1O57( ) ;
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

      protected void CONFIRM_1O0( )
      {
         BeforeValidate1O57( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1O57( ) ;
            }
            else
            {
               CheckExtendedTable1O57( ) ;
               if ( AnyError == 0 )
               {
                  ZM1O57( 2) ;
               }
               CloseExtendedTableCursors1O57( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1O0( ) ;
         }
      }

      protected void ResetCaption1O0( )
      {
      }

      protected void ZM1O57( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z78CConpDsc = T001O3_A78CConpDsc[0];
               Z517CConpSts = T001O3_A517CConpSts[0];
               Z77CConpCueCod = T001O3_A77CConpCueCod[0];
            }
            else
            {
               Z78CConpDsc = A78CConpDsc;
               Z517CConpSts = A517CConpSts;
               Z77CConpCueCod = A77CConpCueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z76CConpCod = A76CConpCod;
            Z78CConpDsc = A78CConpDsc;
            Z517CConpSts = A517CConpSts;
            Z77CConpCueCod = A77CConpCueCod;
            Z516CConpCueDsc = A516CConpCueDsc;
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

      protected void Load1O57( )
      {
         /* Using cursor T001O5 */
         pr_default.execute(3, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound57 = 1;
            A78CConpDsc = T001O5_A78CConpDsc[0];
            AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
            A516CConpCueDsc = T001O5_A516CConpCueDsc[0];
            AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
            A517CConpSts = T001O5_A517CConpSts[0];
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            A77CConpCueCod = T001O5_A77CConpCueCod[0];
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            ZM1O57( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1O57( ) ;
      }

      protected void OnLoadActions1O57( )
      {
      }

      protected void CheckExtendedTable1O57( )
      {
         nIsDirty_57 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001O4 */
         pr_default.execute(2, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A516CConpCueDsc = T001O4_A516CConpCueDsc[0];
         AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1O57( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A77CConpCueCod )
      {
         /* Using cursor T001O6 */
         pr_default.execute(4, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A516CConpCueDsc = T001O6_A516CConpCueDsc[0];
         AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A516CConpCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1O57( )
      {
         /* Using cursor T001O7 */
         pr_default.execute(5, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound57 = 1;
         }
         else
         {
            RcdFound57 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001O3 */
         pr_default.execute(1, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1O57( 1) ;
            RcdFound57 = 1;
            A76CConpCod = T001O3_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            A78CConpDsc = T001O3_A78CConpDsc[0];
            AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
            A517CConpSts = T001O3_A517CConpSts[0];
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
            A77CConpCueCod = T001O3_A77CConpCueCod[0];
            AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
            Z76CConpCod = A76CConpCod;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1O57( ) ;
            if ( AnyError == 1 )
            {
               RcdFound57 = 0;
               InitializeNonKey1O57( ) ;
            }
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound57 = 0;
            InitializeNonKey1O57( ) ;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode57;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1O57( ) ;
         if ( RcdFound57 == 0 )
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
         RcdFound57 = 0;
         /* Using cursor T001O8 */
         pr_default.execute(6, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001O8_A76CConpCod[0] < A76CConpCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001O8_A76CConpCod[0] > A76CConpCod ) ) )
            {
               A76CConpCod = T001O8_A76CConpCod[0];
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound57 = 0;
         /* Using cursor T001O9 */
         pr_default.execute(7, new Object[] {A76CConpCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001O9_A76CConpCod[0] > A76CConpCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001O9_A76CConpCod[0] < A76CConpCod ) ) )
            {
               A76CConpCod = T001O9_A76CConpCod[0];
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               RcdFound57 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1O57( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1O57( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound57 == 1 )
            {
               if ( A76CConpCod != Z76CConpCod )
               {
                  A76CConpCod = Z76CConpCod;
                  AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CCONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1O57( ) ;
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A76CConpCod != Z76CConpCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCConpCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1O57( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCONPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCConpCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCConpCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1O57( ) ;
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
         if ( A76CConpCod != Z76CConpCod )
         {
            A76CConpCod = Z76CConpCod;
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCConpCod_Internalname;
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
         GetKey1O57( ) ;
         if ( RcdFound57 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtCConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A76CConpCod != Z76CConpCod )
            {
               A76CConpCod = Z76CConpCod;
               AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtCConpCod_Internalname;
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
            if ( A76CConpCod != Z76CConpCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCConpCod_Internalname;
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
         context.RollbackDataStores("cbcomprasconc",pr_default);
         GX_FocusControl = edtCConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1O0( ) ;
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
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1O57( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1O57( ) ;
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
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCConpDsc_Internalname;
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
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCConpDsc_Internalname;
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
         ScanStart1O57( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound57 != 0 )
            {
               ScanNext1O57( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1O57( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1O57( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001O2 */
            pr_default.execute(0, new Object[] {A76CConpCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOMPRASCONC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z78CConpDsc, T001O2_A78CConpDsc[0]) != 0 ) || ( Z517CConpSts != T001O2_A517CConpSts[0] ) || ( StringUtil.StrCmp(Z77CConpCueCod, T001O2_A77CConpCueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z78CConpDsc, T001O2_A78CConpDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcomprasconc:[seudo value changed for attri]"+"CConpDsc");
                  GXUtil.WriteLogRaw("Old: ",Z78CConpDsc);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A78CConpDsc[0]);
               }
               if ( Z517CConpSts != T001O2_A517CConpSts[0] )
               {
                  GXUtil.WriteLog("cbcomprasconc:[seudo value changed for attri]"+"CConpSts");
                  GXUtil.WriteLogRaw("Old: ",Z517CConpSts);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A517CConpSts[0]);
               }
               if ( StringUtil.StrCmp(Z77CConpCueCod, T001O2_A77CConpCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcomprasconc:[seudo value changed for attri]"+"CConpCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z77CConpCueCod);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A77CConpCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCOMPRASCONC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O57( )
      {
         BeforeValidate1O57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O57( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O57( 0) ;
            CheckOptimisticConcurrency1O57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O10 */
                     pr_default.execute(8, new Object[] {A76CConpCod, A78CConpDsc, A517CConpSts, A77CConpCueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
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
                           ResetCaption1O0( ) ;
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
               Load1O57( ) ;
            }
            EndLevel1O57( ) ;
         }
         CloseExtendedTableCursors1O57( ) ;
      }

      protected void Update1O57( )
      {
         BeforeValidate1O57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O57( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1O57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O11 */
                     pr_default.execute(9, new Object[] {A78CConpDsc, A517CConpSts, A77CConpCueCod, A76CConpCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCOMPRASCONC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1O57( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1O0( ) ;
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
            EndLevel1O57( ) ;
         }
         CloseExtendedTableCursors1O57( ) ;
      }

      protected void DeferredUpdate1O57( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1O57( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O57( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O57( ) ;
            AfterConfirm1O57( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O57( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001O12 */
                  pr_default.execute(10, new Object[] {A76CConpCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCOMPRASCONC");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound57 == 0 )
                        {
                           InitAll1O57( ) ;
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
                        ResetCaption1O0( ) ;
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
         sMode57 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1O57( ) ;
         Gx_mode = sMode57;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1O57( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001O13 */
            pr_default.execute(11, new Object[] {A77CConpCueCod});
            A516CConpCueDsc = T001O13_A516CConpCueDsc[0];
            AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
            pr_default.close(11);
         }
      }

      protected void EndLevel1O57( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1O57( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("cbcomprasconc",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("cbcomprasconc",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1O57( )
      {
         /* Using cursor T001O14 */
         pr_default.execute(12);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound57 = 1;
            A76CConpCod = T001O14_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1O57( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound57 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound57 = 1;
            A76CConpCod = T001O14_A76CConpCod[0];
            AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         }
      }

      protected void ScanEnd1O57( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1O57( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O57( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O57( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O57( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O57( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O57( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O57( )
      {
         edtCConpCod_Enabled = 0;
         AssignProp("", false, edtCConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCod_Enabled), 5, 0), true);
         edtCConpDsc_Enabled = 0;
         AssignProp("", false, edtCConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpDsc_Enabled), 5, 0), true);
         edtCConpCueCod_Enabled = 0;
         AssignProp("", false, edtCConpCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCueCod_Enabled), 5, 0), true);
         edtCConpCueDsc_Enabled = 0;
         AssignProp("", false, edtCConpCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCConpCueDsc_Enabled), 5, 0), true);
         cmbCConpSts.Enabled = 0;
         AssignProp("", false, cmbCConpSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCConpSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1O57( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1O0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181024559", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbcomprasconc.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z76CConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76CConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z78CConpDsc", StringUtil.RTrim( Z78CConpDsc));
         GxWebStd.gx_hidden_field( context, "Z517CConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z517CConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z77CConpCueCod", StringUtil.RTrim( Z77CConpCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("cbcomprasconc.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBCOMPRASCONC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Compras" ;
      }

      protected void InitializeNonKey1O57( )
      {
         A78CConpDsc = "";
         AssignAttri("", false, "A78CConpDsc", A78CConpDsc);
         A77CConpCueCod = "";
         AssignAttri("", false, "A77CConpCueCod", A77CConpCueCod);
         A516CConpCueDsc = "";
         AssignAttri("", false, "A516CConpCueDsc", A516CConpCueDsc);
         A517CConpSts = 0;
         AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         Z78CConpDsc = "";
         Z517CConpSts = 0;
         Z77CConpCueCod = "";
      }

      protected void InitAll1O57( )
      {
         A76CConpCod = 0;
         AssignAttri("", false, "A76CConpCod", StringUtil.LTrimStr( (decimal)(A76CConpCod), 6, 0));
         InitializeNonKey1O57( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024565", true, true);
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
         context.AddJavascriptSource("cbcomprasconc.js", "?20228181024565", false, true);
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
         edtCConpCod_Internalname = "CCONPCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCConpDsc_Internalname = "CCONPDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCConpCueCod_Internalname = "CCONPCUECOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCConpCueDsc_Internalname = "CCONPCUEDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbCConpSts_Internalname = "CCONPSTS";
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
         Form.Caption = "Conceptos de Compras";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbCConpSts_Jsonclick = "";
         cmbCConpSts.Enabled = 1;
         edtCConpCueDsc_Jsonclick = "";
         edtCConpCueDsc_Enabled = 0;
         edtCConpCueCod_Jsonclick = "";
         edtCConpCueCod_Enabled = 1;
         edtCConpDsc_Jsonclick = "";
         edtCConpDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCConpCod_Jsonclick = "";
         edtCConpCod_Enabled = 1;
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
         cmbCConpSts.Name = "CCONPSTS";
         cmbCConpSts.WebTags = "";
         cmbCConpSts.addItem("1", "ACTIVO", 0);
         cmbCConpSts.addItem("0", "INACTIVO", 0);
         if ( cmbCConpSts.ItemCount > 0 )
         {
            A517CConpSts = (short)(NumberUtil.Val( cmbCConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0))), "."));
            AssignAttri("", false, "A517CConpSts", StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCConpDsc_Internalname;
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

      public void Valid_Cconpcod( )
      {
         A517CConpSts = (short)(NumberUtil.Val( cmbCConpSts.CurrentValue, "."));
         cmbCConpSts.CurrentValue = StringUtil.Str( (decimal)(A517CConpSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbCConpSts.ItemCount > 0 )
         {
            A517CConpSts = (short)(NumberUtil.Val( cmbCConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0))), "."));
            cmbCConpSts.CurrentValue = StringUtil.Str( (decimal)(A517CConpSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A78CConpDsc", StringUtil.RTrim( A78CConpDsc));
         AssignAttri("", false, "A77CConpCueCod", StringUtil.RTrim( A77CConpCueCod));
         AssignAttri("", false, "A517CConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A517CConpSts), 1, 0, ".", "")));
         cmbCConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A517CConpSts), 1, 0));
         AssignProp("", false, cmbCConpSts_Internalname, "Values", cmbCConpSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A516CConpCueDsc", StringUtil.RTrim( A516CConpCueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z76CConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76CConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z78CConpDsc", StringUtil.RTrim( Z78CConpDsc));
         GxWebStd.gx_hidden_field( context, "Z77CConpCueCod", StringUtil.RTrim( Z77CConpCueCod));
         GxWebStd.gx_hidden_field( context, "Z517CConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z517CConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z516CConpCueDsc", StringUtil.RTrim( Z516CConpCueDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cconpcuecod( )
      {
         /* Using cursor T001O13 */
         pr_default.execute(11, new Object[] {A77CConpCueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CCONPCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCConpCueCod_Internalname;
         }
         A516CConpCueDsc = T001O13_A516CConpCueDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A516CConpCueDsc", StringUtil.RTrim( A516CConpCueDsc));
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
         setEventMetadata("VALID_CCONPCOD","{handler:'Valid_Cconpcod',iparms:[{av:'cmbCConpSts'},{av:'A517CConpSts',fld:'CCONPSTS',pic:'9'},{av:'A76CConpCod',fld:'CCONPCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CCONPCOD",",oparms:[{av:'A78CConpDsc',fld:'CCONPDSC',pic:''},{av:'A77CConpCueCod',fld:'CCONPCUECOD',pic:''},{av:'cmbCConpSts'},{av:'A517CConpSts',fld:'CCONPSTS',pic:'9'},{av:'A516CConpCueDsc',fld:'CCONPCUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z76CConpCod'},{av:'Z78CConpDsc'},{av:'Z77CConpCueCod'},{av:'Z517CConpSts'},{av:'Z516CConpCueDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CCONPCUECOD","{handler:'Valid_Cconpcuecod',iparms:[{av:'A77CConpCueCod',fld:'CCONPCUECOD',pic:''},{av:'A516CConpCueDsc',fld:'CCONPCUEDSC',pic:''}]");
         setEventMetadata("VALID_CCONPCUECOD",",oparms:[{av:'A516CConpCueDsc',fld:'CCONPCUEDSC',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z78CConpDsc = "";
         Z77CConpCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A77CConpCueCod = "";
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
         A78CConpDsc = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A516CConpCueDsc = "";
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
         Z516CConpCueDsc = "";
         T001O5_A76CConpCod = new int[1] ;
         T001O5_A78CConpDsc = new string[] {""} ;
         T001O5_A516CConpCueDsc = new string[] {""} ;
         T001O5_A517CConpSts = new short[1] ;
         T001O5_A77CConpCueCod = new string[] {""} ;
         T001O4_A516CConpCueDsc = new string[] {""} ;
         T001O6_A516CConpCueDsc = new string[] {""} ;
         T001O7_A76CConpCod = new int[1] ;
         T001O3_A76CConpCod = new int[1] ;
         T001O3_A78CConpDsc = new string[] {""} ;
         T001O3_A517CConpSts = new short[1] ;
         T001O3_A77CConpCueCod = new string[] {""} ;
         sMode57 = "";
         T001O8_A76CConpCod = new int[1] ;
         T001O9_A76CConpCod = new int[1] ;
         T001O2_A76CConpCod = new int[1] ;
         T001O2_A78CConpDsc = new string[] {""} ;
         T001O2_A517CConpSts = new short[1] ;
         T001O2_A77CConpCueCod = new string[] {""} ;
         T001O13_A516CConpCueDsc = new string[] {""} ;
         T001O14_A76CConpCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ78CConpDsc = "";
         ZZ77CConpCueCod = "";
         ZZ516CConpCueDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbcomprasconc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbcomprasconc__default(),
            new Object[][] {
                new Object[] {
               T001O2_A76CConpCod, T001O2_A78CConpDsc, T001O2_A517CConpSts, T001O2_A77CConpCueCod
               }
               , new Object[] {
               T001O3_A76CConpCod, T001O3_A78CConpDsc, T001O3_A517CConpSts, T001O3_A77CConpCueCod
               }
               , new Object[] {
               T001O4_A516CConpCueDsc
               }
               , new Object[] {
               T001O5_A76CConpCod, T001O5_A78CConpDsc, T001O5_A516CConpCueDsc, T001O5_A517CConpSts, T001O5_A77CConpCueCod
               }
               , new Object[] {
               T001O6_A516CConpCueDsc
               }
               , new Object[] {
               T001O7_A76CConpCod
               }
               , new Object[] {
               T001O8_A76CConpCod
               }
               , new Object[] {
               T001O9_A76CConpCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001O13_A516CConpCueDsc
               }
               , new Object[] {
               T001O14_A76CConpCod
               }
            }
         );
      }

      private short Z517CConpSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A517CConpSts ;
      private short GX_JID ;
      private short RcdFound57 ;
      private short nIsDirty_57 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ517CConpSts ;
      private int Z76CConpCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A76CConpCod ;
      private int edtCConpCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCConpDsc_Enabled ;
      private int edtCConpCueCod_Enabled ;
      private int edtCConpCueDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ76CConpCod ;
      private string sPrefix ;
      private string Z78CConpDsc ;
      private string Z77CConpCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A77CConpCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCConpCod_Internalname ;
      private string cmbCConpSts_Internalname ;
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
      private string edtCConpCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCConpDsc_Internalname ;
      private string A78CConpDsc ;
      private string edtCConpDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCConpCueCod_Internalname ;
      private string edtCConpCueCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCConpCueDsc_Internalname ;
      private string A516CConpCueDsc ;
      private string edtCConpCueDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbCConpSts_Jsonclick ;
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
      private string Z516CConpCueDsc ;
      private string sMode57 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ78CConpDsc ;
      private string ZZ77CConpCueCod ;
      private string ZZ516CConpCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCConpSts ;
      private IDataStoreProvider pr_default ;
      private int[] T001O5_A76CConpCod ;
      private string[] T001O5_A78CConpDsc ;
      private string[] T001O5_A516CConpCueDsc ;
      private short[] T001O5_A517CConpSts ;
      private string[] T001O5_A77CConpCueCod ;
      private string[] T001O4_A516CConpCueDsc ;
      private string[] T001O6_A516CConpCueDsc ;
      private int[] T001O7_A76CConpCod ;
      private int[] T001O3_A76CConpCod ;
      private string[] T001O3_A78CConpDsc ;
      private short[] T001O3_A517CConpSts ;
      private string[] T001O3_A77CConpCueCod ;
      private int[] T001O8_A76CConpCod ;
      private int[] T001O9_A76CConpCod ;
      private int[] T001O2_A76CConpCod ;
      private string[] T001O2_A78CConpDsc ;
      private short[] T001O2_A517CConpSts ;
      private string[] T001O2_A77CConpCueCod ;
      private string[] T001O13_A516CConpCueDsc ;
      private int[] T001O14_A76CConpCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbcomprasconc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbcomprasconc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001O5;
        prmT001O5 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O4;
        prmT001O4 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001O6;
        prmT001O6 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001O7;
        prmT001O7 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O3;
        prmT001O3 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O8;
        prmT001O8 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O9;
        prmT001O9 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O2;
        prmT001O2 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O10;
        prmT001O10 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0) ,
        new ParDef("@CConpDsc",GXType.NChar,100,0) ,
        new ParDef("@CConpSts",GXType.Int16,1,0) ,
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001O11;
        prmT001O11 = new Object[] {
        new ParDef("@CConpDsc",GXType.NChar,100,0) ,
        new ParDef("@CConpSts",GXType.Int16,1,0) ,
        new ParDef("@CConpCueCod",GXType.NChar,15,0) ,
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O12;
        prmT001O12 = new Object[] {
        new ParDef("@CConpCod",GXType.Int32,6,0)
        };
        Object[] prmT001O14;
        prmT001O14 = new Object[] {
        };
        Object[] prmT001O13;
        prmT001O13 = new Object[] {
        new ParDef("@CConpCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001O2", "SELECT [CConpCod], [CConpDsc], [CConpSts], [CConpCueCod] AS CConpCueCod FROM [CBCOMPRASCONC] WITH (UPDLOCK) WHERE [CConpCod] = @CConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O3", "SELECT [CConpCod], [CConpDsc], [CConpSts], [CConpCueCod] AS CConpCueCod FROM [CBCOMPRASCONC] WHERE [CConpCod] = @CConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O4", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O5", "SELECT TM1.[CConpCod], TM1.[CConpDsc], T2.[CueDsc] AS CConpCueDsc, TM1.[CConpSts], TM1.[CConpCueCod] AS CConpCueCod FROM ([CBCOMPRASCONC] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CConpCueCod]) WHERE TM1.[CConpCod] = @CConpCod ORDER BY TM1.[CConpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O6", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O7", "SELECT [CConpCod] FROM [CBCOMPRASCONC] WHERE [CConpCod] = @CConpCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O8", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE ( [CConpCod] > @CConpCod) ORDER BY [CConpCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001O9", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE ( [CConpCod] < @CConpCod) ORDER BY [CConpCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001O10", "INSERT INTO [CBCOMPRASCONC]([CConpCod], [CConpDsc], [CConpSts], [CConpCueCod]) VALUES(@CConpCod, @CConpDsc, @CConpSts, @CConpCueCod)", GxErrorMask.GX_NOMASK,prmT001O10)
           ,new CursorDef("T001O11", "UPDATE [CBCOMPRASCONC] SET [CConpDsc]=@CConpDsc, [CConpSts]=@CConpSts, [CConpCueCod]=@CConpCueCod  WHERE [CConpCod] = @CConpCod", GxErrorMask.GX_NOMASK,prmT001O11)
           ,new CursorDef("T001O12", "DELETE FROM [CBCOMPRASCONC]  WHERE [CConpCod] = @CConpCod", GxErrorMask.GX_NOMASK,prmT001O12)
           ,new CursorDef("T001O13", "SELECT [CueDsc] AS CConpCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CConpCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O14", "SELECT [CConpCod] FROM [CBCOMPRASCONC] ORDER BY [CConpCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O14,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
