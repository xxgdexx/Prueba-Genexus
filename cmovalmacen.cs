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
   public class cmovalmacen : GXHttpHandler
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
            Form.Meta.addItem("description", "Movimientos de Almacen", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cmovalmacen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cmovalmacen( IGxContext context )
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
         cmbMovSts = new GXCombobox();
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
         if ( cmbMovSts.ItemCount > 0 )
         {
            A1240MovSts = (short)(NumberUtil.Val( cmbMovSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0))), "."));
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            AssignProp("", false, cmbMovSts_Internalname, "Values", cmbMovSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm31104( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CMOVALMACEN.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Movimiento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A234MovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A234MovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A234MovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripcion Movimiento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovDsc_Internalname, StringUtil.RTrim( A1239MovDsc), StringUtil.RTrim( context.localUtil.Format( A1239MovDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura Movimiento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovAbr_Internalname, StringUtil.RTrim( A1237MovAbr), StringUtil.RTrim( context.localUtil.Format( A1237MovAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Tipo Mov. Almacen", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovTip_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1241MovTip), 1, 0, ".", "")), StringUtil.LTrim( ((edtMovTip_Enabled!=0) ? context.localUtil.Format( (decimal)(A1241MovTip), "9") : context.localUtil.Format( (decimal)(A1241MovTip), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovTip_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situacion Movimiento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovSts, cmbMovSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0)), 1, cmbMovSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbMovSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CMOVALMACEN.htm");
         cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         AssignProp("", false, cmbMovSts_Internalname, "Values", (string)(cmbMovSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Valoriza Automatico", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1238MovAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtMovAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1238MovAut), "9") : context.localUtil.Format( (decimal)(A1238MovAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMOVALMACEN.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CMOVALMACEN.htm");
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
            Z234MovCod = (int)(context.localUtil.CToN( cgiGet( "Z234MovCod"), ".", ","));
            Z1239MovDsc = cgiGet( "Z1239MovDsc");
            Z1237MovAbr = cgiGet( "Z1237MovAbr");
            Z1241MovTip = (short)(context.localUtil.CToN( cgiGet( "Z1241MovTip"), ".", ","));
            Z1240MovSts = (short)(context.localUtil.CToN( cgiGet( "Z1240MovSts"), ".", ","));
            Z1238MovAut = (short)(context.localUtil.CToN( cgiGet( "Z1238MovAut"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A234MovCod = 0;
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            }
            else
            {
               A234MovCod = (int)(context.localUtil.CToN( cgiGet( edtMovCod_Internalname), ".", ","));
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            }
            A1239MovDsc = cgiGet( edtMovDsc_Internalname);
            AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
            A1237MovAbr = cgiGet( edtMovAbr_Internalname);
            AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVTIP");
               AnyError = 1;
               GX_FocusControl = edtMovTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1241MovTip = 0;
               AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            }
            else
            {
               A1241MovTip = (short)(context.localUtil.CToN( cgiGet( edtMovTip_Internalname), ".", ","));
               AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            }
            cmbMovSts.CurrentValue = cgiGet( cmbMovSts_Internalname);
            A1240MovSts = (short)(NumberUtil.Val( cgiGet( cmbMovSts_Internalname), "."));
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVAUT");
               AnyError = 1;
               GX_FocusControl = edtMovAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1238MovAut = 0;
               AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
            }
            else
            {
               A1238MovAut = (short)(context.localUtil.CToN( cgiGet( edtMovAut_Internalname), ".", ","));
               AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
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
               A234MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
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
               InitAll31104( ) ;
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
         DisableAttributes31104( ) ;
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

      protected void CONFIRM_310( )
      {
         BeforeValidate31104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls31104( ) ;
            }
            else
            {
               CheckExtendedTable31104( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors31104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues310( ) ;
         }
      }

      protected void ResetCaption310( )
      {
      }

      protected void ZM31104( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1239MovDsc = T00313_A1239MovDsc[0];
               Z1237MovAbr = T00313_A1237MovAbr[0];
               Z1241MovTip = T00313_A1241MovTip[0];
               Z1240MovSts = T00313_A1240MovSts[0];
               Z1238MovAut = T00313_A1238MovAut[0];
            }
            else
            {
               Z1239MovDsc = A1239MovDsc;
               Z1237MovAbr = A1237MovAbr;
               Z1241MovTip = A1241MovTip;
               Z1240MovSts = A1240MovSts;
               Z1238MovAut = A1238MovAut;
            }
         }
         if ( GX_JID == -1 )
         {
            Z234MovCod = A234MovCod;
            Z1239MovDsc = A1239MovDsc;
            Z1237MovAbr = A1237MovAbr;
            Z1241MovTip = A1241MovTip;
            Z1240MovSts = A1240MovSts;
            Z1238MovAut = A1238MovAut;
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

      protected void Load31104( )
      {
         /* Using cursor T00314 */
         pr_default.execute(2, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound104 = 1;
            A1239MovDsc = T00314_A1239MovDsc[0];
            AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
            A1237MovAbr = T00314_A1237MovAbr[0];
            AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
            A1241MovTip = T00314_A1241MovTip[0];
            AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            A1240MovSts = T00314_A1240MovSts[0];
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            A1238MovAut = T00314_A1238MovAut[0];
            AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
            ZM31104( -1) ;
         }
         pr_default.close(2);
         OnLoadActions31104( ) ;
      }

      protected void OnLoadActions31104( )
      {
      }

      protected void CheckExtendedTable31104( )
      {
         nIsDirty_104 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors31104( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey31104( )
      {
         /* Using cursor T00315 */
         pr_default.execute(3, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00313 */
         pr_default.execute(1, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM31104( 1) ;
            RcdFound104 = 1;
            A234MovCod = T00313_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            A1239MovDsc = T00313_A1239MovDsc[0];
            AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
            A1237MovAbr = T00313_A1237MovAbr[0];
            AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
            A1241MovTip = T00313_A1241MovTip[0];
            AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
            A1240MovSts = T00313_A1240MovSts[0];
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
            A1238MovAut = T00313_A1238MovAut[0];
            AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
            Z234MovCod = A234MovCod;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load31104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey31104( ) ;
            }
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey31104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode104;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey31104( ) ;
         if ( RcdFound104 == 0 )
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
         RcdFound104 = 0;
         /* Using cursor T00316 */
         pr_default.execute(4, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00316_A234MovCod[0] < A234MovCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00316_A234MovCod[0] > A234MovCod ) ) )
            {
               A234MovCod = T00316_A234MovCod[0];
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound104 = 0;
         /* Using cursor T00317 */
         pr_default.execute(5, new Object[] {A234MovCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00317_A234MovCod[0] > A234MovCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00317_A234MovCod[0] < A234MovCod ) ) )
            {
               A234MovCod = T00317_A234MovCod[0];
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               RcdFound104 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey31104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert31104( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( A234MovCod != Z234MovCod )
               {
                  A234MovCod = Z234MovCod;
                  AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update31104( ) ;
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A234MovCod != Z234MovCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert31104( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert31104( ) ;
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
         if ( A234MovCod != Z234MovCod )
         {
            A234MovCod = Z234MovCod;
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MOVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMovCod_Internalname;
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
         GetKey31104( ) ;
         if ( RcdFound104 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MOVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A234MovCod != Z234MovCod )
            {
               A234MovCod = Z234MovCod;
               AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "MOVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovCod_Internalname;
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
            if ( A234MovCod != Z234MovCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovCod_Internalname;
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
         context.RollbackDataStores("cmovalmacen",pr_default);
         GX_FocusControl = edtMovDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_310( ) ;
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
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MOVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMovDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart31104( ) ;
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd31104( ) ;
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
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovDsc_Internalname;
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
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovDsc_Internalname;
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
         ScanStart31104( ) ;
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound104 != 0 )
            {
               ScanNext31104( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd31104( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency31104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00312 */
            pr_default.execute(0, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1239MovDsc, T00312_A1239MovDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1237MovAbr, T00312_A1237MovAbr[0]) != 0 ) || ( Z1241MovTip != T00312_A1241MovTip[0] ) || ( Z1240MovSts != T00312_A1240MovSts[0] ) || ( Z1238MovAut != T00312_A1238MovAut[0] ) )
            {
               if ( StringUtil.StrCmp(Z1239MovDsc, T00312_A1239MovDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cmovalmacen:[seudo value changed for attri]"+"MovDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1239MovDsc);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1239MovDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1237MovAbr, T00312_A1237MovAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cmovalmacen:[seudo value changed for attri]"+"MovAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1237MovAbr);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1237MovAbr[0]);
               }
               if ( Z1241MovTip != T00312_A1241MovTip[0] )
               {
                  GXUtil.WriteLog("cmovalmacen:[seudo value changed for attri]"+"MovTip");
                  GXUtil.WriteLogRaw("Old: ",Z1241MovTip);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1241MovTip[0]);
               }
               if ( Z1240MovSts != T00312_A1240MovSts[0] )
               {
                  GXUtil.WriteLog("cmovalmacen:[seudo value changed for attri]"+"MovSts");
                  GXUtil.WriteLogRaw("Old: ",Z1240MovSts);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1240MovSts[0]);
               }
               if ( Z1238MovAut != T00312_A1238MovAut[0] )
               {
                  GXUtil.WriteLog("cmovalmacen:[seudo value changed for attri]"+"MovAut");
                  GXUtil.WriteLogRaw("Old: ",Z1238MovAut);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1238MovAut[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMOVALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert31104( )
      {
         BeforeValidate31104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM31104( 0) ;
            CheckOptimisticConcurrency31104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert31104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00318 */
                     pr_default.execute(6, new Object[] {A234MovCod, A1239MovDsc, A1237MovAbr, A1241MovTip, A1240MovSts, A1238MovAut});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
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
                           ResetCaption310( ) ;
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
               Load31104( ) ;
            }
            EndLevel31104( ) ;
         }
         CloseExtendedTableCursors31104( ) ;
      }

      protected void Update31104( )
      {
         BeforeValidate31104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate31104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00319 */
                     pr_default.execute(7, new Object[] {A1239MovDsc, A1237MovAbr, A1241MovTip, A1240MovSts, A1238MovAut, A234MovCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate31104( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption310( ) ;
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
            EndLevel31104( ) ;
         }
         CloseExtendedTableCursors31104( ) ;
      }

      protected void DeferredUpdate31104( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate31104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls31104( ) ;
            AfterConfirm31104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete31104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003110 */
                  pr_default.execute(8, new Object[] {A234MovCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMOVALMACEN");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound104 == 0 )
                        {
                           InitAll31104( ) ;
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
                        ResetCaption310( ) ;
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel31104( ) ;
         Gx_mode = sMode104;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls31104( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003111 */
            pr_default.execute(9, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003112 */
            pr_default.execute(10, new Object[] {A234MovCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel31104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete31104( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cmovalmacen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues310( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cmovalmacen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart31104( )
      {
         /* Using cursor T003113 */
         pr_default.execute(11);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound104 = 1;
            A234MovCod = T003113_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext31104( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound104 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound104 = 1;
            A234MovCod = T003113_A234MovCod[0];
            AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         }
      }

      protected void ScanEnd31104( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm31104( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert31104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate31104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete31104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete31104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate31104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes31104( )
      {
         edtMovCod_Enabled = 0;
         AssignProp("", false, edtMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovCod_Enabled), 5, 0), true);
         edtMovDsc_Enabled = 0;
         AssignProp("", false, edtMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovDsc_Enabled), 5, 0), true);
         edtMovAbr_Enabled = 0;
         AssignProp("", false, edtMovAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovAbr_Enabled), 5, 0), true);
         edtMovTip_Enabled = 0;
         AssignProp("", false, edtMovTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovTip_Enabled), 5, 0), true);
         cmbMovSts.Enabled = 0;
         AssignProp("", false, cmbMovSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovSts.Enabled), 5, 0), true);
         edtMovAut_Enabled = 0;
         AssignProp("", false, edtMovAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovAut_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes31104( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues310( )
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
         context.SendWebValue( "Movimientos de Almacen") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245334", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cmovalmacen.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z234MovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z234MovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1239MovDsc", StringUtil.RTrim( Z1239MovDsc));
         GxWebStd.gx_hidden_field( context, "Z1237MovAbr", StringUtil.RTrim( Z1237MovAbr));
         GxWebStd.gx_hidden_field( context, "Z1241MovTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1241MovTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1240MovSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1240MovSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1238MovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1238MovAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm31104( )
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
         return "CMOVALMACEN" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Almacen" ;
      }

      protected void InitializeNonKey31104( )
      {
         A1239MovDsc = "";
         AssignAttri("", false, "A1239MovDsc", A1239MovDsc);
         A1237MovAbr = "";
         AssignAttri("", false, "A1237MovAbr", A1237MovAbr);
         A1241MovTip = 0;
         AssignAttri("", false, "A1241MovTip", StringUtil.Str( (decimal)(A1241MovTip), 1, 0));
         A1240MovSts = 0;
         AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         A1238MovAut = 0;
         AssignAttri("", false, "A1238MovAut", StringUtil.Str( (decimal)(A1238MovAut), 1, 0));
         Z1239MovDsc = "";
         Z1237MovAbr = "";
         Z1241MovTip = 0;
         Z1240MovSts = 0;
         Z1238MovAut = 0;
      }

      protected void InitAll31104( )
      {
         A234MovCod = 0;
         AssignAttri("", false, "A234MovCod", StringUtil.LTrimStr( (decimal)(A234MovCod), 6, 0));
         InitializeNonKey31104( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245339", true, true);
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
         context.AddJavascriptSource("cmovalmacen.js", "?202281810245339", false, true);
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
         edtMovCod_Internalname = "MOVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMovDsc_Internalname = "MOVDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMovAbr_Internalname = "MOVABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMovTip_Internalname = "MOVTIP";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbMovSts_Internalname = "MOVSTS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMovAut_Internalname = "MOVAUT";
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
         edtMovAut_Jsonclick = "";
         edtMovAut_Enabled = 1;
         cmbMovSts_Jsonclick = "";
         cmbMovSts.Enabled = 1;
         edtMovTip_Jsonclick = "";
         edtMovTip_Enabled = 1;
         edtMovAbr_Jsonclick = "";
         edtMovAbr_Enabled = 1;
         edtMovDsc_Jsonclick = "";
         edtMovDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMovCod_Jsonclick = "";
         edtMovCod_Enabled = 1;
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
         cmbMovSts.Name = "MOVSTS";
         cmbMovSts.WebTags = "";
         cmbMovSts.addItem("1", "ACTIVO", 0);
         cmbMovSts.addItem("0", "INACTIVO", 0);
         if ( cmbMovSts.ItemCount > 0 )
         {
            A1240MovSts = (short)(NumberUtil.Val( cmbMovSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0))), "."));
            AssignAttri("", false, "A1240MovSts", StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtMovDsc_Internalname;
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

      public void Valid_Movcod( )
      {
         A1240MovSts = (short)(NumberUtil.Val( cmbMovSts.CurrentValue, "."));
         cmbMovSts.CurrentValue = StringUtil.Str( (decimal)(A1240MovSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbMovSts.ItemCount > 0 )
         {
            A1240MovSts = (short)(NumberUtil.Val( cmbMovSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0))), "."));
            cmbMovSts.CurrentValue = StringUtil.Str( (decimal)(A1240MovSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1239MovDsc", StringUtil.RTrim( A1239MovDsc));
         AssignAttri("", false, "A1237MovAbr", StringUtil.RTrim( A1237MovAbr));
         AssignAttri("", false, "A1241MovTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1241MovTip), 1, 0, ".", "")));
         AssignAttri("", false, "A1240MovSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1240MovSts), 1, 0, ".", "")));
         cmbMovSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1240MovSts), 1, 0));
         AssignProp("", false, cmbMovSts_Internalname, "Values", cmbMovSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A1238MovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1238MovAut), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z234MovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z234MovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1239MovDsc", StringUtil.RTrim( Z1239MovDsc));
         GxWebStd.gx_hidden_field( context, "Z1237MovAbr", StringUtil.RTrim( Z1237MovAbr));
         GxWebStd.gx_hidden_field( context, "Z1241MovTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1241MovTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1240MovSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1240MovSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1238MovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1238MovAut), 1, 0, ".", "")));
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
         setEventMetadata("VALID_MOVCOD","{handler:'Valid_Movcod',iparms:[{av:'cmbMovSts'},{av:'A1240MovSts',fld:'MOVSTS',pic:'9'},{av:'A234MovCod',fld:'MOVCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOVCOD",",oparms:[{av:'A1239MovDsc',fld:'MOVDSC',pic:''},{av:'A1237MovAbr',fld:'MOVABR',pic:''},{av:'A1241MovTip',fld:'MOVTIP',pic:'9'},{av:'cmbMovSts'},{av:'A1240MovSts',fld:'MOVSTS',pic:'9'},{av:'A1238MovAut',fld:'MOVAUT',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z234MovCod'},{av:'Z1239MovDsc'},{av:'Z1237MovAbr'},{av:'Z1241MovTip'},{av:'Z1240MovSts'},{av:'Z1238MovAut'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1239MovDsc = "";
         Z1237MovAbr = "";
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
         A1239MovDsc = "";
         lblTextblock3_Jsonclick = "";
         A1237MovAbr = "";
         lblTextblock4_Jsonclick = "";
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
         T00314_A234MovCod = new int[1] ;
         T00314_A1239MovDsc = new string[] {""} ;
         T00314_A1237MovAbr = new string[] {""} ;
         T00314_A1241MovTip = new short[1] ;
         T00314_A1240MovSts = new short[1] ;
         T00314_A1238MovAut = new short[1] ;
         T00315_A234MovCod = new int[1] ;
         T00313_A234MovCod = new int[1] ;
         T00313_A1239MovDsc = new string[] {""} ;
         T00313_A1237MovAbr = new string[] {""} ;
         T00313_A1241MovTip = new short[1] ;
         T00313_A1240MovSts = new short[1] ;
         T00313_A1238MovAut = new short[1] ;
         sMode104 = "";
         T00316_A234MovCod = new int[1] ;
         T00317_A234MovCod = new int[1] ;
         T00312_A234MovCod = new int[1] ;
         T00312_A1239MovDsc = new string[] {""} ;
         T00312_A1237MovAbr = new string[] {""} ;
         T00312_A1241MovTip = new short[1] ;
         T00312_A1240MovSts = new short[1] ;
         T00312_A1238MovAut = new short[1] ;
         T003111_A191ImpItem = new long[1] ;
         T003112_A13MvATip = new string[] {""} ;
         T003112_A14MvACod = new string[] {""} ;
         T003113_A234MovCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1239MovDsc = "";
         ZZ1237MovAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cmovalmacen__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cmovalmacen__default(),
            new Object[][] {
                new Object[] {
               T00312_A234MovCod, T00312_A1239MovDsc, T00312_A1237MovAbr, T00312_A1241MovTip, T00312_A1240MovSts, T00312_A1238MovAut
               }
               , new Object[] {
               T00313_A234MovCod, T00313_A1239MovDsc, T00313_A1237MovAbr, T00313_A1241MovTip, T00313_A1240MovSts, T00313_A1238MovAut
               }
               , new Object[] {
               T00314_A234MovCod, T00314_A1239MovDsc, T00314_A1237MovAbr, T00314_A1241MovTip, T00314_A1240MovSts, T00314_A1238MovAut
               }
               , new Object[] {
               T00315_A234MovCod
               }
               , new Object[] {
               T00316_A234MovCod
               }
               , new Object[] {
               T00317_A234MovCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003111_A191ImpItem
               }
               , new Object[] {
               T003112_A13MvATip, T003112_A14MvACod
               }
               , new Object[] {
               T003113_A234MovCod
               }
            }
         );
      }

      private short Z1241MovTip ;
      private short Z1240MovSts ;
      private short Z1238MovAut ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1240MovSts ;
      private short A1241MovTip ;
      private short A1238MovAut ;
      private short GX_JID ;
      private short RcdFound104 ;
      private short nIsDirty_104 ;
      private short Gx_BScreen ;
      private short ZZ1241MovTip ;
      private short ZZ1240MovSts ;
      private short ZZ1238MovAut ;
      private int Z234MovCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A234MovCod ;
      private int edtMovCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMovDsc_Enabled ;
      private int edtMovAbr_Enabled ;
      private int edtMovTip_Enabled ;
      private int edtMovAut_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ234MovCod ;
      private string sPrefix ;
      private string Z1239MovDsc ;
      private string Z1237MovAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMovCod_Internalname ;
      private string cmbMovSts_Internalname ;
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
      private string edtMovCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMovDsc_Internalname ;
      private string A1239MovDsc ;
      private string edtMovDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMovAbr_Internalname ;
      private string A1237MovAbr ;
      private string edtMovAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMovTip_Internalname ;
      private string edtMovTip_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbMovSts_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMovAut_Internalname ;
      private string edtMovAut_Jsonclick ;
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
      private string sMode104 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1239MovDsc ;
      private string ZZ1237MovAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMovSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00314_A234MovCod ;
      private string[] T00314_A1239MovDsc ;
      private string[] T00314_A1237MovAbr ;
      private short[] T00314_A1241MovTip ;
      private short[] T00314_A1240MovSts ;
      private short[] T00314_A1238MovAut ;
      private int[] T00315_A234MovCod ;
      private int[] T00313_A234MovCod ;
      private string[] T00313_A1239MovDsc ;
      private string[] T00313_A1237MovAbr ;
      private short[] T00313_A1241MovTip ;
      private short[] T00313_A1240MovSts ;
      private short[] T00313_A1238MovAut ;
      private int[] T00316_A234MovCod ;
      private int[] T00317_A234MovCod ;
      private int[] T00312_A234MovCod ;
      private string[] T00312_A1239MovDsc ;
      private string[] T00312_A1237MovAbr ;
      private short[] T00312_A1241MovTip ;
      private short[] T00312_A1240MovSts ;
      private short[] T00312_A1238MovAut ;
      private long[] T003111_A191ImpItem ;
      private string[] T003112_A13MvATip ;
      private string[] T003112_A14MvACod ;
      private int[] T003113_A234MovCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cmovalmacen__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cmovalmacen__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00314;
        prmT00314 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00315;
        prmT00315 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00313;
        prmT00313 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00316;
        prmT00316 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00317;
        prmT00317 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00312;
        prmT00312 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT00318;
        prmT00318 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0) ,
        new ParDef("@MovDsc",GXType.NChar,100,0) ,
        new ParDef("@MovAbr",GXType.NChar,5,0) ,
        new ParDef("@MovTip",GXType.Int16,1,0) ,
        new ParDef("@MovSts",GXType.Int16,1,0) ,
        new ParDef("@MovAut",GXType.Int16,1,0)
        };
        Object[] prmT00319;
        prmT00319 = new Object[] {
        new ParDef("@MovDsc",GXType.NChar,100,0) ,
        new ParDef("@MovAbr",GXType.NChar,5,0) ,
        new ParDef("@MovTip",GXType.Int16,1,0) ,
        new ParDef("@MovSts",GXType.Int16,1,0) ,
        new ParDef("@MovAut",GXType.Int16,1,0) ,
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT003110;
        prmT003110 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT003111;
        prmT003111 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT003112;
        prmT003112 = new Object[] {
        new ParDef("@MovCod",GXType.Int32,6,0)
        };
        Object[] prmT003113;
        prmT003113 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00312", "SELECT [MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut] FROM [CMOVALMACEN] WITH (UPDLOCK) WHERE [MovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00313", "SELECT [MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut] FROM [CMOVALMACEN] WHERE [MovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00314", "SELECT TM1.[MovCod], TM1.[MovDsc], TM1.[MovAbr], TM1.[MovTip], TM1.[MovSts], TM1.[MovAut] FROM [CMOVALMACEN] TM1 WHERE TM1.[MovCod] = @MovCod ORDER BY TM1.[MovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00314,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00315", "SELECT [MovCod] FROM [CMOVALMACEN] WHERE [MovCod] = @MovCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00316", "SELECT TOP 1 [MovCod] FROM [CMOVALMACEN] WHERE ( [MovCod] > @MovCod) ORDER BY [MovCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00316,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00317", "SELECT TOP 1 [MovCod] FROM [CMOVALMACEN] WHERE ( [MovCod] < @MovCod) ORDER BY [MovCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00317,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00318", "INSERT INTO [CMOVALMACEN]([MovCod], [MovDsc], [MovAbr], [MovTip], [MovSts], [MovAut]) VALUES(@MovCod, @MovDsc, @MovAbr, @MovTip, @MovSts, @MovAut)", GxErrorMask.GX_NOMASK,prmT00318)
           ,new CursorDef("T00319", "UPDATE [CMOVALMACEN] SET [MovDsc]=@MovDsc, [MovAbr]=@MovAbr, [MovTip]=@MovTip, [MovSts]=@MovSts, [MovAut]=@MovAut  WHERE [MovCod] = @MovCod", GxErrorMask.GX_NOMASK,prmT00319)
           ,new CursorDef("T003110", "DELETE FROM [CMOVALMACEN]  WHERE [MovCod] = @MovCod", GxErrorMask.GX_NOMASK,prmT003110)
           ,new CursorDef("T003111", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpMovCod] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003112", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MvAMov] = @MovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003113", "SELECT [MovCod] FROM [CMOVALMACEN] ORDER BY [MovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003113,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
