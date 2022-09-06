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
   public class adespachodet : GXDataArea
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
            A8DesCod = GetPar( "DesCod");
            AssignAttri("", false, "A8DesCod", A8DesCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A8DesCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A11DesTipGuia = GetPar( "DesTipGuia");
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = GetPar( "DesGuia");
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A11DesTipGuia, A12DesGuia) ;
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
            Form.Meta.addItem("description", "Despacho Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public adespachodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public adespachodet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ADESPACHODET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Despacho", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDesCod_Internalname, StringUtil.RTrim( A8DesCod), StringUtil.RTrim( context.localUtil.Format( A8DesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ADESPACHODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo Guia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDesTipGuia_Internalname, StringUtil.RTrim( A11DesTipGuia), StringUtil.RTrim( context.localUtil.Format( A11DesTipGuia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesTipGuia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesTipGuia_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ADESPACHODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "N° Guia", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDesGuia_Internalname, StringUtil.RTrim( A12DesGuia), StringUtil.RTrim( context.localUtil.Format( A12DesGuia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesGuia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesGuia_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ADESPACHODET.htm");
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
            Z8DesCod = cgiGet( "Z8DesCod");
            Z11DesTipGuia = cgiGet( "Z11DesTipGuia");
            Z12DesGuia = cgiGet( "Z12DesGuia");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A8DesCod = cgiGet( edtDesCod_Internalname);
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A11DesTipGuia = cgiGet( edtDesTipGuia_Internalname);
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = cgiGet( edtDesGuia_Internalname);
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
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
               A8DesCod = GetPar( "DesCod");
               AssignAttri("", false, "A8DesCod", A8DesCod);
               A11DesTipGuia = GetPar( "DesTipGuia");
               AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
               A12DesGuia = GetPar( "DesGuia");
               AssignAttri("", false, "A12DesGuia", A12DesGuia);
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
               InitAll1337( ) ;
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
         DisableAttributes1337( ) ;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1337( ) ;
            }
            else
            {
               CheckExtendedTable1337( ) ;
               if ( AnyError == 0 )
               {
                  ZM1337( 2) ;
                  ZM1337( 3) ;
               }
               CloseExtendedTableCursors1337( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues130( ) ;
         }
      }

      protected void ResetCaption130( )
      {
      }

      protected void ZM1337( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -1 )
         {
            Z8DesCod = A8DesCod;
            Z11DesTipGuia = A11DesTipGuia;
            Z12DesGuia = A12DesGuia;
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

      protected void Load1337( )
      {
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound37 = 1;
            ZM1337( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1337( ) ;
      }

      protected void OnLoadActions1337( )
      {
      }

      protected void CheckExtendedTable1337( )
      {
         nIsDirty_37 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Despacho'.", "ForeignKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Despacho'.", "ForeignKeyNotFound", 1, "DESGUIA");
            AnyError = 1;
            GX_FocusControl = edtDesTipGuia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1337( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A8DesCod )
      {
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Despacho'.", "ForeignKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
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

      protected void gxLoad_3( string A11DesTipGuia ,
                               string A12DesGuia )
      {
         /* Using cursor T00138 */
         pr_default.execute(6, new Object[] {A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Despacho'.", "ForeignKeyNotFound", 1, "DESGUIA");
            AnyError = 1;
            GX_FocusControl = edtDesTipGuia_Internalname;
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

      protected void GetKey1337( )
      {
         /* Using cursor T00139 */
         pr_default.execute(7, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1337( 1) ;
            RcdFound37 = 1;
            A8DesCod = T00133_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A11DesTipGuia = T00133_A11DesTipGuia[0];
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = T00133_A12DesGuia[0];
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
            Z8DesCod = A8DesCod;
            Z11DesTipGuia = A11DesTipGuia;
            Z12DesGuia = A12DesGuia;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1337( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey1337( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey1337( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1337( ) ;
         if ( RcdFound37 == 0 )
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
         RcdFound37 = 0;
         /* Using cursor T001310 */
         pr_default.execute(8, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) < 0 ) || ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001310_A11DesTipGuia[0], A11DesTipGuia) < 0 ) || ( StringUtil.StrCmp(T001310_A11DesTipGuia[0], A11DesTipGuia) == 0 ) && ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001310_A12DesGuia[0], A12DesGuia) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) > 0 ) || ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001310_A11DesTipGuia[0], A11DesTipGuia) > 0 ) || ( StringUtil.StrCmp(T001310_A11DesTipGuia[0], A11DesTipGuia) == 0 ) && ( StringUtil.StrCmp(T001310_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001310_A12DesGuia[0], A12DesGuia) > 0 ) ) )
            {
               A8DesCod = T001310_A8DesCod[0];
               AssignAttri("", false, "A8DesCod", A8DesCod);
               A11DesTipGuia = T001310_A11DesTipGuia[0];
               AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
               A12DesGuia = T001310_A12DesGuia[0];
               AssignAttri("", false, "A12DesGuia", A12DesGuia);
               RcdFound37 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T001311 */
         pr_default.execute(9, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) > 0 ) || ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001311_A11DesTipGuia[0], A11DesTipGuia) > 0 ) || ( StringUtil.StrCmp(T001311_A11DesTipGuia[0], A11DesTipGuia) == 0 ) && ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001311_A12DesGuia[0], A12DesGuia) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) < 0 ) || ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001311_A11DesTipGuia[0], A11DesTipGuia) < 0 ) || ( StringUtil.StrCmp(T001311_A11DesTipGuia[0], A11DesTipGuia) == 0 ) && ( StringUtil.StrCmp(T001311_A8DesCod[0], A8DesCod) == 0 ) && ( StringUtil.StrCmp(T001311_A12DesGuia[0], A12DesGuia) < 0 ) ) )
            {
               A8DesCod = T001311_A8DesCod[0];
               AssignAttri("", false, "A8DesCod", A8DesCod);
               A11DesTipGuia = T001311_A11DesTipGuia[0];
               AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
               A12DesGuia = T001311_A12DesGuia[0];
               AssignAttri("", false, "A12DesGuia", A12DesGuia);
               RcdFound37 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1337( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1337( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 ) || ( StringUtil.StrCmp(A11DesTipGuia, Z11DesTipGuia) != 0 ) || ( StringUtil.StrCmp(A12DesGuia, Z12DesGuia) != 0 ) )
               {
                  A8DesCod = Z8DesCod;
                  AssignAttri("", false, "A8DesCod", A8DesCod);
                  A11DesTipGuia = Z11DesTipGuia;
                  AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
                  A12DesGuia = Z12DesGuia;
                  AssignAttri("", false, "A12DesGuia", A12DesGuia);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DESCOD");
                  AnyError = 1;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1337( ) ;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 ) || ( StringUtil.StrCmp(A11DesTipGuia, Z11DesTipGuia) != 0 ) || ( StringUtil.StrCmp(A12DesGuia, Z12DesGuia) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1337( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DESCOD");
                     AnyError = 1;
                     GX_FocusControl = edtDesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1337( ) ;
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
         if ( ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 ) || ( StringUtil.StrCmp(A11DesTipGuia, Z11DesTipGuia) != 0 ) || ( StringUtil.StrCmp(A12DesGuia, Z12DesGuia) != 0 ) )
         {
            A8DesCod = Z8DesCod;
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A11DesTipGuia = Z11DesTipGuia;
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = Z12DesGuia;
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDesCod_Internalname;
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
         GetKey1337( ) ;
         if ( RcdFound37 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "DESCOD");
               AnyError = 1;
               GX_FocusControl = edtDesCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 ) || ( StringUtil.StrCmp(A11DesTipGuia, Z11DesTipGuia) != 0 ) || ( StringUtil.StrCmp(A12DesGuia, Z12DesGuia) != 0 ) )
            {
               A8DesCod = Z8DesCod;
               AssignAttri("", false, "A8DesCod", A8DesCod);
               A11DesTipGuia = Z11DesTipGuia;
               AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
               A12DesGuia = Z12DesGuia;
               AssignAttri("", false, "A12DesGuia", A12DesGuia);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "DESCOD");
               AnyError = 1;
               GX_FocusControl = edtDesCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 ) || ( StringUtil.StrCmp(A11DesTipGuia, Z11DesTipGuia) != 0 ) || ( StringUtil.StrCmp(A12DesGuia, Z12DesGuia) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DESCOD");
                  AnyError = 1;
                  GX_FocusControl = edtDesCod_Internalname;
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
         context.RollbackDataStores("adespachodet",pr_default);
      }

      protected void insert_Check( )
      {
         CONFIRM_130( ) ;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1337( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1337( ) ;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1337( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound37 != 0 )
            {
               ScanNext1337( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1337( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1337( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ADESPACHODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ADESPACHODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1337( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1337( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1337( 0) ;
            CheckOptimisticConcurrency1337( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1337( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1337( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001312 */
                     pr_default.execute(10, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ADESPACHODET");
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
                           ResetCaption130( ) ;
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
               Load1337( ) ;
            }
            EndLevel1337( ) ;
         }
         CloseExtendedTableCursors1337( ) ;
      }

      protected void Update1337( )
      {
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1337( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1337( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1337( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1337( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [ADESPACHODET] */
                     DeferredUpdate1337( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption130( ) ;
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
            EndLevel1337( ) ;
         }
         CloseExtendedTableCursors1337( ) ;
      }

      protected void DeferredUpdate1337( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1337( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1337( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1337( ) ;
            AfterConfirm1337( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1337( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001313 */
                  pr_default.execute(11, new Object[] {A8DesCod, A11DesTipGuia, A12DesGuia});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("ADESPACHODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound37 == 0 )
                        {
                           InitAll1337( ) ;
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
                        ResetCaption130( ) ;
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1337( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1337( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1337( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1337( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("adespachodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("adespachodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1337( )
      {
         /* Using cursor T001314 */
         pr_default.execute(12);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound37 = 1;
            A8DesCod = T001314_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A11DesTipGuia = T001314_A11DesTipGuia[0];
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = T001314_A12DesGuia[0];
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1337( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound37 = 1;
            A8DesCod = T001314_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A11DesTipGuia = T001314_A11DesTipGuia[0];
            AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
            A12DesGuia = T001314_A12DesGuia[0];
            AssignAttri("", false, "A12DesGuia", A12DesGuia);
         }
      }

      protected void ScanEnd1337( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1337( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1337( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1337( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1337( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1337( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1337( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1337( )
      {
         edtDesCod_Enabled = 0;
         AssignProp("", false, edtDesCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesCod_Enabled), 5, 0), true);
         edtDesTipGuia_Enabled = 0;
         AssignProp("", false, edtDesTipGuia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesTipGuia_Enabled), 5, 0), true);
         edtDesGuia_Enabled = 0;
         AssignProp("", false, edtDesGuia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesGuia_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1337( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144376", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("adespachodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z8DesCod", StringUtil.RTrim( Z8DesCod));
         GxWebStd.gx_hidden_field( context, "Z11DesTipGuia", StringUtil.RTrim( Z11DesTipGuia));
         GxWebStd.gx_hidden_field( context, "Z12DesGuia", StringUtil.RTrim( Z12DesGuia));
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
         return formatLink("adespachodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ADESPACHODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Despacho Detalle" ;
      }

      protected void InitializeNonKey1337( )
      {
      }

      protected void InitAll1337( )
      {
         A8DesCod = "";
         AssignAttri("", false, "A8DesCod", A8DesCod);
         A11DesTipGuia = "";
         AssignAttri("", false, "A11DesTipGuia", A11DesTipGuia);
         A12DesGuia = "";
         AssignAttri("", false, "A12DesGuia", A12DesGuia);
         InitializeNonKey1337( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443711", true, true);
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
         context.AddJavascriptSource("adespachodet.js", "?202281811443711", false, true);
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
         edtDesCod_Internalname = "DESCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtDesTipGuia_Internalname = "DESTIPGUIA";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtDesGuia_Internalname = "DESGUIA";
         bttBtn_get_Internalname = "BTN_GET";
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
         Form.Caption = "Despacho Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtDesGuia_Jsonclick = "";
         edtDesGuia_Enabled = 1;
         edtDesTipGuia_Jsonclick = "";
         edtDesTipGuia_Enabled = 1;
         edtDesCod_Jsonclick = "";
         edtDesCod_Enabled = 1;
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
         /* Using cursor T001315 */
         pr_default.execute(13, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Despacho'.", "ForeignKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         /* Using cursor T001316 */
         pr_default.execute(14, new Object[] {A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Despacho'.", "ForeignKeyNotFound", 1, "DESGUIA");
            AnyError = 1;
            GX_FocusControl = edtDesTipGuia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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

      public void Valid_Descod( )
      {
         /* Using cursor T001315 */
         pr_default.execute(13, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Despacho'.", "ForeignKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Desguia( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001316 */
         pr_default.execute(14, new Object[] {A11DesTipGuia, A12DesGuia});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Despacho'.", "ForeignKeyNotFound", 1, "DESGUIA");
            AnyError = 1;
            GX_FocusControl = edtDesTipGuia_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z8DesCod", StringUtil.RTrim( Z8DesCod));
         GxWebStd.gx_hidden_field( context, "Z11DesTipGuia", StringUtil.RTrim( Z11DesTipGuia));
         GxWebStd.gx_hidden_field( context, "Z12DesGuia", StringUtil.RTrim( Z12DesGuia));
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
         setEventMetadata("VALID_DESCOD","{handler:'Valid_Descod',iparms:[{av:'A8DesCod',fld:'DESCOD',pic:''}]");
         setEventMetadata("VALID_DESCOD",",oparms:[]}");
         setEventMetadata("VALID_DESTIPGUIA","{handler:'Valid_Destipguia',iparms:[]");
         setEventMetadata("VALID_DESTIPGUIA",",oparms:[]}");
         setEventMetadata("VALID_DESGUIA","{handler:'Valid_Desguia',iparms:[{av:'A8DesCod',fld:'DESCOD',pic:''},{av:'A11DesTipGuia',fld:'DESTIPGUIA',pic:''},{av:'A12DesGuia',fld:'DESGUIA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DESGUIA",",oparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z8DesCod'},{av:'Z11DesTipGuia'},{av:'Z12DesGuia'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z8DesCod = "";
         Z11DesTipGuia = "";
         Z12DesGuia = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A8DesCod = "";
         A11DesTipGuia = "";
         A12DesGuia = "";
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
         bttBtn_get_Jsonclick = "";
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
         T00136_A8DesCod = new string[] {""} ;
         T00136_A11DesTipGuia = new string[] {""} ;
         T00136_A12DesGuia = new string[] {""} ;
         T00134_A8DesCod = new string[] {""} ;
         T00135_A11DesTipGuia = new string[] {""} ;
         T00137_A8DesCod = new string[] {""} ;
         T00138_A11DesTipGuia = new string[] {""} ;
         T00139_A8DesCod = new string[] {""} ;
         T00139_A11DesTipGuia = new string[] {""} ;
         T00139_A12DesGuia = new string[] {""} ;
         T00133_A8DesCod = new string[] {""} ;
         T00133_A11DesTipGuia = new string[] {""} ;
         T00133_A12DesGuia = new string[] {""} ;
         sMode37 = "";
         T001310_A8DesCod = new string[] {""} ;
         T001310_A11DesTipGuia = new string[] {""} ;
         T001310_A12DesGuia = new string[] {""} ;
         T001311_A8DesCod = new string[] {""} ;
         T001311_A11DesTipGuia = new string[] {""} ;
         T001311_A12DesGuia = new string[] {""} ;
         T00132_A8DesCod = new string[] {""} ;
         T00132_A11DesTipGuia = new string[] {""} ;
         T00132_A12DesGuia = new string[] {""} ;
         T001314_A8DesCod = new string[] {""} ;
         T001314_A11DesTipGuia = new string[] {""} ;
         T001314_A12DesGuia = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001315_A8DesCod = new string[] {""} ;
         T001316_A11DesTipGuia = new string[] {""} ;
         ZZ8DesCod = "";
         ZZ11DesTipGuia = "";
         ZZ12DesGuia = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.adespachodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adespachodet__default(),
            new Object[][] {
                new Object[] {
               T00132_A8DesCod, T00132_A11DesTipGuia, T00132_A12DesGuia
               }
               , new Object[] {
               T00133_A8DesCod, T00133_A11DesTipGuia, T00133_A12DesGuia
               }
               , new Object[] {
               T00134_A8DesCod
               }
               , new Object[] {
               T00135_A11DesTipGuia
               }
               , new Object[] {
               T00136_A8DesCod, T00136_A11DesTipGuia, T00136_A12DesGuia
               }
               , new Object[] {
               T00137_A8DesCod
               }
               , new Object[] {
               T00138_A11DesTipGuia
               }
               , new Object[] {
               T00139_A8DesCod, T00139_A11DesTipGuia, T00139_A12DesGuia
               }
               , new Object[] {
               T001310_A8DesCod, T001310_A11DesTipGuia, T001310_A12DesGuia
               }
               , new Object[] {
               T001311_A8DesCod, T001311_A11DesTipGuia, T001311_A12DesGuia
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001314_A8DesCod, T001314_A11DesTipGuia, T001314_A12DesGuia
               }
               , new Object[] {
               T001315_A8DesCod
               }
               , new Object[] {
               T001316_A11DesTipGuia
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
      private short RcdFound37 ;
      private short nIsDirty_37 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtDesCod_Enabled ;
      private int edtDesTipGuia_Enabled ;
      private int edtDesGuia_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
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
      private string Z8DesCod ;
      private string Z11DesTipGuia ;
      private string Z12DesGuia ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A8DesCod ;
      private string A11DesTipGuia ;
      private string A12DesGuia ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDesCod_Internalname ;
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
      private string edtDesCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtDesTipGuia_Internalname ;
      private string edtDesTipGuia_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtDesGuia_Internalname ;
      private string edtDesGuia_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
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
      private string sMode37 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ8DesCod ;
      private string ZZ11DesTipGuia ;
      private string ZZ12DesGuia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00136_A8DesCod ;
      private string[] T00136_A11DesTipGuia ;
      private string[] T00136_A12DesGuia ;
      private string[] T00134_A8DesCod ;
      private string[] T00135_A11DesTipGuia ;
      private string[] T00137_A8DesCod ;
      private string[] T00138_A11DesTipGuia ;
      private string[] T00139_A8DesCod ;
      private string[] T00139_A11DesTipGuia ;
      private string[] T00139_A12DesGuia ;
      private string[] T00133_A8DesCod ;
      private string[] T00133_A11DesTipGuia ;
      private string[] T00133_A12DesGuia ;
      private string[] T001310_A8DesCod ;
      private string[] T001310_A11DesTipGuia ;
      private string[] T001310_A12DesGuia ;
      private string[] T001311_A8DesCod ;
      private string[] T001311_A11DesTipGuia ;
      private string[] T001311_A12DesGuia ;
      private string[] T00132_A8DesCod ;
      private string[] T00132_A11DesTipGuia ;
      private string[] T00132_A12DesGuia ;
      private string[] T001314_A8DesCod ;
      private string[] T001314_A11DesTipGuia ;
      private string[] T001314_A12DesGuia ;
      private string[] T001315_A8DesCod ;
      private string[] T001316_A11DesTipGuia ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class adespachodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class adespachodet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00136;
        prmT00136 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT00134;
        prmT00134 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT00135;
        prmT00135 = new Object[] {
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT00137;
        prmT00137 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT00138;
        prmT00138 = new Object[] {
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT00139;
        prmT00139 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT00133;
        prmT00133 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT001310;
        prmT001310 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT001311;
        prmT001311 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT00132;
        prmT00132 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT001312;
        prmT001312 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT001313;
        prmT001313 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        Object[] prmT001314;
        prmT001314 = new Object[] {
        };
        Object[] prmT001315;
        prmT001315 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001316;
        prmT001316 = new Object[] {
        new ParDef("@DesTipGuia",GXType.NChar,3,0) ,
        new ParDef("@DesGuia",GXType.NChar,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00132", "SELECT [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] WITH (UPDLOCK) WHERE [DesCod] = @DesCod AND [DesTipGuia] = @DesTipGuia AND [DesGuia] = @DesGuia ",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00133", "SELECT [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] WHERE [DesCod] = @DesCod AND [DesTipGuia] = @DesTipGuia AND [DesGuia] = @DesGuia ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00134", "SELECT [DesCod] FROM [ADESPACHO] WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00135", "SELECT [MvATip] AS DesTipGuia FROM [AGUIAS] WHERE [MvATip] = @DesTipGuia AND [MvACod] = @DesGuia ",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00136", "SELECT TM1.[DesCod], TM1.[DesTipGuia] AS DesTipGuia, TM1.[DesGuia] AS DesGuia FROM [ADESPACHODET] TM1 WHERE TM1.[DesCod] = @DesCod and TM1.[DesTipGuia] = @DesTipGuia and TM1.[DesGuia] = @DesGuia ORDER BY TM1.[DesCod], TM1.[DesTipGuia], TM1.[DesGuia]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00137", "SELECT [DesCod] FROM [ADESPACHO] WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00138", "SELECT [MvATip] AS DesTipGuia FROM [AGUIAS] WHERE [MvATip] = @DesTipGuia AND [MvACod] = @DesGuia ",true, GxErrorMask.GX_NOMASK, false, this,prmT00138,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00139", "SELECT [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] WHERE [DesCod] = @DesCod AND [DesTipGuia] = @DesTipGuia AND [DesGuia] = @DesGuia  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00139,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001310", "SELECT TOP 1 [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] WHERE ( [DesCod] > @DesCod or [DesCod] = @DesCod and [DesTipGuia] > @DesTipGuia or [DesTipGuia] = @DesTipGuia and [DesCod] = @DesCod and [DesGuia] > @DesGuia) ORDER BY [DesCod], [DesTipGuia], [DesGuia]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001310,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001311", "SELECT TOP 1 [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] WHERE ( [DesCod] < @DesCod or [DesCod] = @DesCod and [DesTipGuia] < @DesTipGuia or [DesTipGuia] = @DesTipGuia and [DesCod] = @DesCod and [DesGuia] < @DesGuia) ORDER BY [DesCod] DESC, [DesTipGuia] DESC, [DesGuia] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001311,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001312", "INSERT INTO [ADESPACHODET]([DesCod], [DesTipGuia], [DesGuia]) VALUES(@DesCod, @DesTipGuia, @DesGuia)", GxErrorMask.GX_NOMASK,prmT001312)
           ,new CursorDef("T001313", "DELETE FROM [ADESPACHODET]  WHERE [DesCod] = @DesCod AND [DesTipGuia] = @DesTipGuia AND [DesGuia] = @DesGuia", GxErrorMask.GX_NOMASK,prmT001313)
           ,new CursorDef("T001314", "SELECT [DesCod], [DesTipGuia] AS DesTipGuia, [DesGuia] AS DesGuia FROM [ADESPACHODET] ORDER BY [DesCod], [DesTipGuia], [DesGuia]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001314,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001315", "SELECT [DesCod] FROM [ADESPACHO] WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001316", "SELECT [MvATip] AS DesTipGuia FROM [AGUIAS] WHERE [MvATip] = @DesTipGuia AND [MvACod] = @DesGuia ",true, GxErrorMask.GX_NOMASK, false, this,prmT001316,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
