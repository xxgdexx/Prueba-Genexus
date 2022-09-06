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
   public class poorsermaq : GXDataArea
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
            A329PSerCod = GetPar( "PSerCod");
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A329PSerCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A320MAQCod = GetPar( "MAQCod");
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A320MAQCod) ;
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
            Form.Meta.addItem("description", "Maquina", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poorsermaq( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poorsermaq( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POORSERMAQ.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N� Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCod_Internalname, StringUtil.RTrim( A329PSerCod), StringUtil.RTrim( context.localUtil.Format( A329PSerCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo de Maquina", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMAQCod_Internalname, StringUtil.RTrim( A320MAQCod), StringUtil.RTrim( context.localUtil.Format( A320MAQCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMAQCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMAQCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "N� Horas", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerMaqCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1811PSerMaqCant, 17, 2, ".", "")), StringUtil.LTrim( ((edtPSerMaqCant_Enabled!=0) ? context.localUtil.Format( A1811PSerMaqCant, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1811PSerMaqCant, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerMaqCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerMaqCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POORSERMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORSERMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POORSERMAQ.htm");
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
            Z329PSerCod = cgiGet( "Z329PSerCod");
            Z320MAQCod = cgiGet( "Z320MAQCod");
            Z1811PSerMaqCant = context.localUtil.CToN( cgiGet( "Z1811PSerMaqCant"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A329PSerCod = cgiGet( edtPSerCod_Internalname);
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A320MAQCod = cgiGet( edtMAQCod_Internalname);
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerMaqCant_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerMaqCant_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERMAQCANT");
               AnyError = 1;
               GX_FocusControl = edtPSerMaqCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1811PSerMaqCant = 0;
               AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrimStr( A1811PSerMaqCant, 15, 2));
            }
            else
            {
               A1811PSerMaqCant = context.localUtil.CToN( cgiGet( edtPSerMaqCant_Internalname), ".", ",");
               AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrimStr( A1811PSerMaqCant, 15, 2));
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
               A329PSerCod = GetPar( "PSerCod");
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A320MAQCod = GetPar( "MAQCod");
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
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
               InitAll4F154( ) ;
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
         DisableAttributes4F154( ) ;
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

      protected void CONFIRM_4F0( )
      {
         BeforeValidate4F154( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4F154( ) ;
            }
            else
            {
               CheckExtendedTable4F154( ) ;
               if ( AnyError == 0 )
               {
                  ZM4F154( 2) ;
                  ZM4F154( 3) ;
               }
               CloseExtendedTableCursors4F154( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4F0( ) ;
         }
      }

      protected void ResetCaption4F0( )
      {
      }

      protected void ZM4F154( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1811PSerMaqCant = T004F3_A1811PSerMaqCant[0];
            }
            else
            {
               Z1811PSerMaqCant = A1811PSerMaqCant;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1811PSerMaqCant = A1811PSerMaqCant;
            Z329PSerCod = A329PSerCod;
            Z320MAQCod = A320MAQCod;
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

      protected void Load4F154( )
      {
         /* Using cursor T004F6 */
         pr_default.execute(4, new Object[] {A329PSerCod, A320MAQCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound154 = 1;
            A1811PSerMaqCant = T004F6_A1811PSerMaqCant[0];
            AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrimStr( A1811PSerMaqCant, 15, 2));
            ZM4F154( -1) ;
         }
         pr_default.close(4);
         OnLoadActions4F154( ) ;
      }

      protected void OnLoadActions4F154( )
      {
      }

      protected void CheckExtendedTable4F154( )
      {
         nIsDirty_154 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004F4 */
         pr_default.execute(2, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004F5 */
         pr_default.execute(3, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors4F154( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A329PSerCod )
      {
         /* Using cursor T004F7 */
         pr_default.execute(5, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A320MAQCod )
      {
         /* Using cursor T004F8 */
         pr_default.execute(6, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
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

      protected void GetKey4F154( )
      {
         /* Using cursor T004F9 */
         pr_default.execute(7, new Object[] {A329PSerCod, A320MAQCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound154 = 1;
         }
         else
         {
            RcdFound154 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004F3 */
         pr_default.execute(1, new Object[] {A329PSerCod, A320MAQCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4F154( 1) ;
            RcdFound154 = 1;
            A1811PSerMaqCant = T004F3_A1811PSerMaqCant[0];
            AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrimStr( A1811PSerMaqCant, 15, 2));
            A329PSerCod = T004F3_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A320MAQCod = T004F3_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            Z329PSerCod = A329PSerCod;
            Z320MAQCod = A320MAQCod;
            sMode154 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4F154( ) ;
            if ( AnyError == 1 )
            {
               RcdFound154 = 0;
               InitializeNonKey4F154( ) ;
            }
            Gx_mode = sMode154;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound154 = 0;
            InitializeNonKey4F154( ) ;
            sMode154 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode154;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4F154( ) ;
         if ( RcdFound154 == 0 )
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
         RcdFound154 = 0;
         /* Using cursor T004F10 */
         pr_default.execute(8, new Object[] {A329PSerCod, A320MAQCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004F10_A329PSerCod[0], A329PSerCod) < 0 ) || ( StringUtil.StrCmp(T004F10_A329PSerCod[0], A329PSerCod) == 0 ) && ( StringUtil.StrCmp(T004F10_A320MAQCod[0], A320MAQCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004F10_A329PSerCod[0], A329PSerCod) > 0 ) || ( StringUtil.StrCmp(T004F10_A329PSerCod[0], A329PSerCod) == 0 ) && ( StringUtil.StrCmp(T004F10_A320MAQCod[0], A320MAQCod) > 0 ) ) )
            {
               A329PSerCod = T004F10_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A320MAQCod = T004F10_A320MAQCod[0];
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               RcdFound154 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound154 = 0;
         /* Using cursor T004F11 */
         pr_default.execute(9, new Object[] {A329PSerCod, A320MAQCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004F11_A329PSerCod[0], A329PSerCod) > 0 ) || ( StringUtil.StrCmp(T004F11_A329PSerCod[0], A329PSerCod) == 0 ) && ( StringUtil.StrCmp(T004F11_A320MAQCod[0], A320MAQCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004F11_A329PSerCod[0], A329PSerCod) < 0 ) || ( StringUtil.StrCmp(T004F11_A329PSerCod[0], A329PSerCod) == 0 ) && ( StringUtil.StrCmp(T004F11_A320MAQCod[0], A320MAQCod) < 0 ) ) )
            {
               A329PSerCod = T004F11_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A320MAQCod = T004F11_A320MAQCod[0];
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               RcdFound154 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4F154( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4F154( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound154 == 1 )
            {
               if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
               {
                  A329PSerCod = Z329PSerCod;
                  AssignAttri("", false, "A329PSerCod", A329PSerCod);
                  A320MAQCod = Z320MAQCod;
                  AssignAttri("", false, "A320MAQCod", A320MAQCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PSERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4F154( ) ;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4F154( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPSerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPSerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4F154( ) ;
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
         if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
         {
            A329PSerCod = Z329PSerCod;
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A320MAQCod = Z320MAQCod;
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPSerCod_Internalname;
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
         GetKey4F154( ) ;
         if ( RcdFound154 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PSERCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
            {
               A329PSerCod = Z329PSerCod;
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A320MAQCod = Z320MAQCod;
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PSERCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerCod_Internalname;
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
         context.RollbackDataStores("poorsermaq",pr_default);
         GX_FocusControl = edtPSerMaqCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4F0( ) ;
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
         if ( RcdFound154 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPSerMaqCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4F154( ) ;
         if ( RcdFound154 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerMaqCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4F154( ) ;
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
         if ( RcdFound154 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerMaqCant_Internalname;
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
         if ( RcdFound154 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerMaqCant_Internalname;
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
         ScanStart4F154( ) ;
         if ( RcdFound154 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound154 != 0 )
            {
               ScanNext4F154( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerMaqCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4F154( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4F154( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004F2 */
            pr_default.execute(0, new Object[] {A329PSerCod, A320MAQCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORSERMAQ"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1811PSerMaqCant != T004F2_A1811PSerMaqCant[0] ) )
            {
               if ( Z1811PSerMaqCant != T004F2_A1811PSerMaqCant[0] )
               {
                  GXUtil.WriteLog("poorsermaq:[seudo value changed for attri]"+"PSerMaqCant");
                  GXUtil.WriteLogRaw("Old: ",Z1811PSerMaqCant);
                  GXUtil.WriteLogRaw("Current: ",T004F2_A1811PSerMaqCant[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POORSERMAQ"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4F154( )
      {
         BeforeValidate4F154( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4F154( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4F154( 0) ;
            CheckOptimisticConcurrency4F154( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4F154( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4F154( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004F12 */
                     pr_default.execute(10, new Object[] {A1811PSerMaqCant, A329PSerCod, A320MAQCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POORSERMAQ");
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
                           ResetCaption4F0( ) ;
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
               Load4F154( ) ;
            }
            EndLevel4F154( ) ;
         }
         CloseExtendedTableCursors4F154( ) ;
      }

      protected void Update4F154( )
      {
         BeforeValidate4F154( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4F154( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4F154( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4F154( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4F154( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004F13 */
                     pr_default.execute(11, new Object[] {A1811PSerMaqCant, A329PSerCod, A320MAQCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POORSERMAQ");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORSERMAQ"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4F154( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4F0( ) ;
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
            EndLevel4F154( ) ;
         }
         CloseExtendedTableCursors4F154( ) ;
      }

      protected void DeferredUpdate4F154( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4F154( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4F154( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4F154( ) ;
            AfterConfirm4F154( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4F154( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004F14 */
                  pr_default.execute(12, new Object[] {A329PSerCod, A320MAQCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("POORSERMAQ");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound154 == 0 )
                        {
                           InitAll4F154( ) ;
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
                        ResetCaption4F0( ) ;
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
         sMode154 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4F154( ) ;
         Gx_mode = sMode154;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4F154( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel4F154( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4F154( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("poorsermaq",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("poorsermaq",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4F154( )
      {
         /* Using cursor T004F15 */
         pr_default.execute(13);
         RcdFound154 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound154 = 1;
            A329PSerCod = T004F15_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A320MAQCod = T004F15_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4F154( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound154 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound154 = 1;
            A329PSerCod = T004F15_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A320MAQCod = T004F15_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
         }
      }

      protected void ScanEnd4F154( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm4F154( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4F154( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4F154( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4F154( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4F154( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4F154( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4F154( )
      {
         edtPSerCod_Enabled = 0;
         AssignProp("", false, edtPSerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCod_Enabled), 5, 0), true);
         edtMAQCod_Enabled = 0;
         AssignProp("", false, edtMAQCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMAQCod_Enabled), 5, 0), true);
         edtPSerMaqCant_Enabled = 0;
         AssignProp("", false, edtPSerMaqCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerMaqCant_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4F154( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253781", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poorsermaq.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z320MAQCod", StringUtil.RTrim( Z320MAQCod));
         GxWebStd.gx_hidden_field( context, "Z1811PSerMaqCant", StringUtil.LTrim( StringUtil.NToC( Z1811PSerMaqCant, 15, 2, ".", "")));
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
         return formatLink("poorsermaq.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POORSERMAQ" ;
      }

      public override string GetPgmdesc( )
      {
         return "Maquina" ;
      }

      protected void InitializeNonKey4F154( )
      {
         A1811PSerMaqCant = 0;
         AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrimStr( A1811PSerMaqCant, 15, 2));
         Z1811PSerMaqCant = 0;
      }

      protected void InitAll4F154( )
      {
         A329PSerCod = "";
         AssignAttri("", false, "A329PSerCod", A329PSerCod);
         A320MAQCod = "";
         AssignAttri("", false, "A320MAQCod", A320MAQCod);
         InitializeNonKey4F154( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253785", true, true);
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
         context.AddJavascriptSource("poorsermaq.js", "?202281810253785", false, true);
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
         edtPSerCod_Internalname = "PSERCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMAQCod_Internalname = "MAQCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPSerMaqCant_Internalname = "PSERMAQCANT";
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
         Form.Caption = "Maquina";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPSerMaqCant_Jsonclick = "";
         edtPSerMaqCant_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMAQCod_Jsonclick = "";
         edtMAQCod_Enabled = 1;
         edtPSerCod_Jsonclick = "";
         edtPSerCod_Enabled = 1;
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
         /* Using cursor T004F16 */
         pr_default.execute(14, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T004F17 */
         pr_default.execute(15, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtPSerMaqCant_Internalname;
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

      public void Valid_Psercod( )
      {
         /* Using cursor T004F16 */
         pr_default.execute(14, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Maqcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T004F17 */
         pr_default.execute(15, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1811PSerMaqCant", StringUtil.LTrim( StringUtil.NToC( A1811PSerMaqCant, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z320MAQCod", StringUtil.RTrim( Z320MAQCod));
         GxWebStd.gx_hidden_field( context, "Z1811PSerMaqCant", StringUtil.LTrim( StringUtil.NToC( Z1811PSerMaqCant, 15, 2, ".", "")));
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
         setEventMetadata("VALID_PSERCOD","{handler:'Valid_Psercod',iparms:[{av:'A329PSerCod',fld:'PSERCOD',pic:''}]");
         setEventMetadata("VALID_PSERCOD",",oparms:[]}");
         setEventMetadata("VALID_MAQCOD","{handler:'Valid_Maqcod',iparms:[{av:'A329PSerCod',fld:'PSERCOD',pic:''},{av:'A320MAQCod',fld:'MAQCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MAQCOD",",oparms:[{av:'A1811PSerMaqCant',fld:'PSERMAQCANT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z329PSerCod'},{av:'Z320MAQCod'},{av:'Z1811PSerMaqCant'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z329PSerCod = "";
         Z320MAQCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A329PSerCod = "";
         A320MAQCod = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
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
         T004F6_A1811PSerMaqCant = new decimal[1] ;
         T004F6_A329PSerCod = new string[] {""} ;
         T004F6_A320MAQCod = new string[] {""} ;
         T004F4_A329PSerCod = new string[] {""} ;
         T004F5_A320MAQCod = new string[] {""} ;
         T004F7_A329PSerCod = new string[] {""} ;
         T004F8_A320MAQCod = new string[] {""} ;
         T004F9_A329PSerCod = new string[] {""} ;
         T004F9_A320MAQCod = new string[] {""} ;
         T004F3_A1811PSerMaqCant = new decimal[1] ;
         T004F3_A329PSerCod = new string[] {""} ;
         T004F3_A320MAQCod = new string[] {""} ;
         sMode154 = "";
         T004F10_A329PSerCod = new string[] {""} ;
         T004F10_A320MAQCod = new string[] {""} ;
         T004F11_A329PSerCod = new string[] {""} ;
         T004F11_A320MAQCod = new string[] {""} ;
         T004F2_A1811PSerMaqCant = new decimal[1] ;
         T004F2_A329PSerCod = new string[] {""} ;
         T004F2_A320MAQCod = new string[] {""} ;
         T004F15_A329PSerCod = new string[] {""} ;
         T004F15_A320MAQCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004F16_A329PSerCod = new string[] {""} ;
         T004F17_A320MAQCod = new string[] {""} ;
         ZZ329PSerCod = "";
         ZZ320MAQCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poorsermaq__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poorsermaq__default(),
            new Object[][] {
                new Object[] {
               T004F2_A1811PSerMaqCant, T004F2_A329PSerCod, T004F2_A320MAQCod
               }
               , new Object[] {
               T004F3_A1811PSerMaqCant, T004F3_A329PSerCod, T004F3_A320MAQCod
               }
               , new Object[] {
               T004F4_A329PSerCod
               }
               , new Object[] {
               T004F5_A320MAQCod
               }
               , new Object[] {
               T004F6_A1811PSerMaqCant, T004F6_A329PSerCod, T004F6_A320MAQCod
               }
               , new Object[] {
               T004F7_A329PSerCod
               }
               , new Object[] {
               T004F8_A320MAQCod
               }
               , new Object[] {
               T004F9_A329PSerCod, T004F9_A320MAQCod
               }
               , new Object[] {
               T004F10_A329PSerCod, T004F10_A320MAQCod
               }
               , new Object[] {
               T004F11_A329PSerCod, T004F11_A320MAQCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004F15_A329PSerCod, T004F15_A320MAQCod
               }
               , new Object[] {
               T004F16_A329PSerCod
               }
               , new Object[] {
               T004F17_A320MAQCod
               }
            }
         );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound154 ;
      private short nIsDirty_154 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPSerCod_Enabled ;
      private int edtMAQCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPSerMaqCant_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z1811PSerMaqCant ;
      private decimal A1811PSerMaqCant ;
      private decimal ZZ1811PSerMaqCant ;
      private string sPrefix ;
      private string Z329PSerCod ;
      private string Z320MAQCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A329PSerCod ;
      private string A320MAQCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPSerCod_Internalname ;
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
      private string edtPSerCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMAQCod_Internalname ;
      private string edtMAQCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPSerMaqCant_Internalname ;
      private string edtPSerMaqCant_Jsonclick ;
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
      private string sMode154 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ329PSerCod ;
      private string ZZ320MAQCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T004F6_A1811PSerMaqCant ;
      private string[] T004F6_A329PSerCod ;
      private string[] T004F6_A320MAQCod ;
      private string[] T004F4_A329PSerCod ;
      private string[] T004F5_A320MAQCod ;
      private string[] T004F7_A329PSerCod ;
      private string[] T004F8_A320MAQCod ;
      private string[] T004F9_A329PSerCod ;
      private string[] T004F9_A320MAQCod ;
      private decimal[] T004F3_A1811PSerMaqCant ;
      private string[] T004F3_A329PSerCod ;
      private string[] T004F3_A320MAQCod ;
      private string[] T004F10_A329PSerCod ;
      private string[] T004F10_A320MAQCod ;
      private string[] T004F11_A329PSerCod ;
      private string[] T004F11_A320MAQCod ;
      private decimal[] T004F2_A1811PSerMaqCant ;
      private string[] T004F2_A329PSerCod ;
      private string[] T004F2_A320MAQCod ;
      private string[] T004F15_A329PSerCod ;
      private string[] T004F15_A320MAQCod ;
      private string[] T004F16_A329PSerCod ;
      private string[] T004F17_A320MAQCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poorsermaq__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poorsermaq__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004F6;
        prmT004F6 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F4;
        prmT004F4 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004F5;
        prmT004F5 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F7;
        prmT004F7 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004F8;
        prmT004F8 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F9;
        prmT004F9 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F3;
        prmT004F3 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F10;
        prmT004F10 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F11;
        prmT004F11 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F2;
        prmT004F2 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F12;
        prmT004F12 = new Object[] {
        new ParDef("@PSerMaqCant",GXType.Decimal,15,2) ,
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F13;
        prmT004F13 = new Object[] {
        new ParDef("@PSerMaqCant",GXType.Decimal,15,2) ,
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F14;
        prmT004F14 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004F15;
        prmT004F15 = new Object[] {
        };
        Object[] prmT004F16;
        prmT004F16 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004F17;
        prmT004F17 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004F2", "SELECT [PSerMaqCant], [PSerCod], [MAQCod] FROM [POORSERMAQ] WITH (UPDLOCK) WHERE [PSerCod] = @PSerCod AND [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F3", "SELECT [PSerMaqCant], [PSerCod], [MAQCod] FROM [POORSERMAQ] WHERE [PSerCod] = @PSerCod AND [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F4", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F5", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F6", "SELECT TM1.[PSerMaqCant], TM1.[PSerCod], TM1.[MAQCod] FROM [POORSERMAQ] TM1 WHERE TM1.[PSerCod] = @PSerCod and TM1.[MAQCod] = @MAQCod ORDER BY TM1.[PSerCod], TM1.[MAQCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004F6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F7", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F8", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F9", "SELECT [PSerCod], [MAQCod] FROM [POORSERMAQ] WHERE [PSerCod] = @PSerCod AND [MAQCod] = @MAQCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F10", "SELECT TOP 1 [PSerCod], [MAQCod] FROM [POORSERMAQ] WHERE ( [PSerCod] > @PSerCod or [PSerCod] = @PSerCod and [MAQCod] > @MAQCod) ORDER BY [PSerCod], [MAQCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004F11", "SELECT TOP 1 [PSerCod], [MAQCod] FROM [POORSERMAQ] WHERE ( [PSerCod] < @PSerCod or [PSerCod] = @PSerCod and [MAQCod] < @MAQCod) ORDER BY [PSerCod] DESC, [MAQCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004F12", "INSERT INTO [POORSERMAQ]([PSerMaqCant], [PSerCod], [MAQCod]) VALUES(@PSerMaqCant, @PSerCod, @MAQCod)", GxErrorMask.GX_NOMASK,prmT004F12)
           ,new CursorDef("T004F13", "UPDATE [POORSERMAQ] SET [PSerMaqCant]=@PSerMaqCant  WHERE [PSerCod] = @PSerCod AND [MAQCod] = @MAQCod", GxErrorMask.GX_NOMASK,prmT004F13)
           ,new CursorDef("T004F14", "DELETE FROM [POORSERMAQ]  WHERE [PSerCod] = @PSerCod AND [MAQCod] = @MAQCod", GxErrorMask.GX_NOMASK,prmT004F14)
           ,new CursorDef("T004F15", "SELECT [PSerCod], [MAQCod] FROM [POORSERMAQ] ORDER BY [PSerCod], [MAQCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004F15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F16", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004F17", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004F17,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
