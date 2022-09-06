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
   public class ccondicionpago : GXHttpHandler
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
            Form.Meta.addItem("description", "Condiciones de Pago", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ccondicionpago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ccondicionpago( IGxContext context )
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
         cmbConpSts = new GXCombobox();
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
         if ( cmbConpSts.ItemCount > 0 )
         {
            A754ConpSts = (short)(NumberUtil.Val( cmbConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0))), "."));
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            AssignProp("", false, cmbConpSts_Internalname, "Values", cmbConpSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2675( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CCONDICIONPAGO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo condicion pago", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConpcod_Enabled!=0) ? context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Condicion de pago", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpDsc_Internalname, StringUtil.RTrim( A753ConpDsc), StringUtil.RTrim( context.localUtil.Format( A753ConpDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura condicion pago", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpAbr_Internalname, StringUtil.RTrim( A751ConpAbr), StringUtil.RTrim( context.localUtil.Format( A751ConpAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Dias", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConpDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A752ConpDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtConpDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A752ConpDias), "ZZZ9") : context.localUtil.Format( (decimal)(A752ConpDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situacion condicion pago", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCONDICIONPAGO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConpSts, cmbConpSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0)), 1, cmbConpSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConpSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CCONDICIONPAGO.htm");
         cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         AssignProp("", false, cmbConpSts_Internalname, "Values", (string)(cmbConpSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCONDICIONPAGO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CCONDICIONPAGO.htm");
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
            Z137Conpcod = (int)(context.localUtil.CToN( cgiGet( "Z137Conpcod"), ".", ","));
            Z753ConpDsc = cgiGet( "Z753ConpDsc");
            Z751ConpAbr = cgiGet( "Z751ConpAbr");
            Z752ConpDias = (short)(context.localUtil.CToN( cgiGet( "Z752ConpDias"), ".", ","));
            Z754ConpSts = (short)(context.localUtil.CToN( cgiGet( "Z754ConpSts"), ".", ","));
            Z755ConpSunat = cgiGet( "Z755ConpSunat");
            A755ConpSunat = cgiGet( "Z755ConpSunat");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A755ConpSunat = cgiGet( "CONPSUNAT");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONPCOD");
               AnyError = 1;
               GX_FocusControl = edtConpcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A137Conpcod = 0;
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            }
            else
            {
               A137Conpcod = (int)(context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ","));
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            }
            A753ConpDsc = cgiGet( edtConpDsc_Internalname);
            AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
            A751ConpAbr = cgiGet( edtConpAbr_Internalname);
            AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONPDIAS");
               AnyError = 1;
               GX_FocusControl = edtConpDias_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A752ConpDias = 0;
               AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            }
            else
            {
               A752ConpDias = (short)(context.localUtil.CToN( cgiGet( edtConpDias_Internalname), ".", ","));
               AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            }
            cmbConpSts.CurrentValue = cgiGet( cmbConpSts_Internalname);
            A754ConpSts = (short)(NumberUtil.Val( cgiGet( cmbConpSts_Internalname), "."));
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CCONDICIONPAGO");
            forbiddenHiddens.Add("ConpSunat", StringUtil.RTrim( context.localUtil.Format( A755ConpSunat, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A137Conpcod != Z137Conpcod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("ccondicionpago:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A137Conpcod = (int)(NumberUtil.Val( GetPar( "Conpcod"), "."));
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
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
               InitAll2675( ) ;
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
         DisableAttributes2675( ) ;
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

      protected void CONFIRM_260( )
      {
         BeforeValidate2675( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2675( ) ;
            }
            else
            {
               CheckExtendedTable2675( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2675( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues260( ) ;
         }
      }

      protected void ResetCaption260( )
      {
      }

      protected void ZM2675( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z753ConpDsc = T00263_A753ConpDsc[0];
               Z751ConpAbr = T00263_A751ConpAbr[0];
               Z752ConpDias = T00263_A752ConpDias[0];
               Z754ConpSts = T00263_A754ConpSts[0];
               Z755ConpSunat = T00263_A755ConpSunat[0];
            }
            else
            {
               Z753ConpDsc = A753ConpDsc;
               Z751ConpAbr = A751ConpAbr;
               Z752ConpDias = A752ConpDias;
               Z754ConpSts = A754ConpSts;
               Z755ConpSunat = A755ConpSunat;
            }
         }
         if ( GX_JID == -1 )
         {
            Z137Conpcod = A137Conpcod;
            Z753ConpDsc = A753ConpDsc;
            Z751ConpAbr = A751ConpAbr;
            Z752ConpDias = A752ConpDias;
            Z754ConpSts = A754ConpSts;
            Z755ConpSunat = A755ConpSunat;
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

      protected void Load2675( )
      {
         /* Using cursor T00264 */
         pr_default.execute(2, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound75 = 1;
            A753ConpDsc = T00264_A753ConpDsc[0];
            AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
            A751ConpAbr = T00264_A751ConpAbr[0];
            AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
            A752ConpDias = T00264_A752ConpDias[0];
            AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            A754ConpSts = T00264_A754ConpSts[0];
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            A755ConpSunat = T00264_A755ConpSunat[0];
            ZM2675( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2675( ) ;
      }

      protected void OnLoadActions2675( )
      {
      }

      protected void CheckExtendedTable2675( )
      {
         nIsDirty_75 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2675( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2675( )
      {
         /* Using cursor T00265 */
         pr_default.execute(3, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00263 */
         pr_default.execute(1, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2675( 1) ;
            RcdFound75 = 1;
            A137Conpcod = T00263_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            A753ConpDsc = T00263_A753ConpDsc[0];
            AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
            A751ConpAbr = T00263_A751ConpAbr[0];
            AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
            A752ConpDias = T00263_A752ConpDias[0];
            AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
            A754ConpSts = T00263_A754ConpSts[0];
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
            A755ConpSunat = T00263_A755ConpSunat[0];
            Z137Conpcod = A137Conpcod;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2675( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey2675( ) ;
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey2675( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2675( ) ;
         if ( RcdFound75 == 0 )
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
         RcdFound75 = 0;
         /* Using cursor T00266 */
         pr_default.execute(4, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00266_A137Conpcod[0] < A137Conpcod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00266_A137Conpcod[0] > A137Conpcod ) ) )
            {
               A137Conpcod = T00266_A137Conpcod[0];
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound75 = 0;
         /* Using cursor T00267 */
         pr_default.execute(5, new Object[] {A137Conpcod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00267_A137Conpcod[0] > A137Conpcod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00267_A137Conpcod[0] < A137Conpcod ) ) )
            {
               A137Conpcod = T00267_A137Conpcod[0];
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2675( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2675( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( A137Conpcod != Z137Conpcod )
               {
                  A137Conpcod = Z137Conpcod;
                  AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2675( ) ;
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A137Conpcod != Z137Conpcod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtConpcod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2675( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtConpcod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtConpcod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2675( ) ;
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
         if ( A137Conpcod != Z137Conpcod )
         {
            A137Conpcod = Z137Conpcod;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConpcod_Internalname;
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
         GetKey2675( ) ;
         if ( RcdFound75 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CONPCOD");
               AnyError = 1;
               GX_FocusControl = edtConpcod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A137Conpcod != Z137Conpcod )
            {
               A137Conpcod = Z137Conpcod;
               AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CONPCOD");
               AnyError = 1;
               GX_FocusControl = edtConpcod_Internalname;
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
            if ( A137Conpcod != Z137Conpcod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConpcod_Internalname;
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
         context.RollbackDataStores("ccondicionpago",pr_default);
         GX_FocusControl = edtConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_260( ) ;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CONPCOD");
            AnyError = 1;
            GX_FocusControl = edtConpcod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2675( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2675( ) ;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConpDsc_Internalname;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConpDsc_Internalname;
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
         ScanStart2675( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound75 != 0 )
            {
               ScanNext2675( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConpDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2675( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2675( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00262 */
            pr_default.execute(0, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCONDICIONPAGO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z753ConpDsc, T00262_A753ConpDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z751ConpAbr, T00262_A751ConpAbr[0]) != 0 ) || ( Z752ConpDias != T00262_A752ConpDias[0] ) || ( Z754ConpSts != T00262_A754ConpSts[0] ) || ( StringUtil.StrCmp(Z755ConpSunat, T00262_A755ConpSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z753ConpDsc, T00262_A753ConpDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ccondicionpago:[seudo value changed for attri]"+"ConpDsc");
                  GXUtil.WriteLogRaw("Old: ",Z753ConpDsc);
                  GXUtil.WriteLogRaw("Current: ",T00262_A753ConpDsc[0]);
               }
               if ( StringUtil.StrCmp(Z751ConpAbr, T00262_A751ConpAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ccondicionpago:[seudo value changed for attri]"+"ConpAbr");
                  GXUtil.WriteLogRaw("Old: ",Z751ConpAbr);
                  GXUtil.WriteLogRaw("Current: ",T00262_A751ConpAbr[0]);
               }
               if ( Z752ConpDias != T00262_A752ConpDias[0] )
               {
                  GXUtil.WriteLog("ccondicionpago:[seudo value changed for attri]"+"ConpDias");
                  GXUtil.WriteLogRaw("Old: ",Z752ConpDias);
                  GXUtil.WriteLogRaw("Current: ",T00262_A752ConpDias[0]);
               }
               if ( Z754ConpSts != T00262_A754ConpSts[0] )
               {
                  GXUtil.WriteLog("ccondicionpago:[seudo value changed for attri]"+"ConpSts");
                  GXUtil.WriteLogRaw("Old: ",Z754ConpSts);
                  GXUtil.WriteLogRaw("Current: ",T00262_A754ConpSts[0]);
               }
               if ( StringUtil.StrCmp(Z755ConpSunat, T00262_A755ConpSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("ccondicionpago:[seudo value changed for attri]"+"ConpSunat");
                  GXUtil.WriteLogRaw("Old: ",Z755ConpSunat);
                  GXUtil.WriteLogRaw("Current: ",T00262_A755ConpSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CCONDICIONPAGO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2675( )
      {
         BeforeValidate2675( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2675( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2675( 0) ;
            CheckOptimisticConcurrency2675( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2675( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2675( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00268 */
                     pr_default.execute(6, new Object[] {A137Conpcod, A753ConpDsc, A751ConpAbr, A752ConpDias, A754ConpSts, A755ConpSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
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
                           ResetCaption260( ) ;
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
               Load2675( ) ;
            }
            EndLevel2675( ) ;
         }
         CloseExtendedTableCursors2675( ) ;
      }

      protected void Update2675( )
      {
         BeforeValidate2675( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2675( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2675( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2675( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2675( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00269 */
                     pr_default.execute(7, new Object[] {A753ConpDsc, A751ConpAbr, A752ConpDias, A754ConpSts, A755ConpSunat, A137Conpcod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCONDICIONPAGO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2675( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption260( ) ;
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
            EndLevel2675( ) ;
         }
         CloseExtendedTableCursors2675( ) ;
      }

      protected void DeferredUpdate2675( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2675( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2675( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2675( ) ;
            AfterConfirm2675( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2675( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002610 */
                  pr_default.execute(8, new Object[] {A137Conpcod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CCONDICIONPAGO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound75 == 0 )
                        {
                           InitAll2675( ) ;
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
                        ResetCaption260( ) ;
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2675( ) ;
         Gx_mode = sMode75;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2675( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002611 */
            pr_default.execute(9, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T002612 */
            pr_default.execute(10, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T002613 */
            pr_default.execute(11, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T002614 */
            pr_default.execute(12, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T002615 */
            pr_default.execute(13, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T002616 */
            pr_default.execute(14, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002617 */
            pr_default.execute(15, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T002618 */
            pr_default.execute(16, new Object[] {A137Conpcod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel2675( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2675( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ccondicionpago",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues260( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ccondicionpago",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2675( )
      {
         /* Using cursor T002619 */
         pr_default.execute(17);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound75 = 1;
            A137Conpcod = T002619_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2675( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound75 = 1;
            A137Conpcod = T002619_A137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         }
      }

      protected void ScanEnd2675( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm2675( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2675( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2675( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2675( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2675( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2675( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2675( )
      {
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         edtConpDsc_Enabled = 0;
         AssignProp("", false, edtConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpDsc_Enabled), 5, 0), true);
         edtConpAbr_Enabled = 0;
         AssignProp("", false, edtConpAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpAbr_Enabled), 5, 0), true);
         edtConpDias_Enabled = 0;
         AssignProp("", false, edtConpDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpDias_Enabled), 5, 0), true);
         cmbConpSts.Enabled = 0;
         AssignProp("", false, cmbConpSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConpSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2675( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues260( )
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
         context.SendWebValue( "Condiciones de Pago") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242713", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ccondicionpago.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CCONDICIONPAGO");
         forbiddenHiddens.Add("ConpSunat", StringUtil.RTrim( context.localUtil.Format( A755ConpSunat, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ccondicionpago:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z753ConpDsc", StringUtil.RTrim( Z753ConpDsc));
         GxWebStd.gx_hidden_field( context, "Z751ConpAbr", StringUtil.RTrim( Z751ConpAbr));
         GxWebStd.gx_hidden_field( context, "Z752ConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z752ConpDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z754ConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z754ConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z755ConpSunat", Z755ConpSunat);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CONPSUNAT", A755ConpSunat);
      }

      protected void RenderHtmlCloseForm2675( )
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
         return "CCONDICIONPAGO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Condiciones de Pago" ;
      }

      protected void InitializeNonKey2675( )
      {
         A753ConpDsc = "";
         AssignAttri("", false, "A753ConpDsc", A753ConpDsc);
         A751ConpAbr = "";
         AssignAttri("", false, "A751ConpAbr", A751ConpAbr);
         A752ConpDias = 0;
         AssignAttri("", false, "A752ConpDias", StringUtil.LTrimStr( (decimal)(A752ConpDias), 4, 0));
         A754ConpSts = 0;
         AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         A755ConpSunat = "";
         AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
         Z753ConpDsc = "";
         Z751ConpAbr = "";
         Z752ConpDias = 0;
         Z754ConpSts = 0;
         Z755ConpSunat = "";
      }

      protected void InitAll2675( )
      {
         A137Conpcod = 0;
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         InitializeNonKey2675( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242720", true, true);
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
         context.AddJavascriptSource("ccondicionpago.js", "?202281810242720", false, true);
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
         edtConpcod_Internalname = "CONPCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtConpDsc_Internalname = "CONPDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtConpAbr_Internalname = "CONPABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtConpDias_Internalname = "CONPDIAS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbConpSts_Internalname = "CONPSTS";
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
         cmbConpSts_Jsonclick = "";
         cmbConpSts.Enabled = 1;
         edtConpDias_Jsonclick = "";
         edtConpDias_Enabled = 1;
         edtConpAbr_Jsonclick = "";
         edtConpAbr_Enabled = 1;
         edtConpDsc_Jsonclick = "";
         edtConpDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtConpcod_Jsonclick = "";
         edtConpcod_Enabled = 1;
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
         cmbConpSts.Name = "CONPSTS";
         cmbConpSts.WebTags = "";
         cmbConpSts.addItem("1", "ACTIVO", 0);
         cmbConpSts.addItem("0", "INACTIVO", 0);
         if ( cmbConpSts.ItemCount > 0 )
         {
            A754ConpSts = (short)(NumberUtil.Val( cmbConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0))), "."));
            AssignAttri("", false, "A754ConpSts", StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtConpDsc_Internalname;
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

      public void Valid_Conpcod( )
      {
         A754ConpSts = (short)(NumberUtil.Val( cmbConpSts.CurrentValue, "."));
         cmbConpSts.CurrentValue = StringUtil.Str( (decimal)(A754ConpSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbConpSts.ItemCount > 0 )
         {
            A754ConpSts = (short)(NumberUtil.Val( cmbConpSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0))), "."));
            cmbConpSts.CurrentValue = StringUtil.Str( (decimal)(A754ConpSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A753ConpDsc", StringUtil.RTrim( A753ConpDsc));
         AssignAttri("", false, "A751ConpAbr", StringUtil.RTrim( A751ConpAbr));
         AssignAttri("", false, "A752ConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A752ConpDias), 4, 0, ".", "")));
         AssignAttri("", false, "A754ConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A754ConpSts), 1, 0, ".", "")));
         cmbConpSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A754ConpSts), 1, 0));
         AssignProp("", false, cmbConpSts_Internalname, "Values", cmbConpSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A755ConpSunat", A755ConpSunat);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137Conpcod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z753ConpDsc", StringUtil.RTrim( Z753ConpDsc));
         GxWebStd.gx_hidden_field( context, "Z751ConpAbr", StringUtil.RTrim( Z751ConpAbr));
         GxWebStd.gx_hidden_field( context, "Z752ConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z752ConpDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z754ConpSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z754ConpSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z755ConpSunat", Z755ConpSunat);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A755ConpSunat',fld:'CONPSUNAT',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CONPCOD","{handler:'Valid_Conpcod',iparms:[{av:'A755ConpSunat',fld:'CONPSUNAT',pic:''},{av:'cmbConpSts'},{av:'A754ConpSts',fld:'CONPSTS',pic:'9'},{av:'A137Conpcod',fld:'CONPCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CONPCOD",",oparms:[{av:'A753ConpDsc',fld:'CONPDSC',pic:''},{av:'A751ConpAbr',fld:'CONPABR',pic:''},{av:'A752ConpDias',fld:'CONPDIAS',pic:'ZZZ9'},{av:'cmbConpSts'},{av:'A754ConpSts',fld:'CONPSTS',pic:'9'},{av:'A755ConpSunat',fld:'CONPSUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z137Conpcod'},{av:'Z753ConpDsc'},{av:'Z751ConpAbr'},{av:'Z752ConpDias'},{av:'Z754ConpSts'},{av:'Z755ConpSunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z753ConpDsc = "";
         Z751ConpAbr = "";
         Z755ConpSunat = "";
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
         A753ConpDsc = "";
         lblTextblock3_Jsonclick = "";
         A751ConpAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A755ConpSunat = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00264_A137Conpcod = new int[1] ;
         T00264_A753ConpDsc = new string[] {""} ;
         T00264_A751ConpAbr = new string[] {""} ;
         T00264_A752ConpDias = new short[1] ;
         T00264_A754ConpSts = new short[1] ;
         T00264_A755ConpSunat = new string[] {""} ;
         T00265_A137Conpcod = new int[1] ;
         T00263_A137Conpcod = new int[1] ;
         T00263_A753ConpDsc = new string[] {""} ;
         T00263_A751ConpAbr = new string[] {""} ;
         T00263_A752ConpDias = new short[1] ;
         T00263_A754ConpSts = new short[1] ;
         T00263_A755ConpSunat = new string[] {""} ;
         sMode75 = "";
         T00266_A137Conpcod = new int[1] ;
         T00267_A137Conpcod = new int[1] ;
         T00262_A137Conpcod = new int[1] ;
         T00262_A753ConpDsc = new string[] {""} ;
         T00262_A751ConpAbr = new string[] {""} ;
         T00262_A752ConpDias = new short[1] ;
         T00262_A754ConpSts = new short[1] ;
         T00262_A755ConpSunat = new string[] {""} ;
         T002611_A244PrvCod = new string[] {""} ;
         T002612_A289OrdCod = new string[] {""} ;
         T002613_A149TipCod = new string[] {""} ;
         T002613_A243ComCod = new string[] {""} ;
         T002613_A244PrvCod = new string[] {""} ;
         T002614_A149TipCod = new string[] {""} ;
         T002614_A24DocNum = new string[] {""} ;
         T002615_A210PedCod = new string[] {""} ;
         T002616_A191ImpItem = new long[1] ;
         T002617_A177CotCod = new string[] {""} ;
         T002618_A45CliCod = new string[] {""} ;
         T002619_A137Conpcod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ753ConpDsc = "";
         ZZ751ConpAbr = "";
         ZZ755ConpSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ccondicionpago__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ccondicionpago__default(),
            new Object[][] {
                new Object[] {
               T00262_A137Conpcod, T00262_A753ConpDsc, T00262_A751ConpAbr, T00262_A752ConpDias, T00262_A754ConpSts, T00262_A755ConpSunat
               }
               , new Object[] {
               T00263_A137Conpcod, T00263_A753ConpDsc, T00263_A751ConpAbr, T00263_A752ConpDias, T00263_A754ConpSts, T00263_A755ConpSunat
               }
               , new Object[] {
               T00264_A137Conpcod, T00264_A753ConpDsc, T00264_A751ConpAbr, T00264_A752ConpDias, T00264_A754ConpSts, T00264_A755ConpSunat
               }
               , new Object[] {
               T00265_A137Conpcod
               }
               , new Object[] {
               T00266_A137Conpcod
               }
               , new Object[] {
               T00267_A137Conpcod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002611_A244PrvCod
               }
               , new Object[] {
               T002612_A289OrdCod
               }
               , new Object[] {
               T002613_A149TipCod, T002613_A243ComCod, T002613_A244PrvCod
               }
               , new Object[] {
               T002614_A149TipCod, T002614_A24DocNum
               }
               , new Object[] {
               T002615_A210PedCod
               }
               , new Object[] {
               T002616_A191ImpItem
               }
               , new Object[] {
               T002617_A177CotCod
               }
               , new Object[] {
               T002618_A45CliCod
               }
               , new Object[] {
               T002619_A137Conpcod
               }
            }
         );
      }

      private short Z752ConpDias ;
      private short Z754ConpSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A754ConpSts ;
      private short A752ConpDias ;
      private short GX_JID ;
      private short RcdFound75 ;
      private short nIsDirty_75 ;
      private short Gx_BScreen ;
      private short ZZ752ConpDias ;
      private short ZZ754ConpSts ;
      private int Z137Conpcod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A137Conpcod ;
      private int edtConpcod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtConpDsc_Enabled ;
      private int edtConpAbr_Enabled ;
      private int edtConpDias_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ137Conpcod ;
      private string sPrefix ;
      private string Z753ConpDsc ;
      private string Z751ConpAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConpcod_Internalname ;
      private string cmbConpSts_Internalname ;
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
      private string edtConpcod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtConpDsc_Internalname ;
      private string A753ConpDsc ;
      private string edtConpDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtConpAbr_Internalname ;
      private string A751ConpAbr ;
      private string edtConpAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtConpDias_Internalname ;
      private string edtConpDias_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbConpSts_Jsonclick ;
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
      private string sMode75 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ753ConpDsc ;
      private string ZZ751ConpAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z755ConpSunat ;
      private string A755ConpSunat ;
      private string ZZ755ConpSunat ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConpSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00264_A137Conpcod ;
      private string[] T00264_A753ConpDsc ;
      private string[] T00264_A751ConpAbr ;
      private short[] T00264_A752ConpDias ;
      private short[] T00264_A754ConpSts ;
      private string[] T00264_A755ConpSunat ;
      private int[] T00265_A137Conpcod ;
      private int[] T00263_A137Conpcod ;
      private string[] T00263_A753ConpDsc ;
      private string[] T00263_A751ConpAbr ;
      private short[] T00263_A752ConpDias ;
      private short[] T00263_A754ConpSts ;
      private string[] T00263_A755ConpSunat ;
      private int[] T00266_A137Conpcod ;
      private int[] T00267_A137Conpcod ;
      private int[] T00262_A137Conpcod ;
      private string[] T00262_A753ConpDsc ;
      private string[] T00262_A751ConpAbr ;
      private short[] T00262_A752ConpDias ;
      private short[] T00262_A754ConpSts ;
      private string[] T00262_A755ConpSunat ;
      private string[] T002611_A244PrvCod ;
      private string[] T002612_A289OrdCod ;
      private string[] T002613_A149TipCod ;
      private string[] T002613_A243ComCod ;
      private string[] T002613_A244PrvCod ;
      private string[] T002614_A149TipCod ;
      private string[] T002614_A24DocNum ;
      private string[] T002615_A210PedCod ;
      private long[] T002616_A191ImpItem ;
      private string[] T002617_A177CotCod ;
      private string[] T002618_A45CliCod ;
      private int[] T002619_A137Conpcod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ccondicionpago__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ccondicionpago__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00264;
        prmT00264 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00265;
        prmT00265 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00263;
        prmT00263 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00266;
        prmT00266 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00267;
        prmT00267 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00262;
        prmT00262 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT00268;
        prmT00268 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0) ,
        new ParDef("@ConpDsc",GXType.NChar,100,0) ,
        new ParDef("@ConpAbr",GXType.NChar,5,0) ,
        new ParDef("@ConpDias",GXType.Int16,4,0) ,
        new ParDef("@ConpSts",GXType.Int16,1,0) ,
        new ParDef("@ConpSunat",GXType.NVarChar,20,0)
        };
        Object[] prmT00269;
        prmT00269 = new Object[] {
        new ParDef("@ConpDsc",GXType.NChar,100,0) ,
        new ParDef("@ConpAbr",GXType.NChar,5,0) ,
        new ParDef("@ConpDias",GXType.Int16,4,0) ,
        new ParDef("@ConpSts",GXType.Int16,1,0) ,
        new ParDef("@ConpSunat",GXType.NVarChar,20,0) ,
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002610;
        prmT002610 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002611;
        prmT002611 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002612;
        prmT002612 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002613;
        prmT002613 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002614;
        prmT002614 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002615;
        prmT002615 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002616;
        prmT002616 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002617;
        prmT002617 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002618;
        prmT002618 = new Object[] {
        new ParDef("@Conpcod",GXType.Int32,6,0)
        };
        Object[] prmT002619;
        prmT002619 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00262", "SELECT [Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat] FROM [CCONDICIONPAGO] WITH (UPDLOCK) WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00262,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00263", "SELECT [Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00263,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00264", "SELECT TM1.[Conpcod], TM1.[ConpDsc], TM1.[ConpAbr], TM1.[ConpDias], TM1.[ConpSts], TM1.[ConpSunat] FROM [CCONDICIONPAGO] TM1 WHERE TM1.[Conpcod] = @Conpcod ORDER BY TM1.[Conpcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00264,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00265", "SELECT [Conpcod] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @Conpcod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00265,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00266", "SELECT TOP 1 [Conpcod] FROM [CCONDICIONPAGO] WHERE ( [Conpcod] > @Conpcod) ORDER BY [Conpcod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00266,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00267", "SELECT TOP 1 [Conpcod] FROM [CCONDICIONPAGO] WHERE ( [Conpcod] < @Conpcod) ORDER BY [Conpcod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00267,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00268", "INSERT INTO [CCONDICIONPAGO]([Conpcod], [ConpDsc], [ConpAbr], [ConpDias], [ConpSts], [ConpSunat]) VALUES(@Conpcod, @ConpDsc, @ConpAbr, @ConpDias, @ConpSts, @ConpSunat)", GxErrorMask.GX_NOMASK,prmT00268)
           ,new CursorDef("T00269", "UPDATE [CCONDICIONPAGO] SET [ConpDsc]=@ConpDsc, [ConpAbr]=@ConpAbr, [ConpDias]=@ConpDias, [ConpSts]=@ConpSts, [ConpSunat]=@ConpSunat  WHERE [Conpcod] = @Conpcod", GxErrorMask.GX_NOMASK,prmT00269)
           ,new CursorDef("T002610", "DELETE FROM [CCONDICIONPAGO]  WHERE [Conpcod] = @Conpcod", GxErrorMask.GX_NOMASK,prmT002610)
           ,new CursorDef("T002611", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002612", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002613", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [ComConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002614", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002614,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002615", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedConp] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002615,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002616", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002616,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002617", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotConpCod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002617,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002618", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [Conpcod] = @Conpcod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002618,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002619", "SELECT [Conpcod] FROM [CCONDICIONPAGO] ORDER BY [Conpcod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002619,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
