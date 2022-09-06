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
   public class ctipocambio : GXHttpHandler
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
            A307TipMonCod = (int)(NumberUtil.Val( GetPar( "TipMonCod"), "."));
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A307TipMonCod) ;
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
            Form.Meta.addItem("description", "Tipos de Cambio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctipocambio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctipocambio( IGxContext context )
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
            RenderHtmlCloseForm3S131( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPOCAMBIO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Cambio Moneda", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A307TipMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A307TipMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Cambio Fecha", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTipFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTipFech_Internalname, context.localUtil.Format(A308TipFech, "99/99/99"), context.localUtil.Format( A308TipFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCAMBIO.htm");
         GxWebStd.gx_bitmap( context, edtTipFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTipFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Compra", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCompra_Internalname, StringUtil.LTrim( StringUtil.NToC( A1907TipCompra, 15, 5, ".", "")), StringUtil.LTrim( ((edtTipCompra_Enabled!=0) ? context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1907TipCompra, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCompra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCompra_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Venta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPOCAMBIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipVenta_Internalname, StringUtil.LTrim( StringUtil.NToC( A1920TipVenta, 15, 5, ".", "")), StringUtil.LTrim( ((edtTipVenta_Enabled!=0) ? context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1920TipVenta, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipVenta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipVenta_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPOCAMBIO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPOCAMBIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPOCAMBIO.htm");
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
            Z307TipMonCod = (int)(context.localUtil.CToN( cgiGet( "Z307TipMonCod"), ".", ","));
            Z308TipFech = context.localUtil.CToD( cgiGet( "Z308TipFech"), 0);
            Z1907TipCompra = context.localUtil.CToN( cgiGet( "Z1907TipCompra"), ".", ",");
            Z1920TipVenta = context.localUtil.CToN( cgiGet( "Z1920TipVenta"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtTipMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A307TipMonCod = 0;
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            }
            else
            {
               A307TipMonCod = (int)(context.localUtil.CToN( cgiGet( edtTipMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtTipFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tipo de Cambio Fecha"}), 1, "TIPFECH");
               AnyError = 1;
               GX_FocusControl = edtTipFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A308TipFech = DateTime.MinValue;
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            }
            else
            {
               A308TipFech = context.localUtil.CToD( cgiGet( edtTipFech_Internalname), 2);
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCOMPRA");
               AnyError = 1;
               GX_FocusControl = edtTipCompra_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1907TipCompra = 0;
               AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            }
            else
            {
               A1907TipCompra = context.localUtil.CToN( cgiGet( edtTipCompra_Internalname), ".", ",");
               AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPVENTA");
               AnyError = 1;
               GX_FocusControl = edtTipVenta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1920TipVenta = 0;
               AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
            }
            else
            {
               A1920TipVenta = context.localUtil.CToN( cgiGet( edtTipVenta_Internalname), ".", ",");
               AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
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
               A307TipMonCod = (int)(NumberUtil.Val( GetPar( "TipMonCod"), "."));
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = context.localUtil.ParseDateParm( GetPar( "TipFech"));
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
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
               InitAll3S131( ) ;
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
         DisableAttributes3S131( ) ;
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

      protected void CONFIRM_3S0( )
      {
         BeforeValidate3S131( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3S131( ) ;
            }
            else
            {
               CheckExtendedTable3S131( ) ;
               if ( AnyError == 0 )
               {
                  ZM3S131( 3) ;
               }
               CloseExtendedTableCursors3S131( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3S0( ) ;
         }
      }

      protected void ResetCaption3S0( )
      {
      }

      protected void ZM3S131( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1907TipCompra = T003S3_A1907TipCompra[0];
               Z1920TipVenta = T003S3_A1920TipVenta[0];
            }
            else
            {
               Z1907TipCompra = A1907TipCompra;
               Z1920TipVenta = A1920TipVenta;
            }
         }
         if ( GX_JID == -2 )
         {
            Z308TipFech = A308TipFech;
            Z1907TipCompra = A1907TipCompra;
            Z1920TipVenta = A1920TipVenta;
            Z307TipMonCod = A307TipMonCod;
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

      protected void Load3S131( )
      {
         /* Using cursor T003S5 */
         pr_default.execute(3, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound131 = 1;
            A1907TipCompra = T003S5_A1907TipCompra[0];
            AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            A1920TipVenta = T003S5_A1920TipVenta[0];
            AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
            ZM3S131( -2) ;
         }
         pr_default.close(3);
         OnLoadActions3S131( ) ;
      }

      protected void OnLoadActions3S131( )
      {
      }

      protected void CheckExtendedTable3S131( )
      {
         nIsDirty_131 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003S4 */
         pr_default.execute(2, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A308TipFech) || ( DateTimeUtil.ResetTime ( A308TipFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tipo de Cambio Fecha fuera de rango", "OutOfRange", 1, "TIPFECH");
            AnyError = 1;
            GX_FocusControl = edtTipFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3S131( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A307TipMonCod )
      {
         /* Using cursor T003S6 */
         pr_default.execute(4, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
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

      protected void GetKey3S131( )
      {
         /* Using cursor T003S7 */
         pr_default.execute(5, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound131 = 1;
         }
         else
         {
            RcdFound131 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003S3 */
         pr_default.execute(1, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3S131( 2) ;
            RcdFound131 = 1;
            A308TipFech = T003S3_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            A1907TipCompra = T003S3_A1907TipCompra[0];
            AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
            A1920TipVenta = T003S3_A1920TipVenta[0];
            AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
            A307TipMonCod = T003S3_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            Z307TipMonCod = A307TipMonCod;
            Z308TipFech = A308TipFech;
            sMode131 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3S131( ) ;
            if ( AnyError == 1 )
            {
               RcdFound131 = 0;
               InitializeNonKey3S131( ) ;
            }
            Gx_mode = sMode131;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound131 = 0;
            InitializeNonKey3S131( ) ;
            sMode131 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode131;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3S131( ) ;
         if ( RcdFound131 == 0 )
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
         RcdFound131 = 0;
         /* Using cursor T003S8 */
         pr_default.execute(6, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T003S8_A307TipMonCod[0] < A307TipMonCod ) || ( T003S8_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T003S8_A308TipFech[0] ) < DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T003S8_A307TipMonCod[0] > A307TipMonCod ) || ( T003S8_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T003S8_A308TipFech[0] ) > DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               A307TipMonCod = T003S8_A307TipMonCod[0];
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = T003S8_A308TipFech[0];
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               RcdFound131 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound131 = 0;
         /* Using cursor T003S9 */
         pr_default.execute(7, new Object[] {A307TipMonCod, A308TipFech});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T003S9_A307TipMonCod[0] > A307TipMonCod ) || ( T003S9_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T003S9_A308TipFech[0] ) > DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T003S9_A307TipMonCod[0] < A307TipMonCod ) || ( T003S9_A307TipMonCod[0] == A307TipMonCod ) && ( DateTimeUtil.ResetTime ( T003S9_A308TipFech[0] ) < DateTimeUtil.ResetTime ( A308TipFech ) ) ) )
            {
               A307TipMonCod = T003S9_A307TipMonCod[0];
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = T003S9_A308TipFech[0];
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               RcdFound131 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3S131( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3S131( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound131 == 1 )
            {
               if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
               {
                  A307TipMonCod = Z307TipMonCod;
                  AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
                  A308TipFech = Z308TipFech;
                  AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPMONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3S131( ) ;
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3S131( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPMONCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3S131( ) ;
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
         if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
         {
            A307TipMonCod = Z307TipMonCod;
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = Z308TipFech;
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipMonCod_Internalname;
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
         GetKey3S131( ) ;
         if ( RcdFound131 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtTipMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
            {
               A307TipMonCod = Z307TipMonCod;
               AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
               A308TipFech = Z308TipFech;
               AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtTipMonCod_Internalname;
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
            if ( ( A307TipMonCod != Z307TipMonCod ) || ( DateTimeUtil.ResetTime ( A308TipFech ) != DateTimeUtil.ResetTime ( Z308TipFech ) ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPMONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipMonCod_Internalname;
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
         context.RollbackDataStores("ctipocambio",pr_default);
         GX_FocusControl = edtTipCompra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3S0( ) ;
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
         if ( RcdFound131 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipCompra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3S131( ) ;
         if ( RcdFound131 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCompra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3S131( ) ;
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
         if ( RcdFound131 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCompra_Internalname;
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
         if ( RcdFound131 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCompra_Internalname;
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
         ScanStart3S131( ) ;
         if ( RcdFound131 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound131 != 0 )
            {
               ScanNext3S131( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCompra_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3S131( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3S131( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003S2 */
            pr_default.execute(0, new Object[] {A307TipMonCod, A308TipFech});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCAMBIO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1907TipCompra != T003S2_A1907TipCompra[0] ) || ( Z1920TipVenta != T003S2_A1920TipVenta[0] ) )
            {
               if ( Z1907TipCompra != T003S2_A1907TipCompra[0] )
               {
                  GXUtil.WriteLog("ctipocambio:[seudo value changed for attri]"+"TipCompra");
                  GXUtil.WriteLogRaw("Old: ",Z1907TipCompra);
                  GXUtil.WriteLogRaw("Current: ",T003S2_A1907TipCompra[0]);
               }
               if ( Z1920TipVenta != T003S2_A1920TipVenta[0] )
               {
                  GXUtil.WriteLog("ctipocambio:[seudo value changed for attri]"+"TipVenta");
                  GXUtil.WriteLogRaw("Old: ",Z1920TipVenta);
                  GXUtil.WriteLogRaw("Current: ",T003S2_A1920TipVenta[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOCAMBIO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3S131( )
      {
         BeforeValidate3S131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3S131( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3S131( 0) ;
            CheckOptimisticConcurrency3S131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3S131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3S131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003S10 */
                     pr_default.execute(8, new Object[] {A308TipFech, A1907TipCompra, A1920TipVenta, A307TipMonCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
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
                           ResetCaption3S0( ) ;
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
               Load3S131( ) ;
            }
            EndLevel3S131( ) ;
         }
         CloseExtendedTableCursors3S131( ) ;
      }

      protected void Update3S131( )
      {
         BeforeValidate3S131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3S131( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3S131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3S131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3S131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003S11 */
                     pr_default.execute(9, new Object[] {A1907TipCompra, A1920TipVenta, A307TipMonCod, A308TipFech});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOCAMBIO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3S131( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3S0( ) ;
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
            EndLevel3S131( ) ;
         }
         CloseExtendedTableCursors3S131( ) ;
      }

      protected void DeferredUpdate3S131( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3S131( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3S131( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3S131( ) ;
            AfterConfirm3S131( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3S131( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003S12 */
                  pr_default.execute(10, new Object[] {A307TipMonCod, A308TipFech});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOCAMBIO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound131 == 0 )
                        {
                           InitAll3S131( ) ;
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
                        ResetCaption3S0( ) ;
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
         sMode131 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3S131( ) ;
         Gx_mode = sMode131;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3S131( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel3S131( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3S131( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctipocambio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctipocambio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3S131( )
      {
         /* Using cursor T003S13 */
         pr_default.execute(11);
         RcdFound131 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound131 = 1;
            A307TipMonCod = T003S13_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = T003S13_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3S131( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound131 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound131 = 1;
            A307TipMonCod = T003S13_A307TipMonCod[0];
            AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
            A308TipFech = T003S13_A308TipFech[0];
            AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         }
      }

      protected void ScanEnd3S131( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm3S131( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3S131( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3S131( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3S131( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3S131( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3S131( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3S131( )
      {
         edtTipMonCod_Enabled = 0;
         AssignProp("", false, edtTipMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipMonCod_Enabled), 5, 0), true);
         edtTipFech_Enabled = 0;
         AssignProp("", false, edtTipFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipFech_Enabled), 5, 0), true);
         edtTipCompra_Enabled = 0;
         AssignProp("", false, edtTipCompra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCompra_Enabled), 5, 0), true);
         edtTipVenta_Enabled = 0;
         AssignProp("", false, edtTipVenta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipVenta_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3S131( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3S0( )
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
         context.SendWebValue( "Tipos de Cambio") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251848", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctipocambio.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z307TipMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z307TipMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z308TipFech", context.localUtil.DToC( Z308TipFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1907TipCompra", StringUtil.LTrim( StringUtil.NToC( Z1907TipCompra, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1920TipVenta", StringUtil.LTrim( StringUtil.NToC( Z1920TipVenta, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3S131( )
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
         return "CTIPOCAMBIO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Cambio" ;
      }

      protected void InitializeNonKey3S131( )
      {
         A1907TipCompra = 0;
         AssignAttri("", false, "A1907TipCompra", StringUtil.LTrimStr( A1907TipCompra, 15, 5));
         A1920TipVenta = 0;
         AssignAttri("", false, "A1920TipVenta", StringUtil.LTrimStr( A1920TipVenta, 15, 5));
         Z1907TipCompra = 0;
         Z1920TipVenta = 0;
      }

      protected void InitAll3S131( )
      {
         A307TipMonCod = 0;
         AssignAttri("", false, "A307TipMonCod", StringUtil.LTrimStr( (decimal)(A307TipMonCod), 6, 0));
         A308TipFech = DateTime.MinValue;
         AssignAttri("", false, "A308TipFech", context.localUtil.Format(A308TipFech, "99/99/99"));
         InitializeNonKey3S131( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251853", true, true);
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
         context.AddJavascriptSource("ctipocambio.js", "?202281810251853", false, true);
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
         edtTipMonCod_Internalname = "TIPMONCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipFech_Internalname = "TIPFECH";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipCompra_Internalname = "TIPCOMPRA";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTipVenta_Internalname = "TIPVENTA";
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
         edtTipVenta_Jsonclick = "";
         edtTipVenta_Enabled = 1;
         edtTipCompra_Jsonclick = "";
         edtTipCompra_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipFech_Jsonclick = "";
         edtTipFech_Enabled = 1;
         edtTipMonCod_Jsonclick = "";
         edtTipMonCod_Enabled = 1;
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
         /* Using cursor T003S14 */
         pr_default.execute(12, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtTipCompra_Internalname;
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

      public void Valid_Tipmoncod( )
      {
         /* Using cursor T003S14 */
         pr_default.execute(12, new Object[] {A307TipMonCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "TIPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtTipMonCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipfech( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         if ( ! ( (DateTime.MinValue==A308TipFech) || ( DateTimeUtil.ResetTime ( A308TipFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Tipo de Cambio Fecha fuera de rango", "OutOfRange", 1, "TIPFECH");
            AnyError = 1;
            GX_FocusControl = edtTipFech_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1907TipCompra", StringUtil.LTrim( StringUtil.NToC( A1907TipCompra, 15, 5, ".", "")));
         AssignAttri("", false, "A1920TipVenta", StringUtil.LTrim( StringUtil.NToC( A1920TipVenta, 15, 5, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z307TipMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z307TipMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z308TipFech", context.localUtil.Format(Z308TipFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1907TipCompra", StringUtil.LTrim( StringUtil.NToC( Z1907TipCompra, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1920TipVenta", StringUtil.LTrim( StringUtil.NToC( Z1920TipVenta, 15, 5, ".", "")));
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
         setEventMetadata("VALID_TIPMONCOD","{handler:'Valid_Tipmoncod',iparms:[{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPMONCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPFECH","{handler:'Valid_Tipfech',iparms:[{av:'A307TipMonCod',fld:'TIPMONCOD',pic:'ZZZZZ9'},{av:'A308TipFech',fld:'TIPFECH',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPFECH",",oparms:[{av:'A1907TipCompra',fld:'TIPCOMPRA',pic:'ZZZZZZZZ9.99999'},{av:'A1920TipVenta',fld:'TIPVENTA',pic:'ZZZZZZZZ9.99999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z307TipMonCod'},{av:'Z308TipFech'},{av:'Z1907TipCompra'},{av:'Z1920TipVenta'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z308TipFech = DateTime.MinValue;
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
         A308TipFech = DateTime.MinValue;
         bttBtn_get_Jsonclick = "";
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
         T003S5_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S5_A1907TipCompra = new decimal[1] ;
         T003S5_A1920TipVenta = new decimal[1] ;
         T003S5_A307TipMonCod = new int[1] ;
         T003S4_A307TipMonCod = new int[1] ;
         T003S6_A307TipMonCod = new int[1] ;
         T003S7_A307TipMonCod = new int[1] ;
         T003S7_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S3_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S3_A1907TipCompra = new decimal[1] ;
         T003S3_A1920TipVenta = new decimal[1] ;
         T003S3_A307TipMonCod = new int[1] ;
         sMode131 = "";
         T003S8_A307TipMonCod = new int[1] ;
         T003S8_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S9_A307TipMonCod = new int[1] ;
         T003S9_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S2_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T003S2_A1907TipCompra = new decimal[1] ;
         T003S2_A1920TipVenta = new decimal[1] ;
         T003S2_A307TipMonCod = new int[1] ;
         T003S13_A307TipMonCod = new int[1] ;
         T003S13_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003S14_A307TipMonCod = new int[1] ;
         ZZ308TipFech = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctipocambio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctipocambio__default(),
            new Object[][] {
                new Object[] {
               T003S2_A308TipFech, T003S2_A1907TipCompra, T003S2_A1920TipVenta, T003S2_A307TipMonCod
               }
               , new Object[] {
               T003S3_A308TipFech, T003S3_A1907TipCompra, T003S3_A1920TipVenta, T003S3_A307TipMonCod
               }
               , new Object[] {
               T003S4_A307TipMonCod
               }
               , new Object[] {
               T003S5_A308TipFech, T003S5_A1907TipCompra, T003S5_A1920TipVenta, T003S5_A307TipMonCod
               }
               , new Object[] {
               T003S6_A307TipMonCod
               }
               , new Object[] {
               T003S7_A307TipMonCod, T003S7_A308TipFech
               }
               , new Object[] {
               T003S8_A307TipMonCod, T003S8_A308TipFech
               }
               , new Object[] {
               T003S9_A307TipMonCod, T003S9_A308TipFech
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003S13_A307TipMonCod, T003S13_A308TipFech
               }
               , new Object[] {
               T003S14_A307TipMonCod
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
      private short nDynComponent ;
      private short GX_JID ;
      private short RcdFound131 ;
      private short nIsDirty_131 ;
      private short Gx_BScreen ;
      private int Z307TipMonCod ;
      private int A307TipMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipMonCod_Enabled ;
      private int edtTipFech_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipCompra_Enabled ;
      private int edtTipVenta_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ307TipMonCod ;
      private decimal Z1907TipCompra ;
      private decimal Z1920TipVenta ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private decimal ZZ1907TipCompra ;
      private decimal ZZ1920TipVenta ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipMonCod_Internalname ;
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
      private string edtTipMonCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipFech_Internalname ;
      private string edtTipFech_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipCompra_Internalname ;
      private string edtTipCompra_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTipVenta_Internalname ;
      private string edtTipVenta_Jsonclick ;
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
      private string sMode131 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z308TipFech ;
      private DateTime A308TipFech ;
      private DateTime ZZ308TipFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T003S5_A308TipFech ;
      private decimal[] T003S5_A1907TipCompra ;
      private decimal[] T003S5_A1920TipVenta ;
      private int[] T003S5_A307TipMonCod ;
      private int[] T003S4_A307TipMonCod ;
      private int[] T003S6_A307TipMonCod ;
      private int[] T003S7_A307TipMonCod ;
      private DateTime[] T003S7_A308TipFech ;
      private DateTime[] T003S3_A308TipFech ;
      private decimal[] T003S3_A1907TipCompra ;
      private decimal[] T003S3_A1920TipVenta ;
      private int[] T003S3_A307TipMonCod ;
      private int[] T003S8_A307TipMonCod ;
      private DateTime[] T003S8_A308TipFech ;
      private int[] T003S9_A307TipMonCod ;
      private DateTime[] T003S9_A308TipFech ;
      private DateTime[] T003S2_A308TipFech ;
      private decimal[] T003S2_A1907TipCompra ;
      private decimal[] T003S2_A1920TipVenta ;
      private int[] T003S2_A307TipMonCod ;
      private int[] T003S13_A307TipMonCod ;
      private DateTime[] T003S13_A308TipFech ;
      private int[] T003S14_A307TipMonCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ctipocambio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctipocambio__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003S5;
        prmT003S5 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S4;
        prmT003S4 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003S6;
        prmT003S6 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003S7;
        prmT003S7 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S3;
        prmT003S3 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S8;
        prmT003S8 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S9;
        prmT003S9 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S2;
        prmT003S2 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S10;
        prmT003S10 = new Object[] {
        new ParDef("@TipFech",GXType.Date,8,0) ,
        new ParDef("@TipCompra",GXType.Decimal,15,5) ,
        new ParDef("@TipVenta",GXType.Decimal,15,5) ,
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003S11;
        prmT003S11 = new Object[] {
        new ParDef("@TipCompra",GXType.Decimal,15,5) ,
        new ParDef("@TipVenta",GXType.Decimal,15,5) ,
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S12;
        prmT003S12 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0) ,
        new ParDef("@TipFech",GXType.Date,8,0)
        };
        Object[] prmT003S13;
        prmT003S13 = new Object[] {
        };
        Object[] prmT003S14;
        prmT003S14 = new Object[] {
        new ParDef("@TipMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003S2", "SELECT [TipFech], [TipCompra], [TipVenta], [TipMonCod] AS TipMonCod FROM [CTIPOCAMBIO] WITH (UPDLOCK) WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech ",true, GxErrorMask.GX_NOMASK, false, this,prmT003S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S3", "SELECT [TipFech], [TipCompra], [TipVenta], [TipMonCod] AS TipMonCod FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech ",true, GxErrorMask.GX_NOMASK, false, this,prmT003S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S4", "SELECT [MonCod] AS TipMonCod FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S5", "SELECT TM1.[TipFech], TM1.[TipCompra], TM1.[TipVenta], TM1.[TipMonCod] AS TipMonCod FROM [CTIPOCAMBIO] TM1 WHERE TM1.[TipMonCod] = @TipMonCod and TM1.[TipFech] = @TipFech ORDER BY TM1.[TipMonCod], TM1.[TipFech]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S6", "SELECT [MonCod] AS TipMonCod FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S7", "SELECT [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S8", "SELECT TOP 1 [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE ( [TipMonCod] > @TipMonCod or [TipMonCod] = @TipMonCod and [TipFech] > @TipFech) ORDER BY [TipMonCod], [TipFech]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003S8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003S9", "SELECT TOP 1 [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] WHERE ( [TipMonCod] < @TipMonCod or [TipMonCod] = @TipMonCod and [TipFech] < @TipFech) ORDER BY [TipMonCod] DESC, [TipFech] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003S9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003S10", "INSERT INTO [CTIPOCAMBIO]([TipFech], [TipCompra], [TipVenta], [TipMonCod]) VALUES(@TipFech, @TipCompra, @TipVenta, @TipMonCod)", GxErrorMask.GX_NOMASK,prmT003S10)
           ,new CursorDef("T003S11", "UPDATE [CTIPOCAMBIO] SET [TipCompra]=@TipCompra, [TipVenta]=@TipVenta  WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech", GxErrorMask.GX_NOMASK,prmT003S11)
           ,new CursorDef("T003S12", "DELETE FROM [CTIPOCAMBIO]  WHERE [TipMonCod] = @TipMonCod AND [TipFech] = @TipFech", GxErrorMask.GX_NOMASK,prmT003S12)
           ,new CursorDef("T003S13", "SELECT [TipMonCod] AS TipMonCod, [TipFech] FROM [CTIPOCAMBIO] ORDER BY [TipMonCod], [TipFech]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003S13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003S14", "SELECT [MonCod] AS TipMonCod FROM [CMONEDAS] WHERE [MonCod] = @TipMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003S14,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
