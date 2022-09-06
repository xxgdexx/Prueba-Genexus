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
   public class ctpersona : GXDataArea
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
            Form.Meta.addItem("description", "Tipo de Persona", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctpersona( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctpersona( IGxContext context )
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
         cmbTPerSts = new GXCombobox();
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
         if ( cmbTPerSts.ItemCount > 0 )
         {
            A1939TPerSts = (short)(NumberUtil.Val( cmbTPerSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0))), "."));
            AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTPerSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
            AssignProp("", false, cmbTPerSts_Internalname, "Values", cmbTPerSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTPERSONA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Tipo Persona", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPerCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A297TPerCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPerCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A297TPerCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A297TPerCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPerCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo Persona", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPerDsc_Internalname, StringUtil.RTrim( A1938TPerDsc), StringUtil.RTrim( context.localUtil.Format( A1938TPerDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPerDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPerDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abr. Tipo Persona", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPerAbr_Internalname, StringUtil.RTrim( A1937TPerAbr), StringUtil.RTrim( context.localUtil.Format( A1937TPerAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPerAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPerAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado T. Persona", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTPERSONA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTPerSts, cmbTPerSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0)), 1, cmbTPerSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTPerSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CTPERSONA.htm");
         cmbTPerSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         AssignProp("", false, cmbTPerSts_Internalname, "Values", (string)(cmbTPerSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTPERSONA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTPERSONA.htm");
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
            Z297TPerCod = (int)(context.localUtil.CToN( cgiGet( "Z297TPerCod"), ".", ","));
            Z1938TPerDsc = cgiGet( "Z1938TPerDsc");
            Z1937TPerAbr = cgiGet( "Z1937TPerAbr");
            Z1939TPerSts = (short)(context.localUtil.CToN( cgiGet( "Z1939TPerSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A297TPerCod = 0;
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            }
            else
            {
               A297TPerCod = (int)(context.localUtil.CToN( cgiGet( edtTPerCod_Internalname), ".", ","));
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            }
            A1938TPerDsc = cgiGet( edtTPerDsc_Internalname);
            AssignAttri("", false, "A1938TPerDsc", A1938TPerDsc);
            A1937TPerAbr = cgiGet( edtTPerAbr_Internalname);
            AssignAttri("", false, "A1937TPerAbr", A1937TPerAbr);
            cmbTPerSts.CurrentValue = cgiGet( cmbTPerSts_Internalname);
            A1939TPerSts = (short)(NumberUtil.Val( cgiGet( cmbTPerSts_Internalname), "."));
            AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
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
               A297TPerCod = (int)(NumberUtil.Val( GetPar( "TPerCod"), "."));
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
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
               InitAll3X136( ) ;
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
         DisableAttributes3X136( ) ;
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

      protected void CONFIRM_3X0( )
      {
         BeforeValidate3X136( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3X136( ) ;
            }
            else
            {
               CheckExtendedTable3X136( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3X136( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3X0( ) ;
         }
      }

      protected void ResetCaption3X0( )
      {
      }

      protected void ZM3X136( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1938TPerDsc = T003X3_A1938TPerDsc[0];
               Z1937TPerAbr = T003X3_A1937TPerAbr[0];
               Z1939TPerSts = T003X3_A1939TPerSts[0];
            }
            else
            {
               Z1938TPerDsc = A1938TPerDsc;
               Z1937TPerAbr = A1937TPerAbr;
               Z1939TPerSts = A1939TPerSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z297TPerCod = A297TPerCod;
            Z1938TPerDsc = A1938TPerDsc;
            Z1937TPerAbr = A1937TPerAbr;
            Z1939TPerSts = A1939TPerSts;
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

      protected void Load3X136( )
      {
         /* Using cursor T003X4 */
         pr_default.execute(2, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound136 = 1;
            A1938TPerDsc = T003X4_A1938TPerDsc[0];
            AssignAttri("", false, "A1938TPerDsc", A1938TPerDsc);
            A1937TPerAbr = T003X4_A1937TPerAbr[0];
            AssignAttri("", false, "A1937TPerAbr", A1937TPerAbr);
            A1939TPerSts = T003X4_A1939TPerSts[0];
            AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
            ZM3X136( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3X136( ) ;
      }

      protected void OnLoadActions3X136( )
      {
      }

      protected void CheckExtendedTable3X136( )
      {
         nIsDirty_136 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3X136( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3X136( )
      {
         /* Using cursor T003X5 */
         pr_default.execute(3, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound136 = 1;
         }
         else
         {
            RcdFound136 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003X3 */
         pr_default.execute(1, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3X136( 1) ;
            RcdFound136 = 1;
            A297TPerCod = T003X3_A297TPerCod[0];
            n297TPerCod = T003X3_n297TPerCod[0];
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            A1938TPerDsc = T003X3_A1938TPerDsc[0];
            AssignAttri("", false, "A1938TPerDsc", A1938TPerDsc);
            A1937TPerAbr = T003X3_A1937TPerAbr[0];
            AssignAttri("", false, "A1937TPerAbr", A1937TPerAbr);
            A1939TPerSts = T003X3_A1939TPerSts[0];
            AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
            Z297TPerCod = A297TPerCod;
            sMode136 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3X136( ) ;
            if ( AnyError == 1 )
            {
               RcdFound136 = 0;
               InitializeNonKey3X136( ) ;
            }
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound136 = 0;
            InitializeNonKey3X136( ) ;
            sMode136 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode136;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3X136( ) ;
         if ( RcdFound136 == 0 )
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
         RcdFound136 = 0;
         /* Using cursor T003X6 */
         pr_default.execute(4, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003X6_A297TPerCod[0] < A297TPerCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003X6_A297TPerCod[0] > A297TPerCod ) ) )
            {
               A297TPerCod = T003X6_A297TPerCod[0];
               n297TPerCod = T003X6_n297TPerCod[0];
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
               RcdFound136 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound136 = 0;
         /* Using cursor T003X7 */
         pr_default.execute(5, new Object[] {n297TPerCod, A297TPerCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003X7_A297TPerCod[0] > A297TPerCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003X7_A297TPerCod[0] < A297TPerCod ) ) )
            {
               A297TPerCod = T003X7_A297TPerCod[0];
               n297TPerCod = T003X7_n297TPerCod[0];
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
               RcdFound136 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3X136( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3X136( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound136 == 1 )
            {
               if ( A297TPerCod != Z297TPerCod )
               {
                  A297TPerCod = Z297TPerCod;
                  n297TPerCod = false;
                  AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3X136( ) ;
                  GX_FocusControl = edtTPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A297TPerCod != Z297TPerCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3X136( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPERCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTPerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTPerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3X136( ) ;
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
         if ( A297TPerCod != Z297TPerCod )
         {
            A297TPerCod = Z297TPerCod;
            n297TPerCod = false;
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPERCOD");
            AnyError = 1;
            GX_FocusControl = edtTPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTPerCod_Internalname;
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
         GetKey3X136( ) ;
         if ( RcdFound136 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A297TPerCod != Z297TPerCod )
            {
               A297TPerCod = Z297TPerCod;
               n297TPerCod = false;
               AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TPERCOD");
               AnyError = 1;
               GX_FocusControl = edtTPerCod_Internalname;
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
            if ( A297TPerCod != Z297TPerCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPerCod_Internalname;
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
         context.RollbackDataStores("ctpersona",pr_default);
         GX_FocusControl = edtTPerDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3X0( ) ;
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
         if ( RcdFound136 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TPERCOD");
            AnyError = 1;
            GX_FocusControl = edtTPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTPerDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3X136( ) ;
         if ( RcdFound136 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPerDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3X136( ) ;
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
         if ( RcdFound136 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPerDsc_Internalname;
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
         if ( RcdFound136 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPerDsc_Internalname;
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
         ScanStart3X136( ) ;
         if ( RcdFound136 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound136 != 0 )
            {
               ScanNext3X136( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPerDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3X136( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3X136( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003X2 */
            pr_default.execute(0, new Object[] {n297TPerCod, A297TPerCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTPERSONA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1938TPerDsc, T003X2_A1938TPerDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1937TPerAbr, T003X2_A1937TPerAbr[0]) != 0 ) || ( Z1939TPerSts != T003X2_A1939TPerSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1938TPerDsc, T003X2_A1938TPerDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctpersona:[seudo value changed for attri]"+"TPerDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1938TPerDsc);
                  GXUtil.WriteLogRaw("Current: ",T003X2_A1938TPerDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1937TPerAbr, T003X2_A1937TPerAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ctpersona:[seudo value changed for attri]"+"TPerAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1937TPerAbr);
                  GXUtil.WriteLogRaw("Current: ",T003X2_A1937TPerAbr[0]);
               }
               if ( Z1939TPerSts != T003X2_A1939TPerSts[0] )
               {
                  GXUtil.WriteLog("ctpersona:[seudo value changed for attri]"+"TPerSts");
                  GXUtil.WriteLogRaw("Old: ",Z1939TPerSts);
                  GXUtil.WriteLogRaw("Current: ",T003X2_A1939TPerSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTPERSONA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3X136( )
      {
         BeforeValidate3X136( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3X136( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3X136( 0) ;
            CheckOptimisticConcurrency3X136( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3X136( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3X136( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003X8 */
                     pr_default.execute(6, new Object[] {n297TPerCod, A297TPerCod, A1938TPerDsc, A1937TPerAbr, A1939TPerSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTPERSONA");
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
                           ResetCaption3X0( ) ;
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
               Load3X136( ) ;
            }
            EndLevel3X136( ) ;
         }
         CloseExtendedTableCursors3X136( ) ;
      }

      protected void Update3X136( )
      {
         BeforeValidate3X136( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3X136( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3X136( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3X136( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3X136( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003X9 */
                     pr_default.execute(7, new Object[] {A1938TPerDsc, A1937TPerAbr, A1939TPerSts, n297TPerCod, A297TPerCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTPERSONA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTPERSONA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3X136( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3X0( ) ;
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
            EndLevel3X136( ) ;
         }
         CloseExtendedTableCursors3X136( ) ;
      }

      protected void DeferredUpdate3X136( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3X136( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3X136( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3X136( ) ;
            AfterConfirm3X136( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3X136( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003X10 */
                  pr_default.execute(8, new Object[] {n297TPerCod, A297TPerCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTPERSONA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound136 == 0 )
                        {
                           InitAll3X136( ) ;
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
                        ResetCaption3X0( ) ;
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
         sMode136 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3X136( ) ;
         Gx_mode = sMode136;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3X136( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003X11 */
            pr_default.execute(9, new Object[] {n297TPerCod, A297TPerCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel3X136( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3X136( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctpersona",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctpersona",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3X136( )
      {
         /* Using cursor T003X12 */
         pr_default.execute(10);
         RcdFound136 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound136 = 1;
            A297TPerCod = T003X12_A297TPerCod[0];
            n297TPerCod = T003X12_n297TPerCod[0];
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3X136( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound136 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound136 = 1;
            A297TPerCod = T003X12_A297TPerCod[0];
            n297TPerCod = T003X12_n297TPerCod[0];
            AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
         }
      }

      protected void ScanEnd3X136( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm3X136( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3X136( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3X136( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3X136( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3X136( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3X136( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3X136( )
      {
         edtTPerCod_Enabled = 0;
         AssignProp("", false, edtTPerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPerCod_Enabled), 5, 0), true);
         edtTPerDsc_Enabled = 0;
         AssignProp("", false, edtTPerDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPerDsc_Enabled), 5, 0), true);
         edtTPerAbr_Enabled = 0;
         AssignProp("", false, edtTPerAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPerAbr_Enabled), 5, 0), true);
         cmbTPerSts.Enabled = 0;
         AssignProp("", false, cmbTPerSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTPerSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3X136( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3X0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252256", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctpersona.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z297TPerCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z297TPerCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1938TPerDsc", StringUtil.RTrim( Z1938TPerDsc));
         GxWebStd.gx_hidden_field( context, "Z1937TPerAbr", StringUtil.RTrim( Z1937TPerAbr));
         GxWebStd.gx_hidden_field( context, "Z1939TPerSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1939TPerSts), 1, 0, ".", "")));
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
         return formatLink("ctpersona.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CTPERSONA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Persona" ;
      }

      protected void InitializeNonKey3X136( )
      {
         A1938TPerDsc = "";
         AssignAttri("", false, "A1938TPerDsc", A1938TPerDsc);
         A1937TPerAbr = "";
         AssignAttri("", false, "A1937TPerAbr", A1937TPerAbr);
         A1939TPerSts = 0;
         AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         Z1938TPerDsc = "";
         Z1937TPerAbr = "";
         Z1939TPerSts = 0;
      }

      protected void InitAll3X136( )
      {
         A297TPerCod = 0;
         n297TPerCod = false;
         AssignAttri("", false, "A297TPerCod", StringUtil.LTrimStr( (decimal)(A297TPerCod), 6, 0));
         InitializeNonKey3X136( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252261", true, true);
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
         context.AddJavascriptSource("ctpersona.js", "?202281810252261", false, true);
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
         edtTPerCod_Internalname = "TPERCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTPerDsc_Internalname = "TPERDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTPerAbr_Internalname = "TPERABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbTPerSts_Internalname = "TPERSTS";
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
         Form.Caption = "Tipo de Persona";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbTPerSts_Jsonclick = "";
         cmbTPerSts.Enabled = 1;
         edtTPerAbr_Jsonclick = "";
         edtTPerAbr_Enabled = 1;
         edtTPerDsc_Jsonclick = "";
         edtTPerDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTPerCod_Jsonclick = "";
         edtTPerCod_Enabled = 1;
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
         cmbTPerSts.Name = "TPERSTS";
         cmbTPerSts.WebTags = "";
         cmbTPerSts.addItem("1", "ACTIVO", 0);
         cmbTPerSts.addItem("0", "INACTIVO", 0);
         if ( cmbTPerSts.ItemCount > 0 )
         {
            A1939TPerSts = (short)(NumberUtil.Val( cmbTPerSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0))), "."));
            AssignAttri("", false, "A1939TPerSts", StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTPerDsc_Internalname;
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

      public void Valid_Tpercod( )
      {
         A1939TPerSts = (short)(NumberUtil.Val( cmbTPerSts.CurrentValue, "."));
         cmbTPerSts.CurrentValue = StringUtil.Str( (decimal)(A1939TPerSts), 1, 0);
         n297TPerCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTPerSts.ItemCount > 0 )
         {
            A1939TPerSts = (short)(NumberUtil.Val( cmbTPerSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0))), "."));
            cmbTPerSts.CurrentValue = StringUtil.Str( (decimal)(A1939TPerSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTPerSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1938TPerDsc", StringUtil.RTrim( A1938TPerDsc));
         AssignAttri("", false, "A1937TPerAbr", StringUtil.RTrim( A1937TPerAbr));
         AssignAttri("", false, "A1939TPerSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1939TPerSts), 1, 0, ".", "")));
         cmbTPerSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1939TPerSts), 1, 0));
         AssignProp("", false, cmbTPerSts_Internalname, "Values", cmbTPerSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z297TPerCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z297TPerCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1938TPerDsc", StringUtil.RTrim( Z1938TPerDsc));
         GxWebStd.gx_hidden_field( context, "Z1937TPerAbr", StringUtil.RTrim( Z1937TPerAbr));
         GxWebStd.gx_hidden_field( context, "Z1939TPerSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1939TPerSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TPERCOD","{handler:'Valid_Tpercod',iparms:[{av:'cmbTPerSts'},{av:'A1939TPerSts',fld:'TPERSTS',pic:'9'},{av:'A297TPerCod',fld:'TPERCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TPERCOD",",oparms:[{av:'A1938TPerDsc',fld:'TPERDSC',pic:''},{av:'A1937TPerAbr',fld:'TPERABR',pic:''},{av:'cmbTPerSts'},{av:'A1939TPerSts',fld:'TPERSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z297TPerCod'},{av:'Z1938TPerDsc'},{av:'Z1937TPerAbr'},{av:'Z1939TPerSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1938TPerDsc = "";
         Z1937TPerAbr = "";
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
         A1938TPerDsc = "";
         lblTextblock3_Jsonclick = "";
         A1937TPerAbr = "";
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
         T003X4_A297TPerCod = new int[1] ;
         T003X4_n297TPerCod = new bool[] {false} ;
         T003X4_A1938TPerDsc = new string[] {""} ;
         T003X4_A1937TPerAbr = new string[] {""} ;
         T003X4_A1939TPerSts = new short[1] ;
         T003X5_A297TPerCod = new int[1] ;
         T003X5_n297TPerCod = new bool[] {false} ;
         T003X3_A297TPerCod = new int[1] ;
         T003X3_n297TPerCod = new bool[] {false} ;
         T003X3_A1938TPerDsc = new string[] {""} ;
         T003X3_A1937TPerAbr = new string[] {""} ;
         T003X3_A1939TPerSts = new short[1] ;
         sMode136 = "";
         T003X6_A297TPerCod = new int[1] ;
         T003X6_n297TPerCod = new bool[] {false} ;
         T003X7_A297TPerCod = new int[1] ;
         T003X7_n297TPerCod = new bool[] {false} ;
         T003X2_A297TPerCod = new int[1] ;
         T003X2_n297TPerCod = new bool[] {false} ;
         T003X2_A1938TPerDsc = new string[] {""} ;
         T003X2_A1937TPerAbr = new string[] {""} ;
         T003X2_A1939TPerSts = new short[1] ;
         T003X11_A244PrvCod = new string[] {""} ;
         T003X12_A297TPerCod = new int[1] ;
         T003X12_n297TPerCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1938TPerDsc = "";
         ZZ1937TPerAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctpersona__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctpersona__default(),
            new Object[][] {
                new Object[] {
               T003X2_A297TPerCod, T003X2_A1938TPerDsc, T003X2_A1937TPerAbr, T003X2_A1939TPerSts
               }
               , new Object[] {
               T003X3_A297TPerCod, T003X3_A1938TPerDsc, T003X3_A1937TPerAbr, T003X3_A1939TPerSts
               }
               , new Object[] {
               T003X4_A297TPerCod, T003X4_A1938TPerDsc, T003X4_A1937TPerAbr, T003X4_A1939TPerSts
               }
               , new Object[] {
               T003X5_A297TPerCod
               }
               , new Object[] {
               T003X6_A297TPerCod
               }
               , new Object[] {
               T003X7_A297TPerCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003X11_A244PrvCod
               }
               , new Object[] {
               T003X12_A297TPerCod
               }
            }
         );
      }

      private short Z1939TPerSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1939TPerSts ;
      private short GX_JID ;
      private short RcdFound136 ;
      private short nIsDirty_136 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1939TPerSts ;
      private int Z297TPerCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A297TPerCod ;
      private int edtTPerCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTPerDsc_Enabled ;
      private int edtTPerAbr_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ297TPerCod ;
      private string sPrefix ;
      private string Z1938TPerDsc ;
      private string Z1937TPerAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTPerCod_Internalname ;
      private string cmbTPerSts_Internalname ;
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
      private string edtTPerCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTPerDsc_Internalname ;
      private string A1938TPerDsc ;
      private string edtTPerDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTPerAbr_Internalname ;
      private string A1937TPerAbr ;
      private string edtTPerAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbTPerSts_Jsonclick ;
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
      private string sMode136 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1938TPerDsc ;
      private string ZZ1937TPerAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n297TPerCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTPerSts ;
      private IDataStoreProvider pr_default ;
      private int[] T003X4_A297TPerCod ;
      private bool[] T003X4_n297TPerCod ;
      private string[] T003X4_A1938TPerDsc ;
      private string[] T003X4_A1937TPerAbr ;
      private short[] T003X4_A1939TPerSts ;
      private int[] T003X5_A297TPerCod ;
      private bool[] T003X5_n297TPerCod ;
      private int[] T003X3_A297TPerCod ;
      private bool[] T003X3_n297TPerCod ;
      private string[] T003X3_A1938TPerDsc ;
      private string[] T003X3_A1937TPerAbr ;
      private short[] T003X3_A1939TPerSts ;
      private int[] T003X6_A297TPerCod ;
      private bool[] T003X6_n297TPerCod ;
      private int[] T003X7_A297TPerCod ;
      private bool[] T003X7_n297TPerCod ;
      private int[] T003X2_A297TPerCod ;
      private bool[] T003X2_n297TPerCod ;
      private string[] T003X2_A1938TPerDsc ;
      private string[] T003X2_A1937TPerAbr ;
      private short[] T003X2_A1939TPerSts ;
      private string[] T003X11_A244PrvCod ;
      private int[] T003X12_A297TPerCod ;
      private bool[] T003X12_n297TPerCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class ctpersona__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctpersona__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003X4;
        prmT003X4 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X5;
        prmT003X5 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X3;
        prmT003X3 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X6;
        prmT003X6 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X7;
        prmT003X7 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X2;
        prmT003X2 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X8;
        prmT003X8 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TPerDsc",GXType.NChar,100,0) ,
        new ParDef("@TPerAbr",GXType.NChar,5,0) ,
        new ParDef("@TPerSts",GXType.Int16,1,0)
        };
        Object[] prmT003X9;
        prmT003X9 = new Object[] {
        new ParDef("@TPerDsc",GXType.NChar,100,0) ,
        new ParDef("@TPerAbr",GXType.NChar,5,0) ,
        new ParDef("@TPerSts",GXType.Int16,1,0) ,
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X10;
        prmT003X10 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X11;
        prmT003X11 = new Object[] {
        new ParDef("@TPerCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003X12;
        prmT003X12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003X2", "SELECT [TPerCod], [TPerDsc], [TPerAbr], [TPerSts] FROM [CTPERSONA] WITH (UPDLOCK) WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003X3", "SELECT [TPerCod], [TPerDsc], [TPerAbr], [TPerSts] FROM [CTPERSONA] WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003X4", "SELECT TM1.[TPerCod], TM1.[TPerDsc], TM1.[TPerAbr], TM1.[TPerSts] FROM [CTPERSONA] TM1 WHERE TM1.[TPerCod] = @TPerCod ORDER BY TM1.[TPerCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003X4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003X5", "SELECT [TPerCod] FROM [CTPERSONA] WHERE [TPerCod] = @TPerCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003X6", "SELECT TOP 1 [TPerCod] FROM [CTPERSONA] WHERE ( [TPerCod] > @TPerCod) ORDER BY [TPerCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003X6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003X7", "SELECT TOP 1 [TPerCod] FROM [CTPERSONA] WHERE ( [TPerCod] < @TPerCod) ORDER BY [TPerCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003X7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003X8", "INSERT INTO [CTPERSONA]([TPerCod], [TPerDsc], [TPerAbr], [TPerSts]) VALUES(@TPerCod, @TPerDsc, @TPerAbr, @TPerSts)", GxErrorMask.GX_NOMASK,prmT003X8)
           ,new CursorDef("T003X9", "UPDATE [CTPERSONA] SET [TPerDsc]=@TPerDsc, [TPerAbr]=@TPerAbr, [TPerSts]=@TPerSts  WHERE [TPerCod] = @TPerCod", GxErrorMask.GX_NOMASK,prmT003X9)
           ,new CursorDef("T003X10", "DELETE FROM [CTPERSONA]  WHERE [TPerCod] = @TPerCod", GxErrorMask.GX_NOMASK,prmT003X10)
           ,new CursorDef("T003X11", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [TPerCod] = @TPerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003X11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003X12", "SELECT [TPerCod] FROM [CTPERSONA] ORDER BY [TPerCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003X12,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
