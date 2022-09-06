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
   public class cpaises : GXHttpHandler
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
            Form.Meta.addItem("description", "Paises", 0) ;
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

      public cpaises( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpaises( IGxContext context )
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
         cmbPaiSts = new GXCombobox();
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
         if ( cmbPaiSts.ItemCount > 0 )
         {
            A1501PaiSts = (short)(NumberUtil.Val( cmbPaiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0))), "."));
            AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
            AssignProp("", false, cmbPaiSts_Internalname, "Values", cmbPaiSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm34107( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPAISES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pais", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiCod_Internalname, StringUtil.RTrim( A139PaiCod), StringUtil.RTrim( context.localUtil.Format( A139PaiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiCod_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Pais", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiDsc_Internalname, StringUtil.RTrim( A1500PaiDsc), StringUtil.RTrim( context.localUtil.Format( A1500PaiDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr.Pais", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaiAbr_Internalname, StringUtil.RTrim( A1499PaiAbr), StringUtil.RTrim( context.localUtil.Format( A1499PaiAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaiAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaiAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situación", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAISES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPaiSts, cmbPaiSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0)), 1, cmbPaiSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPaiSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CPAISES.htm");
         cmbPaiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         AssignProp("", false, cmbPaiSts_Internalname, "Values", (string)(cmbPaiSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAISES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPAISES.htm");
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
            Z1500PaiDsc = cgiGet( "Z1500PaiDsc");
            Z1499PaiAbr = cgiGet( "Z1499PaiAbr");
            Z1501PaiSts = (short)(context.localUtil.CToN( cgiGet( "Z1501PaiSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A139PaiCod = cgiGet( edtPaiCod_Internalname);
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A1500PaiDsc = cgiGet( edtPaiDsc_Internalname);
            AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
            A1499PaiAbr = cgiGet( edtPaiAbr_Internalname);
            AssignAttri("", false, "A1499PaiAbr", A1499PaiAbr);
            cmbPaiSts.CurrentValue = cgiGet( cmbPaiSts_Internalname);
            A1501PaiSts = (short)(NumberUtil.Val( cgiGet( cmbPaiSts_Internalname), "."));
            AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
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
               InitAll34107( ) ;
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
         DisableAttributes34107( ) ;
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

      protected void CONFIRM_340( )
      {
         BeforeValidate34107( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls34107( ) ;
            }
            else
            {
               CheckExtendedTable34107( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors34107( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues340( ) ;
         }
      }

      protected void ResetCaption340( )
      {
      }

      protected void ZM34107( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1500PaiDsc = T00343_A1500PaiDsc[0];
               Z1499PaiAbr = T00343_A1499PaiAbr[0];
               Z1501PaiSts = T00343_A1501PaiSts[0];
            }
            else
            {
               Z1500PaiDsc = A1500PaiDsc;
               Z1499PaiAbr = A1499PaiAbr;
               Z1501PaiSts = A1501PaiSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z139PaiCod = A139PaiCod;
            Z1500PaiDsc = A1500PaiDsc;
            Z1499PaiAbr = A1499PaiAbr;
            Z1501PaiSts = A1501PaiSts;
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

      protected void Load34107( )
      {
         /* Using cursor T00344 */
         pr_default.execute(2, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound107 = 1;
            A1500PaiDsc = T00344_A1500PaiDsc[0];
            AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
            A1499PaiAbr = T00344_A1499PaiAbr[0];
            AssignAttri("", false, "A1499PaiAbr", A1499PaiAbr);
            A1501PaiSts = T00344_A1501PaiSts[0];
            AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
            ZM34107( -1) ;
         }
         pr_default.close(2);
         OnLoadActions34107( ) ;
      }

      protected void OnLoadActions34107( )
      {
      }

      protected void CheckExtendedTable34107( )
      {
         nIsDirty_107 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors34107( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey34107( )
      {
         /* Using cursor T00345 */
         pr_default.execute(3, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00343 */
         pr_default.execute(1, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM34107( 1) ;
            RcdFound107 = 1;
            A139PaiCod = T00343_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
            A1500PaiDsc = T00343_A1500PaiDsc[0];
            AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
            A1499PaiAbr = T00343_A1499PaiAbr[0];
            AssignAttri("", false, "A1499PaiAbr", A1499PaiAbr);
            A1501PaiSts = T00343_A1501PaiSts[0];
            AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
            Z139PaiCod = A139PaiCod;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load34107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey34107( ) ;
            }
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey34107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey34107( ) ;
         if ( RcdFound107 == 0 )
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
         RcdFound107 = 0;
         /* Using cursor T00346 */
         pr_default.execute(4, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00346_A139PaiCod[0], A139PaiCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00346_A139PaiCod[0], A139PaiCod) > 0 ) ) )
            {
               A139PaiCod = T00346_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               RcdFound107 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound107 = 0;
         /* Using cursor T00347 */
         pr_default.execute(5, new Object[] {A139PaiCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00347_A139PaiCod[0], A139PaiCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00347_A139PaiCod[0], A139PaiCod) < 0 ) ) )
            {
               A139PaiCod = T00347_A139PaiCod[0];
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
               RcdFound107 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey34107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert34107( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 )
               {
                  A139PaiCod = Z139PaiCod;
                  AssignAttri("", false, "A139PaiCod", A139PaiCod);
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
                  Update34107( ) ;
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPaiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert34107( ) ;
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
                     Insert34107( ) ;
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
         if ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 )
         {
            A139PaiCod = Z139PaiCod;
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
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
         GetKey34107( ) ;
         if ( RcdFound107 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PAICOD");
               AnyError = 1;
               GX_FocusControl = edtPaiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 )
            {
               A139PaiCod = Z139PaiCod;
               AssignAttri("", false, "A139PaiCod", A139PaiCod);
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
            if ( StringUtil.StrCmp(A139PaiCod, Z139PaiCod) != 0 )
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
         context.RollbackDataStores("cpaises",pr_default);
         GX_FocusControl = edtPaiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_340( ) ;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAICOD");
            AnyError = 1;
            GX_FocusControl = edtPaiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPaiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart34107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPaiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd34107( ) ;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPaiDsc_Internalname;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPaiDsc_Internalname;
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
         ScanStart34107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound107 != 0 )
            {
               ScanNext34107( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPaiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd34107( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency34107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00342 */
            pr_default.execute(0, new Object[] {A139PaiCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPAISES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1500PaiDsc, T00342_A1500PaiDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1499PaiAbr, T00342_A1499PaiAbr[0]) != 0 ) || ( Z1501PaiSts != T00342_A1501PaiSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1500PaiDsc, T00342_A1500PaiDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpaises:[seudo value changed for attri]"+"PaiDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1500PaiDsc);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1500PaiDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1499PaiAbr, T00342_A1499PaiAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cpaises:[seudo value changed for attri]"+"PaiAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1499PaiAbr);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1499PaiAbr[0]);
               }
               if ( Z1501PaiSts != T00342_A1501PaiSts[0] )
               {
                  GXUtil.WriteLog("cpaises:[seudo value changed for attri]"+"PaiSts");
                  GXUtil.WriteLogRaw("Old: ",Z1501PaiSts);
                  GXUtil.WriteLogRaw("Current: ",T00342_A1501PaiSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPAISES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert34107( )
      {
         BeforeValidate34107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM34107( 0) ;
            CheckOptimisticConcurrency34107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert34107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00348 */
                     pr_default.execute(6, new Object[] {A139PaiCod, A1500PaiDsc, A1499PaiAbr, A1501PaiSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CPAISES");
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
                           ResetCaption340( ) ;
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
               Load34107( ) ;
            }
            EndLevel34107( ) ;
         }
         CloseExtendedTableCursors34107( ) ;
      }

      protected void Update34107( )
      {
         BeforeValidate34107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate34107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00349 */
                     pr_default.execute(7, new Object[] {A1500PaiDsc, A1499PaiAbr, A1501PaiSts, A139PaiCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CPAISES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPAISES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate34107( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption340( ) ;
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
            EndLevel34107( ) ;
         }
         CloseExtendedTableCursors34107( ) ;
      }

      protected void DeferredUpdate34107( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate34107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls34107( ) ;
            AfterConfirm34107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete34107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003410 */
                  pr_default.execute(8, new Object[] {A139PaiCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CPAISES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound107 == 0 )
                        {
                           InitAll34107( ) ;
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
                        ResetCaption340( ) ;
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
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel34107( ) ;
         Gx_mode = sMode107;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls34107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003411 */
            pr_default.execute(9, new Object[] {A139PaiCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Departamentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel34107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete34107( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpaises",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues340( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpaises",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart34107( )
      {
         /* Using cursor T003412 */
         pr_default.execute(10);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A139PaiCod = T003412_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext34107( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound107 = 1;
            A139PaiCod = T003412_A139PaiCod[0];
            AssignAttri("", false, "A139PaiCod", A139PaiCod);
         }
      }

      protected void ScanEnd34107( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm34107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert34107( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate34107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete34107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete34107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate34107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes34107( )
      {
         edtPaiCod_Enabled = 0;
         AssignProp("", false, edtPaiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiCod_Enabled), 5, 0), true);
         edtPaiDsc_Enabled = 0;
         AssignProp("", false, edtPaiDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiDsc_Enabled), 5, 0), true);
         edtPaiAbr_Enabled = 0;
         AssignProp("", false, edtPaiAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaiAbr_Enabled), 5, 0), true);
         cmbPaiSts.Enabled = 0;
         AssignProp("", false, cmbPaiSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPaiSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes34107( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues340( )
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
         context.SendWebValue( "Paises") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245347", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpaises.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1500PaiDsc", StringUtil.RTrim( Z1500PaiDsc));
         GxWebStd.gx_hidden_field( context, "Z1499PaiAbr", StringUtil.RTrim( Z1499PaiAbr));
         GxWebStd.gx_hidden_field( context, "Z1501PaiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1501PaiSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm34107( )
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
         return "CPAISES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Paises" ;
      }

      protected void InitializeNonKey34107( )
      {
         A1500PaiDsc = "";
         AssignAttri("", false, "A1500PaiDsc", A1500PaiDsc);
         A1499PaiAbr = "";
         AssignAttri("", false, "A1499PaiAbr", A1499PaiAbr);
         A1501PaiSts = 0;
         AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         Z1500PaiDsc = "";
         Z1499PaiAbr = "";
         Z1501PaiSts = 0;
      }

      protected void InitAll34107( )
      {
         A139PaiCod = "";
         AssignAttri("", false, "A139PaiCod", A139PaiCod);
         InitializeNonKey34107( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245351", true, true);
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
         context.AddJavascriptSource("cpaises.js", "?202281810245351", false, true);
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
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPaiDsc_Internalname = "PAIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPaiAbr_Internalname = "PAIABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbPaiSts_Internalname = "PAISTS";
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
         cmbPaiSts_Jsonclick = "";
         cmbPaiSts.Enabled = 1;
         edtPaiAbr_Jsonclick = "";
         edtPaiAbr_Enabled = 1;
         edtPaiDsc_Jsonclick = "";
         edtPaiDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
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
         cmbPaiSts.Name = "PAISTS";
         cmbPaiSts.WebTags = "";
         cmbPaiSts.addItem("1", "ACTIVO", 0);
         cmbPaiSts.addItem("0", "INACTIVO", 0);
         if ( cmbPaiSts.ItemCount > 0 )
         {
            A1501PaiSts = (short)(NumberUtil.Val( cmbPaiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0))), "."));
            AssignAttri("", false, "A1501PaiSts", StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPaiDsc_Internalname;
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
         A1501PaiSts = (short)(NumberUtil.Val( cmbPaiSts.CurrentValue, "."));
         cmbPaiSts.CurrentValue = StringUtil.Str( (decimal)(A1501PaiSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPaiSts.ItemCount > 0 )
         {
            A1501PaiSts = (short)(NumberUtil.Val( cmbPaiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0))), "."));
            cmbPaiSts.CurrentValue = StringUtil.Str( (decimal)(A1501PaiSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPaiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1500PaiDsc", StringUtil.RTrim( A1500PaiDsc));
         AssignAttri("", false, "A1499PaiAbr", StringUtil.RTrim( A1499PaiAbr));
         AssignAttri("", false, "A1501PaiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1501PaiSts), 1, 0, ".", "")));
         cmbPaiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1501PaiSts), 1, 0));
         AssignProp("", false, cmbPaiSts_Internalname, "Values", cmbPaiSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z139PaiCod", StringUtil.RTrim( Z139PaiCod));
         GxWebStd.gx_hidden_field( context, "Z1500PaiDsc", StringUtil.RTrim( Z1500PaiDsc));
         GxWebStd.gx_hidden_field( context, "Z1499PaiAbr", StringUtil.RTrim( Z1499PaiAbr));
         GxWebStd.gx_hidden_field( context, "Z1501PaiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1501PaiSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_PAICOD","{handler:'Valid_Paicod',iparms:[{av:'cmbPaiSts'},{av:'A1501PaiSts',fld:'PAISTS',pic:'9'},{av:'A139PaiCod',fld:'PAICOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PAICOD",",oparms:[{av:'A1500PaiDsc',fld:'PAIDSC',pic:''},{av:'A1499PaiAbr',fld:'PAIABR',pic:''},{av:'cmbPaiSts'},{av:'A1501PaiSts',fld:'PAISTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z139PaiCod'},{av:'Z1500PaiDsc'},{av:'Z1499PaiAbr'},{av:'Z1501PaiSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z139PaiCod = "";
         Z1500PaiDsc = "";
         Z1499PaiAbr = "";
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
         A139PaiCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1500PaiDsc = "";
         lblTextblock3_Jsonclick = "";
         A1499PaiAbr = "";
         lblTextblock4_Jsonclick = "";
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
         T00344_A139PaiCod = new string[] {""} ;
         T00344_A1500PaiDsc = new string[] {""} ;
         T00344_A1499PaiAbr = new string[] {""} ;
         T00344_A1501PaiSts = new short[1] ;
         T00345_A139PaiCod = new string[] {""} ;
         T00343_A139PaiCod = new string[] {""} ;
         T00343_A1500PaiDsc = new string[] {""} ;
         T00343_A1499PaiAbr = new string[] {""} ;
         T00343_A1501PaiSts = new short[1] ;
         sMode107 = "";
         T00346_A139PaiCod = new string[] {""} ;
         T00347_A139PaiCod = new string[] {""} ;
         T00342_A139PaiCod = new string[] {""} ;
         T00342_A1500PaiDsc = new string[] {""} ;
         T00342_A1499PaiAbr = new string[] {""} ;
         T00342_A1501PaiSts = new short[1] ;
         T003411_A139PaiCod = new string[] {""} ;
         T003411_A140EstCod = new string[] {""} ;
         T003412_A139PaiCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ139PaiCod = "";
         ZZ1500PaiDsc = "";
         ZZ1499PaiAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpaises__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpaises__default(),
            new Object[][] {
                new Object[] {
               T00342_A139PaiCod, T00342_A1500PaiDsc, T00342_A1499PaiAbr, T00342_A1501PaiSts
               }
               , new Object[] {
               T00343_A139PaiCod, T00343_A1500PaiDsc, T00343_A1499PaiAbr, T00343_A1501PaiSts
               }
               , new Object[] {
               T00344_A139PaiCod, T00344_A1500PaiDsc, T00344_A1499PaiAbr, T00344_A1501PaiSts
               }
               , new Object[] {
               T00345_A139PaiCod
               }
               , new Object[] {
               T00346_A139PaiCod
               }
               , new Object[] {
               T00347_A139PaiCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003411_A139PaiCod, T003411_A140EstCod
               }
               , new Object[] {
               T003412_A139PaiCod
               }
            }
         );
      }

      private short Z1501PaiSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1501PaiSts ;
      private short GX_JID ;
      private short RcdFound107 ;
      private short nIsDirty_107 ;
      private short Gx_BScreen ;
      private short ZZ1501PaiSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaiCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPaiDsc_Enabled ;
      private int edtPaiAbr_Enabled ;
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
      private string Z1500PaiDsc ;
      private string Z1499PaiAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaiCod_Internalname ;
      private string cmbPaiSts_Internalname ;
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
      private string A139PaiCod ;
      private string edtPaiCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPaiDsc_Internalname ;
      private string A1500PaiDsc ;
      private string edtPaiDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPaiAbr_Internalname ;
      private string A1499PaiAbr ;
      private string edtPaiAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbPaiSts_Jsonclick ;
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
      private string sMode107 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ139PaiCod ;
      private string ZZ1500PaiDsc ;
      private string ZZ1499PaiAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPaiSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00344_A139PaiCod ;
      private string[] T00344_A1500PaiDsc ;
      private string[] T00344_A1499PaiAbr ;
      private short[] T00344_A1501PaiSts ;
      private string[] T00345_A139PaiCod ;
      private string[] T00343_A139PaiCod ;
      private string[] T00343_A1500PaiDsc ;
      private string[] T00343_A1499PaiAbr ;
      private short[] T00343_A1501PaiSts ;
      private string[] T00346_A139PaiCod ;
      private string[] T00347_A139PaiCod ;
      private string[] T00342_A139PaiCod ;
      private string[] T00342_A1500PaiDsc ;
      private string[] T00342_A1499PaiAbr ;
      private short[] T00342_A1501PaiSts ;
      private string[] T003411_A139PaiCod ;
      private string[] T003411_A140EstCod ;
      private string[] T003412_A139PaiCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cpaises__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpaises__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00344;
        prmT00344 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00345;
        prmT00345 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00343;
        prmT00343 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00346;
        prmT00346 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00347;
        prmT00347 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00342;
        prmT00342 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT00348;
        prmT00348 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0) ,
        new ParDef("@PaiDsc",GXType.NChar,100,0) ,
        new ParDef("@PaiAbr",GXType.NChar,5,0) ,
        new ParDef("@PaiSts",GXType.Int16,1,0)
        };
        Object[] prmT00349;
        prmT00349 = new Object[] {
        new ParDef("@PaiDsc",GXType.NChar,100,0) ,
        new ParDef("@PaiAbr",GXType.NChar,5,0) ,
        new ParDef("@PaiSts",GXType.Int16,1,0) ,
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003410;
        prmT003410 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003411;
        prmT003411 = new Object[] {
        new ParDef("@PaiCod",GXType.NChar,4,0)
        };
        Object[] prmT003412;
        prmT003412 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00342", "SELECT [PaiCod], [PaiDsc], [PaiAbr], [PaiSts] FROM [CPAISES] WITH (UPDLOCK) WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00342,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00343", "SELECT [PaiCod], [PaiDsc], [PaiAbr], [PaiSts] FROM [CPAISES] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00343,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00344", "SELECT TM1.[PaiCod], TM1.[PaiDsc], TM1.[PaiAbr], TM1.[PaiSts] FROM [CPAISES] TM1 WHERE TM1.[PaiCod] = @PaiCod ORDER BY TM1.[PaiCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00344,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00345", "SELECT [PaiCod] FROM [CPAISES] WHERE [PaiCod] = @PaiCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00345,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00346", "SELECT TOP 1 [PaiCod] FROM [CPAISES] WHERE ( [PaiCod] > @PaiCod) ORDER BY [PaiCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00346,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00347", "SELECT TOP 1 [PaiCod] FROM [CPAISES] WHERE ( [PaiCod] < @PaiCod) ORDER BY [PaiCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00347,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00348", "INSERT INTO [CPAISES]([PaiCod], [PaiDsc], [PaiAbr], [PaiSts]) VALUES(@PaiCod, @PaiDsc, @PaiAbr, @PaiSts)", GxErrorMask.GX_NOMASK,prmT00348)
           ,new CursorDef("T00349", "UPDATE [CPAISES] SET [PaiDsc]=@PaiDsc, [PaiAbr]=@PaiAbr, [PaiSts]=@PaiSts  WHERE [PaiCod] = @PaiCod", GxErrorMask.GX_NOMASK,prmT00349)
           ,new CursorDef("T003410", "DELETE FROM [CPAISES]  WHERE [PaiCod] = @PaiCod", GxErrorMask.GX_NOMASK,prmT003410)
           ,new CursorDef("T003411", "SELECT TOP 1 [PaiCod], [EstCod] FROM [CESTADOS] WHERE [PaiCod] = @PaiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003412", "SELECT [PaiCod] FROM [CPAISES] ORDER BY [PaiCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003412,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 4);
              return;
     }
  }

}

}
