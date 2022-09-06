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
   public class poordenmaq : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A322ProCod = GetPar( "ProCod");
            AssignAttri("", false, "A322ProCod", A322ProCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A322ProCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A320MAQCod = GetPar( "MAQCod");
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A320MAQCod) ;
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
            Form.Meta.addItem("description", "Orden de Producción Maquinas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poordenmaq( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poordenmaq( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POORDENMAQ.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCod_Internalname, StringUtil.RTrim( A322ProCod), StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo de Maquina", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMAQCod_Internalname, StringUtil.RTrim( A320MAQCod), StringUtil.RTrim( context.localUtil.Format( A320MAQCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMAQCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMAQCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Horas Maquina", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProMaqHora_Internalname, StringUtil.LTrim( StringUtil.NToC( A1729ProMaqHora, 17, 2, ".", "")), StringUtil.LTrim( ((edtProMaqHora_Enabled!=0) ? context.localUtil.Format( A1729ProMaqHora, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1729ProMaqHora, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProMaqHora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProMaqHora_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Costo Hora", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProMaqCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1727ProMaqCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtProMaqCosto_Enabled!=0) ? context.localUtil.Format( A1727ProMaqCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1727ProMaqCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProMaqCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProMaqCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Costo Total", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENMAQ.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProMaqCostoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1728ProMaqCostoTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtProMaqCostoTotal_Enabled!=0) ? context.localUtil.Format( A1728ProMaqCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1728ProMaqCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProMaqCostoTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProMaqCostoTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POORDENMAQ.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENMAQ.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POORDENMAQ.htm");
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
            Z322ProCod = cgiGet( "Z322ProCod");
            Z320MAQCod = cgiGet( "Z320MAQCod");
            Z1729ProMaqHora = context.localUtil.CToN( cgiGet( "Z1729ProMaqHora"), ".", ",");
            Z1727ProMaqCosto = context.localUtil.CToN( cgiGet( "Z1727ProMaqCosto"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A322ProCod = cgiGet( edtProCod_Internalname);
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A320MAQCod = cgiGet( edtMAQCod_Internalname);
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProMaqHora_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProMaqHora_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMAQHORA");
               AnyError = 1;
               GX_FocusControl = edtProMaqHora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1729ProMaqHora = 0;
               AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrimStr( A1729ProMaqHora, 15, 2));
            }
            else
            {
               A1729ProMaqHora = context.localUtil.CToN( cgiGet( edtProMaqHora_Internalname), ".", ",");
               AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrimStr( A1729ProMaqHora, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProMaqCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProMaqCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMAQCOSTO");
               AnyError = 1;
               GX_FocusControl = edtProMaqCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1727ProMaqCosto = 0;
               AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrimStr( A1727ProMaqCosto, 15, 2));
            }
            else
            {
               A1727ProMaqCosto = context.localUtil.CToN( cgiGet( edtProMaqCosto_Internalname), ".", ",");
               AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrimStr( A1727ProMaqCosto, 15, 2));
            }
            A1728ProMaqCostoTotal = context.localUtil.CToN( cgiGet( edtProMaqCostoTotal_Internalname), ".", ",");
            AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrimStr( A1728ProMaqCostoTotal, 15, 2));
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
               A322ProCod = GetPar( "ProCod");
               AssignAttri("", false, "A322ProCod", A322ProCod);
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
               InitAll4B150( ) ;
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
         DisableAttributes4B150( ) ;
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

      protected void CONFIRM_4B0( )
      {
         BeforeValidate4B150( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4B150( ) ;
            }
            else
            {
               CheckExtendedTable4B150( ) ;
               if ( AnyError == 0 )
               {
                  ZM4B150( 3) ;
                  ZM4B150( 4) ;
               }
               CloseExtendedTableCursors4B150( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4B0( ) ;
         }
      }

      protected void ResetCaption4B0( )
      {
      }

      protected void ZM4B150( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1729ProMaqHora = T004B3_A1729ProMaqHora[0];
               Z1727ProMaqCosto = T004B3_A1727ProMaqCosto[0];
            }
            else
            {
               Z1729ProMaqHora = A1729ProMaqHora;
               Z1727ProMaqCosto = A1727ProMaqCosto;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1729ProMaqHora = A1729ProMaqHora;
            Z1727ProMaqCosto = A1727ProMaqCosto;
            Z322ProCod = A322ProCod;
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

      protected void Load4B150( )
      {
         /* Using cursor T004B6 */
         pr_default.execute(4, new Object[] {A322ProCod, A320MAQCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound150 = 1;
            A1729ProMaqHora = T004B6_A1729ProMaqHora[0];
            AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrimStr( A1729ProMaqHora, 15, 2));
            A1727ProMaqCosto = T004B6_A1727ProMaqCosto[0];
            AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrimStr( A1727ProMaqCosto, 15, 2));
            ZM4B150( -2) ;
         }
         pr_default.close(4);
         OnLoadActions4B150( ) ;
      }

      protected void OnLoadActions4B150( )
      {
         A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
         AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrimStr( A1728ProMaqCostoTotal, 15, 2));
      }

      protected void CheckExtendedTable4B150( )
      {
         nIsDirty_150 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004B4 */
         pr_default.execute(2, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004B5 */
         pr_default.execute(3, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         nIsDirty_150 = 1;
         A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
         AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrimStr( A1728ProMaqCostoTotal, 15, 2));
      }

      protected void CloseExtendedTableCursors4B150( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A322ProCod )
      {
         /* Using cursor T004B7 */
         pr_default.execute(5, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
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

      protected void gxLoad_4( string A320MAQCod )
      {
         /* Using cursor T004B8 */
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

      protected void GetKey4B150( )
      {
         /* Using cursor T004B9 */
         pr_default.execute(7, new Object[] {A322ProCod, A320MAQCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound150 = 1;
         }
         else
         {
            RcdFound150 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004B3 */
         pr_default.execute(1, new Object[] {A322ProCod, A320MAQCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4B150( 2) ;
            RcdFound150 = 1;
            A1729ProMaqHora = T004B3_A1729ProMaqHora[0];
            AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrimStr( A1729ProMaqHora, 15, 2));
            A1727ProMaqCosto = T004B3_A1727ProMaqCosto[0];
            AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrimStr( A1727ProMaqCosto, 15, 2));
            A322ProCod = T004B3_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A320MAQCod = T004B3_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            Z322ProCod = A322ProCod;
            Z320MAQCod = A320MAQCod;
            sMode150 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4B150( ) ;
            if ( AnyError == 1 )
            {
               RcdFound150 = 0;
               InitializeNonKey4B150( ) ;
            }
            Gx_mode = sMode150;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound150 = 0;
            InitializeNonKey4B150( ) ;
            sMode150 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode150;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4B150( ) ;
         if ( RcdFound150 == 0 )
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
         RcdFound150 = 0;
         /* Using cursor T004B10 */
         pr_default.execute(8, new Object[] {A322ProCod, A320MAQCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004B10_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004B10_A322ProCod[0], A322ProCod) == 0 ) && ( StringUtil.StrCmp(T004B10_A320MAQCod[0], A320MAQCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004B10_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004B10_A322ProCod[0], A322ProCod) == 0 ) && ( StringUtil.StrCmp(T004B10_A320MAQCod[0], A320MAQCod) > 0 ) ) )
            {
               A322ProCod = T004B10_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A320MAQCod = T004B10_A320MAQCod[0];
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               RcdFound150 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound150 = 0;
         /* Using cursor T004B11 */
         pr_default.execute(9, new Object[] {A322ProCod, A320MAQCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004B11_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004B11_A322ProCod[0], A322ProCod) == 0 ) && ( StringUtil.StrCmp(T004B11_A320MAQCod[0], A320MAQCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004B11_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004B11_A322ProCod[0], A322ProCod) == 0 ) && ( StringUtil.StrCmp(T004B11_A320MAQCod[0], A320MAQCod) < 0 ) ) )
            {
               A322ProCod = T004B11_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A320MAQCod = T004B11_A320MAQCod[0];
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               RcdFound150 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4B150( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4B150( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound150 == 1 )
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
               {
                  A322ProCod = Z322ProCod;
                  AssignAttri("", false, "A322ProCod", A322ProCod);
                  A320MAQCod = Z320MAQCod;
                  AssignAttri("", false, "A320MAQCod", A320MAQCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4B150( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4B150( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4B150( ) ;
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
         if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
         {
            A322ProCod = Z322ProCod;
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A320MAQCod = Z320MAQCod;
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCod_Internalname;
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
         GetKey4B150( ) ;
         if ( RcdFound150 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROCOD");
               AnyError = 1;
               GX_FocusControl = edtProCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
            {
               A322ProCod = Z322ProCod;
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A320MAQCod = Z320MAQCod;
               AssignAttri("", false, "A320MAQCod", A320MAQCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PROCOD");
               AnyError = 1;
               GX_FocusControl = edtProCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( StringUtil.StrCmp(A320MAQCod, Z320MAQCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
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
         context.RollbackDataStores("poordenmaq",pr_default);
         GX_FocusControl = edtProMaqHora_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4B0( ) ;
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
         if ( RcdFound150 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProMaqHora_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4B150( ) ;
         if ( RcdFound150 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProMaqHora_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4B150( ) ;
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
         if ( RcdFound150 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProMaqHora_Internalname;
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
         if ( RcdFound150 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProMaqHora_Internalname;
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
         ScanStart4B150( ) ;
         if ( RcdFound150 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound150 != 0 )
            {
               ScanNext4B150( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProMaqHora_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4B150( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4B150( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004B2 */
            pr_default.execute(0, new Object[] {A322ProCod, A320MAQCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENMAQ"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1729ProMaqHora != T004B2_A1729ProMaqHora[0] ) || ( Z1727ProMaqCosto != T004B2_A1727ProMaqCosto[0] ) )
            {
               if ( Z1729ProMaqHora != T004B2_A1729ProMaqHora[0] )
               {
                  GXUtil.WriteLog("poordenmaq:[seudo value changed for attri]"+"ProMaqHora");
                  GXUtil.WriteLogRaw("Old: ",Z1729ProMaqHora);
                  GXUtil.WriteLogRaw("Current: ",T004B2_A1729ProMaqHora[0]);
               }
               if ( Z1727ProMaqCosto != T004B2_A1727ProMaqCosto[0] )
               {
                  GXUtil.WriteLog("poordenmaq:[seudo value changed for attri]"+"ProMaqCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1727ProMaqCosto);
                  GXUtil.WriteLogRaw("Current: ",T004B2_A1727ProMaqCosto[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POORDENMAQ"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4B150( )
      {
         BeforeValidate4B150( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4B150( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4B150( 0) ;
            CheckOptimisticConcurrency4B150( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4B150( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4B150( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004B12 */
                     pr_default.execute(10, new Object[] {A1729ProMaqHora, A1727ProMaqCosto, A322ProCod, A320MAQCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENMAQ");
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
                           ResetCaption4B0( ) ;
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
               Load4B150( ) ;
            }
            EndLevel4B150( ) ;
         }
         CloseExtendedTableCursors4B150( ) ;
      }

      protected void Update4B150( )
      {
         BeforeValidate4B150( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4B150( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4B150( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4B150( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4B150( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004B13 */
                     pr_default.execute(11, new Object[] {A1729ProMaqHora, A1727ProMaqCosto, A322ProCod, A320MAQCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENMAQ");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENMAQ"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4B150( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4B0( ) ;
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
            EndLevel4B150( ) ;
         }
         CloseExtendedTableCursors4B150( ) ;
      }

      protected void DeferredUpdate4B150( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4B150( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4B150( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4B150( ) ;
            AfterConfirm4B150( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4B150( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004B14 */
                  pr_default.execute(12, new Object[] {A322ProCod, A320MAQCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("POORDENMAQ");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound150 == 0 )
                        {
                           InitAll4B150( ) ;
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
                        ResetCaption4B0( ) ;
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
         sMode150 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4B150( ) ;
         Gx_mode = sMode150;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4B150( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
            AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrimStr( A1728ProMaqCostoTotal, 15, 2));
         }
      }

      protected void EndLevel4B150( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4B150( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("poordenmaq",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("poordenmaq",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4B150( )
      {
         /* Using cursor T004B15 */
         pr_default.execute(13);
         RcdFound150 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound150 = 1;
            A322ProCod = T004B15_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A320MAQCod = T004B15_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4B150( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound150 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound150 = 1;
            A322ProCod = T004B15_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A320MAQCod = T004B15_A320MAQCod[0];
            AssignAttri("", false, "A320MAQCod", A320MAQCod);
         }
      }

      protected void ScanEnd4B150( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm4B150( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4B150( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4B150( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4B150( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4B150( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4B150( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4B150( )
      {
         edtProCod_Enabled = 0;
         AssignProp("", false, edtProCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCod_Enabled), 5, 0), true);
         edtMAQCod_Enabled = 0;
         AssignProp("", false, edtMAQCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMAQCod_Enabled), 5, 0), true);
         edtProMaqHora_Enabled = 0;
         AssignProp("", false, edtProMaqHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProMaqHora_Enabled), 5, 0), true);
         edtProMaqCosto_Enabled = 0;
         AssignProp("", false, edtProMaqCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProMaqCosto_Enabled), 5, 0), true);
         edtProMaqCostoTotal_Enabled = 0;
         AssignProp("", false, edtProMaqCostoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProMaqCostoTotal_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4B150( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025344", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poordenmaq.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z320MAQCod", StringUtil.RTrim( Z320MAQCod));
         GxWebStd.gx_hidden_field( context, "Z1729ProMaqHora", StringUtil.LTrim( StringUtil.NToC( Z1729ProMaqHora, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1727ProMaqCosto", StringUtil.LTrim( StringUtil.NToC( Z1727ProMaqCosto, 15, 2, ".", "")));
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
         return formatLink("poordenmaq.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POORDENMAQ" ;
      }

      public override string GetPgmdesc( )
      {
         return "Orden de Producción Maquinas" ;
      }

      protected void InitializeNonKey4B150( )
      {
         A1728ProMaqCostoTotal = 0;
         AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrimStr( A1728ProMaqCostoTotal, 15, 2));
         A1729ProMaqHora = 0;
         AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrimStr( A1729ProMaqHora, 15, 2));
         A1727ProMaqCosto = 0;
         AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrimStr( A1727ProMaqCosto, 15, 2));
         Z1729ProMaqHora = 0;
         Z1727ProMaqCosto = 0;
      }

      protected void InitAll4B150( )
      {
         A322ProCod = "";
         AssignAttri("", false, "A322ProCod", A322ProCod);
         A320MAQCod = "";
         AssignAttri("", false, "A320MAQCod", A320MAQCod);
         InitializeNonKey4B150( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025349", true, true);
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
         context.AddJavascriptSource("poordenmaq.js", "?20228181025349", false, true);
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
         edtProCod_Internalname = "PROCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMAQCod_Internalname = "MAQCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProMaqHora_Internalname = "PROMAQHORA";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProMaqCosto_Internalname = "PROMAQCOSTO";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProMaqCostoTotal_Internalname = "PROMAQCOSTOTOTAL";
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
         Form.Caption = "Orden de Producción Maquinas";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProMaqCostoTotal_Jsonclick = "";
         edtProMaqCostoTotal_Enabled = 0;
         edtProMaqCosto_Jsonclick = "";
         edtProMaqCosto_Enabled = 1;
         edtProMaqHora_Jsonclick = "";
         edtProMaqHora_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMAQCod_Jsonclick = "";
         edtMAQCod_Enabled = 1;
         edtProCod_Jsonclick = "";
         edtProCod_Enabled = 1;
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
         /* Using cursor T004B16 */
         pr_default.execute(14, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T004B17 */
         pr_default.execute(15, new Object[] {A320MAQCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Maquinas'.", "ForeignKeyNotFound", 1, "MAQCOD");
            AnyError = 1;
            GX_FocusControl = edtMAQCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtProMaqHora_Internalname;
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

      public void Valid_Procod( )
      {
         /* Using cursor T004B16 */
         pr_default.execute(14, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
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
         /* Using cursor T004B17 */
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
         AssignAttri("", false, "A1729ProMaqHora", StringUtil.LTrim( StringUtil.NToC( A1729ProMaqHora, 15, 2, ".", "")));
         AssignAttri("", false, "A1727ProMaqCosto", StringUtil.LTrim( StringUtil.NToC( A1727ProMaqCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A1728ProMaqCostoTotal", StringUtil.LTrim( StringUtil.NToC( A1728ProMaqCostoTotal, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z320MAQCod", StringUtil.RTrim( Z320MAQCod));
         GxWebStd.gx_hidden_field( context, "Z1729ProMaqHora", StringUtil.LTrim( StringUtil.NToC( Z1729ProMaqHora, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1727ProMaqCosto", StringUtil.LTrim( StringUtil.NToC( Z1727ProMaqCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1728ProMaqCostoTotal", StringUtil.LTrim( StringUtil.NToC( Z1728ProMaqCostoTotal, 15, 2, ".", "")));
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
         setEventMetadata("VALID_PROCOD","{handler:'Valid_Procod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''}]");
         setEventMetadata("VALID_PROCOD",",oparms:[]}");
         setEventMetadata("VALID_MAQCOD","{handler:'Valid_Maqcod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''},{av:'A320MAQCod',fld:'MAQCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MAQCOD",",oparms:[{av:'A1729ProMaqHora',fld:'PROMAQHORA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1727ProMaqCosto',fld:'PROMAQCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1728ProMaqCostoTotal',fld:'PROMAQCOSTOTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z322ProCod'},{av:'Z320MAQCod'},{av:'Z1729ProMaqHora'},{av:'Z1727ProMaqCosto'},{av:'Z1728ProMaqCostoTotal'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROMAQHORA","{handler:'Valid_Promaqhora',iparms:[]");
         setEventMetadata("VALID_PROMAQHORA",",oparms:[]}");
         setEventMetadata("VALID_PROMAQCOSTO","{handler:'Valid_Promaqcosto',iparms:[]");
         setEventMetadata("VALID_PROMAQCOSTO",",oparms:[]}");
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
         Z322ProCod = "";
         Z320MAQCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A322ProCod = "";
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
         lblTextblock4_Jsonclick = "";
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
         T004B6_A1729ProMaqHora = new decimal[1] ;
         T004B6_A1727ProMaqCosto = new decimal[1] ;
         T004B6_A322ProCod = new string[] {""} ;
         T004B6_A320MAQCod = new string[] {""} ;
         T004B4_A322ProCod = new string[] {""} ;
         T004B5_A320MAQCod = new string[] {""} ;
         T004B7_A322ProCod = new string[] {""} ;
         T004B8_A320MAQCod = new string[] {""} ;
         T004B9_A322ProCod = new string[] {""} ;
         T004B9_A320MAQCod = new string[] {""} ;
         T004B3_A1729ProMaqHora = new decimal[1] ;
         T004B3_A1727ProMaqCosto = new decimal[1] ;
         T004B3_A322ProCod = new string[] {""} ;
         T004B3_A320MAQCod = new string[] {""} ;
         sMode150 = "";
         T004B10_A322ProCod = new string[] {""} ;
         T004B10_A320MAQCod = new string[] {""} ;
         T004B11_A322ProCod = new string[] {""} ;
         T004B11_A320MAQCod = new string[] {""} ;
         T004B2_A1729ProMaqHora = new decimal[1] ;
         T004B2_A1727ProMaqCosto = new decimal[1] ;
         T004B2_A322ProCod = new string[] {""} ;
         T004B2_A320MAQCod = new string[] {""} ;
         T004B15_A322ProCod = new string[] {""} ;
         T004B15_A320MAQCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004B16_A322ProCod = new string[] {""} ;
         T004B17_A320MAQCod = new string[] {""} ;
         ZZ322ProCod = "";
         ZZ320MAQCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poordenmaq__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poordenmaq__default(),
            new Object[][] {
                new Object[] {
               T004B2_A1729ProMaqHora, T004B2_A1727ProMaqCosto, T004B2_A322ProCod, T004B2_A320MAQCod
               }
               , new Object[] {
               T004B3_A1729ProMaqHora, T004B3_A1727ProMaqCosto, T004B3_A322ProCod, T004B3_A320MAQCod
               }
               , new Object[] {
               T004B4_A322ProCod
               }
               , new Object[] {
               T004B5_A320MAQCod
               }
               , new Object[] {
               T004B6_A1729ProMaqHora, T004B6_A1727ProMaqCosto, T004B6_A322ProCod, T004B6_A320MAQCod
               }
               , new Object[] {
               T004B7_A322ProCod
               }
               , new Object[] {
               T004B8_A320MAQCod
               }
               , new Object[] {
               T004B9_A322ProCod, T004B9_A320MAQCod
               }
               , new Object[] {
               T004B10_A322ProCod, T004B10_A320MAQCod
               }
               , new Object[] {
               T004B11_A322ProCod, T004B11_A320MAQCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004B15_A322ProCod, T004B15_A320MAQCod
               }
               , new Object[] {
               T004B16_A322ProCod
               }
               , new Object[] {
               T004B17_A320MAQCod
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
      private short RcdFound150 ;
      private short nIsDirty_150 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCod_Enabled ;
      private int edtMAQCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProMaqHora_Enabled ;
      private int edtProMaqCosto_Enabled ;
      private int edtProMaqCostoTotal_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z1729ProMaqHora ;
      private decimal Z1727ProMaqCosto ;
      private decimal A1729ProMaqHora ;
      private decimal A1727ProMaqCosto ;
      private decimal A1728ProMaqCostoTotal ;
      private decimal Z1728ProMaqCostoTotal ;
      private decimal ZZ1729ProMaqHora ;
      private decimal ZZ1727ProMaqCosto ;
      private decimal ZZ1728ProMaqCostoTotal ;
      private string sPrefix ;
      private string Z322ProCod ;
      private string Z320MAQCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A322ProCod ;
      private string A320MAQCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCod_Internalname ;
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
      private string edtProCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMAQCod_Internalname ;
      private string edtMAQCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProMaqHora_Internalname ;
      private string edtProMaqHora_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProMaqCosto_Internalname ;
      private string edtProMaqCosto_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProMaqCostoTotal_Internalname ;
      private string edtProMaqCostoTotal_Jsonclick ;
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
      private string sMode150 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ322ProCod ;
      private string ZZ320MAQCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T004B6_A1729ProMaqHora ;
      private decimal[] T004B6_A1727ProMaqCosto ;
      private string[] T004B6_A322ProCod ;
      private string[] T004B6_A320MAQCod ;
      private string[] T004B4_A322ProCod ;
      private string[] T004B5_A320MAQCod ;
      private string[] T004B7_A322ProCod ;
      private string[] T004B8_A320MAQCod ;
      private string[] T004B9_A322ProCod ;
      private string[] T004B9_A320MAQCod ;
      private decimal[] T004B3_A1729ProMaqHora ;
      private decimal[] T004B3_A1727ProMaqCosto ;
      private string[] T004B3_A322ProCod ;
      private string[] T004B3_A320MAQCod ;
      private string[] T004B10_A322ProCod ;
      private string[] T004B10_A320MAQCod ;
      private string[] T004B11_A322ProCod ;
      private string[] T004B11_A320MAQCod ;
      private decimal[] T004B2_A1729ProMaqHora ;
      private decimal[] T004B2_A1727ProMaqCosto ;
      private string[] T004B2_A322ProCod ;
      private string[] T004B2_A320MAQCod ;
      private string[] T004B15_A322ProCod ;
      private string[] T004B15_A320MAQCod ;
      private string[] T004B16_A322ProCod ;
      private string[] T004B17_A320MAQCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poordenmaq__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poordenmaq__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT004B6;
        prmT004B6 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B4;
        prmT004B4 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004B5;
        prmT004B5 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B7;
        prmT004B7 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004B8;
        prmT004B8 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B9;
        prmT004B9 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B3;
        prmT004B3 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B10;
        prmT004B10 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B11;
        prmT004B11 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B2;
        prmT004B2 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B12;
        prmT004B12 = new Object[] {
        new ParDef("@ProMaqHora",GXType.Decimal,15,2) ,
        new ParDef("@ProMaqCosto",GXType.Decimal,15,2) ,
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B13;
        prmT004B13 = new Object[] {
        new ParDef("@ProMaqHora",GXType.Decimal,15,2) ,
        new ParDef("@ProMaqCosto",GXType.Decimal,15,2) ,
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B14;
        prmT004B14 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        Object[] prmT004B15;
        prmT004B15 = new Object[] {
        };
        Object[] prmT004B16;
        prmT004B16 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004B17;
        prmT004B17 = new Object[] {
        new ParDef("@MAQCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004B2", "SELECT [ProMaqHora], [ProMaqCosto], [ProCod], [MAQCod] FROM [POORDENMAQ] WITH (UPDLOCK) WHERE [ProCod] = @ProCod AND [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B3", "SELECT [ProMaqHora], [ProMaqCosto], [ProCod], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @ProCod AND [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B4", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B5", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B6", "SELECT TM1.[ProMaqHora], TM1.[ProMaqCosto], TM1.[ProCod], TM1.[MAQCod] FROM [POORDENMAQ] TM1 WHERE TM1.[ProCod] = @ProCod and TM1.[MAQCod] = @MAQCod ORDER BY TM1.[ProCod], TM1.[MAQCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B7", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B8", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B9", "SELECT [ProCod], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @ProCod AND [MAQCod] = @MAQCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B10", "SELECT TOP 1 [ProCod], [MAQCod] FROM [POORDENMAQ] WHERE ( [ProCod] > @ProCod or [ProCod] = @ProCod and [MAQCod] > @MAQCod) ORDER BY [ProCod], [MAQCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004B11", "SELECT TOP 1 [ProCod], [MAQCod] FROM [POORDENMAQ] WHERE ( [ProCod] < @ProCod or [ProCod] = @ProCod and [MAQCod] < @MAQCod) ORDER BY [ProCod] DESC, [MAQCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004B12", "INSERT INTO [POORDENMAQ]([ProMaqHora], [ProMaqCosto], [ProCod], [MAQCod]) VALUES(@ProMaqHora, @ProMaqCosto, @ProCod, @MAQCod)", GxErrorMask.GX_NOMASK,prmT004B12)
           ,new CursorDef("T004B13", "UPDATE [POORDENMAQ] SET [ProMaqHora]=@ProMaqHora, [ProMaqCosto]=@ProMaqCosto  WHERE [ProCod] = @ProCod AND [MAQCod] = @MAQCod", GxErrorMask.GX_NOMASK,prmT004B13)
           ,new CursorDef("T004B14", "DELETE FROM [POORDENMAQ]  WHERE [ProCod] = @ProCod AND [MAQCod] = @MAQCod", GxErrorMask.GX_NOMASK,prmT004B14)
           ,new CursorDef("T004B15", "SELECT [ProCod], [MAQCod] FROM [POORDENMAQ] ORDER BY [ProCod], [MAQCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004B15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B16", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004B17", "SELECT [MAQCod] FROM [POMAQUINA] WHERE [MAQCod] = @MAQCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004B17,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
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
