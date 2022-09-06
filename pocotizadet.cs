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
   public class pocotizadet : GXDataArea
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
            A317ProCotProdCod = GetPar( "ProCotProdCod");
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A317ProCotProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A319ProCotDProdCod = GetPar( "ProCotDProdCod");
            n319ProCotDProdCod = false;
            AssignAttri("", false, "A319ProCotDProdCod", A319ProCotDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A319ProCotDProdCod) ;
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
            Form.Meta.addItem("description", "POCOTIZADET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pocotizadet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pocotizadet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POCOTIZADET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo de Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotProdCod_Internalname, StringUtil.RTrim( A317ProCotProdCod), StringUtil.RTrim( context.localUtil.Format( A317ProCotProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A318ProCotItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtProCotItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A318ProCotItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A318ProCotItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotTipo_Internalname, StringUtil.RTrim( A1669ProCotTipo), StringUtil.RTrim( context.localUtil.Format( A1669ProCotTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotDProdCod_Internalname, StringUtil.RTrim( A319ProCotDProdCod), StringUtil.RTrim( context.localUtil.Format( A319ProCotDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Materia Prima", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotDProdDsc_Internalname, StringUtil.RTrim( A1663ProCotDProdDsc), StringUtil.RTrim( context.localUtil.Format( A1663ProCotDProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotDProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotDProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Factor", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotDFactor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1661ProCotDFactor, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCotDFactor_Enabled!=0) ? context.localUtil.Format( A1661ProCotDFactor, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1661ProCotDFactor, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotDFactor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotDFactor_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Saldo", "right", false, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cantidad", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( A1658ProCotCantidad, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCotCantidad_Enabled!=0) ? context.localUtil.Format( A1658ProCotCantidad, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1658ProCotCantidad, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotCantidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotCantidad_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Precio Unit", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotCostoUNIT_Internalname, StringUtil.LTrim( StringUtil.NToC( A1662ProCotCostoUNIT, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCotCostoUNIT_Enabled!=0) ? context.localUtil.Format( A1662ProCotCostoUNIT, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1662ProCotCostoUNIT, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotCostoUNIT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotCostoUNIT_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Costo Total", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProCotCostoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1660ProCotCostoTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCotCostoTotal_Enabled!=0) ? context.localUtil.Format( A1660ProCotCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1660ProCotCostoTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotCostoTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotCostoTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POCOTIZADET.htm");
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
            Z317ProCotProdCod = cgiGet( "Z317ProCotProdCod");
            Z318ProCotItem = (int)(context.localUtil.CToN( cgiGet( "Z318ProCotItem"), ".", ","));
            Z1669ProCotTipo = cgiGet( "Z1669ProCotTipo");
            Z1663ProCotDProdDsc = cgiGet( "Z1663ProCotDProdDsc");
            Z1661ProCotDFactor = context.localUtil.CToN( cgiGet( "Z1661ProCotDFactor"), ".", ",");
            Z1658ProCotCantidad = context.localUtil.CToN( cgiGet( "Z1658ProCotCantidad"), ".", ",");
            Z1662ProCotCostoUNIT = context.localUtil.CToN( cgiGet( "Z1662ProCotCostoUNIT"), ".", ",");
            Z319ProCotDProdCod = cgiGet( "Z319ProCotDProdCod");
            n319ProCotDProdCod = (String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A317ProCotProdCod = StringUtil.Upper( cgiGet( edtProCotProdCod_Internalname));
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTITEM");
               AnyError = 1;
               GX_FocusControl = edtProCotItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A318ProCotItem = 0;
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
            }
            else
            {
               A318ProCotItem = (int)(context.localUtil.CToN( cgiGet( edtProCotItem_Internalname), ".", ","));
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
            }
            A1669ProCotTipo = cgiGet( edtProCotTipo_Internalname);
            AssignAttri("", false, "A1669ProCotTipo", A1669ProCotTipo);
            A319ProCotDProdCod = StringUtil.Upper( cgiGet( edtProCotDProdCod_Internalname));
            n319ProCotDProdCod = false;
            AssignAttri("", false, "A319ProCotDProdCod", A319ProCotDProdCod);
            n319ProCotDProdCod = (String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ? true : false);
            A1663ProCotDProdDsc = cgiGet( edtProCotDProdDsc_Internalname);
            AssignAttri("", false, "A1663ProCotDProdDsc", A1663ProCotDProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotDFactor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotDFactor_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTDFACTOR");
               AnyError = 1;
               GX_FocusControl = edtProCotDFactor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1661ProCotDFactor = 0;
               AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrimStr( A1661ProCotDFactor, 15, 2));
            }
            else
            {
               A1661ProCotDFactor = context.localUtil.CToN( cgiGet( edtProCotDFactor_Internalname), ".", ",");
               AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrimStr( A1661ProCotDFactor, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotCantidad_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotCantidad_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTCANTIDAD");
               AnyError = 1;
               GX_FocusControl = edtProCotCantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1658ProCotCantidad = 0;
               AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrimStr( A1658ProCotCantidad, 15, 4));
            }
            else
            {
               A1658ProCotCantidad = context.localUtil.CToN( cgiGet( edtProCotCantidad_Internalname), ".", ",");
               AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrimStr( A1658ProCotCantidad, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotCostoUNIT_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotCostoUNIT_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTCOSTOUNIT");
               AnyError = 1;
               GX_FocusControl = edtProCotCostoUNIT_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1662ProCotCostoUNIT = 0;
               AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrimStr( A1662ProCotCostoUNIT, 15, 4));
            }
            else
            {
               A1662ProCotCostoUNIT = context.localUtil.CToN( cgiGet( edtProCotCostoUNIT_Internalname), ".", ",");
               AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrimStr( A1662ProCotCostoUNIT, 15, 4));
            }
            A1660ProCotCostoTotal = context.localUtil.CToN( cgiGet( edtProCotCostoTotal_Internalname), ".", ",");
            AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrimStr( A1660ProCotCostoTotal, 15, 2));
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
               A317ProCotProdCod = GetPar( "ProCotProdCod");
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               A318ProCotItem = (int)(NumberUtil.Val( GetPar( "ProCotItem"), "."));
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
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
               InitAll45144( ) ;
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
         DisableAttributes45144( ) ;
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

      protected void CONFIRM_450( )
      {
         BeforeValidate45144( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls45144( ) ;
            }
            else
            {
               CheckExtendedTable45144( ) ;
               if ( AnyError == 0 )
               {
                  ZM45144( 3) ;
                  ZM45144( 4) ;
               }
               CloseExtendedTableCursors45144( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues450( ) ;
         }
      }

      protected void ResetCaption450( )
      {
      }

      protected void ZM45144( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1669ProCotTipo = T00453_A1669ProCotTipo[0];
               Z1663ProCotDProdDsc = T00453_A1663ProCotDProdDsc[0];
               Z1661ProCotDFactor = T00453_A1661ProCotDFactor[0];
               Z1658ProCotCantidad = T00453_A1658ProCotCantidad[0];
               Z1662ProCotCostoUNIT = T00453_A1662ProCotCostoUNIT[0];
               Z319ProCotDProdCod = T00453_A319ProCotDProdCod[0];
            }
            else
            {
               Z1669ProCotTipo = A1669ProCotTipo;
               Z1663ProCotDProdDsc = A1663ProCotDProdDsc;
               Z1661ProCotDFactor = A1661ProCotDFactor;
               Z1658ProCotCantidad = A1658ProCotCantidad;
               Z1662ProCotCostoUNIT = A1662ProCotCostoUNIT;
               Z319ProCotDProdCod = A319ProCotDProdCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z318ProCotItem = A318ProCotItem;
            Z1669ProCotTipo = A1669ProCotTipo;
            Z1663ProCotDProdDsc = A1663ProCotDProdDsc;
            Z1661ProCotDFactor = A1661ProCotDFactor;
            Z1658ProCotCantidad = A1658ProCotCantidad;
            Z1662ProCotCostoUNIT = A1662ProCotCostoUNIT;
            Z317ProCotProdCod = A317ProCotProdCod;
            Z319ProCotDProdCod = A319ProCotDProdCod;
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

      protected void Load45144( )
      {
         /* Using cursor T00456 */
         pr_default.execute(4, new Object[] {A317ProCotProdCod, A318ProCotItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound144 = 1;
            A1669ProCotTipo = T00456_A1669ProCotTipo[0];
            AssignAttri("", false, "A1669ProCotTipo", A1669ProCotTipo);
            A1663ProCotDProdDsc = T00456_A1663ProCotDProdDsc[0];
            AssignAttri("", false, "A1663ProCotDProdDsc", A1663ProCotDProdDsc);
            A1661ProCotDFactor = T00456_A1661ProCotDFactor[0];
            AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrimStr( A1661ProCotDFactor, 15, 2));
            A1658ProCotCantidad = T00456_A1658ProCotCantidad[0];
            AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrimStr( A1658ProCotCantidad, 15, 4));
            A1662ProCotCostoUNIT = T00456_A1662ProCotCostoUNIT[0];
            AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrimStr( A1662ProCotCostoUNIT, 15, 4));
            A319ProCotDProdCod = T00456_A319ProCotDProdCod[0];
            n319ProCotDProdCod = T00456_n319ProCotDProdCod[0];
            AssignAttri("", false, "A319ProCotDProdCod", A319ProCotDProdCod);
            ZM45144( -2) ;
         }
         pr_default.close(4);
         OnLoadActions45144( ) ;
      }

      protected void OnLoadActions45144( )
      {
         A1660ProCotCostoTotal = ((A1661ProCotDFactor==Convert.ToDecimal(0)) ? (decimal)(0) : ((A1658ProCotCantidad/ (decimal)(A1661ProCotDFactor))*A1662ProCotCostoUNIT));
         AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrimStr( A1660ProCotCostoTotal, 15, 2));
      }

      protected void CheckExtendedTable45144( )
      {
         nIsDirty_144 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00454 */
         pr_default.execute(2, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'POCOTIZA'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00455 */
         pr_default.execute(3, new Object[] {n319ProCotDProdCod, A319ProCotDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Detalle'.", "ForeignKeyNotFound", 1, "PROCOTDPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotDProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         nIsDirty_144 = 1;
         A1660ProCotCostoTotal = ((A1661ProCotDFactor==Convert.ToDecimal(0)) ? (decimal)(0) : ((A1658ProCotCantidad/ (decimal)(A1661ProCotDFactor))*A1662ProCotCostoUNIT));
         AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrimStr( A1660ProCotCostoTotal, 15, 2));
      }

      protected void CloseExtendedTableCursors45144( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A317ProCotProdCod )
      {
         /* Using cursor T00457 */
         pr_default.execute(5, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'POCOTIZA'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
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

      protected void gxLoad_4( string A319ProCotDProdCod )
      {
         /* Using cursor T00458 */
         pr_default.execute(6, new Object[] {n319ProCotDProdCod, A319ProCotDProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Detalle'.", "ForeignKeyNotFound", 1, "PROCOTDPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotDProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey45144( )
      {
         /* Using cursor T00459 */
         pr_default.execute(7, new Object[] {A317ProCotProdCod, A318ProCotItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound144 = 1;
         }
         else
         {
            RcdFound144 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00453 */
         pr_default.execute(1, new Object[] {A317ProCotProdCod, A318ProCotItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM45144( 2) ;
            RcdFound144 = 1;
            A318ProCotItem = T00453_A318ProCotItem[0];
            AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
            A1669ProCotTipo = T00453_A1669ProCotTipo[0];
            AssignAttri("", false, "A1669ProCotTipo", A1669ProCotTipo);
            A1663ProCotDProdDsc = T00453_A1663ProCotDProdDsc[0];
            AssignAttri("", false, "A1663ProCotDProdDsc", A1663ProCotDProdDsc);
            A1661ProCotDFactor = T00453_A1661ProCotDFactor[0];
            AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrimStr( A1661ProCotDFactor, 15, 2));
            A1658ProCotCantidad = T00453_A1658ProCotCantidad[0];
            AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrimStr( A1658ProCotCantidad, 15, 4));
            A1662ProCotCostoUNIT = T00453_A1662ProCotCostoUNIT[0];
            AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrimStr( A1662ProCotCostoUNIT, 15, 4));
            A317ProCotProdCod = T00453_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            A319ProCotDProdCod = T00453_A319ProCotDProdCod[0];
            n319ProCotDProdCod = T00453_n319ProCotDProdCod[0];
            AssignAttri("", false, "A319ProCotDProdCod", A319ProCotDProdCod);
            Z317ProCotProdCod = A317ProCotProdCod;
            Z318ProCotItem = A318ProCotItem;
            sMode144 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load45144( ) ;
            if ( AnyError == 1 )
            {
               RcdFound144 = 0;
               InitializeNonKey45144( ) ;
            }
            Gx_mode = sMode144;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound144 = 0;
            InitializeNonKey45144( ) ;
            sMode144 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode144;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey45144( ) ;
         if ( RcdFound144 == 0 )
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
         RcdFound144 = 0;
         /* Using cursor T004510 */
         pr_default.execute(8, new Object[] {A317ProCotProdCod, A318ProCotItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004510_A317ProCotProdCod[0], A317ProCotProdCod) < 0 ) || ( StringUtil.StrCmp(T004510_A317ProCotProdCod[0], A317ProCotProdCod) == 0 ) && ( T004510_A318ProCotItem[0] < A318ProCotItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004510_A317ProCotProdCod[0], A317ProCotProdCod) > 0 ) || ( StringUtil.StrCmp(T004510_A317ProCotProdCod[0], A317ProCotProdCod) == 0 ) && ( T004510_A318ProCotItem[0] > A318ProCotItem ) ) )
            {
               A317ProCotProdCod = T004510_A317ProCotProdCod[0];
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               A318ProCotItem = T004510_A318ProCotItem[0];
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
               RcdFound144 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound144 = 0;
         /* Using cursor T004511 */
         pr_default.execute(9, new Object[] {A317ProCotProdCod, A318ProCotItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004511_A317ProCotProdCod[0], A317ProCotProdCod) > 0 ) || ( StringUtil.StrCmp(T004511_A317ProCotProdCod[0], A317ProCotProdCod) == 0 ) && ( T004511_A318ProCotItem[0] > A318ProCotItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004511_A317ProCotProdCod[0], A317ProCotProdCod) < 0 ) || ( StringUtil.StrCmp(T004511_A317ProCotProdCod[0], A317ProCotProdCod) == 0 ) && ( T004511_A318ProCotItem[0] < A318ProCotItem ) ) )
            {
               A317ProCotProdCod = T004511_A317ProCotProdCod[0];
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               A318ProCotItem = T004511_A318ProCotItem[0];
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
               RcdFound144 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey45144( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert45144( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound144 == 1 )
            {
               if ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) || ( A318ProCotItem != Z318ProCotItem ) )
               {
                  A317ProCotProdCod = Z317ProCotProdCod;
                  AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
                  A318ProCotItem = Z318ProCotItem;
                  AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOTPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update45144( ) ;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) || ( A318ProCotItem != Z318ProCotItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert45144( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOTPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCotProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCotProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert45144( ) ;
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
         if ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) || ( A318ProCotItem != Z318ProCotItem ) )
         {
            A317ProCotProdCod = Z317ProCotProdCod;
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            A318ProCotItem = Z318ProCotItem;
            AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCotProdCod_Internalname;
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
         GetKey45144( ) ;
         if ( RcdFound144 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROCOTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) || ( A318ProCotItem != Z318ProCotItem ) )
            {
               A317ProCotProdCod = Z317ProCotProdCod;
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               A318ProCotItem = Z318ProCotItem;
               AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PROCOTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotProdCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) || ( A318ProCotItem != Z318ProCotItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOTPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCotProdCod_Internalname;
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
         context.RollbackDataStores("pocotizadet",pr_default);
         GX_FocusControl = edtProCotTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_450( ) ;
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
         if ( RcdFound144 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProCotTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart45144( ) ;
         if ( RcdFound144 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd45144( ) ;
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
         if ( RcdFound144 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotTipo_Internalname;
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
         if ( RcdFound144 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotTipo_Internalname;
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
         ScanStart45144( ) ;
         if ( RcdFound144 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound144 != 0 )
            {
               ScanNext45144( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd45144( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency45144( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00452 */
            pr_default.execute(0, new Object[] {A317ProCotProdCod, A318ProCotItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCOTIZADET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1669ProCotTipo, T00452_A1669ProCotTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1663ProCotDProdDsc, T00452_A1663ProCotDProdDsc[0]) != 0 ) || ( Z1661ProCotDFactor != T00452_A1661ProCotDFactor[0] ) || ( Z1658ProCotCantidad != T00452_A1658ProCotCantidad[0] ) || ( Z1662ProCotCostoUNIT != T00452_A1662ProCotCostoUNIT[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z319ProCotDProdCod, T00452_A319ProCotDProdCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1669ProCotTipo, T00452_A1669ProCotTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1669ProCotTipo);
                  GXUtil.WriteLogRaw("Current: ",T00452_A1669ProCotTipo[0]);
               }
               if ( StringUtil.StrCmp(Z1663ProCotDProdDsc, T00452_A1663ProCotDProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotDProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1663ProCotDProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T00452_A1663ProCotDProdDsc[0]);
               }
               if ( Z1661ProCotDFactor != T00452_A1661ProCotDFactor[0] )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotDFactor");
                  GXUtil.WriteLogRaw("Old: ",Z1661ProCotDFactor);
                  GXUtil.WriteLogRaw("Current: ",T00452_A1661ProCotDFactor[0]);
               }
               if ( Z1658ProCotCantidad != T00452_A1658ProCotCantidad[0] )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z1658ProCotCantidad);
                  GXUtil.WriteLogRaw("Current: ",T00452_A1658ProCotCantidad[0]);
               }
               if ( Z1662ProCotCostoUNIT != T00452_A1662ProCotCostoUNIT[0] )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotCostoUNIT");
                  GXUtil.WriteLogRaw("Old: ",Z1662ProCotCostoUNIT);
                  GXUtil.WriteLogRaw("Current: ",T00452_A1662ProCotCostoUNIT[0]);
               }
               if ( StringUtil.StrCmp(Z319ProCotDProdCod, T00452_A319ProCotDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("pocotizadet:[seudo value changed for attri]"+"ProCotDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z319ProCotDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00452_A319ProCotDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCOTIZADET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert45144( )
      {
         BeforeValidate45144( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable45144( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM45144( 0) ;
            CheckOptimisticConcurrency45144( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm45144( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert45144( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004512 */
                     pr_default.execute(10, new Object[] {A318ProCotItem, A1669ProCotTipo, A1663ProCotDProdDsc, A1661ProCotDFactor, A1658ProCotCantidad, A1662ProCotCostoUNIT, A317ProCotProdCod, n319ProCotDProdCod, A319ProCotDProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POCOTIZADET");
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
                           ResetCaption450( ) ;
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
               Load45144( ) ;
            }
            EndLevel45144( ) ;
         }
         CloseExtendedTableCursors45144( ) ;
      }

      protected void Update45144( )
      {
         BeforeValidate45144( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable45144( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency45144( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm45144( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate45144( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004513 */
                     pr_default.execute(11, new Object[] {A1669ProCotTipo, A1663ProCotDProdDsc, A1661ProCotDFactor, A1658ProCotCantidad, A1662ProCotCostoUNIT, n319ProCotDProdCod, A319ProCotDProdCod, A317ProCotProdCod, A318ProCotItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POCOTIZADET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCOTIZADET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate45144( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption450( ) ;
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
            EndLevel45144( ) ;
         }
         CloseExtendedTableCursors45144( ) ;
      }

      protected void DeferredUpdate45144( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate45144( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency45144( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls45144( ) ;
            AfterConfirm45144( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete45144( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004514 */
                  pr_default.execute(12, new Object[] {A317ProCotProdCod, A318ProCotItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("POCOTIZADET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound144 == 0 )
                        {
                           InitAll45144( ) ;
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
                        ResetCaption450( ) ;
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
         sMode144 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel45144( ) ;
         Gx_mode = sMode144;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls45144( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1660ProCotCostoTotal = ((A1661ProCotDFactor==Convert.ToDecimal(0)) ? (decimal)(0) : ((A1658ProCotCantidad/ (decimal)(A1661ProCotDFactor))*A1662ProCotCostoUNIT));
            AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrimStr( A1660ProCotCostoTotal, 15, 2));
         }
      }

      protected void EndLevel45144( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete45144( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("pocotizadet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues450( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("pocotizadet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart45144( )
      {
         /* Using cursor T004515 */
         pr_default.execute(13);
         RcdFound144 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound144 = 1;
            A317ProCotProdCod = T004515_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            A318ProCotItem = T004515_A318ProCotItem[0];
            AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext45144( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound144 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound144 = 1;
            A317ProCotProdCod = T004515_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            A318ProCotItem = T004515_A318ProCotItem[0];
            AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
         }
      }

      protected void ScanEnd45144( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm45144( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert45144( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate45144( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete45144( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete45144( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate45144( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes45144( )
      {
         edtProCotProdCod_Enabled = 0;
         AssignProp("", false, edtProCotProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotProdCod_Enabled), 5, 0), true);
         edtProCotItem_Enabled = 0;
         AssignProp("", false, edtProCotItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotItem_Enabled), 5, 0), true);
         edtProCotTipo_Enabled = 0;
         AssignProp("", false, edtProCotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotTipo_Enabled), 5, 0), true);
         edtProCotDProdCod_Enabled = 0;
         AssignProp("", false, edtProCotDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotDProdCod_Enabled), 5, 0), true);
         edtProCotDProdDsc_Enabled = 0;
         AssignProp("", false, edtProCotDProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotDProdDsc_Enabled), 5, 0), true);
         edtProCotDFactor_Enabled = 0;
         AssignProp("", false, edtProCotDFactor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotDFactor_Enabled), 5, 0), true);
         edtProCotCantidad_Enabled = 0;
         AssignProp("", false, edtProCotCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotCantidad_Enabled), 5, 0), true);
         edtProCotCostoUNIT_Enabled = 0;
         AssignProp("", false, edtProCotCostoUNIT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotCostoUNIT_Enabled), 5, 0), true);
         edtProCotCostoTotal_Enabled = 0;
         AssignProp("", false, edtProCotCostoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotCostoTotal_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes45144( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues450( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253164", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("pocotizadet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z317ProCotProdCod", StringUtil.RTrim( Z317ProCotProdCod));
         GxWebStd.gx_hidden_field( context, "Z318ProCotItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z318ProCotItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1669ProCotTipo", StringUtil.RTrim( Z1669ProCotTipo));
         GxWebStd.gx_hidden_field( context, "Z1663ProCotDProdDsc", StringUtil.RTrim( Z1663ProCotDProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1661ProCotDFactor", StringUtil.LTrim( StringUtil.NToC( Z1661ProCotDFactor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1658ProCotCantidad", StringUtil.LTrim( StringUtil.NToC( Z1658ProCotCantidad, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1662ProCotCostoUNIT", StringUtil.LTrim( StringUtil.NToC( Z1662ProCotCostoUNIT, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z319ProCotDProdCod", StringUtil.RTrim( Z319ProCotDProdCod));
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
         return formatLink("pocotizadet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POCOTIZADET" ;
      }

      public override string GetPgmdesc( )
      {
         return "POCOTIZADET" ;
      }

      protected void InitializeNonKey45144( )
      {
         A1660ProCotCostoTotal = 0;
         AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrimStr( A1660ProCotCostoTotal, 15, 2));
         A1669ProCotTipo = "";
         AssignAttri("", false, "A1669ProCotTipo", A1669ProCotTipo);
         A319ProCotDProdCod = "";
         n319ProCotDProdCod = false;
         AssignAttri("", false, "A319ProCotDProdCod", A319ProCotDProdCod);
         n319ProCotDProdCod = (String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ? true : false);
         A1663ProCotDProdDsc = "";
         AssignAttri("", false, "A1663ProCotDProdDsc", A1663ProCotDProdDsc);
         A1661ProCotDFactor = 0;
         AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrimStr( A1661ProCotDFactor, 15, 2));
         A1658ProCotCantidad = 0;
         AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrimStr( A1658ProCotCantidad, 15, 4));
         A1662ProCotCostoUNIT = 0;
         AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrimStr( A1662ProCotCostoUNIT, 15, 4));
         Z1669ProCotTipo = "";
         Z1663ProCotDProdDsc = "";
         Z1661ProCotDFactor = 0;
         Z1658ProCotCantidad = 0;
         Z1662ProCotCostoUNIT = 0;
         Z319ProCotDProdCod = "";
      }

      protected void InitAll45144( )
      {
         A317ProCotProdCod = "";
         AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
         A318ProCotItem = 0;
         AssignAttri("", false, "A318ProCotItem", StringUtil.LTrimStr( (decimal)(A318ProCotItem), 6, 0));
         InitializeNonKey45144( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253172", true, true);
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
         context.AddJavascriptSource("pocotizadet.js", "?202281810253172", false, true);
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
         edtProCotProdCod_Internalname = "PROCOTPRODCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProCotItem_Internalname = "PROCOTITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProCotTipo_Internalname = "PROCOTTIPO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProCotDProdCod_Internalname = "PROCOTDPRODCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProCotDProdDsc_Internalname = "PROCOTDPRODDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtProCotDFactor_Internalname = "PROCOTDFACTOR";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtProCotCantidad_Internalname = "PROCOTCANTIDAD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtProCotCostoUNIT_Internalname = "PROCOTCOSTOUNIT";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtProCotCostoTotal_Internalname = "PROCOTCOSTOTOTAL";
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
         Form.Caption = "POCOTIZADET";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProCotCostoTotal_Jsonclick = "";
         edtProCotCostoTotal_Enabled = 0;
         edtProCotCostoUNIT_Jsonclick = "";
         edtProCotCostoUNIT_Enabled = 1;
         edtProCotCantidad_Jsonclick = "";
         edtProCotCantidad_Enabled = 1;
         edtProCotDFactor_Jsonclick = "";
         edtProCotDFactor_Enabled = 1;
         edtProCotDProdDsc_Jsonclick = "";
         edtProCotDProdDsc_Enabled = 1;
         edtProCotDProdCod_Jsonclick = "";
         edtProCotDProdCod_Enabled = 1;
         edtProCotTipo_Jsonclick = "";
         edtProCotTipo_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProCotItem_Jsonclick = "";
         edtProCotItem_Enabled = 1;
         edtProCotProdCod_Jsonclick = "";
         edtProCotProdCod_Enabled = 1;
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
         /* Using cursor T004516 */
         pr_default.execute(14, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'POCOTIZA'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtProCotTipo_Internalname;
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

      public void Valid_Procotprodcod( )
      {
         /* Using cursor T004516 */
         pr_default.execute(14, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'POCOTIZA'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Procotitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1669ProCotTipo", StringUtil.RTrim( A1669ProCotTipo));
         AssignAttri("", false, "A319ProCotDProdCod", StringUtil.RTrim( A319ProCotDProdCod));
         AssignAttri("", false, "A1663ProCotDProdDsc", StringUtil.RTrim( A1663ProCotDProdDsc));
         AssignAttri("", false, "A1661ProCotDFactor", StringUtil.LTrim( StringUtil.NToC( A1661ProCotDFactor, 15, 2, ".", "")));
         AssignAttri("", false, "A1658ProCotCantidad", StringUtil.LTrim( StringUtil.NToC( A1658ProCotCantidad, 15, 4, ".", "")));
         AssignAttri("", false, "A1662ProCotCostoUNIT", StringUtil.LTrim( StringUtil.NToC( A1662ProCotCostoUNIT, 15, 4, ".", "")));
         AssignAttri("", false, "A1660ProCotCostoTotal", StringUtil.LTrim( StringUtil.NToC( A1660ProCotCostoTotal, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z317ProCotProdCod", StringUtil.RTrim( Z317ProCotProdCod));
         GxWebStd.gx_hidden_field( context, "Z318ProCotItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z318ProCotItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1669ProCotTipo", StringUtil.RTrim( Z1669ProCotTipo));
         GxWebStd.gx_hidden_field( context, "Z319ProCotDProdCod", StringUtil.RTrim( Z319ProCotDProdCod));
         GxWebStd.gx_hidden_field( context, "Z1663ProCotDProdDsc", StringUtil.RTrim( Z1663ProCotDProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1661ProCotDFactor", StringUtil.LTrim( StringUtil.NToC( Z1661ProCotDFactor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1658ProCotCantidad", StringUtil.LTrim( StringUtil.NToC( Z1658ProCotCantidad, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1662ProCotCostoUNIT", StringUtil.LTrim( StringUtil.NToC( Z1662ProCotCostoUNIT, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1660ProCotCostoTotal", StringUtil.LTrim( StringUtil.NToC( Z1660ProCotCostoTotal, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Procotdprodcod( )
      {
         n319ProCotDProdCod = false;
         /* Using cursor T004517 */
         pr_default.execute(15, new Object[] {n319ProCotDProdCod, A319ProCotDProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A319ProCotDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Detalle'.", "ForeignKeyNotFound", 1, "PROCOTDPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotDProdCod_Internalname;
            }
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_PROCOTPRODCOD","{handler:'Valid_Procotprodcod',iparms:[{av:'A317ProCotProdCod',fld:'PROCOTPRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PROCOTPRODCOD",",oparms:[]}");
         setEventMetadata("VALID_PROCOTITEM","{handler:'Valid_Procotitem',iparms:[{av:'A317ProCotProdCod',fld:'PROCOTPRODCOD',pic:'@!'},{av:'A318ProCotItem',fld:'PROCOTITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCOTITEM",",oparms:[{av:'A1669ProCotTipo',fld:'PROCOTTIPO',pic:''},{av:'A319ProCotDProdCod',fld:'PROCOTDPRODCOD',pic:'@!'},{av:'A1663ProCotDProdDsc',fld:'PROCOTDPRODDSC',pic:''},{av:'A1661ProCotDFactor',fld:'PROCOTDFACTOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1658ProCotCantidad',fld:'PROCOTCANTIDAD',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1662ProCotCostoUNIT',fld:'PROCOTCOSTOUNIT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1660ProCotCostoTotal',fld:'PROCOTCOSTOTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z317ProCotProdCod'},{av:'Z318ProCotItem'},{av:'Z1669ProCotTipo'},{av:'Z319ProCotDProdCod'},{av:'Z1663ProCotDProdDsc'},{av:'Z1661ProCotDFactor'},{av:'Z1658ProCotCantidad'},{av:'Z1662ProCotCostoUNIT'},{av:'Z1660ProCotCostoTotal'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROCOTDPRODCOD","{handler:'Valid_Procotdprodcod',iparms:[{av:'A319ProCotDProdCod',fld:'PROCOTDPRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PROCOTDPRODCOD",",oparms:[]}");
         setEventMetadata("VALID_PROCOTDFACTOR","{handler:'Valid_Procotdfactor',iparms:[]");
         setEventMetadata("VALID_PROCOTDFACTOR",",oparms:[]}");
         setEventMetadata("VALID_PROCOTCANTIDAD","{handler:'Valid_Procotcantidad',iparms:[]");
         setEventMetadata("VALID_PROCOTCANTIDAD",",oparms:[]}");
         setEventMetadata("VALID_PROCOTCOSTOUNIT","{handler:'Valid_Procotcostounit',iparms:[]");
         setEventMetadata("VALID_PROCOTCOSTOUNIT",",oparms:[]}");
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
         Z317ProCotProdCod = "";
         Z1669ProCotTipo = "";
         Z1663ProCotDProdDsc = "";
         Z319ProCotDProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A317ProCotProdCod = "";
         A319ProCotDProdCod = "";
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
         A1669ProCotTipo = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A1663ProCotDProdDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
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
         T00456_A318ProCotItem = new int[1] ;
         T00456_A1669ProCotTipo = new string[] {""} ;
         T00456_A1663ProCotDProdDsc = new string[] {""} ;
         T00456_A1661ProCotDFactor = new decimal[1] ;
         T00456_A1658ProCotCantidad = new decimal[1] ;
         T00456_A1662ProCotCostoUNIT = new decimal[1] ;
         T00456_A317ProCotProdCod = new string[] {""} ;
         T00456_A319ProCotDProdCod = new string[] {""} ;
         T00456_n319ProCotDProdCod = new bool[] {false} ;
         T00454_A317ProCotProdCod = new string[] {""} ;
         T00455_A319ProCotDProdCod = new string[] {""} ;
         T00455_n319ProCotDProdCod = new bool[] {false} ;
         T00457_A317ProCotProdCod = new string[] {""} ;
         T00458_A319ProCotDProdCod = new string[] {""} ;
         T00458_n319ProCotDProdCod = new bool[] {false} ;
         T00459_A317ProCotProdCod = new string[] {""} ;
         T00459_A318ProCotItem = new int[1] ;
         T00453_A318ProCotItem = new int[1] ;
         T00453_A1669ProCotTipo = new string[] {""} ;
         T00453_A1663ProCotDProdDsc = new string[] {""} ;
         T00453_A1661ProCotDFactor = new decimal[1] ;
         T00453_A1658ProCotCantidad = new decimal[1] ;
         T00453_A1662ProCotCostoUNIT = new decimal[1] ;
         T00453_A317ProCotProdCod = new string[] {""} ;
         T00453_A319ProCotDProdCod = new string[] {""} ;
         T00453_n319ProCotDProdCod = new bool[] {false} ;
         sMode144 = "";
         T004510_A317ProCotProdCod = new string[] {""} ;
         T004510_A318ProCotItem = new int[1] ;
         T004511_A317ProCotProdCod = new string[] {""} ;
         T004511_A318ProCotItem = new int[1] ;
         T00452_A318ProCotItem = new int[1] ;
         T00452_A1669ProCotTipo = new string[] {""} ;
         T00452_A1663ProCotDProdDsc = new string[] {""} ;
         T00452_A1661ProCotDFactor = new decimal[1] ;
         T00452_A1658ProCotCantidad = new decimal[1] ;
         T00452_A1662ProCotCostoUNIT = new decimal[1] ;
         T00452_A317ProCotProdCod = new string[] {""} ;
         T00452_A319ProCotDProdCod = new string[] {""} ;
         T00452_n319ProCotDProdCod = new bool[] {false} ;
         T004515_A317ProCotProdCod = new string[] {""} ;
         T004515_A318ProCotItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004516_A317ProCotProdCod = new string[] {""} ;
         ZZ317ProCotProdCod = "";
         ZZ1669ProCotTipo = "";
         ZZ319ProCotDProdCod = "";
         ZZ1663ProCotDProdDsc = "";
         T004517_A319ProCotDProdCod = new string[] {""} ;
         T004517_n319ProCotDProdCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.pocotizadet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pocotizadet__default(),
            new Object[][] {
                new Object[] {
               T00452_A318ProCotItem, T00452_A1669ProCotTipo, T00452_A1663ProCotDProdDsc, T00452_A1661ProCotDFactor, T00452_A1658ProCotCantidad, T00452_A1662ProCotCostoUNIT, T00452_A317ProCotProdCod, T00452_A319ProCotDProdCod, T00452_n319ProCotDProdCod
               }
               , new Object[] {
               T00453_A318ProCotItem, T00453_A1669ProCotTipo, T00453_A1663ProCotDProdDsc, T00453_A1661ProCotDFactor, T00453_A1658ProCotCantidad, T00453_A1662ProCotCostoUNIT, T00453_A317ProCotProdCod, T00453_A319ProCotDProdCod, T00453_n319ProCotDProdCod
               }
               , new Object[] {
               T00454_A317ProCotProdCod
               }
               , new Object[] {
               T00455_A319ProCotDProdCod
               }
               , new Object[] {
               T00456_A318ProCotItem, T00456_A1669ProCotTipo, T00456_A1663ProCotDProdDsc, T00456_A1661ProCotDFactor, T00456_A1658ProCotCantidad, T00456_A1662ProCotCostoUNIT, T00456_A317ProCotProdCod, T00456_A319ProCotDProdCod, T00456_n319ProCotDProdCod
               }
               , new Object[] {
               T00457_A317ProCotProdCod
               }
               , new Object[] {
               T00458_A319ProCotDProdCod
               }
               , new Object[] {
               T00459_A317ProCotProdCod, T00459_A318ProCotItem
               }
               , new Object[] {
               T004510_A317ProCotProdCod, T004510_A318ProCotItem
               }
               , new Object[] {
               T004511_A317ProCotProdCod, T004511_A318ProCotItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004515_A317ProCotProdCod, T004515_A318ProCotItem
               }
               , new Object[] {
               T004516_A317ProCotProdCod
               }
               , new Object[] {
               T004517_A319ProCotDProdCod
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
      private short RcdFound144 ;
      private short nIsDirty_144 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z318ProCotItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCotProdCod_Enabled ;
      private int A318ProCotItem ;
      private int edtProCotItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProCotTipo_Enabled ;
      private int edtProCotDProdCod_Enabled ;
      private int edtProCotDProdDsc_Enabled ;
      private int edtProCotDFactor_Enabled ;
      private int edtProCotCantidad_Enabled ;
      private int edtProCotCostoUNIT_Enabled ;
      private int edtProCotCostoTotal_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ318ProCotItem ;
      private decimal Z1661ProCotDFactor ;
      private decimal Z1658ProCotCantidad ;
      private decimal Z1662ProCotCostoUNIT ;
      private decimal A1661ProCotDFactor ;
      private decimal A1658ProCotCantidad ;
      private decimal A1662ProCotCostoUNIT ;
      private decimal A1660ProCotCostoTotal ;
      private decimal Z1660ProCotCostoTotal ;
      private decimal ZZ1661ProCotDFactor ;
      private decimal ZZ1658ProCotCantidad ;
      private decimal ZZ1662ProCotCostoUNIT ;
      private decimal ZZ1660ProCotCostoTotal ;
      private string sPrefix ;
      private string Z317ProCotProdCod ;
      private string Z1669ProCotTipo ;
      private string Z1663ProCotDProdDsc ;
      private string Z319ProCotDProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A317ProCotProdCod ;
      private string A319ProCotDProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCotProdCod_Internalname ;
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
      private string edtProCotProdCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProCotItem_Internalname ;
      private string edtProCotItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProCotTipo_Internalname ;
      private string A1669ProCotTipo ;
      private string edtProCotTipo_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProCotDProdCod_Internalname ;
      private string edtProCotDProdCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProCotDProdDsc_Internalname ;
      private string A1663ProCotDProdDsc ;
      private string edtProCotDProdDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtProCotDFactor_Internalname ;
      private string edtProCotDFactor_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtProCotCantidad_Internalname ;
      private string edtProCotCantidad_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtProCotCostoUNIT_Internalname ;
      private string edtProCotCostoUNIT_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtProCotCostoTotal_Internalname ;
      private string edtProCotCostoTotal_Jsonclick ;
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
      private string sMode144 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ317ProCotProdCod ;
      private string ZZ1669ProCotTipo ;
      private string ZZ319ProCotDProdCod ;
      private string ZZ1663ProCotDProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n319ProCotDProdCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00456_A318ProCotItem ;
      private string[] T00456_A1669ProCotTipo ;
      private string[] T00456_A1663ProCotDProdDsc ;
      private decimal[] T00456_A1661ProCotDFactor ;
      private decimal[] T00456_A1658ProCotCantidad ;
      private decimal[] T00456_A1662ProCotCostoUNIT ;
      private string[] T00456_A317ProCotProdCod ;
      private string[] T00456_A319ProCotDProdCod ;
      private bool[] T00456_n319ProCotDProdCod ;
      private string[] T00454_A317ProCotProdCod ;
      private string[] T00455_A319ProCotDProdCod ;
      private bool[] T00455_n319ProCotDProdCod ;
      private string[] T00457_A317ProCotProdCod ;
      private string[] T00458_A319ProCotDProdCod ;
      private bool[] T00458_n319ProCotDProdCod ;
      private string[] T00459_A317ProCotProdCod ;
      private int[] T00459_A318ProCotItem ;
      private int[] T00453_A318ProCotItem ;
      private string[] T00453_A1669ProCotTipo ;
      private string[] T00453_A1663ProCotDProdDsc ;
      private decimal[] T00453_A1661ProCotDFactor ;
      private decimal[] T00453_A1658ProCotCantidad ;
      private decimal[] T00453_A1662ProCotCostoUNIT ;
      private string[] T00453_A317ProCotProdCod ;
      private string[] T00453_A319ProCotDProdCod ;
      private bool[] T00453_n319ProCotDProdCod ;
      private string[] T004510_A317ProCotProdCod ;
      private int[] T004510_A318ProCotItem ;
      private string[] T004511_A317ProCotProdCod ;
      private int[] T004511_A318ProCotItem ;
      private int[] T00452_A318ProCotItem ;
      private string[] T00452_A1669ProCotTipo ;
      private string[] T00452_A1663ProCotDProdDsc ;
      private decimal[] T00452_A1661ProCotDFactor ;
      private decimal[] T00452_A1658ProCotCantidad ;
      private decimal[] T00452_A1662ProCotCostoUNIT ;
      private string[] T00452_A317ProCotProdCod ;
      private string[] T00452_A319ProCotDProdCod ;
      private bool[] T00452_n319ProCotDProdCod ;
      private string[] T004515_A317ProCotProdCod ;
      private int[] T004515_A318ProCotItem ;
      private string[] T004516_A317ProCotProdCod ;
      private string[] T004517_A319ProCotDProdCod ;
      private bool[] T004517_n319ProCotDProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class pocotizadet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pocotizadet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00456;
        prmT00456 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT00454;
        prmT00454 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00455;
        prmT00455 = new Object[] {
        new ParDef("@ProCotDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00457;
        prmT00457 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00458;
        prmT00458 = new Object[] {
        new ParDef("@ProCotDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00459;
        prmT00459 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT00453;
        prmT00453 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT004510;
        prmT004510 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT004511;
        prmT004511 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT00452;
        prmT00452 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT004512;
        prmT004512 = new Object[] {
        new ParDef("@ProCotItem",GXType.Int32,6,0) ,
        new ParDef("@ProCotTipo",GXType.NChar,1,0) ,
        new ParDef("@ProCotDProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCotDFactor",GXType.Decimal,15,2) ,
        new ParDef("@ProCotCantidad",GXType.Decimal,15,4) ,
        new ParDef("@ProCotCostoUNIT",GXType.Decimal,15,4) ,
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT004513;
        prmT004513 = new Object[] {
        new ParDef("@ProCotTipo",GXType.NChar,1,0) ,
        new ParDef("@ProCotDProdDsc",GXType.NChar,100,0) ,
        new ParDef("@ProCotDFactor",GXType.Decimal,15,2) ,
        new ParDef("@ProCotCantidad",GXType.Decimal,15,4) ,
        new ParDef("@ProCotCostoUNIT",GXType.Decimal,15,4) ,
        new ParDef("@ProCotDProdCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT004514;
        prmT004514 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCotItem",GXType.Int32,6,0)
        };
        Object[] prmT004515;
        prmT004515 = new Object[] {
        };
        Object[] prmT004516;
        prmT004516 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004517;
        prmT004517 = new Object[] {
        new ParDef("@ProCotDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00452", "SELECT [ProCotItem], [ProCotTipo], [ProCotDProdDsc], [ProCotDFactor], [ProCotCantidad], [ProCotCostoUNIT], [ProCotProdCod], [ProCotDProdCod] AS ProCotDProdCod FROM [POCOTIZADET] WITH (UPDLOCK) WHERE [ProCotProdCod] = @ProCotProdCod AND [ProCotItem] = @ProCotItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00452,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00453", "SELECT [ProCotItem], [ProCotTipo], [ProCotDProdDsc], [ProCotDFactor], [ProCotCantidad], [ProCotCostoUNIT], [ProCotProdCod], [ProCotDProdCod] AS ProCotDProdCod FROM [POCOTIZADET] WHERE [ProCotProdCod] = @ProCotProdCod AND [ProCotItem] = @ProCotItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00453,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00454", "SELECT [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00454,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00455", "SELECT [ProdCod] AS ProCotDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00455,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00456", "SELECT TM1.[ProCotItem], TM1.[ProCotTipo], TM1.[ProCotDProdDsc], TM1.[ProCotDFactor], TM1.[ProCotCantidad], TM1.[ProCotCostoUNIT], TM1.[ProCotProdCod], TM1.[ProCotDProdCod] AS ProCotDProdCod FROM [POCOTIZADET] TM1 WHERE TM1.[ProCotProdCod] = @ProCotProdCod and TM1.[ProCotItem] = @ProCotItem ORDER BY TM1.[ProCotProdCod], TM1.[ProCotItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00456,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00457", "SELECT [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00457,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00458", "SELECT [ProdCod] AS ProCotDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00458,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00459", "SELECT [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE [ProCotProdCod] = @ProCotProdCod AND [ProCotItem] = @ProCotItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00459,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004510", "SELECT TOP 1 [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE ( [ProCotProdCod] > @ProCotProdCod or [ProCotProdCod] = @ProCotProdCod and [ProCotItem] > @ProCotItem) ORDER BY [ProCotProdCod], [ProCotItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004510,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004511", "SELECT TOP 1 [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE ( [ProCotProdCod] < @ProCotProdCod or [ProCotProdCod] = @ProCotProdCod and [ProCotItem] < @ProCotItem) ORDER BY [ProCotProdCod] DESC, [ProCotItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004512", "INSERT INTO [POCOTIZADET]([ProCotItem], [ProCotTipo], [ProCotDProdDsc], [ProCotDFactor], [ProCotCantidad], [ProCotCostoUNIT], [ProCotProdCod], [ProCotDProdCod]) VALUES(@ProCotItem, @ProCotTipo, @ProCotDProdDsc, @ProCotDFactor, @ProCotCantidad, @ProCotCostoUNIT, @ProCotProdCod, @ProCotDProdCod)", GxErrorMask.GX_NOMASK,prmT004512)
           ,new CursorDef("T004513", "UPDATE [POCOTIZADET] SET [ProCotTipo]=@ProCotTipo, [ProCotDProdDsc]=@ProCotDProdDsc, [ProCotDFactor]=@ProCotDFactor, [ProCotCantidad]=@ProCotCantidad, [ProCotCostoUNIT]=@ProCotCostoUNIT, [ProCotDProdCod]=@ProCotDProdCod  WHERE [ProCotProdCod] = @ProCotProdCod AND [ProCotItem] = @ProCotItem", GxErrorMask.GX_NOMASK,prmT004513)
           ,new CursorDef("T004514", "DELETE FROM [POCOTIZADET]  WHERE [ProCotProdCod] = @ProCotProdCod AND [ProCotItem] = @ProCotItem", GxErrorMask.GX_NOMASK,prmT004514)
           ,new CursorDef("T004515", "SELECT [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] ORDER BY [ProCotProdCod], [ProCotItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004515,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004516", "SELECT [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004516,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004517", "SELECT [ProdCod] AS ProCotDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004517,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
