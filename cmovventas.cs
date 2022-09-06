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
   public class cmovventas : GXDataArea
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
            Form.Meta.addItem("description", "Movimientos de Ventas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMovVCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cmovventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cmovventas( IGxContext context )
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
         cmbMovVTip = new GXCombobox();
         cmbMovVSts = new GXCombobox();
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
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
            AssignProp("", false, cmbMovVTip_Internalname, "Values", cmbMovVTip.ToJavascriptSource(), true);
         }
         if ( cmbMovVSts.ItemCount > 0 )
         {
            A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            AssignProp("", false, cmbMovVSts_Internalname, "Values", cmbMovVSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CMOVVENTAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Mov. Venta", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A235MovVCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMovVCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A235MovVCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovVCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripción Mov. Venta", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVDsc_Internalname, StringUtil.RTrim( A1243MovVDsc), StringUtil.RTrim( context.localUtil.Format( A1243MovVDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovVDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura Mov. Venta", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovVAbr_Internalname, StringUtil.RTrim( A1242MovVAbr), StringUtil.RTrim( context.localUtil.Format( A1242MovVAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovVAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovVAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cargo / Abono", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovVTip, cmbMovVTip_Internalname, StringUtil.RTrim( A1245MovVTip), 1, cmbMovVTip_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMovVTip.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CMOVVENTAS.htm");
         cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
         AssignProp("", false, cmbMovVTip_Internalname, "Values", (string)(cmbMovVTip.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situación Mov. Venta", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CMOVVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovVSts, cmbMovVSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0)), 1, cmbMovVSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbMovVSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CMOVVENTAS.htm");
         cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         AssignProp("", false, cmbMovVSts_Internalname, "Values", (string)(cmbMovVSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CMOVVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CMOVVENTAS.htm");
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
            Z235MovVCod = (int)(context.localUtil.CToN( cgiGet( "Z235MovVCod"), ".", ","));
            Z1243MovVDsc = cgiGet( "Z1243MovVDsc");
            Z1242MovVAbr = cgiGet( "Z1242MovVAbr");
            Z1245MovVTip = cgiGet( "Z1245MovVTip");
            Z1244MovVSts = (short)(context.localUtil.CToN( cgiGet( "Z1244MovVSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovVCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A235MovVCod = 0;
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            }
            else
            {
               A235MovVCod = (int)(context.localUtil.CToN( cgiGet( edtMovVCod_Internalname), ".", ","));
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            }
            A1243MovVDsc = cgiGet( edtMovVDsc_Internalname);
            AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
            A1242MovVAbr = cgiGet( edtMovVAbr_Internalname);
            AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
            cmbMovVTip.CurrentValue = cgiGet( cmbMovVTip_Internalname);
            A1245MovVTip = cgiGet( cmbMovVTip_Internalname);
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
            cmbMovVSts.CurrentValue = cgiGet( cmbMovVSts_Internalname);
            A1244MovVSts = (short)(NumberUtil.Val( cgiGet( cmbMovVSts_Internalname), "."));
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
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
               A235MovVCod = (int)(NumberUtil.Val( GetPar( "MovVCod"), "."));
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
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
               InitAll32105( ) ;
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
         DisableAttributes32105( ) ;
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

      protected void CONFIRM_320( )
      {
         BeforeValidate32105( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls32105( ) ;
            }
            else
            {
               CheckExtendedTable32105( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors32105( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues320( ) ;
         }
      }

      protected void ResetCaption320( )
      {
      }

      protected void ZM32105( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1243MovVDsc = T00323_A1243MovVDsc[0];
               Z1242MovVAbr = T00323_A1242MovVAbr[0];
               Z1245MovVTip = T00323_A1245MovVTip[0];
               Z1244MovVSts = T00323_A1244MovVSts[0];
            }
            else
            {
               Z1243MovVDsc = A1243MovVDsc;
               Z1242MovVAbr = A1242MovVAbr;
               Z1245MovVTip = A1245MovVTip;
               Z1244MovVSts = A1244MovVSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z235MovVCod = A235MovVCod;
            Z1243MovVDsc = A1243MovVDsc;
            Z1242MovVAbr = A1242MovVAbr;
            Z1245MovVTip = A1245MovVTip;
            Z1244MovVSts = A1244MovVSts;
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

      protected void Load32105( )
      {
         /* Using cursor T00324 */
         pr_default.execute(2, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound105 = 1;
            A1243MovVDsc = T00324_A1243MovVDsc[0];
            AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
            A1242MovVAbr = T00324_A1242MovVAbr[0];
            AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
            A1245MovVTip = T00324_A1245MovVTip[0];
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
            A1244MovVSts = T00324_A1244MovVSts[0];
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            ZM32105( -1) ;
         }
         pr_default.close(2);
         OnLoadActions32105( ) ;
      }

      protected void OnLoadActions32105( )
      {
      }

      protected void CheckExtendedTable32105( )
      {
         nIsDirty_105 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors32105( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey32105( )
      {
         /* Using cursor T00325 */
         pr_default.execute(3, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00323 */
         pr_default.execute(1, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM32105( 1) ;
            RcdFound105 = 1;
            A235MovVCod = T00323_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            A1243MovVDsc = T00323_A1243MovVDsc[0];
            AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
            A1242MovVAbr = T00323_A1242MovVAbr[0];
            AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
            A1245MovVTip = T00323_A1245MovVTip[0];
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
            A1244MovVSts = T00323_A1244MovVSts[0];
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
            Z235MovVCod = A235MovVCod;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load32105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey32105( ) ;
            }
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey32105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey32105( ) ;
         if ( RcdFound105 == 0 )
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
         RcdFound105 = 0;
         /* Using cursor T00326 */
         pr_default.execute(4, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00326_A235MovVCod[0] < A235MovVCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00326_A235MovVCod[0] > A235MovVCod ) ) )
            {
               A235MovVCod = T00326_A235MovVCod[0];
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound105 = 0;
         /* Using cursor T00327 */
         pr_default.execute(5, new Object[] {A235MovVCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00327_A235MovVCod[0] > A235MovVCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00327_A235MovVCod[0] < A235MovVCod ) ) )
            {
               A235MovVCod = T00327_A235MovVCod[0];
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey32105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMovVCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert32105( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A235MovVCod != Z235MovVCod )
               {
                  A235MovVCod = Z235MovVCod;
                  AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MOVVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update32105( ) ;
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A235MovVCod != Z235MovVCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMovVCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert32105( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMovVCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMovVCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert32105( ) ;
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
         if ( A235MovVCod != Z235MovVCod )
         {
            A235MovVCod = Z235MovVCod;
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MOVVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovVCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMovVCod_Internalname;
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
         GetKey32105( ) ;
         if ( RcdFound105 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MOVVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovVCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A235MovVCod != Z235MovVCod )
            {
               A235MovVCod = Z235MovVCod;
               AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "MOVVCOD");
               AnyError = 1;
               GX_FocusControl = edtMovVCod_Internalname;
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
            if ( A235MovVCod != Z235MovVCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMovVCod_Internalname;
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
         context.RollbackDataStores("cmovventas",pr_default);
         GX_FocusControl = edtMovVDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_320( ) ;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MOVVCOD");
            AnyError = 1;
            GX_FocusControl = edtMovVCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMovVDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart32105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovVDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd32105( ) ;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovVDsc_Internalname;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovVDsc_Internalname;
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
         ScanStart32105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound105 != 0 )
            {
               ScanNext32105( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMovVDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd32105( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency32105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00322 */
            pr_default.execute(0, new Object[] {A235MovVCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVVENTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1243MovVDsc, T00322_A1243MovVDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1242MovVAbr, T00322_A1242MovVAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z1245MovVTip, T00322_A1245MovVTip[0]) != 0 ) || ( Z1244MovVSts != T00322_A1244MovVSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1243MovVDsc, T00322_A1243MovVDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cmovventas:[seudo value changed for attri]"+"MovVDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1243MovVDsc);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1243MovVDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1242MovVAbr, T00322_A1242MovVAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cmovventas:[seudo value changed for attri]"+"MovVAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1242MovVAbr);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1242MovVAbr[0]);
               }
               if ( StringUtil.StrCmp(Z1245MovVTip, T00322_A1245MovVTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cmovventas:[seudo value changed for attri]"+"MovVTip");
                  GXUtil.WriteLogRaw("Old: ",Z1245MovVTip);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1245MovVTip[0]);
               }
               if ( Z1244MovVSts != T00322_A1244MovVSts[0] )
               {
                  GXUtil.WriteLog("cmovventas:[seudo value changed for attri]"+"MovVSts");
                  GXUtil.WriteLogRaw("Old: ",Z1244MovVSts);
                  GXUtil.WriteLogRaw("Current: ",T00322_A1244MovVSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMOVVENTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert32105( )
      {
         BeforeValidate32105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM32105( 0) ;
            CheckOptimisticConcurrency32105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert32105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00328 */
                     pr_default.execute(6, new Object[] {A235MovVCod, A1243MovVDsc, A1242MovVAbr, A1245MovVTip, A1244MovVSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
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
                           ResetCaption320( ) ;
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
               Load32105( ) ;
            }
            EndLevel32105( ) ;
         }
         CloseExtendedTableCursors32105( ) ;
      }

      protected void Update32105( )
      {
         BeforeValidate32105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate32105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00329 */
                     pr_default.execute(7, new Object[] {A1243MovVDsc, A1242MovVAbr, A1245MovVTip, A1244MovVSts, A235MovVCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMOVVENTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate32105( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption320( ) ;
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
            EndLevel32105( ) ;
         }
         CloseExtendedTableCursors32105( ) ;
      }

      protected void DeferredUpdate32105( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate32105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls32105( ) ;
            AfterConfirm32105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete32105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003210 */
                  pr_default.execute(8, new Object[] {A235MovVCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMOVVENTAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound105 == 0 )
                        {
                           InitAll32105( ) ;
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
                        ResetCaption320( ) ;
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel32105( ) ;
         Gx_mode = sMode105;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls32105( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003211 */
            pr_default.execute(9, new Object[] {A235MovVCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel32105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete32105( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cmovventas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues320( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cmovventas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart32105( )
      {
         /* Using cursor T003212 */
         pr_default.execute(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A235MovVCod = T003212_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext32105( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound105 = 1;
            A235MovVCod = T003212_A235MovVCod[0];
            AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         }
      }

      protected void ScanEnd32105( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm32105( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert32105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate32105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete32105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete32105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate32105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes32105( )
      {
         edtMovVCod_Enabled = 0;
         AssignProp("", false, edtMovVCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVCod_Enabled), 5, 0), true);
         edtMovVDsc_Enabled = 0;
         AssignProp("", false, edtMovVDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVDsc_Enabled), 5, 0), true);
         edtMovVAbr_Enabled = 0;
         AssignProp("", false, edtMovVAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovVAbr_Enabled), 5, 0), true);
         cmbMovVTip.Enabled = 0;
         AssignProp("", false, cmbMovVTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovVTip.Enabled), 5, 0), true);
         cmbMovVSts.Enabled = 0;
         AssignProp("", false, cmbMovVSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovVSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes32105( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues320( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245193", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cmovventas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z235MovVCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z235MovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1243MovVDsc", StringUtil.RTrim( Z1243MovVDsc));
         GxWebStd.gx_hidden_field( context, "Z1242MovVAbr", StringUtil.RTrim( Z1242MovVAbr));
         GxWebStd.gx_hidden_field( context, "Z1245MovVTip", StringUtil.RTrim( Z1245MovVTip));
         GxWebStd.gx_hidden_field( context, "Z1244MovVSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1244MovVSts), 1, 0, ".", "")));
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
         return formatLink("cmovventas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CMOVVENTAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Ventas" ;
      }

      protected void InitializeNonKey32105( )
      {
         A1243MovVDsc = "";
         AssignAttri("", false, "A1243MovVDsc", A1243MovVDsc);
         A1242MovVAbr = "";
         AssignAttri("", false, "A1242MovVAbr", A1242MovVAbr);
         A1245MovVTip = "";
         AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         A1244MovVSts = 0;
         AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         Z1243MovVDsc = "";
         Z1242MovVAbr = "";
         Z1245MovVTip = "";
         Z1244MovVSts = 0;
      }

      protected void InitAll32105( )
      {
         A235MovVCod = 0;
         AssignAttri("", false, "A235MovVCod", StringUtil.LTrimStr( (decimal)(A235MovVCod), 6, 0));
         InitializeNonKey32105( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245198", true, true);
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
         context.AddJavascriptSource("cmovventas.js", "?202281810245198", false, true);
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
         edtMovVCod_Internalname = "MOVVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMovVDsc_Internalname = "MOVVDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMovVAbr_Internalname = "MOVVABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbMovVTip_Internalname = "MOVVTIP";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbMovVSts_Internalname = "MOVVSTS";
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
         Form.Caption = "Movimientos de Ventas";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbMovVSts_Jsonclick = "";
         cmbMovVSts.Enabled = 1;
         cmbMovVTip_Jsonclick = "";
         cmbMovVTip.Enabled = 1;
         edtMovVAbr_Jsonclick = "";
         edtMovVAbr_Enabled = 1;
         edtMovVDsc_Jsonclick = "";
         edtMovVDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMovVCod_Jsonclick = "";
         edtMovVCod_Enabled = 1;
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
         cmbMovVTip.Name = "MOVVTIP";
         cmbMovVTip.WebTags = "";
         cmbMovVTip.addItem("C", "Credito", 0);
         cmbMovVTip.addItem("D", "Debito", 0);
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
            AssignAttri("", false, "A1245MovVTip", A1245MovVTip);
         }
         cmbMovVSts.Name = "MOVVSTS";
         cmbMovVSts.WebTags = "";
         cmbMovVSts.addItem("1", "ACTIVO", 0);
         cmbMovVSts.addItem("0", "INACTIVO", 0);
         if ( cmbMovVSts.ItemCount > 0 )
         {
            A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
            AssignAttri("", false, "A1244MovVSts", StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtMovVDsc_Internalname;
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

      public void Valid_Movvcod( )
      {
         A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.CurrentValue, "."));
         cmbMovVSts.CurrentValue = StringUtil.Str( (decimal)(A1244MovVSts), 1, 0);
         A1245MovVTip = cmbMovVTip.CurrentValue;
         cmbMovVTip.CurrentValue = A1245MovVTip;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbMovVTip.ItemCount > 0 )
         {
            A1245MovVTip = cmbMovVTip.getValidValue(A1245MovVTip);
            cmbMovVTip.CurrentValue = A1245MovVTip;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
         }
         if ( cmbMovVSts.ItemCount > 0 )
         {
            A1244MovVSts = (short)(NumberUtil.Val( cmbMovVSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0))), "."));
            cmbMovVSts.CurrentValue = StringUtil.Str( (decimal)(A1244MovVSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1243MovVDsc", StringUtil.RTrim( A1243MovVDsc));
         AssignAttri("", false, "A1242MovVAbr", StringUtil.RTrim( A1242MovVAbr));
         AssignAttri("", false, "A1245MovVTip", StringUtil.RTrim( A1245MovVTip));
         cmbMovVTip.CurrentValue = StringUtil.RTrim( A1245MovVTip);
         AssignProp("", false, cmbMovVTip_Internalname, "Values", cmbMovVTip.ToJavascriptSource(), true);
         AssignAttri("", false, "A1244MovVSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1244MovVSts), 1, 0, ".", "")));
         cmbMovVSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1244MovVSts), 1, 0));
         AssignProp("", false, cmbMovVSts_Internalname, "Values", cmbMovVSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z235MovVCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z235MovVCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1243MovVDsc", StringUtil.RTrim( Z1243MovVDsc));
         GxWebStd.gx_hidden_field( context, "Z1242MovVAbr", StringUtil.RTrim( Z1242MovVAbr));
         GxWebStd.gx_hidden_field( context, "Z1245MovVTip", StringUtil.RTrim( Z1245MovVTip));
         GxWebStd.gx_hidden_field( context, "Z1244MovVSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1244MovVSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_MOVVCOD","{handler:'Valid_Movvcod',iparms:[{av:'cmbMovVSts'},{av:'A1244MovVSts',fld:'MOVVSTS',pic:'9'},{av:'cmbMovVTip'},{av:'A1245MovVTip',fld:'MOVVTIP',pic:''},{av:'A235MovVCod',fld:'MOVVCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MOVVCOD",",oparms:[{av:'A1243MovVDsc',fld:'MOVVDSC',pic:''},{av:'A1242MovVAbr',fld:'MOVVABR',pic:''},{av:'cmbMovVTip'},{av:'A1245MovVTip',fld:'MOVVTIP',pic:''},{av:'cmbMovVSts'},{av:'A1244MovVSts',fld:'MOVVSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z235MovVCod'},{av:'Z1243MovVDsc'},{av:'Z1242MovVAbr'},{av:'Z1245MovVTip'},{av:'Z1244MovVSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1243MovVDsc = "";
         Z1242MovVAbr = "";
         Z1245MovVTip = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1245MovVTip = "";
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
         A1243MovVDsc = "";
         lblTextblock3_Jsonclick = "";
         A1242MovVAbr = "";
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
         T00324_A235MovVCod = new int[1] ;
         T00324_A1243MovVDsc = new string[] {""} ;
         T00324_A1242MovVAbr = new string[] {""} ;
         T00324_A1245MovVTip = new string[] {""} ;
         T00324_A1244MovVSts = new short[1] ;
         T00325_A235MovVCod = new int[1] ;
         T00323_A235MovVCod = new int[1] ;
         T00323_A1243MovVDsc = new string[] {""} ;
         T00323_A1242MovVAbr = new string[] {""} ;
         T00323_A1245MovVTip = new string[] {""} ;
         T00323_A1244MovVSts = new short[1] ;
         sMode105 = "";
         T00326_A235MovVCod = new int[1] ;
         T00327_A235MovVCod = new int[1] ;
         T00322_A235MovVCod = new int[1] ;
         T00322_A1243MovVDsc = new string[] {""} ;
         T00322_A1242MovVAbr = new string[] {""} ;
         T00322_A1245MovVTip = new string[] {""} ;
         T00322_A1244MovVSts = new short[1] ;
         T003211_A149TipCod = new string[] {""} ;
         T003211_A24DocNum = new string[] {""} ;
         T003212_A235MovVCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1243MovVDsc = "";
         ZZ1242MovVAbr = "";
         ZZ1245MovVTip = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cmovventas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cmovventas__default(),
            new Object[][] {
                new Object[] {
               T00322_A235MovVCod, T00322_A1243MovVDsc, T00322_A1242MovVAbr, T00322_A1245MovVTip, T00322_A1244MovVSts
               }
               , new Object[] {
               T00323_A235MovVCod, T00323_A1243MovVDsc, T00323_A1242MovVAbr, T00323_A1245MovVTip, T00323_A1244MovVSts
               }
               , new Object[] {
               T00324_A235MovVCod, T00324_A1243MovVDsc, T00324_A1242MovVAbr, T00324_A1245MovVTip, T00324_A1244MovVSts
               }
               , new Object[] {
               T00325_A235MovVCod
               }
               , new Object[] {
               T00326_A235MovVCod
               }
               , new Object[] {
               T00327_A235MovVCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003211_A149TipCod, T003211_A24DocNum
               }
               , new Object[] {
               T003212_A235MovVCod
               }
            }
         );
      }

      private short Z1244MovVSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1244MovVSts ;
      private short GX_JID ;
      private short RcdFound105 ;
      private short nIsDirty_105 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1244MovVSts ;
      private int Z235MovVCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A235MovVCod ;
      private int edtMovVCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMovVDsc_Enabled ;
      private int edtMovVAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ235MovVCod ;
      private string sPrefix ;
      private string Z1243MovVDsc ;
      private string Z1242MovVAbr ;
      private string Z1245MovVTip ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMovVCod_Internalname ;
      private string A1245MovVTip ;
      private string cmbMovVTip_Internalname ;
      private string cmbMovVSts_Internalname ;
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
      private string edtMovVCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMovVDsc_Internalname ;
      private string A1243MovVDsc ;
      private string edtMovVDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMovVAbr_Internalname ;
      private string A1242MovVAbr ;
      private string edtMovVAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbMovVTip_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbMovVSts_Jsonclick ;
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
      private string sMode105 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1243MovVDsc ;
      private string ZZ1242MovVAbr ;
      private string ZZ1245MovVTip ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMovVTip ;
      private GXCombobox cmbMovVSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00324_A235MovVCod ;
      private string[] T00324_A1243MovVDsc ;
      private string[] T00324_A1242MovVAbr ;
      private string[] T00324_A1245MovVTip ;
      private short[] T00324_A1244MovVSts ;
      private int[] T00325_A235MovVCod ;
      private int[] T00323_A235MovVCod ;
      private string[] T00323_A1243MovVDsc ;
      private string[] T00323_A1242MovVAbr ;
      private string[] T00323_A1245MovVTip ;
      private short[] T00323_A1244MovVSts ;
      private int[] T00326_A235MovVCod ;
      private int[] T00327_A235MovVCod ;
      private int[] T00322_A235MovVCod ;
      private string[] T00322_A1243MovVDsc ;
      private string[] T00322_A1242MovVAbr ;
      private string[] T00322_A1245MovVTip ;
      private short[] T00322_A1244MovVSts ;
      private string[] T003211_A149TipCod ;
      private string[] T003211_A24DocNum ;
      private int[] T003212_A235MovVCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cmovventas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cmovventas__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00324;
        prmT00324 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00325;
        prmT00325 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00323;
        prmT00323 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00326;
        prmT00326 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00327;
        prmT00327 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00322;
        prmT00322 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT00328;
        prmT00328 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0) ,
        new ParDef("@MovVDsc",GXType.NChar,100,0) ,
        new ParDef("@MovVAbr",GXType.NChar,5,0) ,
        new ParDef("@MovVTip",GXType.NChar,1,0) ,
        new ParDef("@MovVSts",GXType.Int16,1,0)
        };
        Object[] prmT00329;
        prmT00329 = new Object[] {
        new ParDef("@MovVDsc",GXType.NChar,100,0) ,
        new ParDef("@MovVAbr",GXType.NChar,5,0) ,
        new ParDef("@MovVTip",GXType.NChar,1,0) ,
        new ParDef("@MovVSts",GXType.Int16,1,0) ,
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT003210;
        prmT003210 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT003211;
        prmT003211 = new Object[] {
        new ParDef("@MovVCod",GXType.Int32,6,0)
        };
        Object[] prmT003212;
        prmT003212 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00322", "SELECT [MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts] FROM [CMOVVENTAS] WITH (UPDLOCK) WHERE [MovVCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00322,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00323", "SELECT [MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts] FROM [CMOVVENTAS] WHERE [MovVCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00323,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00324", "SELECT TM1.[MovVCod], TM1.[MovVDsc], TM1.[MovVAbr], TM1.[MovVTip], TM1.[MovVSts] FROM [CMOVVENTAS] TM1 WHERE TM1.[MovVCod] = @MovVCod ORDER BY TM1.[MovVCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00324,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00325", "SELECT [MovVCod] FROM [CMOVVENTAS] WHERE [MovVCod] = @MovVCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00325,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00326", "SELECT TOP 1 [MovVCod] FROM [CMOVVENTAS] WHERE ( [MovVCod] > @MovVCod) ORDER BY [MovVCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00326,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00327", "SELECT TOP 1 [MovVCod] FROM [CMOVVENTAS] WHERE ( [MovVCod] < @MovVCod) ORDER BY [MovVCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00327,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00328", "INSERT INTO [CMOVVENTAS]([MovVCod], [MovVDsc], [MovVAbr], [MovVTip], [MovVSts]) VALUES(@MovVCod, @MovVDsc, @MovVAbr, @MovVTip, @MovVSts)", GxErrorMask.GX_NOMASK,prmT00328)
           ,new CursorDef("T00329", "UPDATE [CMOVVENTAS] SET [MovVDsc]=@MovVDsc, [MovVAbr]=@MovVAbr, [MovVTip]=@MovVTip, [MovVSts]=@MovVSts  WHERE [MovVCod] = @MovVCod", GxErrorMask.GX_NOMASK,prmT00329)
           ,new CursorDef("T003210", "DELETE FROM [CMOVVENTAS]  WHERE [MovVCod] = @MovVCod", GxErrorMask.GX_NOMASK,prmT003210)
           ,new CursorDef("T003211", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocMovCod] = @MovVCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003212", "SELECT [MovVCod] FROM [CMOVVENTAS] ORDER BY [MovVCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003212,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
