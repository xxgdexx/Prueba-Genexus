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
   public class poserconceptosdet : GXDataArea
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
            A332PSerConcCod = (int)(NumberUtil.Val( GetPar( "PSerConcCod"), "."));
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A332PSerConcCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A333PSerDConcCueCod = GetPar( "PSerDConcCueCod");
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A333PSerDConcCueCod) ;
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
            Form.Meta.addItem("description", "Detalle de Conceptos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poserconceptosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poserconceptosdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POSERCONCEPTOSDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A332PSerConcCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPSerConcCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A332PSerConcCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A332PSerConcCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerConcCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerConcCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERCONCEPTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cuenta", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDConcCueCod_Internalname, StringUtil.RTrim( A333PSerDConcCueCod), StringUtil.RTrim( context.localUtil.Format( A333PSerDConcCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDConcCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDConcCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cuenta", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPSerDConcCueDsc_Internalname, StringUtil.RTrim( A1801PSerDConcCueDsc), StringUtil.RTrim( context.localUtil.Format( A1801PSerDConcCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDConcCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDConcCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERCONCEPTOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POSERCONCEPTOSDET.htm");
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
            Z332PSerConcCod = (int)(context.localUtil.CToN( cgiGet( "Z332PSerConcCod"), ".", ","));
            Z333PSerDConcCueCod = cgiGet( "Z333PSerDConcCueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERCONCCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerConcCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A332PSerConcCod = 0;
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            }
            else
            {
               A332PSerConcCod = (int)(context.localUtil.CToN( cgiGet( edtPSerConcCod_Internalname), ".", ","));
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            }
            A333PSerDConcCueCod = cgiGet( edtPSerDConcCueCod_Internalname);
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
            A1801PSerDConcCueDsc = cgiGet( edtPSerDConcCueDsc_Internalname);
            AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
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
               A332PSerConcCod = (int)(NumberUtil.Val( GetPar( "PSerConcCod"), "."));
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               A333PSerDConcCueCod = GetPar( "PSerDConcCueCod");
               AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
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
               InitAll4J158( ) ;
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
         DisableAttributes4J158( ) ;
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

      protected void CONFIRM_4J0( )
      {
         BeforeValidate4J158( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4J158( ) ;
            }
            else
            {
               CheckExtendedTable4J158( ) ;
               if ( AnyError == 0 )
               {
                  ZM4J158( 2) ;
                  ZM4J158( 3) ;
               }
               CloseExtendedTableCursors4J158( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4J0( ) ;
         }
      }

      protected void ResetCaption4J0( )
      {
      }

      protected void ZM4J158( short GX_JID )
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
            Z332PSerConcCod = A332PSerConcCod;
            Z333PSerDConcCueCod = A333PSerDConcCueCod;
            Z1801PSerDConcCueDsc = A1801PSerDConcCueDsc;
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

      protected void Load4J158( )
      {
         /* Using cursor T004J6 */
         pr_default.execute(4, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound158 = 1;
            A1801PSerDConcCueDsc = T004J6_A1801PSerDConcCueDsc[0];
            AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
            ZM4J158( -1) ;
         }
         pr_default.close(4);
         OnLoadActions4J158( ) ;
      }

      protected void OnLoadActions4J158( )
      {
      }

      protected void CheckExtendedTable4J158( )
      {
         nIsDirty_158 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004J4 */
         pr_default.execute(2, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Servicios'.", "ForeignKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004J5 */
         pr_default.execute(3, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, "PSERDCONCCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1801PSerDConcCueDsc = T004J5_A1801PSerDConcCueDsc[0];
         AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors4J158( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A332PSerConcCod )
      {
         /* Using cursor T004J7 */
         pr_default.execute(5, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Servicios'.", "ForeignKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
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

      protected void gxLoad_3( string A333PSerDConcCueCod )
      {
         /* Using cursor T004J8 */
         pr_default.execute(6, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, "PSERDCONCCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1801PSerDConcCueDsc = T004J8_A1801PSerDConcCueDsc[0];
         AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1801PSerDConcCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey4J158( )
      {
         /* Using cursor T004J9 */
         pr_default.execute(7, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound158 = 1;
         }
         else
         {
            RcdFound158 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004J3 */
         pr_default.execute(1, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4J158( 1) ;
            RcdFound158 = 1;
            A332PSerConcCod = T004J3_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A333PSerDConcCueCod = T004J3_A333PSerDConcCueCod[0];
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
            Z332PSerConcCod = A332PSerConcCod;
            Z333PSerDConcCueCod = A333PSerDConcCueCod;
            sMode158 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4J158( ) ;
            if ( AnyError == 1 )
            {
               RcdFound158 = 0;
               InitializeNonKey4J158( ) ;
            }
            Gx_mode = sMode158;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound158 = 0;
            InitializeNonKey4J158( ) ;
            sMode158 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode158;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4J158( ) ;
         if ( RcdFound158 == 0 )
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
         RcdFound158 = 0;
         /* Using cursor T004J10 */
         pr_default.execute(8, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T004J10_A332PSerConcCod[0] < A332PSerConcCod ) || ( T004J10_A332PSerConcCod[0] == A332PSerConcCod ) && ( StringUtil.StrCmp(T004J10_A333PSerDConcCueCod[0], A333PSerDConcCueCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T004J10_A332PSerConcCod[0] > A332PSerConcCod ) || ( T004J10_A332PSerConcCod[0] == A332PSerConcCod ) && ( StringUtil.StrCmp(T004J10_A333PSerDConcCueCod[0], A333PSerDConcCueCod) > 0 ) ) )
            {
               A332PSerConcCod = T004J10_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               A333PSerDConcCueCod = T004J10_A333PSerDConcCueCod[0];
               AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
               RcdFound158 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound158 = 0;
         /* Using cursor T004J11 */
         pr_default.execute(9, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T004J11_A332PSerConcCod[0] > A332PSerConcCod ) || ( T004J11_A332PSerConcCod[0] == A332PSerConcCod ) && ( StringUtil.StrCmp(T004J11_A333PSerDConcCueCod[0], A333PSerDConcCueCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T004J11_A332PSerConcCod[0] < A332PSerConcCod ) || ( T004J11_A332PSerConcCod[0] == A332PSerConcCod ) && ( StringUtil.StrCmp(T004J11_A333PSerDConcCueCod[0], A333PSerDConcCueCod) < 0 ) ) )
            {
               A332PSerConcCod = T004J11_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               A333PSerDConcCueCod = T004J11_A333PSerDConcCueCod[0];
               AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
               RcdFound158 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4J158( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4J158( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound158 == 1 )
            {
               if ( ( A332PSerConcCod != Z332PSerConcCod ) || ( StringUtil.StrCmp(A333PSerDConcCueCod, Z333PSerDConcCueCod) != 0 ) )
               {
                  A332PSerConcCod = Z332PSerConcCod;
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
                  A333PSerDConcCueCod = Z333PSerDConcCueCod;
                  AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PSERCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4J158( ) ;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A332PSerConcCod != Z332PSerConcCod ) || ( StringUtil.StrCmp(A333PSerDConcCueCod, Z333PSerDConcCueCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4J158( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCONCCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPSerConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPSerConcCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4J158( ) ;
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
         if ( ( A332PSerConcCod != Z332PSerConcCod ) || ( StringUtil.StrCmp(A333PSerDConcCueCod, Z333PSerDConcCueCod) != 0 ) )
         {
            A332PSerConcCod = Z332PSerConcCod;
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A333PSerDConcCueCod = Z333PSerDConcCueCod;
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPSerConcCod_Internalname;
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
         GetKey4J158( ) ;
         if ( RcdFound158 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PSERCONCCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerConcCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A332PSerConcCod != Z332PSerConcCod ) || ( StringUtil.StrCmp(A333PSerDConcCueCod, Z333PSerDConcCueCod) != 0 ) )
            {
               A332PSerConcCod = Z332PSerConcCod;
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               A333PSerDConcCueCod = Z333PSerDConcCueCod;
               AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PSERCONCCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerConcCod_Internalname;
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
            if ( ( A332PSerConcCod != Z332PSerConcCod ) || ( StringUtil.StrCmp(A333PSerDConcCueCod, Z333PSerDConcCueCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCONCCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerConcCod_Internalname;
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
         context.RollbackDataStores("poserconceptosdet",pr_default);
      }

      protected void insert_Check( )
      {
         CONFIRM_4J0( ) ;
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
         if ( RcdFound158 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
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
         ScanStart4J158( ) ;
         if ( RcdFound158 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd4J158( ) ;
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
         if ( RcdFound158 == 0 )
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
         if ( RcdFound158 == 0 )
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
         ScanStart4J158( ) ;
         if ( RcdFound158 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound158 != 0 )
            {
               ScanNext4J158( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd4J158( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4J158( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004J2 */
            pr_default.execute(0, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERCONCEPTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4J158( )
      {
         BeforeValidate4J158( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4J158( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4J158( 0) ;
            CheckOptimisticConcurrency4J158( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4J158( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4J158( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004J12 */
                     pr_default.execute(10, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOSDET");
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
                           ResetCaption4J0( ) ;
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
               Load4J158( ) ;
            }
            EndLevel4J158( ) ;
         }
         CloseExtendedTableCursors4J158( ) ;
      }

      protected void Update4J158( )
      {
         BeforeValidate4J158( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4J158( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4J158( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4J158( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4J158( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [POSERCONCEPTOSDET] */
                     DeferredUpdate4J158( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4J0( ) ;
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
            EndLevel4J158( ) ;
         }
         CloseExtendedTableCursors4J158( ) ;
      }

      protected void DeferredUpdate4J158( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4J158( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4J158( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4J158( ) ;
            AfterConfirm4J158( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4J158( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004J13 */
                  pr_default.execute(11, new Object[] {A332PSerConcCod, A333PSerDConcCueCod});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound158 == 0 )
                        {
                           InitAll4J158( ) ;
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
                        ResetCaption4J0( ) ;
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
         sMode158 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4J158( ) ;
         Gx_mode = sMode158;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4J158( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004J14 */
            pr_default.execute(12, new Object[] {A333PSerDConcCueCod});
            A1801PSerDConcCueDsc = T004J14_A1801PSerDConcCueDsc[0];
            AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
            pr_default.close(12);
         }
      }

      protected void EndLevel4J158( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4J158( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("poserconceptosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("poserconceptosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4J158( )
      {
         /* Using cursor T004J15 */
         pr_default.execute(13);
         RcdFound158 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound158 = 1;
            A332PSerConcCod = T004J15_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A333PSerDConcCueCod = T004J15_A333PSerDConcCueCod[0];
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4J158( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound158 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound158 = 1;
            A332PSerConcCod = T004J15_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A333PSerDConcCueCod = T004J15_A333PSerDConcCueCod[0];
            AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
         }
      }

      protected void ScanEnd4J158( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm4J158( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4J158( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4J158( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4J158( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4J158( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4J158( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4J158( )
      {
         edtPSerConcCod_Enabled = 0;
         AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
         edtPSerDConcCueCod_Enabled = 0;
         AssignProp("", false, edtPSerDConcCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueCod_Enabled), 5, 0), true);
         edtPSerDConcCueDsc_Enabled = 0;
         AssignProp("", false, edtPSerDConcCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4J158( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253942", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poserconceptosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z332PSerConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z332PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z333PSerDConcCueCod", StringUtil.RTrim( Z333PSerDConcCueCod));
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
         return formatLink("poserconceptosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POSERCONCEPTOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle de Conceptos" ;
      }

      protected void InitializeNonKey4J158( )
      {
         A1801PSerDConcCueDsc = "";
         AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
      }

      protected void InitAll4J158( )
      {
         A332PSerConcCod = 0;
         AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         A333PSerDConcCueCod = "";
         AssignAttri("", false, "A333PSerDConcCueCod", A333PSerDConcCueCod);
         InitializeNonKey4J158( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253947", true, true);
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
         context.AddJavascriptSource("poserconceptosdet.js", "?202281810253947", false, true);
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
         edtPSerConcCod_Internalname = "PSERCONCCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPSerDConcCueCod_Internalname = "PSERDCONCCUECOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPSerDConcCueDsc_Internalname = "PSERDCONCCUEDSC";
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
         Form.Caption = "Detalle de Conceptos";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPSerDConcCueDsc_Jsonclick = "";
         edtPSerDConcCueDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPSerDConcCueCod_Jsonclick = "";
         edtPSerDConcCueCod_Enabled = 1;
         edtPSerConcCod_Jsonclick = "";
         edtPSerConcCod_Enabled = 1;
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
         /* Using cursor T004J16 */
         pr_default.execute(14, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Servicios'.", "ForeignKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T004J14 */
         pr_default.execute(12, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, "PSERDCONCCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1801PSerDConcCueDsc = T004J14_A1801PSerDConcCueDsc[0];
         AssignAttri("", false, "A1801PSerDConcCueDsc", A1801PSerDConcCueDsc);
         pr_default.close(12);
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

      public void Valid_Pserconccod( )
      {
         /* Using cursor T004J16 */
         pr_default.execute(14, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Conceptos de Servicios'.", "ForeignKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pserdconccuecod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T004J14 */
         pr_default.execute(12, new Object[] {A333PSerDConcCueCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de cuentas'.", "ForeignKeyNotFound", 1, "PSERDCONCCUECOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDConcCueCod_Internalname;
         }
         A1801PSerDConcCueDsc = T004J14_A1801PSerDConcCueDsc[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1801PSerDConcCueDsc", StringUtil.RTrim( A1801PSerDConcCueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z332PSerConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z332PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z333PSerDConcCueCod", StringUtil.RTrim( Z333PSerDConcCueCod));
         GxWebStd.gx_hidden_field( context, "Z1801PSerDConcCueDsc", StringUtil.RTrim( Z1801PSerDConcCueDsc));
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
         setEventMetadata("VALID_PSERCONCCOD","{handler:'Valid_Pserconccod',iparms:[{av:'A332PSerConcCod',fld:'PSERCONCCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PSERCONCCOD",",oparms:[]}");
         setEventMetadata("VALID_PSERDCONCCUECOD","{handler:'Valid_Pserdconccuecod',iparms:[{av:'A332PSerConcCod',fld:'PSERCONCCOD',pic:'ZZZZZ9'},{av:'A333PSerDConcCueCod',fld:'PSERDCONCCUECOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PSERDCONCCUECOD",",oparms:[{av:'A1801PSerDConcCueDsc',fld:'PSERDCONCCUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z332PSerConcCod'},{av:'Z333PSerDConcCueCod'},{av:'Z1801PSerDConcCueDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z333PSerDConcCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A333PSerDConcCueCod = "";
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
         A1801PSerDConcCueDsc = "";
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
         Z1801PSerDConcCueDsc = "";
         T004J6_A1801PSerDConcCueDsc = new string[] {""} ;
         T004J6_A332PSerConcCod = new int[1] ;
         T004J6_A333PSerDConcCueCod = new string[] {""} ;
         T004J4_A332PSerConcCod = new int[1] ;
         T004J5_A1801PSerDConcCueDsc = new string[] {""} ;
         T004J7_A332PSerConcCod = new int[1] ;
         T004J8_A1801PSerDConcCueDsc = new string[] {""} ;
         T004J9_A332PSerConcCod = new int[1] ;
         T004J9_A333PSerDConcCueCod = new string[] {""} ;
         T004J3_A332PSerConcCod = new int[1] ;
         T004J3_A333PSerDConcCueCod = new string[] {""} ;
         sMode158 = "";
         T004J10_A332PSerConcCod = new int[1] ;
         T004J10_A333PSerDConcCueCod = new string[] {""} ;
         T004J11_A332PSerConcCod = new int[1] ;
         T004J11_A333PSerDConcCueCod = new string[] {""} ;
         T004J2_A332PSerConcCod = new int[1] ;
         T004J2_A333PSerDConcCueCod = new string[] {""} ;
         T004J14_A1801PSerDConcCueDsc = new string[] {""} ;
         T004J15_A332PSerConcCod = new int[1] ;
         T004J15_A333PSerDConcCueCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004J16_A332PSerConcCod = new int[1] ;
         ZZ333PSerDConcCueCod = "";
         ZZ1801PSerDConcCueDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poserconceptosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poserconceptosdet__default(),
            new Object[][] {
                new Object[] {
               T004J2_A332PSerConcCod, T004J2_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J3_A332PSerConcCod, T004J3_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J4_A332PSerConcCod
               }
               , new Object[] {
               T004J5_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T004J6_A1801PSerDConcCueDsc, T004J6_A332PSerConcCod, T004J6_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J7_A332PSerConcCod
               }
               , new Object[] {
               T004J8_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T004J9_A332PSerConcCod, T004J9_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J10_A332PSerConcCod, T004J10_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J11_A332PSerConcCod, T004J11_A333PSerDConcCueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004J14_A1801PSerDConcCueDsc
               }
               , new Object[] {
               T004J15_A332PSerConcCod, T004J15_A333PSerDConcCueCod
               }
               , new Object[] {
               T004J16_A332PSerConcCod
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
      private short RcdFound158 ;
      private short nIsDirty_158 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z332PSerConcCod ;
      private int A332PSerConcCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPSerConcCod_Enabled ;
      private int edtPSerDConcCueCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPSerDConcCueDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ332PSerConcCod ;
      private string sPrefix ;
      private string Z333PSerDConcCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A333PSerDConcCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPSerConcCod_Internalname ;
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
      private string edtPSerConcCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPSerDConcCueCod_Internalname ;
      private string edtPSerDConcCueCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPSerDConcCueDsc_Internalname ;
      private string A1801PSerDConcCueDsc ;
      private string edtPSerDConcCueDsc_Jsonclick ;
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
      private string Z1801PSerDConcCueDsc ;
      private string sMode158 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ333PSerDConcCueCod ;
      private string ZZ1801PSerDConcCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004J6_A1801PSerDConcCueDsc ;
      private int[] T004J6_A332PSerConcCod ;
      private string[] T004J6_A333PSerDConcCueCod ;
      private int[] T004J4_A332PSerConcCod ;
      private string[] T004J5_A1801PSerDConcCueDsc ;
      private int[] T004J7_A332PSerConcCod ;
      private string[] T004J8_A1801PSerDConcCueDsc ;
      private int[] T004J9_A332PSerConcCod ;
      private string[] T004J9_A333PSerDConcCueCod ;
      private int[] T004J3_A332PSerConcCod ;
      private string[] T004J3_A333PSerDConcCueCod ;
      private int[] T004J10_A332PSerConcCod ;
      private string[] T004J10_A333PSerDConcCueCod ;
      private int[] T004J11_A332PSerConcCod ;
      private string[] T004J11_A333PSerDConcCueCod ;
      private int[] T004J2_A332PSerConcCod ;
      private string[] T004J2_A333PSerDConcCueCod ;
      private string[] T004J14_A1801PSerDConcCueDsc ;
      private int[] T004J15_A332PSerConcCod ;
      private string[] T004J15_A333PSerDConcCueCod ;
      private int[] T004J16_A332PSerConcCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poserconceptosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poserconceptosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT004J6;
        prmT004J6 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J4;
        prmT004J4 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004J5;
        prmT004J5 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J7;
        prmT004J7 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004J8;
        prmT004J8 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J9;
        prmT004J9 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J3;
        prmT004J3 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J10;
        prmT004J10 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J11;
        prmT004J11 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J2;
        prmT004J2 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J12;
        prmT004J12 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J13;
        prmT004J13 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004J15;
        prmT004J15 = new Object[] {
        };
        Object[] prmT004J16;
        prmT004J16 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004J14;
        prmT004J14 = new Object[] {
        new ParDef("@PSerDConcCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004J2", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WITH (UPDLOCK) WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J3", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J4", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J5", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J6", "SELECT T2.[CueDsc] AS PSerDConcCueDsc, TM1.[PSerConcCod], TM1.[PSerDConcCueCod] AS PSerDConcCueCod FROM ([POSERCONCEPTOSDET] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[PSerDConcCueCod]) WHERE TM1.[PSerConcCod] = @PSerConcCod and TM1.[PSerDConcCueCod] = @PSerDConcCueCod ORDER BY TM1.[PSerConcCod], TM1.[PSerDConcCueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004J6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J7", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J8", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J9", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J10", "SELECT TOP 1 [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE ( [PSerConcCod] > @PSerConcCod or [PSerConcCod] = @PSerConcCod and [PSerDConcCueCod] > @PSerDConcCueCod) ORDER BY [PSerConcCod], [PSerDConcCueCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004J11", "SELECT TOP 1 [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] WHERE ( [PSerConcCod] < @PSerConcCod or [PSerConcCod] = @PSerConcCod and [PSerDConcCueCod] < @PSerDConcCueCod) ORDER BY [PSerConcCod] DESC, [PSerDConcCueCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004J12", "INSERT INTO [POSERCONCEPTOSDET]([PSerConcCod], [PSerDConcCueCod]) VALUES(@PSerConcCod, @PSerDConcCueCod)", GxErrorMask.GX_NOMASK,prmT004J12)
           ,new CursorDef("T004J13", "DELETE FROM [POSERCONCEPTOSDET]  WHERE [PSerConcCod] = @PSerConcCod AND [PSerDConcCueCod] = @PSerDConcCueCod", GxErrorMask.GX_NOMASK,prmT004J13)
           ,new CursorDef("T004J14", "SELECT [CueDsc] AS PSerDConcCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @PSerDConcCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J15", "SELECT [PSerConcCod], [PSerDConcCueCod] AS PSerDConcCueCod FROM [POSERCONCEPTOSDET] ORDER BY [PSerConcCod], [PSerDConcCueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004J15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004J16", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004J16,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
