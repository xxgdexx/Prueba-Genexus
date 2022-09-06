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
   public class poserviciodet : GXDataArea
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
            A329PSerCod = GetPar( "PSerCod");
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A329PSerCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A336PSerDProdCod = GetPar( "PSerDProdCod");
            AssignAttri("", false, "A336PSerDProdCod", A336PSerDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A336PSerDProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A1808PSerLinCod = (int)(NumberUtil.Val( GetPar( "PSerLinCod"), "."));
            AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A1808PSerLinCod) ;
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
            Form.Meta.addItem("description", "Orden de Servicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poserviciodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poserviciodet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POSERVICIODET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCod_Internalname, StringUtil.RTrim( A329PSerCod), StringUtil.RTrim( context.localUtil.Format( A329PSerCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A335PSerDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtPSerDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A335PSerDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A335PSerDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDProdCod_Internalname, StringUtil.RTrim( A336PSerDProdCod), StringUtil.RTrim( context.localUtil.Format( A336PSerDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPSerDProdDsc_Internalname, StringUtil.RTrim( A1804PSerDProdDsc), StringUtil.RTrim( context.localUtil.Format( A1804PSerDProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Linea", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPSerLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1808PSerLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPSerLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1808PSerLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1808PSerLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Stock", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPSerLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1810PSerLinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtPSerLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1810PSerLinStk), "9") : context.localUtil.Format( (decimal)(A1810PSerLinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Concepto", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDConcepto_Internalname, A1802PSerDConcepto, StringUtil.RTrim( context.localUtil.Format( A1802PSerDConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cantidad Requerida", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDCantFormula_Internalname, StringUtil.LTrim( StringUtil.NToC( A1799PSerDCantFormula, 17, 4, ".", "")), StringUtil.LTrim( ((edtPSerDCantFormula_Enabled!=0) ? context.localUtil.Format( A1799PSerDCantFormula, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1799PSerDCantFormula, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDCantFormula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDCantFormula_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad Atendida", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDCantIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1800PSerDCantIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtPSerDCantIng_Enabled!=0) ? context.localUtil.Format( A1800PSerDCantIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1800PSerDCantIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDCantIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDCantIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Costo", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerDCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1803PSerDCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtPSerDCosto_Enabled!=0) ? context.localUtil.Format( A1803PSerDCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1803PSerDCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerDCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerDCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POSERVICIODET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIODET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POSERVICIODET.htm");
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
            Z329PSerCod = cgiGet( "Z329PSerCod");
            Z335PSerDItem = (int)(context.localUtil.CToN( cgiGet( "Z335PSerDItem"), ".", ","));
            Z1802PSerDConcepto = cgiGet( "Z1802PSerDConcepto");
            Z1799PSerDCantFormula = context.localUtil.CToN( cgiGet( "Z1799PSerDCantFormula"), ".", ",");
            Z1800PSerDCantIng = context.localUtil.CToN( cgiGet( "Z1800PSerDCantIng"), ".", ",");
            Z1803PSerDCosto = context.localUtil.CToN( cgiGet( "Z1803PSerDCosto"), ".", ",");
            Z336PSerDProdCod = cgiGet( "Z336PSerDProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1809PSerLinRef1 = cgiGet( "PSERLINREF1");
            /* Read variables values. */
            A329PSerCod = cgiGet( edtPSerCod_Internalname);
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERDITEM");
               AnyError = 1;
               GX_FocusControl = edtPSerDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A335PSerDItem = 0;
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
            }
            else
            {
               A335PSerDItem = (int)(context.localUtil.CToN( cgiGet( edtPSerDItem_Internalname), ".", ","));
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
            }
            A336PSerDProdCod = StringUtil.Upper( cgiGet( edtPSerDProdCod_Internalname));
            AssignAttri("", false, "A336PSerDProdCod", A336PSerDProdCod);
            A1804PSerDProdDsc = cgiGet( edtPSerDProdDsc_Internalname);
            AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
            A1808PSerLinCod = (int)(context.localUtil.CToN( cgiGet( edtPSerLinCod_Internalname), ".", ","));
            AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
            A1810PSerLinStk = (short)(context.localUtil.CToN( cgiGet( edtPSerLinStk_Internalname), ".", ","));
            AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
            A1802PSerDConcepto = cgiGet( edtPSerDConcepto_Internalname);
            AssignAttri("", false, "A1802PSerDConcepto", A1802PSerDConcepto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerDCantFormula_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerDCantFormula_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERDCANTFORMULA");
               AnyError = 1;
               GX_FocusControl = edtPSerDCantFormula_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1799PSerDCantFormula = 0;
               AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrimStr( A1799PSerDCantFormula, 15, 4));
            }
            else
            {
               A1799PSerDCantFormula = context.localUtil.CToN( cgiGet( edtPSerDCantFormula_Internalname), ".", ",");
               AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrimStr( A1799PSerDCantFormula, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerDCantIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerDCantIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERDCANTING");
               AnyError = 1;
               GX_FocusControl = edtPSerDCantIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1800PSerDCantIng = 0;
               AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrimStr( A1800PSerDCantIng, 15, 4));
            }
            else
            {
               A1800PSerDCantIng = context.localUtil.CToN( cgiGet( edtPSerDCantIng_Internalname), ".", ",");
               AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrimStr( A1800PSerDCantIng, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerDCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerDCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERDCOSTO");
               AnyError = 1;
               GX_FocusControl = edtPSerDCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1803PSerDCosto = 0;
               AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrimStr( A1803PSerDCosto, 15, 2));
            }
            else
            {
               A1803PSerDCosto = context.localUtil.CToN( cgiGet( edtPSerDCosto_Internalname), ".", ",");
               AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrimStr( A1803PSerDCosto, 15, 2));
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
               A329PSerCod = GetPar( "PSerCod");
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A335PSerDItem = (int)(NumberUtil.Val( GetPar( "PSerDItem"), "."));
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
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
               InitAll4L160( ) ;
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
         DisableAttributes4L160( ) ;
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

      protected void CONFIRM_4L0( )
      {
         BeforeValidate4L160( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4L160( ) ;
            }
            else
            {
               CheckExtendedTable4L160( ) ;
               if ( AnyError == 0 )
               {
                  ZM4L160( 2) ;
                  ZM4L160( 3) ;
                  ZM4L160( 4) ;
               }
               CloseExtendedTableCursors4L160( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4L0( ) ;
         }
      }

      protected void ResetCaption4L0( )
      {
      }

      protected void ZM4L160( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1802PSerDConcepto = T004L3_A1802PSerDConcepto[0];
               Z1799PSerDCantFormula = T004L3_A1799PSerDCantFormula[0];
               Z1800PSerDCantIng = T004L3_A1800PSerDCantIng[0];
               Z1803PSerDCosto = T004L3_A1803PSerDCosto[0];
               Z336PSerDProdCod = T004L3_A336PSerDProdCod[0];
            }
            else
            {
               Z1802PSerDConcepto = A1802PSerDConcepto;
               Z1799PSerDCantFormula = A1799PSerDCantFormula;
               Z1800PSerDCantIng = A1800PSerDCantIng;
               Z1803PSerDCosto = A1803PSerDCosto;
               Z336PSerDProdCod = A336PSerDProdCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z335PSerDItem = A335PSerDItem;
            Z1802PSerDConcepto = A1802PSerDConcepto;
            Z1799PSerDCantFormula = A1799PSerDCantFormula;
            Z1800PSerDCantIng = A1800PSerDCantIng;
            Z1803PSerDCosto = A1803PSerDCosto;
            Z329PSerCod = A329PSerCod;
            Z336PSerDProdCod = A336PSerDProdCod;
            Z1804PSerDProdDsc = A1804PSerDProdDsc;
            Z1808PSerLinCod = A1808PSerLinCod;
            Z1810PSerLinStk = A1810PSerLinStk;
            Z1809PSerLinRef1 = A1809PSerLinRef1;
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

      protected void Load4L160( )
      {
         /* Using cursor T004L7 */
         pr_default.execute(5, new Object[] {A329PSerCod, A335PSerDItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound160 = 1;
            A1804PSerDProdDsc = T004L7_A1804PSerDProdDsc[0];
            AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
            A1810PSerLinStk = T004L7_A1810PSerLinStk[0];
            AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
            A1809PSerLinRef1 = T004L7_A1809PSerLinRef1[0];
            A1802PSerDConcepto = T004L7_A1802PSerDConcepto[0];
            AssignAttri("", false, "A1802PSerDConcepto", A1802PSerDConcepto);
            A1799PSerDCantFormula = T004L7_A1799PSerDCantFormula[0];
            AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrimStr( A1799PSerDCantFormula, 15, 4));
            A1800PSerDCantIng = T004L7_A1800PSerDCantIng[0];
            AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrimStr( A1800PSerDCantIng, 15, 4));
            A1803PSerDCosto = T004L7_A1803PSerDCosto[0];
            AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrimStr( A1803PSerDCosto, 15, 2));
            A336PSerDProdCod = T004L7_A336PSerDProdCod[0];
            AssignAttri("", false, "A336PSerDProdCod", A336PSerDProdCod);
            A1808PSerLinCod = T004L7_A1808PSerLinCod[0];
            AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
            ZM4L160( -1) ;
         }
         pr_default.close(5);
         OnLoadActions4L160( ) ;
      }

      protected void OnLoadActions4L160( )
      {
      }

      protected void CheckExtendedTable4L160( )
      {
         nIsDirty_160 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004L4 */
         pr_default.execute(2, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004L5 */
         pr_default.execute(3, new Object[] {A336PSerDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1804PSerDProdDsc = T004L5_A1804PSerDProdDsc[0];
         AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
         A1808PSerLinCod = T004L5_A1808PSerLinCod[0];
         AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
         pr_default.close(3);
         /* Using cursor T004L6 */
         pr_default.execute(4, new Object[] {A1808PSerLinCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERLINCOD");
            AnyError = 1;
         }
         A1810PSerLinStk = T004L6_A1810PSerLinStk[0];
         AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
         A1809PSerLinRef1 = T004L6_A1809PSerLinRef1[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors4L160( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A329PSerCod )
      {
         /* Using cursor T004L8 */
         pr_default.execute(6, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
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

      protected void gxLoad_3( string A336PSerDProdCod )
      {
         /* Using cursor T004L9 */
         pr_default.execute(7, new Object[] {A336PSerDProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1804PSerDProdDsc = T004L9_A1804PSerDProdDsc[0];
         AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
         A1808PSerLinCod = T004L9_A1808PSerLinCod[0];
         AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1804PSerDProdDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1808PSerLinCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( int A1808PSerLinCod )
      {
         /* Using cursor T004L10 */
         pr_default.execute(8, new Object[] {A1808PSerLinCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERLINCOD");
            AnyError = 1;
         }
         A1810PSerLinStk = T004L10_A1810PSerLinStk[0];
         AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
         A1809PSerLinRef1 = T004L10_A1809PSerLinRef1[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1810PSerLinStk), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A1809PSerLinRef1)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey4L160( )
      {
         /* Using cursor T004L11 */
         pr_default.execute(9, new Object[] {A329PSerCod, A335PSerDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound160 = 1;
         }
         else
         {
            RcdFound160 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004L3 */
         pr_default.execute(1, new Object[] {A329PSerCod, A335PSerDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4L160( 1) ;
            RcdFound160 = 1;
            A335PSerDItem = T004L3_A335PSerDItem[0];
            AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
            A1802PSerDConcepto = T004L3_A1802PSerDConcepto[0];
            AssignAttri("", false, "A1802PSerDConcepto", A1802PSerDConcepto);
            A1799PSerDCantFormula = T004L3_A1799PSerDCantFormula[0];
            AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrimStr( A1799PSerDCantFormula, 15, 4));
            A1800PSerDCantIng = T004L3_A1800PSerDCantIng[0];
            AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrimStr( A1800PSerDCantIng, 15, 4));
            A1803PSerDCosto = T004L3_A1803PSerDCosto[0];
            AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrimStr( A1803PSerDCosto, 15, 2));
            A329PSerCod = T004L3_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A336PSerDProdCod = T004L3_A336PSerDProdCod[0];
            AssignAttri("", false, "A336PSerDProdCod", A336PSerDProdCod);
            Z329PSerCod = A329PSerCod;
            Z335PSerDItem = A335PSerDItem;
            sMode160 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4L160( ) ;
            if ( AnyError == 1 )
            {
               RcdFound160 = 0;
               InitializeNonKey4L160( ) ;
            }
            Gx_mode = sMode160;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound160 = 0;
            InitializeNonKey4L160( ) ;
            sMode160 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode160;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4L160( ) ;
         if ( RcdFound160 == 0 )
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
         RcdFound160 = 0;
         /* Using cursor T004L12 */
         pr_default.execute(10, new Object[] {A329PSerCod, A335PSerDItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004L12_A329PSerCod[0], A329PSerCod) < 0 ) || ( StringUtil.StrCmp(T004L12_A329PSerCod[0], A329PSerCod) == 0 ) && ( T004L12_A335PSerDItem[0] < A335PSerDItem ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004L12_A329PSerCod[0], A329PSerCod) > 0 ) || ( StringUtil.StrCmp(T004L12_A329PSerCod[0], A329PSerCod) == 0 ) && ( T004L12_A335PSerDItem[0] > A335PSerDItem ) ) )
            {
               A329PSerCod = T004L12_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A335PSerDItem = T004L12_A335PSerDItem[0];
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
               RcdFound160 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound160 = 0;
         /* Using cursor T004L13 */
         pr_default.execute(11, new Object[] {A329PSerCod, A335PSerDItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004L13_A329PSerCod[0], A329PSerCod) > 0 ) || ( StringUtil.StrCmp(T004L13_A329PSerCod[0], A329PSerCod) == 0 ) && ( T004L13_A335PSerDItem[0] > A335PSerDItem ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004L13_A329PSerCod[0], A329PSerCod) < 0 ) || ( StringUtil.StrCmp(T004L13_A329PSerCod[0], A329PSerCod) == 0 ) && ( T004L13_A335PSerDItem[0] < A335PSerDItem ) ) )
            {
               A329PSerCod = T004L13_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A335PSerDItem = T004L13_A335PSerDItem[0];
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
               RcdFound160 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4L160( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4L160( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound160 == 1 )
            {
               if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( A335PSerDItem != Z335PSerDItem ) )
               {
                  A329PSerCod = Z329PSerCod;
                  AssignAttri("", false, "A329PSerCod", A329PSerCod);
                  A335PSerDItem = Z335PSerDItem;
                  AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PSERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4L160( ) ;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( A335PSerDItem != Z335PSerDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4L160( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPSerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPSerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4L160( ) ;
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
         if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( A335PSerDItem != Z335PSerDItem ) )
         {
            A329PSerCod = Z329PSerCod;
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A335PSerDItem = Z335PSerDItem;
            AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPSerCod_Internalname;
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
         GetKey4L160( ) ;
         if ( RcdFound160 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PSERCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( A335PSerDItem != Z335PSerDItem ) )
            {
               A329PSerCod = Z329PSerCod;
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               A335PSerDItem = Z335PSerDItem;
               AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PSERCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) || ( A335PSerDItem != Z335PSerDItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PSERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPSerCod_Internalname;
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
         context.RollbackDataStores("poserviciodet",pr_default);
         GX_FocusControl = edtPSerDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4L0( ) ;
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
         if ( RcdFound160 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPSerDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4L160( ) ;
         if ( RcdFound160 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4L160( ) ;
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
         if ( RcdFound160 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerDProdCod_Internalname;
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
         if ( RcdFound160 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerDProdCod_Internalname;
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
         ScanStart4L160( ) ;
         if ( RcdFound160 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound160 != 0 )
            {
               ScanNext4L160( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4L160( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4L160( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004L2 */
            pr_default.execute(0, new Object[] {A329PSerCod, A335PSerDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERVICIODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1802PSerDConcepto, T004L2_A1802PSerDConcepto[0]) != 0 ) || ( Z1799PSerDCantFormula != T004L2_A1799PSerDCantFormula[0] ) || ( Z1800PSerDCantIng != T004L2_A1800PSerDCantIng[0] ) || ( Z1803PSerDCosto != T004L2_A1803PSerDCosto[0] ) || ( StringUtil.StrCmp(Z336PSerDProdCod, T004L2_A336PSerDProdCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1802PSerDConcepto, T004L2_A1802PSerDConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("poserviciodet:[seudo value changed for attri]"+"PSerDConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1802PSerDConcepto);
                  GXUtil.WriteLogRaw("Current: ",T004L2_A1802PSerDConcepto[0]);
               }
               if ( Z1799PSerDCantFormula != T004L2_A1799PSerDCantFormula[0] )
               {
                  GXUtil.WriteLog("poserviciodet:[seudo value changed for attri]"+"PSerDCantFormula");
                  GXUtil.WriteLogRaw("Old: ",Z1799PSerDCantFormula);
                  GXUtil.WriteLogRaw("Current: ",T004L2_A1799PSerDCantFormula[0]);
               }
               if ( Z1800PSerDCantIng != T004L2_A1800PSerDCantIng[0] )
               {
                  GXUtil.WriteLog("poserviciodet:[seudo value changed for attri]"+"PSerDCantIng");
                  GXUtil.WriteLogRaw("Old: ",Z1800PSerDCantIng);
                  GXUtil.WriteLogRaw("Current: ",T004L2_A1800PSerDCantIng[0]);
               }
               if ( Z1803PSerDCosto != T004L2_A1803PSerDCosto[0] )
               {
                  GXUtil.WriteLog("poserviciodet:[seudo value changed for attri]"+"PSerDCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1803PSerDCosto);
                  GXUtil.WriteLogRaw("Current: ",T004L2_A1803PSerDCosto[0]);
               }
               if ( StringUtil.StrCmp(Z336PSerDProdCod, T004L2_A336PSerDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poserviciodet:[seudo value changed for attri]"+"PSerDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z336PSerDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T004L2_A336PSerDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERVICIODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4L160( )
      {
         BeforeValidate4L160( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4L160( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4L160( 0) ;
            CheckOptimisticConcurrency4L160( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4L160( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4L160( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004L14 */
                     pr_default.execute(12, new Object[] {A335PSerDItem, A1802PSerDConcepto, A1799PSerDCantFormula, A1800PSerDCantIng, A1803PSerDCosto, A329PSerCod, A336PSerDProdCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERVICIODET");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption4L0( ) ;
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
               Load4L160( ) ;
            }
            EndLevel4L160( ) ;
         }
         CloseExtendedTableCursors4L160( ) ;
      }

      protected void Update4L160( )
      {
         BeforeValidate4L160( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4L160( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4L160( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4L160( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4L160( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004L15 */
                     pr_default.execute(13, new Object[] {A1802PSerDConcepto, A1799PSerDCantFormula, A1800PSerDCantIng, A1803PSerDCosto, A336PSerDProdCod, A329PSerCod, A335PSerDItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERVICIODET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERVICIODET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4L160( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4L0( ) ;
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
            EndLevel4L160( ) ;
         }
         CloseExtendedTableCursors4L160( ) ;
      }

      protected void DeferredUpdate4L160( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4L160( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4L160( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4L160( ) ;
            AfterConfirm4L160( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4L160( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004L16 */
                  pr_default.execute(14, new Object[] {A329PSerCod, A335PSerDItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("POSERVICIODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound160 == 0 )
                        {
                           InitAll4L160( ) ;
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
                        ResetCaption4L0( ) ;
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
         sMode160 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4L160( ) ;
         Gx_mode = sMode160;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4L160( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004L17 */
            pr_default.execute(15, new Object[] {A336PSerDProdCod});
            A1804PSerDProdDsc = T004L17_A1804PSerDProdDsc[0];
            AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
            A1808PSerLinCod = T004L17_A1808PSerLinCod[0];
            AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
            pr_default.close(15);
            /* Using cursor T004L18 */
            pr_default.execute(16, new Object[] {A1808PSerLinCod});
            A1810PSerLinStk = T004L18_A1810PSerLinStk[0];
            AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
            A1809PSerLinRef1 = T004L18_A1809PSerLinRef1[0];
            pr_default.close(16);
         }
      }

      protected void EndLevel4L160( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4L160( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("poserviciodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("poserviciodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4L160( )
      {
         /* Using cursor T004L19 */
         pr_default.execute(17);
         RcdFound160 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound160 = 1;
            A329PSerCod = T004L19_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A335PSerDItem = T004L19_A335PSerDItem[0];
            AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4L160( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound160 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound160 = 1;
            A329PSerCod = T004L19_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A335PSerDItem = T004L19_A335PSerDItem[0];
            AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
         }
      }

      protected void ScanEnd4L160( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm4L160( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4L160( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4L160( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4L160( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4L160( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4L160( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4L160( )
      {
         edtPSerCod_Enabled = 0;
         AssignProp("", false, edtPSerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCod_Enabled), 5, 0), true);
         edtPSerDItem_Enabled = 0;
         AssignProp("", false, edtPSerDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDItem_Enabled), 5, 0), true);
         edtPSerDProdCod_Enabled = 0;
         AssignProp("", false, edtPSerDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDProdCod_Enabled), 5, 0), true);
         edtPSerDProdDsc_Enabled = 0;
         AssignProp("", false, edtPSerDProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDProdDsc_Enabled), 5, 0), true);
         edtPSerLinCod_Enabled = 0;
         AssignProp("", false, edtPSerLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerLinCod_Enabled), 5, 0), true);
         edtPSerLinStk_Enabled = 0;
         AssignProp("", false, edtPSerLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerLinStk_Enabled), 5, 0), true);
         edtPSerDConcepto_Enabled = 0;
         AssignProp("", false, edtPSerDConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDConcepto_Enabled), 5, 0), true);
         edtPSerDCantFormula_Enabled = 0;
         AssignProp("", false, edtPSerDCantFormula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDCantFormula_Enabled), 5, 0), true);
         edtPSerDCantIng_Enabled = 0;
         AssignProp("", false, edtPSerDCantIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDCantIng_Enabled), 5, 0), true);
         edtPSerDCosto_Enabled = 0;
         AssignProp("", false, edtPSerDCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerDCosto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4L160( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254027", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poserviciodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z335PSerDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z335PSerDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1802PSerDConcepto", Z1802PSerDConcepto);
         GxWebStd.gx_hidden_field( context, "Z1799PSerDCantFormula", StringUtil.LTrim( StringUtil.NToC( Z1799PSerDCantFormula, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1800PSerDCantIng", StringUtil.LTrim( StringUtil.NToC( Z1800PSerDCantIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1803PSerDCosto", StringUtil.LTrim( StringUtil.NToC( Z1803PSerDCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z336PSerDProdCod", StringUtil.RTrim( Z336PSerDProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PSERLINREF1", A1809PSerLinRef1);
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
         return formatLink("poserviciodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POSERVICIODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Orden de Servicio" ;
      }

      protected void InitializeNonKey4L160( )
      {
         A336PSerDProdCod = "";
         AssignAttri("", false, "A336PSerDProdCod", A336PSerDProdCod);
         A1804PSerDProdDsc = "";
         AssignAttri("", false, "A1804PSerDProdDsc", A1804PSerDProdDsc);
         A1808PSerLinCod = 0;
         AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrimStr( (decimal)(A1808PSerLinCod), 6, 0));
         A1810PSerLinStk = 0;
         AssignAttri("", false, "A1810PSerLinStk", StringUtil.Str( (decimal)(A1810PSerLinStk), 1, 0));
         A1809PSerLinRef1 = "";
         AssignAttri("", false, "A1809PSerLinRef1", A1809PSerLinRef1);
         A1802PSerDConcepto = "";
         AssignAttri("", false, "A1802PSerDConcepto", A1802PSerDConcepto);
         A1799PSerDCantFormula = 0;
         AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrimStr( A1799PSerDCantFormula, 15, 4));
         A1800PSerDCantIng = 0;
         AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrimStr( A1800PSerDCantIng, 15, 4));
         A1803PSerDCosto = 0;
         AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrimStr( A1803PSerDCosto, 15, 2));
         Z1802PSerDConcepto = "";
         Z1799PSerDCantFormula = 0;
         Z1800PSerDCantIng = 0;
         Z1803PSerDCosto = 0;
         Z336PSerDProdCod = "";
      }

      protected void InitAll4L160( )
      {
         A329PSerCod = "";
         AssignAttri("", false, "A329PSerCod", A329PSerCod);
         A335PSerDItem = 0;
         AssignAttri("", false, "A335PSerDItem", StringUtil.LTrimStr( (decimal)(A335PSerDItem), 6, 0));
         InitializeNonKey4L160( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254035", true, true);
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
         context.AddJavascriptSource("poserviciodet.js", "?202281810254035", false, true);
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
         edtPSerCod_Internalname = "PSERCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPSerDItem_Internalname = "PSERDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPSerDProdCod_Internalname = "PSERDPRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPSerDProdDsc_Internalname = "PSERDPRODDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPSerLinCod_Internalname = "PSERLINCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPSerLinStk_Internalname = "PSERLINSTK";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPSerDConcepto_Internalname = "PSERDCONCEPTO";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPSerDCantFormula_Internalname = "PSERDCANTFORMULA";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPSerDCantIng_Internalname = "PSERDCANTING";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPSerDCosto_Internalname = "PSERDCOSTO";
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
         Form.Caption = "Orden de Servicio";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPSerDCosto_Jsonclick = "";
         edtPSerDCosto_Enabled = 1;
         edtPSerDCantIng_Jsonclick = "";
         edtPSerDCantIng_Enabled = 1;
         edtPSerDCantFormula_Jsonclick = "";
         edtPSerDCantFormula_Enabled = 1;
         edtPSerDConcepto_Jsonclick = "";
         edtPSerDConcepto_Enabled = 1;
         edtPSerLinStk_Jsonclick = "";
         edtPSerLinStk_Enabled = 0;
         edtPSerLinCod_Jsonclick = "";
         edtPSerLinCod_Enabled = 0;
         edtPSerDProdDsc_Jsonclick = "";
         edtPSerDProdDsc_Enabled = 0;
         edtPSerDProdCod_Jsonclick = "";
         edtPSerDProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPSerDItem_Jsonclick = "";
         edtPSerDItem_Enabled = 1;
         edtPSerCod_Jsonclick = "";
         edtPSerCod_Enabled = 1;
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
         /* Using cursor T004L20 */
         pr_default.execute(18, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtPSerDProdCod_Internalname;
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

      public void Valid_Psercod( )
      {
         /* Using cursor T004L20 */
         pr_default.execute(18, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Orden de Servicio'.", "ForeignKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pserditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A336PSerDProdCod", StringUtil.RTrim( A336PSerDProdCod));
         AssignAttri("", false, "A1802PSerDConcepto", A1802PSerDConcepto);
         AssignAttri("", false, "A1799PSerDCantFormula", StringUtil.LTrim( StringUtil.NToC( A1799PSerDCantFormula, 15, 4, ".", "")));
         AssignAttri("", false, "A1800PSerDCantIng", StringUtil.LTrim( StringUtil.NToC( A1800PSerDCantIng, 15, 4, ".", "")));
         AssignAttri("", false, "A1803PSerDCosto", StringUtil.LTrim( StringUtil.NToC( A1803PSerDCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A1804PSerDProdDsc", StringUtil.RTrim( A1804PSerDProdDsc));
         AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1808PSerLinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1810PSerLinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1810PSerLinStk), 1, 0, ".", "")));
         AssignAttri("", false, "A1809PSerLinRef1", A1809PSerLinRef1);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z335PSerDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z335PSerDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z336PSerDProdCod", StringUtil.RTrim( Z336PSerDProdCod));
         GxWebStd.gx_hidden_field( context, "Z1802PSerDConcepto", Z1802PSerDConcepto);
         GxWebStd.gx_hidden_field( context, "Z1799PSerDCantFormula", StringUtil.LTrim( StringUtil.NToC( Z1799PSerDCantFormula, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1800PSerDCantIng", StringUtil.LTrim( StringUtil.NToC( Z1800PSerDCantIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1803PSerDCosto", StringUtil.LTrim( StringUtil.NToC( Z1803PSerDCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1804PSerDProdDsc", StringUtil.RTrim( Z1804PSerDProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1808PSerLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1808PSerLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1810PSerLinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1810PSerLinStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1809PSerLinRef1", Z1809PSerLinRef1);
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Pserdprodcod( )
      {
         /* Using cursor T004L17 */
         pr_default.execute(15, new Object[] {A336PSerDProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerDProdCod_Internalname;
         }
         A1804PSerDProdDsc = T004L17_A1804PSerDProdDsc[0];
         A1808PSerLinCod = T004L17_A1808PSerLinCod[0];
         pr_default.close(15);
         /* Using cursor T004L18 */
         pr_default.execute(16, new Object[] {A1808PSerLinCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PSERLINCOD");
            AnyError = 1;
         }
         A1810PSerLinStk = T004L18_A1810PSerLinStk[0];
         A1809PSerLinRef1 = T004L18_A1809PSerLinRef1[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1804PSerDProdDsc", StringUtil.RTrim( A1804PSerDProdDsc));
         AssignAttri("", false, "A1808PSerLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1808PSerLinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1810PSerLinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1810PSerLinStk), 1, 0, ".", "")));
         AssignAttri("", false, "A1809PSerLinRef1", A1809PSerLinRef1);
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
         setEventMetadata("VALID_PSERCOD","{handler:'Valid_Psercod',iparms:[{av:'A329PSerCod',fld:'PSERCOD',pic:''}]");
         setEventMetadata("VALID_PSERCOD",",oparms:[]}");
         setEventMetadata("VALID_PSERDITEM","{handler:'Valid_Pserditem',iparms:[{av:'A329PSerCod',fld:'PSERCOD',pic:''},{av:'A335PSerDItem',fld:'PSERDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PSERDITEM",",oparms:[{av:'A336PSerDProdCod',fld:'PSERDPRODCOD',pic:'@!'},{av:'A1802PSerDConcepto',fld:'PSERDCONCEPTO',pic:''},{av:'A1799PSerDCantFormula',fld:'PSERDCANTFORMULA',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1800PSerDCantIng',fld:'PSERDCANTING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1803PSerDCosto',fld:'PSERDCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1804PSerDProdDsc',fld:'PSERDPRODDSC',pic:''},{av:'A1808PSerLinCod',fld:'PSERLINCOD',pic:'ZZZZZ9'},{av:'A1810PSerLinStk',fld:'PSERLINSTK',pic:'9'},{av:'A1809PSerLinRef1',fld:'PSERLINREF1',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z329PSerCod'},{av:'Z335PSerDItem'},{av:'Z336PSerDProdCod'},{av:'Z1802PSerDConcepto'},{av:'Z1799PSerDCantFormula'},{av:'Z1800PSerDCantIng'},{av:'Z1803PSerDCosto'},{av:'Z1804PSerDProdDsc'},{av:'Z1808PSerLinCod'},{av:'Z1810PSerLinStk'},{av:'Z1809PSerLinRef1'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PSERDPRODCOD","{handler:'Valid_Pserdprodcod',iparms:[{av:'A336PSerDProdCod',fld:'PSERDPRODCOD',pic:'@!'},{av:'A1808PSerLinCod',fld:'PSERLINCOD',pic:'ZZZZZ9'},{av:'A1804PSerDProdDsc',fld:'PSERDPRODDSC',pic:''},{av:'A1810PSerLinStk',fld:'PSERLINSTK',pic:'9'},{av:'A1809PSerLinRef1',fld:'PSERLINREF1',pic:''}]");
         setEventMetadata("VALID_PSERDPRODCOD",",oparms:[{av:'A1804PSerDProdDsc',fld:'PSERDPRODDSC',pic:''},{av:'A1808PSerLinCod',fld:'PSERLINCOD',pic:'ZZZZZ9'},{av:'A1810PSerLinStk',fld:'PSERLINSTK',pic:'9'},{av:'A1809PSerLinRef1',fld:'PSERLINREF1',pic:''}]}");
         setEventMetadata("VALID_PSERLINCOD","{handler:'Valid_Pserlincod',iparms:[]");
         setEventMetadata("VALID_PSERLINCOD",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z329PSerCod = "";
         Z1802PSerDConcepto = "";
         Z336PSerDProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A329PSerCod = "";
         A336PSerDProdCod = "";
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
         A1804PSerDProdDsc = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1802PSerDConcepto = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A1809PSerLinRef1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1804PSerDProdDsc = "";
         Z1809PSerLinRef1 = "";
         T004L7_A335PSerDItem = new int[1] ;
         T004L7_A1804PSerDProdDsc = new string[] {""} ;
         T004L7_A1810PSerLinStk = new short[1] ;
         T004L7_A1809PSerLinRef1 = new string[] {""} ;
         T004L7_A1802PSerDConcepto = new string[] {""} ;
         T004L7_A1799PSerDCantFormula = new decimal[1] ;
         T004L7_A1800PSerDCantIng = new decimal[1] ;
         T004L7_A1803PSerDCosto = new decimal[1] ;
         T004L7_A329PSerCod = new string[] {""} ;
         T004L7_A336PSerDProdCod = new string[] {""} ;
         T004L7_A1808PSerLinCod = new int[1] ;
         T004L4_A329PSerCod = new string[] {""} ;
         T004L5_A1804PSerDProdDsc = new string[] {""} ;
         T004L5_A1808PSerLinCod = new int[1] ;
         T004L6_A1810PSerLinStk = new short[1] ;
         T004L6_A1809PSerLinRef1 = new string[] {""} ;
         T004L8_A329PSerCod = new string[] {""} ;
         T004L9_A1804PSerDProdDsc = new string[] {""} ;
         T004L9_A1808PSerLinCod = new int[1] ;
         T004L10_A1810PSerLinStk = new short[1] ;
         T004L10_A1809PSerLinRef1 = new string[] {""} ;
         T004L11_A329PSerCod = new string[] {""} ;
         T004L11_A335PSerDItem = new int[1] ;
         T004L3_A335PSerDItem = new int[1] ;
         T004L3_A1802PSerDConcepto = new string[] {""} ;
         T004L3_A1799PSerDCantFormula = new decimal[1] ;
         T004L3_A1800PSerDCantIng = new decimal[1] ;
         T004L3_A1803PSerDCosto = new decimal[1] ;
         T004L3_A329PSerCod = new string[] {""} ;
         T004L3_A336PSerDProdCod = new string[] {""} ;
         sMode160 = "";
         T004L12_A329PSerCod = new string[] {""} ;
         T004L12_A335PSerDItem = new int[1] ;
         T004L13_A329PSerCod = new string[] {""} ;
         T004L13_A335PSerDItem = new int[1] ;
         T004L2_A335PSerDItem = new int[1] ;
         T004L2_A1802PSerDConcepto = new string[] {""} ;
         T004L2_A1799PSerDCantFormula = new decimal[1] ;
         T004L2_A1800PSerDCantIng = new decimal[1] ;
         T004L2_A1803PSerDCosto = new decimal[1] ;
         T004L2_A329PSerCod = new string[] {""} ;
         T004L2_A336PSerDProdCod = new string[] {""} ;
         T004L17_A1804PSerDProdDsc = new string[] {""} ;
         T004L17_A1808PSerLinCod = new int[1] ;
         T004L18_A1810PSerLinStk = new short[1] ;
         T004L18_A1809PSerLinRef1 = new string[] {""} ;
         T004L19_A329PSerCod = new string[] {""} ;
         T004L19_A335PSerDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004L20_A329PSerCod = new string[] {""} ;
         ZZ329PSerCod = "";
         ZZ336PSerDProdCod = "";
         ZZ1802PSerDConcepto = "";
         ZZ1804PSerDProdDsc = "";
         ZZ1809PSerLinRef1 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poserviciodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poserviciodet__default(),
            new Object[][] {
                new Object[] {
               T004L2_A335PSerDItem, T004L2_A1802PSerDConcepto, T004L2_A1799PSerDCantFormula, T004L2_A1800PSerDCantIng, T004L2_A1803PSerDCosto, T004L2_A329PSerCod, T004L2_A336PSerDProdCod
               }
               , new Object[] {
               T004L3_A335PSerDItem, T004L3_A1802PSerDConcepto, T004L3_A1799PSerDCantFormula, T004L3_A1800PSerDCantIng, T004L3_A1803PSerDCosto, T004L3_A329PSerCod, T004L3_A336PSerDProdCod
               }
               , new Object[] {
               T004L4_A329PSerCod
               }
               , new Object[] {
               T004L5_A1804PSerDProdDsc, T004L5_A1808PSerLinCod
               }
               , new Object[] {
               T004L6_A1810PSerLinStk, T004L6_A1809PSerLinRef1
               }
               , new Object[] {
               T004L7_A335PSerDItem, T004L7_A1804PSerDProdDsc, T004L7_A1810PSerLinStk, T004L7_A1809PSerLinRef1, T004L7_A1802PSerDConcepto, T004L7_A1799PSerDCantFormula, T004L7_A1800PSerDCantIng, T004L7_A1803PSerDCosto, T004L7_A329PSerCod, T004L7_A336PSerDProdCod,
               T004L7_A1808PSerLinCod
               }
               , new Object[] {
               T004L8_A329PSerCod
               }
               , new Object[] {
               T004L9_A1804PSerDProdDsc, T004L9_A1808PSerLinCod
               }
               , new Object[] {
               T004L10_A1810PSerLinStk, T004L10_A1809PSerLinRef1
               }
               , new Object[] {
               T004L11_A329PSerCod, T004L11_A335PSerDItem
               }
               , new Object[] {
               T004L12_A329PSerCod, T004L12_A335PSerDItem
               }
               , new Object[] {
               T004L13_A329PSerCod, T004L13_A335PSerDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004L17_A1804PSerDProdDsc, T004L17_A1808PSerLinCod
               }
               , new Object[] {
               T004L18_A1810PSerLinStk, T004L18_A1809PSerLinRef1
               }
               , new Object[] {
               T004L19_A329PSerCod, T004L19_A335PSerDItem
               }
               , new Object[] {
               T004L20_A329PSerCod
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
      private short A1810PSerLinStk ;
      private short GX_JID ;
      private short Z1810PSerLinStk ;
      private short RcdFound160 ;
      private short nIsDirty_160 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1810PSerLinStk ;
      private int Z335PSerDItem ;
      private int A1808PSerLinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPSerCod_Enabled ;
      private int A335PSerDItem ;
      private int edtPSerDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPSerDProdCod_Enabled ;
      private int edtPSerDProdDsc_Enabled ;
      private int edtPSerLinCod_Enabled ;
      private int edtPSerLinStk_Enabled ;
      private int edtPSerDConcepto_Enabled ;
      private int edtPSerDCantFormula_Enabled ;
      private int edtPSerDCantIng_Enabled ;
      private int edtPSerDCosto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z1808PSerLinCod ;
      private int idxLst ;
      private int ZZ335PSerDItem ;
      private int ZZ1808PSerLinCod ;
      private decimal Z1799PSerDCantFormula ;
      private decimal Z1800PSerDCantIng ;
      private decimal Z1803PSerDCosto ;
      private decimal A1799PSerDCantFormula ;
      private decimal A1800PSerDCantIng ;
      private decimal A1803PSerDCosto ;
      private decimal ZZ1799PSerDCantFormula ;
      private decimal ZZ1800PSerDCantIng ;
      private decimal ZZ1803PSerDCosto ;
      private string sPrefix ;
      private string Z329PSerCod ;
      private string Z336PSerDProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A329PSerCod ;
      private string A336PSerDProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPSerCod_Internalname ;
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
      private string edtPSerCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPSerDItem_Internalname ;
      private string edtPSerDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPSerDProdCod_Internalname ;
      private string edtPSerDProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPSerDProdDsc_Internalname ;
      private string A1804PSerDProdDsc ;
      private string edtPSerDProdDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPSerLinCod_Internalname ;
      private string edtPSerLinCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPSerLinStk_Internalname ;
      private string edtPSerLinStk_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPSerDConcepto_Internalname ;
      private string edtPSerDConcepto_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPSerDCantFormula_Internalname ;
      private string edtPSerDCantFormula_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPSerDCantIng_Internalname ;
      private string edtPSerDCantIng_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPSerDCosto_Internalname ;
      private string edtPSerDCosto_Jsonclick ;
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
      private string Z1804PSerDProdDsc ;
      private string sMode160 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ329PSerCod ;
      private string ZZ336PSerDProdCod ;
      private string ZZ1804PSerDProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z1802PSerDConcepto ;
      private string A1802PSerDConcepto ;
      private string A1809PSerLinRef1 ;
      private string Z1809PSerLinRef1 ;
      private string ZZ1802PSerDConcepto ;
      private string ZZ1809PSerLinRef1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T004L7_A335PSerDItem ;
      private string[] T004L7_A1804PSerDProdDsc ;
      private short[] T004L7_A1810PSerLinStk ;
      private string[] T004L7_A1809PSerLinRef1 ;
      private string[] T004L7_A1802PSerDConcepto ;
      private decimal[] T004L7_A1799PSerDCantFormula ;
      private decimal[] T004L7_A1800PSerDCantIng ;
      private decimal[] T004L7_A1803PSerDCosto ;
      private string[] T004L7_A329PSerCod ;
      private string[] T004L7_A336PSerDProdCod ;
      private int[] T004L7_A1808PSerLinCod ;
      private string[] T004L4_A329PSerCod ;
      private string[] T004L5_A1804PSerDProdDsc ;
      private int[] T004L5_A1808PSerLinCod ;
      private short[] T004L6_A1810PSerLinStk ;
      private string[] T004L6_A1809PSerLinRef1 ;
      private string[] T004L8_A329PSerCod ;
      private string[] T004L9_A1804PSerDProdDsc ;
      private int[] T004L9_A1808PSerLinCod ;
      private short[] T004L10_A1810PSerLinStk ;
      private string[] T004L10_A1809PSerLinRef1 ;
      private string[] T004L11_A329PSerCod ;
      private int[] T004L11_A335PSerDItem ;
      private int[] T004L3_A335PSerDItem ;
      private string[] T004L3_A1802PSerDConcepto ;
      private decimal[] T004L3_A1799PSerDCantFormula ;
      private decimal[] T004L3_A1800PSerDCantIng ;
      private decimal[] T004L3_A1803PSerDCosto ;
      private string[] T004L3_A329PSerCod ;
      private string[] T004L3_A336PSerDProdCod ;
      private string[] T004L12_A329PSerCod ;
      private int[] T004L12_A335PSerDItem ;
      private string[] T004L13_A329PSerCod ;
      private int[] T004L13_A335PSerDItem ;
      private int[] T004L2_A335PSerDItem ;
      private string[] T004L2_A1802PSerDConcepto ;
      private decimal[] T004L2_A1799PSerDCantFormula ;
      private decimal[] T004L2_A1800PSerDCantIng ;
      private decimal[] T004L2_A1803PSerDCosto ;
      private string[] T004L2_A329PSerCod ;
      private string[] T004L2_A336PSerDProdCod ;
      private string[] T004L17_A1804PSerDProdDsc ;
      private int[] T004L17_A1808PSerLinCod ;
      private short[] T004L18_A1810PSerLinStk ;
      private string[] T004L18_A1809PSerLinRef1 ;
      private string[] T004L19_A329PSerCod ;
      private int[] T004L19_A335PSerDItem ;
      private string[] T004L20_A329PSerCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poserviciodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poserviciodet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004L7;
        prmT004L7 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L4;
        prmT004L4 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004L5;
        prmT004L5 = new Object[] {
        new ParDef("@PSerDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004L6;
        prmT004L6 = new Object[] {
        new ParDef("@PSerLinCod",GXType.Int32,6,0)
        };
        Object[] prmT004L8;
        prmT004L8 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004L9;
        prmT004L9 = new Object[] {
        new ParDef("@PSerDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004L10;
        prmT004L10 = new Object[] {
        new ParDef("@PSerLinCod",GXType.Int32,6,0)
        };
        Object[] prmT004L11;
        prmT004L11 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L3;
        prmT004L3 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L12;
        prmT004L12 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L13;
        prmT004L13 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L2;
        prmT004L2 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L14;
        prmT004L14 = new Object[] {
        new ParDef("@PSerDItem",GXType.Int32,6,0) ,
        new ParDef("@PSerDConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@PSerDCantFormula",GXType.Decimal,15,4) ,
        new ParDef("@PSerDCantIng",GXType.Decimal,15,4) ,
        new ParDef("@PSerDCosto",GXType.Decimal,15,2) ,
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004L15;
        prmT004L15 = new Object[] {
        new ParDef("@PSerDConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@PSerDCantFormula",GXType.Decimal,15,4) ,
        new ParDef("@PSerDCantIng",GXType.Decimal,15,4) ,
        new ParDef("@PSerDCosto",GXType.Decimal,15,2) ,
        new ParDef("@PSerDProdCod",GXType.NChar,15,0) ,
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L16;
        prmT004L16 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerDItem",GXType.Int32,6,0)
        };
        Object[] prmT004L19;
        prmT004L19 = new Object[] {
        };
        Object[] prmT004L20;
        prmT004L20 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004L17;
        prmT004L17 = new Object[] {
        new ParDef("@PSerDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004L18;
        prmT004L18 = new Object[] {
        new ParDef("@PSerLinCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004L2", "SELECT [PSerDItem], [PSerDConcepto], [PSerDCantFormula], [PSerDCantIng], [PSerDCosto], [PSerCod], [PSerDProdCod] AS PSerDProdCod FROM [POSERVICIODET] WITH (UPDLOCK) WHERE [PSerCod] = @PSerCod AND [PSerDItem] = @PSerDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L3", "SELECT [PSerDItem], [PSerDConcepto], [PSerDCantFormula], [PSerDCantIng], [PSerDCosto], [PSerCod], [PSerDProdCod] AS PSerDProdCod FROM [POSERVICIODET] WHERE [PSerCod] = @PSerCod AND [PSerDItem] = @PSerDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L4", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L5", "SELECT [ProdDsc] AS PSerDProdDsc, [LinCod] AS PSerLinCod FROM [APRODUCTOS] WHERE [ProdCod] = @PSerDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L6", "SELECT [LinStk] AS PSerLinStk, [LinRef1] AS PSerLinRef1 FROM [CLINEAPROD] WHERE [LinCod] = @PSerLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L7", "SELECT TM1.[PSerDItem], T2.[ProdDsc] AS PSerDProdDsc, T3.[LinStk] AS PSerLinStk, T3.[LinRef1] AS PSerLinRef1, TM1.[PSerDConcepto], TM1.[PSerDCantFormula], TM1.[PSerDCantIng], TM1.[PSerDCosto], TM1.[PSerCod], TM1.[PSerDProdCod] AS PSerDProdCod, T2.[LinCod] AS PSerLinCod FROM (([POSERVICIODET] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[PSerDProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) WHERE TM1.[PSerCod] = @PSerCod and TM1.[PSerDItem] = @PSerDItem ORDER BY TM1.[PSerCod], TM1.[PSerDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004L7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L8", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L9", "SELECT [ProdDsc] AS PSerDProdDsc, [LinCod] AS PSerLinCod FROM [APRODUCTOS] WHERE [ProdCod] = @PSerDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L10", "SELECT [LinStk] AS PSerLinStk, [LinRef1] AS PSerLinRef1 FROM [CLINEAPROD] WHERE [LinCod] = @PSerLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L11", "SELECT [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE [PSerCod] = @PSerCod AND [PSerDItem] = @PSerDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004L11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L12", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE ( [PSerCod] > @PSerCod or [PSerCod] = @PSerCod and [PSerDItem] > @PSerDItem) ORDER BY [PSerCod], [PSerDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004L12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004L13", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE ( [PSerCod] < @PSerCod or [PSerCod] = @PSerCod and [PSerDItem] < @PSerDItem) ORDER BY [PSerCod] DESC, [PSerDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004L13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004L14", "INSERT INTO [POSERVICIODET]([PSerDItem], [PSerDConcepto], [PSerDCantFormula], [PSerDCantIng], [PSerDCosto], [PSerCod], [PSerDProdCod]) VALUES(@PSerDItem, @PSerDConcepto, @PSerDCantFormula, @PSerDCantIng, @PSerDCosto, @PSerCod, @PSerDProdCod)", GxErrorMask.GX_NOMASK,prmT004L14)
           ,new CursorDef("T004L15", "UPDATE [POSERVICIODET] SET [PSerDConcepto]=@PSerDConcepto, [PSerDCantFormula]=@PSerDCantFormula, [PSerDCantIng]=@PSerDCantIng, [PSerDCosto]=@PSerDCosto, [PSerDProdCod]=@PSerDProdCod  WHERE [PSerCod] = @PSerCod AND [PSerDItem] = @PSerDItem", GxErrorMask.GX_NOMASK,prmT004L15)
           ,new CursorDef("T004L16", "DELETE FROM [POSERVICIODET]  WHERE [PSerCod] = @PSerCod AND [PSerDItem] = @PSerDItem", GxErrorMask.GX_NOMASK,prmT004L16)
           ,new CursorDef("T004L17", "SELECT [ProdDsc] AS PSerDProdDsc, [LinCod] AS PSerLinCod FROM [APRODUCTOS] WHERE [ProdCod] = @PSerDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L18", "SELECT [LinStk] AS PSerLinStk, [LinRef1] AS PSerLinRef1 FROM [CLINEAPROD] WHERE [LinCod] = @PSerLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L19", "SELECT [PSerCod], [PSerDItem] FROM [POSERVICIODET] ORDER BY [PSerCod], [PSerDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004L19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004L20", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004L20,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
