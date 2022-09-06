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
   public class cemptransporte : GXDataArea
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
            Form.Meta.addItem("description", "Empresa de Transporte", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cemptransporte( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cemptransporte( IGxContext context )
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
         cmbEmpTSts = new GXCombobox();
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
         if ( cmbEmpTSts.ItemCount > 0 )
         {
            A967EmpTSts = (short)(NumberUtil.Val( cmbEmpTSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0))), "."));
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            AssignProp("", false, cmbEmpTSts_Internalname, "Values", cmbEmpTSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CEMPTRANSPORTE.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EmpTCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEmpTCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Empresa de Transporte", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTDsc_Internalname, A964EmpTDsc, StringUtil.RTrim( context.localUtil.Format( A964EmpTDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmptDir_Internalname, A963EmptDir, StringUtil.RTrim( context.localUtil.Format( A963EmptDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmptDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmptDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "R.U.C.", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTRuc_Internalname, A966EmpTRuc, StringUtil.RTrim( context.localUtil.Format( A966EmpTRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTRuc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Estado", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CEMPTRANSPORTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEmpTSts, cmbEmpTSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0)), 1, cmbEmpTSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEmpTSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CEMPTRANSPORTE.htm");
         cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         AssignProp("", false, cmbEmpTSts_Internalname, "Values", (string)(cmbEmpTSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CEMPTRANSPORTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CEMPTRANSPORTE.htm");
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
            Z17EmpTCod = (int)(context.localUtil.CToN( cgiGet( "Z17EmpTCod"), ".", ","));
            Z964EmpTDsc = cgiGet( "Z964EmpTDsc");
            Z963EmptDir = cgiGet( "Z963EmptDir");
            Z966EmpTRuc = cgiGet( "Z966EmpTRuc");
            Z967EmpTSts = (short)(context.localUtil.CToN( cgiGet( "Z967EmpTSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17EmpTCod = 0;
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            }
            else
            {
               A17EmpTCod = (int)(context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ","));
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            }
            A964EmpTDsc = cgiGet( edtEmpTDsc_Internalname);
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            A963EmptDir = cgiGet( edtEmptDir_Internalname);
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            A966EmpTRuc = cgiGet( edtEmpTRuc_Internalname);
            AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
            cmbEmpTSts.CurrentValue = cgiGet( cmbEmpTSts_Internalname);
            A967EmpTSts = (short)(NumberUtil.Val( cgiGet( cmbEmpTSts_Internalname), "."));
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
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
               A17EmpTCod = (int)(NumberUtil.Val( GetPar( "EmpTCod"), "."));
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
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
               InitAll2978( ) ;
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
         DisableAttributes2978( ) ;
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

      protected void CONFIRM_290( )
      {
         BeforeValidate2978( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2978( ) ;
            }
            else
            {
               CheckExtendedTable2978( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2978( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues290( ) ;
         }
      }

      protected void ResetCaption290( )
      {
      }

      protected void ZM2978( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z964EmpTDsc = T00293_A964EmpTDsc[0];
               Z963EmptDir = T00293_A963EmptDir[0];
               Z966EmpTRuc = T00293_A966EmpTRuc[0];
               Z967EmpTSts = T00293_A967EmpTSts[0];
            }
            else
            {
               Z964EmpTDsc = A964EmpTDsc;
               Z963EmptDir = A963EmptDir;
               Z966EmpTRuc = A966EmpTRuc;
               Z967EmpTSts = A967EmpTSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z17EmpTCod = A17EmpTCod;
            Z964EmpTDsc = A964EmpTDsc;
            Z963EmptDir = A963EmptDir;
            Z966EmpTRuc = A966EmpTRuc;
            Z967EmpTSts = A967EmpTSts;
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

      protected void Load2978( )
      {
         /* Using cursor T00294 */
         pr_default.execute(2, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound78 = 1;
            A964EmpTDsc = T00294_A964EmpTDsc[0];
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            A963EmptDir = T00294_A963EmptDir[0];
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            A966EmpTRuc = T00294_A966EmpTRuc[0];
            AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
            A967EmpTSts = T00294_A967EmpTSts[0];
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            ZM2978( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2978( ) ;
      }

      protected void OnLoadActions2978( )
      {
      }

      protected void CheckExtendedTable2978( )
      {
         nIsDirty_78 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2978( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2978( )
      {
         /* Using cursor T00295 */
         pr_default.execute(3, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00293 */
         pr_default.execute(1, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2978( 1) ;
            RcdFound78 = 1;
            A17EmpTCod = T00293_A17EmpTCod[0];
            n17EmpTCod = T00293_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            A964EmpTDsc = T00293_A964EmpTDsc[0];
            AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
            A963EmptDir = T00293_A963EmptDir[0];
            AssignAttri("", false, "A963EmptDir", A963EmptDir);
            A966EmpTRuc = T00293_A966EmpTRuc[0];
            AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
            A967EmpTSts = T00293_A967EmpTSts[0];
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
            Z17EmpTCod = A17EmpTCod;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2978( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey2978( ) ;
            }
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey2978( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2978( ) ;
         if ( RcdFound78 == 0 )
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
         RcdFound78 = 0;
         /* Using cursor T00296 */
         pr_default.execute(4, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00296_A17EmpTCod[0] < A17EmpTCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00296_A17EmpTCod[0] > A17EmpTCod ) ) )
            {
               A17EmpTCod = T00296_A17EmpTCod[0];
               n17EmpTCod = T00296_n17EmpTCod[0];
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound78 = 0;
         /* Using cursor T00297 */
         pr_default.execute(5, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00297_A17EmpTCod[0] > A17EmpTCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00297_A17EmpTCod[0] < A17EmpTCod ) ) )
            {
               A17EmpTCod = T00297_A17EmpTCod[0];
               n17EmpTCod = T00297_n17EmpTCod[0];
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2978( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2978( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A17EmpTCod != Z17EmpTCod )
               {
                  A17EmpTCod = Z17EmpTCod;
                  n17EmpTCod = false;
                  AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2978( ) ;
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17EmpTCod != Z17EmpTCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEmpTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2978( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEmpTCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEmpTCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2978( ) ;
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
         if ( A17EmpTCod != Z17EmpTCod )
         {
            A17EmpTCod = Z17EmpTCod;
            n17EmpTCod = false;
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPTCOD");
            AnyError = 1;
            GX_FocusControl = edtEmpTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpTCod_Internalname;
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
         GetKey2978( ) ;
         if ( RcdFound78 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A17EmpTCod != Z17EmpTCod )
            {
               A17EmpTCod = Z17EmpTCod;
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
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
            if ( A17EmpTCod != Z17EmpTCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEmpTCod_Internalname;
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
         context.RollbackDataStores("cemptransporte",pr_default);
         GX_FocusControl = edtEmpTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_290( ) ;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "EMPTCOD");
            AnyError = 1;
            GX_FocusControl = edtEmpTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtEmpTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2978( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2978( ) ;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpTDsc_Internalname;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpTDsc_Internalname;
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
         ScanStart2978( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound78 != 0 )
            {
               ScanNext2978( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEmpTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2978( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2978( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00292 */
            pr_default.execute(0, new Object[] {n17EmpTCod, A17EmpTCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEMPTRANSPORTE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z964EmpTDsc, T00292_A964EmpTDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z963EmptDir, T00292_A963EmptDir[0]) != 0 ) || ( StringUtil.StrCmp(Z966EmpTRuc, T00292_A966EmpTRuc[0]) != 0 ) || ( Z967EmpTSts != T00292_A967EmpTSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z964EmpTDsc, T00292_A964EmpTDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cemptransporte:[seudo value changed for attri]"+"EmpTDsc");
                  GXUtil.WriteLogRaw("Old: ",Z964EmpTDsc);
                  GXUtil.WriteLogRaw("Current: ",T00292_A964EmpTDsc[0]);
               }
               if ( StringUtil.StrCmp(Z963EmptDir, T00292_A963EmptDir[0]) != 0 )
               {
                  GXUtil.WriteLog("cemptransporte:[seudo value changed for attri]"+"EmptDir");
                  GXUtil.WriteLogRaw("Old: ",Z963EmptDir);
                  GXUtil.WriteLogRaw("Current: ",T00292_A963EmptDir[0]);
               }
               if ( StringUtil.StrCmp(Z966EmpTRuc, T00292_A966EmpTRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("cemptransporte:[seudo value changed for attri]"+"EmpTRuc");
                  GXUtil.WriteLogRaw("Old: ",Z966EmpTRuc);
                  GXUtil.WriteLogRaw("Current: ",T00292_A966EmpTRuc[0]);
               }
               if ( Z967EmpTSts != T00292_A967EmpTSts[0] )
               {
                  GXUtil.WriteLog("cemptransporte:[seudo value changed for attri]"+"EmpTSts");
                  GXUtil.WriteLogRaw("Old: ",Z967EmpTSts);
                  GXUtil.WriteLogRaw("Current: ",T00292_A967EmpTSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CEMPTRANSPORTE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2978( )
      {
         BeforeValidate2978( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2978( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2978( 0) ;
            CheckOptimisticConcurrency2978( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2978( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2978( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00298 */
                     pr_default.execute(6, new Object[] {n17EmpTCod, A17EmpTCod, A964EmpTDsc, A963EmptDir, A966EmpTRuc, A967EmpTSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
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
                           ResetCaption290( ) ;
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
               Load2978( ) ;
            }
            EndLevel2978( ) ;
         }
         CloseExtendedTableCursors2978( ) ;
      }

      protected void Update2978( )
      {
         BeforeValidate2978( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2978( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2978( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2978( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2978( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00299 */
                     pr_default.execute(7, new Object[] {A964EmpTDsc, A963EmptDir, A966EmpTRuc, A967EmpTSts, n17EmpTCod, A17EmpTCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CEMPTRANSPORTE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2978( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption290( ) ;
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
            EndLevel2978( ) ;
         }
         CloseExtendedTableCursors2978( ) ;
      }

      protected void DeferredUpdate2978( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2978( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2978( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2978( ) ;
            AfterConfirm2978( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2978( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002910 */
                  pr_default.execute(8, new Object[] {n17EmpTCod, A17EmpTCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CEMPTRANSPORTE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound78 == 0 )
                        {
                           InitAll2978( ) ;
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
                        ResetCaption290( ) ;
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2978( ) ;
         Gx_mode = sMode78;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2978( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002911 */
            pr_default.execute(9, new Object[] {n17EmpTCod, A17EmpTCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel2978( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2978( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cemptransporte",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues290( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cemptransporte",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2978( )
      {
         /* Using cursor T002912 */
         pr_default.execute(10);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound78 = 1;
            A17EmpTCod = T002912_A17EmpTCod[0];
            n17EmpTCod = T002912_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2978( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound78 = 1;
            A17EmpTCod = T002912_A17EmpTCod[0];
            n17EmpTCod = T002912_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         }
      }

      protected void ScanEnd2978( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2978( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2978( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2978( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2978( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2978( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2978( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2978( )
      {
         edtEmpTCod_Enabled = 0;
         AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
         edtEmpTDsc_Enabled = 0;
         AssignProp("", false, edtEmpTDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTDsc_Enabled), 5, 0), true);
         edtEmptDir_Enabled = 0;
         AssignProp("", false, edtEmptDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmptDir_Enabled), 5, 0), true);
         edtEmpTRuc_Enabled = 0;
         AssignProp("", false, edtEmpTRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTRuc_Enabled), 5, 0), true);
         cmbEmpTSts.Enabled = 0;
         AssignProp("", false, cmbEmpTSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEmpTSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2978( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues290( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242526", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cemptransporte.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z964EmpTDsc", Z964EmpTDsc);
         GxWebStd.gx_hidden_field( context, "Z963EmptDir", Z963EmptDir);
         GxWebStd.gx_hidden_field( context, "Z966EmpTRuc", Z966EmpTRuc);
         GxWebStd.gx_hidden_field( context, "Z967EmpTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z967EmpTSts), 1, 0, ".", "")));
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
         return formatLink("cemptransporte.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CEMPTRANSPORTE" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empresa de Transporte" ;
      }

      protected void InitializeNonKey2978( )
      {
         A964EmpTDsc = "";
         AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
         A963EmptDir = "";
         AssignAttri("", false, "A963EmptDir", A963EmptDir);
         A966EmpTRuc = "";
         AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
         A967EmpTSts = 0;
         AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         Z964EmpTDsc = "";
         Z963EmptDir = "";
         Z966EmpTRuc = "";
         Z967EmpTSts = 0;
      }

      protected void InitAll2978( )
      {
         A17EmpTCod = 0;
         n17EmpTCod = false;
         AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         InitializeNonKey2978( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242531", true, true);
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
         context.AddJavascriptSource("cemptransporte.js", "?202281810242531", false, true);
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
         edtEmpTCod_Internalname = "EMPTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtEmpTDsc_Internalname = "EMPTDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtEmptDir_Internalname = "EMPTDIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtEmpTRuc_Internalname = "EMPTRUC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbEmpTSts_Internalname = "EMPTSTS";
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
         Form.Caption = "Empresa de Transporte";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbEmpTSts_Jsonclick = "";
         cmbEmpTSts.Enabled = 1;
         edtEmpTRuc_Jsonclick = "";
         edtEmpTRuc_Enabled = 1;
         edtEmptDir_Jsonclick = "";
         edtEmptDir_Enabled = 1;
         edtEmpTDsc_Jsonclick = "";
         edtEmpTDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtEmpTCod_Jsonclick = "";
         edtEmpTCod_Enabled = 1;
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
         cmbEmpTSts.Name = "EMPTSTS";
         cmbEmpTSts.WebTags = "";
         cmbEmpTSts.addItem("1", "ACTIVO", 0);
         cmbEmpTSts.addItem("0", "INACTIVO", 0);
         if ( cmbEmpTSts.ItemCount > 0 )
         {
            A967EmpTSts = (short)(NumberUtil.Val( cmbEmpTSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0))), "."));
            AssignAttri("", false, "A967EmpTSts", StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtEmpTDsc_Internalname;
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

      public void Valid_Emptcod( )
      {
         A967EmpTSts = (short)(NumberUtil.Val( cmbEmpTSts.CurrentValue, "."));
         cmbEmpTSts.CurrentValue = StringUtil.Str( (decimal)(A967EmpTSts), 1, 0);
         n17EmpTCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbEmpTSts.ItemCount > 0 )
         {
            A967EmpTSts = (short)(NumberUtil.Val( cmbEmpTSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0))), "."));
            cmbEmpTSts.CurrentValue = StringUtil.Str( (decimal)(A967EmpTSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A964EmpTDsc", A964EmpTDsc);
         AssignAttri("", false, "A963EmptDir", A963EmptDir);
         AssignAttri("", false, "A966EmpTRuc", A966EmpTRuc);
         AssignAttri("", false, "A967EmpTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A967EmpTSts), 1, 0, ".", "")));
         cmbEmpTSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A967EmpTSts), 1, 0));
         AssignProp("", false, cmbEmpTSts_Internalname, "Values", cmbEmpTSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z964EmpTDsc", Z964EmpTDsc);
         GxWebStd.gx_hidden_field( context, "Z963EmptDir", Z963EmptDir);
         GxWebStd.gx_hidden_field( context, "Z966EmpTRuc", Z966EmpTRuc);
         GxWebStd.gx_hidden_field( context, "Z967EmpTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z967EmpTSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_EMPTCOD","{handler:'Valid_Emptcod',iparms:[{av:'cmbEmpTSts'},{av:'A967EmpTSts',fld:'EMPTSTS',pic:'9'},{av:'A17EmpTCod',fld:'EMPTCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_EMPTCOD",",oparms:[{av:'A964EmpTDsc',fld:'EMPTDSC',pic:''},{av:'A963EmptDir',fld:'EMPTDIR',pic:''},{av:'A966EmpTRuc',fld:'EMPTRUC',pic:''},{av:'cmbEmpTSts'},{av:'A967EmpTSts',fld:'EMPTSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z17EmpTCod'},{av:'Z964EmpTDsc'},{av:'Z963EmptDir'},{av:'Z966EmpTRuc'},{av:'Z967EmpTSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z964EmpTDsc = "";
         Z963EmptDir = "";
         Z966EmpTRuc = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A964EmpTDsc = "";
         lblTextblock3_Jsonclick = "";
         A963EmptDir = "";
         lblTextblock4_Jsonclick = "";
         A966EmpTRuc = "";
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
         T00294_A17EmpTCod = new int[1] ;
         T00294_n17EmpTCod = new bool[] {false} ;
         T00294_A964EmpTDsc = new string[] {""} ;
         T00294_A963EmptDir = new string[] {""} ;
         T00294_A966EmpTRuc = new string[] {""} ;
         T00294_A967EmpTSts = new short[1] ;
         T00295_A17EmpTCod = new int[1] ;
         T00295_n17EmpTCod = new bool[] {false} ;
         T00293_A17EmpTCod = new int[1] ;
         T00293_n17EmpTCod = new bool[] {false} ;
         T00293_A964EmpTDsc = new string[] {""} ;
         T00293_A963EmptDir = new string[] {""} ;
         T00293_A966EmpTRuc = new string[] {""} ;
         T00293_A967EmpTSts = new short[1] ;
         sMode78 = "";
         T00296_A17EmpTCod = new int[1] ;
         T00296_n17EmpTCod = new bool[] {false} ;
         T00297_A17EmpTCod = new int[1] ;
         T00297_n17EmpTCod = new bool[] {false} ;
         T00292_A17EmpTCod = new int[1] ;
         T00292_n17EmpTCod = new bool[] {false} ;
         T00292_A964EmpTDsc = new string[] {""} ;
         T00292_A963EmptDir = new string[] {""} ;
         T00292_A966EmpTRuc = new string[] {""} ;
         T00292_A967EmpTSts = new short[1] ;
         T002911_A13MvATip = new string[] {""} ;
         T002911_A14MvACod = new string[] {""} ;
         T002912_A17EmpTCod = new int[1] ;
         T002912_n17EmpTCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ964EmpTDsc = "";
         ZZ963EmptDir = "";
         ZZ966EmpTRuc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cemptransporte__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cemptransporte__default(),
            new Object[][] {
                new Object[] {
               T00292_A17EmpTCod, T00292_A964EmpTDsc, T00292_A963EmptDir, T00292_A966EmpTRuc, T00292_A967EmpTSts
               }
               , new Object[] {
               T00293_A17EmpTCod, T00293_A964EmpTDsc, T00293_A963EmptDir, T00293_A966EmpTRuc, T00293_A967EmpTSts
               }
               , new Object[] {
               T00294_A17EmpTCod, T00294_A964EmpTDsc, T00294_A963EmptDir, T00294_A966EmpTRuc, T00294_A967EmpTSts
               }
               , new Object[] {
               T00295_A17EmpTCod
               }
               , new Object[] {
               T00296_A17EmpTCod
               }
               , new Object[] {
               T00297_A17EmpTCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002911_A13MvATip, T002911_A14MvACod
               }
               , new Object[] {
               T002912_A17EmpTCod
               }
            }
         );
      }

      private short Z967EmpTSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A967EmpTSts ;
      private short GX_JID ;
      private short RcdFound78 ;
      private short nIsDirty_78 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ967EmpTSts ;
      private int Z17EmpTCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A17EmpTCod ;
      private int edtEmpTCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtEmpTDsc_Enabled ;
      private int edtEmptDir_Enabled ;
      private int edtEmpTRuc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ17EmpTCod ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpTCod_Internalname ;
      private string cmbEmpTSts_Internalname ;
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
      private string edtEmpTCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtEmpTDsc_Internalname ;
      private string edtEmpTDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtEmptDir_Internalname ;
      private string edtEmptDir_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtEmpTRuc_Internalname ;
      private string edtEmpTRuc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbEmpTSts_Jsonclick ;
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
      private string sMode78 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n17EmpTCod ;
      private string Z964EmpTDsc ;
      private string Z963EmptDir ;
      private string Z966EmpTRuc ;
      private string A964EmpTDsc ;
      private string A963EmptDir ;
      private string A966EmpTRuc ;
      private string ZZ964EmpTDsc ;
      private string ZZ963EmptDir ;
      private string ZZ966EmpTRuc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEmpTSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00294_A17EmpTCod ;
      private bool[] T00294_n17EmpTCod ;
      private string[] T00294_A964EmpTDsc ;
      private string[] T00294_A963EmptDir ;
      private string[] T00294_A966EmpTRuc ;
      private short[] T00294_A967EmpTSts ;
      private int[] T00295_A17EmpTCod ;
      private bool[] T00295_n17EmpTCod ;
      private int[] T00293_A17EmpTCod ;
      private bool[] T00293_n17EmpTCod ;
      private string[] T00293_A964EmpTDsc ;
      private string[] T00293_A963EmptDir ;
      private string[] T00293_A966EmpTRuc ;
      private short[] T00293_A967EmpTSts ;
      private int[] T00296_A17EmpTCod ;
      private bool[] T00296_n17EmpTCod ;
      private int[] T00297_A17EmpTCod ;
      private bool[] T00297_n17EmpTCod ;
      private int[] T00292_A17EmpTCod ;
      private bool[] T00292_n17EmpTCod ;
      private string[] T00292_A964EmpTDsc ;
      private string[] T00292_A963EmptDir ;
      private string[] T00292_A966EmpTRuc ;
      private short[] T00292_A967EmpTSts ;
      private string[] T002911_A13MvATip ;
      private string[] T002911_A14MvACod ;
      private int[] T002912_A17EmpTCod ;
      private bool[] T002912_n17EmpTCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cemptransporte__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cemptransporte__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00294;
        prmT00294 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00295;
        prmT00295 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00293;
        prmT00293 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00296;
        prmT00296 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00297;
        prmT00297 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00292;
        prmT00292 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00298;
        prmT00298 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EmpTDsc",GXType.NVarChar,100,0) ,
        new ParDef("@EmptDir",GXType.NVarChar,100,0) ,
        new ParDef("@EmpTRuc",GXType.NVarChar,20,0) ,
        new ParDef("@EmpTSts",GXType.Int16,1,0)
        };
        Object[] prmT00299;
        prmT00299 = new Object[] {
        new ParDef("@EmpTDsc",GXType.NVarChar,100,0) ,
        new ParDef("@EmptDir",GXType.NVarChar,100,0) ,
        new ParDef("@EmpTRuc",GXType.NVarChar,20,0) ,
        new ParDef("@EmpTSts",GXType.Int16,1,0) ,
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002910;
        prmT002910 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002911;
        prmT002911 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002912;
        prmT002912 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00292", "SELECT [EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts] FROM [CEMPTRANSPORTE] WITH (UPDLOCK) WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00292,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00293", "SELECT [EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00293,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00294", "SELECT TM1.[EmpTCod], TM1.[EmpTDsc], TM1.[EmptDir], TM1.[EmpTRuc], TM1.[EmpTSts] FROM [CEMPTRANSPORTE] TM1 WHERE TM1.[EmpTCod] = @EmpTCod ORDER BY TM1.[EmpTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00294,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00295", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00295,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00296", "SELECT TOP 1 [EmpTCod] FROM [CEMPTRANSPORTE] WHERE ( [EmpTCod] > @EmpTCod) ORDER BY [EmpTCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00296,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00297", "SELECT TOP 1 [EmpTCod] FROM [CEMPTRANSPORTE] WHERE ( [EmpTCod] < @EmpTCod) ORDER BY [EmpTCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00297,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00298", "INSERT INTO [CEMPTRANSPORTE]([EmpTCod], [EmpTDsc], [EmptDir], [EmpTRuc], [EmpTSts]) VALUES(@EmpTCod, @EmpTDsc, @EmptDir, @EmpTRuc, @EmpTSts)", GxErrorMask.GX_NOMASK,prmT00298)
           ,new CursorDef("T00299", "UPDATE [CEMPTRANSPORTE] SET [EmpTDsc]=@EmpTDsc, [EmptDir]=@EmptDir, [EmpTRuc]=@EmpTRuc, [EmpTSts]=@EmpTSts  WHERE [EmpTCod] = @EmpTCod", GxErrorMask.GX_NOMASK,prmT00299)
           ,new CursorDef("T002910", "DELETE FROM [CEMPTRANSPORTE]  WHERE [EmpTCod] = @EmpTCod", GxErrorMask.GX_NOMASK,prmT002910)
           ,new CursorDef("T002911", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002912", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] ORDER BY [EmpTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002912,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
