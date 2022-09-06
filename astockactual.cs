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
   public class astockactual : GXDataArea
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
            A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A63AlmCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A28ProdCod) ;
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
            Form.Meta.addItem("description", "Stock Actual", 0) ;
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

      public astockactual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public astockactual( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ASTOCKACTUAL.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63AlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Producto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Descripcion producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Ingresos", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1881StkIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkIng_Enabled!=0) ? context.localUtil.Format( A1881StkIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1881StkIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Salidas", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkSal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1882StkSal, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkSal_Enabled!=0) ? context.localUtil.Format( A1882StkSal, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1882StkSal, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkSal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkSal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Stock", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtStkAct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1880StkAct, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkAct_Enabled!=0) ? context.localUtil.Format( A1880StkAct, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1880StkAct, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkAct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkAct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUAL.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ASTOCKACTUAL.htm");
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
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z1881StkIng = context.localUtil.CToN( cgiGet( "Z1881StkIng"), ".", ",");
            Z1882StkSal = context.localUtil.CToN( cgiGet( "Z1882StkSal"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
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
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A55ProdDsc = cgiGet( edtProdDsc_Internalname);
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtStkIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtStkIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STKING");
               AnyError = 1;
               GX_FocusControl = edtStkIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1881StkIng = 0;
               AssignAttri("", false, "A1881StkIng", StringUtil.LTrimStr( A1881StkIng, 15, 4));
            }
            else
            {
               A1881StkIng = context.localUtil.CToN( cgiGet( edtStkIng_Internalname), ".", ",");
               AssignAttri("", false, "A1881StkIng", StringUtil.LTrimStr( A1881StkIng, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtStkSal_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtStkSal_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STKSAL");
               AnyError = 1;
               GX_FocusControl = edtStkSal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1882StkSal = 0;
               AssignAttri("", false, "A1882StkSal", StringUtil.LTrimStr( A1882StkSal, 15, 4));
            }
            else
            {
               A1882StkSal = context.localUtil.CToN( cgiGet( edtStkSal_Internalname), ".", ",");
               AssignAttri("", false, "A1882StkSal", StringUtil.LTrimStr( A1882StkSal, 15, 4));
            }
            A1880StkAct = context.localUtil.CToN( cgiGet( edtStkAct_Internalname), ".", ",");
            AssignAttri("", false, "A1880StkAct", StringUtil.LTrimStr( A1880StkAct, 15, 4));
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
               A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = GetPar( "ProdCod");
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
               InitAll1F49( ) ;
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
         DisableAttributes1F49( ) ;
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

      protected void CONFIRM_1F0( )
      {
         BeforeValidate1F49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1F49( ) ;
            }
            else
            {
               CheckExtendedTable1F49( ) ;
               if ( AnyError == 0 )
               {
                  ZM1F49( 3) ;
                  ZM1F49( 4) ;
               }
               CloseExtendedTableCursors1F49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1F0( ) ;
         }
      }

      protected void ResetCaption1F0( )
      {
      }

      protected void ZM1F49( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1881StkIng = T001F3_A1881StkIng[0];
               Z1882StkSal = T001F3_A1882StkSal[0];
            }
            else
            {
               Z1881StkIng = A1881StkIng;
               Z1882StkSal = A1882StkSal;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1881StkIng = A1881StkIng;
            Z1882StkSal = A1882StkSal;
            Z63AlmCod = A63AlmCod;
            Z28ProdCod = A28ProdCod;
            Z55ProdDsc = A55ProdDsc;
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

      protected void Load1F49( )
      {
         /* Using cursor T001F6 */
         pr_default.execute(4, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound49 = 1;
            A55ProdDsc = T001F6_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1881StkIng = T001F6_A1881StkIng[0];
            AssignAttri("", false, "A1881StkIng", StringUtil.LTrimStr( A1881StkIng, 15, 4));
            A1882StkSal = T001F6_A1882StkSal[0];
            AssignAttri("", false, "A1882StkSal", StringUtil.LTrimStr( A1882StkSal, 15, 4));
            ZM1F49( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1F49( ) ;
      }

      protected void OnLoadActions1F49( )
      {
         A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
         AssignAttri("", false, "A1880StkAct", StringUtil.LTrimStr( A1880StkAct, 15, 4));
      }

      protected void CheckExtendedTable1F49( )
      {
         nIsDirty_49 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001F4 */
         pr_default.execute(2, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001F5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T001F5_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(3);
         nIsDirty_49 = 1;
         A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
         AssignAttri("", false, "A1880StkAct", StringUtil.LTrimStr( A1880StkAct, 15, 4));
      }

      protected void CloseExtendedTableCursors1F49( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A63AlmCod )
      {
         /* Using cursor T001F7 */
         pr_default.execute(5, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
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

      protected void gxLoad_4( string A28ProdCod )
      {
         /* Using cursor T001F8 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T001F8_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1F49( )
      {
         /* Using cursor T001F9 */
         pr_default.execute(7, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001F3 */
         pr_default.execute(1, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F49( 2) ;
            RcdFound49 = 1;
            A1881StkIng = T001F3_A1881StkIng[0];
            AssignAttri("", false, "A1881StkIng", StringUtil.LTrimStr( A1881StkIng, 15, 4));
            A1882StkSal = T001F3_A1882StkSal[0];
            AssignAttri("", false, "A1882StkSal", StringUtil.LTrimStr( A1882StkSal, 15, 4));
            A63AlmCod = T001F3_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001F3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z63AlmCod = A63AlmCod;
            Z28ProdCod = A28ProdCod;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1F49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1F49( ) ;
            }
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1F49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F49( ) ;
         if ( RcdFound49 == 0 )
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
         RcdFound49 = 0;
         /* Using cursor T001F10 */
         pr_default.execute(8, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001F10_A63AlmCod[0] < A63AlmCod ) || ( T001F10_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001F10_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001F10_A63AlmCod[0] > A63AlmCod ) || ( T001F10_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001F10_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A63AlmCod = T001F10_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = T001F10_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound49 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound49 = 0;
         /* Using cursor T001F11 */
         pr_default.execute(9, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001F11_A63AlmCod[0] > A63AlmCod ) || ( T001F11_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001F11_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001F11_A63AlmCod[0] < A63AlmCod ) || ( T001F11_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001F11_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A63AlmCod = T001F11_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = T001F11_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound49 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1F49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1F49( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
               {
                  A63AlmCod = Z63AlmCod;
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
                  Update1F49( ) ;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1F49( ) ;
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
                     Insert1F49( ) ;
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
         if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
         {
            A63AlmCod = Z63AlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
         GetKey1F49( ) ;
         if ( RcdFound49 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
            {
               A63AlmCod = Z63AlmCod;
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = Z28ProdCod;
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
            if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
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
         context.RollbackDataStores("astockactual",pr_default);
         GX_FocusControl = edtStkIng_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1F0( ) ;
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
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtStkIng_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1F49( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkIng_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F49( ) ;
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
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkIng_Internalname;
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
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkIng_Internalname;
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
         ScanStart1F49( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound49 != 0 )
            {
               ScanNext1F49( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkIng_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1F49( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1F49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001F2 */
            pr_default.execute(0, new Object[] {A63AlmCod, A28ProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASTOCKACTUAL"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1881StkIng != T001F2_A1881StkIng[0] ) || ( Z1882StkSal != T001F2_A1882StkSal[0] ) )
            {
               if ( Z1881StkIng != T001F2_A1881StkIng[0] )
               {
                  GXUtil.WriteLog("astockactual:[seudo value changed for attri]"+"StkIng");
                  GXUtil.WriteLogRaw("Old: ",Z1881StkIng);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A1881StkIng[0]);
               }
               if ( Z1882StkSal != T001F2_A1882StkSal[0] )
               {
                  GXUtil.WriteLog("astockactual:[seudo value changed for attri]"+"StkSal");
                  GXUtil.WriteLogRaw("Old: ",Z1882StkSal);
                  GXUtil.WriteLogRaw("Current: ",T001F2_A1882StkSal[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ASTOCKACTUAL"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F49( )
      {
         BeforeValidate1F49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F49( 0) ;
            CheckOptimisticConcurrency1F49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F12 */
                     pr_default.execute(10, new Object[] {A1881StkIng, A1882StkSal, A63AlmCod, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUAL");
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
                           ResetCaption1F0( ) ;
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
               Load1F49( ) ;
            }
            EndLevel1F49( ) ;
         }
         CloseExtendedTableCursors1F49( ) ;
      }

      protected void Update1F49( )
      {
         BeforeValidate1F49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001F13 */
                     pr_default.execute(11, new Object[] {A1881StkIng, A1882StkSal, A63AlmCod, A28ProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUAL");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASTOCKACTUAL"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F49( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1F0( ) ;
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
            EndLevel1F49( ) ;
         }
         CloseExtendedTableCursors1F49( ) ;
      }

      protected void DeferredUpdate1F49( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1F49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F49( ) ;
            AfterConfirm1F49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001F14 */
                  pr_default.execute(12, new Object[] {A63AlmCod, A28ProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUAL");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound49 == 0 )
                        {
                           InitAll1F49( ) ;
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
                        ResetCaption1F0( ) ;
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1F49( ) ;
         Gx_mode = sMode49;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1F49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001F15 */
            pr_default.execute(13, new Object[] {A28ProdCod});
            A55ProdDsc = T001F15_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            pr_default.close(13);
            A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
            AssignAttri("", false, "A1880StkAct", StringUtil.LTrimStr( A1880StkAct, 15, 4));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001F16 */
            pr_default.execute(14, new Object[] {A63AlmCod, A28ProdCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual Detalles"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel1F49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F49( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("astockactual",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("astockactual",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1F49( )
      {
         /* Using cursor T001F17 */
         pr_default.execute(15);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound49 = 1;
            A63AlmCod = T001F17_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001F17_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1F49( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound49 = 1;
            A63AlmCod = T001F17_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001F17_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd1F49( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1F49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F49( )
      {
         edtAlmCod_Enabled = 0;
         AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtStkIng_Enabled = 0;
         AssignProp("", false, edtStkIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkIng_Enabled), 5, 0), true);
         edtStkSal_Enabled = 0;
         AssignProp("", false, edtStkSal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkSal_Enabled), 5, 0), true);
         edtStkAct_Enabled = 0;
         AssignProp("", false, edtStkAct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkAct_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1F49( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465676", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("astockactual.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1881StkIng", StringUtil.LTrim( StringUtil.NToC( Z1881StkIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1882StkSal", StringUtil.LTrim( StringUtil.NToC( Z1882StkSal, 15, 4, ".", "")));
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
         return formatLink("astockactual.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ASTOCKACTUAL" ;
      }

      public override string GetPgmdesc( )
      {
         return "Stock Actual" ;
      }

      protected void InitializeNonKey1F49( )
      {
         A1880StkAct = 0;
         AssignAttri("", false, "A1880StkAct", StringUtil.LTrimStr( A1880StkAct, 15, 4));
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1881StkIng = 0;
         AssignAttri("", false, "A1881StkIng", StringUtil.LTrimStr( A1881StkIng, 15, 4));
         A1882StkSal = 0;
         AssignAttri("", false, "A1882StkSal", StringUtil.LTrimStr( A1882StkSal, 15, 4));
         Z1881StkIng = 0;
         Z1882StkSal = 0;
      }

      protected void InitAll1F49( )
      {
         A63AlmCod = 0;
         AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey1F49( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465679", true, true);
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
         context.AddJavascriptSource("astockactual.js", "?202281811465679", false, true);
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
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProdCod_Internalname = "PRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtStkIng_Internalname = "STKING";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtStkSal_Internalname = "STKSAL";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtStkAct_Internalname = "STKACT";
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
         Form.Caption = "Stock Actual";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtStkAct_Jsonclick = "";
         edtStkAct_Enabled = 0;
         edtStkSal_Jsonclick = "";
         edtStkSal_Enabled = 1;
         edtStkIng_Jsonclick = "";
         edtStkIng_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001F18 */
         pr_default.execute(16, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T001F15 */
         pr_default.execute(13, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T001F15_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(13);
         GX_FocusControl = edtStkIng_Internalname;
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
         /* Using cursor T001F18 */
         pr_default.execute(16, new Object[] {A63AlmCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001F15 */
         pr_default.execute(13, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A55ProdDsc = T001F15_A55ProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1881StkIng", StringUtil.LTrim( StringUtil.NToC( A1881StkIng, 15, 4, ".", "")));
         AssignAttri("", false, "A1882StkSal", StringUtil.LTrim( StringUtil.NToC( A1882StkSal, 15, 4, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A1880StkAct", StringUtil.LTrim( StringUtil.NToC( A1880StkAct, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1881StkIng", StringUtil.LTrim( StringUtil.NToC( Z1881StkIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1882StkSal", StringUtil.LTrim( StringUtil.NToC( Z1882StkSal, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1880StkAct", StringUtil.LTrim( StringUtil.NToC( Z1880StkAct, 15, 4, ".", "")));
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
         setEventMetadata("VALID_ALMCOD","{handler:'Valid_Almcod',iparms:[{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ALMCOD",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A1881StkIng',fld:'STKING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1882StkSal',fld:'STKSAL',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1880StkAct',fld:'STKACT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z63AlmCod'},{av:'Z28ProdCod'},{av:'Z1881StkIng'},{av:'Z1882StkSal'},{av:'Z55ProdDsc'},{av:'Z1880StkAct'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_STKING","{handler:'Valid_Stking',iparms:[]");
         setEventMetadata("VALID_STKING",",oparms:[]}");
         setEventMetadata("VALID_STKSAL","{handler:'Valid_Stksal',iparms:[]");
         setEventMetadata("VALID_STKSAL",",oparms:[]}");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A28ProdCod = "";
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
         A55ProdDsc = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
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
         Z55ProdDsc = "";
         T001F6_A55ProdDsc = new string[] {""} ;
         T001F6_A1881StkIng = new decimal[1] ;
         T001F6_A1882StkSal = new decimal[1] ;
         T001F6_A63AlmCod = new int[1] ;
         T001F6_A28ProdCod = new string[] {""} ;
         T001F4_A63AlmCod = new int[1] ;
         T001F5_A55ProdDsc = new string[] {""} ;
         T001F7_A63AlmCod = new int[1] ;
         T001F8_A55ProdDsc = new string[] {""} ;
         T001F9_A63AlmCod = new int[1] ;
         T001F9_A28ProdCod = new string[] {""} ;
         T001F3_A1881StkIng = new decimal[1] ;
         T001F3_A1882StkSal = new decimal[1] ;
         T001F3_A63AlmCod = new int[1] ;
         T001F3_A28ProdCod = new string[] {""} ;
         sMode49 = "";
         T001F10_A63AlmCod = new int[1] ;
         T001F10_A28ProdCod = new string[] {""} ;
         T001F11_A63AlmCod = new int[1] ;
         T001F11_A28ProdCod = new string[] {""} ;
         T001F2_A1881StkIng = new decimal[1] ;
         T001F2_A1882StkSal = new decimal[1] ;
         T001F2_A63AlmCod = new int[1] ;
         T001F2_A28ProdCod = new string[] {""} ;
         T001F15_A55ProdDsc = new string[] {""} ;
         T001F16_A63AlmCod = new int[1] ;
         T001F16_A28ProdCod = new string[] {""} ;
         T001F16_A64StkRef1 = new string[] {""} ;
         T001F17_A63AlmCod = new int[1] ;
         T001F17_A28ProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001F18_A63AlmCod = new int[1] ;
         ZZ28ProdCod = "";
         ZZ55ProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.astockactual__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.astockactual__default(),
            new Object[][] {
                new Object[] {
               T001F2_A1881StkIng, T001F2_A1882StkSal, T001F2_A63AlmCod, T001F2_A28ProdCod
               }
               , new Object[] {
               T001F3_A1881StkIng, T001F3_A1882StkSal, T001F3_A63AlmCod, T001F3_A28ProdCod
               }
               , new Object[] {
               T001F4_A63AlmCod
               }
               , new Object[] {
               T001F5_A55ProdDsc
               }
               , new Object[] {
               T001F6_A55ProdDsc, T001F6_A1881StkIng, T001F6_A1882StkSal, T001F6_A63AlmCod, T001F6_A28ProdCod
               }
               , new Object[] {
               T001F7_A63AlmCod
               }
               , new Object[] {
               T001F8_A55ProdDsc
               }
               , new Object[] {
               T001F9_A63AlmCod, T001F9_A28ProdCod
               }
               , new Object[] {
               T001F10_A63AlmCod, T001F10_A28ProdCod
               }
               , new Object[] {
               T001F11_A63AlmCod, T001F11_A28ProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001F15_A55ProdDsc
               }
               , new Object[] {
               T001F16_A63AlmCod, T001F16_A28ProdCod, T001F16_A64StkRef1
               }
               , new Object[] {
               T001F17_A63AlmCod, T001F17_A28ProdCod
               }
               , new Object[] {
               T001F18_A63AlmCod
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
      private short RcdFound49 ;
      private short nIsDirty_49 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z63AlmCod ;
      private int A63AlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAlmCod_Enabled ;
      private int edtProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtStkIng_Enabled ;
      private int edtStkSal_Enabled ;
      private int edtStkAct_Enabled ;
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
      private decimal Z1881StkIng ;
      private decimal Z1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal A1880StkAct ;
      private decimal Z1880StkAct ;
      private decimal ZZ1881StkIng ;
      private decimal ZZ1882StkSal ;
      private decimal ZZ1880StkAct ;
      private string sPrefix ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAlmCod_Internalname ;
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
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtStkIng_Internalname ;
      private string edtStkIng_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtStkSal_Internalname ;
      private string edtStkSal_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtStkAct_Internalname ;
      private string edtStkAct_Jsonclick ;
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
      private string Z55ProdDsc ;
      private string sMode49 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ28ProdCod ;
      private string ZZ55ProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001F6_A55ProdDsc ;
      private decimal[] T001F6_A1881StkIng ;
      private decimal[] T001F6_A1882StkSal ;
      private int[] T001F6_A63AlmCod ;
      private string[] T001F6_A28ProdCod ;
      private int[] T001F4_A63AlmCod ;
      private string[] T001F5_A55ProdDsc ;
      private int[] T001F7_A63AlmCod ;
      private string[] T001F8_A55ProdDsc ;
      private int[] T001F9_A63AlmCod ;
      private string[] T001F9_A28ProdCod ;
      private decimal[] T001F3_A1881StkIng ;
      private decimal[] T001F3_A1882StkSal ;
      private int[] T001F3_A63AlmCod ;
      private string[] T001F3_A28ProdCod ;
      private int[] T001F10_A63AlmCod ;
      private string[] T001F10_A28ProdCod ;
      private int[] T001F11_A63AlmCod ;
      private string[] T001F11_A28ProdCod ;
      private decimal[] T001F2_A1881StkIng ;
      private decimal[] T001F2_A1882StkSal ;
      private int[] T001F2_A63AlmCod ;
      private string[] T001F2_A28ProdCod ;
      private string[] T001F15_A55ProdDsc ;
      private int[] T001F16_A63AlmCod ;
      private string[] T001F16_A28ProdCod ;
      private string[] T001F16_A64StkRef1 ;
      private int[] T001F17_A63AlmCod ;
      private string[] T001F17_A28ProdCod ;
      private int[] T001F18_A63AlmCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class astockactual__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class astockactual__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001F6;
        prmT001F6 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F4;
        prmT001F4 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001F5;
        prmT001F5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F7;
        prmT001F7 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001F8;
        prmT001F8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F9;
        prmT001F9 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F3;
        prmT001F3 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F10;
        prmT001F10 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F11;
        prmT001F11 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F2;
        prmT001F2 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F12;
        prmT001F12 = new Object[] {
        new ParDef("@StkIng",GXType.Decimal,15,4) ,
        new ParDef("@StkSal",GXType.Decimal,15,4) ,
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F13;
        prmT001F13 = new Object[] {
        new ParDef("@StkIng",GXType.Decimal,15,4) ,
        new ParDef("@StkSal",GXType.Decimal,15,4) ,
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F14;
        prmT001F14 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F16;
        prmT001F16 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001F17;
        prmT001F17 = new Object[] {
        };
        Object[] prmT001F18;
        prmT001F18 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001F15;
        prmT001F15 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001F2", "SELECT [StkIng], [StkSal], [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WITH (UPDLOCK) WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F3", "SELECT [StkIng], [StkSal], [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F4", "SELECT [AlmCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F5", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F6", "SELECT T2.[ProdDsc], TM1.[StkIng], TM1.[StkSal], TM1.[AlmCod], TM1.[ProdCod] FROM ([ASTOCKACTUAL] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProdCod]) WHERE TM1.[AlmCod] = @AlmCod and TM1.[ProdCod] = @ProdCod ORDER BY TM1.[AlmCod], TM1.[ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F7", "SELECT [AlmCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F8", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F9", "SELECT [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F10", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE ( [AlmCod] > @AlmCod or [AlmCod] = @AlmCod and [ProdCod] > @ProdCod) ORDER BY [AlmCod], [ProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F11", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE ( [AlmCod] < @AlmCod or [AlmCod] = @AlmCod and [ProdCod] < @ProdCod) ORDER BY [AlmCod] DESC, [ProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F12", "INSERT INTO [ASTOCKACTUAL]([StkIng], [StkSal], [AlmCod], [ProdCod]) VALUES(@StkIng, @StkSal, @AlmCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT001F12)
           ,new CursorDef("T001F13", "UPDATE [ASTOCKACTUAL] SET [StkIng]=@StkIng, [StkSal]=@StkSal  WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001F13)
           ,new CursorDef("T001F14", "DELETE FROM [ASTOCKACTUAL]  WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001F14)
           ,new CursorDef("T001F15", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F16", "SELECT TOP 1 [AlmCod], [ProdCod], [StkRef1] FROM [ASTOCKACTUALDET] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001F17", "SELECT [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] ORDER BY [AlmCod], [ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001F17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001F18", "SELECT [AlmCod] FROM [CALMACEN] WHERE [AlmCod] = @AlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001F18,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
