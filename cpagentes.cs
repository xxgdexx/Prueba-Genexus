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
   public class cpagentes : GXDataArea
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
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A91CueCod) ;
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
            Form.Meta.addItem("description", "Agentes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpagentes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpagentes( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPAGENTES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Agente", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqPrvCod_Internalname, StringUtil.RTrim( A236LiqPrvCod), StringUtil.RTrim( context.localUtil.Format( A236LiqPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cuenta", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Agente de Aduana", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqPrvDsc_Internalname, StringUtil.RTrim( A1197LiqPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1197LiqPrvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Descripción de Cuenta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc), StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Auxiliar", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqCueCodAux_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1175LiqCueCodAux), 4, 0, ".", "")), StringUtil.LTrim( ((edtLiqCueCodAux_Enabled!=0) ? context.localUtil.Format( (decimal)(A1175LiqCueCodAux), "ZZZ9") : context.localUtil.Format( (decimal)(A1175LiqCueCodAux), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCueCodAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCueCodAux_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Auxiliar", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqCueAuxDsc_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1174LiqCueAuxDsc), 4, 0, ".", "")), StringUtil.LTrim( ((edtLiqCueAuxDsc_Enabled!=0) ? context.localUtil.Format( (decimal)(A1174LiqCueAuxDsc), "ZZZ9") : context.localUtil.Format( (decimal)(A1174LiqCueAuxDsc), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCueAuxDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCueAuxDsc_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPAGENTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1198LiqSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtLiqSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1198LiqSts), "9") : context.localUtil.Format( (decimal)(A1198LiqSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPAGENTES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPAGENTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPAGENTES.htm");
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
            Z236LiqPrvCod = cgiGet( "Z236LiqPrvCod");
            Z1197LiqPrvDsc = cgiGet( "Z1197LiqPrvDsc");
            Z1175LiqCueCodAux = (short)(context.localUtil.CToN( cgiGet( "Z1175LiqCueCodAux"), ".", ","));
            Z1174LiqCueAuxDsc = (short)(context.localUtil.CToN( cgiGet( "Z1174LiqCueAuxDsc"), ".", ","));
            Z1198LiqSts = (short)(context.localUtil.CToN( cgiGet( "Z1198LiqSts"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A236LiqPrvCod = cgiGet( edtLiqPrvCod_Internalname);
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A1197LiqPrvDsc = cgiGet( edtLiqPrvDsc_Internalname);
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            A860CueDsc = cgiGet( edtCueDsc_Internalname);
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqCueCodAux_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqCueCodAux_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQCUECODAUX");
               AnyError = 1;
               GX_FocusControl = edtLiqCueCodAux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1175LiqCueCodAux = 0;
               n1175LiqCueCodAux = false;
               AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrimStr( (decimal)(A1175LiqCueCodAux), 4, 0));
            }
            else
            {
               A1175LiqCueCodAux = (short)(context.localUtil.CToN( cgiGet( edtLiqCueCodAux_Internalname), ".", ","));
               n1175LiqCueCodAux = false;
               AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrimStr( (decimal)(A1175LiqCueCodAux), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqCueAuxDsc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqCueAuxDsc_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQCUEAUXDSC");
               AnyError = 1;
               GX_FocusControl = edtLiqCueAuxDsc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1174LiqCueAuxDsc = 0;
               AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrimStr( (decimal)(A1174LiqCueAuxDsc), 4, 0));
            }
            else
            {
               A1174LiqCueAuxDsc = (short)(context.localUtil.CToN( cgiGet( edtLiqCueAuxDsc_Internalname), ".", ","));
               AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrimStr( (decimal)(A1174LiqCueAuxDsc), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQSTS");
               AnyError = 1;
               GX_FocusControl = edtLiqSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1198LiqSts = 0;
               AssignAttri("", false, "A1198LiqSts", StringUtil.Str( (decimal)(A1198LiqSts), 1, 0));
            }
            else
            {
               A1198LiqSts = (short)(context.localUtil.CToN( cgiGet( edtLiqSts_Internalname), ".", ","));
               AssignAttri("", false, "A1198LiqSts", StringUtil.Str( (decimal)(A1198LiqSts), 1, 0));
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
               A236LiqPrvCod = GetPar( "LiqPrvCod");
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
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
               InitAll33106( ) ;
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
         DisableAttributes33106( ) ;
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

      protected void CONFIRM_330( )
      {
         BeforeValidate33106( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls33106( ) ;
            }
            else
            {
               CheckExtendedTable33106( ) ;
               if ( AnyError == 0 )
               {
                  ZM33106( 2) ;
               }
               CloseExtendedTableCursors33106( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues330( ) ;
         }
      }

      protected void ResetCaption330( )
      {
      }

      protected void ZM33106( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1197LiqPrvDsc = T00333_A1197LiqPrvDsc[0];
               Z1175LiqCueCodAux = T00333_A1175LiqCueCodAux[0];
               Z1174LiqCueAuxDsc = T00333_A1174LiqCueAuxDsc[0];
               Z1198LiqSts = T00333_A1198LiqSts[0];
               Z91CueCod = T00333_A91CueCod[0];
            }
            else
            {
               Z1197LiqPrvDsc = A1197LiqPrvDsc;
               Z1175LiqCueCodAux = A1175LiqCueCodAux;
               Z1174LiqCueAuxDsc = A1174LiqCueAuxDsc;
               Z1198LiqSts = A1198LiqSts;
               Z91CueCod = A91CueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z236LiqPrvCod = A236LiqPrvCod;
            Z1197LiqPrvDsc = A1197LiqPrvDsc;
            Z1175LiqCueCodAux = A1175LiqCueCodAux;
            Z1174LiqCueAuxDsc = A1174LiqCueAuxDsc;
            Z1198LiqSts = A1198LiqSts;
            Z91CueCod = A91CueCod;
            Z860CueDsc = A860CueDsc;
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

      protected void Load33106( )
      {
         /* Using cursor T00335 */
         pr_default.execute(3, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound106 = 1;
            A1197LiqPrvDsc = T00335_A1197LiqPrvDsc[0];
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            A860CueDsc = T00335_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A1175LiqCueCodAux = T00335_A1175LiqCueCodAux[0];
            n1175LiqCueCodAux = T00335_n1175LiqCueCodAux[0];
            AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrimStr( (decimal)(A1175LiqCueCodAux), 4, 0));
            A1174LiqCueAuxDsc = T00335_A1174LiqCueAuxDsc[0];
            AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrimStr( (decimal)(A1174LiqCueAuxDsc), 4, 0));
            A1198LiqSts = T00335_A1198LiqSts[0];
            AssignAttri("", false, "A1198LiqSts", StringUtil.Str( (decimal)(A1198LiqSts), 1, 0));
            A91CueCod = T00335_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            ZM33106( -1) ;
         }
         pr_default.close(3);
         OnLoadActions33106( ) ;
      }

      protected void OnLoadActions33106( )
      {
      }

      protected void CheckExtendedTable33106( )
      {
         nIsDirty_106 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00334 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T00334_A860CueDsc[0];
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors33106( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A91CueCod )
      {
         /* Using cursor T00336 */
         pr_default.execute(4, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T00336_A860CueDsc[0];
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A860CueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey33106( )
      {
         /* Using cursor T00337 */
         pr_default.execute(5, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound106 = 1;
         }
         else
         {
            RcdFound106 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00333 */
         pr_default.execute(1, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM33106( 1) ;
            RcdFound106 = 1;
            A236LiqPrvCod = T00333_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A1197LiqPrvDsc = T00333_A1197LiqPrvDsc[0];
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            A1175LiqCueCodAux = T00333_A1175LiqCueCodAux[0];
            n1175LiqCueCodAux = T00333_n1175LiqCueCodAux[0];
            AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrimStr( (decimal)(A1175LiqCueCodAux), 4, 0));
            A1174LiqCueAuxDsc = T00333_A1174LiqCueAuxDsc[0];
            AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrimStr( (decimal)(A1174LiqCueAuxDsc), 4, 0));
            A1198LiqSts = T00333_A1198LiqSts[0];
            AssignAttri("", false, "A1198LiqSts", StringUtil.Str( (decimal)(A1198LiqSts), 1, 0));
            A91CueCod = T00333_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            Z236LiqPrvCod = A236LiqPrvCod;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load33106( ) ;
            if ( AnyError == 1 )
            {
               RcdFound106 = 0;
               InitializeNonKey33106( ) ;
            }
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound106 = 0;
            InitializeNonKey33106( ) ;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode106;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey33106( ) ;
         if ( RcdFound106 == 0 )
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
         RcdFound106 = 0;
         /* Using cursor T00338 */
         pr_default.execute(6, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00338_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00338_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) ) )
            {
               A236LiqPrvCod = T00338_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               RcdFound106 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound106 = 0;
         /* Using cursor T00339 */
         pr_default.execute(7, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00339_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00339_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) ) )
            {
               A236LiqPrvCod = T00339_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               RcdFound106 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey33106( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert33106( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound106 == 1 )
            {
               if ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 )
               {
                  A236LiqPrvCod = Z236LiqPrvCod;
                  AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LIQPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLiqPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLiqPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update33106( ) ;
                  GX_FocusControl = edtLiqPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLiqPrvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert33106( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LIQPRVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLiqPrvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLiqPrvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert33106( ) ;
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
         if ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 )
         {
            A236LiqPrvCod = Z236LiqPrvCod;
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLiqPrvCod_Internalname;
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
         GetKey33106( ) ;
         if ( RcdFound106 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LIQPRVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqPrvCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 )
            {
               A236LiqPrvCod = Z236LiqPrvCod;
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LIQPRVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqPrvCod_Internalname;
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
            if ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LIQPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLiqPrvCod_Internalname;
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
         context.RollbackDataStores("cpagentes",pr_default);
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_330( ) ;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart33106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd33106( ) ;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
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
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
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
         ScanStart33106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound106 != 0 )
            {
               ScanNext33106( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd33106( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency33106( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00332 */
            pr_default.execute(0, new Object[] {A236LiqPrvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPAGENTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1197LiqPrvDsc, T00332_A1197LiqPrvDsc[0]) != 0 ) || ( Z1175LiqCueCodAux != T00332_A1175LiqCueCodAux[0] ) || ( Z1174LiqCueAuxDsc != T00332_A1174LiqCueAuxDsc[0] ) || ( Z1198LiqSts != T00332_A1198LiqSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T00332_A91CueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1197LiqPrvDsc, T00332_A1197LiqPrvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpagentes:[seudo value changed for attri]"+"LiqPrvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1197LiqPrvDsc);
                  GXUtil.WriteLogRaw("Current: ",T00332_A1197LiqPrvDsc[0]);
               }
               if ( Z1175LiqCueCodAux != T00332_A1175LiqCueCodAux[0] )
               {
                  GXUtil.WriteLog("cpagentes:[seudo value changed for attri]"+"LiqCueCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z1175LiqCueCodAux);
                  GXUtil.WriteLogRaw("Current: ",T00332_A1175LiqCueCodAux[0]);
               }
               if ( Z1174LiqCueAuxDsc != T00332_A1174LiqCueAuxDsc[0] )
               {
                  GXUtil.WriteLog("cpagentes:[seudo value changed for attri]"+"LiqCueAuxDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1174LiqCueAuxDsc);
                  GXUtil.WriteLogRaw("Current: ",T00332_A1174LiqCueAuxDsc[0]);
               }
               if ( Z1198LiqSts != T00332_A1198LiqSts[0] )
               {
                  GXUtil.WriteLog("cpagentes:[seudo value changed for attri]"+"LiqSts");
                  GXUtil.WriteLogRaw("Old: ",Z1198LiqSts);
                  GXUtil.WriteLogRaw("Current: ",T00332_A1198LiqSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T00332_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpagentes:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T00332_A91CueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPAGENTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert33106( )
      {
         BeforeValidate33106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33106( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM33106( 0) ;
            CheckOptimisticConcurrency33106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert33106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003310 */
                     pr_default.execute(8, new Object[] {A236LiqPrvCod, A1197LiqPrvDsc, n1175LiqCueCodAux, A1175LiqCueCodAux, A1174LiqCueAuxDsc, A1198LiqSts, A91CueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CPAGENTES");
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
                           ResetCaption330( ) ;
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
               Load33106( ) ;
            }
            EndLevel33106( ) ;
         }
         CloseExtendedTableCursors33106( ) ;
      }

      protected void Update33106( )
      {
         BeforeValidate33106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33106( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate33106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003311 */
                     pr_default.execute(9, new Object[] {A1197LiqPrvDsc, n1175LiqCueCodAux, A1175LiqCueCodAux, A1174LiqCueAuxDsc, A1198LiqSts, A91CueCod, A236LiqPrvCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CPAGENTES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPAGENTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate33106( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption330( ) ;
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
            EndLevel33106( ) ;
         }
         CloseExtendedTableCursors33106( ) ;
      }

      protected void DeferredUpdate33106( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate33106( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33106( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls33106( ) ;
            AfterConfirm33106( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete33106( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003312 */
                  pr_default.execute(10, new Object[] {A236LiqPrvCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CPAGENTES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound106 == 0 )
                        {
                           InitAll33106( ) ;
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
                        ResetCaption330( ) ;
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
         sMode106 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel33106( ) ;
         Gx_mode = sMode106;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls33106( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003313 */
            pr_default.execute(11, new Object[] {A91CueCod});
            A860CueDsc = T003313_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003314 */
            pr_default.execute(12, new Object[] {A236LiqPrvCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T003315 */
            pr_default.execute(13, new Object[] {A236LiqPrvCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel33106( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete33106( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("cpagentes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues330( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("cpagentes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart33106( )
      {
         /* Using cursor T003316 */
         pr_default.execute(14);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound106 = 1;
            A236LiqPrvCod = T003316_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext33106( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound106 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound106 = 1;
            A236LiqPrvCod = T003316_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         }
      }

      protected void ScanEnd33106( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm33106( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert33106( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate33106( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete33106( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete33106( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate33106( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes33106( )
      {
         edtLiqPrvCod_Enabled = 0;
         AssignProp("", false, edtLiqPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvCod_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtLiqPrvDsc_Enabled = 0;
         AssignProp("", false, edtLiqPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvDsc_Enabled), 5, 0), true);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), true);
         edtLiqCueCodAux_Enabled = 0;
         AssignProp("", false, edtLiqCueCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCueCodAux_Enabled), 5, 0), true);
         edtLiqCueAuxDsc_Enabled = 0;
         AssignProp("", false, edtLiqCueAuxDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCueAuxDsc_Enabled), 5, 0), true);
         edtLiqSts_Enabled = 0;
         AssignProp("", false, edtLiqSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes33106( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues330( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245520", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpagentes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1197LiqPrvDsc", StringUtil.RTrim( Z1197LiqPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1175LiqCueCodAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1175LiqCueCodAux), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1174LiqCueAuxDsc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1174LiqCueAuxDsc), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1198LiqSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1198LiqSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
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
         return formatLink("cpagentes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPAGENTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Agentes" ;
      }

      protected void InitializeNonKey33106( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A1197LiqPrvDsc = "";
         AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
         A860CueDsc = "";
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A1175LiqCueCodAux = 0;
         n1175LiqCueCodAux = false;
         AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrimStr( (decimal)(A1175LiqCueCodAux), 4, 0));
         A1174LiqCueAuxDsc = 0;
         AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrimStr( (decimal)(A1174LiqCueAuxDsc), 4, 0));
         A1198LiqSts = 0;
         AssignAttri("", false, "A1198LiqSts", StringUtil.Str( (decimal)(A1198LiqSts), 1, 0));
         Z1197LiqPrvDsc = "";
         Z1175LiqCueCodAux = 0;
         Z1174LiqCueAuxDsc = 0;
         Z1198LiqSts = 0;
         Z91CueCod = "";
      }

      protected void InitAll33106( )
      {
         A236LiqPrvCod = "";
         AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         InitializeNonKey33106( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245527", true, true);
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
         context.AddJavascriptSource("cpagentes.js", "?202281810245528", false, true);
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
         edtLiqPrvCod_Internalname = "LIQPRVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLiqPrvDsc_Internalname = "LIQPRVDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCueDsc_Internalname = "CUEDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLiqCueCodAux_Internalname = "LIQCUECODAUX";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLiqCueAuxDsc_Internalname = "LIQCUEAUXDSC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLiqSts_Internalname = "LIQSTS";
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
         Form.Caption = "Agentes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLiqSts_Jsonclick = "";
         edtLiqSts_Enabled = 1;
         edtLiqCueAuxDsc_Jsonclick = "";
         edtLiqCueAuxDsc_Enabled = 1;
         edtLiqCueCodAux_Jsonclick = "";
         edtLiqCueCodAux_Enabled = 1;
         edtCueDsc_Jsonclick = "";
         edtCueDsc_Enabled = 0;
         edtLiqPrvDsc_Jsonclick = "";
         edtLiqPrvDsc_Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLiqPrvCod_Jsonclick = "";
         edtLiqPrvCod_Enabled = 1;
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
         GX_FocusControl = edtCueCod_Internalname;
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

      public void Valid_Liqprvcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A1197LiqPrvDsc", StringUtil.RTrim( A1197LiqPrvDsc));
         AssignAttri("", false, "A1175LiqCueCodAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1175LiqCueCodAux), 4, 0, ".", "")));
         AssignAttri("", false, "A1174LiqCueAuxDsc", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1174LiqCueAuxDsc), 4, 0, ".", "")));
         AssignAttri("", false, "A1198LiqSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1198LiqSts), 1, 0, ".", "")));
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z1197LiqPrvDsc", StringUtil.RTrim( Z1197LiqPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1175LiqCueCodAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1175LiqCueCodAux), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1174LiqCueAuxDsc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1174LiqCueAuxDsc), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1198LiqSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1198LiqSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z860CueDsc", StringUtil.RTrim( Z860CueDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T003313 */
         pr_default.execute(11, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         A860CueDsc = T003313_A860CueDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
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
         setEventMetadata("VALID_LIQPRVCOD","{handler:'Valid_Liqprvcod',iparms:[{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LIQPRVCOD",",oparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A1197LiqPrvDsc',fld:'LIQPRVDSC',pic:''},{av:'A1175LiqCueCodAux',fld:'LIQCUECODAUX',pic:'ZZZ9'},{av:'A1174LiqCueAuxDsc',fld:'LIQCUEAUXDSC',pic:'ZZZ9'},{av:'A1198LiqSts',fld:'LIQSTS',pic:'9'},{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z236LiqPrvCod'},{av:'Z91CueCod'},{av:'Z1197LiqPrvDsc'},{av:'Z1175LiqCueCodAux'},{av:'Z1174LiqCueAuxDsc'},{av:'Z1198LiqSts'},{av:'Z860CueDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z236LiqPrvCod = "";
         Z1197LiqPrvDsc = "";
         Z91CueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A91CueCod = "";
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
         A236LiqPrvCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A1197LiqPrvDsc = "";
         lblTextblock4_Jsonclick = "";
         A860CueDsc = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
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
         Z860CueDsc = "";
         T00335_A236LiqPrvCod = new string[] {""} ;
         T00335_A1197LiqPrvDsc = new string[] {""} ;
         T00335_A860CueDsc = new string[] {""} ;
         T00335_A1175LiqCueCodAux = new short[1] ;
         T00335_n1175LiqCueCodAux = new bool[] {false} ;
         T00335_A1174LiqCueAuxDsc = new short[1] ;
         T00335_A1198LiqSts = new short[1] ;
         T00335_A91CueCod = new string[] {""} ;
         T00334_A860CueDsc = new string[] {""} ;
         T00336_A860CueDsc = new string[] {""} ;
         T00337_A236LiqPrvCod = new string[] {""} ;
         T00333_A236LiqPrvCod = new string[] {""} ;
         T00333_A1197LiqPrvDsc = new string[] {""} ;
         T00333_A1175LiqCueCodAux = new short[1] ;
         T00333_n1175LiqCueCodAux = new bool[] {false} ;
         T00333_A1174LiqCueAuxDsc = new short[1] ;
         T00333_A1198LiqSts = new short[1] ;
         T00333_A91CueCod = new string[] {""} ;
         sMode106 = "";
         T00338_A236LiqPrvCod = new string[] {""} ;
         T00339_A236LiqPrvCod = new string[] {""} ;
         T00332_A236LiqPrvCod = new string[] {""} ;
         T00332_A1197LiqPrvDsc = new string[] {""} ;
         T00332_A1175LiqCueCodAux = new short[1] ;
         T00332_n1175LiqCueCodAux = new bool[] {false} ;
         T00332_A1174LiqCueAuxDsc = new short[1] ;
         T00332_A1198LiqSts = new short[1] ;
         T00332_A91CueCod = new string[] {""} ;
         T003313_A860CueDsc = new string[] {""} ;
         T003314_A270LiqCod = new string[] {""} ;
         T003314_A236LiqPrvCod = new string[] {""} ;
         T003314_A277LiqMItem = new int[1] ;
         T003315_A270LiqCod = new string[] {""} ;
         T003315_A236LiqPrvCod = new string[] {""} ;
         T003315_A271LiqCodItem = new int[1] ;
         T003316_A236LiqPrvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ236LiqPrvCod = "";
         ZZ91CueCod = "";
         ZZ1197LiqPrvDsc = "";
         ZZ860CueDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpagentes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpagentes__default(),
            new Object[][] {
                new Object[] {
               T00332_A236LiqPrvCod, T00332_A1197LiqPrvDsc, T00332_A1175LiqCueCodAux, T00332_n1175LiqCueCodAux, T00332_A1174LiqCueAuxDsc, T00332_A1198LiqSts, T00332_A91CueCod
               }
               , new Object[] {
               T00333_A236LiqPrvCod, T00333_A1197LiqPrvDsc, T00333_A1175LiqCueCodAux, T00333_n1175LiqCueCodAux, T00333_A1174LiqCueAuxDsc, T00333_A1198LiqSts, T00333_A91CueCod
               }
               , new Object[] {
               T00334_A860CueDsc
               }
               , new Object[] {
               T00335_A236LiqPrvCod, T00335_A1197LiqPrvDsc, T00335_A860CueDsc, T00335_A1175LiqCueCodAux, T00335_n1175LiqCueCodAux, T00335_A1174LiqCueAuxDsc, T00335_A1198LiqSts, T00335_A91CueCod
               }
               , new Object[] {
               T00336_A860CueDsc
               }
               , new Object[] {
               T00337_A236LiqPrvCod
               }
               , new Object[] {
               T00338_A236LiqPrvCod
               }
               , new Object[] {
               T00339_A236LiqPrvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003313_A860CueDsc
               }
               , new Object[] {
               T003314_A270LiqCod, T003314_A236LiqPrvCod, T003314_A277LiqMItem
               }
               , new Object[] {
               T003315_A270LiqCod, T003315_A236LiqPrvCod, T003315_A271LiqCodItem
               }
               , new Object[] {
               T003316_A236LiqPrvCod
               }
            }
         );
      }

      private short Z1175LiqCueCodAux ;
      private short Z1174LiqCueAuxDsc ;
      private short Z1198LiqSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1175LiqCueCodAux ;
      private short A1174LiqCueAuxDsc ;
      private short A1198LiqSts ;
      private short GX_JID ;
      private short RcdFound106 ;
      private short nIsDirty_106 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1175LiqCueCodAux ;
      private short ZZ1174LiqCueAuxDsc ;
      private short ZZ1198LiqSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLiqPrvCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtLiqPrvDsc_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtLiqCueCodAux_Enabled ;
      private int edtLiqCueAuxDsc_Enabled ;
      private int edtLiqSts_Enabled ;
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
      private string Z236LiqPrvCod ;
      private string Z1197LiqPrvDsc ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLiqPrvCod_Internalname ;
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
      private string A236LiqPrvCod ;
      private string edtLiqPrvCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLiqPrvDsc_Internalname ;
      private string A1197LiqPrvDsc ;
      private string edtLiqPrvDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCueDsc_Internalname ;
      private string A860CueDsc ;
      private string edtCueDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLiqCueCodAux_Internalname ;
      private string edtLiqCueCodAux_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLiqCueAuxDsc_Internalname ;
      private string edtLiqCueAuxDsc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLiqSts_Internalname ;
      private string edtLiqSts_Jsonclick ;
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
      private string Z860CueDsc ;
      private string sMode106 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ236LiqPrvCod ;
      private string ZZ91CueCod ;
      private string ZZ1197LiqPrvDsc ;
      private string ZZ860CueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1175LiqCueCodAux ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00335_A236LiqPrvCod ;
      private string[] T00335_A1197LiqPrvDsc ;
      private string[] T00335_A860CueDsc ;
      private short[] T00335_A1175LiqCueCodAux ;
      private bool[] T00335_n1175LiqCueCodAux ;
      private short[] T00335_A1174LiqCueAuxDsc ;
      private short[] T00335_A1198LiqSts ;
      private string[] T00335_A91CueCod ;
      private string[] T00334_A860CueDsc ;
      private string[] T00336_A860CueDsc ;
      private string[] T00337_A236LiqPrvCod ;
      private string[] T00333_A236LiqPrvCod ;
      private string[] T00333_A1197LiqPrvDsc ;
      private short[] T00333_A1175LiqCueCodAux ;
      private bool[] T00333_n1175LiqCueCodAux ;
      private short[] T00333_A1174LiqCueAuxDsc ;
      private short[] T00333_A1198LiqSts ;
      private string[] T00333_A91CueCod ;
      private string[] T00338_A236LiqPrvCod ;
      private string[] T00339_A236LiqPrvCod ;
      private string[] T00332_A236LiqPrvCod ;
      private string[] T00332_A1197LiqPrvDsc ;
      private short[] T00332_A1175LiqCueCodAux ;
      private bool[] T00332_n1175LiqCueCodAux ;
      private short[] T00332_A1174LiqCueAuxDsc ;
      private short[] T00332_A1198LiqSts ;
      private string[] T00332_A91CueCod ;
      private string[] T003313_A860CueDsc ;
      private string[] T003314_A270LiqCod ;
      private string[] T003314_A236LiqPrvCod ;
      private int[] T003314_A277LiqMItem ;
      private string[] T003315_A270LiqCod ;
      private string[] T003315_A236LiqPrvCod ;
      private int[] T003315_A271LiqCodItem ;
      private string[] T003316_A236LiqPrvCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpagentes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpagentes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00335;
        prmT00335 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00334;
        prmT00334 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00336;
        prmT00336 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00337;
        prmT00337 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00333;
        prmT00333 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00338;
        prmT00338 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00339;
        prmT00339 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00332;
        prmT00332 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003310;
        prmT003310 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqPrvDsc",GXType.NChar,100,0) ,
        new ParDef("@LiqCueCodAux",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@LiqCueAuxDsc",GXType.Int16,4,0) ,
        new ParDef("@LiqSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT003311;
        prmT003311 = new Object[] {
        new ParDef("@LiqPrvDsc",GXType.NChar,100,0) ,
        new ParDef("@LiqCueCodAux",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@LiqCueAuxDsc",GXType.Int16,4,0) ,
        new ParDef("@LiqSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003312;
        prmT003312 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003314;
        prmT003314 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003315;
        prmT003315 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003316;
        prmT003316 = new Object[] {
        };
        Object[] prmT003313;
        prmT003313 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00332", "SELECT [LiqPrvCod], [LiqPrvDsc], [LiqCueCodAux], [LiqCueAuxDsc], [LiqSts], [CueCod] FROM [CPAGENTES] WITH (UPDLOCK) WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00332,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00333", "SELECT [LiqPrvCod], [LiqPrvDsc], [LiqCueCodAux], [LiqCueAuxDsc], [LiqSts], [CueCod] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00333,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00334", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00334,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00335", "SELECT TM1.[LiqPrvCod], TM1.[LiqPrvDsc], T2.[CueDsc], TM1.[LiqCueCodAux], TM1.[LiqCueAuxDsc], TM1.[LiqSts], TM1.[CueCod] FROM ([CPAGENTES] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CueCod]) WHERE TM1.[LiqPrvCod] = @LiqPrvCod ORDER BY TM1.[LiqPrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00335,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00336", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00336,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00337", "SELECT [LiqPrvCod] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00337,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00338", "SELECT TOP 1 [LiqPrvCod] FROM [CPAGENTES] WHERE ( [LiqPrvCod] > @LiqPrvCod) ORDER BY [LiqPrvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00338,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00339", "SELECT TOP 1 [LiqPrvCod] FROM [CPAGENTES] WHERE ( [LiqPrvCod] < @LiqPrvCod) ORDER BY [LiqPrvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00339,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003310", "INSERT INTO [CPAGENTES]([LiqPrvCod], [LiqPrvDsc], [LiqCueCodAux], [LiqCueAuxDsc], [LiqSts], [CueCod]) VALUES(@LiqPrvCod, @LiqPrvDsc, @LiqCueCodAux, @LiqCueAuxDsc, @LiqSts, @CueCod)", GxErrorMask.GX_NOMASK,prmT003310)
           ,new CursorDef("T003311", "UPDATE [CPAGENTES] SET [LiqPrvDsc]=@LiqPrvDsc, [LiqCueCodAux]=@LiqCueCodAux, [LiqCueAuxDsc]=@LiqCueAuxDsc, [LiqSts]=@LiqSts, [CueCod]=@CueCod  WHERE [LiqPrvCod] = @LiqPrvCod", GxErrorMask.GX_NOMASK,prmT003311)
           ,new CursorDef("T003312", "DELETE FROM [CPAGENTES]  WHERE [LiqPrvCod] = @LiqPrvCod", GxErrorMask.GX_NOMASK,prmT003312)
           ,new CursorDef("T003313", "SELECT [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003314", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003314,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003315", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003315,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003316", "SELECT [LiqPrvCod] FROM [CPAGENTES] ORDER BY [LiqPrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003316,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
