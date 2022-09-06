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
   public class cbauxiliares : GXDataArea
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
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A70TipACod) ;
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
            Form.Meta.addItem("description", "Auxiliares", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbauxiliares( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbauxiliares( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBAUXILIARES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Auxiliar", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipACod_Enabled!=0) ? context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipACod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Auxiliar", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADCod_Internalname, StringUtil.RTrim( A71TipADCod), StringUtil.RTrim( context.localUtil.Format( A71TipADCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipADCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Auxiliar", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADDsc_Internalname, StringUtil.RTrim( A72TipADDsc), StringUtil.RTrim( context.localUtil.Format( A72TipADDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipADDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBAUXILIARES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipADSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1901TipADSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipADSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1901TipADSts), "9") : context.localUtil.Format( (decimal)(A1901TipADSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipADSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipADSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBAUXILIARES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBAUXILIARES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBAUXILIARES.htm");
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
            Z70TipACod = (int)(context.localUtil.CToN( cgiGet( "Z70TipACod"), ".", ","));
            Z71TipADCod = cgiGet( "Z71TipADCod");
            Z72TipADDsc = cgiGet( "Z72TipADDsc");
            Z1901TipADSts = (short)(context.localUtil.CToN( cgiGet( "Z1901TipADSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A70TipACod = 0;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            }
            else
            {
               A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            }
            A71TipADCod = cgiGet( edtTipADCod_Internalname);
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
            A72TipADDsc = cgiGet( edtTipADDsc_Internalname);
            AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPADSTS");
               AnyError = 1;
               GX_FocusControl = edtTipADSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1901TipADSts = 0;
               AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
            }
            else
            {
               A1901TipADSts = (short)(context.localUtil.CToN( cgiGet( edtTipADSts_Internalname), ".", ","));
               AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
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
               A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = GetPar( "TipADCod");
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
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
               InitAll1M56( ) ;
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
         DisableAttributes1M56( ) ;
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

      protected void CONFIRM_1M0( )
      {
         BeforeValidate1M56( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1M56( ) ;
            }
            else
            {
               CheckExtendedTable1M56( ) ;
               if ( AnyError == 0 )
               {
                  ZM1M56( 2) ;
               }
               CloseExtendedTableCursors1M56( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1M0( ) ;
         }
      }

      protected void ResetCaption1M0( )
      {
      }

      protected void ZM1M56( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z72TipADDsc = T001M3_A72TipADDsc[0];
               Z1901TipADSts = T001M3_A1901TipADSts[0];
            }
            else
            {
               Z72TipADDsc = A72TipADDsc;
               Z1901TipADSts = A1901TipADSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z71TipADCod = A71TipADCod;
            Z72TipADDsc = A72TipADDsc;
            Z1901TipADSts = A1901TipADSts;
            Z70TipACod = A70TipACod;
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

      protected void Load1M56( )
      {
         /* Using cursor T001M5 */
         pr_default.execute(3, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
            A72TipADDsc = T001M5_A72TipADDsc[0];
            AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
            A1901TipADSts = T001M5_A1901TipADSts[0];
            AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
            ZM1M56( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1M56( ) ;
      }

      protected void OnLoadActions1M56( )
      {
      }

      protected void CheckExtendedTable1M56( )
      {
         nIsDirty_56 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001M4 */
         pr_default.execute(2, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1M56( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A70TipACod )
      {
         /* Using cursor T001M6 */
         pr_default.execute(4, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
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

      protected void GetKey1M56( )
      {
         /* Using cursor T001M7 */
         pr_default.execute(5, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001M3 */
         pr_default.execute(1, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M56( 1) ;
            RcdFound56 = 1;
            A71TipADCod = T001M3_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
            A72TipADDsc = T001M3_A72TipADDsc[0];
            AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
            A1901TipADSts = T001M3_A1901TipADSts[0];
            AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
            A70TipACod = T001M3_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            Z70TipACod = A70TipACod;
            Z71TipADCod = A71TipADCod;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1M56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1M56( ) ;
            }
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1M56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode56;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M56( ) ;
         if ( RcdFound56 == 0 )
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
         RcdFound56 = 0;
         /* Using cursor T001M8 */
         pr_default.execute(6, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001M8_A70TipACod[0] < A70TipACod ) || ( T001M8_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T001M8_A71TipADCod[0], A71TipADCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001M8_A70TipACod[0] > A70TipACod ) || ( T001M8_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T001M8_A71TipADCod[0], A71TipADCod) > 0 ) ) )
            {
               A70TipACod = T001M8_A70TipACod[0];
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = T001M8_A71TipADCod[0];
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound56 = 0;
         /* Using cursor T001M9 */
         pr_default.execute(7, new Object[] {A70TipACod, A71TipADCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001M9_A70TipACod[0] > A70TipACod ) || ( T001M9_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T001M9_A71TipADCod[0], A71TipADCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001M9_A70TipACod[0] < A70TipACod ) || ( T001M9_A70TipACod[0] == A70TipACod ) && ( StringUtil.StrCmp(T001M9_A71TipADCod[0], A71TipADCod) < 0 ) ) )
            {
               A70TipACod = T001M9_A70TipACod[0];
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = T001M9_A71TipADCod[0];
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               RcdFound56 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1M56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1M56( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
               {
                  A70TipACod = Z70TipACod;
                  AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
                  A71TipADCod = Z71TipADCod;
                  AssignAttri("", false, "A71TipADCod", A71TipADCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPACOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1M56( ) ;
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipACod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1M56( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPACOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipACod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipACod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1M56( ) ;
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
         if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
         {
            A70TipACod = Z70TipACod;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = Z71TipADCod;
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipACod_Internalname;
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
         GetKey1M56( ) ;
         if ( RcdFound56 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
            {
               A70TipACod = Z70TipACod;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
               A71TipADCod = Z71TipADCod;
               AssignAttri("", false, "A71TipADCod", A71TipADCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
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
            if ( ( A70TipACod != Z70TipACod ) || ( StringUtil.StrCmp(A71TipADCod, Z71TipADCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPACOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipACod_Internalname;
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
         context.RollbackDataStores("cbauxiliares",pr_default);
         GX_FocusControl = edtTipADDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1M0( ) ;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipADDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1M56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipADDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M56( ) ;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipADDsc_Internalname;
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
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipADDsc_Internalname;
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
         ScanStart1M56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound56 != 0 )
            {
               ScanNext1M56( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipADDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1M56( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1M56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001M2 */
            pr_default.execute(0, new Object[] {A70TipACod, A71TipADCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBAUXILIARES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z72TipADDsc, T001M2_A72TipADDsc[0]) != 0 ) || ( Z1901TipADSts != T001M2_A1901TipADSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z72TipADDsc, T001M2_A72TipADDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbauxiliares:[seudo value changed for attri]"+"TipADDsc");
                  GXUtil.WriteLogRaw("Old: ",Z72TipADDsc);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A72TipADDsc[0]);
               }
               if ( Z1901TipADSts != T001M2_A1901TipADSts[0] )
               {
                  GXUtil.WriteLog("cbauxiliares:[seudo value changed for attri]"+"TipADSts");
                  GXUtil.WriteLogRaw("Old: ",Z1901TipADSts);
                  GXUtil.WriteLogRaw("Current: ",T001M2_A1901TipADSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBAUXILIARES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M56( )
      {
         BeforeValidate1M56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M56( 0) ;
            CheckOptimisticConcurrency1M56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M10 */
                     pr_default.execute(8, new Object[] {A71TipADCod, A72TipADDsc, A1901TipADSts, A70TipACod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
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
                           ResetCaption1M0( ) ;
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
               Load1M56( ) ;
            }
            EndLevel1M56( ) ;
         }
         CloseExtendedTableCursors1M56( ) ;
      }

      protected void Update1M56( )
      {
         BeforeValidate1M56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001M11 */
                     pr_default.execute(9, new Object[] {A72TipADDsc, A1901TipADSts, A70TipACod, A71TipADCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBAUXILIARES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M56( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1M0( ) ;
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
            EndLevel1M56( ) ;
         }
         CloseExtendedTableCursors1M56( ) ;
      }

      protected void DeferredUpdate1M56( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1M56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M56( ) ;
            AfterConfirm1M56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001M12 */
                  pr_default.execute(10, new Object[] {A70TipACod, A71TipADCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBAUXILIARES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound56 == 0 )
                        {
                           InitAll1M56( ) ;
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
                        ResetCaption1M0( ) ;
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1M56( ) ;
         Gx_mode = sMode56;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1M56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1M56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M56( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbauxiliares",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbauxiliares",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1M56( )
      {
         /* Using cursor T001M13 */
         pr_default.execute(11);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A70TipACod = T001M13_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = T001M13_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1M56( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound56 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A70TipACod = T001M13_A70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A71TipADCod = T001M13_A71TipADCod[0];
            AssignAttri("", false, "A71TipADCod", A71TipADCod);
         }
      }

      protected void ScanEnd1M56( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1M56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M56( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M56( )
      {
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         edtTipADCod_Enabled = 0;
         AssignProp("", false, edtTipADCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADCod_Enabled), 5, 0), true);
         edtTipADDsc_Enabled = 0;
         AssignProp("", false, edtTipADDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADDsc_Enabled), 5, 0), true);
         edtTipADSts_Enabled = 0;
         AssignProp("", false, edtTipADSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipADSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1M56( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181024022", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbauxiliares.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71TipADCod", StringUtil.RTrim( Z71TipADCod));
         GxWebStd.gx_hidden_field( context, "Z72TipADDsc", StringUtil.RTrim( Z72TipADDsc));
         GxWebStd.gx_hidden_field( context, "Z1901TipADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1901TipADSts), 1, 0, ".", "")));
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
         return formatLink("cbauxiliares.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBAUXILIARES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Auxiliares" ;
      }

      protected void InitializeNonKey1M56( )
      {
         A72TipADDsc = "";
         AssignAttri("", false, "A72TipADDsc", A72TipADDsc);
         A1901TipADSts = 0;
         AssignAttri("", false, "A1901TipADSts", StringUtil.Str( (decimal)(A1901TipADSts), 1, 0));
         Z72TipADDsc = "";
         Z1901TipADSts = 0;
      }

      protected void InitAll1M56( )
      {
         A70TipACod = 0;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         A71TipADCod = "";
         AssignAttri("", false, "A71TipADCod", A71TipADCod);
         InitializeNonKey1M56( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024027", true, true);
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
         context.AddJavascriptSource("cbauxiliares.js", "?20228181024027", false, true);
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
         edtTipACod_Internalname = "TIPACOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipADCod_Internalname = "TIPADCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipADDsc_Internalname = "TIPADDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTipADSts_Internalname = "TIPADSTS";
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
         Form.Caption = "Auxiliares";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTipADSts_Jsonclick = "";
         edtTipADSts_Enabled = 1;
         edtTipADDsc_Jsonclick = "";
         edtTipADDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipADCod_Jsonclick = "";
         edtTipADCod_Enabled = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 1;
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
         /* Using cursor T001M14 */
         pr_default.execute(12, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtTipADDsc_Internalname;
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

      public void Valid_Tipacod( )
      {
         /* Using cursor T001M14 */
         pr_default.execute(12, new Object[] {A70TipACod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
            AnyError = 1;
            GX_FocusControl = edtTipACod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipadcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A72TipADDsc", StringUtil.RTrim( A72TipADDsc));
         AssignAttri("", false, "A1901TipADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1901TipADSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71TipADCod", StringUtil.RTrim( Z71TipADCod));
         GxWebStd.gx_hidden_field( context, "Z72TipADDsc", StringUtil.RTrim( Z72TipADDsc));
         GxWebStd.gx_hidden_field( context, "Z1901TipADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1901TipADSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
         setEventMetadata("VALID_TIPADCOD","{handler:'Valid_Tipadcod',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'},{av:'A71TipADCod',fld:'TIPADCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPADCOD",",oparms:[{av:'A72TipADDsc',fld:'TIPADDSC',pic:''},{av:'A1901TipADSts',fld:'TIPADSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z70TipACod'},{av:'Z71TipADCod'},{av:'Z72TipADDsc'},{av:'Z1901TipADSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z71TipADCod = "";
         Z72TipADDsc = "";
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
         lblTextblock2_Jsonclick = "";
         A71TipADCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A72TipADDsc = "";
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
         T001M5_A71TipADCod = new string[] {""} ;
         T001M5_A72TipADDsc = new string[] {""} ;
         T001M5_A1901TipADSts = new short[1] ;
         T001M5_A70TipACod = new int[1] ;
         T001M4_A70TipACod = new int[1] ;
         T001M6_A70TipACod = new int[1] ;
         T001M7_A70TipACod = new int[1] ;
         T001M7_A71TipADCod = new string[] {""} ;
         T001M3_A71TipADCod = new string[] {""} ;
         T001M3_A72TipADDsc = new string[] {""} ;
         T001M3_A1901TipADSts = new short[1] ;
         T001M3_A70TipACod = new int[1] ;
         sMode56 = "";
         T001M8_A70TipACod = new int[1] ;
         T001M8_A71TipADCod = new string[] {""} ;
         T001M9_A70TipACod = new int[1] ;
         T001M9_A71TipADCod = new string[] {""} ;
         T001M2_A71TipADCod = new string[] {""} ;
         T001M2_A72TipADDsc = new string[] {""} ;
         T001M2_A1901TipADSts = new short[1] ;
         T001M2_A70TipACod = new int[1] ;
         T001M13_A70TipACod = new int[1] ;
         T001M13_A71TipADCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001M14_A70TipACod = new int[1] ;
         ZZ71TipADCod = "";
         ZZ72TipADDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbauxiliares__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbauxiliares__default(),
            new Object[][] {
                new Object[] {
               T001M2_A71TipADCod, T001M2_A72TipADDsc, T001M2_A1901TipADSts, T001M2_A70TipACod
               }
               , new Object[] {
               T001M3_A71TipADCod, T001M3_A72TipADDsc, T001M3_A1901TipADSts, T001M3_A70TipACod
               }
               , new Object[] {
               T001M4_A70TipACod
               }
               , new Object[] {
               T001M5_A71TipADCod, T001M5_A72TipADDsc, T001M5_A1901TipADSts, T001M5_A70TipACod
               }
               , new Object[] {
               T001M6_A70TipACod
               }
               , new Object[] {
               T001M7_A70TipACod, T001M7_A71TipADCod
               }
               , new Object[] {
               T001M8_A70TipACod, T001M8_A71TipADCod
               }
               , new Object[] {
               T001M9_A70TipACod, T001M9_A71TipADCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001M13_A70TipACod, T001M13_A71TipADCod
               }
               , new Object[] {
               T001M14_A70TipACod
               }
            }
         );
      }

      private short Z1901TipADSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1901TipADSts ;
      private short GX_JID ;
      private short RcdFound56 ;
      private short nIsDirty_56 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1901TipADSts ;
      private int Z70TipACod ;
      private int A70TipACod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipACod_Enabled ;
      private int edtTipADCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipADDsc_Enabled ;
      private int edtTipADSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ70TipACod ;
      private string sPrefix ;
      private string Z71TipADCod ;
      private string Z72TipADDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipACod_Internalname ;
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
      private string edtTipACod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipADCod_Internalname ;
      private string A71TipADCod ;
      private string edtTipADCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipADDsc_Internalname ;
      private string A72TipADDsc ;
      private string edtTipADDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTipADSts_Internalname ;
      private string edtTipADSts_Jsonclick ;
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
      private string sMode56 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ71TipADCod ;
      private string ZZ72TipADDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001M5_A71TipADCod ;
      private string[] T001M5_A72TipADDsc ;
      private short[] T001M5_A1901TipADSts ;
      private int[] T001M5_A70TipACod ;
      private int[] T001M4_A70TipACod ;
      private int[] T001M6_A70TipACod ;
      private int[] T001M7_A70TipACod ;
      private string[] T001M7_A71TipADCod ;
      private string[] T001M3_A71TipADCod ;
      private string[] T001M3_A72TipADDsc ;
      private short[] T001M3_A1901TipADSts ;
      private int[] T001M3_A70TipACod ;
      private int[] T001M8_A70TipACod ;
      private string[] T001M8_A71TipADCod ;
      private int[] T001M9_A70TipACod ;
      private string[] T001M9_A71TipADCod ;
      private string[] T001M2_A71TipADCod ;
      private string[] T001M2_A72TipADDsc ;
      private short[] T001M2_A1901TipADSts ;
      private int[] T001M2_A70TipACod ;
      private int[] T001M13_A70TipACod ;
      private string[] T001M13_A71TipADCod ;
      private int[] T001M14_A70TipACod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbauxiliares__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbauxiliares__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001M5;
        prmT001M5 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M4;
        prmT001M4 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT001M6;
        prmT001M6 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT001M7;
        prmT001M7 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M3;
        prmT001M3 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M8;
        prmT001M8 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M9;
        prmT001M9 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M2;
        prmT001M2 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M10;
        prmT001M10 = new Object[] {
        new ParDef("@TipADCod",GXType.NChar,20,0) ,
        new ParDef("@TipADDsc",GXType.NChar,100,0) ,
        new ParDef("@TipADSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        Object[] prmT001M11;
        prmT001M11 = new Object[] {
        new ParDef("@TipADDsc",GXType.NChar,100,0) ,
        new ParDef("@TipADSts",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M12;
        prmT001M12 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0) ,
        new ParDef("@TipADCod",GXType.NChar,20,0)
        };
        Object[] prmT001M13;
        prmT001M13 = new Object[] {
        };
        Object[] prmT001M14;
        prmT001M14 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001M2", "SELECT [TipADCod], [TipADDsc], [TipADSts], [TipACod] FROM [CBAUXILIARES] WITH (UPDLOCK) WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M3", "SELECT [TipADCod], [TipADDsc], [TipADSts], [TipACod] FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M4", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M5", "SELECT TM1.[TipADCod], TM1.[TipADDsc], TM1.[TipADSts], TM1.[TipACod] FROM [CBAUXILIARES] TM1 WHERE TM1.[TipACod] = @TipACod and TM1.[TipADCod] = @TipADCod ORDER BY TM1.[TipACod], TM1.[TipADCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M6", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M7", "SELECT [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M8", "SELECT TOP 1 [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE ( [TipACod] > @TipACod or [TipACod] = @TipACod and [TipADCod] > @TipADCod) ORDER BY [TipACod], [TipADCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001M9", "SELECT TOP 1 [TipACod], [TipADCod] FROM [CBAUXILIARES] WHERE ( [TipACod] < @TipACod or [TipACod] = @TipACod and [TipADCod] < @TipADCod) ORDER BY [TipACod] DESC, [TipADCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001M10", "INSERT INTO [CBAUXILIARES]([TipADCod], [TipADDsc], [TipADSts], [TipACod]) VALUES(@TipADCod, @TipADDsc, @TipADSts, @TipACod)", GxErrorMask.GX_NOMASK,prmT001M10)
           ,new CursorDef("T001M11", "UPDATE [CBAUXILIARES] SET [TipADDsc]=@TipADDsc, [TipADSts]=@TipADSts  WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod", GxErrorMask.GX_NOMASK,prmT001M11)
           ,new CursorDef("T001M12", "DELETE FROM [CBAUXILIARES]  WHERE [TipACod] = @TipACod AND [TipADCod] = @TipADCod", GxErrorMask.GX_NOMASK,prmT001M12)
           ,new CursorDef("T001M13", "SELECT [TipACod], [TipADCod] FROM [CBAUXILIARES] ORDER BY [TipACod], [TipADCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001M13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001M14", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001M14,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
