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
   public class cdistritos : GXHttpHandler
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
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A139PaiCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A139PaiCod = GetPar( "PaiCod");
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = GetPar( "EstCod");
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = GetPar( "ProvCod");
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A139PaiCod, A140EstCod, A141ProvCod) ;
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
            Form.Meta.addItem("description", "Distritos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cdistritos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cdistritos( IGxContext context )
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
         cmbDisSts = new GXCombobox();
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
         if ( cmbDisSts.ItemCount > 0 )
         {
            A878DisSts = (short)(NumberUtil.Val( cmbDisSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0))), "."));
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            AssignProp("", false, cmbDisSts_Internalname, "Values", cmbDisSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2877( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CDISTRITOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pais", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Departamento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Provincia", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProvCod_Internalname, StringUtil.RTrim( A141ProvCod), StringUtil.RTrim( context.localUtil.Format( A141ProvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProvCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Distrito", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisCod_Internalname, StringUtil.RTrim( A142DisCod), StringUtil.RTrim( context.localUtil.Format( A142DisCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Distrito", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisDsc_Internalname, StringUtil.RTrim( A604DisDsc), StringUtil.RTrim( context.localUtil.Format( A604DisDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Abrv. Distrito", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDisAbr_Internalname, StringUtil.RTrim( A877DisAbr), StringUtil.RTrim( context.localUtil.Format( A877DisAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDisAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDisAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CDISTRITOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDisSts, cmbDisSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0)), 1, cmbDisSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbDisSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 1, "HLP_CDISTRITOS.htm");
         cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         AssignProp("", false, cmbDisSts_Internalname, "Values", (string)(cmbDisSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CDISTRITOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CDISTRITOS.htm");
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
            Z139PaiCod = cgiGet( "Z139PaiCod");
            Z140EstCod = cgiGet( "Z140EstCod");
            Z141ProvCod = cgiGet( "Z141ProvCod");
            Z142DisCod = cgiGet( "Z142DisCod");
            Z604DisDsc = cgiGet( "Z604DisDsc");
            Z877DisAbr = cgiGet( "Z877DisAbr");
            Z878DisSts = (short)(context.localUtil.CToN( cgiGet( "Z878DisSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1500PaiDsc = cgiGet( "PAIDSC");
            /* Read variables values. */
            A139PaiCod = cgiGet( edtPaiCod_Internalname);
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = cgiGet( edtEstCod_Internalname);
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = cgiGet( edtProvCod_Internalname);
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = cgiGet( edtDisCod_Internalname);
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A604DisDsc = cgiGet( edtDisDsc_Internalname);
            AssignAttri("", false, "A604DisDsc", A604DisDsc);
            A877DisAbr = cgiGet( edtDisAbr_Internalname);
            AssignAttri("", false, "A877DisAbr", A877DisAbr);
            cmbDisSts.CurrentValue = cgiGet( cmbDisSts_Internalname);
            A878DisSts = (short)(NumberUtil.Val( cgiGet( cmbDisSts_Internalname), "."));
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
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
               A139PaiCod = GetPar( "PaiCod");
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = GetPar( "EstCod");
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = GetPar( "ProvCod");
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = GetPar( "DisCod");
               AssignAttri("", false, "A142DisCod", A142DisCod);
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
               InitAll2877( ) ;
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
         DisableAttributes2877( ) ;
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

      protected void CONFIRM_280( )
      {
         BeforeValidate2877( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2877( ) ;
            }
            else
            {
               CheckExtendedTable2877( ) ;
               if ( AnyError == 0 )
               {
                  ZM2877( 2) ;
                  ZM2877( 3) ;
               }
               CloseExtendedTableCursors2877( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues280( ) ;
         }
      }

      protected void ResetCaption280( )
      {
      }

      protected void ZM2877( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z604DisDsc = T00283_A604DisDsc[0];
               Z877DisAbr = T00283_A877DisAbr[0];
               Z878DisSts = T00283_A878DisSts[0];
            }
            else
            {
               Z604DisDsc = A604DisDsc;
               Z877DisAbr = A877DisAbr;
               Z878DisSts = A878DisSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z142DisCod = A142DisCod;
            Z604DisDsc = A604DisDsc;
            Z877DisAbr = A877DisAbr;
            Z878DisSts = A878DisSts;
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z1500PaiDsc = A1500PaiDsc;
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

      protected void Load2877( )
      {
         /* Using cursor T00286 */
         pr_default.execute(4, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound77 = 1;
            A1500PaiDsc = T00286_A1500PaiDsc[0];
            A604DisDsc = T00286_A604DisDsc[0];
            AssignAttri("", false, "A604DisDsc", A604DisDsc);
            A877DisAbr = T00286_A877DisAbr[0];
            AssignAttri("", false, "A877DisAbr", A877DisAbr);
            A878DisSts = T00286_A878DisSts[0];
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            ZM2877( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2877( ) ;
      }

      protected void OnLoadActions2877( )
      {
      }

      protected void CheckExtendedTable2877( )
      {
         nIsDirty_77 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00284 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T00284_A1500PaiDsc[0];
         pr_default.close(2);
         /* Using cursor T00285 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2877( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A139PaiCod )
      {
         /* Using cursor T00287 */
         pr_default.execute(5, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T00287_A1500PaiDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1500PaiDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A139PaiCod ,
                               string A140EstCod ,
                               string A141ProvCod )
      {
         /* Using cursor T00288 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2877( )
      {
         /* Using cursor T00289 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00283 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2877( 1) ;
            RcdFound77 = 1;
            A142DisCod = T00283_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
            A604DisDsc = T00283_A604DisDsc[0];
            AssignAttri("", false, "A604DisDsc", A604DisDsc);
            A877DisAbr = T00283_A877DisAbr[0];
            AssignAttri("", false, "A877DisAbr", A877DisAbr);
            A878DisSts = T00283_A878DisSts[0];
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
            A139PaiCod = T00283_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T00283_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T00283_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            Z141ProvCod = A141ProvCod;
            Z142DisCod = A142DisCod;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2877( ) ;
            if ( AnyError == 1 )
            {
               RcdFound77 = 0;
               InitializeNonKey2877( ) ;
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey2877( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2877( ) ;
         if ( RcdFound77 == 0 )
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
         RcdFound77 = 0;
         /* Using cursor T002810 */
         pr_default.execute(8, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A141ProvCod[0], A141ProvCod) < 0 ) || ( StringUtil.StrCmp(T002810_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A142DisCod[0], A142DisCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A141ProvCod[0], A141ProvCod) > 0 ) || ( StringUtil.StrCmp(T002810_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T002810_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002810_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002810_A142DisCod[0], A142DisCod) > 0 ) ) )
            {
               A139PaiCod = T002810_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T002810_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T002810_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = T002810_A142DisCod[0];
               AssignAttri("", false, "A142DisCod", A142DisCod);
               RcdFound77 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound77 = 0;
         /* Using cursor T002811 */
         pr_default.execute(9, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) > 0 ) || ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A141ProvCod[0], A141ProvCod) > 0 ) || ( StringUtil.StrCmp(T002811_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A142DisCod[0], A142DisCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) < 0 ) || ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A141ProvCod[0], A141ProvCod) < 0 ) || ( StringUtil.StrCmp(T002811_A141ProvCod[0], A141ProvCod) == 0 ) && ( StringUtil.StrCmp(T002811_A140EstCod[0], A140EstCod) == 0 ) && ( StringUtil.StrCmp(T002811_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002811_A142DisCod[0], A142DisCod) < 0 ) ) )
            {
               A139PaiCod = T002811_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T002811_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = T002811_A141ProvCod[0];
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = T002811_A142DisCod[0];
               AssignAttri("", false, "A142DisCod", A142DisCod);
               RcdFound77 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2877( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2877( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound77 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
                  A141ProvCod = Z141ProvCod;
                  AssignAttri("", false, "A141ProvCod", A141ProvCod);
                  A142DisCod = Z142DisCod;
                  AssignAttri("", false, "A142DisCod", A142DisCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAICOD");
                  AnyError = 1;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2877( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2877( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAICOD");
                     AnyError = 1;
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPaiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2877( ) ;
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
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = Z141ProvCod;
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = Z142DisCod;
            AssignAttri("", false, "A142DisCod", A142DisCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaiCod_Internalname;
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
         GetKey2877( ) ;
         if ( RcdFound77 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PAICOD");
               AnyError = 1;
               GX_FocusControl = edtPaiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
            {
               A139PaiCod = Z139PaiCod;
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = Z140EstCod;
               AssignAttri("", false, "A140EstCod", A140EstCod);
               A141ProvCod = Z141ProvCod;
               AssignAttri("", false, "A141ProvCod", A141ProvCod);
               A142DisCod = Z142DisCod;
               AssignAttri("", false, "A142DisCod", A142DisCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PAICOD");
               AnyError = 1;
               GX_FocusControl = edtPaiCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) || ( StringUtil.StrCmp(A141ProvCod, Z141ProvCod) != 0 ) || ( StringUtil.StrCmp(A142DisCod, Z142DisCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAICOD");
                  AnyError = 1;
                  GX_FocusControl = edtPaiCod_Internalname;
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
         context.RollbackDataStores("cdistritos",pr_default);
         GX_FocusControl = edtDisDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_280( ) ;
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
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtDisDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2877( ) ;
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDisDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2877( ) ;
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
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDisDsc_Internalname;
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
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDisDsc_Internalname;
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
         ScanStart2877( ) ;
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound77 != 0 )
            {
               ScanNext2877( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDisDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2877( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2877( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00282 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CDISTRITOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z604DisDsc, T00282_A604DisDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z877DisAbr, T00282_A877DisAbr[0]) != 0 ) || ( Z878DisSts != T00282_A878DisSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z604DisDsc, T00282_A604DisDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cdistritos:[seudo value changed for attri]"+"DisDsc");
                  GXUtil.WriteLogRaw("Old: ",Z604DisDsc);
                  GXUtil.WriteLogRaw("Current: ",T00282_A604DisDsc[0]);
               }
               if ( StringUtil.StrCmp(Z877DisAbr, T00282_A877DisAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cdistritos:[seudo value changed for attri]"+"DisAbr");
                  GXUtil.WriteLogRaw("Old: ",Z877DisAbr);
                  GXUtil.WriteLogRaw("Current: ",T00282_A877DisAbr[0]);
               }
               if ( Z878DisSts != T00282_A878DisSts[0] )
               {
                  GXUtil.WriteLog("cdistritos:[seudo value changed for attri]"+"DisSts");
                  GXUtil.WriteLogRaw("Old: ",Z878DisSts);
                  GXUtil.WriteLogRaw("Current: ",T00282_A878DisSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CDISTRITOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2877( )
      {
         BeforeValidate2877( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2877( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2877( 0) ;
            CheckOptimisticConcurrency2877( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2877( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2877( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002812 */
                     pr_default.execute(10, new Object[] {A142DisCod, A604DisDsc, A877DisAbr, A878DisSts, A139PaiCod, A140EstCod, A141ProvCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption280( ) ;
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
               Load2877( ) ;
            }
            EndLevel2877( ) ;
         }
         CloseExtendedTableCursors2877( ) ;
      }

      protected void Update2877( )
      {
         BeforeValidate2877( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2877( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2877( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2877( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2877( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002813 */
                     pr_default.execute(11, new Object[] {A604DisDsc, A877DisAbr, A878DisSts, A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CDISTRITOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2877( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption280( ) ;
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
            EndLevel2877( ) ;
         }
         CloseExtendedTableCursors2877( ) ;
      }

      protected void DeferredUpdate2877( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2877( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2877( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2877( ) ;
            AfterConfirm2877( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2877( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002814 */
                  pr_default.execute(12, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CDISTRITOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound77 == 0 )
                        {
                           InitAll2877( ) ;
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
                        ResetCaption280( ) ;
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2877( ) ;
         Gx_mode = sMode77;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2877( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002815 */
            pr_default.execute(13, new Object[] {A139PaiCod});
            A1500PaiDsc = T002815_A1500PaiDsc[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002816 */
            pr_default.execute(14, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002817 */
            pr_default.execute(15, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Almacen"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T002818 */
            pr_default.execute(16, new Object[] {A139PaiCod, A140EstCod, A141ProvCod, A142DisCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel2877( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2877( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cdistritos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues280( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cdistritos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2877( )
      {
         /* Using cursor T002819 */
         pr_default.execute(17);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound77 = 1;
            A139PaiCod = T002819_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002819_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T002819_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T002819_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2877( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound77 = 1;
            A139PaiCod = T002819_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002819_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A141ProvCod = T002819_A141ProvCod[0];
            AssignAttri("", false, "A141ProvCod", A141ProvCod);
            A142DisCod = T002819_A142DisCod[0];
            AssignAttri("", false, "A142DisCod", A142DisCod);
         }
      }

      protected void ScanEnd2877( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm2877( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2877( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2877( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2877( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2877( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2877( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2877( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtProvCod_Enabled = 0;
         AssignProp("", false, edtProvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProvCod_Enabled), 5, 0), true);
         edtDisCod_Enabled = 0;
         AssignProp("", false, edtDisCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisCod_Enabled), 5, 0), true);
         edtDisDsc_Enabled = 0;
         AssignProp("", false, edtDisDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisDsc_Enabled), 5, 0), true);
         edtDisAbr_Enabled = 0;
         AssignProp("", false, edtDisAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDisAbr_Enabled), 5, 0), true);
         cmbDisSts.Enabled = 0;
         AssignProp("", false, cmbDisSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDisSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2877( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues280( )
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
         context.SendWebValue( "Distritos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242630", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cdistritos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z604DisDsc", StringUtil.RTrim( Z604DisDsc));
         GxWebStd.gx_hidden_field( context, "Z877DisAbr", StringUtil.RTrim( Z877DisAbr));
         GxWebStd.gx_hidden_field( context, "Z878DisSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z878DisSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PAIDSC", StringUtil.RTrim( A1500PaiDsc));
      }

      protected void RenderHtmlCloseForm2877( )
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
         return "CDISTRITOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Distritos" ;
      }

      protected void InitializeNonKey2877( )
      {
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A604DisDsc = "";
         AssignAttri("", false, "A604DisDsc", A604DisDsc);
         A877DisAbr = "";
         AssignAttri("", false, "A877DisAbr", A877DisAbr);
         A878DisSts = 0;
         AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         Z604DisDsc = "";
         Z877DisAbr = "";
         Z878DisSts = 0;
      }

      protected void InitAll2877( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         A141ProvCod = "";
         AssignAttri("", false, "A141ProvCod", A141ProvCod);
         A142DisCod = "";
         AssignAttri("", false, "A142DisCod", A142DisCod);
         InitializeNonKey2877( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242636", true, true);
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
         context.AddJavascriptSource("cdistritos.js", "?202281810242636", false, true);
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
         edtPaiCod_Internalname = "PAICOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtEstCod_Internalname = "ESTCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProvCod_Internalname = "PROVCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtDisCod_Internalname = "DISCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtDisDsc_Internalname = "DISDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtDisAbr_Internalname = "DISABR";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         cmbDisSts_Internalname = "DISSTS";
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
         cmbDisSts_Jsonclick = "";
         cmbDisSts.Enabled = 1;
         edtDisAbr_Jsonclick = "";
         edtDisAbr_Enabled = 1;
         edtDisDsc_Jsonclick = "";
         edtDisDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtDisCod_Jsonclick = "";
         edtDisCod_Enabled = 1;
         edtProvCod_Jsonclick = "";
         edtProvCod_Enabled = 1;
         edtEstCod_Jsonclick = "";
         edtEstCod_Enabled = 1;
         edtPaiCod_Jsonclick = "";
         edtPaiCod_Enabled = 1;
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
         cmbDisSts.Name = "DISSTS";
         cmbDisSts.WebTags = "";
         cmbDisSts.addItem("1", "ACTIVO", 0);
         cmbDisSts.addItem("0", "INACTIVO", 0);
         if ( cmbDisSts.ItemCount > 0 )
         {
            A878DisSts = (short)(NumberUtil.Val( cmbDisSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0))), "."));
            AssignAttri("", false, "A878DisSts", StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T002815 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1500PaiDsc = T002815_A1500PaiDsc[0];
         pr_default.close(13);
         /* Using cursor T002820 */
         pr_default.execute(18, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtDisDsc_Internalname;
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

      public void Valid_Paicod( )
      {
         /* Using cursor T002815 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         A1500PaiDsc = T002815_A1500PaiDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
      }

      public void Valid_Provcod( )
      {
         /* Using cursor T002820 */
         pr_default.execute(18, new Object[] {A139PaiCod, A140EstCod, A141ProvCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Provincias'.", "ForeignKeyNotFound", 1, "PROVCOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Discod( )
      {
         A878DisSts = (short)(NumberUtil.Val( cmbDisSts.CurrentValue, "."));
         cmbDisSts.CurrentValue = StringUtil.Str( (decimal)(A878DisSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbDisSts.ItemCount > 0 )
         {
            A878DisSts = (short)(NumberUtil.Val( cmbDisSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0))), "."));
            cmbDisSts.CurrentValue = StringUtil.Str( (decimal)(A878DisSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A604DisDsc", StringUtil.RTrim( A604DisDsc));
         AssignAttri("", false, "A877DisAbr", StringUtil.RTrim( A877DisAbr));
         AssignAttri("", false, "A878DisSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A878DisSts), 1, 0, ".", "")));
         cmbDisSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A878DisSts), 1, 0));
         AssignProp("", false, cmbDisSts_Internalname, "Values", cmbDisSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z141ProvCod", StringUtil.RTrim( Z141ProvCod));
         GxWebStd.gx_hidden_field( context, "Z142DisCod", StringUtil.RTrim( Z142DisCod));
         GxWebStd.gx_hidden_field( context, "Z604DisDsc", StringUtil.RTrim( Z604DisDsc));
         GxWebStd.gx_hidden_field( context, "Z877DisAbr", StringUtil.RTrim( Z877DisAbr));
         GxWebStd.gx_hidden_field( context, "Z878DisSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z878DisSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1500PaiDsc", StringUtil.RTrim( Z1500PaiDsc));
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
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''}]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[]");
         setEventMetadata("VALID_ESTCOD",",oparms:[]}");
         setEventMetadata("VALID_PROVCOD","{handler:'Valid_Provcod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''}]");
         setEventMetadata("VALID_PROVCOD",",oparms:[]}");
         setEventMetadata("VALID_DISCOD","{handler:'Valid_Discod',iparms:[{av:'cmbDisSts'},{av:'A878DisSts',fld:'DISSTS',pic:'9'},{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'A141ProvCod',fld:'PROVCOD',pic:''},{av:'A142DisCod',fld:'DISCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DISCOD",",oparms:[{av:'A604DisDsc',fld:'DISDSC',pic:''},{av:'A877DisAbr',fld:'DISABR',pic:''},{av:'cmbDisSts'},{av:'A878DisSts',fld:'DISSTS',pic:'9'},{av:'A1500PaiDsc',fld:'PAIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z139PaiCod'},{av:'Z140EstCod'},{av:'Z141ProvCod'},{av:'Z142DisCod'},{av:'Z604DisDsc'},{av:'Z877DisAbr'},{av:'Z878DisSts'},{av:'Z1500PaiDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(13);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z141ProvCod = "";
         Z142DisCod = "";
         Z604DisDsc = "";
         Z877DisAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
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
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A142DisCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A604DisDsc = "";
         lblTextblock6_Jsonclick = "";
         A877DisAbr = "";
         lblTextblock7_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A1500PaiDsc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1500PaiDsc = "";
         T00286_A142DisCod = new string[] {""} ;
         T00286_A1500PaiDsc = new string[] {""} ;
         T00286_A604DisDsc = new string[] {""} ;
         T00286_A877DisAbr = new string[] {""} ;
         T00286_A878DisSts = new short[1] ;
         T00286_A139PaiCod = new string[] {""} ;
         T00286_A140EstCod = new string[] {""} ;
         T00286_A141ProvCod = new string[] {""} ;
         T00284_A1500PaiDsc = new string[] {""} ;
         T00285_A139PaiCod = new string[] {""} ;
         T00287_A1500PaiDsc = new string[] {""} ;
         T00288_A139PaiCod = new string[] {""} ;
         T00289_A139PaiCod = new string[] {""} ;
         T00289_A140EstCod = new string[] {""} ;
         T00289_A141ProvCod = new string[] {""} ;
         T00289_A142DisCod = new string[] {""} ;
         T00283_A142DisCod = new string[] {""} ;
         T00283_A604DisDsc = new string[] {""} ;
         T00283_A877DisAbr = new string[] {""} ;
         T00283_A878DisSts = new short[1] ;
         T00283_A139PaiCod = new string[] {""} ;
         T00283_A140EstCod = new string[] {""} ;
         T00283_A141ProvCod = new string[] {""} ;
         sMode77 = "";
         T002810_A139PaiCod = new string[] {""} ;
         T002810_A140EstCod = new string[] {""} ;
         T002810_A141ProvCod = new string[] {""} ;
         T002810_A142DisCod = new string[] {""} ;
         T002811_A139PaiCod = new string[] {""} ;
         T002811_A140EstCod = new string[] {""} ;
         T002811_A141ProvCod = new string[] {""} ;
         T002811_A142DisCod = new string[] {""} ;
         T00282_A142DisCod = new string[] {""} ;
         T00282_A604DisDsc = new string[] {""} ;
         T00282_A877DisAbr = new string[] {""} ;
         T00282_A878DisSts = new short[1] ;
         T00282_A139PaiCod = new string[] {""} ;
         T00282_A140EstCod = new string[] {""} ;
         T00282_A141ProvCod = new string[] {""} ;
         T002815_A1500PaiDsc = new string[] {""} ;
         T002816_A244PrvCod = new string[] {""} ;
         T002817_A63AlmCod = new int[1] ;
         T002818_A45CliCod = new string[] {""} ;
         T002819_A139PaiCod = new string[] {""} ;
         T002819_A140EstCod = new string[] {""} ;
         T002819_A141ProvCod = new string[] {""} ;
         T002819_A142DisCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002820_A139PaiCod = new string[] {""} ;
         ZZ139PaiCod = "";
         ZZ140EstCod = "";
         ZZ141ProvCod = "";
         ZZ142DisCod = "";
         ZZ604DisDsc = "";
         ZZ877DisAbr = "";
         ZZ1500PaiDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cdistritos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cdistritos__default(),
            new Object[][] {
                new Object[] {
               T00282_A142DisCod, T00282_A604DisDsc, T00282_A877DisAbr, T00282_A878DisSts, T00282_A139PaiCod, T00282_A140EstCod, T00282_A141ProvCod
               }
               , new Object[] {
               T00283_A142DisCod, T00283_A604DisDsc, T00283_A877DisAbr, T00283_A878DisSts, T00283_A139PaiCod, T00283_A140EstCod, T00283_A141ProvCod
               }
               , new Object[] {
               T00284_A1500PaiDsc
               }
               , new Object[] {
               T00285_A139PaiCod
               }
               , new Object[] {
               T00286_A142DisCod, T00286_A1500PaiDsc, T00286_A604DisDsc, T00286_A877DisAbr, T00286_A878DisSts, T00286_A139PaiCod, T00286_A140EstCod, T00286_A141ProvCod
               }
               , new Object[] {
               T00287_A1500PaiDsc
               }
               , new Object[] {
               T00288_A139PaiCod
               }
               , new Object[] {
               T00289_A139PaiCod, T00289_A140EstCod, T00289_A141ProvCod, T00289_A142DisCod
               }
               , new Object[] {
               T002810_A139PaiCod, T002810_A140EstCod, T002810_A141ProvCod, T002810_A142DisCod
               }
               , new Object[] {
               T002811_A139PaiCod, T002811_A140EstCod, T002811_A141ProvCod, T002811_A142DisCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002815_A1500PaiDsc
               }
               , new Object[] {
               T002816_A244PrvCod
               }
               , new Object[] {
               T002817_A63AlmCod
               }
               , new Object[] {
               T002818_A45CliCod
               }
               , new Object[] {
               T002819_A139PaiCod, T002819_A140EstCod, T002819_A141ProvCod, T002819_A142DisCod
               }
               , new Object[] {
               T002820_A139PaiCod
               }
            }
         );
      }

      private short Z878DisSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A878DisSts ;
      private short GX_JID ;
      private short RcdFound77 ;
      private short nIsDirty_77 ;
      private short Gx_BScreen ;
      private short ZZ878DisSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Enabled ;
      private int edtProvCod_Enabled ;
      private int edtDisCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtDisDsc_Enabled ;
      private int edtDisAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string Z139PaiCod ;
      private string Z140EstCod ;
      private string Z141ProvCod ;
      private string Z142DisCod ;
      private string Z604DisDsc ;
      private string Z877DisAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbDisSts_Internalname ;
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
      private string edtPaiCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtEstCod_Internalname ;
      private string edtEstCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProvCod_Internalname ;
      private string edtProvCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtDisCod_Internalname ;
      private string A142DisCod ;
      private string edtDisCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtDisDsc_Internalname ;
      private string A604DisDsc ;
      private string edtDisDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtDisAbr_Internalname ;
      private string A877DisAbr ;
      private string edtDisAbr_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string cmbDisSts_Jsonclick ;
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
      private string A1500PaiDsc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1500PaiDsc ;
      private string sMode77 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ139PaiCod ;
      private string ZZ140EstCod ;
      private string ZZ141ProvCod ;
      private string ZZ142DisCod ;
      private string ZZ604DisDsc ;
      private string ZZ877DisAbr ;
      private string ZZ1500PaiDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDisSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00286_A142DisCod ;
      private string[] T00286_A1500PaiDsc ;
      private string[] T00286_A604DisDsc ;
      private string[] T00286_A877DisAbr ;
      private short[] T00286_A878DisSts ;
      private string[] T00286_A139PaiCod ;
      private string[] T00286_A140EstCod ;
      private string[] T00286_A141ProvCod ;
      private string[] T00284_A1500PaiDsc ;
      private string[] T00285_A139PaiCod ;
      private string[] T00287_A1500PaiDsc ;
      private string[] T00288_A139PaiCod ;
      private string[] T00289_A139PaiCod ;
      private string[] T00289_A140EstCod ;
      private string[] T00289_A141ProvCod ;
      private string[] T00289_A142DisCod ;
      private string[] T00283_A142DisCod ;
      private string[] T00283_A604DisDsc ;
      private string[] T00283_A877DisAbr ;
      private short[] T00283_A878DisSts ;
      private string[] T00283_A139PaiCod ;
      private string[] T00283_A140EstCod ;
      private string[] T00283_A141ProvCod ;
      private string[] T002810_A139PaiCod ;
      private string[] T002810_A140EstCod ;
      private string[] T002810_A141ProvCod ;
      private string[] T002810_A142DisCod ;
      private string[] T002811_A139PaiCod ;
      private string[] T002811_A140EstCod ;
      private string[] T002811_A141ProvCod ;
      private string[] T002811_A142DisCod ;
      private string[] T00282_A142DisCod ;
      private string[] T00282_A604DisDsc ;
      private string[] T00282_A877DisAbr ;
      private short[] T00282_A878DisSts ;
      private string[] T00282_A139PaiCod ;
      private string[] T00282_A140EstCod ;
      private string[] T00282_A141ProvCod ;
      private string[] T002815_A1500PaiDsc ;
      private string[] T002816_A244PrvCod ;
      private int[] T002817_A63AlmCod ;
      private string[] T002818_A45CliCod ;
      private string[] T002819_A139PaiCod ;
      private string[] T002819_A140EstCod ;
      private string[] T002819_A141ProvCod ;
      private string[] T002819_A142DisCod ;
      private string[] T002820_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cdistritos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cdistritos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00286;
        prmT00286 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT00284;
        prmT00284 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00285;
        prmT00285 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT00287;
        prmT00287 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00288;
        prmT00288 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT00289;
        prmT00289 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT00283;
        prmT00283 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002810;
        prmT002810 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002811;
        prmT002811 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT00282;
        prmT00282 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002812;
        prmT002812 = new Object[] {
        new ParDef("@DisCod",GXType.NChar,4,0) ,
        new ParDef("@DisDsc",GXType.NChar,100,0) ,
        new ParDef("@DisAbr",GXType.NChar,5,0) ,
        new ParDef("@DisSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        Object[] prmT002813;
        prmT002813 = new Object[] {
        new ParDef("@DisDsc",GXType.NChar,100,0) ,
        new ParDef("@DisAbr",GXType.NChar,5,0) ,
        new ParDef("@DisSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002814;
        prmT002814 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002816;
        prmT002816 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002817;
        prmT002817 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002818;
        prmT002818 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0) ,
        new ParDef("@DisCod",GXType.NChar,4,0)
        };
        Object[] prmT002819;
        prmT002819 = new Object[] {
        };
        Object[] prmT002815;
        prmT002815 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT002820;
        prmT002820 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@ProvCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00282", "SELECT [DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod] FROM [CDISTRITOS] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00282,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00283", "SELECT [DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00283,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00284", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00284,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00285", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00285,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00286", "SELECT TM1.[DisCod], T2.[PaiDsc], TM1.[DisDsc], TM1.[DisAbr], TM1.[DisSts], TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod] FROM ([CDISTRITOS] TM1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = TM1.[PaiCod]) WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod and TM1.[ProvCod] = @ProvCod and TM1.[DisCod] = @DisCod ORDER BY TM1.[PaiCod], TM1.[EstCod], TM1.[ProvCod], TM1.[DisCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00286,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00287", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00287,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00288", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00288,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00289", "SELECT [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00289,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002810", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] > @ProvCod or [ProvCod] = @ProvCod and [EstCod] = @EstCod and [PaiCod] = @PaiCod and [DisCod] > @DisCod) ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002811", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod or [EstCod] = @EstCod and [PaiCod] = @PaiCod and [ProvCod] < @ProvCod or [ProvCod] = @ProvCod and [EstCod] = @EstCod and [PaiCod] = @PaiCod and [DisCod] < @DisCod) ORDER BY [PaiCod] DESC, [EstCod] DESC, [ProvCod] DESC, [DisCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002812", "INSERT INTO [CDISTRITOS]([DisCod], [DisDsc], [DisAbr], [DisSts], [PaiCod], [EstCod], [ProvCod]) VALUES(@DisCod, @DisDsc, @DisAbr, @DisSts, @PaiCod, @EstCod, @ProvCod)", GxErrorMask.GX_NOMASK,prmT002812)
           ,new CursorDef("T002813", "UPDATE [CDISTRITOS] SET [DisDsc]=@DisDsc, [DisAbr]=@DisAbr, [DisSts]=@DisSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod", GxErrorMask.GX_NOMASK,prmT002813)
           ,new CursorDef("T002814", "DELETE FROM [CDISTRITOS]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod", GxErrorMask.GX_NOMASK,prmT002814)
           ,new CursorDef("T002815", "SELECT [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002816", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002816,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002817", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002817,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002818", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod AND [DisCod] = @DisCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002818,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002819", "SELECT [PaiCod], [EstCod], [ProvCod], [DisCod] FROM [CDISTRITOS] ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002819,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002820", "SELECT [PaiCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod AND [ProvCod] = @ProvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002820,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
