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
   public class aunitrasportes : GXDataArea
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
            Form.Meta.addItem("description", "Unidades de Transportes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUNTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aunitrasportes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aunitrasportes( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AUNITRASPORTES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Unidad", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UNTCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUNTCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A9UNTCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A9UNTCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Unidad", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTDsc_Internalname, StringUtil.RTrim( A2002UNTDsc), StringUtil.RTrim( context.localUtil.Format( A2002UNTDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Marca", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTMarca_Internalname, StringUtil.RTrim( A2003UNTMarca), StringUtil.RTrim( context.localUtil.Format( A2003UNTMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTMarca_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Placa", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTPlaca_Internalname, StringUtil.RTrim( A2005UNTPlaca), StringUtil.RTrim( context.localUtil.Format( A2005UNTPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTPlaca_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Modelo", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTMod_Internalname, StringUtil.RTrim( A2004UNTMod), StringUtil.RTrim( context.localUtil.Format( A2004UNTMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTMod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTMod_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Año", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTAno_Internalname, StringUtil.RTrim( A2001UNTAno), StringUtil.RTrim( context.localUtil.Format( A2001UNTAno, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTAno_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AUNITRASPORTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2006UNTSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtUNTSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2006UNTSts), "9") : context.localUtil.Format( (decimal)(A2006UNTSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AUNITRASPORTES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AUNITRASPORTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AUNITRASPORTES.htm");
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
            Z9UNTCod = (int)(context.localUtil.CToN( cgiGet( "Z9UNTCod"), ".", ","));
            Z2002UNTDsc = cgiGet( "Z2002UNTDsc");
            Z2003UNTMarca = cgiGet( "Z2003UNTMarca");
            Z2005UNTPlaca = cgiGet( "Z2005UNTPlaca");
            Z2004UNTMod = cgiGet( "Z2004UNTMod");
            Z2001UNTAno = cgiGet( "Z2001UNTAno");
            Z2006UNTSts = (short)(context.localUtil.CToN( cgiGet( "Z2006UNTSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNTCOD");
               AnyError = 1;
               GX_FocusControl = edtUNTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9UNTCod = 0;
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            }
            else
            {
               A9UNTCod = (int)(context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ","));
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            }
            A2002UNTDsc = cgiGet( edtUNTDsc_Internalname);
            AssignAttri("", false, "A2002UNTDsc", A2002UNTDsc);
            A2003UNTMarca = cgiGet( edtUNTMarca_Internalname);
            AssignAttri("", false, "A2003UNTMarca", A2003UNTMarca);
            A2005UNTPlaca = cgiGet( edtUNTPlaca_Internalname);
            AssignAttri("", false, "A2005UNTPlaca", A2005UNTPlaca);
            A2004UNTMod = cgiGet( edtUNTMod_Internalname);
            AssignAttri("", false, "A2004UNTMod", A2004UNTMod);
            A2001UNTAno = cgiGet( edtUNTAno_Internalname);
            AssignAttri("", false, "A2001UNTAno", A2001UNTAno);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUNTSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUNTSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNTSTS");
               AnyError = 1;
               GX_FocusControl = edtUNTSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2006UNTSts = 0;
               AssignAttri("", false, "A2006UNTSts", StringUtil.Str( (decimal)(A2006UNTSts), 1, 0));
            }
            else
            {
               A2006UNTSts = (short)(context.localUtil.CToN( cgiGet( edtUNTSts_Internalname), ".", ","));
               AssignAttri("", false, "A2006UNTSts", StringUtil.Str( (decimal)(A2006UNTSts), 1, 0));
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
               A9UNTCod = (int)(NumberUtil.Val( GetPar( "UNTCod"), "."));
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
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
               InitAll1J53( ) ;
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
         DisableAttributes1J53( ) ;
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

      protected void CONFIRM_1J0( )
      {
         BeforeValidate1J53( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1J53( ) ;
            }
            else
            {
               CheckExtendedTable1J53( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1J53( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1J0( ) ;
         }
      }

      protected void ResetCaption1J0( )
      {
      }

      protected void ZM1J53( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2002UNTDsc = T001J3_A2002UNTDsc[0];
               Z2003UNTMarca = T001J3_A2003UNTMarca[0];
               Z2005UNTPlaca = T001J3_A2005UNTPlaca[0];
               Z2004UNTMod = T001J3_A2004UNTMod[0];
               Z2001UNTAno = T001J3_A2001UNTAno[0];
               Z2006UNTSts = T001J3_A2006UNTSts[0];
            }
            else
            {
               Z2002UNTDsc = A2002UNTDsc;
               Z2003UNTMarca = A2003UNTMarca;
               Z2005UNTPlaca = A2005UNTPlaca;
               Z2004UNTMod = A2004UNTMod;
               Z2001UNTAno = A2001UNTAno;
               Z2006UNTSts = A2006UNTSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z9UNTCod = A9UNTCod;
            Z2002UNTDsc = A2002UNTDsc;
            Z2003UNTMarca = A2003UNTMarca;
            Z2005UNTPlaca = A2005UNTPlaca;
            Z2004UNTMod = A2004UNTMod;
            Z2001UNTAno = A2001UNTAno;
            Z2006UNTSts = A2006UNTSts;
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

      protected void Load1J53( )
      {
         /* Using cursor T001J4 */
         pr_default.execute(2, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound53 = 1;
            A2002UNTDsc = T001J4_A2002UNTDsc[0];
            AssignAttri("", false, "A2002UNTDsc", A2002UNTDsc);
            A2003UNTMarca = T001J4_A2003UNTMarca[0];
            AssignAttri("", false, "A2003UNTMarca", A2003UNTMarca);
            A2005UNTPlaca = T001J4_A2005UNTPlaca[0];
            AssignAttri("", false, "A2005UNTPlaca", A2005UNTPlaca);
            A2004UNTMod = T001J4_A2004UNTMod[0];
            AssignAttri("", false, "A2004UNTMod", A2004UNTMod);
            A2001UNTAno = T001J4_A2001UNTAno[0];
            AssignAttri("", false, "A2001UNTAno", A2001UNTAno);
            A2006UNTSts = T001J4_A2006UNTSts[0];
            AssignAttri("", false, "A2006UNTSts", StringUtil.Str( (decimal)(A2006UNTSts), 1, 0));
            ZM1J53( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1J53( ) ;
      }

      protected void OnLoadActions1J53( )
      {
      }

      protected void CheckExtendedTable1J53( )
      {
         nIsDirty_53 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1J53( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1J53( )
      {
         /* Using cursor T001J5 */
         pr_default.execute(3, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001J3 */
         pr_default.execute(1, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1J53( 1) ;
            RcdFound53 = 1;
            A9UNTCod = T001J3_A9UNTCod[0];
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            A2002UNTDsc = T001J3_A2002UNTDsc[0];
            AssignAttri("", false, "A2002UNTDsc", A2002UNTDsc);
            A2003UNTMarca = T001J3_A2003UNTMarca[0];
            AssignAttri("", false, "A2003UNTMarca", A2003UNTMarca);
            A2005UNTPlaca = T001J3_A2005UNTPlaca[0];
            AssignAttri("", false, "A2005UNTPlaca", A2005UNTPlaca);
            A2004UNTMod = T001J3_A2004UNTMod[0];
            AssignAttri("", false, "A2004UNTMod", A2004UNTMod);
            A2001UNTAno = T001J3_A2001UNTAno[0];
            AssignAttri("", false, "A2001UNTAno", A2001UNTAno);
            A2006UNTSts = T001J3_A2006UNTSts[0];
            AssignAttri("", false, "A2006UNTSts", StringUtil.Str( (decimal)(A2006UNTSts), 1, 0));
            Z9UNTCod = A9UNTCod;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1J53( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1J53( ) ;
            }
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1J53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode53;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1J53( ) ;
         if ( RcdFound53 == 0 )
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
         RcdFound53 = 0;
         /* Using cursor T001J6 */
         pr_default.execute(4, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001J6_A9UNTCod[0] < A9UNTCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001J6_A9UNTCod[0] > A9UNTCod ) ) )
            {
               A9UNTCod = T001J6_A9UNTCod[0];
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound53 = 0;
         /* Using cursor T001J7 */
         pr_default.execute(5, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001J7_A9UNTCod[0] > A9UNTCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001J7_A9UNTCod[0] < A9UNTCod ) ) )
            {
               A9UNTCod = T001J7_A9UNTCod[0];
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
               RcdFound53 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1J53( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUNTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1J53( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A9UNTCod != Z9UNTCod )
               {
                  A9UNTCod = Z9UNTCod;
                  AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "UNTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUNTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUNTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1J53( ) ;
                  GX_FocusControl = edtUNTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9UNTCod != Z9UNTCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUNTCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1J53( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "UNTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtUNTCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUNTCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1J53( ) ;
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
         if ( A9UNTCod != Z9UNTCod )
         {
            A9UNTCod = Z9UNTCod;
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "UNTCOD");
            AnyError = 1;
            GX_FocusControl = edtUNTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUNTCod_Internalname;
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
         GetKey1J53( ) ;
         if ( RcdFound53 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "UNTCOD");
               AnyError = 1;
               GX_FocusControl = edtUNTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A9UNTCod != Z9UNTCod )
            {
               A9UNTCod = Z9UNTCod;
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "UNTCOD");
               AnyError = 1;
               GX_FocusControl = edtUNTCod_Internalname;
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
            if ( A9UNTCod != Z9UNTCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "UNTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUNTCod_Internalname;
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
         context.RollbackDataStores("aunitrasportes",pr_default);
         GX_FocusControl = edtUNTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1J0( ) ;
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
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "UNTCOD");
            AnyError = 1;
            GX_FocusControl = edtUNTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUNTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1J53( ) ;
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUNTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1J53( ) ;
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
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUNTDsc_Internalname;
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
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUNTDsc_Internalname;
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
         ScanStart1J53( ) ;
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound53 != 0 )
            {
               ScanNext1J53( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUNTDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1J53( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1J53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001J2 */
            pr_default.execute(0, new Object[] {A9UNTCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AUNITRANSP"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2002UNTDsc, T001J2_A2002UNTDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2003UNTMarca, T001J2_A2003UNTMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z2005UNTPlaca, T001J2_A2005UNTPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z2004UNTMod, T001J2_A2004UNTMod[0]) != 0 ) || ( StringUtil.StrCmp(Z2001UNTAno, T001J2_A2001UNTAno[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2006UNTSts != T001J2_A2006UNTSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2002UNTDsc, T001J2_A2002UNTDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2002UNTDsc);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2002UNTDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2003UNTMarca, T001J2_A2003UNTMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTMarca");
                  GXUtil.WriteLogRaw("Old: ",Z2003UNTMarca);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2003UNTMarca[0]);
               }
               if ( StringUtil.StrCmp(Z2005UNTPlaca, T001J2_A2005UNTPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z2005UNTPlaca);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2005UNTPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z2004UNTMod, T001J2_A2004UNTMod[0]) != 0 )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTMod");
                  GXUtil.WriteLogRaw("Old: ",Z2004UNTMod);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2004UNTMod[0]);
               }
               if ( StringUtil.StrCmp(Z2001UNTAno, T001J2_A2001UNTAno[0]) != 0 )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTAno");
                  GXUtil.WriteLogRaw("Old: ",Z2001UNTAno);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2001UNTAno[0]);
               }
               if ( Z2006UNTSts != T001J2_A2006UNTSts[0] )
               {
                  GXUtil.WriteLog("aunitrasportes:[seudo value changed for attri]"+"UNTSts");
                  GXUtil.WriteLogRaw("Old: ",Z2006UNTSts);
                  GXUtil.WriteLogRaw("Current: ",T001J2_A2006UNTSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AUNITRANSP"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J53( )
      {
         BeforeValidate1J53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J53( 0) ;
            CheckOptimisticConcurrency1J53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J8 */
                     pr_default.execute(6, new Object[] {A9UNTCod, A2002UNTDsc, A2003UNTMarca, A2005UNTPlaca, A2004UNTMod, A2001UNTAno, A2006UNTSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AUNITRANSP");
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
                           ResetCaption1J0( ) ;
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
               Load1J53( ) ;
            }
            EndLevel1J53( ) ;
         }
         CloseExtendedTableCursors1J53( ) ;
      }

      protected void Update1J53( )
      {
         BeforeValidate1J53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1J53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001J9 */
                     pr_default.execute(7, new Object[] {A2002UNTDsc, A2003UNTMarca, A2005UNTPlaca, A2004UNTMod, A2001UNTAno, A2006UNTSts, A9UNTCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AUNITRANSP");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AUNITRANSP"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1J53( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1J0( ) ;
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
            EndLevel1J53( ) ;
         }
         CloseExtendedTableCursors1J53( ) ;
      }

      protected void DeferredUpdate1J53( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1J53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J53( ) ;
            AfterConfirm1J53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001J10 */
                  pr_default.execute(8, new Object[] {A9UNTCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AUNITRANSP");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound53 == 0 )
                        {
                           InitAll1J53( ) ;
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
                        ResetCaption1J0( ) ;
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1J53( ) ;
         Gx_mode = sMode53;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1J53( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001J11 */
            pr_default.execute(9, new Object[] {A9UNTCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1J53( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1J53( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("aunitrasportes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("aunitrasportes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1J53( )
      {
         /* Using cursor T001J12 */
         pr_default.execute(10);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound53 = 1;
            A9UNTCod = T001J12_A9UNTCod[0];
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1J53( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound53 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound53 = 1;
            A9UNTCod = T001J12_A9UNTCod[0];
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
         }
      }

      protected void ScanEnd1J53( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1J53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J53( )
      {
         edtUNTCod_Enabled = 0;
         AssignProp("", false, edtUNTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTCod_Enabled), 5, 0), true);
         edtUNTDsc_Enabled = 0;
         AssignProp("", false, edtUNTDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTDsc_Enabled), 5, 0), true);
         edtUNTMarca_Enabled = 0;
         AssignProp("", false, edtUNTMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTMarca_Enabled), 5, 0), true);
         edtUNTPlaca_Enabled = 0;
         AssignProp("", false, edtUNTPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTPlaca_Enabled), 5, 0), true);
         edtUNTMod_Enabled = 0;
         AssignProp("", false, edtUNTMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTMod_Enabled), 5, 0), true);
         edtUNTAno_Enabled = 0;
         AssignProp("", false, edtUNTAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTAno_Enabled), 5, 0), true);
         edtUNTSts_Enabled = 0;
         AssignProp("", false, edtUNTSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1J53( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810235490", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aunitrasportes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z9UNTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UNTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2002UNTDsc", StringUtil.RTrim( Z2002UNTDsc));
         GxWebStd.gx_hidden_field( context, "Z2003UNTMarca", StringUtil.RTrim( Z2003UNTMarca));
         GxWebStd.gx_hidden_field( context, "Z2005UNTPlaca", StringUtil.RTrim( Z2005UNTPlaca));
         GxWebStd.gx_hidden_field( context, "Z2004UNTMod", StringUtil.RTrim( Z2004UNTMod));
         GxWebStd.gx_hidden_field( context, "Z2001UNTAno", StringUtil.RTrim( Z2001UNTAno));
         GxWebStd.gx_hidden_field( context, "Z2006UNTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2006UNTSts), 1, 0, ".", "")));
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
         return formatLink("aunitrasportes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AUNITRASPORTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Unidades de Transportes" ;
      }

      protected void InitializeNonKey1J53( )
      {
         A2002UNTDsc = "";
         AssignAttri("", false, "A2002UNTDsc", A2002UNTDsc);
         A2003UNTMarca = "";
         AssignAttri("", false, "A2003UNTMarca", A2003UNTMarca);
         A2005UNTPlaca = "";
         AssignAttri("", false, "A2005UNTPlaca", A2005UNTPlaca);
         A2004UNTMod = "";
         AssignAttri("", false, "A2004UNTMod", A2004UNTMod);
         A2001UNTAno = "";
         AssignAttri("", false, "A2001UNTAno", A2001UNTAno);
         A2006UNTSts = 0;
         AssignAttri("", false, "A2006UNTSts", StringUtil.Str( (decimal)(A2006UNTSts), 1, 0));
         Z2002UNTDsc = "";
         Z2003UNTMarca = "";
         Z2005UNTPlaca = "";
         Z2004UNTMod = "";
         Z2001UNTAno = "";
         Z2006UNTSts = 0;
      }

      protected void InitAll1J53( )
      {
         A9UNTCod = 0;
         AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
         InitializeNonKey1J53( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810235497", true, true);
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
         context.AddJavascriptSource("aunitrasportes.js", "?202281810235497", false, true);
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
         edtUNTCod_Internalname = "UNTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtUNTDsc_Internalname = "UNTDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtUNTMarca_Internalname = "UNTMARCA";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtUNTPlaca_Internalname = "UNTPLACA";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtUNTMod_Internalname = "UNTMOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtUNTAno_Internalname = "UNTANO";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtUNTSts_Internalname = "UNTSTS";
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
         Form.Caption = "Unidades de Transportes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUNTSts_Jsonclick = "";
         edtUNTSts_Enabled = 1;
         edtUNTAno_Jsonclick = "";
         edtUNTAno_Enabled = 1;
         edtUNTMod_Jsonclick = "";
         edtUNTMod_Enabled = 1;
         edtUNTPlaca_Jsonclick = "";
         edtUNTPlaca_Enabled = 1;
         edtUNTMarca_Jsonclick = "";
         edtUNTMarca_Enabled = 1;
         edtUNTDsc_Jsonclick = "";
         edtUNTDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtUNTCod_Jsonclick = "";
         edtUNTCod_Enabled = 1;
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
         GX_FocusControl = edtUNTDsc_Internalname;
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

      public void Valid_Untcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2002UNTDsc", StringUtil.RTrim( A2002UNTDsc));
         AssignAttri("", false, "A2003UNTMarca", StringUtil.RTrim( A2003UNTMarca));
         AssignAttri("", false, "A2005UNTPlaca", StringUtil.RTrim( A2005UNTPlaca));
         AssignAttri("", false, "A2004UNTMod", StringUtil.RTrim( A2004UNTMod));
         AssignAttri("", false, "A2001UNTAno", StringUtil.RTrim( A2001UNTAno));
         AssignAttri("", false, "A2006UNTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2006UNTSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z9UNTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UNTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2002UNTDsc", StringUtil.RTrim( Z2002UNTDsc));
         GxWebStd.gx_hidden_field( context, "Z2003UNTMarca", StringUtil.RTrim( Z2003UNTMarca));
         GxWebStd.gx_hidden_field( context, "Z2005UNTPlaca", StringUtil.RTrim( Z2005UNTPlaca));
         GxWebStd.gx_hidden_field( context, "Z2004UNTMod", StringUtil.RTrim( Z2004UNTMod));
         GxWebStd.gx_hidden_field( context, "Z2001UNTAno", StringUtil.RTrim( Z2001UNTAno));
         GxWebStd.gx_hidden_field( context, "Z2006UNTSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2006UNTSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_UNTCOD","{handler:'Valid_Untcod',iparms:[{av:'A9UNTCod',fld:'UNTCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_UNTCOD",",oparms:[{av:'A2002UNTDsc',fld:'UNTDSC',pic:''},{av:'A2003UNTMarca',fld:'UNTMARCA',pic:''},{av:'A2005UNTPlaca',fld:'UNTPLACA',pic:''},{av:'A2004UNTMod',fld:'UNTMOD',pic:''},{av:'A2001UNTAno',fld:'UNTANO',pic:''},{av:'A2006UNTSts',fld:'UNTSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z9UNTCod'},{av:'Z2002UNTDsc'},{av:'Z2003UNTMarca'},{av:'Z2005UNTPlaca'},{av:'Z2004UNTMod'},{av:'Z2001UNTAno'},{av:'Z2006UNTSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z2002UNTDsc = "";
         Z2003UNTMarca = "";
         Z2005UNTPlaca = "";
         Z2004UNTMod = "";
         Z2001UNTAno = "";
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
         A2002UNTDsc = "";
         lblTextblock3_Jsonclick = "";
         A2003UNTMarca = "";
         lblTextblock4_Jsonclick = "";
         A2005UNTPlaca = "";
         lblTextblock5_Jsonclick = "";
         A2004UNTMod = "";
         lblTextblock6_Jsonclick = "";
         A2001UNTAno = "";
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
         T001J4_A9UNTCod = new int[1] ;
         T001J4_A2002UNTDsc = new string[] {""} ;
         T001J4_A2003UNTMarca = new string[] {""} ;
         T001J4_A2005UNTPlaca = new string[] {""} ;
         T001J4_A2004UNTMod = new string[] {""} ;
         T001J4_A2001UNTAno = new string[] {""} ;
         T001J4_A2006UNTSts = new short[1] ;
         T001J5_A9UNTCod = new int[1] ;
         T001J3_A9UNTCod = new int[1] ;
         T001J3_A2002UNTDsc = new string[] {""} ;
         T001J3_A2003UNTMarca = new string[] {""} ;
         T001J3_A2005UNTPlaca = new string[] {""} ;
         T001J3_A2004UNTMod = new string[] {""} ;
         T001J3_A2001UNTAno = new string[] {""} ;
         T001J3_A2006UNTSts = new short[1] ;
         sMode53 = "";
         T001J6_A9UNTCod = new int[1] ;
         T001J7_A9UNTCod = new int[1] ;
         T001J2_A9UNTCod = new int[1] ;
         T001J2_A2002UNTDsc = new string[] {""} ;
         T001J2_A2003UNTMarca = new string[] {""} ;
         T001J2_A2005UNTPlaca = new string[] {""} ;
         T001J2_A2004UNTMod = new string[] {""} ;
         T001J2_A2001UNTAno = new string[] {""} ;
         T001J2_A2006UNTSts = new short[1] ;
         T001J11_A8DesCod = new string[] {""} ;
         T001J12_A9UNTCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2002UNTDsc = "";
         ZZ2003UNTMarca = "";
         ZZ2005UNTPlaca = "";
         ZZ2004UNTMod = "";
         ZZ2001UNTAno = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aunitrasportes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aunitrasportes__default(),
            new Object[][] {
                new Object[] {
               T001J2_A9UNTCod, T001J2_A2002UNTDsc, T001J2_A2003UNTMarca, T001J2_A2005UNTPlaca, T001J2_A2004UNTMod, T001J2_A2001UNTAno, T001J2_A2006UNTSts
               }
               , new Object[] {
               T001J3_A9UNTCod, T001J3_A2002UNTDsc, T001J3_A2003UNTMarca, T001J3_A2005UNTPlaca, T001J3_A2004UNTMod, T001J3_A2001UNTAno, T001J3_A2006UNTSts
               }
               , new Object[] {
               T001J4_A9UNTCod, T001J4_A2002UNTDsc, T001J4_A2003UNTMarca, T001J4_A2005UNTPlaca, T001J4_A2004UNTMod, T001J4_A2001UNTAno, T001J4_A2006UNTSts
               }
               , new Object[] {
               T001J5_A9UNTCod
               }
               , new Object[] {
               T001J6_A9UNTCod
               }
               , new Object[] {
               T001J7_A9UNTCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001J11_A8DesCod
               }
               , new Object[] {
               T001J12_A9UNTCod
               }
            }
         );
      }

      private short Z2006UNTSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2006UNTSts ;
      private short GX_JID ;
      private short RcdFound53 ;
      private short nIsDirty_53 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2006UNTSts ;
      private int Z9UNTCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A9UNTCod ;
      private int edtUNTCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtUNTDsc_Enabled ;
      private int edtUNTMarca_Enabled ;
      private int edtUNTPlaca_Enabled ;
      private int edtUNTMod_Enabled ;
      private int edtUNTAno_Enabled ;
      private int edtUNTSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ9UNTCod ;
      private string sPrefix ;
      private string Z2002UNTDsc ;
      private string Z2003UNTMarca ;
      private string Z2005UNTPlaca ;
      private string Z2004UNTMod ;
      private string Z2001UNTAno ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUNTCod_Internalname ;
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
      private string edtUNTCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtUNTDsc_Internalname ;
      private string A2002UNTDsc ;
      private string edtUNTDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtUNTMarca_Internalname ;
      private string A2003UNTMarca ;
      private string edtUNTMarca_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtUNTPlaca_Internalname ;
      private string A2005UNTPlaca ;
      private string edtUNTPlaca_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtUNTMod_Internalname ;
      private string A2004UNTMod ;
      private string edtUNTMod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtUNTAno_Internalname ;
      private string A2001UNTAno ;
      private string edtUNTAno_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtUNTSts_Internalname ;
      private string edtUNTSts_Jsonclick ;
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
      private string sMode53 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2002UNTDsc ;
      private string ZZ2003UNTMarca ;
      private string ZZ2005UNTPlaca ;
      private string ZZ2004UNTMod ;
      private string ZZ2001UNTAno ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001J4_A9UNTCod ;
      private string[] T001J4_A2002UNTDsc ;
      private string[] T001J4_A2003UNTMarca ;
      private string[] T001J4_A2005UNTPlaca ;
      private string[] T001J4_A2004UNTMod ;
      private string[] T001J4_A2001UNTAno ;
      private short[] T001J4_A2006UNTSts ;
      private int[] T001J5_A9UNTCod ;
      private int[] T001J3_A9UNTCod ;
      private string[] T001J3_A2002UNTDsc ;
      private string[] T001J3_A2003UNTMarca ;
      private string[] T001J3_A2005UNTPlaca ;
      private string[] T001J3_A2004UNTMod ;
      private string[] T001J3_A2001UNTAno ;
      private short[] T001J3_A2006UNTSts ;
      private int[] T001J6_A9UNTCod ;
      private int[] T001J7_A9UNTCod ;
      private int[] T001J2_A9UNTCod ;
      private string[] T001J2_A2002UNTDsc ;
      private string[] T001J2_A2003UNTMarca ;
      private string[] T001J2_A2005UNTPlaca ;
      private string[] T001J2_A2004UNTMod ;
      private string[] T001J2_A2001UNTAno ;
      private short[] T001J2_A2006UNTSts ;
      private string[] T001J11_A8DesCod ;
      private int[] T001J12_A9UNTCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aunitrasportes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aunitrasportes__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001J4;
        prmT001J4 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J5;
        prmT001J5 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J3;
        prmT001J3 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J6;
        prmT001J6 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J7;
        prmT001J7 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J2;
        prmT001J2 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J8;
        prmT001J8 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0) ,
        new ParDef("@UNTDsc",GXType.NChar,100,0) ,
        new ParDef("@UNTMarca",GXType.NChar,50,0) ,
        new ParDef("@UNTPlaca",GXType.NChar,50,0) ,
        new ParDef("@UNTMod",GXType.NChar,50,0) ,
        new ParDef("@UNTAno",GXType.NChar,50,0) ,
        new ParDef("@UNTSts",GXType.Int16,1,0)
        };
        Object[] prmT001J9;
        prmT001J9 = new Object[] {
        new ParDef("@UNTDsc",GXType.NChar,100,0) ,
        new ParDef("@UNTMarca",GXType.NChar,50,0) ,
        new ParDef("@UNTPlaca",GXType.NChar,50,0) ,
        new ParDef("@UNTMod",GXType.NChar,50,0) ,
        new ParDef("@UNTAno",GXType.NChar,50,0) ,
        new ParDef("@UNTSts",GXType.Int16,1,0) ,
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J10;
        prmT001J10 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J11;
        prmT001J11 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001J12;
        prmT001J12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001J2", "SELECT [UNTCod], [UNTDsc], [UNTMarca], [UNTPlaca], [UNTMod], [UNTAno], [UNTSts] FROM [AUNITRANSP] WITH (UPDLOCK) WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J3", "SELECT [UNTCod], [UNTDsc], [UNTMarca], [UNTPlaca], [UNTMod], [UNTAno], [UNTSts] FROM [AUNITRANSP] WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J4", "SELECT TM1.[UNTCod], TM1.[UNTDsc], TM1.[UNTMarca], TM1.[UNTPlaca], TM1.[UNTMod], TM1.[UNTAno], TM1.[UNTSts] FROM [AUNITRANSP] TM1 WHERE TM1.[UNTCod] = @UNTCod ORDER BY TM1.[UNTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J5", "SELECT [UNTCod] FROM [AUNITRANSP] WHERE [UNTCod] = @UNTCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001J6", "SELECT TOP 1 [UNTCod] FROM [AUNITRANSP] WHERE ( [UNTCod] > @UNTCod) ORDER BY [UNTCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001J7", "SELECT TOP 1 [UNTCod] FROM [AUNITRANSP] WHERE ( [UNTCod] < @UNTCod) ORDER BY [UNTCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001J8", "INSERT INTO [AUNITRANSP]([UNTCod], [UNTDsc], [UNTMarca], [UNTPlaca], [UNTMod], [UNTAno], [UNTSts]) VALUES(@UNTCod, @UNTDsc, @UNTMarca, @UNTPlaca, @UNTMod, @UNTAno, @UNTSts)", GxErrorMask.GX_NOMASK,prmT001J8)
           ,new CursorDef("T001J9", "UPDATE [AUNITRANSP] SET [UNTDsc]=@UNTDsc, [UNTMarca]=@UNTMarca, [UNTPlaca]=@UNTPlaca, [UNTMod]=@UNTMod, [UNTAno]=@UNTAno, [UNTSts]=@UNTSts  WHERE [UNTCod] = @UNTCod", GxErrorMask.GX_NOMASK,prmT001J9)
           ,new CursorDef("T001J10", "DELETE FROM [AUNITRANSP]  WHERE [UNTCod] = @UNTCod", GxErrorMask.GX_NOMASK,prmT001J10)
           ,new CursorDef("T001J11", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001J12", "SELECT [UNTCod] FROM [AUNITRANSP] ORDER BY [UNTCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001J12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((short[]) buf[6])[0] = rslt.getShort(7);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
