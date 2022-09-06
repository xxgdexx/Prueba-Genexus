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
   public class cpcomprasdetimpo : GXDataArea
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
            Form.Meta.addItem("description", "Detalle % de Gastos de Importacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtImpPoliza_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpcomprasdetimpo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpcomprasdetimpo( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCOMPRASDETIMPO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Poliza", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPoliza_Internalname, StringUtil.RTrim( A255ImpPoliza), StringUtil.RTrim( context.localUtil.Format( A255ImpPoliza, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPoliza_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPoliza_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Proveedor", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPrvCod_Internalname, StringUtil.RTrim( A256ImpPrvCod), StringUtil.RTrim( context.localUtil.Format( A256ImpPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPrvCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo Documento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPTipCod_Internalname, StringUtil.RTrim( A257ImpPTipCod), StringUtil.RTrim( context.localUtil.Format( A257ImpPTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "N° Documento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPComCod_Internalname, StringUtil.RTrim( A258ImpPComCod), StringUtil.RTrim( context.localUtil.Format( A258ImpPComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPComCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Producto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPProdCod_Internalname, StringUtil.RTrim( A259ImpPProdCod), StringUtil.RTrim( context.localUtil.Format( A259ImpPProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Porcentaje", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1042ImpPPor, 8, 4, ".", "")), StringUtil.LTrim( ((edtImpPPor_Enabled!=0) ? context.localUtil.Format( A1042ImpPPor, "ZZ9.9999") : context.localUtil.Format( A1042ImpPPor, "ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPPor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPPor_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRASDETIMPO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDETIMPO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPCOMPRASDETIMPO.htm");
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
            Z255ImpPoliza = cgiGet( "Z255ImpPoliza");
            Z256ImpPrvCod = cgiGet( "Z256ImpPrvCod");
            Z257ImpPTipCod = cgiGet( "Z257ImpPTipCod");
            Z258ImpPComCod = cgiGet( "Z258ImpPComCod");
            Z259ImpPProdCod = cgiGet( "Z259ImpPProdCod");
            Z1042ImpPPor = context.localUtil.CToN( cgiGet( "Z1042ImpPPor"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A255ImpPoliza = cgiGet( edtImpPoliza_Internalname);
            AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
            A256ImpPrvCod = cgiGet( edtImpPrvCod_Internalname);
            AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
            A257ImpPTipCod = cgiGet( edtImpPTipCod_Internalname);
            AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
            A258ImpPComCod = cgiGet( edtImpPComCod_Internalname);
            AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
            A259ImpPProdCod = cgiGet( edtImpPProdCod_Internalname);
            AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpPPor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpPPor_Internalname), ".", ",") > 999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPPPOR");
               AnyError = 1;
               GX_FocusControl = edtImpPPor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1042ImpPPor = 0;
               AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrimStr( A1042ImpPPor, 8, 4));
            }
            else
            {
               A1042ImpPPor = context.localUtil.CToN( cgiGet( edtImpPPor_Internalname), ".", ",");
               AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrimStr( A1042ImpPPor, 8, 4));
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
               A255ImpPoliza = GetPar( "ImpPoliza");
               AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
               A256ImpPrvCod = GetPar( "ImpPrvCod");
               AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
               A257ImpPTipCod = GetPar( "ImpPTipCod");
               AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
               A258ImpPComCod = GetPar( "ImpPComCod");
               AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
               A259ImpPProdCod = GetPar( "ImpPProdCod");
               AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
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
               InitAll38111( ) ;
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
         DisableAttributes38111( ) ;
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

      protected void CONFIRM_380( )
      {
         BeforeValidate38111( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls38111( ) ;
            }
            else
            {
               CheckExtendedTable38111( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors38111( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues380( ) ;
         }
      }

      protected void ResetCaption380( )
      {
      }

      protected void ZM38111( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1042ImpPPor = T00383_A1042ImpPPor[0];
            }
            else
            {
               Z1042ImpPPor = A1042ImpPPor;
            }
         }
         if ( GX_JID == -1 )
         {
            Z255ImpPoliza = A255ImpPoliza;
            Z256ImpPrvCod = A256ImpPrvCod;
            Z257ImpPTipCod = A257ImpPTipCod;
            Z258ImpPComCod = A258ImpPComCod;
            Z259ImpPProdCod = A259ImpPProdCod;
            Z1042ImpPPor = A1042ImpPPor;
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

      protected void Load38111( )
      {
         /* Using cursor T00384 */
         pr_default.execute(2, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound111 = 1;
            A1042ImpPPor = T00384_A1042ImpPPor[0];
            AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrimStr( A1042ImpPPor, 8, 4));
            ZM38111( -1) ;
         }
         pr_default.close(2);
         OnLoadActions38111( ) ;
      }

      protected void OnLoadActions38111( )
      {
      }

      protected void CheckExtendedTable38111( )
      {
         nIsDirty_111 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors38111( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey38111( )
      {
         /* Using cursor T00385 */
         pr_default.execute(3, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound111 = 1;
         }
         else
         {
            RcdFound111 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00383 */
         pr_default.execute(1, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM38111( 1) ;
            RcdFound111 = 1;
            A255ImpPoliza = T00383_A255ImpPoliza[0];
            AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
            A256ImpPrvCod = T00383_A256ImpPrvCod[0];
            AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
            A257ImpPTipCod = T00383_A257ImpPTipCod[0];
            AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
            A258ImpPComCod = T00383_A258ImpPComCod[0];
            AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
            A259ImpPProdCod = T00383_A259ImpPProdCod[0];
            AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
            A1042ImpPPor = T00383_A1042ImpPPor[0];
            AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrimStr( A1042ImpPPor, 8, 4));
            Z255ImpPoliza = A255ImpPoliza;
            Z256ImpPrvCod = A256ImpPrvCod;
            Z257ImpPTipCod = A257ImpPTipCod;
            Z258ImpPComCod = A258ImpPComCod;
            Z259ImpPProdCod = A259ImpPProdCod;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load38111( ) ;
            if ( AnyError == 1 )
            {
               RcdFound111 = 0;
               InitializeNonKey38111( ) ;
            }
            Gx_mode = sMode111;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound111 = 0;
            InitializeNonKey38111( ) ;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode111;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey38111( ) ;
         if ( RcdFound111 == 0 )
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
         RcdFound111 = 0;
         /* Using cursor T00386 */
         pr_default.execute(4, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) < 0 ) || ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) < 0 ) || ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) < 0 ) || ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A258ImpPComCod[0], A258ImpPComCod) < 0 ) || ( StringUtil.StrCmp(T00386_A258ImpPComCod[0], A258ImpPComCod) == 0 ) && ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A259ImpPProdCod[0], A259ImpPProdCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) > 0 ) || ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) > 0 ) || ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) > 0 ) || ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A258ImpPComCod[0], A258ImpPComCod) > 0 ) || ( StringUtil.StrCmp(T00386_A258ImpPComCod[0], A258ImpPComCod) == 0 ) && ( StringUtil.StrCmp(T00386_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00386_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00386_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00386_A259ImpPProdCod[0], A259ImpPProdCod) > 0 ) ) )
            {
               A255ImpPoliza = T00386_A255ImpPoliza[0];
               AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
               A256ImpPrvCod = T00386_A256ImpPrvCod[0];
               AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
               A257ImpPTipCod = T00386_A257ImpPTipCod[0];
               AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
               A258ImpPComCod = T00386_A258ImpPComCod[0];
               AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
               A259ImpPProdCod = T00386_A259ImpPProdCod[0];
               AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
               RcdFound111 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound111 = 0;
         /* Using cursor T00387 */
         pr_default.execute(5, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) > 0 ) || ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) > 0 ) || ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) > 0 ) || ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A258ImpPComCod[0], A258ImpPComCod) > 0 ) || ( StringUtil.StrCmp(T00387_A258ImpPComCod[0], A258ImpPComCod) == 0 ) && ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A259ImpPProdCod[0], A259ImpPProdCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) < 0 ) || ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) < 0 ) || ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) < 0 ) || ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A258ImpPComCod[0], A258ImpPComCod) < 0 ) || ( StringUtil.StrCmp(T00387_A258ImpPComCod[0], A258ImpPComCod) == 0 ) && ( StringUtil.StrCmp(T00387_A257ImpPTipCod[0], A257ImpPTipCod) == 0 ) && ( StringUtil.StrCmp(T00387_A256ImpPrvCod[0], A256ImpPrvCod) == 0 ) && ( StringUtil.StrCmp(T00387_A255ImpPoliza[0], A255ImpPoliza) == 0 ) && ( StringUtil.StrCmp(T00387_A259ImpPProdCod[0], A259ImpPProdCod) < 0 ) ) )
            {
               A255ImpPoliza = T00387_A255ImpPoliza[0];
               AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
               A256ImpPrvCod = T00387_A256ImpPrvCod[0];
               AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
               A257ImpPTipCod = T00387_A257ImpPTipCod[0];
               AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
               A258ImpPComCod = T00387_A258ImpPComCod[0];
               AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
               A259ImpPProdCod = T00387_A259ImpPProdCod[0];
               AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
               RcdFound111 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey38111( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtImpPoliza_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert38111( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound111 == 1 )
            {
               if ( ( StringUtil.StrCmp(A255ImpPoliza, Z255ImpPoliza) != 0 ) || ( StringUtil.StrCmp(A256ImpPrvCod, Z256ImpPrvCod) != 0 ) || ( StringUtil.StrCmp(A257ImpPTipCod, Z257ImpPTipCod) != 0 ) || ( StringUtil.StrCmp(A258ImpPComCod, Z258ImpPComCod) != 0 ) || ( StringUtil.StrCmp(A259ImpPProdCod, Z259ImpPProdCod) != 0 ) )
               {
                  A255ImpPoliza = Z255ImpPoliza;
                  AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
                  A256ImpPrvCod = Z256ImpPrvCod;
                  AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
                  A257ImpPTipCod = Z257ImpPTipCod;
                  AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
                  A258ImpPComCod = Z258ImpPComCod;
                  AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
                  A259ImpPProdCod = Z259ImpPProdCod;
                  AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IMPPOLIZA");
                  AnyError = 1;
                  GX_FocusControl = edtImpPoliza_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtImpPoliza_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update38111( ) ;
                  GX_FocusControl = edtImpPoliza_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A255ImpPoliza, Z255ImpPoliza) != 0 ) || ( StringUtil.StrCmp(A256ImpPrvCod, Z256ImpPrvCod) != 0 ) || ( StringUtil.StrCmp(A257ImpPTipCod, Z257ImpPTipCod) != 0 ) || ( StringUtil.StrCmp(A258ImpPComCod, Z258ImpPComCod) != 0 ) || ( StringUtil.StrCmp(A259ImpPProdCod, Z259ImpPProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtImpPoliza_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert38111( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPPOLIZA");
                     AnyError = 1;
                     GX_FocusControl = edtImpPoliza_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtImpPoliza_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert38111( ) ;
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
         if ( ( StringUtil.StrCmp(A255ImpPoliza, Z255ImpPoliza) != 0 ) || ( StringUtil.StrCmp(A256ImpPrvCod, Z256ImpPrvCod) != 0 ) || ( StringUtil.StrCmp(A257ImpPTipCod, Z257ImpPTipCod) != 0 ) || ( StringUtil.StrCmp(A258ImpPComCod, Z258ImpPComCod) != 0 ) || ( StringUtil.StrCmp(A259ImpPProdCod, Z259ImpPProdCod) != 0 ) )
         {
            A255ImpPoliza = Z255ImpPoliza;
            AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
            A256ImpPrvCod = Z256ImpPrvCod;
            AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
            A257ImpPTipCod = Z257ImpPTipCod;
            AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
            A258ImpPComCod = Z258ImpPComCod;
            AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
            A259ImpPProdCod = Z259ImpPProdCod;
            AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IMPPOLIZA");
            AnyError = 1;
            GX_FocusControl = edtImpPoliza_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtImpPoliza_Internalname;
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
         GetKey38111( ) ;
         if ( RcdFound111 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "IMPPOLIZA");
               AnyError = 1;
               GX_FocusControl = edtImpPoliza_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A255ImpPoliza, Z255ImpPoliza) != 0 ) || ( StringUtil.StrCmp(A256ImpPrvCod, Z256ImpPrvCod) != 0 ) || ( StringUtil.StrCmp(A257ImpPTipCod, Z257ImpPTipCod) != 0 ) || ( StringUtil.StrCmp(A258ImpPComCod, Z258ImpPComCod) != 0 ) || ( StringUtil.StrCmp(A259ImpPProdCod, Z259ImpPProdCod) != 0 ) )
            {
               A255ImpPoliza = Z255ImpPoliza;
               AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
               A256ImpPrvCod = Z256ImpPrvCod;
               AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
               A257ImpPTipCod = Z257ImpPTipCod;
               AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
               A258ImpPComCod = Z258ImpPComCod;
               AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
               A259ImpPProdCod = Z259ImpPProdCod;
               AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "IMPPOLIZA");
               AnyError = 1;
               GX_FocusControl = edtImpPoliza_Internalname;
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
            if ( ( StringUtil.StrCmp(A255ImpPoliza, Z255ImpPoliza) != 0 ) || ( StringUtil.StrCmp(A256ImpPrvCod, Z256ImpPrvCod) != 0 ) || ( StringUtil.StrCmp(A257ImpPTipCod, Z257ImpPTipCod) != 0 ) || ( StringUtil.StrCmp(A258ImpPComCod, Z258ImpPComCod) != 0 ) || ( StringUtil.StrCmp(A259ImpPProdCod, Z259ImpPProdCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPPOLIZA");
                  AnyError = 1;
                  GX_FocusControl = edtImpPoliza_Internalname;
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
         context.RollbackDataStores("cpcomprasdetimpo",pr_default);
         GX_FocusControl = edtImpPPor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_380( ) ;
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
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "IMPPOLIZA");
            AnyError = 1;
            GX_FocusControl = edtImpPoliza_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtImpPPor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart38111( ) ;
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpPPor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd38111( ) ;
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
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpPPor_Internalname;
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
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpPPor_Internalname;
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
         ScanStart38111( ) ;
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound111 != 0 )
            {
               ScanNext38111( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpPPor_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd38111( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency38111( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00382 */
            pr_default.execute(0, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRASDETIMPO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1042ImpPPor != T00382_A1042ImpPPor[0] ) )
            {
               if ( Z1042ImpPPor != T00382_A1042ImpPPor[0] )
               {
                  GXUtil.WriteLog("cpcomprasdetimpo:[seudo value changed for attri]"+"ImpPPor");
                  GXUtil.WriteLogRaw("Old: ",Z1042ImpPPor);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1042ImpPPor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCOMPRASDETIMPO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert38111( )
      {
         BeforeValidate38111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38111( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM38111( 0) ;
            CheckOptimisticConcurrency38111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert38111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00388 */
                     pr_default.execute(6, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod, A1042ImpPPor});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDETIMPO");
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
                           ResetCaption380( ) ;
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
               Load38111( ) ;
            }
            EndLevel38111( ) ;
         }
         CloseExtendedTableCursors38111( ) ;
      }

      protected void Update38111( )
      {
         BeforeValidate38111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38111( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate38111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00389 */
                     pr_default.execute(7, new Object[] {A1042ImpPPor, A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDETIMPO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRASDETIMPO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate38111( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption380( ) ;
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
            EndLevel38111( ) ;
         }
         CloseExtendedTableCursors38111( ) ;
      }

      protected void DeferredUpdate38111( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate38111( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38111( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls38111( ) ;
            AfterConfirm38111( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete38111( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003810 */
                  pr_default.execute(8, new Object[] {A255ImpPoliza, A256ImpPrvCod, A257ImpPTipCod, A258ImpPComCod, A259ImpPProdCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDETIMPO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound111 == 0 )
                        {
                           InitAll38111( ) ;
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
                        ResetCaption380( ) ;
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
         sMode111 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel38111( ) ;
         Gx_mode = sMode111;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls38111( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel38111( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete38111( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpcomprasdetimpo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues380( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpcomprasdetimpo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart38111( )
      {
         /* Using cursor T003811 */
         pr_default.execute(9);
         RcdFound111 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound111 = 1;
            A255ImpPoliza = T003811_A255ImpPoliza[0];
            AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
            A256ImpPrvCod = T003811_A256ImpPrvCod[0];
            AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
            A257ImpPTipCod = T003811_A257ImpPTipCod[0];
            AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
            A258ImpPComCod = T003811_A258ImpPComCod[0];
            AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
            A259ImpPProdCod = T003811_A259ImpPProdCod[0];
            AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext38111( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound111 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound111 = 1;
            A255ImpPoliza = T003811_A255ImpPoliza[0];
            AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
            A256ImpPrvCod = T003811_A256ImpPrvCod[0];
            AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
            A257ImpPTipCod = T003811_A257ImpPTipCod[0];
            AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
            A258ImpPComCod = T003811_A258ImpPComCod[0];
            AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
            A259ImpPProdCod = T003811_A259ImpPProdCod[0];
            AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
         }
      }

      protected void ScanEnd38111( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm38111( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert38111( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate38111( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete38111( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete38111( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate38111( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes38111( )
      {
         edtImpPoliza_Enabled = 0;
         AssignProp("", false, edtImpPoliza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPoliza_Enabled), 5, 0), true);
         edtImpPrvCod_Enabled = 0;
         AssignProp("", false, edtImpPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPrvCod_Enabled), 5, 0), true);
         edtImpPTipCod_Enabled = 0;
         AssignProp("", false, edtImpPTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPTipCod_Enabled), 5, 0), true);
         edtImpPComCod_Enabled = 0;
         AssignProp("", false, edtImpPComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPComCod_Enabled), 5, 0), true);
         edtImpPProdCod_Enabled = 0;
         AssignProp("", false, edtImpPProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPProdCod_Enabled), 5, 0), true);
         edtImpPPor_Enabled = 0;
         AssignProp("", false, edtImpPPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPPor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes38111( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues380( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245748", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpcomprasdetimpo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z255ImpPoliza", StringUtil.RTrim( Z255ImpPoliza));
         GxWebStd.gx_hidden_field( context, "Z256ImpPrvCod", StringUtil.RTrim( Z256ImpPrvCod));
         GxWebStd.gx_hidden_field( context, "Z257ImpPTipCod", StringUtil.RTrim( Z257ImpPTipCod));
         GxWebStd.gx_hidden_field( context, "Z258ImpPComCod", StringUtil.RTrim( Z258ImpPComCod));
         GxWebStd.gx_hidden_field( context, "Z259ImpPProdCod", StringUtil.RTrim( Z259ImpPProdCod));
         GxWebStd.gx_hidden_field( context, "Z1042ImpPPor", StringUtil.LTrim( StringUtil.NToC( Z1042ImpPPor, 8, 4, ".", "")));
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
         return formatLink("cpcomprasdetimpo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCOMPRASDETIMPO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle % de Gastos de Importacion" ;
      }

      protected void InitializeNonKey38111( )
      {
         A1042ImpPPor = 0;
         AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrimStr( A1042ImpPPor, 8, 4));
         Z1042ImpPPor = 0;
      }

      protected void InitAll38111( )
      {
         A255ImpPoliza = "";
         AssignAttri("", false, "A255ImpPoliza", A255ImpPoliza);
         A256ImpPrvCod = "";
         AssignAttri("", false, "A256ImpPrvCod", A256ImpPrvCod);
         A257ImpPTipCod = "";
         AssignAttri("", false, "A257ImpPTipCod", A257ImpPTipCod);
         A258ImpPComCod = "";
         AssignAttri("", false, "A258ImpPComCod", A258ImpPComCod);
         A259ImpPProdCod = "";
         AssignAttri("", false, "A259ImpPProdCod", A259ImpPProdCod);
         InitializeNonKey38111( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245754", true, true);
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
         context.AddJavascriptSource("cpcomprasdetimpo.js", "?202281810245754", false, true);
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
         edtImpPoliza_Internalname = "IMPPOLIZA";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtImpPrvCod_Internalname = "IMPPRVCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtImpPTipCod_Internalname = "IMPPTIPCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtImpPComCod_Internalname = "IMPPCOMCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtImpPProdCod_Internalname = "IMPPPRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtImpPPor_Internalname = "IMPPPOR";
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
         Form.Caption = "Detalle % de Gastos de Importacion";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtImpPPor_Jsonclick = "";
         edtImpPPor_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtImpPProdCod_Jsonclick = "";
         edtImpPProdCod_Enabled = 1;
         edtImpPComCod_Jsonclick = "";
         edtImpPComCod_Enabled = 1;
         edtImpPTipCod_Jsonclick = "";
         edtImpPTipCod_Enabled = 1;
         edtImpPrvCod_Jsonclick = "";
         edtImpPrvCod_Enabled = 1;
         edtImpPoliza_Jsonclick = "";
         edtImpPoliza_Enabled = 1;
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
         GX_FocusControl = edtImpPPor_Internalname;
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

      public void Valid_Imppprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1042ImpPPor", StringUtil.LTrim( StringUtil.NToC( A1042ImpPPor, 8, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z255ImpPoliza", StringUtil.RTrim( Z255ImpPoliza));
         GxWebStd.gx_hidden_field( context, "Z256ImpPrvCod", StringUtil.RTrim( Z256ImpPrvCod));
         GxWebStd.gx_hidden_field( context, "Z257ImpPTipCod", StringUtil.RTrim( Z257ImpPTipCod));
         GxWebStd.gx_hidden_field( context, "Z258ImpPComCod", StringUtil.RTrim( Z258ImpPComCod));
         GxWebStd.gx_hidden_field( context, "Z259ImpPProdCod", StringUtil.RTrim( Z259ImpPProdCod));
         GxWebStd.gx_hidden_field( context, "Z1042ImpPPor", StringUtil.LTrim( StringUtil.NToC( Z1042ImpPPor, 8, 4, ".", "")));
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
         setEventMetadata("VALID_IMPPOLIZA","{handler:'Valid_Imppoliza',iparms:[]");
         setEventMetadata("VALID_IMPPOLIZA",",oparms:[]}");
         setEventMetadata("VALID_IMPPRVCOD","{handler:'Valid_Impprvcod',iparms:[]");
         setEventMetadata("VALID_IMPPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPPTIPCOD","{handler:'Valid_Impptipcod',iparms:[]");
         setEventMetadata("VALID_IMPPTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPPCOMCOD","{handler:'Valid_Imppcomcod',iparms:[]");
         setEventMetadata("VALID_IMPPCOMCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPPPRODCOD","{handler:'Valid_Imppprodcod',iparms:[{av:'A255ImpPoliza',fld:'IMPPOLIZA',pic:''},{av:'A256ImpPrvCod',fld:'IMPPRVCOD',pic:''},{av:'A257ImpPTipCod',fld:'IMPPTIPCOD',pic:''},{av:'A258ImpPComCod',fld:'IMPPCOMCOD',pic:''},{av:'A259ImpPProdCod',fld:'IMPPPRODCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_IMPPPRODCOD",",oparms:[{av:'A1042ImpPPor',fld:'IMPPPOR',pic:'ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z255ImpPoliza'},{av:'Z256ImpPrvCod'},{av:'Z257ImpPTipCod'},{av:'Z258ImpPComCod'},{av:'Z259ImpPProdCod'},{av:'Z1042ImpPPor'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z255ImpPoliza = "";
         Z256ImpPrvCod = "";
         Z257ImpPTipCod = "";
         Z258ImpPComCod = "";
         Z259ImpPProdCod = "";
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
         A255ImpPoliza = "";
         lblTextblock2_Jsonclick = "";
         A256ImpPrvCod = "";
         lblTextblock3_Jsonclick = "";
         A257ImpPTipCod = "";
         lblTextblock4_Jsonclick = "";
         A258ImpPComCod = "";
         lblTextblock5_Jsonclick = "";
         A259ImpPProdCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
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
         T00384_A255ImpPoliza = new string[] {""} ;
         T00384_A256ImpPrvCod = new string[] {""} ;
         T00384_A257ImpPTipCod = new string[] {""} ;
         T00384_A258ImpPComCod = new string[] {""} ;
         T00384_A259ImpPProdCod = new string[] {""} ;
         T00384_A1042ImpPPor = new decimal[1] ;
         T00385_A255ImpPoliza = new string[] {""} ;
         T00385_A256ImpPrvCod = new string[] {""} ;
         T00385_A257ImpPTipCod = new string[] {""} ;
         T00385_A258ImpPComCod = new string[] {""} ;
         T00385_A259ImpPProdCod = new string[] {""} ;
         T00383_A255ImpPoliza = new string[] {""} ;
         T00383_A256ImpPrvCod = new string[] {""} ;
         T00383_A257ImpPTipCod = new string[] {""} ;
         T00383_A258ImpPComCod = new string[] {""} ;
         T00383_A259ImpPProdCod = new string[] {""} ;
         T00383_A1042ImpPPor = new decimal[1] ;
         sMode111 = "";
         T00386_A255ImpPoliza = new string[] {""} ;
         T00386_A256ImpPrvCod = new string[] {""} ;
         T00386_A257ImpPTipCod = new string[] {""} ;
         T00386_A258ImpPComCod = new string[] {""} ;
         T00386_A259ImpPProdCod = new string[] {""} ;
         T00387_A255ImpPoliza = new string[] {""} ;
         T00387_A256ImpPrvCod = new string[] {""} ;
         T00387_A257ImpPTipCod = new string[] {""} ;
         T00387_A258ImpPComCod = new string[] {""} ;
         T00387_A259ImpPProdCod = new string[] {""} ;
         T00382_A255ImpPoliza = new string[] {""} ;
         T00382_A256ImpPrvCod = new string[] {""} ;
         T00382_A257ImpPTipCod = new string[] {""} ;
         T00382_A258ImpPComCod = new string[] {""} ;
         T00382_A259ImpPProdCod = new string[] {""} ;
         T00382_A1042ImpPPor = new decimal[1] ;
         T003811_A255ImpPoliza = new string[] {""} ;
         T003811_A256ImpPrvCod = new string[] {""} ;
         T003811_A257ImpPTipCod = new string[] {""} ;
         T003811_A258ImpPComCod = new string[] {""} ;
         T003811_A259ImpPProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ255ImpPoliza = "";
         ZZ256ImpPrvCod = "";
         ZZ257ImpPTipCod = "";
         ZZ258ImpPComCod = "";
         ZZ259ImpPProdCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpcomprasdetimpo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpcomprasdetimpo__default(),
            new Object[][] {
                new Object[] {
               T00382_A255ImpPoliza, T00382_A256ImpPrvCod, T00382_A257ImpPTipCod, T00382_A258ImpPComCod, T00382_A259ImpPProdCod, T00382_A1042ImpPPor
               }
               , new Object[] {
               T00383_A255ImpPoliza, T00383_A256ImpPrvCod, T00383_A257ImpPTipCod, T00383_A258ImpPComCod, T00383_A259ImpPProdCod, T00383_A1042ImpPPor
               }
               , new Object[] {
               T00384_A255ImpPoliza, T00384_A256ImpPrvCod, T00384_A257ImpPTipCod, T00384_A258ImpPComCod, T00384_A259ImpPProdCod, T00384_A1042ImpPPor
               }
               , new Object[] {
               T00385_A255ImpPoliza, T00385_A256ImpPrvCod, T00385_A257ImpPTipCod, T00385_A258ImpPComCod, T00385_A259ImpPProdCod
               }
               , new Object[] {
               T00386_A255ImpPoliza, T00386_A256ImpPrvCod, T00386_A257ImpPTipCod, T00386_A258ImpPComCod, T00386_A259ImpPProdCod
               }
               , new Object[] {
               T00387_A255ImpPoliza, T00387_A256ImpPrvCod, T00387_A257ImpPTipCod, T00387_A258ImpPComCod, T00387_A259ImpPProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003811_A255ImpPoliza, T003811_A256ImpPrvCod, T003811_A257ImpPTipCod, T003811_A258ImpPComCod, T003811_A259ImpPProdCod
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
      private short RcdFound111 ;
      private short nIsDirty_111 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtImpPoliza_Enabled ;
      private int edtImpPrvCod_Enabled ;
      private int edtImpPTipCod_Enabled ;
      private int edtImpPComCod_Enabled ;
      private int edtImpPProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtImpPPor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z1042ImpPPor ;
      private decimal A1042ImpPPor ;
      private decimal ZZ1042ImpPPor ;
      private string sPrefix ;
      private string Z255ImpPoliza ;
      private string Z256ImpPrvCod ;
      private string Z257ImpPTipCod ;
      private string Z258ImpPComCod ;
      private string Z259ImpPProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtImpPoliza_Internalname ;
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
      private string A255ImpPoliza ;
      private string edtImpPoliza_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtImpPrvCod_Internalname ;
      private string A256ImpPrvCod ;
      private string edtImpPrvCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtImpPTipCod_Internalname ;
      private string A257ImpPTipCod ;
      private string edtImpPTipCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtImpPComCod_Internalname ;
      private string A258ImpPComCod ;
      private string edtImpPComCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtImpPProdCod_Internalname ;
      private string A259ImpPProdCod ;
      private string edtImpPProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtImpPPor_Internalname ;
      private string edtImpPPor_Jsonclick ;
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
      private string sMode111 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ255ImpPoliza ;
      private string ZZ256ImpPrvCod ;
      private string ZZ257ImpPTipCod ;
      private string ZZ258ImpPComCod ;
      private string ZZ259ImpPProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00384_A255ImpPoliza ;
      private string[] T00384_A256ImpPrvCod ;
      private string[] T00384_A257ImpPTipCod ;
      private string[] T00384_A258ImpPComCod ;
      private string[] T00384_A259ImpPProdCod ;
      private decimal[] T00384_A1042ImpPPor ;
      private string[] T00385_A255ImpPoliza ;
      private string[] T00385_A256ImpPrvCod ;
      private string[] T00385_A257ImpPTipCod ;
      private string[] T00385_A258ImpPComCod ;
      private string[] T00385_A259ImpPProdCod ;
      private string[] T00383_A255ImpPoliza ;
      private string[] T00383_A256ImpPrvCod ;
      private string[] T00383_A257ImpPTipCod ;
      private string[] T00383_A258ImpPComCod ;
      private string[] T00383_A259ImpPProdCod ;
      private decimal[] T00383_A1042ImpPPor ;
      private string[] T00386_A255ImpPoliza ;
      private string[] T00386_A256ImpPrvCod ;
      private string[] T00386_A257ImpPTipCod ;
      private string[] T00386_A258ImpPComCod ;
      private string[] T00386_A259ImpPProdCod ;
      private string[] T00387_A255ImpPoliza ;
      private string[] T00387_A256ImpPrvCod ;
      private string[] T00387_A257ImpPTipCod ;
      private string[] T00387_A258ImpPComCod ;
      private string[] T00387_A259ImpPProdCod ;
      private string[] T00382_A255ImpPoliza ;
      private string[] T00382_A256ImpPrvCod ;
      private string[] T00382_A257ImpPTipCod ;
      private string[] T00382_A258ImpPComCod ;
      private string[] T00382_A259ImpPProdCod ;
      private decimal[] T00382_A1042ImpPPor ;
      private string[] T003811_A255ImpPoliza ;
      private string[] T003811_A256ImpPrvCod ;
      private string[] T003811_A257ImpPTipCod ;
      private string[] T003811_A258ImpPComCod ;
      private string[] T003811_A259ImpPProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpcomprasdetimpo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpcomprasdetimpo__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00384;
        prmT00384 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00385;
        prmT00385 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00383;
        prmT00383 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00386;
        prmT00386 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00387;
        prmT00387 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00382;
        prmT00382 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00388;
        prmT00388 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPPor",GXType.Decimal,8,4)
        };
        Object[] prmT00389;
        prmT00389 = new Object[] {
        new ParDef("@ImpPPor",GXType.Decimal,8,4) ,
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003810;
        prmT003810 = new Object[] {
        new ParDef("@ImpPoliza",GXType.NChar,20,0) ,
        new ParDef("@ImpPrvCod",GXType.NChar,15,0) ,
        new ParDef("@ImpPTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpPComCod",GXType.NChar,20,0) ,
        new ParDef("@ImpPProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003811;
        prmT003811 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00382", "SELECT [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod], [ImpPPor] FROM [CPCOMPRASDETIMPO] WITH (UPDLOCK) WHERE [ImpPoliza] = @ImpPoliza AND [ImpPrvCod] = @ImpPrvCod AND [ImpPTipCod] = @ImpPTipCod AND [ImpPComCod] = @ImpPComCod AND [ImpPProdCod] = @ImpPProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00382,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00383", "SELECT [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod], [ImpPPor] FROM [CPCOMPRASDETIMPO] WHERE [ImpPoliza] = @ImpPoliza AND [ImpPrvCod] = @ImpPrvCod AND [ImpPTipCod] = @ImpPTipCod AND [ImpPComCod] = @ImpPComCod AND [ImpPProdCod] = @ImpPProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00383,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00384", "SELECT TM1.[ImpPoliza], TM1.[ImpPrvCod], TM1.[ImpPTipCod], TM1.[ImpPComCod], TM1.[ImpPProdCod], TM1.[ImpPPor] FROM [CPCOMPRASDETIMPO] TM1 WHERE TM1.[ImpPoliza] = @ImpPoliza and TM1.[ImpPrvCod] = @ImpPrvCod and TM1.[ImpPTipCod] = @ImpPTipCod and TM1.[ImpPComCod] = @ImpPComCod and TM1.[ImpPProdCod] = @ImpPProdCod ORDER BY TM1.[ImpPoliza], TM1.[ImpPrvCod], TM1.[ImpPTipCod], TM1.[ImpPComCod], TM1.[ImpPProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00384,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00385", "SELECT [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod] FROM [CPCOMPRASDETIMPO] WHERE [ImpPoliza] = @ImpPoliza AND [ImpPrvCod] = @ImpPrvCod AND [ImpPTipCod] = @ImpPTipCod AND [ImpPComCod] = @ImpPComCod AND [ImpPProdCod] = @ImpPProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00385,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00386", "SELECT TOP 1 [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod] FROM [CPCOMPRASDETIMPO] WHERE ( [ImpPoliza] > @ImpPoliza or [ImpPoliza] = @ImpPoliza and [ImpPrvCod] > @ImpPrvCod or [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPTipCod] > @ImpPTipCod or [ImpPTipCod] = @ImpPTipCod and [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPComCod] > @ImpPComCod or [ImpPComCod] = @ImpPComCod and [ImpPTipCod] = @ImpPTipCod and [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPProdCod] > @ImpPProdCod) ORDER BY [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00386,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00387", "SELECT TOP 1 [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod] FROM [CPCOMPRASDETIMPO] WHERE ( [ImpPoliza] < @ImpPoliza or [ImpPoliza] = @ImpPoliza and [ImpPrvCod] < @ImpPrvCod or [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPTipCod] < @ImpPTipCod or [ImpPTipCod] = @ImpPTipCod and [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPComCod] < @ImpPComCod or [ImpPComCod] = @ImpPComCod and [ImpPTipCod] = @ImpPTipCod and [ImpPrvCod] = @ImpPrvCod and [ImpPoliza] = @ImpPoliza and [ImpPProdCod] < @ImpPProdCod) ORDER BY [ImpPoliza] DESC, [ImpPrvCod] DESC, [ImpPTipCod] DESC, [ImpPComCod] DESC, [ImpPProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00387,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00388", "INSERT INTO [CPCOMPRASDETIMPO]([ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod], [ImpPPor]) VALUES(@ImpPoliza, @ImpPrvCod, @ImpPTipCod, @ImpPComCod, @ImpPProdCod, @ImpPPor)", GxErrorMask.GX_NOMASK,prmT00388)
           ,new CursorDef("T00389", "UPDATE [CPCOMPRASDETIMPO] SET [ImpPPor]=@ImpPPor  WHERE [ImpPoliza] = @ImpPoliza AND [ImpPrvCod] = @ImpPrvCod AND [ImpPTipCod] = @ImpPTipCod AND [ImpPComCod] = @ImpPComCod AND [ImpPProdCod] = @ImpPProdCod", GxErrorMask.GX_NOMASK,prmT00389)
           ,new CursorDef("T003810", "DELETE FROM [CPCOMPRASDETIMPO]  WHERE [ImpPoliza] = @ImpPoliza AND [ImpPrvCod] = @ImpPrvCod AND [ImpPTipCod] = @ImpPTipCod AND [ImpPComCod] = @ImpPComCod AND [ImpPProdCod] = @ImpPProdCod", GxErrorMask.GX_NOMASK,prmT003810)
           ,new CursorDef("T003811", "SELECT [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod] FROM [CPCOMPRASDETIMPO] ORDER BY [ImpPoliza], [ImpPrvCod], [ImpPTipCod], [ImpPComCod], [ImpPProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003811,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
     }
  }

}

}
