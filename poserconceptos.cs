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
   public class poserconceptos : GXDataArea
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
            Form.Meta.addItem("description", "Conceptos de Servicios", 0) ;
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

      public poserconceptos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poserconceptos( IGxContext context )
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
         cmbPSerConcTipo = new GXCombobox();
         cmbPSerConcSts = new GXCombobox();
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
         if ( cmbPSerConcTipo.ItemCount > 0 )
         {
            A1797PSerConcTipo = cmbPSerConcTipo.getValidValue(A1797PSerConcTipo);
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
            AssignProp("", false, cmbPSerConcTipo_Internalname, "Values", cmbPSerConcTipo.ToJavascriptSource(), true);
         }
         if ( cmbPSerConcSts.ItemCount > 0 )
         {
            A1796PSerConcSts = (short)(NumberUtil.Val( cmbPSerConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            AssignProp("", false, cmbPSerConcSts_Internalname, "Values", cmbPSerConcSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POSERCONCEPTOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerConcCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A332PSerConcCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPSerConcCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A332PSerConcCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A332PSerConcCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerConcCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerConcCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Concepto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerConcDsc_Internalname, A1795PSerConcDsc, StringUtil.RTrim( context.localUtil.Format( A1795PSerConcDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerConcDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerConcDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo Distribución", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPSerConcTipo, cmbPSerConcTipo_Internalname, StringUtil.RTrim( A1797PSerConcTipo), 1, cmbPSerConcTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPSerConcTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 1, "HLP_POSERCONCEPTOS.htm");
         cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
         AssignProp("", false, cmbPSerConcTipo_Internalname, "Values", (string)(cmbPSerConcTipo.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPSerConcSts, cmbPSerConcSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0)), 1, cmbPSerConcSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbPSerConcSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_POSERCONCEPTOS.htm");
         cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         AssignProp("", false, cmbPSerConcSts_Internalname, "Values", (string)(cmbPSerConcSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POSERCONCEPTOS.htm");
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
            Z1795PSerConcDsc = cgiGet( "Z1795PSerConcDsc");
            Z1797PSerConcTipo = cgiGet( "Z1797PSerConcTipo");
            Z1796PSerConcSts = (short)(context.localUtil.CToN( cgiGet( "Z1796PSerConcSts"), ".", ","));
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
            A1795PSerConcDsc = cgiGet( edtPSerConcDsc_Internalname);
            AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
            cmbPSerConcTipo.CurrentValue = cgiGet( cmbPSerConcTipo_Internalname);
            A1797PSerConcTipo = cgiGet( cmbPSerConcTipo_Internalname);
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
            cmbPSerConcSts.CurrentValue = cgiGet( cmbPSerConcSts_Internalname);
            A1796PSerConcSts = (short)(NumberUtil.Val( cgiGet( cmbPSerConcSts_Internalname), "."));
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
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
               InitAll4I157( ) ;
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
         DisableAttributes4I157( ) ;
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

      protected void CONFIRM_4I0( )
      {
         BeforeValidate4I157( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4I157( ) ;
            }
            else
            {
               CheckExtendedTable4I157( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors4I157( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4I0( ) ;
         }
      }

      protected void ResetCaption4I0( )
      {
      }

      protected void ZM4I157( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1795PSerConcDsc = T004I3_A1795PSerConcDsc[0];
               Z1797PSerConcTipo = T004I3_A1797PSerConcTipo[0];
               Z1796PSerConcSts = T004I3_A1796PSerConcSts[0];
            }
            else
            {
               Z1795PSerConcDsc = A1795PSerConcDsc;
               Z1797PSerConcTipo = A1797PSerConcTipo;
               Z1796PSerConcSts = A1796PSerConcSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z332PSerConcCod = A332PSerConcCod;
            Z1795PSerConcDsc = A1795PSerConcDsc;
            Z1797PSerConcTipo = A1797PSerConcTipo;
            Z1796PSerConcSts = A1796PSerConcSts;
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

      protected void Load4I157( )
      {
         /* Using cursor T004I4 */
         pr_default.execute(2, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound157 = 1;
            A1795PSerConcDsc = T004I4_A1795PSerConcDsc[0];
            AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
            A1797PSerConcTipo = T004I4_A1797PSerConcTipo[0];
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
            A1796PSerConcSts = T004I4_A1796PSerConcSts[0];
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            ZM4I157( -1) ;
         }
         pr_default.close(2);
         OnLoadActions4I157( ) ;
      }

      protected void OnLoadActions4I157( )
      {
      }

      protected void CheckExtendedTable4I157( )
      {
         nIsDirty_157 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors4I157( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey4I157( )
      {
         /* Using cursor T004I5 */
         pr_default.execute(3, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound157 = 1;
         }
         else
         {
            RcdFound157 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004I3 */
         pr_default.execute(1, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4I157( 1) ;
            RcdFound157 = 1;
            A332PSerConcCod = T004I3_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
            A1795PSerConcDsc = T004I3_A1795PSerConcDsc[0];
            AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
            A1797PSerConcTipo = T004I3_A1797PSerConcTipo[0];
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
            A1796PSerConcSts = T004I3_A1796PSerConcSts[0];
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
            Z332PSerConcCod = A332PSerConcCod;
            sMode157 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4I157( ) ;
            if ( AnyError == 1 )
            {
               RcdFound157 = 0;
               InitializeNonKey4I157( ) ;
            }
            Gx_mode = sMode157;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound157 = 0;
            InitializeNonKey4I157( ) ;
            sMode157 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode157;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4I157( ) ;
         if ( RcdFound157 == 0 )
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
         RcdFound157 = 0;
         /* Using cursor T004I6 */
         pr_default.execute(4, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T004I6_A332PSerConcCod[0] < A332PSerConcCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T004I6_A332PSerConcCod[0] > A332PSerConcCod ) ) )
            {
               A332PSerConcCod = T004I6_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               RcdFound157 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound157 = 0;
         /* Using cursor T004I7 */
         pr_default.execute(5, new Object[] {A332PSerConcCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T004I7_A332PSerConcCod[0] > A332PSerConcCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T004I7_A332PSerConcCod[0] < A332PSerConcCod ) ) )
            {
               A332PSerConcCod = T004I7_A332PSerConcCod[0];
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
               RcdFound157 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4I157( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4I157( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound157 == 1 )
            {
               if ( A332PSerConcCod != Z332PSerConcCod )
               {
                  A332PSerConcCod = Z332PSerConcCod;
                  AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
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
                  Update4I157( ) ;
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A332PSerConcCod != Z332PSerConcCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPSerConcCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4I157( ) ;
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
                     Insert4I157( ) ;
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
         if ( A332PSerConcCod != Z332PSerConcCod )
         {
            A332PSerConcCod = Z332PSerConcCod;
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
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
         GetKey4I157( ) ;
         if ( RcdFound157 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PSERCONCCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerConcCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A332PSerConcCod != Z332PSerConcCod )
            {
               A332PSerConcCod = Z332PSerConcCod;
               AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
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
            if ( A332PSerConcCod != Z332PSerConcCod )
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
         context.RollbackDataStores("poserconceptos",pr_default);
         GX_FocusControl = edtPSerConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4I0( ) ;
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
         if ( RcdFound157 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PSERCONCCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerConcCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPSerConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4I157( ) ;
         if ( RcdFound157 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4I157( ) ;
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
         if ( RcdFound157 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerConcDsc_Internalname;
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
         if ( RcdFound157 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerConcDsc_Internalname;
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
         ScanStart4I157( ) ;
         if ( RcdFound157 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound157 != 0 )
            {
               ScanNext4I157( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerConcDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4I157( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4I157( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004I2 */
            pr_default.execute(0, new Object[] {A332PSerConcCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1795PSerConcDsc, T004I2_A1795PSerConcDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1797PSerConcTipo, T004I2_A1797PSerConcTipo[0]) != 0 ) || ( Z1796PSerConcSts != T004I2_A1796PSerConcSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1795PSerConcDsc, T004I2_A1795PSerConcDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("poserconceptos:[seudo value changed for attri]"+"PSerConcDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1795PSerConcDsc);
                  GXUtil.WriteLogRaw("Current: ",T004I2_A1795PSerConcDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1797PSerConcTipo, T004I2_A1797PSerConcTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("poserconceptos:[seudo value changed for attri]"+"PSerConcTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1797PSerConcTipo);
                  GXUtil.WriteLogRaw("Current: ",T004I2_A1797PSerConcTipo[0]);
               }
               if ( Z1796PSerConcSts != T004I2_A1796PSerConcSts[0] )
               {
                  GXUtil.WriteLog("poserconceptos:[seudo value changed for attri]"+"PSerConcSts");
                  GXUtil.WriteLogRaw("Old: ",Z1796PSerConcSts);
                  GXUtil.WriteLogRaw("Current: ",T004I2_A1796PSerConcSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4I157( )
      {
         BeforeValidate4I157( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4I157( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4I157( 0) ;
            CheckOptimisticConcurrency4I157( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4I157( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4I157( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004I8 */
                     pr_default.execute(6, new Object[] {A332PSerConcCod, A1795PSerConcDsc, A1797PSerConcTipo, A1796PSerConcSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
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
                           ResetCaption4I0( ) ;
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
               Load4I157( ) ;
            }
            EndLevel4I157( ) ;
         }
         CloseExtendedTableCursors4I157( ) ;
      }

      protected void Update4I157( )
      {
         BeforeValidate4I157( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4I157( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4I157( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4I157( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4I157( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004I9 */
                     pr_default.execute(7, new Object[] {A1795PSerConcDsc, A1797PSerConcTipo, A1796PSerConcSts, A332PSerConcCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4I157( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4I0( ) ;
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
            EndLevel4I157( ) ;
         }
         CloseExtendedTableCursors4I157( ) ;
      }

      protected void DeferredUpdate4I157( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4I157( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4I157( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4I157( ) ;
            AfterConfirm4I157( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4I157( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004I10 */
                  pr_default.execute(8, new Object[] {A332PSerConcCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("POSERCONCEPTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound157 == 0 )
                        {
                           InitAll4I157( ) ;
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
                        ResetCaption4I0( ) ;
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
         sMode157 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4I157( ) ;
         Gx_mode = sMode157;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4I157( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T004I11 */
            pr_default.execute(9, new Object[] {A332PSerConcCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Conceptos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel4I157( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4I157( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("poserconceptos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("poserconceptos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4I157( )
      {
         /* Using cursor T004I12 */
         pr_default.execute(10);
         RcdFound157 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound157 = 1;
            A332PSerConcCod = T004I12_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4I157( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound157 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound157 = 1;
            A332PSerConcCod = T004I12_A332PSerConcCod[0];
            AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         }
      }

      protected void ScanEnd4I157( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm4I157( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4I157( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4I157( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4I157( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4I157( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4I157( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4I157( )
      {
         edtPSerConcCod_Enabled = 0;
         AssignProp("", false, edtPSerConcCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcCod_Enabled), 5, 0), true);
         edtPSerConcDsc_Enabled = 0;
         AssignProp("", false, edtPSerConcDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerConcDsc_Enabled), 5, 0), true);
         cmbPSerConcTipo.Enabled = 0;
         AssignProp("", false, cmbPSerConcTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPSerConcTipo.Enabled), 5, 0), true);
         cmbPSerConcSts.Enabled = 0;
         AssignProp("", false, cmbPSerConcSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPSerConcSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4I157( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253771", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poserconceptos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1795PSerConcDsc", Z1795PSerConcDsc);
         GxWebStd.gx_hidden_field( context, "Z1797PSerConcTipo", Z1797PSerConcTipo);
         GxWebStd.gx_hidden_field( context, "Z1796PSerConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1796PSerConcSts), 1, 0, ".", "")));
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
         return formatLink("poserconceptos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POSERCONCEPTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Servicios" ;
      }

      protected void InitializeNonKey4I157( )
      {
         A1795PSerConcDsc = "";
         AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
         A1797PSerConcTipo = "";
         AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         A1796PSerConcSts = 0;
         AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         Z1795PSerConcDsc = "";
         Z1797PSerConcTipo = "";
         Z1796PSerConcSts = 0;
      }

      protected void InitAll4I157( )
      {
         A332PSerConcCod = 0;
         AssignAttri("", false, "A332PSerConcCod", StringUtil.LTrimStr( (decimal)(A332PSerConcCod), 6, 0));
         InitializeNonKey4I157( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253777", true, true);
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
         context.AddJavascriptSource("poserconceptos.js", "?202281810253777", false, true);
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
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPSerConcDsc_Internalname = "PSERCONCDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbPSerConcTipo_Internalname = "PSERCONCTIPO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbPSerConcSts_Internalname = "PSERCONCSTS";
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
         Form.Caption = "Conceptos de Servicios";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbPSerConcSts_Jsonclick = "";
         cmbPSerConcSts.Enabled = 1;
         cmbPSerConcTipo_Jsonclick = "";
         cmbPSerConcTipo.Enabled = 1;
         edtPSerConcDsc_Jsonclick = "";
         edtPSerConcDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
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
         cmbPSerConcTipo.Name = "PSERCONCTIPO";
         cmbPSerConcTipo.WebTags = "";
         cmbPSerConcTipo.addItem("O", "Horas Mano de Obra", 0);
         cmbPSerConcTipo.addItem("M", "Horas Maquinas", 0);
         if ( cmbPSerConcTipo.ItemCount > 0 )
         {
            A1797PSerConcTipo = cmbPSerConcTipo.getValidValue(A1797PSerConcTipo);
            AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         }
         cmbPSerConcSts.Name = "PSERCONCSTS";
         cmbPSerConcSts.WebTags = "";
         cmbPSerConcSts.addItem("1", "Activo", 0);
         cmbPSerConcSts.addItem("0", "Inactivo", 0);
         if ( cmbPSerConcSts.ItemCount > 0 )
         {
            A1796PSerConcSts = (short)(NumberUtil.Val( cmbPSerConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0))), "."));
            AssignAttri("", false, "A1796PSerConcSts", StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPSerConcDsc_Internalname;
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

      public void Valid_Pserconccod( )
      {
         A1796PSerConcSts = (short)(NumberUtil.Val( cmbPSerConcSts.CurrentValue, "."));
         cmbPSerConcSts.CurrentValue = StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0);
         A1797PSerConcTipo = cmbPSerConcTipo.CurrentValue;
         cmbPSerConcTipo.CurrentValue = A1797PSerConcTipo;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPSerConcTipo.ItemCount > 0 )
         {
            A1797PSerConcTipo = cmbPSerConcTipo.getValidValue(A1797PSerConcTipo);
            cmbPSerConcTipo.CurrentValue = A1797PSerConcTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
         }
         if ( cmbPSerConcSts.ItemCount > 0 )
         {
            A1796PSerConcSts = (short)(NumberUtil.Val( cmbPSerConcSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0))), "."));
            cmbPSerConcSts.CurrentValue = StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1795PSerConcDsc", A1795PSerConcDsc);
         AssignAttri("", false, "A1797PSerConcTipo", A1797PSerConcTipo);
         cmbPSerConcTipo.CurrentValue = StringUtil.RTrim( A1797PSerConcTipo);
         AssignProp("", false, cmbPSerConcTipo_Internalname, "Values", cmbPSerConcTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A1796PSerConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1796PSerConcSts), 1, 0, ".", "")));
         cmbPSerConcSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1796PSerConcSts), 1, 0));
         AssignProp("", false, cmbPSerConcSts_Internalname, "Values", cmbPSerConcSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z332PSerConcCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z332PSerConcCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1795PSerConcDsc", Z1795PSerConcDsc);
         GxWebStd.gx_hidden_field( context, "Z1797PSerConcTipo", Z1797PSerConcTipo);
         GxWebStd.gx_hidden_field( context, "Z1796PSerConcSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1796PSerConcSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_PSERCONCCOD","{handler:'Valid_Pserconccod',iparms:[{av:'cmbPSerConcSts'},{av:'A1796PSerConcSts',fld:'PSERCONCSTS',pic:'9'},{av:'cmbPSerConcTipo'},{av:'A1797PSerConcTipo',fld:'PSERCONCTIPO',pic:''},{av:'A332PSerConcCod',fld:'PSERCONCCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PSERCONCCOD",",oparms:[{av:'A1795PSerConcDsc',fld:'PSERCONCDSC',pic:''},{av:'cmbPSerConcTipo'},{av:'A1797PSerConcTipo',fld:'PSERCONCTIPO',pic:''},{av:'cmbPSerConcSts'},{av:'A1796PSerConcSts',fld:'PSERCONCSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z332PSerConcCod'},{av:'Z1795PSerConcDsc'},{av:'Z1797PSerConcTipo'},{av:'Z1796PSerConcSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1795PSerConcDsc = "";
         Z1797PSerConcTipo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1797PSerConcTipo = "";
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
         A1795PSerConcDsc = "";
         lblTextblock3_Jsonclick = "";
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
         T004I4_A332PSerConcCod = new int[1] ;
         T004I4_A1795PSerConcDsc = new string[] {""} ;
         T004I4_A1797PSerConcTipo = new string[] {""} ;
         T004I4_A1796PSerConcSts = new short[1] ;
         T004I5_A332PSerConcCod = new int[1] ;
         T004I3_A332PSerConcCod = new int[1] ;
         T004I3_A1795PSerConcDsc = new string[] {""} ;
         T004I3_A1797PSerConcTipo = new string[] {""} ;
         T004I3_A1796PSerConcSts = new short[1] ;
         sMode157 = "";
         T004I6_A332PSerConcCod = new int[1] ;
         T004I7_A332PSerConcCod = new int[1] ;
         T004I2_A332PSerConcCod = new int[1] ;
         T004I2_A1795PSerConcDsc = new string[] {""} ;
         T004I2_A1797PSerConcTipo = new string[] {""} ;
         T004I2_A1796PSerConcSts = new short[1] ;
         T004I11_A332PSerConcCod = new int[1] ;
         T004I11_A333PSerDConcCueCod = new string[] {""} ;
         T004I12_A332PSerConcCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1795PSerConcDsc = "";
         ZZ1797PSerConcTipo = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poserconceptos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poserconceptos__default(),
            new Object[][] {
                new Object[] {
               T004I2_A332PSerConcCod, T004I2_A1795PSerConcDsc, T004I2_A1797PSerConcTipo, T004I2_A1796PSerConcSts
               }
               , new Object[] {
               T004I3_A332PSerConcCod, T004I3_A1795PSerConcDsc, T004I3_A1797PSerConcTipo, T004I3_A1796PSerConcSts
               }
               , new Object[] {
               T004I4_A332PSerConcCod, T004I4_A1795PSerConcDsc, T004I4_A1797PSerConcTipo, T004I4_A1796PSerConcSts
               }
               , new Object[] {
               T004I5_A332PSerConcCod
               }
               , new Object[] {
               T004I6_A332PSerConcCod
               }
               , new Object[] {
               T004I7_A332PSerConcCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004I11_A332PSerConcCod, T004I11_A333PSerDConcCueCod
               }
               , new Object[] {
               T004I12_A332PSerConcCod
               }
            }
         );
      }

      private short Z1796PSerConcSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1796PSerConcSts ;
      private short GX_JID ;
      private short RcdFound157 ;
      private short nIsDirty_157 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1796PSerConcSts ;
      private int Z332PSerConcCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A332PSerConcCod ;
      private int edtPSerConcCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPSerConcDsc_Enabled ;
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
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPSerConcCod_Internalname ;
      private string cmbPSerConcTipo_Internalname ;
      private string cmbPSerConcSts_Internalname ;
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
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPSerConcDsc_Internalname ;
      private string edtPSerConcDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbPSerConcTipo_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbPSerConcSts_Jsonclick ;
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
      private string sMode157 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z1795PSerConcDsc ;
      private string Z1797PSerConcTipo ;
      private string A1797PSerConcTipo ;
      private string A1795PSerConcDsc ;
      private string ZZ1795PSerConcDsc ;
      private string ZZ1797PSerConcTipo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPSerConcTipo ;
      private GXCombobox cmbPSerConcSts ;
      private IDataStoreProvider pr_default ;
      private int[] T004I4_A332PSerConcCod ;
      private string[] T004I4_A1795PSerConcDsc ;
      private string[] T004I4_A1797PSerConcTipo ;
      private short[] T004I4_A1796PSerConcSts ;
      private int[] T004I5_A332PSerConcCod ;
      private int[] T004I3_A332PSerConcCod ;
      private string[] T004I3_A1795PSerConcDsc ;
      private string[] T004I3_A1797PSerConcTipo ;
      private short[] T004I3_A1796PSerConcSts ;
      private int[] T004I6_A332PSerConcCod ;
      private int[] T004I7_A332PSerConcCod ;
      private int[] T004I2_A332PSerConcCod ;
      private string[] T004I2_A1795PSerConcDsc ;
      private string[] T004I2_A1797PSerConcTipo ;
      private short[] T004I2_A1796PSerConcSts ;
      private int[] T004I11_A332PSerConcCod ;
      private string[] T004I11_A333PSerDConcCueCod ;
      private int[] T004I12_A332PSerConcCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poserconceptos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poserconceptos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT004I4;
        prmT004I4 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I5;
        prmT004I5 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I3;
        prmT004I3 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I6;
        prmT004I6 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I7;
        prmT004I7 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I2;
        prmT004I2 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I8;
        prmT004I8 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0) ,
        new ParDef("@PSerConcDsc",GXType.NVarChar,100,0) ,
        new ParDef("@PSerConcTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerConcSts",GXType.Int16,1,0)
        };
        Object[] prmT004I9;
        prmT004I9 = new Object[] {
        new ParDef("@PSerConcDsc",GXType.NVarChar,100,0) ,
        new ParDef("@PSerConcTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerConcSts",GXType.Int16,1,0) ,
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I10;
        prmT004I10 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I11;
        prmT004I11 = new Object[] {
        new ParDef("@PSerConcCod",GXType.Int32,6,0)
        };
        Object[] prmT004I12;
        prmT004I12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T004I2", "SELECT [PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts] FROM [POSERCONCEPTOS] WITH (UPDLOCK) WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004I3", "SELECT [PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004I4", "SELECT TM1.[PSerConcCod], TM1.[PSerConcDsc], TM1.[PSerConcTipo], TM1.[PSerConcSts] FROM [POSERCONCEPTOS] TM1 WHERE TM1.[PSerConcCod] = @PSerConcCod ORDER BY TM1.[PSerConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004I5", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] WHERE [PSerConcCod] = @PSerConcCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004I6", "SELECT TOP 1 [PSerConcCod] FROM [POSERCONCEPTOS] WHERE ( [PSerConcCod] > @PSerConcCod) ORDER BY [PSerConcCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004I6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004I7", "SELECT TOP 1 [PSerConcCod] FROM [POSERCONCEPTOS] WHERE ( [PSerConcCod] < @PSerConcCod) ORDER BY [PSerConcCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004I7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004I8", "INSERT INTO [POSERCONCEPTOS]([PSerConcCod], [PSerConcDsc], [PSerConcTipo], [PSerConcSts]) VALUES(@PSerConcCod, @PSerConcDsc, @PSerConcTipo, @PSerConcSts)", GxErrorMask.GX_NOMASK,prmT004I8)
           ,new CursorDef("T004I9", "UPDATE [POSERCONCEPTOS] SET [PSerConcDsc]=@PSerConcDsc, [PSerConcTipo]=@PSerConcTipo, [PSerConcSts]=@PSerConcSts  WHERE [PSerConcCod] = @PSerConcCod", GxErrorMask.GX_NOMASK,prmT004I9)
           ,new CursorDef("T004I10", "DELETE FROM [POSERCONCEPTOS]  WHERE [PSerConcCod] = @PSerConcCod", GxErrorMask.GX_NOMASK,prmT004I10)
           ,new CursorDef("T004I11", "SELECT TOP 1 [PSerConcCod], [PSerDConcCueCod] FROM [POSERCONCEPTOSDET] WHERE [PSerConcCod] = @PSerConcCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004I11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004I12", "SELECT [PSerConcCod] FROM [POSERCONCEPTOS] ORDER BY [PSerConcCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004I12,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
