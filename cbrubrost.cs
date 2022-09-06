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
   public class cbrubrost : GXHttpHandler
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
            Form.Meta.addItem("description", "Rubros Totales", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbrubrost( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbrubrost( IGxContext context )
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
         cmbTotSts = new GXCombobox();
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
         if ( cmbTotSts.ItemCount > 0 )
         {
            A1930TotSts = (short)(NumberUtil.Val( cmbTotSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0))), "."));
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            AssignProp("", false, cmbTotSts_Internalname, "Values", cmbTotSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm1Z68( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBRUBROST.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Reporte", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotTipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Rubro Totales", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotRub_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")), StringUtil.LTrim( ((edtTotRub_Enabled!=0) ? context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9") : context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotRub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotRub_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Titulo de Totales", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotDsc_Internalname, StringUtil.RTrim( A1928TotDsc), StringUtil.RTrim( context.localUtil.Format( A1928TotDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Totales", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotDscTot_Internalname, StringUtil.RTrim( A1929TotDscTot), StringUtil.RTrim( context.localUtil.Format( A1929TotDscTot, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotDscTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotDscTot_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Orden", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A120TotOrd), 2, 0, ".", "")), StringUtil.LTrim( ((edtTotOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A120TotOrd), "Z9") : context.localUtil.Format( (decimal)(A120TotOrd), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotOrd_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Estado", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROST.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTotSts, cmbTotSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0)), 1, cmbTotSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTotSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 1, "HLP_CBRUBROST.htm");
         cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         AssignProp("", false, cmbTotSts_Internalname, "Values", (string)(cmbTotSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROST.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBRUBROST.htm");
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
            Z114TotTipo = cgiGet( "Z114TotTipo");
            Z115TotRub = (int)(context.localUtil.CToN( cgiGet( "Z115TotRub"), ".", ","));
            Z1928TotDsc = cgiGet( "Z1928TotDsc");
            Z1929TotDscTot = cgiGet( "Z1929TotDscTot");
            Z120TotOrd = (short)(context.localUtil.CToN( cgiGet( "Z120TotOrd"), ".", ","));
            Z1930TotSts = (short)(context.localUtil.CToN( cgiGet( "Z1930TotSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A114TotTipo = cgiGet( edtTotTipo_Internalname);
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTRUB");
               AnyError = 1;
               GX_FocusControl = edtTotRub_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A115TotRub = 0;
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            }
            else
            {
               A115TotRub = (int)(context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ","));
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            }
            A1928TotDsc = cgiGet( edtTotDsc_Internalname);
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1929TotDscTot = cgiGet( edtTotDscTot_Internalname);
            AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTORD");
               AnyError = 1;
               GX_FocusControl = edtTotOrd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A120TotOrd = 0;
               AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            }
            else
            {
               A120TotOrd = (short)(context.localUtil.CToN( cgiGet( edtTotOrd_Internalname), ".", ","));
               AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            }
            cmbTotSts.CurrentValue = cgiGet( cmbTotSts_Internalname);
            A1930TotSts = (short)(NumberUtil.Val( cgiGet( cmbTotSts_Internalname), "."));
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
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
               A114TotTipo = GetPar( "TotTipo");
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
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
               InitAll1Z68( ) ;
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
         DisableAttributes1Z68( ) ;
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

      protected void CONFIRM_1Z0( )
      {
         BeforeValidate1Z68( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Z68( ) ;
            }
            else
            {
               CheckExtendedTable1Z68( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1Z68( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1Z0( ) ;
         }
      }

      protected void ResetCaption1Z0( )
      {
      }

      protected void ZM1Z68( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1928TotDsc = T001Z3_A1928TotDsc[0];
               Z1929TotDscTot = T001Z3_A1929TotDscTot[0];
               Z120TotOrd = T001Z3_A120TotOrd[0];
               Z1930TotSts = T001Z3_A1930TotSts[0];
            }
            else
            {
               Z1928TotDsc = A1928TotDsc;
               Z1929TotDscTot = A1929TotDscTot;
               Z120TotOrd = A120TotOrd;
               Z1930TotSts = A1930TotSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z1928TotDsc = A1928TotDsc;
            Z1929TotDscTot = A1929TotDscTot;
            Z120TotOrd = A120TotOrd;
            Z1930TotSts = A1930TotSts;
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

      protected void Load1Z68( )
      {
         /* Using cursor T001Z4 */
         pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound68 = 1;
            A1928TotDsc = T001Z4_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1929TotDscTot = T001Z4_A1929TotDscTot[0];
            AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
            A120TotOrd = T001Z4_A120TotOrd[0];
            AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            A1930TotSts = T001Z4_A1930TotSts[0];
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            ZM1Z68( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1Z68( ) ;
      }

      protected void OnLoadActions1Z68( )
      {
      }

      protected void CheckExtendedTable1Z68( )
      {
         nIsDirty_68 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1Z68( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Z68( )
      {
         /* Using cursor T001Z5 */
         pr_default.execute(3, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Z3 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Z68( 1) ;
            RcdFound68 = 1;
            A114TotTipo = T001Z3_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Z3_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A1928TotDsc = T001Z3_A1928TotDsc[0];
            AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
            A1929TotDscTot = T001Z3_A1929TotDscTot[0];
            AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
            A120TotOrd = T001Z3_A120TotOrd[0];
            AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
            A1930TotSts = T001Z3_A1930TotSts[0];
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Z68( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey1Z68( ) ;
            }
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey1Z68( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode68;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Z68( ) ;
         if ( RcdFound68 == 0 )
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
         RcdFound68 = 0;
         /* Using cursor T001Z6 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001Z6_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001Z6_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Z6_A115TotRub[0] < A115TotRub ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001Z6_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001Z6_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Z6_A115TotRub[0] > A115TotRub ) ) )
            {
               A114TotTipo = T001Z6_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001Z6_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound68 = 0;
         /* Using cursor T001Z7 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001Z7_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001Z7_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Z7_A115TotRub[0] > A115TotRub ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001Z7_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001Z7_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Z7_A115TotRub[0] < A115TotRub ) ) )
            {
               A114TotTipo = T001Z7_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001Z7_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               RcdFound68 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Z68( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Z68( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1Z68( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Z68( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1Z68( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTotTipo_Internalname;
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
         GetKey1Z68( ) ;
         if ( RcdFound68 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TOTTIPO");
               AnyError = 1;
               GX_FocusControl = edtTotTipo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
            {
               A114TotTipo = Z114TotTipo;
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = Z115TotRub;
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TOTTIPO");
               AnyError = 1;
               GX_FocusControl = edtTotTipo_Internalname;
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
            if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtTotTipo_Internalname;
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
         context.RollbackDataStores("cbrubrost",pr_default);
         GX_FocusControl = edtTotDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1Z0( ) ;
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
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTotDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Z68( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTotDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Z68( ) ;
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
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTotDsc_Internalname;
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
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTotDsc_Internalname;
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
         ScanStart1Z68( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound68 != 0 )
            {
               ScanNext1Z68( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTotDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Z68( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Z68( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Z2 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROST"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1928TotDsc, T001Z2_A1928TotDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1929TotDscTot, T001Z2_A1929TotDscTot[0]) != 0 ) || ( Z120TotOrd != T001Z2_A120TotOrd[0] ) || ( Z1930TotSts != T001Z2_A1930TotSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1928TotDsc, T001Z2_A1928TotDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbrubrost:[seudo value changed for attri]"+"TotDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1928TotDsc);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A1928TotDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1929TotDscTot, T001Z2_A1929TotDscTot[0]) != 0 )
               {
                  GXUtil.WriteLog("cbrubrost:[seudo value changed for attri]"+"TotDscTot");
                  GXUtil.WriteLogRaw("Old: ",Z1929TotDscTot);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A1929TotDscTot[0]);
               }
               if ( Z120TotOrd != T001Z2_A120TotOrd[0] )
               {
                  GXUtil.WriteLog("cbrubrost:[seudo value changed for attri]"+"TotOrd");
                  GXUtil.WriteLogRaw("Old: ",Z120TotOrd);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A120TotOrd[0]);
               }
               if ( Z1930TotSts != T001Z2_A1930TotSts[0] )
               {
                  GXUtil.WriteLog("cbrubrost:[seudo value changed for attri]"+"TotSts");
                  GXUtil.WriteLogRaw("Old: ",Z1930TotSts);
                  GXUtil.WriteLogRaw("Current: ",T001Z2_A1930TotSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROST"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Z68( )
      {
         BeforeValidate1Z68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z68( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Z68( 0) ;
            CheckOptimisticConcurrency1Z68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Z68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Z8 */
                     pr_default.execute(6, new Object[] {A114TotTipo, A115TotRub, A1928TotDsc, A1929TotDscTot, A120TotOrd, A1930TotSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
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
                           ResetCaption1Z0( ) ;
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
               Load1Z68( ) ;
            }
            EndLevel1Z68( ) ;
         }
         CloseExtendedTableCursors1Z68( ) ;
      }

      protected void Update1Z68( )
      {
         BeforeValidate1Z68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z68( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Z68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Z9 */
                     pr_default.execute(7, new Object[] {A1928TotDsc, A1929TotDscTot, A120TotOrd, A1930TotSts, A114TotTipo, A115TotRub});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROST"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Z68( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1Z0( ) ;
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
            EndLevel1Z68( ) ;
         }
         CloseExtendedTableCursors1Z68( ) ;
      }

      protected void DeferredUpdate1Z68( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Z68( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z68( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Z68( ) ;
            AfterConfirm1Z68( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Z68( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Z10 */
                  pr_default.execute(8, new Object[] {A114TotTipo, A115TotRub});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROST");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound68 == 0 )
                        {
                           InitAll1Z68( ) ;
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
                        ResetCaption1Z0( ) ;
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Z68( ) ;
         Gx_mode = sMode68;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Z68( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001Z11 */
            pr_default.execute(9, new Object[] {A114TotTipo, A115TotRub});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rubros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1Z68( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Z68( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbrubrost",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbrubrost",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Z68( )
      {
         /* Using cursor T001Z12 */
         pr_default.execute(10);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound68 = 1;
            A114TotTipo = T001Z12_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Z12_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Z68( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound68 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound68 = 1;
            A114TotTipo = T001Z12_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Z12_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         }
      }

      protected void ScanEnd1Z68( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1Z68( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Z68( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Z68( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Z68( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Z68( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Z68( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Z68( )
      {
         edtTotTipo_Enabled = 0;
         AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         edtTotRub_Enabled = 0;
         AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         edtTotDsc_Enabled = 0;
         AssignProp("", false, edtTotDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotDsc_Enabled), 5, 0), true);
         edtTotDscTot_Enabled = 0;
         AssignProp("", false, edtTotDscTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotDscTot_Enabled), 5, 0), true);
         edtTotOrd_Enabled = 0;
         AssignProp("", false, edtTotOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotOrd_Enabled), 5, 0), true);
         cmbTotSts.Enabled = 0;
         AssignProp("", false, cmbTotSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTotSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Z68( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Z0( )
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
         context.SendWebValue( "Rubros Totales") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241713", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbrubrost.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1928TotDsc", StringUtil.RTrim( Z1928TotDsc));
         GxWebStd.gx_hidden_field( context, "Z1929TotDscTot", StringUtil.RTrim( Z1929TotDscTot));
         GxWebStd.gx_hidden_field( context, "Z120TotOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120TotOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1930TotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1930TotSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm1Z68( )
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
         return "CBRUBROST" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros Totales" ;
      }

      protected void InitializeNonKey1Z68( )
      {
         A1928TotDsc = "";
         AssignAttri("", false, "A1928TotDsc", A1928TotDsc);
         A1929TotDscTot = "";
         AssignAttri("", false, "A1929TotDscTot", A1929TotDscTot);
         A120TotOrd = 0;
         AssignAttri("", false, "A120TotOrd", StringUtil.LTrimStr( (decimal)(A120TotOrd), 2, 0));
         A1930TotSts = 0;
         AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         Z1928TotDsc = "";
         Z1929TotDscTot = "";
         Z120TotOrd = 0;
         Z1930TotSts = 0;
      }

      protected void InitAll1Z68( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         InitializeNonKey1Z68( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241718", true, true);
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
         context.AddJavascriptSource("cbrubrost.js", "?202281810241719", false, true);
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
         edtTotTipo_Internalname = "TOTTIPO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTotRub_Internalname = "TOTRUB";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTotDsc_Internalname = "TOTDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTotDscTot_Internalname = "TOTDSCTOT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtTotOrd_Internalname = "TOTORD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         cmbTotSts_Internalname = "TOTSTS";
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
         cmbTotSts_Jsonclick = "";
         cmbTotSts.Enabled = 1;
         edtTotOrd_Jsonclick = "";
         edtTotOrd_Enabled = 1;
         edtTotDscTot_Jsonclick = "";
         edtTotDscTot_Enabled = 1;
         edtTotDsc_Jsonclick = "";
         edtTotDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTotRub_Jsonclick = "";
         edtTotRub_Enabled = 1;
         edtTotTipo_Jsonclick = "";
         edtTotTipo_Enabled = 1;
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
         cmbTotSts.Name = "TOTSTS";
         cmbTotSts.WebTags = "";
         cmbTotSts.addItem("1", "ACTIVO", 0);
         cmbTotSts.addItem("0", "INACTIVO", 0);
         if ( cmbTotSts.ItemCount > 0 )
         {
            A1930TotSts = (short)(NumberUtil.Val( cmbTotSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0))), "."));
            AssignAttri("", false, "A1930TotSts", StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTotDsc_Internalname;
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

      public void Valid_Totrub( )
      {
         A1930TotSts = (short)(NumberUtil.Val( cmbTotSts.CurrentValue, "."));
         cmbTotSts.CurrentValue = StringUtil.Str( (decimal)(A1930TotSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTotSts.ItemCount > 0 )
         {
            A1930TotSts = (short)(NumberUtil.Val( cmbTotSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0))), "."));
            cmbTotSts.CurrentValue = StringUtil.Str( (decimal)(A1930TotSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1928TotDsc", StringUtil.RTrim( A1928TotDsc));
         AssignAttri("", false, "A1929TotDscTot", StringUtil.RTrim( A1929TotDscTot));
         AssignAttri("", false, "A120TotOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A120TotOrd), 2, 0, ".", "")));
         AssignAttri("", false, "A1930TotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1930TotSts), 1, 0, ".", "")));
         cmbTotSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1930TotSts), 1, 0));
         AssignProp("", false, cmbTotSts_Internalname, "Values", cmbTotSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1928TotDsc", StringUtil.RTrim( Z1928TotDsc));
         GxWebStd.gx_hidden_field( context, "Z1929TotDscTot", StringUtil.RTrim( Z1929TotDscTot));
         GxWebStd.gx_hidden_field( context, "Z120TotOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120TotOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1930TotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1930TotSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TOTTIPO","{handler:'Valid_Tottipo',iparms:[]");
         setEventMetadata("VALID_TOTTIPO",",oparms:[]}");
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[{av:'cmbTotSts'},{av:'A1930TotSts',fld:'TOTSTS',pic:'9'},{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TOTRUB",",oparms:[{av:'A1928TotDsc',fld:'TOTDSC',pic:''},{av:'A1929TotDscTot',fld:'TOTDSCTOT',pic:''},{av:'A120TotOrd',fld:'TOTORD',pic:'Z9'},{av:'cmbTotSts'},{av:'A1930TotSts',fld:'TOTSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z114TotTipo'},{av:'Z115TotRub'},{av:'Z1928TotDsc'},{av:'Z1929TotDscTot'},{av:'Z120TotOrd'},{av:'Z1930TotSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z114TotTipo = "";
         Z1928TotDsc = "";
         Z1929TotDscTot = "";
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
         A114TotTipo = "";
         lblTextblock2_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A1928TotDsc = "";
         lblTextblock4_Jsonclick = "";
         A1929TotDscTot = "";
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
         T001Z4_A114TotTipo = new string[] {""} ;
         T001Z4_A115TotRub = new int[1] ;
         T001Z4_A1928TotDsc = new string[] {""} ;
         T001Z4_A1929TotDscTot = new string[] {""} ;
         T001Z4_A120TotOrd = new short[1] ;
         T001Z4_A1930TotSts = new short[1] ;
         T001Z5_A114TotTipo = new string[] {""} ;
         T001Z5_A115TotRub = new int[1] ;
         T001Z3_A114TotTipo = new string[] {""} ;
         T001Z3_A115TotRub = new int[1] ;
         T001Z3_A1928TotDsc = new string[] {""} ;
         T001Z3_A1929TotDscTot = new string[] {""} ;
         T001Z3_A120TotOrd = new short[1] ;
         T001Z3_A1930TotSts = new short[1] ;
         sMode68 = "";
         T001Z6_A114TotTipo = new string[] {""} ;
         T001Z6_A115TotRub = new int[1] ;
         T001Z7_A114TotTipo = new string[] {""} ;
         T001Z7_A115TotRub = new int[1] ;
         T001Z2_A114TotTipo = new string[] {""} ;
         T001Z2_A115TotRub = new int[1] ;
         T001Z2_A1928TotDsc = new string[] {""} ;
         T001Z2_A1929TotDscTot = new string[] {""} ;
         T001Z2_A120TotOrd = new short[1] ;
         T001Z2_A1930TotSts = new short[1] ;
         T001Z11_A114TotTipo = new string[] {""} ;
         T001Z11_A115TotRub = new int[1] ;
         T001Z11_A116RubCod = new int[1] ;
         T001Z12_A114TotTipo = new string[] {""} ;
         T001Z12_A115TotRub = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ114TotTipo = "";
         ZZ1928TotDsc = "";
         ZZ1929TotDscTot = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbrubrost__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbrubrost__default(),
            new Object[][] {
                new Object[] {
               T001Z2_A114TotTipo, T001Z2_A115TotRub, T001Z2_A1928TotDsc, T001Z2_A1929TotDscTot, T001Z2_A120TotOrd, T001Z2_A1930TotSts
               }
               , new Object[] {
               T001Z3_A114TotTipo, T001Z3_A115TotRub, T001Z3_A1928TotDsc, T001Z3_A1929TotDscTot, T001Z3_A120TotOrd, T001Z3_A1930TotSts
               }
               , new Object[] {
               T001Z4_A114TotTipo, T001Z4_A115TotRub, T001Z4_A1928TotDsc, T001Z4_A1929TotDscTot, T001Z4_A120TotOrd, T001Z4_A1930TotSts
               }
               , new Object[] {
               T001Z5_A114TotTipo, T001Z5_A115TotRub
               }
               , new Object[] {
               T001Z6_A114TotTipo, T001Z6_A115TotRub
               }
               , new Object[] {
               T001Z7_A114TotTipo, T001Z7_A115TotRub
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Z11_A114TotTipo, T001Z11_A115TotRub, T001Z11_A116RubCod
               }
               , new Object[] {
               T001Z12_A114TotTipo, T001Z12_A115TotRub
               }
            }
         );
      }

      private short Z120TotOrd ;
      private short Z1930TotSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1930TotSts ;
      private short A120TotOrd ;
      private short GX_JID ;
      private short RcdFound68 ;
      private short nIsDirty_68 ;
      private short Gx_BScreen ;
      private short ZZ120TotOrd ;
      private short ZZ1930TotSts ;
      private int Z115TotRub ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTotTipo_Enabled ;
      private int A115TotRub ;
      private int edtTotRub_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTotDsc_Enabled ;
      private int edtTotDscTot_Enabled ;
      private int edtTotOrd_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ115TotRub ;
      private string sPrefix ;
      private string Z114TotTipo ;
      private string Z1928TotDsc ;
      private string Z1929TotDscTot ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTotTipo_Internalname ;
      private string cmbTotSts_Internalname ;
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
      private string A114TotTipo ;
      private string edtTotTipo_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTotRub_Internalname ;
      private string edtTotRub_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTotDsc_Internalname ;
      private string A1928TotDsc ;
      private string edtTotDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTotDscTot_Internalname ;
      private string A1929TotDscTot ;
      private string edtTotDscTot_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtTotOrd_Internalname ;
      private string edtTotOrd_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string cmbTotSts_Jsonclick ;
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
      private string sMode68 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ114TotTipo ;
      private string ZZ1928TotDsc ;
      private string ZZ1929TotDscTot ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTotSts ;
      private IDataStoreProvider pr_default ;
      private string[] T001Z4_A114TotTipo ;
      private int[] T001Z4_A115TotRub ;
      private string[] T001Z4_A1928TotDsc ;
      private string[] T001Z4_A1929TotDscTot ;
      private short[] T001Z4_A120TotOrd ;
      private short[] T001Z4_A1930TotSts ;
      private string[] T001Z5_A114TotTipo ;
      private int[] T001Z5_A115TotRub ;
      private string[] T001Z3_A114TotTipo ;
      private int[] T001Z3_A115TotRub ;
      private string[] T001Z3_A1928TotDsc ;
      private string[] T001Z3_A1929TotDscTot ;
      private short[] T001Z3_A120TotOrd ;
      private short[] T001Z3_A1930TotSts ;
      private string[] T001Z6_A114TotTipo ;
      private int[] T001Z6_A115TotRub ;
      private string[] T001Z7_A114TotTipo ;
      private int[] T001Z7_A115TotRub ;
      private string[] T001Z2_A114TotTipo ;
      private int[] T001Z2_A115TotRub ;
      private string[] T001Z2_A1928TotDsc ;
      private string[] T001Z2_A1929TotDscTot ;
      private short[] T001Z2_A120TotOrd ;
      private short[] T001Z2_A1930TotSts ;
      private string[] T001Z11_A114TotTipo ;
      private int[] T001Z11_A115TotRub ;
      private int[] T001Z11_A116RubCod ;
      private string[] T001Z12_A114TotTipo ;
      private int[] T001Z12_A115TotRub ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cbrubrost__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbrubrost__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001Z4;
        prmT001Z4 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z5;
        prmT001Z5 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z3;
        prmT001Z3 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z6;
        prmT001Z6 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z7;
        prmT001Z7 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z2;
        prmT001Z2 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z8;
        prmT001Z8 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@TotDsc",GXType.NChar,100,0) ,
        new ParDef("@TotDscTot",GXType.NChar,100,0) ,
        new ParDef("@TotOrd",GXType.Int16,2,0) ,
        new ParDef("@TotSts",GXType.Int16,1,0)
        };
        Object[] prmT001Z9;
        prmT001Z9 = new Object[] {
        new ParDef("@TotDsc",GXType.NChar,100,0) ,
        new ParDef("@TotDscTot",GXType.NChar,100,0) ,
        new ParDef("@TotOrd",GXType.Int16,2,0) ,
        new ParDef("@TotSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z10;
        prmT001Z10 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z11;
        prmT001Z11 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001Z12;
        prmT001Z12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001Z2", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts] FROM [CBRUBROST] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z3", "SELECT [TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z4", "SELECT TM1.[TotTipo], TM1.[TotRub], TM1.[TotDsc], TM1.[TotDscTot], TM1.[TotOrd], TM1.[TotSts] FROM [CBRUBROST] TM1 WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub ORDER BY TM1.[TotTipo], TM1.[TotRub]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z5", "SELECT [TotTipo], [TotRub] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Z6", "SELECT TOP 1 [TotTipo], [TotRub] FROM [CBRUBROST] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub) ORDER BY [TotTipo], [TotRub]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Z7", "SELECT TOP 1 [TotTipo], [TotRub] FROM [CBRUBROST] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub) ORDER BY [TotTipo] DESC, [TotRub] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Z8", "INSERT INTO [CBRUBROST]([TotTipo], [TotRub], [TotDsc], [TotDscTot], [TotOrd], [TotSts]) VALUES(@TotTipo, @TotRub, @TotDsc, @TotDscTot, @TotOrd, @TotSts)", GxErrorMask.GX_NOMASK,prmT001Z8)
           ,new CursorDef("T001Z9", "UPDATE [CBRUBROST] SET [TotDsc]=@TotDsc, [TotDscTot]=@TotDscTot, [TotOrd]=@TotOrd, [TotSts]=@TotSts  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub", GxErrorMask.GX_NOMASK,prmT001Z9)
           ,new CursorDef("T001Z10", "DELETE FROM [CBRUBROST]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub", GxErrorMask.GX_NOMASK,prmT001Z10)
           ,new CursorDef("T001Z11", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Z12", "SELECT [TotTipo], [TotRub] FROM [CBRUBROST] ORDER BY [TotTipo], [TotRub]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Z12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
