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
   public class tsconceptoentrega : GXHttpHandler
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
            Form.Meta.addItem("description", "Conceptos de Entregas a Rendir", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtConEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsconceptoentrega( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsconceptoentrega( IGxContext context )
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
         cmbConEntSts = new GXCombobox();
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
         if ( cmbConEntSts.ItemCount > 0 )
         {
            A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0))), "."));
            AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
            AssignProp("", false, cmbConEntSts_Internalname, "Values", cmbConEntSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm56173( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSCONCEPTOENTREGA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Concepto de Entrega", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ConEntCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConEntCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A376ConEntCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConEntCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Concepto de Entrega", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConEntDsc_Internalname, StringUtil.RTrim( A749ConEntDsc), StringUtil.RTrim( context.localUtil.Format( A749ConEntDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConEntDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConEntDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cuenta", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCONCEPTOENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbConEntSts, cmbConEntSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0)), 1, cmbConEntSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbConEntSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_TSCONCEPTOENTREGA.htm");
         cmbConEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         AssignProp("", false, cmbConEntSts_Internalname, "Values", (string)(cmbConEntSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCONCEPTOENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSCONCEPTOENTREGA.htm");
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
            Z376ConEntCod = (int)(context.localUtil.CToN( cgiGet( "Z376ConEntCod"), ".", ","));
            Z749ConEntDsc = cgiGet( "Z749ConEntDsc");
            Z750ConEntSts = (short)(context.localUtil.CToN( cgiGet( "Z750ConEntSts"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtConEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONENTCOD");
               AnyError = 1;
               GX_FocusControl = edtConEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A376ConEntCod = 0;
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
            }
            else
            {
               A376ConEntCod = (int)(context.localUtil.CToN( cgiGet( edtConEntCod_Internalname), ".", ","));
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
            }
            A749ConEntDsc = cgiGet( edtConEntDsc_Internalname);
            AssignAttri("", false, "A749ConEntDsc", A749ConEntDsc);
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            cmbConEntSts.CurrentValue = cgiGet( cmbConEntSts_Internalname);
            A750ConEntSts = (short)(NumberUtil.Val( cgiGet( cmbConEntSts_Internalname), "."));
            AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
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
               A376ConEntCod = (int)(NumberUtil.Val( GetPar( "ConEntCod"), "."));
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
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
               InitAll56173( ) ;
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
         DisableAttributes56173( ) ;
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

      protected void CONFIRM_560( )
      {
         BeforeValidate56173( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls56173( ) ;
            }
            else
            {
               CheckExtendedTable56173( ) ;
               if ( AnyError == 0 )
               {
                  ZM56173( 2) ;
               }
               CloseExtendedTableCursors56173( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues560( ) ;
         }
      }

      protected void ResetCaption560( )
      {
      }

      protected void ZM56173( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z749ConEntDsc = T00563_A749ConEntDsc[0];
               Z750ConEntSts = T00563_A750ConEntSts[0];
               Z91CueCod = T00563_A91CueCod[0];
            }
            else
            {
               Z749ConEntDsc = A749ConEntDsc;
               Z750ConEntSts = A750ConEntSts;
               Z91CueCod = A91CueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z376ConEntCod = A376ConEntCod;
            Z749ConEntDsc = A749ConEntDsc;
            Z750ConEntSts = A750ConEntSts;
            Z91CueCod = A91CueCod;
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

      protected void Load56173( )
      {
         /* Using cursor T00565 */
         pr_default.execute(3, new Object[] {A376ConEntCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound173 = 1;
            A749ConEntDsc = T00565_A749ConEntDsc[0];
            AssignAttri("", false, "A749ConEntDsc", A749ConEntDsc);
            A750ConEntSts = T00565_A750ConEntSts[0];
            AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
            A91CueCod = T00565_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            ZM56173( -1) ;
         }
         pr_default.close(3);
         OnLoadActions56173( ) ;
      }

      protected void OnLoadActions56173( )
      {
      }

      protected void CheckExtendedTable56173( )
      {
         nIsDirty_173 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00564 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors56173( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A91CueCod )
      {
         /* Using cursor T00566 */
         pr_default.execute(4, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
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

      protected void GetKey56173( )
      {
         /* Using cursor T00567 */
         pr_default.execute(5, new Object[] {A376ConEntCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound173 = 1;
         }
         else
         {
            RcdFound173 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00563 */
         pr_default.execute(1, new Object[] {A376ConEntCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM56173( 1) ;
            RcdFound173 = 1;
            A376ConEntCod = T00563_A376ConEntCod[0];
            AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
            A749ConEntDsc = T00563_A749ConEntDsc[0];
            AssignAttri("", false, "A749ConEntDsc", A749ConEntDsc);
            A750ConEntSts = T00563_A750ConEntSts[0];
            AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
            A91CueCod = T00563_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            Z376ConEntCod = A376ConEntCod;
            sMode173 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load56173( ) ;
            if ( AnyError == 1 )
            {
               RcdFound173 = 0;
               InitializeNonKey56173( ) ;
            }
            Gx_mode = sMode173;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound173 = 0;
            InitializeNonKey56173( ) ;
            sMode173 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode173;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey56173( ) ;
         if ( RcdFound173 == 0 )
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
         RcdFound173 = 0;
         /* Using cursor T00568 */
         pr_default.execute(6, new Object[] {A376ConEntCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00568_A376ConEntCod[0] < A376ConEntCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00568_A376ConEntCod[0] > A376ConEntCod ) ) )
            {
               A376ConEntCod = T00568_A376ConEntCod[0];
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
               RcdFound173 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound173 = 0;
         /* Using cursor T00569 */
         pr_default.execute(7, new Object[] {A376ConEntCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00569_A376ConEntCod[0] > A376ConEntCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00569_A376ConEntCod[0] < A376ConEntCod ) ) )
            {
               A376ConEntCod = T00569_A376ConEntCod[0];
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
               RcdFound173 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey56173( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtConEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert56173( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound173 == 1 )
            {
               if ( A376ConEntCod != Z376ConEntCod )
               {
                  A376ConEntCod = Z376ConEntCod;
                  AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CONENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtConEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update56173( ) ;
                  GX_FocusControl = edtConEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A376ConEntCod != Z376ConEntCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtConEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert56173( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONENTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtConEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtConEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert56173( ) ;
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
         if ( A376ConEntCod != Z376ConEntCod )
         {
            A376ConEntCod = Z376ConEntCod;
            AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CONENTCOD");
            AnyError = 1;
            GX_FocusControl = edtConEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtConEntCod_Internalname;
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
         GetKey56173( ) ;
         if ( RcdFound173 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CONENTCOD");
               AnyError = 1;
               GX_FocusControl = edtConEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A376ConEntCod != Z376ConEntCod )
            {
               A376ConEntCod = Z376ConEntCod;
               AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CONENTCOD");
               AnyError = 1;
               GX_FocusControl = edtConEntCod_Internalname;
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
            if ( A376ConEntCod != Z376ConEntCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CONENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtConEntCod_Internalname;
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
         context.RollbackDataStores("tsconceptoentrega",pr_default);
         GX_FocusControl = edtConEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_560( ) ;
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
         if ( RcdFound173 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CONENTCOD");
            AnyError = 1;
            GX_FocusControl = edtConEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtConEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart56173( ) ;
         if ( RcdFound173 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd56173( ) ;
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
         if ( RcdFound173 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConEntDsc_Internalname;
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
         if ( RcdFound173 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConEntDsc_Internalname;
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
         ScanStart56173( ) ;
         if ( RcdFound173 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound173 != 0 )
            {
               ScanNext56173( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtConEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd56173( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency56173( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00562 */
            pr_default.execute(0, new Object[] {A376ConEntCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOENTREGA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z749ConEntDsc, T00562_A749ConEntDsc[0]) != 0 ) || ( Z750ConEntSts != T00562_A750ConEntSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T00562_A91CueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z749ConEntDsc, T00562_A749ConEntDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsconceptoentrega:[seudo value changed for attri]"+"ConEntDsc");
                  GXUtil.WriteLogRaw("Old: ",Z749ConEntDsc);
                  GXUtil.WriteLogRaw("Current: ",T00562_A749ConEntDsc[0]);
               }
               if ( Z750ConEntSts != T00562_A750ConEntSts[0] )
               {
                  GXUtil.WriteLog("tsconceptoentrega:[seudo value changed for attri]"+"ConEntSts");
                  GXUtil.WriteLogRaw("Old: ",Z750ConEntSts);
                  GXUtil.WriteLogRaw("Current: ",T00562_A750ConEntSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T00562_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsconceptoentrega:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T00562_A91CueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCONCEPTOENTREGA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert56173( )
      {
         BeforeValidate56173( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable56173( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM56173( 0) ;
            CheckOptimisticConcurrency56173( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm56173( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert56173( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005610 */
                     pr_default.execute(8, new Object[] {A376ConEntCod, A749ConEntDsc, A750ConEntSts, A91CueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOENTREGA");
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
                           ResetCaption560( ) ;
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
               Load56173( ) ;
            }
            EndLevel56173( ) ;
         }
         CloseExtendedTableCursors56173( ) ;
      }

      protected void Update56173( )
      {
         BeforeValidate56173( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable56173( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency56173( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm56173( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate56173( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005611 */
                     pr_default.execute(9, new Object[] {A749ConEntDsc, A750ConEntSts, A91CueCod, A376ConEntCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOENTREGA");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCONCEPTOENTREGA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate56173( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption560( ) ;
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
            EndLevel56173( ) ;
         }
         CloseExtendedTableCursors56173( ) ;
      }

      protected void DeferredUpdate56173( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate56173( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency56173( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls56173( ) ;
            AfterConfirm56173( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete56173( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005612 */
                  pr_default.execute(10, new Object[] {A376ConEntCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCONCEPTOENTREGA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound173 == 0 )
                        {
                           InitAll56173( ) ;
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
                        ResetCaption560( ) ;
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
         sMode173 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel56173( ) ;
         Gx_mode = sMode173;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls56173( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005613 */
            pr_default.execute(11, new Object[] {A376ConEntCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel56173( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete56173( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tsconceptoentrega",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues560( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tsconceptoentrega",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart56173( )
      {
         /* Using cursor T005614 */
         pr_default.execute(12);
         RcdFound173 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound173 = 1;
            A376ConEntCod = T005614_A376ConEntCod[0];
            AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext56173( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound173 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound173 = 1;
            A376ConEntCod = T005614_A376ConEntCod[0];
            AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
         }
      }

      protected void ScanEnd56173( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm56173( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert56173( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate56173( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete56173( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete56173( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate56173( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes56173( )
      {
         edtConEntCod_Enabled = 0;
         AssignProp("", false, edtConEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConEntCod_Enabled), 5, 0), true);
         edtConEntDsc_Enabled = 0;
         AssignProp("", false, edtConEntDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConEntDsc_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         cmbConEntSts.Enabled = 0;
         AssignProp("", false, cmbConEntSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbConEntSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes56173( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues560( )
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
         context.SendWebValue( "Conceptos de Entregas a Rendir") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254848", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsconceptoentrega.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z376ConEntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ConEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z749ConEntDsc", StringUtil.RTrim( Z749ConEntDsc));
         GxWebStd.gx_hidden_field( context, "Z750ConEntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z750ConEntSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm56173( )
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
         return "TSCONCEPTOENTREGA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Conceptos de Entregas a Rendir" ;
      }

      protected void InitializeNonKey56173( )
      {
         A749ConEntDsc = "";
         AssignAttri("", false, "A749ConEntDsc", A749ConEntDsc);
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A750ConEntSts = 0;
         AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         Z749ConEntDsc = "";
         Z750ConEntSts = 0;
         Z91CueCod = "";
      }

      protected void InitAll56173( )
      {
         A376ConEntCod = 0;
         AssignAttri("", false, "A376ConEntCod", StringUtil.LTrimStr( (decimal)(A376ConEntCod), 6, 0));
         InitializeNonKey56173( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254852", true, true);
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
         context.AddJavascriptSource("tsconceptoentrega.js", "?202281810254853", false, true);
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
         edtConEntCod_Internalname = "CONENTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtConEntDsc_Internalname = "CONENTDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbConEntSts_Internalname = "CONENTSTS";
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
         cmbConEntSts_Jsonclick = "";
         cmbConEntSts.Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtConEntDsc_Jsonclick = "";
         edtConEntDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtConEntCod_Jsonclick = "";
         edtConEntCod_Enabled = 1;
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
         cmbConEntSts.Name = "CONENTSTS";
         cmbConEntSts.WebTags = "";
         cmbConEntSts.addItem("1", "ACTIVO", 0);
         cmbConEntSts.addItem("0", "INACTIVO", 0);
         if ( cmbConEntSts.ItemCount > 0 )
         {
            A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0))), "."));
            AssignAttri("", false, "A750ConEntSts", StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtConEntDsc_Internalname;
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

      public void Valid_Conentcod( )
      {
         A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.CurrentValue, "."));
         cmbConEntSts.CurrentValue = StringUtil.Str( (decimal)(A750ConEntSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbConEntSts.ItemCount > 0 )
         {
            A750ConEntSts = (short)(NumberUtil.Val( cmbConEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0))), "."));
            cmbConEntSts.CurrentValue = StringUtil.Str( (decimal)(A750ConEntSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbConEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A749ConEntDsc", StringUtil.RTrim( A749ConEntDsc));
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A750ConEntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A750ConEntSts), 1, 0, ".", "")));
         cmbConEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A750ConEntSts), 1, 0));
         AssignProp("", false, cmbConEntSts_Internalname, "Values", cmbConEntSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z376ConEntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ConEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z749ConEntDsc", StringUtil.RTrim( Z749ConEntDsc));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z750ConEntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z750ConEntSts), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T005615 */
         pr_default.execute(13, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_CONENTCOD","{handler:'Valid_Conentcod',iparms:[{av:'cmbConEntSts'},{av:'A750ConEntSts',fld:'CONENTSTS',pic:'9'},{av:'A376ConEntCod',fld:'CONENTCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CONENTCOD",",oparms:[{av:'A749ConEntDsc',fld:'CONENTDSC',pic:''},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'cmbConEntSts'},{av:'A750ConEntSts',fld:'CONENTSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z376ConEntCod'},{av:'Z749ConEntDsc'},{av:'Z91CueCod'},{av:'Z750ConEntSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z749ConEntDsc = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A749ConEntDsc = "";
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
         T00565_A376ConEntCod = new int[1] ;
         T00565_A749ConEntDsc = new string[] {""} ;
         T00565_A750ConEntSts = new short[1] ;
         T00565_A91CueCod = new string[] {""} ;
         T00564_A91CueCod = new string[] {""} ;
         T00566_A91CueCod = new string[] {""} ;
         T00567_A376ConEntCod = new int[1] ;
         T00563_A376ConEntCod = new int[1] ;
         T00563_A749ConEntDsc = new string[] {""} ;
         T00563_A750ConEntSts = new short[1] ;
         T00563_A91CueCod = new string[] {""} ;
         sMode173 = "";
         T00568_A376ConEntCod = new int[1] ;
         T00569_A376ConEntCod = new int[1] ;
         T00562_A376ConEntCod = new int[1] ;
         T00562_A749ConEntDsc = new string[] {""} ;
         T00562_A750ConEntSts = new short[1] ;
         T00562_A91CueCod = new string[] {""} ;
         T005613_A365EntCod = new int[1] ;
         T005613_A403MVLEntCod = new string[] {""} ;
         T005613_A404MVLEITem = new int[1] ;
         T005614_A376ConEntCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ749ConEntDsc = "";
         ZZ91CueCod = "";
         T005615_A91CueCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsconceptoentrega__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsconceptoentrega__default(),
            new Object[][] {
                new Object[] {
               T00562_A376ConEntCod, T00562_A749ConEntDsc, T00562_A750ConEntSts, T00562_A91CueCod
               }
               , new Object[] {
               T00563_A376ConEntCod, T00563_A749ConEntDsc, T00563_A750ConEntSts, T00563_A91CueCod
               }
               , new Object[] {
               T00564_A91CueCod
               }
               , new Object[] {
               T00565_A376ConEntCod, T00565_A749ConEntDsc, T00565_A750ConEntSts, T00565_A91CueCod
               }
               , new Object[] {
               T00566_A91CueCod
               }
               , new Object[] {
               T00567_A376ConEntCod
               }
               , new Object[] {
               T00568_A376ConEntCod
               }
               , new Object[] {
               T00569_A376ConEntCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005613_A365EntCod, T005613_A403MVLEntCod, T005613_A404MVLEITem
               }
               , new Object[] {
               T005614_A376ConEntCod
               }
               , new Object[] {
               T005615_A91CueCod
               }
            }
         );
      }

      private short Z750ConEntSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A750ConEntSts ;
      private short GX_JID ;
      private short RcdFound173 ;
      private short nIsDirty_173 ;
      private short Gx_BScreen ;
      private short ZZ750ConEntSts ;
      private int Z376ConEntCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A376ConEntCod ;
      private int edtConEntCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtConEntDsc_Enabled ;
      private int edtCueCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ376ConEntCod ;
      private string sPrefix ;
      private string Z749ConEntDsc ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtConEntCod_Internalname ;
      private string cmbConEntSts_Internalname ;
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
      private string edtConEntCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtConEntDsc_Internalname ;
      private string A749ConEntDsc ;
      private string edtConEntDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbConEntSts_Jsonclick ;
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
      private string sMode173 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ749ConEntDsc ;
      private string ZZ91CueCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbConEntSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00565_A376ConEntCod ;
      private string[] T00565_A749ConEntDsc ;
      private short[] T00565_A750ConEntSts ;
      private string[] T00565_A91CueCod ;
      private string[] T00564_A91CueCod ;
      private string[] T00566_A91CueCod ;
      private int[] T00567_A376ConEntCod ;
      private int[] T00563_A376ConEntCod ;
      private string[] T00563_A749ConEntDsc ;
      private short[] T00563_A750ConEntSts ;
      private string[] T00563_A91CueCod ;
      private int[] T00568_A376ConEntCod ;
      private int[] T00569_A376ConEntCod ;
      private int[] T00562_A376ConEntCod ;
      private string[] T00562_A749ConEntDsc ;
      private short[] T00562_A750ConEntSts ;
      private string[] T00562_A91CueCod ;
      private int[] T005613_A365EntCod ;
      private string[] T005613_A403MVLEntCod ;
      private int[] T005613_A404MVLEITem ;
      private int[] T005614_A376ConEntCod ;
      private string[] T005615_A91CueCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tsconceptoentrega__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsconceptoentrega__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00565;
        prmT00565 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT00564;
        prmT00564 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00566;
        prmT00566 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00567;
        prmT00567 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT00563;
        prmT00563 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT00568;
        prmT00568 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT00569;
        prmT00569 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT00562;
        prmT00562 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005610;
        prmT005610 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0) ,
        new ParDef("@ConEntDsc",GXType.NChar,100,0) ,
        new ParDef("@ConEntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT005611;
        prmT005611 = new Object[] {
        new ParDef("@ConEntDsc",GXType.NChar,100,0) ,
        new ParDef("@ConEntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005612;
        prmT005612 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005613;
        prmT005613 = new Object[] {
        new ParDef("@ConEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005614;
        prmT005614 = new Object[] {
        };
        Object[] prmT005615;
        prmT005615 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00562", "SELECT [ConEntCod], [ConEntDsc], [ConEntSts], [CueCod] FROM [TSCONCEPTOENTREGA] WITH (UPDLOCK) WHERE [ConEntCod] = @ConEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00562,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00563", "SELECT [ConEntCod], [ConEntDsc], [ConEntSts], [CueCod] FROM [TSCONCEPTOENTREGA] WHERE [ConEntCod] = @ConEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00563,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00564", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00564,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00565", "SELECT TM1.[ConEntCod], TM1.[ConEntDsc], TM1.[ConEntSts], TM1.[CueCod] FROM [TSCONCEPTOENTREGA] TM1 WHERE TM1.[ConEntCod] = @ConEntCod ORDER BY TM1.[ConEntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00565,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00566", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00566,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00567", "SELECT [ConEntCod] FROM [TSCONCEPTOENTREGA] WHERE [ConEntCod] = @ConEntCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00567,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00568", "SELECT TOP 1 [ConEntCod] FROM [TSCONCEPTOENTREGA] WHERE ( [ConEntCod] > @ConEntCod) ORDER BY [ConEntCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00568,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00569", "SELECT TOP 1 [ConEntCod] FROM [TSCONCEPTOENTREGA] WHERE ( [ConEntCod] < @ConEntCod) ORDER BY [ConEntCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00569,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005610", "INSERT INTO [TSCONCEPTOENTREGA]([ConEntCod], [ConEntDsc], [ConEntSts], [CueCod]) VALUES(@ConEntCod, @ConEntDsc, @ConEntSts, @CueCod)", GxErrorMask.GX_NOMASK,prmT005610)
           ,new CursorDef("T005611", "UPDATE [TSCONCEPTOENTREGA] SET [ConEntDsc]=@ConEntDsc, [ConEntSts]=@ConEntSts, [CueCod]=@CueCod  WHERE [ConEntCod] = @ConEntCod", GxErrorMask.GX_NOMASK,prmT005611)
           ,new CursorDef("T005612", "DELETE FROM [TSCONCEPTOENTREGA]  WHERE [ConEntCod] = @ConEntCod", GxErrorMask.GX_NOMASK,prmT005612)
           ,new CursorDef("T005613", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLConcEntCod] = @ConEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005614", "SELECT [ConEntCod] FROM [TSCONCEPTOENTREGA] ORDER BY [ConEntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005614,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005615", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005615,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
