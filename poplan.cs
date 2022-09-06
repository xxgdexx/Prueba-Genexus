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
   public class poplan : GXDataArea
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
            Form.Meta.addItem("description", "Cabacera Plan de Producción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProPlanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poplan( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poplan( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POPLAN.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Plan", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProPlanCod_Internalname, StringUtil.RTrim( A324ProPlanCod), StringUtil.RTrim( context.localUtil.Format( A324ProPlanCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProPlanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProPlanCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProPlanFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProPlanFec_Internalname, context.localUtil.Format(A1734ProPlanFec, "99/99/99"), context.localUtil.Format( A1734ProPlanFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProPlanFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProPlanFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POPLAN.htm");
         GxWebStd.gx_bitmap( context, edtProPlanFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProPlanFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_POPLAN.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Concepto Plan", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProPlanTit_Internalname, StringUtil.RTrim( A1737ProPlanTit), StringUtil.RTrim( context.localUtil.Format( A1737ProPlanTit, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProPlanTit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProPlanTit_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Observaciones", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProPlanObs_Internalname, A1735ProPlanObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtProPlanObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Estado", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POPLAN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProPlanSts_Internalname, StringUtil.RTrim( A1736ProPlanSts), StringUtil.RTrim( context.localUtil.Format( A1736ProPlanSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProPlanSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProPlanSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POPLAN.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POPLAN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POPLAN.htm");
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
            Z324ProPlanCod = cgiGet( "Z324ProPlanCod");
            Z1734ProPlanFec = context.localUtil.CToD( cgiGet( "Z1734ProPlanFec"), 0);
            Z1737ProPlanTit = cgiGet( "Z1737ProPlanTit");
            Z1736ProPlanSts = cgiGet( "Z1736ProPlanSts");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A324ProPlanCod = cgiGet( edtProPlanCod_Internalname);
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            if ( context.localUtil.VCDate( cgiGet( edtProPlanFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "PROPLANFEC");
               AnyError = 1;
               GX_FocusControl = edtProPlanFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1734ProPlanFec = DateTime.MinValue;
               AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
            }
            else
            {
               A1734ProPlanFec = context.localUtil.CToD( cgiGet( edtProPlanFec_Internalname), 2);
               AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
            }
            A1737ProPlanTit = cgiGet( edtProPlanTit_Internalname);
            AssignAttri("", false, "A1737ProPlanTit", A1737ProPlanTit);
            A1735ProPlanObs = cgiGet( edtProPlanObs_Internalname);
            AssignAttri("", false, "A1735ProPlanObs", A1735ProPlanObs);
            A1736ProPlanSts = cgiGet( edtProPlanSts_Internalname);
            AssignAttri("", false, "A1736ProPlanSts", A1736ProPlanSts);
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
               A324ProPlanCod = GetPar( "ProPlanCod");
               AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
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
               InitAll4G155( ) ;
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
         DisableAttributes4G155( ) ;
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

      protected void CONFIRM_4G0( )
      {
         BeforeValidate4G155( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4G155( ) ;
            }
            else
            {
               CheckExtendedTable4G155( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors4G155( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4G0( ) ;
         }
      }

      protected void ResetCaption4G0( )
      {
      }

      protected void ZM4G155( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1734ProPlanFec = T004G3_A1734ProPlanFec[0];
               Z1737ProPlanTit = T004G3_A1737ProPlanTit[0];
               Z1736ProPlanSts = T004G3_A1736ProPlanSts[0];
            }
            else
            {
               Z1734ProPlanFec = A1734ProPlanFec;
               Z1737ProPlanTit = A1737ProPlanTit;
               Z1736ProPlanSts = A1736ProPlanSts;
            }
         }
         if ( GX_JID == -2 )
         {
            Z324ProPlanCod = A324ProPlanCod;
            Z1734ProPlanFec = A1734ProPlanFec;
            Z1737ProPlanTit = A1737ProPlanTit;
            Z1735ProPlanObs = A1735ProPlanObs;
            Z1736ProPlanSts = A1736ProPlanSts;
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

      protected void Load4G155( )
      {
         /* Using cursor T004G4 */
         pr_default.execute(2, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound155 = 1;
            A1734ProPlanFec = T004G4_A1734ProPlanFec[0];
            AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
            A1737ProPlanTit = T004G4_A1737ProPlanTit[0];
            AssignAttri("", false, "A1737ProPlanTit", A1737ProPlanTit);
            A1735ProPlanObs = T004G4_A1735ProPlanObs[0];
            AssignAttri("", false, "A1735ProPlanObs", A1735ProPlanObs);
            A1736ProPlanSts = T004G4_A1736ProPlanSts[0];
            AssignAttri("", false, "A1736ProPlanSts", A1736ProPlanSts);
            ZM4G155( -2) ;
         }
         pr_default.close(2);
         OnLoadActions4G155( ) ;
      }

      protected void OnLoadActions4G155( )
      {
      }

      protected void CheckExtendedTable4G155( )
      {
         nIsDirty_155 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1734ProPlanFec) || ( DateTimeUtil.ResetTime ( A1734ProPlanFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "PROPLANFEC");
            AnyError = 1;
            GX_FocusControl = edtProPlanFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors4G155( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey4G155( )
      {
         /* Using cursor T004G5 */
         pr_default.execute(3, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound155 = 1;
         }
         else
         {
            RcdFound155 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004G3 */
         pr_default.execute(1, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4G155( 2) ;
            RcdFound155 = 1;
            A324ProPlanCod = T004G3_A324ProPlanCod[0];
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            A1734ProPlanFec = T004G3_A1734ProPlanFec[0];
            AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
            A1737ProPlanTit = T004G3_A1737ProPlanTit[0];
            AssignAttri("", false, "A1737ProPlanTit", A1737ProPlanTit);
            A1735ProPlanObs = T004G3_A1735ProPlanObs[0];
            AssignAttri("", false, "A1735ProPlanObs", A1735ProPlanObs);
            A1736ProPlanSts = T004G3_A1736ProPlanSts[0];
            AssignAttri("", false, "A1736ProPlanSts", A1736ProPlanSts);
            Z324ProPlanCod = A324ProPlanCod;
            sMode155 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4G155( ) ;
            if ( AnyError == 1 )
            {
               RcdFound155 = 0;
               InitializeNonKey4G155( ) ;
            }
            Gx_mode = sMode155;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound155 = 0;
            InitializeNonKey4G155( ) ;
            sMode155 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode155;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4G155( ) ;
         if ( RcdFound155 == 0 )
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
         RcdFound155 = 0;
         /* Using cursor T004G6 */
         pr_default.execute(4, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T004G6_A324ProPlanCod[0], A324ProPlanCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T004G6_A324ProPlanCod[0], A324ProPlanCod) > 0 ) ) )
            {
               A324ProPlanCod = T004G6_A324ProPlanCod[0];
               AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
               RcdFound155 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound155 = 0;
         /* Using cursor T004G7 */
         pr_default.execute(5, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T004G7_A324ProPlanCod[0], A324ProPlanCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T004G7_A324ProPlanCod[0], A324ProPlanCod) < 0 ) ) )
            {
               A324ProPlanCod = T004G7_A324ProPlanCod[0];
               AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
               RcdFound155 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4G155( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProPlanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4G155( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound155 == 1 )
            {
               if ( StringUtil.StrCmp(A324ProPlanCod, Z324ProPlanCod) != 0 )
               {
                  A324ProPlanCod = Z324ProPlanCod;
                  AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPLANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProPlanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProPlanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4G155( ) ;
                  GX_FocusControl = edtProPlanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A324ProPlanCod, Z324ProPlanCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProPlanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4G155( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPLANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProPlanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProPlanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4G155( ) ;
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
         if ( StringUtil.StrCmp(A324ProPlanCod, Z324ProPlanCod) != 0 )
         {
            A324ProPlanCod = Z324ProPlanCod;
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPLANCOD");
            AnyError = 1;
            GX_FocusControl = edtProPlanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProPlanCod_Internalname;
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
         GetKey4G155( ) ;
         if ( RcdFound155 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROPLANCOD");
               AnyError = 1;
               GX_FocusControl = edtProPlanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A324ProPlanCod, Z324ProPlanCod) != 0 )
            {
               A324ProPlanCod = Z324ProPlanCod;
               AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PROPLANCOD");
               AnyError = 1;
               GX_FocusControl = edtProPlanCod_Internalname;
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
            if ( StringUtil.StrCmp(A324ProPlanCod, Z324ProPlanCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPLANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProPlanCod_Internalname;
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
         context.RollbackDataStores("poplan",pr_default);
         GX_FocusControl = edtProPlanFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4G0( ) ;
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
         if ( RcdFound155 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROPLANCOD");
            AnyError = 1;
            GX_FocusControl = edtProPlanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProPlanFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4G155( ) ;
         if ( RcdFound155 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProPlanFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4G155( ) ;
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
         if ( RcdFound155 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProPlanFec_Internalname;
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
         if ( RcdFound155 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProPlanFec_Internalname;
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
         ScanStart4G155( ) ;
         if ( RcdFound155 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound155 != 0 )
            {
               ScanNext4G155( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProPlanFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4G155( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4G155( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004G2 */
            pr_default.execute(0, new Object[] {A324ProPlanCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POPLAN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1734ProPlanFec ) != DateTimeUtil.ResetTime ( T004G2_A1734ProPlanFec[0] ) ) || ( StringUtil.StrCmp(Z1737ProPlanTit, T004G2_A1737ProPlanTit[0]) != 0 ) || ( StringUtil.StrCmp(Z1736ProPlanSts, T004G2_A1736ProPlanSts[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1734ProPlanFec ) != DateTimeUtil.ResetTime ( T004G2_A1734ProPlanFec[0] ) )
               {
                  GXUtil.WriteLog("poplan:[seudo value changed for attri]"+"ProPlanFec");
                  GXUtil.WriteLogRaw("Old: ",Z1734ProPlanFec);
                  GXUtil.WriteLogRaw("Current: ",T004G2_A1734ProPlanFec[0]);
               }
               if ( StringUtil.StrCmp(Z1737ProPlanTit, T004G2_A1737ProPlanTit[0]) != 0 )
               {
                  GXUtil.WriteLog("poplan:[seudo value changed for attri]"+"ProPlanTit");
                  GXUtil.WriteLogRaw("Old: ",Z1737ProPlanTit);
                  GXUtil.WriteLogRaw("Current: ",T004G2_A1737ProPlanTit[0]);
               }
               if ( StringUtil.StrCmp(Z1736ProPlanSts, T004G2_A1736ProPlanSts[0]) != 0 )
               {
                  GXUtil.WriteLog("poplan:[seudo value changed for attri]"+"ProPlanSts");
                  GXUtil.WriteLogRaw("Old: ",Z1736ProPlanSts);
                  GXUtil.WriteLogRaw("Current: ",T004G2_A1736ProPlanSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POPLAN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4G155( )
      {
         BeforeValidate4G155( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4G155( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4G155( 0) ;
            CheckOptimisticConcurrency4G155( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4G155( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4G155( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004G8 */
                     pr_default.execute(6, new Object[] {A324ProPlanCod, A1734ProPlanFec, A1737ProPlanTit, A1735ProPlanObs, A1736ProPlanSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("POPLAN");
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
                           ResetCaption4G0( ) ;
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
               Load4G155( ) ;
            }
            EndLevel4G155( ) ;
         }
         CloseExtendedTableCursors4G155( ) ;
      }

      protected void Update4G155( )
      {
         BeforeValidate4G155( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4G155( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4G155( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4G155( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4G155( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004G9 */
                     pr_default.execute(7, new Object[] {A1734ProPlanFec, A1737ProPlanTit, A1735ProPlanObs, A1736ProPlanSts, A324ProPlanCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("POPLAN");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POPLAN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4G155( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4G0( ) ;
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
            EndLevel4G155( ) ;
         }
         CloseExtendedTableCursors4G155( ) ;
      }

      protected void DeferredUpdate4G155( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4G155( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4G155( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4G155( ) ;
            AfterConfirm4G155( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4G155( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004G10 */
                  pr_default.execute(8, new Object[] {A324ProPlanCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("POPLAN");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound155 == 0 )
                        {
                           InitAll4G155( ) ;
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
                        ResetCaption4G0( ) ;
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
         sMode155 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4G155( ) ;
         Gx_mode = sMode155;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4G155( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T004G11 */
            pr_default.execute(9, new Object[] {A324ProPlanCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T004G12 */
            pr_default.execute(10, new Object[] {A324ProPlanCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Plan de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel4G155( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4G155( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("poplan",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("poplan",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4G155( )
      {
         /* Using cursor T004G13 */
         pr_default.execute(11);
         RcdFound155 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound155 = 1;
            A324ProPlanCod = T004G13_A324ProPlanCod[0];
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4G155( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound155 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound155 = 1;
            A324ProPlanCod = T004G13_A324ProPlanCod[0];
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
         }
      }

      protected void ScanEnd4G155( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm4G155( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4G155( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4G155( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4G155( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4G155( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4G155( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4G155( )
      {
         edtProPlanCod_Enabled = 0;
         AssignProp("", false, edtProPlanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanCod_Enabled), 5, 0), true);
         edtProPlanFec_Enabled = 0;
         AssignProp("", false, edtProPlanFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanFec_Enabled), 5, 0), true);
         edtProPlanTit_Enabled = 0;
         AssignProp("", false, edtProPlanTit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanTit_Enabled), 5, 0), true);
         edtProPlanObs_Enabled = 0;
         AssignProp("", false, edtProPlanObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanObs_Enabled), 5, 0), true);
         edtProPlanSts_Enabled = 0;
         AssignProp("", false, edtProPlanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4G155( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253784", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poplan.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z324ProPlanCod", StringUtil.RTrim( Z324ProPlanCod));
         GxWebStd.gx_hidden_field( context, "Z1734ProPlanFec", context.localUtil.DToC( Z1734ProPlanFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1737ProPlanTit", StringUtil.RTrim( Z1737ProPlanTit));
         GxWebStd.gx_hidden_field( context, "Z1736ProPlanSts", StringUtil.RTrim( Z1736ProPlanSts));
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
         return formatLink("poplan.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POPLAN" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cabacera Plan de Producción" ;
      }

      protected void InitializeNonKey4G155( )
      {
         A1734ProPlanFec = DateTime.MinValue;
         AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
         A1737ProPlanTit = "";
         AssignAttri("", false, "A1737ProPlanTit", A1737ProPlanTit);
         A1735ProPlanObs = "";
         AssignAttri("", false, "A1735ProPlanObs", A1735ProPlanObs);
         A1736ProPlanSts = "";
         AssignAttri("", false, "A1736ProPlanSts", A1736ProPlanSts);
         Z1734ProPlanFec = DateTime.MinValue;
         Z1737ProPlanTit = "";
         Z1736ProPlanSts = "";
      }

      protected void InitAll4G155( )
      {
         A324ProPlanCod = "";
         AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
         InitializeNonKey4G155( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253789", true, true);
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
         context.AddJavascriptSource("poplan.js", "?202281810253789", false, true);
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
         edtProPlanCod_Internalname = "PROPLANCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProPlanFec_Internalname = "PROPLANFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProPlanTit_Internalname = "PROPLANTIT";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProPlanObs_Internalname = "PROPLANOBS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProPlanSts_Internalname = "PROPLANSTS";
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
         Form.Caption = "Cabacera Plan de Producción";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProPlanSts_Jsonclick = "";
         edtProPlanSts_Enabled = 1;
         edtProPlanObs_Enabled = 1;
         edtProPlanTit_Jsonclick = "";
         edtProPlanTit_Enabled = 1;
         edtProPlanFec_Jsonclick = "";
         edtProPlanFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProPlanCod_Jsonclick = "";
         edtProPlanCod_Enabled = 1;
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
         GX_FocusControl = edtProPlanFec_Internalname;
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

      public void Valid_Proplancod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1734ProPlanFec", context.localUtil.Format(A1734ProPlanFec, "99/99/99"));
         AssignAttri("", false, "A1737ProPlanTit", StringUtil.RTrim( A1737ProPlanTit));
         AssignAttri("", false, "A1735ProPlanObs", A1735ProPlanObs);
         AssignAttri("", false, "A1736ProPlanSts", StringUtil.RTrim( A1736ProPlanSts));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z324ProPlanCod", StringUtil.RTrim( Z324ProPlanCod));
         GxWebStd.gx_hidden_field( context, "Z1734ProPlanFec", context.localUtil.Format(Z1734ProPlanFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1737ProPlanTit", StringUtil.RTrim( Z1737ProPlanTit));
         GxWebStd.gx_hidden_field( context, "Z1735ProPlanObs", Z1735ProPlanObs);
         GxWebStd.gx_hidden_field( context, "Z1736ProPlanSts", StringUtil.RTrim( Z1736ProPlanSts));
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
         setEventMetadata("VALID_PROPLANCOD","{handler:'Valid_Proplancod',iparms:[{av:'A324ProPlanCod',fld:'PROPLANCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROPLANCOD",",oparms:[{av:'A1734ProPlanFec',fld:'PROPLANFEC',pic:''},{av:'A1737ProPlanTit',fld:'PROPLANTIT',pic:''},{av:'A1735ProPlanObs',fld:'PROPLANOBS',pic:''},{av:'A1736ProPlanSts',fld:'PROPLANSTS',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z324ProPlanCod'},{av:'Z1734ProPlanFec'},{av:'Z1737ProPlanTit'},{av:'Z1735ProPlanObs'},{av:'Z1736ProPlanSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROPLANFEC","{handler:'Valid_Proplanfec',iparms:[]");
         setEventMetadata("VALID_PROPLANFEC",",oparms:[]}");
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
         Z324ProPlanCod = "";
         Z1734ProPlanFec = DateTime.MinValue;
         Z1737ProPlanTit = "";
         Z1736ProPlanSts = "";
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
         A324ProPlanCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1734ProPlanFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         A1737ProPlanTit = "";
         lblTextblock4_Jsonclick = "";
         A1735ProPlanObs = "";
         lblTextblock5_Jsonclick = "";
         A1736ProPlanSts = "";
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
         Z1735ProPlanObs = "";
         T004G4_A324ProPlanCod = new string[] {""} ;
         T004G4_A1734ProPlanFec = new DateTime[] {DateTime.MinValue} ;
         T004G4_A1737ProPlanTit = new string[] {""} ;
         T004G4_A1735ProPlanObs = new string[] {""} ;
         T004G4_A1736ProPlanSts = new string[] {""} ;
         T004G5_A324ProPlanCod = new string[] {""} ;
         T004G3_A324ProPlanCod = new string[] {""} ;
         T004G3_A1734ProPlanFec = new DateTime[] {DateTime.MinValue} ;
         T004G3_A1737ProPlanTit = new string[] {""} ;
         T004G3_A1735ProPlanObs = new string[] {""} ;
         T004G3_A1736ProPlanSts = new string[] {""} ;
         sMode155 = "";
         T004G6_A324ProPlanCod = new string[] {""} ;
         T004G7_A324ProPlanCod = new string[] {""} ;
         T004G2_A324ProPlanCod = new string[] {""} ;
         T004G2_A1734ProPlanFec = new DateTime[] {DateTime.MinValue} ;
         T004G2_A1737ProPlanTit = new string[] {""} ;
         T004G2_A1735ProPlanObs = new string[] {""} ;
         T004G2_A1736ProPlanSts = new string[] {""} ;
         T004G11_A322ProCod = new string[] {""} ;
         T004G12_A324ProPlanCod = new string[] {""} ;
         T004G12_A331ProPlanDProdCod = new string[] {""} ;
         T004G13_A324ProPlanCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ324ProPlanCod = "";
         ZZ1734ProPlanFec = DateTime.MinValue;
         ZZ1737ProPlanTit = "";
         ZZ1735ProPlanObs = "";
         ZZ1736ProPlanSts = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poplan__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poplan__default(),
            new Object[][] {
                new Object[] {
               T004G2_A324ProPlanCod, T004G2_A1734ProPlanFec, T004G2_A1737ProPlanTit, T004G2_A1735ProPlanObs, T004G2_A1736ProPlanSts
               }
               , new Object[] {
               T004G3_A324ProPlanCod, T004G3_A1734ProPlanFec, T004G3_A1737ProPlanTit, T004G3_A1735ProPlanObs, T004G3_A1736ProPlanSts
               }
               , new Object[] {
               T004G4_A324ProPlanCod, T004G4_A1734ProPlanFec, T004G4_A1737ProPlanTit, T004G4_A1735ProPlanObs, T004G4_A1736ProPlanSts
               }
               , new Object[] {
               T004G5_A324ProPlanCod
               }
               , new Object[] {
               T004G6_A324ProPlanCod
               }
               , new Object[] {
               T004G7_A324ProPlanCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004G11_A322ProCod
               }
               , new Object[] {
               T004G12_A324ProPlanCod, T004G12_A331ProPlanDProdCod
               }
               , new Object[] {
               T004G13_A324ProPlanCod
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
      private short RcdFound155 ;
      private short nIsDirty_155 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProPlanCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProPlanFec_Enabled ;
      private int edtProPlanTit_Enabled ;
      private int edtProPlanObs_Enabled ;
      private int edtProPlanSts_Enabled ;
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
      private string Z324ProPlanCod ;
      private string Z1737ProPlanTit ;
      private string Z1736ProPlanSts ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProPlanCod_Internalname ;
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
      private string A324ProPlanCod ;
      private string edtProPlanCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProPlanFec_Internalname ;
      private string edtProPlanFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProPlanTit_Internalname ;
      private string A1737ProPlanTit ;
      private string edtProPlanTit_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProPlanObs_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProPlanSts_Internalname ;
      private string A1736ProPlanSts ;
      private string edtProPlanSts_Jsonclick ;
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
      private string sMode155 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ324ProPlanCod ;
      private string ZZ1737ProPlanTit ;
      private string ZZ1736ProPlanSts ;
      private DateTime Z1734ProPlanFec ;
      private DateTime A1734ProPlanFec ;
      private DateTime ZZ1734ProPlanFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A1735ProPlanObs ;
      private string Z1735ProPlanObs ;
      private string ZZ1735ProPlanObs ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004G4_A324ProPlanCod ;
      private DateTime[] T004G4_A1734ProPlanFec ;
      private string[] T004G4_A1737ProPlanTit ;
      private string[] T004G4_A1735ProPlanObs ;
      private string[] T004G4_A1736ProPlanSts ;
      private string[] T004G5_A324ProPlanCod ;
      private string[] T004G3_A324ProPlanCod ;
      private DateTime[] T004G3_A1734ProPlanFec ;
      private string[] T004G3_A1737ProPlanTit ;
      private string[] T004G3_A1735ProPlanObs ;
      private string[] T004G3_A1736ProPlanSts ;
      private string[] T004G6_A324ProPlanCod ;
      private string[] T004G7_A324ProPlanCod ;
      private string[] T004G2_A324ProPlanCod ;
      private DateTime[] T004G2_A1734ProPlanFec ;
      private string[] T004G2_A1737ProPlanTit ;
      private string[] T004G2_A1735ProPlanObs ;
      private string[] T004G2_A1736ProPlanSts ;
      private string[] T004G11_A322ProCod ;
      private string[] T004G12_A324ProPlanCod ;
      private string[] T004G12_A331ProPlanDProdCod ;
      private string[] T004G13_A324ProPlanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poplan__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poplan__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT004G4;
        prmT004G4 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G5;
        prmT004G5 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G3;
        prmT004G3 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G6;
        prmT004G6 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G7;
        prmT004G7 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G2;
        prmT004G2 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G8;
        prmT004G8 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0) ,
        new ParDef("@ProPlanFec",GXType.Date,8,0) ,
        new ParDef("@ProPlanTit",GXType.NChar,100,0) ,
        new ParDef("@ProPlanObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProPlanSts",GXType.NChar,1,0)
        };
        Object[] prmT004G9;
        prmT004G9 = new Object[] {
        new ParDef("@ProPlanFec",GXType.Date,8,0) ,
        new ParDef("@ProPlanTit",GXType.NChar,100,0) ,
        new ParDef("@ProPlanObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProPlanSts",GXType.NChar,1,0) ,
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G10;
        prmT004G10 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G11;
        prmT004G11 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G12;
        prmT004G12 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT004G13;
        prmT004G13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T004G2", "SELECT [ProPlanCod], [ProPlanFec], [ProPlanTit], [ProPlanObs], [ProPlanSts] FROM [POPLAN] WITH (UPDLOCK) WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004G3", "SELECT [ProPlanCod], [ProPlanFec], [ProPlanTit], [ProPlanObs], [ProPlanSts] FROM [POPLAN] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004G4", "SELECT TM1.[ProPlanCod], TM1.[ProPlanFec], TM1.[ProPlanTit], TM1.[ProPlanObs], TM1.[ProPlanSts] FROM [POPLAN] TM1 WHERE TM1.[ProPlanCod] = @ProPlanCod ORDER BY TM1.[ProPlanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004G4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004G5", "SELECT [ProPlanCod] FROM [POPLAN] WHERE [ProPlanCod] = @ProPlanCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004G6", "SELECT TOP 1 [ProPlanCod] FROM [POPLAN] WHERE ( [ProPlanCod] > @ProPlanCod) ORDER BY [ProPlanCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004G6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004G7", "SELECT TOP 1 [ProPlanCod] FROM [POPLAN] WHERE ( [ProPlanCod] < @ProPlanCod) ORDER BY [ProPlanCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004G7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004G8", "INSERT INTO [POPLAN]([ProPlanCod], [ProPlanFec], [ProPlanTit], [ProPlanObs], [ProPlanSts]) VALUES(@ProPlanCod, @ProPlanFec, @ProPlanTit, @ProPlanObs, @ProPlanSts)", GxErrorMask.GX_NOMASK,prmT004G8)
           ,new CursorDef("T004G9", "UPDATE [POPLAN] SET [ProPlanFec]=@ProPlanFec, [ProPlanTit]=@ProPlanTit, [ProPlanObs]=@ProPlanObs, [ProPlanSts]=@ProPlanSts  WHERE [ProPlanCod] = @ProPlanCod", GxErrorMask.GX_NOMASK,prmT004G9)
           ,new CursorDef("T004G10", "DELETE FROM [POPLAN]  WHERE [ProPlanCod] = @ProPlanCod", GxErrorMask.GX_NOMASK,prmT004G10)
           ,new CursorDef("T004G11", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004G11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004G12", "SELECT TOP 1 [ProPlanCod], [ProPlanDProdCod] FROM [POPLANDET] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004G13", "SELECT [ProPlanCod] FROM [POPLAN] ORDER BY [ProPlanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004G13,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
