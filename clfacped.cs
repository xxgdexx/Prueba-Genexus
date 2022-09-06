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
   public class clfacped : GXDataArea
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
            Form.Meta.addItem("description", "Relación - Facturas Pedidos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRelTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clfacped( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clfacped( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLFACPED.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLFACPED.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelTipCod_Internalname, StringUtil.RTrim( A199RelTipCod), StringUtil.RTrim( context.localUtil.Format( A199RelTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLFACPED.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Documento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLFACPED.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelDocNum_Internalname, StringUtil.RTrim( A200RelDocNum), StringUtil.RTrim( context.localUtil.Format( A200RelDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLFACPED.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Pedido", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLFACPED.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelPedCod_Internalname, StringUtil.RTrim( A201RelPedCod), StringUtil.RTrim( context.localUtil.Format( A201RelPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLFACPED.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLFACPED.htm");
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
            Z199RelTipCod = cgiGet( "Z199RelTipCod");
            Z200RelDocNum = cgiGet( "Z200RelDocNum");
            Z201RelPedCod = cgiGet( "Z201RelPedCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A199RelTipCod = cgiGet( edtRelTipCod_Internalname);
            AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
            A200RelDocNum = cgiGet( edtRelDocNum_Internalname);
            AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
            A201RelPedCod = cgiGet( edtRelPedCod_Internalname);
            AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
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
               A199RelTipCod = GetPar( "RelTipCod");
               AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
               A200RelDocNum = GetPar( "RelDocNum");
               AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
               A201RelPedCod = GetPar( "RelPedCod");
               AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
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
               InitAll2N91( ) ;
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
         DisableAttributes2N91( ) ;
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

      protected void CONFIRM_2N0( )
      {
         BeforeValidate2N91( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2N91( ) ;
            }
            else
            {
               CheckExtendedTable2N91( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2N91( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2N0( ) ;
         }
      }

      protected void ResetCaption2N0( )
      {
      }

      protected void ZM2N91( short GX_JID )
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
            Z199RelTipCod = A199RelTipCod;
            Z200RelDocNum = A200RelDocNum;
            Z201RelPedCod = A201RelPedCod;
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

      protected void Load2N91( )
      {
         /* Using cursor T002N4 */
         pr_default.execute(2, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound91 = 1;
            ZM2N91( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2N91( ) ;
      }

      protected void OnLoadActions2N91( )
      {
      }

      protected void CheckExtendedTable2N91( )
      {
         nIsDirty_91 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2N91( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2N91( )
      {
         /* Using cursor T002N5 */
         pr_default.execute(3, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound91 = 1;
         }
         else
         {
            RcdFound91 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002N3 */
         pr_default.execute(1, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2N91( 1) ;
            RcdFound91 = 1;
            A199RelTipCod = T002N3_A199RelTipCod[0];
            AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
            A200RelDocNum = T002N3_A200RelDocNum[0];
            AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
            A201RelPedCod = T002N3_A201RelPedCod[0];
            AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
            Z199RelTipCod = A199RelTipCod;
            Z200RelDocNum = A200RelDocNum;
            Z201RelPedCod = A201RelPedCod;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2N91( ) ;
            if ( AnyError == 1 )
            {
               RcdFound91 = 0;
               InitializeNonKey2N91( ) ;
            }
            Gx_mode = sMode91;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound91 = 0;
            InitializeNonKey2N91( ) ;
            sMode91 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode91;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2N91( ) ;
         if ( RcdFound91 == 0 )
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
         RcdFound91 = 0;
         /* Using cursor T002N6 */
         pr_default.execute(4, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) < 0 ) || ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N6_A200RelDocNum[0], A200RelDocNum) < 0 ) || ( StringUtil.StrCmp(T002N6_A200RelDocNum[0], A200RelDocNum) == 0 ) && ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N6_A201RelPedCod[0], A201RelPedCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) > 0 ) || ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N6_A200RelDocNum[0], A200RelDocNum) > 0 ) || ( StringUtil.StrCmp(T002N6_A200RelDocNum[0], A200RelDocNum) == 0 ) && ( StringUtil.StrCmp(T002N6_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N6_A201RelPedCod[0], A201RelPedCod) > 0 ) ) )
            {
               A199RelTipCod = T002N6_A199RelTipCod[0];
               AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
               A200RelDocNum = T002N6_A200RelDocNum[0];
               AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
               A201RelPedCod = T002N6_A201RelPedCod[0];
               AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
               RcdFound91 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound91 = 0;
         /* Using cursor T002N7 */
         pr_default.execute(5, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) > 0 ) || ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N7_A200RelDocNum[0], A200RelDocNum) > 0 ) || ( StringUtil.StrCmp(T002N7_A200RelDocNum[0], A200RelDocNum) == 0 ) && ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N7_A201RelPedCod[0], A201RelPedCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) < 0 ) || ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N7_A200RelDocNum[0], A200RelDocNum) < 0 ) || ( StringUtil.StrCmp(T002N7_A200RelDocNum[0], A200RelDocNum) == 0 ) && ( StringUtil.StrCmp(T002N7_A199RelTipCod[0], A199RelTipCod) == 0 ) && ( StringUtil.StrCmp(T002N7_A201RelPedCod[0], A201RelPedCod) < 0 ) ) )
            {
               A199RelTipCod = T002N7_A199RelTipCod[0];
               AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
               A200RelDocNum = T002N7_A200RelDocNum[0];
               AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
               A201RelPedCod = T002N7_A201RelPedCod[0];
               AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
               RcdFound91 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2N91( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRelTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2N91( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound91 == 1 )
            {
               if ( ( StringUtil.StrCmp(A199RelTipCod, Z199RelTipCod) != 0 ) || ( StringUtil.StrCmp(A200RelDocNum, Z200RelDocNum) != 0 ) || ( StringUtil.StrCmp(A201RelPedCod, Z201RelPedCod) != 0 ) )
               {
                  A199RelTipCod = Z199RelTipCod;
                  AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
                  A200RelDocNum = Z200RelDocNum;
                  AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
                  A201RelPedCod = Z201RelPedCod;
                  AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RELTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtRelTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRelTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2N91( ) ;
                  GX_FocusControl = edtRelTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A199RelTipCod, Z199RelTipCod) != 0 ) || ( StringUtil.StrCmp(A200RelDocNum, Z200RelDocNum) != 0 ) || ( StringUtil.StrCmp(A201RelPedCod, Z201RelPedCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtRelTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2N91( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RELTIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtRelTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtRelTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2N91( ) ;
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
         if ( ( StringUtil.StrCmp(A199RelTipCod, Z199RelTipCod) != 0 ) || ( StringUtil.StrCmp(A200RelDocNum, Z200RelDocNum) != 0 ) || ( StringUtil.StrCmp(A201RelPedCod, Z201RelPedCod) != 0 ) )
         {
            A199RelTipCod = Z199RelTipCod;
            AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
            A200RelDocNum = Z200RelDocNum;
            AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
            A201RelPedCod = Z201RelPedCod;
            AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RELTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtRelTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRelTipCod_Internalname;
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
         GetKey2N91( ) ;
         if ( RcdFound91 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "RELTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtRelTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A199RelTipCod, Z199RelTipCod) != 0 ) || ( StringUtil.StrCmp(A200RelDocNum, Z200RelDocNum) != 0 ) || ( StringUtil.StrCmp(A201RelPedCod, Z201RelPedCod) != 0 ) )
            {
               A199RelTipCod = Z199RelTipCod;
               AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
               A200RelDocNum = Z200RelDocNum;
               AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
               A201RelPedCod = Z201RelPedCod;
               AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "RELTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtRelTipCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A199RelTipCod, Z199RelTipCod) != 0 ) || ( StringUtil.StrCmp(A200RelDocNum, Z200RelDocNum) != 0 ) || ( StringUtil.StrCmp(A201RelPedCod, Z201RelPedCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RELTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtRelTipCod_Internalname;
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
         context.RollbackDataStores("clfacped",pr_default);
      }

      protected void insert_Check( )
      {
         CONFIRM_2N0( ) ;
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
         if ( RcdFound91 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "RELTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtRelTipCod_Internalname;
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
         ScanStart2N91( ) ;
         if ( RcdFound91 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd2N91( ) ;
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
         if ( RcdFound91 == 0 )
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
         if ( RcdFound91 == 0 )
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
         ScanStart2N91( ) ;
         if ( RcdFound91 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound91 != 0 )
            {
               ScanNext2N91( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd2N91( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2N91( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002N2 */
            pr_default.execute(0, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLFACPED"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLFACPED"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2N91( )
      {
         BeforeValidate2N91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N91( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2N91( 0) ;
            CheckOptimisticConcurrency2N91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2N91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002N8 */
                     pr_default.execute(6, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CLFACPED");
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
                           ResetCaption2N0( ) ;
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
               Load2N91( ) ;
            }
            EndLevel2N91( ) ;
         }
         CloseExtendedTableCursors2N91( ) ;
      }

      protected void Update2N91( )
      {
         BeforeValidate2N91( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N91( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N91( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N91( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2N91( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [CLFACPED] */
                     DeferredUpdate2N91( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2N0( ) ;
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
            EndLevel2N91( ) ;
         }
         CloseExtendedTableCursors2N91( ) ;
      }

      protected void DeferredUpdate2N91( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2N91( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N91( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2N91( ) ;
            AfterConfirm2N91( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2N91( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002N9 */
                  pr_default.execute(7, new Object[] {A199RelTipCod, A200RelDocNum, A201RelPedCod});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("CLFACPED");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound91 == 0 )
                        {
                           InitAll2N91( ) ;
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
                        ResetCaption2N0( ) ;
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
         sMode91 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2N91( ) ;
         Gx_mode = sMode91;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2N91( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2N91( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2N91( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clfacped",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clfacped",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2N91( )
      {
         /* Using cursor T002N10 */
         pr_default.execute(8);
         RcdFound91 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound91 = 1;
            A199RelTipCod = T002N10_A199RelTipCod[0];
            AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
            A200RelDocNum = T002N10_A200RelDocNum[0];
            AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
            A201RelPedCod = T002N10_A201RelPedCod[0];
            AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2N91( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound91 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound91 = 1;
            A199RelTipCod = T002N10_A199RelTipCod[0];
            AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
            A200RelDocNum = T002N10_A200RelDocNum[0];
            AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
            A201RelPedCod = T002N10_A201RelPedCod[0];
            AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
         }
      }

      protected void ScanEnd2N91( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2N91( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2N91( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2N91( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2N91( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2N91( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2N91( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2N91( )
      {
         edtRelTipCod_Enabled = 0;
         AssignProp("", false, edtRelTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelTipCod_Enabled), 5, 0), true);
         edtRelDocNum_Enabled = 0;
         AssignProp("", false, edtRelDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelDocNum_Enabled), 5, 0), true);
         edtRelPedCod_Enabled = 0;
         AssignProp("", false, edtRelPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelPedCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2N91( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810243613", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clfacped.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z199RelTipCod", StringUtil.RTrim( Z199RelTipCod));
         GxWebStd.gx_hidden_field( context, "Z200RelDocNum", StringUtil.RTrim( Z200RelDocNum));
         GxWebStd.gx_hidden_field( context, "Z201RelPedCod", StringUtil.RTrim( Z201RelPedCod));
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
         return formatLink("clfacped.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLFACPED" ;
      }

      public override string GetPgmdesc( )
      {
         return "Relación - Facturas Pedidos" ;
      }

      protected void InitializeNonKey2N91( )
      {
      }

      protected void InitAll2N91( )
      {
         A199RelTipCod = "";
         AssignAttri("", false, "A199RelTipCod", A199RelTipCod);
         A200RelDocNum = "";
         AssignAttri("", false, "A200RelDocNum", A200RelDocNum);
         A201RelPedCod = "";
         AssignAttri("", false, "A201RelPedCod", A201RelPedCod);
         InitializeNonKey2N91( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810243617", true, true);
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
         context.AddJavascriptSource("clfacped.js", "?202281810243617", false, true);
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
         edtRelTipCod_Internalname = "RELTIPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtRelDocNum_Internalname = "RELDOCNUM";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtRelPedCod_Internalname = "RELPEDCOD";
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
         Form.Caption = "Relación - Facturas Pedidos";
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
         edtRelPedCod_Jsonclick = "";
         edtRelPedCod_Enabled = 1;
         edtRelDocNum_Jsonclick = "";
         edtRelDocNum_Enabled = 1;
         edtRelTipCod_Jsonclick = "";
         edtRelTipCod_Enabled = 1;
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

      public void Valid_Relpedcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z199RelTipCod", StringUtil.RTrim( Z199RelTipCod));
         GxWebStd.gx_hidden_field( context, "Z200RelDocNum", StringUtil.RTrim( Z200RelDocNum));
         GxWebStd.gx_hidden_field( context, "Z201RelPedCod", StringUtil.RTrim( Z201RelPedCod));
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
         setEventMetadata("VALID_RELTIPCOD","{handler:'Valid_Reltipcod',iparms:[]");
         setEventMetadata("VALID_RELTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_RELDOCNUM","{handler:'Valid_Reldocnum',iparms:[]");
         setEventMetadata("VALID_RELDOCNUM",",oparms:[]}");
         setEventMetadata("VALID_RELPEDCOD","{handler:'Valid_Relpedcod',iparms:[{av:'A199RelTipCod',fld:'RELTIPCOD',pic:''},{av:'A200RelDocNum',fld:'RELDOCNUM',pic:''},{av:'A201RelPedCod',fld:'RELPEDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_RELPEDCOD",",oparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z199RelTipCod'},{av:'Z200RelDocNum'},{av:'Z201RelPedCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z199RelTipCod = "";
         Z200RelDocNum = "";
         Z201RelPedCod = "";
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
         A199RelTipCod = "";
         lblTextblock2_Jsonclick = "";
         A200RelDocNum = "";
         lblTextblock3_Jsonclick = "";
         A201RelPedCod = "";
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
         T002N4_A199RelTipCod = new string[] {""} ;
         T002N4_A200RelDocNum = new string[] {""} ;
         T002N4_A201RelPedCod = new string[] {""} ;
         T002N5_A199RelTipCod = new string[] {""} ;
         T002N5_A200RelDocNum = new string[] {""} ;
         T002N5_A201RelPedCod = new string[] {""} ;
         T002N3_A199RelTipCod = new string[] {""} ;
         T002N3_A200RelDocNum = new string[] {""} ;
         T002N3_A201RelPedCod = new string[] {""} ;
         sMode91 = "";
         T002N6_A199RelTipCod = new string[] {""} ;
         T002N6_A200RelDocNum = new string[] {""} ;
         T002N6_A201RelPedCod = new string[] {""} ;
         T002N7_A199RelTipCod = new string[] {""} ;
         T002N7_A200RelDocNum = new string[] {""} ;
         T002N7_A201RelPedCod = new string[] {""} ;
         T002N2_A199RelTipCod = new string[] {""} ;
         T002N2_A200RelDocNum = new string[] {""} ;
         T002N2_A201RelPedCod = new string[] {""} ;
         T002N10_A199RelTipCod = new string[] {""} ;
         T002N10_A200RelDocNum = new string[] {""} ;
         T002N10_A201RelPedCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ199RelTipCod = "";
         ZZ200RelDocNum = "";
         ZZ201RelPedCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clfacped__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clfacped__default(),
            new Object[][] {
                new Object[] {
               T002N2_A199RelTipCod, T002N2_A200RelDocNum, T002N2_A201RelPedCod
               }
               , new Object[] {
               T002N3_A199RelTipCod, T002N3_A200RelDocNum, T002N3_A201RelPedCod
               }
               , new Object[] {
               T002N4_A199RelTipCod, T002N4_A200RelDocNum, T002N4_A201RelPedCod
               }
               , new Object[] {
               T002N5_A199RelTipCod, T002N5_A200RelDocNum, T002N5_A201RelPedCod
               }
               , new Object[] {
               T002N6_A199RelTipCod, T002N6_A200RelDocNum, T002N6_A201RelPedCod
               }
               , new Object[] {
               T002N7_A199RelTipCod, T002N7_A200RelDocNum, T002N7_A201RelPedCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002N10_A199RelTipCod, T002N10_A200RelDocNum, T002N10_A201RelPedCod
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
      private short RcdFound91 ;
      private short nIsDirty_91 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtRelTipCod_Enabled ;
      private int edtRelDocNum_Enabled ;
      private int edtRelPedCod_Enabled ;
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
      private string Z199RelTipCod ;
      private string Z200RelDocNum ;
      private string Z201RelPedCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRelTipCod_Internalname ;
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
      private string A199RelTipCod ;
      private string edtRelTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtRelDocNum_Internalname ;
      private string A200RelDocNum ;
      private string edtRelDocNum_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtRelPedCod_Internalname ;
      private string A201RelPedCod ;
      private string edtRelPedCod_Jsonclick ;
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
      private string sMode91 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ199RelTipCod ;
      private string ZZ200RelDocNum ;
      private string ZZ201RelPedCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002N4_A199RelTipCod ;
      private string[] T002N4_A200RelDocNum ;
      private string[] T002N4_A201RelPedCod ;
      private string[] T002N5_A199RelTipCod ;
      private string[] T002N5_A200RelDocNum ;
      private string[] T002N5_A201RelPedCod ;
      private string[] T002N3_A199RelTipCod ;
      private string[] T002N3_A200RelDocNum ;
      private string[] T002N3_A201RelPedCod ;
      private string[] T002N6_A199RelTipCod ;
      private string[] T002N6_A200RelDocNum ;
      private string[] T002N6_A201RelPedCod ;
      private string[] T002N7_A199RelTipCod ;
      private string[] T002N7_A200RelDocNum ;
      private string[] T002N7_A201RelPedCod ;
      private string[] T002N2_A199RelTipCod ;
      private string[] T002N2_A200RelDocNum ;
      private string[] T002N2_A201RelPedCod ;
      private string[] T002N10_A199RelTipCod ;
      private string[] T002N10_A200RelDocNum ;
      private string[] T002N10_A201RelPedCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clfacped__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clfacped__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002N4;
        prmT002N4 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N5;
        prmT002N5 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N3;
        prmT002N3 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N6;
        prmT002N6 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N7;
        prmT002N7 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N2;
        prmT002N2 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N8;
        prmT002N8 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N9;
        prmT002N9 = new Object[] {
        new ParDef("@RelTipCod",GXType.NChar,3,0) ,
        new ParDef("@RelDocNum",GXType.NChar,12,0) ,
        new ParDef("@RelPedCod",GXType.NChar,10,0)
        };
        Object[] prmT002N10;
        prmT002N10 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002N2", "SELECT [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] WITH (UPDLOCK) WHERE [RelTipCod] = @RelTipCod AND [RelDocNum] = @RelDocNum AND [RelPedCod] = @RelPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002N3", "SELECT [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] WHERE [RelTipCod] = @RelTipCod AND [RelDocNum] = @RelDocNum AND [RelPedCod] = @RelPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002N4", "SELECT TM1.[RelTipCod], TM1.[RelDocNum], TM1.[RelPedCod] FROM [CLFACPED] TM1 WHERE TM1.[RelTipCod] = @RelTipCod and TM1.[RelDocNum] = @RelDocNum and TM1.[RelPedCod] = @RelPedCod ORDER BY TM1.[RelTipCod], TM1.[RelDocNum], TM1.[RelPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002N5", "SELECT [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] WHERE [RelTipCod] = @RelTipCod AND [RelDocNum] = @RelDocNum AND [RelPedCod] = @RelPedCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002N6", "SELECT TOP 1 [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] WHERE ( [RelTipCod] > @RelTipCod or [RelTipCod] = @RelTipCod and [RelDocNum] > @RelDocNum or [RelDocNum] = @RelDocNum and [RelTipCod] = @RelTipCod and [RelPedCod] > @RelPedCod) ORDER BY [RelTipCod], [RelDocNum], [RelPedCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002N7", "SELECT TOP 1 [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] WHERE ( [RelTipCod] < @RelTipCod or [RelTipCod] = @RelTipCod and [RelDocNum] < @RelDocNum or [RelDocNum] = @RelDocNum and [RelTipCod] = @RelTipCod and [RelPedCod] < @RelPedCod) ORDER BY [RelTipCod] DESC, [RelDocNum] DESC, [RelPedCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002N8", "INSERT INTO [CLFACPED]([RelTipCod], [RelDocNum], [RelPedCod]) VALUES(@RelTipCod, @RelDocNum, @RelPedCod)", GxErrorMask.GX_NOMASK,prmT002N8)
           ,new CursorDef("T002N9", "DELETE FROM [CLFACPED]  WHERE [RelTipCod] = @RelTipCod AND [RelDocNum] = @RelDocNum AND [RelPedCod] = @RelPedCod", GxErrorMask.GX_NOMASK,prmT002N9)
           ,new CursorDef("T002N10", "SELECT [RelTipCod], [RelDocNum], [RelPedCod] FROM [CLFACPED] ORDER BY [RelTipCod], [RelDocNum], [RelPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002N10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
     }
  }

}

}
