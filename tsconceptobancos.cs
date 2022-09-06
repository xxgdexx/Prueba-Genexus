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
   public class tsconceptobancos : GXHttpHandler
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
            A374ConBCueCod = GetPar( "ConBCueCod");
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A374ConBCueCod) ;
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
            Form.Meta.addItem("description", "Conceptos de Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsconceptobancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsconceptobancos( IGxContext context )
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
         cmbConBSts = new GXCombobox();
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
         if ( cmbConBSts.ItemCount > 0 )
         {
            A746ConBSts = (short)(NumberUtil.Val( cmbConBSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0))), "."));
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            AssignProp("", false, cmbConBSts_Internalname, "Values", cmbConBSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm54171( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSCONCEPTOBANCOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A355ConBCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConBCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Concepto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBDsc_Internalname, StringUtil.RTrim( A745ConBDsc), StringUtil.RTrim( context.localUtil.Format( A745ConBDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cuenta", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBCueCod_Internalname, StringUtil.RTrim( A374ConBCueCod), StringUtil.RTrim( context.localUtil.Format( A374ConBCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConBSts, cmbConBSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0)), 1, cmbConBSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConBSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_TSCONCEPTOBANCOS.htm");
         cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         AssignProp("", false, cmbConBSts_Internalname, "Values", (string)(cmbConBSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Descripción", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtConBCueDsc_Internalname, StringUtil.RTrim( A744ConBCueDsc), StringUtil.RTrim( context.localUtil.Format( A744ConBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCONCEPTOBANCOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSCONCEPTOBANCOS.htm");
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
            Z355ConBCod = (int)(context.localUtil.CToN( cgiGet( "Z355ConBCod"), ".", ","));
            Z745ConBDsc = cgiGet( "Z745ConBDsc");
            Z746ConBSts = (short)(context.localUtil.CToN( cgiGet( "Z746ConBSts"), ".", ","));
            Z374ConBCueCod = cgiGet( "Z374ConBCueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONBCOD");
               AnyError = 1;
               GX_FocusControl = edtConBCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A355ConBCod = 0;
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            }
            else
            {
               A355ConBCod = (int)(context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ","));
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            }
            A745ConBDsc = cgiGet( edtConBDsc_Internalname);
            AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
            A374ConBCueCod = cgiGet( edtConBCueCod_Internalname);
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            cmbConBSts.CurrentValue = cgiGet( cmbConBSts_Internalname);
            A746ConBSts = (short)(NumberUtil.Val( cgiGet( cmbConBSts_Internalname), "."));
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            A744ConBCueDsc = cgiGet( edtConBCueDsc_Internalname);
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
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
               A355ConBCod = (int)(NumberUtil.Val( GetPar( "ConBCod"), "."));
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
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
               InitAll54171( ) ;
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
         DisableAttributes54171( ) ;
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

      protected void CONFIRM_540( )
      {
         BeforeValidate54171( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls54171( ) ;
            }
            else
            {
               CheckExtendedTable54171( ) ;
               if ( AnyError == 0 )
               {
                  ZM54171( 2) ;
               }
               CloseExtendedTableCursors54171( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues540( ) ;
         }
      }

      protected void ResetCaption540( )
      {
      }

      protected void ZM54171( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z745ConBDsc = T00543_A745ConBDsc[0];
               Z746ConBSts = T00543_A746ConBSts[0];
               Z374ConBCueCod = T00543_A374ConBCueCod[0];
            }
            else
            {
               Z745ConBDsc = A745ConBDsc;
               Z746ConBSts = A746ConBSts;
               Z374ConBCueCod = A374ConBCueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z355ConBCod = A355ConBCod;
            Z745ConBDsc = A745ConBDsc;
            Z746ConBSts = A746ConBSts;
            Z374ConBCueCod = A374ConBCueCod;
            Z744ConBCueDsc = A744ConBCueDsc;
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

      protected void Load54171( )
      {
         /* Using cursor T00545 */
         pr_default.execute(3, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound171 = 1;
            A745ConBDsc = T00545_A745ConBDsc[0];
            AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
            A746ConBSts = T00545_A746ConBSts[0];
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            A744ConBCueDsc = T00545_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            A374ConBCueCod = T00545_A374ConBCueCod[0];
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            ZM54171( -1) ;
         }
         pr_default.close(3);
         OnLoadActions54171( ) ;
      }

      protected void OnLoadActions54171( )
      {
      }

      protected void CheckExtendedTable54171( )
      {
         nIsDirty_171 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00544 */
         pr_default.execute(2, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A744ConBCueDsc = T00544_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors54171( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A374ConBCueCod )
      {
         /* Using cursor T00546 */
         pr_default.execute(4, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A744ConBCueDsc = T00546_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A744ConBCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey54171( )
      {
         /* Using cursor T00547 */
         pr_default.execute(5, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound171 = 1;
         }
         else
         {
            RcdFound171 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00543 */
         pr_default.execute(1, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM54171( 1) ;
            RcdFound171 = 1;
            A355ConBCod = T00543_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            A745ConBDsc = T00543_A745ConBDsc[0];
            AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
            A746ConBSts = T00543_A746ConBSts[0];
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
            A374ConBCueCod = T00543_A374ConBCueCod[0];
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            Z355ConBCod = A355ConBCod;
            sMode171 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load54171( ) ;
            if ( AnyError == 1 )
            {
               RcdFound171 = 0;
               InitializeNonKey54171( ) ;
            }
            Gx_mode = sMode171;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound171 = 0;
            InitializeNonKey54171( ) ;
            sMode171 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode171;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey54171( ) ;
         if ( RcdFound171 == 0 )
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
         RcdFound171 = 0;
         /* Using cursor T00548 */
         pr_default.execute(6, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00548_A355ConBCod[0] < A355ConBCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00548_A355ConBCod[0] > A355ConBCod ) ) )
            {
               A355ConBCod = T00548_A355ConBCod[0];
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               RcdFound171 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound171 = 0;
         /* Using cursor T00549 */
         pr_default.execute(7, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00549_A355ConBCod[0] > A355ConBCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00549_A355ConBCod[0] < A355ConBCod ) ) )
            {
               A355ConBCod = T00549_A355ConBCod[0];
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               RcdFound171 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey54171( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert54171( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound171 == 1 )
            {
               if ( A355ConBCod != Z355ConBCod )
               {
                  A355ConBCod = Z355ConBCod;
                  AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update54171( ) ;
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A355ConBCod != Z355ConBCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtConBCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert54171( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONBCOD");
                     AnyError = 1;
                     GX_FocusControl = edtConBCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtConBCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert54171( ) ;
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
         if ( A355ConBCod != Z355ConBCod )
         {
            A355ConBCod = Z355ConBCod;
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConBCod_Internalname;
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
         GetKey54171( ) ;
         if ( RcdFound171 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CONBCOD");
               AnyError = 1;
               GX_FocusControl = edtConBCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A355ConBCod != Z355ConBCod )
            {
               A355ConBCod = Z355ConBCod;
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CONBCOD");
               AnyError = 1;
               GX_FocusControl = edtConBCod_Internalname;
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
            if ( A355ConBCod != Z355ConBCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONBCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConBCod_Internalname;
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
         context.RollbackDataStores("tsconceptobancos",pr_default);
         GX_FocusControl = edtConBDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_540( ) ;
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
         if ( RcdFound171 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtConBDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart54171( ) ;
         if ( RcdFound171 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConBDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd54171( ) ;
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
         if ( RcdFound171 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConBDsc_Internalname;
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
         if ( RcdFound171 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConBDsc_Internalname;
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
         ScanStart54171( ) ;
         if ( RcdFound171 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound171 != 0 )
            {
               ScanNext54171( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConBDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd54171( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency54171( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00542 */
            pr_default.execute(0, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z745ConBDsc, T00542_A745ConBDsc[0]) != 0 ) || ( Z746ConBSts != T00542_A746ConBSts[0] ) || ( StringUtil.StrCmp(Z374ConBCueCod, T00542_A374ConBCueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z745ConBDsc, T00542_A745ConBDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsconceptobancos:[seudo value changed for attri]"+"ConBDsc");
                  GXUtil.WriteLogRaw("Old: ",Z745ConBDsc);
                  GXUtil.WriteLogRaw("Current: ",T00542_A745ConBDsc[0]);
               }
               if ( Z746ConBSts != T00542_A746ConBSts[0] )
               {
                  GXUtil.WriteLog("tsconceptobancos:[seudo value changed for attri]"+"ConBSts");
                  GXUtil.WriteLogRaw("Old: ",Z746ConBSts);
                  GXUtil.WriteLogRaw("Current: ",T00542_A746ConBSts[0]);
               }
               if ( StringUtil.StrCmp(Z374ConBCueCod, T00542_A374ConBCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsconceptobancos:[seudo value changed for attri]"+"ConBCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z374ConBCueCod);
                  GXUtil.WriteLogRaw("Current: ",T00542_A374ConBCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert54171( )
      {
         BeforeValidate54171( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable54171( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM54171( 0) ;
            CheckOptimisticConcurrency54171( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm54171( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert54171( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005410 */
                     pr_default.execute(8, new Object[] {A355ConBCod, A745ConBDsc, A746ConBSts, A374ConBCueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
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
                           ResetCaption540( ) ;
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
               Load54171( ) ;
            }
            EndLevel54171( ) ;
         }
         CloseExtendedTableCursors54171( ) ;
      }

      protected void Update54171( )
      {
         BeforeValidate54171( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable54171( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency54171( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm54171( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate54171( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005411 */
                     pr_default.execute(9, new Object[] {A745ConBDsc, A746ConBSts, A374ConBCueCod, A355ConBCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate54171( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption540( ) ;
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
            EndLevel54171( ) ;
         }
         CloseExtendedTableCursors54171( ) ;
      }

      protected void DeferredUpdate54171( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate54171( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency54171( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls54171( ) ;
            AfterConfirm54171( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete54171( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005412 */
                  pr_default.execute(10, new Object[] {A355ConBCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOBANCOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound171 == 0 )
                        {
                           InitAll54171( ) ;
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
                        ResetCaption540( ) ;
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
         sMode171 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel54171( ) ;
         Gx_mode = sMode171;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls54171( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005413 */
            pr_default.execute(11, new Object[] {A374ConBCueCod});
            A744ConBCueDsc = T005413_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005414 */
            pr_default.execute(12, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005415 */
            pr_default.execute(13, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005416 */
            pr_default.execute(14, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005417 */
            pr_default.execute(15, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005418 */
            pr_default.execute(16, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005419 */
            pr_default.execute(17, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005420 */
            pr_default.execute(18, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005421 */
            pr_default.execute(19, new Object[] {A355ConBCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel54171( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete54171( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("tsconceptobancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues540( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("tsconceptobancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart54171( )
      {
         /* Using cursor T005422 */
         pr_default.execute(20);
         RcdFound171 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound171 = 1;
            A355ConBCod = T005422_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext54171( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound171 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound171 = 1;
            A355ConBCod = T005422_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         }
      }

      protected void ScanEnd54171( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm54171( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert54171( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate54171( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete54171( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete54171( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate54171( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes54171( )
      {
         edtConBCod_Enabled = 0;
         AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         edtConBDsc_Enabled = 0;
         AssignProp("", false, edtConBDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBDsc_Enabled), 5, 0), true);
         edtConBCueCod_Enabled = 0;
         AssignProp("", false, edtConBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueCod_Enabled), 5, 0), true);
         cmbConBSts.Enabled = 0;
         AssignProp("", false, cmbConBSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConBSts.Enabled), 5, 0), true);
         edtConBCueDsc_Enabled = 0;
         AssignProp("", false, edtConBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes54171( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues540( )
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
         context.SendWebValue( "Conceptos de Bancos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255045", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsconceptobancos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z745ConBDsc", StringUtil.RTrim( Z745ConBDsc));
         GxWebStd.gx_hidden_field( context, "Z746ConBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z746ConBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z374ConBCueCod", StringUtil.RTrim( Z374ConBCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm54171( )
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
         return "TSCONCEPTOBANCOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Bancos" ;
      }

      protected void InitializeNonKey54171( )
      {
         A745ConBDsc = "";
         AssignAttri("", false, "A745ConBDsc", A745ConBDsc);
         A374ConBCueCod = "";
         AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
         A746ConBSts = 0;
         AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         A744ConBCueDsc = "";
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         Z745ConBDsc = "";
         Z746ConBSts = 0;
         Z374ConBCueCod = "";
      }

      protected void InitAll54171( )
      {
         A355ConBCod = 0;
         AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         InitializeNonKey54171( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255051", true, true);
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
         context.AddJavascriptSource("tsconceptobancos.js", "?202281810255051", false, true);
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
         edtConBCod_Internalname = "CONBCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtConBDsc_Internalname = "CONBDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtConBCueCod_Internalname = "CONBCUECOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbConBSts_Internalname = "CONBSTS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtConBCueDsc_Internalname = "CONBCUEDSC";
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
         edtConBCueDsc_Jsonclick = "";
         edtConBCueDsc_Enabled = 0;
         cmbConBSts_Jsonclick = "";
         cmbConBSts.Enabled = 1;
         edtConBCueCod_Jsonclick = "";
         edtConBCueCod_Enabled = 1;
         edtConBDsc_Jsonclick = "";
         edtConBDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtConBCod_Jsonclick = "";
         edtConBCod_Enabled = 1;
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
         cmbConBSts.Name = "CONBSTS";
         cmbConBSts.WebTags = "";
         cmbConBSts.addItem("1", "ACTIVO", 0);
         cmbConBSts.addItem("0", "INACTIVO", 0);
         if ( cmbConBSts.ItemCount > 0 )
         {
            A746ConBSts = (short)(NumberUtil.Val( cmbConBSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0))), "."));
            AssignAttri("", false, "A746ConBSts", StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtConBDsc_Internalname;
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

      public void Valid_Conbcod( )
      {
         A746ConBSts = (short)(NumberUtil.Val( cmbConBSts.CurrentValue, "."));
         cmbConBSts.CurrentValue = StringUtil.Str( (decimal)(A746ConBSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbConBSts.ItemCount > 0 )
         {
            A746ConBSts = (short)(NumberUtil.Val( cmbConBSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0))), "."));
            cmbConBSts.CurrentValue = StringUtil.Str( (decimal)(A746ConBSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A745ConBDsc", StringUtil.RTrim( A745ConBDsc));
         AssignAttri("", false, "A374ConBCueCod", StringUtil.RTrim( A374ConBCueCod));
         AssignAttri("", false, "A746ConBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ConBSts), 1, 0, ".", "")));
         cmbConBSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A746ConBSts), 1, 0));
         AssignProp("", false, cmbConBSts_Internalname, "Values", cmbConBSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A744ConBCueDsc", StringUtil.RTrim( A744ConBCueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z745ConBDsc", StringUtil.RTrim( Z745ConBDsc));
         GxWebStd.gx_hidden_field( context, "Z374ConBCueCod", StringUtil.RTrim( Z374ConBCueCod));
         GxWebStd.gx_hidden_field( context, "Z746ConBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z746ConBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z744ConBCueDsc", StringUtil.RTrim( Z744ConBCueDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Conbcuecod( )
      {
         /* Using cursor T005413 */
         pr_default.execute(11, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtConBCueCod_Internalname;
         }
         A744ConBCueDsc = T005413_A744ConBCueDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A744ConBCueDsc", StringUtil.RTrim( A744ConBCueDsc));
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
         setEventMetadata("VALID_CONBCOD","{handler:'Valid_Conbcod',iparms:[{av:'cmbConBSts'},{av:'A746ConBSts',fld:'CONBSTS',pic:'9'},{av:'A355ConBCod',fld:'CONBCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CONBCOD",",oparms:[{av:'A745ConBDsc',fld:'CONBDSC',pic:''},{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'cmbConBSts'},{av:'A746ConBSts',fld:'CONBSTS',pic:'9'},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z355ConBCod'},{av:'Z745ConBDsc'},{av:'Z374ConBCueCod'},{av:'Z746ConBSts'},{av:'Z744ConBCueDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CONBCUECOD","{handler:'Valid_Conbcuecod',iparms:[{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]");
         setEventMetadata("VALID_CONBCUECOD",",oparms:[{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]}");
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
         Z745ConBDsc = "";
         Z374ConBCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A374ConBCueCod = "";
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
         A745ConBDsc = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A744ConBCueDsc = "";
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
         Z744ConBCueDsc = "";
         T00545_A355ConBCod = new int[1] ;
         T00545_A745ConBDsc = new string[] {""} ;
         T00545_A746ConBSts = new short[1] ;
         T00545_A744ConBCueDsc = new string[] {""} ;
         T00545_A374ConBCueCod = new string[] {""} ;
         T00544_A744ConBCueDsc = new string[] {""} ;
         T00546_A744ConBCueDsc = new string[] {""} ;
         T00547_A355ConBCod = new int[1] ;
         T00543_A355ConBCod = new int[1] ;
         T00543_A745ConBDsc = new string[] {""} ;
         T00543_A746ConBSts = new short[1] ;
         T00543_A374ConBCueCod = new string[] {""} ;
         sMode171 = "";
         T00548_A355ConBCod = new int[1] ;
         T00549_A355ConBCod = new int[1] ;
         T00542_A355ConBCod = new int[1] ;
         T00542_A745ConBDsc = new string[] {""} ;
         T00542_A746ConBSts = new short[1] ;
         T00542_A374ConBCueCod = new string[] {""} ;
         T005413_A744ConBCueDsc = new string[] {""} ;
         T005414_A379LBBanCod = new int[1] ;
         T005414_A380LBCBCod = new string[] {""} ;
         T005414_A381LBRegistro = new string[] {""} ;
         T005414_A383LBDITem = new int[1] ;
         T005415_A365EntCod = new int[1] ;
         T005415_A366AperEntCod = new string[] {""} ;
         T005416_A358CajCod = new int[1] ;
         T005416_A359AperCajCod = new string[] {""} ;
         T005417_A354TSAntCod = new string[] {""} ;
         T005418_A348UsuCod = new string[] {""} ;
         T005419_A270LiqCod = new string[] {""} ;
         T005419_A236LiqPrvCod = new string[] {""} ;
         T005419_A277LiqMItem = new int[1] ;
         T005420_A270LiqCod = new string[] {""} ;
         T005420_A236LiqPrvCod = new string[] {""} ;
         T005420_A271LiqCodItem = new int[1] ;
         T005421_A166CobTip = new string[] {""} ;
         T005421_A167CobCod = new string[] {""} ;
         T005422_A355ConBCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ745ConBDsc = "";
         ZZ374ConBCueCod = "";
         ZZ744ConBCueDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsconceptobancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsconceptobancos__default(),
            new Object[][] {
                new Object[] {
               T00542_A355ConBCod, T00542_A745ConBDsc, T00542_A746ConBSts, T00542_A374ConBCueCod
               }
               , new Object[] {
               T00543_A355ConBCod, T00543_A745ConBDsc, T00543_A746ConBSts, T00543_A374ConBCueCod
               }
               , new Object[] {
               T00544_A744ConBCueDsc
               }
               , new Object[] {
               T00545_A355ConBCod, T00545_A745ConBDsc, T00545_A746ConBSts, T00545_A744ConBCueDsc, T00545_A374ConBCueCod
               }
               , new Object[] {
               T00546_A744ConBCueDsc
               }
               , new Object[] {
               T00547_A355ConBCod
               }
               , new Object[] {
               T00548_A355ConBCod
               }
               , new Object[] {
               T00549_A355ConBCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005413_A744ConBCueDsc
               }
               , new Object[] {
               T005414_A379LBBanCod, T005414_A380LBCBCod, T005414_A381LBRegistro, T005414_A383LBDITem
               }
               , new Object[] {
               T005415_A365EntCod, T005415_A366AperEntCod
               }
               , new Object[] {
               T005416_A358CajCod, T005416_A359AperCajCod
               }
               , new Object[] {
               T005417_A354TSAntCod
               }
               , new Object[] {
               T005418_A348UsuCod
               }
               , new Object[] {
               T005419_A270LiqCod, T005419_A236LiqPrvCod, T005419_A277LiqMItem
               }
               , new Object[] {
               T005420_A270LiqCod, T005420_A236LiqPrvCod, T005420_A271LiqCodItem
               }
               , new Object[] {
               T005421_A166CobTip, T005421_A167CobCod
               }
               , new Object[] {
               T005422_A355ConBCod
               }
            }
         );
      }

      private short Z746ConBSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A746ConBSts ;
      private short GX_JID ;
      private short RcdFound171 ;
      private short nIsDirty_171 ;
      private short Gx_BScreen ;
      private short ZZ746ConBSts ;
      private int Z355ConBCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A355ConBCod ;
      private int edtConBCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtConBDsc_Enabled ;
      private int edtConBCueCod_Enabled ;
      private int edtConBCueDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ355ConBCod ;
      private string sPrefix ;
      private string Z745ConBDsc ;
      private string Z374ConBCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A374ConBCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConBCod_Internalname ;
      private string cmbConBSts_Internalname ;
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
      private string edtConBCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtConBDsc_Internalname ;
      private string A745ConBDsc ;
      private string edtConBDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtConBCueCod_Internalname ;
      private string edtConBCueCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbConBSts_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtConBCueDsc_Internalname ;
      private string A744ConBCueDsc ;
      private string edtConBCueDsc_Jsonclick ;
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
      private string Z744ConBCueDsc ;
      private string sMode171 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ745ConBDsc ;
      private string ZZ374ConBCueCod ;
      private string ZZ744ConBCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConBSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00545_A355ConBCod ;
      private string[] T00545_A745ConBDsc ;
      private short[] T00545_A746ConBSts ;
      private string[] T00545_A744ConBCueDsc ;
      private string[] T00545_A374ConBCueCod ;
      private string[] T00544_A744ConBCueDsc ;
      private string[] T00546_A744ConBCueDsc ;
      private int[] T00547_A355ConBCod ;
      private int[] T00543_A355ConBCod ;
      private string[] T00543_A745ConBDsc ;
      private short[] T00543_A746ConBSts ;
      private string[] T00543_A374ConBCueCod ;
      private int[] T00548_A355ConBCod ;
      private int[] T00549_A355ConBCod ;
      private int[] T00542_A355ConBCod ;
      private string[] T00542_A745ConBDsc ;
      private short[] T00542_A746ConBSts ;
      private string[] T00542_A374ConBCueCod ;
      private string[] T005413_A744ConBCueDsc ;
      private int[] T005414_A379LBBanCod ;
      private string[] T005414_A380LBCBCod ;
      private string[] T005414_A381LBRegistro ;
      private int[] T005414_A383LBDITem ;
      private int[] T005415_A365EntCod ;
      private string[] T005415_A366AperEntCod ;
      private int[] T005416_A358CajCod ;
      private string[] T005416_A359AperCajCod ;
      private string[] T005417_A354TSAntCod ;
      private string[] T005418_A348UsuCod ;
      private string[] T005419_A270LiqCod ;
      private string[] T005419_A236LiqPrvCod ;
      private int[] T005419_A277LiqMItem ;
      private string[] T005420_A270LiqCod ;
      private string[] T005420_A236LiqPrvCod ;
      private int[] T005420_A271LiqCodItem ;
      private string[] T005421_A166CobTip ;
      private string[] T005421_A167CobCod ;
      private int[] T005422_A355ConBCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tsconceptobancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsconceptobancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00545;
        prmT00545 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT00544;
        prmT00544 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00546;
        prmT00546 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00547;
        prmT00547 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT00543;
        prmT00543 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT00548;
        prmT00548 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT00549;
        prmT00549 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT00542;
        prmT00542 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005410;
        prmT005410 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0) ,
        new ParDef("@ConBDsc",GXType.NChar,100,0) ,
        new ParDef("@ConBSts",GXType.Int16,1,0) ,
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005411;
        prmT005411 = new Object[] {
        new ParDef("@ConBDsc",GXType.NChar,100,0) ,
        new ParDef("@ConBSts",GXType.Int16,1,0) ,
        new ParDef("@ConBCueCod",GXType.NChar,15,0) ,
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005412;
        prmT005412 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005414;
        prmT005414 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005415;
        prmT005415 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005416;
        prmT005416 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005417;
        prmT005417 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005418;
        prmT005418 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005419;
        prmT005419 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005420;
        prmT005420 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005421;
        prmT005421 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT005422;
        prmT005422 = new Object[] {
        };
        Object[] prmT005413;
        prmT005413 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00542", "SELECT [ConBCod], [ConBDsc], [ConBSts], [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WITH (UPDLOCK) WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00542,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00543", "SELECT [ConBCod], [ConBDsc], [ConBSts], [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00543,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00544", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00544,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00545", "SELECT TM1.[ConBCod], TM1.[ConBDsc], TM1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, TM1.[ConBCueCod] AS ConBCueCod FROM ([TSCONCEPTOBANCOS] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[ConBCueCod]) WHERE TM1.[ConBCod] = @ConBCod ORDER BY TM1.[ConBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00545,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00546", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00546,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00547", "SELECT [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00547,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00548", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE ( [ConBCod] > @ConBCod) ORDER BY [ConBCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00548,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00549", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE ( [ConBCod] < @ConBCod) ORDER BY [ConBCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00549,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005410", "INSERT INTO [TSCONCEPTOBANCOS]([ConBCod], [ConBDsc], [ConBSts], [ConBCueCod]) VALUES(@ConBCod, @ConBDsc, @ConBSts, @ConBCueCod)", GxErrorMask.GX_NOMASK,prmT005410)
           ,new CursorDef("T005411", "UPDATE [TSCONCEPTOBANCOS] SET [ConBDsc]=@ConBDsc, [ConBSts]=@ConBSts, [ConBCueCod]=@ConBCueCod  WHERE [ConBCod] = @ConBCod", GxErrorMask.GX_NOMASK,prmT005411)
           ,new CursorDef("T005412", "DELETE FROM [TSCONCEPTOBANCOS]  WHERE [ConBCod] = @ConBCod", GxErrorMask.GX_NOMASK,prmT005412)
           ,new CursorDef("T005413", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005414", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBConBan] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005414,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005415", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperETmov] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005415,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005416", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperTmov] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005416,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005417", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005417,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005418", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosConcepto] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005418,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005419", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE [LiqMTMovCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005419,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005420", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqTMovCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005420,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005421", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005421,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005422", "SELECT [ConBCod] FROM [TSCONCEPTOBANCOS] ORDER BY [ConBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005422,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
