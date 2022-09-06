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
   public class cestados : GXHttpHandler
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
            Form.Meta.addItem("description", "Estados", 0) ;
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

      public cestados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cestados( IGxContext context )
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
         cmbEstSts = new GXCombobox();
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
         if ( cmbEstSts.ItemCount > 0 )
         {
            A975EstSts = (short)(NumberUtil.Val( cmbEstSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0))), "."));
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            AssignProp("", false, cmbEstSts_Internalname, "Values", cmbEstSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2A79( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CESTADOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pais", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Departamento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCod_Internalname, StringUtil.RTrim( A140EstCod), StringUtil.RTrim( context.localUtil.Format( A140EstCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Departamento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstDsc_Internalname, StringUtil.RTrim( A602EstDsc), StringUtil.RTrim( context.localUtil.Format( A602EstDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Abr. Departamento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstAbr_Internalname, StringUtil.RTrim( A974EstAbr), StringUtil.RTrim( context.localUtil.Format( A974EstAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CESTADOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEstSts, cmbEstSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0)), 1, cmbEstSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEstSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CESTADOS.htm");
         cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         AssignProp("", false, cmbEstSts_Internalname, "Values", (string)(cmbEstSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CESTADOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CESTADOS.htm");
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
            Z602EstDsc = cgiGet( "Z602EstDsc");
            Z974EstAbr = cgiGet( "Z974EstAbr");
            Z975EstSts = (short)(context.localUtil.CToN( cgiGet( "Z975EstSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A139PaiCod = cgiGet( edtPaiCod_Internalname);
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = cgiGet( edtEstCod_Internalname);
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A602EstDsc = cgiGet( edtEstDsc_Internalname);
            AssignAttri("", false, "A602EstDsc", A602EstDsc);
            A974EstAbr = cgiGet( edtEstAbr_Internalname);
            AssignAttri("", false, "A974EstAbr", A974EstAbr);
            cmbEstSts.CurrentValue = cgiGet( cmbEstSts_Internalname);
            A975EstSts = (short)(NumberUtil.Val( cgiGet( cmbEstSts_Internalname), "."));
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
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
               InitAll2A79( ) ;
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
         DisableAttributes2A79( ) ;
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

      protected void CONFIRM_2A0( )
      {
         BeforeValidate2A79( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2A79( ) ;
            }
            else
            {
               CheckExtendedTable2A79( ) ;
               if ( AnyError == 0 )
               {
                  ZM2A79( 2) ;
               }
               CloseExtendedTableCursors2A79( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2A0( ) ;
         }
      }

      protected void ResetCaption2A0( )
      {
      }

      protected void ZM2A79( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z602EstDsc = T002A3_A602EstDsc[0];
               Z974EstAbr = T002A3_A974EstAbr[0];
               Z975EstSts = T002A3_A975EstSts[0];
            }
            else
            {
               Z602EstDsc = A602EstDsc;
               Z974EstAbr = A974EstAbr;
               Z975EstSts = A975EstSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z140EstCod = A140EstCod;
            Z602EstDsc = A602EstDsc;
            Z974EstAbr = A974EstAbr;
            Z975EstSts = A975EstSts;
            Z139PaiCod = A139PaiCod;
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

      protected void Load2A79( )
      {
         /* Using cursor T002A5 */
         pr_default.execute(3, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound79 = 1;
            A602EstDsc = T002A5_A602EstDsc[0];
            AssignAttri("", false, "A602EstDsc", A602EstDsc);
            A974EstAbr = T002A5_A974EstAbr[0];
            AssignAttri("", false, "A974EstAbr", A974EstAbr);
            A975EstSts = T002A5_A975EstSts[0];
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            ZM2A79( -1) ;
         }
         pr_default.close(3);
         OnLoadActions2A79( ) ;
      }

      protected void OnLoadActions2A79( )
      {
      }

      protected void CheckExtendedTable2A79( )
      {
         nIsDirty_79 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002A4 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2A79( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A139PaiCod )
      {
         /* Using cursor T002A6 */
         pr_default.execute(4, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
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

      protected void GetKey2A79( )
      {
         /* Using cursor T002A7 */
         pr_default.execute(5, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound79 = 1;
         }
         else
         {
            RcdFound79 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002A3 */
         pr_default.execute(1, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2A79( 1) ;
            RcdFound79 = 1;
            A140EstCod = T002A3_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
            A602EstDsc = T002A3_A602EstDsc[0];
            AssignAttri("", false, "A602EstDsc", A602EstDsc);
            A974EstAbr = T002A3_A974EstAbr[0];
            AssignAttri("", false, "A974EstAbr", A974EstAbr);
            A975EstSts = T002A3_A975EstSts[0];
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
            A139PaiCod = T002A3_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            Z139PaiCod = A139PaiCod;
            Z140EstCod = A140EstCod;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2A79( ) ;
            if ( AnyError == 1 )
            {
               RcdFound79 = 0;
               InitializeNonKey2A79( ) ;
            }
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound79 = 0;
            InitializeNonKey2A79( ) ;
            sMode79 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode79;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2A79( ) ;
         if ( RcdFound79 == 0 )
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
         RcdFound79 = 0;
         /* Using cursor T002A8 */
         pr_default.execute(6, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002A8_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T002A8_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002A8_A140EstCod[0], A140EstCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002A8_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T002A8_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002A8_A140EstCod[0], A140EstCod) > 0 ) ) )
            {
               A139PaiCod = T002A8_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T002A8_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               RcdFound79 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound79 = 0;
         /* Using cursor T002A9 */
         pr_default.execute(7, new Object[] {A139PaiCod, A140EstCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002A9_A139PaiCod[0], A139PaiCod) > 0 ) || ( StringUtil.StrCmp(T002A9_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002A9_A140EstCod[0], A140EstCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002A9_A139PaiCod[0], A139PaiCod) < 0 ) || ( StringUtil.StrCmp(T002A9_A139PaiCod[0], A139PaiCod) == 0 ) && ( StringUtil.StrCmp(T002A9_A140EstCod[0], A140EstCod) < 0 ) ) )
            {
               A139PaiCod = T002A9_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = T002A9_A140EstCod[0];
               AssignAttri("", false, "A140EstCod", A140EstCod);
               RcdFound79 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2A79( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2A79( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound79 == 1 )
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
                  A140EstCod = Z140EstCod;
                  AssignAttri("", false, "A140EstCod", A140EstCod);
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
                  Update2A79( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2A79( ) ;
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
                     Insert2A79( ) ;
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
         if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = Z140EstCod;
            AssignAttri("", false, "A140EstCod", A140EstCod);
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
         GetKey2A79( ) ;
         if ( RcdFound79 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PAICOD");
               AnyError = 1;
               GX_FocusControl = edtPaiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
            {
               A139PaiCod = Z139PaiCod;
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               A140EstCod = Z140EstCod;
               AssignAttri("", false, "A140EstCod", A140EstCod);
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
            if ( ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 ) || ( StringUtil.StrCmp(A140EstCod, Z140EstCod) != 0 ) )
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
         context.RollbackDataStores("cestados",pr_default);
         GX_FocusControl = edtEstDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2A0( ) ;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtEstDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2A79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEstDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2A79( ) ;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEstDsc_Internalname;
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
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEstDsc_Internalname;
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
         ScanStart2A79( ) ;
         if ( RcdFound79 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound79 != 0 )
            {
               ScanNext2A79( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEstDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2A79( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2A79( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002A2 */
            pr_default.execute(0, new Object[] {A139PaiCod, A140EstCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CESTADOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z602EstDsc, T002A2_A602EstDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z974EstAbr, T002A2_A974EstAbr[0]) != 0 ) || ( Z975EstSts != T002A2_A975EstSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z602EstDsc, T002A2_A602EstDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cestados:[seudo value changed for attri]"+"EstDsc");
                  GXUtil.WriteLogRaw("Old: ",Z602EstDsc);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A602EstDsc[0]);
               }
               if ( StringUtil.StrCmp(Z974EstAbr, T002A2_A974EstAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cestados:[seudo value changed for attri]"+"EstAbr");
                  GXUtil.WriteLogRaw("Old: ",Z974EstAbr);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A974EstAbr[0]);
               }
               if ( Z975EstSts != T002A2_A975EstSts[0] )
               {
                  GXUtil.WriteLog("cestados:[seudo value changed for attri]"+"EstSts");
                  GXUtil.WriteLogRaw("Old: ",Z975EstSts);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A975EstSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CESTADOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2A79( )
      {
         BeforeValidate2A79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A79( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2A79( 0) ;
            CheckOptimisticConcurrency2A79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2A79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002A10 */
                     pr_default.execute(8, new Object[] {A140EstCod, A602EstDsc, A974EstAbr, A975EstSts, A139PaiCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
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
                           ResetCaption2A0( ) ;
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
               Load2A79( ) ;
            }
            EndLevel2A79( ) ;
         }
         CloseExtendedTableCursors2A79( ) ;
      }

      protected void Update2A79( )
      {
         BeforeValidate2A79( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A79( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A79( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A79( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2A79( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002A11 */
                     pr_default.execute(9, new Object[] {A602EstDsc, A974EstAbr, A975EstSts, A139PaiCod, A140EstCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CESTADOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2A79( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2A0( ) ;
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
            EndLevel2A79( ) ;
         }
         CloseExtendedTableCursors2A79( ) ;
      }

      protected void DeferredUpdate2A79( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2A79( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A79( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2A79( ) ;
            AfterConfirm2A79( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2A79( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002A12 */
                  pr_default.execute(10, new Object[] {A139PaiCod, A140EstCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CESTADOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound79 == 0 )
                        {
                           InitAll2A79( ) ;
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
                        ResetCaption2A0( ) ;
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
         sMode79 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2A79( ) ;
         Gx_mode = sMode79;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2A79( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002A13 */
            pr_default.execute(11, new Object[] {A139PaiCod, A140EstCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Provincias"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel2A79( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2A79( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cestados",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cestados",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2A79( )
      {
         /* Using cursor T002A14 */
         pr_default.execute(12);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound79 = 1;
            A139PaiCod = T002A14_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002A14_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2A79( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound79 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound79 = 1;
            A139PaiCod = T002A14_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A140EstCod = T002A14_A140EstCod[0];
            AssignAttri("", false, "A140EstCod", A140EstCod);
         }
      }

      protected void ScanEnd2A79( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2A79( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2A79( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2A79( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2A79( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2A79( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2A79( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2A79( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtEstCod_Enabled = 0;
         AssignProp("", false, edtEstCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCod_Enabled), 5, 0), true);
         edtEstDsc_Enabled = 0;
         AssignProp("", false, edtEstDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstDsc_Enabled), 5, 0), true);
         edtEstAbr_Enabled = 0;
         AssignProp("", false, edtEstAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstAbr_Enabled), 5, 0), true);
         cmbEstSts.Enabled = 0;
         AssignProp("", false, cmbEstSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2A79( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2A0( )
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
         context.SendWebValue( "Estados") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242356", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cestados.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z602EstDsc", StringUtil.RTrim( Z602EstDsc));
         GxWebStd.gx_hidden_field( context, "Z974EstAbr", StringUtil.RTrim( Z974EstAbr));
         GxWebStd.gx_hidden_field( context, "Z975EstSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z975EstSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm2A79( )
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
         return "CESTADOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Estados" ;
      }

      protected void InitializeNonKey2A79( )
      {
         A602EstDsc = "";
         AssignAttri("", false, "A602EstDsc", A602EstDsc);
         A974EstAbr = "";
         AssignAttri("", false, "A974EstAbr", A974EstAbr);
         A975EstSts = 0;
         AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         Z602EstDsc = "";
         Z974EstAbr = "";
         Z975EstSts = 0;
      }

      protected void InitAll2A79( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         A140EstCod = "";
         AssignAttri("", false, "A140EstCod", A140EstCod);
         InitializeNonKey2A79( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242361", true, true);
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
         context.AddJavascriptSource("cestados.js", "?202281810242361", false, true);
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
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtEstDsc_Internalname = "ESTDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtEstAbr_Internalname = "ESTABR";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbEstSts_Internalname = "ESTSTS";
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
         cmbEstSts_Jsonclick = "";
         cmbEstSts.Enabled = 1;
         edtEstAbr_Jsonclick = "";
         edtEstAbr_Enabled = 1;
         edtEstDsc_Jsonclick = "";
         edtEstDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
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
         cmbEstSts.Name = "ESTSTS";
         cmbEstSts.WebTags = "";
         cmbEstSts.addItem("1", "ACTIVO", 0);
         cmbEstSts.addItem("0", "INACTIVO", 0);
         if ( cmbEstSts.ItemCount > 0 )
         {
            A975EstSts = (short)(NumberUtil.Val( cmbEstSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0))), "."));
            AssignAttri("", false, "A975EstSts", StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T002A15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         GX_FocusControl = edtEstDsc_Internalname;
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
         /* Using cursor T002A15 */
         pr_default.execute(13, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Paises'.", "ForeignKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Estcod( )
      {
         A975EstSts = (short)(NumberUtil.Val( cmbEstSts.CurrentValue, "."));
         cmbEstSts.CurrentValue = StringUtil.Str( (decimal)(A975EstSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbEstSts.ItemCount > 0 )
         {
            A975EstSts = (short)(NumberUtil.Val( cmbEstSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0))), "."));
            cmbEstSts.CurrentValue = StringUtil.Str( (decimal)(A975EstSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A602EstDsc", StringUtil.RTrim( A602EstDsc));
         AssignAttri("", false, "A974EstAbr", StringUtil.RTrim( A974EstAbr));
         AssignAttri("", false, "A975EstSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A975EstSts), 1, 0, ".", "")));
         cmbEstSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A975EstSts), 1, 0));
         AssignProp("", false, cmbEstSts_Internalname, "Values", cmbEstSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z140EstCod", StringUtil.RTrim( Z140EstCod));
         GxWebStd.gx_hidden_field( context, "Z602EstDsc", StringUtil.RTrim( Z602EstDsc));
         GxWebStd.gx_hidden_field( context, "Z974EstAbr", StringUtil.RTrim( Z974EstAbr));
         GxWebStd.gx_hidden_field( context, "Z975EstSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z975EstSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'A139PaiCod',fld:'PAICOD',pic:''}]");
         setEventMetadata("VALID_PAICOD",",oparms:[]}");
         setEventMetadata("VALID_ESTCOD","{handler:'Valid_Estcod',iparms:[{av:'cmbEstSts'},{av:'A975EstSts',fld:'ESTSTS',pic:'9'},{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'A140EstCod',fld:'ESTCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ESTCOD",",oparms:[{av:'A602EstDsc',fld:'ESTDSC',pic:''},{av:'A974EstAbr',fld:'ESTABR',pic:''},{av:'cmbEstSts'},{av:'A975EstSts',fld:'ESTSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z139PaiCod'},{av:'Z140EstCod'},{av:'Z602EstDsc'},{av:'Z974EstAbr'},{av:'Z975EstSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z139PaiCod = "";
         Z140EstCod = "";
         Z602EstDsc = "";
         Z974EstAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A139PaiCod = "";
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
         A140EstCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A602EstDsc = "";
         lblTextblock4_Jsonclick = "";
         A974EstAbr = "";
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
         T002A5_A140EstCod = new string[] {""} ;
         T002A5_A602EstDsc = new string[] {""} ;
         T002A5_A974EstAbr = new string[] {""} ;
         T002A5_A975EstSts = new short[1] ;
         T002A5_A139PaiCod = new string[] {""} ;
         T002A4_A139PaiCod = new string[] {""} ;
         T002A6_A139PaiCod = new string[] {""} ;
         T002A7_A139PaiCod = new string[] {""} ;
         T002A7_A140EstCod = new string[] {""} ;
         T002A3_A140EstCod = new string[] {""} ;
         T002A3_A602EstDsc = new string[] {""} ;
         T002A3_A974EstAbr = new string[] {""} ;
         T002A3_A975EstSts = new short[1] ;
         T002A3_A139PaiCod = new string[] {""} ;
         sMode79 = "";
         T002A8_A139PaiCod = new string[] {""} ;
         T002A8_A140EstCod = new string[] {""} ;
         T002A9_A139PaiCod = new string[] {""} ;
         T002A9_A140EstCod = new string[] {""} ;
         T002A2_A140EstCod = new string[] {""} ;
         T002A2_A602EstDsc = new string[] {""} ;
         T002A2_A974EstAbr = new string[] {""} ;
         T002A2_A975EstSts = new short[1] ;
         T002A2_A139PaiCod = new string[] {""} ;
         T002A13_A139PaiCod = new string[] {""} ;
         T002A13_A140EstCod = new string[] {""} ;
         T002A13_A141ProvCod = new string[] {""} ;
         T002A14_A139PaiCod = new string[] {""} ;
         T002A14_A140EstCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002A15_A139PaiCod = new string[] {""} ;
         ZZ139PaiCod = "";
         ZZ140EstCod = "";
         ZZ602EstDsc = "";
         ZZ974EstAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cestados__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cestados__default(),
            new Object[][] {
                new Object[] {
               T002A2_A140EstCod, T002A2_A602EstDsc, T002A2_A974EstAbr, T002A2_A975EstSts, T002A2_A139PaiCod
               }
               , new Object[] {
               T002A3_A140EstCod, T002A3_A602EstDsc, T002A3_A974EstAbr, T002A3_A975EstSts, T002A3_A139PaiCod
               }
               , new Object[] {
               T002A4_A139PaiCod
               }
               , new Object[] {
               T002A5_A140EstCod, T002A5_A602EstDsc, T002A5_A974EstAbr, T002A5_A975EstSts, T002A5_A139PaiCod
               }
               , new Object[] {
               T002A6_A139PaiCod
               }
               , new Object[] {
               T002A7_A139PaiCod, T002A7_A140EstCod
               }
               , new Object[] {
               T002A8_A139PaiCod, T002A8_A140EstCod
               }
               , new Object[] {
               T002A9_A139PaiCod, T002A9_A140EstCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002A13_A139PaiCod, T002A13_A140EstCod, T002A13_A141ProvCod
               }
               , new Object[] {
               T002A14_A139PaiCod, T002A14_A140EstCod
               }
               , new Object[] {
               T002A15_A139PaiCod
               }
            }
         );
      }

      private short Z975EstSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A975EstSts ;
      private short GX_JID ;
      private short RcdFound79 ;
      private short nIsDirty_79 ;
      private short Gx_BScreen ;
      private short ZZ975EstSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaiCod_Enabled ;
      private int edtEstCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtEstDsc_Enabled ;
      private int edtEstAbr_Enabled ;
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
      private string Z602EstDsc ;
      private string Z974EstAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A139PaiCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbEstSts_Internalname ;
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
      private string A140EstCod ;
      private string edtEstCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtEstDsc_Internalname ;
      private string A602EstDsc ;
      private string edtEstDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtEstAbr_Internalname ;
      private string A974EstAbr ;
      private string edtEstAbr_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbEstSts_Jsonclick ;
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
      private string sMode79 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ139PaiCod ;
      private string ZZ140EstCod ;
      private string ZZ602EstDsc ;
      private string ZZ974EstAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEstSts ;
      private IDataStoreProvider pr_default ;
      private string[] T002A5_A140EstCod ;
      private string[] T002A5_A602EstDsc ;
      private string[] T002A5_A974EstAbr ;
      private short[] T002A5_A975EstSts ;
      private string[] T002A5_A139PaiCod ;
      private string[] T002A4_A139PaiCod ;
      private string[] T002A6_A139PaiCod ;
      private string[] T002A7_A139PaiCod ;
      private string[] T002A7_A140EstCod ;
      private string[] T002A3_A140EstCod ;
      private string[] T002A3_A602EstDsc ;
      private string[] T002A3_A974EstAbr ;
      private short[] T002A3_A975EstSts ;
      private string[] T002A3_A139PaiCod ;
      private string[] T002A8_A139PaiCod ;
      private string[] T002A8_A140EstCod ;
      private string[] T002A9_A139PaiCod ;
      private string[] T002A9_A140EstCod ;
      private string[] T002A2_A140EstCod ;
      private string[] T002A2_A602EstDsc ;
      private string[] T002A2_A974EstAbr ;
      private short[] T002A2_A975EstSts ;
      private string[] T002A2_A139PaiCod ;
      private string[] T002A13_A139PaiCod ;
      private string[] T002A13_A140EstCod ;
      private string[] T002A13_A141ProvCod ;
      private string[] T002A14_A139PaiCod ;
      private string[] T002A14_A140EstCod ;
      private string[] T002A15_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cestados__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cestados__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002A5;
        prmT002A5 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A4;
        prmT002A4 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT002A6;
        prmT002A6 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT002A7;
        prmT002A7 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A3;
        prmT002A3 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A8;
        prmT002A8 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A9;
        prmT002A9 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A2;
        prmT002A2 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A10;
        prmT002A10 = new Object[] {
        new ParDef("@EstCod",GXType.NChar,4,0) ,
        new ParDef("@EstDsc",GXType.NChar,100,0) ,
        new ParDef("@EstAbr",GXType.NChar,5,0) ,
        new ParDef("@EstSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT002A11;
        prmT002A11 = new Object[] {
        new ParDef("@EstDsc",GXType.NChar,100,0) ,
        new ParDef("@EstAbr",GXType.NChar,5,0) ,
        new ParDef("@EstSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A12;
        prmT002A12 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A13;
        prmT002A13 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@EstCod",GXType.NChar,4,0)
        };
        Object[] prmT002A14;
        prmT002A14 = new Object[] {
        };
        Object[] prmT002A15;
        prmT002A15 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002A2", "SELECT [EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod] FROM [CESTADOS] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A3", "SELECT [EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A4", "SELECT [PaiCod] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A5", "SELECT TM1.[EstCod], TM1.[EstDsc], TM1.[EstAbr], TM1.[EstSts], TM1.[PaiCod] FROM [CESTADOS] TM1 WHERE TM1.[PaiCod] = @PaiCod and TM1.[EstCod] = @EstCod ORDER BY TM1.[PaiCod], TM1.[EstCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002A5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A6", "SELECT [PaiCod] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A7", "SELECT [PaiCod], [EstCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A8", "SELECT TOP 1 [PaiCod], [EstCod] FROM [CESTADOS] WHERE ( [PaiCod] > @PaiCod or [PaiCod] = @PaiCod and [EstCod] > @EstCod) ORDER BY [PaiCod], [EstCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002A8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002A9", "SELECT TOP 1 [PaiCod], [EstCod] FROM [CESTADOS] WHERE ( [PaiCod] < @PaiCod or [PaiCod] = @PaiCod and [EstCod] < @EstCod) ORDER BY [PaiCod] DESC, [EstCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002A9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002A10", "INSERT INTO [CESTADOS]([EstCod], [EstDsc], [EstAbr], [EstSts], [PaiCod]) VALUES(@EstCod, @EstDsc, @EstAbr, @EstSts, @PaiCod)", GxErrorMask.GX_NOMASK,prmT002A10)
           ,new CursorDef("T002A11", "UPDATE [CESTADOS] SET [EstDsc]=@EstDsc, [EstAbr]=@EstAbr, [EstSts]=@EstSts  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod", GxErrorMask.GX_NOMASK,prmT002A11)
           ,new CursorDef("T002A12", "DELETE FROM [CESTADOS]  WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod", GxErrorMask.GX_NOMASK,prmT002A12)
           ,new CursorDef("T002A13", "SELECT TOP 1 [PaiCod], [EstCod], [ProvCod] FROM [CPROVINCIA] WHERE [PaiCod] = @PaiCod AND [EstCod] = @EstCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002A14", "SELECT [PaiCod], [EstCod] FROM [CESTADOS] ORDER BY [PaiCod], [EstCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002A14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002A15", "SELECT [PaiCod] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A15,1, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
