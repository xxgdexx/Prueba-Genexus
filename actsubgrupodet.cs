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
   public class actsubgrupodet : GXDataArea
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
            A426ACTClaCod = GetPar( "ACTClaCod");
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = GetPar( "ACTGrupCod");
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = GetPar( "ACTSGrupCod");
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod) ;
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
            Form.Meta.addItem("description", "Detalle Sub Grupo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actsubgrupodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actsubgrupodet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTSUBGRUPODET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTGrupCod_Internalname, A2103ACTGrupCod, StringUtil.RTrim( context.localUtil.Format( A2103ACTGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSGrupCod_Internalname, A2114ACTSGrupCod, StringUtil.RTrim( context.localUtil.Format( A2114ACTSGrupCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSGrupCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSSGrupCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2115ACTSSGrupCod), 5, 0, ".", "")), StringUtil.LTrim( ((edtACTSSGrupCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2115ACTSSGrupCod), "ZZZZ9") : context.localUtil.Format( (decimal)(A2115ACTSSGrupCod), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSSGrupCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSSGrupCod_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Descripción", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSSGrupDsc_Internalname, A2230ACTSSGrupDsc, StringUtil.RTrim( context.localUtil.Format( A2230ACTSSGrupDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSSGrupDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSSGrupDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Porcentaje", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ACTSUBGRUPODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTSSGrupPor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", "")), StringUtil.LTrim( ((edtACTSSGrupPor_Enabled!=0) ? context.localUtil.Format( A2229ACTSSGrupPor, "ZZ9.99") : context.localUtil.Format( A2229ACTSSGrupPor, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTSSGrupPor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTSSGrupPor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTSUBGRUPODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTSUBGRUPODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ACTSUBGRUPODET.htm");
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
            Z426ACTClaCod = cgiGet( "Z426ACTClaCod");
            Z2103ACTGrupCod = cgiGet( "Z2103ACTGrupCod");
            Z2114ACTSGrupCod = cgiGet( "Z2114ACTSGrupCod");
            Z2115ACTSSGrupCod = (int)(context.localUtil.CToN( cgiGet( "Z2115ACTSSGrupCod"), ".", ","));
            Z2230ACTSSGrupDsc = cgiGet( "Z2230ACTSSGrupDsc");
            Z2229ACTSSGrupPor = context.localUtil.CToN( cgiGet( "Z2229ACTSSGrupPor"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = cgiGet( edtACTGrupCod_Internalname);
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = cgiGet( edtACTSGrupCod_Internalname);
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupCod_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTSSGRUPCOD");
               AnyError = 1;
               GX_FocusControl = edtACTSSGrupCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2115ACTSSGrupCod = 0;
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
            }
            else
            {
               A2115ACTSSGrupCod = (int)(context.localUtil.CToN( cgiGet( edtACTSSGrupCod_Internalname), ".", ","));
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
            }
            A2230ACTSSGrupDsc = cgiGet( edtACTSSGrupDsc_Internalname);
            AssignAttri("", false, "A2230ACTSSGrupDsc", A2230ACTSSGrupDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTSSGRUPPOR");
               AnyError = 1;
               GX_FocusControl = edtACTSSGrupPor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2229ACTSSGrupPor = 0;
               AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrimStr( A2229ACTSSGrupPor, 6, 2));
            }
            else
            {
               A2229ACTSSGrupPor = context.localUtil.CToN( cgiGet( edtACTSSGrupPor_Internalname), ".", ",");
               AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrimStr( A2229ACTSSGrupPor, 6, 2));
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
               A426ACTClaCod = GetPar( "ACTClaCod");
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = GetPar( "ACTGrupCod");
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = GetPar( "ACTSGrupCod");
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               A2115ACTSSGrupCod = (int)(NumberUtil.Val( GetPar( "ACTSSGrupCod"), "."));
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
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
               InitAll72196( ) ;
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
         DisableAttributes72196( ) ;
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

      protected void CONFIRM_720( )
      {
         BeforeValidate72196( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls72196( ) ;
            }
            else
            {
               CheckExtendedTable72196( ) ;
               if ( AnyError == 0 )
               {
                  ZM72196( 2) ;
               }
               CloseExtendedTableCursors72196( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues720( ) ;
         }
      }

      protected void ResetCaption720( )
      {
      }

      protected void ZM72196( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2230ACTSSGrupDsc = T00723_A2230ACTSSGrupDsc[0];
               Z2229ACTSSGrupPor = T00723_A2229ACTSSGrupPor[0];
            }
            else
            {
               Z2230ACTSSGrupDsc = A2230ACTSSGrupDsc;
               Z2229ACTSSGrupPor = A2229ACTSSGrupPor;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2115ACTSSGrupCod = A2115ACTSSGrupCod;
            Z2230ACTSSGrupDsc = A2230ACTSSGrupDsc;
            Z2229ACTSSGrupPor = A2229ACTSSGrupPor;
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
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

      protected void Load72196( )
      {
         /* Using cursor T00725 */
         pr_default.execute(3, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound196 = 1;
            A2230ACTSSGrupDsc = T00725_A2230ACTSSGrupDsc[0];
            AssignAttri("", false, "A2230ACTSSGrupDsc", A2230ACTSSGrupDsc);
            A2229ACTSSGrupPor = T00725_A2229ACTSSGrupPor[0];
            AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrimStr( A2229ACTSSGrupPor, 6, 2));
            ZM72196( -1) ;
         }
         pr_default.close(3);
         OnLoadActions72196( ) ;
      }

      protected void OnLoadActions72196( )
      {
      }

      protected void CheckExtendedTable72196( )
      {
         nIsDirty_196 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00724 */
         pr_default.execute(2, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors72196( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A426ACTClaCod ,
                               string A2103ACTGrupCod ,
                               string A2114ACTSGrupCod )
      {
         /* Using cursor T00726 */
         pr_default.execute(4, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey72196( )
      {
         /* Using cursor T00727 */
         pr_default.execute(5, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound196 = 1;
         }
         else
         {
            RcdFound196 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00723 */
         pr_default.execute(1, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM72196( 1) ;
            RcdFound196 = 1;
            A2115ACTSSGrupCod = T00723_A2115ACTSSGrupCod[0];
            AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
            A2230ACTSSGrupDsc = T00723_A2230ACTSSGrupDsc[0];
            AssignAttri("", false, "A2230ACTSSGrupDsc", A2230ACTSSGrupDsc);
            A2229ACTSSGrupPor = T00723_A2229ACTSSGrupPor[0];
            AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrimStr( A2229ACTSSGrupPor, 6, 2));
            A426ACTClaCod = T00723_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T00723_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T00723_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            Z426ACTClaCod = A426ACTClaCod;
            Z2103ACTGrupCod = A2103ACTGrupCod;
            Z2114ACTSGrupCod = A2114ACTSGrupCod;
            Z2115ACTSSGrupCod = A2115ACTSSGrupCod;
            sMode196 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load72196( ) ;
            if ( AnyError == 1 )
            {
               RcdFound196 = 0;
               InitializeNonKey72196( ) ;
            }
            Gx_mode = sMode196;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound196 = 0;
            InitializeNonKey72196( ) ;
            sMode196 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode196;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey72196( ) ;
         if ( RcdFound196 == 0 )
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
         RcdFound196 = 0;
         /* Using cursor T00728 */
         pr_default.execute(6, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) || ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2114ACTSGrupCod[0], A2114ACTSGrupCod) < 0 ) || ( StringUtil.StrCmp(T00728_A2114ACTSGrupCod[0], A2114ACTSGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( T00728_A2115ACTSSGrupCod[0] < A2115ACTSSGrupCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) || ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2114ACTSGrupCod[0], A2114ACTSGrupCod) > 0 ) || ( StringUtil.StrCmp(T00728_A2114ACTSGrupCod[0], A2114ACTSGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00728_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( T00728_A2115ACTSSGrupCod[0] > A2115ACTSSGrupCod ) ) )
            {
               A426ACTClaCod = T00728_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T00728_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = T00728_A2114ACTSGrupCod[0];
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               A2115ACTSSGrupCod = T00728_A2115ACTSSGrupCod[0];
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
               RcdFound196 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound196 = 0;
         /* Using cursor T00729 */
         pr_default.execute(7, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) > 0 ) || ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) > 0 ) || ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2114ACTSGrupCod[0], A2114ACTSGrupCod) > 0 ) || ( StringUtil.StrCmp(T00729_A2114ACTSGrupCod[0], A2114ACTSGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( T00729_A2115ACTSSGrupCod[0] > A2115ACTSSGrupCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) < 0 ) || ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) < 0 ) || ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2114ACTSGrupCod[0], A2114ACTSGrupCod) < 0 ) || ( StringUtil.StrCmp(T00729_A2114ACTSGrupCod[0], A2114ACTSGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A2103ACTGrupCod[0], A2103ACTGrupCod) == 0 ) && ( StringUtil.StrCmp(T00729_A426ACTClaCod[0], A426ACTClaCod) == 0 ) && ( T00729_A2115ACTSSGrupCod[0] < A2115ACTSSGrupCod ) ) )
            {
               A426ACTClaCod = T00729_A426ACTClaCod[0];
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = T00729_A2103ACTGrupCod[0];
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = T00729_A2114ACTSGrupCod[0];
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               A2115ACTSSGrupCod = T00729_A2115ACTSSGrupCod[0];
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
               RcdFound196 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey72196( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert72196( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound196 == 1 )
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) || ( A2115ACTSSGrupCod != Z2115ACTSSGrupCod ) )
               {
                  A426ACTClaCod = Z426ACTClaCod;
                  AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
                  A2103ACTGrupCod = Z2103ACTGrupCod;
                  AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
                  A2114ACTSGrupCod = Z2114ACTSGrupCod;
                  AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
                  A2115ACTSSGrupCod = Z2115ACTSSGrupCod;
                  AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTCLACOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update72196( ) ;
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) || ( A2115ACTSSGrupCod != Z2115ACTSSGrupCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTClaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert72196( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTCLACOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTClaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert72196( ) ;
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
         if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) || ( A2115ACTSSGrupCod != Z2115ACTSSGrupCod ) )
         {
            A426ACTClaCod = Z426ACTClaCod;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = Z2103ACTGrupCod;
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = Z2114ACTSGrupCod;
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2115ACTSSGrupCod = Z2115ACTSSGrupCod;
            AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTClaCod_Internalname;
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
         GetKey72196( ) ;
         if ( RcdFound196 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ACTCLACOD");
               AnyError = 1;
               GX_FocusControl = edtACTClaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) || ( A2115ACTSSGrupCod != Z2115ACTSSGrupCod ) )
            {
               A426ACTClaCod = Z426ACTClaCod;
               AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
               A2103ACTGrupCod = Z2103ACTGrupCod;
               AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
               A2114ACTSGrupCod = Z2114ACTSGrupCod;
               AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
               A2115ACTSSGrupCod = Z2115ACTSSGrupCod;
               AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ACTCLACOD");
               AnyError = 1;
               GX_FocusControl = edtACTClaCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A426ACTClaCod, Z426ACTClaCod) != 0 ) || ( StringUtil.StrCmp(A2103ACTGrupCod, Z2103ACTGrupCod) != 0 ) || ( StringUtil.StrCmp(A2114ACTSGrupCod, Z2114ACTSGrupCod) != 0 ) || ( A2115ACTSSGrupCod != Z2115ACTSSGrupCod ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTCLACOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTClaCod_Internalname;
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
         context.RollbackDataStores("actsubgrupodet",pr_default);
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_720( ) ;
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
         if ( RcdFound196 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTCLACOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart72196( ) ;
         if ( RcdFound196 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd72196( ) ;
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
         if ( RcdFound196 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
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
         if ( RcdFound196 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
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
         ScanStart72196( ) ;
         if ( RcdFound196 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound196 != 0 )
            {
               ScanNext72196( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd72196( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency72196( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00722 */
            pr_default.execute(0, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2230ACTSSGrupDsc, T00722_A2230ACTSSGrupDsc[0]) != 0 ) || ( Z2229ACTSSGrupPor != T00722_A2229ACTSSGrupPor[0] ) )
            {
               if ( StringUtil.StrCmp(Z2230ACTSSGrupDsc, T00722_A2230ACTSSGrupDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actsubgrupodet:[seudo value changed for attri]"+"ACTSSGrupDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2230ACTSSGrupDsc);
                  GXUtil.WriteLogRaw("Current: ",T00722_A2230ACTSSGrupDsc[0]);
               }
               if ( Z2229ACTSSGrupPor != T00722_A2229ACTSSGrupPor[0] )
               {
                  GXUtil.WriteLog("actsubgrupodet:[seudo value changed for attri]"+"ACTSSGrupPor");
                  GXUtil.WriteLogRaw("Old: ",Z2229ACTSSGrupPor);
                  GXUtil.WriteLogRaw("Current: ",T00722_A2229ACTSSGrupPor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTSUBGRUPODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert72196( )
      {
         BeforeValidate72196( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable72196( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM72196( 0) ;
            CheckOptimisticConcurrency72196( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm72196( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert72196( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007210 */
                     pr_default.execute(8, new Object[] {A2115ACTSSGrupCod, A2230ACTSSGrupDsc, A2229ACTSSGrupPor, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
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
                           ResetCaption720( ) ;
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
               Load72196( ) ;
            }
            EndLevel72196( ) ;
         }
         CloseExtendedTableCursors72196( ) ;
      }

      protected void Update72196( )
      {
         BeforeValidate72196( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable72196( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency72196( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm72196( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate72196( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007211 */
                     pr_default.execute(9, new Object[] {A2230ACTSSGrupDsc, A2229ACTSSGrupPor, A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTSUBGRUPODET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate72196( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption720( ) ;
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
            EndLevel72196( ) ;
         }
         CloseExtendedTableCursors72196( ) ;
      }

      protected void DeferredUpdate72196( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate72196( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency72196( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls72196( ) ;
            AfterConfirm72196( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete72196( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007212 */
                  pr_default.execute(10, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod, A2115ACTSSGrupCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTSUBGRUPODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound196 == 0 )
                        {
                           InitAll72196( ) ;
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
                        ResetCaption720( ) ;
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
         sMode196 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel72196( ) ;
         Gx_mode = sMode196;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls72196( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel72196( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete72196( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actsubgrupodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues720( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actsubgrupodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart72196( )
      {
         /* Using cursor T007213 */
         pr_default.execute(11);
         RcdFound196 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound196 = 1;
            A426ACTClaCod = T007213_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T007213_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T007213_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2115ACTSSGrupCod = T007213_A2115ACTSSGrupCod[0];
            AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext72196( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound196 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound196 = 1;
            A426ACTClaCod = T007213_A426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A2103ACTGrupCod = T007213_A2103ACTGrupCod[0];
            AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
            A2114ACTSGrupCod = T007213_A2114ACTSGrupCod[0];
            AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
            A2115ACTSSGrupCod = T007213_A2115ACTSSGrupCod[0];
            AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
         }
      }

      protected void ScanEnd72196( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm72196( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert72196( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate72196( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete72196( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete72196( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate72196( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes72196( )
      {
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtACTGrupCod_Enabled = 0;
         AssignProp("", false, edtACTGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTGrupCod_Enabled), 5, 0), true);
         edtACTSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSGrupCod_Enabled), 5, 0), true);
         edtACTSSGrupCod_Enabled = 0;
         AssignProp("", false, edtACTSSGrupCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupCod_Enabled), 5, 0), true);
         edtACTSSGrupDsc_Enabled = 0;
         AssignProp("", false, edtACTSSGrupDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupDsc_Enabled), 5, 0), true);
         edtACTSSGrupPor_Enabled = 0;
         AssignProp("", false, edtACTSSGrupPor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTSSGrupPor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes72196( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues720( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265380", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actsubgrupodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2115ACTSSGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2115ACTSSGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2230ACTSSGrupDsc", Z2230ACTSSGrupDsc);
         GxWebStd.gx_hidden_field( context, "Z2229ACTSSGrupPor", StringUtil.LTrim( StringUtil.NToC( Z2229ACTSSGrupPor, 6, 2, ".", "")));
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
         return formatLink("actsubgrupodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACTSUBGRUPODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle Sub Grupo" ;
      }

      protected void InitializeNonKey72196( )
      {
         A2230ACTSSGrupDsc = "";
         AssignAttri("", false, "A2230ACTSSGrupDsc", A2230ACTSSGrupDsc);
         A2229ACTSSGrupPor = 0;
         AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrimStr( A2229ACTSSGrupPor, 6, 2));
         Z2230ACTSSGrupDsc = "";
         Z2229ACTSSGrupPor = 0;
      }

      protected void InitAll72196( )
      {
         A426ACTClaCod = "";
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         A2103ACTGrupCod = "";
         AssignAttri("", false, "A2103ACTGrupCod", A2103ACTGrupCod);
         A2114ACTSGrupCod = "";
         AssignAttri("", false, "A2114ACTSGrupCod", A2114ACTSGrupCod);
         A2115ACTSSGrupCod = 0;
         AssignAttri("", false, "A2115ACTSSGrupCod", StringUtil.LTrimStr( (decimal)(A2115ACTSSGrupCod), 5, 0));
         InitializeNonKey72196( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265386", true, true);
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
         context.AddJavascriptSource("actsubgrupodet.js", "?202281810265386", false, true);
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
         edtACTClaCod_Internalname = "ACTCLACOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtACTGrupCod_Internalname = "ACTGRUPCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtACTSGrupCod_Internalname = "ACTSGRUPCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtACTSSGrupCod_Internalname = "ACTSSGRUPCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtACTSSGrupDsc_Internalname = "ACTSSGRUPDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtACTSSGrupPor_Internalname = "ACTSSGRUPPOR";
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
         Form.Caption = "Detalle Sub Grupo";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACTSSGrupPor_Jsonclick = "";
         edtACTSSGrupPor_Enabled = 1;
         edtACTSSGrupDsc_Jsonclick = "";
         edtACTSSGrupDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtACTSSGrupCod_Jsonclick = "";
         edtACTSSGrupCod_Enabled = 1;
         edtACTSGrupCod_Jsonclick = "";
         edtACTSGrupCod_Enabled = 1;
         edtACTGrupCod_Jsonclick = "";
         edtACTGrupCod_Enabled = 1;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 1;
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
         /* Using cursor T007214 */
         pr_default.execute(12, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtACTSSGrupDsc_Internalname;
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

      public void Valid_Actsgrupcod( )
      {
         /* Using cursor T007214 */
         pr_default.execute(12, new Object[] {A426ACTClaCod, A2103ACTGrupCod, A2114ACTSGrupCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Grupo'.", "ForeignKeyNotFound", 1, "ACTSGRUPCOD");
            AnyError = 1;
            GX_FocusControl = edtACTClaCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Actssgrupcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2230ACTSSGrupDsc", A2230ACTSSGrupDsc);
         AssignAttri("", false, "A2229ACTSSGrupPor", StringUtil.LTrim( StringUtil.NToC( A2229ACTSSGrupPor, 6, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z2103ACTGrupCod", Z2103ACTGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2114ACTSGrupCod", Z2114ACTSGrupCod);
         GxWebStd.gx_hidden_field( context, "Z2115ACTSSGrupCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2115ACTSSGrupCod), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2230ACTSSGrupDsc", Z2230ACTSSGrupDsc);
         GxWebStd.gx_hidden_field( context, "Z2229ACTSSGrupPor", StringUtil.LTrim( StringUtil.NToC( Z2229ACTSSGrupPor, 6, 2, ".", "")));
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
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[]}");
         setEventMetadata("VALID_ACTGRUPCOD","{handler:'Valid_Actgrupcod',iparms:[]");
         setEventMetadata("VALID_ACTGRUPCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTSGRUPCOD","{handler:'Valid_Actsgrupcod',iparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''}]");
         setEventMetadata("VALID_ACTSGRUPCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTSSGRUPCOD","{handler:'Valid_Actssgrupcod',iparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A2103ACTGrupCod',fld:'ACTGRUPCOD',pic:''},{av:'A2114ACTSGrupCod',fld:'ACTSGRUPCOD',pic:''},{av:'A2115ACTSSGrupCod',fld:'ACTSSGRUPCOD',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTSSGRUPCOD",",oparms:[{av:'A2230ACTSSGrupDsc',fld:'ACTSSGRUPDSC',pic:''},{av:'A2229ACTSSGrupPor',fld:'ACTSSGRUPPOR',pic:'ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z426ACTClaCod'},{av:'Z2103ACTGrupCod'},{av:'Z2114ACTSGrupCod'},{av:'Z2115ACTSSGrupCod'},{av:'Z2230ACTSSGrupDsc'},{av:'Z2229ACTSSGrupPor'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z426ACTClaCod = "";
         Z2103ACTGrupCod = "";
         Z2114ACTSGrupCod = "";
         Z2230ACTSSGrupDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2114ACTSGrupCod = "";
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
         lblTextblock4_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A2230ACTSSGrupDsc = "";
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
         T00725_A2115ACTSSGrupCod = new int[1] ;
         T00725_A2230ACTSSGrupDsc = new string[] {""} ;
         T00725_A2229ACTSSGrupPor = new decimal[1] ;
         T00725_A426ACTClaCod = new string[] {""} ;
         T00725_A2103ACTGrupCod = new string[] {""} ;
         T00725_A2114ACTSGrupCod = new string[] {""} ;
         T00724_A426ACTClaCod = new string[] {""} ;
         T00726_A426ACTClaCod = new string[] {""} ;
         T00727_A426ACTClaCod = new string[] {""} ;
         T00727_A2103ACTGrupCod = new string[] {""} ;
         T00727_A2114ACTSGrupCod = new string[] {""} ;
         T00727_A2115ACTSSGrupCod = new int[1] ;
         T00723_A2115ACTSSGrupCod = new int[1] ;
         T00723_A2230ACTSSGrupDsc = new string[] {""} ;
         T00723_A2229ACTSSGrupPor = new decimal[1] ;
         T00723_A426ACTClaCod = new string[] {""} ;
         T00723_A2103ACTGrupCod = new string[] {""} ;
         T00723_A2114ACTSGrupCod = new string[] {""} ;
         sMode196 = "";
         T00728_A426ACTClaCod = new string[] {""} ;
         T00728_A2103ACTGrupCod = new string[] {""} ;
         T00728_A2114ACTSGrupCod = new string[] {""} ;
         T00728_A2115ACTSSGrupCod = new int[1] ;
         T00729_A426ACTClaCod = new string[] {""} ;
         T00729_A2103ACTGrupCod = new string[] {""} ;
         T00729_A2114ACTSGrupCod = new string[] {""} ;
         T00729_A2115ACTSSGrupCod = new int[1] ;
         T00722_A2115ACTSSGrupCod = new int[1] ;
         T00722_A2230ACTSSGrupDsc = new string[] {""} ;
         T00722_A2229ACTSSGrupPor = new decimal[1] ;
         T00722_A426ACTClaCod = new string[] {""} ;
         T00722_A2103ACTGrupCod = new string[] {""} ;
         T00722_A2114ACTSGrupCod = new string[] {""} ;
         T007213_A426ACTClaCod = new string[] {""} ;
         T007213_A2103ACTGrupCod = new string[] {""} ;
         T007213_A2114ACTSGrupCod = new string[] {""} ;
         T007213_A2115ACTSSGrupCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007214_A426ACTClaCod = new string[] {""} ;
         ZZ426ACTClaCod = "";
         ZZ2103ACTGrupCod = "";
         ZZ2114ACTSGrupCod = "";
         ZZ2230ACTSSGrupDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actsubgrupodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actsubgrupodet__default(),
            new Object[][] {
                new Object[] {
               T00722_A2115ACTSSGrupCod, T00722_A2230ACTSSGrupDsc, T00722_A2229ACTSSGrupPor, T00722_A426ACTClaCod, T00722_A2103ACTGrupCod, T00722_A2114ACTSGrupCod
               }
               , new Object[] {
               T00723_A2115ACTSSGrupCod, T00723_A2230ACTSSGrupDsc, T00723_A2229ACTSSGrupPor, T00723_A426ACTClaCod, T00723_A2103ACTGrupCod, T00723_A2114ACTSGrupCod
               }
               , new Object[] {
               T00724_A426ACTClaCod
               }
               , new Object[] {
               T00725_A2115ACTSSGrupCod, T00725_A2230ACTSSGrupDsc, T00725_A2229ACTSSGrupPor, T00725_A426ACTClaCod, T00725_A2103ACTGrupCod, T00725_A2114ACTSGrupCod
               }
               , new Object[] {
               T00726_A426ACTClaCod
               }
               , new Object[] {
               T00727_A426ACTClaCod, T00727_A2103ACTGrupCod, T00727_A2114ACTSGrupCod, T00727_A2115ACTSSGrupCod
               }
               , new Object[] {
               T00728_A426ACTClaCod, T00728_A2103ACTGrupCod, T00728_A2114ACTSGrupCod, T00728_A2115ACTSSGrupCod
               }
               , new Object[] {
               T00729_A426ACTClaCod, T00729_A2103ACTGrupCod, T00729_A2114ACTSGrupCod, T00729_A2115ACTSSGrupCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007213_A426ACTClaCod, T007213_A2103ACTGrupCod, T007213_A2114ACTSGrupCod, T007213_A2115ACTSSGrupCod
               }
               , new Object[] {
               T007214_A426ACTClaCod
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
      private short RcdFound196 ;
      private short nIsDirty_196 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z2115ACTSSGrupCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTClaCod_Enabled ;
      private int edtACTGrupCod_Enabled ;
      private int edtACTSGrupCod_Enabled ;
      private int A2115ACTSSGrupCod ;
      private int edtACTSSGrupCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtACTSSGrupDsc_Enabled ;
      private int edtACTSSGrupPor_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ2115ACTSSGrupCod ;
      private decimal Z2229ACTSSGrupPor ;
      private decimal A2229ACTSSGrupPor ;
      private decimal ZZ2229ACTSSGrupPor ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTClaCod_Internalname ;
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
      private string edtACTClaCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtACTGrupCod_Internalname ;
      private string edtACTGrupCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtACTSGrupCod_Internalname ;
      private string edtACTSGrupCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtACTSSGrupCod_Internalname ;
      private string edtACTSSGrupCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtACTSSGrupDsc_Internalname ;
      private string edtACTSSGrupDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtACTSSGrupPor_Internalname ;
      private string edtACTSSGrupPor_Jsonclick ;
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
      private string sMode196 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z426ACTClaCod ;
      private string Z2103ACTGrupCod ;
      private string Z2114ACTSGrupCod ;
      private string Z2230ACTSSGrupDsc ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2114ACTSGrupCod ;
      private string A2230ACTSSGrupDsc ;
      private string ZZ426ACTClaCod ;
      private string ZZ2103ACTGrupCod ;
      private string ZZ2114ACTSGrupCod ;
      private string ZZ2230ACTSSGrupDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00725_A2115ACTSSGrupCod ;
      private string[] T00725_A2230ACTSSGrupDsc ;
      private decimal[] T00725_A2229ACTSSGrupPor ;
      private string[] T00725_A426ACTClaCod ;
      private string[] T00725_A2103ACTGrupCod ;
      private string[] T00725_A2114ACTSGrupCod ;
      private string[] T00724_A426ACTClaCod ;
      private string[] T00726_A426ACTClaCod ;
      private string[] T00727_A426ACTClaCod ;
      private string[] T00727_A2103ACTGrupCod ;
      private string[] T00727_A2114ACTSGrupCod ;
      private int[] T00727_A2115ACTSSGrupCod ;
      private int[] T00723_A2115ACTSSGrupCod ;
      private string[] T00723_A2230ACTSSGrupDsc ;
      private decimal[] T00723_A2229ACTSSGrupPor ;
      private string[] T00723_A426ACTClaCod ;
      private string[] T00723_A2103ACTGrupCod ;
      private string[] T00723_A2114ACTSGrupCod ;
      private string[] T00728_A426ACTClaCod ;
      private string[] T00728_A2103ACTGrupCod ;
      private string[] T00728_A2114ACTSGrupCod ;
      private int[] T00728_A2115ACTSSGrupCod ;
      private string[] T00729_A426ACTClaCod ;
      private string[] T00729_A2103ACTGrupCod ;
      private string[] T00729_A2114ACTSGrupCod ;
      private int[] T00729_A2115ACTSSGrupCod ;
      private int[] T00722_A2115ACTSSGrupCod ;
      private string[] T00722_A2230ACTSSGrupDsc ;
      private decimal[] T00722_A2229ACTSSGrupPor ;
      private string[] T00722_A426ACTClaCod ;
      private string[] T00722_A2103ACTGrupCod ;
      private string[] T00722_A2114ACTSGrupCod ;
      private string[] T007213_A426ACTClaCod ;
      private string[] T007213_A2103ACTGrupCod ;
      private string[] T007213_A2114ACTSGrupCod ;
      private int[] T007213_A2115ACTSSGrupCod ;
      private string[] T007214_A426ACTClaCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class actsubgrupodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actsubgrupodet__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00725;
        prmT00725 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00724;
        prmT00724 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00726;
        prmT00726 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00727;
        prmT00727 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00723;
        prmT00723 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00728;
        prmT00728 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00729;
        prmT00729 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT00722;
        prmT00722 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007210;
        prmT007210 = new Object[] {
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0) ,
        new ParDef("@ACTSSGrupDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTSSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007211;
        prmT007211 = new Object[] {
        new ParDef("@ACTSSGrupDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTSSGrupPor",GXType.Decimal,6,2) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007212;
        prmT007212 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSSGrupCod",GXType.Int32,5,0)
        };
        Object[] prmT007213;
        prmT007213 = new Object[] {
        };
        Object[] prmT007214;
        prmT007214 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTGrupCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTSGrupCod",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00722", "SELECT [ACTSSGrupCod], [ACTSSGrupDsc], [ACTSSGrupPor], [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPODET] WITH (UPDLOCK) WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00722,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00723", "SELECT [ACTSSGrupCod], [ACTSSGrupDsc], [ACTSSGrupPor], [ACTClaCod], [ACTGrupCod], [ACTSGrupCod] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00723,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00724", "SELECT [ACTClaCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00724,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00725", "SELECT TM1.[ACTSSGrupCod], TM1.[ACTSSGrupDsc], TM1.[ACTSSGrupPor], TM1.[ACTClaCod], TM1.[ACTGrupCod], TM1.[ACTSGrupCod] FROM [ACTSUBGRUPODET] TM1 WHERE TM1.[ACTClaCod] = @ACTClaCod and TM1.[ACTGrupCod] = @ACTGrupCod and TM1.[ACTSGrupCod] = @ACTSGrupCod and TM1.[ACTSSGrupCod] = @ACTSSGrupCod ORDER BY TM1.[ACTClaCod], TM1.[ACTGrupCod], TM1.[ACTSGrupCod], TM1.[ACTSSGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00725,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00726", "SELECT [ACTClaCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00726,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00727", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00727,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00728", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] WHERE ( [ACTClaCod] > @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] > @ACTGrupCod or [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSGrupCod] > @ACTSGrupCod or [ACTSGrupCod] = @ACTSGrupCod and [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSSGrupCod] > @ACTSSGrupCod) ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00728,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00729", "SELECT TOP 1 [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] WHERE ( [ACTClaCod] < @ACTClaCod or [ACTClaCod] = @ACTClaCod and [ACTGrupCod] < @ACTGrupCod or [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSGrupCod] < @ACTSGrupCod or [ACTSGrupCod] = @ACTSGrupCod and [ACTGrupCod] = @ACTGrupCod and [ACTClaCod] = @ACTClaCod and [ACTSSGrupCod] < @ACTSSGrupCod) ORDER BY [ACTClaCod] DESC, [ACTGrupCod] DESC, [ACTSGrupCod] DESC, [ACTSSGrupCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00729,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007210", "INSERT INTO [ACTSUBGRUPODET]([ACTSSGrupCod], [ACTSSGrupDsc], [ACTSSGrupPor], [ACTClaCod], [ACTGrupCod], [ACTSGrupCod]) VALUES(@ACTSSGrupCod, @ACTSSGrupDsc, @ACTSSGrupPor, @ACTClaCod, @ACTGrupCod, @ACTSGrupCod)", GxErrorMask.GX_NOMASK,prmT007210)
           ,new CursorDef("T007211", "UPDATE [ACTSUBGRUPODET] SET [ACTSSGrupDsc]=@ACTSSGrupDsc, [ACTSSGrupPor]=@ACTSSGrupPor  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod", GxErrorMask.GX_NOMASK,prmT007211)
           ,new CursorDef("T007212", "DELETE FROM [ACTSUBGRUPODET]  WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod AND [ACTSSGrupCod] = @ACTSSGrupCod", GxErrorMask.GX_NOMASK,prmT007212)
           ,new CursorDef("T007213", "SELECT [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod] FROM [ACTSUBGRUPODET] ORDER BY [ACTClaCod], [ACTGrupCod], [ACTSGrupCod], [ACTSSGrupCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007213,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007214", "SELECT [ACTClaCod] FROM [ACTSUBGRUPO] WHERE [ACTClaCod] = @ACTClaCod AND [ACTGrupCod] = @ACTGrupCod AND [ACTSGrupCod] = @ACTSGrupCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007214,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
