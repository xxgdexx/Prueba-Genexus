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
   public class calmacen : GXHttpHandler
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
            Form.Meta.addItem("description", "Almacenes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public calmacen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public calmacen( IGxContext context )
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
         cmbAlmSts = new GXCombobox();
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
         if ( cmbAlmSts.ItemCount > 0 )
         {
            A438AlmSts = (short)(NumberUtil.Val( cmbAlmSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0))), "."));
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            AssignProp("", false, cmbAlmSts_Internalname, "Values", cmbAlmSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm1K54( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CALMACEN.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63AlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Nombre Almacen", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmDsc_Internalname, StringUtil.RTrim( A436AlmDsc), StringUtil.RTrim( context.localUtil.Format( A436AlmDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura Almacen", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmAbr_Internalname, StringUtil.RTrim( A433AlmAbr), StringUtil.RTrim( context.localUtil.Format( A433AlmAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmAbr_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Valoriza", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A434AlmCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtAlmCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A434AlmCos), "9") : context.localUtil.Format( (decimal)(A434AlmCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situacion Almacen", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAlmSts, cmbAlmSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0)), 1, cmbAlmSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbAlmSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CALMACEN.htm");
         cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         AssignProp("", false, cmbAlmSts_Internalname, "Values", (string)(cmbAlmSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Dirección Almacen", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CALMACEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmDir_Internalname, A435AlmDir, StringUtil.RTrim( context.localUtil.Format( A435AlmDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CALMACEN.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CALMACEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CALMACEN.htm");
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
            Z63AlmCod = (int)(context.localUtil.CToN( cgiGet( "Z63AlmCod"), ".", ","));
            Z436AlmDsc = cgiGet( "Z436AlmDsc");
            Z433AlmAbr = cgiGet( "Z433AlmAbr");
            Z434AlmCos = (short)(context.localUtil.CToN( cgiGet( "Z434AlmCos"), ".", ","));
            Z437AlmPed = (short)(context.localUtil.CToN( cgiGet( "Z437AlmPed"), ".", ","));
            Z438AlmSts = (short)(context.localUtil.CToN( cgiGet( "Z438AlmSts"), ".", ","));
            Z435AlmDir = cgiGet( "Z435AlmDir");
            Z439AlmSunat = cgiGet( "Z439AlmSunat");
            A437AlmPed = (short)(context.localUtil.CToN( cgiGet( "Z437AlmPed"), ".", ","));
            A439AlmSunat = cgiGet( "Z439AlmSunat");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A437AlmPed = (short)(context.localUtil.CToN( cgiGet( "ALMPED"), ".", ","));
            A439AlmSunat = cgiGet( "ALMSUNAT");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A63AlmCod = 0;
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            }
            else
            {
               A63AlmCod = (int)(context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            }
            A436AlmDsc = cgiGet( edtAlmDsc_Internalname);
            AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
            A433AlmAbr = cgiGet( edtAlmAbr_Internalname);
            AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMCOS");
               AnyError = 1;
               GX_FocusControl = edtAlmCos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A434AlmCos = 0;
               AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            }
            else
            {
               A434AlmCos = (short)(context.localUtil.CToN( cgiGet( edtAlmCos_Internalname), ".", ","));
               AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            }
            cmbAlmSts.CurrentValue = cgiGet( cmbAlmSts_Internalname);
            A438AlmSts = (short)(NumberUtil.Val( cgiGet( cmbAlmSts_Internalname), "."));
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            A435AlmDir = cgiGet( edtAlmDir_Internalname);
            AssignAttri("", false, "A435AlmDir", A435AlmDir);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CALMACEN");
            forbiddenHiddens.Add("AlmPed", context.localUtil.Format( (decimal)(A437AlmPed), "9"));
            forbiddenHiddens.Add("AlmSunat", StringUtil.RTrim( context.localUtil.Format( A439AlmSunat, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A63AlmCod != Z63AlmCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("calmacen:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
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
               InitAll1K54( ) ;
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
         DisableAttributes1K54( ) ;
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

      protected void CONFIRM_1K0( )
      {
         BeforeValidate1K54( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1K54( ) ;
            }
            else
            {
               CheckExtendedTable1K54( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1K54( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1K0( ) ;
         }
      }

      protected void ResetCaption1K0( )
      {
      }

      protected void ZM1K54( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z436AlmDsc = T001K3_A436AlmDsc[0];
               Z433AlmAbr = T001K3_A433AlmAbr[0];
               Z434AlmCos = T001K3_A434AlmCos[0];
               Z437AlmPed = T001K3_A437AlmPed[0];
               Z438AlmSts = T001K3_A438AlmSts[0];
               Z435AlmDir = T001K3_A435AlmDir[0];
               Z439AlmSunat = T001K3_A439AlmSunat[0];
            }
            else
            {
               Z436AlmDsc = A436AlmDsc;
               Z433AlmAbr = A433AlmAbr;
               Z434AlmCos = A434AlmCos;
               Z437AlmPed = A437AlmPed;
               Z438AlmSts = A438AlmSts;
               Z435AlmDir = A435AlmDir;
               Z439AlmSunat = A439AlmSunat;
            }
         }
         if ( GX_JID == -1 )
         {
            Z63AlmCod = A63AlmCod;
            Z436AlmDsc = A436AlmDsc;
            Z433AlmAbr = A433AlmAbr;
            Z434AlmCos = A434AlmCos;
            Z437AlmPed = A437AlmPed;
            Z438AlmSts = A438AlmSts;
            Z435AlmDir = A435AlmDir;
            Z439AlmSunat = A439AlmSunat;
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

      protected void Load1K54( )
      {
         /* Using cursor T001K4 */
         pr_default.execute(2, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound54 = 1;
            A436AlmDsc = T001K4_A436AlmDsc[0];
            AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
            A433AlmAbr = T001K4_A433AlmAbr[0];
            AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
            A434AlmCos = T001K4_A434AlmCos[0];
            AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            A437AlmPed = T001K4_A437AlmPed[0];
            A438AlmSts = T001K4_A438AlmSts[0];
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            A435AlmDir = T001K4_A435AlmDir[0];
            AssignAttri("", false, "A435AlmDir", A435AlmDir);
            A439AlmSunat = T001K4_A439AlmSunat[0];
            ZM1K54( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1K54( ) ;
      }

      protected void OnLoadActions1K54( )
      {
      }

      protected void CheckExtendedTable1K54( )
      {
         nIsDirty_54 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1K54( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1K54( )
      {
         /* Using cursor T001K5 */
         pr_default.execute(3, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001K3 */
         pr_default.execute(1, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1K54( 1) ;
            RcdFound54 = 1;
            A63AlmCod = T001K3_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A436AlmDsc = T001K3_A436AlmDsc[0];
            AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
            A433AlmAbr = T001K3_A433AlmAbr[0];
            AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
            A434AlmCos = T001K3_A434AlmCos[0];
            AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
            A437AlmPed = T001K3_A437AlmPed[0];
            A438AlmSts = T001K3_A438AlmSts[0];
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
            A435AlmDir = T001K3_A435AlmDir[0];
            AssignAttri("", false, "A435AlmDir", A435AlmDir);
            A439AlmSunat = T001K3_A439AlmSunat[0];
            Z63AlmCod = A63AlmCod;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1K54( ) ;
            if ( AnyError == 1 )
            {
               RcdFound54 = 0;
               InitializeNonKey1K54( ) ;
            }
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey1K54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode54;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1K54( ) ;
         if ( RcdFound54 == 0 )
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
         RcdFound54 = 0;
         /* Using cursor T001K6 */
         pr_default.execute(4, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001K6_A63AlmCod[0] < A63AlmCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001K6_A63AlmCod[0] > A63AlmCod ) ) )
            {
               A63AlmCod = T001K6_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound54 = 0;
         /* Using cursor T001K7 */
         pr_default.execute(5, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001K7_A63AlmCod[0] > A63AlmCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001K7_A63AlmCod[0] < A63AlmCod ) ) )
            {
               A63AlmCod = T001K7_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               RcdFound54 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1K54( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1K54( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound54 == 1 )
            {
               if ( A63AlmCod != Z63AlmCod )
               {
                  A63AlmCod = Z63AlmCod;
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1K54( ) ;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A63AlmCod != Z63AlmCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1K54( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ALMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1K54( ) ;
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
         if ( A63AlmCod != Z63AlmCod )
         {
            A63AlmCod = Z63AlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAlmCod_Internalname;
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
         GetKey1K54( ) ;
         if ( RcdFound54 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A63AlmCod != Z63AlmCod )
            {
               A63AlmCod = Z63AlmCod;
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
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
            if ( A63AlmCod != Z63AlmCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
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
         context.RollbackDataStores("calmacen",pr_default);
         GX_FocusControl = edtAlmDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1K0( ) ;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAlmDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1K54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAlmDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1K54( ) ;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAlmDsc_Internalname;
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
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAlmDsc_Internalname;
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
         ScanStart1K54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound54 != 0 )
            {
               ScanNext1K54( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAlmDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1K54( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1K54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001K2 */
            pr_default.execute(0, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z436AlmDsc, T001K2_A436AlmDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z433AlmAbr, T001K2_A433AlmAbr[0]) != 0 ) || ( Z434AlmCos != T001K2_A434AlmCos[0] ) || ( Z437AlmPed != T001K2_A437AlmPed[0] ) || ( Z438AlmSts != T001K2_A438AlmSts[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z435AlmDir, T001K2_A435AlmDir[0]) != 0 ) || ( StringUtil.StrCmp(Z439AlmSunat, T001K2_A439AlmSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z436AlmDsc, T001K2_A436AlmDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmDsc");
                  GXUtil.WriteLogRaw("Old: ",Z436AlmDsc);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A436AlmDsc[0]);
               }
               if ( StringUtil.StrCmp(Z433AlmAbr, T001K2_A433AlmAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmAbr");
                  GXUtil.WriteLogRaw("Old: ",Z433AlmAbr);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A433AlmAbr[0]);
               }
               if ( Z434AlmCos != T001K2_A434AlmCos[0] )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmCos");
                  GXUtil.WriteLogRaw("Old: ",Z434AlmCos);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A434AlmCos[0]);
               }
               if ( Z437AlmPed != T001K2_A437AlmPed[0] )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmPed");
                  GXUtil.WriteLogRaw("Old: ",Z437AlmPed);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A437AlmPed[0]);
               }
               if ( Z438AlmSts != T001K2_A438AlmSts[0] )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmSts");
                  GXUtil.WriteLogRaw("Old: ",Z438AlmSts);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A438AlmSts[0]);
               }
               if ( StringUtil.StrCmp(Z435AlmDir, T001K2_A435AlmDir[0]) != 0 )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmDir");
                  GXUtil.WriteLogRaw("Old: ",Z435AlmDir);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A435AlmDir[0]);
               }
               if ( StringUtil.StrCmp(Z439AlmSunat, T001K2_A439AlmSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("calmacen:[seudo value changed for attri]"+"AlmSunat");
                  GXUtil.WriteLogRaw("Old: ",Z439AlmSunat);
                  GXUtil.WriteLogRaw("Current: ",T001K2_A439AlmSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1K54( )
      {
         BeforeValidate1K54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1K54( 0) ;
            CheckOptimisticConcurrency1K54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1K54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K8 */
                     pr_default.execute(6, new Object[] {A63AlmCod, A436AlmDsc, A433AlmAbr, A434AlmCos, A437AlmPed, A438AlmSts, A435AlmDir, A439AlmSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
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
                           ResetCaption1K0( ) ;
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
               Load1K54( ) ;
            }
            EndLevel1K54( ) ;
         }
         CloseExtendedTableCursors1K54( ) ;
      }

      protected void Update1K54( )
      {
         BeforeValidate1K54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1K54( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1K54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1K54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001K9 */
                     pr_default.execute(7, new Object[] {A436AlmDsc, A433AlmAbr, A434AlmCos, A437AlmPed, A438AlmSts, A435AlmDir, A439AlmSunat, A63AlmCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1K54( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1K0( ) ;
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
            EndLevel1K54( ) ;
         }
         CloseExtendedTableCursors1K54( ) ;
      }

      protected void DeferredUpdate1K54( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1K54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1K54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1K54( ) ;
            AfterConfirm1K54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1K54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001K10 */
                  pr_default.execute(8, new Object[] {A63AlmCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CALMACEN");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound54 == 0 )
                        {
                           InitAll1K54( ) ;
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
                        ResetCaption1K0( ) ;
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1K54( ) ;
         Gx_mode = sMode54;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1K54( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001K11 */
            pr_default.execute(9, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T001K12 */
            pr_default.execute(10, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T001K13 */
            pr_default.execute(11, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T001K14 */
            pr_default.execute(12, new Object[] {A63AlmCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel1K54( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1K54( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("calmacen",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("calmacen",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1K54( )
      {
         /* Using cursor T001K15 */
         pr_default.execute(13);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound54 = 1;
            A63AlmCod = T001K15_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1K54( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound54 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound54 = 1;
            A63AlmCod = T001K15_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         }
      }

      protected void ScanEnd1K54( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1K54( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1K54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1K54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1K54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1K54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1K54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1K54( )
      {
         edtAlmCod_Enabled = 0;
         AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         edtAlmDsc_Enabled = 0;
         AssignProp("", false, edtAlmDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmDsc_Enabled), 5, 0), true);
         edtAlmAbr_Enabled = 0;
         AssignProp("", false, edtAlmAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmAbr_Enabled), 5, 0), true);
         edtAlmCos_Enabled = 0;
         AssignProp("", false, edtAlmCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCos_Enabled), 5, 0), true);
         cmbAlmSts.Enabled = 0;
         AssignProp("", false, cmbAlmSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAlmSts.Enabled), 5, 0), true);
         edtAlmDir_Enabled = 0;
         AssignProp("", false, edtAlmDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmDir_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1K54( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1K0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Almacenes") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810235835", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("calmacen.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"CALMACEN");
         forbiddenHiddens.Add("AlmPed", context.localUtil.Format( (decimal)(A437AlmPed), "9"));
         forbiddenHiddens.Add("AlmSunat", StringUtil.RTrim( context.localUtil.Format( A439AlmSunat, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("calmacen:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z436AlmDsc", StringUtil.RTrim( Z436AlmDsc));
         GxWebStd.gx_hidden_field( context, "Z433AlmAbr", StringUtil.RTrim( Z433AlmAbr));
         GxWebStd.gx_hidden_field( context, "Z434AlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z434AlmCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z437AlmPed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z437AlmPed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z438AlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z438AlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z435AlmDir", Z435AlmDir);
         GxWebStd.gx_hidden_field( context, "Z439AlmSunat", Z439AlmSunat);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ALMPED", StringUtil.LTrim( StringUtil.NToC( (decimal)(A437AlmPed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALMSUNAT", A439AlmSunat);
      }

      protected void RenderHtmlCloseForm1K54( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "CALMACEN" ;
      }

      public override string GetPgmdesc( )
      {
         return "Almacenes" ;
      }

      protected void InitializeNonKey1K54( )
      {
         A436AlmDsc = "";
         AssignAttri("", false, "A436AlmDsc", A436AlmDsc);
         A433AlmAbr = "";
         AssignAttri("", false, "A433AlmAbr", A433AlmAbr);
         A434AlmCos = 0;
         AssignAttri("", false, "A434AlmCos", StringUtil.Str( (decimal)(A434AlmCos), 1, 0));
         A437AlmPed = 0;
         AssignAttri("", false, "A437AlmPed", StringUtil.Str( (decimal)(A437AlmPed), 1, 0));
         A438AlmSts = 0;
         AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         A435AlmDir = "";
         AssignAttri("", false, "A435AlmDir", A435AlmDir);
         A439AlmSunat = "";
         AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
         Z436AlmDsc = "";
         Z433AlmAbr = "";
         Z434AlmCos = 0;
         Z437AlmPed = 0;
         Z438AlmSts = 0;
         Z435AlmDir = "";
         Z439AlmSunat = "";
      }

      protected void InitAll1K54( )
      {
         A63AlmCod = 0;
         AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         InitializeNonKey1K54( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810235842", true, true);
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
         context.AddJavascriptSource("calmacen.js", "?202281810235842", false, true);
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
         edtAlmCod_Internalname = "ALMCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAlmDsc_Internalname = "ALMDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAlmAbr_Internalname = "ALMABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAlmCos_Internalname = "ALMCOS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbAlmSts_Internalname = "ALMSTS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAlmDir_Internalname = "ALMDIR";
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
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAlmDir_Jsonclick = "";
         edtAlmDir_Enabled = 1;
         cmbAlmSts_Jsonclick = "";
         cmbAlmSts.Enabled = 1;
         edtAlmCos_Jsonclick = "";
         edtAlmCos_Enabled = 1;
         edtAlmAbr_Jsonclick = "";
         edtAlmAbr_Enabled = 1;
         edtAlmDsc_Jsonclick = "";
         edtAlmDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAlmCod_Jsonclick = "";
         edtAlmCod_Enabled = 1;
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
         cmbAlmSts.Name = "ALMSTS";
         cmbAlmSts.WebTags = "";
         cmbAlmSts.addItem("1", "ACTIVO", 0);
         cmbAlmSts.addItem("0", "INACTIVO", 0);
         if ( cmbAlmSts.ItemCount > 0 )
         {
            A438AlmSts = (short)(NumberUtil.Val( cmbAlmSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0))), "."));
            AssignAttri("", false, "A438AlmSts", StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAlmDsc_Internalname;
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

      public void Valid_Almcod( )
      {
         A438AlmSts = (short)(NumberUtil.Val( cmbAlmSts.CurrentValue, "."));
         cmbAlmSts.CurrentValue = StringUtil.Str( (decimal)(A438AlmSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbAlmSts.ItemCount > 0 )
         {
            A438AlmSts = (short)(NumberUtil.Val( cmbAlmSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0))), "."));
            cmbAlmSts.CurrentValue = StringUtil.Str( (decimal)(A438AlmSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A436AlmDsc", StringUtil.RTrim( A436AlmDsc));
         AssignAttri("", false, "A433AlmAbr", StringUtil.RTrim( A433AlmAbr));
         AssignAttri("", false, "A434AlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A434AlmCos), 1, 0, ".", "")));
         AssignAttri("", false, "A437AlmPed", StringUtil.LTrim( StringUtil.NToC( (decimal)(A437AlmPed), 1, 0, ".", "")));
         AssignAttri("", false, "A438AlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A438AlmSts), 1, 0, ".", "")));
         cmbAlmSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A438AlmSts), 1, 0));
         AssignProp("", false, cmbAlmSts_Internalname, "Values", cmbAlmSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A435AlmDir", A435AlmDir);
         AssignAttri("", false, "A439AlmSunat", A439AlmSunat);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z436AlmDsc", StringUtil.RTrim( Z436AlmDsc));
         GxWebStd.gx_hidden_field( context, "Z433AlmAbr", StringUtil.RTrim( Z433AlmAbr));
         GxWebStd.gx_hidden_field( context, "Z434AlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z434AlmCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z437AlmPed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z437AlmPed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z438AlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z438AlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z435AlmDir", Z435AlmDir);
         GxWebStd.gx_hidden_field( context, "Z439AlmSunat", Z439AlmSunat);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A437AlmPed',fld:'ALMPED',pic:'9'},{av:'A439AlmSunat',fld:'ALMSUNAT',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ALMCOD","{handler:'Valid_Almcod',iparms:[{av:'A439AlmSunat',fld:'ALMSUNAT',pic:''},{av:'A437AlmPed',fld:'ALMPED',pic:'9'},{av:'cmbAlmSts'},{av:'A438AlmSts',fld:'ALMSTS',pic:'9'},{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ALMCOD",",oparms:[{av:'A436AlmDsc',fld:'ALMDSC',pic:''},{av:'A433AlmAbr',fld:'ALMABR',pic:''},{av:'A434AlmCos',fld:'ALMCOS',pic:'9'},{av:'A437AlmPed',fld:'ALMPED',pic:'9'},{av:'cmbAlmSts'},{av:'A438AlmSts',fld:'ALMSTS',pic:'9'},{av:'A435AlmDir',fld:'ALMDIR',pic:''},{av:'A439AlmSunat',fld:'ALMSUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z63AlmCod'},{av:'Z436AlmDsc'},{av:'Z433AlmAbr'},{av:'Z434AlmCos'},{av:'Z437AlmPed'},{av:'Z438AlmSts'},{av:'Z435AlmDir'},{av:'Z439AlmSunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z436AlmDsc = "";
         Z433AlmAbr = "";
         Z435AlmDir = "";
         Z439AlmSunat = "";
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
         A436AlmDsc = "";
         lblTextblock3_Jsonclick = "";
         A433AlmAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A435AlmDir = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A439AlmSunat = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T001K4_A63AlmCod = new int[1] ;
         T001K4_A436AlmDsc = new string[] {""} ;
         T001K4_A433AlmAbr = new string[] {""} ;
         T001K4_A434AlmCos = new short[1] ;
         T001K4_A437AlmPed = new short[1] ;
         T001K4_A438AlmSts = new short[1] ;
         T001K4_A435AlmDir = new string[] {""} ;
         T001K4_A439AlmSunat = new string[] {""} ;
         T001K5_A63AlmCod = new int[1] ;
         T001K3_A63AlmCod = new int[1] ;
         T001K3_A436AlmDsc = new string[] {""} ;
         T001K3_A433AlmAbr = new string[] {""} ;
         T001K3_A434AlmCos = new short[1] ;
         T001K3_A437AlmPed = new short[1] ;
         T001K3_A438AlmSts = new short[1] ;
         T001K3_A435AlmDir = new string[] {""} ;
         T001K3_A439AlmSunat = new string[] {""} ;
         sMode54 = "";
         T001K6_A63AlmCod = new int[1] ;
         T001K7_A63AlmCod = new int[1] ;
         T001K2_A63AlmCod = new int[1] ;
         T001K2_A436AlmDsc = new string[] {""} ;
         T001K2_A433AlmAbr = new string[] {""} ;
         T001K2_A434AlmCos = new short[1] ;
         T001K2_A437AlmPed = new short[1] ;
         T001K2_A438AlmSts = new short[1] ;
         T001K2_A435AlmDir = new string[] {""} ;
         T001K2_A439AlmSunat = new string[] {""} ;
         T001K11_A348UsuCod = new string[] {""} ;
         T001K11_A349UsuAlmCod = new int[1] ;
         T001K12_A63AlmCod = new int[1] ;
         T001K12_A28ProdCod = new string[] {""} ;
         T001K13_A59SalCosAno = new int[1] ;
         T001K13_A60SalCosMes = new short[1] ;
         T001K13_A61SalCosAlmCod = new int[1] ;
         T001K13_A62SalCosProdCod = new string[] {""} ;
         T001K14_A13MvATip = new string[] {""} ;
         T001K14_A14MvACod = new string[] {""} ;
         T001K15_A63AlmCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ436AlmDsc = "";
         ZZ433AlmAbr = "";
         ZZ435AlmDir = "";
         ZZ439AlmSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.calmacen__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calmacen__default(),
            new Object[][] {
                new Object[] {
               T001K2_A63AlmCod, T001K2_A436AlmDsc, T001K2_A433AlmAbr, T001K2_A434AlmCos, T001K2_A437AlmPed, T001K2_A438AlmSts, T001K2_A435AlmDir, T001K2_A439AlmSunat
               }
               , new Object[] {
               T001K3_A63AlmCod, T001K3_A436AlmDsc, T001K3_A433AlmAbr, T001K3_A434AlmCos, T001K3_A437AlmPed, T001K3_A438AlmSts, T001K3_A435AlmDir, T001K3_A439AlmSunat
               }
               , new Object[] {
               T001K4_A63AlmCod, T001K4_A436AlmDsc, T001K4_A433AlmAbr, T001K4_A434AlmCos, T001K4_A437AlmPed, T001K4_A438AlmSts, T001K4_A435AlmDir, T001K4_A439AlmSunat
               }
               , new Object[] {
               T001K5_A63AlmCod
               }
               , new Object[] {
               T001K6_A63AlmCod
               }
               , new Object[] {
               T001K7_A63AlmCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001K11_A348UsuCod, T001K11_A349UsuAlmCod
               }
               , new Object[] {
               T001K12_A63AlmCod, T001K12_A28ProdCod
               }
               , new Object[] {
               T001K13_A59SalCosAno, T001K13_A60SalCosMes, T001K13_A61SalCosAlmCod, T001K13_A62SalCosProdCod
               }
               , new Object[] {
               T001K14_A13MvATip, T001K14_A14MvACod
               }
               , new Object[] {
               T001K15_A63AlmCod
               }
            }
         );
      }

      private short Z434AlmCos ;
      private short Z437AlmPed ;
      private short Z438AlmSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A438AlmSts ;
      private short A434AlmCos ;
      private short A437AlmPed ;
      private short GX_JID ;
      private short RcdFound54 ;
      private short nIsDirty_54 ;
      private short Gx_BScreen ;
      private short ZZ434AlmCos ;
      private short ZZ437AlmPed ;
      private short ZZ438AlmSts ;
      private int Z63AlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A63AlmCod ;
      private int edtAlmCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAlmDsc_Enabled ;
      private int edtAlmAbr_Enabled ;
      private int edtAlmCos_Enabled ;
      private int edtAlmDir_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ63AlmCod ;
      private string sPrefix ;
      private string Z436AlmDsc ;
      private string Z433AlmAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAlmCod_Internalname ;
      private string cmbAlmSts_Internalname ;
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
      private string edtAlmCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAlmDsc_Internalname ;
      private string A436AlmDsc ;
      private string edtAlmDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAlmAbr_Internalname ;
      private string A433AlmAbr ;
      private string edtAlmAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAlmCos_Internalname ;
      private string edtAlmCos_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbAlmSts_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAlmDir_Internalname ;
      private string edtAlmDir_Jsonclick ;
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
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode54 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ436AlmDsc ;
      private string ZZ433AlmAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z435AlmDir ;
      private string Z439AlmSunat ;
      private string A435AlmDir ;
      private string A439AlmSunat ;
      private string ZZ435AlmDir ;
      private string ZZ439AlmSunat ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAlmSts ;
      private IDataStoreProvider pr_default ;
      private int[] T001K4_A63AlmCod ;
      private string[] T001K4_A436AlmDsc ;
      private string[] T001K4_A433AlmAbr ;
      private short[] T001K4_A434AlmCos ;
      private short[] T001K4_A437AlmPed ;
      private short[] T001K4_A438AlmSts ;
      private string[] T001K4_A435AlmDir ;
      private string[] T001K4_A439AlmSunat ;
      private int[] T001K5_A63AlmCod ;
      private int[] T001K3_A63AlmCod ;
      private string[] T001K3_A436AlmDsc ;
      private string[] T001K3_A433AlmAbr ;
      private short[] T001K3_A434AlmCos ;
      private short[] T001K3_A437AlmPed ;
      private short[] T001K3_A438AlmSts ;
      private string[] T001K3_A435AlmDir ;
      private string[] T001K3_A439AlmSunat ;
      private int[] T001K6_A63AlmCod ;
      private int[] T001K7_A63AlmCod ;
      private int[] T001K2_A63AlmCod ;
      private string[] T001K2_A436AlmDsc ;
      private string[] T001K2_A433AlmAbr ;
      private short[] T001K2_A434AlmCos ;
      private short[] T001K2_A437AlmPed ;
      private short[] T001K2_A438AlmSts ;
      private string[] T001K2_A435AlmDir ;
      private string[] T001K2_A439AlmSunat ;
      private string[] T001K11_A348UsuCod ;
      private int[] T001K11_A349UsuAlmCod ;
      private int[] T001K12_A63AlmCod ;
      private string[] T001K12_A28ProdCod ;
      private int[] T001K13_A59SalCosAno ;
      private short[] T001K13_A60SalCosMes ;
      private int[] T001K13_A61SalCosAlmCod ;
      private string[] T001K13_A62SalCosProdCod ;
      private string[] T001K14_A13MvATip ;
      private string[] T001K14_A14MvACod ;
      private int[] T001K15_A63AlmCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class calmacen__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class calmacen__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001K4;
        prmT001K4 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K5;
        prmT001K5 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K3;
        prmT001K3 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K6;
        prmT001K6 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K7;
        prmT001K7 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K2;
        prmT001K2 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K8;
        prmT001K8 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@AlmDsc",GXType.NChar,100,0) ,
        new ParDef("@AlmAbr",GXType.NChar,10,0) ,
        new ParDef("@AlmCos",GXType.Int16,1,0) ,
        new ParDef("@AlmPed",GXType.Int16,1,0) ,
        new ParDef("@AlmSts",GXType.Int16,1,0) ,
        new ParDef("@AlmDir",GXType.NVarChar,100,0) ,
        new ParDef("@AlmSunat",GXType.NVarChar,4,0)
        };
        Object[] prmT001K9;
        prmT001K9 = new Object[] {
        new ParDef("@AlmDsc",GXType.NChar,100,0) ,
        new ParDef("@AlmAbr",GXType.NChar,10,0) ,
        new ParDef("@AlmCos",GXType.Int16,1,0) ,
        new ParDef("@AlmPed",GXType.Int16,1,0) ,
        new ParDef("@AlmSts",GXType.Int16,1,0) ,
        new ParDef("@AlmDir",GXType.NVarChar,100,0) ,
        new ParDef("@AlmSunat",GXType.NVarChar,4,0) ,
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K10;
        prmT001K10 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K11;
        prmT001K11 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K12;
        prmT001K12 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K13;
        prmT001K13 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K14;
        prmT001K14 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001K15;
        prmT001K15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001K2", "SELECT [AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat] FROM [CALMACEN] WITH (UPDLOCK) WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K3", "SELECT [AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K4", "SELECT TM1.[AlmCod], TM1.[AlmDsc], TM1.[AlmAbr], TM1.[AlmCos], TM1.[AlmPed], TM1.[AlmSts], TM1.[AlmDir], TM1.[AlmSunat] FROM [CALMACEN] TM1 WHERE TM1.[AlmCod] = @AlmCod ORDER BY TM1.[AlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K5", "SELECT [AlmCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001K6", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE ( [AlmCod] > @AlmCod) ORDER BY [AlmCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K7", "SELECT TOP 1 [AlmCod] FROM [CALMACEN] WHERE ( [AlmCod] < @AlmCod) ORDER BY [AlmCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K8", "INSERT INTO [CALMACEN]([AlmCod], [AlmDsc], [AlmAbr], [AlmCos], [AlmPed], [AlmSts], [AlmDir], [AlmSunat], [PaiCod], [EstCod], [ProvCod], [DisCod]) VALUES(@AlmCod, @AlmDsc, @AlmAbr, @AlmCos, @AlmPed, @AlmSts, @AlmDir, @AlmSunat, '', '', '', '')", GxErrorMask.GX_NOMASK,prmT001K8)
           ,new CursorDef("T001K9", "UPDATE [CALMACEN] SET [AlmDsc]=@AlmDsc, [AlmAbr]=@AlmAbr, [AlmCos]=@AlmCos, [AlmPed]=@AlmPed, [AlmSts]=@AlmSts, [AlmDir]=@AlmDir, [AlmSunat]=@AlmSunat  WHERE [AlmCod] = @AlmCod", GxErrorMask.GX_NOMASK,prmT001K9)
           ,new CursorDef("T001K10", "DELETE FROM [CALMACEN]  WHERE [AlmCod] = @AlmCod", GxErrorMask.GX_NOMASK,prmT001K10)
           ,new CursorDef("T001K11", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuAlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K12", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K13", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosAlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K14", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MvAlm] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001K15", "SELECT [AlmCod] FROM [CALMACEN] ORDER BY [AlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001K15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
